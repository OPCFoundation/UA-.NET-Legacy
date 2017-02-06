/* ========================================================================
 * Copyright (c) 2005-2017 The OPC Foundation, Inc. All rights reserved.
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
using System.ServiceModel;
using System.Runtime.Serialization;
using System.IO;
using System.Xml;
using System.Text;

namespace Opc.Ua
{    
    /// <summary>
    /// A set of nodes in an address space.
    /// </summary>
	[DataContract(Namespace = Namespaces.OpcUaXsd)]
    [KnownType(typeof(ObjectNode))]
    [KnownType(typeof(ObjectTypeNode))]
    [KnownType(typeof(VariableNode))]
    [KnownType(typeof(VariableTypeNode))]
    [KnownType(typeof(MethodNode))]
    [KnownType(typeof(DataTypeNode))]
    [KnownType(typeof(ReferenceTypeNode))]
    [KnownType(typeof(ViewNode))]
    public partial class NodeSet  : IEnumerable<Node>
    {
        #region Constructors
        /// <summary>
        /// Creates an empty nodeset.
        /// </summary>
        public NodeSet()
        {
            m_namespaceUris = new NamespaceTable();
            m_serverUris = new StringTable();
            m_nodes = new Dictionary<string,Node>();
        }
        
        /// <summary>
        /// Loads a nodeset from a stream.
        /// </summary>
        public static NodeSet Read(Stream istrm)
        {
            XmlTextReader reader = new XmlTextReader(istrm);
            
            try
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(NodeSet));
                return serializer.ReadObject(reader) as NodeSet;
            }
            finally
            {
                reader.Close();
            }
        }
        
        /// <summary>
        /// Write a nodeset to a stream.
        /// </summary>
        public void Write(Stream istrm)
        {
            XmlTextWriter writer = new XmlTextWriter(istrm, Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
                        
            try
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(NodeSet));
                serializer.WriteObject(writer, this);
            }
            finally
            {
                writer.Close();
            }
        }
        #endregion
        
        #region IEnumerable<IReference> Members
        /// <summary cref="IEnumerable{T}.GetEnumerator" />
        public IEnumerator<Node> GetEnumerator()
        {
            return new List<Node>(m_nodes.Values).GetEnumerator();
        }
        #endregion

        #region IEnumerable Members
        /// <summary cref="System.Collections.IEnumerable.GetEnumerator" />
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Adds a node to the set.
        /// </summary>
        /// <remarks>
        /// The NodeId must reference the strings for the node set.
        /// </remarks>
        public void Add(Node node)
        {
            if (node == null) throw new ArgumentNullException("node");

            if (NodeId.IsNull(node.NodeId))
            {
                throw new ArgumentException("A non-null NodeId must be specified.");
            }
            
            if (m_nodes.ContainsKey(node.NodeId.Identifier))
            {
                throw new ArgumentException(String.Format("NodeID {0} already exists for node: {1}", node.NodeId, node));
            }

            m_nodes.Add(node.NodeId.Identifier, node);
        }
        
        /// <summary>
        /// Translates a reference and adds it to the specified node.
        /// </summary>
        public void AddReference(Node node, ReferenceNode referenceToExport, NamespaceTable namespaceUris, StringTable serverUris)
        {
            ReferenceNode reference = new ReferenceNode();

            reference.ReferenceTypeId = referenceToExport.ReferenceTypeId;
            reference.IsInverse = referenceToExport.IsInverse;
            reference.TargetId = referenceToExport.TargetId; 

            node.References.Add(reference);
        }

        /// <summary>
        /// Removes a node from the set.
        /// </summary>
        /// <remarks>
        /// The NodeId must reference the strings for the node set.
        /// </remarks>
        public bool Remove(NodeId nodeId)
        {
            if (!NodeId.IsNull(nodeId))
            {
                return m_nodes.Remove(nodeId.Identifier);
            }

            return false;
        }        
        
        /// <summary>
        /// Returns true if the node exists in the nodeset.
        /// </summary>
        /// <remarks>
        /// The NodeId must reference the strings for the node set.
        /// </remarks>
        public bool Contains(NodeId nodeId)
        {
            if (!NodeId.IsNull(nodeId))
            {
                return m_nodes.ContainsKey(nodeId.Identifier);
            }

            return false;
        }
        
        /// <summary>
        /// Returns the node in the set.
        /// </summary>
        public Node Find(NodeId nodeId)
        {
            if (NodeId.IsNull(nodeId))
            {
                return null;
            }

            Node node = null;

            if (m_nodes.TryGetValue(nodeId.Identifier, out node))
            {
                return node;
            }

            return null;
        }

        /// <summary>
        /// Returns the node in the set.
        /// </summary>
        public Node Find(ExpandedNodeId nodeId)
        {
            if (NodeId.IsNull(nodeId))
            {
                return null;
            }

            Node node = null;

            if (m_nodes.TryGetValue(nodeId.Identifier, out node))
            {
                return node;
            }

            return null;
        }
        #endregion

        #region Private Members
        /// <summary>
		/// The table of namespaces.
		/// </summary>
		[DataMember(Name = "NamespaceUris", Order = 1)]
        internal ListOfString NamespaceUris
        {
            get 
            {
                ListOfString array = new ListOfString();
                array.AddRange(m_namespaceUris.ToArray());
                return array;
            }
            
            set
            {
                if (value == null)
                {
                    m_namespaceUris = new NamespaceTable();
                }
                else
                {
                    m_namespaceUris = new NamespaceTable(value);
                }
            }
        }
        
		/// <summary>
		/// The table of servers.
		/// </summary>
		[DataMember(Name = "ServerUris", Order = 2)]
        internal ListOfString ServerUris
        {
            get
            {
                ListOfString array = new ListOfString();
                array.AddRange(m_serverUris.ToArray());
                return array;
            }
            
            set
            {
                if (value == null)
                {
                    m_serverUris = new StringTable();
                }
                else
                {
                    m_serverUris = new StringTable(value);
                }
            }
        }
        
		/// <summary>
		/// The table of nodes.
		/// </summary>
		[DataMember(Name = "Nodes", Order = 3)]
        internal ListOfNode Nodes
        {
            get 
            {
                ListOfNode value = new ListOfNode();
                value.AddRange(m_nodes.Values);
                return value;
            }
            
            set
            {
                m_nodes = new Dictionary<string,Node>();

                if (value != null)
                {
                    foreach (Node node in value)
                    {
                        if (!NodeId.IsNull(node.NodeId))
                        {
                            m_nodes[node.NodeId.Identifier] = node;
                        }
                    }
                }
            }
        }
        #endregion
        
        #region Private Fields
        private NamespaceTable m_namespaceUris;
        private StringTable m_serverUris;
        private Dictionary<string,Node> m_nodes;
        #endregion
    }
}
