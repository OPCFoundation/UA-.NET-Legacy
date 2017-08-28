/* Copyright (c) 1996-2016, OPC Foundation. All rights reserved.
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
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Opc.Ua.Bindings
{
    /// <summary>
    /// Manages the server side of a UA TCP channel.
    /// </summary>
    public partial class TcpChannel
    {
        /// <summary>
        /// Return the plaintext block size for RSA OAEP encryption.
        /// </summary>
        protected static int Ecc_GetPlainTextBlockSize(X509Certificate2 encryptingCertificate)
        {
            return 1;
        }

        /// <summary>
        /// Return the ciphertext block size for RSA OAEP encryption.
        /// </summary>
        protected static int Ecc_GetCipherTextBlockSize(X509Certificate2 encryptingCertificate)
        {
            return 1;
        }

        /// <summary>
        /// Returns the length of a RSA PKCS#1 v1.5 signature.
        /// </summary>
        private static int Ecdsa_GetSignatureLength(X509Certificate2 signingCertificate)
        {
            using (var ecdsa = signingCertificate.GetECDsaPublicKey())
            {
                if (ecdsa == null)
                {
                    throw ServiceResultException.Create(StatusCodes.BadSecurityChecksFailed, "No public key for certificate.");
                }

                return ecdsa.KeySize / 4;
            }
        }

        /// <summary>
        /// Creates an RSA PKCS#1 v1.5 signature of a hash algorithm for the stream.
        /// </summary>
        private static byte[] Ecdsa_Sign(
            ArraySegment<byte> dataToSign,
            X509Certificate2 signingCertificate,
            HashAlgorithmName algorithm)
        {
            // extract the private key.
            using (var ecdsa = signingCertificate.GetECDsaPrivateKey())
            {
                if (ecdsa == null)
                {
                    throw ServiceResultException.Create(StatusCodes.BadSecurityChecksFailed, "No private key for certificate.");
                }

                // create the signature.
                return ecdsa.SignData(dataToSign.Array, dataToSign.Offset, dataToSign.Count, algorithm);
            }
        }


        /// <summary>
        /// Verifies an RSA PKCS#1 v1.5 signature of a hash algorithm for the stream.
        /// </summary>
        private static bool Ecdsa_Verify(
            ArraySegment<byte> dataToVerify,
            byte[]             signature,
            X509Certificate2   signingCertificate,
            HashAlgorithmName  algorithm)
        {
            // extract the public key.
            using (var ecdsa = signingCertificate.GetECDsaPublicKey())
            {

                if (ecdsa == null)
                {
                    throw ServiceResultException.Create(StatusCodes.BadSecurityChecksFailed, "No public key for certificate.");
                }

                // verify signature.
                if (!ecdsa.VerifyData(dataToVerify.Array, dataToVerify.Offset, dataToVerify.Count, signature, algorithm))
                {
                    string messageType = new UTF8Encoding().GetString(dataToVerify.Array, dataToVerify.Offset, 4);
                    int messageLength = BitConverter.ToInt32(dataToVerify.Array, dataToVerify.Offset + 4);
                    string actualSignature = Utils.ToHexString(signature);

                    Utils.Trace(
                        "Could not validate signature.\r\nCertificate={0}, MessageType={1}, Length={2}\r\nActualSignature={3}",
                        signingCertificate.Subject,
                        messageType,
                        messageLength,
                        actualSignature);

                    return false;
                }
            }

            return true;
        }

        private ECDiffieHellmanCng m_localEmpheralKey;
        private ECDiffieHellmanCng m_remoteEmpheralKey;
        
        private byte[] Ecdh_NistP256_DeriveSecret()
        {
            return m_localEmpheralKey.DeriveKeyMaterial(m_remoteEmpheralKey.PublicKey);
        }
        
        private byte[] Ecdh_NistP256_CreateNonce(int nonceLength)
        {
            if (m_localEmpheralKey != null)
            {
                m_localEmpheralKey.Dispose();
                m_localEmpheralKey = null;
            }

            CngKey key = CngKey.Create(CngAlgorithm.ECDiffieHellmanP256, null, new CngKeyCreationParameters() { ExportPolicy = CngExportPolicies.AllowPlaintextExport });
            m_localEmpheralKey = new ECDiffieHellmanCng(key);
            m_localEmpheralKey.KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash;
            m_localEmpheralKey.HashAlgorithm = CngAlgorithm.Sha512;
            
            var publicKey = key.Export(CngKeyBlobFormat.EccPublicBlob);
            byte[] nonce = new byte[key.KeySize/4];
            Buffer.BlockCopy(publicKey, 8, nonce, 0, nonce.Length);
            return nonce;
        }
        
        private void Ecdh_NistP256_ValidateNonce(byte[] nonce)
        {
            if (m_remoteEmpheralKey != null)
            {
                m_remoteEmpheralKey.Dispose();
                m_remoteEmpheralKey = null;
            }

            var keyLength = nonce.Length/2;

            using (var ostrm = new System.IO.MemoryStream())
            {
                ostrm.WriteByte(0x45);
                ostrm.WriteByte(0x43);
                ostrm.WriteByte(0x4B);
                ostrm.WriteByte(0x31);
                ostrm.Write(BitConverter.GetBytes(nonce.Length/2), 0, 4);
                ostrm.Write(nonce, 0, nonce.Length);
                ostrm.Close();

                var ephemeralKey = ostrm.ToArray();

                var key = CngKey.Import(ephemeralKey, CngKeyBlobFormat.EccPublicBlob);

                m_remoteEmpheralKey = new ECDiffieHellmanCng(key);
                m_remoteEmpheralKey.KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash;
                m_remoteEmpheralKey.HashAlgorithm = CngAlgorithm.Sha512;
            }
        }

        /// <summary>
        /// Encrypts the message using RSA PKCS#1 v1.5 encryption.
        /// </summary>
        private ArraySegment<byte> No_Encrypt(
            ArraySegment<byte> dataToEncrypt,
            ArraySegment<byte> headerToCopy)
        {
            byte[] encryptedBuffer = BufferManager.TakeBuffer(SendBufferSize, "Ecc_Encrypt");

            Array.Copy(headerToCopy.Array, headerToCopy.Offset, encryptedBuffer, 0, headerToCopy.Count);
            Array.Copy(dataToEncrypt.Array, dataToEncrypt.Offset, encryptedBuffer, headerToCopy.Count, dataToEncrypt.Count);
            
            return new ArraySegment<byte>(encryptedBuffer, 0, dataToEncrypt.Count + headerToCopy.Count);
        }

        /// <summary>
        /// Decrypts the message using RSA PKCS#1 v1.5 encryption.
        /// </summary>
        private ArraySegment<byte> No_Decrypt(
            ArraySegment<byte> dataToDecrypt,
            ArraySegment<byte> headerToCopy)
        {   
            byte[] decryptedBuffer = BufferManager.TakeBuffer(SendBufferSize, "Ecc_Decrypt");

            Array.Copy(headerToCopy.Array, headerToCopy.Offset, decryptedBuffer, 0, headerToCopy.Count);
            Array.Copy(dataToDecrypt.Array, dataToDecrypt.Offset, decryptedBuffer, headerToCopy.Count, dataToDecrypt.Count);
            
            return new ArraySegment<byte>(decryptedBuffer, 0, dataToDecrypt.Count + headerToCopy.Count);
        }
    }
}
