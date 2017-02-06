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
using System.Threading;
using System.Text;
using System.IO;
using System.Xml;
using System.Reflection;


namespace Opc.Ua.StackTest
{
    #region Class TestUtils
    /// <summary>
    /// Utility class for testing.
    /// </summary>
    public static class TestUtils
    {
        /// <summary>
        /// Obtains the int value of the specified parameter
        /// </summary>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="testParameter">An array of the test parameters configured in the file.</param>
        /// <returns></returns>
        public static int GetTestParameterIntValue(string parameterName, TestParameter[] testParameter)
        {
            if (parameterName == null)
            {
                throw new ArgumentException();
            }

            if (testParameter == null || testParameter.Length == 0)
            {
                return 0;
            }

            for (int i = 0; i < testParameter.Length; i++)
            {
                if (testParameter[i].Name == parameterName)
                {
                    return Int32.Parse(testParameter[i].Value);
                }
            }

            return 0;
        }

        /// <summary>
        /// Populates the test parameters information into a TestCaseContext object
        /// </summary>
        /// <param name="testCase">This parameter stores the test case related data.</param>
        /// <returns>TestCaseContext object</returns>
        public static TestCaseContext GetExecutionContext(TestCase testCase)
        {
            TestCaseContext testCaseContext = new TestCaseContext();

            int value = 0;
            
            value = TestUtils.GetTestParameterIntValue(TestCases.MaxStringLength, testCase.Parameter);

            if (value != 0)
            {
                testCaseContext.MaxStringLength = value;
            }

            value = TestUtils.GetTestParameterIntValue(TestCases.MaxArrayLength, testCase.Parameter);
            
            if (value != 0)
            {
                testCaseContext.MaxArrayLength = value;
            }

            value = TestUtils.GetTestParameterIntValue(TestCases.ServerMaxMessageSize, testCase.Parameter);
            
            if (value != 0)
            {
                testCaseContext.ServerMaxMessageSize = value;
            }

            value = TestUtils.GetTestParameterIntValue(TestCases.ClientMaxMessageSize, testCase.Parameter);
            
            if (value != 0)
            {
                testCaseContext.ClientMaxMessageSize = value;
            }

            value = TestUtils.GetTestParameterIntValue(TestCases.MaxDepth, testCase.Parameter); ;
            
            if (value != 0)
            {
                testCaseContext.MaxDepth = value;
            }

            value = TestUtils.GetTestParameterIntValue(TestCases.MinTimeout, testCase.Parameter);
            
            if (value != 0)
            {
                testCaseContext.MinTimeout = value;
            }

            value = TestUtils.GetTestParameterIntValue(TestCases.MaxTimeout, testCase.Parameter);
            
            if (value != 0)
            {
                testCaseContext.MaxTimeout = value;
            }

            value = TestUtils.GetTestParameterIntValue(TestCases.MaxResponseDelay, testCase.Parameter);
            
            if (value != 0)
            {
                testCaseContext.MaxResponseDelay = value;
            }

            value = TestUtils.GetTestParameterIntValue(TestCases.MaxTransportDelay, testCase.Parameter);
            
            if (value != 0)
            {
                testCaseContext.MaxTransportDelay = value;
            }
            
            value = TestUtils.GetTestParameterIntValue(TestCases.RequestInterval, testCase.Parameter);
            
            if (value != 0)
            {
                testCaseContext.RequestInterval = value;
            }
            
            value = TestUtils.GetTestParameterIntValue(TestCases.StackEventType, testCase.Parameter);
            
            if (value != 0)
            {
                testCaseContext.StackEventType = value;
            }

            value = TestUtils.GetTestParameterIntValue(TestCases.StackEventFrequency, testCase.Parameter);

            if (value != 0)
            {
                testCaseContext.StackEventFrequency = value;
            }

            value = TestUtils.GetTestParameterIntValue(TestCases.MaxRecoveryTime, testCase.Parameter);

            if (value != 0)
            {
                testCaseContext.MaxRecoveryTime = value;
            }

            if (testCase.Name == TestCases.MultipleChannels)
            {
                value = TestUtils.GetTestParameterIntValue(TestCases.ChannelsPerServer, testCase.Parameter);
                
                if (value != 0)
                {
                    testCaseContext.ChannelsPerServer = value;
                }

                List<ServerDetail> ServerDetails;

                ServerDetails = TestUtils.GetTestParameterServerDetails(testCase.Parameter);
                
                if (ServerDetails != null)
                {
                    testCaseContext.ServerDetails = ServerDetails;
                }
            }

            return testCaseContext;
        }

        /// <summary>
        /// This method gets the Server details from the test files.
        /// The $ separated server names and urls are written in the test case file.
        /// This method extract those values from the file and populates list of the type ServerDetail.
        /// </summary>
        /// <param name="testParameter">An array of the test parameters configured in the file.</param>
        /// <returns>List containing server details.</returns>
        private static List<ServerDetail> GetTestParameterServerDetails(TestParameter[] testParameter)
        {
            List<ServerDetail> ServerDetails = null;
            bool firstServerDetail = false;
            if (testParameter == null || testParameter.Length == 0)
            {
                return null;
            }

            char[] separator = { '$' };
            for (int i = 0; i < testParameter.Length; i++)
            {
                if (testParameter[i].Name == TestCases.ServerDetails)
                {
                    if (!firstServerDetail)
                    {
                        ServerDetails = new List<ServerDetail>();
                        firstServerDetail = true;
                    }
                    string[] details = testParameter[i].Value.Split(separator);
                    if (details.Length != 2)
                    {
                        return null;
                    }
                    ServerDetails.Add(new ServerDetail(details[0], details[1]));
                }
            }
            return ServerDetails;
        }

        /// <summary>
        /// Validates the test case
        /// </summary>
        /// <param name="testCase">This parameter stores the test case related data.</param>
        /// <param name="iteration">This parameter stores the current iteration number.</param>
        public static void ValidateTestCase(TestCase testCase, int iteration)
        {
            if (testCase.Name.Equals(string.Empty))
            {
                throw new Exception("Invalid test case name");
            }
            if (testCase.StartSpecified && testCase.Start < 0)
            {
                throw new Exception("Start value is less than 0 for test case.");
            }

            if (testCase.CountSpecified && testCase.Count < 0)
            {
                throw new Exception("Iteration value is less than 0 for test case.");
            }

            if (testCase.StartSpecified && testCase.Start > iteration && iteration != TestCases.TestSetupIteration)
            {
                throw new Exception("Iteration is less than start for test case.");
            }

            if (testCase.CountSpecified && testCase.Count < iteration && iteration != TestCases.TestCleanupIteration)
            {
                throw new Exception("Iteration is greater than count for test case.");
            }
        }

        /// <summary>
        /// Initializes contexts for vendor namespaces.
        /// </summary>
        /// <param name="serviceMessageContext"> An object value of type ServiceMessageContext</param>
        public static void InitializeContexts(ServiceMessageContext serviceMessageContext)
        {
            FieldInfo[] fields = typeof(VendorNamespaces).GetFields(BindingFlags.Static | BindingFlags.Public);

            List<string> namespaceUris = new List<string>();

            namespaceUris.Add(Namespaces.OpcUa);
            namespaceUris.Add(Guid.NewGuid().ToString());

            foreach (FieldInfo field in fields)
            {
                if (field.FieldType == typeof(string))
                {
                    namespaceUris.Add((string)field.GetValue(null));
                }
            }

            serviceMessageContext.NamespaceUris.Update(namespaceUris);

            serviceMessageContext.Factory.AddEncodeableType(typeof(AcmeWidget));
            serviceMessageContext.Factory.AddEncodeableType(typeof(CoyoteGadget));
            serviceMessageContext.Factory.AddEncodeableType(typeof(SkyNetRobot));
            serviceMessageContext.Factory.AddEncodeableType(typeof(S88Batch));
            serviceMessageContext.Factory.AddEncodeableType(typeof(S88Operation));
            serviceMessageContext.Factory.AddEncodeableType(typeof(S88Phase));
            serviceMessageContext.Factory.AddEncodeableType(typeof(S88UnitProcedure));
            serviceMessageContext.Factory.AddEncodeableType(typeof(Driver));
            serviceMessageContext.Factory.AddEncodeableType(typeof(Vehicle));
            serviceMessageContext.Factory.AddEncodeableType(typeof(Wheel));
            serviceMessageContext.Factory.AddEncodeableType(typeof(Car));
            serviceMessageContext.Factory.AddEncodeableType(typeof(Truck));
        }

        /// <summary>
        /// Checks if the specified test case is the last one to execute
        /// </summary>
        /// <param name="sequenceToExecute"></param>
        /// <param name="testCase">This parameter stores the test case related data.</param>
        /// <returns>True if the test case is the last test case.</returns>
        public static bool IsLastTestCase(TestSequence sequenceToExecute, TestCase testCase)
        {
            int lastTestCaseIndex = sequenceToExecute.TestCase.Length - 1;
            // Find the last testCase with skiptest attribute value as false ;

            while (lastTestCaseIndex >= 0 && sequenceToExecute.TestCase[lastTestCaseIndex].SkipTest == true)
            {
                lastTestCaseIndex--;
            }
            if (lastTestCaseIndex == -1)
            {
                // This case should never occur.
                return true;
            }

            return Object.ReferenceEquals(sequenceToExecute.TestCase[lastTestCaseIndex], testCase);
        }

        /// <summary>
        /// Checks if the iteration is a setup setp that is iteration == -1 or iteration == Int32.MaxValue
        /// </summary>
        /// <param name="iteration">This parameter stores the current iteration number.</param>
        /// <returns>True if the test case is the  first or last test case.</returns>
        public static bool IsSetupIteration(int iteration)
        {
            return (iteration == TestCases.TestSetupIteration || iteration == TestCases.TestCleanupIteration);
        }
        
        /// <summary>
        /// Returns the stack action to use for the current context.
        /// </summary>
        public static StackAction GetStackAction(TestCaseContext context, EndpointDescription endpointDescription)
        {
            if (!endpointDescription.EndpointUrl.StartsWith(Utils.UriSchemeOpcTcp))
            {
                return null;
            }

            StackAction action = new StackAction();

            switch (context.StackEventType)
            {
                case 1: { action.ActionType = StackActionType.CorruptMessageChunk;   break; }
                case 2: { action.ActionType = StackActionType.ReuseSequenceNumber;   break; }
                case 3: { action.ActionType = StackActionType.CloseConnectionSocket; break; }
                case 4: { action.ActionType = StackActionType.CloseConnectionSocket; break; }

                default:
                {
                    return null;
                }                     
            }

            // cannot detect corrupt messages predictably if no security is used.
            if (endpointDescription.SecurityMode == MessageSecurityMode.None)
            {
                if (action.ActionType == StackActionType.CorruptMessageChunk)
                {
                    action.ActionType = StackActionType.ReuseSequenceNumber;
                }
            }

            return action;
        }
    }
    #endregion   

    #region Class AsycnTestState
    /// <summary>
    /// Asynchronous test state information
    /// </summary>
    public class AsyncTestState
    {
        /// <summary />
        /// <param name="channelContext">This parameter stores the channel related data.</param>
        /// <param name="testCaseContext">This parameter stores the test case parameter values.</param>
        /// <param name="testCase">This parameter stores the test case related data.</param>
        /// <param name="iteration">This parameter stores the current iteration number.</param>
        public AsyncTestState(
            ChannelContext  channelContext,
            TestCaseContext testCaseContext,
            TestCase        testCase,
            int             iteration)
        {
            ChannelContext = channelContext;
            TestCaseContext = testCaseContext;
            Testcase = testCase;
            Iteration = iteration;
        }

        /// <summary />
        public ChannelContext ChannelContext;

        /// <summary />
        public TestCaseContext TestCaseContext;
        
        /// <summary />
        public TestCase Testcase;
        
        /// <summary />
        public int Iteration;
        
        /// <summary />
        public object CallData;
    }
    #endregion

    #region Class AsyncTestEventState
    /// <summary>
    /// Asynchronous test event logger state information
    /// </summary>
    public class AsyncTestEventState
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="testCase">This parameter stores the test case related data.</param>
        /// <param name="iteration">This parameter stores the current iteration number.</param>
        public AsyncTestEventState(TestCase testCase, int iteration)
        {
            Testcase = testCase;
            Iteration = iteration;
            E = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="testCase">This parameter stores the test case related data.</param>
         /// <param name="iteration">This parameter stores the current iteration number.</param>
        /// <param name="e">Exception</param>
        public AsyncTestEventState(TestCase testCase, int iteration, Exception e)
        {
            Testcase = testCase;
            Iteration = iteration;
            E = e;
        }

        /// <summary>
        /// 
        /// </summary>
        public IAsyncResult AsyncResult;

        /// <summary>
        /// 
        /// </summary>
        public TestCase Testcase;

        /// <summary>
        /// 
        /// </summary>
        public int Iteration;

        /// <summary>
        /// 
        /// </summary>
        public Exception E;
    }
    #endregion

    #region Structure ServerDetail
    /// <summary>
    /// This structure will store the server related details.
    /// </summary>
    public struct ServerDetail
    {
        /// <summary>
        /// Creates an instance with the specified server details.
        /// The details will include server name and server url.
        /// </summary>
        public ServerDetail(string name, string url)
        {
            Name = name;
            Url = url;
        }

        /// <summary>
        /// The name of the server.
        /// </summary>
        public string Name;

        /// <summary>
        /// The url of the server.
        /// </summary>
        public string Url;
    }
    #endregion

    #region Delegates
    /// <summary>
    /// The delegate used to compare two values.   
    /// </summary> 
    public delegate bool Comparator<T>(T value1, T value2);
    #endregion
}
