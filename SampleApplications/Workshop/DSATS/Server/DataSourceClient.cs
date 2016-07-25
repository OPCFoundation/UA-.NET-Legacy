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
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Runtime.Serialization;
using Opc.Ua;
using Opc.Ua.Client;
using Opc.Ua.Client.Controls;

namespace DsatsDemoServer
{
    /// <summary>
    /// Provides access to data stored in another UA server.
    /// </summary>
    public class DataSourceClient
    {
        public DataSourceClient(ApplicationConfiguration configuration)
        {
            DataContractSerializer serializer = new DataContractSerializer(configuration.GetType()); 

            // serialize and reload configuration to ensure object has its own copy.
            MemoryStream ostrm = new MemoryStream();

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = System.Text.Encoding.UTF8;
            settings.Indent = false;
            settings.CloseOutput = true;
            settings.ConformanceLevel = ConformanceLevel.Document;
            settings.OmitXmlDeclaration = false;

            XmlWriter writer = XmlDictionaryWriter.Create(ostrm, settings);

            try
            {
                serializer.WriteObject(writer, configuration);
            }
            finally
            {
                writer.Close();
            }

            MemoryStream istrm = new MemoryStream(ostrm.ToArray());
            XmlReader reader = XmlReader.Create(istrm);
            m_configuration = (ApplicationConfiguration)serializer.ReadObject(reader, false);
            m_configuration.Validate(ApplicationType.Client);

            // always accept server certificates.
            m_CertificateValidation = new CertificateValidationEventHandler(CertificateValidator_CertificateValidation);
            m_configuration.CertificateValidator.CertificateValidation += m_CertificateValidation;

            m_monitoredItems = new Dictionary<uint, MonitoredItem>();
        }

        #region Public Methods
        /// <summary>
        /// Creates a new session.
        /// </summary>
        public void Connect(string serverUrl, bool useSecurity)
        {
            lock (m_lock)
            {
                // disconnect from existing session.
                Disconnect();

                try
                {
                    m_serverUrl = serverUrl;
                    m_useSecurity = useSecurity;

                    // select the best endpoint.
                    EndpointDescription endpointDescription = ClientUtils.SelectEndpoint(serverUrl, useSecurity);

                    EndpointConfiguration endpointConfiguration = EndpointConfiguration.Create(m_configuration);
                    ConfiguredEndpoint endpoint = new ConfiguredEndpoint(null, endpointDescription, endpointConfiguration);

                    m_session = Session.Create(
                        m_configuration,
                        endpoint,
                        false,
                        false, // domainCheck should be true (waiting for fix for NOV server).
                        m_configuration.ApplicationName,
                        60000,
                        null,
                        null);

                    // set up keep alive callback.
                    m_session.KeepAlive += new KeepAliveEventHandler(Session_KeepAlive);

                    m_subscription = new Subscription(m_session.DefaultSubscription);

                    m_subscription.PublishingEnabled = true;
                    m_subscription.PublishingInterval = 100;
                    m_subscription.KeepAliveCount = 100;
                    m_subscription.LifetimeCount = 100;
                    m_subscription.MaxNotificationsPerPublish = 10000;
                    m_subscription.Priority = 100;
                    m_subscription.DisableMonitoredItemCache = true;
                    m_subscription.FastDataChangeCallback = MonitoredItem_Notification;

                    m_session.AddSubscription(m_subscription);

                    m_subscription.Create();
                }
                catch (Exception e)
                {
                    Utils.Trace("Connect failed. Attempting reconnect. {0}", e.Message);

                    if (m_connectTimer != null)
                    {
                        m_connectTimer.Dispose();
                        m_connectTimer = null;
                    }

                    m_connectTimer = new System.Threading.Timer(OnConnect, null, 10000, System.Threading.Timeout.Infinite);
                }
            }
        }

        private void OnConnect(object state)
        {
            try
            {
                Connect(m_serverUrl, m_useSecurity);
            }
            catch (Exception e)
            {
                Utils.Trace("Connect failed. Attempting reconnect. {0}", e.Message);

                if (m_connectTimer != null)
                {
                    m_connectTimer.Dispose();
                    m_connectTimer = null;
                }

                m_connectTimer = new System.Threading.Timer(OnConnect, null, 10000, System.Threading.Timeout.Infinite);
            }
        }

        /// <summary>
        /// Disconnects from the server.
        /// </summary>
        public void Disconnect()
        {
            lock (m_lock)
            {
                // stop any reconnect operation.
                if (m_reconnectHandler != null)
                {
                    m_reconnectHandler.Dispose();
                    m_reconnectHandler = null;
                }

                // disconnect any existing session.
                if (m_session != null)
                {
                    m_session.Close(10000);
                    m_session = null;
                }
            }
        }

        public class ReadRequest
        {
            public ExpandedNodeId RemoteId { get; set; }
            public ReadValueId ReadValueId { get; set; }
            public DataValue Value { get; set; }
            public int Index { get; set; }
        }

        /// <summary>
        /// Handles a read request.
        /// </summary>
        public List<ServiceResult> Read(List<ReadRequest> requests)
        {
            if (m_session == null)
            {
                throw new ServiceResultException(StatusCodes.BadCommunicationError);
            }

            ReadValueIdCollection valuesToRead = new ReadValueIdCollection();

            for (int ii = 0; ii < requests.Count; ii++)
            {
                ReadValueId valueToRead = new ReadValueId();
                valueToRead.NodeId = ExpandedNodeId.ToNodeId(requests[ii].RemoteId, m_session.NamespaceUris);
                valueToRead.AttributeId = requests[ii].ReadValueId.AttributeId;
                valueToRead.IndexRange = requests[ii].ReadValueId.IndexRange;
                valueToRead.DataEncoding = requests[ii].ReadValueId.DataEncoding;
                valuesToRead.Add(valueToRead);
            }

            DataValueCollection results = null;
            DiagnosticInfoCollection diagnosticInfos = null;

            ResponseHeader responseHeader = m_session.Read(
                null,
                0,
                TimestampsToReturn.Both,
                valuesToRead,
                out results,
                out diagnosticInfos);

            Session.ValidateResponse(results, valuesToRead);
            Session.ValidateDiagnosticInfos(diagnosticInfos, valuesToRead);

            List<ServiceResult> errors = new List<ServiceResult>();

            for (int ii = 0; ii < requests.Count; ii++)
            {
                requests[ii].Value = results[ii];

                if (results[ii].StatusCode != StatusCodes.Good)
                {
                    errors.Add(new ServiceResult(results[ii].StatusCode, ii, diagnosticInfos, responseHeader.StringTable));
                }
                else
                {
                    errors.Add(null);
                }
            }

            return errors;
        }

        public class WriteRequest
        {
            public ExpandedNodeId RemoteId { get; set; }
            public WriteValue WriteValue { get; set; }
            public int Index { get; set; }
        }

        /// <summary>
        /// Handles a write request.
        /// </summary>
        public List<ServiceResult> Write(List<WriteRequest> requests)
        {
            if (m_session == null)
            {
                throw new ServiceResultException(StatusCodes.BadCommunicationError);
            }

            WriteValueCollection valuesToWrite = new WriteValueCollection();

            for (int ii = 0; ii < requests.Count; ii++)
            {
                WriteValue valueToWrite = new WriteValue();
                valueToWrite.NodeId = ExpandedNodeId.ToNodeId(requests[ii].RemoteId, m_session.NamespaceUris);
                valueToWrite.AttributeId = requests[ii].WriteValue.AttributeId;
                valueToWrite.IndexRange = requests[ii].WriteValue.IndexRange;
                valueToWrite.Value = requests[ii].WriteValue.Value;
                valuesToWrite.Add(valueToWrite);
            }

            StatusCodeCollection results = null;
            DiagnosticInfoCollection diagnosticInfos = null;

            ResponseHeader responseHeader = m_session.Write(
                null,
                valuesToWrite,
                out results,
                out diagnosticInfos);

            Session.ValidateResponse(results, valuesToWrite);
            Session.ValidateDiagnosticInfos(diagnosticInfos, valuesToWrite);

            List<ServiceResult> errors = new List<ServiceResult>();

            for (int ii = 0; ii < requests.Count; ii++)
            {
                if (results[ii] != StatusCodes.Good)
                {
                    errors.Add(new ServiceResult(results[ii], ii, diagnosticInfos, responseHeader.StringTable));
                }
                else
                {
                    errors.Add(null);
                }
            }

            return errors;
        }


        public class MonitoringRequest
        {
            public ExpandedNodeId RemoteId { get; set; }
            public Opc.Ua.Server.MonitoredItem MonitoredItem { get; set; }
            public int Index { get; set; }
        }

        /// <summary>
        /// Handles a create monitored item request.
        /// </summary>
        public void CreateMonitoredItems(List<MonitoringRequest> requests)
        {
            lock (m_lock)
            {
                if (m_session == null)
                {
                    throw new ServiceResultException(StatusCodes.BadCommunicationError);
                }

                List<MonitoredItem> remoteMonitoredItems = new List<MonitoredItem>();

                for (int ii = 0; ii < requests.Count; ii++)
                {
                    MonitoredItem monitoredItem = new MonitoredItem(m_subscription.DefaultItem);

                    monitoredItem.StartNodeId = ExpandedNodeId.ToNodeId(requests[ii].RemoteId, m_session.NamespaceUris);
                    monitoredItem.AttributeId = requests[ii].MonitoredItem.AttributeId;
                    monitoredItem.MonitoringMode = requests[ii].MonitoredItem.MonitoringMode;
                    monitoredItem.SamplingInterval = (int)(requests[ii].MonitoredItem.SamplingInterval * 0.75);
                    monitoredItem.QueueSize = requests[ii].MonitoredItem.QueueSize;
                    monitoredItem.DiscardOldest = true;
                    monitoredItem.Filter = requests[ii].MonitoredItem.Filter;
                    monitoredItem.Handle = requests[ii].MonitoredItem;

                    m_subscription.AddItem(monitoredItem);
                    remoteMonitoredItems.Add(monitoredItem);
                }

                m_subscription.ApplyChanges();

                for (int ii = 0; ii < requests.Count; ii++)
                {
                    m_monitoredItems[requests[ii].MonitoredItem.Id] = remoteMonitoredItems[ii];

                    if (ServiceResult.IsBad(remoteMonitoredItems[ii].Status.Error))
                    {
                        requests[ii].MonitoredItem.QueueValue(null, remoteMonitoredItems[ii].Status.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Handles a modify monitored item request.
        /// </summary>
        public void ModifyMonitoredItems(List<MonitoringRequest> requests)
        {
            lock (m_lock)
            {
                if (m_session == null)
                {
                    throw new ServiceResultException(StatusCodes.BadCommunicationError);
                }

                for (int ii = 0; ii < requests.Count; ii++)
                {
                    MonitoredItem monitoredItem = null;

                    if (!m_monitoredItems.TryGetValue(requests[ii].MonitoredItem.Id, out monitoredItem))
                    {
                        continue;
                    }

                    monitoredItem.SamplingInterval = (int)(requests[ii].MonitoredItem.SamplingInterval * 0.75);
                    monitoredItem.QueueSize = requests[ii].MonitoredItem.QueueSize;
                    monitoredItem.DiscardOldest = true;
                    monitoredItem.Filter = requests[ii].MonitoredItem.Filter;
                }

                m_subscription.ApplyChanges();
            }
        }
        
        /// <summary>
        /// Handles a delete monitored item request.
        /// </summary>
        public void DeleteMonitoredItems(List<MonitoringRequest> requests)
        {
            lock (m_lock)
            {
                for (int ii = 0; ii < requests.Count; ii++)
                {
                    MonitoredItem remoteMonitoredItem = null;

                    if (m_monitoredItems.TryGetValue(requests[ii].MonitoredItem.Id, out remoteMonitoredItem))
                    {
                        if (m_subscription != null)
                        {
                            m_subscription.RemoveItem(remoteMonitoredItem);
                        }

                        m_monitoredItems.Remove(requests[ii].MonitoredItem.Id);
                    }
                }

                if (m_subscription != null)
                {
                    m_subscription.ApplyChanges();
                }
            }
        }

        /// <summary>
        /// Handles a set monitoring mode request.
        /// </summary>
        public void SetMonitoringMode(List<MonitoringRequest> requests)
        {
            lock (m_lock)
            {
                if (m_session == null)
                {
                    throw new ServiceResultException(StatusCodes.BadCommunicationError);
                }

                for (int ii = 0; ii < requests.Count; ii++)
                {
                    MonitoredItem monitoredItem = null;

                    if (!m_monitoredItems.TryGetValue(requests[ii].MonitoredItem.Id, out monitoredItem))
                    {
                        continue;
                    }

                    monitoredItem.MonitoringMode = requests[ii].MonitoredItem.MonitoringMode;
                }

                m_subscription.ApplyChanges();
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Handles a datachange notifications.
        /// </summary>
        private void MonitoredItem_Notification(Subscription subscription, DataChangeNotification notification, IList<string> stringTable)
        {
            if (!Object.ReferenceEquals(subscription, m_subscription))
            {
                return;
            }

            lock (m_lock)
            {
                for (int ii = 0; ii < notification.MonitoredItems.Count; ii++)
                {
                    MonitoredItem monitoredItem = m_subscription.FindItemByClientHandle(notification.MonitoredItems[ii].ClientHandle);

                    if (monitoredItem != null)
                    {
                        Opc.Ua.Server.MonitoredItem localItem = (Opc.Ua.Server.MonitoredItem)monitoredItem.Handle;
                        localItem.QueueValue(notification.MonitoredItems[ii].Value, null);
                    }
                }
            }
        }

        /// <summary>
        /// Handles a keep alive event from a session.
        /// </summary>
        private void Session_KeepAlive(Session session, KeepAliveEventArgs e)
        {
            try
            {
                // check for events from discarded sessions.
                if (!Object.ReferenceEquals(session, m_session))
                {
                    return;
                }

                // start reconnect sequence on communication error.
                if (ServiceResult.IsBad(e.Status))
                {
                    lock (m_lock)
                    {
                        if (m_reconnectPeriod <= 0)
                        {
                            return;
                        }

                        BeginReconnect();
                    }
                }
            }
            catch (Exception exception)
            {
                Utils.Trace(exception, "Unexpected error handling keep alive.");
            }
        }

        private void BeginReconnect()
        {
            if (m_subscription != null)
            {
                foreach (MonitoredItem monitoredItem in m_subscription.MonitoredItems)
                {
                    Opc.Ua.Server.MonitoredItem localItem = (Opc.Ua.Server.MonitoredItem)monitoredItem.Handle;
                    localItem.QueueValue(null, StatusCodes.BadDeviceFailure);
                }
            }

            if (m_reconnectHandler == null)
            {
                m_reconnectHandler = new SessionReconnectHandler();
                m_reconnectHandler.BeginReconnect(m_session, m_reconnectPeriod * 1000, Server_ReconnectComplete);
            }

            m_session = null;
            m_subscription = null;
        }

        /// <summary>
        /// Handles a reconnect event complete from the reconnect handler.
        /// </summary>
        private void Server_ReconnectComplete(object sender, EventArgs e)
        {
            try
            {
                // ignore callbacks from discarded objects.
                if (!Object.ReferenceEquals(sender, m_reconnectHandler))
                {
                    return;
                }

                lock (m_lock)
                {
                    m_session = m_reconnectHandler.Session;
                    m_reconnectHandler.Dispose();
                    m_reconnectHandler = null;

                    foreach (Subscription subscription in m_session.Subscriptions)
                    {
                        m_subscription = subscription;
                        break;
                    }

                    if (m_subscription != null)
                    {
                        foreach (MonitoredItem monitoredItem in m_subscription.MonitoredItems)
                        {
                            Opc.Ua.Server.MonitoredItem localItem = (Opc.Ua.Server.MonitoredItem)monitoredItem.Handle;

                            if (m_monitoredItems.ContainsKey(localItem.Id))
                            {
                                m_monitoredItems[localItem.Id] = monitoredItem;
                            }
                            else
                            {
                                m_subscription.RemoveItem(monitoredItem);
                            }
                        }

                        m_subscription.ApplyChanges();
                    }
                }
            }
            catch (Exception exception)
            {
                Utils.Trace(exception, "Unexpected error doing reconnect.");
            }
        }

        /// <summary>
        /// Handles a certificate validation error.
        /// </summary>
        private void CertificateValidator_CertificateValidation(CertificateValidator sender, CertificateValidationEventArgs e)
        {
            e.Accept = true;
        }
        #endregion

        #region Private Fields
        private object m_lock = new object();
        private ApplicationConfiguration m_configuration;
        private string m_serverUrl;
        private bool m_useSecurity;
        private System.Threading.Timer m_connectTimer;
        private Session m_session;
        private Subscription m_subscription;
        private Dictionary<uint,MonitoredItem> m_monitoredItems;
        private int m_reconnectPeriod = 10;
        private SessionReconnectHandler m_reconnectHandler;
        private CertificateValidationEventHandler m_CertificateValidation;
        #endregion
    }
}
