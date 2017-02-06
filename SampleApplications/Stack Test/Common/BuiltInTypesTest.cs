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
        /// This method executes a builtin types test.
        /// </summary>
        /// <param name="channelContext">This parameter stores the channel related data.</param>
        /// <param name="testCaseContext">This parameter stores the test case parameter values.</param>
        /// <param name="testCase">This parameter stores the test case related data.</param>
        /// <param name="iteration">This parameter stores the current iteration number.</param>
        /// <remarks>
        /// The test parameters required for this test case are of the 
        /// following types:
        /// <list type="bullet">
        ///     <item>MaxStringLength <see cref="TestCaseContext.MaxStringLength"/></item>
        /// </list>     
        /// </remarks>
        private void ExecuteTest_BuiltInTypes(ChannelContext channelContext, TestCaseContext testCaseContext, TestCase testCase, int iteration)
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

            CompositeTestType input;
            CompositeTestType output;
            CompositeTestType expectedOutput;
            ResponseHeader responseHeader;

            if (isSetupStep)
            {
                input = null;

                responseHeader = channelContext.ClientSession.TestStackEx(
                    requestHeader,
                    testCase.TestId,
                    iteration,
                    input,
                    out output);

            }
            else
            {
                channelContext.Random.Start(
                    (int)(testCase.Seed + iteration),
                    (int)m_sequenceToExecute.RandomDataStepSize,
                    testCaseContext);

                input = channelContext.Random.GetCompositeTestType();

                responseHeader = channelContext.ClientSession.TestStackEx(
                    requestHeader,
                    testCase.TestId,
                    iteration,
                    input,
                    out output);

                channelContext.Random.Start(
                    (int)(testCase.ResponseSeed + iteration),
                    (int)m_sequenceToExecute.RandomDataStepSize,
                    testCaseContext);

                expectedOutput = channelContext.Random.GetCompositeTestType();

                if (!Compare.CompareCompositeTestType(output, expectedOutput))
                {
                    throw new ServiceResultException(
                        StatusCodes.BadInvalidState,
                        Utils.Format("'{0}' is not equal to '{1}'.", output, expectedOutput));
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
        /// This method executes a builtin types test.
        /// </summary>
        /// <param name="testCaseContext">This parameter stores the test case parameter values.</param>
        /// <param name="testCase">This parameter stores the test case related data.</param>
        /// <param name="iteration">This parameter stores the current iteration number.</param>
        /// <param name="input">Input value.</param>
        /// <returns>A variant of the type scalar value.</returns>
        /// <remarks>
        /// The test parameters required for this test case are of the 
        /// following types:
        /// <list type="bullet">
        ///     <item>MaxStringLength <see cref="TestCaseContext.MaxStringLength"/></item>
        /// </list>     
        /// </remarks>
        private CompositeTestType ExecuteTest_BuiltInTypes(TestCaseContext testCaseContext, TestCase testCase, int iteration, CompositeTestType input)
        {
            bool isSetupStep = TestUtils.IsSetupIteration(iteration);

            if (!isSetupStep)
            {
                m_logger.LogStartEvent(testCase, iteration);
            }
            try
            {
                if (isSetupStep)
                {
                    // No verification for the input is required.
                    return null;
                }
                else
                {
                    m_random.Start(
                        (int)(testCase.Seed + iteration),
                        (int)m_sequenceToExecute.RandomDataStepSize,
                        testCaseContext);

                    CompositeTestType expectedInput = m_random.GetCompositeTestType();

                    try
                    {
                        if (!Compare.CompareCompositeTestType(input, expectedInput))
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

                    return m_random.GetCompositeTestType();
                }
            }
            finally
            {
                if (!isSetupStep)
                {
                    m_logger.LogCompleteEvent(testCase, iteration);
                }
            }
        }
    }
}
