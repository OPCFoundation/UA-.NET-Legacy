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
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using Amqp;
using Amqp.Framing;
using Amqp.Types;

namespace Opc.Ua.Bindings
{
    public class AmqpTopicConnection : IAmqpConnection
    {
        public string EndpointUrl;
        public string ConnectionString;
        public string ReplyTo;
        public TopicClient Stream;
        public uint MessageCount;

        public AmqpTopicConnection(string brokerUrl, string userName, string password, string topicName)
        {
            EndpointUrl = brokerUrl;

            var cs = ConnectionString = ServiceBusListener.ConnectionStringFromUrl(EndpointUrl, userName, password);

            NamespaceManager namespaceManager = NamespaceManager.CreateFromConnectionString(cs);

            try
            {
                if (!namespaceManager.TopicExists(topicName))
                {
                    Utils.Trace("Creating Topic '{0}'...", topicName);
                    namespaceManager.CreateTopic(topicName);
                }
            }
            catch (UnauthorizedAccessException e)
            {
                Utils.Trace("Could not check if '{0}' Topic exists. {1}", topicName, e.Message);
            }
        }

        public void Open(string amqpNodeName)
        {
            if (Stream != null)
            {
                Stream.Close();
                Stream = null;
            }

            if (Uri.IsWellFormedUriString(amqpNodeName, UriKind.Absolute))
            {
                Uri uri = new Uri(amqpNodeName);
                amqpNodeName = uri.PathAndQuery.Substring(1);
            }

            Stream = TopicClient.CreateFromConnectionString(ConnectionString, amqpNodeName);
            Console.WriteLine("Sending with ServiceBus API '{0}'...", amqpNodeName);
        }

        public void Close()
        {
            if (Stream != null)
            {
                Stream.Close();
                Stream = null;
            }
        }

        public void Send(AmqpMessageSettings settings, ArraySegment<byte> body)
        {
            try
            {
                MessageCount++;
                
                using (var istrm = new System.IO.MemoryStream(body.Array, body.Offset, body.Count, false))
                {
                    BrokeredMessage message = new BrokeredMessage(istrm);

                    message.MessageId = (settings.MessageId != null) ? settings.MessageId : MessageCount.ToString();
                    message.CorrelationId = settings.CorrelationId;
                    message.ReplyTo = ReplyTo;
                    message.ContentType = "application/text";

                    Stream.Send(message);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error during send: {0}", e.Message);
            }
        }

        public async Task RenewTokenAsync(int expiryTime)
        {
            await Task.Delay(0);
        }

        public async Task UpdateTokenAsync(string tokenUri, string accessToken)
        {
            await Task.Delay(0);
        }
    }
}
