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
            base(server, configuration, Namespaces.Tutorial)            
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
                return GenerateNodeId();
            }

            return node.NodeId;
        }
        #endregion

        /// <summary>
        /// Used to receive notifications when the value attribute is read or written.
        /// </summary>
        public ServiceResult DoLoadDictionary(
            ISystemContext context,
            NodeState node,
            ref object value)
        {
            Stream istrm = Assembly.GetExecutingAssembly().GetManifestResourceStream("TutorialServer.Model.TutorialModel.Types.bsd");

            if (istrm == null)
            {
                throw ServiceResultException.Create(StatusCodes.BadDecodingError, "Could not load resource.");
            }

            StreamReader reader = new StreamReader(istrm);
            string xml = reader.ReadToEnd();
            value = new UTF8Encoding().GetBytes(xml);

            return ServiceResult.Good;
        }

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
                BaseObjectState root = CreateFolderNode("x:\\Work");

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
            }
        }

        private BaseObjectState CreateFolderNode(string path)
        {
            DirectoryInfo info = new DirectoryInfo(path);

            if (!info.Exists)
            {
                return null;
            }

            ParsedNodeId nodeId = new ParsedNodeId();
            nodeId.RootType = 0;
            nodeId.RootId = path;
            nodeId.NamespaceIndex = NamespaceIndex;

            FolderState node = new FolderState(null);

            node.NodeId = nodeId.Construct();
            node.BrowseName = new QualifiedName(info.Name, NamespaceIndex);
            node.DisplayName = node.BrowseName.Name;
            node.TypeDefinitionId = ObjectTypeIds.FolderType;

            node.OnPopulateBrowser = OnPopulateBrowser;

            return node;
        }

        /// <summary>
        /// Used to receive notifications when a node is browsed.
        /// </summary>
        public void OnPopulateBrowser(
            ISystemContext context,
            NodeState node,
            NodeBrowser browser)
        {
            ParsedNodeId nodeId = ParsedNodeId.Parse(node.NodeId);
            DirectoryInfo info = new DirectoryInfo(nodeId.RootId);

            if (!info.Exists)
            {
                return;
            }

            if (browser.IsRequired(ReferenceTypeIds.Organizes, false))
            {
                foreach (DirectoryInfo child in info.GetDirectories())
                {
                    ParsedNodeId childId = new ParsedNodeId();
                    childId.RootType = 0;
                    childId.RootId = child.FullName;
                    childId.NamespaceIndex = NamespaceIndex;

                    browser.Add(new NodeStateReference(ReferenceTypeIds.Organizes, false, childId.Construct()));
                }
            }

            if (browser.IsRequired(ReferenceTypeIds.Organizes, true))
            {
                ParsedNodeId parentId = new ParsedNodeId();
                parentId.RootType = 0;
                parentId.RootId = info.Parent.FullName;
                parentId.NamespaceIndex = NamespaceIndex;

                browser.Add(new NodeStateReference(ReferenceTypeIds.Organizes, true, parentId.Construct()));
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
                    NodeHandle handle = new NodeHandle();
                    handle.NodeId = nodeId;
                    handle.Validated = false;
                    handle.ParsedNodeId = ParsedNodeId.Parse(nodeId);
                    return handle;
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
            ParsedNodeId nodeId = (ParsedNodeId)handle.ParsedNodeId;
            BaseObjectState node = CreateFolderNode(nodeId.RootId);

            if (node == null)
            {
                return null;
            }

            target = node;
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
