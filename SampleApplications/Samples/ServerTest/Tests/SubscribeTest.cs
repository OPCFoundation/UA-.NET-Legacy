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
    internal class SubscribeTest : TestBase
    {
        #region Constructors
        /// <summary>
        /// Creates the test object.
        /// </summary>
        public SubscribeTest(
            Session session,
            ServerTestConfiguration configuration,
            ReportMessageEventHandler reportMessage,
            ReportProgressEventHandler reportProgress,
            TestBase template)
        : 
            base("Subscribe", session, configuration, reportMessage, reportProgress, template)
        {
            m_subscriptions = new List<Subscription>();
            m_errorEvent = new ManualResetEvent(false);
            m_acknowledgements = new SubscriptionAcknowledgementCollection();
            m_publishPipelineDepth = 10;
            m_idealTimingError = 400;
            m_maximumTimingError = 500;
        }
        #endregion
        
        #region Public Methods
        /// <summary>
        /// Runs the test
        /// </summary>
        public override bool Run(ServerTestCase testcase, int iteration)
        {
            Iteration = iteration;

            // do secondary test.
            switch (testcase.Name)
            {
                case "PublishingInterval":
                {
                    if (!DoPublishingIntervalTest())
                    {
                        Log("WARNING: Re-doing PublishingInterval test to check if random timing glitches were the cause of failure.");
                        return DoPublishingIntervalTest();
                    }

                    return true;
                }

                case "CreateItems":
                {
                    // need fetch nodes used for the test if not already available.
                    if (AvailableNodes.Count == 0)
                    {
                        if (!GetNodesInHierarchy())
                        {
                            return false;
                        }
                    }

                    return DoCreateItemsTest();
                }

                default:
                {
                    if (!DoKeepAliveTest())
                    {
                        Log("WARNING: Re-doing KeepAlive test to check if random timing glitches were the cause of failure.");
                        return DoKeepAliveTest();
                    }

                    return true;
                }
            }
        }        
        #endregion
        
        #region Test Methods
        /// <summary>
        /// Reads an verifies all of the nodes.
        /// </summary>
        private bool DoKeepAliveTest()
        {
            // follow tree from each starting node.
            bool success = true;
                     
            Log("Starting KeepAliveTest. PipelineDepth = {0}, OutstandingRequests = {1}", m_publishPipelineDepth, m_outstandingPublishRequests);
            
            double increment = MaxProgress/8;
            double position  = 0;
            ReportProgress(position);

            // create subscription.
            Interlocked.Exchange(ref m_publishCount, 0);
            Interlocked.Exchange(ref m_stopped, 0);
                        
            for (int ii = 1000; ii <= 10000; ii += 1000)
            {
                try
                {
                    CreateSubscription(
                        ii,
                        (uint)(60000/ii),
                        2,
                        0,
                        true,
                        0);
                }
                catch (Exception e)
                {
                    success = false;
                    Log(e, "KeepAliveTest Failed while creating subsciptions.");
                }
            }
            
            position += increment;
            ReportProgress(position);
            Log("Created {0} subscriptions.", m_subscriptions.Count);

            m_errorEvent.Reset();

            bool publishingEnabled = true;

            for (int ii = 0; ii < 6; ii++)
            {
                if (m_errorEvent.WaitOne(5000, false))
                {
                    success = false;
                    Log("KeepAliveTest exiting because of an error during publishing.", null);
                    break;
                }

                Log("{0} publish responses received. Publishing Enabled = {1}", m_publishCount, publishingEnabled);
                
                // toggle publishing enabled.
                publishingEnabled = !publishingEnabled;

                if (!SetPublishingEnabled(publishingEnabled))
                {
                    success = false;
                    break;
                }
                
                position += increment;
                ReportProgress(position);
            }

            // delete.
            if (!DeleteSubscriptions())
            {
                success = false;
            }

            // stop publish threads.
            Interlocked.CompareExchange(ref m_stopped, 1, 0);
            Log("Deleted subscriptions.");

            // verify test results.
            lock (m_subscriptions)
            {
                if (success)
                {
                    for (int ii = 0; ii < m_subscriptions.Count; ii++)
                    {
                        Subscription subscription = m_subscriptions[ii];

                        lock (subscription)
                        {
                            if (!VerifyKeepAliveTestResults(subscription))
                            {
                                success = false;
                            }
                        }
                    }
                }

                m_subscriptions.Clear();
            }

            position += increment;
            ReportProgress(position);

            return success;
        }
        
        /// <summary>
        /// Reads an verifies all of the nodes.
        /// </summary>
        private bool DoPublishingIntervalTest()
        {
            // follow tree from each starting node.
            bool success = true;
                     
            Log("Starting PublishingIntervalTest. PipelineDepth = {0}, OutstandingRequests = {1}", m_publishPipelineDepth, m_outstandingPublishRequests);
            
            double increment = MaxProgress/6;
            double position  = 0;
            ReportProgress(position);

            // create subscription.
            Interlocked.Exchange(ref m_publishCount, 0);
            Interlocked.Exchange(ref m_stopped, 0);
                        
            for (int ii = 0; ii < 10; ii++)
            {
                try
                {
                    CreateSubscription(
                        1000,
                        60,
                        (uint)(ii%6)+2,
                        0,
                        true,
                        0);
                }
                catch (Exception e)
                {
                    success = false;
                    Log(e, "KeepAliveTest Failed while creating subsciptions.");
                }
            }
            
            position += increment;
            ReportProgress(position);
            Log("Created {0} subscriptions.", m_subscriptions.Count);

            m_errorEvent.Reset();

            double publishingInterval = 1000;

            for (int ii = 0; ii < 3; ii++)
            {
                if (m_errorEvent.WaitOne(10000, false))
                {
                    success = false;
                    Log("KeepAliveTest exiting because of an error during publishing.", null);
                    break;
                }

                Log("{0} publish responses received. Publishing Interval = {1}", m_publishCount, publishingInterval);
                
                // change publishing interval.
                publishingInterval = (publishingInterval == 1000)?2000:1000;
                
                List<Subscription> subscriptions = new List<Subscription>();

                lock (m_subscriptions)
                {
                    subscriptions = new List<Subscription>(m_subscriptions);
                }

                for (int jj = 0; jj < subscriptions.Count; jj++)
                {
                    if (!ModifySubscription(subscriptions[jj], publishingInterval))
                    {
                        success = false;
                    }
                }
            
                position += increment;
                ReportProgress(position);
            }

            // delete.
            if (!DeleteSubscriptions())
            {
                success = false;
            }

            // stop publish threads.
            Interlocked.CompareExchange(ref m_stopped, 1, 0);
            Log("Deleted subscriptions.");

            // verify test results.
            lock (m_subscriptions)
            {
                if (success)
                {
                    for (int ii = 0; ii < m_subscriptions.Count; ii++)
                    {
                        Subscription subscription = m_subscriptions[ii];

                        lock (subscription)
                        {
                            if (!VerifyKeepAliveTestResults(subscription))
                            {
                                success = false;
                            }
                        }
                    }
                }

                m_subscriptions.Clear();
            }

            position += increment;
            ReportProgress(position);

            return success;
        }

        /// <summary>
        /// Creates subscription, adds items and verifies that the initial update arrives.
        /// </summary>
        private bool DoCreateItemsTest()
        {
            // follow tree from each starting node.
            bool success = true;
                     
            double increment = MaxProgress/AvailableNodes.Count;
            double position  = 0;

            Log("Starting CreateItemsTest for {0} Nodes ({1}% Coverage). PipelineDepth = {2}, OutstandingRequests = {3}", AvailableNodes.Values.Count, Configuration.Coverage, m_publishPipelineDepth, m_outstandingPublishRequests);

            // create subscription.
            Interlocked.Exchange(ref m_publishCount, 0);
            Interlocked.Exchange(ref m_stopped, 0);

            m_errorEvent.Reset();

            if (!CreateSubscription(1000, 100, 10, 0, true, 0))
            {
                return false;
            }

            uint[] attributeIds = Attributes.GetIdentifiers();
            
            int nodes = 0;
            int operations = 0;
            
            MonitoredItemCreateRequestCollection itemsToCreate = new MonitoredItemCreateRequestCollection();

            int counter = 0;

            foreach (Node node in AvailableNodes.Values)
            {         
                if (!CheckCoverage(ref counter))
                {
                    continue;
                }
                         
                nodes++;

                AddMonitoredItems(node, itemsToCreate, attributeIds);

                // process batch.
                if (itemsToCreate.Count > BlockSize)
                {
                    operations += itemsToCreate.Count;

                    if (!Subscribe(m_subscriptions[0], itemsToCreate))
                    {
                        Log("WARNING: CreateItemsTest failed. Trying it again do check for random timing errors.");

                        if (!Subscribe(m_subscriptions[0], itemsToCreate))
                        {
                            success = false;
                            break;
                        }
                    }

                    itemsToCreate.Clear();

                    if (nodes > AvailableNodes.Count/5)
                    {
                        Log("Subscribed to {0} attribute values for {1} nodes.", operations, nodes);
                        nodes = 0;
                        operations = 0;
                    }
                }

                position += increment;
                ReportProgress(position);
            }   
         
            // process final batch.
            if (success)
            {
                if (itemsToCreate.Count > 0)
                {
                    operations += itemsToCreate.Count;

                    if (!Subscribe(m_subscriptions[0], itemsToCreate))
                    {
                        Log("WARNING: CreateItemsTest failed. Trying it again do check for random timing errors.");

                        if (!Subscribe(m_subscriptions[0], itemsToCreate))
                        {
                            success = false;
                        }
                    }

                    if (success)
                    {
                        Log("Subscribed to {0} attribute values for {1} nodes.", operations, nodes);
                    }
                }
            }

            // delete subscriptions.
            if (!DeleteSubscriptions())
            {
                success = false;
            }

            Interlocked.CompareExchange(ref m_stopped, 1, 0);
            Log("Deleted subscriptions.");

            lock (m_subscriptions)
            {
                m_subscriptions.Clear();
            }

            return success;
        }
        
        /// <summary>
        /// Adds the MonitoredItems to the request collection.
        /// </summary>
        private void AddMonitoredItems(
            Node node, 
            MonitoredItemCreateRequestCollection itemsToCreate, 
            params uint[] attributeIds)
        {
            if (attributeIds != null)
            {
                for (int ii = 0; ii < attributeIds.Length; ii++)
                {
                    MonitoredItemCreateRequest request = new MonitoredItemCreateRequest();

                    request.ItemToMonitor.NodeId = node.NodeId;
                    request.ItemToMonitor.AttributeId = attributeIds[ii];
                    request.MonitoringMode = MonitoringMode.Reporting;
                    request.RequestedParameters.ClientHandle = ++m_lastClientHandle;
                    request.RequestedParameters.SamplingInterval = 6000000;
                    request.RequestedParameters.QueueSize = 0;
                    request.RequestedParameters.DiscardOldest = true;
                    request.RequestedParameters.Filter = null;
                    request.Handle = node;

                    itemsToCreate.Add(request);
                }
            }
        }

        /// <summary>
        /// Adds the items to subscription. Verifies the initial update.
        /// </summary>
        private bool Subscribe(Subscription subscription, MonitoredItemCreateRequestCollection itemsToCreate)
        {
            bool success = true;

            try
            {
                List<MonitoredItem> monitoredItems = new List<MonitoredItem>();

                if (!CreateMonitoredItems(subscription, itemsToCreate, monitoredItems))
                {
                    success = false;
                }

                if (success)
                {
                    if (!WaitForUpdates(subscription, monitoredItems, false))
                    {
                        success = false;
                    }
                }

                if (success)
                {
                    if (!ToogleDisabledState(subscription, monitoredItems))
                    {
                        success = false;
                    }
                }
                
                if (success)
                {
                    if (!WaitForUpdates(subscription, monitoredItems, true))
                    {
                        success = false;
                    }
                }

                if (!DeleteMonitoredItems(subscription, monitoredItems))
                {
                    success = false;
                }

                lock (subscription)
                {
                    subscription.NotificationMessages.Clear();
                    subscription.ReceiveTimes.Clear();
                }

                return success;
            }
            catch (Exception e)
            {
                Log(e, "Error during subscribe test.");
                return false;
            }
        }
        
        /// <summary>
        /// Waits for updates.
        /// </summary>
        private bool WaitForUpdates(Subscription subscription, List<MonitoredItem> monitoredItems, bool afterDisable)
        {
            bool success = true;

            DateTime deadline = DateTime.UtcNow.AddMilliseconds((double)(subscription.PublishingInterval*3 + m_maximumTimingError));
            
            do
            {
                int count = 0; 

                lock (subscription)
                {
                    for (int ii = 0; ii < subscription.NotificationMessages.Count; ii++)
                    {
                        for (int jj = 0; jj < subscription.NotificationMessages[ii].NotificationData.Count; jj++)
                        {
                            ExtensionObject extension = subscription.NotificationMessages[ii].NotificationData[jj];
                            DataChangeNotification notification = extension.Body as DataChangeNotification;
                                            
                            if (notification != null)
                            {
                                count += notification.MonitoredItems.Count;
                            }
                        }
                    }
                }

                if (count == monitoredItems.Count)
                {
                    break;
                }

                if (m_errorEvent.WaitOne(100, false))
                {
                    success = false;
                    break;
                }

                if (subscription.Failed)
                {
                    success = false;
                    break;
                }
            }
            while(deadline > DateTime.UtcNow);

            if (success)
            {
                lock (subscription)
                {
                    if (!VerifyInitialDataChange(subscription, monitoredItems, afterDisable))
                    {
                        success = false;
                    }
                }
            }

            return success;
        }

        /// <summary>
        /// Toggles the monitoring mode for the items.
        /// </summary>
        private bool ToogleDisabledState(Subscription subscription, List<MonitoredItem> monitoredItems)
        {
            UInt32Collection monitoredItemIds = new UInt32Collection();

            lock (subscription)
            {
                subscription.NotificationMessages.Clear();
                subscription.ReceiveTimes.Clear();

                for (int ii = 0; ii < monitoredItems.Count; ii++)
                {
                    monitoredItemIds.Add(monitoredItems[ii].MonitoredItemId);
                    monitoredItems[ii].Value = null;
                }
            }

            StatusCodeCollection results = null;
            DiagnosticInfoCollection diagnosticInfos = null;

            Session.SetMonitoringMode(
                null,
                subscription.SubscriptionId,
                MonitoringMode.Disabled,
                monitoredItemIds,
                out results,
                out diagnosticInfos);

            ClientBase.ValidateResponse(results, monitoredItemIds);
            ClientBase.ValidateDiagnosticInfos(diagnosticInfos, monitoredItemIds);
            
            lock (subscription)
            {
                for (int ii = 0; ii < results.Count; ii++)
                {
                    if (StatusCode.IsBad(results[ii]))
                    {
                        Log(
                            "Error disabling MonitoredItem. ClientHandle = {0}, Node = {1}, Attribute = {2}, StatusCode = {3}", 
                            monitoredItems[ii].MonitoredItemId,
                            monitoredItems[ii].Node,
                            Attributes.GetBrowseName(monitoredItems[ii].AttributeId),
                            results[ii]);

                        return false;
                    }
                }
            }

            ResponseHeader responseHeader = Session.SetMonitoringMode(
                null,
                subscription.SubscriptionId,
                MonitoringMode.Reporting,
                monitoredItemIds,
                out results,
                out diagnosticInfos);

            ClientBase.ValidateResponse(results, monitoredItemIds);
            ClientBase.ValidateDiagnosticInfos(diagnosticInfos, monitoredItemIds);
            
            lock (subscription)
            {
                for (int ii = 0; ii < results.Count; ii++)
                {
                    if (StatusCode.IsBad(results[ii]))
                    {
                        Log(
                            "Error enabling MonitoredItem. ClientHandle = {0}, Node = {1}, Attribute = {2}, StatusCode = {3}", 
                            monitoredItems[ii].MonitoredItemId,
                            monitoredItems[ii].Node,
                            Attributes.GetBrowseName(monitoredItems[ii].AttributeId),
                            results[ii]);

                        return false;
                    }

                    monitoredItems[ii].UpdateTime = responseHeader.Timestamp;
                }
            }

            return true;
        }

        /// <summary>
        /// Verifies that the initial data change was received.
        /// </summary>
        private bool VerifyInitialDataChange(
            Subscription subscription, 
            IList<MonitoredItem> monitoredItems,
            bool afterDisable)
        {
            // build list of notifications.
            int totalCount = 0;
            Dictionary<uint,MonitoredItem> updatedItems = new Dictionary<uint,MonitoredItem>();

            for (int ii = 0; ii < subscription.NotificationMessages.Count; ii++)
            {
                NotificationMessage message = subscription.NotificationMessages[ii];
                                
                for (int jj = 0; jj < message.NotificationData.Count; jj++)
                {
                    ExtensionObject extension = message.NotificationData[jj];

                    // extract notification.
                    DataChangeNotification notification = ExtensionObject.ToEncodeable(extension) as DataChangeNotification;
                                    
                    if (notification == null)
                    {
                        Log("Null notification returned from server. Extension = {0}", extension);
                        return false;
                    }
                    
                    /*
                    Log(
                        "Verifying NotificationMessages={0}, RcvTime={1:hh:mm:ss}, PublishTime={2:hh:mm:ss}, ExpectedCount={3}, ActualCount={4}", 
                        message.SequenceNumber, 
                        subscription.ReceiveTimes[ii],
                        message.PublishTime,
                        monitoredItems.Count,
                        notification.MonitoredItems.Count);
                    */

                    // verify data change.
                    if (!VerifyInitialDataChange(subscription, notification, subscription.ReceiveTimes[ii], monitoredItems, ref totalCount, updatedItems))
                    {
                        Log(
                            "Expected {0} publishes (AfterDisable={1}). Verified {2}, Processed = {3}",
                            monitoredItems.Count,
                            afterDisable,
                            totalCount,
                            updatedItems.Count);

                        return false;
                    }
                }
            }            
            
            // check for missing publish requests.
            if (monitoredItems.Count != totalCount)
            {               
                Log(
                    "Expected {0} publishes (AfterDisable={1}). Received {2}, UniqueNotifications = {3}, FirstNode {4}, NodeId = {5}", 
                    monitoredItems.Count, 
                    afterDisable,
                    totalCount, 
                    updatedItems.Count,
                    (monitoredItems.Count > 0)?monitoredItems[0].Node:null,
                    (monitoredItems.Count > 0)?monitoredItems[0].Node.NodeId:null);

                return false;
            }

            // check attribute consistency.
            bool success = true;

            for (int ii = 0; ii < monitoredItems.Count; ii++)
            {
                if (!VerifyAttributeConsistency(monitoredItems[ii].Node))
                {
                    success = false;
                    continue; 
                }
            }

            return success;
        }

        /// <summary>
        /// Verifies that the initial data change was received.
        /// </summary>
        private bool VerifyInitialDataChange(
            Subscription subscription,
            DataChangeNotification notification,
            DateTime receiveTime,
            IList<MonitoredItem> monitoredItems,
            ref int totalCount,
            Dictionary<uint,MonitoredItem> updatedItems)
        {
            bool success = true;
            bool errorReported = false;

            // determine the maximum requested diagnostics.
            uint diagnosticsMask = 0;
            DiagnosticInfoCollection diagnosticInfos = notification.DiagnosticInfos;
       
            for (int ii = 0; ii < notification.MonitoredItems.Count; ii++)
            {
                totalCount++;

                MonitoredItemNotification update = notification.MonitoredItems[ii];

                // find matching item.
                MonitoredItem monitoredItem = null;

                for (int jj = 0; jj < monitoredItems.Count; jj++)
                {
                    monitoredItem =  monitoredItems[jj];

                    if (update.ClientHandle == monitoredItem.ClientHandle)
                    {
                        MonitoredItem existingItem = null;

                        if (updatedItems.TryGetValue(update.ClientHandle, out existingItem))
                        {
                            Log(
                                "Unexpected notification returned from server for MonitoredItem. ClientHandle = {0}, Node = {1}, Attribute = {2}, NewValue = {3}, OldValue={4}",
                                update.ClientHandle,
                                monitoredItem.Node,
                                Attributes.GetBrowseName(monitoredItem.AttributeId),
                                update.Value.WrappedValue,
                                existingItem.Value.Value);
                        }

                        updatedItems[update.ClientHandle] = monitoredItem;
                        break;
                    }

                    monitoredItem = null;
                }

                if (monitoredItem == null)
                {
                    Log(
                        "Unexpected notification returned from server for Node. ClientHandle = {0}, Value = {1}",
                        update.ClientHandle,
                        update.Value.WrappedValue);

                    success = false;
                    break;
                }
                
                if (monitoredItem.Value != null)
                {
                    Log(
                        "Duplicate notification for MonitoredItem for Node {0}. NodeId = {1}, AttributeId = {2}",
                        monitoredItem.Node,
                        monitoredItem.Node.NodeId,
                        Attributes.GetBrowseName(monitoredItem.AttributeId));

                    success = false;
                    break;
                }

                double initialDelay = CalculateInterval(monitoredItem.UpdateTime, receiveTime);

                if (initialDelay > subscription.PublishingInterval + m_idealTimingError)
                {
                    bool fatal = initialDelay > subscription.PublishingInterval*2;

                    if (!errorReported)
                    {
                        Log(
                            "{0}: Late notification for MonitoredItem for Node {1}. NodeId = {2}, AttributeId = {3}, Delay = {4}ms, MaxDelay = {5}ms",
                            "TIMING ERROR",
                            monitoredItem.Node,
                            monitoredItem.Node.NodeId,
                            Attributes.GetBrowseName(monitoredItem.AttributeId),
                            initialDelay,
                            subscription.PublishingInterval);

                        errorReported = true;
                    }

                    if (fatal)
                    {
                        success = false;
                        break;
                    }
                }
                
                monitoredItem.Value = update.Value;
                
                // verify timestamps.
                if (!VerifyTimestamps(monitoredItem.Node, monitoredItem.AttributeId, monitoredItem.TimestampsToReturn, update.Value))
                {
                    success = false;
                    break;
                }
                    
                // check if diagnostics could exist.
                if (update.Value.StatusCode != StatusCodes.Good)
                {
                    diagnosticsMask |= monitoredItem.DiagnosticsMasks;

                    if ((monitoredItem.DiagnosticsMasks & (uint)DiagnosticsMasks.OperationAll) != 0)
                    {
                        if (diagnosticInfos == null || diagnosticInfos.Count < ii || diagnosticInfos[ii] == null)
                        {
                            Log(
                                "Missing DiagnosticInfo for MonitoredItem for Node {0}. NodeId = {1}, AttributeId = {2}",
                                monitoredItem.Node,
                                monitoredItem.Node.NodeId,
                                Attributes.GetBrowseName(monitoredItem.AttributeId));

                            success = false;
                            break;
                        }
                    }
                }

                // verify error.
                if (StatusCode.IsBad(update.Value.StatusCode))
                {
                    if (!VerifyBadAttribute(monitoredItem.Node, monitoredItem.AttributeId, update.Value.StatusCode))
                    {
                        success = false;
                        break;                   
                    }

                    continue;
                }
                    
                // verify success.
                if (!VerifyGoodAttribute(monitoredItem.Node, monitoredItem.AttributeId, update.Value))
                {
                    success = false;
                    break;                 
                }
            }

            // check for unnecessary diagnostics.
            if ((diagnosticsMask & (uint)DiagnosticsMasks.OperationAll) == 0)
            {
                if (diagnosticInfos != null && diagnosticInfos.Count > 0)
                {
                    Log("Returned non-empty DiagnosticInfos array during Publish.");
                    return false;
                }
            }

            return success;
        }

        /// <summary>
        /// Creates the monitored items.
        /// </summary>
        private bool CreateMonitoredItems(
            Subscription subscription, 
            MonitoredItemCreateRequestCollection itemsToCreate,
            List<MonitoredItem> monitoredItems)
        {   
            try
            {
                RequestHeader requestHeader = new RequestHeader();
                requestHeader.ReturnDiagnostics = 0;

                MonitoredItemCreateResultCollection results;
                DiagnosticInfoCollection diagnosticInfos;

                ResponseHeader responseHeader = Session.CreateMonitoredItems(
                    requestHeader,
                    subscription.SubscriptionId,
                    TimestampsToReturn.Both,
                    itemsToCreate,
                    out results,
                    out diagnosticInfos);

                ClientBase.ValidateResponse(results, itemsToCreate);
                ClientBase.ValidateDiagnosticInfos(diagnosticInfos, itemsToCreate);
                                
                if (diagnosticInfos != null && diagnosticInfos.Count > 0)
                {
                    Log("Returned non-empty DiagnosticInfos array during CreateMonitoredItems.");
                    return false;
                }

                bool success = true;
                DateTime updateTime = responseHeader.Timestamp;
                
                for (int ii = 0; ii < itemsToCreate.Count; ii++)
                {
                    MonitoredItemCreateRequest request = itemsToCreate[ii];
                    MonitoredItemCreateResult result = results[ii];
                    Node node = (Node)request.Handle;

                    if (StatusCode.IsBad(result.StatusCode))
                    {
                        if (!VerifyBadAttribute(node, request.ItemToMonitor.AttributeId, result.StatusCode))
                        {
                            success = false;
                        }

                        continue;
                    }
                    
                    // check if attribute is not supposed to be valid for node.
                    if (!Attributes.IsValid(node.NodeClass, request.ItemToMonitor.AttributeId))
                    {
                        Log(
                            "CreateMonitoredItem accepted for invalid attribute Node '{0}'. NodeId = {1}, NodeClass = {2}, Attribute = {3}",
                            node,
                            node.NodeId,
                            node.NodeClass,
                            Attributes.GetBrowseName(request.ItemToMonitor.AttributeId));

                        success = false;
                        continue;
                    }

                    // check filter result.
                    if (request.RequestedParameters.Filter == null)
                    {
                        if (!ExtensionObject.IsNull(result.FilterResult))
                        {
                            Log(
                                "Server returned a non-null filter result for Node '{0}', NodeId = {1}, AttributeId = {2}, FilterResult = {3}",
                                node,
                                node.NodeId,
                                Attributes.GetBrowseName(request.ItemToMonitor.AttributeId),
                                result.FilterResult);

                            success = false;
                            continue;
                        }
                    }

                    MonitoredItem monitoredItem = new MonitoredItem();
                    
                    monitoredItem.MonitoredItemId = result.MonitoredItemId;
                    monitoredItem.Node = node;
                    monitoredItem.TimestampsToReturn = TimestampsToReturn.Both;
                    monitoredItem.DiagnosticsMasks = 0;
                    monitoredItem.AttributeId = request.ItemToMonitor.AttributeId;
                    monitoredItem.MonitoringMode = request.MonitoringMode;
                    monitoredItem.ClientHandle = request.RequestedParameters.ClientHandle;
                    monitoredItem.SamplingInterval = result.RevisedSamplingInterval;
                    monitoredItem.QueueSize = result.RevisedQueueSize;
                    monitoredItem.DiscardOldest = request.RequestedParameters.DiscardOldest;
                    monitoredItem.Filter = ExtensionObject.ToEncodeable(request.RequestedParameters.Filter) as MonitoringFilter;
                    monitoredItem.UpdateTime = updateTime;
                    
                    monitoredItems.Add(monitoredItem);
                }
                
                return success;              
            }
            catch (Exception e)
            {
                Log(e, "CreateMonitoredItems Failed.");
                return false;
            } 
        }
        
        /// <summary>
        /// Deletes the monitored items.
        /// </summary>
        private bool DeleteMonitoredItems(
            Subscription subscription, 
            List<MonitoredItem> monitoredItems)
        {   
            try
            {
                RequestHeader requestHeader = new RequestHeader();
                requestHeader.ReturnDiagnostics = 0;

                UInt32Collection monitoredItemIds = new UInt32Collection();
                
                for (int ii = 0; ii < monitoredItems.Count; ii++)
                {
                    monitoredItemIds.Add(monitoredItems[ii].MonitoredItemId);
                }

                StatusCodeCollection results;
                DiagnosticInfoCollection diagnosticInfos;

                Session.DeleteMonitoredItems(
                    requestHeader,
                    subscription.SubscriptionId,
                    monitoredItemIds,
                    out results,
                    out diagnosticInfos);

                ClientBase.ValidateResponse(results, monitoredItemIds);
                ClientBase.ValidateDiagnosticInfos(diagnosticInfos, monitoredItemIds);
                                
                if (diagnosticInfos != null && diagnosticInfos.Count > 0)
                {
                    Log("Returned non-empty DiagnosticInfos array during DeleteMonitoredItems.");
                    return false;
                }

                bool success = true;
                
                for (int ii = 0; ii < monitoredItems.Count; ii++)
                {
                    if (StatusCode.IsBad(results[ii]))
                    {
                        Log(
                            "Delete monitored item failed for Node '{0}', NodeId = {1}, AttributeId = {2}, StatusCode = {3}",
                            monitoredItems[ii].Node,
                            monitoredItems[ii].Node.NodeId,
                            Attributes.GetBrowseName(monitoredItems[ii].AttributeId),
                            results[ii]);

                        success = false;
                        continue;
                    }
                }
                
                return success;              
            }
            catch (Exception e)
            {
                Log(e, "DeleteMonitoredItems Failed.");
                return false;
            } 
        }

        /// <summary>
        /// Verifies the keep alive results for the subscription.
        /// </summary>
        private bool VerifyKeepAliveTestResults(Subscription subscription)
        {
            if (subscription.Failed)
            {
                return false;
            }

            if (subscription.MissingSequenceNumbers.Count > 0)
            {
                Log(
                    "Missing messages for subscription. SubscriptionId = {0}, Last = {1}, Missing = {2}",
                    subscription.SubscriptionId,
                    subscription.LastReceivedSequenceNumber,
                    new Variant(subscription.MissingSequenceNumbers));

                return false;
            }

            if (subscription.NextExpectedSequenceNumber != subscription.LastReceivedSequenceNumber+1)
            {
                Log(
                    "Missing messages for subscription. SubscriptionId = {0}, Actual = {1}, Expected = {2}", 
                    subscription.SubscriptionId,
                    subscription.LastReceivedSequenceNumber,
                    subscription.NextExpectedSequenceNumber);

                return false;
            }

            if (subscription.NotificationMessages.Count > 0)
            {
                Log(
                    "Received unexpected notification messages for subscription {0}. Count = {1}", 
                    subscription.SubscriptionId,
                    subscription.NotificationMessages.Count);

                return false;
            }

            bool success = true;

            for (int ii = 0; ii < subscription.States.Count; ii++)
            {
                if (!VerifyKeepAliveTestResults(subscription, subscription.States[ii], ii == 0))
                {
                    success = false;
                }
            }

            return success;
        }

        /// <summary>
        /// Verifies the keep alive test results.
        /// </summary>
        private bool VerifyKeepAliveTestResults(Subscription subscription, PublishingState state, bool isFirst)
        {
            double keepAlivePeriod = state.KeepAliveCount*state.PublishingInterval;
            double elaspedTime = CalculateInterval(state.Start, state.End);
            double referencePeriod = (state.KeepAliveMode)?keepAlivePeriod:state.PublishingInterval;

            bool success = true;
            DateTime start = state.Start;

            for (int ii = 0; ii < state.KeepAlives.Count; ii++)
            {
                double referencePeriodToUse = referencePeriod;

                // the first keep alive comes with the first publishing interval.
                if (isFirst && ii == 0)
                {
                    referencePeriodToUse = state.PublishingInterval;
                }

                double delta = CalculateInterval(start, state.KeepAlives[ii]);

                if (Math.Abs(referencePeriodToUse - delta) > m_idealTimingError && delta > m_idealTimingError)
                {
                    bool fatal = Math.Abs(referencePeriodToUse - delta) > (referencePeriodToUse + (double)((isFirst)?500:0));

                    Log(
                        "{0}: Notification received at the wrong time for subscription {1}. Index = {2}, Expected = {3}ms, Actual = {4}ms",
                        "TIMING ERROR",
                        subscription.SubscriptionId,
                        ii,
                        referencePeriodToUse,
                        delta);

                    if (fatal)
                    {
                        success = false;
                    }
                }             

                start = state.KeepAlives[ii];
            }

            if ((Math.Truncate(elaspedTime/keepAlivePeriod) > state.KeepAlives.Count))
            {
                double[] deltas = new double[state.KeepAlives.Count];

                for (int ii = 0; ii < state.KeepAlives.Count-1; ii++)
                {
                    deltas[ii] = CalculateInterval(state.KeepAlives[ii], state.KeepAlives[ii + 1]);
                }

                double timingError = Math.Abs((state.KeepAlives.Count + 1) * keepAlivePeriod - elaspedTime);

                // check if the keep alive is an exact multiple of the elapsed time.
                if (timingError > m_idealTimingError && timingError > state.PublishingInterval)
                {
                    bool fatal = Math.Truncate(elaspedTime/keepAlivePeriod) > state.KeepAlives.Count+1;

                    Log(
                        "{0}: Keep alives not received for subscription {1}. , Expected = {2}, Actual = {3}, TimingError={4}",
                        "TIMING ERROR",
                        subscription.SubscriptionId,
                        Math.Truncate(elaspedTime/keepAlivePeriod),
                        state.KeepAlives.Count,
                        timingError);

                    if (fatal)
                    {
                        success = false;
                    }
                }
            }

            return success;
        }
        #endregion

        #region Setup/Control Functions
        private class MonitoredItem
        {
            public uint MonitoredItemId;
            public uint DiagnosticsMasks;
            public TimestampsToReturn TimestampsToReturn;
            public Node Node;
            public uint AttributeId;
            public MonitoringMode MonitoringMode;
            public uint ClientHandle;
            public double SamplingInterval;
            public uint QueueSize;
            public bool DiscardOldest;
            public MonitoringFilter Filter;
            public DateTime UpdateTime;
            public DataValue Value;
        }

        /// <summary>
        /// Deletes all of the active subscriptions.
        /// </summary>
        private bool DeleteSubscriptions()
        {   
            try
            {
                UInt32Collection subscriptionIds = new UInt32Collection();

                lock (m_subscriptions)
                {
                    for (int ii = 0; ii < m_subscriptions.Count; ii++)
                    {
                        Subscription subscription = m_subscriptions[ii];

                        lock (subscription)
                        {
                            subscriptionIds.Add(subscription.SubscriptionId);
                            subscription.Deleted = true;
                        }
                    }
                }
                    
                RequestHeader requestHeader = new RequestHeader();
                requestHeader.ReturnDiagnostics = 0;

                StatusCodeCollection results;
                DiagnosticInfoCollection diagnosticInfos;

                ResponseHeader responseHeader = Session.DeleteSubscriptions(
                    requestHeader,
                    subscriptionIds,
                    out results,
                    out diagnosticInfos);

                ClientBase.ValidateResponse(results, subscriptionIds);
                ClientBase.ValidateDiagnosticInfos(diagnosticInfos, subscriptionIds);
                                
                if (diagnosticInfos != null && diagnosticInfos.Count > 0)
                {
                    Log("Returned non-empty DiagnosticInfos array during DeleteSubscriptions.");
                    return false;
                }

                bool success = true;

                lock (m_subscriptions)
                {
                    for (int ii = 0; ii < m_subscriptions.Count; ii++)
                    {
                        if (StatusCode.IsBad(results[ii]))
                        {
                            Log(
                                "Unexpected error deleting subscription {0}. StatusCode = {1}",
                                subscriptionIds[ii],
                                subscriptionIds);

                            success = false;
                        }

                        Subscription subscription = m_subscriptions[ii];

                        lock (subscription)
                        {
                            subscription.States[subscription.States.Count - 1].End = responseHeader.Timestamp;
                        }
                    }
                }

                // let the queue empty.
                Thread.Sleep(1000);

                return success;
            }
            catch (Exception e)
            {
                Log(e, "DeleteSubscriptions Failed.");
                return false;
            } 
        }
        
        /// <summary>
        /// Sets the publishing enable state for the subscriptions.
        /// </summary>
        private bool SetPublishingEnabled(bool enabled)
        {   
            try
            {
                UInt32Collection subscriptionIds = new UInt32Collection();

                lock (m_subscriptions)
                {
                    for (int ii = 0; ii < m_subscriptions.Count; ii++)
                    {
                        subscriptionIds.Add(m_subscriptions[ii].SubscriptionId);
                        m_subscriptions[ii].PublishingEnabled = enabled;
                    }
                }
                    
                RequestHeader requestHeader = new RequestHeader();
                requestHeader.ReturnDiagnostics = 0;

                StatusCodeCollection results;
                DiagnosticInfoCollection diagnosticInfos;

                Session.SetPublishingMode(
                    requestHeader,
                    enabled,
                    subscriptionIds,
                    out results,
                    out diagnosticInfos);

                ClientBase.ValidateResponse(results, subscriptionIds);
                ClientBase.ValidateDiagnosticInfos(diagnosticInfos, subscriptionIds);
                                
                if (diagnosticInfos != null && diagnosticInfos.Count > 0)
                {
                    Log("Returned non-empty DiagnosticInfos array during SetPublishingMode.");
                    return false;
                }

                bool success = true;
                
                for  (int ii = 0; ii < results.Count; ii++)
                {
                    if (StatusCode.IsBad(results[ii]))
                    {
                        Log(
                            "Unexpected error setting publish enable state for subscription {0}. StatusCode = {1}", 
                            subscriptionIds[ii],
                            subscriptionIds);

                        success = false;
                    }
                }

                return success;
            }
            catch (Exception e)
            {
                Log(e, "SetPublishingMode Failed.");
                return false;
            } 
        }

        /// <summary>
        /// Sets the publishing enable state for the subscriptions.
        /// </summary>
        private bool ModifySubscription(Subscription subscription, double publishingInterval)
        {   
            try
            {        
                double revisedPublishingInterval;
                uint revisedLifetimeCount;
                uint revisedKeepAliveCount;
          
                RequestHeader requestHeader = new RequestHeader();
                requestHeader.ReturnDiagnostics = 0;

                DateTime start = DateTime.UtcNow;

                ResponseHeader responseHeader = Session.ModifySubscription(
                    requestHeader,
                    subscription.SubscriptionId,
                    publishingInterval,
                    subscription.LifetimeCount,
                    subscription.KeepAliveCount,
                    subscription.MaxNotificationsPerPublish,
                    subscription.Priority,
                    out revisedPublishingInterval,
                    out revisedLifetimeCount,
                    out revisedKeepAliveCount);
                
                double elapsedTime = (DateTime.UtcNow - start).TotalMilliseconds;

                if (elapsedTime > 300)
                {
                    Log("WARNING: ModifySubscription took {0}ms. Timing errors may occur.", (DateTime.UtcNow - start).TotalMilliseconds);
                }               

                PublishingState state = new PublishingState();

                state.KeepAliveCount = revisedKeepAliveCount;
                state.PublishingInterval = revisedPublishingInterval;
                state.Start = responseHeader.Timestamp;
                state.KeepAliveMode = true;

                lock (subscription)
                {
                    subscription.PublishingInterval = revisedPublishingInterval;
                    subscription.KeepAliveCount = revisedKeepAliveCount;
                    subscription.LifetimeCount = revisedLifetimeCount;
                    subscription.States[subscription.States.Count-1].End = state.Start;
                    subscription.States.Add(state);
                }

                return true;
            }
            catch (Exception e)
            {
                Log(e, "Error modifying state of subscription {0}.", subscription.SubscriptionId);
                return false;
            } 
        }

        /// <summary>
        /// Creates a subscription.
        /// </summary>
        private bool CreateSubscription(
            double publishingInterval,
            uint lifetimeCount,
            uint keepAliveCount,
            uint maxNotificationsPerPublish,
            bool publishingEnabled,
            byte priority)
        {            
            try
            {
                uint subscriptionId;
                double revisedPublishingInterval;
                uint revisedLifetimeCount;
                uint revisedKeepAliveCount;
                
                Subscription subscription = new Subscription();

                subscription.MaxNotificationsPerPublish = maxNotificationsPerPublish;
                subscription.PublishingEnabled = publishingEnabled;
                subscription.Priority = priority;
                subscription.NextExpectedSequenceNumber = 1;
                subscription.StaticData = true;
                
                lock (m_subscriptions)
                {
                    m_subscriptions.Add(subscription);
                }

                DateTime start = DateTime.UtcNow;

                ResponseHeader responseHeader = Session.CreateSubscription(
                    null,
                    publishingInterval,
                    lifetimeCount,
                    keepAliveCount,
                    maxNotificationsPerPublish,
                    publishingEnabled,
                    priority,
                    out subscriptionId,
                    out revisedPublishingInterval,
                    out revisedLifetimeCount,
                    out revisedKeepAliveCount);

                double elapsedTime = (DateTime.UtcNow - start).TotalMilliseconds;

                if (elapsedTime > 300)
                {
                    Log("WARNING: CreateSubscription took {0}ms. Timing errors may occur.", (DateTime.UtcNow - start).TotalMilliseconds);
                }
                
                subscription.SubscriptionId = subscriptionId;
                subscription.PublishingInterval = revisedPublishingInterval;
                subscription.LifetimeCount = revisedLifetimeCount;
                subscription.KeepAliveCount = revisedKeepAliveCount;

                while (m_outstandingPublishRequests < m_publishPipelineDepth)
                {
                    BeginPublish();
                }
                                
                lock (subscription)
                {
                    PublishingState state = new PublishingState();

                    state.KeepAliveCount = subscription.KeepAliveCount;
                    state.PublishingInterval = subscription.PublishingInterval;
                    state.Start = responseHeader.Timestamp;
                    state.KeepAliveMode = true;

                    subscription.States.Add(state);
                }

                return true;
            }
            catch (Exception e)
            {
                Log(e, "Error creating subscription.", null);
                return false;
            }
        }

#if SYNC
        /// <summary>
        /// Sends a publish request.
        /// </summary>
        private void BeginPublish()
        {
            PublishCallbackData callbackData = new PublishCallbackData();

            callbackData.Session = Session;
            callbackData.Acknowledgements = GetAcknowledgements();
            callbackData.Timestamp = DateTime.UtcNow;

            Interlocked.Increment(ref m_outstandingPublishRequests);

            ThreadPool.QueueUserWorkItem(OnPublishComplete, callbackData);
        }
        
        /// <summary>
        /// Called when a publish request completes.
        /// </summary>
        private void OnPublishComplete(object state)
        {
            PublishCallbackData callbackData = (PublishCallbackData)state;

            uint subscriptionId = 0;
            UInt32Collection availableSequenceNumbers = null;
            bool moreNotifications = false;
            NotificationMessage notificationMessage = null;
            StatusCodeCollection results = null;
            DiagnosticInfoCollection diagnosticInfos = null;
            ResponseHeader responseHeader = null;

            try
            {
                RequestHeader requestHeader = new RequestHeader();
                requestHeader.ReturnDiagnostics = 0;
                requestHeader.TimeoutHint = 60000;

                responseHeader = callbackData.Session.Publish(
                    requestHeader,
                    callbackData.Acknowledgements,
                    out subscriptionId,
                    out availableSequenceNumbers,
                    out moreNotifications,
                    out notificationMessage,
                    out results,
                    out diagnosticInfos);
            }
            catch (ServiceResultException e)
            {
                HaltTestOnError(e, "Fatal error during publish.", null);
            }
            catch (Exception e)
            {
                HaltTestOnError(e, "Fatal error during publish.", null);
            }
            finally
            {
                Interlocked.Decrement(ref m_outstandingPublishRequests);
            }
            
            try
            {                
                if (Object.ReferenceEquals(callbackData.Session, Session))
                {
                    Interlocked.Increment(ref m_publishCount);
                }

                ClientBase.ValidateResponse(results, callbackData.Acknowledgements);
                ClientBase.ValidateDiagnosticInfos(diagnosticInfos, callbackData.Acknowledgements);
                                
                if (diagnosticInfos != null && diagnosticInfos.Count > 0)
                {
                    HaltTestOnError(null, "Returned non-empty DiagnosticInfos array during Publish.", null);
                    return;
                }

                // find subscription.
                Subscription subscription = Find(subscriptionId);

                if (subscription == null || subscription.Deleted)
                {
                    return;
                }
                
                lock (subscription)
                {
                    VerifyPublishResponse(
                        responseHeader,
                        subscription,
                        availableSequenceNumbers,
                        moreNotifications,
                        notificationMessage,
                        results,
                        diagnosticInfos);
                }
                
                // send a new request.
                bool notsent = true;

                if (m_stopped == 0 && Object.ReferenceEquals(callbackData.Session, Session))
                {
                    if (m_outstandingPublishRequests < m_publishPipelineDepth)
                    {
                        BeginPublish();
                        notsent = false;
                    }
                }

                if (notsent)
                {
                    Log(
                        "Publish not sent. Count={0}, Pipeline={1}, Stopped={2}", 
                        m_outstandingPublishRequests, 
                        m_publishPipelineDepth, 
                        m_stopped);
                }
            }
            catch (ServiceResultException e)
            {
                HaltTestOnError(e, "Fatal error during publish.", null);
            }
            catch (Exception e)
            {
                HaltTestOnError(e, "Fatal error during publish.", null);
            }
        }
#endif

#if !SYNC
        /// <summary>
        /// Sends a publish request.
        /// </summary>
        private void BeginPublish()
        {
            PublishCallbackData callbackData = new PublishCallbackData();

            callbackData.Session = Session;
            callbackData.Acknowledgements = GetAcknowledgements();
            callbackData.Timestamp = DateTime.UtcNow;

            RequestHeader requestHeader = new RequestHeader();
            requestHeader.ReturnDiagnostics = 0;
            requestHeader.TimeoutHint = 60000;

            Interlocked.Increment(ref m_outstandingPublishRequests);

            Session.BeginPublish(
                requestHeader,
                callbackData.Acknowledgements,
                new AsyncCallback(OnPublishComplete),
                callbackData);

            // Utils.Trace("Publish sent. Count={0}", m_outstandingPublishRequests);
        }

        /// <summary>
        /// Called when a publish request completes.
        /// </summary>
        private void OnPublishComplete(IAsyncResult result)
        {
            PublishCallbackData callbackData = (PublishCallbackData)result.AsyncState;

            try
            {                
                Interlocked.Decrement(ref m_outstandingPublishRequests);

                if (Object.ReferenceEquals(callbackData.Session, Session))
                {
                    Interlocked.Increment(ref m_publishCount);
                }

                // complete request.
                uint subscriptionId;
                UInt32Collection availableSequenceNumbers;
                bool moreNotifications;
                NotificationMessage notificationMessage;
                StatusCodeCollection results;
                DiagnosticInfoCollection diagnosticInfos;

                ResponseHeader responseHeader = callbackData.Session.EndPublish(
                    result,
                    out subscriptionId,
                    out availableSequenceNumbers,
                    out moreNotifications,
                    out notificationMessage,
                    out results,
                    out diagnosticInfos);

                ClientBase.ValidateResponse(results, callbackData.Acknowledgements);
                ClientBase.ValidateDiagnosticInfos(diagnosticInfos, callbackData.Acknowledgements);
                                
                if (diagnosticInfos != null && diagnosticInfos.Count > 0)
                {
                    HaltTestOnError(null, "Returned non-empty DiagnosticInfos array during Publish.", null);
                    return;
                }

                // find subscription.
                Subscription subscription = Find(subscriptionId);

                if (subscription == null || subscription.Deleted)
                {
                    return;
                }
                
                lock (subscription)
                {
                    VerifyPublishResponse(
                        responseHeader,
                        subscription,
                        availableSequenceNumbers,
                        moreNotifications,
                        notificationMessage,
                        results,
                        diagnosticInfos);
                }
                
                // send a new request.
                bool notsent = true;

                if (m_stopped == 0 && Object.ReferenceEquals(callbackData.Session, Session))
                {
                    if (m_outstandingPublishRequests < m_publishPipelineDepth)
                    {
                        BeginPublish();
                        notsent = false;
                    }
                }

                if (notsent)
                {
                    Utils.Trace("Publish not sent. Count={0}, Pipeline={1}, Stopped={2}", m_outstandingPublishRequests, m_publishPipelineDepth, m_stopped);
                }
            }
            catch (ServiceResultException e)
            {
                if (e.StatusCode == StatusCodes.BadNoSubscription)
                {
                    return;
                }
            
                if (e.StatusCode == StatusCodes.BadTimeout)
                {
                    if (!Object.ReferenceEquals(callbackData.Session, Session))
                    {
                        return;
                    }
                    
                    Log(
                        "WARNING: Publish timeout. Count={0}, Pipeline={1}, SentTime={2:HH:mm:ss}, RecvTime={3:HH:mm:ss}",
                        m_outstandingPublishRequests,
                        m_publishPipelineDepth,
                        callbackData.Timestamp,
                        DateTime.UtcNow);

                    if (m_outstandingPublishRequests < m_publishPipelineDepth)
                    {
                        BeginPublish();
                    }

                    return;
                }

                HaltTestOnError(e, "Fatal error during publish.", null);
            }
            catch (Exception e)
            {
                HaltTestOnError(e, "Fatal error during publish.", null);
            }
        }
#endif
        #endregion

        /// <summary>
        /// Stores the state of a subscription.
        /// </summary>
        private class Subscription
        {
            public uint SubscriptionId;
            public double PublishingInterval;
            public uint LifetimeCount;
            public uint KeepAliveCount;
            public uint MaxNotificationsPerPublish;
            public bool PublishingEnabled;
            public byte Priority;           
            public bool Failed;
            public bool Deleted;
            public bool StaticData;
            public uint NextExpectedSequenceNumber;
            public uint LastReceivedSequenceNumber;
            public UInt32Collection MissingSequenceNumbers = new UInt32Collection();
            public UInt32Collection AvailableSequenceNumbers;
            public List<PublishingState> States = new List<PublishingState>();
            public List<DateTime> ReceiveTimes = new List<DateTime>();
            public List<NotificationMessage> NotificationMessages = new List<NotificationMessage>();
        }

        private class PublishingState
        {
            public DateTime Start;
            public DateTime End;
            public double PublishingInterval;
            public double KeepAliveCount;
            public bool KeepAliveMode;
            public List<DateTime> KeepAlives = new List<DateTime>();
        }

        private class PublishCallbackData
        {
            public Session Session;
            public SubscriptionAcknowledgementCollection Acknowledgements;
            public DateTime Timestamp;
        }

        /// <summary>
        /// Verifies the result of a publish
        /// </summary>
        private bool VerifyPublishResponse(
            ResponseHeader responseHeader,
            Subscription subscription,
            UInt32Collection availableSequenceNumbers,
            bool moreNotifications,
            NotificationMessage notificationMessage,
            StatusCodeCollection results,
            DiagnosticInfoCollection diagnosticInfos)
        {
            /*
            Utils.Trace(
                "PublishReceived: SubId={0} SeqNo={1}, PublishTime={2:mm:ss.fff}, Time={3:mm:ss.fff}",
                subscription.SubscriptionId,
                notificationMessage.SequenceNumber,
                notificationMessage.PublishTime,
                DateTime.UtcNow);
            */

            // check if there is an odd delay.
            if (responseHeader.Timestamp > notificationMessage.PublishTime.AddMilliseconds(100))
            {
                Log(
                    "WARNING. Unexpected delay between PublishTime and ResponseTime. SeqNo={0}, PublishTime={1:hh:mm:ss.fff}, ResponseTime={2:hh:mm:ss.fff}",
                    notificationMessage.SequenceNumber,
                    notificationMessage.PublishTime,
                    responseHeader.Timestamp);
            }

            // save results.
            subscription.AvailableSequenceNumbers = availableSequenceNumbers;

            if (notificationMessage.NotificationData.Count == 0)
            {
                // keep alives do not increment the sequence number.
                if (subscription.NextExpectedSequenceNumber != notificationMessage.SequenceNumber)
                {
                    Log(
                        "Incorrect sequence number for keep alive. SubscriptionId = {0}, Actual = {1}, Expected = {2}", 
                        subscription.SubscriptionId,
                        notificationMessage.SequenceNumber,
                        subscription.NextExpectedSequenceNumber);

                    subscription.Failed = true;
                    return false;
                }

                // save the message.                
                DateTime timestamp = responseHeader.Timestamp;
                DateTime start = subscription.States[subscription.States.Count - 1].Start;

                // check if this is an old request being processed late.
                if (start > timestamp && subscription.States.Count > 1)
                {
                    subscription.States[subscription.States.Count - 2].KeepAlives.Add(timestamp);
                }
                else
                {
                    subscription.States[subscription.States.Count - 1].KeepAlives.Add(timestamp);
                }
            }
            else
            {
                // check for replays.
                if (subscription.NextExpectedSequenceNumber > notificationMessage.SequenceNumber)
                {
                    // check for out of order responses.
                    bool found = false;

                    for (int ii = 0; ii < subscription.MissingSequenceNumbers.Count; ii++)
                    {
                        if (subscription.MissingSequenceNumbers[ii] == notificationMessage.SequenceNumber)
                        {
                            subscription.MissingSequenceNumbers.RemoveAt(ii);
                            found = true;
                            break;
                        }
                    }

                    // oops - duplicate.
                    if (!found)
                    {
                        Log(
                            "Duplicate sequence number for message. SubscriptionId = {0}, Actual = {1}, Expected = {2}",
                            subscription.SubscriptionId,
                            notificationMessage.SequenceNumber,
                            subscription.NextExpectedSequenceNumber);

                        subscription.Failed = true;
                        return false;
                    }
                }
                
                // increment message counter.
                if (notificationMessage.SequenceNumber >= subscription.NextExpectedSequenceNumber)
                {
                    for (uint ii = subscription.NextExpectedSequenceNumber; ii < notificationMessage.SequenceNumber; ii++)
                    {
                        if (!subscription.MissingSequenceNumbers.Contains(ii))
                        {
                            subscription.MissingSequenceNumbers.Add(ii);
                        }
                    }

                    subscription.NextExpectedSequenceNumber = notificationMessage.SequenceNumber+1;
                }
                                                        
                // save the largest received message number (gap exist because of client side threading issues).
                if (subscription.LastReceivedSequenceNumber < notificationMessage.SequenceNumber)
                {
                    subscription.LastReceivedSequenceNumber = notificationMessage.SequenceNumber;
                }

                // save the message.                
                DateTime timestamp = responseHeader.Timestamp;
                DateTime start = subscription.States[subscription.States.Count-1].Start;

                // check if this is an old request being processed late.
                if (start > timestamp && subscription.States.Count > 1)
                {
                    subscription.States[subscription.States.Count - 2].KeepAlives.Add(timestamp);
                }
                else
                {
                    subscription.States[subscription.States.Count - 1].KeepAlives.Add(timestamp);
                }

                subscription.NotificationMessages.Add(notificationMessage);
                subscription.ReceiveTimes.Add(responseHeader.Timestamp);

                // change to keep alive mode.
                if (subscription.StaticData)
                {
                    PublishingState state = new PublishingState();

                    state.KeepAliveCount = subscription.KeepAliveCount;
                    state.PublishingInterval = subscription.PublishingInterval;
                    state.Start = timestamp;
                    state.KeepAliveMode = true;

                    subscription.States[subscription.States.Count-1].End = state.Start;
                    subscription.States.Add(state);
                }

                // save the acknowlegements.
                SaveAcknowledgement(subscription.SubscriptionId, notificationMessage.SequenceNumber);
            }

            return true;
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
        /// Finds the subscription.
        /// </summary>
        private Subscription Find(uint subscriptionId)
        {
            lock (m_subscriptions)
            {
                for (int ii = 0; ii <  m_subscriptions.Count; ii++)
                {
                    if (m_subscriptions[ii].SubscriptionId == subscriptionId)
                    {
                        return m_subscriptions[ii];
                    }
                }

                Log("Received a message for a subscription that does not exist. Id = {0}", subscriptionId);
                return null;
            }
        }
        
        /// <summary>
        /// Save the acknowledgement to send to the server with the publish.
        /// </summary>
        private void SaveAcknowledgement(uint subscriptionId, uint sequenceNumber)
        {
            lock (m_acknowledgements)
            {
                SubscriptionAcknowledgement acknowledgement = new SubscriptionAcknowledgement();

                acknowledgement.SubscriptionId = subscriptionId;
                acknowledgement.SequenceNumber = sequenceNumber;

                m_acknowledgements.Add(acknowledgement);
            }
        }        

        /// <summary>
        /// Returns the acknowledgements to send to the server with the publish.
        /// </summary>
        private SubscriptionAcknowledgementCollection GetAcknowledgements()
        {
            lock (m_acknowledgements)
            {
                SubscriptionAcknowledgementCollection acknowledgements = new SubscriptionAcknowledgementCollection();
                acknowledgements.AddRange(m_acknowledgements);
                m_acknowledgements.Clear();
                return acknowledgements;
            }
        }
        
        #region Verification Methods
        #endregion

        #region Private Fields
        private List<Subscription> m_subscriptions;
        private ManualResetEvent m_errorEvent;
        private SubscriptionAcknowledgementCollection m_acknowledgements;
        private int m_stopped;
        private int m_publishCount;
        private int m_idealTimingError;
        private int m_maximumTimingError;
        private int m_outstandingPublishRequests;
        private int m_publishPipelineDepth;
        private uint m_lastClientHandle = 1000;
        #endregion
    }
}
