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
using Opc.Ua.Client;
using Opc.Ua.StackTest;
using Opc.Ua.Server;

namespace Opc.Ua.StackTest
{
    public partial class TestClient
    {
        /// <summary>
        /// This method executes a test using messages that exceed the maximum message size.
        /// </summary>
        private void ExecuteTest_LargeMessages(
            ChannelContext  channelContext, 
            TestCaseContext testCaseContext, 
            TestCase        testCase, 
            int             iteration)
        {
            bool isSetupStep = TestUtils.IsSetupIteration(iteration);

            if (!isSetupStep)
            {
                channelContext.EventLogger.LogStartEvent(testCase, iteration);
            }
            else
            {
                channelContext.ClientSession.OperationTimeout = 30000;
            }

            RequestHeader requestHeader = new RequestHeader();

            requestHeader.Timestamp = DateTime.UtcNow;
            requestHeader.ReturnDiagnostics = (uint)DiagnosticsMasks.All;

            Variant input;
            Variant output;
            Variant expectedOutput;
            ResponseHeader responseHeader;

            if (isSetupStep)
            {
                testCaseContext.ClientMaxMessageSize = channelContext.MessageContext.MaxMessageSize;

                responseHeader = channelContext.ClientSession.TestStack(
                    requestHeader,
                    testCase.TestId,
                    iteration,
                    new Variant(testCaseContext.ClientMaxMessageSize),
                    out output);

                if (output.Value is int)
                {
                    testCaseContext.ServerMaxMessageSize = (int)output.Value;
                }

                // update the parameters.
                for (int ii = 0; ii < testCase.Parameter.Length; ii++)
                {
                    if (testCase.Parameter[ii].Name == TestCases.ServerMaxMessageSize)
                    {
                        testCase.Parameter[ii].Value = Utils.Format("{0}", testCaseContext.ServerMaxMessageSize);
                        continue;
                    }

                    if (testCase.Parameter[ii].Name == TestCases.ClientMaxMessageSize)
                    {
                        testCase.Parameter[ii].Value = Utils.Format("{0}", testCaseContext.ClientMaxMessageSize);
                        continue;
                    }
                }
            }
            else
            {
                channelContext.Random.Start(
                    (int)(testCase.Seed + iteration),
                    (int)m_sequenceToExecute.RandomDataStepSize,
                    testCaseContext);
                
                int messageLength = 0;

                if (channelContext.Random.GetRandomBoolean())
                {
                    messageLength = channelContext.Random.GetInt32Range(1, testCaseContext.ServerMaxMessageSize/2);
                }
                else
                {
                    messageLength = channelContext.Random.GetInt32Range(testCaseContext.ServerMaxMessageSize, testCaseContext.ServerMaxMessageSize*2);
                }
                
                input = new Variant(channelContext.Random.GetRandomByteString(messageLength));

                ServiceResultException sre = null;

                try
                {
                    responseHeader = channelContext.ClientSession.TestStack(
                        requestHeader,
                        testCase.TestId,
                        iteration,
                        input,
                        out output);
                }
                catch (ServiceResultException e)
                {
                    sre = e;
                }

                if (messageLength > testCaseContext.ServerMaxMessageSize)
                {
                    if (sre == null)
                    {
                        throw new ServiceResultException(
                          StatusCodes.BadInvalidState,
                          Utils.Format("Server did not reject a message that is too large ({0} bytes).", messageLength));
                    }
                    else
                    {
                        if (sre.StatusCode != StatusCodes.BadRequestTooLarge)
                        {
                            throw new ServiceResultException(
                              StatusCodes.BadInvalidState,
                              Utils.Format("Client do not receive a BadRequestTooLarge exception: {0}", sre.StatusCode));
                        }
                    }
                }
                else
                {
                    channelContext.Random.Start(
                        (int)(testCase.ResponseSeed + iteration),
                        (int)m_sequenceToExecute.RandomDataStepSize,
                        testCaseContext);
                    
                    if (channelContext.Random.GetRandomBoolean())
                    {
                        messageLength = channelContext.Random.GetInt32Range(1, testCaseContext.ClientMaxMessageSize/2);
                    }
                    else
                    {
                        messageLength = channelContext.Random.GetInt32Range(testCaseContext.ClientMaxMessageSize, testCaseContext.ClientMaxMessageSize*2);
                    }
                    
                    if (sre == null)
                    {
                        if (messageLength > testCaseContext.ClientMaxMessageSize)
                        {
                            throw new ServiceResultException(
                              StatusCodes.BadInvalidState,
                              Utils.Format("Client received a message that is too large ({0} bytes).", messageLength));
                        }

                        expectedOutput = new Variant(channelContext.Random.GetRandomByteString(messageLength));

                        if (!Compare.CompareVariant(output, expectedOutput))
                        {
                            throw new ServiceResultException(
                                StatusCodes.BadInvalidState,
                                Utils.Format("'{0}' is not equal to '{1}'.", output, expectedOutput));
                        }
                    }
                    else
                    {
                        if (sre.StatusCode != StatusCodes.BadResponseTooLarge)
                        {
                            throw new ServiceResultException(
                              StatusCodes.BadInvalidState,
                              Utils.Format("Client do not receive a BadResponseTooLarge exception: {0}", sre.StatusCode));
                        }
                    }
                }
            }

            if (!isSetupStep)
            {
                channelContext.EventLogger.LogCompleteEvent(testCase, iteration);
            }
        }
    }

    public partial class TestServer : StandardServer
    {
        /// <summary>
        /// This method executes a test using messages that exceed the maximum message size.
        /// </summary>
        private Variant ExecuteTest_LargeMessages(
            TestCaseContext testCaseContext, 
            TestCase        testCase, 
            int             iteration, 
            Variant         input)
        {
            bool isSetupStep = TestUtils.IsSetupIteration(iteration);
            
            // No verification for the input is required.
            if (isSetupStep)
            {
                testCaseContext.ServerMaxMessageSize = MessageContext.MaxMessageSize;

                if (input.Value is int)
                {
                    testCaseContext.ClientMaxMessageSize = (int)input.Value;
                }
                
                // update the parameters.
                for (int ii = 0; ii < testCase.Parameter.Length; ii++)
                {
                    if (testCase.Parameter[ii].Name == TestCases.ServerMaxMessageSize)
                    {
                        testCase.Parameter[ii].Value = Utils.Format("{0}", testCaseContext.ServerMaxMessageSize);
                        continue;
                    }

                    if (testCase.Parameter[ii].Name == TestCases.ClientMaxMessageSize)
                    {
                        testCase.Parameter[ii].Value = Utils.Format("{0}", testCaseContext.ClientMaxMessageSize);
                        continue;
                    }
                }

                return new Variant(testCaseContext.ServerMaxMessageSize);
            }

            m_logger.LogStartEvent(testCase, iteration);

            try
            {
                m_random.Start(
                    (int)(testCase.Seed + iteration),
                    (int)m_sequenceToExecute.RandomDataStepSize,
                    testCaseContext);
                
                int messageLength = 0;

                if (m_random.GetRandomBoolean())
                {
                    messageLength = m_random.GetInt32Range(1, testCaseContext.ServerMaxMessageSize/2);
                }
                else
                {
                    messageLength = m_random.GetInt32Range(testCaseContext.ServerMaxMessageSize, testCaseContext.ServerMaxMessageSize*2);
                }

                Variant expectedInput = new Variant(m_random.GetRandomByteString(messageLength));

                if (messageLength > testCaseContext.ServerMaxMessageSize)
                {
                    throw new ServiceResultException(
                      StatusCodes.BadInvalidState,
                      Utils.Format("Server received a message that is too large ({0} bytes).", messageLength));
                }

                try
                {
                    if (!Compare.CompareVariant(input, expectedInput))
                    {
                        throw new ServiceResultException(
                          StatusCodes.BadInvalidState,
                          Utils.Format("'{0}' is not equal to '{1}'.", input, expectedInput));
                    }
                }
                catch (Exception e)
                {
                    throw ServiceResultException.Create(
                        StatusCodes.BadInvalidState,
                        e,
                        "'{0}' is not equal to '{1}'.", input, expectedInput);
                }

                m_random.Start((int)(
                    testCase.ResponseSeed + iteration),
                    (int)m_sequenceToExecute.RandomDataStepSize,
                    testCaseContext);

                if (m_random.GetRandomBoolean())
                {
                    messageLength = m_random.GetInt32Range(1, testCaseContext.ClientMaxMessageSize/2);
                }
                else
                {
                    messageLength = m_random.GetInt32Range(testCaseContext.ClientMaxMessageSize, testCaseContext.ClientMaxMessageSize*2);
                }
                
                return new Variant(m_random.GetRandomByteString(messageLength));
            }
            finally
            {
                m_logger.LogCompleteEvent(testCase, iteration);
            }
        }
    }
}
