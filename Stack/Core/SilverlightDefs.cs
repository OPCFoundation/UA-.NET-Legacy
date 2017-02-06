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

#if SILVERLIGHT
using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace System
{
    public class SerializableAttribute : Attribute
    {
    }
}

namespace System.ComponentModel
{
    public class DesignerCategoryAttribute : Attribute
    {
        public DesignerCategoryAttribute(string dummy)
        {
        }
    }
}

namespace System.Security
{
    public class SecureString
    {
    }
}

namespace System.IdentityModel.Tokens
{
    public class SecureString
    {
    }

    public class SecurityToken
    {
    }
}

namespace System.IdentityModel.Selectors
{
}

namespace System.Security.Cryptography.X509Certificates
{
    public class X500DistinguishedName
    {
        public string Name { get; set; }
    }

    public class X509Certificate2 : X509Certificate
    {
        public X509Certificate2()
        {
        }

        public X509Certificate2(byte[] bytes)
            : base(bytes)
        {
        }

        public string FriendlyName
        {
            get { return null; }
        }

        public X500DistinguishedName SubjectName
        {
            get { return new X500DistinguishedName(); }
        }

        public string Thumbprint
        {
            get { return GetCertHashString(); }
        }

        public bool HasPrivateKey
        {
            get { return false; }
        }
    }

    public class X509Certificate2Collection : System.Collections.Generic.List<X509Certificate2>
    {
    }

    public class X509CertificateValidator
    {
    }   
}

namespace System.Collections.Generic
{
    public class SortedDictionary<K,V> : System.Collections.Generic.Dictionary<K,V> 
    {
    }
}

namespace System.Net
{
    public static class Dns
    {
        public static string GetHostName()
        {
            return "localhost";
        }
    }
}

namespace System.Runtime.Serialization
{
    public interface IExtensibleDataObject
    {
    }

    public class ExtensionDataObject
    {
    }
}

namespace System.Xml
{
    public class XmlDocument
    {
        public string InnerXml
        {
            get
            {
                if (DocumentElement != null)
                {
                    return DocumentElement.OuterXml;
                }

                return null;
            }

            set
            {
                if (DocumentElement == null)
                {
                    DocumentElement = new XmlElement();
                }

                DocumentElement.OuterXml = value;
            }
        }

        public XmlElement DocumentElement { get; set; }
    }

    public class XmlElement
    {
        public string NamespaceURI { get; set; }
        public string LocalName { get; set; }
        public string Prefix { get; set; }
        public string Name { get; set; }
        public string OuterXml { get; set; }
    }
}

namespace Opc.Ua
{
    public interface ICloneable
    {
        Object Clone();
    }

    public class SerializationInfo
    {
    }
}
#endif
