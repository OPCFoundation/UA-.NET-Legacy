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

using Opc.Ua.Security.Certificates;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using X509Extension = System.Security.Cryptography.X509Certificates.X509Extension;

namespace Opc.Ua
{
    /// <summary>
    /// Stores the authority key identifier extension.
    /// </summary>
    /// <remarks>
    ///     id-ce-authorityKeyIdentifier OBJECT IDENTIFIER ::=  { id-ce 35 }
    ///     AuthorityKeyIdentifier ::= SEQUENCE {
    ///         keyIdentifier[0] KeyIdentifier           OPTIONAL,
    ///         authorityCertIssuer[1] GeneralNames            OPTIONAL,
    ///         authorityCertSerialNumber[2] CertificateSerialNumber OPTIONAL
    ///         }
    ///     KeyIdentifier::= OCTET STRING
    /// </remarks>
    public class X509AuthorityKeyIdentifierExtension : X509Extension
    {
        #region Constructors
        /// <summary>
        /// Creates an empty extension.
        /// </summary>
        protected X509AuthorityKeyIdentifierExtension()
        {
        }

        /// <summary>
        /// Creates an extension from ASN.1 encoded data.
        /// </summary>
        public X509AuthorityKeyIdentifierExtension(AsnEncodedData encodedExtension, bool critical)
        :
            this(encodedExtension.Oid, encodedExtension.RawData, critical)
        {
        }

        /// <summary>
        /// Creates an extension from ASN.1 encoded data.
        /// </summary>
        public X509AuthorityKeyIdentifierExtension(string oid, byte[] rawData, bool critical)
        :
            this(new Oid(oid, kFriendlyName), rawData, critical)
        {
        }

        /// <summary>
        /// Creates an extension from ASN.1 encoded data.
        /// </summary>
        public X509AuthorityKeyIdentifierExtension(Oid oid, byte[] rawData, bool critical)
        :
            base(oid, rawData, critical)
        {
            Decode(rawData);
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Returns a formatted version of the Authority Key Identifier as a string.
        /// </summary>
        public override string Format(bool multiLine)
        {
            StringBuilder buffer = new StringBuilder();

            if (m_keyIdentifier != null && m_keyIdentifier.Length > 0)
            {
                if (buffer.Length > 0)
                {
                    if (multiLine)
                    {
                        buffer.AppendLine();
                    }
                    else
                    {
                        buffer.Append(", ");
                    }
                }

                buffer.Append(kKeyIdentifier);
                buffer.Append('=');
                buffer.Append(m_keyIdentifier.ToHexString());
            }

            if (m_issuer != null)
            {
                if (multiLine)
                {
                    buffer.AppendLine();
                }
                else
                {
                    buffer.Append(", ");
                }

                buffer.Append(kIssuer);
                buffer.Append('=');
                buffer.Append(m_issuer.Format(true));
            }

            if (m_serialNumber != null && m_serialNumber.Length > 0)
            {
                if (buffer.Length > 0)
                {
                    if (!multiLine)
                    {
                        buffer.Append(", ");
                    }
                }

                buffer.Append(kSerialNumber);
                buffer.Append('=');
                buffer.Append(m_serialNumber);
            }
            return buffer.ToString();

        }


        /// <summary>
        /// Initializes the extension from ASN.1 encoded data.
        /// </summary>
        public override void CopyFrom(AsnEncodedData asnEncodedData)
        {
            if (asnEncodedData == null) throw new ArgumentNullException("asnEncodedData");
            this.Oid = asnEncodedData.Oid;
            Decode(asnEncodedData.RawData);
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// The OID for a Authority Key Identifier extension.
        /// </summary>
        public const string AuthorityKeyIdentifierOid = "2.5.29.1";

        /// <summary>
        /// The alternate OID for a Authority Key Identifier extension.
        /// </summary>
        public const string AuthorityKeyIdentifier2Oid = "2.5.29.35";

        /// <summary>
        /// The identifier for the key as a little endian hexadecimal string.
        /// </summary>
        public string KeyIdentifier => m_keyIdentifier.ToHexString();

        /// <summary>
        /// The identifier for the key as a byte array.
        /// </summary>
        public byte[] GetKeyIdentifier() => m_keyIdentifier;

        /// <summary>
        /// A list of distinguished names for the issuer.
        /// </summary>
        public X500DistinguishedName Issuer => m_issuer;

        /// <summary>
        /// A list of distinguished names for the issuer.
        /// </summary>
        /// <summary>
        /// The identifier for the key.
        /// </summary>
        public string KeyId
        {
            get { return m_keyId; }
        }

        /// <summary>
        /// A list of names for the issuer.
        /// </summary>
        public string[] AuthorityNames
        {
            get { return m_authorityNames; }
        }

        /// <summary>
        /// The serial number for the key.
        /// </summary>
        public string SerialNumber
        {
            get { return m_serialNumber; }
        }
        #endregion

        #region Private Methods

        private void Decode(byte[] data)
        {
            if (base.Oid.Value == AuthorityKeyIdentifierOid ||
                base.Oid.Value == AuthorityKeyIdentifier2Oid)
            {
                try
                {
                    #region Legacy Property holders
                    byte[] keyId;
                    byte[] serialNumber;

                    if (base.Oid.Value == AuthorityKeyIdentifierOid)
                    {
                        CertificateFactory.ParseAuthorityKeyIdentifierExtension(
                            data,
                            out keyId,
                            out m_authorityNames,
                            out serialNumber);
                    }
                    else
                    {
                        CertificateFactory.ParseAuthorityKeyIdentifierExtension2(
                            data,
                            out keyId,
                            out m_authorityNames,
                            out serialNumber);
                    }

                    m_keyId = Utils.ToHexString(keyId);
                    m_serialNumber = null;


                    // the serial number is a little endian integer so must convert to string in reverse order. 
                    if (serialNumber != null)
                    {
                        StringBuilder builder = new StringBuilder(serialNumber.Length * 2);

                        for (int ii = serialNumber.Length - 1; ii >= 0; ii--)
                        {
                            builder.AppendFormat("{0:X2}", serialNumber[ii]);
                        }

                        m_serialNumber = builder.ToString();
                    }

                    #endregion
                    m_keyIdentifier = keyId;

                    if (m_authorityNames != null)
                    {
                        StringBuilder builder = new StringBuilder();

                        for (int ii = m_authorityNames.Length - 1; ii >= 0; ii--)
                        {
                            builder.Append(m_authorityNames[ii]);
                        }

                        m_issuer = new X500DistinguishedName(builder.ToString());
                    }

                    return;
                }
                catch (Exception ace)
                {
                    throw new CryptographicException("Failed to decode the AuthorityKeyIdentifier extension.", ace);
                }
            }
            throw new CryptographicException("Failed to decode the AuthorityKeyIdentifier extention; No valid data");
        }
        #endregion

        #region Private Fields
        /// <summary>
        /// Authority Key Identifier extension string
        /// definitions see RFC 5280 4.2.1.1
        /// </summary>

        #region Legacy
        private string m_keyId;
        private string[] m_authorityNames;
        private string m_serialNumber;
        #endregion
        private const string kKeyIdentifier = "KeyID";
        private const string kIssuer = "Issuer";
        private const string kSerialNumber = "SerialNumber";
        private const string kFriendlyName = "Authority Key Identifier";
        private byte[] m_keyIdentifier;
        private X500DistinguishedName m_issuer;
        #endregion  
    }
}
