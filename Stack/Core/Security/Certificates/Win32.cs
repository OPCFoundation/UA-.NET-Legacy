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

namespace Opc.Ua
{
    internal static class Win32
    {
        #region Constants
        public const int X509_ASN_ENCODING = 0x00000001;
        public const int PKCS_7_ASN_ENCODING = 0x00010000;

        public const int CRYPT_DECODE_ALLOC_FLAG = 0x8000;
        public const int CRYPT_DECODE_NOCOPY_FLAG = 0x1;

        public const int X509_CERT = 1;
        public const int X509_CERT_CRL_TO_BE_SIGNED = 3;
        public const int X509_AUTHORITY_KEY_ID = 9;
        public const int X509_KEY_ATTRIBUTES = 10;
        public const int X509_KEY_USAGE_RESTRICTION = 11;
        public const int X509_ALTERNATE_NAME = 12;
        public const int X509_BASIC_CONSTRAINTS = 13;
        public const int X509_KEY_USAGE = 14;
        public const int X509_BASIC_CONSTRAINTS2 = 15;
        public const int X509_CERT_POLICIES = 16;

        public const int CERT_SIMPLE_NAME_STR = 1;
        public const int CERT_OID_NAME_STR = 2;
        public const int CERT_X500_NAME_STR = 3;

        public const int CERT_NAME_STR_SEMICOLON_FLAG = 0x40000000;
        public const int CERT_NAME_STR_NO_PLUS_FLAG = 0x20000000;
        public const int CERT_NAME_STR_NO_QUOTING_FLAG = 0x10000000;
        public const int CERT_NAME_STR_CRLF_FLAG = 0x08000000;
        public const int CERT_NAME_STR_COMMA_FLAG = 0x04000000;
        public const int CERT_NAME_STR_REVERSE_FLAG = 0x02000000;
        #endregion

        #region Structs
        [StructLayout(LayoutKind.Sequential)]
        public struct CRYPT_OBJID_BLOB
        {
            public int cbData;
            public IntPtr pbData;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct CRYPT_ALGORITHM_IDENTIFIER
        {
            [MarshalAs(UnmanagedType.LPStr)]
            public string pszObjId;
            public CRYPT_OBJID_BLOB Parameters;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct CRYPT_DATA_BLOB
        {
            public int cbData;
            public IntPtr pbData;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct CRYPT_INTEGER_BLOB
        {
            public int cbData;
            public IntPtr pbData;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct CERT_NAME_BLOB
        {
            public int cbData;
            public IntPtr pbData;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct CRYPT_BIT_BLOB
        {
            public int cbData;
            public IntPtr pbData;
            public int cUnusedBits;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct CERT_SIGNED_CONTENT_INFO
        {
            public CRYPT_DATA_BLOB ToBeSigned;
            public CRYPT_ALGORITHM_IDENTIFIER SignatureAlgorithm;
            public CRYPT_BIT_BLOB Signature;
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct CERT_PUBLIC_KEY_INFO
        {
            public CRYPT_ALGORITHM_IDENTIFIER Algorithm;
            public CRYPT_BIT_BLOB PublicKey;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct CERT_INFO
        {
            public int dwVersion;
            public CRYPT_INTEGER_BLOB SerialNumber;
            public CRYPT_ALGORITHM_IDENTIFIER SignatureAlgorithm;
            public CERT_NAME_BLOB Issuer;
            public System.Runtime.InteropServices.ComTypes.FILETIME NotBefore;
            public System.Runtime.InteropServices.ComTypes.FILETIME NotAfter;
            public CERT_NAME_BLOB Subject;
            public CERT_PUBLIC_KEY_INFO SubjectPublicKeyInfo;
            public CRYPT_BIT_BLOB IssuerUniqueId;
            public CRYPT_BIT_BLOB SubjectUniqueId;
            public int cExtension;
            public IntPtr rgExtension;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct CERT_CONTEXT
        {
            public int dwCertEncodingType;
            public IntPtr pbCertEncoded;
            public int cbCertEncoded;
            public IntPtr pCertInfo;
            public IntPtr hCertStore;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct CRL_INFO
        {
            public int dwVersion;
            public CRYPT_ALGORITHM_IDENTIFIER SignatureAlgorithm;
            public CERT_NAME_BLOB Issuer;
            public System.Runtime.InteropServices.ComTypes.FILETIME ThisUpdate;
            public System.Runtime.InteropServices.ComTypes.FILETIME NextUpdate;
            public int cCRLEntry;
            public IntPtr rgCRLEntry;
            public int cExtension;
            public IntPtr rgExtension;
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct CRL_ENTRY
        {
            public CRYPT_INTEGER_BLOB SerialNumber;
            public System.Runtime.InteropServices.ComTypes.FILETIME RevocationDate;
            public int cExtension;
            public IntPtr rgExtension;
        };
        #endregion

        #region Functions
        [DllImport("KERNEL32.DLL")]
        public static extern int GetLastError();

        [DllImport("CRYPT32.DLL", BestFitMapping = false, ThrowOnUnmappableChar = true, SetLastError = true)]
        public static extern int CryptDecodeObjectEx(
            int dwCertEncodingType,
            IntPtr lpszStructType,
            IntPtr pbEncoded,
            int cbEncoded,
            int dwFlags,
            IntPtr pDecodePara,
            IntPtr pvStructInfo,
            ref int pcbStructInfo);

        [DllImport("CRYPT32.DLL", BestFitMapping = false, ThrowOnUnmappableChar = true, SetLastError = true)]
        public static extern int CryptEncodeObjectEx(
            int dwCertEncodingType,
            IntPtr lpszStructType,
            IntPtr pvStructInfo,
            int dwFlags,
            IntPtr pEncodePara,
            IntPtr pvEncoded,
            ref int pcbEncoded);

        [DllImport("CRYPT32.DLL", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int CryptVerifyCertificateSignature(
          IntPtr hCryptProv,
          Int32 dwCertEncodingType,
          IntPtr pbEncoded,
          Int32 cbEncoded,
          ref CERT_PUBLIC_KEY_INFO pPublicKey);

        [DllImport("CRYPT32.DLL", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int CertVerifyCRLRevocation(
            int dwCertEncodingType,
            IntPtr pCertId,
            int cCrlInfo,
            IntPtr rgpCrlInfo);

        [DllImport("CRYPT32.DLL", SetLastError = true)]
        public static extern int CertNameToStrW(
            int dwCertEncodingType,
            IntPtr pName,
            int dwStrType,
            IntPtr psz,
            int csz);

        [DllImport("CRYPT32.DLL", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int CertStrToNameW(
            int dwCertEncodingType,
            [MarshalAs(UnmanagedType.LPWStr)] string pszX500,
            int dwStrType,
            IntPtr pvReserved,
            IntPtr pbEncoded,
            ref int pcbEncoded,
            IntPtr ppszError);

        [DllImport("MSVCRT.DLL", SetLastError = false)]
        public static extern IntPtr memcpy(IntPtr dest, IntPtr src, int count); 
        #endregion

        /// <summary>
        /// Throws an exception with the last WIN32 error code.
        /// </summary>
        public static Exception GetLastError(uint code, string format, params object[] args)
        {
            int error = Win32.GetLastError();

            if (format == null)
            {
                format = String.Empty;
            }

            object[] args2 = args;

            if (args != null && args.Length > 0)
            {
                format += Utils.Format(" (GetLastError = {{{0:X8}}})", args.Length);
                args2 = new object[args.Length + 1];
                Array.Copy(args, args2, args.Length);
                args2[args2.Length - 1] = error;
            }
            else
            {
                format += " (GetLastError = {0:X8})";
                args2 = new object[] { error };
            }

            return ServiceResultException.Create(code, format, args2);
        }

        /// <summary>
        /// Decodes a CERT_NAME_BLOB.
        /// </summary>
        public static string Decode_CERT_NAME_BLOB(CERT_NAME_BLOB blob)
        {
            int dwChars = 0;
            IntPtr pName = IntPtr.Zero;
            IntPtr pBlob = IntPtr.Zero;

            try
            {
                pBlob = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(Win32.CERT_NAME_BLOB)));
                Marshal.StructureToPtr(blob, pBlob, false);

                int bResult = Win32.CertNameToStrW(
                    Win32.PKCS_7_ASN_ENCODING | Win32.X509_ASN_ENCODING,
                    pBlob,
                    Win32.CERT_X500_NAME_STR | CERT_NAME_STR_REVERSE_FLAG,
                    IntPtr.Zero,
                    dwChars);

                if (bResult == 0)
                {
                    throw GetLastError(StatusCodes.BadDecodingError, "Could not get size of CERT_X500_NAME_STR.");
                }

                dwChars = bResult;
                pName = Marshal.AllocHGlobal((dwChars + 1) * 2);

                bResult = Win32.CertNameToStrW(
                    Win32.PKCS_7_ASN_ENCODING | Win32.X509_ASN_ENCODING,
                    pBlob,
                    Win32.CERT_X500_NAME_STR | CERT_NAME_STR_REVERSE_FLAG,
                    pName,
                    dwChars);

                if (bResult == 0)
                {
                    throw GetLastError(StatusCodes.BadDecodingError, "Could not decode CERT_X500_NAME_STR.");
                }

                return Marshal.PtrToStringUni(pName);
            }
            finally
            {
                if (pBlob != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(pBlob);
                }

                if (pName != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(pName);
                }
            }
        }

        /// <summary>
        /// Encodes a CERT_NAME_BLOB
        /// </summary>
        public static void Encode_CERT_NAME_BLOB(string name, ref CERT_NAME_BLOB pName)
        {
            int dwSize = 0;
            IntPtr pBuffer = IntPtr.Zero;

            try
            {
                // reconstruct name using comma as delimeter.
                name = ChangeSubjectNameDelimiter(name, ',');

                int bResult = Win32.CertStrToNameW(
                    X509_ASN_ENCODING,
                    name,
                    CERT_X500_NAME_STR | CERT_NAME_STR_REVERSE_FLAG,
                    IntPtr.Zero,
                    IntPtr.Zero,
                    ref dwSize,
                    IntPtr.Zero);

                if (bResult == 0)
                {
                    throw GetLastError(StatusCodes.BadEncodingError, "Could not get size for CERT_X500_NAME_STR.");
                }

                pBuffer = Marshal.AllocHGlobal(dwSize);

                bResult = Win32.CertStrToNameW(
                    X509_ASN_ENCODING,
                    name,
                    CERT_X500_NAME_STR | CERT_NAME_STR_REVERSE_FLAG,
                    IntPtr.Zero,
                    pBuffer,
                    ref dwSize,
                    IntPtr.Zero);

                if (bResult == 0)
                {
                    throw GetLastError(StatusCodes.BadEncodingError, "Could not encode CERT_X500_NAME_STR.");
                }

                pName.pbData = pBuffer;
                pName.cbData = dwSize;
                pBuffer = IntPtr.Zero;
            }
            finally
            {
                if (pBuffer != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(pBuffer);
                }
            }
        }

        /// <summary>
        /// Changes the delimiter used to seperate fields in a subject name.
        /// </summary>
        private static string ChangeSubjectNameDelimiter(string name, char delimiter)
        {
            StringBuilder buffer = new StringBuilder();
            List<string> elements = Utils.ParseDistinguishedName(name);

            for (int ii = 0; ii < elements.Count; ii++)
            {
                string element = elements[ii];

                if (buffer.Length > 0)
                {
                    buffer.Append(delimiter);
                }

                if (element.IndexOf(delimiter) != -1)
                {
                    int index = element.IndexOf('=');
                    buffer.Append(element.Substring(0, index + 1));
                    buffer.Append('"');
                    buffer.Append(element.Substring(index + 1));
                    buffer.Append('"');
                    continue;
                }

                buffer.Append(elements[ii]);
            }

            return buffer.ToString();
        }

        /// <summary>
        /// Decodes a CERT_SIGNED_CONTENT_INFO.
        /// </summary>
        public static CERT_SIGNED_CONTENT_INFO Decode_CERT_SIGNED_CONTENT_INFO(IntPtr pEncoded, int iEncodedSize)
        {
            IntPtr pData1 = IntPtr.Zero;
            int dwDataSize1 = 0;

            try
            {
                // calculate amount of memory required.
                int bResult = Win32.CryptDecodeObjectEx(
                    Win32.X509_ASN_ENCODING | Win32.PKCS_7_ASN_ENCODING,
                    (IntPtr)Win32.X509_CERT,
                    pEncoded,
                    iEncodedSize,
                    Win32.CRYPT_DECODE_NOCOPY_FLAG,
                    IntPtr.Zero,
                    pData1,
                    ref dwDataSize1);

                if (bResult == 0)
                {
                    throw GetLastError(StatusCodes.BadDecodingError, "Could not get size for CERT_SIGNED_CONTENT_INFO.");
                }

                // allocate memory.
                pData1 = Marshal.AllocHGlobal(dwDataSize1);

                // decode blob.
                bResult = Win32.CryptDecodeObjectEx(
                    Win32.X509_ASN_ENCODING | Win32.PKCS_7_ASN_ENCODING,
                    (IntPtr)Win32.X509_CERT,
                    pEncoded,
                    iEncodedSize,
                    Win32.CRYPT_DECODE_NOCOPY_FLAG,
                    IntPtr.Zero,
                    pData1,
                    ref dwDataSize1);

                if (bResult == 0)
                {
                    throw GetLastError(StatusCodes.BadDecodingError, "Could not decode CERT_SIGNED_CONTENT_INFO.");
                }

                return (Win32.CERT_SIGNED_CONTENT_INFO)Marshal.PtrToStructure(pData1, typeof(Win32.CERT_SIGNED_CONTENT_INFO));
            }
            finally
            {
                if (pData1 != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(pData1);
                }
            }
        }

        /// <summary>
        /// Decodes a CERT_INFO.
        /// </summary>
        public static CRL_INFO Decode_CERT_INFO(IntPtr pEncoded, int iEncodedSize)
        {
            IntPtr pData2 = IntPtr.Zero;
            int dwDataSize2 = 0;

            try
            {
                // calculate amount of memory required.
                int bResult = Win32.CryptDecodeObjectEx(
                    Win32.X509_ASN_ENCODING | Win32.PKCS_7_ASN_ENCODING,
                    (IntPtr)Win32.X509_CERT_CRL_TO_BE_SIGNED,
                    pEncoded,
                    iEncodedSize,
                    Win32.CRYPT_DECODE_NOCOPY_FLAG,
                    IntPtr.Zero,
                    pData2,
                    ref dwDataSize2);

                if (bResult == 0)
                {
                    throw GetLastError(StatusCodes.BadDecodingError, "Could not get size for CRL_INFO.");
                }

                // allocate memory.
                pData2 = Marshal.AllocHGlobal(dwDataSize2);

                // decode blob.
                bResult = Win32.CryptDecodeObjectEx(
                    Win32.X509_ASN_ENCODING | Win32.PKCS_7_ASN_ENCODING,
                    (IntPtr)Win32.X509_CERT_CRL_TO_BE_SIGNED,
                    pEncoded,
                    iEncodedSize,
                    Win32.CRYPT_DECODE_NOCOPY_FLAG,
                    IntPtr.Zero,
                    pData2,
                    ref dwDataSize2);

                if (bResult == 0)
                {
                    throw GetLastError(StatusCodes.BadDecodingError, "Could not decode CRL_INFO.");
                }

                return (Win32.CRL_INFO)Marshal.PtrToStructure(pData2, typeof(Win32.CRL_INFO));
            }
            finally
            {
                if (pData2 != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(pData2);
                }
            }
        }

        /// <summary>
        /// Encodes a CERT_INFO.
        /// </summary>
        public static void Encode_CERT_INFO(CERT_INFO info, out IntPtr pEncoded, out int encodedSize)
        {
            pEncoded = IntPtr.Zero;
            encodedSize = 0;

            IntPtr pData = IntPtr.Zero;
            int dwDataSize = 0;

            GCHandle hData = GCHandle.Alloc(info);

            try
            {
                // calculate amount of memory required.
                int bResult = Win32.CryptEncodeObjectEx(
                    Win32.X509_ASN_ENCODING,
                    (IntPtr)Win32.X509_CERT_CRL_TO_BE_SIGNED,
                    hData.AddrOfPinnedObject(),
                    0,
                    IntPtr.Zero,
                    IntPtr.Zero,
                    ref dwDataSize);

                if (bResult == 0)
                {
                    throw GetLastError(StatusCodes.BadEncodingError, "Could not get size for CRL_INFO.");
                }

                // allocate memory.
                pData = Marshal.AllocHGlobal(dwDataSize);

                // decode blob.
                bResult = Win32.CryptEncodeObjectEx(
                    Win32.X509_ASN_ENCODING | Win32.PKCS_7_ASN_ENCODING,
                    (IntPtr)Win32.X509_CERT_CRL_TO_BE_SIGNED,
                    hData.AddrOfPinnedObject(),
                    0,
                    IntPtr.Zero,
                    pData,
                    ref dwDataSize);

                if (bResult == 0)
                {
                    throw GetLastError(StatusCodes.BadEncodingError, "Could not encoder CRL_INFO.");
                }

                // return results.
                pEncoded = pData;
                encodedSize = dwDataSize;
                pData = IntPtr.Zero;
            }
            finally
            {
                if (hData.IsAllocated)
                {
                    hData.Free();
                }

                if (pData != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(pData);
                }
            }
        }

        /// <summary>
        /// Decodes a WIN32 FILETIME.
        /// </summary>
        public static DateTime Decode_FILETIME(System.Runtime.InteropServices.ComTypes.FILETIME filetime)
        {
            // check for invalid value.
            if (filetime.dwHighDateTime < 0)
            {
                return DateTime.MinValue;
            }

            // convert FILETIME structure to a 64 bit integer.
            long buffer = (long)filetime.dwHighDateTime;

            if (buffer < 0)
            {
                buffer += ((long)UInt32.MaxValue + 1);
            }

            long ticks = (buffer << 32);

            buffer = (long)filetime.dwLowDateTime;

            if (buffer < 0)
            {
                buffer += ((long)UInt32.MaxValue + 1);
            }

            ticks += buffer;

            // check for invalid value.
            if (ticks == 0)
            {
                return DateTime.MinValue;
            }

            // adjust for WIN32 FILETIME base.			
            return new DateTime(1601, 1, 1).Add(new TimeSpan(ticks));
        }

        /// <summary>
        /// Encodes a WIN32 FILETIME.
        /// </summary>
        public static System.Runtime.InteropServices.ComTypes.FILETIME Encode_FILETIME(DateTime datetime)
        {
            System.Runtime.InteropServices.ComTypes.FILETIME filetime;

            if (datetime <= new DateTime(1601, 1, 1))
            {
                filetime.dwHighDateTime = 0;
                filetime.dwLowDateTime = 0;
                return filetime;
            }

            // adjust for WIN32 FILETIME base.
            long ticks = 0;
            ticks = datetime.Subtract(new TimeSpan(new DateTime(1601, 1, 1).Ticks)).Ticks;

            filetime.dwHighDateTime = (int)((ticks >> 32) & 0xFFFFFFFF);
            filetime.dwLowDateTime = (int)(ticks & 0xFFFFFFFF);

            return filetime;
        }
    }
}
