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
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.ServiceModel.Channels;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Web;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Reflection;
using System.Xml;

namespace Opc.Ua.Bindings
{
    #if !NET4_CLIENT_FRAMEWORK
    /// <summary>
    /// Manages the connections for a UA AMQP server.
    /// </summary>
    public partial class AmqpTransportListener : IDisposable, ITransportListener, IAmqpMessageSink
    {
        #region Private Fields
        private object m_lock = new object();
        private string m_listenerId;
        private Uri m_url;
        private EndpointDescriptionCollection m_descriptions;
        private EndpointConfiguration m_configuration;
        private TcpChannelQuotas m_quotas;
        private ITransportListenerCallback m_callback;
        private IAmqpListener m_listener;
        private AmqpBrokerConfigurationCollection m_brokers;
        private Dictionary<string,IAmqpConnection> m_connections;
        private BufferManager m_bufferManager;
        private X509Certificate2 m_serverCertificate;
        private long m_channelExpiryTime;
        private Timer m_cleanupTimer;

        private long m_nextChannelId = 1000;
        private Dictionary<string, AmqpServerChannel> m_channels = new Dictionary<string, AmqpServerChannel>();
        private const string g_ImplementationString = "AmqpTransportListener UA-AMQP " + AssemblyVersionInfo.CurrentVersion;
        #endregion

        private class AmqpServerChannel
        {
            public string GroupId;
            public UaTcpChannelSerializer Serializer;
            public IAmqpConnection Connection;
            public long LastMessageTime;
            public bool IsDisposed;
            public bool WasOpened;

            public async Task SendAsync(string correlationId, ArraySegment<byte> message)
            {
                try
                {
                    StringBuilder messageId = new StringBuilder();

                    messageId.Append(GroupId);
                    messageId.Append(":");
                    messageId.Append(Serializer.ChannelId);
                    messageId.Append("/");
                    messageId.Append(Serializer.SequenceNumber);

                    var settings = new AmqpServiceMessageSettings()
                    {
                        MessageId = messageId.ToString(),
                        CorrelationId = correlationId,
                        ChannelId = GroupId,
                        SequenceNumber = Serializer.SequenceNumber
                    };

                    await Connection.SendAsync(settings, message);
                }
                finally
                {
                    Serializer.BufferManager.ReturnBuffer(message.Array, "AmqpServerChannel.SendAsync");
                }
            }

            public async Task SendAsync(string correlationId, BufferCollection message)
            {
                try
                {
                    StringBuilder messageId = new StringBuilder();

                    messageId.Append(GroupId);
                    messageId.Append(":");
                    messageId.Append(Serializer.ChannelId);
                    messageId.Append("/");

                    long sequenceNumber = Serializer.SequenceNumber - message.Count + 1;

                    foreach (var chunk in message)
                    {
                        var settings = new AmqpServiceMessageSettings()
                        {
                            MessageId = messageId.ToString() + sequenceNumber.ToString(),
                            CorrelationId = correlationId,
                            ChannelId = GroupId,
                            SequenceNumber = (uint)sequenceNumber
                        };

                        await Connection.SendAsync(settings, chunk);
                        sequenceNumber++;
                    }
                }
                finally
                {
                    message.Release(Serializer.BufferManager, "AmqpServerChannel.SendAsync");
                }
            }
        }

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="AmqpTransportListener"/> class.
        /// </summary>
        public AmqpTransportListener(ApplicationConfiguration configuration, X509Certificate2 serverCertificate, EndpointDescriptionCollection endpoints)
        {
            m_brokers = AmqpBrokerConfigurationCollection.Load(configuration);
            m_connections = new Dictionary<string, IAmqpConnection>();
            m_nextChannelId = 0;
            m_serverCertificate = serverCertificate;
            m_channelExpiryTime = 60000 * 5;
            m_cleanupTimer = new Timer(OnCleanupTimerExpired, null, m_channelExpiryTime, m_channelExpiryTime / 2);
            m_descriptions = new EndpointDescriptionCollection();

            foreach (var endpoint in endpoints)
            {
                if (endpoint.EndpointUrl.StartsWith(Utils.UriSchemeOpcAmqp))
                {
                    m_descriptions.Add(endpoint);
                }
            }
        }
        #endregion

        #region IDisposable Members
        /// <summary>
        /// Frees any unmanaged resources.
        /// </summary>
        public void Dispose()
        {   
            Dispose(true);
        }

        /// <summary>
        /// An overrideable version of the Dispose.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
        }
        #endregion

        #region ITransportListener Members
        /// <summary>
        /// The URI scheme handled by the listener.
        /// </summary>
        public string UriScheme { get { return Utils.UriSchemeOpcAmqp; } }

        /// <summary>
        /// Opens the listener and starts accepting connection.
        /// </summary>
        /// <param name="baseAddress">The base address.</param>
        /// <param name="settings">The settings to use when creating the listener.</param>
        /// <param name="callback">The callback to use when requests arrive via the channel.</param>
        /// <exception cref="ArgumentNullException">Thrown if any parameter is null.</exception>
        /// <exception cref="ServiceResultException">Thrown if any communication error occurs.</exception>
        public void Open(Uri baseAddress, TransportListenerSettings settings, ITransportListenerCallback callback)
        {
            // assign a unique guid to the listener.
            m_listenerId = Guid.NewGuid().ToString();

            m_url = baseAddress;
            m_descriptions = settings.Descriptions;
            m_configuration = settings.Configuration;

            // initialize the quotas.
            m_quotas = new TcpChannelQuotas();

            m_quotas.MaxBufferSize = m_configuration.MaxBufferSize;
            m_quotas.MaxMessageSize = m_configuration.MaxMessageSize;
            m_quotas.ChannelLifetime = m_configuration.ChannelLifetime;
            m_quotas.SecurityTokenLifetime = m_configuration.SecurityTokenLifetime;

            m_quotas.MessageContext = new ServiceMessageContext();

            m_quotas.MessageContext.MaxArrayLength = m_configuration.MaxArrayLength;
            m_quotas.MessageContext.MaxByteStringLength = m_configuration.MaxByteStringLength;
            m_quotas.MessageContext.MaxMessageSize = m_configuration.MaxMessageSize;
            m_quotas.MessageContext.MaxStringLength = m_configuration.MaxStringLength;
            m_quotas.MessageContext.NamespaceUris = settings.NamespaceUris;
            m_quotas.MessageContext.ServerUris = new StringTable();
            m_quotas.MessageContext.Factory = settings.Factory;

            m_quotas.CertificateValidator = settings.CertificateValidator;

            // save the callback to the server.
            m_callback = callback;

            m_bufferManager = new BufferManager(baseAddress.PathAndQuery, (int)Int32.MaxValue, settings.Configuration.MaxBufferSize);

            // start the listener.
            Start();
        }

        /// <summary>
        /// Closes the listener and stops accepting connection.
        /// </summary>
        /// <exception cref="ServiceResultException">Thrown if any communication error occurs.</exception>
        public void Close()
        {
            Stop();
        }

        /// <summary>
        /// Raised when a new connection is waiting for a client.
        /// </summary>
        public event EventHandler<ConnectionWaitingEventArgs> ConnectionWaiting;

        /// <summary>
        /// Raised when a monitored connection's status changed.
        /// </summary>
        public event EventHandler<ConnectionStatusEventArgs> ConnectionStatusChanged;

        /// <remarks />
        public void CreateConnection(Uri url)
        {
            if (ConnectionStatusChanged == null || ConnectionWaiting == null)
            {
                throw new NotImplementedException();
            }

            throw new NotImplementedException();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Gets the URL for the listener's endpoint.
        /// </summary>
        /// <value>The URL for the listener's endpoint.</value>
        public Uri EndpointUrl
        {
            get { return m_url; }
        }

        /// <summary>
        /// Starts listening at the specified port.
        /// </summary>
        public void Start()
        {
            IAmqpListener listener = m_listener;

            if (listener == null)
            { 
                // select the broker.
                lock (m_brokers)
                {
                    listener = m_brokers.SelectListenerAsync(m_url, m_quotas).Result;
                    listener.RegisterSink(String.Empty, this);
                }

                // check for multiple threads opening.
                if (Interlocked.CompareExchange(ref m_listener, listener, null) != null)
                { 
                    listener.UnregisterSink(String.Empty);
                    listener.Close();

                    throw new InvalidOperationException("Cannot start a listener that has already been started.");
                }
            }
        }

        /// <summary>
        /// Stops listening.
        /// </summary>
        public void Stop()
        {
            IAmqpListener listener = m_listener;

            if (Interlocked.CompareExchange(ref m_listener, listener, null) != null)
            {
                m_listener.UnregisterSink(String.Empty);
                m_listener.Close();
            }
        }
        #endregion

        private void CleanupChannel(AmqpServerChannel channel)
        {
            if (!channel.IsDisposed)
            {
                lock (m_channels)
                {
                    m_channels.Remove(channel.GroupId);
                }

                channel.IsDisposed = true;
                channel.Serializer.Dispose();
                channel.Connection.Release();
            }
        }

        #region Private Methods
        private void OnCleanupTimerExpired(object state)
        {
            try
            {
                List<AmqpServerChannel> channelsToDelete = new List<AmqpServerChannel>();

                long cutoff = TimeUtils.GetTickCount() - m_channelExpiryTime;

                foreach (var ii in m_channels)
                {
                    if (cutoff > ii.Value.LastMessageTime)
                    {
                        channelsToDelete.Add(ii.Value);
                    }
                }

                foreach (var ii in channelsToDelete)
                {
                    CleanupChannel(ii);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write("Unexpected error deleting connections: " + e.Message);
            }
        }

        /// <remarks />
        public async void OnMessage(object sender, AmqpReceiveMessageEventArgs e)
        {
            // Utils.Trace("[AmqpTransportListener.Listener_ReceiveMessage] {0} {1} {2}", e.MessageId, e.CorrelationId, e.GroupId);

            var message = e.Body;
            var messageType = BitConverter.ToUInt32(message.Array, message.Offset);

            switch (messageType)
            {
                case TcpMessageType.Hello:
                {
                    await ProcessHelloAsync(e);
                    break;
                }

                case TcpMessageType.Open | TcpMessageType.Final:
                {
                    await ProcessOpenAsync(e);
                    break;
                }

                case TcpMessageType.Close | TcpMessageType.Final:
                {
                    await ProcessCloseAsync(e);
                    break;
                }

                case TcpMessageType.MessageIntermediate:
                case TcpMessageType.MessageFinal:
                {
                    await ProcessRequestAsync(e);
                    break;
                }

                default:
                {
                    Utils.Trace("[AmqpTransportListener.Listener_ReceiveMessage] Invalid MessageType: 0x{0:X8}", messageType);
                    break;
                }
            }
        }

        private async Task ProcessHelloAsync(AmqpReceiveMessageEventArgs e)
        {
            ServiceResult result = null;

            AmqpServerChannel channel = null;

            lock (m_channels)
            {
                if (!m_channels.TryGetValue(e.GroupId, out channel))
                {
                    channel = new AmqpServerChannel()
                    {
                        GroupId = e.GroupId,
                        Serializer = new UaTcpChannelSerializer(m_bufferManager, m_quotas, m_serverCertificate, null, m_descriptions),
                        LastMessageTime = DateTime.UtcNow.Ticks
                    };

                    channel.Serializer.ChannelId = Utils.IncrementIdentifier(ref m_nextChannelId);
                    m_channels[e.GroupId] = channel;
                }
            }

            if (channel.Connection == null)
            {
                string amqpNodeName = e.ReplyTo;

                if (Uri.IsWellFormedUriString(e.ReplyTo, UriKind.Absolute))
                {
                    amqpNodeName = new Uri(e.ReplyTo).AbsolutePath.Substring(1);
                }

                channel.Connection = await m_listener.ConnectAsync(amqpNodeName, e.ReplyTo, e.AccessToken);
                channel.LastMessageTime = DateTime.UtcNow.Ticks;
            }

            if (Uri.IsWellFormedUriString(e.ReplyTo, UriKind.Absolute) && !String.IsNullOrEmpty(e.AccessToken))
            {
                await channel.Connection.UpdateTokenAsync(e.ReplyTo, e.AccessToken);
            }

            try
            {
                result = channel.Serializer.ProcessHelloMessage(e.Body);

                if (ServiceResult.IsGood(result))
                {
                    var message = channel.Serializer.ConstructAcknowledgeMessage();
                    await channel.SendAsync(e.MessageId, message);
                    return;
                }
            }
            catch (Exception exception)
            {
                var message = channel.Serializer.ConstructErrorMessage(new ServiceResult(exception));
                await channel.SendAsync(e.MessageId, message);
            }
        }

        private async Task ProcessOpenAsync(AmqpReceiveMessageEventArgs e)
        {
            AmqpServerChannel channel = null;

            lock (m_channels)
            {
                if (!m_channels.TryGetValue(e.GroupId, out channel))
                {
                    Utils.Trace("[AmqpTransportListener.ProcessOpenAsync] Channel not found: {0}", e.GroupId);
                    return;
                }
            }

            channel.LastMessageTime = DateTime.UtcNow.Ticks;

            try
            {
                uint requestId = channel.Serializer.ProcessOpenSecureChannelRequest(e.Body);

                foreach (var endpoint in m_descriptions)
                {
                    if (endpoint.SecurityMode == channel.Serializer.SecurityMode)
                    {
                        if (endpoint.SecurityPolicyUri == channel.Serializer.SecurityPolicyUri)
                        {
                            channel.Serializer.EndpointDescription = endpoint;
                            break;
                        }
                    }
                }

                Opc.Ua.Security.Audit.SecureChannelCreated(
                    g_ImplementationString,
                    m_url.ToString(),
                    channel.Serializer.ChannelId.ToString(),
                    channel.Serializer.EndpointDescription,
                    channel.Serializer.ClientCertificate,
                    channel.Serializer.ServerCertificate,
                    BinaryEncodingSupport.Required);

                channel.WasOpened = true;
                var message = channel.Serializer.ConstructOpenSecureChannelResponse(requestId);
                await channel.SendAsync(e.MessageId, message);
            }
            catch (Exception exception)
            {
                var message = channel.Serializer.ConstructErrorMessage(new ServiceResult(exception));
                await channel.SendAsync(e.MessageId, message);
            }
        }

        private async Task ProcessCloseAsync(AmqpReceiveMessageEventArgs e)
        {
            AmqpServerChannel channel = null;

            Utils.Trace("[AmqpTransportListener.ProcessCloseAsync] {0}", e.GroupId);

            lock (m_channels)
            {
                if (!m_channels.TryGetValue(e.GroupId, out channel))
                {
                    Utils.Trace("[AmqpTransportListener.ProcessCloseAsync] Channel not found: {0}", e.GroupId);
                    return;
                }
            }

            channel.LastMessageTime = DateTime.UtcNow.Ticks;

            try
            {
                channel.Serializer.ProcessCloseSecureChannelRequest(e.Body);
                CleanupChannel(channel);
            }
            catch (Exception exception)
            {
                var message = channel.Serializer.ConstructErrorMessage(new ServiceResult(exception));
                await channel.SendAsync(e.MessageId, message);
            }
        }

        private class AmqpProcessRequestAsyncState
        {
            public string RequestMessageId;
            public uint RequestId;
            public AmqpServerChannel Channel;
        }

        private async Task ProcessRequestAsync(AmqpReceiveMessageEventArgs e)
        {
            AmqpServerChannel channel = null;

            lock (m_channels)
            {
                if (!m_channels.TryGetValue(e.GroupId, out channel))
                {
                    Utils.Trace("[AmqpTransportListener.ProcessCloseAsync] Channel not found: {0}", e.GroupId);
                    return;
                }
            }

            channel.LastMessageTime = DateTime.UtcNow.Ticks;

            try
            {
                uint requestId = 0;
                IServiceRequest request = channel.Serializer.ProcessRequest(e.Body, out requestId);

                if (request != null)
                {
                    var ad = new AmqpProcessRequestAsyncState()
                    {
                        Channel = channel,
                        RequestMessageId = e.MessageId,
                        RequestId = requestId
                    };

                    m_callback.QueueRequest(
                        m_listenerId,
                        channel.Serializer.EndpointDescription,
                        request,
                        OnRequestProcessed,
                        ad);
                }
            }
            catch (Exception exception)
            {
                // check if the application is forcing the channel to close.
                var sre = exception as ServiceResultException;

                if (sre != null)
                {
                    if (sre.StatusCode == StatusCodes.BadSecureChannelClosed)
                    {
                        CleanupChannel(channel);
                    }

                    return;
                }

                var message = channel.Serializer.ConstructErrorMessage(ServiceResult.Create(exception, StatusCodes.BadTcpInternalError, "Could not process request."));
                await channel.SendAsync(e.MessageId, message);
            }
        }

        private async void OnRequestProcessed(IAsyncResult result)
        {
            AmqpProcessRequestAsyncState ad = (AmqpProcessRequestAsyncState)result.AsyncState;

            try
            {
                var response = m_callback.FinishRequest(result);

                if (!ad.Channel.IsDisposed)
                {
                    var message = ad.Channel.Serializer.ConstructResponse(ad.RequestId, response);
                    await ad.Channel.SendAsync(ad.RequestMessageId, message);
                }
            }
            catch (Exception e)
            {
                Utils.Trace(e, "[AmqpTransportListener.OnRequestProcessed] Could not process response.");
            }
        }
        #endregion
    }    
    #endif
}
