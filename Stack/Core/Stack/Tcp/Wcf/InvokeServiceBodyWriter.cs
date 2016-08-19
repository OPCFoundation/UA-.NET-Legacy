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
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.Serialization;
using System.Xml;
using System.IO;
using System.Diagnostics;

namespace Opc.Ua.Bindings
{
    /// <summary>
    /// A writer used to serializing the body of a InvokeService request or response.
    /// </summary>
    public class InvokeServiceBodyWriter : BodyWriter
    {
        /// <summary>
        /// Stores the buffer for writing.
        /// </summary>
        public InvokeServiceBodyWriter(byte[] data, bool isRequest) : base(true)
        {
            m_data = data;
            m_isRequest = isRequest;
        }

        /// <summary>
        /// Writes the body to the stream.
        /// </summary>
        protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
        {
            if (m_isRequest)
            {
                writer.WriteStartElement("InvokeServiceRequest", Namespaces.OpcUaXsd);
            }
            else
            {
                writer.WriteStartElement("InvokeServiceResponse", Namespaces.OpcUaXsd);
            }

            if (m_data != null)
            {
                writer.WriteBase64(m_data, 0, m_data.Length);
            }

            writer.WriteEndElement();
        }

        #region Private Fields
        private byte[] m_data = null;
        private bool m_isRequest = false;
        #endregion
    }

    #region Class MessageProperties
    /// <summary>
    /// String constants using for message properties.
    /// </summary>
    public static class MessageProperties
    {
        /// <summary>
        /// The body of the request message.
        /// </summary>
        public const string RequestBody = "RB";

        /// <summary>
        /// The encoded message body.
        /// </summary>
        public const string EncodedBody = "EB";

        /// <summary>
        /// The unencoded message body.
        /// </summary>
        public const string UnencodedBody = "UB";
    }
    #endregion
}
