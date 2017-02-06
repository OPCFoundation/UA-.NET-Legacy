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
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.ServiceModel.Channels;
using System.Threading;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

using Opc.Ua.Client;
using Opc.Ua.StackTest;

namespace Opc.Ua.StackTest
{
    #region TestClient Class
    /// <summary>
    /// A class executes the tests on the client side.
    /// </summary>
    public partial class TestClient : IStackEventSink 
    {
        #region Constructors
        /// <summary>
        /// This constructor loads the configuration.
        /// </summary>
        /// <remarks> It loads Client configuration, test configuration and 
        /// initializes contexts for vendor namespaces. </remarks>
        public TestClient(ApplicationConfiguration configuration)
        {
            m_configuration = configuration;
            LoadTestConfiguration(null);
            m_messageContext = Compare.MessageContext = m_configuration.CreateMessageContext();
            TestUtils.InitializeContexts(m_messageContext);
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// This method returns the configuration for the client application.
        /// </summary>
        public ApplicationConfiguration Configuration
        {
            get { return m_configuration; }
        }

        /// <summary>
        /// This method returns the path to the test configuration file that the client uses.
        /// </summary>
        public string TestFilePath
        {
            get { return m_testFilePath; }
        }

        /// <summary>
        /// The test sequence, which the client must execute.
        /// </summary>
        public TestSequence SequenceToExecute
        {
            get { return m_sequenceToExecute; }
            set { m_sequenceToExecute = value; }
        }

        /// <summary>
        /// Whether a quick test should be done.
        /// </summary>
        public bool QuickTest
        {
            get { return m_quickTest; }
            set { m_quickTest = value; }
        }

        /// <summary>
        /// This event notifies the client about the details of the running test..
        /// </summary>
        public event TestSequenceEventHandler TestSequenceEvent
        {
            add
            {
                lock (m_lock)
                {
                    m_TestSequenceEvent += value;
                }
            }

            remove
            {
                lock (m_lock)
                {
                    m_TestSequenceEvent -= value; ;
                }
            }
        }

        /// <summary>
        /// This event notifies the client to cancel a running test.
        /// </summary>
        public bool Cancel
        {
            get
            {
                return m_cancel;
            }

            set
            {
                m_cancel = value;
            }
        }

        /// <summary>
        /// This event notifies the client that application is logging the test event.
        /// </summary>
        public event TestLogEventHandler TestLogEventHandler
        {
            add
            {
                lock (m_lock)
                {
                    m_testLogEventHandler += value;
                }
            }

            remove
            {
                lock (m_lock)
                {
                    m_testLogEventHandler -= value;
                }
            }
        }

        /// <summary>
        /// This method loads the test configuration from the specified file path.
        /// </summary>
        /// <param name="testFilePath">Test case file path.</param>
        public void LoadTestConfiguration(string testFilePath)
        {
            // (re)load the test configuration file.
            TestConfiguration configuration = TestConfiguration.Load("Opc.Ua.StackTest");

            m_testFilePath = configuration.TestFilePath;

            if (!String.IsNullOrEmpty(testFilePath))
            {
                m_testFilePath = testFilePath;
            }

            // load sequence to execute.
            m_sequenceToExecute = TestSequence.Load(m_testFilePath);

            m_randomFilePath = configuration.RandomFilePath;

            // TODO: How to handle multiple channels. Where will all those channels write to same log.
            m_logFilePath = configuration.LogFilePath;
        }

        /// <summary>
        /// This method executes the test cases for the configured endpoint.
        /// This method is called from the main form, when connect command is executed.
        /// </summary>
        /// <param name="endpoint">This parameter stores an endpoint of the server.</param>
        public void BeginExecuteTestSequence(ConfiguredEndpoint endpoint)
        {
            m_operationTimeout = endpoint.Configuration.OperationTimeout;
            ThreadPool.QueueUserWorkItem(new WaitCallback(ExecuteTestSequence), new object[] { endpoint });
        }

        /// <summary>
        /// Starts executing the direct serializer tests (i.e. tests that do not go over the network).
        /// </summary>
        public void BeginExecuteSerializerDirect()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(ExecuteSerializerDirectTests), null);
        }

        /// <summary>
        /// This method executes the test cases in the sequence configured in the test case file.
        /// </summary>
        /// <param name="state">An object value that stores configured endpoint value.</param>
        private void ExecuteTestSequence(object state)
        {
            try
            {
                ExecuteTestSequence(((ConfiguredEndpoint)((object[])state)[0]));
            }
            catch (Exception e)
            {
                RaiseEvent(new TestSequenceEventArgs(e));
            }
        }

        /// <summary>
        /// This method executes the test cases for the configured endpoint.
        /// In case of multiple channel test cases, this endpoint value is ignored and new
        /// endpoint is used to connect to the server specified in test configuration.
        /// </summary>
        /// <param name="endpoint">This parameter stores an endpoint of the server.</param>
        public void ExecuteTestSequence(ConfiguredEndpoint endpoint)
        {
            lock (m_lock)
            {
                m_cancel = false;
            }

            if (endpoint.UpdateBeforeConnect)
            {
                // create the binding factory if it has not been created yet.
                if (m_bindingFactory == null)
                {
                    m_bindingFactory = BindingFactory.Create(m_configuration, m_messageContext);
                }

                endpoint.UpdateFromServer(m_bindingFactory);
            }

            ChannelContext selectedChannelContext = null;

            selectedChannelContext = InitializeChannel(endpoint, m_logFilePath);

            try
            {
                foreach (TestCase testCase in m_sequenceToExecute.TestCase)
                {
                    if (testCase.SkipTest || testCase.Name.StartsWith(TestCases.SerializerDirect))
                    {
                        continue;
                    }
                    
                    try
                    {
                        TestUtils.ValidateTestCase(testCase, (int)testCase.Start);
                    }
                    catch (Exception e)
                    {
                        selectedChannelContext.EventLogger.LogErrorEvent(testCase, (int)testCase.Start, e);

                        if (m_sequenceToExecute.HaltOnError)
                        {
                            throw;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    TestCaseContext testCaseContext = TestUtils.GetExecutionContext(testCase);

                    try
                    {
                        ValidateTestContext(testCaseContext, testCase);
                    }
                    catch (Exception e)
                    {
                        selectedChannelContext.EventLogger.LogErrorEvent(testCase, (int)testCase.Start, e);

                        if (m_sequenceToExecute.HaltOnError)
                        {
                            throw;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    if (testCase.Name != TestCases.MultipleChannels)
                    {
                        ExecuteTestCase(selectedChannelContext, testCaseContext, testCase);
                    }
                    else
                    {
                        Uri defaultUrl = new Uri(endpoint.Description.EndpointUrl);

                        // In case of multiple channel get endpoint urls from the test case file.
                        List<ChannelContext> channelContextList = new List<ChannelContext>();
                        List<ConfiguredEndpoint> configuredEndpointList = new List<ConfiguredEndpoint>();
                        for (int serverCnt = 0; serverCnt < testCaseContext.ServerDetails.Count; serverCnt++)
                        {
                            string serverURL = testCaseContext.ServerDetails[serverCnt].Url;
                            serverURL = serverURL.Replace("localhost", defaultUrl.DnsSafeHost);

                            //ConfiguredEndpointCollection endpointCollection = new ConfiguredEndpointCollection () ;
                            //ConfiguredEndpoint serverendpoint = endpointCollection.Create(serverURL);
                            ConfiguredEndpoint serverendpoint = (ConfiguredEndpoint)endpoint.Clone();

                            // slow systems may not be able to renew tokens fast enough when overloaded with channels.
                            serverendpoint.Configuration.SecurityTokenLifetime = 60000;

                            serverendpoint.Description.EndpointUrl = serverURL;
                            configuredEndpointList.Add(serverendpoint);

                            //For each channel get the log file name as <default file name>_<server name>_<channel index>.
                            for (int channelCnt = 0; channelCnt < testCaseContext.ChannelsPerServer; channelCnt++)
                            {
                                string logFileSuffix = "_" + testCaseContext.ServerDetails[serverCnt].Name + "_" + channelCnt.ToString();
                                string logFileName = m_logFilePath.Replace(".xml", logFileSuffix) + ".xml";

                                ChannelContext channelContext = InitializeChannel(configuredEndpointList[serverCnt],
                                logFileName);
                                channelContextList.Add(channelContext);
                            }
                        }

                        try
                        {
                            WaitHandle[] waitHandles = new WaitHandle[channelContextList.Count];

                            for (int iCtr = 0; iCtr < channelContextList.Count; iCtr++)
                            {
                                waitHandles[iCtr] = channelContextList[iCtr].TestCaseComplete;
                                ThreadPool.QueueUserWorkItem(ExecuteTestCase, new object[] { channelContextList[iCtr], testCaseContext, testCase });
                            }

                            WaitHandle.WaitAll(waitHandles);
                        }
                        finally
                        {
                            for (int iCtr = 0; iCtr < channelContextList.Count; iCtr++)
                            {
                                WindupChannel(channelContextList[iCtr]);
                            }
                        }
                    }
                }
            }
            finally
            {
                WindupChannel(selectedChannelContext);
            }

            RaiseEvent(new TestSequenceEventArgs(0, "Done", 0));
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// Executes the direct serializer tests.
        /// </summary>
        private void ExecuteSerializerDirectTests(object state)
        {
            try
            {
                foreach (TestCase testCase in m_sequenceToExecute.TestCase)
                {
                    if (testCase.SkipTest)
                    {
                        continue;
                    }

                    // ExecuteTest_SerializerDirect(testCase);
                }

                RaiseEvent(new TestSequenceEventArgs(0, "Done", 0));
            }
            catch (Exception e)
            {
                RaiseEvent(new TestSequenceEventArgs(e));
            }
        }

        /// <summary>
        /// This method executes the test case.
        /// </summary>
        /// <param name="state">Object value, which stores ChannelContext, TestCase and TestCaseContext value.</param>
        private void ExecuteTestCase(object state)
        {
            try
            {
                ExecuteTestCase(((ChannelContext)((object[])state)[0]), ((TestCaseContext)((object[])state)[1]), ((TestCase)((object[])state)[2]));
            }
            catch (Exception e)
            {
                RaiseEvent(new TestSequenceEventArgs(e));
            }
        }
        /// <summary>
        /// This method executes the test case.
        /// </summary>
        /// <param name="channelContext">This parameter stores the channel related data.</param>
        /// <param name="testCaseContext">This parameter stores the test case parameter values.</param>
        /// <param name="testCase">This parameter stores the test case related data.</param>
        private void ExecuteTestCase(ChannelContext channelContext, TestCaseContext testCaseContext, TestCase testCase)
        {
            try
            {
                channelContext.TestCaseComplete.Reset();
                channelContext.AsyncTestsComplete.Set();

                lock (m_lock)
                {
                    if (m_cancel)
                    {
                        return;
                    }
                }

                try
                {
                    channelContext.EventLogger.LogStartEvent(testCase, TestCases.TestSetupIteration);
                    ExecuteTest(channelContext, testCaseContext, testCase, TestCases.TestSetupIteration);
                }
                catch (Exception e)
                {
                    channelContext.EventLogger.LogErrorEvent(testCase, TestCases.TestSetupIteration, e);

                    if (m_sequenceToExecute.HaltOnError)
                    {
                        throw;
                    }
                    else
                    {
                        return;
                    }
                }


                // start the test at the iteration specified in the test case.
                for (int ii = (int)testCase.Start; ii < testCase.Count; ii++)
                {
                    lock (m_lock)
                    {                        
                        if (m_cancel)
                        {
                            break;
                        }

                        if (m_quickTest && ii > 10)
                        {
                            break;
                        }

                        RaiseEvent(new TestSequenceEventArgs(testCase.TestId, testCase.Name, ii));
                    }

                    try
                    {
                        ExecuteTest(channelContext, testCaseContext, testCase, ii);
                    }
                    catch (Exception e)
                    {
                        channelContext.EventLogger.LogErrorEvent(testCase, ii, e);

                        if (m_sequenceToExecute.HaltOnError)
                        {
                            throw;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                try
                {
                    // Wait till any of the pending test cases to finish before closing the logger
                    channelContext.AsyncTestsComplete.WaitOne();

                    ExecuteTest(channelContext, testCaseContext, testCase, TestCases.TestCleanupIteration);
                    channelContext.EventLogger.LogCompleteEvent(testCase, TestCases.TestCleanupIteration);
                }
                catch (Exception e)
                {
                    channelContext.EventLogger.LogErrorEvent(testCase, TestCases.TestCleanupIteration, e);

                    if (m_sequenceToExecute.HaltOnError)
                    {
                        throw;
                    }
                    else
                    {
                        return;
                    }
                }
            }
            finally
            {
                channelContext.TestCaseComplete.Set();
            }
        }

        /// <summary>
        /// Validates the test execution context and checks if the test parameters are with in the allowed range
        /// </summary>
        /// <param name="testCase">This parameter stores the test case related data.</param>
        /// <param name="testCaseContext">This parameter stores the test case parameter values.</param>
        private void ValidateTestContext(TestCaseContext testCaseContext, TestCase testCase)
        {
            switch (testCase.Name)
            {
                case TestCases.ServerTimeout:
                {
                    if (testCaseContext.MinTimeout >= testCaseContext.MaxTimeout)
                    {
                        throw new Exception("The test parameter MinTimeout should be less than  test parameter MaxTimeout");
                    }

                    break;
                }

                case TestCases.AutoReconnect:
                {
                    break;
                }

                default:
                {
                    return;
                }
            }
        }

        /// <summary>
        /// This method executes a test.  
        /// </summary>
        /// <param name="channelContext">This parameter stores the channel related data.</param>
        /// <param name="testCaseContext">This parameter stores the test case parameter values.</param>
        /// <param name="testCase">This parameter stores the test case related data.</param>
        /// <param name="iteration">This parameter stores the current iteration number.</param>
        private void ExecuteTest(ChannelContext channelContext, TestCaseContext testCaseContext, TestCase testCase, int iteration)
        {
            switch (testCase.Name)
            {
                #region Serialization Tests
                case TestCases.ScalarValues:
                {
                    ExecuteTest_ScalarValues(channelContext, testCaseContext, testCase, iteration);
                    break;
                }

                case TestCases.ArrayValues:
                {
                    ExecuteTest_ArrayValues(channelContext, testCaseContext, testCase, iteration);
                    break;
                }

                case TestCases.ExtensionObjectValues:
                {
                    ExecuteTest_ExtensionObjectValues(channelContext, testCaseContext, testCase, iteration);
                    break;
                }

                case TestCases.BuiltInTypes:
                {
                    ExecuteTest_BuiltInTypes(channelContext, testCaseContext, testCase, iteration);
                    break;
                }

                case TestCases.LargeMessages:
                {
                    ExecuteTest_LargeMessages(channelContext, testCaseContext, testCase, iteration);
                    break;
                }
                #endregion

                #region Protocol Tests
                case TestCases.MultipleChannels:
                {
                    ExecuteTest_MultipleChannels(channelContext, testCaseContext, testCase, iteration);
                    break;
                }

                case TestCases.AutoReconnect:
                {
                    ExecuteTest_AutoReconnect(channelContext, testCaseContext, testCase, iteration);
                    break;
                }

                #endregion

                #region Fault Tests
                case TestCases.ServerFault:
                {
                    ExecuteTest_ServerFault(channelContext, testCaseContext, testCase, iteration);
                    break;
                }

                case TestCases.ServerTimeout:
                {
                    ExecuteTest_ServerTimout(channelContext, testCaseContext, testCase, iteration);
                    break;
                }
                #endregion

                default:
                {
                    throw ServiceResultException.Create(StatusCodes.BadConfigurationError, "Unsupported test case : " + testCase.Name);
                }
            }
        }

        /// <summary>
        /// Connects to an endpoint of a server and returns its channel context
        /// </summary>
        /// <param name="endpoint">This parameter stores an endpoint of the server.</param>
        /// <param name="logFileName">File name for logging.</param>
        /// <returns>This object will contain the channel related information.</returns>
        private ChannelContext InitializeChannel(ConfiguredEndpoint endpoint, string logFileName)
        {
            ChannelContext channelContext = new ChannelContext();

            channelContext.PendingAsycnTests = 0;

            channelContext.AsyncTestsComplete = new AutoResetEvent(false);

            channelContext.TestCaseComplete = new AutoResetEvent(false);

            // load random number file.
            channelContext.Random = new PseudoRandom(m_randomFilePath);

            // create the proxy.
            channelContext.Channel = SessionChannel.Create(
                Configuration,
                endpoint.Description,
                endpoint.Configuration,
                m_configuration.SecurityConfiguration.ApplicationCertificate.Find(true),
                m_messageContext);

            channelContext.MessageContext = m_messageContext;
            channelContext.EndpointDescription = endpoint.Description;

            // wrap the channel.
            channelContext.ClientSession = new SessionClient(channelContext.Channel);
            
            // open log file.
            channelContext.EventLogger = new Logger(logFileName, (TestLogDetailMasks)m_sequenceToExecute.LogDetailLevel);

            channelContext.EventLogger.Open(String.Empty, m_testFilePath, channelContext.Random.FilePath);

            if (m_testLogEventHandler != null)
            {
                channelContext.EventLogger.TestLogEvent += m_testLogEventHandler;
            }

            return channelContext;
        }


        /// <summary>
        /// Winds up a channel
        /// </summary>
        /// <param name="channelContext">Channel related data.</param>
        private void WindupChannel(ChannelContext channelContext)
        {
            if (m_testLogEventHandler != null)
            {
                channelContext.EventLogger.TestLogEvent -= m_testLogEventHandler;
            }

            channelContext.EventLogger.Close();
            channelContext.EventLogger = null;

            channelContext.Channel.Close();
            channelContext.Channel = null;
        }

        /// <summary>
        /// Raises an event when something happens during testing.
        /// </summary>
        private void RaiseEvent(TestSequenceEventArgs args)
        {
            lock (m_lock)
            {
                if (m_TestSequenceEvent != null)
                {
                    m_TestSequenceEvent(this, args);
                }
            }
        }

        /// <summary>
        /// Queues an action.
        /// </summary>
        private void QueueStackAction(SessionClient session, StackAction action)
        {
            System.ServiceModel.ClientBase<ISessionChannel> channel = session.InnerChannel as System.ServiceModel.ClientBase<ISessionChannel>;

            if (channel != null)
            {
                IStackControl control = channel.InnerChannel.GetProperty<IStackControl>();

                if (control != null)
                {
                    control.QueueAction(action);
                }
            }
        }
        #endregion       

        #region Private Fields
        // The random numbers file path.       
        private string m_randomFilePath;

        // Client Configuration.        
        private ApplicationConfiguration m_configuration;

        // It stores test case sequences.
        private TestSequence m_sequenceToExecute;

        // Test File Path.       
        private string m_testFilePath;

        // Object used for locking.     
        private object m_lock = new object();

        // Object of type Opc.Ua.StackTest.TestSequenceEventHandler.       
        private event TestSequenceEventHandler m_TestSequenceEvent;

        // Default timeout period of the stack.     
        private int m_operationTimeout;

        // The delegate, which needs to be fired when a test event occurs.        
        private event TestLogEventHandler m_testLogEventHandler;

        // Binding factory for the channel.     
        private BindingFactory m_bindingFactory;

        // Binding factory for the channel.     
        private ServiceMessageContext m_messageContext;

        // Log file path.       
        private string m_logFilePath;

        // Flag used to abort the testing.                      
        private bool m_cancel;

        private bool m_quickTest;
        #endregion

        #region IStackEventSink Members
        /// <summary cref="IStackEventSink.CertificateRejected" />
        public void CertificateRejected(uint channelId, X509Certificate2 certificate)
        {
            Utils.Trace("Client Channel {0}: Rejected Certificate {1}", channelId, certificate.Subject);
        }
        
        /// <summary cref="IStackEventSink.MessageError" />
        public void MessageError(uint channelId, ServiceResult error)
        {
            Utils.Trace("Client Channel {0}: Error {1} {2}", channelId, error.SymbolicId, error.LocalizedText);
        }
        #endregion
    }
    #endregion
   
    #region TestSequenceEventArgs Class
    /// <summary>
    /// The event arguments provided when the state of a subscription changes.
    /// </summary>
    public class TestSequenceEventArgs : EventArgs
    {
        #region Constructors
        /// <summary>
        /// Creates a new instance.
        /// </summary>
        internal TestSequenceEventArgs(uint testId, string testCaseName, int iteration)
        {
            m_testId = testId;
            m_testCaseName = testCaseName;
            m_iteration = iteration;
        }

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        internal TestSequenceEventArgs(Exception e)
        {
            m_exception = e;
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// The current test id.
        /// </summary>
        public uint TestId
        {
            get
            {
                if (m_exception != null)
                {
                    throw new ServiceResultException(m_exception, StatusCodes.BadUnexpectedError);
                }

                return m_testId;
            }
        }

        /// <summary>
        /// The current test case name.
        /// </summary>
        public string TestCaseName
        {
            get
            {
                if (m_exception != null)
                {
                    throw new ServiceResultException(m_exception, StatusCodes.BadUnexpectedError);
                }

                return m_testCaseName;
            }
        }

        /// <summary>
        /// The current iteration
        /// </summary>
        public int Iteration
        {
            get
            {
                if (m_exception != null)
                {
                    throw new ServiceResultException(m_exception, StatusCodes.BadUnexpectedError);
                }

                return m_iteration;
            }
        }
        #endregion

        #region Private Fields
        // The current test id.        
        private uint m_testId;

        // The current test case name.       
        private string m_testCaseName;

        // The current iteration.       
        private int m_iteration;

        // The Exception.      
        private Exception m_exception;
        #endregion
    }

    /// <summary>
    /// The delegate used to receive test sequence event notifications.
    /// </summary>
    public delegate void TestSequenceEventHandler(TestClient client, TestSequenceEventArgs e);
    #endregion
}
