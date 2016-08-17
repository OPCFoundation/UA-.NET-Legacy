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
using System.Net;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace Opc.Ua.Bindings
{
    /// <summary>
    /// Manages the connections for a UA AMQP server.
    /// </summary>
    public partial class TlsTransportListener : IDisposable, ITransportListener
    {
        #region Private Fields
        private object m_lock = new object();
        private string m_listenerId;
        private Uri m_url;
        private EndpointDescriptionCollection m_descriptions;
        private EndpointConfiguration m_configuration;
        private TcpChannelQuotas m_quotas;
        private ITransportListenerCallback m_callback;
        private TlsListener m_listener;
        private BufferManager m_bufferManager;
        private X509Certificate2 m_serverCertificate;
        private Timer m_cleanupTimer;
        private long m_maxSetupTime;
        private long m_maxIdleTime;
        private const string g_ImplementationString = "TlsTransportListener UA-{0} " + AssemblyVersionInfo.CurrentVersion;

        private long m_nextChannelId = 1000;
        private Dictionary<uint, TlsServerChannel> m_channels = new Dictionary<uint, TlsServerChannel>();
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="AmqpChannelListener"/> class.
        /// </summary>
        public TlsTransportListener()
        {
            m_nextChannelId = 0;
            m_maxIdleTime = 60000 * 60;
            m_maxSetupTime = 60000 * 2;
            m_cleanupTimer = new Timer(OnCleanupTimerExpired, null, m_maxSetupTime, m_maxSetupTime / 2);
            m_descriptions = new EndpointDescriptionCollection();
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
            m_serverCertificate = settings.ServerCertificate;

            // m_tlsCertificate = settings.TlsCertificate;

            m_url = baseAddress;
            m_descriptions = settings.Descriptions;
            m_configuration = settings.Configuration;

            m_listener = new TlsListener(m_url, settings);
            m_listener.ConnectionOpened += Listener_ConnectionOpened;
            m_listener.ConnectionClosed += Listener_ConnectionClosed;
            m_listener.ReceiveMessage += Listener_ReceiveMessage;

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
            IPAddress address = IPAddress.Any;
            int port = (m_url.Port <= 0) ? 4843 : m_url.Port;

            if (!IPAddress.TryParse(m_url.DnsSafeHost, out address))
            {
                address = IPAddress.Any;
            }


            Task.Run(() => m_listener.ListenAsync(address, port));
        }

        /// <summary>
        /// Stops listening.
        /// </summary>
        public void Stop()
        {
            lock (m_lock)
            {
                if (m_listener != null)
                {
                    m_listener.ConnectionOpened -= Listener_ConnectionOpened;
                    m_listener.ConnectionClosed -= Listener_ConnectionClosed;
                    m_listener.ReceiveMessage -= Listener_ReceiveMessage;
                    m_listener.CloseAsync().Wait();
                }
            }
        }
        #endregion

        #region Private Methods
        private void CleanupChannel(TlsServerChannel channel)
        {
            if (!channel.IsDisposed)
            {
                lock (m_channels)
                {
                    m_channels.Remove(channel.ChannelId);
                }

                channel.IsDisposed = true;
                channel.Serializer.Dispose();
                channel.Connection.Dispose();
            }
        }

        private void OnCleanupTimerExpired(object state)
        {
            try
            {
                Queue<TlsServerChannel> channelsToCleanup = new Queue<TlsServerChannel>();

                lock (m_channels)
                {
                    foreach (var channel in m_channels)
                    {
                        long quietTime = DateTime.UtcNow.Ticks - channel.Value.LastMessageTime;
                        quietTime /= TimeSpan.TicksPerMillisecond;

                        if (quietTime > m_maxIdleTime || (!channel.Value.WasOpened && quietTime > m_maxSetupTime))
                        {
                            channelsToCleanup.Enqueue(channel.Value);
                        }
                    }
                }

                while (channelsToCleanup.Count > 0)
                {
                    CleanupChannel(channelsToCleanup.Dequeue());
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write("Unexpected error deleting connections: " + e.Message);
            }
        }

        private class TlsServerChannel
        {
            public uint ChannelId;
            public UaTcpChannelSerializer Serializer;
            public TlsConnection Connection;
            public long LastMessageTime;
            public bool IsDisposed;
            public bool WasOpened;
        }

        private void Listener_ConnectionOpened(object sender, ConnectionStateEventArgs e)
        {
            var channel = new TlsServerChannel()
            {
                ChannelId = (uint)Utils.IncrementIdentifier(ref m_nextChannelId),
                Serializer = new UaTcpChannelSerializer(m_bufferManager, m_quotas, m_serverCertificate, null, m_descriptions),
                Connection = e.Connection,
                LastMessageTime = DateTime.UtcNow.Ticks
            };

            channel.Serializer.ChannelId = channel.ChannelId;

            lock (m_channels)
            {
                m_channels[channel.ChannelId] = channel;
            }

            e.Connection.Handle = channel;
        }

        private void Listener_ConnectionClosed(object sender, ConnectionStateEventArgs e)
        {
            var channel = e.Connection.Handle as TlsServerChannel;

            if (channel != null)
            {
                CleanupChannel(channel);
            }

            if (ServiceResult.IsBad(e.Error))
            {
                Utils.Trace("TlsServerChannel Error: {0}", e.Error);
            }
        }

        private void Listener_ReceiveMessage(object sender, ReceiveMessageEventArgs e)
        {
            var message = e.Message;
            var messageType = BitConverter.ToUInt32(message.Array, message.Offset);

            switch (messageType)
            {
                case TcpMessageType.Hello:
                {
                    ProcessHello(e.Connection, message);
                    break;
                }

                case TcpMessageType.Open | TcpMessageType.Final:
                {
                    ProcessOpen(e.Connection, message);
                    break;
                }

                case TcpMessageType.Close | TcpMessageType.Final:
                {
                    ProcessClose(e.Connection, message);
                    break;
                }

                case TcpMessageType.MessageIntermediate:
                case TcpMessageType.MessageFinal:
                {
                    ProcessRequest(e.Connection, message);
                    break;
                }

                default:
                {
                    Utils.Trace("Invalid MessageType: 0x{0:X8}", messageType);
                    m_bufferManager.ReturnBuffer(message.Array, "TlsTransportListener.Listener_ReceiveMessage");
                    e.Connection.Dispose();
                    break;
                }
            }
        }

        private void ProcessHello(TlsConnection connection, ArraySegment<byte> chunk)
        { 
            ServiceResult result = null;
            ArraySegment<byte> message;

            var channel = connection.Handle as TlsServerChannel;

            if (channel == null)
            {
                m_bufferManager.ReturnBuffer(chunk.Array, "TlsTransportListener.ProcessHello");
                message = channel.Serializer.ConstructErrorMessage(new ServiceResult(StatusCodes.BadSecureChannelIdInvalid));
                connection.Enqueue(message);
                return;
            }

            channel.LastMessageTime = DateTime.UtcNow.Ticks;

            try
            {                
                result = channel.Serializer.ProcessHelloMessage(chunk);

                if (ServiceResult.IsGood(result))
                {
                    message = channel.Serializer.ConstructAcknowledgeMessage();
                    connection.Enqueue(message);
                    return;
                }
            }
            catch (Exception e)
            {
                m_bufferManager.ReturnBuffer(chunk.Array, "TlsTransportListener.ProcessHello");
                message = channel.Serializer.ConstructErrorMessage(new ServiceResult(e));
                connection.Enqueue(message);
            }
        }

        private void ProcessOpen(TlsConnection connection, ArraySegment<byte> chunk)
        {
            ArraySegment<byte> message;

            var channel = connection.Handle as TlsServerChannel;

            if (channel == null)
            {
                m_bufferManager.ReturnBuffer(chunk.Array, "TlsTransportListener.ProcessOpen");
                message = channel.Serializer.ConstructErrorMessage(new ServiceResult(StatusCodes.BadSecureChannelIdInvalid));
                connection.Enqueue(message);
                return;
            }

            channel.LastMessageTime = DateTime.UtcNow.Ticks;

            try
            {
                uint requestId = channel.Serializer.ProcessOpenSecureChannelRequest(chunk);

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
                    String.Format(g_ImplementationString, (connection.Stream is System.Net.Security.SslStream) ? "TLS" : "TCP"),
                    m_url.ToString(),
                    channel.ChannelId.ToString(),
                    channel.Serializer.EndpointDescription,
                    channel.Serializer.ClientCertificate,
                    channel.Serializer.ServerCertificate,
                    BinaryEncodingSupport.Required);

                channel.WasOpened = true;
                message = channel.Serializer.ConstructOpenSecureChannelResponse(requestId);
                connection.Enqueue(message);
            }
            catch (Exception e)
            {
                m_bufferManager.ReturnBuffer(chunk.Array, "TlsTransportListener.ProcessHello");
                message = channel.Serializer.ConstructErrorMessage(new ServiceResult(e));
                connection.Enqueue(message);
            }
        }

        private void ProcessClose(TlsConnection connection, ArraySegment<byte> chunk)
        {
            ArraySegment<byte> message;

            var channel = connection.Handle as TlsServerChannel;

            if (channel == null)
            {
                m_bufferManager.ReturnBuffer(chunk.Array, "TlsTransportListener.ProcessClose");
                message = channel.Serializer.ConstructErrorMessage(new ServiceResult(StatusCodes.BadSecureChannelIdInvalid));
                connection.Enqueue(message);
                return;
            }

            channel.LastMessageTime = DateTime.UtcNow.Ticks;

            try
            {
                channel.Serializer.ProcessCloseSecureChannelRequest(chunk);
                CleanupChannel(channel);
            }
            catch (Exception e)
            {
                m_bufferManager.ReturnBuffer(chunk.Array, "TlsTransportListener.ProcessClose");
                message = channel.Serializer.ConstructErrorMessage(new ServiceResult(e));
                connection.Enqueue(message);
            }
        }

        private class TlsProcessRequestAsyncState
        {
            public uint RequestId;
            public TlsServerChannel Channel;
        }   

        private void ProcessRequest(TlsConnection connection, ArraySegment<byte> chunk)
        {
            var channel = connection.Handle as TlsServerChannel;

            if (channel == null)
            {
                m_bufferManager.ReturnBuffer(chunk.Array, "TlsTransportListener.ProcessRequest");
                var message = channel.Serializer.ConstructErrorMessage(new ServiceResult(StatusCodes.BadSecureChannelIdInvalid));
                connection.Enqueue(message);
                return;
            }

            channel.LastMessageTime = DateTime.UtcNow.Ticks;

            try
            {
                uint requestId = 0;
                IServiceRequest request = channel.Serializer.ProcessRequest(chunk, out requestId);

                if (request != null)
                {
                    var ad = new TlsProcessRequestAsyncState()
                    {
                        Channel = channel,
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
                connection.Enqueue(message);
                return;
            }
        }

        private void OnRequestProcessed(IAsyncResult result)
        {
            TlsProcessRequestAsyncState ad = (TlsProcessRequestAsyncState)result.AsyncState;

            try
            {
                if (!ad.Channel.IsDisposed)
                {
                    var response = m_callback.FinishRequest(result);
                    var message = ad.Channel.Serializer.ConstructResponse(ad.RequestId, response);
                    ad.Channel.Connection.Enqueue(message);
                }
            }
            catch (Exception e)
            {
                Utils.Trace(e, "TLS LISTENER - Unexpected error sending response.");
            }
        }
        #endregion
    }    
}
