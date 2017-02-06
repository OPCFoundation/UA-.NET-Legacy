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
using System.Linq;
using System.Text;
using System.Threading;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Xml;
using System.Runtime.Serialization;

namespace Opc.Ua.Sample
{
    /// <summary>
    /// Manages a subscription for a client.
    /// </summary>
    class Subscription
    {
        #region Initialization
        /// <summary>
        /// Creates the subscription.
        /// </summary>
        public void Create(
            Session session,
            NodeManager nodeManager,
            double publishingInterval,
            uint lifetimeCount,
            uint keepAliveCount,
            uint maxNotificationCount,
            bool publishingEnabled,
            byte priority,
            out uint subscriptionId,
            out double revisedPublishingInterval,
            out uint revisedLifetimeCount,
            out uint revisedKeepAliveCount)
        {
            lock (m_lock)
            {
                m_session = session;
                m_nodeManager = nodeManager;
                m_subscriptionId = subscriptionId = (uint)Interlocked.Increment(ref m_subscriptionCounter);
                m_publishingInterval = revisedPublishingInterval = publishingInterval;
                m_lifetimeCount = revisedLifetimeCount = lifetimeCount;
                m_keepAliveCount = revisedKeepAliveCount = keepAliveCount;
                m_maxNotificationCount = maxNotificationCount;
                m_publishingEnabled = publishingEnabled;
                m_priority = priority;
                m_lastPublishTime = 0;
                m_nextKeepAliveTime = (long)(DateTime.UtcNow.Ticks / TimeSpan.TicksPerMillisecond + m_publishingInterval * m_keepAliveCount);
            }
        }
        #endregion

        #region Public Interface
        /// <summary>
        /// Returns the session that the subscription belongs to.
        /// </summary>
        public Session Session
        {
            get { return m_session; }
        }

        /// <summary>
        /// Returns the identifier for the subscription.
        /// </summary>
        public uint Id
        {
            get { return m_subscriptionId; }
        }

        /// <summary>
        /// Checks if the subscription is ready to publish and returns a notification message.
        /// </summary>
        public NotificationMessage Publish()
        {
            lock (m_lock)
            {
                long currentTime = DateTime.UtcNow.Ticks / TimeSpan.TicksPerMillisecond;

                // check of it is time for a publish.
                if (m_lastPublishTime + m_publishingInterval < currentTime)
                {
                    ListOfMonitoredItemNotification notifications = new ListOfMonitoredItemNotification();
                    ListOfDiagnosticInfo diagnosticInfos = new ListOfDiagnosticInfo();

                    // check each monitored item for data changes to send.
                    foreach (MonitoredItem monitoredItem in m_monitoredItems.Values)
                    {
                        while (monitoredItem.Values.Count > 0)
                        {
                            MonitoredItemNotification notification = new MonitoredItemNotification();

                            notification.ClientHandle = monitoredItem.Parameters.ClientHandle;
                            notification.Value = monitoredItem.Values.Dequeue();

                            notifications.Add(notification);
                            diagnosticInfos.Add(monitoredItem.DiagnosticInfos.Dequeue());
                        }
                    }

                    // check if any notifications were found.
                    if (notifications.Count > 0)
                    {
                        // subscriptions can produce different types of notifications so the notification parameter 
                        // is an extensible parameter. This means the object must be manually serialized and wrapped in
                        // an ExtensionObject which specifies the type of data contained in the Body. The complete
                        // UA SDK takes care this housekeeping and will serialize extensible parameters automatically.

                        DataChangeNotification body = new DataChangeNotification();

                        body.MonitoredItems = notifications;
                        body.DiagnosticInfos = diagnosticInfos;
                        
                        ExtensionObject extension = new ExtensionObject(
                            new ExpandedNodeId(Objects.DataChangeNotification_Encoding_DefaultXml),
                            body);

                        // construct the message and assign a new sequence number.
                        NotificationMessage message = new NotificationMessage();

                        message.SequenceNumber = ++m_nextSequenceNumber;
                        message.PublishTime = DateTime.UtcNow;
                        message.NotificationData = new ListOfExtensionObject();

                        message.NotificationData.Add(extension);

                        m_lastPublishTime = currentTime;
                        m_nextKeepAliveTime = (long)(currentTime + m_publishingInterval * m_keepAliveCount);

                        return message;
                    }
                }

                // check if it is time for a keep alive.
                if (m_nextKeepAliveTime < currentTime)
                {
                    NotificationMessage message = new NotificationMessage();

                    message.SequenceNumber = m_nextSequenceNumber;
                    message.PublishTime = DateTime.UtcNow;
                    message.NotificationData = new ListOfExtensionObject();

                    m_nextKeepAliveTime = (long)(currentTime + m_publishingInterval * m_keepAliveCount);

                    return message;
                }

                return null;
            }
        }

        /// <summary>
        /// Creates a monitored item.
        /// </summary>
        public void CreateMonitoredItem(
            TimestampsToReturn timestampsToReturn,
            MonitoredItemCreateRequest request,
            MonitoredItemCreateResult result,
            DiagnosticInfo diagnosticInfo)
        {
            lock (m_lock)
            {
                // initialize the monitored item.
                MonitoredItem monitoredItem = new MonitoredItem();

                monitoredItem.Id = (uint)Interlocked.Increment(ref m_monitoredItemCounter);
                monitoredItem.ItemToMonitor = request.ItemToMonitor;
                monitoredItem.MonitoringMode = request.MonitoringMode;
                monitoredItem.Parameters = request.RequestedParameters;
                monitoredItem.NextScanTime = 0;

                // use the publishing interval as the default.
                if (monitoredItem.Parameters.SamplingInterval < 0)
                {
                    monitoredItem.Parameters.SamplingInterval = m_publishingInterval;
                }

                // ensure the queue is at least one.
                if (monitoredItem.Parameters.QueueSize == 0)
                {
                    monitoredItem.Parameters.QueueSize = 1;
                }

                result.MonitoredItemId = monitoredItem.Id;
                result.RevisedQueueSize = monitoredItem.Parameters.QueueSize;
                result.RevisedSamplingInterval = monitoredItem.Parameters.SamplingInterval;
                result.FilterResult = new ExtensionObject();

                m_monitoredItems.Add(monitoredItem.Id, monitoredItem);

                // start a background thread that scans the items.
                if (m_monitoredItems.Count == 1)
                {
                    ThreadPool.QueueUserWorkItem(OnScanItems);
                }
            }
        }

        /// <summary>
        /// Periodically reads the values for the monitored items and queues the data changes.
        /// </summary>
        private void OnScanItems(object state)
        {
            List<MonitoredItem> monitoredItems = new List<MonitoredItem>();

            while (true)
            {
                monitoredItems.Clear();

                long currentTime = DateTime.UtcNow.Ticks/TimeSpan.TicksPerMillisecond;

                // build list of items that are ready to scan.
                lock (m_lock)
                {
                    foreach (MonitoredItem monitoredItem in m_monitoredItems.Values)
                    {
                        if (monitoredItem.NextScanTime < currentTime)
                        {
                            monitoredItems.Add(monitoredItem);
                        }
                    }
                }

                // read the value for each monitored item.
                foreach (MonitoredItem monitoredItem in monitoredItems)
                {
                    lock (m_lock)
                    {
                        DataValue result = new DataValue();
                        DiagnosticInfo diagnosticInfo = new DiagnosticInfo();

                        m_nodeManager.Read(
                            monitoredItem.ItemToMonitor,
                            result,
                            diagnosticInfo);

                        monitoredItem.NextScanTime += (long)monitoredItem.Parameters.SamplingInterval;

                        // check if the value has changed.
                        if (HasValueChanged(result, monitoredItem.LastValue))
                        {
                            monitoredItem.Values.Enqueue(result);
                            monitoredItem.DiagnosticInfos.Enqueue(diagnosticInfo);
                            monitoredItem.LastValue = result;

                            while (monitoredItem.Values.Count > monitoredItem.Parameters.QueueSize)
                            {
                                monitoredItem.Values.Dequeue();
                                monitoredItem.DiagnosticInfos.Dequeue();
                            }
                        }
                    }
                }

                Thread.Sleep(100);
            }
        }
        #endregion

        #region MonitoredItem Class
        /// <summary>
        /// Stores the state and the queued data changes for a monitored item.
        /// </summary>
        private class MonitoredItem
        {
            public uint Id;
            public ReadValueId ItemToMonitor;
            public MonitoringMode MonitoringMode;
            public MonitoringParameters Parameters;
            public Queue<DataValue> Values = new Queue<DataValue>();
            public Queue<DiagnosticInfo> DiagnosticInfos = new Queue<DiagnosticInfo>();
            public long NextScanTime;
            public DataValue LastValue;
        }
        #endregion

        #region Helper Functions
        /// <summary>
        /// Compares an old value to a new value (only supports a limited set of datatypes at this time).
        /// </summary>
        private bool HasValueChanged(DataValue newValue, DataValue oldValue)
        {
            if (oldValue == null || newValue == null)
            {
                return true;
            }

            if (oldValue.StatusCode != newValue.StatusCode)
            {
                return true;
            }

            object value1 = Variant.ToObject(oldValue.Value);
            object value2 = Variant.ToObject(newValue.Value);

            if (value1 == null || value2 == null)
            {
                return !Object.ReferenceEquals(value1, value2);
            }

            if (value1.GetType() != value2.GetType())
            {
                return true;
            }

            switch (value1.GetType().Name)
            {
                case "Byte": { return (byte)value1 != (byte)value2; }
                case "SByte": { return (sbyte)value1 != (sbyte)value2; }
                case "Int16": { return (short)value1 != (short)value2; }
                case "UInt16": { return (ushort)value1 != (ushort)value2; }
                case "Int32": { return (int)value1 != (int)value2; }
                case "UInt32": { return (uint)value1 != (uint)value2; }
                case "Int64": { return (long)value1 != (long)value2; }
                case "UInt64": { return (ulong)value1 != (ulong)value2; }
                case "Single": { return (float)value1 != (float)value2; }
                case "Double": { return (double)value1 != (double)value2; }
                case "String": { return (string)value1 != (string)value2; }
                case "DateTime": { return (DateTime)value1 != (DateTime)value2; }
                case "NodeId": { return (NodeId)value1 != (NodeId)value2; }
                case "ExpandedNodeId": { return (ExpandedNodeId)value1 != (ExpandedNodeId)value2; }
                case "LocalizedText": { return (LocalizedText)value1 != (LocalizedText)value2; }
                case "QualifiedName": { return (QualifiedName)value1 != (QualifiedName)value2; }
                case "StatusCode": { return (StatusCode)value1 != (StatusCode)value2; }
            }

            return true;
        }
        #endregion

        #region Private Fields
        private object m_lock = new object();
        private Session m_session;
        private NodeManager m_nodeManager;
        private uint m_subscriptionId;
        private double m_publishingInterval;
        private uint m_lifetimeCount;
        private uint m_keepAliveCount;
        private uint m_maxNotificationCount;
        private bool m_publishingEnabled;
        private byte m_priority;
        private long m_lastPublishTime;
        private long m_nextKeepAliveTime;
        private uint m_nextSequenceNumber;
        private Dictionary<uint, MonitoredItem> m_monitoredItems = new Dictionary<uint, MonitoredItem>();

        private static int m_subscriptionCounter;
        private static int m_monitoredItemCounter;
        #endregion
    }
}
