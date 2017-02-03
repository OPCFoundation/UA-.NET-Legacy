/* ========================================================================
 * Copyright (c) 2005-2016 The OPC Foundation, Inc. All rights reserved.
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
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.IdentityModel.Tokens;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;
using System.Reflection;
using Opc.Ua.Bindings;

namespace Opc.Ua.Client
{
    /// <summary>
    /// The standard implementation of a UA server.
    /// </summary>
    public partial class ConnectionManager : ServerBase
    {
        #region Private Fields
        private object m_lock = new object();
        private ConfigurationWatcher m_configurationWatcher;
        private object m_registrationLock = new object();
        private ConfiguredEndpointCollection m_registrationEndpoints;
        private RegisteredServer m_registrationInfo;
        private Timer m_registrationTimer;
        private int m_minRegistrationInterval;
        private int m_maxRegistrationInterval;
        private int m_lastRegistrationInterval;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes the object with default values.
        /// </summary>
        public ConnectionManager()
        {
        }
        #endregion
        
        #region IDisposable Members
        /// <summary>
        /// An overrideable version of the Dispose.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {  
            if (disposing)
            {
                // halt any outstanding timer.
                if (m_registrationTimer != null)
                {
                    Utils.SilentDispose(m_registrationTimer);
                    m_registrationTimer = null;
                }
                
                // close the watcher.
                if (m_configurationWatcher != null)
                {
                    Utils.SilentDispose(m_configurationWatcher);
                    m_configurationWatcher = null;
                }
            }

            base.Dispose(disposing);
        }
        #endregion

        #region Public Methods used by the Host Process
        /// <summary>
        /// Registers the server with the discovery server.
        /// </summary>
        /// <returns>Boolean value.</returns>
        public bool RegisterWithDiscoveryServer()
        {
            ApplicationConfiguration configuration = string.IsNullOrEmpty(base.Configuration.SourceFilePath) ? base.Configuration : ApplicationConfiguration.Load(new FileInfo(base.Configuration.SourceFilePath), ApplicationType.Server, null, false);
            CertificateValidationEventHandler registrationCertificateValidator = new CertificateValidationEventHandler(RegistrationValidator_CertificateValidation);
            configuration.CertificateValidator.CertificateValidation += registrationCertificateValidator;            

            try
            {
                // try each endpoint.
                foreach (ConfiguredEndpoint endpoint in m_registrationEndpoints.Endpoints)
                {
                    RegistrationClient client = null;

                    try
                    {
                        var bindingFactory = BindingFactory.Create(configuration, MessageContext);

                        // update from the server.
                        bool updateRequired = true;

                        lock (m_registrationLock)
                        {
                            updateRequired = endpoint.UpdateBeforeConnect;
                        }

                        if (updateRequired)
                        {
                            endpoint.UpdateFromServer(configuration, bindingFactory);
                        }

                        lock (m_registrationLock)
                        {
                            endpoint.UpdateBeforeConnect = false;
                        }

                        // create the client.
                        client = RegistrationClient.Create(
                            configuration,
                            endpoint.Description,
                            endpoint.Configuration,
                            bindingFactory,
                            base.InstanceCertificate);

                        // register the server.
                        RequestHeader requestHeader = new RequestHeader();
                        requestHeader.Timestamp = DateTime.UtcNow;

                        client.OperationTimeout = 10000;
                        client.RegisterServer(requestHeader, m_registrationInfo);
                        return true;
                    }
                    catch (Exception e)
                    {
                        Utils.Trace("Register server failed for at: {0}. Exception={1}", endpoint.EndpointUrl, e.Message);
                    }
                    finally
                    {
                        if (client != null)
                        {
                            try
                            {
                                client.Close();
                            }
                            catch (Exception e)
                            {
                                Utils.Trace("Could not cleanly close connection with LDS. Exception={0}", e.Message);
                            }
                        }
                    }
                }
            }
            finally
            {
                if (configuration != null)
                {
                    configuration.CertificateValidator.CertificateValidation -= registrationCertificateValidator;
                }
            }            
            
            return false;
        }

        /// <summary>
        /// Checks that the domains in the certificate match the current host.
        /// </summary>
        private void RegistrationValidator_CertificateValidation(CertificateValidator sender, CertificateValidationEventArgs e)
        {
            System.Net.IPAddress[] targetAddresses = System.Net.Dns.GetHostAddresses(System.Net.Dns.GetHostName());
            
            foreach (string domain in Utils.GetDomainsFromCertficate(e.Certificate))
            {
                System.Net.IPAddress[] actualAddresses = System.Net.Dns.GetHostAddresses(domain);

                foreach (System.Net.IPAddress actualAddress in actualAddresses)
                {
                    foreach (System.Net.IPAddress targetAddress in targetAddresses)
                    {
                        if (targetAddress.Equals(actualAddress))
                        {
                            e.Accept = true;
                            return;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Registers the server endpoints with the LDS.
        /// </summary>
        /// <param name="state">The state.</param>
        private void OnRegisterServer(object state)
        {
            try
            {
                lock (m_registrationLock)
                {  
                    // halt any outstanding timer.
                    if (m_registrationTimer != null)
                    {
                        m_registrationTimer.Dispose();
                        m_registrationTimer = null;
                    }
                }

                if (RegisterWithDiscoveryServer())
                {
                    // schedule next registration.                        
                    lock (m_registrationLock)
                    {  
                        if (m_maxRegistrationInterval > 0)
                        {
                            m_registrationTimer = new Timer(
                                OnRegisterServer, 
                                this, 
                                m_maxRegistrationInterval, 
                                Timeout.Infinite);

                            m_lastRegistrationInterval = m_minRegistrationInterval;
                            Utils.Trace("Register server succeeded. Registering again in {0} ms", m_maxRegistrationInterval);
                        }
                    }
                }
                else
                {
                    lock (m_registrationLock)
                    {  
                        if (m_registrationTimer == null)
                        {
                            // calculate next registration attempt.
                            m_lastRegistrationInterval *= 2;

                            if (m_lastRegistrationInterval > m_maxRegistrationInterval)
                            {
                                m_lastRegistrationInterval = m_maxRegistrationInterval;
                            }

                            Utils.Trace("Register server failed. Trying again in {0} ms", m_lastRegistrationInterval);
                                      
                            // create timer.        
                            m_registrationTimer = new Timer(OnRegisterServer, this, m_lastRegistrationInterval, Timeout.Infinite);
                        }
                    }
                }
            }
            catch (Exception e)
            {                   
                Utils.Trace(e, "Unexpected exception handling registration timer.");
            }
        }
        #endregion

        #region Protected Members used for Initialization
        /// <summary>
        /// Raised when the configuration changes.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="Opc.Ua.ConfigurationWatcherEventArgs"/> instance containing the event data.</param>
        protected virtual void OnConfigurationChanged(object sender, ConfigurationWatcherEventArgs args)
        {
            try
            {
                ApplicationConfiguration configuration = ApplicationConfiguration.Load(
                    new FileInfo(args.FilePath),
                    Configuration.ApplicationType,
                    Configuration.GetType());

                OnUpdateConfiguration(configuration);
            }
            catch (Exception e)
            {
                Utils.Trace(e, "Could not load updated configuration file from: {0}", args);
            }
        }

        /// <summary>
        /// Called when the server configuration is changed on disk.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <remarks>
        /// Servers are free to ignore changes if it is difficult/impossible to apply them without a restart.
        /// </remarks>
        protected override void OnUpdateConfiguration(ApplicationConfiguration configuration)
        {             
            lock (m_lock)
            {
                // update security configuration.
                configuration.SecurityConfiguration.Validate();

                Configuration.SecurityConfiguration.TrustedIssuerCertificates = configuration.SecurityConfiguration.TrustedIssuerCertificates;
                Configuration.SecurityConfiguration.TrustedPeerCertificates = configuration.SecurityConfiguration.TrustedPeerCertificates;
                Configuration.SecurityConfiguration.RejectedCertificateStore = configuration.SecurityConfiguration.RejectedCertificateStore;
                
                Configuration.CertificateValidator.Update(Configuration.SecurityConfiguration);

                // update trace configuration.
                Configuration.TraceConfiguration = configuration.TraceConfiguration;

                if (Configuration.TraceConfiguration == null)
                {
                    Configuration.TraceConfiguration = new TraceConfiguration();
                }

                Configuration.TraceConfiguration.ApplySettings();
            }
        }
        
        /// <summary>
        /// Creates the endpoints and creates the hosts.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="bindingFactory">The binding factory.</param>
        /// <param name="serverDescription">The server description.</param>
        /// <param name="endpoints">The endpoints.</param>
        /// <returns>
        /// Returns IList of a host for a UA service which type is <seealso cref="ServiceHost"/>.
        /// </returns>
        protected override IList<ServiceHost> InitializeServiceHosts(
            ApplicationConfiguration          configuration, 
            BindingFactory                    bindingFactory,
            out ApplicationDescription        serverDescription,
            out EndpointDescriptionCollection endpoints)
        {
            serverDescription = null;
            endpoints = null;

            Dictionary<string,ServiceHost> hosts = new Dictionary<string,ServiceHost>();

            // ensure at least one security policy exists.
            if (configuration.ServerConfiguration.SecurityPolicies.Count == 0)
            {                   
                configuration.ServerConfiguration.SecurityPolicies.Add(new ServerSecurityPolicy());
            }
            
            // ensure at least one user token policy exists.
            if (configuration.ServerConfiguration.UserTokenPolicies.Count == 0)
            {                   
                UserTokenPolicy userTokenPolicy = new UserTokenPolicy();
                
                userTokenPolicy.TokenType = UserTokenType.Anonymous;
                userTokenPolicy.PolicyId  = userTokenPolicy.TokenType.ToString();

                configuration.ServerConfiguration.UserTokenPolicies.Add(userTokenPolicy);
            }

            // set server description.
            serverDescription = new ApplicationDescription();

            serverDescription.ApplicationUri = configuration.ApplicationUri;
            serverDescription.ApplicationName = configuration.ApplicationName;
            serverDescription.ApplicationType = configuration.ApplicationType;
            serverDescription.ProductUri = configuration.ProductUri;
            serverDescription.DiscoveryUrls = GetDiscoveryUrls();
                          
            endpoints = new EndpointDescriptionCollection();
            IList<EndpointDescription> endpointsForHost = null;

            // create UA TCP host.
            endpointsForHost = CreateUaTcpServiceHost(
                hosts,
                configuration,
                bindingFactory,
                configuration.ServerConfiguration.BaseAddresses,
                serverDescription,
                configuration.ServerConfiguration.SecurityPolicies);

            endpoints.InsertRange(0, endpointsForHost);

            // create secure Websockets host.
            endpointsForHost = CreateUaWssServiceHost(
                hosts,
                configuration,
                bindingFactory,
                configuration.ServerConfiguration.BaseAddresses,
                serverDescription,
                configuration.ServerConfiguration.SecurityPolicies);

            endpoints.AddRange(endpointsForHost);

            // create HTTPS host.
            endpointsForHost = CreateHttpsServiceHost(
                hosts,
                configuration,
                bindingFactory, 
                configuration.ServerConfiguration.BaseAddresses, 
                serverDescription,
                configuration.ServerConfiguration.SecurityPolicies);

            endpoints.AddRange(endpointsForHost);

            // create AMQP host.
            endpointsForHost = CreateAmqpsServiceHost(
                hosts,
                configuration,
                bindingFactory,
                configuration.ServerConfiguration.BaseAddresses,
                serverDescription,
                configuration.ServerConfiguration.SecurityPolicies);

            endpoints.AddRange(endpointsForHost);
            
            return new List<ServiceHost>(hosts.Values);
        }

        /// <summary>
        /// Creates an instance of the service host.
        /// </summary>
        protected override ServiceHost CreateServiceHost(ServerBase server, params Uri[] addresses)
        {
            return new ServiceHost(this, typeof(SessionEndpoint), addresses);
        }

        /// <summary>
        /// Starts the server application.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        protected override void StartApplication(ApplicationConfiguration configuration)
        {
            base.StartApplication(configuration);
                                        
            lock (m_lock)
            {
                try
                {
                    ServerError = null;
                    
                    // setup registration information.
                    lock (m_registrationLock)
                    {
                        m_maxRegistrationInterval = configuration.ServerConfiguration.MaxRegistrationInterval;

                        ApplicationDescription serverDescription = ServerDescription;

                        m_registrationInfo = new RegisteredServer();

                        m_registrationInfo.ServerUri = serverDescription.ApplicationUri;
                        m_registrationInfo.ServerNames.Add(serverDescription.ApplicationName);
                        m_registrationInfo.ProductUri = serverDescription.ProductUri;
                        m_registrationInfo.ServerType = serverDescription.ApplicationType;
                        m_registrationInfo.GatewayServerUri = null;
                        m_registrationInfo.IsOnline = true;
                        m_registrationInfo.SemaphoreFilePath = null;

                        // add all discovery urls.
                        string computerName = System.Net.Dns.GetHostName();

                        for (int ii = 0; ii < BaseAddresses.Count; ii++)
                        {
                            UriBuilder uri = new UriBuilder(BaseAddresses[ii].DiscoveryUrl);

                            if (String.Compare(uri.Host, "localhost", StringComparison.OrdinalIgnoreCase) == 0)
                            {
                                uri.Host = computerName;
                            }

                            m_registrationInfo.DiscoveryUrls.Add(uri.ToString());
                        }
                        
                        // build list of registration endpoints.
                        m_registrationEndpoints = new ConfiguredEndpointCollection(configuration);

                        EndpointDescription endpoint = configuration.ServerConfiguration.RegistrationEndpoint;

                        if (endpoint == null)
                        {
                            endpoint = new EndpointDescription();
                            endpoint.EndpointUrl = Utils.Format(Utils.DiscoveryUrls[0], "localhost");
                            endpoint.SecurityLevel = 0;
                            endpoint.SecurityMode = MessageSecurityMode.SignAndEncrypt;
                            endpoint.SecurityPolicyUri = SecurityPolicies.Basic128Rsa15;
                            endpoint.Server.ApplicationType = ApplicationType.DiscoveryServer;
                        }

                        m_registrationEndpoints.Add(endpoint);

                        m_minRegistrationInterval  = 1000;
                        m_lastRegistrationInterval = m_minRegistrationInterval;

                        // start registration timer.
                        if (m_registrationTimer != null)
                        {
                            m_registrationTimer.Dispose();
                            m_registrationTimer = null;
                        }

                        if (m_maxRegistrationInterval > 0)
                        {
                            m_registrationTimer = new Timer(OnRegisterServer, this, m_minRegistrationInterval, Timeout.Infinite);
                        }
                    }
                                        
                    // monitor the configuration file.
                    if (!String.IsNullOrEmpty(configuration.SourceFilePath))
                    {
                        m_configurationWatcher = new ConfigurationWatcher(configuration);
                        m_configurationWatcher.Changed += new EventHandler<ConfigurationWatcherEventArgs>(this.OnConfigurationChanged);
                    }
                }
                catch (Exception e)
                {
                    Utils.Trace(e, "Unexpected error starting application");
                    ServiceResult error = ServiceResult.Create(e, StatusCodes.BadInternalError, "Unexpected error starting application");
                    ServerError = error;
                    throw new ServiceResultException(error);
                }
            }
        }

        /// <summary>
        /// Called before the server stops
        /// </summary>
        protected override void OnServerStopping()
        {
            // halt any outstanding timer.
            lock (m_registrationLock)
            {
                if (m_registrationTimer != null)
                {
                    m_registrationTimer.Dispose();
                    m_registrationTimer = null;
                }
            }

            // attempt graceful shutdown the server.
            try
            {
                // unregister from Discovery Server
                m_registrationInfo.IsOnline = false;
                RegisterWithDiscoveryServer();
            }
            catch (Exception e)
            {
                ServerError = new ServiceResult(e);   
            }
        }
        #endregion
    }
}
