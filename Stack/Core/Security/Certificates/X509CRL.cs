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
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.IO;

namespace Opc.Ua
{
    /// <summary>
    /// Provides access to an X509 CRL object.
    /// </summary>
    public sealed class X509CRL : IDisposable
    {
        #region Constructors
        /// <summary>
        /// Loads a CRL from a file.
        /// </summary>
        public X509CRL(string filePath)
        {
            RawData = File.ReadAllBytes(filePath);
            Initialize(RawData);
        }

        /// <summary>
        /// Loads a CRL from a memory buffer.
        /// </summary>
        public X509CRL(byte[] crl)
        {
            RawData = crl;
            Initialize(RawData);
        }
        #endregion

        #region IDisposable Members
        /// <summary>
        /// The finializer implementation.
        /// </summary>
        ~X509CRL()
        {
            Dispose(false);
        }

        /// <summary>
        /// Frees any unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// An overrideable version of the Dispose.
        /// </summary>
        private void Dispose(bool disposing)
        {
            FreeUnmanagedPointers();
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// The subject name of the Issuer for the CRL.
        /// </summary>
        public string Issuer { get; private set; }

        /// <summary>
        /// When the CRL was last updated.
        /// </summary>
        public DateTime UpdateTime { get; private set; }

        /// <summary>
        /// When the CRL is due for its next update.
        /// </summary>
        public DateTime NextUpdateTime { get; private set; }

        /// <summary>
        /// The raw data for the CRL.
        /// </summary>
        public byte[] RawData { get; private set; }
        #endregion

        #region Public Methods
        /// <summary>
        /// Verifies the signature on the CRL.
        /// </summary>
        public bool VerifySignature(X509Certificate2 issuer, bool throwOnError)
        {
            Win32.CERT_CONTEXT context = (Win32.CERT_CONTEXT)Marshal.PtrToStructure(issuer.Handle, typeof(Win32.CERT_CONTEXT));
            Win32.CERT_INFO info = (Win32.CERT_INFO)Marshal.PtrToStructure(context.pCertInfo, typeof(Win32.CERT_INFO));

            int bResult = Win32.CryptVerifyCertificateSignature(
                IntPtr.Zero,
                Win32.X509_ASN_ENCODING,
                m_pBuffer,
                m_bufferSize,
                ref info.SubjectPublicKeyInfo);

            if (bResult == 0)
            {
                if (throwOnError)
                {
                    throw Win32.GetLastError(StatusCodes.BadCertificateInvalid, "Could not get verify signature on CRL.");
                }

                return false;
            }

            m_issuer = issuer;
            return true;
        }

        /// <summary>
        /// Returns true the certificate is in the CRL.
        /// </summary>
        public bool IsRevoked(X509Certificate2 certificate)
        {
            IntPtr pData1 = IntPtr.Zero;
            IntPtr pData2 = IntPtr.Zero;
            int dwDataSize1 = 0;
   
            try
            {
                // check that the issuer matches.
                if (m_issuer == null || !Utils.CompareDistinguishedName(certificate.Issuer, m_issuer.Subject))
                {
                    throw new ServiceResultException(StatusCodes.BadCertificateInvalid, "Certificate was not created by the CRL issuer.");
                }

                // get the cert info for the target certificate.
                Win32.CERT_CONTEXT context = (Win32.CERT_CONTEXT)Marshal.PtrToStructure(certificate.Handle, typeof(Win32.CERT_CONTEXT));
                
                // calculate amount of memory required.
                int bResult = Win32.CryptDecodeObjectEx(
                    Win32.X509_ASN_ENCODING | Win32.PKCS_7_ASN_ENCODING,
                    (IntPtr)Win32.X509_CERT_CRL_TO_BE_SIGNED,
                    m_signedCrl.ToBeSigned.pbData,
                    m_signedCrl.ToBeSigned.cbData,
                    Win32.CRYPT_DECODE_NOCOPY_FLAG,
                    IntPtr.Zero,
                    pData1,
                    ref dwDataSize1);

                if (bResult == 0)
                {
                    throw Win32.GetLastError(StatusCodes.BadDecodingError, "Could not get size for CRL_INFO.");
                }

                // allocate memory.
                pData1 = Marshal.AllocHGlobal(dwDataSize1);

                // decode blob.
                bResult = Win32.CryptDecodeObjectEx(
                    Win32.X509_ASN_ENCODING | Win32.PKCS_7_ASN_ENCODING,
                    (IntPtr)Win32.X509_CERT_CRL_TO_BE_SIGNED,
                    m_signedCrl.ToBeSigned.pbData,
                    m_signedCrl.ToBeSigned.cbData,
                    Win32.CRYPT_DECODE_NOCOPY_FLAG,
                    IntPtr.Zero,
                    pData1,
                    ref dwDataSize1);

                if (bResult == 0)
                {
                    throw Win32.GetLastError(StatusCodes.BadDecodingError, "Could not decode CRL_INFO.");
                }

                IntPtr[] pCRLs = new IntPtr[] { pData1 };
                pData2 = Marshal.AllocHGlobal(IntPtr.Size * pCRLs.Length);
                Marshal.Copy(pCRLs, 0, pData2, pCRLs.Length);

                // check for revocation.                
                bResult = Win32.CertVerifyCRLRevocation(
                    Win32.X509_ASN_ENCODING | Win32.PKCS_7_ASN_ENCODING,
                    context.pCertInfo,
                    pCRLs.Length,
                    pData2);

                if (bResult == 0)
                {
                    return true;
                }
                
                // not revoked.
                return false;
            }
            finally
            {
                if (pData1 != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(pData1);
                    pData1 = IntPtr.Zero;
                }

                if (pData2 != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(pData2);
                    pData2 = IntPtr.Zero; 
                }
            }
        }
        #endregion
        
        #region Private Methods
        private void Initialize(byte[] crl)
        {
            m_bufferSize = crl.Length;
            m_pBuffer = Marshal.AllocHGlobal(m_bufferSize);
            Marshal.Copy(crl, 0, m_pBuffer, m_bufferSize);
            SaveUnmanagedPointer(m_pBuffer);

            m_signedCrl = Win32.Decode_CERT_SIGNED_CONTENT_INFO(m_pBuffer, crl.Length);
            Win32.CRL_INFO info = Win32.Decode_CERT_INFO(m_signedCrl.ToBeSigned.pbData, m_signedCrl.ToBeSigned.cbData);

            Issuer = Win32.Decode_CERT_NAME_BLOB(info.Issuer);
            UpdateTime = Win32.Decode_FILETIME(info.ThisUpdate);
            NextUpdateTime = Win32.Decode_FILETIME(info.NextUpdate);
        }

        private void SaveUnmanagedPointer(IntPtr pData)
        {
            if (m_memoryToFree == null)
            {
                m_memoryToFree = new IntPtr[] { pData };
                return;
            }

            IntPtr[] memoryToFree = new IntPtr[m_memoryToFree.Length+1];
            Array.Copy(m_memoryToFree, memoryToFree, m_memoryToFree.Length);
            memoryToFree[m_memoryToFree.Length] = pData;
            m_memoryToFree = memoryToFree;
        }

        private void FreeUnmanagedPointers()
        {
            if (m_memoryToFree != null)
            {
                for (int ii = 0; ii < m_memoryToFree.Length; ii++)
                {
                    Marshal.FreeHGlobal(m_memoryToFree[ii]);
                }
            }
        }
        #endregion

        #region Private Fields
        private IntPtr m_pBuffer;
        private int m_bufferSize;
        private Win32.CERT_SIGNED_CONTENT_INFO m_signedCrl;
        private X509Certificate2 m_issuer;
        private IntPtr[] m_memoryToFree;
        #endregion    
    }
}
