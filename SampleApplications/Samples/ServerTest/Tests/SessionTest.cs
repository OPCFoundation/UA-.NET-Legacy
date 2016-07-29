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
    internal class SessionTest : TestBase
    {
        #region Constructors
        /// <summary>
        /// Creates the test object.
        /// </summary>
        public SessionTest(
            Session session,
            ServerTestConfiguration configuration,
            ReportMessageEventHandler reportMessage,
            ReportProgressEventHandler reportProgress,
            TestBase template)
        : 
            base("Activate", session, configuration, reportMessage, reportProgress, template)
        {
            m_errorEvent = new ManualResetEvent(false);
            m_messages = new Dictionary<uint,List<uint>>();
        }
        #endregion
        
        #region Public Methods
        /// <summary>
        /// Runs the test for all of the browse roots.
        /// </summary>
        public override bool Run(ServerTestCase testcase, int iteration)
        {
            Iteration = iteration;

            // do secondary test.
            switch (testcase.Name)
            {
                case "KeepAlive":
                {
                    return DoKeepAliveTest();
                }

                default:
                case "Reconnect":
                {
                    return DoReconnectTest();    
                }
            }
        }        
        #endregion
        
        #region Test Methods
        /// <summary>
        /// Tests the session reconnect.
        /// </summary>
        private bool DoReconnectTest()
        {
            double increment = MaxProgress/6;
            double position  = 0;

            bool success = true;
            
            lock (m_messages)
            {
                m_messages.Clear();
            }

            int currentKeepAlive = Session.KeepAliveInterval;
            List<Subscription> subscriptions = new List<Subscription>();
            KeepAliveEventHandler keepAliveHandler = new KeepAliveEventHandler(Session_Reconnect);
            NotificationEventHandler notificationHandler = new NotificationEventHandler(Session_Notification);

            try
            {
                Session.KeepAlive += keepAliveHandler;
                Session.Notification += notificationHandler;

                for (int publishingInterval = 1000; publishingInterval <= 10000; publishingInterval += 1000)
                {
                    Subscription subscription = new Subscription();

                    subscription.MaxMessageCount = 100;
                    subscription.LifetimeCount = 100;
                    subscription.KeepAliveCount = 10;
                    subscription.PublishingEnabled = true;
                    subscription.PublishingInterval = publishingInterval;

                    MonitoredItem monitoredItem = new MonitoredItem();

                    monitoredItem.StartNodeId = VariableIds.Server_ServerStatus_CurrentTime;
                    monitoredItem.AttributeId = Attributes.Value;
                    monitoredItem.SamplingInterval = -1;
                    monitoredItem.QueueSize = 0;
                    monitoredItem.DiscardOldest = true;

                    subscription.AddItem(monitoredItem);
                    Session.AddSubscription(subscription);
                    subscription.Create();
                    subscriptions.Add(subscription);
                }

                m_keepAliveCount = 0;
                Session.KeepAliveInterval = 1000;
                Log("Setting keep alive interval to {0}ms.", Session.KeepAliveInterval);

                int testDuration = 3000;

                for (int ii = 0; ii < 6; ii++)
                {
                    Session.Reconnect();

                    Log("Session reconnected. KeepAlives={0}", m_keepAliveCount);

                    if (m_errorEvent.WaitOne(testDuration, false))
                    {
                        Log("Unexpected error waiting for session keep alives. {0}", m_error.ToLongString());
                        return false;
                    }

                    position += increment;
                    ReportProgress(position);
                }
            }
            finally
            {
                Session.RemoveSubscriptions(subscriptions);
                Session.KeepAliveInterval = currentKeepAlive;
                Session.KeepAlive -= keepAliveHandler;
                Session.Notification -= notificationHandler;
            } 
                
            ReportProgress(MaxProgress);

            lock (m_messages)
            {
                foreach (KeyValuePair<uint,List<uint>> entry in m_messages)
                {
                    entry.Value.Sort();

                    for (int ii = 0; ii < entry.Value.Count-1; ii++)
                    {
                        if (entry.Value[ii+1] - entry.Value[ii] > 1)
                        {
                            Log("Missing message. Subscription={0}, SequenceNumber={1}-{2}", entry.Key, entry.Value[ii]+1, entry.Value[ii+1]-1);
                        }

                        if (entry.Value[ii+1] == entry.Value[ii])
                        {
                            // Log("Duplicate message. Subscription={0}, SequenceNumber={1}", entry.Key, entry.Value[ii]);
                        }
                    }
                }
            }

            return success;
        }

        void Session_Notification(Session session, NotificationEventArgs e)
        {            
            lock (m_messages)
            {
                List<uint> messages = null;

                if (!m_messages.TryGetValue(e.Subscription.Id, out messages))
                {
                    m_messages[e.Subscription.Id] = messages = new List<uint>();
                }

                messages.Add(e.NotificationMessage.SequenceNumber);
            }
        }

        /// <summary>
        /// Reports keep alive responses from the server.
        /// </summary>
        void Session_Reconnect(Session session, KeepAliveEventArgs e)
        {
            m_keepAliveCount++;

            if (ServiceResult.IsBad(e.Status))
            {
                if (m_keepAliveCount > 2)
                {
                    m_error = e.Status;
                    m_errorEvent.Set();
                }
            }
        }

        /// <summary>
        /// Tests the session keep alive when there are no errors. 
        /// </summary>
        private bool DoKeepAliveTest()
        {
            bool success = true;
            
            double increment = MaxProgress/3;
            double position  = 0;

            m_keepAliveCount = 0;

            int currentKeepAlive = Session.KeepAliveInterval;
            List<Subscription> subscriptions = new List<Subscription>();
            KeepAliveEventHandler handler = new KeepAliveEventHandler(Session_KeepAlive); 

            try
            {
                Session.KeepAlive += handler;

                // add several subscriptions with long publish intervals.
                for (int publishingInterval = 10000; publishingInterval <= 20000; publishingInterval += 1000)
                {
                    Subscription subscription = new Subscription();

                    subscription.MaxMessageCount = 100;
                    subscription.LifetimeCount = 100;
                    subscription.KeepAliveCount = 10;
                    subscription.PublishingEnabled = true;
                    subscription.PublishingInterval = publishingInterval;

                    MonitoredItem monitoredItem = new MonitoredItem();

                    monitoredItem.StartNodeId = VariableIds.Server_ServerStatus_CurrentTime;
                    monitoredItem.AttributeId = Attributes.Value;
                    monitoredItem.SamplingInterval = -1;
                    monitoredItem.QueueSize = 0;
                    monitoredItem.DiscardOldest = true;

                    subscription.AddItem(monitoredItem);
                    Session.AddSubscription(subscription);
                    subscription.Create();
                    subscriptions.Add(subscription);
                }
                
                // get a value to read.
                ReadValueId nodeToRead = new ReadValueId();
                nodeToRead.NodeId = VariableIds.Server_ServerStatus;
                nodeToRead.AttributeId = Attributes.Value;
                ReadValueIdCollection nodesToRead = new ReadValueIdCollection();
                nodesToRead.Add(nodeToRead);

                int testDuration = 5000;

                // make sure the keep alives come at the expected rate.
                for (int keepAliveInterval = 500; keepAliveInterval < 2000; keepAliveInterval += 500)
                {
                    m_keepAliveCount = 0;

                    DateTime start = DateTime.UtcNow;
                    
                    DataValueCollection results = null;
                    DiagnosticInfoCollection diagnosticsInfos = null;

                    Session.Read(
                        null,
                        0,
                        TimestampsToReturn.Neither,
                        nodesToRead,
                        out results,
                        out diagnosticsInfos);

                    ClientBase.ValidateResponse(results, nodesToRead);
                    ClientBase.ValidateDiagnosticInfos(diagnosticsInfos, nodesToRead);

                    ServerStatusDataType status = ExtensionObject.ToEncodeable(results[0].Value as ExtensionObject) as ServerStatusDataType;

                    if (status == null)
                    {
                        Log("Server did not return a valid ServerStatusDataType structure. Value={0}, Status={1}", results[0].WrappedValue, results[0].StatusCode);
                        return false;
                    }

                    if ((DateTime.UtcNow - start).TotalSeconds > 1)
                    {
                        Log("Unexpected delay reading the ServerStatus structure. Delay={0}s", (DateTime.UtcNow - start).TotalSeconds);
                        return false;
                    }

                    Log("Setting keep alive interval to {0}ms.", keepAliveInterval);

                    Session.KeepAliveInterval = keepAliveInterval;

                    if (m_errorEvent.WaitOne(testDuration, false))
                    {
                        Log("Unexpected error waiting for session keep alives. {0}", m_error.ToLongString());
                        return false;
                    }

                    if (m_keepAliveCount < testDuration / keepAliveInterval)
                    {
                        Log("Missing session keep alives. Expected={0}, Actual={1}", testDuration / keepAliveInterval, m_keepAliveCount);
                        return false;
                    }

                    Log("{0} keep alives received in {1}ms.", m_keepAliveCount, testDuration);

                    position += increment;
                    ReportProgress(position);
                }

                ReportProgress(MaxProgress);
            }
            finally
            {
                Session.RemoveSubscriptions(subscriptions);
                Session.KeepAliveInterval = currentKeepAlive;
                Session.KeepAlive -= handler;
            }

            return success;
        }

        /// <summary>
        /// Reports keep alive responses from the server.
        /// </summary>
        void Session_KeepAlive(Session session, KeepAliveEventArgs e)
        {
            if (ServiceResult.IsBad(e.Status))
            {
                m_error = e.Status;
                m_errorEvent.Set();
                return;
            }
            
            m_keepAliveCount++;
        }
        #endregion
        
        #region Private Fields
        private ManualResetEvent m_errorEvent;
        private int m_keepAliveCount;
        private Dictionary<uint,List<uint>> m_messages;
        private ServiceResult m_error;
        #endregion
    }
}
