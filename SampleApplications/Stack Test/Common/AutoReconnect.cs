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
using Opc.Ua.Bindings;

namespace Opc.Ua.StackTest
{
    public partial class TestClient
    {
        private void ExecuteTest_AutoReconnect(
            ChannelContext  channelContext, 
            TestCaseContext testCaseContext, 
            TestCase        testCase, 
            int             iteration)
        {
            Variant input;
            Variant output;

            // initialize test case.
            if (iteration == TestCases.TestSetupIteration)
            {
                m_fault = null;
                m_blackouts = new List<BlackoutPeriod>();
                channelContext.ClientSession.OperationTimeout = 30000;
                
                RequestHeader requestHeader = new RequestHeader();

                requestHeader.Timestamp = DateTime.UtcNow;
                requestHeader.ReturnDiagnostics = (uint)DiagnosticsMasks.All;

                ResponseHeader responseHeader = channelContext.ClientSession.TestStack(
                    null,
                    testCase.TestId,
                    TestCases.TestSetupIteration,
                    input,
                    out output);

                return;
            }

            if (iteration == TestCases.TestCleanupIteration)
            {
                do
                {
                    lock (m_lock)
                    {
                        if (m_requestCount == 0)
                        {
                            return;
                        }
                    }

                    Thread.Sleep(100);
                }
                while (true);
            }
                        
            Thread.Sleep(testCaseContext.RequestInterval);

            // report fault after waiting for all active threads to exit.
            if (m_sequenceToExecute.HaltOnError)
            {
                ServiceResult fault = null;

                lock (m_lock)
                {
                    fault = m_fault;
                }

                if (fault != null)
                {
                    do
                    {
                        lock (m_lock)
                        {
                            if (m_requestCount == 0)
                            {
                                throw new ServiceResultException(fault);
                            }
                        }

                        Thread.Sleep(100);
                    }
                    while (true);
                }
            }

            // begin iteration.                            
            channelContext.EventLogger.LogStartEvent(testCase, iteration);
                
            lock (m_lock)
            {
                // set up header.
                RequestHeader requestHeader = new RequestHeader();

                requestHeader.Timestamp = DateTime.UtcNow;
                requestHeader.ReturnDiagnostics = (uint)DiagnosticsMasks.All;

                // generate input data.
                channelContext.Random.Start(
                    (int)(testCase.Seed + iteration),
                    (int)m_sequenceToExecute.RandomDataStepSize,
                    testCaseContext);

                input = channelContext.Random.GetVariant();
                
                // determine processing time in server.
                int processingTime = channelContext.Random.GetInt32Range(0, testCaseContext.MaxResponseDelay);
                
                Utils.Trace("Iteration {0}; Processing Time {1}.", iteration, processingTime);

                AsyncTestState state = new AsyncTestState(channelContext, testCaseContext, testCase, iteration);
                state.CallData = (DateTime.UtcNow.AddMilliseconds(processingTime).Ticks/TimeSpan.TicksPerMillisecond);
                                
                // set timeout to twice the processing time.
                if (processingTime < testCaseContext.MaxTransportDelay)
                {
                    processingTime = testCaseContext.MaxTransportDelay;
                }

                channelContext.ClientSession.OperationTimeout = processingTime*2;
              
                if ((iteration+1)%testCaseContext.StackEventFrequency == 0)
                {
                    StackAction action = TestUtils.GetStackAction(testCaseContext, channelContext.EndpointDescription);

                    if (action != null)
                    {
                        BlackoutPeriod period = new BlackoutPeriod();
                        period.Start = (DateTime.UtcNow.Ticks/TimeSpan.TicksPerMillisecond);
                        m_blackouts.Add(period);

                        Utils.Trace("Iteration {0}; Expecting Fault {1}", iteration, action.ActionType);
                    }
                }

                try
                {
                    channelContext.ClientSession.BeginTestStack(
                        requestHeader,
                        testCase.TestId,
                        iteration,
                        input,
                        EndAutoReconnect,
                        state);
                                        
                    m_requestCount++;
                }
                catch (Exception e)
                {
                    // check if a fault is expected.
                    bool faultExpected = FaultExpected((long)state.CallData , testCaseContext);

                    if (faultExpected)
                    {
                        Utils.Trace("Iteration {0}; Fault Expected {1}", state.Iteration, e.Message);
                        state.ChannelContext.EventLogger.LogCompleteEvent(testCase, iteration);  
                        return; 
                    }
                
                    channelContext.EventLogger.LogErrorEvent(testCase, iteration, e);

                    if (m_sequenceToExecute.HaltOnError)
                    {
                        if (m_fault == null)
                        {
                            m_fault = ServiceResult.Create(e, StatusCodes.BadUnexpectedError, "Could not send request.");
                        }
                    }
                }   
            }
        }

        /// <summary>
        /// Callback method that will be invoked when the asynchronous BeginTestStack method is complete
        /// </summary>
        private void EndAutoReconnect(IAsyncResult asyncResult)
        {
            AsyncTestState state = (AsyncTestState)asyncResult.AsyncState;            
            long completionTime = (state.CallData is long)?(long)state.CallData:0;

            lock (m_lock)
            {
                m_requestCount--;

                // check if a fault is expected.
                bool faultExpected = FaultExpected(completionTime, state.TestCaseContext);

                // complete the operation.
                Variant output;

                try
                {
                    state.ChannelContext.ClientSession.EndTestStack(asyncResult, out output);
                }
                catch (Exception e)
                {
                    if (!faultExpected)
                    {
                        // allow faults for a short period of time after a black out ends.
                        for (int ii = 0; ii < m_blackouts.Count; ii++)
                        {
                            if (completionTime >= m_blackouts[ii].Start && completionTime < m_blackouts[ii].End + state.TestCaseContext.MaxTransportDelay)
                            {
                                faultExpected = true;
                                break;
                            }
                        }
                    }

                    for (int ii = 0; ii < m_blackouts.Count; ii++)
                    {
                        long period = m_blackouts[ii].Start;

                        if (m_blackouts[ii].End <= 0)
                        {
                            period = DateTime.UtcNow.Ticks/TimeSpan.TicksPerMillisecond - period;
                        }
                        else
                        {
                            period = m_blackouts[ii].End - period;
                        }

                        if (state.TestCaseContext.MaxRecoveryTime + state.TestCaseContext.MaxResponseDelay <= (int)period)
                        {
                            e = ServiceResultException.Create(
                                StatusCodes.BadUnexpectedError, 
                                "Iteration {0} MaxRecoveryTime Exceeded {1} ms", 
                                state.Iteration,
                                period);
                            
                            faultExpected = false;
                            break;
                        }
                    }
                    
                    // no error if a fault was expected.
                    if (faultExpected)
                    {
                        Utils.Trace("Iteration {0}; Fault Expected {1}", state.Iteration, e.Message);
                        state.ChannelContext.EventLogger.LogCompleteEvent(state.Testcase, state.Iteration);  
                        return; 
                    }
                    
                    Utils.Trace("Iteration {0}; Fault Unexpected {1}", state.Iteration, e.Message);

                    // log error.
                    state.ChannelContext.EventLogger.LogErrorEvent(state.Testcase, state.Iteration, e);

                    if (m_sequenceToExecute.HaltOnError)
                    {
                        // only report first fault.
                        if (m_fault == null)
                        {
                            m_fault = ServiceResult.Create(e, StatusCodes.BadUnexpectedError, "Unexpected Fault on Iteration {0}", state.Iteration);
                        }
                    }

                    return;
                }
                
                // allow success for a short period of time before a black out begins.
                for (int ii = 0; ii < m_blackouts.Count; ii++)
                {
                    if ((completionTime <= m_blackouts[ii].End || m_blackouts[ii].End == 0) && completionTime >= m_blackouts[ii].Start - state.TestCaseContext.MaxTransportDelay)
                    {
                        faultExpected = false;
                        break;
                    }
                }

                try
                {
                    // check if a fault was expected.
                    if (faultExpected)
                    {
                        throw ServiceResultException.Create(
                            StatusCodes.BadUnexpectedError, 
                            "Expecting a fault which did not occur.");
                    }

                    // check processing time.
                    long processingTimeError = ((DateTime.UtcNow.Ticks/TimeSpan.TicksPerMillisecond) - completionTime);

                    Utils.Trace("Iteration {0}; Delta {1}.", state.Iteration, processingTimeError);

                    if (Math.Abs(processingTimeError) > state.TestCaseContext.MaxTransportDelay*2)
                    {
                        bool late = true;

                        if (state.TestCaseContext.StackEventType == 4)
                        {
                            if (Math.Abs(processingTimeError) > state.TestCaseContext.MaxRecoveryTime)
                            {
                                late = false;
                            }
                        }

                        if (late)
                        {
                            throw ServiceResultException.Create(
                                StatusCodes.BadUnexpectedError, 
                                "Request did not complete in the specified time (Error = {0}ms).", 
                                processingTimeError);
                        }
                    }

                    // black out ends when the first valid request is returned.
                    for (int ii = 0; ii < m_blackouts.Count; ii++)
                    {
                        if (m_blackouts[ii].End <= 0)
                        {
                            m_blackouts[ii].End = (DateTime.UtcNow.Ticks/TimeSpan.TicksPerMillisecond);
                        }
                    }
                    
                    // check output.
                    state.ChannelContext.Random.Start(
                        (int)(state.Testcase.ResponseSeed + state.Iteration),
                        (int)m_sequenceToExecute.RandomDataStepSize,
                        state.TestCaseContext);

                    Variant expectedOutput = state.ChannelContext.Random.GetVariant();
                    
                    if (!Compare.CompareVariant(output, expectedOutput))
                    {
                        throw ServiceResultException.Create(
                            StatusCodes.BadUnexpectedError, 
                            "Server did not return expected output\r\nActual = {0}\r\nExpected = {0}", 
                            output,
                            expectedOutput);
                    }
                                        
                    // iteration complete.
                    state.ChannelContext.EventLogger.LogCompleteEvent(state.Testcase, state.Iteration);   
                }
                catch (Exception e)
                {
                    state.ChannelContext.EventLogger.LogErrorEvent(state.Testcase, state.Iteration, e);

                    if (m_sequenceToExecute.HaltOnError)
                    {
                        // only report first fault.
                        if (m_fault == null)
                        {
                            m_fault = new ServiceResult(e);
                        }
                    }
                }
            }
        }
        
        /// <summary>
        /// A period where faults should occur.
        /// </summary>
        private class BlackoutPeriod
        {
            public long Start;
            public long End;
            
            /// <summary>
            /// Returns true if the completion time is in the blackout period.
            /// </summary>
            public bool InPeriod(long completionTime)
            {
                if (completionTime < Start)
                {
                    return false;
                }

                if (End > 0 && completionTime > End)
                {
                    return false;
                }

                return true;
            }

            /// <summary>
            /// Returns true if the blackout period is no longer meaningful.
            /// </summary>
            public bool Expired(long maxResponseDelay, long maxTransportDelay)
            {
                long timeout = maxResponseDelay;

                if (timeout < maxTransportDelay)
                {
                    timeout = maxTransportDelay;
                }

                if (End > 0 && End + timeout*3 < (DateTime.UtcNow.Ticks/TimeSpan.TicksPerMillisecond))
                {
                    return true;
                }
                    
                return false;
            }
        }

        /// <summary>
        /// Returns true if a fault is expected. 
        /// </summary>
        private bool FaultExpected(long completionTime, TestCaseContext context)
        {
            // remove expired periods
            int ii = 0;

            while (ii < m_blackouts.Count)
            {
                if (m_blackouts[ii].Expired(context.MaxResponseDelay, context.MaxTransportDelay))
                {
                    m_blackouts.RemoveAt(ii);
                    continue;
                }

                ii++;
            }

            // always fault.
            if (completionTime == 0)
            {
                return true;
            }

            // check if in a balckout period.
            for (int jj = 0; jj < m_blackouts.Count; jj++)
            {
                if (m_blackouts[jj].InPeriod(completionTime))
                {
                    return true;
                }
            }

            return false;
        }       

        private ServiceResult m_fault;
        private int m_requestCount;
        private List<BlackoutPeriod> m_blackouts;
    }

    public partial class TestServer : StandardServer
    {
        private Variant ExecuteTest_AutoReconnect(TestCaseContext testCaseContext, TestCase testCase, int iteration, Variant input)
        {
            if (TestUtils.IsSetupIteration(iteration))
            {
                SetEventSink();
                return Variant.Null;
            }

            // get the expected input.
            Variant expectedInput;
            int processingTime = 0;

            lock (m_random)
            {
                Utils.Trace("Iteration {0}; Server Received", iteration);

                // compare actual to expected input.
                m_random.Start(
                    (int)(testCase.Seed + iteration),
                    (int)m_sequenceToExecute.RandomDataStepSize,
                    testCaseContext);
                
                expectedInput = m_random.GetVariant();
                
                if (!Compare.CompareVariant(input, expectedInput))
                {
                    throw ServiceResultException.Create(
                        StatusCodes.BadUnexpectedError, 
                        "Server did not receive expected input\r\nActual = {0}\r\nExpected = {0}", 
                        input,
                        expectedInput);
                }

                // determine processing time in server.
                processingTime = m_random.GetInt32Range(0, testCaseContext.MaxResponseDelay);

                if ((iteration+1)%testCaseContext.StackEventFrequency == 0)
                {
                    if (testCaseContext.StackEventType == 4)
                    {
                        InterruptListener(testCaseContext.StackEventFrequency*testCaseContext.RequestInterval/2);
                    }

                    StackAction action = TestUtils.GetStackAction(testCaseContext, SecureChannelContext.Current.EndpointDescription);

                    if (action != null)
                    {
                        QueueStackAction(action);
                    }
                }
            }

            // wait.
            Thread.Sleep(processingTime);

            // generate and return the output.
            lock (m_random)
            {
                m_random.Start((int)(
                    testCase.ResponseSeed + iteration),
                    (int)m_sequenceToExecute.RandomDataStepSize,
                    testCaseContext);

                return  m_random.GetVariant();
            }
        }
    }
}
