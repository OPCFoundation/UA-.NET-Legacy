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
using Opc.Ua;
using Opc.Ua.Sample;

namespace FileSystem
{
    /// <summary>
    /// A node manager for a variety of test data.
    /// </summary>
    public class FileSystemNodeManager : SampleNodeManager
    {
        #region Constructors
        /// <summary>
        /// Initializes the node manager.
        /// </summary>
        public FileSystemNodeManager(Opc.Ua.Server.IServerInternal server, string systemRoot)
        :
            base(server)
        {
            List<string> namespaceUris = new List<string>();
         
            namespaceUris.Add(Namespaces.FileSystem);
            namespaceUris.Add(Namespaces.FileSystem + "/Instance");
            
            NamespaceUris = namespaceUris;

            m_cache = new NodeIdDictionary<NodeState>();

            // create the directory.
            string absolutePath = Utils.GetAbsoluteDirectoryPath(systemRoot, true, false,  true);
            
            // create the system.
            m_system = new FileSystemMonitor(
                SystemContext,
                absolutePath, 
                server.NamespaceUris.GetIndexOrAppend(namespaceUris[1]),
                Lock);
            
            // update the default context.
            SystemContext.SystemHandle = m_system;
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
                Utils.SilentDispose(m_system);
                m_system = null;
            }

            base.Dispose(disposing);
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
   
                // add a reference to the root object.
                base.AddExternalReference(
                    ObjectIds.ObjectsFolder,
                    ReferenceTypeIds.Organizes,
                    false,
                    m_system.CreateNodeIdFromDirectoryPath(ObjectTypes.AreaType, m_system.SystemDirectory),
                    externalReferences);
            }
        }

        /// <summary>
        /// Loads a node set from a file or resource and addes them to the set of predefined nodes.
        /// </summary>
        protected override NodeStateCollection LoadPredefinedNodes(ISystemContext context)
        {
            NodeStateCollection predefinedNodes = new NodeStateCollection();
            predefinedNodes.LoadFromBinaryResource(context, "Opc.Ua.Sample.FileSystem.FileSystem.PredefinedNodes.uanodes", null, true);
            return predefinedNodes;
        }

        /// <summary>
        /// Returns a unique handle for the node.
        /// </summary>
        /// <remarks>
        /// This must efficiently determine whether the node belongs to the node manager. If it does belong to 
        /// NodeManager it should return a handle that does not require the NodeId to be validated again when
        /// the handle is passed into other methods such as 'Read' or 'Write'.
        /// </remarks>
        protected override object GetManagerHandle(ISystemContext context, NodeId nodeId, IDictionary<NodeId,NodeState> cache)
        {
            lock (Lock)
            {
                if (!IsNodeIdInNamespace(nodeId))
                {
                    return null;
                }

                // check for cached node.
                NodeState node = null;

                if (m_cache.TryGetValue(nodeId, out node))
                {
                    return node;
                }

                // check for a dynamic node.
                object handle = FileSystemMonitor.CreateHandleFromNodeId(context, nodeId, cache);

                if (handle != null)
                {
                    return handle;
                }

                // base class will look up predefined nodes. 
                return base.GetManagerHandle(context, nodeId, cache);
            }
        }

        /// <summary>
        /// Adds the hierachy of nodes to the cache.
        /// </summary>
        private void AddNodeHierarchyToCache(ISystemContext context, NodeState root)
        {
            m_cache.Add(root.NodeId, root);
            
            List<BaseInstanceState> children = new List<BaseInstanceState>();
            root.GetChildren(context, children);

            for (int ii = 0; ii < children.Count; ii++)
            {
                AddNodeHierarchyToCache(context, children[ii]);
            }
        }
        
        /// <summary>
        /// Removes the hierachy of nodes from the cache.
        /// </summary>
        private void RemoveNodeHierarchyFromCache(ISystemContext context, NodeState root)
        {
            m_cache.Remove(root.NodeId);
            
            List<BaseInstanceState> children = new List<BaseInstanceState>();
            root.GetChildren(context, children);

            for (int ii = 0; ii < children.Count; ii++)
            {
                RemoveNodeHierarchyFromCache(context, children[ii]);
            }
        }
        
        /// <summary>
        /// Returns true if the system must be scanning to provide updates for the monitored item.
        /// </summary>
        private void StartMonitoring(ISystemContext context, MonitoredNode monitoredNode)
        {
            // find the root.
            NodeState root = monitoredNode.Node.GetHierarchyRoot();
            
            // check for areas.
            AreaState area = root as AreaState;

            if (area != null)
            {
                m_system.MonitorArea(area, false);

                if (!m_cache.ContainsKey(area.NodeId))
                {
                    AddNodeHierarchyToCache(context, area);
                }

                return;             
            }

            // check for controllers.
            ControllerState controller = root as ControllerState;

            if (controller != null)
            {
                m_system.MonitorController(controller, false);
                
                if (!m_cache.ContainsKey(controller.NodeId))
                {
                    AddNodeHierarchyToCache(context, controller);
                }

                return;             
            }
        }
        
        /// <summary>
        /// Returns true if the system must be scanning to provide updates for the monitored item.
        /// </summary>
        private void StopMonitoring(ISystemContext context, MonitoredNode monitoredNode)
        {
            // find the root.
            NodeState root = monitoredNode.Node.GetHierarchyRoot();
            
            // check for areas.
            AreaState area = root as AreaState;

            if (area != null)
            {
                if (m_system.MonitorArea(area, true) == 0)
                {                    
                    RemoveNodeHierarchyFromCache(context, area);
                }

                return;             
            }

            // check for controllers.
            ControllerState controller = root as ControllerState;

            if (controller != null)
            {
                if (m_system.MonitorController(controller, true) == 0)
                {                    
                    RemoveNodeHierarchyFromCache(context, controller);
                }

                return;             
            }
        }
        
        /// <summary>
        /// Does any processing after a monitored item is created.
        /// </summary>
        protected override void OnCreateMonitoredItem(
            ISystemContext systemContext,
            MonitoredItemCreateRequest itemToCreate,
            MonitoredNode monitoredNode,
            DataChangeMonitoredItem monitoredItem)
        {
            StartMonitoring(systemContext, monitoredNode);
        }

        /// <summary>
        /// Does any processing after a monitored item is created.
        /// </summary>
        protected override void OnModifyMonitoredItem(
            ISystemContext systemContext,
            MonitoredItemModifyRequest itemToModify,
            MonitoredNode monitoredNode,
            DataChangeMonitoredItem monitoredItem,
            double previousSamplingInterval)
        {
            // nothing to do.
        }

        /// <summary>
        /// Does any processing after a monitored item is deleted.
        /// </summary>
        protected override void OnDeleteMonitoredItem(
            ISystemContext systemContext,
            MonitoredNode monitoredNode,
            DataChangeMonitoredItem monitoredItem)
        {
            StopMonitoring(systemContext, monitoredNode);
        }

        /// <summary>
        /// Does any processing after a monitored item is created.
        /// </summary>
        protected override void OnSetMonitoringMode(
            ISystemContext systemContext,
            MonitoredNode monitoredNode,
            DataChangeMonitoredItem monitoredItem,
            MonitoringMode previousMode,
            MonitoringMode currentMode)
        {
            // nothing to do.
        }
        #endregion

        #region Private Fields
        private FileSystemMonitor m_system;
        private NodeIdDictionary<NodeState> m_cache;
        #endregion
    }
}
