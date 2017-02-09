using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Threading;
using Opc.Ua;
using Opc.Ua.Client;
using Opc.Ua.Client.Controls;
using Opc.Ua.Bindings;

namespace AmqpTestServer
{
    /// <summary>
    /// A tool bar used to connect to a server.
    /// </summary>
    public partial class InternalClient
    {
        #region Private Fields
        private ApplicationConfiguration m_configuration;
        private Session m_session;
        private int m_reconnectPeriod = 10;
        private SessionReconnectHandler m_reconnectHandler;
        private Subscription m_subscription;
        private List<MessageWriterData> m_writers;
        private Opc.Ua.Bindings.AmqpBrokerConfigurationCollection m_brokers;
        private Opc.Ua.Bindings.AmqpDataSetConfigurationCollection m_datasets;
        private int m_tokenLifetime;
        private Timer m_renewTokenTimer;
        #endregion

        private class MessageWriterData
        {
            public string PublisherId;
            public string DataSetWriterId;
            public string DataSetClassId;
            public string MetadataNodeName;
            public uint SequenceNumber;
            public Opc.Ua.Bindings.IAmqpConnection Connection;
        }

        #region Constructors
        /// <summary>
        /// Initializes the object.
        /// </summary>
        public InternalClient(ApplicationConfiguration configuration)
        {
            Configuration = configuration;
            m_brokers = AmqpBrokerConfigurationCollection.Load(configuration);
            m_datasets = AmqpDataSetConfigurationCollection.Load(configuration);
            m_writers = new List<MessageWriterData>();
            m_tokenLifetime = 10*60*1000;
        }
        #endregion

        #region Public Members
        /// <summary>
        /// The name of the session to create.
        /// </summary>
        public string SessionName { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating that the domain checks should be ignored when connecting.
        /// </summary>
        public bool DisableDomainCheck { get; set; }

        /// <summary>
        /// The URL displayed in the control.
        /// </summary>
        public string ServerUrl { get; set; }

        /// <summary>
        /// Whether to use security when connecting.
        /// </summary>
        public bool UseSecurity { get; set; }

        /// <summary>
        /// The locales to use when creating the session.
        /// </summary>
        public string[] PreferredLocales { get; set; }

        /// <summary>
        /// The user identity to use when creating the session.
        /// </summary>
        public IUserIdentity UserIdentity { get; set; }

        /// <summary>
        /// The client application configuration.
        /// </summary>
        public ApplicationConfiguration Configuration
        {
            get { return m_configuration; }

            private set
            {
                if (!Object.ReferenceEquals(m_configuration, value))
                {
                    if (m_configuration != null)
                    {
                        m_configuration.CertificateValidator.CertificateValidation -= new CertificateValidationEventHandler(CertificateValidator_CertificateValidation);
                    }

                    m_configuration = value;

                    if (m_configuration != null)
                    {
                        m_configuration.CertificateValidator.CertificateValidation += new CertificateValidationEventHandler(CertificateValidator_CertificateValidation);
                    }
                }
            }
        }

        /// <summary>
        /// The currently active session. 
        /// </summary>
        public Session Session
        {
            get { return m_session; }
        }

        /// <summary>
        /// The number of seconds between reconnect attempts (0 means reconnect is disabled).
        /// </summary>
        public int ReconnectPeriod
        {
            get { return m_reconnectPeriod; }
            set { m_reconnectPeriod = value; }
        }

        /// <summary>
        /// Creates a new session.
        /// </summary>
        /// <returns>The new session object.</returns>
        public Session Connect()
        {
            // disconnect from existing session.
            Disconnect();

            // select the best endpoint.
            EndpointDescription endpointDescription = EndpointDescription.SelectEndpoint(m_configuration, ServerUrl, UseSecurity);

            EndpointConfiguration endpointConfiguration = EndpointConfiguration.Create(m_configuration);
            ConfiguredEndpoint endpoint = new ConfiguredEndpoint(null, endpointDescription, endpointConfiguration);

            m_session = Session.Create(
                m_configuration,
                endpoint,
                false,
                !DisableDomainCheck,
                (String.IsNullOrEmpty(SessionName)) ? m_configuration.ApplicationName : SessionName,
                60000,
                UserIdentity,
                PreferredLocales);

            // set up keep alive callback.
            m_session.KeepAlive += new KeepAliveEventHandler(Session_KeepAlive);

            CreateSubscription();

            // return the new session.
            return m_session;
        }

        /// <summary>
        /// Creates a new session.
        /// </summary>
        /// <param name="serverUrl">The URL of a server endpoint.</param>
        /// <param name="useSecurity">Whether to use security.</param>
        /// <returns>The new session object.</returns>
        public Session Connect(string serverUrl, bool useSecurity)
        {
            ServerUrl = serverUrl;
            UseSecurity = useSecurity;
            return Connect();
        }

        /// <summary>
        /// Disconnects from the server.
        /// </summary>
        public void Disconnect()
        {
            if (m_renewTokenTimer != null)
            {
                m_renewTokenTimer.Dispose();
                m_renewTokenTimer = null;
            }

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
        #endregion


        #region Private Methods
        private async Task<IAmqpConnection> CreateConnectionAsync(AmqpConnectionConfiguration configuration)
        {
            UriBuilder url = new UriBuilder(configuration.BrokerUrl);

            string serverKeyName = null;
            string serverKeyValue = null;

            var key = m_brokers.FindTargetKeys(url.Uri, configuration.TargetName);

            if (key == null)
            {
                throw new ArgumentException("Cannot find the broker configuration");
            }

            serverKeyName = key.KeyName;
            serverKeyValue = key.KeyValue;

            if (!key.UseSasl)
            {
                url.UserName = serverKeyName;
                url.Password = serverKeyValue;
            }

            AmqpListenerSettings settings = new AmqpListenerSettings()
            {
                UseSasl = key.UseSasl,
                TokenRenewalInterval = (uint)m_tokenLifetime
            };

            var connection = new GenericAmqpConnection(url.ToString(), settings);
            await connection.OpenAsync(key.TargetName, serverKeyName, serverKeyValue);

            return connection;
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// Handles a keep alive event from a session.
        /// </summary>
        private void Session_KeepAlive(Session session, KeepAliveEventArgs e)
        {
            // check for events from discarded sessions.
            if (!Object.ReferenceEquals(session, m_session))
            {
                return;
            }

            // start reconnect sequence on communication error.
            if (ServiceResult.IsBad(e.Status))
            {
                if (m_reconnectPeriod <= 0)
                {
                    return;
                }

                if (m_reconnectHandler == null)
                {
                    m_reconnectHandler = new SessionReconnectHandler();
                    m_reconnectHandler.BeginReconnect(m_session, m_reconnectPeriod * 1000, Server_ReconnectComplete);
                }

                return;
            }
        }

        /// <summary>
        /// Handles a reconnect event complete from the reconnect handler.
        /// </summary>
        private void Server_ReconnectComplete(object sender, EventArgs e)
        {
            // ignore callbacks from discarded objects.
            if (!Object.ReferenceEquals(sender, m_reconnectHandler))
            {
                return;
            }

            m_session = m_reconnectHandler.Session;
            m_reconnectHandler.Dispose();
            m_reconnectHandler = null;
        }

        static public SimpleAttributeOperandCollection GetSelectClause()
        {
            var selectClause = new SimpleAttributeOperandCollection();

            SimpleAttributeOperand operand = null;

            operand = new SimpleAttributeOperand();
            operand.TypeDefinitionId = Opc.Ua.ObjectTypeIds.BaseEventType;
            operand.AttributeId = Attributes.Value;
            operand.BrowsePath.Add(BrowseNames.EventId);
            selectClause.Add(operand);

            operand = new SimpleAttributeOperand();
            operand.TypeDefinitionId = Opc.Ua.ObjectTypeIds.BaseEventType;
            operand.AttributeId = Attributes.Value;
            operand.BrowsePath.Add(BrowseNames.SourceNode);
            selectClause.Add(operand);

            operand = new SimpleAttributeOperand();
            operand.TypeDefinitionId = Opc.Ua.ObjectTypeIds.BaseEventType;
            operand.AttributeId = Attributes.Value;
            operand.BrowsePath.Add(BrowseNames.SourceName);
            selectClause.Add(operand);

            operand = new SimpleAttributeOperand();
            operand.TypeDefinitionId = Opc.Ua.ObjectTypeIds.BaseEventType;
            operand.AttributeId = Attributes.Value;
            operand.BrowsePath.Add(BrowseNames.EventType);
            selectClause.Add(operand);

            operand = new SimpleAttributeOperand();
            operand.TypeDefinitionId = Opc.Ua.ObjectTypeIds.BaseEventType;
            operand.AttributeId = Attributes.Value;
            operand.BrowsePath.Add(BrowseNames.Time);
            selectClause.Add(operand);

            operand = new SimpleAttributeOperand();
            operand.TypeDefinitionId = Opc.Ua.ObjectTypeIds.BaseEventType;
            operand.AttributeId = Attributes.Value;
            operand.BrowsePath.Add(BrowseNames.ReceiveTime);
            selectClause.Add(operand);

            operand = new SimpleAttributeOperand();
            operand.TypeDefinitionId = Opc.Ua.ObjectTypeIds.BaseEventType;
            operand.AttributeId = Attributes.Value;
            operand.BrowsePath.Add(BrowseNames.Message);
            selectClause.Add(operand);

            operand = new SimpleAttributeOperand();
            operand.TypeDefinitionId = Opc.Ua.ObjectTypeIds.BaseEventType;
            operand.AttributeId = Attributes.Value;
            operand.BrowsePath.Add(BrowseNames.Severity);
            selectClause.Add(operand);

            return selectClause;
        }

        /// <summary>
        /// Creates the subscription.
        /// </summary>
        private void CreateSubscription()
        {
            // create link for reporting events.
            UriBuilder builder = new UriBuilder();

            foreach (var dataset in m_datasets)
            {
                if (dataset.Connections != null)
                {
                    foreach (var connection in dataset.Connections)
                    {
                        var task = CreateConnectionAsync(connection);
                        task.Wait(10000);

                        m_writers.Add(new MessageWriterData()
                        {
                            Connection = task.Result,
                            PublisherId = connection.ConnectionName,
                            DataSetWriterId = dataset.Name + connection.ConnectionName + "Writer",
                            SequenceNumber = 1,
                            DataSetClassId= "---",
                            MetadataNodeName = "---"
                        });
                    }
                }
            }

            if (m_renewTokenTimer != null)
            {
                m_renewTokenTimer.Dispose();
            }

            m_renewTokenTimer = new Timer(OnRenewToken, null, 30000, 30000);

            // create the default subscription.
            m_subscription = new Subscription();

            m_subscription.DisplayName = null;
            m_subscription.PublishingInterval = 5000;
            m_subscription.KeepAliveCount = 10;
            m_subscription.LifetimeCount = 100;
            m_subscription.MaxNotificationsPerPublish = 1000;
            m_subscription.PublishingEnabled = true;
            m_subscription.TimestampsToReturn = TimestampsToReturn.Both;

            m_session.AddSubscription(m_subscription);
            m_subscription.Create();

            foreach (var dataset in m_datasets)
            {
                EventFilter filter = new EventFilter();
                filter.SelectClauses = GetSelectClause();

                // create a monitored item based on the current filter settings.            
                var m_monitoredItem = new MonitoredItem();
                m_monitoredItem.StartNodeId = Opc.Ua.ObjectIds.Server;
                m_monitoredItem.AttributeId = Attributes.EventNotifier;
                m_monitoredItem.SamplingInterval = 0;
                m_monitoredItem.QueueSize = 1000;
                m_monitoredItem.DiscardOldest = true;
                m_monitoredItem.Filter = filter;
                m_monitoredItem.Handle = dataset;

                // set up callback for notifications.
                m_monitoredItem.Notification += new MonitoredItemNotificationEventHandler(MonitoredItem_Notification);

                m_subscription.AddItem(m_monitoredItem);
                m_subscription.ApplyChanges();
            }
        }

        private void OnRenewToken(object state)
        {
            try
            {
                foreach (var writer in m_writers)
                {
                    writer.Connection.RenewTokenAsync(m_tokenLifetime);
                }
            }
            catch (Exception exception)
            {
                Utils.Trace(exception, "Error renewing tokens.");
            }
        }

        private async void MonitoredItem_Notification(MonitoredItem monitoredItem, MonitoredItemNotificationEventArgs e)
        {
            try
            {
                EventFieldList notification = e.NotificationValue as EventFieldList;

                if (notification == null)
                {
                    return;
                }

                // check the type of event.
                NodeId eventTypeId = ClientUtils.FindEventType(monitoredItem, notification);

                // ignore unknown events.
                if (NodeId.IsNull(eventTypeId))
                {
                    return;
                }

                // construct the event based on the known event type.
                BaseEventState be = (BaseEventState)Activator.CreateInstance(typeof(BaseEventState), new object[] { (NodeState)null });

                // get the filter which defines the contents of the notification.
                EventFilter filter = monitoredItem.Status.Filter as EventFilter;

                // initialize the event with the values in the notification.
                be.Update(m_session.SystemContext, filter.SelectClauses, notification);

                // save the orginal notification.
                be.Handle = notification;

                EventMessage em = new EventMessage();
                em.SourceServer = m_configuration.ApplicationUri;
                em.Events = new List<EventInstance>();
                
                EventInstance ei = new EventInstance();
                ei.Fields = new Dictionary<string,string>();

                em.Events.Add(ei);

                JsonEncoder encoder = new JsonEncoder(m_session.MessageContext, false);

                for (int ii = 0; ii < filter.SelectClauses.Count; ii++)
                {
                    StringBuilder buffer = new StringBuilder();

                    foreach (var browseName in filter.SelectClauses[ii].BrowsePath)
                    {
                        if (buffer.Length > 0)
                        {
                            buffer.Append("/");
                        }

                        buffer.Append(browseName);
                    }

                    encoder.WriteVariant(buffer.ToString(), notification.EventFields[ii]);
                }

                var json = encoder.CloseAndReturnText();
                var bytes = new UTF8Encoding(false).GetBytes(json);

                foreach (var writer in m_writers)
                {
                    var settings = new Opc.Ua.Bindings.AmqpPubSubMessageSettings()
                    {
                        MessageId = Guid.NewGuid().ToString(),
                        PublisherId = writer.PublisherId,
                        Subject = "ua-data",
                        DataSetWriterId = writer.DataSetWriterId,
                        ContentType = "application/opcua+json",
                        SequenceNumber = ++writer.SequenceNumber,
                        DataSetClassId = writer.DataSetClassId,
                        MetadataNodeName = writer.MetadataNodeName
                    };

                    await writer.Connection.SendAsync(settings, new ArraySegment<byte>(bytes));
                }
            }
            catch (Exception exception)
            {
                Utils.Trace(exception, "Error processing event.");
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
    }

    [DataContract]
    public class EventInstance
    {
        [DataMember]
        public Dictionary<string, string> Fields;
    }

    [DataContract]
    [KnownType(typeof(EventInstance))]
    public class EventMessage
    {
        [DataMember]
        public string SourceServer;

        [DataMember]
        public List<EventInstance> Events;
    }
}
