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

namespace TutorialServer
{
    /// <summary>
    /// A node manager for a server that exposes several variables.
    /// </summary>
    public class TutorialNodeManager : CustomNodeManager2
    {
        #region Constructors
        /// <summary>
        /// Initializes the node manager.
        /// </summary>
        public TutorialNodeManager(IServerInternal server, ApplicationConfiguration configuration)
        :
            // base(server, configuration, Namespaces.Tutorial)            
            #region Task #C2 - Add Information Model
            base(server, configuration, Namespaces.Tutorial, TutorialModel.Namespaces.Tutorial)
            #endregion
        {
            SystemContext.NodeIdFactory = this;

            // get the configuration for the node manager.
            m_configuration = configuration.ParseExtension<TutorialServerConfiguration>();

            // use suitable defaults if no configuration exists.
            if (m_configuration == null)
            {
                m_configuration = new TutorialServerConfiguration();
            }
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
        public override NodeId New(ISystemContext context, NodeState node)
        {
            // generate a numeric node id if the node has a parent and no node id assigned.
            BaseInstanceState instance = node as BaseInstanceState;

            if (instance != null && instance.Parent != null)
            {
                #region Task #A5 - Add Support for External Nodes
                // check for component.
                if (instance.Parent.NodeId.IdType == IdType.String)
                {
                    return CreateIdForComponent(instance, instance.Parent.NodeId.NamespaceIndex);
                }
                #endregion

                return GenerateNodeId();
            }

            return node.NodeId;
        }
        #endregion

        #region INodeManager Members
        /// <summary>
        /// Does any initialization required before the address space can be used.
        /// </summary>
        /// <remarks>
        /// The externalReferences is an out parameter that allows the node manager to link to nodes
        /// in other node managers. For example, the 'Objects' node is managed by the CoreNodeManager and
        /// should have a reference to the root folder node(s) exposed by this node manager.  
        /// </remarks>
        public override void CreateAddressSpace(IDictionary<NodeId, IList<IReference>> externalReferences)
        {
            lock (Lock)
            {
                base.CreateAddressSpace(externalReferences);

                #region Task #A1 - Create Root Folder
                // create the root folder.
                FolderState root = new FolderState(null);

                root.NodeId = GenerateNodeId();
                root.BrowseName = new QualifiedName("Root", NamespaceIndex);
                root.DisplayName = root.BrowseName.Name;
                root.TypeDefinitionId = ObjectTypeIds.FolderType;

                // ensure root can be found via the server object. 
                IList<IReference> references = null;

                if (!externalReferences.TryGetValue(ObjectIds.ObjectsFolder, out references))
                {
                    externalReferences[ObjectIds.ObjectsFolder] = references = new List<IReference>();
                }

                root.AddReference(ReferenceTypeIds.Organizes, true, ObjectIds.ObjectsFolder);
                references.Add(new NodeStateReference(ReferenceTypeIds.Organizes, false, root.NodeId));
                
                // save the node for later lookup.
                AddPredefinedNode(SystemContext, root);
                #endregion

                #region Task #A2 - Create Object Instance with a Property
                // create the folder object.
                BaseObjectState instance = new BaseObjectState(null);

                instance.NodeId = GenerateNodeId();
                instance.BrowseName = new QualifiedName("Object", NamespaceIndex);
                instance.DisplayName = instance.BrowseName.Name;
                instance.TypeDefinitionId = ObjectTypeIds.BaseObjectType;

                // create a losely coupled relationship with the root object.
                root.AddReference(ReferenceTypeIds.Organizes, false, instance.NodeId);
                instance.AddReference(ReferenceTypeIds.Organizes, true, root.NodeId);

                // create a property.
                PropertyState<int> property = new PropertyState<int>(instance);

                property.NodeId = GenerateNodeId();
                property.BrowseName = new QualifiedName("Property", NamespaceIndex);
                property.DisplayName = property.BrowseName.Name;
                property.TypeDefinitionId = VariableTypeIds.PropertyType;
                property.DataType = DataTypeIds.Int32;
                property.ValueRank = ValueRanks.Scalar;
                property.MinimumSamplingInterval = MinimumSamplingIntervals.Continuous;
                property.AccessLevel = AccessLevels.CurrentReadOrWrite;
                property.UserAccessLevel = AccessLevels.CurrentReadOrWrite;
                property.Historizing = false;
                property.ReferenceTypeId = ReferenceTypeIds.HasProperty;

                // create a property that is tightly coupled.
                instance.AddChild(property);

                // save the node for later lookup (all tightly coupled children are added with this call).
                AddPredefinedNode(SystemContext, instance);
                #endregion
                
                #region Task #A3 - Create a Variable using the Built-in Type Model
                // create the variable.
                AnalogItemState<double> variable = new AnalogItemState<double>(instance);

                // add optional properties.
                variable.InstrumentRange = new PropertyState<Range>(variable);

                // instantiate based on the type model. assigns ids automatically using SystemContext.NodeIdFactory
                variable.Create(
                    SystemContext,
                    GenerateNodeId(),
                    new QualifiedName("Variable", NamespaceIndex),
                    null,
                    true);

                // set default values.
                variable.EURange.Value = new Range(90, 10);
                variable.InstrumentRange.Value = new Range(100, 0);

                // tightly coupled.
                instance.AddChild(variable);

                // need to add it manually since its parent was already added.
                AddPredefinedNode(SystemContext, variable);
                #endregion

                #region Task #A4 - Add Dynamic Behavoir by Updating In-Memory Nodes
                m_property = property;
                m_simulationTimer = new Timer(DoSimulation, null, 1000, 1000);
                #endregion

                #region Task #A5 - Add Support for External Nodes
                // External nodes are nodes that reference an entity which stored elsewhere. 
                // These nodes use no memory in the server unless they are accessed.
                // The NodeId is a string that is used to create the external node on demand.
                root.AddReference(ReferenceTypeIds.Organizes, false, CreateNodeId("Alpha"));
                root.AddReference(ReferenceTypeIds.Organizes, false, CreateNodeId("Omega"));
                #endregion

                #region Task #A7 - Add Support for Method
                MethodState method = new MethodState(instance);

                method.NodeId = GenerateNodeId();
                method.BrowseName = new QualifiedName("Method", NamespaceIndex);
                method.DisplayName = method.BrowseName.Name;
                method.Executable = true;
                method.UserExecutable = true;
                method.ReferenceTypeId = ReferenceTypeIds.HasComponent;

                instance.AddChild(method);
                
                // create the input arguments.
                PropertyState<Argument[]> inputArguments = new PropertyState<Argument[]>(method);

                inputArguments.NodeId = GenerateNodeId();
                inputArguments.BrowseName = new QualifiedName(BrowseNames.InputArguments);
                inputArguments.DisplayName = inputArguments.BrowseName.Name;
                inputArguments.TypeDefinitionId = VariableTypeIds.PropertyType;
                inputArguments.DataType = DataTypeIds.Argument;
                inputArguments.ValueRank = ValueRanks.OneDimension;
                inputArguments.MinimumSamplingInterval = MinimumSamplingIntervals.Continuous;
                inputArguments.AccessLevel = AccessLevels.CurrentRead;
                inputArguments.UserAccessLevel = AccessLevels.CurrentRead;
                inputArguments.Historizing = false;
                inputArguments.ReferenceTypeId = ReferenceTypeIds.HasProperty;

                inputArguments.Value = new Argument[] 
                {
                    new Argument() { Name = "CurrentCount", Description = "The current count.",  DataType = DataTypeIds.Int32, ValueRank = ValueRanks.Scalar }
                };

                method.InputArguments = inputArguments;

                // create the output arguments.
                PropertyState<Argument[]> outputArguments = new PropertyState<Argument[]>(method);

                outputArguments.NodeId = GenerateNodeId();
                outputArguments.BrowseName = new QualifiedName(BrowseNames.OutputArguments);
                outputArguments.DisplayName = outputArguments.BrowseName.Name;
                outputArguments.TypeDefinitionId = VariableTypeIds.PropertyType;
                outputArguments.DataType = DataTypeIds.Argument;
                outputArguments.ValueRank = ValueRanks.OneDimension;
                outputArguments.MinimumSamplingInterval = MinimumSamplingIntervals.Continuous;
                outputArguments.AccessLevel = AccessLevels.CurrentRead;
                outputArguments.UserAccessLevel = AccessLevels.CurrentRead;
                outputArguments.Historizing = false;
                outputArguments.ReferenceTypeId = ReferenceTypeIds.HasProperty;

                outputArguments.Value = new Argument[] 
                {
                    new Argument() { Name = "NewCount", Description = "The new count.",  DataType = DataTypeIds.Int32, ValueRank = ValueRanks.Scalar }
                };

                method.OutputArguments = outputArguments;

                // save the node for later lookup (all tightly coupled children are added with this call).
                AddPredefinedNode(SystemContext, instance);
                
                // register handler.
                method.OnCallMethod = new GenericMethodCalledEventHandler(DoMethodCall);
                #endregion

                #region Task #D6 - Add Support for Notifiers
                // enable subscriptions.
                root.EventNotifier = EventNotifiers.SubscribeToEvents;

                // creating notifier ensures events propogate up the hierarchy when the are produced.
                AddRootNotifier(root);
                
                // add link to server object.
                if (!externalReferences.TryGetValue(ObjectIds.Server, out references))
                {
                    externalReferences[ObjectIds.Server] = references = new List<IReference>();
                }

                references.Add(new NodeStateReference(ReferenceTypeIds.HasNotifier, false, root.NodeId));

                // add sub-notifiers.
                instance.EventNotifier = EventNotifiers.SubscribeToEvents;
                instance.AddNotifier(SystemContext, ReferenceTypeIds.HasNotifier, true, root);
                root.AddNotifier(SystemContext, ReferenceTypeIds.HasNotifier, false, instance);
                #endregion
            }
        }

        #region Task #A4 - Add Dynamic Behavoir by Updating In-Memory Nodes
        /// <summary>
        /// Need to save a reference to the property so it can be updated by the simualation. 
        /// </summary>
        private PropertyState<int> m_property;

        /// <summary>
        /// A period timer that triggers data changes.
        /// </summary>
        private Timer m_simulationTimer;

        /// <summary>
        /// Called each time the scan cycle completes.
        /// </summary>
        private void DoSimulation(object state)
        {
            try
            {
                // must acquire the lock.
                lock (Lock)
                {
                    // increment counter.
                    m_property.Value++;

                    // this triggers a callback which is implemented in the base class.
                    // the call back pushes the updated values into the monitored items.
                    m_property.ClearChangeMasks(SystemContext, true);
                }
            }
            catch (Exception e)
            {
                Utils.Trace(e, "Unexpected error doing simulation.");
            }
        }
        #endregion

        #region Task #A5 - Add Support for External Nodes
        /// <summary>
        /// Simulates an external source for the values of the variables.
        /// </summary>
        private Dictionary<NodeId, double> m_externalValues = new Dictionary<NodeId, double>();

        /// <summary>
        /// Determines if the value has an external source.
        /// </summary>
        private bool IsExternalSource(NodeHandle handle, uint attributeId)
        {
            return (handle.NodeId.IdType == IdType.String && attributeId == Attributes.Value && String.IsNullOrEmpty(handle.ComponentPath));
        }

        /// <summary>
        /// Creates a new node from a unique id.
        /// </summary>
        private NodeId CreateNodeId(string uniqueId)
        {
            return new NodeId(uniqueId, NamespaceIndex);
        }

        /// <summary>
        /// Constructs the node identifier for a component.
        /// <summary>
        public static NodeId CreateIdForComponent(NodeState component, ushort namespaceIndex)
        {
            if (component == null)
            {
                return null;
            }

            // components must be instances with a parent.
            BaseInstanceState instance = component as BaseInstanceState;

            if (instance == null || instance.Parent == null)
            {
                return component.NodeId;
            }

            // parent must have a string identifier.
            string parentId = instance.Parent.NodeId.Identifier as string;

            if (parentId == null)
            {
                return null;
            }

            StringBuilder buffer = new StringBuilder();
            buffer.Append(parentId);

            // check if the parent is another component.
            int index = parentId.IndexOf('?');

            if (index < 0)
            {
                buffer.Append('?');
            }
            else
            {
                buffer.Append('/');
            }

            buffer.Append(component.SymbolicName);

            // return the node identifier.
            return new NodeId(buffer.ToString(), namespaceIndex);
        }

        /// <summary>
        /// Parses the node id for an external node.
        /// </summary>
        private NodeHandle ParseNodeId(NodeId nodeId)
        {
            if (NodeId.IsNull(nodeId))
            {
                return null;
            }

            string id = nodeId.Identifier as string;

            if (String.IsNullOrEmpty(id))
            {
                return null;
            }

            // create an unvalidated handle.
            NodeHandle handle = new NodeHandle();
            handle.NodeId = nodeId;
            handle.Validated = false;

            // check for references to any component.
            int index = id.LastIndexOf('?');

            if (index != -1)
            {
                handle.ComponentPath = id.Substring(index + 1);
                id = id.Substring(0, index);
            }

            handle.RootId = new NodeId(id, NamespaceIndex);

            return handle;
        }

        /// <summary>
        /// Validates an emphermal node.
        /// </summary>
        private NodeState ValidateExternalNode(ISystemContext context, NodeHandle handle)
        {
            string uniqueId = handle.RootId.Identifier as string;

            if (String.IsNullOrEmpty(uniqueId))
            {
                return null;
            }

            // lookup in persistent cache (nodes that are being monitored are in the cache).
            NodeState target = LookupNodeInComponentCache(context, handle);

            if (target != null)
            {
                return target;
            }

            // validate the external node (normally this means look it up in underlying system).
            switch (uniqueId)
            {
                case "Alpha":
                case "Omega":
                {
                    // create the variable.
                    AnalogItemState<double> target2 = new AnalogItemState<double>(null);

                    // instantiate based on the type model. assigns ids automatically using SystemContext.NodeIdFactory
                    target2.Create(
                        SystemContext,
                        handle.RootId,
                        new QualifiedName(uniqueId, NamespaceIndex),
                        null,
                        true);

                    // always allow read/write.
                    target2.AccessLevel = AccessLevels.CurrentReadOrWrite;
                    target2.UserAccessLevel = AccessLevels.CurrentReadOrWrite;
                    target2.StatusCode = StatusCodes.BadWaitingForInitialData;

                    #region Task #D4 - Add Support for Access Control
                    target2.OnReadUserAccessLevel = OnReadUserAccessLevel;
                    #endregion

                    target = target2;
                    break;
                }

                default:
                {
                    return null;
                }
            }

            // validate component.
            if (!String.IsNullOrEmpty(handle.ComponentPath))
            {
                NodeState component = target.FindChildBySymbolicName(context, handle.ComponentPath);

                // component does not exist.
                if (component == null)
                {
                    return null;
                }

                target = component;
            }

            return target;
        }

        /// <summary>
        /// Stores a request to read/write data in an external source.
        /// </summary>
        private class ReadWriteRequest
        {
            public NodeHandle Handle { get; set; }
            public Variant Value { get; set; }
            public ServiceResult Result { get; set; }
            public IUserIdentity UserIdentity { get; set; }
        }

        /// <summary>
        /// Handles a read operations that fetch data from an external source.
        /// </summary>
        protected override void Read(
            ServerSystemContext context,
            IList<ReadValueId> nodesToRead,
            IList<DataValue> values,
            IList<ServiceResult> errors,
            List<NodeHandle> nodesToValidate,
            IDictionary<NodeId, NodeState> cache)
        {
            List<ReadWriteRequest> requests = new List<ReadWriteRequest>();

            for (int ii = 0; ii < nodesToValidate.Count; ii++)
            {
                NodeHandle handle = nodesToValidate[ii];
                ReadValueId nodeToRead = nodesToRead[ii];
                DataValue value = values[ii];

                lock (Lock)
                {
                    // validate node.
                    NodeState source = ValidateNode(context, handle, cache);

                    if (source == null)
                    {
                        continue;
                    }

                    // determine if an external source is required.
                    if (IsExternalSource(handle, nodeToRead.AttributeId))
                    {
                        errors[handle.Index] = AddReadRequest(context, handle, nodeToRead, requests);
                        continue;
                    }

                    // read built-in metadata.
                    errors[handle.Index] = source.ReadAttribute(
                        context,
                        nodeToRead.AttributeId,
                        nodeToRead.ParsedIndexRange,
                        nodeToRead.DataEncoding,
                        value);
                }
            }

            // send request to external system.
            try
            {
                ProcessReadRequests(requests);
            }
            catch (Exception e)
            {
                // handle unexpected communication error.
                ServiceResult error = ServiceResult.Create(e, StatusCodes.BadUnexpectedError, "Could not access external system.");

                for (int ii = 0; ii < requests.Count; ii++)
                {
                    requests[ii].Result = error;
                }
            }

            // set results.
            for (int ii = 0; ii < requests.Count; ii++)
            {
                ReadWriteRequest request = requests[ii];

                if (ServiceResult.IsBad(request.Result))
                {
                    errors[request.Handle.Index] = request.Result;
                    continue;
                }

                values[request.Handle.Index] = new DataValue(request.Value);
            }
        }

        /// <summary>
        /// Creates a request to read a value from an external source.
        /// </summary>
        private ServiceResult AddReadRequest(ISystemContext context, NodeHandle handle, ReadValueId nodeToRead, List<ReadWriteRequest> requests)
        {
            requests.Add(new ReadWriteRequest() { Handle = handle, UserIdentity = context.UserIdentity });
            return ServiceResult.Good;
        }

        /// <summary>
        /// Processes a batch of read requests.
        /// </summary>
        private ServiceResult ProcessReadRequests(List<ReadWriteRequest> requests)
        {
            for (int ii = 0; ii < requests.Count; ii++)
            {
                ReadWriteRequest request = requests[ii];

                double value = 0;

                if (!m_externalValues.TryGetValue(request.Handle.NodeId, out value))
                {
                    m_externalValues[request.Handle.NodeId] = 0;
                }

                request.Value = new Variant(value);
            }

            return ServiceResult.Good;
        }
        #endregion
        
        #region Task #A6 - Add Dynamic Behavior to External Nodes
        /// <summary>
        /// Need to save the monitored items that are being monitored.
        /// </summary>
        private List<MonitoredItem> m_activeItems = new List<MonitoredItem>();

        /// <summary>
        /// A period timer that triggers data changes.
        /// </summary>
        private Timer m_scanTimer;

        /// <summary>
        /// Called each time the scan cycle completes.
        /// </summary>
        private void DoScan(object state)
        {
            try
            {
                // must acquire the lock.
                lock (m_activeItems)
                {
                    for (int ii = 0; ii < m_activeItems.Count; ii++)
                    {
                        NodeHandle handle = m_activeItems[ii].ManagerHandle as NodeHandle;

                        // simulate a value change and read from an external source.
                        double value = 0;

                        if (!m_externalValues.TryGetValue(handle.RootId, out value))
                        {
                            m_externalValues.Add(handle.RootId, value);
                        }

                        value++;
                        m_externalValues[handle.RootId] = value;

                        // use the in memory object as a cache.
                        AnalogItemState<double> item = handle.Node as AnalogItemState<double>;
                        item.Value = value;

                        // push data change.
                        m_activeItems[ii].QueueValue(new DataValue(new Variant(value), StatusCodes.Good, DateTime.UtcNow, DateTime.UtcNow), null);
                    }
                }
            }
            catch (Exception e)
            {
                Utils.Trace(e, "Unexpected error doing scan.");
            }
        }

        /// <summary>
        /// Determines if the node requires a scan.
        /// </summary>
        private bool IsScanRequired(NodeHandle handle, MonitoredItem monitoredItem)
        {
            return IsExternalSource(handle, monitoredItem.AttributeId);
        }

        /// <summary>
        /// Starts scanning the monitored item.
        /// </summary>
        private void StartScan(NodeHandle handle, MonitoredItem monitoredItem)
        {
            lock (m_activeItems)
            {
                m_activeItems.Add(monitoredItem);

                if (m_scanTimer == null)
                {
                    m_scanTimer = new Timer(DoScan, null, 1000, 1000);
                }
            }
        }

        /// <summary>
        /// Stops scanning the monitored item.
        /// </summary>
        private void StopScan(NodeHandle handle, MonitoredItem monitoredItem)
        {
            for (int ii = 0; ii < m_activeItems.Count; ii++)
            {
                if (m_activeItems[ii].Id == monitoredItem.Id)
                {
                    m_activeItems.RemoveAt(ii);

                    if (m_scanTimer != null && m_activeItems.Count == 0)
                    {
                        m_scanTimer.Dispose();
                        m_scanTimer = null;
                    }

                    break;
                }
            }
        }

        /// <summary>
        /// Called when a monitored item is created.
        /// </summary>
        protected override void OnMonitoredItemCreated(ServerSystemContext context, NodeHandle handle, MonitoredItem monitoredItem)
        {
            // check if monitored item requires scaning.
            if (!IsScanRequired(handle, monitoredItem))
            {
                return;
            }

            // only scan enabled items.
            if (monitoredItem.MonitoringMode != MonitoringMode.Disabled)
            {
                StartScan(handle, monitoredItem);
            }
        }
        
        /// <summary>
        /// Called when a monitored item is modified.
        /// </summary>
        protected override void OnMonitoredItemModified(ServerSystemContext context, NodeHandle handle, MonitoredItem monitoredItem)
        {
            // TBD - handle changes to sampling interval.
        }

        /// <summary>
        /// Called when a monitored item is deleted
        /// </summary>
        protected override void OnMonitoredItemDeleted(ServerSystemContext context, NodeHandle handle, MonitoredItem monitoredItem)
        {
            // check if monitored item requires scaning.
            if (!IsScanRequired(handle, monitoredItem))
            {
                return;
            }

            // delete monitored item.
            StopScan(handle, monitoredItem);
        }
        
        /// <summary>
        /// Called when a monitored item monitoring mode is changed.
        /// </summary>
        protected override void OnMonitoringModeChanged(ServerSystemContext context, NodeHandle handle, MonitoredItem monitoredItem, MonitoringMode previousMode, MonitoringMode monitoringMode)
        {
            // check if monitored item requires scaning.
            if (!IsScanRequired(handle, monitoredItem))
            {
                return;
            }

            // check if starting scan.
            if (previousMode == MonitoringMode.Disabled && monitoringMode != MonitoringMode.Disabled)
            {
                StartScan(handle, monitoredItem);
            }

            // check if stopping scan.
            if (previousMode != MonitoringMode.Disabled && monitoringMode == MonitoringMode.Disabled)
            {
                StopScan(handle, monitoredItem);
            }
        }
        #endregion
        
        #region Task #A7 - Add Support for Writes to an External Source
        /// <summary>
        /// Handles a write operation.
        /// </summary>
        protected override void Write(
            ServerSystemContext context,
            IList<WriteValue> nodesToWrite,
            IList<ServiceResult> errors,
            List<NodeHandle> nodesToValidate,
            IDictionary<NodeId, NodeState> cache)
        {
            List<ReadWriteRequest> requests = new List<ReadWriteRequest>();

            // validates the nodes and constructs requests for external nodes.
            for (int ii = 0; ii < nodesToValidate.Count; ii++)
            {
                WriteValue nodeToWrite = nodesToWrite[ii];
                NodeHandle handle = nodesToValidate[ii];

                lock (Lock)
                {
                    // validate node.
                    NodeState source = ValidateNode(context, handle, cache);

                    if (source == null)
                    {
                        continue;
                    }

                    // determine if an external source is required.
                    if (IsExternalSource(handle, nodeToWrite.AttributeId))
                    {
                        errors[handle.Index] = AddWriteRequest(context, handle, nodeToWrite, requests);
                        continue;
                    }

                    // write the attribute value.
                    errors[handle.Index] = source.WriteAttribute(
                        context,
                        nodeToWrite.AttributeId,
                        nodeToWrite.ParsedIndexRange,
                        nodeToWrite.Value);

                    // updates to source finished - report changes to monitored items.
                    source.ClearChangeMasks(context, false);
                }
            }

            // send request to external system.
            try
            {
                ProcessWriteRequests(requests);
            }
            catch (Exception e)
            {
                // handle unexpected communication error.
                ServiceResult error = ServiceResult.Create(e, StatusCodes.BadUnexpectedError, "Could not access external system.");

                for (int ii = 0; ii < requests.Count; ii++)
                {
                    requests[ii].Result = error;
                }
            }

            // set results.
            for (int ii = 0; ii < requests.Count; ii++)
            {
                ReadWriteRequest request = requests[ii];
                errors[request.Handle.Index] = request.Result;
            }
        }

        /// <summary>
        /// Creates a request to write a value to an external source.
        /// </summary>
        private ServiceResult AddWriteRequest(ISystemContext context, NodeHandle handle, WriteValue nodeToWrite, List<ReadWriteRequest> requests)
        {
            DataValue valueToWrite = nodeToWrite.Value;

            // cannot write status or timestamps to this source.
            if (valueToWrite.StatusCode != StatusCodes.Good || valueToWrite.ServerTimestamp != DateTime.MinValue || valueToWrite.SourceTimestamp != DateTime.MinValue)
            {
                return StatusCodes.BadWriteNotSupported;
            }

            // apply the index range (not supported by this external system).
            if (nodeToWrite.ParsedIndexRange != NumericRange.Empty)
            {
                return StatusCodes.BadIndexRangeInvalid;
            }

            // need node metadata to check data type.
            BaseVariableState variable = handle.Node as BaseVariableState;

            if (variable == null)
            {
                return StatusCodes.BadTypeMismatch;
            }

            // check that the data type is correct.
            TypeInfo typeInfo = TypeInfo.IsInstanceOfDataType(
                valueToWrite.Value, 
                variable.DataType, 
                variable.ValueRank, 
                Server.NamespaceUris, 
                Server.TypeTree);

            if (typeInfo == null)
            {
                return StatusCodes.BadTypeMismatch;
            }

            requests.Add(new ReadWriteRequest() { Handle = handle, Value = valueToWrite.WrappedValue, UserIdentity = context.UserIdentity });
            return ServiceResult.Good;
        }

        /// <summary>
        /// Processes a batch of write requests.
        /// </summary>
        private ServiceResult ProcessWriteRequests(List<ReadWriteRequest> requests)
        {
            for (int ii = 0; ii < requests.Count; ii++)
            {
                ReadWriteRequest request = requests[ii];

                #region Task #D4 - Add Support for Access Control
                if (!HasAccess(request.UserIdentity, request.Handle.NodeId))
                {
                    request.Result = StatusCodes.BadUserAccessDenied;
                    continue;
                }
                #endregion

                m_externalValues[request.Handle.NodeId] = (double)request.Value.Value;
            }

            return ServiceResult.Good;
        }
        #endregion

        #region Task #A8 - Add Support for Method
        /// <summary>
        /// Handles a method call.
        /// </summary>
        private ServiceResult DoMethodCall(
            ISystemContext context,
            MethodState method,
            IList<object> inputArguments,
            IList<object> outputArguments)
        {
            // the number of arguments is checked by the called.
            int counter = (int)inputArguments[0];
            counter++;

            // output arguments are set to default values.
            outputArguments[0] = counter;

            // raise an audit event.
            #region Task #D5 - Raise an Event
            RaiseAuditUpdateMethodEvent(context, method, true, inputArguments);
            #endregion

            return ServiceResult.Good;
        }
        #endregion

        #region Task #C2 - Add Information Model
        /// <summary>
        /// Loads a node set from a file or resource and addes them to the set of predefined nodes.
        /// </summary>
        protected override NodeStateCollection LoadPredefinedNodes(ISystemContext context)
        {
            NodeStateCollection predefinedNodes = new NodeStateCollection();
            predefinedNodes.LoadFromBinaryResource(context, "TutorialServer.Model.TutorialModel.PredefinedNodes.uanodes", null, true);
            return predefinedNodes;
        }
        #endregion

        #region Task #D4 - Add Support for Access Control
        /// <summary>
        /// Checks the user access level for the variable.
        /// </summary>
        private ServiceResult OnReadUserAccessLevel(
            ISystemContext context,
            NodeState node,
            ref byte value)
        {
            value = AccessLevels.CurrentRead;

            if (HasAccess(context.UserIdentity, node.NodeId))
            {
                value = AccessLevels.CurrentReadOrWrite;
            }

            return ServiceResult.Good;
        }

        /// <summary>
        /// Updates the access level based on the current user identity.
        /// </summary>
        private bool HasAccess(IUserIdentity identity, NodeId nodeId)
        {
            if (identity == null || identity.TokenType == UserTokenType.Anonymous)
            {
                return false;
            }

            return true;
        }
        #endregion

        #region Task #D5 - Raise an Event
        /// <summary>
        /// Constructs an event and reports to the server.
        /// </summary>
        private void RaiseAuditUpdateMethodEvent(
            ISystemContext context,
            MethodState method,
            bool status,
            IList<object> inputArguments)
        {
            BaseObjectState parent = method.Parent as BaseObjectState;

            #region Task #D6 - Add Support for Notifiers
            // check if it is even necessary to produce an event.
            if (parent != null && !parent.AreEventsMonitored)
            {
                return;
            }
            #endregion

            // construct translation object with default text.
            TranslationInfo info = new TranslationInfo(
                "AuditUpdateMethodEvent",
                "en-US",
                "A method was called.");

            // intialize the event.
            AuditUpdateMethodEventState e = new AuditUpdateMethodEventState(null);

            e.Initialize(
                SystemContext,
                null,
                EventSeverity.Medium,
                new LocalizedText(info),
                true,
                DateTime.UtcNow);

            // fill in additional fields.
            e.SetChildValue(SystemContext, Opc.Ua.BrowseNames.SourceNode, method.Parent.NodeId, false);
            e.SetChildValue(SystemContext, Opc.Ua.BrowseNames.SourceName, "Attribute/Call", false);
            e.SetChildValue(SystemContext, Opc.Ua.BrowseNames.ServerId, context.ServerUris.GetString(0), false);
            e.SetChildValue(SystemContext, Opc.Ua.BrowseNames.ClientAuditEntryId, context.AuditEntryId, false);

            if (context.UserIdentity != null)
            {
                e.SetChildValue(SystemContext, Opc.Ua.BrowseNames.ClientUserId, context.UserIdentity.DisplayName, false);
            }

            e.SetChildValue(SystemContext, Opc.Ua.BrowseNames.MethodId, method.NodeId, false);

            // need to change data type.
            Variant[] values = new Variant[inputArguments.Count];

            for (int ii = 0; ii < values.Length; ii++)
            {
                values[ii] = new Variant(inputArguments[ii]);
            }

            e.SetChildValue(SystemContext, Opc.Ua.BrowseNames.InputArguments, values, false);

            #region Task #D6 - Add Support for Notifiers
            // report the event to the parent. let it propagate up the tree. 
            if (parent != null && parent.AreEventsMonitored)
            {
                parent.ReportEvent(context, e);
                return;
            }
            #endregion

            // report the event to the server object.
            Server.ReportEvent(e);
        }
        #endregion

        /// <summary>
        /// Frees any resources allocated for the address space.
        /// </summary>
        public override void DeleteAddressSpace()
        {
            lock (Lock)
            {
                // TBD
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

                // check cache (the cache is used because the same node id can appear many times in a single request).
                if (cache != null)
                {
                    if (cache.TryGetValue(nodeId, out node))
                    {
                        return new NodeHandle(nodeId, node);
                    }
                }

                // look up predefined node.
                if (PredefinedNodes.TryGetValue(nodeId, out node))
                {
                    NodeHandle handle = new NodeHandle(nodeId, node);

                    if (cache != null)
                    {
                        cache.Add(nodeId, node);
                    }

                    return handle;
                }

                #region Task #A5 - Add Support for External Nodes
                // parse the node id and return an unvalidated handle.
                if (nodeId.IdType == IdType.String)
                {
                    return ParseNodeId(nodeId);
                }
                #endregion

                // node not found.
                return null;
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

            // lookup in operation cache.
            NodeState target = FindNodeInCache(context, handle, cache);

            if (target != null)
            {
                handle.Node = target;
                handle.Validated = true;
                return handle.Node;
            }

            #region Task #A5 - Add Support for External Nodes
            // checkf if the id actually referes to a valid node id.
            target = ValidateExternalNode(context, handle);

            if (target == null)
            {
                return null;
            }
            #endregion

            // put root into operation cache.
            if (cache != null)
            {
                cache[handle.NodeId] = target;
            }

            handle.Node = target;
            handle.Validated = true;
            return handle.Node;
        }
        #endregion

        #region Overridden Methods
        #endregion

        #region Private Methods
        /// <summary>
        /// Generates a new node id.
        /// </summary>
        private NodeId GenerateNodeId()
        {
            return new NodeId(++m_nextNodeId, NamespaceIndex);
        }
        #endregion

        #region Private Fields
        private uint m_nextNodeId;
        private TutorialServerConfiguration m_configuration;
        #endregion
    }
}
