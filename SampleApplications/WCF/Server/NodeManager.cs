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
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;

namespace Opc.Ua.Sample
{
    /// <summary>
    /// Manages the address space for the server.
    /// </summary>
    class NodeManager
    {
        #region Initialization
        /// <summary>
        /// Creates the default address space.
        /// </summary>
        public void Create()
        {
            lock (m_lock)
            {
                // the information model defined by the specification is stored in an XML file that is embedded in the Common library.
                // this model can be used to create a static but browseable address space. Dynamic behavoir can be added as required.
                // For example, the ServerObject class provides live data for the nodes in the Server object tree.

                Stream istrm = Assembly.GetAssembly(typeof(NodeId)).GetManifestResourceStream("Opc.Ua.Sample.Generated.Opc.Ua.NodeSet.xml");

                if (istrm != null)
                {
                    try
                    {
                        DataContractSerializer serializer = new DataContractSerializer(typeof(NodeSet));
                        m_nodes = (NodeSet)serializer.ReadObject(istrm);

                        // the node file does not store the inverse references. add them in manually to ensure two-way browsing.
                        foreach (Node node in m_nodes)
                        {
                            if (node.References == null)
                            {
                                continue;
                            }

                            foreach (ReferenceNode reference in node.References)
                            {
                                AddInverseReference(node.NodeId, reference);
                            }
                        }
                    }
                    finally
                    {
                        istrm.Close();
                    }
                }
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Saves the callback use to read the value of a node.
        /// </summary>
        /// <remarks>
        /// Other components use this to specify themselves as sources for the specifed node.
        /// </remarks>
        public void SetReadValueCallback(NodeId nodeId, ReadValueEventHandler callback)
        {
            m_callbacks[nodeId.Identifier] = callback;
        }

        /// <summary>
        /// Browses the references for the specified node.
        /// </summary>
        public void Browse(
            BrowseDescription request,
            BrowseResult result,
            DiagnosticInfo diagnosticInfo)
        {
            lock (m_lock)
            {
                // find the starting nodes.
                Node source = m_nodes.Find(request.NodeId);

                if (source == null)
                {
                    result.StatusCode = new StatusCode(StatusCodes.BadNodeIdUnknown);
                    return;
                }

                result.References = new ListOfReferenceDescription();

                // return all of the references that meet the filter criteria.
                foreach (ReferenceNode reference in source.References)
                {
                    if (reference.IsInverse && request.BrowseDirection == BrowseDirection.Forward_0)
                    {
                        continue;
                    }

                    if (!reference.IsInverse && request.BrowseDirection == BrowseDirection.Inverse_1)
                    {
                        continue;
                    }

                    // the reference type filter can be an exact match or it can be for any subtype.
                    if (reference.ReferenceTypeId != request.ReferenceTypeId)
                    {
                        if (!request.IncludeSubtypes)
                        {
                            continue;
                        }

                        if (!IsTypeOf(reference.ReferenceTypeId, request.ReferenceTypeId))
                        {
                            continue;
                        }
                    }

                    // need to look up the target to find the attributes.
                    // note that the result filter mask is being ignored. production servers only need to 
                    // look up the attributes requested by the client.
                    Node target = m_nodes.Find(reference.TargetId);

                    if (target != null)
                    {
                        ReferenceDescription description = new ReferenceDescription();

                        description.NodeId = reference.TargetId;
                        description.IsForward = !reference.IsInverse;
                        description.ReferenceTypeId = reference.ReferenceTypeId;
                        description.BrowseName = target.BrowseName;
                        description.DisplayName = target.DisplayName;
                        description.NodeClass = target.NodeClass;
                        description.TypeDefinition = GetTypeDefinition(target);

                        result.References.Add(description);
                    }
                }
            }
        }

        /// <summary>
        /// Follows the browse path and returns any targets found.
        /// </summary>
        public void TranslateBrowsePath(
            BrowsePath request,
            BrowsePathResult result,
            DiagnosticInfo diagnosticInfo)
        {
            lock (m_lock)
            {
                // find the starting node.
                Node source = m_nodes.Find(request.StartingNode);

                if (source == null)
                {
                    result.StatusCode = new StatusCode(StatusCodes.BadNodeIdUnknown);
                    return;
                }

                // check if there is nothing to do.
                if (request.RelativePath.Elements == null || request.RelativePath.Elements.Count == 0)
                {
                    result.StatusCode = new StatusCode(StatusCodes.BadNothingToDo);
                    return;
                }

                result.Targets = new ListOfBrowsePathTarget();
                
                Node current = source;

                // follow each element in the browse path.
                for (int ii = 0; ii < request.RelativePath.Elements.Count; ii++)
                {
                    RelativePathElement element = request.RelativePath.Elements[ii];

                    bool found = false;

                    // need to find any matching reference.
                    foreach (ReferenceNode reference in current.References)
                    {                        
                        // inverse is a quick check - do that first.
                        if (reference.IsInverse != element.IsInverse)
                        {
                            continue;
                        }

                        // check for reference type matches.
                        if (reference.ReferenceTypeId != element.ReferenceTypeId)
                        {
                            if (!element.IncludeSubtypes)
                            {
                                continue;
                            }

                            if (!IsTypeOf(reference.ReferenceTypeId, element.ReferenceTypeId))
                            {
                                continue;
                            }
                        }

                        // The UA type model requires that the browse names of all targets of hierarchial references
                        // be unique within a parent. This means most browse paths will point to no more than one node.
                        // However, instances are allowed to add additional nodes with duplicate browse names. If the server
                        // allows this it must keep track of the child that matches the type model and return it as the
                        // first target. 

                        // need to find the target to check the browse name.
                        Node target = m_nodes.Find(reference.TargetId);

                        if (target != null)
                        {
                            if (element.TargetName == target.BrowseName)
                            {
                                found = true;
                                current = target;
                                break;
                            }
                        }
                    }

                    if (found)
                    {
                        // check if the complete path has been followed.
                        if (ii == request.RelativePath.Elements.Count - 1)
                        {
                            BrowsePathTarget item = new BrowsePathTarget();
                            item.TargetId = new ExpandedNodeId(current.NodeId);
                            item.RemainingPathIndex = UInt32.MaxValue;
                            result.Targets.Add(item);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Returns the value of an attribute.
        /// </summary>
        public void Read(
            ReadValueId request,
            DataValue result,
            DiagnosticInfo diagnosticInfo)
        {
            lock (m_lock)
            {
                // find the node to read.
                Node source = m_nodes.Find(request.NodeId);

                result.ServerTimestamp = DateTime.UtcNow;

                if (source == null)
                {
                    result.StatusCode = new StatusCode(StatusCodes.BadNodeIdUnknown);
                    return;
                }

                result.Value = Variant.Null;

                // switch on the attribute value.
                switch (request.AttributeId)
                {
                    case Attributes.NodeId:
                    {
                        result.Value = new Variant(source.NodeId);
                        break;
                    }

                    case Attributes.NodeClass:
                    {
                        result.Value = new Variant(DataTypes.EnumToMask(source.NodeClass));
                        break;
                    }

                    case Attributes.BrowseName:
                    {
                        result.Value = new Variant(source.BrowseName);
                        break;
                    }

                    case Attributes.DisplayName:
                    {
                        result.Value = new Variant(source.DisplayName);
                        break;
                    }

                    case Attributes.Description:
                    {
                        result.Value = new Variant(source.Description);
                        break;
                    }

                    case Attributes.WriteMask:
                    {
                        result.Value = new Variant(source.WriteMask);
                        break;
                    }

                    case Attributes.UserWriteMask:
                    {
                        result.Value = new Variant(source.UserWriteMask);
                        break;
                    }

                    case Attributes.Value:
                    {
                        // check if another component has installed a read callback.
                        ReadValueEventHandler callback = null;

                        if (m_callbacks.TryGetValue(source.NodeId.Identifier, out callback))
                        {
                            result.Value = new Variant(callback());
                            break;
                        }

                        // use the value cached in the node otherwise.
                        VariableNode variable = source as VariableNode;

                        if (variable != null)
                        {
                            result.Value = variable.Value;
                            result.SourceTimestamp = DateTime.UtcNow; // The Value attribute requires a SourceTimestamp.
                            break;
                        }

                        VariableTypeNode variableType = source as VariableTypeNode;

                        if (variableType != null)
                        {
                            result.Value = variableType.Value;
                            result.SourceTimestamp = DateTime.UtcNow; // The Value attribute requires a SourceTimestamp.
                            break;
                        }

                        result.StatusCode = new StatusCode(StatusCodes.BadAttributeIdInvalid);
                        break;
                    }

                    case Attributes.DataType:
                    {
                        VariableNode variable = source as VariableNode;

                        if (variable != null)
                        {
                            result.Value = new Variant(variable.DataType);
                            break;
                        }

                        VariableTypeNode variableType = source as VariableTypeNode;

                        if (variableType != null)
                        {
                            result.Value = new Variant(variableType.DataType);
                            break;
                        }

                        result.StatusCode = new StatusCode(StatusCodes.BadAttributeIdInvalid);
                        break;
                    }

                    case Attributes.ValueRank:
                    {
                        VariableNode variable = source as VariableNode;

                        if (variable != null)
                        {
                            result.Value = new Variant(variable.ValueRank);
                            break;
                        }

                        VariableTypeNode variableType = source as VariableTypeNode;

                        if (variableType != null)
                        {
                            result.Value = new Variant(variableType.ValueRank);
                            break;
                        }

                        result.StatusCode = new StatusCode(StatusCodes.BadAttributeIdInvalid);
                        break;
                    }

                    case Attributes.MinimumSamplingInterval:
                    {
                        VariableNode variable = source as VariableNode;

                        if (variable != null)
                        {
                            result.Value = new Variant(variable.MinimumSamplingInterval);
                            break;
                        }

                        result.StatusCode = new StatusCode(StatusCodes.BadAttributeIdInvalid);
                        break;
                    }
                        
                    case Attributes.Historizing:
                    {
                        VariableNode variable = source as VariableNode;

                        if (variable != null)
                        {
                            result.Value = new Variant(variable.Historizing);
                            break;
                        }

                        result.StatusCode = new StatusCode(StatusCodes.BadAttributeIdInvalid);
                        break;
                    }

                    case Attributes.AccessLevel:
                    {
                        VariableNode variable = source as VariableNode;

                        if (variable != null)
                        {
                            result.Value = new Variant(variable.AccessLevel);
                            break;
                        }

                        result.StatusCode = new StatusCode(StatusCodes.BadAttributeIdInvalid);
                        break;
                    }

                    case Attributes.UserAccessLevel:
                    {
                        VariableNode variable = source as VariableNode;

                        if (variable != null)
                        {
                            result.Value = new Variant(variable.UserAccessLevel);
                            break;
                        }

                        result.StatusCode = new StatusCode(StatusCodes.BadAttributeIdInvalid);
                        break;
                    }

                    case Attributes.EventNotifier:
                    {
                        ObjectNode objectn = source as ObjectNode;

                        if (objectn != null)
                        {
                            result.Value = new Variant(objectn.EventNotifier);
                            break;
                        }

                        ViewNode view = source as ViewNode;

                        if (view != null)
                        {
                            result.Value = new Variant(view.EventNotifier);
                            break;
                        }

                        result.StatusCode = new StatusCode(StatusCodes.BadAttributeIdInvalid);
                        break;
                    }

                    case Attributes.Executable:
                    {
                        MethodNode method = source as MethodNode;

                        if (method != null)
                        {
                            result.Value = new Variant(method.Executable);
                            break;
                        }

                        result.StatusCode = new StatusCode(StatusCodes.BadAttributeIdInvalid);
                        break;
                    }

                    case Attributes.UserExecutable:
                    {
                        MethodNode method = source as MethodNode;

                        if (method != null)
                        {
                            result.Value = new Variant(method.UserExecutable);
                            break;
                        }

                        result.StatusCode = new StatusCode(StatusCodes.BadAttributeIdInvalid);
                        break;
                    }

                    case Attributes.ContainsNoLoops:
                    {
                        ViewNode view = source as ViewNode;

                        if (view != null)
                        {
                            result.Value = new Variant(view.ContainsNoLoops);
                            break;
                        }

                        result.StatusCode = new StatusCode(StatusCodes.BadAttributeIdInvalid);
                        break;
                    }

                    case Attributes.InverseName:
                    {
                        ReferenceTypeNode referenceType = source as ReferenceTypeNode;

                        if (referenceType != null)
                        {
                            result.Value = new Variant(referenceType.InverseName);
                            break;
                        }

                        result.StatusCode = new StatusCode(StatusCodes.BadAttributeIdInvalid);
                        break;
                    }

                    case Attributes.IsAbstract:
                    {
                        DataTypeNode dataType = source as DataTypeNode;

                        if (dataType != null)
                        {
                            result.Value = new Variant(dataType.IsAbstract);
                            break;
                        }

                        ReferenceTypeNode referenceType = source as ReferenceTypeNode;

                        if (referenceType != null)
                        {
                            result.Value = new Variant(referenceType.IsAbstract);
                            break;
                        }

                        ObjectTypeNode objectType = source as ObjectTypeNode;

                        if (objectType != null)
                        {
                            result.Value = new Variant(objectType.IsAbstract);
                            break;
                        }

                        VariableTypeNode variableType = source as VariableTypeNode;

                        if (variableType != null)
                        {
                            result.Value = new Variant(variableType.IsAbstract);
                            break;
                        }

                        result.StatusCode = new StatusCode(StatusCodes.BadAttributeIdInvalid);
                        break;
                    }

                    case Attributes.Symmetric:
                    {
                        ReferenceTypeNode referenceType = source as ReferenceTypeNode;

                        if (referenceType != null)
                        {
                            result.Value = new Variant(referenceType.Symmetric);
                            break;
                        }

                        result.StatusCode = new StatusCode(StatusCodes.BadAttributeIdInvalid);
                        break;
                    }

                    default:
                    {
                        result.StatusCode = new StatusCode(StatusCodes.BadAttributeIdInvalid);
                        break;
                    }
                }
            }
        }
        #endregion

        #region Helper Functions
        /// <summary>
        /// Checks if the type is subtype of the supertype.
        /// </summary>
        private bool IsTypeOf(NodeId subtytpe, NodeId supertype)
        {
            return IsTypeOf(new ExpandedNodeId(subtytpe), new ExpandedNodeId(supertype));
        }

        /// <summary>
        /// Checks if the type is subtype of the supertype.
        /// </summary>
        private bool IsTypeOf(ExpandedNodeId subtytpe, ExpandedNodeId supertype)
        {
            ExpandedNodeId typeId = subtytpe;

            do
            {
                if (typeId == supertype)
                {
                    return true;
                }

                Node source = m_nodes.Find(typeId);

                if (source == null)
                {
                    return false;
                }

                typeId = GetSuperType(source);
            }
            while (typeId != null);
            
            return false;
        }

        /// <summary>
        /// Returns the supertype for the node.
        /// </summary>
        private ExpandedNodeId GetSuperType(Node node)
        {
            if (node == null || node.References == null)
            {
                return null;
            }

            NodeId targetId = new NodeId(ReferenceTypes.HasSubtype);

            foreach (ReferenceNode reference in node.References)
            {
                if (reference.IsInverse && reference.ReferenceTypeId == targetId)
                {
                    return reference.TargetId;
                }
            }

            return null;
        }

        /// <summary>
        /// Returns the type definition for the node.
        /// </summary>
        private ExpandedNodeId GetTypeDefinition(Node node)
        {
            if (node == null || node.References != null)
            {
                return null;
            }

            NodeId targetId = new NodeId(ReferenceTypes.HasTypeDefinition);

            foreach (ReferenceNode reference in node.References)
            {
                if (!reference.IsInverse && reference.ReferenceTypeId == targetId)
                {
                    return reference.TargetId;
                }
            }

            return null;
        }

        /// <summary>
        /// Adds the inverse reference to the table.
        /// </summary>
        private void AddInverseReference(NodeId sourceId, ReferenceNode reference)
        {
            Node target = m_nodes.Find(reference.TargetId);

            if (target != null && target.References != null)
            {
                foreach (ReferenceNode reference2 in target.References)
                {
                    if (reference2.IsInverse == !reference.IsInverse)
                    {
                        if (reference2.ReferenceTypeId == reference.ReferenceTypeId)
                        {
                            if (reference2.TargetId == sourceId)
                            {
                                return;
                            }
                        }
                    }
                }
            }

            if (target.References == null)
            {
                target.References = new ListOfReferenceNode();
            }

            ReferenceNode copy = new ReferenceNode();

            copy.IsInverse = !reference.IsInverse;
            copy.ReferenceTypeId = reference.ReferenceTypeId;
            copy.TargetId = new ExpandedNodeId(sourceId);

            target.References.Add(copy);
        }
        #endregion

        #region Private Fields
        private object m_lock = new object();
        private NodeSet m_nodes;
        private Dictionary<string, ReadValueEventHandler> m_callbacks = new Dictionary<string, ReadValueEventHandler>();
        #endregion
    }

    /// <summary>
    /// Used to read the value of a node from another component.
    /// </summary>
    public delegate object ReadValueEventHandler();
}
