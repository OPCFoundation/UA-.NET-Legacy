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
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Security;
using Opc.Ua.Bindings;

namespace Opc.Ua
{
    /// <summary>
    /// A host for a UA service.
    /// </summary>
    public class ServiceHost : System.ServiceModel.ServiceHost, IServiceHostBase
    {
        #region Constructors
        /// <summary>
        /// Initializes the service host.
        /// </summary>
        /// <param name="server">The server.</param>
        /// <param name="endpointType">Type of the endpoint.</param>
        /// <param name="addresses">The addresses.</param>
		public ServiceHost(ServerBase server, Type endpointType, params Uri[] addresses) : base(endpointType, addresses)
        {
            m_server = server;
            m_stopServerOnClose = false;
		}
        #endregion

        #region IServerHostBase Members
        /// <summary>
        /// The UA server instance associated with the service host.
        /// </summary>
        /// <value>The server.</value>
        public IServerBase Server
        {
            get { return m_server; }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Whether the host should stop its contained server when it is closed.
        /// </summary>
        /// <value><c>true</c> if server is to be stoped on close, otherwise <c>false</c>.</value>
        public bool StopServerOnClose
        {
            get { return m_stopServerOnClose; }
            set { m_stopServerOnClose = value; }
        }

        /// <summary>
        /// Initializes the host for protocols that support a single policy per endpoint.
        /// </summary>
        /// <param name="contractType">Type of the contract.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="bindingFactory">The binding factory.</param>
        /// <param name="endpointConfiguration">The endpoint configuration.</param>
        /// <param name="endpoints">The endpoints.</param>
        /// <param name="securityMode">The security mode.</param>
        /// <param name="securityPolicyUri">The security policy URI.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling")]
        public void InitializeSinglePolicy(
            Type                      contractType,
            ApplicationConfiguration  configuration, 
            BindingFactory            bindingFactory,
            EndpointConfiguration     endpointConfiguration,
            List<EndpointDescription> endpoints,
            MessageSecurityMode       securityMode, 
            string                    securityPolicyUri)
        {
            // allow any url to match.
            System.ServiceModel.ServiceBehaviorAttribute behavoir = this.Description.Behaviors.Find<System.ServiceModel.ServiceBehaviorAttribute>();
            behavoir.AddressFilterMode = System.ServiceModel.AddressFilterMode.Any;

            // specify service credentials          
            ServiceCredentials credentials = new ServiceCredentials();
        
            credentials.ClientCertificate.Authentication.CertificateValidationMode  = X509CertificateValidationMode.Custom;
            credentials.ClientCertificate.Authentication.TrustedStoreLocation       = StoreLocation.LocalMachine;
            credentials.ClientCertificate.Authentication.RevocationMode             = X509RevocationMode.NoCheck;
            credentials.ClientCertificate.Authentication.CustomCertificateValidator = configuration.CertificateValidator.GetChannelValidator();
            
            if (configuration.SecurityConfiguration.ApplicationCertificate != null)
            {
                X509Certificate2 certificate = configuration.SecurityConfiguration.ApplicationCertificate.Find(true);
 
                if (certificate != null)
                {
                    credentials.ServiceCertificate.Certificate = CertificateFactory.Load(certificate, true);
                }
            }
            
            this.Description.Behaviors.Add(credentials);
            
            // check if explicitly specified.
            ServiceThrottlingBehavior throttle = this.Description.Behaviors.Find<ServiceThrottlingBehavior>();

            if (throttle == null)
            {
                throttle = new ServiceThrottlingBehavior();

                throttle.MaxConcurrentCalls = 1000;
                throttle.MaxConcurrentInstances = 100;
                throttle.MaxConcurrentSessions = 100;

                this.Description.Behaviors.Add(throttle);
            }
                        
            // add the endpoints for each base address.                          
            foreach (Uri baseAddress in this.BaseAddresses)
            {   
                ServiceEndpoint endpoint = null;
               
                // find endpoint configuration.
                EndpointDescription description = null;

                foreach (EndpointDescription current in endpoints)
                {
                    if (new Uri(current.EndpointUrl) == baseAddress)
                    {
                        description = current;
                        break;
                    }
                }

                // skip endpoints without a matching base address.
                if (description == null)
                {
                    continue;
                }

                // set the supported profiles.
                description.TransportProfileUri = Profiles.WsHttpXmlOrBinaryTransport;
                
                // create the SOAP XML binding
                Binding binding = bindingFactory.Create(baseAddress.Scheme, description, endpointConfiguration);
                
                // add the session endpoint.
                endpoint = this.AddServiceEndpoint(contractType, binding, baseAddress, baseAddress);
                
                // set the protection level
                if (securityMode == MessageSecurityMode.Sign)
                {
                    endpoint.Contract.ProtectionLevel = System.Net.Security.ProtectionLevel.Sign;
                }

                // update the max items in graph (set to an low value by default).
                foreach (OperationDescription operation in endpoint.Contract.Operations)            
                {
                    operation.Behaviors.Find<DataContractSerializerOperationBehavior>().MaxItemsInObjectGraph = Int32.MaxValue;
                }
            }
        }

        /// <summary>
        /// Adds the discovery url to the hosts.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="discoveryUrls">The discovery urls.</param>
        public virtual void InitializeDiscovery(
            ApplicationConfiguration configuration,
            StringCollection         discoveryUrls)
        {
            // create the binding factory.
            BindingFactory bindingFactory = BindingFactory.Create(configuration, configuration.CreateMessageContext());
            EndpointConfiguration endpointConfiguration = EndpointConfiguration.Create(configuration);
                        
            foreach (string discoveryUrl in discoveryUrls)
            {                  
                // parse discovery url.
                Uri url = Utils.ParseUri(discoveryUrl);

                if (url == null)
                {
                    continue;
                }

                // create endpoint.
                if (url.PathAndQuery.EndsWith("/discovery"))
                {
                    Binding binding = bindingFactory.Create(url.Scheme, endpointConfiguration);
                    this.AddServiceEndpoint(typeof(IDiscoveryEndpoint), binding, url, url);
                }
            }
        }
        #endregion        
        
        #region Overridden Methods
        /// <summary>
        /// Shutdowns the server gracefully.
        /// </summary>
        protected override void OnClosing()
        {            
            // stop the server.
            if (m_stopServerOnClose && m_server != null)
            {
                m_server.Stop();
                m_server = null;
            }
            
            base.OnClosing();
        }

        /// <summary>
        /// Starts the UA TCP listener if configured as part of the host.
        /// </summary>
        protected override void OnOpening()
        {
            base.OnOpening();
        }
        #endregion

        #region Private Fields
        private ServerBase m_server;
        private bool m_stopServerOnClose;
        #endregion
    }
}
