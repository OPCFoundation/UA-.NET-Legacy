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
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Opc.Ua;

namespace DsatsDemo.DataSource
{    
    /// <summary>
    /// The data sources for a DSATS server.
    /// </summary>
    public partial class DataSource
    {
        #region Constructors
        /// <summary>
        /// Creates an empty datasource.
        /// </summary>
        public DataSource()
        {
        }
        
        /// <summary>
        /// Loads a datasource from a stream.
        /// </summary>
        /// <param name="istrm">The input stream.</param>
        /// <returns>The datasources</returns>
        public static DataSource Read(Stream istrm)
        {
            XmlTextReader reader = new XmlTextReader(istrm);
            
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(DataSource));
                return serializer.Deserialize(reader) as DataSource;
            }
            finally
            {
                reader.Close();
            }
        }
        
        /// <summary>
        /// Write a datasource to a stream.
        /// </summary>
        /// <param name="istrm">The input stream.</param>
        public void Write(Stream istrm)
        {
            XmlTextWriter writer = new XmlTextWriter(istrm, Encoding.UTF8);
            writer.Formatting = Formatting.Indented;

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(DataSource));
                serializer.Serialize(writer, this);
            }
            finally
            {
                writer.Close();
            }
        }

        /// <summary>
        /// Reads the value of a Variant.
        /// </summary>
        public Variant Read(ISystemContext context, XmlElement element)
        {
            XmlDecoder decoder = CreateDecoder(context, element);
            TypeInfo typeInfo = null;
            object value = decoder.ReadVariantContents(out typeInfo);
            decoder.Close();
            return new Variant(value, typeInfo);
        }

        /// <summary>
        /// Reads a NodeId
        /// </summary>
        public Opc.Ua.NodeId ReadNodeId(ISystemContext context, string source)
        {
            if (String.IsNullOrEmpty(source))
            {
                return Opc.Ua.NodeId.Null;
            }

            return ImportNodeId(source, context.NamespaceUris, false);
        }

        /// <summary>
        /// Reads an ExpandedNodeId
        /// </summary>
        public Opc.Ua.ExpandedNodeId ReadExpandedNodeId(ISystemContext context, string source)
        {
            if (String.IsNullOrEmpty(source))
            {
                return Opc.Ua.ExpandedNodeId.Null;
            }

            return ImportExpandedNodeId(source, context.NamespaceUris, context.ServerUris);
        }

        /// <summary>
        /// Reads a phase object.
        /// </summary>
        public PhaseState ReadPhase(ISystemContext context, BaseObject source)
        {
            ushort namespaceIndex = (ushort)context.NamespaceUris.GetIndex(DsatsDemo.Namespaces.DsatsDemo);

            PhaseState node = new PhaseState(null);

            node.Create(
                context,
                new NodeId("Phases/" + source.BrowseName, namespaceIndex), 
                new QualifiedName(source.BrowseName, namespaceIndex),
                null,
                true);

            if (source.DisplayName != null && source.DisplayName.Length > 0)
            {
                node.DisplayName = Import(source.DisplayName);
            }

            if (source.Description != null && source.Description.Length > 0)
            {
                node.Description = Import(source.Description);
            }

            return node;
        }

        /// <summary>
        /// Reads a lock object.
        /// </summary>
        public LockConditionState ReadLock(ISystemContext context, BaseObject source)
        {
            ushort namespaceIndex = (ushort)context.NamespaceUris.GetIndex(DsatsDemo.Namespaces.DsatsDemo);

            LockConditionState node = new LockConditionState(null);

            node.Create(
                context,
                new NodeId("Locks/" + source.BrowseName, namespaceIndex),
                new QualifiedName(source.BrowseName, namespaceIndex),
                null,
                true);

            if (source.DisplayName != null && source.DisplayName.Length > 0)
            {
                node.DisplayName = Import(source.DisplayName);
            }

            if (source.Description != null && source.Description.Length > 0)
            {
                node.Description = Import(source.Description);
            }

            node.SetEnableState(context, true);
            node.Unlock(context);

            node.ConditionName.Value = source.BrowseName;
            node.EventId.Value = Guid.NewGuid().ToByteArray();
            node.EventType.Value = node.TypeDefinitionId;
            node.SourceName.Value = BrowseNames.Rig;
            node.SourceNode.Value = new NodeId(Objects.Rig, namespaceIndex);
            node.Severity.Value = 100;
            node.Time.Value = DateTime.UtcNow;
            node.ReceiveTime.Value = DateTime.UtcNow;
            node.ConditionClassId.Value = Opc.Ua.ObjectTypeIds.BaseConditionClassType;
            node.ConditionClassName.Value = Opc.Ua.BrowseNames.BaseConditionClassType;
            node.Retain.Value = true;
            
            TranslationInfo state = new TranslationInfo(
                "LockConditionStateMessage",
                "en-US",
                "Lock object is now in the '{0}' state.",
                node.LockState.CurrentState);

            node.Message.Value = new Opc.Ua.LocalizedText(state);

            return node;
        }
        #endregion

        #region Private Methods
        /// <summary>
        ///  Imports a NodeId
        /// </summary>
        private Opc.Ua.NodeId ImportNodeId(string source, NamespaceTable namespaceUris, bool lookupAlias)
        {
            if (String.IsNullOrEmpty(source))
            {
                return Opc.Ua.NodeId.Null;
            }

            // parse the string.
            Opc.Ua.NodeId nodeId = Opc.Ua.NodeId.Parse(source);

            if (nodeId.NamespaceIndex > 0)
            {
                ushort namespaceIndex = ImportNamespaceIndex(nodeId.NamespaceIndex, namespaceUris);
                nodeId = new Opc.Ua.NodeId(nodeId.Identifier, namespaceIndex);
            }

            return nodeId;
        }

        /// <summary>
        /// Imports a ExpandedNodeId
        /// </summary>
        private Opc.Ua.ExpandedNodeId ImportExpandedNodeId(string source, NamespaceTable namespaceUris, StringTable serverUris)
        {
            if (String.IsNullOrEmpty(source))
            {
                return Opc.Ua.ExpandedNodeId.Null;
            }

            // parse the node.
            Opc.Ua.ExpandedNodeId nodeId = Opc.Ua.ExpandedNodeId.Parse(source);

            if (nodeId.ServerIndex <= 0 && nodeId.NamespaceIndex <= 0 && String.IsNullOrEmpty(nodeId.NamespaceUri))
            {
                return nodeId;
            }

            uint serverIndex = ImportServerIndex(nodeId.ServerIndex, serverUris);
            ushort namespaceIndex = ImportNamespaceIndex(nodeId.NamespaceIndex, namespaceUris);

            if (serverIndex > 0)
            {
                string namespaceUri = nodeId.NamespaceUri;

                if (String.IsNullOrEmpty(nodeId.NamespaceUri))
                {
                    namespaceUri = namespaceUris.GetString(namespaceIndex);
                }

                nodeId = new Opc.Ua.ExpandedNodeId(nodeId.Identifier, 0, namespaceUri, serverIndex);
                return nodeId;
            }


            nodeId = new Opc.Ua.ExpandedNodeId(nodeId.Identifier, namespaceIndex, null, 0);
            return nodeId;
        }

        /// <summary>
        /// Imports a QualifiedName
        /// </summary>
        private Opc.Ua.QualifiedName ImportQualifiedName(string source, NamespaceTable namespaceUris)
        {
            if (String.IsNullOrEmpty(source))
            {
                return Opc.Ua.QualifiedName.Null;
            }

            Opc.Ua.QualifiedName qname = Opc.Ua.QualifiedName.Parse(source);

            if (qname.NamespaceIndex > 0)
            {
                ushort namespaceIndex = ImportNamespaceIndex(qname.NamespaceIndex, namespaceUris);
                qname = new Opc.Ua.QualifiedName(qname.Name, namespaceIndex);
            }

            return qname;
        }

        /// <summary>
        /// Imports localized text.
        /// </summary>
        private Opc.Ua.LocalizedText Import(params LocalizedText[] input)
        {
            if (input == null)
            {
                return null;
            }

            for (int ii = 0; ii < input.Length; ii++)
            {
                if (input[ii] != null)
                {
                    return new Opc.Ua.LocalizedText(input[ii].Locale, input[ii].Value);
                }
            }

            return null;
        }

        /// <summary>
        /// Imports the array dimensions.
        /// </summary>
        private uint[] ImportArrayDimensions(string arrayDimensions)
        {
            if (String.IsNullOrEmpty(arrayDimensions))
            {
                return null;
            }

            string[] fields = arrayDimensions.Split(',');
            uint[] dimensions = new uint[fields.Length];

            for (int ii = 0; ii < fields.Length; ii++)
            {
                try
                {
                    dimensions[ii] = Convert.ToUInt32(fields[ii]);
                }
                catch
                {
                    dimensions[ii] = 0;
                }
            }

            return dimensions;
        }

        /// <summary>
        /// Exports a namespace index.
        /// </summary>
        private ushort ImportNamespaceIndex(ushort namespaceIndex, NamespaceTable namespaceUris)
        {
            // nothing special required for indexes 0 and 1.
            if (namespaceIndex < 1)
            {
                return namespaceIndex;
            }

            // return a bad value if parameters are bad.
            if (namespaceUris == null || this.NamespaceUris == null || this.NamespaceUris.Length <= namespaceIndex - 1)
            {
                return UInt16.MaxValue;
            }

            // find or append uri.
            return namespaceUris.GetIndexOrAppend(this.NamespaceUris[namespaceIndex - 1]);
        }

        /// <summary>
        /// Exports a server index.
        /// </summary>
        private uint ImportServerIndex(uint serverIndex, StringTable serverUris)
        {
            // nothing special required for indexes 0.
            if (serverIndex <= 0)
            {
                return serverIndex;
            }

            // return a bad value if parameters are bad.
            if (serverUris == null || this.ServerUris == null || this.ServerUris.Length <= serverIndex - 1)
            {
                return UInt16.MaxValue;
            }

            // find or append uri.
            return serverUris.GetIndexOrAppend(this.ServerUris[serverIndex - 1]);
        }

        /// <summary>
        /// Creates an decoder to restore Variant values.
        /// </summary>
        private XmlDecoder CreateDecoder(ISystemContext context, XmlElement source)
        {
            ServiceMessageContext messageContext = new ServiceMessageContext();
            messageContext.NamespaceUris = context.NamespaceUris;
            messageContext.ServerUris = context.ServerUris;
            messageContext.Factory = context.EncodeableFactory;

            XmlDecoder decoder = new XmlDecoder(source, messageContext);

            NamespaceTable namespaceUris = new NamespaceTable();

            if (NamespaceUris != null)
            {
                for (int ii = 0; ii < NamespaceUris.Length; ii++)
                {
                    namespaceUris.Append(NamespaceUris[ii]);
                }
            }

            StringTable serverUris = new StringTable();

            if (ServerUris != null)
            {
                serverUris.Append(context.ServerUris.GetString(0));

                for (int ii = 0; ii < ServerUris.Length; ii++)
                {
                    serverUris.Append(ServerUris[ii]);
                }
            }

            decoder.SetMappingTables(namespaceUris, serverUris);

            return decoder;
        }
        #endregion
    }
}
