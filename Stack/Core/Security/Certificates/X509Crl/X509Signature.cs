/* ========================================================================
 * Copyright (c) 2005-2020 The OPC Foundation, Inc. All rights reserved.
 *
 * OPC Foundation MIT License 1.00
 * 
 * Permission is hereby granted, free of charge, to any person
 * obtaining a copy of this software and associated documentation
 * files (the "Software"), to deal in the Software without
 * restriction, including without limitation the rights to use,
 * copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the
 * Software is furnished to do so, subject to the following
 * conditions:
 * 
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 * OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.
 *
 * The complete license agreement can be found here:
 * http://opcfoundation.org/License/MIT/1.00/
 * ======================================================================*/

using Opc.Ua.Security.Certificates.Common;
using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Opc.Ua.Security.Certificates
{
    /// <summary>
    /// Describes the three required fields of a X509 Certificate and CRL.
    /// </summary>
    public class X509Signature
    {
        /// <summary>
        /// The field contains the ASN.1 data to be signed.
        /// </summary>
        public byte[] Tbs { get; private set; }
        /// <summary>
        /// The signature of the data.
        /// </summary>
        public byte[] Signature { get; private set; }
        /// <summary>
        /// The encoded signature algorithm that was used for signing.
        /// </summary>
        public byte[] SignatureAlgorithmIdentifier { get; private set; }
        /// <summary>
        /// The signature algorithm as Oid string.
        /// </summary>
        public string SignatureAlgorithm { get; private set; }
        /// <summary>
        /// The hash algorithm used for signing.
        /// </summary>
        public HashAlgorithmName Name { get; private set; }
        /// <summary>
        /// Initialize and decode the sequence with binary ASN.1 encoded CRL or certificate.
        /// </summary>
        /// <param name="signedBlob"></param>
        public X509Signature(byte[] signedBlob)
        {
            Decode(signedBlob);
        }

        /// <summary>
        /// Decoder for the signature sequence.
        /// </summary>
        /// <param name="crl">The encoded CRL or certificate sequence.</param>
        private void Decode(byte[] crl)
        {
            int bufferSize = crl.Length;
            IntPtr pBuffer = Marshal.AllocHGlobal(bufferSize);

            try
            {
                
                Marshal.Copy(crl, 0, pBuffer, bufferSize);

                Win32.CERT_SIGNED_CONTENT_INFO signedCrl = Win32.Decode_CERT_SIGNED_CONTENT_INFO(pBuffer, crl.Length);

                if (signedCrl.ToBeSigned.pbData != IntPtr.Zero)
                {
                    // Tbs encoded data
                    Tbs = new byte[signedCrl.ToBeSigned.cbData];
                    Marshal.Copy(signedCrl.ToBeSigned.pbData, Tbs, 0, signedCrl.ToBeSigned.cbData);

                    // Signature Algorithm Identifier
                    SignatureAlgorithm = signedCrl.SignatureAlgorithm.pszObjId;
                    Name = Oids.GetHashAlgorithmName(SignatureAlgorithm);

                    //Signature
                    Signature = new byte[signedCrl.Signature.cbData];
                    Marshal.Copy(signedCrl.Signature.pbData, Signature, 0, signedCrl.Signature.cbData);

                    return;
                }

                throw new CryptographicException("No valid data in the X509 signature.");
            }
            catch (CryptographicException ace)
            {
                throw new CryptographicException("Failed to decode the X509 signature.", ace);
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
        /// Verify the signature with the public key of the signer.
        /// </summary>
        /// <param name="certificate"></param>
        /// <returns>true if the signature is valid.</returns>
        public bool Verify(X509Certificate2 certificate)
        {
            switch (SignatureAlgorithm)
            {
                case Oids.RsaPkcs1Sha1:
                case Oids.RsaPkcs1Sha256:
                case Oids.RsaPkcs1Sha384:
                case Oids.RsaPkcs1Sha512:
                case Oids.ECDsaWithSha1:
                case Oids.ECDsaWithSha256:
                case Oids.ECDsaWithSha384:
                case Oids.ECDsaWithSha512:
                    return VerifySignature(certificate);

                default:
                    throw new CryptographicException("Failed to verify signature due to unknown signature algorithm.");
            }
        }

        /// <summary>
        /// Verifies the signature on the CRL or certificate.
        /// </summary>
        private bool VerifySignature(X509Certificate2 certificate)
        {
         
            byte[] certBytes = certificate.GetRawCertData();
            int bufferSize = certBytes.Length;
            IntPtr pBuffer = Marshal.AllocHGlobal(bufferSize);
            Marshal.Copy(certBytes, 0, pBuffer, bufferSize);

            try
            {
                Win32.CERT_CONTEXT context = (Win32.CERT_CONTEXT)Marshal.PtrToStructure(certificate.Handle, typeof(Win32.CERT_CONTEXT));
                Win32.CERT_INFO info = (Win32.CERT_INFO)Marshal.PtrToStructure(context.pCertInfo, typeof(Win32.CERT_INFO));

                int bResult = Win32.CryptVerifyCertificateSignature(
                    IntPtr.Zero,
                    Win32.X509_ASN_ENCODING,
                    pBuffer,
                    bufferSize,
                    ref info.SubjectPublicKeyInfo);

                if (bResult == 0)
                {
                    throw new CryptographicException("Failed to verify signature due to unknown signature algorithm.");
                }
            }
            finally
            {
                if (pBuffer != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(pBuffer);
                }
            }
            return true;
        }
    }
}
