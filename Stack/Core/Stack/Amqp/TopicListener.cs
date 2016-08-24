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
using System.Threading.Tasks;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using Amqp;
using Amqp.Framing;
using Amqp.Types;

namespace Opc.Ua.Bindings
{
    class AmqpTopicListener : IAmqpListener
    {
        public string ConnectionString;
        public string EndpointUrl;
        public SubscriptionClient Stream;

        public string TerminusName { get; set; }

        public event EventHandler<AmqpReceiveMessageEventArgs> ReceiveMessage;

        public void Listen(AmqpListenerSettings settings, string terminusName)
        {
            EndpointUrl = settings.BrokerUrl;

            var cs = ConnectionString = ConnectionStringFromUrl(EndpointUrl, settings.ReceiveKeyName, settings.ReceiveKeyValue);

            NamespaceManager namespaceManager = NamespaceManager.CreateFromConnectionString(cs);

            try
            {
                if (!namespaceManager.TopicExists(terminusName))
                {
                    Console.WriteLine("Creating Topic '{0}'...", terminusName);
                    namespaceManager.CreateTopic(terminusName);
                }
            }
            catch (UnauthorizedAccessException e)
            {
                // ignore access errors.
                Console.WriteLine("Could not check if '{0}' Topic exists. {1}", terminusName, e.Message);
            }

            try
            {
                if (!namespaceManager.SubscriptionExists(terminusName, "default"))
                {
                    Console.WriteLine("Creating Subscription '{0}'...", terminusName);
                    namespaceManager.CreateSubscription(terminusName, "default");
                }
            }
            catch (UnauthorizedAccessException e)
            {
                // ignore access errors.
                Console.WriteLine("Could not check if '{0}' Subscription exists. {1}", terminusName, e.Message);
            }

            TerminusName = terminusName;

            Stream = SubscriptionClient.CreateFromConnectionString(cs, terminusName, "default");
            Stream.BeginReceive(OnMessageReceived, null);
            Console.WriteLine("Listening with ServiceBus API '{0}'...", terminusName);
        }

        public void Close()
        {
            if (Stream != null)
            {
                Stream.Close();
                Stream = null;
            }
        }

        public IAmqpConnection CreateConnection(string terminusName, bool useListenerCredentials)
        {
            var connection = new AmqpTopicConnection(ConnectionString, null, null, TerminusName);
            connection.Open(terminusName);
            return connection;
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

        private void OnMessageReceived(IAsyncResult result)
        {
            try
            {
                var message = Stream.EndReceive(result);

                if (message != null)
                {
                    var ostrm = message.GetBody<System.IO.Stream>();

                    // using (var ostrm = new System.IO.MemoryStream(bytes, false))
                    {
                        var reader = new System.IO.StreamReader(ostrm);
                        var body = reader.ReadToEnd();

                        Console.WriteLine(
                            "MessageId={0} TerminusName={1} CorrelationId={2} ContentType={3} Content={4}",
                            message.MessageId,
                            message.ReplyTo,
                            message.CorrelationId,
                            message.ContentType,
                            body);
                    }
                 
                    message.BeginComplete(OnMessageComplete, message);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error during receive: {0}", e.Message);
            }
            finally
            {
                if (Stream != null)
                {
                    Stream.BeginReceive(OnMessageReceived, null);
                }
            }
        }

        private void OnMessageComplete(IAsyncResult result)
        {
            try
            {
                BrokeredMessage message = (BrokeredMessage)result.AsyncState;
                message.EndComplete(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error during complete: {0}", e.Message);
            }
        }
    }
}
