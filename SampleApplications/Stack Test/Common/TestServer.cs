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
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Reflection;
using System.Threading;
using System.ServiceModel;
using System.Xml;
using System.Xml.Serialization;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

using Opc.Ua.Server;

namespace Opc.Ua.StackTest
{
    /// <summary>
    /// A class executes the tests on the server side.
    /// </summary>
    public partial class TestServer : StandardServer, IStackEventSink 
    {
        /// <summary>
        /// Constructs a service instance with the specified identifier.
        /// </summary>
        /// <param name="serverId">A unique identfier for the server instance.</param>
        public TestServer(ushort serverId)
        {
            m_serverId = serverId;
        }

        /// <summary>
        /// This method loads the configuration for the test server.
        /// </summary>
        protected override void OnServerStarting(ApplicationConfiguration configuration)
        {
            base.OnServerStarting(configuration);

            LoadTestConfiguration(null);
            TestUtils.InitializeContexts(base.MessageContext);
        }

        /// <summary>
        /// This method loads the test configuration.
        /// </summary>
        /// <param name="testFilePath">Test case file path.</param>
        private void LoadTestConfiguration(string testFilePath)
        {
            // (re)load the test configuration file.
            m_configuration = TestConfiguration.Load("Opc.Ua.StackTest");

            if (!String.IsNullOrEmpty(testFilePath))
            {
                m_configuration.TestFilePath = testFilePath;
            }

            // incorporate the server id into the log file path.
            int index = m_configuration.LogFilePath.LastIndexOf('.');

            if (index != -1)
            {
                string path = m_configuration.LogFilePath;

                int subindex = path.LastIndexOf('_');

                if (subindex < 0)
                {
                    subindex = index;
                }

                m_configuration.LogFilePath = Utils.Format(
                    "{0}_{1}{2}",
                    path.Substring(0, subindex),
                    m_serverId,
                    path.Substring(index));
            }

            // load sequence to execute.
            m_sequenceToExecute = TestSequence.Load(m_configuration.TestFilePath);

            // load random number file.
            m_random = new PseudoRandom(m_configuration.RandomFilePath);

            // open log file.
            m_logger = new Logger(m_configuration.LogFilePath, (TestLogDetailMasks)m_sequenceToExecute.LogDetailLevel);

        }

        /// <summary>
        /// This method returns the compile time properties for the server.
        /// </summary>
        protected override ServerProperties LoadServerProperties()
        {
            ServerProperties properties = new ServerProperties();

            properties.DatatypeAssemblies.Add(Assembly.GetExecutingAssembly().FullName);

            return properties;
        }

        /// <summary>
        /// Used by the performance test.
        /// </summary>
        public override ResponseHeader Read(
            RequestHeader                requestHeader, 
            double                       maxAge, 
            TimestampsToReturn           timestampsToReturn, 
            ReadValueIdCollection        nodesToRead, 
            out DataValueCollection      values, 
            out DiagnosticInfoCollection diagnosticInfos)
        {
            if (requestHeader.ReturnDiagnostics != 5000)
            {
                return base.Read(requestHeader, maxAge, timestampsToReturn, nodesToRead, out values, out diagnosticInfos);
            }

            diagnosticInfos = null;

            DataValue value = new DataValue();
            
            value.WrappedValue    = new Variant((int)1);
            value.SourceTimestamp = DateTime.UtcNow;

            values = new DataValueCollection(nodesToRead.Count);

            foreach (ReadValueId valueId in nodesToRead)
            {
                values.Add(value);
            }
            
            return new ResponseHeader();
        }                    

        /// <summary>
        /// This method invokes the TestStack service.
        /// </summary>
        /// <param name="requestHeader">Request Header.</param>
        /// <param name="testId">Test Case Id.</param>
        /// <param name="iteration">This parameter stores the current iteration number.</param>
        /// <param name="input">Input Value.</param>
        /// <param name="output">Output Value.</param>
        /// <returns>Exception or Response based on the conditions.</returns>
        public override ResponseHeader TestStack(
            RequestHeader requestHeader,
            uint testId,
            int iteration,
            Variant input,
            out Variant output)
        {
            TestCase testCase = null;

            lock (m_lock)
            {
                if (!m_logger.IsOpened)
                {
                    m_logger.Open(SecureChannelContext.Current.SecureChannelId, m_configuration.TestFilePath, m_configuration.RandomFilePath);
                }

                if (iteration == TestCases.TestSetupIteration)
                {
                    Interlocked.Increment(ref m_activeTestCasesCount);
                }
            }

            try
            {
                testCase = ValidateTestCase(testId, iteration);
            }
            catch (Exception e)
            {
                m_logger.LogNotValidatedEvent(testId, iteration, e);
                throw;
            }

            try
            {
                try
                {
                    ValidateRequest(requestHeader);

                    TestCaseContext context = TestUtils.GetExecutionContext(testCase);

                    output = (Variant)ExecuteTest(context, testCase, iteration, input);

                    return CreateResponse(requestHeader, StatusCodes.Good);
                }
                catch (Exception e)
                {
                    if (testCase.Name == TestCases.ServerFault)
                    {
                        throw e;
                    }
                    else
                    {
                        m_logger.LogErrorEvent(testCase, iteration, e);
                        throw ServiceResultException.Create(StatusCodes.BadUnexpectedError, e, "Test {0}, Iteration {1} Failed.", testCase.Name, iteration);
                    }
                }
            }
            finally
            {
                lock (m_lock)
                {
                    if (iteration == TestCases.TestCleanupIteration)
                    {
                        Interlocked.Decrement(ref m_activeTestCasesCount);
                    }

                    if (iteration == TestCases.TestCleanupIteration && 
                        TestUtils.IsLastTestCase(m_sequenceToExecute, testCase) && 
                        m_activeTestCasesCount == 0 )
                    {
                        if (m_logger.IsOpened)
                        {
                            m_logger.Close();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// This method invokes the TestStackEx service.
        /// </summary>
        /// <param name="requestHeader">Request Header.</param>
        /// <param name="testId">Test Case Id.</param>
        /// <param name="iteration">This parameter stores the current iteration number.</param>
        /// <param name="input">Input Value.</param>
        /// <param name="output">Output Value.</param>
        /// <returns>Exception or Response based on the conditions.</returns>
        public override ResponseHeader TestStackEx(
            RequestHeader         requestHeader,
            uint                  testId,
            int                   iteration,
            CompositeTestType     input,
            out CompositeTestType output)
        {
            TestCase testCase = null;

            lock (m_lock)
            {
                if (!m_logger.IsOpened)
                {
                    m_logger.Open(SecureChannelContext.Current.SecureChannelId, m_configuration.TestFilePath, m_configuration.RandomFilePath);
                }

                if (iteration == TestCases.TestSetupIteration)
                {
                    Interlocked.Increment(ref m_activeTestCasesCount);
                }
            }

            try
            {
                testCase = ValidateTestCase(testId, iteration);
            }
            catch (Exception e)
            {
                m_logger.LogNotValidatedEvent(testId, iteration, e);
                throw;
            }

            try
            {
                try
                {
                    ValidateRequest(requestHeader);

                    TestCaseContext context = TestUtils.GetExecutionContext(testCase);

                    output = ExecuteTest(context, testCase, iteration, input);

                    return CreateResponse(requestHeader, StatusCodes.Good);
                }
                catch (Exception e)
                {
                    if (testCase.Name == TestCases.ServerFault)
                    {
                        throw e;
                    }
                    else
                    {
                        m_logger.LogErrorEvent(testCase, iteration, e);
                        throw ServiceResultException.Create(StatusCodes.BadUnexpectedError, e, "Test {0}, Iteration {1} Failed.", testCase.Name, iteration);
                    }
                }
            }
            finally
            {
                lock (m_lock)
                {
                    if (iteration == TestCases.TestCleanupIteration)
                    {
                        Interlocked.Decrement(ref m_activeTestCasesCount);
                    }

                    if (iteration == TestCases.TestCleanupIteration && 
                        TestUtils.IsLastTestCase(m_sequenceToExecute, testCase) && 
                        m_activeTestCasesCount == 0 )
                    {
                        if (m_logger.IsOpened)
                        {
                            m_logger.Close();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// This method returns the test case identified by the id.
        /// </summary>       
        /// <param name="testId">Test Case Id.</param>
        /// <param name="iteration">This parameter stores the current iteration number.</param>      
        /// <returns>Testcase or exception based on the conditions</returns>
        private TestCase ValidateTestCase(uint testId, int iteration)
        {
            foreach (TestCase testCase in m_sequenceToExecute.TestCase)
            {
                if (testCase.TestId == testId)
                {
                    try
                    {
                        TestUtils.ValidateTestCase(testCase, iteration);
                    }
                    catch (Exception e)
                    {
                        throw ServiceResultException.Create(StatusCodes.BadConfigurationError, e.Message);
                    }

                    return testCase;
                }
            }
            throw ServiceResultException.Create(StatusCodes.BadConfigurationError, "Cannot find test case.");
        }
        
        /// <summary>
        /// This method executes a test.
        /// </summary>
        /// <param name="testCaseContext">This parameter stores the test case parameter values.</param>
        /// <param name="testCase">This parameter stores the test case related data.</param>
        /// <param name="iteration">This parameter stores the current iteration number.</param>
        /// <param name="input">Input value.</param>
        /// <returns>Output value.</returns>
        private Variant ExecuteTest(TestCaseContext testCaseContext, TestCase testCase, int iteration, Variant input)
        {
            Variant output = Variant.Null;

            switch (testCase.Name)
            {
                #region Serialization Tests
                case TestCases.ScalarValues:
                    {
                        output = ExecuteTest_ScalarValues(testCaseContext, testCase, iteration, input);
                        break;
                    }
                case TestCases.ArrayValues:
                    {
                        output = ExecuteTest_ArrayValues(testCaseContext, testCase, iteration, input);
                        break;
                    }
                case TestCases.ExtensionObjectValues:
                    {
                        output = ExecuteTest_ExtensionObjectValues(testCaseContext, testCase, iteration, input);
                        break;
                    }
                case TestCases.LargeMessages:
                    {
                        output = ExecuteTest_LargeMessages(testCaseContext, testCase, iteration, input);
                        break;
                    }
                #endregion

                #region Protocol Tests
                case TestCases.MultipleChannels:
                {
                    output = ExecuteTest_MultipleChannels(testCaseContext, testCase, iteration, input);
                    break;
                }

                case TestCases.AutoReconnect:
                {
                    output = ExecuteTest_AutoReconnect(testCaseContext, testCase, iteration, input);
                    break;
                }
                #endregion

                #region Fault Tests
                case TestCases.ServerFault:
                    {
                        output = ExecuteTest_ServerFault(testCaseContext, testCase, iteration, input);
                        break;
                    }
                case TestCases.ServerTimeout:
                    {
                        output = ExecuteTest_ServerTimout(testCaseContext, testCase, iteration, input);
                        break;
                    }
                #endregion

                #region Performance
                #endregion

                default:
                {
                    throw ServiceResultException.Create(StatusCodes.BadConfigurationError, "Unsupported test case : " + testCase.Name);
                }
            }

            return output;
        }
        
        /// <summary>
        /// This method executes a test.
        /// </summary>
        /// <param name="testCaseContext">This parameter stores the test case parameter values.</param>
        /// <param name="testCase">This parameter stores the test case related data.</param>
        /// <param name="iteration">This parameter stores the current iteration number.</param>
        /// <param name="input">Input value.</param>
        /// <returns>Output value.</returns>
        private CompositeTestType ExecuteTest(TestCaseContext testCaseContext, TestCase testCase, int iteration, CompositeTestType input)
        {
            CompositeTestType output = null;

            switch (testCase.Name)
            {
                case TestCases.BuiltInTypes:
                {
                    output = ExecuteTest_BuiltInTypes(testCaseContext, testCase, iteration, input);
                    break;
                }

                default:
                {
                    throw ServiceResultException.Create(StatusCodes.BadConfigurationError, "Unsupported test case : " + testCase.Name);
                }
            }

            return output;
        }

        /// <summary>
        /// Queues an action.
        /// </summary>
        private void QueueStackAction(StackAction action)
        {
            System.ServiceModel.OperationContext context = System.ServiceModel.OperationContext.Current;

            if (context != null)
            {
                IStackControl control = context.Channel.GetProperty<IStackControl>();

                if (control != null)
                {
                    control.QueueAction(action);
                }
            }
        }

        /// <summary>
        /// Sets the event sink for the current channel.
        /// </summary>
        private void SetEventSink()
        {
            System.ServiceModel.OperationContext context = System.ServiceModel.OperationContext.Current;

            if (context != null)
            {
                IStackControl control = context.Channel.GetProperty<IStackControl>();

                if (control != null)
                {
                    control.SetEventSink(this);
                }
            }
        }

        /// <summary>
        /// Sets the event sink for the current channel.
        /// </summary>
        private void InterruptListener(int duration)
        {
            System.ServiceModel.OperationContext context = System.ServiceModel.OperationContext.Current;

            if (context != null)
            {
                IStackControl control = context.EndpointDispatcher.ChannelDispatcher.Listener.GetProperty<IStackControl>();

                if (control != null)
                {
                    StackAction action = new StackAction();
                    
                    action.ActionType = StackActionType.CloseListeningSocket;
                    action.Duration   = duration;

                    control.QueueAction(action);
                }
            }
        }

        #region IStackEventSink Members
        /// <summary cref="IStackEventSink.CertificateRejected" />
        public void CertificateRejected(uint channelId, X509Certificate2 certificate)
        {
            Utils.Trace("Server Channel {0}: Rejected Certificate {1}", channelId, certificate.Subject);
        }
        
        /// <summary cref="IStackEventSink.MessageError" />
        public void MessageError(uint channelId, ServiceResult error)
        {
            Utils.Trace("Server Channel {0}: Error {1} {2}", channelId, error.SymbolicId, error.LocalizedText);
        }
        #endregion
        
        #region Private Fields
        // Object used for locking.        
        private object m_lock = new object();
        
        // Object of type TestConfiguration.        
        private TestConfiguration m_configuration;
        
        // Stores test case sequences.        
        private TestSequence m_sequenceToExecute;
        
        // PseudoRandom class object.        
        private PseudoRandom m_random;
        
        // Logger class object.        
        private Logger m_logger;

        // Number of testcases active at present.
        private int m_activeTestCasesCount = 0;

        private ushort m_serverId;
        #endregion
    }
}
