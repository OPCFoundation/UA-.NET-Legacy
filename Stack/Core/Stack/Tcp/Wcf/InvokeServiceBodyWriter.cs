/* ========================================================================
 * Copyright (c) 2005-2013 The OPC Foundation, Inc. All rights reserved.
 *
 * OPC Reciprocal Community Binary License ("RCBL") Version 1.00
 * 
 * Unless explicitly acquired and licensed from Licensor under another 
 * license, the contents of this file are subject to the Reciprocal 
 * Community Binary License ("RCBL") Version 1.00, or subsequent versions 
 * as allowed by the RCBL, and You may not copy or use this file in either 
 * source code or executable form, except in compliance with the terms and 
 * conditions of the RCBL.
 * 
 * All software distributed under the RCBL is provided strictly on an 
 * "AS IS" basis, WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESS OR IMPLIED, 
 * AND LICENSOR HEREBY DISCLAIMS ALL SUCH WARRANTIES, INCLUDING WITHOUT 
 * LIMITATION, ANY WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR 
 * PURPOSE, QUIET ENJOYMENT, OR NON-INFRINGEMENT. See the RCBL for specific 
 * language governing rights and limitations under the RCBL.
 *
 * The complete license agreement can be found here:
 * http://opcfoundation.org/License/RCBL/1.00/
 * ======================================================================*/

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
