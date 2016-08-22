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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;

namespace Opc.Ua.Gds
{
    [DataContract(Namespace=Namespaces.OpcUaXsd)]
    public class CertificateWrapper : IFormattable, IEncodeable
    {
        public X509Certificate2 Certificate { get; set; }

        [DataMember(Order = 1)]
        public string SubjectName
        {
            get
            {
                if (Certificate != null)
                {
                    return Certificate.Subject;
                }

                return null;
            }

            private set { }
        }

        [DataMember(Order = 2)]
        public string IssuerName
        {
            get
            {
                if (Certificate != null)
                {
                    return Certificate.Issuer;
                }

                return null;
            }

            private set { }
        }

        [DataMember(Order = 3)]
        public DateTime ValidFrom
        {
            get
            {
                if (Certificate != null)
                {
                    return Certificate.NotBefore;
                }

                return DateTime.MinValue;
            }

            private set { }
        }

        [DataMember(Order = 4)]
        public DateTime ValidTo
        {
            get
            {
                if (Certificate != null)
                {
                    return Certificate.NotAfter;
                }

                return DateTime.MinValue;
            }

            private set { }
        }

        [DataMember(Order = 5)]
        public string SerialNumber
        {
            get
            {
                if (Certificate != null)
                {
                    return Certificate.SerialNumber;
                }

                return null;
            }

            private set { }
        }

        [DataMember(Order = 6)]
        public string Thumbprint
        {
            get
            {
                if (Certificate != null)
                {
                    return Certificate.Thumbprint;
                }

                return null;
            }

            private set { }
        }

        [DataMember(Order = 7)]
        public string SignatureAlgorithm
        {
            get
            {
                if (Certificate != null)
                {
                    return Certificate.SignatureAlgorithm.FriendlyName;
                }

                return null;
            }

            private set { }
        }

        [DataMember(Order = 8)]
        public string PublicKeyAlgorithm
        {
            get
            {
                if (Certificate != null)
                {
                    return Certificate.PublicKey.Oid.FriendlyName;
                }

                return null;
            }

            private set { }
        }

        [DataMember(Order = 9)]
        public byte[] PublicKey
        {
            get
            {
                if (Certificate != null)
                {
                    return Certificate.PublicKey.EncodedKeyValue.RawData;
                }

                return null;
            }

            private set { }
        }


        [DataMember(Order = 10)]
        public int KeySize
        {
            get
            {
                if (Certificate != null)
                {
                    return Certificate.PublicKey.Key.KeySize;
                }

                return 0;
            }

            private set { }
        }

        [DataMember(Order = 11)]
        public string ApplicationUri
        {
            get
            {
                if (Certificate != null)
                {
                    try
                    {
                        return Utils.GetApplicationUriFromCertficate(Certificate);
                    }
                    catch (Exception e)
                    {
                        return e.Message;
                    }
                }

                return null;
            }

            private set { }
        }

        [DataMember(Order = 12)]
        public IList<string> Domains
        {
            get
            {
                if (Certificate != null)
                {
                    try
                    {
                        return Utils.GetDomainsFromCertficate(Certificate);
                    }
                    catch (Exception e)
                    {
                        return new string[] { e.Message };
                    }
                }

                return null;
            }

            private set { }
        }

        public override string ToString()
        {
            return ToString(null, null);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return SubjectName;
        }

        #region IEncodeable Members
        public ExpandedNodeId TypeId
        {
            get { return NodeId.Null; }
        }

        public ExpandedNodeId BinaryEncodingId
        {
            get { return NodeId.Null; }
        }

        public ExpandedNodeId XmlEncodingId
        {
            get { return NodeId.Null; }
        }

        public void Encode(IEncoder encoder)
        {
            throw new NotImplementedException();
        }

        public void Decode(IDecoder decoder)
        {
            throw new NotImplementedException();
        }

        public bool IsEqual(IEncodeable encodeable)
        {
            throw new NotImplementedException();
        }

        public object Clone()
        {
            return new CertificateWrapper() { Certificate = this.Certificate };
        }
        #endregion
    }
}
