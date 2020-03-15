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
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System.IO;
using Amqp;
using Amqp.Framing;
using Amqp.Types;

namespace Opc.Ua.Bindings
{
    /// <remarks/>
    public interface IAmqpListener
    {
        /// <remarks/>
        void Close();

        /// <remarks/>
        string AmqpNodeName { get; set; }

        /// <remarks/>
        Task ListenAsync(AmqpListenerSettings settings, string amqpNodeName);

        /// <remarks/>
        Task<IAmqpConnection> ConnectAsync(string amqpNodeName, string serverKeyName = null, string serverKeyValue = null);

        /// <remarks/>
        void RegisterSink(string groupId, IAmqpMessageSink sink);

        /// <remarks/>
        void UnregisterSink(string groupId);
    }

    /// <remarks/>
    public interface IAmqpMessageSink
    {
        /// <remarks/>
        void OnMessage(object sender, AmqpReceiveMessageEventArgs e);
    }


    /// <remarks/>
    public class AmqpListenerSettings
    {
        /// <remarks/>
        public string BrokerUrl;
        /// <remarks/>
        public BrokerTransport BrokerTransport;
        /// <remarks/>
        public bool UseSasl;
        /// <remarks/>
        public string ReplyToNodeName;
        /// <remarks/>
        public string ReceiveKeyName;
        /// <remarks/>
        public string ReceiveKeyValue;
        /// <remarks/>
        public string SendKeyName;
        /// <remarks/>
        public string SendKeyValue;
        /// <remarks/>
        public uint TokenRenewalInterval;
        /// <remarks/>
        public Dictionary<string, KeyValuePair<string, string>> ServerKeys;
    }

    /// <remarks/>
    public class AmqpReceiveMessageEventArgs
    {
        /// <remarks/>
        public AmqpReceiveMessageEventArgs(
            string messageId,
            string correlationId,
            string replyTo,
            string contentType, 
            string groupId,
            uint groupSequence, 
            string accessToken,
            ArraySegment<byte> body)
        {
            MessageId = messageId;
            CorrelationId = correlationId;
            ReplyTo = replyTo;
            ContentType = contentType;
            GroupId = groupId;
            GroupSequence = groupSequence;
            AccessToken = accessToken;
            Body = body;
        }

        /// <remarks/>
        public string MessageId { get; private set; }

        /// <remarks/>
        public string CorrelationId { get; private set; }

        /// <remarks/>
        public string ReplyTo { get; private set; }

        /// <remarks/>
        public string ContentType { get; private set; }

        /// <remarks/>
        public string GroupId { get; private set; }

        /// <remarks/>
        public uint GroupSequence { get; private set; }

        /// <remarks/>
        public string AccessToken { get; private set; }

        /// <remarks/>
        public uint RequestId { get; set; }

        /// <remarks/>
        public ArraySegment<byte> Body { get; private set; }
    }
}
