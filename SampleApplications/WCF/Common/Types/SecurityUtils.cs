/* ========================================================================
 * Copyright (c) 2005-2017 The OPC Foundation, Inc. All rights reserved.
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Reflection;

namespace Opc.Ua.Sample
{
    /// <summary>
    /// Provides various functions which implement the security operations required by the create/active session services. 
    /// </summary>
    public static class SecurityUtils
    {
        /// <summary>
        /// Checks for the certificate in the certificate store.  Loads it from a resource if it does not exist.
        /// </summary>
        public static X509Certificate2 Find(StoreName storeName, StoreLocation storeLocation, string subjectName)
        {
            X509Certificate2 certificate = null;

            // look for the the private key in the personal store.
            X509Store store = new X509Store(storeName, storeLocation);
            store.Open(OpenFlags.ReadWrite);

            try
            {
                X509Certificate2Collection hits = store.Certificates.Find(X509FindType.FindBySubjectName, subjectName, false);

                if (hits.Count == 0)
                {
                    return null;
                }

                certificate = hits[0];
            }
            finally
            {
                store.Close();
            }

            return certificate;
        }

        /// <summary>
        /// Checks for the certificate in the certificate store.  Loads it from a resource if it does not exist.
        /// </summary>
        public static X509Certificate2 InitializeCertificate(StoreName storeName, StoreLocation storeLocation, string subjectName)
        {
            // find matching certificate.
            X509Certificate2 certificate = Find(storeName, storeLocation, subjectName);

            // put a copy in the trusted people store because that is the default location used by WCF to determine trust.
            X509Store store = new X509Store(StoreName.TrustedPeople, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadWrite);

            try
            {
                X509Certificate2Collection hits = store.Certificates.Find(X509FindType.FindByThumbprint, certificate.Thumbprint, false);

                if (hits.Count == 0)
                {
                    // copy the certificate to ensure the private key is not placed in the trusted people store.
                    store.Add(new X509Certificate2(certificate.GetRawCertData()));
                }
            }
            finally
            {
                store.Close();
            }

            return certificate;
        }

        /// <summary>
        /// Appends a list of byte arrays.
        /// </summary>
        public static byte[] Append(params byte[][] arrays)
        {
            if (arrays == null)
            {
                return new byte[0];
            }

            int length = 0;

            for (int ii = 0; ii < arrays.Length; ii++)
            {
                if (arrays[ii] != null)
                {
                    length += arrays[ii].Length;
                }
            }

            byte[] output = new byte[length];

            int pos = 0;

            for (int ii = 0; ii < arrays.Length; ii++)
            {
                if (arrays[ii] != null)
                {
                    Array.Copy(arrays[ii], 0, output, pos, arrays[ii].Length);
                    pos += arrays[ii].Length;
                }
            }

            return output;
        }
        
        /// <summary>
        /// Encrypts the text using the SecurityPolicyUri and returns the result.
        /// </summary>
        public static EncryptedData Encrypt(X509Certificate2 certificate, string securityPolicyUri, byte[] plainText)
        {
            EncryptedData encryptedData = new EncryptedData();

            encryptedData.Algorithm = null;
            encryptedData.Data = plainText;

            // check if nothing to do.
            if (plainText == null)
            {
                return encryptedData;
            }

            // nothing more to do if no encryption.
            if (String.IsNullOrEmpty(securityPolicyUri))
            {
                return encryptedData;
            }

            // encrypt data.
            switch (securityPolicyUri)
            {
                case SecurityPolicies.Basic128:
                case SecurityPolicies.Basic192:
                case SecurityPolicies.Basic256:
                {
                    encryptedData.Algorithm = SecurityAlgorithms.RsaOaep;
                    encryptedData.Data = RsaUtils.Encrypt(plainText, certificate, true);
                    break;
                }

                case SecurityPolicies.Basic128Rsa15:
                case SecurityPolicies.Basic192Rsa15:
                case SecurityPolicies.Basic256Rsa15:
                {
                    encryptedData.Algorithm = SecurityAlgorithms.Rsa15;
                    encryptedData.Data = RsaUtils.Encrypt(plainText, certificate, false);
                    break;
                }

                case SecurityPolicies.None:
                {
                    break;
                }

                default:
                {
                    throw new ApplicationException(String.Format(
                        "Unsupported security policy: {0}",
                        securityPolicyUri));
                }
            }

            return encryptedData;
        }

        /// <summary>
        /// Decrypts the CipherText using the SecurityPolicyUri and returns the PlainTetx.
        /// </summary>
        public static byte[] Decrypt(X509Certificate2 certificate, string securityPolicyUri, EncryptedData dataToDecrypt)
        {
            // check if nothing to do.
            if (dataToDecrypt == null)
            {
                return null;
            }

            // nothing more to do if no encryption.
            if (String.IsNullOrEmpty(securityPolicyUri))
            {
                return dataToDecrypt.Data;
            }

            // decrypt data.
            switch (securityPolicyUri)
            {
                case SecurityPolicies.Basic128:
                case SecurityPolicies.Basic192:
                case SecurityPolicies.Basic256:
                {
                    if (dataToDecrypt.Algorithm == SecurityAlgorithms.RsaOaep)
                    {
                        return RsaUtils.Decrypt(new ArraySegment<byte>(dataToDecrypt.Data), certificate, true);
                    }

                    break;
                }

                case SecurityPolicies.Basic128Rsa15:
                case SecurityPolicies.Basic192Rsa15:
                case SecurityPolicies.Basic256Rsa15:
                {
                    if (dataToDecrypt.Algorithm == SecurityAlgorithms.Rsa15)
                    {
                        return RsaUtils.Decrypt(new ArraySegment<byte>(dataToDecrypt.Data), certificate, false);
                    }

                    break;
                }

                case SecurityPolicies.None:
                {
                    if (String.IsNullOrEmpty(dataToDecrypt.Algorithm))
                    {
                        return dataToDecrypt.Data;
                    }

                    break;
                }

                default:
                {
                    throw new ApplicationException(String.Format(
                        "Unsupported security policy: {0}",
                        securityPolicyUri));
                }
            }

            throw new ApplicationException(String.Format(
                "Unexpected encryption algorithm : {0}",
                dataToDecrypt.Data));
        }

        /// <summary>
        /// Signs the data using the SecurityPolicyUri and returns the signature.
        /// </summary>
        public static SignatureData Sign(X509Certificate2 certificate, string securityPolicyUri, byte[] dataToSign)
        {
            SignatureData signatureData = new SignatureData();

            // check if nothing to do.
            if (dataToSign == null)
            {
                return signatureData;
            }

            // nothing more to do if no encryption.
            if (String.IsNullOrEmpty(securityPolicyUri))
            {
                return signatureData;
            }

            // sign data.
            switch (securityPolicyUri)
            {
                case SecurityPolicies.Basic128:
                case SecurityPolicies.Basic192:
                case SecurityPolicies.Basic256:
                case SecurityPolicies.Basic128Rsa15:
                case SecurityPolicies.Basic192Rsa15:
                case SecurityPolicies.Basic256Rsa15:
                {
                    signatureData.Algorithm = SecurityAlgorithms.RsaSha1;
                    signatureData.Signature = RsaUtils.RsaPkcs15Sha1_Sign(new ArraySegment<byte>(dataToSign), certificate);
                    break;
                }

                case SecurityPolicies.None:
                {
                    signatureData.Algorithm = null;
                    signatureData.Signature = null;
                    break;
                }

                default:
                {
                    throw new ApplicationException(String.Format(
                        "Unsupported security policy: {0}",
                        securityPolicyUri));
                }
            }

            return signatureData;
        }

        /// <summary>
        /// Verifies the signature using the SecurityPolicyUri and return true if valid.
        /// </summary>
        public static bool Verify(X509Certificate2 certificate, string securityPolicyUri, byte[] dataToVerify, SignatureData signature)
        {
            // check if nothing to do.
            if (signature == null)
            {
                return true;
            }

            // nothing more to do if no encryption.
            if (String.IsNullOrEmpty(securityPolicyUri))
            {
                return true;
            }

            // decrypt data.
            switch (securityPolicyUri)
            {
                case SecurityPolicies.Basic128:
                case SecurityPolicies.Basic192:
                case SecurityPolicies.Basic256:
                case SecurityPolicies.Basic128Rsa15:
                case SecurityPolicies.Basic192Rsa15:
                case SecurityPolicies.Basic256Rsa15:
                {
                    if (signature.Algorithm == SecurityAlgorithms.RsaSha1)
                    {
                        return RsaUtils.RsaPkcs15Sha1_Verify(new ArraySegment<byte>(dataToVerify), signature.Signature, certificate);
                    }

                    break;
                }

                // always accept signatures if security is not used.
                case SecurityPolicies.None:
                {
                    return true;
                }

                default:
                {
                    throw new ApplicationException(String.Format(
                        "Unsupported security policy: {0}",
                        securityPolicyUri));
                }
            }

            throw new ApplicationException(String.Format(
                "Unexpected signature algorithm : {0}",
                signature.Algorithm));
        }
    }

    /// <summary>
    /// Defines functions to implement RSA cryptography.
    /// </summary>
    public static class RsaUtils
    {
        /// <summary>
        /// Return the plaintext block size for RSA OAEP encryption.
        /// </summary>
        public static int GetPlainTextBlockSize(X509Certificate2 encryptingCertificate, bool useOaep)
        {
            RSACryptoServiceProvider rsa = encryptingCertificate.PublicKey.Key as RSACryptoServiceProvider;

            if (rsa != null)
            {
                if (useOaep)
                {
                    return rsa.KeySize / 8 - 42;
                }
                else
                {
                    return rsa.KeySize / 8 - 11;
                }
            }

            return -1;
        }

        /// <summary>
        /// Return the ciphertext block size for RSA OAEP encryption.
        /// </summary>
        public static int GetCipherTextBlockSize(X509Certificate2 encryptingCertificate, bool useOaep)
        {
            RSACryptoServiceProvider rsa = encryptingCertificate.PublicKey.Key as RSACryptoServiceProvider;

            if (rsa != null)
            {
                return rsa.KeySize / 8;
            }

            return -1;
        }

        /// <summary>
        /// Returns the length of a RSA PKCS#1 v1.5 signature of a SHA1 digest.
        /// </summary>
        public static int RsaPkcs15Sha1_GetSignatureLength(X509Certificate2 signingCertificate)
        {
            RSACryptoServiceProvider rsa = (RSACryptoServiceProvider)signingCertificate.PublicKey.Key;

            if (rsa == null)
            {
                throw new ApplicationException("No public key for certificate.");
            }

            return rsa.KeySize / 8;
        }

        /// <summary>
        /// Computes an RSA/SHA1 PKCS#1 v1.5 signature.
        /// </summary>
        public static byte[] RsaPkcs15Sha1_Sign(
            ArraySegment<byte> dataToSign,
            X509Certificate2 signingCertificate)
        {
            // extract the private key.
            RSACryptoServiceProvider rsa = (RSACryptoServiceProvider)signingCertificate.PrivateKey;

            if (rsa == null)
            {
                throw new ApplicationException("No private key for certificate.");
            }

            // compute the hash of message.
            MemoryStream istrm = new MemoryStream(dataToSign.Array, dataToSign.Offset, dataToSign.Count, false);

            SHA1 hash = new SHA1Managed();
            byte[] digest = hash.ComputeHash(istrm);

            istrm.Close();

            // create the signature.
            return rsa.SignHash(digest, "SHA1");
        }

        /// <summary>
        /// Verifies an RSA/SHA1 PKCS#1 v1.5 signature.
        /// </summary>
        public static bool RsaPkcs15Sha1_Verify(
            ArraySegment<byte> dataToVerify,
            byte[] signature,
            X509Certificate2 signingCertificate)
        {
            // extract the private key.
            RSACryptoServiceProvider rsa = (RSACryptoServiceProvider)signingCertificate.PublicKey.Key;

            if (rsa == null)
            {
                throw new ApplicationException("No public key for certificate.");
            }

            // compute the hash of message.
            MemoryStream istrm = new MemoryStream(dataToVerify.Array, dataToVerify.Offset, dataToVerify.Count, false);

            SHA1 hash = new SHA1Managed();
            byte[] digest = hash.ComputeHash(istrm);

            istrm.Close();

            // verify signature.
            return rsa.VerifyHash(digest, "SHA1", signature);
        }

        /// <summary>
        /// Encrypts the data using RSA PKCS#1 v1.5 encryption.
        /// </summary>
        public static byte[] Encrypt(
            byte[] dataToEncrypt,
            X509Certificate2 encryptingCertificate,
            bool useOaep)
        {
            int plainTextSize = (dataToEncrypt.Length + 4) / GetPlainTextBlockSize(encryptingCertificate, useOaep) + 1;
            plainTextSize *= GetPlainTextBlockSize(encryptingCertificate, useOaep);

            int cipherTextSize = dataToEncrypt.Length / GetPlainTextBlockSize(encryptingCertificate, useOaep) + 1;
            cipherTextSize *= GetCipherTextBlockSize(encryptingCertificate, useOaep);

            byte[] plainText = new byte[plainTextSize];

            // encode length.
            plainText[0] = (byte)((0x000000FF & dataToEncrypt.Length));
            plainText[1] = (byte)((0x0000FF00 & dataToEncrypt.Length) >> 8);
            plainText[2] = (byte)((0x00FF0000 & dataToEncrypt.Length) >> 16);
            plainText[3] = (byte)((0xFF000000 & dataToEncrypt.Length) >> 24);

            // copy data.
            Array.Copy(dataToEncrypt, 0, plainText, 4, dataToEncrypt.Length);

            byte[] buffer = new byte[cipherTextSize];
            ArraySegment<byte> cipherText = Encrypt(new ArraySegment<byte>(plainText), encryptingCertificate, useOaep, new ArraySegment<byte>(buffer));
            System.Diagnostics.Debug.Assert(cipherText.Count == buffer.Length);

            return buffer;
        }

        /// <summary>
        /// Encrypts the data using RSA PKCS#1 v1.5 or OAEP encryption.
        /// </summary>
        public static ArraySegment<byte> Encrypt(
            ArraySegment<byte> dataToEncrypt,
            X509Certificate2 encryptingCertificate,
            bool useOaep,
            ArraySegment<byte> outputBuffer)
        {
            // get the encrypting key.
            RSACryptoServiceProvider rsa = (RSACryptoServiceProvider)encryptingCertificate.PublicKey.Key;

            if (rsa == null)
            {
                throw new ApplicationException("No public key for certificate.");
            }

            int inputBlockSize = GetPlainTextBlockSize(encryptingCertificate, useOaep);
            int outputBlockSize = rsa.KeySize / 8;

            int length = dataToEncrypt.Count / inputBlockSize;

            // verify the input data is the correct block size.
            if (dataToEncrypt.Count % inputBlockSize != 0)
            {
                throw new ApplicationException(String.Format(
                    "Message is not an integral multiple of the block size. Length = {0}, BlockSize = {1}.", 
                    dataToEncrypt.Count, 
                    inputBlockSize));
            }

            byte[] encryptedBuffer = outputBuffer.Array;

            MemoryStream ostrm = new MemoryStream(
                encryptedBuffer,
                outputBuffer.Offset,
                outputBuffer.Count);

            // encrypt body.
            byte[] input = new byte[inputBlockSize];

            for (int ii = dataToEncrypt.Offset; ii < dataToEncrypt.Offset + dataToEncrypt.Count; ii += inputBlockSize)
            {
                Array.Copy(dataToEncrypt.Array, ii, input, 0, input.Length);
                byte[] cipherText = rsa.Encrypt(input, useOaep);
                ostrm.Write(cipherText, 0, cipherText.Length);
            }

            ostrm.Close();

            // return buffer
            return new ArraySegment<byte>(
                encryptedBuffer,
                outputBuffer.Offset,
                (dataToEncrypt.Count / inputBlockSize) * outputBlockSize);
        }

        /// <summary>
        /// Encrypts the data using RSA PKCS#1 v1.5 encryption.
        /// </summary>
        public static byte[] Decrypt(
            ArraySegment<byte> dataToDecrypt,
            X509Certificate2 encryptingCertificate,
            bool useOaep)
        {
            int plainTextSize = dataToDecrypt.Count / GetCipherTextBlockSize(encryptingCertificate, useOaep);
            plainTextSize *= GetPlainTextBlockSize(encryptingCertificate, useOaep);

            byte[] buffer = new byte[plainTextSize];
            ArraySegment<byte> plainText = Decrypt(dataToDecrypt, encryptingCertificate, useOaep, new ArraySegment<byte>(buffer));
            System.Diagnostics.Debug.Assert(plainText.Count == buffer.Length);

            // decode length.
            int length = 0;

            length += (((int)plainText.Array[plainText.Offset + 0]));
            length += (((int)plainText.Array[plainText.Offset + 1]) << 8);
            length += (((int)plainText.Array[plainText.Offset + 2]) << 16);
            length += (((int)plainText.Array[plainText.Offset + 3]) << 24);

            byte[] decryptedData = new byte[length];
            Array.Copy(plainText.Array, plainText.Offset + 4, decryptedData, 0, length);

            return decryptedData;
        }

        /// <summary>
        /// Des the message using RSA OAEP encryption.
        /// </summary>
        public static ArraySegment<byte> Decrypt(
            ArraySegment<byte> dataToDecrypt,
            X509Certificate2 encryptingCertificate,
            bool useOaep,
            ArraySegment<byte> outputBuffer)
        {
            // get the encrypting key.
            RSACryptoServiceProvider rsa = (RSACryptoServiceProvider)encryptingCertificate.PrivateKey;

            if (rsa == null)
            {
                throw new ApplicationException("No private key for certificate.");
            }

            int inputBlockSize = rsa.KeySize / 8;
            int outputBlockSize = GetPlainTextBlockSize(encryptingCertificate, useOaep);

            // verify the input data is the correct block size.
            if (dataToDecrypt.Count % inputBlockSize != 0)
            {
                throw new ApplicationException(String.Format(
                    "Message is not an integral multiple of the block size. Length = {0}, BlockSize = {1}.", 
                    dataToDecrypt.Count, 
                    inputBlockSize));
            }

            byte[] decryptedBuffer = outputBuffer.Array;

            MemoryStream ostrm = new MemoryStream(
                decryptedBuffer,
                outputBuffer.Offset,
                outputBuffer.Count);

            // decrypt body.
            byte[] input = new byte[inputBlockSize];

            for (int ii = dataToDecrypt.Offset; ii < dataToDecrypt.Offset + dataToDecrypt.Count; ii += inputBlockSize)
            {
                Array.Copy(dataToDecrypt.Array, ii, input, 0, input.Length);
                byte[] plainText = rsa.Decrypt(input, useOaep);
                ostrm.Write(plainText, 0, plainText.Length);
            }

            ostrm.Close();

            // return buffers.
            return new ArraySegment<byte>(decryptedBuffer, outputBuffer.Offset, (dataToDecrypt.Count / inputBlockSize) * outputBlockSize);
        }
    }

    /// <summary>
    /// Stores a block of encypted data.
    /// </summary>
    public class EncryptedData
    {
        #region Private Members
        /// <summary>
        /// The algorithm used to encrypt the data.
        /// </summary>
        public string Algorithm
        {
            get { return m_algorithm; }
            set { m_algorithm = value; }
        }

        /// <summary>
        /// The encrypted data.
        /// </summary>
        public byte[] Data
        {
            get { return m_data; }
            set { m_data = value; }
        }
        #endregion

        #region Private Members
        private string m_algorithm;
        private byte[] m_data;
        #endregion
    }

    /// <summary>
    /// Defines constants for key security policies.
    /// </summary>
    public static class SecurityAlgorithms
    {
        /// <summary>
        /// The HMAC-SHA1 algorithm used to create symmetric key signatures.
        /// </summary>
        public const string HmacSha1 = System.IdentityModel.Tokens.SecurityAlgorithms.HmacSha1Signature;

        /// <summary>
        /// The HMAC-SHA256 algorithm used to create symmetric key signatures.
        /// </summary>
        public const string HmacSha256 = System.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature;

        /// <summary>
        /// The RSA-SHA1 algorithm used to create asymmetric key signatures.
        /// </summary>
        public const string RsaSha1 = System.IdentityModel.Tokens.SecurityAlgorithms.RsaSha1Signature;

        /// <summary>
        /// The RSA-SHA256 algorithm used to create asymmetric key signatures.
        /// </summary>
        public const string RsaSha256 = System.IdentityModel.Tokens.SecurityAlgorithms.RsaSha256Signature;

        /// <summary>
        /// The SHA1 algorithm used to create message digests.
        /// </summary>
        public const string Sha1 = System.IdentityModel.Tokens.SecurityAlgorithms.Sha1Digest;

        /// <summary>
        /// The SHA256 algorithm used to create message digests.
        /// </summary>
        public const string Sha256 = System.IdentityModel.Tokens.SecurityAlgorithms.Sha256Digest;

        /// <summary>
        /// The SHA512 algorithm used to create message digests.
        /// </summary>
        public const string Sha512 = System.IdentityModel.Tokens.SecurityAlgorithms.Sha512Digest;

        /// <summary>
        /// The AES128 algorithm used to encrypt data.
        /// </summary>
        public const string Aes128 = System.IdentityModel.Tokens.SecurityAlgorithms.Aes128Encryption;

        /// <summary>
        /// The AES192 algorithm used to encrypt data.
        /// </summary>
        public const string Aes192 = System.IdentityModel.Tokens.SecurityAlgorithms.Aes192Encryption;

        /// <summary>
        /// The AES256 algorithm used to encrypt data.
        /// </summary>
        public const string Aes256 = System.IdentityModel.Tokens.SecurityAlgorithms.Aes256Encryption;

        /// <summary>
        /// The AES128 algorithm used to encrypt keys.
        /// </summary>        
        public const string KwAes128 = System.IdentityModel.Tokens.SecurityAlgorithms.Aes128KeyWrap;

        /// <summary>
        /// The AES192 algorithm used to encrypt keys.
        /// </summary>        
        public const string KwAes192 = System.IdentityModel.Tokens.SecurityAlgorithms.Aes192KeyWrap;

        /// <summary>
        /// The AES256 algorithm used to encrypt keys.
        /// </summary>        
        public const string KwAes256 = System.IdentityModel.Tokens.SecurityAlgorithms.Aes256KeyWrap;

        /// <summary>
        /// The RSA-OAEP algorithm used to encrypt data.
        /// </summary>        
        public const string RsaOaep = "http://www.w3.org/2001/04/xmlenc#rsa-oaep";

        /// <summary>
        /// The RSA-PKCSv1.5 algorithm used to encrypt data.
        /// </summary>        
        public const string Rsa15 = "http://www.w3.org/2001/04/xmlenc#rsa-1_5";

        /// <summary>
        /// The RSA-OAEP algorithm used to encrypt keys.
        /// </summary>        
        public const string KwRsaOaep = System.IdentityModel.Tokens.SecurityAlgorithms.RsaOaepKeyWrap;

        /// <summary>
        /// The RSA-PKCSv1.5 algorithm used to encrypt keys.
        /// </summary>        
        public const string KwRsa15 = System.IdentityModel.Tokens.SecurityAlgorithms.RsaV15KeyWrap;

        /// <summary>
        /// The P-SHA1 algorithm used to generate keys.
        /// </summary>
        public const string PSha1 = System.IdentityModel.Tokens.SecurityAlgorithms.Psha1KeyDerivation;
    }
}
