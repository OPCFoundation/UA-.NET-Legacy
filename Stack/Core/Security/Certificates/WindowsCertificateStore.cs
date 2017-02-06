/* Copyright (c) 1996-2017, OPC Foundation. All rights reserved.

   The source code in this file is covered under a dual-license scenario:
     - RCL: for OPC Foundation members in good-standing
     - GPL V2: everybody else

   RCL license terms accompanied with this source code. See http://opcfoundation.org/License/RCL/1.00/

   GNU General Public License as published by the Free Software Foundation;
   version 2 of the License are accompanied with this source code. See http://opcfoundation.org/License/GPLv2

   This source code is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;

namespace Opc.Ua
{    
    /// <summary>
    /// Provides access to a simple file based certificate store.
    /// </summary>
    public class WindowsCertificateStore : ICertificateStore
    {
        #region Constructors
        /// <summary>
        /// Initializes a store.
        /// </summary>
        public WindowsCertificateStore()
        {
        }
        #endregion
        
        #region IDisposable Members
        /// <summary>
        /// May be called by the application to clean up resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        /// <summary>
        /// Cleans up all resources held by the object.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            // clean up managed resources.
            if (disposing)
            {
                Close();
            }
        }
        #endregion

        #region ICertificateStore Members
        /// <summary cref="ICertificateStore.Open(string)" />
		/// <remarks>
		/// Syntax (items enclosed in [] are optional):
		///
		/// [\\HostName\]StoreType[\(ServiceName | UserSid)]\SymbolicName		
		///
		/// HostName     - the name of the machine where the store resides.
		/// SymbolicName - one of LocalMachine, CurrentUser, User or Service
		/// ServiceName  - the name of an NT service.
		/// UserSid      - the SID for a user account.
		/// SymbolicName - the symbolic name of the store (e.g. My, Root, Trust, CA, etc.).
		///
		/// Examples:
		///
		/// \\MYPC\LocalMachine\My
		/// CurrentUser\Trust
		/// \\MYPC\Service\My UA Server\UA Applications
		/// User\S-1-5-25\Root
		/// </remarks>
        public void Open(string location)
        {
            lock (m_lock)
            {   
	            Parse(location);
            }
        }

        /// <summary cref="ICertificateStore.Close()" />
        public void Close()
        {
            // do nothing.
        }

        /// <summary>
        /// Returns true if the store exists.
        /// </summary>
        public bool Exists
        {
            get
            {
                lock (m_lock)
                {
                    IntPtr hStore = IntPtr.Zero;

                    try
                    {
                        hStore = OpenStore(true, false, true);
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                    finally
                    {
                        if (hStore != IntPtr.Zero)
                        {
                            int result = NativeMethods.CertCloseStore(hStore, CERT_CLOSE_STORE_CHECK_FLAG);

                            if (result == 0)
                            {
                                Utils.Trace("Could not close certificate store. Error={0:X8}", Marshal.GetLastWin32Error());
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Deletes the store and all certificates contained within it.
        /// </summary>
        public void PermanentlyDeleteStore()
        {   
            lock (m_lock)
            {   
                // check for any certificates.
                X509Certificate2Collection certificates = Enumerate();

                if (certificates.Count > 0)
                {
                    throw ServiceResultException.Create(
                        StatusCodes.BadNotWritable,
                        "Cannot delete a store that contains certificates.\r\nType={0}, Name={1}", 
		                m_storeType,
		                m_symbolicName);
                }
                
	            IntPtr hStore = IntPtr.Zero;
	            IntPtr wszStoreName = IntPtr.Zero;

	            try
	            {
		            // allocate the store base name.
		            wszStoreName = DuplicateString(m_symbolicName);

                    hStore = NativeMethods.CertOpenStore(
                       new IntPtr(CERT_STORE_PROV_SYSTEM),
                       0, 
                       IntPtr.Zero,
                       GetFlags(m_storeType) | CERT_STORE_DELETE_FLAG, 
                       wszStoreName);

                    if (hStore == IntPtr.Zero)
                    {
                        int dwError = Marshal.GetLastWin32Error();

                        if (dwError != 0 && dwError != CRYPT_E_NOT_FOUND)
                        {
                            throw ServiceResultException.Create(
                                StatusCodes.BadUnexpectedError,
                                "Could not delete the certificate store.\r\nType={0}, Name={1}, Error={2:X8}", 
                                m_storeType,
                                m_symbolicName,
                                dwError);
                        }
                    }
	            }
	            finally
	            {
		            if (hStore != IntPtr.Zero)
                    {
                        int result = NativeMethods.CertCloseStore(hStore, CERT_CLOSE_STORE_CHECK_FLAG);

                        if (result == 0)
                        {
                            Utils.Trace("Could not close certificate store. Error={0:X8}", Marshal.GetLastWin32Error());
                        }
		            }

		            if (wszStoreName != IntPtr.Zero)
		            {
			            Marshal.FreeHGlobal(wszStoreName);
		            }
	            }
            }
        }

        /// <summary cref="ICertificateStore.Enumerate()" />
        public X509Certificate2Collection Enumerate()
        {
            lock (m_lock)
            {   
	            X509Certificate2Collection certificates = new X509Certificate2Collection();

	            IntPtr hStore = IntPtr.Zero;
	            X509Store store = null;

	            // find the certificate.
	            try
	            {
                    // open store.
                    hStore = OpenStore(true, false, false);

		            if (hStore == IntPtr.Zero)
		            {
                        return certificates;
		            }

		            // wrap it with a managed store.
                    store = new X509Store(hStore);
                    
		            // get the certificates.
		            for (int ii = 0; ii < store.Certificates.Count; ii++)
		            {
			            certificates.Add(store.Certificates[ii]);
		            }
	            }
	            finally
	            {
		            if (store != null)
		            {
			            store.Close();
		            }

		            if (hStore != IntPtr.Zero)
                    {
                        int result = NativeMethods.CertCloseStore(hStore, 0);

                        if (result == 0)
                        {
                            Utils.Trace("Could not close certificate store. Error={0:X8}", Marshal.GetLastWin32Error());
                        }
		            }
	            }

	            return certificates;
            }
        }
            
        /// <summary cref="ICertificateStore.Add(X509Certificate2)" />
        public void Add(X509Certificate2 certificate)
        {   
            if (certificate == null) throw new ArgumentNullException("certificate");
         
            lock (m_lock)
            {
                IntPtr hStore = IntPtr.Zero;
                IntPtr pCertContext = IntPtr.Zero;   
                
	            // get the DER encoded data.
	            byte[] buffer = certificate.GetRawCertData();
                IntPtr pData = Copy(buffer);

	            // find the certificate.
	            try
                {
                    // open store.
                    hStore = OpenStore(false, true, true);

                    // check for existing certificate.
                    pCertContext = FindCertificate(hStore, certificate.Thumbprint);

                    if (pCertContext != IntPtr.Zero)
                    {
                        throw ServiceResultException.Create(
                            StatusCodes.BadUnexpectedError,
                            "Certificate is already in the store.\r\nType={0}, Name={1}, Subject={2}",
                            m_storeType,
                            m_symbolicName,
                            certificate.Subject);
                    }

                    // add certificate.
                    Opc.Ua.CertificateFactory.AddCertificateToWindowsStore(
                        m_storeType == WindowsStoreType.LocalMachine, 
                        m_symbolicName, 
                        certificate);
	            }
	            finally
	            {
                    if (pData != IntPtr.Zero)
                    {
                        Marshal.FreeHGlobal(pData);
                    }

                    if (pCertContext != IntPtr.Zero)
                    {
                        NativeMethods.CertFreeCertificateContext(pCertContext);
                    }

                    if (hStore != IntPtr.Zero)
                    {
                        NativeMethods.CertCloseStore(hStore, 0);
                    }
	            }
            }
        }

        /// <summary cref="ICertificateStore.Delete(string)" />
        public bool Delete(string thumbprint)
        {
            lock (m_lock)
            {
	            IntPtr hStore = IntPtr.Zero;
                IntPtr pCertContext = IntPtr.Zero;   
                IntPtr pDupCertContext = IntPtr.Zero;

	            // find the certificate.
	            try
                {
                    // open store.
                    hStore = OpenStore(false, false, false);

                    if (hStore == IntPtr.Zero)
                    {
                        return false;
                    }

                    // find certificate in the store.
                    pCertContext = FindCertificate(hStore, thumbprint);

                    if (pCertContext == IntPtr.Zero)
                    {
                        return false;
                    }

                    // duplicate the certificate context.
                    pDupCertContext = NativeMethods.CertDuplicateCertificateContext(pCertContext);

                    if (pDupCertContext == IntPtr.Zero)
                    {
                        int dwError = Marshal.GetLastWin32Error();

                        throw ServiceResultException.Create(
                            StatusCodes.BadUnexpectedError,
                            "Could not duplicate the certificate context. Error={0:X8}",
                            dwError);
                    }

                    // verify that everything is ok.
                    CERT_CONTEXT certificate1 = (CERT_CONTEXT)Marshal.PtrToStructure(pCertContext, typeof(CERT_CONTEXT));
                    CERT_CONTEXT certificate2 = (CERT_CONTEXT)Marshal.PtrToStructure(pDupCertContext, typeof(CERT_CONTEXT));

                    int bResult = NativeMethods.CertCompareCertificate(
                      X509_ASN_ENCODING,
                      certificate1.pCertInfo,
                      certificate2.pCertInfo);

                    if (bResult == 0)
                    {
                        throw ServiceResultException.Create(
                            StatusCodes.BadUnexpectedError,
                            "Duplicated certificate does not match original. Thumbprint={0}",
                            thumbprint);
                    }

                    // delete certificate.
                    bResult = NativeMethods.CertDeleteCertificateFromStore(pDupCertContext);

                    if (bResult == 0)
                    {
                        int dwError = Marshal.GetLastWin32Error();

                        throw ServiceResultException.Create(
                            StatusCodes.BadUnexpectedError,
                            "Could not delete the certificate from the store.\r\nType={0}, Name={1}, Error={2:X8}",
                            m_storeType,
                            m_symbolicName,
                            dwError);
                    }

                    pDupCertContext = IntPtr.Zero;

		            return true;
	            }
	            finally
	            {
                    if (pCertContext != IntPtr.Zero)
                    {
                        NativeMethods.CertFreeCertificateContext(pCertContext);
                    }

                    if (pDupCertContext != IntPtr.Zero)
                    {
                        NativeMethods.CertFreeCertificateContext(pDupCertContext);
                    }

		            if (hStore != IntPtr.Zero)
                    {
                        NativeMethods.CertCloseStore(hStore, 0);
		            }
	            }
            }
        }
        
        /// <summary cref="ICertificateStore.FindByThumbprint(string)" />
        public X509Certificate2 FindByThumbprint(string thumbprint)
        {
            lock (m_lock)
            {
                IntPtr hStore = IntPtr.Zero;
                IntPtr pCertContext = IntPtr.Zero;   
                IntPtr pDupCertContext = IntPtr.Zero;

	            // find the certificate.
	            try
                {
                    // open store.
                    hStore = OpenStore(true, false, false);

                    if (hStore == IntPtr.Zero)
                    {
                        return null;
                    }

                    // find existing certificate.
                    pCertContext = FindCertificate(hStore, thumbprint);

                    if (pCertContext == IntPtr.Zero)
                    {
                        return null;
                    }

                    // duplicate the certificate context.
                    pDupCertContext = NativeMethods.CertDuplicateCertificateContext(pCertContext);

                    if (pDupCertContext == IntPtr.Zero)
                    {
                        int dwError = Marshal.GetLastWin32Error();

                        throw ServiceResultException.Create(
                            StatusCodes.BadUnexpectedError,
                            "Could not duplicate the certificate context. Error={0:X8}",
                            dwError);
                    }

                    // create the certificate.
                    X509Certificate2 certificate = new X509Certificate2(pDupCertContext);
                    return certificate;
	            }
	            finally
                {
                    if (pCertContext != IntPtr.Zero)
                    {
                        NativeMethods.CertFreeCertificateContext(pCertContext);
                    }

                    if (pDupCertContext != IntPtr.Zero)
                    {
                        NativeMethods.CertFreeCertificateContext(pDupCertContext);
                    }
                    
                    if (hStore != IntPtr.Zero)
                    {
                        NativeMethods.CertCloseStore(hStore, 0);
                    }
	            }
            }
        }
        
        /// <summary cref="ICertificateStore.SupportsAccessControl" />
        public bool SupportsAccessControl
        {
            get { return false; }
        }

        /// <summary cref="ICertificateStore.GetAccessRules()" />
        public IList<ApplicationAccessRule> GetAccessRules()
        {
            throw new NotSupportedException();
        }
        
        /// <summary cref="ICertificateStore.SetAccessRules(IList{ApplicationAccessRule},bool)" />
        public void SetAccessRules(IList<ApplicationAccessRule> rules, bool replaceExisting)
        {
            throw new NotSupportedException();
        }
        
        /// <summary cref="ICertificateStore.SupportsCertificateAccessControl" />
        public bool SupportsCertificateAccessControl
        {
            get { return true; }
        }
        
        /// <summary cref="ICertificateStore.SupportsPrivateKeys" />
        public bool SupportsPrivateKeys
        {
            get { return true; }
        }
        
        /// <summary cref="ICertificateStore.GetPrivateKeyFilePath" />
        public string GetPrivateKeyFilePath(string thumbprint)
        {
            lock (m_lock)
            {
                IntPtr hStore = IntPtr.Zero;

                try
                {
                    // open store.
                    hStore = OpenStore(true, false, true);

                    // get the container information.
                    CspKeyContainerInfo container = GetCspKeyContainerInfo(hStore, thumbprint, m_symbolicName, m_storeType);

                    if (container == null)
                    {
                        return null;
                    }

                    // get the key file.
                    FileInfo keyFile = GetKeyFileInfo(
                        container.UniqueKeyContainerName,
                        m_storeType,
                        m_serviceNameOrUserSid);

                    // return the full path.
                    return keyFile.FullName;
                }
                finally
                {
                    if (hStore != IntPtr.Zero)
                    {
                        NativeMethods.CertCloseStore(hStore, 0);
                    }
                }
            }
        }

        /// <summary cref="ICertificateStore.GetAccessRules(string)" />
        public IList<ApplicationAccessRule> GetAccessRules(string thumbprint)
        {
            lock (m_lock)
            {  
	            IntPtr hStore = IntPtr.Zero;

	            // find the certificate.
	            try
                {
                    // open store.
                    hStore = OpenStore(true, false, true);

		            // get the container information.
                    CspKeyContainerInfo container = GetCspKeyContainerInfo(hStore, thumbprint, m_symbolicName, m_storeType);

                    if (container == null)
                    {
                        throw ServiceResultException.Create(
                            StatusCodes.BadUnexpectedError,
                            "Could not get CspKeyContainerInfo for certificate (does the certificate exist?).\r\nType={0}, Name={1}",
                            m_storeType,
                            m_symbolicName);
                    }

		            // get the key file.
		            FileInfo keyFile = GetKeyFileInfo(
			            container.UniqueKeyContainerName, 
			            m_storeType, 
			            m_serviceNameOrUserSid);

		            // get the access rules on the file.
		            return ApplicationAccessRule.GetAccessRules(keyFile.FullName);
	            }
	            finally
	            {
		            if (hStore != IntPtr.Zero)
                    {
                        NativeMethods.CertCloseStore(hStore, 0);
		            }
	            }
            }
        }
        
        /// <summary cref="ICertificateStore.SetAccessRules(string, IList{ApplicationAccessRule},bool)" />
        public void SetAccessRules(string thumbprint, IList<ApplicationAccessRule> rules, bool replaceExisting)
        {
            lock (m_lock)
            {   
	            IntPtr hStore = IntPtr.Zero;

	            try
                {
                    // open store.
                    hStore = OpenStore(true, false, true);

		            // get the container information.
                    CspKeyContainerInfo container = GetCspKeyContainerInfo(hStore, thumbprint, m_symbolicName, m_storeType);

                    if (container == null)
                    {
                        throw ServiceResultException.Create(
                            StatusCodes.BadUnexpectedError,
                            "Could not get CspKeyContainerInfo for certificate (does the certificate exist?).\r\nType={0}, Name={1}",
                            m_storeType,
                            m_symbolicName);
                    }

		            // get the key file.
		            FileInfo keyFile = GetKeyFileInfo(
			            container.UniqueKeyContainerName, 
			            m_storeType, 
			            m_serviceNameOrUserSid);

		            // set the access rules on the file.
		            ApplicationAccessRule.SetAccessRules(keyFile.FullName, rules, replaceExisting);
	            }
	            finally
	            {
		            if (hStore != IntPtr.Zero)
		            {
                        NativeMethods.CertCloseStore(hStore, 0);
		            }
	            }
            }
        }

        /// <summary>
        /// Whether the store support CRLs.
        /// </summary>
        public bool SupportsCRLs { get { return false; } }

        /// <summary>
        /// Checks if issuer has revoked the certificate.
        /// </summary>
        public StatusCode IsRevoked(X509Certificate2 issuer, X509Certificate2 certificate)
        {
            return StatusCodes.BadNotSupported;
        }

        /// <summary>
        /// Returns the CRLs in the store.
        /// </summary>
        public List<X509CRL> EnumerateCRLs()
        {
            return new List<X509CRL>();
        }

        /// <summary>
        /// Returns the CRLs for the issuer.
        /// </summary>
        public List<X509CRL> EnumerateCRLs(X509Certificate2 issuer)
        {
            return new List<X509CRL>();
        }

        /// <summary>
        /// Adds a CRL to the store.
        /// </summary>
        public void AddCRL(X509CRL crl)
        {
            throw new ServiceResultException(StatusCodes.BadNotSupported);
        }

        /// <summary>
        /// Removes a CRL from the store.
        /// </summary>
        public bool DeleteCRL(X509CRL crl)
        {
            throw new ServiceResultException(StatusCodes.BadNotSupported);
        }
        #endregion

        #region PInvoke Declarations
        private const int ERROR_MORE_DATA = 234;

        // Location of the system store:
        private const int CERT_SYSTEM_STORE_LOCATION_SHIFT = 16;

        //  Registry: HKEY_CURRENT_USER or HKEY_LOCAL_MACHINE
        private const int CERT_SYSTEM_STORE_CURRENT_USER_ID = 1;
        private const int CERT_SYSTEM_STORE_LOCAL_MACHINE_ID = 2;
        //  Registry: HKEY_LOCAL_MACHINE\Software\Microsoft\Cryptography\Services
        private const int CERT_SYSTEM_STORE_CURRENT_SERVICE_ID = 4;
        private const int CERT_SYSTEM_STORE_SERVICES_ID = 5;
        //  Registry: HKEY_USERS
        private const int CERT_SYSTEM_STORE_USERS_ID = 6;

        private const int CERT_SYSTEM_STORE_CURRENT_USER = (CERT_SYSTEM_STORE_CURRENT_USER_ID << CERT_SYSTEM_STORE_LOCATION_SHIFT);
        private const int CERT_SYSTEM_STORE_LOCAL_MACHINE = (CERT_SYSTEM_STORE_LOCAL_MACHINE_ID << CERT_SYSTEM_STORE_LOCATION_SHIFT);
        private const int CERT_SYSTEM_STORE_CURRENT_SERVICE = (CERT_SYSTEM_STORE_CURRENT_SERVICE_ID << CERT_SYSTEM_STORE_LOCATION_SHIFT);
        private const int CERT_SYSTEM_STORE_SERVICES = (CERT_SYSTEM_STORE_SERVICES_ID << CERT_SYSTEM_STORE_LOCATION_SHIFT);
        private const int CERT_SYSTEM_STORE_USERS = (CERT_SYSTEM_STORE_USERS_ID << CERT_SYSTEM_STORE_LOCATION_SHIFT);
        
        private const int CERT_STORE_READONLY_FLAG = 0x00008000;
        private const int CERT_STORE_OPEN_EXISTING_FLAG = 0x00004000;
        private const int CERT_STORE_CREATE_NEW_FLAG = 0x00002000;
        private const int CERT_STORE_DELETE_FLAG = 0x00000010;

        private const int CERT_STORE_PROV_SYSTEM_W = 10;
        private const int CERT_STORE_PROV_SYSTEM = CERT_STORE_PROV_SYSTEM_W;
                      
        private const int CERT_CLOSE_STORE_FORCE_FLAG = 0x00000001;
        private const int CERT_CLOSE_STORE_CHECK_FLAG = 0x00000002;

        private const int CERT_SHA1_HASH_PROP_ID = 3;
                
        [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Unicode)]
        private struct CRYPT_KEY_PROV_INFO {
            /*
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pwszContainerName;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pwszProvName;
             * */
            public IntPtr pwszContainerName;
            public IntPtr pwszProvName;
            public int dwProvType;
            public int dwFlags;
            public int cProvParam;
            public IntPtr rgProvParam;
            public int dwKeySpec;
        }
        
        [StructLayout(LayoutKind.Sequential)]
        private struct CRYPTOAPI_BLOB 
        {
            public int cbData;
            public IntPtr pbData;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct CRYPT_ALGORITHM_IDENTIFIER 
        {
            [MarshalAs(UnmanagedType.LPStr)]
            public string pszObjId;
            public CRYPTOAPI_BLOB Parameters;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct CRYPT_BIT_BLOB 
        {
            public int cbData;
            public IntPtr pbData;
            int cUnusedBits;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct CERT_PUBLIC_KEY_INFO 
        {
            public CRYPT_ALGORITHM_IDENTIFIER Algorithm;
            public CRYPT_BIT_BLOB PublicKey;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct CERT_INFO
        {
            public int                         dwVersion;
            public CRYPTOAPI_BLOB              SerialNumber;
            public CRYPT_ALGORITHM_IDENTIFIER  SignatureAlgorithm;
            public CRYPTOAPI_BLOB              Issuer;
            public System.Runtime.InteropServices.ComTypes.FILETIME NotBefore;
            public System.Runtime.InteropServices.ComTypes.FILETIME NotAfter;
            public CRYPTOAPI_BLOB              Subject;
            public CERT_PUBLIC_KEY_INFO        SubjectPublicKeyInfo;
            public CRYPT_BIT_BLOB              IssuerUniqueId;
            public CRYPT_BIT_BLOB              SubjectUniqueId;
            public int                         cExtension;
            public IntPtr                      rgExtension;
        }
 
        [StructLayout(LayoutKind.Sequential)]
        private struct CERT_CONTEXT
        {
            public int dwCertEncodingType;
            public IntPtr pbCertEncoded;
            public int cbCertEncoded;
            public IntPtr pCertInfo;
            public IntPtr hCertStore;
        }

        private const int CERT_KEY_PROV_INFO_PROP_ID = 2;

        private const int X509_ASN_ENCODING = 0x00000001;
        private const int CERT_STORE_ADD_NEW = 1;

        private const int CRYPT_E_NOT_FOUND = -0x7FF6DFFC; // 0x80092004
        
        // stores the results when enumerating certificate stores.
        [StructLayout(LayoutKind.Sequential)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1049:TypesThatOwnNativeResourcesShouldBeDisposable")]
        private struct EnumResults
        {
	        public int Count;
	        public int Capacity;
	        public IntPtr Names;
        };
        
		private delegate int EnumStoreCallbackDelegate(
           IntPtr pvSystemStore,
           uint   dwFlags,
           IntPtr pStoreInfo,
           IntPtr pvReserved,
           IntPtr pvArg);

        /// <summary>
        /// The native methods used by the class.
        /// </summary>
        private static class NativeMethods
        {            
            [DllImport("Crypt32.dll")]
            public static extern int CertCompareCertificate(
                int dwCertEncodingType,
                IntPtr pCertId1,
                IntPtr pCertId2);

            [DllImport("Crypt32.dll")]
            public static extern IntPtr CertEnumCertificatesInStore(
                IntPtr hCertStore,
                IntPtr pPrevCertContext);

            [DllImport("Crypt32.dll")]
            public static extern IntPtr CertDuplicateCertificateContext(
                IntPtr pCertContext);

            [DllImport("Crypt32.dll")]
            public static extern IntPtr CertOpenStore(
                IntPtr lpszStoreProvider,
                uint dwEncodingType,
                IntPtr hCryptProv,
                uint dwFlags,
                IntPtr pvPara);

            [DllImport("Crypt32.dll")]
            public static extern int CertUnregisterSystemStore(
                IntPtr pvSystemStore,
                uint dwFlags);

            [DllImport("Crypt32.dll")]
            public static extern int CertCloseStore(
                IntPtr hCertStore,
                uint dwFlags);

            [DllImport("Crypt32.dll")]
            public static extern int CertGetCertificateContextProperty(
                IntPtr pCertContext,
                int dwPropId,
                IntPtr pvData,
                ref int pcbData);
            
            
            [DllImport("Crypt32.dll")]
            public static extern int CertAddEncodedCertificateToStore(
                IntPtr hCertStore,
                int dwCertEncodingType,
                IntPtr pbCertEncoded,
                int cbCertEncoded,
                int dwAddDisposition,
                out IntPtr ppCertContext);
            
            [DllImport("Crypt32.dll")]
            public static extern int CertFreeCertificateContext(IntPtr pCertContext);
                    
            [DllImport("Crypt32.dll")]
            public static extern int CertDeleteCertificateFromStore(IntPtr pCertContext);

            [DllImport("Crypt32.dll")]
            public static extern int CertEnumSystemStore(
                uint dwFlags,
                IntPtr pvSystemStoreLocationPara,
                IntPtr pvArg,
                EnumStoreCallbackDelegate pfnEnum);
        }

        // called when a certificate store is found.
        static int EnumStoreCallback(
           IntPtr pvSystemStore,
           uint   dwFlags,
           IntPtr pStoreInfo,
           IntPtr pvReserved,
           IntPtr pvArg)
        {
            try
            {
	            EnumResults pResults = (EnumResults)Marshal.PtrToStructure(pvArg, typeof(EnumResults));
                
                IntPtr[] names = null;

	            if (pResults.Count >= pResults.Capacity)
	            {
		            int dwCapacity = pResults.Capacity+10;
                    names = new IntPtr[dwCapacity];

                    if (pResults.Count > 0 && pResults.Names != IntPtr.Zero)
                    {
                        Marshal.Copy(pResults.Names, names, 0, pResults.Count);  
                        Marshal.FreeHGlobal(pResults.Names);
                        pResults.Names = IntPtr.Zero;
                    }

		            pResults.Names = Marshal.AllocHGlobal(dwCapacity*IntPtr.Size);
		            pResults.Capacity = dwCapacity;
	            }
                else
                {
                    names = new IntPtr[pResults.Capacity];
                    Marshal.Copy(pResults.Names, names, 0, pResults.Count);
                }

                string storeName = Marshal.PtrToStringUni(pvSystemStore);
                names[pResults.Count++] = DuplicateString(storeName);

                Marshal.Copy(names, 0, pResults.Names, pResults.Count);
                Marshal.StructureToPtr(pResults, pvArg, false);

	            return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        #endregion 

        #region Public Methods
        /// <summary>
        /// Enumerates the available windows certificate store.
        /// </summary>
        public static IList<WindowsCertificateStore> EnumerateStores(
	        WindowsStoreType storeType, 
	        string           hostName, 
	        string           serviceNameOrUserSid)
        {
	        List<WindowsCertificateStore> stores = new List<WindowsCertificateStore>();

	        EnumResults results = new EnumResults();
            GCHandle hResults = GCHandle.Alloc(results, GCHandleType.Pinned);
	        IntPtr wszStoreBaseName = IntPtr.Zero;

	        try
	        {
		        uint dwFlags = 0;

		        // contruct base name for the store to enumerate.
		        string storeBaseName = null;

		        if (!String.IsNullOrEmpty(hostName) && hostName != ".")
		        {
			        storeBaseName = Utils.Format("{0}", hostName);
		        }

		        if (!String.IsNullOrEmpty(serviceNameOrUserSid))
		        {
			        if (!String.IsNullOrEmpty(storeBaseName))
			        {
				        storeBaseName = Utils.Format("{0}\\{1}", storeBaseName, serviceNameOrUserSid);
			        }
			        else
			        {
				        storeBaseName = serviceNameOrUserSid;
			        }
		        }

		        // allocate the store base name.
		        wszStoreBaseName = DuplicateString(storeBaseName);

		        // set the flags based on store type.
		        dwFlags |= GetFlags(storeType);

		        // get list of names.
		        results.Capacity = 10;
                results.Count = 0;
		        results.Names = Marshal.AllocHGlobal(results.Capacity*IntPtr.Size);

                IntPtr pResults = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(EnumResults)));
                Marshal.StructureToPtr(results, pResults, false);

                int bResult = NativeMethods.CertEnumSystemStore(
			        dwFlags,
			        wszStoreBaseName, 
			        pResults,
			        EnumStoreCallback);

                int dwError = Marshal.GetLastWin32Error();

                results = (EnumResults)Marshal.PtrToStructure(pResults, typeof(EnumResults));
                Marshal.DestroyStructure(pResults, typeof(EnumResults));
                Marshal.FreeHGlobal(pResults);
                
		        if (bResult == 0)
		        {
		            throw ServiceResultException.Create(
                        StatusCodes.BadUnexpectedError,
                        "Can't enumerate the contents of the certificate store.\r\nType={0}, HostName={1}, ServiceNameOrUserSid={2}, Error={3:X8}", 
				        storeType,
				        hostName,
				        serviceNameOrUserSid,
				        dwError);
		        }
        		
		        // copy names.
                IntPtr[] names = new IntPtr[results.Count];
                Marshal.Copy(results.Names, names, 0, results.Count);  

		        for (uint ii = 0; ii < results.Count; ii++)
		        {
			        IntPtr wszSymbolicName = names[ii];

                    IntPtr hStore = NativeMethods.CertOpenStore(
			           new IntPtr(CERT_STORE_PROV_SYSTEM),
			           0,
                       IntPtr.Zero,
                       GetFlags(storeType) | CERT_STORE_READONLY_FLAG | CERT_STORE_OPEN_EXISTING_FLAG, 
			           wszSymbolicName);

			        if (hStore == IntPtr.Zero)
			        {
				        continue;
			        }

                    int result = NativeMethods.CertCloseStore(hStore, 0);

                    if (result == 0)
                    {
                        Utils.Trace("Could not close certificate store. Error={0:X8}", Marshal.GetLastWin32Error());
                    }

			        WindowsCertificateStore store = new WindowsCertificateStore();

			        store.m_symbolicName = Marshal.PtrToStringUni(wszSymbolicName);
			        store.m_storeType = storeType;
			        store.m_displayName = store.m_symbolicName;

			        // extract the store name from the end of the symbolic name.
			        int index = store.m_symbolicName.LastIndexOf('\\');

			        if (index >= 0)
			        {
				        store.m_displayName = store.m_symbolicName.Substring(index+1);
				        store.m_serviceNameOrUserSid = store.m_symbolicName.Substring(0, index);
			        }

			        // check if the service name or user sid has a host name prefix.
			        if (!String.IsNullOrEmpty(store.m_serviceNameOrUserSid))
			        {
				        index = store.m_serviceNameOrUserSid.LastIndexOf('\\');

				        if (index >= 0)
				        {
					        store.m_hostName = store.m_serviceNameOrUserSid.Substring(0, index);
					        store.m_serviceNameOrUserSid = store.m_serviceNameOrUserSid.Substring(index+1);
				        }
			        }

			        // remove the leading '\\' from the host name.
			        if (!String.IsNullOrEmpty(store.m_hostName))
			        {
				        if (store.m_hostName.StartsWith("\\\\", StringComparison.Ordinal))
				        {
					        store.m_hostName = store.m_hostName.Substring(2);
				        }
			        }

			        store.m_displayName = GetStoreDisplayName(store.m_storeType, store.m_serviceNameOrUserSid, store.m_symbolicName);

			        // add the store to the list.
			        stores.Add(store);
		        }
	        }
	        finally
	        {
		        if (results.Names != IntPtr.Zero)
		        {
                    IntPtr[] names = new IntPtr[results.Count];
                    Marshal.Copy(results.Names, names, 0, results.Count);  

			        for (uint ii = 0; ii < names.Length; ii++)
			        {
				        Marshal.FreeHGlobal(names[ii]);
			        }

			        Marshal.FreeHGlobal(results.Names);
		        }

                if (hResults.IsAllocated)
                {
                    hResults.Free();
                }

		        if (wszStoreBaseName != IntPtr.Zero)
		        {
			        Marshal.FreeHGlobal(wszStoreBaseName);
		        }
	        }

	        return stores;
        }
        
        /// <summary>
        /// Returns the string representation of the store.
        /// </summary>
        public string Format()
        {
	        StringBuilder buffer = new StringBuilder();

	        if (!String.IsNullOrEmpty(m_hostName))
	        {
		        buffer.Append("\\\\");
		        buffer.Append(m_hostName);
		        buffer.Append("\\");
	        }

	        switch (m_storeType)
	        {
		        case WindowsStoreType.LocalMachine:
		        {
			        buffer.Append("LocalMachine");
			        break;
		        }

		        case WindowsStoreType.CurrentUser:
		        {
			        buffer.Append("CurrentUser");
			        break;
		        }

		        case WindowsStoreType.User:
		        {
			        buffer.Append("User");
			        break;
		        }

		        case WindowsStoreType.Service:
		        {
			        buffer.Append("Service");
			        break;
		        }
	        }

	        buffer.Append("\\");

	        if (!String.IsNullOrEmpty(m_serviceNameOrUserSid))
	        {
		        buffer.Append(m_serviceNameOrUserSid);
		        buffer.Append("\\");
	        }

	        buffer.Append(m_symbolicName);

	        return buffer.ToString();
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Opens the certificate store.
        /// </summary>
        /// <param name="readOnly">If true the store is opened as read only.</param>
        /// <param name="createAlways">If true the store is created if it does not exist.</param>
        /// <param name="throwIfNotExist">If true an exception is thrown if the store does not exist.</param>
        /// <returns>A handle to the store which must be closed by the caller.</returns>
        private IntPtr OpenStore(bool readOnly, bool createAlways, bool throwIfNotExist)
        {
            IntPtr wszStoreName = IntPtr.Zero;
            IntPtr hStore = IntPtr.Zero;

            try
            {
                // check for a valid name.
                if (String.IsNullOrEmpty(m_symbolicName))
                {
                    if (throwIfNotExist)
                    {
                        throw ServiceResultException.Create(
                            StatusCodes.BadConfigurationError,
                            "WindowsCertificateStore object has not been initialized properly.");
                    }

                    return IntPtr.Zero;
                }

	            // allocate the store base name.
	            wszStoreName = DuplicateString(m_symbolicName);

                uint dwFlags = GetFlags(m_storeType);

                if (readOnly)
                {
                    dwFlags |= CERT_STORE_READONLY_FLAG;
                }

                // open or create the store.
                if (!readOnly && createAlways)
                {
                    hStore = NativeMethods.CertOpenStore(
                       new IntPtr(CERT_STORE_PROV_SYSTEM),
                       0,
                       IntPtr.Zero,
                       dwFlags | CERT_STORE_CREATE_NEW_FLAG,
                       wszStoreName);
                }
                else
                {
                    hStore = NativeMethods.CertOpenStore(
                       new IntPtr(CERT_STORE_PROV_SYSTEM),
                       0,
                       IntPtr.Zero,
                       dwFlags | CERT_STORE_OPEN_EXISTING_FLAG,
                       wszStoreName);
                }

                // check result.
	            if (hStore == IntPtr.Zero)
	            {
                    int dwError = Marshal.GetLastWin32Error();

                    // try to open an existing store if create failed.
                    if (!readOnly && createAlways)
                    {
                        hStore = NativeMethods.CertOpenStore(
                           new IntPtr(CERT_STORE_PROV_SYSTEM),
                           0,
                           IntPtr.Zero,
                           dwFlags | CERT_STORE_OPEN_EXISTING_FLAG,
                           wszStoreName);
                    }

                    if (hStore == IntPtr.Zero)
                    {
                        // throw error.
                        if (throwIfNotExist)
                        {
                            throw ServiceResultException.Create(
                                StatusCodes.BadUnexpectedError,
                                "Could not open the certificate store.\r\nType={0}, Name={1}, Error={2:X8}",
                                m_storeType,
                                m_symbolicName,
                                dwError);
                        }

                        // graceful failure if store not found.
                        return IntPtr.Zero;
                    }
	            }

                // return the handle.
                return hStore;
            }
            finally
            {
                if (wszStoreName != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(wszStoreName);
                }
            }
        }

        /// <summary>
        /// Makes an unmanaged copy of an array.
        /// </summary>
        private static IntPtr Copy(byte[] bytes)
        {
            IntPtr pCopy = Marshal.AllocHGlobal(bytes.Length);
            Marshal.Copy(bytes, 0, pCopy, bytes.Length);
            return pCopy;
        }

        /// <summary>
        /// Gets the thumbprint from the certificate context.
        /// </summary>
        /// <param name="pCertContext">The certificate context.</param>
        /// <returns>The thumbprint of the certificate.</returns>
        private static string GetThumbprint(IntPtr pCertContext)
        {
            IntPtr pData = IntPtr.Zero;
            int dwDataSize = 0;

            try
            {
                if (pCertContext == IntPtr.Zero)
                {
                    return String.Empty;
                }

                int bResult = NativeMethods.CertGetCertificateContextProperty(
                    pCertContext,
                    CERT_SHA1_HASH_PROP_ID,
                    IntPtr.Zero,
                    ref dwDataSize);

                if (bResult == 0)
                {
                    int dwError = Marshal.GetLastWin32Error();

                    if (dwError != ERROR_MORE_DATA)
                    {
                        throw ServiceResultException.Create(
                            StatusCodes.BadUnexpectedError,
                            "Could not get the size of the thumbprint from the certificate context. Error={0:X8}",
                            dwError);
                    }
                }

                pData = Marshal.AllocHGlobal(dwDataSize);

                bResult = NativeMethods.CertGetCertificateContextProperty(
                   pCertContext,
                   CERT_SHA1_HASH_PROP_ID,
                   pData,
                   ref dwDataSize);

                if (bResult == 0)
                {
                    int dwError = Marshal.GetLastWin32Error();

                    throw ServiceResultException.Create(
                        StatusCodes.BadUnexpectedError,
                        "Could not get the thumbprint from the certificate context. Error={0:X8}",
                        dwError);
                }

                byte[] thumprint = new byte[dwDataSize];
                Marshal.Copy(pData, thumprint, 0, thumprint.Length);
                return Utils.ToHexString(thumprint).ToUpperInvariant();
            }
            finally
            {
                if (pData != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(pData);
                }
            }
        }

        /// <summary>
        /// Finds a certificate in the store.
        /// </summary>
        /// <param name="hStore">The handle for the store to search.</param>
        /// <param name="thumbprint">The thumbprint of the certificate to find.</param>
        /// <returns>The context for the matching certificate.</returns>
        private static IntPtr FindCertificate(IntPtr hStore, string thumbprint)
        {
            IntPtr pCertContext = NativeMethods.CertEnumCertificatesInStore(hStore, IntPtr.Zero);

            while (pCertContext != IntPtr.Zero)
            {
                string targetThumbprint = GetThumbprint(pCertContext);

                if (targetThumbprint == thumbprint)
                {
                    break;
                }

                pCertContext = NativeMethods.CertEnumCertificatesInStore(hStore, pCertContext);
            }

            return pCertContext;
        }

        /// <summary>
        /// finds the key file.
        /// </summary>
        private static FileInfo GetKeyFileInfo(string uniqueId, WindowsStoreType storeType, string userSid)
        {
            StringBuilder rootDir = new StringBuilder();

	        switch (storeType)
	        {
		        case WindowsStoreType.LocalMachine:
		        case WindowsStoreType.Service:
		        {
			        rootDir.Append(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));
			        rootDir.Append("\\Microsoft\\Crypto\\RSA\\MachineKeys");
			        break;
		        }

		        case WindowsStoreType.CurrentUser:
		        {
			        rootDir.Append(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
			        rootDir.Append("\\Microsoft\\Crypto\\RSA\\");
			        break;
		        }

		        case WindowsStoreType.User:
		        {
			        // assume other users are in the same location as the AllUser folder.
			        string startDir = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
			        DirectoryInfo info = new DirectoryInfo(startDir);

			        // translate the sid to a user name.
			        SecurityIdentifier sid = new SecurityIdentifier(userSid);
			        string userName = sid.Translate(typeof(NTAccount)).ToString();

			        int index = userName.LastIndexOf('\\');

			        if (index != -1)
			        {
				        userName = userName.Substring(index+1);
			        }

			        // construct a new dir using the user name.
			        rootDir.Append(info.Parent.Parent.FullName);
			        rootDir.AppendFormat("\\{0}\\{1}\\Microsoft\\Crypto\\RSA\\", userName, info.Parent.Name);
			        break;
		        }
	        }

	        // open directory.
	        DirectoryInfo directory = new DirectoryInfo(rootDir.ToString());

	        if (!directory.Exists)
	        {
                throw new InvalidOperationException(
			        Utils.Format("Could not find directory containing key file.\r\nKey={0}, Directory={1}", 
			        uniqueId,
			        directory.FullName));
	        }
        		
	        // file the key file.
	        IList<FileInfo> files = directory.GetFiles(uniqueId, SearchOption.AllDirectories);

	        if (files.Count == 0)
	        {
                throw new InvalidOperationException(
			        Utils.Format("Could not find private key file.\r\nKey={0}, Directory={1}", 
			        uniqueId,
			        directory.FullName));
	        }
        		
	        if (files.Count > 1)
	        {
		        throw new InvalidOperationException(
			        Utils.Format("Multiple key files with the same name exist.\r\nKey={0}, Directory={1}", 
			        uniqueId,
			        directory.FullName));
	        }

	        // return the complete path.
	        return files[0];
        }

        /// <summary>
        /// returns the information for the key container associated with the certificate.
        /// </summary>
        private static CspKeyContainerInfo GetCspKeyContainerInfo(
	        IntPtr           hStore,
	        string           thumbprint, 
	        string           symbolicName, 
	        WindowsStoreType storeType)
        {
	        CRYPT_KEY_PROV_INFO pInfo;
            IntPtr pData = IntPtr.Zero;
            IntPtr pCertContext = IntPtr.Zero;

	        try
            {
                // get the certificates.
                pCertContext = FindCertificate(hStore, thumbprint);

                if (pCertContext == IntPtr.Zero)
                {
                    return null;
                }

		        // get size of the private key provider info struct.
		        int dwInfoSize = 0;

                int bResult = NativeMethods.CertGetCertificateContextProperty(
                    pCertContext,
			        CERT_KEY_PROV_INFO_PROP_ID,
			        pData,
			        ref dwInfoSize);

		        if (bResult == 0)
                {
                    // property must not exist.
                    return null;
		        }

		        // get private key provider info.
		        pData = Marshal.AllocHGlobal(dwInfoSize);

                bResult = NativeMethods.CertGetCertificateContextProperty(
                    pCertContext,
			        CERT_KEY_PROV_INFO_PROP_ID,
			        pData,
			        ref dwInfoSize);
                
		        if (bResult == 0)
		        {
			        int dwError = Marshal.GetLastWin32Error();
                    
		            throw ServiceResultException.Create(
                        StatusCodes.BadUnexpectedError,
			            "Could not get the provider info for certificate. Error={0:X8}", 
			            dwError);
		        }
                
                try
                {
                    pInfo = (CRYPT_KEY_PROV_INFO)Marshal.PtrToStructure(pData, typeof(CRYPT_KEY_PROV_INFO));
                }
                finally
                {
                    Marshal.DestroyStructure(pData, typeof(CRYPT_KEY_PROV_INFO));
                }
                
                string name1 = Marshal.PtrToStringUni(pInfo.pwszProvName);
                string name2 = Marshal.PtrToStringUni(pInfo.pwszContainerName);
                
                Marshal.FreeHGlobal(pData);
                pData = IntPtr.Zero;
                
		        // create the crypto service provide parameters.
		        CspParameters cps = new CspParameters(
			        pInfo.dwProvType, 
			        name1, 
			        name2);

		        cps.Flags = CspProviderFlags.UseExistingKey;

		        if (storeType != WindowsStoreType.CurrentUser)
		        {
			        cps.Flags |= CspProviderFlags.UseMachineKeyStore;
		        }
                
		        // get the container information.
		        CspKeyContainerInfo container = new CspKeyContainerInfo(cps);

		        // get the access rules on the file.
		        return container;
	        }
	        finally
            {
                if (pCertContext != IntPtr.Zero)
                {
                    NativeMethods.CertFreeCertificateContext(pCertContext);
                }

		        if (pData != IntPtr.Zero)
		        {
                    Marshal.FreeHGlobal(pData);
		        }
	        }
        }

        /// <summary>
        /// Returns the display name for the certificate store.
        /// </summary>
        private static string GetStoreDisplayName(WindowsStoreType storeType, string serviceNameOrUserSid, string storeName)
        {
	        int index = storeName.LastIndexOf('\\');

	        if (index != -1)
	        {
		        storeName = storeName.Substring(index+1);
	        }

	        if (storeType == WindowsStoreType.LocalMachine)
	        {
                return Utils.Format("LocalMachine\\{0}", storeName);
	        }

	        if (storeType == WindowsStoreType.CurrentUser)
	        {
                return Utils.Format("CurrentUser\\{0}", storeName);
	        }

	        if (storeType == WindowsStoreType.Service)
	        {
                return Utils.Format("{0}\\{1}", serviceNameOrUserSid, storeName);
	        }

	        if (storeType == WindowsStoreType.User)
	        {
		        SecurityIdentifier sid = new SecurityIdentifier(serviceNameOrUserSid);
		        string userName = sid.Translate(typeof(NTAccount)).ToString();
        		
		        index = userName.LastIndexOf('\\');

		        if (index != -1)
		        {
			        userName = userName.Substring(index+1);
		        }

		        return Utils.Format("{0}\\{1}", userName, storeName);
	        }

	        return storeName;
        }
        
        /// <summary>
        /// Parses the a string representing the store location.
        /// </summary>
        private void Parse(string location)
        {
	        if (location == null) throw new ArgumentNullException("location");

	        location = location.Trim();

            if (String.IsNullOrEmpty(location))
            {
                throw ServiceResultException.Create(
                    StatusCodes.BadUnexpectedError,
                    "Store Location cannot be a empty string.");
            }

	        string hostName = null;
	        WindowsStoreType storeType = WindowsStoreType.LocalMachine;
	        string serviceNameOrUserSid = null;

	        int index = 0;

	        // extract host name.
	        if (location.StartsWith("\\\\", StringComparison.Ordinal))
	        {
		        hostName = location;

		        index = location.IndexOf('\\', 2);

		        if (index > 0)
		        {
			        hostName = hostName.Substring(2, index-2);
			        location = location.Substring(index+1);
		        }
	        }

	        // extract store type.
	        index = location.IndexOf('\\');

	        if (index == -1)
            {
                throw ServiceResultException.Create(
                    StatusCodes.BadUnexpectedError,
                    "Location does not specify a store name. Location={0}",
                    location);
	        }

	        string storeTypeName = location.Substring(0, index);

	        if (storeTypeName == "LocalMachine")
	        {
		        storeType = WindowsStoreType.LocalMachine;
	        }
	        else if (storeTypeName == "CurrentUser")
	        {
		        storeType = WindowsStoreType.CurrentUser;
	        }
	        else if (storeTypeName == "Service")
	        {
		        storeType = WindowsStoreType.Service;
	        }
	        else if (storeTypeName == "User")
	        {
		        storeType = WindowsStoreType.User;
	        }
	        else
            {
                throw ServiceResultException.Create(
                    StatusCodes.BadUnexpectedError,
                    "Location does not specify a valid store type. Location={0}",
                    location);
	        }
        		
	        location = location.Substring(index+1);

	        if (storeType == WindowsStoreType.Service || storeType == WindowsStoreType.User)
	        {
		        index = location.IndexOf('\\');

		        if (index == -1)
                {
                    throw ServiceResultException.Create(
                        StatusCodes.BadUnexpectedError,
                        "Location does not specify a store name. Location={0}",
                        location);
		        }

		        serviceNameOrUserSid = location.Substring(0, index);			
		        location = location.Substring(index+1);
	        }

	        m_hostName = hostName;
	        m_storeType = storeType;
	        m_serviceNameOrUserSid = serviceNameOrUserSid;
	        m_symbolicName = location;
	        m_displayName = GetStoreDisplayName(m_storeType, m_serviceNameOrUserSid, m_symbolicName);

            if (String.IsNullOrEmpty(m_symbolicName))
            {
                throw ServiceResultException.Create(
                    StatusCodes.BadUnexpectedError,
                    "Location does not specify a store name. Location={0}",
                    location);
            }
        }

        /// <summary>
        /// converts a managed string to an unmanaged string (allocated with malloc).
        /// </summary>
        private static IntPtr DuplicateString(string text)
        {
            IntPtr wszText = IntPtr.Zero;

            if (!String.IsNullOrEmpty(text))
            {
                wszText = Marshal.StringToHGlobalUni(text);
            }

            return wszText;
        }

        /// <summary>
        /// maps the store type onto a set of flags that can be passed to the various crypto functions.
        /// </summary>
        private static uint GetFlags(WindowsStoreType storeType)
        {
	        uint dwFlags = 0;

	        switch (storeType)
	        {
		        case WindowsStoreType.LocalMachine:
		        {
			        dwFlags |= CERT_SYSTEM_STORE_LOCAL_MACHINE;
			        break;
		        }

		        case WindowsStoreType.CurrentUser:
		        {
			        dwFlags |= CERT_SYSTEM_STORE_CURRENT_USER;
			        break;
		        }

		        case WindowsStoreType.User:
		        {
			        dwFlags |= CERT_SYSTEM_STORE_USERS;
			        break;
		        }

		        case WindowsStoreType.Service:
		        {
			        dwFlags |= CERT_SYSTEM_STORE_SERVICES;
			        break;
		        }
	        }

	        return dwFlags;
        }
        #endregion
        
        #region Public Properties
        /// <summary>
        /// The symbolic name for the store.
        /// </summary>
		public string SymbolicName
        {
            get { return m_symbolicName; }
        }

        /// <summary>
        /// The type of windows store.
        /// </summary>
		public WindowsStoreType StoreType
        {
            get { return m_storeType; }
        }

        /// <summary>
        /// The name of the machine.
        /// </summary>
		public string HostName
        {
            get { return m_hostName; }
        }
		
        /// <summary>
        /// The service name or user SID.
        /// </summary>
        public string ServiceNameOrUserSid
        {
            get { return m_serviceNameOrUserSid; }
        }

        /// <summary>
        /// A display name for the store.
        /// </summary>
		public string DisplayName
        {
            get { return m_displayName; }
        }
        #endregion
                
        #region Private Fields
        private object m_lock = new object();
		private string m_symbolicName;
		private WindowsStoreType m_storeType;
		private string m_hostName;
		private string m_serviceNameOrUserSid;
		private string m_displayName;
        #endregion
    }
    
    /// <summary>
    /// The type of certificate store.
    /// </summary>
    public enum WindowsStoreType
    {
        /// <summary>
        /// The local machine.
        /// </summary>
	    LocalMachine,

        /// <summary>
        /// The current user.
        /// </summary>
	    CurrentUser,

        /// <summary>
        /// A user account stores.
        /// </summary>
	    User,

        /// <summary>
        /// A service account store.
        /// </summary>
	    Service
    }
}
