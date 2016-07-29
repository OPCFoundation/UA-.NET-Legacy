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
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.IdentityModel.Tokens;
using System.ServiceModel.Security;
using System.IO;
using System.Xml;
using System.Threading;
using System.IdentityModel.Claims;
using System.IdentityModel.Selectors;

using Opc.Ua.Test;
using Opc.Ua.Client;

namespace Opc.Ua.ServerTest
{
    /// <summary>
    /// A class used to execute a series of tests against a server.
    /// </summary>
    public class ServerTestClient
    {
        /// <summary>
        /// Initializes the object with the specified configuration object.
        /// </summary>
        /// <param name="configuration">The application configuration.</param>
        /// <remarks>
        /// This method will create a default configuration if none is provided.
        /// </remarks>
        public ServerTestClient(ApplicationConfiguration configuration)
        {
            if (configuration == null)
            {
                // Initialize the client configuration.
                configuration = new ApplicationConfiguration();

                // Need to specify the application instance certificate for the client.
                configuration.SecurityConfiguration.ApplicationCertificate             = new CertificateIdentifier();
                configuration.SecurityConfiguration.ApplicationCertificate.StoreType   = Utils.DefaultStoreType;
                configuration.SecurityConfiguration.ApplicationCertificate.StorePath   = Utils.DefaultStorePath;
                configuration.SecurityConfiguration.ApplicationCertificate.SubjectName = "UA Sample Client";

                // set the session keep alive to 5 seconds.
                configuration.ClientConfiguration.DefaultSessionTimeout = 500000;
            }
            
            m_configuration  = configuration;
            m_messageContext = configuration.CreateMessageContext();
            m_breakpoint = new ManualResetEvent(false);
            m_stopped = false;
            m_performanceData = new List<PerfData>();
        }
        
        /// <summary>
        /// Raised when the test client has a result to report.
        /// </summary>
        public event EventHandler<ReportResultEventArgs> ReportResult
        {
            add { m_ReportTestResult += value;  }
            remove { m_ReportTestResult -= value; }
        }
        
        #region ReportResultEventArgs Class
        /// <summary>
        /// The arguments provided when raising a report result event.
        /// </summary>
        public class ReportResultEventArgs : EventArgs
        {
            #region Constructors
            /// <summary>
            /// Constructs the object.
            /// </summary>
            public ReportResultEventArgs(
                ServerTestCase testcase,
                string format,
                params object[] args)
            {
                m_testcase = testcase;
                m_format = format;
                m_args = args;
                m_stop = false;
            }
            #endregion
            
            #region Public Properties
            /// <summary>
            /// The test case being run.
            /// </summary>
            public ServerTestCase Testcase
            {
                get { return m_testcase; }
            }

            /// <summary>
            /// The result message.
            /// </summary>
            public string Format
            {
                get { return m_format; }
            }

            /// <summary>
            /// The arguments used to format the message.
            /// </summary>
            public object[] Args
            {
                get { return m_args; }
            }

            /// <summary>
            /// Whether testing should stop.
            /// </summary>
            public bool Stop
            {
                get { return m_stop;  }
                set { m_stop = value; }
            }
            #endregion

            #region Private Fields
            private ServerTestCase  m_testcase;
            private string  m_format;
            private object[] m_args;
            private bool m_stop;
            #endregion
        }
        #endregion

        /// <summary>
        /// Raised when the test client has a progress to report.
        /// </summary>
        public event EventHandler<ReportProgressEventArgs> ReportProgress
        {
            add { m_ReportTestProgress += value;  }
            remove { m_ReportTestProgress -= value; }
        }
        
        #region ReportProgressEventArgs Class
        /// <summary>
        /// The arguments provided when raising a report result event.
        /// </summary>
        public class ReportProgressEventArgs : EventArgs
        {
            #region Constructors
            /// <summary>
            /// Constructs the object.
            /// </summary>
            public ReportProgressEventArgs(
                ConfiguredEndpoint endpoint,
                ServerTestCase testcase,
                int testCount,
                int failedTestCount,
                int endpointCount,
                int totalEndpointCount,
                int iterationCount,
                int totalIterationCount,
                double currentProgress,
                double finalProgress,
                bool breakpoint)
            {
                m_endpoint = endpoint;
                m_testcase = testcase;
                m_testCount = testCount;
                m_failedTestCount = failedTestCount;
                m_endpointCount = endpointCount;
                m_totalEndpointCount = totalEndpointCount;
                m_iterationCount = iterationCount;
                m_totalIterationCount = totalIterationCount;
                m_currentProgress = currentProgress;
                m_finalProgress = finalProgress;
                m_breakpoint = breakpoint;
                m_stop = false;
            }
            #endregion
            
            #region Public Properties
            /// <summary>
            /// The endpoint beng tested.
            /// </summary>
            public ConfiguredEndpoint Endpoint
            {
                get { return m_endpoint; }
            }

            /// <summary>
            /// The test case being run.
            /// </summary>
            public ServerTestCase Testcase
            {
                get { return m_testcase; }
            }

            /// <summary>
            /// The number of tests completed.
            /// </summary>
            public int TestCount
            {
                get { return m_testCount; }
            }

            /// <summary>
            /// The number of tests failed.
            /// </summary>
            public int FailedTestCount
            {
                get { return m_failedTestCount; }
            }

            /// <summary>
            /// The number of endpoints tested.
            /// </summary>
            public int EndpointCount
            {
                get { return m_endpointCount; }
            }

            /// <summary>
            /// The total number of endpoints to test.
            /// </summary>
            public int TotalEndpointCount
            {
                get { return m_totalEndpointCount; }
            }

            /// <summary>
            /// The number of iterations completed for the current test case.
            /// </summary>
            public int IterationCount
            {
                get { return m_iterationCount; }
            }

            /// <summary>
            /// The total number of iterations for the current test case.
            /// </summary>
            public int TotalIterationCount
            {
                get { return m_totalIterationCount; }
            }

            /// <summary>
            /// The current position.
            /// </summary>
            public double CurrentProgress
            {
                get { return m_currentProgress; }
            }

            /// <summary>
            /// The final position.
            /// </summary>
            public double FinalProgress
            {
                get { return m_finalProgress; }
            }

            /// <summary>
            /// Whether a breakpoint has been hit.
            /// </summary>
            public bool Breakpoint
            {
                get { return m_breakpoint; }
            }

            /// <summary>
            /// Whether testing should stop.
            /// </summary>
            public bool Stop
            {
                get { return m_stop;  }
                set { m_stop = value; }
            }
            #endregion

            #region Private Fields
            private ConfiguredEndpoint m_endpoint;
            private ServerTestCase m_testcase;
            private int m_testCount;
            private int m_failedTestCount;
            private int m_endpointCount;
            private int m_totalEndpointCount;
            private int m_iterationCount;
            private int m_totalIterationCount;
            private double  m_currentProgress;
            private double m_finalProgress;
            private bool m_breakpoint;
            private bool m_stop;
            #endregion
        }
        #endregion

        /// <summary>
        /// Returns the elapsed time in milliseconds.
        /// </summary>
        private int GetElapsedTime(DateTime start)
        {
            return (int)(((double)(DateTime.UtcNow.Ticks - start.Ticks))/TimeSpan.TicksPerMillisecond);
        }

        /// <summary>
        /// Runs the testcases against the endpoint.
        /// </summary>
        /// <param name="endpoint">The endpoint to test.</param>
        /// <param name="testcases">The testcases to run.</param>
        public void Run(ConfiguredEndpoint endpoint, ServerTestConfiguration testConfiguration)
        {
            // save the test configuration.
            m_testConfiguration = testConfiguration;
            m_stopped = false;

            // create the binding factory.
            m_bindingFactory = BindingFactory.Create(m_configuration, m_messageContext);

            while (!m_stopped)
            {
                try
                { 
                    Report("Test run started.");

                    // update from server.
                    if (endpoint.UpdateBeforeConnect)
                    {
                        endpoint.UpdateFromServer(m_bindingFactory);
                        Report("Updated endpoint from the discovery endpoint.");
                    }
                    
                    // validate the server certificate.
                    byte[] certificateData = endpoint.Description.ServerCertificate;

                    try
                    {
                        X509Certificate2 certificate = CertificateFactory.Create(certificateData, true);
                        m_configuration.CertificateValidator.Validate(certificate);
                    }
                    catch (ServiceResultException e)
                    {
                        if (e.StatusCode != StatusCodes.BadCertificateUntrusted)
                        {
                            throw new ServiceResultException(e, StatusCodes.BadCertificateInvalid);
                        }
                        
                        // automatically trust the certificate if it is untrusted.
                        m_configuration.CertificateValidator.Update(m_configuration.SecurityConfiguration);
                    }

                    m_defaultEndpoint = endpoint;
                    
                    // fetch all endpoints from the server.
                    m_endpoints = GetEndpoints(endpoint);
                    Report("Fetched all endpoints supported by the server.");
                }
                catch (Exception e)
                {
                    Report(e, "Could not connect to server");
                    return;
                }

                m_endpointCount = 0;
                m_totalEndpointCount = 0;
                m_testCount = 0;
                m_failedTestCount = 0;
                m_iterationCount = 0;
                m_totalIterationCount = 0;

                uint totalCount = 0;
                uint failedCount = 0;
                uint endpointCount = 0;

                if (m_testConfiguration.EndpointSelection != EndpointSelection.Single)
                {
                    EndpointSelection selection = m_testConfiguration.EndpointSelection;

                    foreach (ConfiguredEndpoint current in m_endpoints.Endpoints)
                    {
                        if (IsEndpointSelected(current, selection, false))
                        {
                            m_totalEndpointCount++;
                        }

                        if (current.Description.EncodingSupport == BinaryEncodingSupport.Optional)
                        {
                            if (IsEndpointSelected(current, selection, true))
                            {
                                m_totalEndpointCount++;
                            }
                        }
                    }

                    foreach (ConfiguredEndpoint current in m_endpoints.Endpoints)
                    {
                        if (IsEndpointSelected(current, selection, false))
                        {
                            m_endpointCount++;

                            // check if test stopped.
                            if (m_stopped)
                            {
                                break;
                            }

                            DoTestForEndpoint(current, ref totalCount, ref failedCount);
                            endpointCount++;
                        }

                        if (current.Description.EncodingSupport == BinaryEncodingSupport.Optional)
                        {         
                            if (IsEndpointSelected(current, selection, true))
                            {                   
                                m_endpointCount++;
                             
                                // check if test stopped.
                                if (m_stopped)
                                {
                                    break;
                                }
                                
                                current.Configuration.UseBinaryEncoding = !current.Configuration.UseBinaryEncoding;
                                DoTestForEndpoint(current, ref totalCount, ref failedCount);
                                endpointCount++;
                            }
                        }
                    }
                }
                else
                {
                    m_endpointCount++;
                    m_totalEndpointCount = 1;

                    DoTestForEndpoint(m_defaultEndpoint, ref totalCount, ref failedCount);
                    endpointCount++;
                }

                if (failedCount > 0)
                {
                    Report("WARNING: {0} tests failed. {1} tests run.", failedCount, totalCount);
                }
                else
                {
                    Report("{0} tests completed successfully for {1} endpoints.", totalCount, endpointCount);
                    DumpPerfData();
                }

                if (!m_testConfiguration.Continuous)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Determines whether the endpoint is selected.
        /// </summary>
        /// <param name="endpoint">The endpoint.</param>
        /// <param name="selection">The selection.</param>
        /// <param name="useXml">if set to <c>true</c> then the XML encoding is used..</param>
        /// <returns>
        /// 	<c>true</c> if the endpoint selected; otherwise, <c>false</c>.
        /// </returns>
        private bool IsEndpointSelected(ConfiguredEndpoint endpoint, EndpointSelection selection, bool useXml)
        {
            if (selection == EndpointSelection.Single)
            {
                return true;
            }

            // don't allow pipes when testing across a network.
            if (endpoint.EndpointUrl.Scheme == Utils.UriSchemeNetPipe)
            {
                if (!String.Equals(endpoint.EndpointUrl.DnsSafeHost, System.Net.Dns.GetHostName(), StringComparison.OrdinalIgnoreCase))
                {
                    if (!String.Equals(endpoint.EndpointUrl.DnsSafeHost, "localhost", StringComparison.OrdinalIgnoreCase))
                    {
                        return false;
                    }
                }
            }

            if (selection == EndpointSelection.All)
            {
                return true;
            }

            switch (selection)
            {
                case EndpointSelection.AllEncryptAndSign:
                {
                    if (endpoint.Description.SecurityMode == MessageSecurityMode.SignAndEncrypt)
                    {
                        return true;
                    }

                    return false;
                }

                case EndpointSelection.AllSign:
                {
                    if (endpoint.Description.SecurityMode == MessageSecurityMode.Sign)
                    {
                        return true;
                    }

                    return false;
                }

                case EndpointSelection.AllNoSecurity:
                {
                    if (endpoint.Description.SecurityMode == MessageSecurityMode.None)
                    {
                        return true;
                    }

                    return false;
                }

                case EndpointSelection.AllHttpBinary:
                {
                    if (!useXml && endpoint.EndpointUrl.Scheme != Utils.UriSchemeOpcTcp)
                    {
                        return true;
                    }

                    return false;
                }

                case EndpointSelection.AllHttpXml:
                {
                    if (useXml && endpoint.EndpointUrl.Scheme != Utils.UriSchemeOpcTcp)
                    {
                        return true;
                    }

                    return false;
                }

                case EndpointSelection.AllUaTcp:
                {
                    if (endpoint.EndpointUrl.Scheme == Utils.UriSchemeOpcTcp)
                    {
                        return true;
                    }

                    return false;
                }
            }

            return true;
        }
        
        /// <summary>
        /// Runs a test for a single endpoint.
        /// </summary>
        private void DoTestForEndpoint(ConfiguredEndpoint endpoint, ref uint totalCount, ref uint failedCount)
        {
            m_defaultEndpoint = endpoint;

            string endpointText = Utils.Format(
                "{0}/{1}/{2}/{3}",
                m_defaultEndpoint.EndpointUrl.Scheme,
                endpoint.Description.SecurityMode,
                SecurityPolicies.GetDisplayName(endpoint.Description.SecurityPolicyUri),
                (endpoint.Configuration.UseBinaryEncoding)?"Binary":"XML");
            
            Report("Starting test for Endpoint. {0}", endpointText);

            try
            {
                DoTest(endpointText, ref totalCount, ref failedCount);
                Report("Completed test for Endpoint. {0}\r\n", endpointText);
            }
            catch (Exception e)
            {
                failedCount++;
                m_failedTestCount++;

                Report(
                    "FAILED: Unexpected error during test for Endpoint {0}. Exception={1}, Error = {2}", 
                    m_defaultEndpoint.EndpointUrl, 
                    e.GetType().FullName, 
                    new ServiceResult(e).ToLongString());               
            }
            finally
            {
                if (m_session != null)
                {
                    m_session.Close();
                    m_session = null;
                }
            }
        }

        /// <summary>
        /// Runs a test for a single endpoint.
        /// </summary>
        private void DoTest(string endpoint, ref uint totalCount, ref uint failedCount)
        {
            uint thisTestTotalCount = 0;
            uint thisTestFailedCount = 0;

            bool success = true;
            Dictionary<string,TestBase> testers = new Dictionary<string,TestBase>();
               
            DateTime globalStart = DateTime.UtcNow;
            TestBase lastTester = null;
         
            foreach (ServerTestCase testcase in m_testConfiguration.TestCases)
            {
                // ignore parent tests.
                if (String.IsNullOrEmpty(testcase.Parent))
                {
                    continue;
                }

                // get the test object for the group of tests.
                TestBase tester = null;
                
                if (!testers.TryGetValue(testcase.Parent, out tester))
                {
                    switch (testcase.Parent)
                    {
                        case "Session":
                        {
                            tester = new SessionTest(
                                GetDefaultSession(), 
                                m_testConfiguration, 
                                Report,
                                Report,
                                lastTester);

                            lastTester = tester;
                            break;
                        }

                        case "Browse":
                        {
                            tester = new BrowseTest(
                                GetDefaultSession(), 
                                m_testConfiguration, 
                                Report,
                                Report,
                                lastTester);

                            lastTester = tester;
                            break;
                        }

                        case "Read":
                        {
                            tester = new ReadTest(
                                GetDefaultSession(), 
                                m_testConfiguration, 
                                Report,
                                Report,
                                lastTester);

                            lastTester = tester;
                            break;
                        }

                        case "Write":
                        {
                            tester = new WriteTest(
                                GetDefaultSession(), 
                                m_testConfiguration, 
                                Report,
                                Report,
                                lastTester);

                            lastTester = tester;
                            break;
                        }

                        case "Call":
                        {
                            tester = new CallTest(
                                GetDefaultSession(), 
                                m_testConfiguration, 
                                Report,
                                Report,
                                lastTester);

                            lastTester = tester;
                            break;
                        }

                        case "TranslatePath":
                        {
                            tester = new TranslatePathTest(
                                GetDefaultSession(), 
                                m_testConfiguration, 
                                Report,
                                Report,
                                lastTester);

                            lastTester = tester;
                            break;
                        }

                        case "Subscribe":
                        {
                            tester = new SubscribeTest(
                                GetDefaultSession(), 
                                m_testConfiguration, 
                                Report,
                                Report,
                                lastTester);

                            lastTester = tester;
                            break;
                        }

                        case "MonitoredItem":
                        {
                            tester = new MonitoredItemTest(
                                GetDefaultSession(), 
                                m_testConfiguration, 
                                Report,
                                Report,
                                lastTester);

                            lastTester = tester;
                            break;
                        }
                    }

                    // ignore unknown tests.
                    if (tester == null)
                    {
                        continue;
                    }

                    testers.Add(testcase.Parent, tester);
                }

                try
                {
                    m_testcase = testcase;
                
                    if (!testcase.Enabled)
                    {
                        continue;
                    }

                    if (testcase.Breakpoint)
                    {
                        ReportBreakpoint();
                    }

                    for (int ii = 1; ii <= m_testConfiguration.Iterations; ii++)
                    {
                        m_iterationCount = ii;
                        m_totalIterationCount = (int)m_testConfiguration.Iterations;

                        // check if test stopped.
                        if (m_stopped)
                        {
                            break;
                        }

                        DateTime start = DateTime.UtcNow;
                        thisTestTotalCount++;
                        totalCount++;
                        m_testCount++;
                        
                        Report("", null);

                        ReportWithHeader(
                            "{1}.{2} Test Started Run #{0} at {3:HH:mm:ss} for {4}",
                            ii, 
                            testcase.Parent, 
                            testcase.Name, 
                            DateTime.Now, 
                            endpoint);
                        
                        if (!tester.Run(testcase, ii))
                        {
                            success = false;
                            thisTestFailedCount++;
                            failedCount++;
                            m_failedTestCount++;

                            ReportWithHeader(
                                "{1}.{2} Test Failed Run #{0} ({3}ms) at {4:HH:mm:ss} for {5}",
                                ii, 
                                testcase.Parent, 
                                testcase.Name, 
                                GetElapsedTime(start), 
                                DateTime.Now, 
                                endpoint);
                            
                            continue;
                        }

                        ReportWithHeader(
                            "{1}.{2} Test Success Run #{0} ({3}ms) at {4:HH:mm:ss} for {5}", 
                            ii, 
                            testcase.Parent, 
                            testcase.Name, 
                            GetElapsedTime(start), 
                            DateTime.Now, 
                            endpoint);
                    }
                }
                finally
                {
                    m_testcase = null;
                }
            }
            
            Report("", null);

            if (success)
            {
                if (m_stopped)
                {
                    Report("WARNING: Test halted by User. Total Time = {0}ms.", GetElapsedTime(globalStart));
                }
                else
                {
                    Report("{0} tests completed successfully. Total Time = {1}ms.", thisTestTotalCount, GetElapsedTime(globalStart));
                    SavePerfData(m_defaultEndpoint, GetElapsedTime(globalStart));
                }
            }
            else
            {
                Report("WARNING: {0} tests failed. {1} tests run. Total Time = {2}ms.", thisTestFailedCount, thisTestTotalCount, GetElapsedTime(globalStart));
            }
        }
        
        /// <summary>
        /// Reads the endpoints for a server.
        /// </summary>
        private ConfiguredEndpointCollection GetEndpoints(ConfiguredEndpoint endpoint)
        {
            // some protocols will require a seperate endpoint for the discovery endpoints.
            List<Uri> urlsToTry = new List<Uri>();

            foreach (string discoveryUrl in endpoint.Description.Server.DiscoveryUrls)
            {
                urlsToTry.Add(new Uri(discoveryUrl));
            }

            urlsToTry.Add(endpoint.EndpointUrl);

            // servers that do not support using the same endpoint for discovery and sessions should
            // use the convention where the discovery endpoint is constructed by appending "/discovery";
            if (endpoint.EndpointUrl.Scheme != Utils.UriSchemeOpcTcp)
            {
                urlsToTry.Add(new Uri(endpoint.EndpointUrl.ToString() + "/discovery"));
            }

            for (int ii = 0; ii < urlsToTry.Count; ii++)
            {
                // the discovery client provides a programmer's interace to a discovery server.
                DiscoveryClient client = DiscoveryClient.Create(urlsToTry[ii], m_bindingFactory, null);

                try
                {
                    // fetch the endpoints from the server.
                    EndpointDescriptionCollection endpoints = client.GetEndpoints(null);

                    // add endpoints to cache.
                    ConfiguredEndpointCollection endpointCache = new ConfiguredEndpointCollection();

                    foreach (EndpointDescription description in endpoints)
                    {
                        endpointCache.Add(description, endpoint.Configuration);
                    }

                    return endpointCache;
                }
                catch (Exception)
                {                    
                    Report("No discovery endpoint found at: {0}", urlsToTry[ii]);
                }
                finally
                {
                    // must always close the channel to free resources.
                    client.Close();
                }
            }
             
            // nothing found.
            throw ServiceResultException.Create(
                StatusCodes.BadUnexpectedError, 
                "Could not find discovery endpoint for server at: {0}", 
                endpoint);
        }

        #region CreateSession and GetEndpoints
        /// <summary>
        /// Creates a session.
        /// </summary>
        private Session CreateSession(
            ApplicationConfiguration configuration, 
            BindingFactory           bindingFactory,
            ConfiguredEndpoint       endpoint,
            IUserIdentity            identity)
        {
            Report("Creating new Session with URL = {0}", endpoint.EndpointUrl);

            // Initialize the channel which will be created with the server.
            ITransportChannel channel = SessionChannel.Create(
                configuration,
                endpoint.Description,
                endpoint.Configuration,
                configuration.SecurityConfiguration.ApplicationCertificate.Find(true),
                configuration.CreateMessageContext());

            // Wrap the channel with the session object.
            Session session = new Session(channel, configuration, endpoint, null);
            session.ReturnDiagnostics = DiagnosticsMasks.All;
            
            // register keep alive callback.
            session.KeepAlive += new KeepAliveEventHandler(Session_KeepAlive);
            
            // create the user identity.            
            if (identity == null)
            {
                if (endpoint.Description.UserIdentityTokens.Count > 0)
                {
                    identity = CreateUserIdentity(endpoint.Description.UserIdentityTokens[0]);
                }
            }

            // Create the session. This actually connects to the server.
            session.Open(Guid.NewGuid().ToString(), identity);

            Report("Successfully created new Session.");

            // return the session.
            return session;
        }
        
        /// <summary>
        /// Creates a user identity for the policy.
        /// </summary>
        private IUserIdentity CreateUserIdentity(UserTokenPolicy policy)
        {
            if (policy == null || policy.TokenType == UserTokenType.Anonymous)
            {
                return null;
            }

            if (policy.TokenType == UserTokenType.UserName)
            {
                return new UserIdentity("SomeUser", "password");
            }

            if (policy.TokenType == UserTokenType.Certificate)
            {
                X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine);

                store.Open(OpenFlags.OpenExistingOnly | OpenFlags.ReadOnly);

                try
                {
                    foreach (X509Certificate2 certificate in store.Certificates)
                    {
                        if (certificate.HasPrivateKey)
                        {
                            return new UserIdentity(certificate);
                        }
                    }
                    
                    return null;
                }
                finally
                {
                    store.Close();
                }
            }

            if (policy.TokenType == UserTokenType.IssuedToken)
            {
                CertificateIdentifier userid = new CertificateIdentifier();

                userid.StoreType   = CertificateStoreType.Windows;
                userid.StorePath   = "LocalMachine\\Root";
                userid.SubjectName = "UASampleRoot";

                X509Certificate2 certificate = userid.Find();
                X509SecurityToken signingToken = new X509SecurityToken(certificate);

                SamlSecurityToken token = CreateSAMLToken("someone@somewhere.com", signingToken);
                          
                return new UserIdentity(token);            
            }

            throw ServiceResultException.Create(StatusCodes.BadSecurityPolicyRejected, "User token policy is not supported.");
        }
        
        /// <summary>
        /// Creates a SAML token for the specified email address and security token.
        /// </summary>
        private SamlSecurityToken CreateSAMLToken(
            string            emailAddress,
            X509SecurityToken issuerToken)
        {            
            // Create list of confirmation strings
            List<string> confirmations = new List<string>();

            // Add holder-of-key string to list of confirmation strings
            confirmations.Add("urn:oasis:names:tc:SAML:1.0:cm:bearer");

            // Create SAML subject statement based on issuer member variable, confirmation string collection 
            // local variable and proof key identifier parameter
            SamlSubject subject = new SamlSubject("urn:oasis:names:tc:SAML:1.1:nameid-format:emailAddress", null, emailAddress);

            // Create a list of SAML attributes
            List<SamlAttribute> attributes = new List<SamlAttribute>();
            Claim claim = Claim.CreateNameClaim(emailAddress);            
            attributes.Add(new SamlAttribute(claim));

            // Create list of SAML statements
            List<SamlStatement> statements = new List<SamlStatement>();

            // Add a SAML attribute statement to the list of statements. Attribute statement is based on 
            // subject statement and SAML attributes resulting from claims
            statements.Add(new SamlAttributeStatement(subject, attributes));

            // Create a valid from/until condition
            DateTime validFrom = DateTime.UtcNow;
            DateTime validTo = DateTime.UtcNow.AddHours(12);

            SamlConditions conditions = new SamlConditions(validFrom, validTo);
            
            // Create the SAML assertion
            SamlAssertion assertion = new SamlAssertion(
                "_" + Guid.NewGuid().ToString(),
                issuerToken.Certificate.Subject,
                validFrom, 
                conditions, 
                null,
                statements);

            SecurityKey signingKey = new System.IdentityModel.Tokens.RsaSecurityKey((RSA)issuerToken.Certificate.PrivateKey);

            // Set the signing credentials for the SAML assertion
            assertion.SigningCredentials = new SigningCredentials(
                signingKey, 
                System.IdentityModel.Tokens.SecurityAlgorithms.RsaSha1Signature,
                System.IdentityModel.Tokens.SecurityAlgorithms.Sha1Digest,
                new SecurityKeyIdentifier(issuerToken.CreateKeyIdentifierClause<X509ThumbprintKeyIdentifierClause>()));

            return new SamlSecurityToken(assertion);
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Returns the a session to re-use for different tests.
        /// </summary>
        private Session GetDefaultSession()
        {
            if (m_session == null)
            {
                DateTime start = DateTime.UtcNow;                    
                m_session = CreateSession(m_configuration, m_bindingFactory, m_defaultEndpoint, null);
                
                if ((DateTime.UtcNow - start).TotalSeconds > 10)
                {
                    Report("WARNING: Unexpected delay creating a Session (maybe do to WCF DNS lookup problem). Delay={0}s", (DateTime.UtcNow - start).TotalSeconds);
                
                }

                // fetch the reference type tree.
                m_session.FetchTypeTree(ReferenceTypeIds.References);
                Report("Fetched the known ReferenceTypes from the Server");

                // fetch the data type tree.
                m_session.FetchTypeTree(DataTypeIds.BaseDataType);
                Report("Fetched the known DataTypes from the Server");
            }

            return m_session;
        }

        
        /// <summary>
        /// Formats a header block in the log file.
        /// </summary>
        private void ReportWithHeader(string format, params object[] args)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("========== ");
            builder.AppendFormat(format, args);
            builder.Append(" ==========");

            while (builder.Length < 80)
            {
                builder.Append('=');
            }

            Report(builder.ToString(), null);
        }

        /// <summary>
        /// Used to log errors during a test run.
        /// </summary>
        private void Report(TestBase test, string format, params object[] args)
        {
            Report(format, args);
        }

        /// <summary>
        /// Used to log errors during a test run.
        /// </summary>
        private void Report(TestBase test, double current, double final)
        {
            Report(current, final);
        }

        /// <summary>
        /// Reports an exception encountered during a test.
        /// </summary>
        private void Report(
            Exception        e,
            string           format,
            params object[]  args)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("EXCEPTION: ");

            if (args != null)
            {
                builder.AppendFormat(format, args);
            }
            else
            {
                builder.Append(format);
            }
            
            ServiceResultException sre = e as ServiceResultException;

            if (sre != null)
            {
                builder.AppendFormat(" StatusCode = {0}", (StatusCode)sre.StatusCode);
            }

            builder.AppendFormat(" Message = {0}", e.Message);

            Report(builder.ToString(), null);
        }

        /// <summary>
        /// Reports the result of a test.
        /// </summary>
        private void Report(
            string           format,
            params object[]  args)
        {
            if (m_ReportTestResult != null)
            {
                ReportResultEventArgs e = new ReportResultEventArgs(m_testcase, format, args);
 
                m_ReportTestResult(this, e);
                
                if (e.Stop)
                {
                    m_stopped = e.Stop;
                }
            }
        }

        /// <summary>
        /// Reports the progress for a test.
        /// </summary>
        private void Report(double current, double final)
        {
            if (m_ReportTestProgress != null)
            {
                ReportProgressEventArgs e = new ReportProgressEventArgs(
                    m_defaultEndpoint, 
                    m_testcase, 
                    m_testCount,
                    m_failedTestCount,
                    m_endpointCount,
                    m_totalEndpointCount,
                    m_iterationCount,
                    m_totalIterationCount, 
                    current,
                    final,
                    false);
 
                m_ReportTestProgress(this, e);
                
                if (e.Stop)
                {
                    m_stopped = e.Stop;
                    throw new ServiceResultException(StatusCodes.BadInvalidState);
                }
            }
        }

        /// <summary>
        /// Reports a breakpoint for a test.
        /// </summary>
        private void ReportBreakpoint()
        {
            if (m_ReportTestProgress != null)
            {
                ReportProgressEventArgs e = new ReportProgressEventArgs(
                    m_defaultEndpoint, 
                    m_testcase, 
                    m_testCount,
                    m_failedTestCount,
                    m_endpointCount,
                    m_totalEndpointCount,
                    m_iterationCount,
                    m_totalIterationCount, 
                    0,
                    0,
                    true);
 
                m_ReportTestProgress(this, e);
                
                if (e.Stop)
                {
                    m_stopped = e.Stop;
                }
            }
        }

        /// <summary>
        /// Raised when a keep alive response is returned from the server.
        /// </summary>
        private void Session_KeepAlive(Session session, KeepAliveEventArgs e)
        {
            if (ServiceResult.IsBad(e.Status))
            {
                Report("KEEP ALIVE LATE: {0}", e.Status);
            }
        }
        #endregion

        /// <summary>
        /// Stores the performance data for a test run.
        /// </summary>
        private class PerfData
        {
            public string Transport;
            public string SecurityMode;
            public string SecurityPolicy;
            public string Encoding;
            public double ElaspsedTime;
        }

        /// <summary>
        /// Saves the performance data for a test run.
        /// </summary>
        private void SavePerfData(ConfiguredEndpoint endpoint, double elaspedTime)
        {
            PerfData data = new PerfData();

            data.Transport = endpoint.EndpointUrl.Scheme;
            data.SecurityMode = endpoint.Description.SecurityMode.ToString();
            data.SecurityPolicy = SecurityPolicies.GetDisplayName(endpoint.Description.SecurityPolicyUri);
            data.Encoding = (endpoint.Configuration.UseBinaryEncoding)?"Binary":"XML";
            data.ElaspsedTime = elaspedTime;

            m_performanceData.Add(data);
        }
        
        /// <summary>
        /// Dumps the performance data for a test run.
        /// </summary>
        private void DumpPerfData()
        {
            Dictionary<string,Dictionary<string,double>> table = new Dictionary<string,Dictionary<string,double>>();

            for (int ii = 0; ii < m_performanceData.Count; ii++)
            {
                PerfData data = m_performanceData[ii];
                IndexPerfData(data, table, data.Transport, data.SecurityMode, data.SecurityPolicy, data.Encoding);
            }

            DumpTable(table, "Transport");

            table.Clear();
            
            for (int ii = 0; ii < m_performanceData.Count; ii++)
            {
                PerfData data = m_performanceData[ii];
                IndexPerfData(data, table, data.SecurityMode, data.Transport, data.SecurityPolicy, data.Encoding);
            }

            DumpTable(table, "SecurityMode");

            table.Clear();
            
            for (int ii = 0; ii < m_performanceData.Count; ii++)
            {
                PerfData data = m_performanceData[ii];
                IndexPerfData(data, table, data.SecurityPolicy, data.Transport, data.SecurityMode, data.Encoding);
            }

            DumpTable(table, "SecurityPolicy");

            table.Clear();
            
            for (int ii = 0; ii < m_performanceData.Count; ii++)
            {
                PerfData data = m_performanceData[ii];
                IndexPerfData(data, table, data.Encoding, data.Transport, data.SecurityMode, data.SecurityPolicy);
            }

            DumpTable(table, "Encoding");
        }

        /// <summary>
        /// Dumps a table of results.
        /// </summary>
        private void DumpTable(
            Dictionary<string,Dictionary<string,double>> table,
            string name)
        {
            List<string> columns = new List<string>();

            foreach (Dictionary<string,double> row in table.Values)
            {                
                foreach (string column in row.Keys)
                {        
                    if (!columns.Contains(column))
                    {
                        columns.Add(column);
                    }
                }
            }

            StringBuilder builder = new StringBuilder();
            builder.Append(name);

            for (int ii = 0; ii < columns.Count; ii++)
            {
                builder.AppendFormat(", {0}", columns[ii]);
            }
            
            builder.Append("\r\n");

            foreach (KeyValuePair<string,Dictionary<string,double>> row in table)
            {                
                builder.Append(row.Key);

                for (int ii = 0; ii < columns.Count; ii++)
                {
                    double elaspedTime;

                    if (!row.Value.TryGetValue(columns[ii], out elaspedTime))
                    {
                        elaspedTime = -1;

                        // look up alternate for security none.
                        if (row.Key == "None")
                        {
                            string[] entries = columns[ii].Split(new char[] {'/'}, StringSplitOptions.RemoveEmptyEntries);
                            
                            string column = entries[0];
                            column += "/None/";
                            column += entries[2];
                            
                            if (!row.Value.TryGetValue(column, out elaspedTime))
                            {
                                elaspedTime = -1;
                            }
                        }

                        // look up alternate for opc.tcp and XML
                        else if (row.Key == "opc.tcp")
                        {
                            string[] entries = columns[ii].Split(new char[] {'/'}, StringSplitOptions.RemoveEmptyEntries);
                            
                            string column = entries[0];
                            column += "/";
                            column += entries[1];
                            column += "/Binary";
                            
                            if (!row.Value.TryGetValue(column, out elaspedTime))
                            {
                                elaspedTime = -1;
                            }
                        }
                    }
                    
                    builder.AppendFormat(", {0}", elaspedTime);
                }
                    
                builder.Append("\r\n");
            }

            Report(builder.ToString(), null);
        }
        
        /// <summary>
        /// Indexes the performance data.
        /// </summary>
        private void IndexPerfData(
            PerfData data,
            Dictionary<string,Dictionary<string,double>> table,
            string primaryKey,
            params string[] secondaryKeys)
        {
            Dictionary<string,double> results = null;

            if (!table.TryGetValue(primaryKey, out results))
            {
                table[primaryKey] = results = new Dictionary<string,double>();
            }

            string secondaryKey = Utils.Format("{0}/{1}/{2}", secondaryKeys);  
            results[secondaryKey] = data.ElaspsedTime;
        }

        #region Private Fields
        private ConfiguredEndpoint m_defaultEndpoint;
        private ConfiguredEndpointCollection m_endpoints;
        private ApplicationConfiguration m_configuration;
        private ServerTestConfiguration m_testConfiguration;
        private ServiceMessageContext m_messageContext;
        private BindingFactory m_bindingFactory;
        private ServerTestCase m_testcase;     
        private int m_testCount;
        private int m_failedTestCount;
        private int m_endpointCount;
        private int m_totalEndpointCount;
        private int m_iterationCount;
        private int m_totalIterationCount;
        private Session m_session;
        private event EventHandler<ReportResultEventArgs> m_ReportTestResult;
        private event EventHandler<ReportProgressEventArgs> m_ReportTestProgress;
        private ManualResetEvent m_breakpoint;
        private bool m_stopped;
        private List<PerfData> m_performanceData;
        #endregion
    }
}
