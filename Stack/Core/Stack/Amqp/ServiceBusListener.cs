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
using System.Threading;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using Amqp;
using Amqp.Framing;
using Amqp.Types;

namespace Opc.Ua.Bindings
{
    public class ServiceBusListener : IAmqpListener, IDisposable
    {
        public string ConnectionString;
        public string EndpointUrl;
        public int MessageSize;
        public int ChunkSize;
        public bool IsServer;

        private MessagingFactory m_factory;
        private MessageReceiver m_receiver;
        private ConnectionManager m_connections;

        public ServiceBusListener()
        {
            m_connections = new ConnectionManager();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                m_connections.Dispose();

                if (m_receiver != null)
                {
                    m_receiver.Close();
                    m_receiver = null;
                }   

                if (m_factory != null)
                {
                    m_factory.Close();
                    m_factory = null;
                }            
            }
        }

        public string AmqpNodeName { get; set; }

        public event EventHandler<AmqpReceiveMessageEventArgs> ReceiveMessage;

        public void Listen(AmqpListenerSettings settings, string amqpNodeName)
        {
            EndpointUrl = settings.BrokerUrl;

            var cs = ConnectionString = ConnectionStringFromUrl(EndpointUrl, settings.ReceiveKeyName, settings.ReceiveKeyValue);

            NamespaceManager namespaceManager = NamespaceManager.CreateFromConnectionString(cs);

            try
            {
                ServiceBusEnvironment.SystemConnectivity.Mode = ConnectivityMode.Tcp;

                if (!namespaceManager.QueueExists(amqpNodeName))
                {
                    Console.WriteLine("Creating Queue '{0}'...", amqpNodeName);
                    namespaceManager.CreateQueue(amqpNodeName);
                }

                QueueDescription qd = namespaceManager.GetQueue(amqpNodeName);
                qd.EnableExpress = true;
                namespaceManager.UpdateQueue(qd);               
            }
            catch (UnauthorizedAccessException e)
            {
                // ignore access errors.
                Console.WriteLine("Could not check if '{0}' Queue exists. {1}", amqpNodeName, e.Message);
            }

            AmqpNodeName = amqpNodeName;

            m_factory = MessagingFactory.CreateFromConnectionString(ConnectionStringFromUrl(settings.BrokerUrl, settings.ReceiveKeyName, settings.ReceiveKeyValue));
            m_receiver = m_factory.CreateMessageReceiver(amqpNodeName, ReceiveMode.ReceiveAndDelete);
            ThreadPool.QueueUserWorkItem(OnReceiveComplete, m_receiver);

            Console.WriteLine("Listening with ServiceBus API '{0}'...", amqpNodeName);
        }

        public void Close()
        {
            Dispose(true);
        }

        public IAmqpConnection CreateConnection(string amqpNodeName, bool useListenerCredentials)
        {
            var connection = m_connections.Find(amqpNodeName);

            if (connection != null)
            {
                return connection;
            }

            var sender = m_factory.CreateMessageSender(amqpNodeName);
            var sbc = new ServiceBusConnection(sender, AmqpNodeName, ChunkSize);
            sbc.Open(amqpNodeName);
            m_connections.Save(amqpNodeName, sbc);

            return sbc;
        }

        public static string ConnectionStringFromUrl(string url, string userName, string password)
        {
            Uri uri = new Uri(url);

            if (uri.Scheme != "amqps" && uri.Scheme != "amqp")
            {
                throw new NotSupportedException(uri.Scheme);
            }

            if (userName != null)
            {
                return String.Format("Endpoint=sb://{0}/;SharedAccessKeyName={1};SharedAccessKey={2}", uri.DnsSafeHost, userName, password);
            }
            else
            {
                return String.Format("Endpoint=sb://{0}/;", uri.DnsSafeHost);
            }
        }

        private void OnReceiveComplete(object state)
        {
            try
            {
                MessageReceiver m_receiver = (MessageReceiver)state;

                while (true)
                {
                    var task = m_receiver.ReceiveAsync();
                    task.Wait();
                    var message = task.Result;
                    ProcessMessage(m_receiver, message);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error during OnReceiveComplete: [{0}] {1}", e.GetType().Name, e.Message);
            }
        }

        private void ProcessMessage(MessageReceiver receiver, BrokeredMessage message)
        {
            try
            {
                var ostrm = message.GetBody<System.IO.Stream>();

                // report the new message.
                var Callback = ReceiveMessage;

                if (Callback != null)
                {
                    try
                    {
                        string accessToken = null;

                        if (message.Properties != null && message.Properties.ContainsKey("reply-token"))
                        {
                            accessToken = message.Properties["reply-token"] as string;
                        }

                        var args = new AmqpReceiveMessageEventArgs(
                            message.MessageId,
                            message.CorrelationId,
                            message.ReplyTo,
                            message.ContentType,
                            null,
                            0,
                            accessToken,
                            ostrm);

                        Callback(this, args);
                    }
                    catch (Exception e)
                    {
                        Utils.Trace(e, "Unexpected error raising ReceiveMessage event for Queue={0}.", AmqpNodeName);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error during ProcessMessage: [{0}] {1}", e.GetType().Name, e.Message);
            }
        }
    }
}
