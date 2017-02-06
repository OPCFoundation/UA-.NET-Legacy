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
using System.ServiceModel.Web;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Reflection;
using System.Xml;

namespace Opc.Ua.Bindings
{
    #if !NET4_CLIENT_FRAMEWORK
    /// <summary>
    /// Manages the connections for a UA HTTPS server.
    /// </summary>
    public partial class UaHttpsChannelListener : IDisposable, ITransportListener
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="UaTcpChannelListener"/> class.
        /// </summary>
        public UaHttpsChannelListener()
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
                    Utils.SilentDispose(m_host);
                    m_host = null;
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

        [ServiceContract]
        private interface ICrossDomainPolicy
        {
            [OperationContract]
            [WebGet(UriTemplate = "ClientAccessPolicy.xml")]
            Message ProvidePolicyFile();
        }

        [ServiceContract]
        private interface IInvokeService
        {
            [OperationContract, WebInvoke(UriTemplate = "*")]
            Stream Post(Stream istrm);
        }

        [ServiceBehavior(Namespace = Namespaces.OpcUaWsdl, ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode=InstanceContextMode.Single)]
        private class Service : IInvokeService, ICrossDomainPolicy
        {
            public Service()
            {
            }

            public UaHttpsChannelListener Listener
            {
                get { return m_listener; }
                set { m_listener = value; }
            }

            private UaHttpsChannelListener m_listener;

            public System.ServiceModel.Channels.Message ProvidePolicyFile()
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                Stream istrm = assembly.GetManifestResourceStream("Opc.Ua.Stack.Server.ClientAccessPolicy.xml");

                if (istrm != null)
                {
                    XmlReader reader = XmlReader.Create(istrm);
                    System.ServiceModel.Channels.Message result = Message.CreateMessage(MessageVersion.None, "", reader);
                    return result;
                }

                return null;
            }

            public Stream Post(Stream istrm)
            {
                MemoryStream mstrm = new MemoryStream();

                int bytesRead = 0;
                byte[] buffer = new byte[4096];

                do
                {
                    bytesRead = istrm.Read(buffer, 0, buffer.Length);
                    mstrm.Write(buffer, 0, bytesRead);
                }
                while (bytesRead != 0);
                mstrm.Position = 0;

                Dictionary<string, string> options = Parse(WebOperationContext.Current.IncomingRequest.ContentType);
                string securityPolicyUri = WebOperationContext.Current.IncomingRequest.Headers["OPCUA-SecurityPolicy"];

                StringBuilder contentType2 = new StringBuilder();
                string action = null;

                if (options[String.Empty] == "application/octet-stream")
                {
                    contentType2.Append("application/octet-stream");
                }

                else if (options[String.Empty] == "application/soap+xml")
                {
                    action = options["action"];

                    if (action == null)
                    {
                        throw new WebException("SOAP Action not specified.");
                    }

                    action = action.Substring(Namespaces.OpcUaWsdl.Length+1);

                    contentType2.Append("application/soap+xml; charset=\"utf-8\"; action=\"");
                    contentType2.Append(Namespaces.OpcUaWsdl);
                    contentType2.Append("/");
                    contentType2.Append(action);
                    contentType2.Append("Response");
                }

                else
                {
                    throw new WebException("ContentType not supported.");
                }

                WebOperationContext.Current.OutgoingResponse.ContentType = contentType2.ToString();

                IAsyncResult result = m_listener.BeginProcessRequest(mstrm, action, securityPolicyUri, null);
                Stream ostrm = m_listener.EndProcessRequest(result);

                return ostrm;
            }

            /// <summary>
            /// Parses the content type.
            /// </summary>
            private Dictionary<string, string> Parse(string contentType)
            {
                Dictionary<string, string> options = new Dictionary<string, string>();

                string[] fields = contentType.Split(';');

                for (int ii = 0; ii < fields.Length; ii++)
                {
                    string key = String.Empty;
                    string value = null;

                    int index = fields[ii].IndexOf('=');

                    if (index != -1)
                    {
                        key = fields[ii].Substring(0, index).Trim();
                        value = fields[ii].Substring(index + 1).Trim();
                        value = value.Trim('"');
                    }
                    else
                    {
                        value = fields[ii].Trim();
                    }

                    options[key] = value;
                }

                return options;
            }
        }

        /// <summary>
        /// Starts listening at the specified port.
        /// </summary>
        public void Start()
        {
            lock (m_lock)
            {
                UriBuilder root = new UriBuilder(m_uri);

                string path = root.Path;
                root.Path = String.Empty;

                WebHttpBinding binding = null;

                if (root.Scheme == Utils.UriSchemeHttps)
                {
                    binding = new WebHttpBinding(WebHttpSecurityMode.Transport);
                }
                else
                {
                    binding = new WebHttpBinding();
                }

                Service service = new Service();
                service.Listener = this;
                m_host = new System.ServiceModel.ServiceHost(service, m_uri);
                m_host.AddServiceEndpoint(typeof(ICrossDomainPolicy), binding, root.Uri).Behaviors.Add(new WebHttpBehavior());
                m_host.AddServiceEndpoint(typeof(IInvokeService), binding, "").Behaviors.Add(new WebHttpBehavior());
                m_host.Open();
            }
        }

        /// <summary>
        /// Stops listening.
        /// </summary>
        public void Stop()
        {
            lock (m_lock)
            {
                if (m_host != null)
                {
                    m_host.Close();
                    m_host = null;
                }
            }
        }
        #endregion
                
        #region Private Methods
        /// <summary>
        /// Handles requests arriving from a channel.
        /// </summary>
        private IAsyncResult BeginProcessRequest(Stream istrm, string action, string securityPolicyUri, object callbackData)
        {
            IAsyncResult result = null;

            try
            {
                if (m_callback != null)
                {
                    string contentType = WebOperationContext.Current.IncomingRequest.ContentType;
                    Uri uri = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.RequestUri;

                    string scheme = uri.Scheme + ":";

                    EndpointDescription endpoint = null;

                    for (int ii = 0; ii < m_descriptions.Count; ii++)
                    {
                        if (m_descriptions[ii].EndpointUrl.StartsWith(scheme))
                        {
                            if (endpoint == null)
                            {
                                endpoint = m_descriptions[ii];
                            }

                            if (m_descriptions[ii].SecurityPolicyUri == securityPolicyUri)
                            {
                                endpoint = m_descriptions[ii];
                                break;
                            }
                        }
                    }

                    IEncodeable request = null;
                    
                    if (String.IsNullOrEmpty(action))
                    {
                        request = BinaryDecoder.DecodeMessage(istrm, null, this.m_quotas.MessageContext);
                    }
                    else
                    {
                        string requestType = "Opc.Ua." + action + "Request";

                        request = HttpsTransportChannel.ReadSoapMessage(
                            istrm,
                            action + "Request",
                            Type.GetType(requestType),
                            this.m_quotas.MessageContext);
                    }

                    result = m_callback.BeginProcessRequest(
                        m_listenerId,
                        endpoint,
                        request as IServiceRequest,
                        null,
                        callbackData);
                }
            }
            catch (Exception e)
            {
                Utils.Trace(e, "HTTPSLISTENER - Unexpected error processing request.");
            }

            return result;
        }

        private Stream EndProcessRequest(IAsyncResult result)
        {
            MemoryStream ostrm = new MemoryStream();

            try
            {
                if (m_callback != null)
                {
                    IServiceResponse response = m_callback.EndProcessRequest(result);

                    string contentType = WebOperationContext.Current.IncomingRequest.ContentType;

                    if (contentType == "application/octet-stream")
                    {
                        BinaryEncoder encoder = new BinaryEncoder(ostrm, this.m_quotas.MessageContext);
                        encoder.EncodeMessage(response);
                    }
                    else
                    {
                        HttpsTransportChannel.WriteSoapMessage(
                            ostrm,
                            response.GetType().Name,
                            response,
                            this.m_quotas.MessageContext);
                    }

                    ostrm.Position = 0;
                }
            }
            catch (Exception e)
            {
                Utils.Trace(e, "TCPLISTENER - Unexpected error sending result.");
            }

            return ostrm;
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
        private TcpChannelQuotas m_quotas;
        private ITransportListenerCallback m_callback;
        private System.ServiceModel.ServiceHost m_host;
        #endregion
    }    
    #endif
}
