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
using System.Xml;
using System.IO;
using System.Text;
using System.Reflection;
using System.Threading;
using System.Globalization;
using Opc.Ua;
using Opc.Ua.Server;

namespace FileSystem
{
    /// <summary>
    /// Provides access to a file system that contains configuration files for controllers.
    /// </summary>
    public class FileSystemMonitor : IDisposable
    {
        #region Constructors
        /// <summary>
        /// Initializes the object with the root directory and the namespace index assigned to the node manager.
        /// </summary>
        public FileSystemMonitor(
            ISystemContext systemContext, 
            string systemDirectory, 
            ushort namespaceIndex, 
            object dataLock)
        {
            m_systemContext = systemContext;
            m_systemDirectory = systemDirectory;
            m_namespaceIndex = namespaceIndex;
            m_dataLock = dataLock;
            m_monitoredObjects = new List<MonitoredObject>();
        }
        #endregion
        
        #region IDisposable Members
        /// <summary>
        /// Frees any unmanaged resources.
        /// </summary>
        public void Dispose()
        {   
            Dispose(true);
        }

        /// <summary>
        /// An overrideable version of the Dispose.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {  
            if (disposing)
            {
                Timer timer = m_timer;
                Utils.SilentDispose(timer);
                m_timer = null;
            }
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// The root directory for the file system.
        /// </summary>
        public string SystemDirectory
        {
            get { return m_systemDirectory; }
        }

        /// <summary>
        /// The index of the namespace that qualifies the node ids.
        /// </summary>
        public ushort NamespaceIndex
        {
            get { return m_namespaceIndex; }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Creates a node id from an absolute file path.
        /// </summary>
        public NodeId CreateNodeIdFromFilePath(uint objectTypeId, string filePath)
        {
            if (filePath == null)
            {
                return null;
            }

            string path = filePath.ToUpperInvariant();
            string prefix = m_systemDirectory.ToUpperInvariant();

            if (!path.StartsWith(prefix))
            {
                return null;
            }
            
            if (prefix.Length < path.Length-1)
            {
                path = path.Substring(prefix.Length+1);
            }
            else
            {
                path = String.Empty;
            }

            int index = path.LastIndexOf('.');

            if (index >= 0)
            {
                path = path.Substring(0, index);
            }

            StringBuilder buffer = new StringBuilder();

            buffer.AppendFormat("{0}:", objectTypeId);
            buffer.Append(path);

            return new NodeId(buffer.ToString(), m_namespaceIndex);
        }
                
        /// <summary>
        /// Creates a node id from an absolute directory path.
        /// </summary>
        public NodeId CreateNodeIdFromDirectoryPath(uint objectTypeId, string directoryPath)
        {
            if (directoryPath == null)
            {
                return null;
            }

            string path = directoryPath.ToUpperInvariant();
            string prefix = m_systemDirectory.ToUpperInvariant();

            if (!path.StartsWith(prefix))
            {
                return null;
            }
           
            if (prefix.Length < path.Length-1)
            {
                path = path.Substring(prefix.Length+1);
            }
            else
            {
                path = String.Empty;
            }

            StringBuilder buffer = new StringBuilder();

            buffer.AppendFormat("{0}:", objectTypeId);
            buffer.Append(path);

            return new NodeId(buffer.ToString(), m_namespaceIndex);
        }
        
        /// <summary>
        /// Extracts an absolute file/directory path from a node id.
        /// </summary>
        public string ExtractPathFromNodeId(NodeId nodeId)
        {
            if (nodeId == null || nodeId.NamespaceIndex != m_namespaceIndex || nodeId.IdType != IdType.String)
            {
                return null;
            }

            string path = (string)nodeId.Identifier;

            // extract the object type prefix.
            int index = path.IndexOf(':');

            if (index < 0)
            {
                return null;
            }

            // empty path for root node.
            if (index == path.Length-1)
            {
                return m_systemDirectory;
            }

            path = path.Substring(index+1);

            // remove any suffix.
            index = path.IndexOf(':');

            if (index >= 0)
            {
                path = path.Substring(0, index);
            }


            StringBuilder buffer = new StringBuilder();

            buffer.Append(m_systemDirectory);
            buffer.Append('\\');
            buffer.Append(path);

            return buffer.ToString();
        }
        
        /// <summary>
        /// Creates the appropriate NodeState object from a NodeId. 
        /// </summary>
        public static NodeState CreateHandleFromNodeId(
            ISystemContext context, 
            NodeId nodeId,
            IDictionary<NodeId,NodeState> cache)
        {            
            // get the system to use.
            FileSystemMonitor system = context.SystemHandle as FileSystemMonitor;

            if (system == null)
            {
                return null;
            }
            
            // check for valid node id.
            if (nodeId == null || nodeId.NamespaceIndex != system.m_namespaceIndex || nodeId.IdType != IdType.String)
            {
                return null;
            }

            // lookup in cache.
            NodeState state = null;

            if (cache != null)
            {
                if (cache.TryGetValue(nodeId, out state))
                {
                    return state;
                }
            }

            string path = (string)nodeId.Identifier;
            uint baseline = (uint)Convert.ToUInt32('0');

            // parse the object type id.
            uint objectTypeId = 0;
            int start = 0;

            for (int ii = 0; ii < path.Length; ii++)
            {
                if (path[ii] == ':')
                {
                    start = ii+1;
                    break;
                }

                if (!Char.IsDigit(path[ii]))
                {
                    return null;
                }

                objectTypeId *= 10;
                objectTypeId += (uint)Convert.ToUInt32(path[ii]) - baseline;
            }

            string parentPath = path;
            NodeId parentId = nodeId;

            // check if referencing a child of the object.
            int end = -1;
            
            if (start < path.Length)
            {
                end = path.IndexOf(':', start);

                if (end >= start)
                {
                    parentPath = path.Substring(0, end);
                    parentId = new NodeId(parentPath, system.NamespaceIndex);
                }
            }
                
            // return cached value if available.
            if (cache != null)
            {
                if (!cache.TryGetValue(parentId, out state))
                {
                    state = null;
                }
            }
            
            // create the object instance.
            if (state == null)
            {
                switch (objectTypeId)
                {
                    case ObjectTypes.AreaType:
                    {
                        string directoryPath = system.ExtractPathFromNodeId(nodeId);
                        state = new AreaState(context, new DirectoryInfo(directoryPath));
                        break;
                    }

                    case ObjectTypes.ControllerType:
                    {
                        string filePath = system.ExtractPathFromNodeId(nodeId);
                        filePath += ".csv";
                        state = new ControllerState(context, new FileInfo(filePath));
                        break;
                    }

                    default:
                    {
                        return null;
                    }
                }

                // update cache if provided.
                if (cache != null)
                {
                    cache[parentId] = state;
                }
            }

            // nothing more to do if referencing the root.
            if (end < 0)
            {
                return state;
            }
            
            // create the child identified by the name in the node id.
            string childPath = path.Substring(end+1);
            
            // extract path of children.
            List<string> childNames = new List<string>();

            int index = childPath.IndexOf(':');

            while (index > 0)
            {
                childNames.Add(childPath.Substring(0, index));
                childPath = childPath.Substring(index+1);
                index = childPath.IndexOf(':');
            }

            childNames.Add(childPath);
          
            NodeState parent = state;
            BaseInstanceState child = null;

            for (int ii = 0; ii < childNames.Count; ii++)
            {            
                child = parent.CreateChild(
                    context, 
                    new QualifiedName(childNames[ii], 0));
                
                if (child == null)
                {
                    return null;
                }

                parent = child;

                if (ii == childNames.Count-1)
                {
                    child.NodeId = nodeId;

                    if (state.ValidationRequired)
                    {
                        child.OnValidate = system.ValidateChild;
                    }

                    if (cache != null)
                    {
                        cache[nodeId] = child;
                    }
                }
            }

            return child;
        }

        /// <summary>
        /// Checks if the the child is for its parent.
        /// </summary>
        public bool ValidateChild(ISystemContext context, NodeState node)
        {
            // only need to validate once.
            node.OnValidate = null;

            BaseInstanceState child = node as BaseInstanceState;

            if (child == null)
            {
                return true;
            }

            // validate the root node.
            NodeState parent = child.Parent;
            
            while (parent != null)
            {
                BaseInstanceState instance = parent as BaseInstanceState;

                if (instance == null || instance.Parent == null)
                {
                    return parent.Validate(context);
                }

                parent = instance.Parent;
            }
            
            return true;
        }

        /// <summary>
        /// Validates an area, creates the node and assigns node ids to all children.
        /// </summary>
        public bool ValidateArea(ISystemContext context, NodeState node)
        {
            // only need to validate once.
            node.OnValidate = null;
                       
            DirectoryInfo directory = AreaState.GetDirectory(context, node.NodeId);

            if (directory == null || !directory.Exists)
            {
                return false;
            }
            
            // initialize the area from the type model.
            node.Create(context, node.NodeId, node.BrowseName, null, false);

            // assign the child node ids.
            AssignChildNodeIds(context, node);
                        
            return true;
        }
        
        /// <summary>
        /// Assigns node ids to the children based on the parent node id.
        /// </summary>
        public void AssignChildNodeIds(ISystemContext context, NodeState parent)
        {
            NodeId parentId = parent.NodeId;

            // check for valid node id.
            if (parentId == null || parentId.IdType != IdType.String)
            {
                return;
            }

            List<BaseInstanceState> children = new List<BaseInstanceState>();
            parent.GetChildren(context, children);

            for (int ii = 0; ii < children.Count; ii++)
            {
                BaseInstanceState child = children[ii];

                if (child.SymbolicName == null)
                {
                    continue;
                }

                StringBuilder builder = new StringBuilder();
                
                builder.Append(parentId.Identifier);
                builder.Append(':');
                builder.Append(child.SymbolicName);

                child.NodeId = new NodeId(builder.ToString(), parentId.NamespaceIndex);

                AssignChildNodeIds(context, child);
            }
        }
        
        /// <summary>
        /// Validates a controller, creates the node and assigns node ids to all children.
        /// </summary>
        public bool ValidateController(ISystemContext context, NodeState node)
        {
            // only need to validate once.
            node.OnValidate = null;

            FileInfo file = ControllerState.GetFile(context, node.NodeId);

            if (file == null || !file.Exists)
            {
                return false;
            }

            // initialize the controller from the type model.
            NodeId originalId = node.NodeId;

            node.Create(context, node.NodeId, node.BrowseName, null, false);

            node.NodeId = originalId;

            // assign the child node ids.
            AssignChildNodeIds(context, node);

            return true;
        }

        /// <summary>
        /// Starts monitoring an area for changes.
        /// </summary>
        public int MonitorArea(AreaState area, bool stop)
        {
            lock (m_dataLock)
            {
                MonitoredObject monitoredObject = null;

                for (int ii = 0; ii < m_monitoredObjects.Count; ii++)
                {
                    monitoredObject = m_monitoredObjects[ii];

                    if (Object.ReferenceEquals(area, monitoredObject.Area))
                    {
                        if (stop)
                        {
                            monitoredObject.Refs--;

                            if (monitoredObject.Refs == 0)
                            {
                                m_monitoredObjects.RemoveAt(ii);
                            }
                        }
                        else
                        {
                            monitoredObject.Refs++;
                        }

                        return monitoredObject.Refs;
                    }
                }
                
                if (stop)
                {
                    return 0;
                }

                StartTimer();
                
                monitoredObject = new MonitoredObject();
                monitoredObject.Area = area;
                monitoredObject.Refs = 1;

                m_monitoredObjects.Add(monitoredObject);

                return monitoredObject.Refs;
            }
        }
        
        /// <summary>
        /// Starts monitoring a controller for changes.
        /// </summary>
        public int MonitorController(ControllerState controller, bool stop)
        {
            lock (m_dataLock)
            {
                MonitoredObject monitoredObject = null;

                for (int ii = 0; ii < m_monitoredObjects.Count; ii++)
                {
                    monitoredObject = m_monitoredObjects[ii];

                    if (Object.ReferenceEquals(controller, monitoredObject.Controller))
                    {
                        if (stop)
                        {
                            monitoredObject.Refs--;

                            if (monitoredObject.Refs == 0)
                            {
                                m_monitoredObjects.RemoveAt(ii);
                            }
                        }
                        else
                        {
                            monitoredObject.Refs++;
                        }

                        return monitoredObject.Refs;
                    }
                }
                
                if (stop)
                {
                    return 0;
                }

                StartTimer();
                
                monitoredObject = new MonitoredObject();;
                monitoredObject.Controller = controller;
                monitoredObject.Refs = 1;

                m_monitoredObjects.Add(monitoredObject);

                return monitoredObject.Refs;
            }
        }
        #endregion
        
        #region MonitoredObject Class
        /// <summary>
        /// Stores the state of an area or controller being monitored.
        /// </summary>
        private class MonitoredObject
        {
            public AreaState Area;
            public ControllerState Controller;
            public int Refs;
        }
        #endregion
        
        #region Private Methods
        /// <summary>
        /// Starts the monitoring timer.
        /// </summary>
        private void StartTimer()
        {
            if (m_timer == null)
            {
                m_timer = new Timer(OnUpdate, null, 1000, 1000);
            }
        }

        /// <summary>
        /// Periodically checks for changes for any monitored area or controller.
        /// </summary>
        private void OnUpdate(object state)
        {
            try
            {
                lock (m_dataLock)
                {
                    // check if halted.
                    if (m_monitoredObjects.Count == 0)
                    {
                        m_timer.Dispose();
                        m_timer = null;
                        return;
                    }

                    for (int ii = 0; ii < m_monitoredObjects.Count; ii++)
                    {
                        MonitoredObject monitoredObject = m_monitoredObjects[ii];
                        
                        if (monitoredObject.Area != null)
                        {
                            monitoredObject.Area.CheckForChanges(m_systemContext);
                            monitoredObject.Area.ClearChangeMasks(m_systemContext, true);
                        }
                        
                        if (monitoredObject.Controller != null)
                        {
                            monitoredObject.Controller.CheckForChanges(m_systemContext);
                            monitoredObject.Controller.ClearChangeMasks(m_systemContext, true);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Utils.Trace(e, "FileSystemMonitor: Unexpected error updating monitored objects.");
            }
        }
        #endregion

        #region Private Fields
        private object m_dataLock;
        private ushort m_namespaceIndex;
        private string m_systemDirectory;
        private List<MonitoredObject> m_monitoredObjects;
        private Timer m_timer;
        private ISystemContext m_systemContext;
        #endregion
    }
}
