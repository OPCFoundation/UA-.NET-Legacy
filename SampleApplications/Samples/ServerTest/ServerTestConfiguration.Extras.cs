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
using System.Configuration;
using System.Runtime.Serialization;
using System.Xml;
using System.Reflection;
using System.IO;
using Opc.Ua.Client;

namespace Opc.Ua.ServerTest
{
	/// <summary>
	/// A class that holds the configuration for a UA service.
	/// </summary>
	public partial class ServerTestConfiguration
	{        
		#region Public Properties
        /// <summary>
        /// The path used to load the configuration.
        /// </summary>
        public string FilePath
        {
            get { return m_filePath; }
        }

        /// <summary>
        /// Whether the test should be run continously.
        /// </summary>
        public bool Continuous
        {
            get { return m_continuous; }
            set { m_continuous = value; }
        }
		#endregion

		#region Static Members
        /// <summary>
        ///  Loads the configuration from a file on disk.
        /// </summary>
        public static ServerTestConfiguration Load(string filePath, ServerTestConfiguration masterConfiguration)
        {
		    XmlTextReader reader = new XmlTextReader(filePath);

            try
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(ServerTestConfiguration));
                ServerTestConfiguration configuration = serializer.ReadObject(reader) as ServerTestConfiguration;
                configuration.m_filePath = filePath;

                if (configuration.Iterations <= 0)
                {
                    configuration.Iterations = 1;
                }

                if (masterConfiguration != null)
                {
                    ListOfServerTestCase replacements = new ListOfServerTestCase();

                    for (int ii = 0; ii < masterConfiguration.TestCases.Count; ii++)
                    {
                        ServerTestCase template = masterConfiguration.TestCases[ii];
                        
                        // create replacement that is disabled by default.
                        ServerTestCase replacement = new ServerTestCase();

                        replacement.Name = template.Name;
                        replacement.Parent = template.Parent;
                        replacement.Enabled = false;
                        replacement.Breakpoint = false;

                        replacements.Add(replacement);

                        // load settings from saved test case.
                        for (int jj = 0; jj < configuration.TestCases.Count; jj++)
                        {
                            ServerTestCase actual = configuration.TestCases[jj];

                            if (actual.Name == template.Name && actual.Parent == template.Parent)
                            {
                                replacement.Enabled = actual.Enabled;
                                replacement.Breakpoint = actual.Breakpoint;
                                break;
                            }
                        }
                    }

                    // replace the test cases.
                    configuration.TestCases = replacements;
                }

                return configuration;
            }
            finally
            {
                reader.Close();
            }
        }

        /// <summary>
        ///  Saves the configuration to a file on disk.
        /// </summary>
        public void Save(string filePath)
        {
            if (String.IsNullOrEmpty(filePath))
            {
                filePath = m_filePath;
            }

		    XmlTextWriter writer = new XmlTextWriter(filePath, System.Text.Encoding.UTF8);

            try
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(ServerTestConfiguration));
                serializer.WriteObject(writer, this);
                m_filePath = filePath;
            }
            finally
            {
                writer.Close();
            }
        }

        /// <summary>
        ///  Loads the configuration from the application configuration file.
        /// </summary>
        public static ServerTestConfiguration Load(XmlElementCollection extensions)
        {
            if (extensions == null || extensions.Count == 0)
            {
                return new ServerTestConfiguration();
            }

            foreach (XmlElement element in extensions)
            {
                if (element.NamespaceURI != "http://opcfoundation.org/UA/SDK/ServerTest/Configuration.xsd")
                {
                    continue;
                }

			    XmlNodeReader reader = new XmlNodeReader(element);

                try
                {
                    DataContractSerializer serializer = new DataContractSerializer(typeof(ServerTestConfiguration));
                    ServerTestConfiguration configuration = serializer.ReadObject(reader) as ServerTestConfiguration;
                    
                    if (configuration.Iterations <= 0)
                    {
                        configuration.Iterations = 1;
                    }

                    return configuration;
                }
                finally
                {
                    reader.Close();
                }
            }
                        
            return new ServerTestConfiguration();
        }
		#endregion

        /// <summary>
        /// Returns the node ids of the test nodes in the list.
        /// </summary>
        public List<NodeId> GetNodeList(IList<TestNode> nodes, NamespaceTable namespaceUris)
        {
            List<NodeId> nodeIds = new List<NodeId>();

            if (nodes != null)
            {
                for (int ii = 0; ii < nodes.Count; ii++)
                {
                    TestNode node = nodes[ii];

                    if (node == null || String.IsNullOrEmpty(node.Id))
                    {
                        continue;
                    }

                    try
                    {
                        NodeId nodeId = NodeId.Parse(node.Id);

                        // translate namespace index.
                        if (nodeId.NamespaceIndex > 1 && namespaceUris != null)
                        {
                            string uri = null;

                            if (NamespaceUris != null && NamespaceUris.Count >= nodeId.NamespaceIndex-2)
                            {
                                uri = NamespaceUris[nodeId.NamespaceIndex-2];
                            }

                            if (uri != null)
                            {
                                int index = namespaceUris.GetIndex(uri);

                                if (index >= 0)
                                {
                                    nodeId = new NodeId(nodeId.Identifier, (ushort)index);
                                }
                            }
                        }

                        nodeIds.Add(nodeId);
                    }
                    catch
                    {
                        // ignore parsing errors.
                    }
                }
            }

            return nodeIds;
        }
        
        /// <summary>
        /// Replaces the test nodes in the list.
        /// </summary>        
        public void ReplaceNodeList(IList<TestNode> nodes, IList<ILocalNode> newNodes, NamespaceTable namespaceUris)
        {
            nodes.Clear();

            if (newNodes == null)
            {
                return;
            }

            List<string> exportedUris = new List<string>();

            if (NamespaceUris != null)
            {
                exportedUris.AddRange(NamespaceUris);
            }
                
            for (int ii = 0; ii < newNodes.Count; ii++)
            {
                ILocalNode newNode = newNodes[ii];

                NodeId nodeId = newNode.NodeId;

                if (namespaceUris != null && nodeId.NamespaceIndex > 1)
                {
                    string uri = namespaceUris.GetString(nodeId.NamespaceIndex);
                    
                    if (uri != null)
                    {
                        bool found = false;

                        for (int jj = 0; jj < exportedUris.Count; ii++)
                        {
                            if (exportedUris[jj] == uri)
                            {
                                nodeId = new NodeId(nodeId.Identifier, (ushort)(jj+2));
                                found = true;
                                break;
                            }
                        }

                        if (!found)
                        {
                            exportedUris.Add(uri);
                            nodeId = new NodeId(nodeId.Identifier, (ushort)(exportedUris.Count+1));
                        }
                    }
                }

                TestNode testNode = new TestNode();

                testNode.Id = nodeId.ToString();
                testNode.Name = newNode.BrowseName.ToString();

                nodes.Add(testNode);
            }

            NamespaceUris = new ListOfString();
            NamespaceUris.AddRange(exportedUris);
        }

		#region Private Fields
        private string m_filePath;
        private bool m_continuous;
		#endregion
	}
}
