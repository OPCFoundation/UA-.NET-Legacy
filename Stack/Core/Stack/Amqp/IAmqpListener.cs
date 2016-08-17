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
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using Amqp;
using Amqp.Framing;
using Amqp.Types;

namespace Opc.Ua.Bindings
{
    public interface IAmqpListener
    {
        void Close();

        string AmqpNodeName { get; set; }

        Task ListenAsync(AmqpListenerSettings settings, string amqpNodeName);

        Task<IAmqpConnection> ConnectAsync(string amqpNodeName, bool useListenerCredentials);

        void RegisterSink(string groupId, IAmqpMessageSink sink);

        void UnregisterSink(string groupId);
    }

    public interface IAmqpMessageSink
    {
        void OnMessage(object sender, AmqpReceiveMessageEventArgs e);
    }


    public class AmqpListenerSettings
    {
        public string BrokerUrl;
        public BrokerTransport BrokerTransport;
        public bool UseSasl;
        public string ReceiveKeyName;
        public string ReceiveKeyValue;
        public string SendKeyName;
        public string SendKeyValue;
        public uint TokenRenewalInterval;
        public Dictionary<string, KeyValuePair<string, string>> ServerKeys;
    }

    public class AmqpReceiveMessageEventArgs
    {
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

        public string MessageId { get; private set; }

        public string CorrelationId { get; private set; }

        public string ReplyTo { get; private set; }

        public string ContentType { get; private set; }

        public string GroupId { get; private set; }

        public uint GroupSequence { get; private set; }

        public string AccessToken { get; private set; }

        public uint RequestId { get; set; }

        public ArraySegment<byte> Body { get; private set; }
    }
}
