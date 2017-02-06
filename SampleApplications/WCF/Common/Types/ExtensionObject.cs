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
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Xml;
using System.Text;

namespace Opc.Ua
{
    /// <summary>
    /// Adds constructors, comparison functions and format capabilities to the ExtensionObject class.
	/// </summary>
    public partial class ExtensionObject : IFormattable
    {
        #region Public Methods
        /// <summary>
        /// Creates an empty extension object.
        /// </summary>
        public ExtensionObject()
        {
        }

        /// <summary>
        /// Serializes the value using XML and stores it in the extension object.
        /// </summary>
        public ExtensionObject(ExpandedNodeId typeId, object value)
        {
            TypeId = typeId;

            StringBuilder buffer = new StringBuilder();

            using (XmlWriter writer = XmlWriter.Create(buffer))
            {
                DataContractSerializer serializer = new DataContractSerializer(value.GetType());
                serializer.WriteObject(writer, value);
            }

            XmlDocument document = new XmlDocument();
            document.InnerXml = buffer.ToString();

            ExtensionObjectBody body = new ExtensionObjectBody();
            body.Nodes = new XmlNode[] { document.DocumentElement };
            Body = body;
        }

        /// <summary>
        /// Parses the body and returns an object.
        /// </summary>
        public object ParseBody(Type type)
        {
            if (this.Body != null && this.Body.Nodes != null && this.Body.Nodes.Length > 0)
            {
                using (XmlNodeReader reader = new XmlNodeReader(this.Body.Nodes[0]))
                {
                    DataContractSerializer serializer = new DataContractSerializer(type);
                    return serializer.ReadObject(reader);
                }
            }

            return null;
        }
        #endregion

        #region IFormattable Members
        /// <summary>
        /// Returns the string representation of the object.
        /// </summary>
        /// <remarks>
        /// Returns the string representation of the object.
        /// </remarks>
        public override string ToString()
        {
            return ToString(null, null);
        }

        /// <summary>
        /// Returns the string representation of the object.
        /// </summary>
        public string ToString(string format, IFormatProvider provider)
        {
            if (format == null)
            {                
                return String.Format(provider, "{0}", TypeId);
            }

            throw new FormatException(String.Format("Invalid format string: '{0}'.", format));
        }
        #endregion
    }
}
