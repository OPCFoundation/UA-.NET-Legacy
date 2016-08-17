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
using System.Threading;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using Amqp;
using Amqp.Framing;
using Amqp.Sasl;
using Amqp.Types;

namespace Opc.Ua.Bindings
{
    public class GenericAmqpConnection : IAmqpConnection, IDisposable
    {
        public Uri BrokerUrl;
        public string ReplyTo;
        public Address Address;

        private int m_refs;
        private Connection m_connection;
        private Session m_session;
        private SenderLink m_link;
        private uint m_counter;
        private string m_replyKeyName;
        private string m_replyKeyValue;
        private bool m_useSasl;
        private string m_amqpNodeName;
        private string m_sendKeyName;
        private string m_sendKeyValue;
        private int m_tokenLifetime;
        private DateTime m_currentExpiryTime;

        public GenericAmqpConnection(
            string brokerUrl,
            string replyTo,
            AmqpListenerSettings settings)
        {
            BrokerUrl = new Uri(brokerUrl);
            ReplyTo = replyTo;
            m_replyKeyName = settings.SendKeyName;
            m_replyKeyValue = settings.SendKeyValue;
            m_useSasl = settings.UseSasl;
            m_tokenLifetime = Math.Max((int)settings.TokenRenewalInterval, 60000);
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                var link = m_link;

                if (link != null && Interlocked.CompareExchange(ref m_link, null, link) == link)
                {
                    link.Close();
                }

                var session = m_session;

                if (session != null && Interlocked.CompareExchange(ref m_session, null, session) == session)
                {
                    session.Close();
                }

                var connection = m_connection;

                if (connection != null && Interlocked.CompareExchange(ref m_connection, null, connection) == connection)
                {
                    connection.Close();
                }
            }
        }

        public async Task RenewTokenAsync(int expiryTime)
        {
            if (m_sendKeyName != null && m_useSasl)
            {
                var sendTokenUri = new Uri(string.Format("http://{0}/{1}", BrokerUrl.DnsSafeHost, Address.Path));
                var sendToken = GenericAmqpListener.GenerateSharedAccessToken(m_sendKeyName, m_sendKeyValue, sendTokenUri, TimeSpan.FromMilliseconds(m_tokenLifetime));
                await UpdateTokenAsync(sendTokenUri.ToString(), sendToken);
            }
        }

        public async Task UpdateTokenAsync(string tokenUri, string accessToken)
        {
            var expiryTime = GenericAmqpListener.GetTokenExpiryTime(accessToken);

            if (m_currentExpiryTime != DateTime.MinValue && expiryTime <= m_currentExpiryTime)
            {
                return;
            }

            m_currentExpiryTime = expiryTime;

            await GenericAmqpListener.AssociateNamespaceEntityTokenAsync(m_connection, new Uri(tokenUri), accessToken);

            if (m_link != null)
            {
                await m_link.CloseAsync();
                m_link = null;
            }

            m_link = new SenderLink(m_session, Guid.NewGuid().ToString(), m_amqpNodeName);
            m_link.Closed += new ClosedCallback(OnLinkClosed);
        }

        public event EventHandler<AmqpConnectionEventArgs> ConnectionClosed;

        public int AddRef()
        {
            return Interlocked.Increment(ref m_refs);
        }

        public int Release()
        {
            var refs = Interlocked.Decrement(ref m_refs);

            if (refs <= 0)
            {
                int TBD_FigureOutWhyConnectionsCantBeRecreatedAfterDeletion = 0;
                // Dispose();
            }

            return refs;
        }

        public async Task OpenAsync(string amqpNodeName, string sendKeyName, string sendKeyValue)
        {
            Close();

            Address address = null;

            m_amqpNodeName = amqpNodeName;
            m_sendKeyName = sendKeyName;
            m_sendKeyValue = sendKeyValue;

            ConnectionFactory factory = new ConnectionFactory();
            factory.AMQP.ContainerId = Guid.NewGuid().ToString();

            if (m_useSasl)
            {
                factory.SASL.Profile = SaslProfile.External;
                address = Address = new Address(BrokerUrl.DnsSafeHost, BrokerUrl.Port, null, null, "/", BrokerUrl.Scheme);
            }
            else
            {
                address = Address = new Address(BrokerUrl.DnsSafeHost, BrokerUrl.Port, sendKeyName, sendKeyValue, amqpNodeName, BrokerUrl.Scheme);
            }

            m_connection = await factory.CreateAsync(address);
            m_connection.Closed += OnConnectionClosed;

            if (m_useSasl && !String.IsNullOrEmpty(sendKeyName))
            {
                await AssignTokenToConnection();
            }

            m_session = new Session(m_connection);
            m_session.Closed += OnSessionClosed;

            m_link = new SenderLink(m_session, Guid.NewGuid().ToString(), amqpNodeName);
            m_link.Closed += OnLinkClosed;
        }

        void OnConnectionClosed(AmqpObject sender, Error error)
        {
            if (error != null)
            {
                Utils.Trace("[GenericAmqpConnection.OnConnectionClosed] {0} {1}", error.Condition, error.Description);
            }

            var Callback = ConnectionClosed;

            if (Callback != null)
            {
                try
                {
                    Callback(this, new AmqpConnectionEventArgs(m_amqpNodeName));
                }
                catch (Exception e)
                {
                    Utils.Trace(e, "[GenericAmqpConnection.OnLinkClosed] Error raising ConnectionClosed event.");
                }
            }
        }

        void OnSessionClosed(AmqpObject sender, Error error)
        {
            if (error != null)
            {
                Utils.Trace("[GenericAmqpConnection.OnSessionClosed] {0} {1}", error.Condition, error.Description);
            }
        }

        void OnLinkClosed(AmqpObject sender, Error error)
        {
            if (error != null)
            {
                Utils.Trace("[GenericAmqpConnection.OnLinkClosed] {0} {1}", error.Condition, error.Description);
            }
        }

        public void Close()
        {
            Dispose(true);
        }

        private async Task AssignTokenToConnection()
        {
            var lifetime = TimeSpan.FromMinutes(m_tokenLifetime);
            var sendTokenUri = new Uri(string.Format("http://{0}/{1}", BrokerUrl.DnsSafeHost, m_amqpNodeName));
            var sendToken = GenericAmqpListener.GenerateSharedAccessToken(m_sendKeyName, m_sendKeyValue, sendTokenUri, lifetime);
            await GenericAmqpListener.AssociateNamespaceEntityTokenAsync(m_connection, sendTokenUri, sendToken);
            m_currentExpiryTime = DateTime.UtcNow + lifetime;
        }

        public async Task SendAsync(AmqpMessageSettings settings, ArraySegment<byte> body)
        {
            if (m_useSasl && (DateTime.UtcNow - m_currentExpiryTime).TotalSeconds < 30)
            {
                // AssignTokenToConnection().Wait(10000);
            }

            m_counter++;

            var istrm = new System.IO.MemoryStream(body.Array, body.Offset, body.Count, false);

            Message message = new Message()
            {
                BodySection = new Data() { Binary = istrm.ToArray() }
            };

            message.Properties = new Properties()
            {
                MessageId = (settings.MessageId != null) ? settings.MessageId : m_counter.ToString(),
                CorrelationId = settings.CorrelationId,
                ReplyTo = ReplyTo,
                GroupId = settings.ChannelId,
                GroupSequence = settings.SequenceNumber,
                Subject = "ua-request",
                ContentType = "application/opcua+uatcp"
            };

            var replyTokenUri = new Uri(string.Format("http://{0}/{1}", BrokerUrl.DnsSafeHost, ReplyTo));

            if (m_useSasl)
            {
                message.Properties.ReplyTo = replyTokenUri.ToString();
            }
            else
            {
                message.Properties.ReplyTo = ReplyTo;
            }
        
            message.ApplicationProperties = new ApplicationProperties();

            if (m_useSasl && !String.IsNullOrEmpty(m_replyKeyName))
            {
                var replyToken = GenericAmqpListener.GenerateSharedAccessToken(m_replyKeyName, m_replyKeyValue, replyTokenUri, TimeSpan.FromMilliseconds(m_tokenLifetime));
                message.ApplicationProperties["reply-token"] = replyToken;
            }

            if (m_link != null)
            {
                await m_link.SendAsync(message);
            }
        }
    }
}
