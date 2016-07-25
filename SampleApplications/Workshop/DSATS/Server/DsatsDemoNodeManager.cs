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
using System.Diagnostics;
using System.Xml;
using System.IO;
using System.Threading;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using Opc.Ua;
using Opc.Ua.Server;
using DsatsDemo;

namespace DsatsDemoServer
{
    /// <summary>
    /// A node manager for a server that exposes several variables.
    /// </summary>
    public class DsatsDemoNodeManager : CustomNodeManager2
    {
        #region Constructors
        /// <summary>
        /// Initializes the node manager.
        /// </summary>
        public DsatsDemoNodeManager(IServerInternal server, ApplicationConfiguration configuration)
        :
            base(server, DsatsDemo.Namespaces.DsatsDemo, DsatsDemo.Namespaces.DsatsDemo +"/Instance")
        {
            SystemContext.NodeIdFactory = this;

            // get the configuration for the node manager.
            m_configuration = configuration.ParseExtension<DsatsDemoServerConfiguration>();

            // use suitable defaults if no configuration exists.
            if (m_configuration == null)
            {
                m_configuration = new DsatsDemoServerConfiguration();
            }

            m_source = new DataSourceClient(configuration);
            m_sessionLocks = new NodeIdDictionary<List<NodeId>>();
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

        #region Overridden Methods
        /// <summary>
        /// Loads a node set from a file or resource and addes them to the set of predefined nodes.
        /// </summary>
        protected override NodeStateCollection LoadPredefinedNodes(ISystemContext context)
        {
            NodeStateCollection predefinedNodes = new NodeStateCollection();
            predefinedNodes.LoadFromBinaryResource(context, "DsatsDemoServer.Model.DsatsDemo.PredefinedNodes.uanodes", null, true);
            return predefinedNodes;
        }
        #endregion

        #region INodeIdFactory Members
        /// <summary>
        /// Creates the NodeId for the specified node.
        /// </summary>
        public override NodeId New(ISystemContext context, NodeState node)
        {
            BaseInstanceState instance = node as BaseInstanceState;

            if (instance != null && instance.Parent != null)
            {
                if (instance.Parent.NodeId.IdType == IdType.String)
                {
                    return ParsedNodeId.CreateIdForComponent(instance, instance.Parent.NodeId.NamespaceIndex);
                }
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
                LoadPredefinedNodes(SystemContext, externalReferences);

                // find the untyped Rig node that was created when the model was loaded.
                BaseObjectState passiveNode = (BaseObjectState)FindPredefinedNode(new NodeId(DsatsDemo.Objects.Rig, NamespaceIndex), typeof(BaseObjectState));

                // convert the untyped node to a typed node that can be manipulated within the server.
                m_rig = new RigState(null);
                m_rig.Create(SystemContext, passiveNode);

                m_rig.ChangePhase.OnCall = OnChangePhase;
                m_rig.ChangePhaseWithString.OnWriteValue  = OnChangePhaseByWrite;
                m_rig.ChangePhaseWithString.OnSimpleReadValue = OnReadPhase;

                // replaces the untyped predefined nodes with their strongly typed versions.
                AddPredefinedNode(SystemContext, m_rig);

                // need to refresh the root notifier now that the object has changed.
                AddRootNotifier(m_rig);

                // load the info for the datasources.
                LoadDataSource(SystemContext);

                // connect to server (only one active server supported at this time).
                if (m_remoteNodes != null)
                {
                    foreach (RemoteNode node in m_remoteNodes.Values)
                    {
                        m_source.Connect(node.ServerUrl, m_configuration.UseSecurity);
                        break;
                    }
                }

                // update the lock ids for the default phase.
                if (m_currentPhase != null)
                {
                    m_rig.CurrentPhase.Value = m_currentPhase;
                    ChangePhase(SystemContext, m_currentPhase);
                }
            } 
        }

        /// <summary>
        /// Used to receive notifications when the value attribute is read or written.
        /// </summary>
        private ServiceResult OnReadPhase(
            ISystemContext context,
            NodeState node,
            ref object value)
        {
            if (m_currentPhase != null)
            {
                NodeState phase = FindPredefinedNode(m_currentPhase, typeof(NodeState));

                if (phase != null)
                {
                    value = phase.SymbolicName;
                    return ServiceResult.Good;
                }
            }

            return StatusCodes.BadWaitingForInitialData;
        }

        /// <summary>
        /// Handles a request to change the phase.
        /// </summary>
        public ServiceResult OnChangePhase(
            ISystemContext context,
            MethodState method,
            NodeId objectId,
            NodeId phaseId)
        {
            //if (!CheckAdminAccess(context))
            //{
            //    return StatusCodes.BadUserAccessDenied;
            //}

            if (!m_rig.IsValidPhase(phaseId))
            {
                return StatusCodes.BadNodeIdInvalid;
            }

            ChangePhase(context, phaseId);

            return ServiceResult.Good;
        }

        private ServiceResult OnChangePhaseByWrite(
            ISystemContext context,
            NodeState node,
            NumericRange indexRange,
            QualifiedName dataEncoding,
            ref object value,
            ref StatusCode statusCode,
            ref DateTime timestamp)
        {
            string phase = value as string;

            if (phase == null)
            {
                return StatusCodes.BadTypeMismatch;
            }

            List<IReference> references = new List<IReference>();
            m_rig.Phases.GetReferences(context, references, Opc.Ua.ReferenceTypeIds.Organizes, false);

            foreach (IReference reference in references)
            {
                if (reference.TargetId.ToString().Contains(phase))
                {
                    return OnChangePhase(context, m_rig.ChangePhase, m_rig.NodeId, (NodeId)reference.TargetId);
                }
            }

            return StatusCodes.BadTypeMismatch;
        }

        private void ChangePhase(ISystemContext context, NodeId phaseId)
        {
            m_currentPhase = phaseId;
            m_rig.CurrentPhase.Value = phaseId;
            m_rig.CurrentPhase.ClearChangeMasks(context, false);

            try
            {
                // build the requests.
                List<DataSourceClient.WriteRequest> requests = new List<DataSourceClient.WriteRequest>();

                for (int ii = 0; ii < m_tools.Count; ii++)
                {
                    NodeId lockId = m_tools[ii].GetLockForPhase(m_currentPhase);

                    if (NodeId.IsNull(lockId) || m_tools[ii].ActiveLockId == null)
                    {
                        continue;
                    }

                    m_tools[ii].ActiveLockId.Value = lockId.ToString();

                    RemoteNode remoteNode = null;

                    if (m_remoteNodes.TryGetValue(m_tools[ii].ActiveLockId.NodeId, out remoteNode))
                    {
                        DataSourceClient.WriteRequest request = new DataSourceClient.WriteRequest();
                        request.Index = 0;
                        request.RemoteId = remoteNode.RemoteId;
                        request.WriteValue = new WriteValue();
                        request.WriteValue.AttributeId = Attributes.Value;
                        request.WriteValue.Value.Value = lockId.ToString();
                        requests.Add(request);
                    }
                }

                // update the remote data source.
                List<ServiceResult> results = m_source.Write(requests);

                for (int ii = 0; ii < requests.Count; ii++)
                {
                    if (ServiceResult.IsBad(results[ii]))
                    {
                        Utils.Trace("Update ActiveLockId failed: {0}", results[ii].ToString());
                    }
                }
            }
            catch (Exception e)
            {
                Utils.Trace("Could not update ActiveLockIds: {0}", e.Message);
            }
        }

        /// <summary>
        /// Loads the datasource file.
        /// </summary>
        void LoadDataSource(ISystemContext context)
        {
            DsatsDemo.DataSource.DataSource datasource = null;

            string filePath = Utils.GetAbsoluteFilePath(m_configuration.DataSourceLocation, true, false, false);

            if (filePath != null)
            {
                try
                {
                    using (Stream istrm = File.OpenRead(filePath))
                    {
                        datasource = DsatsDemo.DataSource.DataSource.Read(istrm);
                    }
                }
                catch (Exception e)
                {
                    Utils.Trace(e, "Could not load the data source file. {0}", filePath);
                }
            }

            if (datasource == null)
            {
                return;
            }

            LoadDataSourcePhases(context, datasource);
            LoadDataSourceLocks(context, datasource);
            LoadDataSourceDeclarations(context, datasource);
        }

        void LoadDataSourcePhases(ISystemContext context, DsatsDemo.DataSource.DataSource datasource)
        {
            if (datasource == null || datasource.Phase == null)
            {
                return;
            }

            foreach (DsatsDemo.DataSource.PhaseType phase in datasource.Phase)
            {
                BaseObjectState node = datasource.ReadPhase(context, phase);
                node.AddReference(Opc.Ua.ReferenceTypeIds.Organizes, true, m_rig.Phases.NodeId);
                m_rig.Phases.AddReference(Opc.Ua.ReferenceTypeIds.Organizes, false, node.NodeId);
                AddPredefinedNode(context, node);

                m_rig.SetPhase(node.NodeId);

                if (m_currentPhase == null)
                {
                    m_currentPhase = node.NodeId;
                }
            }
        }

        void LoadDataSourceLocks(ISystemContext context, DsatsDemo.DataSource.DataSource datasource)
        {
            if (datasource == null || datasource.Lock == null)
            {
                return;
            }

            foreach (DsatsDemo.DataSource.LockType source in datasource.Lock)
            {
                DsatsDemo.LockConditionState node = datasource.ReadLock(context, source);

                node.Request.OnCallMethod2 = OnRequestLock;
                node.Release.OnCallMethod2 = OnReleaseLock;
                node.Approve.OnCallMethod2 = OnApproveLock;
                node.LockStateAsString.OnWriteValue = OnChangeLockByWrite;

                if (source.Permission != null)
                {
                    foreach (DsatsDemo.DataSource.CertificatePermissionType permission in source.Permission)
                    {
                        node.SetPermission(permission.Thumbprint);
                    }
                }

                node.AddNotifier(context, Opc.Ua.ReferenceTypeIds.HasEventSource, true, m_rig.Locks);
                m_rig.Locks.AddNotifier(context, Opc.Ua.ReferenceTypeIds.HasEventSource, false, node);

                AddPredefinedNode(context, node);
            }
        }

        public ServiceResult OnChangeLockByWrite(
            ISystemContext context,
            NodeState node,
            NumericRange indexRange,
            QualifiedName dataEncoding,
            ref object value,
            ref StatusCode statusCode,
            ref DateTime timestamp)
        {
            DsatsDemo.LockConditionState condition = null;

            BaseInstanceState instance = node as BaseInstanceState;

            if (instance.Parent != null)
            {
                condition = instance.Parent as DsatsDemo.LockConditionState;
            }

            if (condition == null)
            {
                return StatusCodes.BadNotWritable;
            }

            string lockState = value as string;

            if (lockState == null)
            {
                return StatusCodes.BadTypeMismatch;
            }

            if (lockState == "Locked")
            {
                ServiceResult result = OnRequestLock(context, condition.Request, condition.NodeId, new object[0], new object[0]);
                value = condition.LockStateAsString.Value;
                return result;
            }

            else if (lockState == "Unlocked")
            {
                ServiceResult result = OnReleaseLock(context, condition.Request, condition.NodeId, new object[0], new object[0]);
                value = condition.LockStateAsString.Value;
                return result;
            }

            return StatusCodes.BadTypeMismatch;
        }

        private ServiceResult OnRequestLock(
            ISystemContext context,
            MethodState method,
            NodeId objectId,
            IList<object> inputArguments,
            IList<object> outputArguments)
        {
            DsatsDemo.LockConditionState node = (DsatsDemo.LockConditionState)FindPredefinedNode(objectId, typeof(DsatsDemo.LockConditionState));

            if (!node.EnabledState.Id.Value)
            {
                return StatusCodes.BadConditionDisabled;
            }

            if (node.LockState.CurrentState.Id.Value != new NodeId(DsatsDemo.Objects.LockStateMachineType_Unlocked, NamespaceIndex))
            {
                return StatusCodes.BadConditionAlreadyShelved;
            }

            node.SessionId.Value = context.SessionId;
            node.ClientUserId.Value = null;
            node.SubjectName.Value = null;

            // get the current user name.
            if (context.UserIdentity != null)
            {
                node.ClientUserId.Value = context.UserIdentity.DisplayName;
            }

            X509Certificate2 certificate = null;

            // get the client certificate subject name.
            ServerSystemContext systemContext = context as ServerSystemContext;

            if (systemContext != null && systemContext.OperationContext != null && systemContext.OperationContext.Session != null && systemContext.OperationContext.Session.ClientCertificate != null)
            {
                certificate = systemContext.OperationContext.Session.ClientCertificate;
                node.SubjectName.Value = certificate.Subject;
            }

            node.RequestLock(context);

            // admins get locks immediately.
            if (CheckAdminAccess(context) || (certificate != null && node.HasPermission(certificate)))
            {
                GrantLockToSession(context, node.SessionId.Value, objectId);
                node.SetLock(context);
            }

            node.ReportEvent(context, node);
            node.ClearChangeMasks(context, true);

            return ServiceResult.Good;
        }

        private ServiceResult OnReleaseLock(
            ISystemContext context,
            MethodState method,
            NodeId objectId,
            IList<object> inputArguments,
            IList<object> outputArguments)
        {
            DsatsDemo.LockConditionState node = (DsatsDemo.LockConditionState)FindPredefinedNode(objectId, typeof(DsatsDemo.LockConditionState));

            if (!node.EnabledState.Id.Value)
            {
                return StatusCodes.BadConditionDisabled;
            }

            if (node.LockState.CurrentState.Id.Value == new NodeId(DsatsDemo.Objects.LockStateMachineType_Unlocked, NamespaceIndex))
            {
                return StatusCodes.BadConditionNotShelved;
            }

            // non-admins can only release their own locks.
            if (!CheckAdminAccess(context))
            {
                if (!SessionHasLock(context, objectId))
                {
                    return StatusCodes.BadUserAccessDenied;
                }
            }

            // revoke the lock.
            RevokeLockForSession(context, node.SessionId.Value, objectId);

            node.SessionId.Value = null;
            node.ClientUserId.Value = null;
            node.SubjectName.Value = null;
            node.Unlock(context);
            node.ReportEvent(context, node);
            node.ClearChangeMasks(context, true);

            return ServiceResult.Good;
        }

        private ServiceResult OnApproveLock(
            ISystemContext context,
            MethodState method,
            NodeId objectId,
            IList<object> inputArguments,
            IList<object> outputArguments)
        {
            DsatsDemo.LockConditionState node = (DsatsDemo.LockConditionState)FindPredefinedNode(objectId, typeof(DsatsDemo.LockConditionState));

            if (!node.EnabledState.Id.Value)
            {
                return StatusCodes.BadConditionDisabled;
            }

            if (node.LockState.CurrentState.Id.Value != new NodeId(DsatsDemo.Objects.LockStateMachineType_WaitingForApproval, NamespaceIndex))
            {
                return StatusCodes.BadConditionNotShelved;
            }

            // only admins can approve locks.
            if (!CheckAdminAccess(context))
            {
                return StatusCodes.BadUserAccessDenied;
            }

            // grant the lock.
            GrantLockToSession(context, node.SessionId.Value, objectId);

            node.SetLock(context);
            node.ReportEvent(context, node);
            node.ClearChangeMasks(context, true);

            return ServiceResult.Good;
        }

        void LoadDataSourceDeclarations(ISystemContext context, DsatsDemo.DataSource.DataSource datasource)
        {
            if (datasource == null || datasource.Declaration == null)
            {
                return;
            }

            m_tools = new List<ToolState>();

            foreach (DsatsDemo.DataSource.DeclarationType declaration in datasource.Declaration)
            {
                BaseInstanceState parent = m_rig;

                if (!String.IsNullOrEmpty(declaration.Path))
                {
                    parent = m_rig.FindChildBySymbolicName(context, declaration.Path);
                }

                if (parent == null)
                {
                    Utils.Trace("Skipping declaration with unknown parent. {0}", declaration.Path);
                    continue;
                }
                    
                NodeId typeDefinitionId = datasource.ReadNodeId(context, declaration.TypeDefinitionId);
                BaseInstanceState child = parent.FindChildBySymbolicName(context, declaration.BrowseName);

                if (child == null)
                {
                    uint? id = typeDefinitionId.Identifier as uint?;

                    if (id != null)
                    {
                        switch (id.Value)
                        {
                            case DsatsDemo.ObjectTypes.MudPumpType:
                            {
                                child = new MudPumpState(null);
                                break;
                            }
                        }

                        child.Create(
                            context,
                            new NodeId(declaration.Path + "/" + declaration.BrowseName, NamespaceIndex),
                            new QualifiedName(declaration.BrowseName, NamespaceIndex),
                            null,
                            true);

                        child.AddReference(Opc.Ua.ReferenceTypeIds.Organizes, true, parent.NodeId);
                        parent.AddReference(Opc.Ua.ReferenceTypeIds.Organizes, false, child.NodeId);

                        AddPredefinedNode(context, child);
                    }
                }

                ToolState tool = child as ToolState;

                if (tool != null)
                {
                    LoadDataSourceAccessRules(context, tool, declaration);
                    LoadDataSourceSources(context, tool, datasource, declaration);
                }

                m_tools.Add(tool);
            }

        }

        void LoadDataSourceAccessRules(ISystemContext context, ToolState tool, DsatsDemo.DataSource.DeclarationType declaration)
        {
            if (declaration == null || declaration.AccessRules == null)
            {
                return;
            }

            BaseInstanceState folder = tool.FindChildBySymbolicName(context, DsatsDemo.BrowseNames.AccessRules);

            if (folder == null)
            {
                return;
            }

            foreach (DsatsDemo.DataSource.AccessRuleType rule in declaration.AccessRules)
            {
                NodeId phaseId = new NodeId("Phases/" + rule.Phase, NamespaceIndex);
                NodeId lockId = new NodeId("Locks/" + rule.Lock, NamespaceIndex);

                AccessRuleState node = new AccessRuleState(null);
                node.ReferenceTypeId = Opc.Ua.ReferenceTypeIds.HasComponent;

                node.Create(
                    context,
                    new NodeId(declaration.Path + "/" + declaration.BrowseName + "/AccessRules/" + rule.Phase, NamespaceIndex),
                    new QualifiedName(rule.Phase, NamespaceIndex),
                    null,
                    true);

                node.AddReference(Opc.Ua.ReferenceTypeIds.Organizes, true, folder.NodeId);
                folder.AddReference(Opc.Ua.ReferenceTypeIds.Organizes, false, node.NodeId);

                AddPredefinedNode(context, node);

                NodeState target = FindPredefinedNode(phaseId, typeof(NodeState));

                if (target != null)
                {
                    NodeId referenceTypeId = new NodeId(DsatsDemo.ReferenceTypes.HasPhase, NamespaceIndex);
                    node.AddReference(referenceTypeId, false, target.NodeId);
                    target.AddReference(referenceTypeId, true, node.NodeId);
                }

                target = (DsatsDemo.LockConditionState)FindPredefinedNode(lockId, typeof(DsatsDemo.LockConditionState));

                if (target != null)
                {
                    NodeId referenceTypeId = new NodeId(DsatsDemo.ReferenceTypes.HasLock, NamespaceIndex);
                    node.AddReference(referenceTypeId, false, target.NodeId);
                    target.AddReference(referenceTypeId, true, node.NodeId);
                }

                tool.SetPhaseLock(phaseId, lockId);
            }
        }

        void LoadDataSourceSources(
            ISystemContext context, 
            ToolState tool, 
            DsatsDemo.DataSource.DataSource datasource, 
            DsatsDemo.DataSource.DeclarationType declaration)
        {
            if (declaration == null || declaration.Sources == null)
            {
                return;
            }

            // need to ensure the server's tables are not updated when loading this file.
            ServerSystemContext context2 = new ServerSystemContext(this.Server);
            context2.NamespaceUris = new NamespaceTable();
            context2.ServerUris = new StringTable();
            context2.NodeIdFactory = this;

            context2.NamespaceUris.Append(context.ServerUris.GetString(0));
            context2.ServerUris.Append(context.ServerUris.GetString(0));

            foreach (DsatsDemo.DataSource.SourceType source in declaration.Sources)
            {
                BaseInstanceState child = tool.FindChildBySymbolicName(context, source.Path);

                if (child == null)
                {
                    continue;
                }

                if (source.DefaultValue != null)
                {
                    BaseVariableState variable = child as BaseVariableState;

                    if (variable != null)
                    {
                        try
                        {
                            Variant value = datasource.Read(context, source.DefaultValue);
                            variable.WrappedValue = value;
                        }
                        catch (Exception)
                        {
                            Utils.Trace("Could not read Variant in file. {0}", source.DefaultValue.InnerXml);
                        }
                    }
                }

                if (source.RemoteId != null)
                {
                    ExpandedNodeId remoteId = datasource.ReadExpandedNodeId(context2, source.RemoteId);

                    if (m_remoteNodes == null)
                    {
                        m_remoteNodes = new NodeIdDictionary<RemoteNode>();
                    }

                    RemoteNode remoteNode = new RemoteNode();

                    remoteNode.Tool = tool;
                    remoteNode.ServerUrl = context2.ServerUris.GetString(remoteId.ServerIndex);
                    remoteNode.LocalNode = child;
                    remoteNode.RemoteId = remoteId;

                    m_remoteNodes.Add(child.NodeId, remoteNode);
                }
            }
        }

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

        /// <summary>
        /// Reads the value for the specified attribute.
        /// </summary>
        public override void Read(
            OperationContext context,
            double maxAge,
            IList<ReadValueId> nodesToRead,
            IList<DataValue> values,
            IList<ServiceResult> errors)
        {
            ServerSystemContext systemContext = SystemContext.Copy(context);
            IDictionary<NodeId, NodeState> operationCache = new NodeIdDictionary<NodeState>();
            List<DataSourceClient.ReadRequest> readRequests = new List<DataSourceClient.ReadRequest>();

            lock (Lock)
            {
                for (int ii = 0; ii < nodesToRead.Count; ii++)
                {
                    ReadValueId nodeToRead = nodesToRead[ii];

                    // skip items that have already been processed.
                    if (nodeToRead.Processed)
                    {
                        continue;
                    }

                    // check for valid handle.
                    NodeHandle handle = GetManagerHandle(systemContext, nodeToRead.NodeId, operationCache);

                    if (handle == null)
                    {
                        continue;
                    }

                    // owned by this node manager.
                    nodeToRead.Processed = true;

                    // create an initial value.
                    DataValue value = values[ii] = new DataValue();

                    value.Value = null;
                    value.ServerTimestamp = DateTime.UtcNow;
                    value.SourceTimestamp = DateTime.MinValue;
                    value.StatusCode = StatusCodes.Good;

                    // check if the node is a area in memory.
                    if (handle.Node == null)
                    {
                        errors[ii] = StatusCodes.BadNodeIdUnknown;
                        continue;
                    }

                    if (nodeToRead.AttributeId == Attributes.Value)
                    {
                        // check if the request if for a remote node.
                        RemoteNode remoteNode = null;

                        if (m_remoteNodes.TryGetValue(handle.NodeId, out remoteNode))
                        {
                            DataSourceClient.ReadRequest request = new DataSourceClient.ReadRequest();
                            request.RemoteId = remoteNode.RemoteId;
                            request.ReadValueId = nodeToRead;
                            request.Value = value;
                            request.Index = ii;
                            readRequests.Add(request);

                            errors[ii] = StatusCodes.BadNoCommunication;
                            continue;
                        }
                    }

                    // read the attribute value.
                    errors[ii] = handle.Node.ReadAttribute(
                        systemContext,
                        nodeToRead.AttributeId,
                        nodeToRead.ParsedIndexRange,
                        nodeToRead.DataEncoding,
                        value);
                }

                // check for nothing to do.
                if (readRequests.Count == 0)
                {
                    return;
                }
            }

            // read from the remote data source.
            List<ServiceResult> results = m_source.Read(readRequests);

            for (int ii = 0; ii < readRequests.Count; ii++)
            {
                values[readRequests[ii].Index] = readRequests[ii].Value;
                errors[readRequests[ii].Index] = results[ii];
            }
        }

        /// <summary>
        /// Writes the value for the specified attributes.
        /// </summary>
        public override void Write(
            OperationContext context,
            IList<WriteValue> nodesToWrite,
            IList<ServiceResult> errors)
        {
            ServerSystemContext systemContext = SystemContext.Copy(context);
            IDictionary<NodeId, NodeState> operationCache = new NodeIdDictionary<NodeState>();
            List<DataSourceClient.WriteRequest> writeRequests = new List<DataSourceClient.WriteRequest>();

            lock (Lock)
            {
                for (int ii = 0; ii < nodesToWrite.Count; ii++)
                {
                    WriteValue nodeToWrite = nodesToWrite[ii];

                    // skip items that have already been processed.
                    if (nodeToWrite.Processed)
                    {
                        continue;
                    }

                    // check for valid handle.
                    NodeHandle handle = GetManagerHandle(systemContext, nodeToWrite.NodeId, operationCache);

                    if (handle == null)
                    {
                        continue;
                    }

                    // owned by this node manager.
                    nodeToWrite.Processed = true;

                    // index range is not supported.
                    if (nodeToWrite.AttributeId != Attributes.Value)
                    {
                        if (!String.IsNullOrEmpty(nodeToWrite.IndexRange))
                        {
                            errors[ii] = StatusCodes.BadWriteNotSupported;
                            continue;
                        }
                    }

                    // check if the node is a area in memory.
                    if (handle.Node == null)
                    {
                        errors[ii] = StatusCodes.BadNodeIdUnknown;
                        continue;
                    }

                    // check if the request if for a remote node.
                    RemoteNode remoteNode = null;

                    if (m_remoteNodes.TryGetValue(handle.NodeId, out remoteNode))
                    {
                        // check for theorectical access.
                        BaseVariableState variable = handle.Node as BaseVariableState;

                        if (variable == null || nodeToWrite.AttributeId != Attributes.Value || (variable.AccessLevel & AccessLevels.CurrentWrite) == 0)
                        {
                            errors[ii] = StatusCodes.BadNotWritable;
                            continue;
                        }

                        // check for access based on current user credentials.
                        if (!CheckWriteAccess(systemContext, remoteNode))
                        {
                            errors[ii] = StatusCodes.BadUserAccessDenied;
                            continue;
                        }

                        DataSourceClient.WriteRequest request = new DataSourceClient.WriteRequest();
                        request.RemoteId = remoteNode.RemoteId;
                        request.WriteValue = nodeToWrite;
                        request.Index = ii;
                        writeRequests.Add(request);

                        errors[ii] = StatusCodes.BadNoCommunication;
                        continue;
                    }

                    // write the attribute value.
                    errors[ii] = handle.Node.WriteAttribute(
                        systemContext,
                        nodeToWrite.AttributeId,
                        nodeToWrite.ParsedIndexRange,
                        nodeToWrite.Value);

                    // updates to source finished - report changes to monitored items.
                    handle.Node.ClearChangeMasks(systemContext, false);
                }

                // check for nothing to do.
                if (writeRequests.Count == 0)
                {
                    return;
                }
            }
            
            // update the remote data source.
            List<ServiceResult> results = m_source.Write(writeRequests);

            for (int ii = 0; ii < writeRequests.Count; ii++)
            {
                errors[writeRequests[ii].Index] = results[ii];
            }
        }
        #endregion

        /// <summary>
        /// Checks if the current session has admin priviledges.
        /// </summary>
        private bool CheckAdminAccess(ISystemContext context)
        {
            // no access if no identity.
            if (context.UserIdentity == null || context.UserIdentity.TokenType != UserTokenType.UserName)
            {
                return false;
            }

            string filePath = Utils.GetAbsoluteFilePath(m_configuration.AccessControlFilePath, false, false, false);

            // nothing more to do if no file.
            if (filePath == null)
            {
                return true;
            }

            // check if account has access to semaphore file.
            try
            {
                using (Stream ostrm = File.OpenWrite(filePath))
                {
                    ostrm.Close();
                }

                // access granted.
                return true;
            }
            catch (Exception)
            {
                // need to check if lock has been granted.
            }

            return false;
        }

        /// <summary>
        /// Returns true if the current session has the lock.
        /// </summary>
        private bool SessionHasLock(ISystemContext context, NodeId lockId)
        {
            List<NodeId> locks = null;

            if (!m_sessionLocks.TryGetValue(context.SessionId, out locks))
            {
                return false;
            }

            for (int ii = 0; ii < locks.Count; ii++)
            {
                if (locks[ii] == lockId)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Called when a session is closed.
        /// </summary>
        public override void SessionClosing(OperationContext context, NodeId sessionId, bool deleteSubscriptions)
        {
            lock (Lock)
            {
                List<NodeId> locks = null;

                if (!m_sessionLocks.TryGetValue(sessionId, out locks))
                {
                    return;
                }

                m_sessionLocks.Remove(sessionId);

                for (int ii = 0; ii < locks.Count; ii++)
                {
                    DsatsDemo.LockConditionState node = (DsatsDemo.LockConditionState)FindPredefinedNode(locks[ii], typeof(DsatsDemo.LockConditionState));

                    if (node != null)
                    {
                        node.SessionId.Value = null;
                        node.ClientUserId.Value = null;
                        node.SubjectName.Value = null;
                        node.Unlock(SystemContext);
                        node.ReportEvent(SystemContext, node);
                    }
                }
            }
        }

        /// <summary>
        /// Grants the lock to the session.
        /// </summary>
        private void GrantLockToSession(ISystemContext context, NodeId sessionId, NodeId lockId)
        {
            List<NodeId> locks = null;

            if (!m_sessionLocks.TryGetValue(sessionId, out locks))
            {
                m_sessionLocks[sessionId] = locks = new List<NodeId>();
            }

            if (!locks.Contains(lockId))
            {
                locks.Add(lockId);
            }
        }

        /// <summary>
        /// Revokes the lock to the session.
        /// </summary>
        private void RevokeLockForSession(ISystemContext context, NodeId sessionId, NodeId lockId)
        {
            List<NodeId> locks = null;

            if (!m_sessionLocks.TryGetValue(sessionId, out locks))
            {
                return;
            }

            for (int ii = 0; ii < locks.Count; ii++)
            {
                if (locks[ii] == lockId)
                {
                    locks.RemoveAt(ii);
                    break;
                }
            }
        }
                
        /// <summary>
        /// Checks if the current user has write access to the remote node.
        /// </summary>
        private bool CheckWriteAccess(ServerSystemContext context, RemoteNode remoteNode)
        {
            // check if session has admin access.
            //if (CheckAdminAccess(context))
            //{
            //    return true;
            //}

            // check if the session holds any locks.
            List<NodeId> locks = null;

            if (!m_sessionLocks.TryGetValue(context.SessionId, out locks))
            {
                return false;
            }

            // check if the tool has locks for the current phase.
            NodeId lockId = remoteNode.Tool.GetLockForPhase(m_currentPhase);

            if (lockId == null)
            {
                return false;
            }

            // check if a lock is held.
            if (SessionHasLock(context, lockId))
            {
                return true;
            }

            return false;
        }

        private List<DataSourceClient.MonitoringRequest> CollectRequests(ServerSystemContext context, IList<IMonitoredItem> monitoredItems)
        {
            List<DataSourceClient.MonitoringRequest> requests = new List<DataSourceClient.MonitoringRequest>();

            for (int ii = 0; ii < monitoredItems.Count; ii++)
            {
                MonitoredItem monitoredItem = monitoredItems[ii] as MonitoredItem;

                if (monitoredItem != null)
                {
                    if (monitoredItem.AttributeId != Attributes.Value)
                    {
                        continue;
                    }

                    RemoteNode remoteNode = null;

                    if (m_remoteNodes.TryGetValue(monitoredItem.NodeId, out remoteNode))
                    {
                        DataSourceClient.MonitoringRequest request = new DataSourceClient.MonitoringRequest();
                        request.RemoteId = remoteNode.RemoteId;
                        request.MonitoredItem = monitoredItem;
                        requests.Add(request);
                    }
                }
            }

            return requests;
        }

        protected override void OnCreateMonitoredItemsComplete(ServerSystemContext context, IList<IMonitoredItem> monitoredItems)
        {
            List<DataSourceClient.MonitoringRequest> requests = null;

            lock (Lock)
            {
                requests = CollectRequests(context, monitoredItems);
            }

            m_source.CreateMonitoredItems(requests);
        }

        protected override void OnModifyMonitoredItemsComplete(ServerSystemContext context, IList<IMonitoredItem> monitoredItems)
        {
            List<DataSourceClient.MonitoringRequest> requests = null;

            lock (Lock)
            {
                requests = CollectRequests(context, monitoredItems);
            }

            m_source.ModifyMonitoredItems(requests);
        }

        protected override void OnDeleteMonitoredItemsComplete(ServerSystemContext context, IList<IMonitoredItem> monitoredItems)
        {
            List<DataSourceClient.MonitoringRequest> requests = null;

            lock (Lock)
            {
                requests = CollectRequests(context, monitoredItems);
            }

            m_source.DeleteMonitoredItems(requests);
        }

        protected override void OnSetMonitoringModeComplete(ServerSystemContext context, IList<IMonitoredItem> monitoredItems)
        {
            List<DataSourceClient.MonitoringRequest> requests = null;

            lock (Lock)
            {
                requests = CollectRequests(context, monitoredItems);
            }

            m_source.SetMonitoringMode(requests);
        }

        #region RemoteNode Class
        /// <summary>
        /// Stores the mapping between a local and remote node,
        /// </summary>
        private class RemoteNode
        {
            public string ServerUrl;
            public ToolState Tool;
            public BaseInstanceState LocalNode;
            public ExpandedNodeId RemoteId;
        }
        #endregion

        #region Private Fields
        private DsatsDemoServerConfiguration m_configuration;
        private RigState m_rig;
        private List<ToolState> m_tools;
        private NodeIdDictionary<RemoteNode> m_remoteNodes;
        private DataSourceClient m_source;
        private NodeId m_currentPhase;
        private NodeIdDictionary<List<NodeId>> m_sessionLocks;
        #endregion
    }
}
