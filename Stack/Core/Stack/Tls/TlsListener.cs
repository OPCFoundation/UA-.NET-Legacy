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
using System.Net.Sockets;
using System.Net.Security;
using System.Security.Authentication;
using System.IdentityModel.Selectors;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace Opc.Ua.Bindings
{
    public sealed class TlsListener : IDisposable
    {
        private bool m_disposed;
        private X509Certificate2 m_certificate;
        private TcpListener m_listener;
        private BufferManager m_bufferManager;
        private X509CertificateValidator m_certificateValidator;
        private CancellationTokenSource m_cts = new CancellationTokenSource();

        public EventHandler<ReceiveMessageEventArgs> ReceiveMessage;
        public EventHandler<ConnectionStateEventArgs> ConnectionOpened;
        public EventHandler<ConnectionStateEventArgs> ConnectionClosed;

        public TlsListener(Uri endpointUrl, TransportListenerSettings settings)
        {
            m_disposed = false;
            m_certificate = settings.ServerCertificate;
            m_bufferManager = new BufferManager("TlsListener", (int)Int32.MaxValue, settings.Configuration.MaxBufferSize);
            m_certificateValidator = settings.CertificateValidator;
        }

        public TlsListener(TransportChannelSettings settings)
        {
            m_disposed = false;
            m_certificate = settings.ClientCertificate;
            m_bufferManager = new BufferManager("TlsListener", (int)Int32.MaxValue, settings.Configuration.MaxBufferSize);
            m_certificateValidator = settings.CertificateValidator;
        }

        #region IDisposable Support
        void CloseAll()
        {
            if (m_listener != null)
            {
                m_listener.Stop();
                m_listener = null;
            }
        }

        void Dispose(bool disposing)
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    CloseAll();
                }

                m_disposed = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
        
        public async Task ListenAsync(IPAddress address, int port)
        {
            m_listener = new TcpListener(address, port);
            m_listener.Start();

            do
            {
                var client = await m_listener.AcceptTcpClientAsync();

                try
                {
                    await AcceptConnection(client, m_cts.Token);
                }
                catch (Exception e)
                {
                    Utils.Trace(e, "[TlsListener.ListenAsync] Could not accept new connection.");
                }
            }
            while (!m_cts.IsCancellationRequested);
        }

        private class SslStreamAuthenticator
        {
            public TlsListener Listener;

            public async Task<Stream> AuthenticateAsClient(TcpClient client, string targetHost, TlsProtocol protocol)
            {
                SslProtocols sslProtocol = SslProtocols.Tls;

                if (protocol == TlsProtocol.Tls12)
                {
                    sslProtocol = SslProtocols.Tls12;
                }

                SslStream stream = new SslStream(
                    client.GetStream(),
                    false,
                    ValidateCertificate,
                    null);

                await stream.AuthenticateAsClientAsync(
                    targetHost, 
                    new X509CertificateCollection(),
                    sslProtocol, 
                    true);

                return stream;
            }

            public Stream AuthenticateAsServer(TcpClient client, X509Certificate2 certificate)
            {
                SslStream stream = new SslStream(client.GetStream(), false);
                stream.AuthenticateAsServer(certificate, false, SslProtocols.Tls12, true);
                return stream;
            }

            private bool ValidateCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            {
                return Listener.ValidateCertificate(this, certificate, chain, sslPolicyErrors);
            }
        }

        private bool ValidateCertificate(SslStreamAuthenticator sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            if (m_cts.IsCancellationRequested)
            {
                return false;
            }

            try
            {
                m_certificateValidator.Validate(certificate as X509Certificate2);
                return true;
            }
            catch (Exception e)
            {
                Utils.Trace(e, "[SslStreamAuthenticator.ValidateCertificate] SSL Certficate was not accepted. {0} {1}", sslPolicyErrors, certificate.Subject);
                return false;
            }
        }

        public async Task<TlsConnection> ConnectAsync(
            string targetHost, 
            IPAddress address, 
            int port,
            TlsProtocol protocol,
            CancellationToken cancellationToken)
        {
            var client = new TcpClient(targetHost, port);
            client.NoDelay = true;

            Stream stream = client.GetStream();

            if (protocol != TlsProtocol.None)
            {
                var authenticator = new SslStreamAuthenticator() { Listener = this };
                var tlsstream = await authenticator.AuthenticateAsClient(client, targetHost, protocol);
                stream = tlsstream;
            }

            var connection = new TlsConnection(client, stream, m_bufferManager);
            
            var callback = ConnectionOpened;

            if (callback != null)
            {
                try
                {
                    callback(this, new ConnectionStateEventArgs(connection, ServiceResult.Good));
                }
                catch (Exception e)
                {
                    Utils.Trace(e, "[TlsListener.ConnectAsync] Error raising ConnectionOpened event.");
                }
            }
            
            var task = Task.Run(() => MonitorConnection(connection));

            return connection;
        }

        public Task CloseAsync()
        {
            m_cts.Cancel();
            CloseAll();
            return Task.FromResult<object>(null);
        }

        
        private async Task MonitorConnection(TlsConnection connection)
        {
            do
            {
                try
                {
                    var message = await connection.Receive();
                    
                    connection.FirstMessageReceived = true;

                    var callback = ReceiveMessage;

                    if (callback != null)
                    {
                        try
                        {
                            callback(this, new ReceiveMessageEventArgs(connection, message));
                        }
                        catch (Exception e)
                        {
                            Utils.Trace(e, "[TlsListener.MonitorConnection] Error raising ReceiveMessage event.");
                        }
                    }
                }
                catch (Exception exception)
                {
                    var callback = ConnectionClosed;

                    if (callback != null)
                    {
                        uint statusCode = StatusCodes.BadUnexpectedError;

                        if (exception is ObjectDisposedException)
                        {
                            statusCode = StatusCodes.GoodNoData;
                        }

                        try
                        {
                            callback(this, new ConnectionStateEventArgs(connection, new ServiceResult(exception, statusCode)));
                        }
                        catch (Exception e)
                        {
                            Utils.Trace(e, "[TlsListener.MonitorConnection] Error raising ConnectionClosed event.");
                        }
                    }

                    connection.Dispose();
                    break;
                }
            }
            while (!m_cts.IsCancellationRequested);
        }

        private Task AcceptConnection(TcpClient client, CancellationToken cancellationToken)
        {
            client.NoDelay = true;

            var stream = client.GetStream();
            TlsConnection connection = new TlsConnection(client, stream, m_bufferManager);

            var authenticator = new SslStreamAuthenticator() { Listener = this };
            var tlsstream = authenticator.AuthenticateAsServer(connection.TcpClient, m_certificate);
            connection.Upgrade(tlsstream);

            var callback = ConnectionOpened;

            if (callback != null)
            {
                try
                {
                    callback(this, new ConnectionStateEventArgs(connection, ServiceResult.Good));
                }
                catch (Exception e)
                {
                    Utils.Trace(e, "[TlsListener.MonitorConnection] Error raising ConnectionOpened event.");
                }
            }

            Task.Run(() => MonitorConnection(connection), cancellationToken);

            return Task.FromResult<object>(null);
        }
    }

    public sealed class ReceiveMessageEventArgs : EventArgs
    {
        public ReceiveMessageEventArgs(TlsConnection connection, ArraySegment<byte> message)
        {
            Connection = connection;
            Message = message;
        }

        public TlsConnection Connection { get; private set; }

        public ArraySegment<byte> Message { get; private set; }
    }

    public sealed class ConnectionStateEventArgs : EventArgs
    {
        public ConnectionStateEventArgs(TlsConnection connection, ServiceResult error)
        {
            Connection = connection;
            Error = error;
        }

        public TlsConnection Connection { get; private set; }

        public ServiceResult Error { get; private set; }
    }
    public enum TlsProtocol
    {
        None,
        TlsAny,
        Tls12
    }
}
