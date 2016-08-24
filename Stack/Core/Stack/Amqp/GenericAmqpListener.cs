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
using System.Net;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using Amqp;
using Amqp.Framing;
using Amqp.Sasl;
using Amqp.Types;

namespace Opc.Ua.Bindings
{
    public class GenericAmqpListener : IAmqpListener, IDisposable
    {
        private ConnectionManager m_connections;
        private Connection m_connection;
        private Session m_session;
        private ReceiverLink m_link;
        private Timer m_tokenRenewalTimer;
        private string m_amqpNodeName;
        private AmqpListenerSettings m_settings;
        private static HashSet<Connection> m_cbsSessions = new HashSet<Connection>();
        private Dictionary<string, IAmqpMessageSink> m_sinks = new Dictionary<string, IAmqpMessageSink>();

        public Address Address { get; set; }
        public int MessageSize { get; set; }
        public int ChunkSize { get; set; }
        public string AmqpNodeName { get; set; }

        public GenericAmqpListener()
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
                if (m_tokenRenewalTimer != null)
                {
                    m_tokenRenewalTimer.Dispose();
                    m_tokenRenewalTimer = null;
                }

                m_connections.Dispose();

                if (m_link != null)
                {
                    m_link.Close();
                    m_link = null;
                }

                if (m_session != null)
                {
                    m_session.Close();
                    m_session = null;
                }

                if (m_connection != null)
                {
                    m_connection.Close();
                    m_connection = null;
                }
            }
        }

        private async Task ConfigureAzureQueueAsync(string amqpNodeName)
        {
            string cs = null;

            Uri uri = new Uri(m_settings.BrokerUrl);

            if (m_settings.ReceiveKeyName != null)
            {
                cs = String.Format("Endpoint=sb://{0}/;SharedAccessKeyName={1};SharedAccessKey={2}", uri.DnsSafeHost, m_settings.ReceiveKeyName, m_settings.ReceiveKeyValue);
            }
            else
            {
                cs = String.Format("Endpoint=sb://{0}/;", uri.DnsSafeHost);
            }

            NamespaceManager namespaceManager = NamespaceManager.CreateFromConnectionString(cs);

            try
            {
                ServiceBusEnvironment.SystemConnectivity.Mode = ConnectivityMode.Tcp;

                if (!namespaceManager.QueueExists(amqpNodeName))
                {
                    Utils.Trace("Creating Queue '{0}'...", amqpNodeName);
                    namespaceManager.CreateQueue(amqpNodeName);
                }

                QueueDescription qd = await namespaceManager.GetQueueAsync(amqpNodeName);
                qd.EnableExpress = true;
                await namespaceManager.UpdateQueueAsync(qd);
            }
            catch (UnauthorizedAccessException exception)
            {
                Utils.Trace(exception, "ERROR [GenericAmqpListener.ConfigureAzureQueueAsync] Could not check if '{0}' Queue exists.", amqpNodeName);
            }
        }

        public void RegisterSink(string groupId, IAmqpMessageSink sink)
        {
            if (groupId == null)
            {
                throw new ArgumentNullException("groupId");
            }

            if (sink == null)
            {
                throw new ArgumentNullException("sink");
            }

            lock (m_sinks)
            {
                m_sinks[groupId] = sink;
            }
        }

        public void UnregisterSink(string groupId)
        {
            if (groupId != null)
            {
                lock (m_sinks)
                {
                    m_sinks.Remove(groupId);
                }
            }
        }

        public async Task ListenAsync(AmqpListenerSettings settings, string amqpNodeName)
        {
            m_connections = new ConnectionManager();

            m_amqpNodeName = amqpNodeName;
            m_settings = settings;

            if (m_settings.BrokerUrl.Contains("servicebus.windows.net"))
            {
                await ConfigureAzureQueueAsync(amqpNodeName);
            }

            var brokerUrl = new UriBuilder(m_settings.BrokerUrl);

            if (m_settings.BrokerTransport == BrokerTransport.Wss)
            {
                brokerUrl.Scheme = "wss";
            }

            UriBuilder url = new UriBuilder(settings.BrokerUrl);

            if (!settings.UseSasl)
            {
                if (!String.IsNullOrEmpty(settings.ReceiveKeyName))
                {
                    url.UserName = Uri.EscapeDataString(settings.ReceiveKeyName);
                    url.Password = Uri.EscapeDataString(settings.ReceiveKeyValue);
                }
            }

            url.Path += amqpNodeName;

            Address = new Address(url.ToString());

            ConnectionFactory factory = new ConnectionFactory();
            factory.AMQP.ContainerId = Guid.NewGuid().ToString();

            if (settings.UseSasl)
            {
                factory.SASL.Profile = SaslProfile.External;
            }

            m_connection = await factory.CreateAsync(Address);
            m_connection.Closed += OnIncomingConnectionClosed;

            if (settings.UseSasl)
            {
                var receiveTokenScopeUri = new Uri(string.Format("http://{0}/{1}", Address.Host, amqpNodeName));
                var receiveToken = GenerateSharedAccessToken(m_settings.ReceiveKeyName, m_settings.ReceiveKeyValue, receiveTokenScopeUri, TimeSpan.FromMilliseconds(m_settings.TokenRenewalInterval));
                await AssociateNamespaceEntityTokenAsync(m_connection, receiveTokenScopeUri, receiveToken);
            }

            m_session = new Session(m_connection);
            m_session.Closed += OnIncomingSessionClosed;

            m_link = new ReceiverLink(m_session, Guid.NewGuid().ToString(), amqpNodeName);
            AmqpNodeName = amqpNodeName;

            m_link.Start(5, OnMessageCallback);
            m_link.Closed += OnIncomingLinkClosed;

            if (m_settings.UseSasl)
            {
                int interval = (int)(m_settings.TokenRenewalInterval * 0.8);
                m_tokenRenewalTimer = new Timer(OnTokenRenewal, null, interval, interval);
            }

            Utils.Trace("[GenericAmqpListener.ListenAsync] Listening with AMQP Lite API '{0}'...", amqpNodeName);
        }

        private void OnTokenRenewal(object state)
        {
            try
            {
                var requestsTokenScopeUri = new Uri(string.Format("http://{0}/{1}", Address.Host, m_amqpNodeName));
                var serverReceiveToken = GenerateSharedAccessToken(m_settings.ReceiveKeyName, m_settings.ReceiveKeyValue, requestsTokenScopeUri, TimeSpan.FromMilliseconds(m_settings.TokenRenewalInterval));
                AssociateNamespaceEntityTokenAsync(m_connection, requestsTokenScopeUri, serverReceiveToken).Wait(10000);

                m_connections.RenewTokens();
            }
            catch (Exception e)
            {
                Utils.Trace(e, "ERROR [GenericAmqpListener.OnTokenRenewal] Unexpected error renewing token.");

                var ae = e as AggregateException;

                if (ae != null)
                {
                    foreach (var ie in ae.InnerExceptions)
                    {
                        Utils.Trace("[{0}] {1}", ie.GetType().Name, ie.Message);
                    }
                }
            }
        }

        public static async Task AssociateNamespaceEntityTokenAsync(Connection connection, Uri entityUri, string sharedAccessToken)
        {
            var session = new Session(connection);
            string cbsClientAddress = "cbs-client-reply-to";
            var cbsSender = new SenderLink(session, "cbs-sender", "$cbs"); // link name is functionally insignificant
            var receiverAttach = new Attach()
            {
                Source = new Source() { Address = "$cbs" },
                Target = new Target() { Address = cbsClientAddress }
            };

            var cbsReceiver = new ReceiverLink(session, "cbs-receiver", receiverAttach, null); // link name is functionally insignificant
            // Utils.Trace("SAS token: {0}", sharedAccessToken);

            // construct the put-token message
            var request = new Message(sharedAccessToken);
            request.Properties = new Properties();
            request.Properties.MessageId = "1";
            request.Properties.ReplyTo = cbsClientAddress;
            request.ApplicationProperties = new ApplicationProperties();
            request.ApplicationProperties["operation"] = "put-token";
            request.ApplicationProperties["type"] = "servicebus.windows.net:sastoken";
            request.ApplicationProperties["name"] = entityUri.ToString();
            await cbsSender.SendAsync(request);

            // Utils.Trace("Request Properties: {0}", request.Properties);
            // Utils.Trace("Request ApplicationProperties: {0}", request.ApplicationProperties);

            // receive the response
            var response = await cbsReceiver.ReceiveAsync();
            if (response == null || response.Properties == null || response.ApplicationProperties == null)
            {
                throw new Exception("invalid response received");
            }

            // validate message properties and status code.
            int statusCode = (int)response.ApplicationProperties["status-code"];
            var statusDescription = response.ApplicationProperties["status-description"];

            if (statusCode != (int)HttpStatusCode.Accepted && statusCode != (int)HttpStatusCode.OK)
            {
                throw new Exception("put-token message was not accepted. Error [" + statusCode + "] " + statusDescription);
            }

            // the sender/receiver may be kept open for refreshing tokens
            await cbsSender.CloseAsync();
            await cbsReceiver.CloseAsync();
            await session.CloseAsync();
        }

        public static DateTime GetTokenExpiryTime(string accessToken)
        {
            if (String.IsNullOrEmpty(accessToken))
            {
                return DateTime.MinValue;                      
            }

            int index = accessToken.IndexOf("&se=");

            if (index < 0)
            {
                return DateTime.MinValue;
            }

            string expiryTime = accessToken.Substring(index + 4);

            index = expiryTime.IndexOf("&");

            if (index >= 0)
            {
                expiryTime = expiryTime.Substring(0, index);
            }

            long ticks = 0;

            if (!Int64.TryParse(expiryTime, out ticks))
            {
                return DateTime.MinValue;
            }

            ticks *= TimeSpan.TicksPerSecond;
            ticks += new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).Ticks;

            return new DateTime(ticks, DateTimeKind.Utc);
        }

        public static string GenerateSharedAccessToken(string keyName, string keyValue, Uri requestUri, TimeSpan ttl)
        {
            // http://msdn.microsoft.com/en-us/library/azure/dn170477.aspx
            // the canonical Uri scheme is http because the token is not amqp specific
            // signature is computed from joined encoded request Uri string and expiry string
            string expiry = ((long)((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)) + ttl).TotalSeconds).ToString();
            string encodedUri = Uri.EscapeDataString(requestUri.ToString());

            string sig;
            using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(keyValue)))
            {
                sig = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(encodedUri + "\n" + expiry)));
            }

            // server specific tokens - swat (simple web access token); jwat is the standard.

            return string.Format(
                "SharedAccessSignature sig={0}&se={1}&skn={2}&sr={3}",
                Uri.EscapeDataString(sig),
                Uri.EscapeDataString(expiry),
                Uri.EscapeDataString(keyName),
                encodedUri);
        }

        public async Task<IAmqpConnection> ConnectAsync(string amqpNodeName, string serverKeyName = null, string serverKeyValue = null)
        {
            var connection = m_connections.Find(amqpNodeName) as GenericAmqpConnection;

            if (connection == null)
            {                
                if (serverKeyName == null || !m_settings.UseSasl)
                {
                    serverKeyName = m_settings.SendKeyName;
                    serverKeyValue = m_settings.SendKeyValue;

                    if (m_settings.ServerKeys != null)
                    {
                        KeyValuePair<string, string> key;

                        if (m_settings.ServerKeys.TryGetValue(amqpNodeName, out key))
                        {
                            serverKeyName = key.Key;
                            serverKeyValue = key.Value;
                        }
                    }
                }

                UriBuilder url = new UriBuilder();

                url.Scheme = Address.Scheme;
                url.Host = Address.Host;
                url.Port = Address.Port;

                if (!m_settings.UseSasl)
                {
                    if (String.IsNullOrEmpty(serverKeyName))
                    {
                        url.UserName = m_settings.ReceiveKeyName;
                        url.Password = m_settings.ReceiveKeyValue;
                    }
                    else
                    {
                        url.UserName = serverKeyName;
                        url.Password = serverKeyValue;
                    }
                }

                connection = new GenericAmqpConnection(url.ToString(), m_settings);
                connection.ConnectionClosed += OnOutgoingConnectionClosed;
                await connection.OpenAsync(amqpNodeName, serverKeyName, serverKeyValue);
                m_connections.Save(amqpNodeName, connection);
            }

            return connection;
        }

        void OnOutgoingConnectionClosed(object sender, AmqpConnectionEventArgs e)
        {
            Utils.Trace("[GenericAmqpListener.OnOutgoingConnectionClosed] {0}", e.AmqpNodeName);
        }

        void OnIncomingConnectionClosed(AmqpObject sender, Error error)
        {
            if (error != null)
            {
                Utils.Trace("[GenericAmqpListener.OnIncomingConnectionClosed] {0} {1}", error.Condition, error.Description);
            }
        }

        void OnIncomingSessionClosed(AmqpObject sender, Error error)
        {
            if (error != null)
            {
                Utils.Trace("[GenericAmqpListener.OnIncomingSessionClosed] {0} {1}", error.Condition, error.Description);
            }
        }

        void OnIncomingLinkClosed(AmqpObject sender, Error error)
        {
            if (error != null)
            {
                Utils.Trace("[GenericAmqpListener.OnIncomingLinkClosed] {0} {1}", error.Condition, error.Description);
            }
        }

        private void RaiseReceiveMessageEvent(Message message, byte[] bytes)
        {
            IAmqpMessageSink sink = null;

            if (!m_sinks.TryGetValue(message.Properties.GroupId, out sink))
            {
                if (!m_sinks.TryGetValue(String.Empty, out sink))
                {
                    return;
                }
            }

            if (sink != null)
            {
                try
                {
                    string accessToken = null;

                    if (message.ApplicationProperties != null)
                    {
                        accessToken = message.ApplicationProperties["reply-token"] as string;
                    }

                    var args = new AmqpReceiveMessageEventArgs(
                        message.Properties.MessageId,
                        message.Properties.CorrelationId,
                        message.Properties.ReplyTo,
                        message.Properties.ContentType,
                        message.Properties.GroupId,
                        message.Properties.GroupSequence,
                        accessToken,
                        new ArraySegment<byte>(bytes));

                    sink.OnMessage(this, args);
                }
                catch (Exception e)
                {
                    Utils.Trace(e, "ERROR [GenericAmqpListener.RaiseReceiveMessageEvent] Error raising ReceiveMessage event for AmqpNode={0}.", AmqpNodeName);
                }
            }
        }

        void OnMessageCallback(ReceiverLink receiver, Message message)
        {
            try
            {
                m_link.Accept(message);
            }
            catch (Exception e)
            {
                Utils.Trace(e, "ERROR [GenericAmqpListener.RaiseReceiveMessageEvent] Error while accepting AMQP Message.");
            }

            try
            {
                var bytes = message.GetBody<byte[]>();
                RaiseReceiveMessageEvent(message, bytes);
            }
            catch (Exception e)
            {
                Utils.Trace(e, "ERROR [GenericAmqpListener.RaiseReceiveMessageEvent] Error while reading AMQP Message body.");
            }
        }

        public void Close()
        {
            Dispose(true);
        }
    }
}
