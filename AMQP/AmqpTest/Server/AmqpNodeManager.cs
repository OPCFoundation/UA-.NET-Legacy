/* ========================================================================
 * Copyright (c) 2005-2013 The OPC Foundation, Inc. All rights reserved.
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
using System.Diagnostics;
using System.Xml;
using System.IO;
using System.Threading;
using System.Reflection;
using Opc.Ua;
using Opc.Ua.Server;

namespace AmqpTestServer
{
    /// <summary>
    /// A node manager for a server that exposes several variables.
    /// </summary>
    public class AmqpNodeManager : CustomNodeManager2
    {
        #region Private Fields
        private long m_lastUsedId;
        private int m_cycleId;
        private AmqpServerConfiguration m_configuration;
        private Timer m_simulationTimer;
        private Opc.Ua.Bindings.AmqpDataSetConfigurationCollection m_datasets;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes the node manager.
        /// </summary>
        public AmqpNodeManager(IServerInternal server, ApplicationConfiguration configuration)
        :
            base(server, configuration, Namespaces.Empty)
        {
            SystemContext.NodeIdFactory = this;

            // get the configuration for the node manager.
            m_configuration = configuration.ParseExtension<AmqpServerConfiguration>();

            // use suitable defaults if no configuration exists.
            if (m_configuration == null)
            {
                m_configuration = new AmqpServerConfiguration();
            }

            m_datasets = Opc.Ua.Bindings.AmqpDataSetConfigurationCollection.Load(configuration);
        }
        #endregion
        
        #region IDisposable Members
        /// <summary>
        /// An overrideable version of the Dispose.
        /// </summary>
        protected override void Dispose(bool disposing)
        {  
            if (disposing)
            {
                // TBD
            }
        }
        #endregion

        #region INodeIdFactory Members
        /// <summary>
        /// Creates the NodeId for the specified node.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="node">The node.</param>
        /// <returns>The new NodeId.</returns>
        public override NodeId New(ISystemContext context, NodeState node)
        {
            uint id = Utils.IncrementIdentifier(ref m_lastUsedId);
            return new NodeId(id, NamespaceIndex);
        }
        #endregion

        /// <summary>
        /// Does the simulation.
        /// </summary>
        /// <param name="state">The state.</param>
        private void DoSimulation(object state)
        {
            try
            {
                for (int ii = 1; ii < 3; ii++)
                {
                    // construct translation object with default text.
                    TranslationInfo info = new TranslationInfo(
                        "SystemCycleStarted",
                        "en-US",
                        "The system cycle '{0}' has started.",
                        ++m_cycleId);

                    // construct the event.
                    SystemStatusChangeEventState e = new SystemStatusChangeEventState(null);

                    e.Initialize(
                        SystemContext,
                        null,
                        (EventSeverity)ii,
                        new LocalizedText(info));

                    e.SetChildValue(SystemContext, Opc.Ua.BrowseNames.SourceName, "System", false);
                    e.SetChildValue(SystemContext, Opc.Ua.BrowseNames.SourceNode, Opc.Ua.ObjectIds.Server, false);
                    
                    Server.ReportEvent(e);
                }
            }
            catch (Exception e)
            {
                Utils.Trace(e, "Unexpected error during simulation.");
            }
        }

        #region INodeManager Members

        private void CreateDataSet(Opc.Ua.Bindings.AmqpDataSetConfiguration configuration, IDictionary<NodeId, IList<IReference>> externalReferences)
        {

            var dataset = new PublishedEventsState(null);

            dataset.Create(
                SystemContext,
                null,
                new QualifiedName(configuration.Name, NamespaceIndex),
                null,
                true);

            dataset.ConfigurationVersion.Value = new ConfigurationVersionDataType() { MinorVersion = 1, MajorVersion = 1 };
            dataset.SelectedNotifier.Value = ObjectIds.Server;
            dataset.SelectedFields.Value = InternalClient.GetSelectClause().ToArray();
            dataset.Filter.Value = new ContentFilter();

            DataSetMetaDataType metadata = new DataSetMetaDataType()
            {
                ConfigurationVersion = dataset.ConfigurationVersion.Value,
                DataSetClassId = Uuid.Empty,
                Fields = new FieldMetaDataCollection(new FieldMetaData[]
                {
                    new FieldMetaData() { Name = BrowseNames.EventId, DataType = DataTypeIds.ByteString, ValueRank = ValueRanks.Scalar },
                    new FieldMetaData() { Name = BrowseNames.EventType, DataType = DataTypeIds.NodeId, ValueRank = ValueRanks.Scalar, FieldFlags = DataSetFieldFlags.PromotedField },
                    new FieldMetaData() { Name = BrowseNames.SourceName, DataType = DataTypeIds.String, ValueRank = ValueRanks.Scalar },
                    new FieldMetaData() { Name = BrowseNames.SourceNode, DataType = DataTypeIds.NodeId, ValueRank = ValueRanks.Scalar },
                    new FieldMetaData() { Name = BrowseNames.Message, DataType = DataTypeIds.LocalizedText, ValueRank = ValueRanks.Scalar },
                    new FieldMetaData() { Name = BrowseNames.Time, DataType = DataTypeIds.DateTime, ValueRank = ValueRanks.Scalar  },
                    new FieldMetaData() { Name = BrowseNames.ReceiveTime, DataType = DataTypeIds.DateTime, ValueRank = ValueRanks.Scalar },
                    new FieldMetaData() { Name = BrowseNames.Severity, DataType = DataTypeIds.UInt16, ValueRank = ValueRanks.Scalar, FieldFlags = DataSetFieldFlags.PromotedField }
                })
            };

            dataset.DataSetMetaData.Value = metadata;

            base.AddExternalReference(
                ObjectIds.PublishSubscribe_PublishedDataSets,
                ReferenceTypeIds.HasComponent,
                false,
                dataset.NodeId,
                externalReferences);

            dataset.AddReference(Opc.Ua.ReferenceTypeIds.HasComponent, true, ObjectIds.PublishSubscribe_PublishedDataSets);

            dataset.SelectedNotifier.Value = Opc.Ua.ObjectIds.Server;
            dataset.SelectedFields.Value = new SimpleAttributeOperand[] { };
            dataset.Filter.Value = new ContentFilter();

            AddPredefinedNode(SystemContext, dataset);

            if (configuration.Connections != null)
            {
                foreach (var connection in configuration.Connections)
                {
                    var node = new BrokerConnectionState(null);

                    node.Create(
                        SystemContext,
                        null,
                        new QualifiedName(connection.ConnectionName, NamespaceIndex),
                        null,
                        true);

                    base.AddExternalReference(
                        ObjectIds.PublishSubscribe,
                        ReferenceTypeIds.HasPubSubConnection,
                        false,
                        node.NodeId,
                        externalReferences);

                    node.AddReference(Opc.Ua.ReferenceTypeIds.HasComponent, true, ObjectIds.PublishSubscribe);
                    node.PublisherId.Value = connection.ConnectionName;
                    node.Address.Value = connection.BrokerUrl;
                    node.Status.State.Value = PubSubState.Operational;

                    AddPredefinedNode(SystemContext, node);

                    var topic = new BrokerGroupState(null);

                    topic.Create(
                        SystemContext,
                        null,
                        new QualifiedName(connection.GroupName, NamespaceIndex),
                        null,
                        true);

                    node.AddReference(Opc.Ua.ReferenceTypeIds.HasComponent, false, topic.NodeId);
                    topic.AddReference(Opc.Ua.ReferenceTypeIds.HasComponent, true, node.NodeId);
                    topic.QueueName.Value = connection.TargetName;
                    topic.PublishingInterval.Value = 5000;
                    topic.KeepAliveTime.Value = 50000;
                    topic.EncodingMimeType.Value = "application/opcua+json";
                    topic.Priority.Value = 100;

                    AddPredefinedNode(SystemContext, topic);

                    var writer = new DataSetWriterState(null);

                    writer.Create(
                        SystemContext,
                        null,
                        new QualifiedName(configuration.Name + connection.GroupName + "MessageWriter", NamespaceIndex),
                        null,
                        true);

                    writer.Status.State.Value = PubSubState.Operational;

                    writer.AddReference(Opc.Ua.ReferenceTypeIds.HasDataSetWriter, true, topic.NodeId);
                    topic.AddReference(Opc.Ua.ReferenceTypeIds.HasDataSetWriter, false, writer.NodeId);

                    AddPredefinedNode(SystemContext, writer);
                }
            }
        }

        public override void CreateAddressSpace(IDictionary<NodeId, IList<IReference>> externalReferences)
        {
            lock (Lock)
            {
                base.CreateAddressSpace(externalReferences);

                if (m_datasets != null)
                {
                    foreach (var dataset in m_datasets)
                    {
                        CreateDataSet(dataset, externalReferences);
                    }
                }
            }

            // start a simulation that changes the values of the nodes.
            m_simulationTimer = new Timer(DoSimulation, null, 10000, 10000);
        }

        /// <summary>
        /// Frees any resources allocated for the address space.
        /// </summary>
        public override void DeleteAddressSpace()
        {
            lock (Lock)
            {
                if (m_simulationTimer != null)
                {
                    m_simulationTimer.Dispose();
                    m_simulationTimer = null;
                }
            }
        }

        /// <summary>
        /// Returns a unique handle for the node.
        /// </summary>
        protected override NodeHandle GetManagerHandle(ServerSystemContext context, NodeId nodeId, IDictionary<NodeId, NodeState> cache)
        {
            lock (Lock)
            {
                // quickly exclude nodes that are not in the namespace. 
                if (!IsNodeIdInNamespace(nodeId))
                {
                    return null;
                }

                NodeState node = null;

                if (!PredefinedNodes.TryGetValue(nodeId, out node))
                {
                    return null;
                }

                NodeHandle handle = new NodeHandle();

                handle.NodeId = nodeId;
                handle.Node = node;
                handle.Validated = true;

                return handle;
            } 
        }

        /// <summary>
        /// Verifies that the specified node exists.
        /// </summary>
        protected override NodeState ValidateNode(
            ServerSystemContext context,
            NodeHandle handle,
            IDictionary<NodeId, NodeState> cache)
        {
            // not valid if no root.
            if (handle == null)
            {
                return null;
            }

            // check if previously validated.
            if (handle.Validated)
            {
                return handle.Node;
            }
            
            // TBD

            return null;
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Loads a node set from a file or resource and addes them to the set of predefined nodes.
        /// </summary>
        protected override NodeStateCollection LoadPredefinedNodes(ISystemContext context)
        {
            NodeStateCollection predefinedNodes = new NodeStateCollection();
            // predefinedNodes.LoadFromBinaryResource(context, "Opc.Ua.Gds.Model.Opc.Ua.Gds.PredefinedNodes.uanodes", typeof(Opc.Ua.Gds.ObjectIds).Assembly, true);
            return predefinedNodes;
        }

        /// <summary>
        /// Replaces the generic node with a node specific to the model.
        /// </summary>
        protected override NodeState AddBehaviourToPredefinedNode(ISystemContext context, NodeState predefinedNode)
        {
            BaseObjectState passiveNode = predefinedNode as BaseObjectState;

            if (passiveNode == null)
            {
                return predefinedNode;
            }

            NodeId typeId = passiveNode.TypeDefinitionId;

            if (!IsNodeIdInNamespace(typeId) || typeId.IdType != IdType.Numeric)
            {
                return predefinedNode;
            }

            return predefinedNode;
        }
        #endregion
    }
}
