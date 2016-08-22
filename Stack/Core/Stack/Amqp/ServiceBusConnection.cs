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
    public class ServiceBusConnection : IAmqpConnection, IDisposable
    {
        public string ConnectionString;
        public string ReplyTo;

        private MessageSender m_sender;
        private uint m_counter;
        private int m_chunkSize;

        public ServiceBusConnection(MessageSender sender, string replyTo, int chunkSize)
        {
            m_sender = sender;
            m_chunkSize = Math.Max(chunkSize, 10000);
            ReplyTo = replyTo;
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (m_sender != null)
                {
                    m_sender.Close();
                    m_sender = null;
                }
            }
        }

        public void Open(string amqpNodeName)
        {
            Console.WriteLine("Sending with ServiceBus API '{0}'...", amqpNodeName);
        }

        public void Close()
        {
            Dispose(true);
        }

        public void Send(AmqpMessageSettings settings, ArraySegment<byte> body)
        {
            try
            {
                m_counter++;

                var sender = m_sender;

                if (sender != null)
                {
                    var strm = new System.IO.MemoryStream(body.Array, body.Offset, body.Count);

                    BrokeredMessage message = new BrokeredMessage(strm, true);

                    message.MessageId = (settings.MessageId != null) ? settings.MessageId : m_counter.ToString();
                    message.CorrelationId = settings.CorrelationId;
                    message.ReplyTo = ReplyTo;
                    message.Properties["group-id"] = settings.ChannelId;
                    message.Properties["group-sequence"] = settings.SequenceNumber;
                    message.ContentType = "application/opcua+amqp";

                    sender.Send(message);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error during Send: [{0}] {1}", e.GetType().Name, e.Message);
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
