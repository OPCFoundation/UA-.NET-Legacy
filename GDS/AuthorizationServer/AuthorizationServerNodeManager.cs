/* Copyright (c) 1996-2016, OPC Foundation. All rights reserved.

   The source code in this file is covered under a dual-license scenario:
     - RCL: for OPC Foundation members in good-standing
     - GPL V2: everybody else

   RCL license terms accompanied with this source code. See http://opcfoundation.org/License/RCL/1.00/

   GNU General Public License as published by the Free Software Foundation;
   version 2 of the License are accompanied with this source code. See http://opcfoundation.org/License/GPLv2

   This source code is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Opc.Ua;
using Opc.Ua.Server;

namespace AuthorizationServer
{
    /// <summary>
    /// A node manager for a server that exposes several variables.
    /// </summary>
    public class AuthorizationServerNodeManager : CustomNodeManager2
    {
        #region Private Fields
        private uint m_nextNodeId;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes the node manager.
        /// </summary>
        public AuthorizationServerNodeManager(IServerInternal server, ApplicationConfiguration configuration)
        :
            base(server, configuration)
        {
            List<string> namespaceUris = new List<string>();
            namespaceUris.Add("http://opcfoundation.org/UA/GDS/applications/");
            namespaceUris.Add(Opc.Ua.Gds.Namespaces.OpcUaGds);
            NamespaceUris = namespaceUris;
            SystemContext.NodeIdFactory = this;
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
                return GenerateNodeId();
            }

            return node.NodeId;
        }
        #endregion

        #region INodeManager Members
        /// <summary>
        /// Does any initialization required before the address space can be used.
        /// </summary>
        public override void CreateAddressSpace(IDictionary<NodeId, IList<IReference>> externalReferences)
        {
            lock (Lock)
            {
                base.CreateAddressSpace(externalReferences);

                for (int ii = 0; ii < 3; ii++)
                {
                    BaseObjectState device = new BaseObjectState(null);
                    device.Create(Server.DefaultSystemContext, GenerateNodeId(), new QualifiedName("Device" + ii.ToString(), NamespaceIndex), null, true);
                    device.AddReference(ReferenceTypeIds.Organizes, true, ObjectIds.ObjectsFolder);
                    AddExternalReference(ObjectIds.ObjectsFolder, ReferenceTypeIds.Organizes, false, device.NodeId, externalReferences);
                    AddPredefinedNode(Server.DefaultSystemContext, device);

                    AnalogItemState measurement = new AnalogItemState(null);
                    measurement.Create(Server.DefaultSystemContext, GenerateNodeId(), new QualifiedName("Measurement", NamespaceIndex), null, true);
                    measurement.AddReference(ReferenceTypeIds.HasComponent, true, device.NodeId);
                    device.AddReference(ReferenceTypeIds.HasComponent, false, measurement.NodeId);
                    AddPredefinedNode(Server.DefaultSystemContext, measurement);

                    AnalogItemState setpoint = new AnalogItemState(null);
                    setpoint.Create(Server.DefaultSystemContext, GenerateNodeId(), new QualifiedName("SetPoint", NamespaceIndex), null, true);
                    setpoint.AddReference(ReferenceTypeIds.HasComponent, true, device.NodeId);
                    device.AddReference(ReferenceTypeIds.HasComponent, false, setpoint.NodeId);
                    AddPredefinedNode(Server.DefaultSystemContext, setpoint);
                }
            }
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

            if (typeId.IdType != IdType.Numeric)
            {
                return predefinedNode;
            }

            return predefinedNode;
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
    }
}
