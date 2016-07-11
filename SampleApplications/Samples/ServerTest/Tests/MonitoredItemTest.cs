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
using System.Threading;

using Opc.Ua.Client;

namespace Opc.Ua.ServerTest
{    
    /// <summary>
    /// Browses all of the nodes in the hierarchies.
    /// </summary>
    internal class MonitoredItemTest : TestBase
    {
        #region Constructors
        /// <summary>
        /// Creates the test object.
        /// </summary>
        public MonitoredItemTest(
            Session session,
            ServerTestConfiguration configuration,
            ReportMessageEventHandler reportMessage,
            ReportProgressEventHandler reportProgress,
            TestBase template)
        : 
            base("MonitoredItem", session, configuration, reportMessage, reportProgress, template)
        {
            m_generator = new Opc.Ua.Test.DataGenerator(new Opc.Ua.Test.RandomSource(configuration.Seed));
            m_generator.NamespaceUris = Session.NamespaceUris;
            m_generator.ServerUris = Session.ServerUris;
            m_generator.MaxArrayLength = 3;
            m_generator.MaxStringLength = 10;
            m_generator.MaxXmlElementCount = 3;
            m_generator.MaxXmlAttributeCount = 3;
            m_comparer = new Opc.Ua.Test.DataComparer(Session.MessageContext);
            m_comparer.ThrowOnError = false;
            
            m_errorEvent = new ManualResetEvent(false);
            m_maximumTimingError = 300;

            m_variables = new List<TestVariable>();    
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Runs the test for all of the browse roots.
        /// </summary>
        public override bool Run(ServerTestCase testcase, int iteration)
        {
            try
            {
                LockServer();
                if (ReadOnlyTests)
                {
                    Log("WARNING: TestCase {0} skipped because client could not acquire a lock on the Server.", testcase.Name);
                    return true;
                }

                Iteration = iteration;

                // need fetch nodes used for the test if not already available.
                if (AvailableNodes.Count == 0)
                {
                    if (!GetNodesInHierarchy())
                    {
                        return false;
                    }
                }

                // get the writeable variables.
                if (WriteableVariables.Count == 0)
                {
                    if (!GetWriteableVariablesInHierarchy())
                    {
                        Log("WARNING: No writeable variables found.");
                        Log(WriteTest.g_WriteableVariableHelpText);
                        return true;
                    }
                }

                // do main test.
                NotificationEventHandler handler = new NotificationEventHandler(Session_Notification);

                try
                {
                    Session.Notification += handler;

                    bool result = true;

                    switch (testcase.Name)
                    {
                        case "Deadband":
                        {
                            if (!DoDeadbandTest(false))
                            {
                                Log("WARNING: Re-doing Deadband test to check if random timing glitches were the cause of failure.");
                                result = DoDeadbandTest(false);
                                break;
                            }

                            return true;
                        }

                        case "ModifyDeadband":
                        {
                            if (!DoDeadbandTest(true))
                            {
                                Log("WARNING: Re-doing ModifyDeadband test to check if random timing glitches were the cause of failure.");
                                result = DoDeadbandTest(true);
                                break;
                            }

                            return true;
                        }

                        case "QueueSize":
                        {
                            if (!DoQueueSizeTest(false))
                            {
                                Log("WARNING: Re-doing QueueSize test to check if random timing glitches were the cause of failure.");
                                result = DoQueueSizeTest(false);
                                break;
                            }

                            return true;
                        }

                        case "ModifyQueueSize":
                        {
                            if (!DoQueueSizeTest(true))
                            {
                                Log("WARNING: Re-doing ModifyQueueSize test to check if random timing glitches were the cause of failure.");
                                result = DoQueueSizeTest(true);
                                break;
                            }

                            return true;
                        }

                        case "ModifySamplingInterval":
                        {
                            if (!DoSamplingIntervalTest(true))
                            {
                                Log("WARNING: Re-doing ModifySamplingInterval test to check if random timing glitches were the cause of failure.");
                                result = DoSamplingIntervalTest(true);
                                break;
                            }

                            return true;
                        }

                        default:
                        {
                            if (!DoSamplingIntervalTest(true))
                            {
                                Log("WARNING: Re-doing SamplingInterval test to check if random timing glitches were the cause of failure.");
                                result = DoSamplingIntervalTest(false);
                                break;
                            }

                            return true;
                        }
                    }

                    if (!result && m_writeDelayed)
                    {
                        Log("WARNING: Test skipped because the system is likely overloaded and cannot process the requests fast enough.");
                        result = true;
                    }

                    return result;
                }
                finally
                {
                    Session.Notification -= handler;
                }
            }
            finally
            {
                UnlockServer();
            }
        }        
        #endregion
        
        private class TestVariable
        {
            public VariableNode Variable;
            public BuiltInType DataType;
            public VariableNode EURangeNode;
            public Range EURange;
            public List<DataValue> Values;
            public List<DateTime> Timestamps;
            public Dictionary<uint,List<Notification>> Notifications = new Dictionary<uint,List<Notification>>();
            public bool WriteError;
        }

        private class Notification
        {
            public DataValue Value;
            public uint SequenceNumber;
            public DateTime Timestamp;
        }

        /// <summary>
        /// Recursively collects the child variables.
        /// </summary>
        private void AddVariableToTest(VariableNode variable, List<TestVariable> variables, bool numericOnly)
        {
            if (numericOnly)
            {
                BuiltInType builtInType = TypeInfo.GetBuiltInType(variable.DataType, Session.TypeTree);

                if (!TypeInfo.IsNumericType(builtInType))
                {
                    return;
                }
            }

            TestVariable test = new TestVariable();

            test.Variable = variable;
            test.DataType = TypeInfo.GetBuiltInType(variable.DataType, Session.TypeTree);
            test.Values = new List<DataValue>();
            test.Timestamps = new List<DateTime>();
            
            // look up EU range.
            VariableNode euRange = Session.NodeCache.Find(
                variable.NodeId,
                ReferenceTypeIds.HasProperty,
                false,
                false,
                BrowseNames.EURange) as VariableNode;

            if (euRange != null)
            {
                test.EURangeNode = euRange;
            }

            variables.Add(test);
        }

        /// <summary>
        /// Reads the EU range for a variable.
        /// </summary>
        private void ReadEURanges(List<TestVariable> variables)
        {
            ReadValueIdCollection euRanges = new ReadValueIdCollection();

            for (int ii = 0; ii < m_variables.Count; ii++)
            {
                VariableNode variable = m_variables[ii].Variable;

                if (m_variables[ii].EURangeNode != null)
                {
                    ReadValueId rangeToRead = new ReadValueId();
                    rangeToRead.NodeId = m_variables[ii].EURangeNode.NodeId;
                    rangeToRead.AttributeId = Attributes.Value;
                    rangeToRead.Handle = m_variables[ii];
                    euRanges.Add(rangeToRead);
                }
            }

            // lookup the EU range.
            if (euRanges.Count > 0)
            {
                DataValueCollection results;
                DiagnosticInfoCollection diagnosticInfos;
                
                RequestHeader requestHeader = new RequestHeader();
                requestHeader.ReturnDiagnostics = 0;

                ResponseHeader responseHeader = Session.Read(
                    requestHeader,
                    0,
                    TimestampsToReturn.Neither,
                    euRanges,
                    out results,
                    out diagnosticInfos);
                
                ClientBase.ValidateResponse(results, euRanges);
                ClientBase.ValidateDiagnosticInfos(diagnosticInfos, euRanges);

                for (int ii = 0; ii < results.Count; ii++)
                {
                    Range range = ExtensionObject.ToEncodeable(results[ii].Value as ExtensionObject) as Range;
                    TestVariable variable = (TestVariable)euRanges[ii].Handle;
                    variable.EURange = range;
                }
            }
        }

        #region Test Methods
        /// <summary>
        /// Reads an verifies all of the nodes.
        /// </summary>
        private bool DoSamplingIntervalTest(bool modifySamplingInterval)
        {
            // follow tree from each starting node.
            bool success = true;
                                 
            // collection writeable variables that don't change during the test.
            lock (m_variables)
            {
                m_lastWriteTime = DateTime.MinValue;
                m_writeDelayed = false;
                m_writeTimerCounter++;
                m_variables.Clear();

                // collection writeable variables that don't change during the test.
                for (int ii = 0; ii < WriteableVariables.Count; ii++)
                {
                    AddVariableToTest(WriteableVariables[ii], m_variables, false);
                }

                // reduce list based on coverage.
                List<TestVariable> variables = new List<TestVariable>();
                
                int counter = 0;

                foreach (TestVariable variable in m_variables)
                {
                    if (!CheckCoverage(ref counter))
                    {
                        continue;
                    }

                    variables.Add(variable);
                }
                
                // check if there is anything to work with.
                if (variables.Count == 0)
                {
                    Log("WARNING: No writeable variables found.");
                    Log(WriteTest.g_WriteableVariableHelpText);
                    return true;
                }

                m_variables.Clear();
                m_variables.AddRange(variables);

                ReadEURanges(m_variables);

                InitialWrite();

                // check if there is anything to work with.
                if (m_variables.Count == 0)
                {
                    Log("WARNING: No writeable variables found.");
                    Log(WriteTest.g_WriteableVariableHelpText);
                    return true;
                }

                Log("Starting SamplingIntervalTest for {0} Variables ({1}% Coverage, Start={2})", m_variables.Count, Configuration.Coverage, m_variables[0].Variable);

                m_stopped = 0;
                m_writeInterval = 1000;
                m_useDeadbandValues = false;

                m_errorEvent.Reset();
            }
                           
            Subscription subscription = new Subscription();

            subscription.PublishingInterval = 500;
            subscription.PublishingEnabled = true;
            subscription.Priority = 0;
            subscription.KeepAliveCount = 1000;
            subscription.LifetimeCount = 1000;
            subscription.MaxNotificationsPerPublish = 100;
            
            Session.AddSubscription(subscription);    
            subscription.Create();

            m_publishingTime = subscription.CurrentPublishingInterval;

            m_writerTimer = new Timer(DoWrite, m_writeTimerCounter, 0, m_writeInterval);
        
            if (m_errorEvent.WaitOne(1000, false))
            {
                success = false;
            }

            // create monitored items.
            if (success)
            {
                lock (m_variables)
                {
                    m_monitoredItems = new Dictionary<uint,TestVariable>();

                    for (int ii = 0; ii < m_variables.Count; ii++)
                    {
                        // servers that sample data values may not pick up boolean value changes.
                        if (m_variables[ii].DataType == BuiltInType.Boolean)
                        {
                            continue;
                        }

                        VariableNode variable = m_variables[ii].Variable;

                        for (int jj = 2000; jj <= 10000; jj += 1000)
                        {
                            MonitoredItem monitoredItem = new MonitoredItem();

                            monitoredItem.StartNodeId = variable.NodeId;
                            monitoredItem.AttributeId = Attributes.Value;
                            monitoredItem.RelativePath = null;
                            monitoredItem.IndexRange = null;
                            monitoredItem.SamplingInterval = jj;
                            monitoredItem.QueueSize = 0;
                            monitoredItem.DiscardOldest = true;
                            monitoredItem.Filter = null;
                            monitoredItem.MonitoringMode = MonitoringMode.Reporting;
                            monitoredItem.Handle = m_variables[ii];

                            m_variables[ii].Notifications[monitoredItem.ClientHandle] = new List<Notification>();
                            m_monitoredItems[monitoredItem.ClientHandle] = m_variables[ii];

                            subscription.AddItem(monitoredItem);
                        }
                    }
                }

                subscription.ApplyChanges();
                
                // check results.
                foreach (MonitoredItem monitoredItem in subscription.MonitoredItems)
                {
                    if (ServiceResult.IsBad(monitoredItem.Status.Error))
                    {
                        TestVariable variable = monitoredItem.Handle as TestVariable;

                        Log(
                            "Could not create MonitoredItem {0}. NodeId={1}, SamplingInterval={2}",
                            variable.Variable,
                            variable.Variable.NodeId,
                            monitoredItem.SamplingInterval);

                        success = false;
                    }
                }
            }

            // modify sampling interval.
            if (success)
            {      
                if (modifySamplingInterval)
                {
                    if (!ModifySamplingInterval(subscription))
                    {
                        success = false;
                    }
                }
            }

            // wait for first data change.
            if (m_errorEvent.WaitOne(1000, false))
            {
                success = false;
            }

            // wait while values are written.
            lock (m_variables)
            {
                m_writeCount = 0;
                m_startTime = DateTime.UtcNow;
            }

            if (success)
            {
                double increment = MaxProgress/10;
                double position  = 0;

                for (int ii = 0; ii < 20; ii++)
                {               
                    if (m_errorEvent.WaitOne(1000, false))
                    {
                        success = false;
                        break;
                    }

                    position += increment;
                    ReportProgress(position);
                } 
            }

            int writeCount = 0;

            lock (m_variables)
            {
                m_stopped = 1;
                m_endTime = DateTime.UtcNow;
                writeCount = m_writeCount;
                m_writerTimer.Dispose();
                m_writerTimer = null;
            }

            Session.RemoveSubscription(subscription);

            // wait for last data change.
            if (m_errorEvent.WaitOne(1000, false))
            {
                success = false;
            }

            // verify results.
            if (success)
            {
                double duration = CalculateInterval(m_startTime, m_endTime);                
                double expectedWrites = Math.Truncate(duration/m_writeInterval);

                if (Math.Abs(expectedWrites - writeCount) > 1)
                {
                    Log(
                        "WARNING: unexpected number of writes for monitored items: Expected={0}, Actual={1}",
                        expectedWrites,
                        writeCount,
                        duration);
                }

                lock (m_variables)
                {
                    int errorCount = 0;

                    foreach (MonitoredItem monitoredItem in subscription.MonitoredItems)
                    {
                        if (errorCount > 10)
                        {
                            break;
                        }
                        
                        TestVariable variable = (TestVariable)monitoredItem.Handle;

                        if (variable.WriteError)
                        {
                            continue;
                        }

                        IList<Notification> notifications = variable.Notifications[monitoredItem.ClientHandle];
                        
                        // count the number of notifications.
                        int first = -1;

                        for (int ii = 0; ii < notifications.Count; ii++)
                        {
                            if (notifications[ii].Timestamp < m_startTime)
                            {
                                continue;
                            }

                            first = ii;
                        }

                        if (first == -1)
                        {
                            Log(
                                "No notifications for monitored item: {0}, NodeId={1}, SamplingInterval={2}",
                                variable.Variable,
                                variable.Variable.NodeId,
                                monitoredItem.SamplingInterval);

                            success = false;
                            errorCount++;
                            continue;
                        }

                        int actualNotifications = notifications.Count - first;

                        double range = (notifications[notifications.Count-1].Timestamp - notifications[first].Timestamp).TotalMilliseconds;
                        
                        // check that at least one notification was recieved.
                        double expectedNotifications = Math.Truncate(range/monitoredItem.SamplingInterval);

                        if (Math.Abs(expectedNotifications - actualNotifications) > 1)
                        {
                            Log(
                                "Unexpected number of notifications for monitored item: {0}, NodeId={1}, SamplingInterval={2}, Expected={3}, Actual={4}",
                                variable.Variable,
                                variable.Variable.NodeId,
                                monitoredItem.SamplingInterval,
                                expectedNotifications,
                                actualNotifications);

                            StringBuilder buffer = new StringBuilder();
                            buffer.Append("Notifications:\r\n");

                            for (int ii = 0; ii < notifications.Count; ii++)
                            {
                                buffer.AppendFormat(
                                    "[{0}]\t{1:HH:mm:ss.fff}\t{2}\t{3:HH:mm:ss.fff}\r\n",
                                    notifications[ii].SequenceNumber,
                                    notifications[ii].Timestamp,
                                    notifications[ii].Value.WrappedValue,
                                    notifications[ii].Value.SourceTimestamp);
                            }

                            buffer.Append("Values:\r\n");

                            for (int ii = 0; ii < variable.Values.Count; ii++)
                            {
                                buffer.AppendFormat(
                                    "[{0}]\t{1}\t{2:HH:mm:ss.fff}\r\n",
                                    ii,
                                    variable.Values[ii].WrappedValue,
                                    variable.Timestamps[ii]);
                            }

                            Log(buffer.ToString());

                            success = false;
                            errorCount++;
                            continue;
                        }
                   
                        // check timing.
                        if (!CheckNotificationTiming(monitoredItem, variable, notifications))
                        {
                            success = false;
                            errorCount++;
                            continue;
                        }
                    }
                }
            }

            lock (m_variables)
            {
                Log("Completed SamplingIntervalTest for {0} Nodes", m_variables.Count);
            }

            return success;
        }

        /// <summary>
        /// Modifies the sampling interval used.
        /// </summary>
        private bool ModifySamplingInterval(Subscription subscription)
        {
            if (m_errorEvent.WaitOne(500, false))
            {
                return false;
            }

            lock (m_variables)
            {
                for (int ii = 0; ii < m_variables.Count; ii++)
                {
                    foreach (IList<Notification> notification in m_variables[ii].Notifications.Values)
                    {
                        notification.Clear();
                    }
                }

                foreach (MonitoredItem monitoredItem in subscription.MonitoredItems)
                {
                    monitoredItem.SamplingInterval = (int)(monitoredItem.Status.SamplingInterval*2);
                }
            }
            
            subscription.ApplyChanges();

            // check results.
            bool success = true;

            foreach (MonitoredItem monitoredItem in subscription.MonitoredItems)
            {
                if (ServiceResult.IsBad(monitoredItem.Status.Error))
                {
                    TestVariable variable = monitoredItem.Handle as TestVariable;

                    Log(
                        "Could not modify MonitoredItem {0}. NodeId={1}, SamplingInterval={2}",
                        variable.Variable,
                        variable.Variable.NodeId,
                        monitoredItem.SamplingInterval);

                    success = false;
                }
            }

            if (!success)
            {                
                return false;
            }

            if (m_errorEvent.WaitOne(500, false))
            {
                return false;
            }

            return true;
        }
        
        /// <summary>
        /// Reads an verifies all of the nodes.
        /// </summary>
        private bool DoQueueSizeTest(bool modifyQueueSize)
        {
            // follow tree from each starting node.
            bool success = true;
                                 
            // collection writeable variables that don't change during the test.
            lock (m_variables)
            {
                m_lastWriteTime = DateTime.MinValue;
                m_writeDelayed = false;
                m_writeTimerCounter++;
                m_variables.Clear();

                // collection writeable variables that don't change during the test.
                for (int ii = 0; ii < WriteableVariables.Count; ii++)
                {
                    AddVariableToTest(WriteableVariables[ii], m_variables, false);
                }

                // reduce list based on coverage.
                List<TestVariable> variables = new List<TestVariable>();

                int counter = 0;

                foreach (TestVariable variable in m_variables)
                {
                    if (!CheckCoverage(ref counter))
                    {
                        continue;
                    }

                    variables.Add(variable);
                }
                
                // check if there is anything to work with.
                if (variables.Count == 0)
                {
                    Log("WARNING: No writeable variables found.");
                    Log(WriteTest.g_WriteableVariableHelpText);
                    return true;
                }

                m_variables.Clear();
                m_variables.AddRange(variables);

                ReadEURanges(m_variables);

                InitialWrite();

                // check if there is anything to work with.
                if (m_variables.Count == 0)
                {
                    Log("WARNING: No writeable variables found.");
                    Log(WriteTest.g_WriteableVariableHelpText);
                    return true;
                }

                Log("Starting QueueSizeTest for {0} Variables ({1}% Coverage, Start={2})", m_variables.Count, Configuration.Coverage, m_variables[0].Variable);

                m_stopped = 0;
                m_writeInterval = 1000;
                m_useDeadbandValues = false;

                m_errorEvent.Reset();
            }
            
            // create subscription.
            Subscription subscription = new Subscription();

            subscription.PublishingInterval = 5000;
            subscription.PublishingEnabled = true;
            subscription.Priority = 0;
            subscription.KeepAliveCount = 100;
            subscription.LifetimeCount = 100;
            subscription.MaxNotificationsPerPublish = 100;
            
            Session.AddSubscription(subscription);    
            subscription.Create();

            m_publishingTime = subscription.CurrentPublishingInterval;

            m_writerTimer = new Timer(DoWrite, m_writeTimerCounter, 0, m_writeInterval);
        
            if (m_errorEvent.WaitOne(1000, false))
            {
                success = false;
            }
            
            // create monitored items.
            if (success)
            {
                lock (m_variables)
                {
                    m_monitoredItems = new Dictionary<uint,TestVariable>();

                    for (int ii = 0; ii < m_variables.Count; ii++)
                    {
                        // servers that sample data values may not pick up boolean value changes.
                        if (m_variables[ii].DataType == BuiltInType.Boolean)
                        {
                            continue;
                        }

                        VariableNode variable = m_variables[ii].Variable;

                        for (int jj = 0; jj < 8; jj += 2)
                        {
                            MonitoredItem monitoredItem = new MonitoredItem();

                            monitoredItem.StartNodeId = variable.NodeId;
                            monitoredItem.AttributeId = Attributes.Value;
                            monitoredItem.RelativePath = null;
                            monitoredItem.IndexRange = null;
                            monitoredItem.SamplingInterval = 100;
                            monitoredItem.QueueSize = (uint)jj;
                            monitoredItem.DiscardOldest = true;
                            monitoredItem.Filter = null;
                            monitoredItem.MonitoringMode = MonitoringMode.Reporting;
                            monitoredItem.Handle = m_variables[ii];

                            m_variables[ii].Notifications[monitoredItem.ClientHandle] = new List<Notification>();
                            m_monitoredItems[monitoredItem.ClientHandle] = m_variables[ii];

                            subscription.AddItem(monitoredItem);
                        }

                        for (int jj = 2; jj < 8; jj += 2)
                        {
                            MonitoredItem monitoredItem = new MonitoredItem();

                            monitoredItem.StartNodeId = variable.NodeId;
                            monitoredItem.AttributeId = Attributes.Value;
                            monitoredItem.RelativePath = null;
                            monitoredItem.IndexRange = null;
                            monitoredItem.SamplingInterval = 100;
                            monitoredItem.QueueSize = (uint)jj;
                            monitoredItem.DiscardOldest = false;
                            monitoredItem.Filter = null;
                            monitoredItem.MonitoringMode = MonitoringMode.Reporting;
                            monitoredItem.Handle = m_variables[ii];

                            m_variables[ii].Notifications[monitoredItem.ClientHandle] = new List<Notification>();
                            m_monitoredItems[monitoredItem.ClientHandle] = m_variables[ii];

                            subscription.AddItem(monitoredItem);
                        }
                    }
                }

                subscription.ApplyChanges();
                
                // check results.
                foreach (MonitoredItem monitoredItem in subscription.MonitoredItems)
                {
                    if (ServiceResult.IsBad(monitoredItem.Status.Error))
                    {
                        TestVariable variable = monitoredItem.Handle as TestVariable;

                        Log(
                            "Could not create MonitoredItem {0}. NodeId={1}, QueueSize={2}",
                            variable.Variable,
                            variable.Variable.NodeId,
                            monitoredItem.QueueSize);

                        success = false;
                    }
                }
            }

            // modify sampling interval.
            if (success)
            {
                if (modifyQueueSize)
                {
                    if (!ModifyQueueSize(subscription))
                    {
                        success = false;
                    }               
                }
            }

            // wait for first data change.
            if (m_errorEvent.WaitOne(1000, false))
            {
                success = false;
            }

            // wait to write some values.
            lock (m_variables)
            {
                m_writeCount = 0;
                m_startTime = DateTime.UtcNow;
            }
            
            if (success)
            {
                double increment = MaxProgress/10;
                double position  = 0;

                for (int ii = 0; ii < 20; ii++)
                {               
                    if (m_errorEvent.WaitOne(1000, false))
                    {
                        success = false;
                        break;
                    }

                    position += increment;
                    ReportProgress(position);
                }
            }

            int writeCount = 0;

            lock (m_variables)
            {
                m_stopped = 1;
                m_endTime = DateTime.UtcNow;
                writeCount = m_writeCount;
                m_writerTimer.Dispose();
                m_writerTimer = null;
            }

            Session.RemoveSubscription(subscription);

            // wait for last data change.
            if (m_errorEvent.WaitOne(1000, false))
            {
                success = false;
            }

            // validate results.
            if (success)
            {
                double duration = CalculateInterval(m_startTime, m_endTime);                
                double expectedWrites = Math.Truncate(duration/m_writeInterval);

                if (Math.Abs(expectedWrites - writeCount) > 1)
                {
                    Log(
                        "WARNING: unexpected number of writes for monitored items: Expected={0}, Actual={1}",
                        expectedWrites,
                        writeCount);
                }

                lock (m_variables)
                {
                    int errorCount = 0;

                    foreach (MonitoredItem monitoredItem in subscription.MonitoredItems)
                    {
                        if (errorCount > 10)
                        {
                            break;
                        }
                        
                        TestVariable variable = (TestVariable)monitoredItem.Handle;

                        // ignore values if syntax errors occurred.
                        if (variable.WriteError)
                        {
                            continue;
                        }
                        
                        double samplingInterval = monitoredItem.Status.SamplingInterval;
                        uint queueSize = monitoredItem.Status.QueueSize;
                        bool discardOldest = monitoredItem.Status.DiscardOldest;
                        
                        double writesPerPublish = m_publishingTime/m_writeInterval;
                        double totalPublishes = duration/m_publishingTime;

                        IList<Notification> notifications = variable.Notifications[monitoredItem.ClientHandle];
                        
                        int actualNotifications = 0;
                        int beforeIndex = 0;
                        int afterIndex = 0;

                        for (int ii = 0; ii < notifications.Count-1; ii++)
                        {
                            actualNotifications++;

                            Notification before = notifications[ii];
                            Notification after = notifications[ii+1];

                            double gap = CalculateInterval(before.Value.SourceTimestamp, after.Value.SourceTimestamp);
                        
                            // check gap.
                            if (gap > m_writeInterval + samplingInterval + m_maximumTimingError)
                            {
                                bool unexpectedGap = true;

                                if (queueSize <= 1 || after.Value.StatusCode.Overflow || before.Value.StatusCode.Overflow)
                                {
                                    unexpectedGap = false;
                                }

                                if (unexpectedGap)
                                {
                                    Log(
                                        "Too much time between consecutive samples: {0}, NodeId={1}, QueueSize={2}, DiscardOldest={3}, SampleIndex={4}, Gap={5}",
                                        variable.Variable,
                                        variable.Variable.NodeId,
                                        monitoredItem.Status.QueueSize,
                                        monitoredItem.Status.DiscardOldest,
                                        ii,
                                        gap);

                                    success = false;
                                    errorCount++;
                                    continue;
                                }
                            }

                            // find the value that matches the before value.
                            beforeIndex = -1;

                            for (int jj = 0; jj < variable.Values.Count; jj++)
                            {
                                if (m_comparer.CompareVariant(variable.Values[jj].WrappedValue, before.Value.WrappedValue))
                                {
                                    beforeIndex = jj;
                                    break;
                                }
                            }

                            // find the value that matches the after value.
                            afterIndex = -1;

                            for (int jj = beforeIndex+1; jj < variable.Values.Count; jj++)
                            {
                                if (m_comparer.CompareVariant(variable.Values[jj].WrappedValue, after.Value.WrappedValue))
                                {
                                    afterIndex = jj;
                                    break;
                                }
                            }
                                
                            // the final write may not have returned. 
                            if (variable.Timestamps.Count > 0)
                            {
                                if (variable.Timestamps[variable.Timestamps.Count-1] < after.Value.SourceTimestamp)
                                {
                                    continue;
                                }
                            }

                            if (beforeIndex < 0 || afterIndex < 0 || afterIndex <= beforeIndex)
                            {
                                Log(
                                    "Could not find matching value for sample: {0}, NodeId={1}, QueueSize={2}, DiscardOldest={3}, BeforeIndex={4}, AfterIndex={5}",
                                    variable.Variable,
                                    variable.Variable.NodeId,
                                    monitoredItem.Status.QueueSize,
                                    monitoredItem.Status.DiscardOldest,
                                    beforeIndex,
                                    afterIndex);

                                success = false;
                                errorCount++;
                                continue;
                            }

                            // validate consecutive samples.
                            if (afterIndex - beforeIndex == 1)
                            {
                                bool unexpectedOverflow = false;

                                if (discardOldest)
                                {
                                    if (after.Value.StatusCode.Overflow)
                                    {
                                        unexpectedOverflow = true;
                                    }
                                }
                                else
                                {
                                    if (before.Value.StatusCode.Overflow)
                                    {
                                        // overflow possible if the same value is reported scanned many times.
                                        if (CalculateInterval(before.Timestamp, after.Timestamp) < m_publishingTime/2)
                                        {
                                            unexpectedOverflow = true;
                                        }
                                    }
                                }

                                if (unexpectedOverflow)
                                {
                                    Log(
                                        "Unexpected overflow between consecutive samples: {0}, NodeId={1}, QueueSize={2}, DiscardOldest={3}, SampleIndex={4}, Gap={5}",
                                        variable.Variable,
                                        variable.Variable.NodeId,
                                        monitoredItem.Status.QueueSize,
                                        monitoredItem.Status.DiscardOldest,
                                        ii,
                                        gap);

                                    success = false;
                                    errorCount++;
                                    continue;
                                }
                            }
                            else
                            {
                                // check for overflow.
                                bool missingOverflow = false;

                                if (discardOldest)
                                {
                                    if (!after.Value.StatusCode.Overflow)
                                    {
                                        missingOverflow = true;
                                    }
                                }
                                else
                                {
                                    if (!before.Value.StatusCode.Overflow)
                                    {
                                        missingOverflow = true;
                                    }
                                }
                                
                                // check for legimate overflows.
                                if (missingOverflow)
                                {
                                    if (queueSize <= 1)
                                    {
                                        missingOverflow = false;
                                    }
                                    else if (writesPerPublish - queueSize <= 1)
                                    {
                                        missingOverflow = false;
                                    }
                                }

                                if (missingOverflow)
                                {
                                    Log(
                                        "Missing overflow between non-consecutive samples: {0}, NodeId={1}, QueueSize={2}, DiscardOldest={3}, SampleIndex={4}, Gap={5}",
                                        variable.Variable,
                                        variable.Variable.NodeId,
                                        monitoredItem.Status.QueueSize,
                                        monitoredItem.Status.DiscardOldest,
                                        ii,
                                        gap);

                                    success = false;
                                    errorCount++;
                                    continue;
                                }
                            }
                        }
                    }
                }
            }

            lock (m_variables)
            {
                Log("Completed QueueSizeTest for {0} Nodes", m_variables.Count);
            }

            return success;
        }

        /// <summary>
        /// Modifies the queue size for the subscription.
        /// </summary>
        private bool ModifyQueueSize(Subscription subscription)
        {
            if (m_errorEvent.WaitOne(500, false))
            {
                return false;
            }

            lock (m_variables)
            {
                for (int ii = 0; ii < m_variables.Count; ii++)
                {
                    foreach (IList<Notification> notification in m_variables[ii].Notifications.Values)
                    {
                        notification.Clear();
                    }
                }

                foreach (MonitoredItem monitoredItem in subscription.MonitoredItems)
                {
                    monitoredItem.QueueSize = (uint)(monitoredItem.Status.QueueSize/2);
                }
            }
            
            subscription.ApplyChanges();

            // check results.
            bool success = true;

            foreach (MonitoredItem monitoredItem in subscription.MonitoredItems)
            {
                if (ServiceResult.IsBad(monitoredItem.Status.Error))
                {
                    TestVariable variable = monitoredItem.Handle as TestVariable;

                    Log(
                        "Could not modify MonitoredItem {0}. NodeId={1}, SamplingInterval={2}",
                        variable.Variable,
                        variable.Variable.NodeId,
                        monitoredItem.SamplingInterval);

                    success = false;
                }
            }

            if (!success)
            {                
                return false;
            }

            if (m_errorEvent.WaitOne(500, false))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks the error code after specifying a deadband.
        /// </summary>
        private bool CheckDeadbandError(MonitoredItem monitoredItem)
        {
            if (ServiceResult.IsBad(monitoredItem.Status.Error))
            {
                TestVariable variable = monitoredItem.Handle as TestVariable;

                switch (monitoredItem.Status.Error.Code)
                {
                    case StatusCodes.BadMonitoredItemFilterUnsupported:
                    case StatusCodes.BadMonitoredItemFilterInvalid:
                    {
                        return true;
                    }

                    default:
                    {
                        DataChangeFilter filter = (DataChangeFilter)monitoredItem.Filter;

                        Log(
                            "Could not create MonitoredItem {0}. NodeId={1}, DeadbandType={2}, Deadband={3}",
                            variable.Variable,
                            variable.Variable.NodeId,
                            (DeadbandType)filter.DeadbandType,
                            filter.DeadbandValue);

                        return false;
                    }
                }
            }

            return true;
        }
        
        /// <summary>
        /// Reads an verifies all of the nodes.
        /// </summary>
        private bool DoDeadbandTest(bool modifyDeadband)
        {
            // follow tree from each starting node.
            bool success = true;
                                 
            // collection writeable variables that don't change during the test.
            lock (m_variables)
            {
                m_lastWriteTime = DateTime.MinValue;
                m_writeDelayed = false;
                m_writeTimerCounter++;
                m_variables.Clear();

                // collection writeable variables that don't change during the test.
                for (int ii = 0; ii < WriteableVariables.Count; ii++)
                {
                    AddVariableToTest(WriteableVariables[ii], m_variables, true);
                }

                // reduce list based on coverage.
                List<TestVariable> variables = new List<TestVariable>();

                int counter = 0;

                foreach (TestVariable variable in m_variables)
                {
                    if (!CheckCoverage(ref counter))
                    {
                        continue;
                    }

                    variables.Add(variable);
                }

                // check if there is anything to work with.
                if (variables.Count == 0)
                {
                    Log("WARNING: No writeable variables found.");
                    Log(WriteTest.g_WriteableVariableHelpText);
                    return true;
                }

                m_variables.Clear();
                m_variables.AddRange(variables);

                ReadEURanges(m_variables);
                
                InitialWrite();

                // check if there is anything to work with.
                if (m_variables.Count == 0)
                {
                    Log("WARNING: No writeable variables found.");
                    Log(WriteTest.g_WriteableVariableHelpText);
                    return true;
                }

                Log("Starting DeadbandTest for {0} Variables ({1}% Coverage, Start={2})", m_variables.Count, Configuration.Coverage, m_variables[0].Variable);

                m_stopped = 0;
                m_writeInterval = 1000;
                m_deadbandCounter = 0;
                m_useDeadbandValues = true;

                m_errorEvent.Reset();
            }
           
            Subscription subscription = new Subscription();

            subscription.PublishingInterval = 1000;
            subscription.PublishingEnabled = true;
            subscription.Priority = 0;
            subscription.KeepAliveCount = 100;
            subscription.LifetimeCount = 100;
            subscription.MaxNotificationsPerPublish = 100;
            
            Session.AddSubscription(subscription);    
            subscription.Create();

            m_publishingTime = subscription.CurrentPublishingInterval;

            m_writerTimer = new Timer(DoWrite, m_writeTimerCounter, 0, m_writeInterval);
        
            if (m_errorEvent.WaitOne(1000, false))
            {
                success = false;
            }
            
            DataChangeFilter[] filters = new DataChangeFilter[5];

            if (success)
            {                    
                DataChangeFilter filter = new DataChangeFilter();
                filter.DeadbandType = (uint)DeadbandType.Absolute;
                filter.DeadbandValue = 2;
                filter.Trigger = DataChangeTrigger.StatusValue;
                filters[0] = filter;

                filter = new DataChangeFilter();
                filter.DeadbandType = (uint)DeadbandType.Absolute;
                filter.DeadbandValue = 5;
                filter.Trigger = DataChangeTrigger.StatusValue;
                filters[1] = filter;

                filter = new DataChangeFilter();
                filter.DeadbandType  = (uint)DeadbandType.Absolute;
                filter.DeadbandValue = 10;
                filter.Trigger = DataChangeTrigger.StatusValue;
                filters[2] = filter;

                filter = new DataChangeFilter();
                filter.DeadbandType  = (uint)DeadbandType.Percent;
                filter.DeadbandValue = 1;
                filter.Trigger = DataChangeTrigger.StatusValue;
                filters[3] = filter;

                filter = new DataChangeFilter();
                filter.DeadbandType = (uint)DeadbandType.Percent;
                filter.DeadbandValue = 10;
                filter.Trigger = DataChangeTrigger.StatusValue;
                filters[4] = filter;

                lock (m_variables)
                {
                    m_monitoredItems = new Dictionary<uint,TestVariable>();

                    for (int ii = 0; ii < m_variables.Count; ii++)
                    {
                        VariableNode variable = m_variables[ii].Variable;

                        for (int jj = 0; jj < filters.Length; jj++)
                        {
                            if (m_variables[ii].EURange == null && filters[jj].DeadbandType == (uint)DeadbandType.Percent)
                            {
                                continue;
                            }

                            MonitoredItem monitoredItem = new MonitoredItem();

                            monitoredItem.StartNodeId = variable.NodeId;
                            monitoredItem.AttributeId = Attributes.Value;
                            monitoredItem.RelativePath = null;
                            monitoredItem.IndexRange = null;
                            monitoredItem.SamplingInterval = 100;
                            monitoredItem.QueueSize = 0;
                            monitoredItem.DiscardOldest = true;
                            monitoredItem.Filter = filters[jj];
                            monitoredItem.MonitoringMode = MonitoringMode.Reporting;
                            monitoredItem.Handle = m_variables[ii];

                            m_variables[ii].Notifications[monitoredItem.ClientHandle] = new List<Notification>();
                            m_monitoredItems[monitoredItem.ClientHandle] = m_variables[ii];

                            subscription.AddItem(monitoredItem);
                        }
                    }
                }

                subscription.ApplyChanges();
                
                // check results.
                foreach (MonitoredItem monitoredItem in subscription.MonitoredItems)
                {
                    if (!CheckDeadbandError(monitoredItem))
                    {
                        success = false;
                        break;
                    }
                }
            }
            
            // modify sampling interval.
            if (success)
            {       
                if (modifyDeadband)
                {
                    if (!ModifyDeadband(subscription))
                    {
                        success = false;
                    }
                }
            }

            // wait for first data change.
            if (m_errorEvent.WaitOne(1000, false))
            {
                success = false;
            }

            lock (m_variables)
            {
                m_writeCount = 0;
                m_startTime = DateTime.UtcNow;
            }
            
            if (success)
            {
                double increment = MaxProgress/10;
                double position  = 0;

                for (int ii = 0; ii < 20; ii++)
                {               
                    if (m_errorEvent.WaitOne(1000, false))
                    {
                        success = false;
                        break;
                    }

                    position += increment;
                    ReportProgress(position);
                }   
            }
            
            int writeCount = 0;

            lock (m_variables)
            {
                m_stopped = 1;
                m_endTime = DateTime.UtcNow;
                writeCount = m_writeCount;
                m_writerTimer.Dispose();
                m_writerTimer = null;
            }

            Session.RemoveSubscription(subscription);

            // wait for last data change.
            if (m_errorEvent.WaitOne(1000, false))
            {
                success = false;
            }
            
            if (success)
            {
                double duration = CalculateInterval(m_startTime, m_endTime);                
                double expectedWrites = Math.Truncate(duration/m_writeInterval);

                if (Math.Abs(expectedWrites - writeCount) > 1)
                {
                    Log(
                        "WARNING: unexpected number of writes for monitored items: Expected={0}, Actual={1}",
                        expectedWrites,
                        writeCount);
                }

                lock (m_variables)
                {
                    int errorCount = 0;

                    foreach (MonitoredItem monitoredItem in subscription.MonitoredItems)
                    {
                        if (ServiceResult.IsBad(monitoredItem.Status.Error))
                        {
                            continue;
                        }

                        DataChangeFilter filter = monitoredItem.Status.Filter as DataChangeFilter;
                      
                        if (filter == null)
                        {
                            continue;
                        }

                        if (errorCount > 10)
                        {
                            break;
                        }
                        
                        TestVariable variable = (TestVariable)monitoredItem.Handle;
                                                
                        double writesPerPublish = m_publishingTime/m_writeInterval;
                        double totalPublishes = duration/m_publishingTime;

                        Range euRange = variable.EURange;
                        
                        if (euRange != null)
                        {
                            if (euRange.High - euRange.Low <= 0)
                            {
                                Log(
                                    "Invalid EU range for variable {0}. NodeId={1}, EURange={2}, EURange={3}",
                                    variable.Variable,
                                    variable.Variable.NodeId,
                                    variable.EURangeNode.NodeId,
                                    euRange);

                                success = false;
                                errorCount++;
                                continue;
                            }
                        }

                        IList<Notification> notifications = variable.Notifications[monitoredItem.ClientHandle];

                        for (int ii = 0; ii < notifications.Count-1; ii++)
                        {
                            Notification before = notifications[ii];
                            Notification after = notifications[ii+1];

                            decimal difference = CalculateDifference(before.Value.Value, after.Value.Value);

                            if (filter.DeadbandType == (uint)DeadbandType.Absolute)
                            {
                                if (difference < (decimal)filter.DeadbandValue)
                                {
                                    Log(
                                        "Values did not exceed deadband {0}. NodeId={1}, DeadbandType={2}, Deadband={3}, Before={4}, After={5}",
                                        variable.Variable,
                                        variable.Variable.NodeId,
                                        (DeadbandType)filter.DeadbandType,
                                        filter.DeadbandValue,
                                        before.Value.WrappedValue,
                                        after.Value.WrappedValue);

                                    success = false;
                                    errorCount++;
                                    continue;
                                }
                            }

                            if (filter.DeadbandType == (uint)DeadbandType.Percent)
                            {
                                double range = euRange.High - euRange.Low;

                                if (((double)difference)/range < filter.DeadbandValue/range)
                                {
                                    Log(
                                        "Values did not exceed deadband {0}. NodeId={1}, DeadbandType={2}, Deadband={3}, Before={4}, After={5}, EURange={6}",
                                        variable.Variable,
                                        variable.Variable.NodeId,
                                        (DeadbandType)filter.DeadbandType,
                                        filter.DeadbandValue,
                                        before.Value.WrappedValue,
                                        after.Value.WrappedValue,
                                        euRange);

                                    success = false;
                                    errorCount++;
                                    continue;
                                }
                            }
                        }
                    }
                }
            }

            lock (m_variables)
            {
                Log("Completed DeadbandTest for {0} Nodes", m_variables.Count);
            }

            return success;
        }

        /// <summary>
        /// Modifies the deadband.
        /// </summary>
        private bool ModifyDeadband(Subscription subscription)
        {
            if (m_errorEvent.WaitOne(500, false))
            {
                return false;
            }

            lock (m_variables)
            {
                for (int ii = 0; ii < m_variables.Count; ii++)
                {
                    foreach (IList<Notification> notification in m_variables[ii].Notifications.Values)
                    {
                        notification.Clear();
                    }
                }

                foreach (MonitoredItem monitoredItem in subscription.MonitoredItems)
                {
                    DataChangeFilter filter =(DataChangeFilter)monitoredItem.Filter;
                    filter.DeadbandValue /= 2;
                    monitoredItem.Filter = filter;
                }
            }
            
            subscription.ApplyChanges();

            // check results.
            bool success = true;

            foreach (MonitoredItem monitoredItem in subscription.MonitoredItems)
            {
                if (!CheckDeadbandError(monitoredItem))
                {
                    success = false;
                    break;
                }
            }

            if (!success)
            {                
                return false;
            }

            if (m_errorEvent.WaitOne(500, false))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Calculates the difference between two values.
        /// </summary>
        private decimal CalculateDifference(object before, object after)
        {
            try
            {
                if (before is Array)
                {
                    object element1 = ((Array)before).GetValue(1);
                    object element2 = ((Array)after).GetValue(1);

                    return CalculateDifference(element1, element2);
                }

                if (typeof(Variant).IsInstanceOfType(before))
                {
                    object element1 = ((Variant)before).Value;
                    object element2 = ((Variant)after).Value;

                    return CalculateDifference(element1, element2);
                }

                if (before is double)
                {
                    double double1 = Convert.ToDouble(before);
                    double double2 = Convert.ToDouble(after);

                    return Convert.ToDecimal(double2 - double1);
                }

                decimal value1 = Convert.ToDecimal(before);
                decimal value2 = Convert.ToDecimal(after);

                return Math.Abs(value2 - value1);
            }
            catch 
            {
                return 0;
            }
        }

        void Session_Notification(Session session, NotificationEventArgs e)
        {
            try
            {  
                lock (m_variables)
                {
                    NotificationMessage message = e.NotificationMessage;

                    // check for keep alive.
                    if (message.NotificationData.Count == 0)
                    {
                        return;
                    }
                
                    int count = 0;

                    foreach (ExtensionObject extension in message.NotificationData)
                    {
                        if (ExtensionObject.IsNull(extension))
                        {
                            continue;
                        }

                        DataChangeNotification datachange = extension.Body as DataChangeNotification;
                                        
                        if (datachange == null)
                        {
                            continue;
                        }

                        /*
                        Log(
                            "NOTIFICATION: [{0}]\t{1:HH:mm:ss.fff}\t{2:HH:mm:ss.fff}\t{3}", 
                            message.SequenceNumber, 
                            message.PublishTime, 
                            DateTime.UtcNow, 
                            datachange.MonitoredItems.Count);
                        */

                        for (int ii = 0; ii < datachange.MonitoredItems.Count; ii++)
                        {
                            count++;

                            MonitoredItemNotification notification = datachange.MonitoredItems[ii];
                            TestVariable variable = null;

                            if (m_monitoredItems.TryGetValue(notification.ClientHandle, out variable))
                            {
                                List<Notification> notifications = variable.Notifications[notification.ClientHandle];

                                Notification record = new Notification();
                         
                                record.Value = notification.Value;
                                record.SequenceNumber = message.SequenceNumber;
                                record.Timestamp = DateTime.UtcNow;

                                for (int jj = notifications.Count-1; jj >= 0 ; jj--)
                                {
                                    if (notifications[jj].SequenceNumber == record.SequenceNumber)
                                    {
                                        if (notifications[jj].Value.SourceTimestamp == record.Value.SourceTimestamp)
                                        {
                                            notifications[jj] = record;
                                            record = null;
                                            break;
                                        }
                                    }
                                    
                                    if (notifications[jj].SequenceNumber <= record.SequenceNumber)
                                    {
                                        if (jj < notifications.Count-1)
                                        {
                                            notifications.Insert(jj+1, record);
                                        }
                                        else
                                        {
                                            notifications.Add(record);
                                        }

                                        record = null;
                                        break;
                                    }
                                    
                                    if (jj == 0 && notifications[jj].SequenceNumber > record.SequenceNumber)
                                    {
                                        notifications.Insert(0, record);
                                        record = null;
                                        break;
                                    }
                                }

                                if (record != null)
                                {
                                    notifications.Add(record);
                                }
                            }
                        }
                    }
                    
                    // Utils.Trace("NotificationMessage #{0} DataCount={1} NotificationCount={2}", message.SequenceNumber, message.NotificationData.Count, count);
                }
            }
            catch (Exception exception)
            {
                HaltTestOnError(exception, "Fatal while processing a notification.", null);
            }
        }

        /// <summary>
        /// Checks the timing for notifications.
        /// </summary>
        private bool CheckNotificationTiming(MonitoredItem monitoredItem, TestVariable variable, IList<Notification> notifications)
        {
            bool success = true;

            for (int ii = 0; ii < notifications.Count; ii++)
            {
                double delta = CalculateInterval(notifications[ii].Timestamp, notifications[ii].Value.SourceTimestamp);

                if (delta > monitoredItem.Status.SamplingInterval + 500)
                {
                    Log(
                        "TIMING: Incorrect time for notificiation {0}. NodeId = {1}, Sample={2}, Actual={3}",
                        variable.Variable,
                        variable.Variable.NodeId,
                        ii,
                        delta);

                    success = false;
                }                
            }

            double minDelta = monitoredItem.Status.SamplingInterval;
            double maxDelta = monitoredItem.Status.SamplingInterval*2 + m_publishingTime + m_writeInterval;

            for (int ii = 0; ii < notifications.Count-2; ii++)
            {
                DateTime firstValue = notifications[ii].Value.SourceTimestamp;
                DateTime nextValue  = notifications[ii+2].Value.SourceTimestamp;

                double delta = CalculateInterval(firstValue, nextValue);

                if (delta < minDelta || delta > maxDelta)
                {
                    /*
                    Log(
                        "TIMING: Incorrect time for notificiation {0}. NodeId = {1}, Sample={2}, Min={3}, Actual={4}, Max={5}",
                        variable.Variable,
                        variable.Variable.NodeId,
                        ii,
                        minDelta,
                        delta,
                        maxDelta);

                    StringBuilder buffer = new StringBuilder();
                    buffer.AppendFormat("{0} ({1}):", variable.Variable, notifications.Count);

                    for (int jj = 0; jj < notifications.Count; jj++)
                    {    
                        double delta1 = 0;
                        double delta2 = 0;
                        
                        if (jj > 0)
                        {
                            delta1 = CalculateInterval(notifications[jj-1].Value.SourceTimestamp, notifications[jj].Value.SourceTimestamp);
                        
                            if (jj < notifications.Count-1)
                            {
                                delta2 = CalculateInterval(notifications[jj-1].Value.SourceTimestamp, notifications[jj+1].Value.SourceTimestamp);
                            }
                        }

                        buffer.AppendFormat(
                            "\r\n{0} - {1:ss.fff} - {2:ss.fff} - {3}ms - {4}ms", 
                            jj,
                            notifications[jj].Value.SourceTimestamp,
                            notifications[jj].Timestamp,
                            delta1,
                            delta2);
                    }
                    
                    Log(buffer.ToString());
                    
                    return false;
                    */

                    break;
                }
            }

            return success;
        }

        /// <summary>
        /// Checks that the correct values were returned.
        /// </summary>
        private bool CheckReturnedValues(MonitoredItem monitoredItem, TestVariable variable, IList<Notification> notifications)
        {
            // ignore values if syntax errors occurred.
            if (variable.WriteError)
            {
                return true;
            }

            for (int ii = 0; ii < notifications.Count; ii++)
            {
                bool match = false;

                for (int jj = 0; jj < variable.Values.Count; jj++)
                {
                    // must match any value change during the sampling period.
                    if (variable.Timestamps[jj] < notifications[ii].Timestamp.AddMilliseconds(-monitoredItem.Status.SamplingInterval-(2*m_publishingTime)-m_maximumTimingError))
                    {
                        continue;
                    }
                    
                    // cannot match values after the time of notification.
                    if (variable.Timestamps[jj] >= notifications[ii].Timestamp)
                    {
                        match = false;
                        break;
                    }
                    
                    // check for match.
                    match = m_comparer.CompareVariant(variable.Values[jj].WrappedValue, notifications[ii].Value.WrappedValue);

                    if (match)
                    {
                        break;
                    }
                }

                if (!match)
                {
                    Log(
                        "Value does not match written value for MonitoredItem {0}. NodeId={1}, SamplingInterval={2}, Actual={3}",
                        variable.Variable,
                        variable.Variable.NodeId,
                        monitoredItem.SamplingInterval,
                        notifications[ii].Value.WrappedValue);
                    
                    return false;
                }
            }

            return true;
        }
        #endregion

        /// <summary>
        /// Periodically writes to the server.
        /// </summary>
        private void DoWrite(object state)
        {
            try
            {
                int? counter = state as int?;

                lock (m_variables)
                {
                    if (counter == null || counter != m_writeTimerCounter)
                    {
                        return;
                    }

                    if (m_stopped != 0)
                    {
                        return;
                    }
                }

                bool success = Write(counter.Value);
                                
                if (!success)
                {
                    HaltTestOnError(null, "Error occurred while writing values.", null);
                    return;
                }
            }
            catch (Exception e)
            {
                HaltTestOnError(e, "Fatal error while writing values.", null);
            }
        }
        
        /// <summary>
        /// Halts the test after an error occurred.
        /// </summary>
        private void HaltTestOnError(Exception e, string format, params object[] args)
        {
            if (Interlocked.CompareExchange(ref m_stopped, 1, 0) == 0)
            {
                try
                {
                    m_errorEvent.Set();

                    if (e != null)
                    {
                        Log(e, format, args);
                    }
                    else
                    {
                        Log(format, args);
                    }
                }
                catch (Exception)
                {
                    // guard against stray publish reponses during debugging.
                }
            }
        }

        /// <summary>
        /// Returns a new value.
        /// </summary>
        private object IncrementValue(TestVariable variable, double counter)
        {
            BuiltInType builtInType = TypeInfo.GetBuiltInType(variable.Variable.DataType, Session.TypeTree);
            
            Range range = variable.EURange;

            if (range == null)
            {
                switch (builtInType)
                {
                    case BuiltInType.SByte:
                    {
                        range = new Range(SByte.MaxValue, 0);
                        break;
                    }

                    case BuiltInType.Byte:
                    {
                        range = new Range(Byte.MaxValue, 0);
                        break;
                    }

                    case BuiltInType.Int16:
                    {
                        range = new Range(Int16.MaxValue, 0);
                        break;
                    }

                    case BuiltInType.UInt16:
                    {
                        range = new Range(UInt16.MaxValue, 0);
                        break;
                    }
                        
                    case BuiltInType.Integer:
                    case BuiltInType.Int32:
                    {
                        range = new Range(Int32.MaxValue, 0);
                        break;
                    }

                    default:
                    {
                        range = new Range(Int32.MaxValue, 0);
                        break;
                    }
                }
            }

            if (counter > range.High)
            {
                counter = 0;
            }

            if (counter < range.Low)
            {
                counter = range.Low;
            }

            object value = TypeInfo.Cast(counter, builtInType);
            
            if (variable.Variable.ValueRank < 0)
            {
                return value;
            }
            
            Array array = TypeInfo.CreateArray(builtInType, 3);

            if (array.GetType().GetElementType() == typeof(Variant))
            {
                array.SetValue(new Variant(value), 0);
                array.SetValue(new Variant(value), 1);
                array.SetValue(new Variant(value), 2);
            }
            else
            {
                array.SetValue(value, 0);
                array.SetValue(value, 1);
                array.SetValue(value, 2);
            }

            return array;
        }

        /// <summary>
        /// Ensures the value is within the EU Range.
        /// </summary>
        private object EnsureInRange(object value, VariableNode variable, Range range)
        {
            try
            {
                if (range == null || range.High <= range.Low)
                {
                    return value;
                }

                int number = 0;
                uint spread = (uint)(Math.Truncate(range.High - range.Low) + 1);

                BuiltInType builtInType = TypeInfo.GetBuiltInType(variable.DataType);

                Array array = value as Array;                

                if (array != null)
                {
                    bool isVariant = typeof(Variant) == array.GetType().GetElementType();

                    for (int ii = 0; ii < array.Length; ii++)
                    {
                        number = (int)(m_generator.GetRandom<uint>(false)%spread) + (int)range.Low;

                        object element = TypeInfo.Cast(number, builtInType);

                        if (isVariant)
                        {
                            element = new Variant(element);
                        }

                        array.SetValue(element, ii);
                    }

                    return array;
                }
                            
                number = (int)(m_generator.GetRandom<uint>(false)%spread) + (int)range.Low;

                return TypeInfo.Cast(number, builtInType);
            }
            catch (Exception)
            {
                return value;
            }
        }

        /// <summary>
        /// Removes nodes that are not actually writeable.
        /// </summary>
        private void InitialWrite()
        {
            WriteValueCollection nodesToWrite = new WriteValueCollection();

            lock (m_variables)
            {
                for (int ii = 0; ii < m_variables.Count; ii++)
                {
                    TestVariable variable = m_variables[ii];
                    WriteValue nodeToWrite = new WriteValue();

                    nodeToWrite.NodeId = variable.Variable.NodeId;
                    nodeToWrite.AttributeId = Attributes.Value;

                    DataValue value = new DataValue();

                    if (!m_useDeadbandValues)
                    {
                        bool different = false;

                        do
                        {
                            value.Value = m_generator.GetRandom(
                                variable.Variable.DataType,
                                variable.Variable.ValueRank,
                                variable.Variable.ArrayDimensions,
                                Session.TypeTree);

                            if (variable.EURange != null)
                            {
                                value.Value = EnsureInRange(value.Value, variable.Variable, variable.EURange);
                            }

                            different = true;

                            for (int jj = variable.Values.Count - 1; jj >= 0; jj--)
                            {
                                if (m_comparer.CompareVariant(value.WrappedValue, variable.Values[jj].WrappedValue))
                                {
                                    different = false;
                                    break;
                                }

                                if (variable.DataType == BuiltInType.Boolean)
                                {
                                    break;
                                }
                            }
                        }
                        while (!different);
                    }

                    else
                    {
                        value.Value = IncrementValue(variable, m_deadbandCounter);
                    }

                    value.StatusCode = StatusCodes.Good;
                    value.ServerTimestamp = DateTime.MinValue;
                    value.SourceTimestamp = DateTime.MinValue;

                    nodeToWrite.Value = value;
                    nodeToWrite.Handle = variable.Values.Count;

                    nodesToWrite.Add(nodeToWrite);

                    variable.Values.Add(value);
                    variable.Timestamps.Add(DateTime.MinValue);
                }
            }

            StatusCodeCollection results;
            DiagnosticInfoCollection diagnosticInfos;

            DateTime now = DateTime.UtcNow;

            RequestHeader requestHeader = new RequestHeader();
            requestHeader.ReturnDiagnostics = 0;

            // need to check if the test completes and the next one starts while the write is in progress.
            ResponseHeader responseHeader = Session.Write(
                requestHeader,
                nodesToWrite,
                out results,
                out diagnosticInfos);

            ClientBase.ValidateResponse(results, nodesToWrite);
            ClientBase.ValidateDiagnosticInfos(diagnosticInfos, nodesToWrite);

            // check diagnostics.
            if (diagnosticInfos != null && diagnosticInfos.Count > 0)
            {
                Log("Returned non-empty DiagnosticInfos array during Write.");
                return;
            }

            // check results.
            lock (m_variables)
            {
                List<TestVariable> writeableVariables = new List<TestVariable>();

                for (int ii = 0; ii < nodesToWrite.Count; ii++)
                {
                    if (StatusCode.IsGood(results[ii]))
                    {
                        m_variables[ii].WriteError = false;
                        writeableVariables.Add(m_variables[ii]);
                    }
                }

                m_variables.Clear();
                m_variables.AddRange(writeableVariables);
            }
        }

        /// <summary>
        /// Reads the attributes, verifies the results and updates the nodes.
        /// </summary>
        private bool Write(int counter)
        {
            bool success = true;
            m_deadbandCounter++;
            
            WriteValueCollection nodesToWrite = new WriteValueCollection();

            lock (m_variables)
            {
                if (m_stopped != 0 || counter != m_writeTimerCounter)
                {
                    return true;
                }

                for (int ii = 0; ii < m_variables.Count; ii++)
                {        
                    TestVariable variable = m_variables[ii];
                    WriteValue nodeToWrite = new WriteValue();
                
                    nodeToWrite.NodeId = variable.Variable.NodeId;
                    nodeToWrite.AttributeId = Attributes.Value;

                    DataValue value = new DataValue();
                    
                    if (!m_useDeadbandValues)
                    {
                        bool different = false;

                        do
                        {                        
                            value.Value = m_generator.GetRandom(
                                variable.Variable.DataType,
                                variable.Variable.ValueRank,
                                variable.Variable.ArrayDimensions,
                                Session.TypeTree);

                            if (variable.EURange != null)
                            {
                                value.Value = EnsureInRange(value.Value, variable.Variable, variable.EURange);
                            }

                            different = true;

                            for (int jj = variable.Values.Count-1; jj >= 0; jj--)
                            {
                                if (m_comparer.CompareVariant(value.WrappedValue, variable.Values[jj].WrappedValue))
                                {
                                    different = false;
                                    break;
                                }

                                if (variable.DataType == BuiltInType.Boolean)
                                {
                                    break;
                                }
                            }
                        }
                        while (!different);
                    }
                    
                    else
                    {
                        value.Value = IncrementValue(variable, m_deadbandCounter);
                    }

                    value.StatusCode = StatusCodes.Good;
                    value.ServerTimestamp = DateTime.MinValue;
                    value.SourceTimestamp = DateTime.MinValue;

                    nodeToWrite.Value = value;
                    nodeToWrite.Handle = variable.Values.Count;

                    nodesToWrite.Add(nodeToWrite);

                    variable.Values.Add(value);
                    variable.Timestamps.Add(DateTime.MinValue);
                }

                m_lastWriteTime = DateTime.UtcNow;
            }

            StatusCodeCollection results;
            DiagnosticInfoCollection diagnosticInfos;

            DateTime now = DateTime.UtcNow;

            RequestHeader requestHeader = new RequestHeader();
            requestHeader.ReturnDiagnostics = 0;

            // need to check if the test completes and the next one starts while the write is in progress.
            ResponseHeader responseHeader = Session.Write(
                requestHeader,
                nodesToWrite,
                out results,
                out diagnosticInfos);

            ClientBase.ValidateResponse(results, nodesToWrite);
            ClientBase.ValidateDiagnosticInfos(diagnosticInfos, nodesToWrite);
            
            // check diagnostics.
            if (diagnosticInfos != null && diagnosticInfos.Count > 0)
            {
                Log("Returned non-empty DiagnosticInfos array during Write.");
                return false;
            }

            // check results.
            lock (m_variables)
            {
                if (m_lastWriteTime > DateTime.MinValue && (DateTime.UtcNow - m_lastWriteTime).TotalMilliseconds > 300)
                {
                    m_writeDelayed = true;
                    Log("WARNING: A Write operation took {0}s. Test results may not be meaningful.", (DateTime.UtcNow - m_lastWriteTime).TotalSeconds);
                }

                m_lastWriteTime = DateTime.UtcNow;

                if (m_stopped != 0 || counter != m_writeTimerCounter)
                {
                    return true;
                }

                for (int ii = 0; ii < nodesToWrite.Count; ii++)
                {
                    TestVariable variable = m_variables[ii];

                    if (StatusCode.IsBad(results[ii]))
                    {
                        if (results[ii] == StatusCodes.BadTypeMismatch || results[ii] == StatusCodes.BadOutOfRange)
                        {
                            variable.WriteError = true;
                            continue;
                        }

                        Log("Unexpected error during Write.");
                        return false;
                    }

                    WriteValue request = nodesToWrite[ii];

                    variable.Timestamps[(int)request.Handle] = responseHeader.Timestamp;
                }

                m_writeCount++;
            }
            
            return success;
        }

        #region Private Fields
        private ManualResetEvent m_errorEvent;
        private int m_stopped;
        private int m_maximumTimingError;
        private Opc.Ua.Test.DataGenerator m_generator;
        private Opc.Ua.Test.DataComparer m_comparer;
        private List<TestVariable> m_variables;
        private Dictionary<uint,TestVariable> m_monitoredItems;
        private Timer m_writerTimer;
        private DateTime m_startTime;
        private DateTime m_endTime;
        private double m_publishingTime;
        private int m_writeInterval;
        private int m_writeCount;
        private double m_deadbandCounter;
        private int m_writeTimerCounter;
        private bool m_useDeadbandValues;
        private bool m_writeDelayed;
        private DateTime m_lastWriteTime;
        #endregion
    }
}
