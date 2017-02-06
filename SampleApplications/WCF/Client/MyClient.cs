/* ========================================================================
 * Copyright (c) 2005-2017 The OPC Foundation, Inc. All rights reserved.
 *
 * OPC Foundation MIT License 1.00
 * 
 * Permission is hereby granted, free of charge, to any person
 * obtaining a copy of this software and associated documentation
 * files (the "Software"), to deal in the Software without
 * restriction, including without limitation the rights to use,
 * copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the
 * Software is furnished to do so, subject to the following
 * conditions:
 * 
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 * OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.
 *
 * The complete license agreement can be found here:
 * http://opcfoundation.org/License/MIT/1.00/
 * ======================================================================*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using System.Security.Cryptography.X509Certificates;

namespace Opc.Ua.Sample
{
    /// <summary>
    /// Manages a session with a server.
    /// </summary>
    class MyClient : SessionEndpointClient
    {
        #region Public Methods
        /// <summary>
        /// Initializes the client with a binding and endpoint address.
        /// </summary>
        /// <param name="binding">The binding to use.</param>
        /// <param name="address">The address of the server.</param>
        public MyClient(Binding binding, EndpointAddress address) : base(binding, address)
        {
        }

        /// <summary>
        /// Creates a new client instance which can connect to the specified server.
        /// </summary>
        /// <param name="url">The URL for the server.</param>
        /// <param name="serverCertificate">The certificate used by the server.</param>
        /// <returns>The new client object.</returns>
        public static MyClient Create(string url, X509Certificate2 serverCertificate)
        {
            // Look up client certificate.
            X509Certificate2 clientCertificate = SecurityUtils.InitializeCertificate(
               StoreName.My, 
               StoreLocation.CurrentUser, 
               "My Client Name");

            // The private key is what the client uses to prove that it is the legimate holder
            // of the certificate. It is stored in a location that can only be accessed by the
            // current user or the adminstrator. We cannot continue if the private key is missing.
            if (clientCertificate == null || !clientCertificate.HasPrivateKey)
            {
                throw new StatusCodeException(
                    StatusCodes.BadConfigurationError,
                    "Cannot find client certificate or the private key is missing.");
            }

            // The endpoint description stores the information required to connect to the server.
            // This includes the security settings which have to be used to initialize the WCF binding.
            // This structure is what is returned by a UA discovery server.
            EndpointDescription endpoint = CreateEndpointDescription(url, serverCertificate);
            
            // Initialize the binding that is used to connect.
            // The binding configurations are specified in the app.config file.
            Binding binding = CreateSessionBinding(endpoint);
            
            // The stack needs some way to verify that it is connecting to the correct server.
            // In this case we assume that the client has verified the server certificate and 
            // tell the stack to check for it when connecting.
            EndpointIdentity serverIdentity =  EndpointIdentity.CreateX509CertificateIdentity(serverCertificate);  
   
            // Associate the endpoint url with the server certificate.
            EndpointAddress address = new EndpointAddress(new Uri(endpoint.EndpointUrl), serverIdentity);
           
            // Instantiate the channel (does not actually connect).
            MyClient channel = new MyClient(binding, address);                        
            channel.m_clientCertificate = clientCertificate;

            // Add the client certificate into the behavoirs.
            ClientCredentials credentials = (ClientCredentials)channel.ChannelFactory.Endpoint.Behaviors[typeof(ClientCredentials)];

            if (clientCertificate != null)
            {
                credentials.ClientCertificate.Certificate = clientCertificate;
            }

            return channel;
        }

        /// <summary>
        /// Creates a session with the server.
        /// </summary>
        public void CreateSession()
        {
            ApplicationDescription description = new ApplicationDescription();

            description.ApplicationName = new LocalizedText("UA Sample Client");
            description.ApplicationType = ApplicationType.Client_1;
            description.ApplicationUri = "http://localhost/UASampleClient";
            
            byte[] serverCertificateData; 
            ListOfEndpointDescription serverEndpoints;
            ListOfSignedSoftwareCertificate serverSoftwareCertificates;
            SignatureData serverSignature;

            // create a client nonce.
            byte[] clientNonce = new byte[32];
            RNGCryptoServiceProvider random = new RNGCryptoServiceProvider();
            random.GetBytes(clientNonce);

            string endpointUrl = this.Endpoint.Address.Uri.ToString();

            // create the session.
            CreateSession(
                CreateRequestHeader(),
                description,
                null,
                this.Endpoint.Address.Uri.ToString(),
                "My Session",
                clientNonce,
                m_clientCertificate.RawData,
                600000,
                0,
                out m_sessionId,
                out m_authenticationToken,
                out m_sessionTimeout,
                out m_serverNonce,
                out serverCertificateData,
                out serverEndpoints,
                out serverSoftwareCertificates,
                out serverSignature,
                out m_maxRequestMessageSize);

            // find the endpoint description being used.
            string securityPolicyUri = "";

            Uri url = new Uri(endpointUrl);

            foreach (EndpointDescription serverEndpoint in serverEndpoints)
            {
                Uri url2 = new Uri(serverEndpoint.EndpointUrl);

                if (url2.Scheme == url.Scheme && url2.Port == url.Port && url2.PathAndQuery == url.PathAndQuery)
                {
                    securityPolicyUri = serverEndpoint.SecurityPolicyUri;
                    break;
                }
            }

            // validate the server's signature.
            byte[] dataToSign = SecurityUtils.Append(m_clientCertificate.RawData, clientNonce);

            bool valid = SecurityUtils.Verify(
                new X509Certificate2(serverCertificateData),
                securityPolicyUri,
                dataToSign,
                serverSignature);

            if (!valid)
            {
                throw new StatusCodeException(
                    StatusCodes.BadSecurityChecksFailed,
                    "Server did not provide a correct signature for the nonce data provided by the client.");
            }

            // create the client signature.
            dataToSign = SecurityUtils.Append(serverCertificateData, m_serverNonce);

            SignatureData clientSignature = SecurityUtils.Sign(
                m_clientCertificate, 
                securityPolicyUri, 
                dataToSign);

            // use an anonymous user identity token.
            ExtensionObject userIdentityToken = new ExtensionObject(
                new ExpandedNodeId(Objects.AnonymousIdentityToken_Encoding_DefaultXml), 
                new AnonymousIdentityToken());

            ListOfStatusCode results;
            ListOfDiagnosticInfo diagnosticInfos;

            // activate the session.
            ActivateSession(
                CreateRequestHeader(),
                clientSignature,
                new ListOfSignedSoftwareCertificate(),
                new ListOfString(),
                null,
                null,
                out m_serverNonce,
                out results,
                out diagnosticInfos);
        }

        /// <summary>
        /// Creates a header for a request.
        /// </summary>
        public RequestHeader CreateRequestHeader()
        {
            RequestHeader requestHeader = new RequestHeader();

            requestHeader.AuthenticationToken = m_authenticationToken;
            requestHeader.RequestHandle = ++m_requestId;
            requestHeader.ReturnDiagnostics = 0;
            requestHeader.TimeoutHint = 30000;
            requestHeader.Timestamp = DateTime.UtcNow;
            requestHeader.AuditEntryId = null;
            requestHeader.AdditionalHeader = new ExtensionObject();

            return requestHeader;
        }
        #endregion
        
        #region Private Methods
        /// <summary>
        /// Returns an endpoint description for the specified URL.
        /// </summary>
        /// <param name="url">The URL to use.</param>
        /// <returns>Tne endpoint description.</returns>
        /// <remarks>
        /// This method fills in default security settings for the server.
        /// It will not be possible to connect to the server if the server's settings do not match.
        /// </remarks>
        private static EndpointDescription CreateEndpointDescription(string url, X509Certificate2 serverCertificate)
        {
            // fill in the minimum amount of information.
            EndpointDescription description = new EndpointDescription();
            
            // The EndpointUrl specifies the communication protocol to use as well as the network address.
            description.EndpointUrl = url;

            // The SecurityMode determines what security is applied to the messages.
            // If the SecurityMode is None then security is turned off.
            description.SecurityMode = MessageSecurityMode.SignAndEncrypt_3;

            // The SecurityPolicyUri is a UA defined URI which represents a suite of cryptography algorithms.
            // This field is ignored if the SecurityMode is None and should be set to SecurityPolicies.None
            description.SecurityPolicyUri = SecurityPolicies.Basic256Rsa15;

            // The server certificate is stored as DER encoded blob.
            description.ServerCertificate = serverCertificate.RawData;

            return description;
        }

        /// <summary>
        /// Constructs the binding from the endpoint description.
        /// </summary>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        private static Binding CreateSessionBinding(EndpointDescription endpoint)
        {
            // Parse the url provided.
            Uri url = new Uri(endpoint.EndpointUrl);

            // Construct the binding based on the URL scheme.
            // The available bindings are specified in the app.config file.
            // Applications cannot communicate unless the binding configuration matches.
            // UA specifies standard binding configurations to ensure interoperability.
            // The bindings used in the sample app.config file are the standard UA bindings.
            Binding binding = null;
            
            switch (url.Scheme)
            {
                case "http":
                {
                    binding = new BasicHttpBinding("UaBasicSoapXmlBinding_ISessionEndpoint");
                    break;
                }

                case "net.tcp":
                {
                    binding = new NetTcpBinding("UaSoapXmlOverTcpBinding_IDiscoveryEndpoint");
                    break;
                }

                case "net.pipe":
                {
                    binding = new NetNamedPipeBinding("UaSoapXmlOverPipeBinding_IDiscoveryEndpoint");
                    break;
                }
                    /*
                case "http":
                {
                    binding = new CustomBinding("UaSoapXmlBinding_ISessionEndpoint");
                    break;
                }

                case "net.tcp":
                {
                    binding = new CustomBinding("UaSoapXmlOverTcpBinding_ISessionEndpoint");
                    break;
                }

                case "net.pipe":
                {
                    binding = new CustomBinding("UaSoapXmlOverPipeBinding_ISessionEndpoint");
                    break;
                }
                     */
            }

            // TBD - Modify the binding to match the SecuirtyMode and the SecurityPolicyUri
            // specified in the EndpointDescription. SignAndEncrypt/Basic256Rsa15 is the default.

            return binding;
        }
        #endregion

        #region Private Fields
        private uint m_requestId;
        private NodeId m_sessionId;
        private NodeId m_authenticationToken;
        private double m_sessionTimeout;
        private uint m_maxRequestMessageSize;
        private byte[] m_serverNonce;
        private X509Certificate2 m_clientCertificate;
        #endregion
    }
}
