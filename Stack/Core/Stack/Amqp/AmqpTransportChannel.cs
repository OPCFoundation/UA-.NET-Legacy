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
using System.Threading;
using System.Threading.Tasks;

namespace Opc.Ua.Bindings
{
    /// <summary>
    /// Wraps the AmqpTransportChannel and provides an ITransportChannel implementation.
    /// </summary>
    public class AmqpTransportChannel : ITransportChannel, IAmqpMessageSink
    {
        #region Private Fields
        private object m_lock = new object();
        private bool m_disposed;
        private Uri m_url;
        private int m_operationTimeout;
        private TransportChannelSettings m_settings;
        private TcpChannelQuotas m_quotas;
        private string m_clientChannelId;
        private long m_requestId = 10000;
        private IAmqpConnection m_connection;
        private UaTcpChannelSerializer m_serializer;
        private IAmqpListener m_listener;
        private AmqpBrokerConfigurationCollection m_brokers;
        private Dictionary<uint, SendRequestAsyncResult> m_requests;
        private BufferManager m_bufferManager;
        private SendRequestAsyncResult m_connectInProgress;
        private const string g_ImplementationString = "AmqpTransportChannel UA-AMQP " + AssemblyVersionInfo.CurrentVersion;
        #endregion

        /// <remarks />
        public AmqpTransportChannel(ApplicationConfiguration configuration)
        {
            m_brokers = AmqpBrokerConfigurationCollection.Load(configuration);
            m_requests = new Dictionary<uint, SendRequestAsyncResult>();
        }

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
            if (!m_disposed)
            {
                if (disposing)
                {
                    var connection = m_connection;

                    if (Interlocked.CompareExchange(ref m_connection, null, connection) == connection)
                    {
                        connection.Close();
                    }

                    var listener = m_listener;

                    if (Interlocked.CompareExchange(ref m_listener, null, listener) == listener)
                    {
                        listener.UnregisterSink(m_clientChannelId);
                        m_clientChannelId = null;
                    }
                }

                m_disposed = true;
            }
        }
        #endregion

        #region ITransportChannel Members
        /// <summary>
        /// Gets the description for the endpoint used by the channel.
        /// </summary>
        public EndpointDescription EndpointDescription
        {
            get { return m_settings.Description; }
        }

        /// <summary>
        /// Gets the configuration for the channel.
        /// </summary>
        public EndpointConfiguration EndpointConfiguration
        {
            get { return m_settings.Configuration; }
        }

        /// <summary>
        /// Gets the context used when serializing messages exchanged via the channel.
        /// </summary>
        public ServiceMessageContext MessageContext
        {
            get { return m_quotas.MessageContext; }
        }

        /// <summary>
        /// Gets or sets the default timeout for requests send via the channel.
        /// </summary>
        public int OperationTimeout
        {
            get { return m_operationTimeout; }
            set { m_operationTimeout = value; }
        }

        /// <summary>
        /// Initializes a secure channel with the endpoint identified by the URL.
        /// </summary>
        /// <param name="url">The URL for the endpoint.</param>
        /// <param name="settings">The settings to use when creating the channel.</param>
        /// <exception cref="ServiceResultException">Thrown if any communication error occurs.</exception>
        public void Initialize(
            Uri url,
            TransportChannelSettings settings)
        {
            SaveSettings(url, settings);
        }

        /// <summary>
        /// Initializes a secure channel with the endpoint identified by the URL.
        /// </summary>
        /// <param name="connection">The URL for the endpoint.</param>
        /// <param name="settings">The settings to use when creating the channel.</param>
        /// <exception cref="ServiceResultException">Thrown if any communication error occurs.</exception>
        public void Initialize(
            ITransportWaitingConnection connection,
            TransportChannelSettings settings)
        {
            SaveSettings(connection.EndpointUrl, settings);
        }

        /// <summary>
        /// Opens a secure channel with the endpoint identified by the URL.
        /// </summary>
        /// <exception cref="ServiceResultException">Thrown if any communication error occurs.</exception>
        public void Open()
        {
            // opens when the first request is called to preserve previous behavoir.
        }

        /// <summary>
        /// Begins an asynchronous operation to open a secure channel with the endpoint identified by the URL.
        /// </summary>
        /// <param name="callback">The callback to call when the operation completes.</param>
        /// <param name="callbackData">The callback data to return with the callback.</param>
        /// <returns>
        /// The result which must be passed to the EndOpen method.
        /// </returns>
        /// <exception cref="ServiceResultException">Thrown if any communication error occurs.</exception>
        /// <seealso cref="Open"/>
        public IAsyncResult BeginOpen(AsyncCallback callback, object callbackData)
        {
            return new AsyncResultBase(callback, callbackData, m_operationTimeout);
        }

        /// <summary>
        /// Completes an asynchronous operation to open a secure channel.
        /// </summary>
        /// <param name="result">The result returned from the BeginOpen call.</param>
        /// <exception cref="ServiceResultException">Thrown if any communication error occurs.</exception>
        /// <seealso cref="Open"/>
        public void EndOpen(IAsyncResult result)
        {
        }

        /// <summary>
        /// Closes the secure channel.
        /// </summary>
        public void Close()
        {
            var ar = BeginClose(null, null);
            EndClose(ar);
        }

        /// <summary>
        /// Begins an asynchronous operation to close the secure channel.
        /// </summary>
        /// <param name="callback">The callback to call when the operation completes.</param>
        /// <param name="callbackData">The callback data to return with the callback.</param>
        /// <returns>
        /// The result which must be passed to the EndClose method.
        /// </returns>
        /// <exception cref="ServiceResultException">Thrown if any communication error occurs.</exception>
        /// <seealso cref="Close"/>
        public IAsyncResult BeginClose(AsyncCallback callback, object callbackData)
        {
            if (m_disposed)
            {
                throw new ObjectDisposedException("AmqpTransportChannel");
            }
            
            SendRequestAsyncResult ar = new SendRequestAsyncResult(null, null, Timeout.Infinite);

            if (m_connection == null || m_serializer == null)
            {
                ar.OperationCompleted();
                return ar;
            }

            ar.RequestId = Utils.IncrementIdentifier(ref m_requestId);
            ar.Connection = m_connection;
            ar.Serializer = m_serializer;

            var message = m_serializer.ConstructCloseSecureChannelRequest(ar.RequestId);

            ar.WorkItem = Task.Run(() => SendAsync(ar, message), ar.CancellationToken).
                ContinueWith(antecedent =>
                {
                    ar.OperationCompleted();
                    CloseConnection();
                },
                TaskContinuationOptions.None);

            return ar;
        }

        /// <summary>
        /// Completes an asynchronous operation to close the secure channel.
        /// </summary>
        /// <param name="result">The result returned from the BeginClose call.</param>
        /// <exception cref="ServiceResultException">Thrown if any communication error occurs.</exception>
        /// <seealso cref="Close"/>
        public void EndClose(IAsyncResult result)
        {
            if (m_disposed)
            {
                throw new ObjectDisposedException("AmqpTransportChannel");
            }

            SendRequestAsyncResult ar = result as SendRequestAsyncResult;

            if (ar == null)
            {
                throw new ArgumentException("Invalid result object passed.", "result");
            }

            if (!ar.WaitForComplete())
            {
                throw new TimeoutException();
            }
        }

        private void CloseConnection()
        {
            var connection = m_connection;
            Interlocked.CompareExchange(ref m_connection, null, connection);

            var listener = m_listener;

            if (Interlocked.CompareExchange(ref m_listener, null, listener) == listener)
            {
                listener.UnregisterSink(m_clientChannelId);
                m_clientChannelId = null;
            }

            var serializer = m_serializer;

            if (Interlocked.CompareExchange(ref m_serializer, null, serializer) == serializer)
            {
                serializer.Dispose();
            }
        }

        private async Task CreateListenerAsync(SendRequestAsyncResult ar)
        {
            IAmqpListener listener = m_listener;

            if (listener == null)
            {
                listener = await m_brokers.SelectListenerAsync(m_url, m_quotas);
            }

            var connection = m_connection;

            // check if channel has not been openned by another thread.
            if (connection == null)
            {
                lock (m_lock)
                {
                    listener.UnregisterSink(m_clientChannelId);

                    m_listener = listener;
                    m_clientChannelId = Guid.NewGuid().ToString();
                    m_requestId = 2000;

                    listener.RegisterSink(m_clientChannelId, this);

                    m_serializer = new UaTcpChannelSerializer(
                        m_bufferManager,
                        m_quotas,
                        m_settings.ServerCertificate,
                        m_settings.ClientCertificate,
                        new EndpointDescriptionCollection(new EndpointDescription[] { m_settings.Description }));
                }

                string amqpNodeName = m_url.PathAndQuery;

                while (amqpNodeName.StartsWith("/")) amqpNodeName = amqpNodeName.Substring(1);
                while (amqpNodeName.EndsWith("/")) amqpNodeName = amqpNodeName.Substring(0, amqpNodeName.Length - 1);

                m_connection = await listener.ConnectAsync(amqpNodeName);

                ar.Connection = m_connection;
                ar.Serializer = m_serializer;
            }
        }

        private async Task SendAsync(SendRequestAsyncResult ar, ArraySegment<byte> message)
        {
            try
            { 
                string messageId = m_clientChannelId;
                messageId += ":";
                messageId += ar.Serializer.SequenceNumber;
                messageId += "/";
                messageId += ar.RequestId;

                var settings = new AmqpServiceMessageSettings()
                {
                    MessageId = messageId,
                    ChannelId = m_clientChannelId,
                    SequenceNumber = ar.Serializer.SequenceNumber
                };

                // Utils.Trace("SEND {0} {1}", m_clientChannelId, messageId);
                await ar.Connection.SendAsync(settings, message);
            }
            finally
            {
                m_bufferManager.ReturnBuffer(message.Array, "AmqpTransportChannel.SendAsync");
            }
        }

        private async Task SendAsync(SendRequestAsyncResult ar, BufferCollection message)
        {
            try
            {
                long sequenceNumber = ar.Serializer.SequenceNumber - message.Count + 1;

                foreach (var chunk in message)
                {
                    string messageId = m_clientChannelId;
                    messageId += ":";
                    messageId += sequenceNumber;
                    messageId += "/";
                    messageId += ar.RequestId;

                    var settings = new AmqpServiceMessageSettings()
                    {
                         MessageId = messageId,
                         ChannelId = m_clientChannelId,
                         SequenceNumber = ar.Serializer.SequenceNumber
                    };

                    // Utils.Trace("SEND {0} {1}", m_clientChannelId, messageId);
                    await ar.Connection.SendAsync(settings, chunk);
                    sequenceNumber++;
                }
            }
            finally
            {
                message.Release(m_bufferManager, "AmqpTransportChannel.SendAsync");
            }
        }

        /// <summary>
        /// Sends a request over the secure channel.
        /// </summary>
        /// <param name="request">The request to send.</param>
        /// <returns>The response returned by the server.</returns>
        /// <exception cref="ServiceResultException">Thrown if any communication error occurs.</exception>
        public IServiceResponse SendRequest(IServiceRequest request)
        {
            IAsyncResult result = BeginSendRequest(request, null, null);
            return EndSendRequest(result);
        }

        private class SendRequestAsyncResult : AsyncResultBase
        {
            public uint RequestId;
            public IAmqpConnection Connection;
            public UaTcpChannelSerializer Serializer;
            public IServiceRequest Request;
            public IServiceResponse Response;
            public Task WorkItem;

            public SendRequestAsyncResult(AsyncCallback callback, object callbackData, int timeout)
            :
                base(callback, callbackData, timeout, new CancellationTokenSource())
            {
            }
        }

        private void Listener_ConnectionClosed(object sender, ConnectionStateEventArgs e)
        {
            if (ServiceResult.IsBad(e.Error))
            {
                Utils.Trace("ConnectionClosed: {0}", e.Error);

                lock (m_requests)
                {
                    foreach (var request in m_requests)
                    {
                        request.Value.Exception = new ServiceResultException(e.Error);
                        request.Value.OperationCompleted();
                    }
                }
            }
        }

        /// <remarks />
        public async void OnMessage(object sender, AmqpReceiveMessageEventArgs e)
        {                        
            // extract the request id from the correlation id.
            uint requestId = 0;

            int index = e.CorrelationId.LastIndexOf("/");

            if (index < 0 || !UInt32.TryParse(e.CorrelationId.Substring(index + 1), out requestId))
            {
                return;
            }

            // check of request is still valid.
            SendRequestAsyncResult ar = null;

            lock (m_requests)
            {
                if (!m_requests.TryGetValue(requestId, out ar))
                {
                    return;
                }
            }

            var message = e.Body;
            var messageType = BitConverter.ToUInt32(message.Array, message.Offset);

            switch (messageType)
            {
                case TcpMessageType.Acknowledge:
                {
                    await ProcessAcknowledgeAsync(e, ar);
                    break;
                }

                case TcpMessageType.Open | TcpMessageType.Final:
                {
                    await ProcessOpenAsync(e, ar);
                    break;
                }

                case TcpMessageType.MessageIntermediate:
                case TcpMessageType.MessageFinal:
                {
                    ProcessResponse(e, ar);
                    break;
                }

                case TcpMessageType.Error:
                {
                    ProcessError(e, ar);
                    break;
                }

                default:
                {
                    Utils.Trace("ERROR [AmqpTransportChannel.Listener_ReceiveMessage] Invalid MessageType: 0x{0:X8}", messageType);
                    break;
                }
            }
        }

        private void ProcessError(AmqpReceiveMessageEventArgs e, SendRequestAsyncResult ar)
        {
            ServiceResult result = null;

            try
            {
                result = ar.Serializer.ProcessError(e.Body);
                CloseConnection();
            }
            catch (Exception exception)
            {
                Utils.Trace(exception, "ERROR [AmqpTransportChannel.ProcessError] Could not process UA TCP Error message.");
                result = new ServiceResult(exception);
            }
            
            if (ar != null)
            {
                ar.Exception = new ServiceResultException(result);
                ar.OperationCompleted();
            }

            lock (m_requests)
            {
                foreach (var request in m_requests)
                {
                    request.Value.Exception = new ServiceResultException(result);
                    request.Value.OperationCompleted();
                }
            }
        }

        private async Task ProcessAcknowledgeAsync(AmqpReceiveMessageEventArgs e, SendRequestAsyncResult ar)
        {
            try
            {
                ar.Serializer.ProcessAcknowledgeMessage(e.Body);
                var message = ar.Serializer.ConstructOpenSecureChannelRequest(false);
                await SendAsync(ar, message);
            }
            catch (Exception exception)
            {
                Utils.Trace(exception, "ERROR [TlsTransportChannel.ProcessAcknowledgeAsync] Could not create OpenSecureChannel request.");
                ar.Exception = exception;
                ar.OperationCompleted();

                Interlocked.CompareExchange(ref m_connectInProgress, null, ar);
                CloseConnection();
            }
        }

        private async Task ProcessOpenAsync(AmqpReceiveMessageEventArgs e, SendRequestAsyncResult ar)
        {
            try
            {
                ar.Serializer.ProcessOpenSecureChannelResponse(e.Body);
            }
            catch (Exception exception)
            {
                Utils.Trace(exception, "ERROR [AmqpTransportChannel.ProcessOpenAsync] Could not process OpenSecureChannel reponse.");
                ar.Exception = exception;
                ar.OperationCompleted();

                Interlocked.CompareExchange(ref m_connectInProgress, null, ar);
                CloseConnection();
                return;
            }

            Opc.Ua.Security.Audit.SecureChannelCreated(
                g_ImplementationString,
                m_url.ToString(),
                ar.Serializer.ChannelId.ToString(),
                ar.Serializer.EndpointDescription,
                ar.Serializer.ClientCertificate,
                ar.Serializer.ServerCertificate,
                BinaryEncodingSupport.Required);

            var message = ar.Serializer.ConstructRequest(ar.RequestId, ar.Request);
            await SendAsync(ar, message);

            Interlocked.CompareExchange(ref m_connectInProgress, null, ar);
        }

        private void ProcessResponse(AmqpReceiveMessageEventArgs e, SendRequestAsyncResult ar)
        {
            // parse and process response.
            IServiceResponse response = null;

            try
            {
                uint requestId = 0;
                response = ar.Serializer.ProcessResponse(e.Body, out requestId);

                // nothing more to do with partial message.
                if (response == null)
                {
                    return;
                }

                ar.Response = response;
                ar.OperationCompleted();
            }
            catch (Exception exception)
            {
                Utils.Trace(exception, "ERROR [AmqpTransportChannel.ProcessResponseAsync] Could not process response.");
                ar.Exception = exception;
                ar.OperationCompleted();
            }
        }

        private async void ConnectAsync(SendRequestAsyncResult ar)
        {
            try
            {
                var pendingRequest = Interlocked.CompareExchange(ref m_connectInProgress, ar, null);

                // this is the first request to send on the channel so set up the connection with the broker.
                if (pendingRequest == null)
                {
                    await CreateListenerAsync(ar);

                    var hello = ar.Serializer.ConstructHelloMessage();
                    await SendAsync(ar, hello);
                    return;
                }

                // if not the first request to send on the channel wait for the first request to complete.
                if (!pendingRequest.WaitForComplete())
                {
                    throw new TimeoutException();
                }

                var message = ar.Serializer.ConstructRequest(ar.RequestId, ar.Request);
                await SendAsync(ar, message);
            }
            catch (Exception e)
            {
                ar.Exception = e;
                ar.OperationCompleted();
            }
        }

        /// <summary>
        /// Begins an asynchronous operation to send a request over the secure channel.
        /// </summary>
        public IAsyncResult BeginSendRequest(IServiceRequest request, AsyncCallback callback, object callbackData)
        {
            if (m_disposed)
            {
                throw new ObjectDisposedException("AmqpTransportChannel");
            }

            SendRequestAsyncResult ar = new SendRequestAsyncResult(callback, callbackData, (int)request.RequestHeader.TimeoutHint);

            try
            {
                ar.RequestId = Utils.IncrementIdentifier(ref m_requestId);
                ar.Request = request;
                ar.Connection = m_connection;
                ar.Serializer = m_serializer;

                lock (m_requests)
                {
                    m_requests[ar.RequestId] = ar;
                }

                if (ar.Connection == null)
                {
                    ar.WorkItem = Task.Run(() => ConnectAsync(ar), ar.CancellationToken);
                    return ar;
                }

                var message = ar.Serializer.ConstructRequest(ar.RequestId, request);
                ar.WorkItem = Task.Run(() => SendAsync(ar, message), ar.CancellationToken);
                return ar;
            }
            catch (Exception e)
            {
                ar.Exception = e;
                ar.OperationCompleted();
            }

            return ar;
        }

        /// <summary>
        /// Completes an asynchronous operation to send a request over the secure channel.
        /// </summary>
        public IServiceResponse EndSendRequest(IAsyncResult result)
        {
            if (m_disposed)
            {
                throw new ObjectDisposedException("AmqpTransportChannel");
            }

            SendRequestAsyncResult ar = result as SendRequestAsyncResult;

            if (ar == null)
            {
                throw new ArgumentException("Invalid result object passed.", "result");
            }

            try
            {
                if (!ar.WaitForComplete())
                {
                    throw new TimeoutException();
                }

                return ar.Response;
            }
            finally
            {
                lock (m_requests)
                {
                    m_requests.Remove(ar.RequestId);
                }
            }
        }

        /// <summary>
        /// Saves the settings so the channel can be opened later.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="settings">The settings.</param>
        private void SaveSettings(Uri url, TransportChannelSettings settings)
        {
            // save the settings.
            m_url = url;
            m_settings = settings;
            m_operationTimeout = settings.Configuration.OperationTimeout;

            // initialize the quotas.
            m_quotas = new TcpChannelQuotas();

            m_quotas.MaxBufferSize = m_settings.Configuration.MaxBufferSize;
            m_quotas.MaxMessageSize = m_settings.Configuration.MaxMessageSize;
            m_quotas.ChannelLifetime = m_settings.Configuration.ChannelLifetime;
            m_quotas.SecurityTokenLifetime = m_settings.Configuration.SecurityTokenLifetime;

            m_quotas.MessageContext = new ServiceMessageContext();

            m_quotas.MessageContext.MaxArrayLength = m_settings.Configuration.MaxArrayLength;
            m_quotas.MessageContext.MaxByteStringLength = m_settings.Configuration.MaxByteStringLength;
            m_quotas.MessageContext.MaxMessageSize = m_settings.Configuration.MaxMessageSize;
            m_quotas.MessageContext.MaxStringLength = m_settings.Configuration.MaxStringLength;
            m_quotas.MessageContext.NamespaceUris = m_settings.NamespaceUris;
            m_quotas.MessageContext.ServerUris = new StringTable();
            m_quotas.MessageContext.Factory = m_settings.Factory;

            m_quotas.CertificateValidator = settings.CertificateValidator;

            m_bufferManager = new BufferManager(url.PathAndQuery, (int)Int32.MaxValue, settings.Configuration.MaxBufferSize);
        }
        #endregion
    }
}
