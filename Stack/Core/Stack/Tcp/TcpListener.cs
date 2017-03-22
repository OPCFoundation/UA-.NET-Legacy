/* Copyright (c) 1996-2017, OPC Foundation. All rights reserved.

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
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Opc.Ua.Bindings
{
    /// <summary>
    /// Manages the connections for a UA TCP server.
    /// </summary>
    public partial class UaTcpChannelListener : IDisposable, ITransportListener
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="UaTcpChannelListener"/> class.
        /// </summary>
        public UaTcpChannelListener()
        {
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2213:DisposableFieldsShouldBeDisposed", MessageId = "m_simulator")]
        protected virtual void Dispose(bool disposing)
        {
            if (disposing) 
            {
                lock (m_lock)
                {
                    if (m_listeningSocket != null)
                    {
                        try
                        {
                            m_listeningSocket.Close();
                        }
                        catch
                        {
                            // ignore errors.
                        }
                        
                        m_listeningSocket = null;
                    }

                    if (m_listeningSocketIPv6 != null)
                    {
                        try
                        {
                            m_listeningSocketIPv6.Close();
                        }
                        catch
                        {
                            // ignore errors.
                        }
                        
                        m_listeningSocketIPv6 = null;
                    }
                    
                    if (m_simulator != null)
                    {
                        Utils.SilentDispose(m_simulator);
                        m_simulator = null; 
                    }

                    foreach (TcpServerChannel channel in m_channels.Values)
                    {
                        Utils.SilentDispose(channel);
                    }
                }
            }
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

            m_uri = baseAddress;
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

            // save the server certificate.
            m_serverCertificate = settings.ServerCertificate;
            m_serverCertificateChain = settings.ServerCertificateChain;

            m_bufferManager = new BufferManager("Server", (int)Int32.MaxValue, m_quotas.MaxBufferSize);
            m_channels = new Dictionary<uint, TcpServerChannel>();

            // save the callback to the server.
            m_callback = callback;

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
            get { return m_uri; }
        }

        /// <summary>
        /// Starts listening at the specified port.
        /// </summary>
        public void Start()
        {
            lock (m_lock)
            {
                // ensure a valid port.
                int port = m_uri.Port;

                if (port <= 0 || port > UInt16.MaxValue)
                {
                    port = Utils.UaTcpDefaultPort;
                }

                // create IPv6 socket.
                IPEndPoint endpoint = new IPEndPoint(IPAddress.IPv6Any, port);    

                Socket ipv6Socket = null;
                
                try                    
                {   
                    ipv6Socket = new Socket(endpoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                }
                catch
                {
                    ipv6Socket = null; // IPv6 not supported.
                }

                // no IPv6 support - open IPv4 socket and finish.
                if (ipv6Socket == null)
                {
                    endpoint = new IPEndPoint(IPAddress.Any, port);
    	
                    m_listeningSocket = new Socket(endpoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);             
                    m_listeningSocket.Bind(endpoint);
                    m_listeningSocket.Listen(Int32.MaxValue);
                    
                    m_listeningSocket.BeginAccept(OnAccept, null);

                    return;
                }
                            
                // If operating system is Vista or later, start socket compatible both IPv4 and IPv6. Running this code in XP will throw an exception.
                if (System.Environment.OSVersion.Version.Major > 5)
                {
                    m_listeningSocket = ipv6Socket;

                    m_listeningSocket.SetSocketOption(System.Net.Sockets.SocketOptionLevel.IPv6, (System.Net.Sockets.SocketOptionName)27, 0);
                    m_listeningSocket.Bind(endpoint);
                    m_listeningSocket.Listen(Int32.MaxValue);
                    
                    m_listeningSocket.BeginAccept(OnAccept, null);

                    return;
                } 
 
                // save IPv6 socket.
                m_listeningSocketIPv6 = ipv6Socket;
       
                m_listeningSocketIPv6.Bind(endpoint);
                m_listeningSocketIPv6.Listen(Int32.MaxValue);
                    
                m_listeningSocketIPv6.BeginAccept(OnAcceptIPv6, null);

                // create seperate IPv4 socket.
                endpoint = new IPEndPoint(IPAddress.Any, port);
	
                m_listeningSocket = new Socket(endpoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);             
                m_listeningSocket.Bind(endpoint);
                m_listeningSocket.Listen(Int32.MaxValue);
                
                m_listeningSocket.BeginAccept(OnAccept, null);
            }
        }

        /// <summary>
        /// Stops listening.
        /// </summary>
        public void Stop()
        {
            lock (m_lock)
            {
                if (m_listeningSocket != null)
                {
                    m_listeningSocket.Close();
                    m_listeningSocket = null;
                }

                if (m_listeningSocketIPv6 != null)
                {
                    m_listeningSocketIPv6.Close();
                    m_listeningSocketIPv6 = null;
                }
            }
        }

        /// <summary>
        /// Binds a new socket to an existing channel.
        /// </summary>
        internal bool ReconnectToExistingChannel(
            TcpMessageSocket         socket, 
            uint                     requestId,
            uint                     sequenceNumber,
            uint                     channelId,
            X509Certificate2         clientCertificate, 
            TcpChannelToken          token,
            OpenSecureChannelRequest request)
        {            
            TcpServerChannel channel = null;

            lock (m_lock)
            {
                if (!m_channels.TryGetValue(channelId, out channel))
                {
                    throw ServiceResultException.Create(StatusCodes.BadTcpSecureChannelUnknown, "Could not find secure channel referenced in the OpenSecureChannel request.");
                }
            }
                       
            channel.Reconnect(socket, requestId, sequenceNumber, clientCertificate, token, request);
            // Utils.Trace("Channel {0} reconnected", channelId);
            return true;
        }

        /// <summary>
        /// Called when a channel closes.
        /// </summary>
        internal void ChannelClosed(uint channelId)
        {
            lock (m_lock)
            {
                m_channels.Remove(channelId);
            }

            Utils.Trace("Channel {0} closed", channelId);
        }
        #endregion
        
        #region Socket Event Handler
        /// <summary>
        /// Handles a new connection.
        /// </summary>
        private void OnAccept(IAsyncResult result)
        {
            TcpServerChannel channel = null;

            lock (m_lock)
            {
                // check if the socket has been closed.
                if (m_listeningSocket == null)
                {
                    return;
                }

                try
                {
                    // accept the socket.
                    Socket socket = m_listeningSocket.EndAccept(result);

                    // create the channel to manage incoming messages.
                    channel = new TcpServerChannel(
                        m_listenerId,
                        this,
                        m_bufferManager,
                        m_quotas,
                        m_serverCertificate,
                        m_descriptions);
                    channel.ServerCertificateChain = m_serverCertificateChain;

                    // start accepting messages on the channel.
                    channel.Attach(++m_lastChannelId, socket);

                    // save the channel for shutdown and reconnects.
                    m_channels.Add(m_lastChannelId, channel);

                    if (m_callback != null)
                    {
                        channel.SetRequestReceivedCallback(new TcpChannelRequestEventHandler(OnRequestReceived));
                    }

                    // Utils.Trace("Channel {0} created.", m_lastChannelId);
                }
                catch (Exception e)
                {
                    Utils.Trace(e, "Unexpected error accepting a new connection.");
                }

                // go back and wait for the next connection.
                try
                {
                    m_listeningSocket.BeginAccept(OnAccept, null);
                }
                catch (Exception e)
                {
                    Utils.Trace(e, "Unexpected error listening for a new connection.");
                }
            }
        }

        /// <summary>
        /// Handles a new connection.
        /// </summary>
        private void OnAcceptIPv6(IAsyncResult result)
        {
            TcpServerChannel channel = null;

            lock (m_lock)
            {
                // check if the socket has been closed.
                if (m_listeningSocketIPv6 == null)
                {
                    return;
                }

                try
                {
                    // accept the socket.
                    Socket socket = m_listeningSocketIPv6.EndAccept(result);      
                        
                    // create the channel to manage incoming messages.
                    channel = new TcpServerChannel(
                        m_listenerId,
                        this,
                        m_bufferManager,
                        m_quotas,
                        m_serverCertificate,
                        m_descriptions);
                    channel.ServerCertificateChain = m_serverCertificateChain;

                    // start accepting messages on the channel.
                    channel.Attach(++m_lastChannelId, socket);
                    
                    // save the channel for shutdown and reconnects.
                    m_channels.Add(m_lastChannelId, channel);

                    if (m_callback != null)
                    {
                        channel.SetRequestReceivedCallback(new TcpChannelRequestEventHandler(OnRequestReceived));
                    }

                    // Utils.Trace("Channel {0} created.", m_lastChannelId);
                }
                catch (Exception e)
                {
                    Utils.Trace(e, "Unexpected error accepting a new connection.");
                }

                // go back and wait for the next connection.
                try
                {
                    m_listeningSocketIPv6.BeginAccept(OnAcceptIPv6, null);
                }
                catch (Exception e)
                {
                    Utils.Trace(e, "Unexpected error listening for a new IPv6 connection.");
                }
            }   
        }
        #endregion
                
        #region Private Methods
        /// <summary>
        /// Handles requests arriving from a channel.
        /// </summary>
        private void OnRequestReceived(TcpServerChannel channel, uint requestId, IServiceRequest request)
        {
            if (m_callback != null)
            {
                try
                {
                    IAsyncResult result = m_callback.BeginProcessRequest(
                        channel.GlobalChannelId,
                        channel.EndpointDescription,
                        request,
                        OnProcessRequestComplete,
                        new object[] { channel, requestId, request });
                }
                catch (Exception e)
                {
                    Utils.Trace(e, "TCPLISTENER - Unexpected error processing request.");
                }
            }            
        }

        private void OnProcessRequestComplete(IAsyncResult result)
        {
            if (m_callback != null)
            {
                try
                {
                    object[] args = (object[])result.AsyncState;

                    TcpServerChannel channel = (TcpServerChannel)args[0];
                    IServiceResponse response = m_callback.EndProcessRequest(result);
                    channel.SendResponse((uint)args[1], response);
                }
                catch (Exception e)
                {
                    Utils.Trace(e, "TCPLISTENER - Unexpected error sending result.");
                }
            }            
        }

        /// <summary>
        /// Sets the URI for the listener.
        /// </summary>
        private void SetUri(Uri baseAddress, string relativeAddress)
        {
            if (baseAddress == null) throw new ArgumentNullException("baseAddress");

            // validate uri.
            if (!baseAddress.IsAbsoluteUri)
            {
                throw new ArgumentException(Utils.Format("Base address must be an absolute URI."), "baseAddress");
            }

            if (String.Compare(baseAddress.Scheme, Utils.UriSchemeOpcTcp, StringComparison.OrdinalIgnoreCase) != 0)
            {
                throw new ArgumentException(Utils.Format("Invalid URI scheme: {0}.", baseAddress.Scheme), "baseAddress");
            }

            m_uri = baseAddress;

            // append the relative path to the base address.
            if (!String.IsNullOrEmpty(relativeAddress))
            {
                if (!baseAddress.AbsolutePath.EndsWith("/", StringComparison.Ordinal))
                {
                    UriBuilder uriBuilder = new UriBuilder(baseAddress);
                    uriBuilder.Path = uriBuilder.Path + "/";
                    baseAddress = uriBuilder.Uri;
                }

                m_uri = new Uri(baseAddress, relativeAddress);
            }
        }
        #endregion

        #region Private Fields
        private object m_lock = new object();

        private string m_listenerId;
        private Uri m_uri;
        private EndpointDescriptionCollection m_descriptions;
        private EndpointConfiguration m_configuration;

        private BufferManager m_bufferManager;
        private TcpChannelQuotas m_quotas;
        private X509Certificate2 m_serverCertificate;

        private X509Certificate2Collection m_serverCertificateChain;
        private uint m_lastChannelId;

        private Socket m_listeningSocket;
        private Socket m_listeningSocketIPv6;
        private Dictionary<uint,TcpServerChannel> m_channels;

        private Timer m_simulator;
        private ITransportListenerCallback m_callback;
        #endregion
    }    
}
