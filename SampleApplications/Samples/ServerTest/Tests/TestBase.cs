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

using Opc.Ua.Client;

namespace Opc.Ua.ServerTest
{    
    /// <summary>
    /// The base class for all tests.
    /// </summary>
    internal class TestBase
    {
        #region Constructors
        /// <summary>
        /// Initializes the test with session, configuration and logger.
        /// </summary>
        public TestBase(
            string name,
            Session session,
            ServerTestConfiguration configuration,
            ReportMessageEventHandler reportMessage,
            ReportProgressEventHandler reportProgress,
            TestBase template)
        {
            m_name = name;
            m_session = session;
            m_configuration = configuration;
            m_reportMessage = reportMessage;
            m_reportProgress = reportProgress;

            if (template != null && Object.ReferenceEquals(session, template.m_session))
            {
                m_blockSize = template.BlockSize;
                m_availableNodes = template.m_availableNodes;
                m_writeableVariables = template.m_writeableVariables;
            }
            else
            {
                m_blockSize = 1000;
                m_availableNodes = new NodeIdDictionary<Node>();
                m_writeableVariables = new List<VariableNode>();
            }
        }
        #endregion
        
        #region Public Members
        /// <summary>
        /// The name of the test case.
        /// </summary>
        public string Name
        {
            get { return m_name; }
        }

        /// <summary>
        /// The current iteration.
        /// </summary>
        public int Iteration
        {
            get { return m_iteration;  }
            protected set { m_iteration = value; }
        }

        /// <summary>
        /// The number of operations to include in a single request.
        /// </summary>
        protected int BlockSize
        {
            get { return m_blockSize;  }
            set { m_blockSize = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether tests which require writes must be skipped.
        /// </summary>
        /// <value><c>true</c> if tests which require writes must be skipped; otherwise, <c>false</c>.</value>
        public bool ReadOnlyTests
        {
            get { return m_readOnlyTests; }
            set { m_readOnlyTests = value; }
        }

        /// <summary>
        /// Runs the test case.
        /// </summary>
        public virtual bool Run(ServerTestCase testcase, int iteration)
        {
            return true;
        }
        #endregion

        #region Protected Members
        /// <summary>
        /// The session to use for the test.
        /// </summary>
        protected Session Session
        {
            get { return m_session; }
        }

        /// <summary>
        /// The configuration to use for the test.
        /// </summary>
        protected ServerTestConfiguration Configuration
        {
            get { return m_configuration; }
        }

        /// <summary>
        /// The nodes that can be used for testing.
        /// </summary>
        protected NodeIdDictionary<Node> AvailableNodes
        {
            get { return m_availableNodes; }
        }

        /// <summary>
        /// The writeable variables that can be used for testing.
        /// </summary>
        protected IList<VariableNode> WriteableVariables
        {
            get { return m_writeableVariables; }
        }
        
        /// <summary>
        /// Locks the server.
        /// </summary>
        protected void LockServer()
        {
            try
            {
                // ServerLock/Lock method was removed from 1.03 specs.
                // m_session.Call(ObjectIds.ServerLock, MethodIds.ServerLock_Lock);
                m_readOnlyTests = false;
                m_unlockRequired = true;
            }
            catch (Exception e)
            {
                ServiceResultException sre = e as ServiceResultException;

                if (sre != null)
                {
                    switch (sre.StatusCode)
                    {
                        case StatusCodes.BadNodeIdUnknown:
                        case StatusCodes.BadNodeIdInvalid:
                        case StatusCodes.BadMethodInvalid:
                        {
                            Log("WARNING: Server does not support locking. Errors could occur with multiple test clients.");
                            m_readOnlyTests = false;
                            return;
                        }
                    }
                }

                Log("WARNING: Could not acquire lock on Server. Tests which require writeable data are disabled.");
                m_readOnlyTests = true;
            }
        }

        /// <summary>
        /// Unlocks the server.
        /// </summary>
        protected void UnlockServer()
        {
            if (m_unlockRequired)
            {
                try
                {
                    // ServerLock/Unlock method was removed from 1.03 specs.
                    // m_session.Call(ObjectIds.ServerLock, MethodIds.ServerLock_Unlock);
                }
                catch (Exception)
                {
                    Log("WARNING: Could not release lock on Server.");
                }
            }

            m_readOnlyTests = true;
            m_unlockRequired = false;
        }

        /// <summary>
        /// Converts a percentage test converage to a modulus.
        /// </summary>
        private int CoverageToModulus(uint coverage)
        {
            if (coverage > 90) return 1;
            if (coverage > 80) return -10;
            if (coverage > 75) return -5;
            if (coverage > 66) return -4;
            if (coverage > 50) return -3;
            if (coverage > 33) return 2;
            if (coverage > 25) return 3;
            if (coverage > 20) return 4;
            if (coverage > 10) return 5;

            return 10;
        }

        /// <summary>
        /// Returns true if current node should be included in the test.
        /// </summary>
        protected bool CheckCoverage(ref int count)
        {
            count++;

            int modulus = CoverageToModulus(Configuration.Coverage);

            if (modulus > 1)
            {
                return (count+m_iteration-1)%modulus == 1;
            }

            if (modulus < 1)
            {
                return (count+m_iteration-1)%(-modulus) != 1;
            }
            
            return true;
        }

        /// <summary>
        /// Logs a message.
        /// </summary>
        protected void Log(string format, params object[] args)
        {
            if (m_reportMessage != null)
            {
                m_reportMessage(this, format, args);
            }
        }

        /// <summary>
        /// Logs a message.
        /// </summary>
        protected void Log(Exception e, string format, params object[] args)
        {
            if (m_reportMessage != null)
            {
                StringBuilder message = new StringBuilder();

                if (args != null && args.Length > 0)
                {
                    message.AppendFormat(format, args);
                }
                else
                {
                    message.Append(format);
                }

                message.Append("\r\n");

                ServiceResultException sre = e as ServiceResultException;

                if (sre != null)
                {
                    message.AppendFormat(
                        ">>> Exception: StatusCode = {0}, Message = {1}",
                        StatusCodes.GetBrowseName(sre.StatusCode), 
                        e.Message);
                }
                else
                {
                    message.AppendFormat(
                        ">>> Exception: Type = {0}, Message = {1}",
                        e.GetType().Name, 
                        e.Message);
                }

                m_reportMessage(this, message.ToString(), null);
            }
        }

        /// <summary>
        /// Reports progress.
        /// </summary>
        protected void ReportProgress(double position)
        {
            if (m_reportProgress != null)
            {
                m_reportProgress(this, position, MaxProgress);
            }
        }

        /// <summary>
        /// The maximum progress position.
        /// </summary>
        protected const double MaxProgress = 10000;
        
        /// <summary>
        /// Collects all of the nodes in the hierarchies specified in the configuration file.
        /// </summary>
        protected bool GetNodesInHierarchy()
        {
            // get list of starting nodes.
            IList<NodeId> nodesToBrowse = Configuration.GetNodeList(Configuration.BrowseRoots, this.Session.NamespaceUris);

            if (nodesToBrowse.Count == 0)
            {
                nodesToBrowse.Add(Objects.RootFolder);
            }

            // follow tree from each starting node.
            bool success = true;
                     
            double increment = MaxProgress/nodesToBrowse.Count;
            double position  = 0;

            for (int ii = 0; ii < nodesToBrowse.Count; ii++)
            {
                ILocalNode node = Session.NodeCache.Find(nodesToBrowse[ii]) as ILocalNode;

                if (node != null)
                {
                    Log("Browsing children of '{0}'. NodeId = {1}", node, node.NodeId);
                    
                    try
                    {
                        if (!Browse(Node.Copy(node), position, increment))
                        {
                            success = false;
                        }
                    }
                    catch (Exception e)
                    {
                        success = false;
                        Log(e, "HierarchicalBrowseTest Failed for Node '{0}'. NodeId = {1}", node, node.NodeId);
                    }
                }

                position += increment;
                ReportProgress(position);
            }

            Log("HierarchicalBrowseTest found {0} Nodes", m_availableNodes.Values.Count);
            return success;
        }

        /// <summary>
        /// Collects all of the nodes in the hierarchies specified in the configuration file.
        /// </summary>
        protected bool GetWriteableVariablesInHierarchy()
        {
            // use folders labelled 'Static' if no explicit list provided.
            bool findStaticFolders = false;
            IList<NodeId> writeableNodes = Configuration.GetNodeList(Configuration.WriteableVariables, this.Session.NamespaceUris);

            if (writeableNodes.Count == 0)
            {
                findStaticFolders = true;
            }

            // collection writeable variables that don't change during the test.
            m_writeableVariables.Clear();

            foreach (Node node in AvailableNodes.Values)
            {
                if (findStaticFolders && node.BrowseName.Name == "Static")
                {
                    Log("Browsing children of '{0}'. NodeId = {1}", node, node.NodeId);
                    CollectVariables(node, m_writeableVariables);
                    writeableNodes.Add(node.NodeId);
                }
                else
                {
                    for (int ii = 0; ii < writeableNodes.Count; ii++)
                    {
                        if (writeableNodes[ii] == node.NodeId)
                        {
                            Log("Browsing children of '{0}'. NodeId = {1}", node, node.NodeId);
                            CollectVariables(node, m_writeableVariables);
                        }
                    }
                }
            }

            Log("GetWriteableVariables found {0} Variables", m_writeableVariables.Count);
            return writeableNodes.Count > 0;
        }

        /// <summary>
        /// Recursively collects the child variables.
        /// </summary>
        private void CollectVariables(INode parent, List<VariableNode> variables)
        {
            VariableNode variable = parent as VariableNode;
            
            if (variable != null && ((variable.UserAccessLevel & AccessLevels.CurrentReadOrWrite) == AccessLevels.CurrentReadOrWrite))
            {
                bool found = false;

                for (int jj = 0; jj < variables.Count; jj++)
                {
                    if (Object.ReferenceEquals(variable, variables[jj]))
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    variables.Add(variable);
                }
            }

            IList<INode> children = Session.NodeCache.Find(
                parent.NodeId,
                ReferenceTypeIds.HierarchicalReferences,
                false,
                true);

            for (int ii = 0; ii < children.Count; ii++)
            {
                CollectVariables(children[ii], variables);
            }
        }

        /// <summary>
        /// Browses the node and returns the references found.
        /// </summary>
        protected virtual bool Browse(
            Node node,
            BrowseDescription nodeToBrowse, 
            ReferenceDescriptionCollection references)
        {            
            BrowseDescriptionCollection nodesToBrowse = new BrowseDescriptionCollection();
            nodesToBrowse.Add(nodeToBrowse);

            BrowseResultCollection results;
            DiagnosticInfoCollection diagnosticInfos;
            
            RequestHeader requestHeader = new RequestHeader();
            requestHeader.ReturnDiagnostics = 0;

            Session.Browse(
                requestHeader,
                new ViewDescription(),
                0,
                nodesToBrowse,
                out results,
                out diagnosticInfos);
            
            ClientBase.ValidateResponse(results, nodesToBrowse);
            ClientBase.ValidateDiagnosticInfos(diagnosticInfos, nodesToBrowse);
            
            // check diagnostics.
            if (diagnosticInfos != null && diagnosticInfos.Count > 0)
            {
                Log("Returned non-empty DiagnosticInfos array during Browse.");
                return false;
            }
            
            // process results.
            ByteStringCollection continuationPoints = new ByteStringCollection();

            for (int ii = 0; ii < results.Count; ii++)
            {
                // check status code.
                if (StatusCode.IsBad(results[ii].StatusCode))
                {
                    Log(
                        "Browse Failed for Node '{0}'. Status = {2}, NodeId = {1}", 
                        node, 
                        node.NodeId, 
                        results[ii].StatusCode);

                    return false;
                }
                
                // save references.
                references.AddRange(results[ii].References);

                if (results[ii].ContinuationPoint != null)
                {
                    continuationPoints.Add(results[ii].ContinuationPoint);
                }
            }
            
            // process continuation points.
            while (continuationPoints.Count > 0)
            {                       
                requestHeader = new RequestHeader();
                requestHeader.ReturnDiagnostics = 0;

                Session.BrowseNext(
                    requestHeader,
                    false,
                    continuationPoints,
                    out results,
                    out diagnosticInfos);
                
                ClientBase.ValidateResponse(results, continuationPoints);
                ClientBase.ValidateDiagnosticInfos(diagnosticInfos, continuationPoints);

                // check diagnostics.
                if (diagnosticInfos != null && diagnosticInfos.Count > 0)
                {
                    Log("Returned non-empty DiagnosticInfos array during BrowseNext.");
                    return false;
                }
                
                continuationPoints.Clear();

                // process results.
                for (int ii = 0; ii < results.Count; ii++)
                {
                    // check status code.
                    if (StatusCode.IsBad(results[ii].StatusCode))
                    {
                        Log(
                            "BrowseNext Failed for Node '{0}'. Status = {2}, NodeId = {1}", 
                            node, 
                            node.NodeId, 
                            results[ii].StatusCode);

                        return false;
                    }

                    // save references.
                    references.AddRange(results[ii].References);

                    if (results[ii].ContinuationPoint != null)
                    {
                        // check max references.
                        if (results[ii].References.Count == 0)
                        {
                            Log(
                                "No references returned with a continuation point for Node '{0}'. NodeId = {1}",
                                node, 
                                node.NodeId);
                           
                            return false;
                        }

                        continuationPoints.Add(results[ii].ContinuationPoint);
                    }
                }
            }
            
            return true;
        }
        
        /// <summary>
        /// Browses the node and verifies the results.
        /// </summary>
        private bool Browse(Node node, double start, double range)
        {
            // watch for circular references.
            if (m_availableNodes.ContainsKey(node.NodeId))
            {
                return true;
            }

            // get the master list of references.
            BrowseDescription nodeToBrowse = new BrowseDescription();
            
            nodeToBrowse.NodeId = node.NodeId;
            nodeToBrowse.BrowseDirection = BrowseDirection.Both;
            nodeToBrowse.IncludeSubtypes = true;
            nodeToBrowse.NodeClassMask = 0;
            nodeToBrowse.ReferenceTypeId = ReferenceTypeIds.References;
            nodeToBrowse.ResultMask = (uint)BrowseResultMask.All;
            
            ReferenceDescriptionCollection references = new ReferenceDescriptionCollection();
            
            if (!Browse(node, nodeToBrowse, references))
            {
                return false;
            }

            // save references.
            node.Handle = references;
            
            // add to dictionary.
            m_availableNodes.Add(node.NodeId, node);

            // build list of hierachial targets.
            List<Node> targets = new List<Node>();

            for (int ii = 0; ii < references.Count; ii++)
            {
                ReferenceDescription reference = references[ii];

                if (!reference.IsForward)
                {
                    continue;
                }

                if (!Session.TypeTree.IsTypeOf(reference.ReferenceTypeId, ReferenceTypeIds.HierarchicalReferences))
                {
                    continue;
                }

                Node target = Node.Copy(new Node(reference));
                targets.Add(target);
            }
                        
            // recursively follow sub-tree.
            if (targets.Count > 0)
            {
                double increment = range/targets.Count;
                double position  = start;

                for (int ii = 0; ii < targets.Count; ii++)
                {
                    if (range == MaxProgress)
                    {
                        Log("Browsing children of '{0}'. NodeId = {1}", targets[ii], targets[ii].NodeId);
                    }

                    Browse(targets[ii], position, increment);

                    position += increment;
                    ReportProgress(position);
                }
            }

            return true;
        }
                
        /// <summary>
        /// Verifies that the timestamps match the requested filter.
        /// </summary>
        protected bool VerifyTimestamps(
            Node node, 
            uint attributeId,
            TimestampsToReturn timestampsToReturn, 
            DataValue value)
        {
            // check server timestamp.
            if (timestampsToReturn != TimestampsToReturn.Server && timestampsToReturn != TimestampsToReturn.Both)
            {
                if (value.ServerTimestamp != DateTime.MinValue || value.ServerPicoseconds != 0)
                {                    
                    Log(
                        "Unexpected ServerTimestamp returned during read for Node '{0}'. NodeId = {1}, Attribute = {2}, Timestamp = {3}, Picoseconds = {4}",
                        node,
                        node.NodeId,
                        Attributes.GetBrowseName(attributeId),
                        value.ServerTimestamp,
                        value.ServerPicoseconds);

                    return false;
                }
            }

            if (timestampsToReturn == TimestampsToReturn.Server || timestampsToReturn == TimestampsToReturn.Both)
            {
                if (value.ServerTimestamp.AddHours(1) < DateTime.UtcNow || DateTime.UtcNow.AddHours(1) < value.ServerTimestamp)
                {                    
                    Log(
                        "Valid ServerTimestamp not returned during read for Node '{0}'. NodeId = {1}, Attribute = {2}, Timestamp = {3}, Picoseconds = {4}",
                        node,
                        node.NodeId,
                        Attributes.GetBrowseName(attributeId),
                        value.ServerTimestamp,
                        value.ServerPicoseconds);

                    return false;
                }
            }
            
            // check source timestamp.
            if (timestampsToReturn != TimestampsToReturn.Source && timestampsToReturn != TimestampsToReturn.Both)
            {
                if (value.SourceTimestamp != DateTime.MinValue || value.SourcePicoseconds != 0)
                {                    
                    Log(
                        "Unexpected SourceTimestamp returned during read for Node '{0}'. NodeId = {1}, Attribute = {2}, Timestamp = {3}, Picoseconds = {4}",
                        node,
                        node.NodeId,
                        Attributes.GetBrowseName(attributeId),
                        value.SourceTimestamp,
                        value.ServerPicoseconds);

                    return false;
                }
            }

            // check non-value attribute source timestamp.
            if (attributeId != Attributes.Value)
            {
                if (value.SourceTimestamp != DateTime.MinValue || value.SourcePicoseconds != 0)
                {                    
                    Log(
                        "Unexpected SourceTimestamp returned during non-value attribute for Node '{0}'. NodeId = {1}, Attribute = {2}, Timestamp = {3}, Picoseconds = {4}",
                        node,
                        node.NodeId,
                        Attributes.GetBrowseName(attributeId),
                        value.SourceTimestamp,
                        value.ServerPicoseconds);

                    return false;
                }
            }
            else if (StatusCode.IsGood(value.StatusCode))
            {
                if (timestampsToReturn == TimestampsToReturn.Source || timestampsToReturn == TimestampsToReturn.Both)
                {
                    if (value.SourceTimestamp.AddYears(10) < DateTime.UtcNow || DateTime.UtcNow.AddHours(1) < value.SourceTimestamp)
                    {                    
                        Log(
                            "Valid SourceTimestamp not returned during read for Node '{0}'. NodeId = {1}, Attribute = {2}, Timestamp = {3}, Picoseconds = {4}",
                            node,
                            node.NodeId,
                            Attributes.GetBrowseName(attributeId),
                            value.SourceTimestamp,
                            value.SourcePicoseconds);

                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Verifies an error returned during an attribute read.
        /// </summary>
        protected bool VerifyBadAttribute(
            Node node, 
            uint attributeId,
            StatusCode error)
        {
            // check for invalid attribute.
            if (error == StatusCodes.BadAttributeIdInvalid)
            {
                // expected if attribute is not valid for node.
                if (!Attributes.IsValid(node.NodeClass, attributeId))
                {
                    return true;
                }

                // check for optional attribute.
                switch (attributeId)
                {
                    case Attributes.Description:
                    {
                        node.Description = null;
                        return true;
                    }

                    case Attributes.ArrayDimensions:
                    {
                        ((IVariableBase)node).ArrayDimensions = null;
                        return true;
                    }

                    case Attributes.InverseName:
                    {
                        ((IReferenceType)node).InverseName = null;
                        return true;
                    }

                    case Attributes.WriteMask:
                    {
                        node.WriteMask = 0;
                        return true;
                    }

                    case Attributes.UserWriteMask:
                    {
                        node.UserWriteMask = 0;
                        return true;
                    }

                    case Attributes.Value:
                    {
                        if (node.NodeClass == NodeClass.VariableType)
                        {
                            ((IVariableBase)node).Value = error;
                            return true;
                        }

                        break;
                    }
                }

                Log(
                    "Mandatory attribute not supported for Node '{0}'. NodeId = {1}, NodeClass = {2}, Attribute = {3}",
                    node,
                    node.NodeId,
                    node.NodeClass,
                    Attributes.GetBrowseName(attributeId));

                return false;
            }
            
            // anything goes for the value attribute.
            if (attributeId == Attributes.Value)
            {
                ((IVariableBase)node).Value = error;
                return true;
            }
            
            Log(
                "Unexpected error reading for Node '{0}'. NodeId = {1}, Attribute = {2}, Error = {3}",
                node,
                node.NodeId,
                Attributes.GetBrowseName(attributeId),
                error);

            return false;
        }
        
        /// <summary>
        /// Verifies the value returned during an attribute read.
        /// </summary>
        protected bool VerifyGoodAttribute(
            Node node, 
            uint attributeId,
            DataValue value)
        {    
            // check if attribute is not valid for node.
            if (!Attributes.IsValid(node.NodeClass, attributeId))
            {
                Log(
                    "Unexpected Attribute returned during read for Node '{0}'. NodeId = {1}, Attribute = {2}, Value = {3}",
                    node,
                    node.NodeId,
                    Attributes.GetBrowseName(attributeId),
                    value.WrappedValue);

                return false;
            }

            // replace null values with the default.
            object attributeValue = value.Value;

            // check data type.
            TypeInfo typeInfo = TypeInfo.IsInstanceOfDataType(
                attributeValue,
                Attributes.GetDataTypeId(attributeId),
                Attributes.GetValueRank(attributeId),
                Session.NamespaceUris,
                Session.TypeTree);

            if (typeInfo == null)
            {
                Log(
                    "Invalid data type for attribute value for Node '{0}'. NodeId = {1}, Attribute = {2}, ExpectedType = {3}, ActualType = {4}",
                    node,
                    node.NodeId,
                    Attributes.GetBrowseName(attributeId),
                    Attributes.GetBuiltInType(attributeId),
                    value.WrappedValue.TypeInfo);

                return false;
            }

            // save the attribute value.
            try
            {
                if (!SetAttributeValue(node, attributeId, attributeValue))
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Log(
                    e,
                    "Unexpected error saving attribute value for Node '{0}'. NodeId = {1}, Attribute = {2}, Value = {3}",
                    node,
                    node.NodeId,
                    Attributes.GetBrowseName(attributeId),
                    new Variant(attributeValue));

                return false;
            }
            
            return true;
        }

        /// <summary>
        /// Stores the attribute value in the object.
        /// </summary>
        protected bool SetAttributeValue(
            Node node, 
            uint attributeId, 
            object attributeValue)
        {
            switch (attributeId)
            {
                case Attributes.NodeId: 
                { 
                    if (node.NodeId != (NodeId)attributeValue)
                    {
                        Log(
                            "Invalid NodeId attribute value for Node '{0}'. NodeId = {1}, Expected = {2}, Actual = {3}",
                            node,
                            node.NodeId,
                            node.NodeId,
                            new Variant(attributeValue));

                        return false;
                    }

                    break;
                }
                    
                case Attributes.NodeClass: 
                { 
                    if (node.NodeClass != (NodeClass)(int)attributeValue)
                    {
                        Log(
                            "Invalid NodeClass attribute value for Node '{0}'. NodeId = {1}, Expected = {2}, Actual = {3}",
                            node,
                            node.NodeId,
                            node.NodeClass,
                            new Variant(attributeValue));

                        return false;
                    }

                    break;
                }

                case Attributes.BrowseName:
                {
                    node.BrowseName = (QualifiedName)attributeValue;
                    break;
                }

                case Attributes.DisplayName:
                {
                    node.DisplayName = (LocalizedText)attributeValue;
                    break;
                }

                case Attributes.Description:
                {
                    node.Description = (LocalizedText)attributeValue;
                    break;
                }

                case Attributes.WriteMask:
                {
                    node.WriteMask = (uint)attributeValue;
                    break;
                }

                case Attributes.UserWriteMask:
                {
                    node.UserWriteMask = (uint)attributeValue;
                    break;
                }

                case Attributes.ContainsNoLoops:
                {
                    ((IView)node).ContainsNoLoops = (bool)attributeValue;
                    break;
                }

                case Attributes.EventNotifier:
                {
                    if (node.NodeClass == NodeClass.View)
                    {
                        ((IView)node).EventNotifier = (byte)attributeValue;
                    }
                    else
                    {
                        ((IObject)node).EventNotifier = (byte)attributeValue;
                    }

                    break;
                }           
                    
                case Attributes.Executable:
                {
                    ((IMethod)node).Executable = (bool)attributeValue;
                    break;
                }
                    
                case Attributes.UserExecutable:
                {
                    ((IMethod)node).UserExecutable = (bool)attributeValue;
                    break;
                }
                    
                case Attributes.DataType:
                {
                    ((IVariableBase)node).DataType = (NodeId)attributeValue;
                    break;
                }                    
                    
                case Attributes.ValueRank:
                {
                    ((IVariableBase)node).ValueRank = (int)attributeValue;
                    break;
                }

                case Attributes.ArrayDimensions:
                {
                    ((IVariableBase)node).ArrayDimensions = (uint[])attributeValue;
                    break;
                }

                case Attributes.AccessLevel:
                {
                    ((IVariable)node).AccessLevel = (byte)attributeValue;
                    break;
                }

                case Attributes.UserAccessLevel:
                {
                    ((IVariable)node).UserAccessLevel = (byte)attributeValue;
                    break;
                }
                    
                case Attributes.MinimumSamplingInterval:
                {
                    ((IVariable)node).MinimumSamplingInterval = (double)attributeValue;
                    break;
                }
                    
                case Attributes.Historizing:
                {
                    ((IVariable)node).Historizing = (bool)attributeValue;
                    break;
                }
                    
                case Attributes.IsAbstract:
                {
                    switch (node.NodeClass)
                    {
                        case NodeClass.ObjectType: { ((IObjectType)node).IsAbstract = (bool)attributeValue; break; }
                        case NodeClass.VariableType: { ((IVariableType)node).IsAbstract = (bool)attributeValue; break; }
                        case NodeClass.ReferenceType: { ((IReferenceType)node).IsAbstract = (bool)attributeValue; break; }
                        case NodeClass.DataType: { ((IDataType)node).IsAbstract = (bool)attributeValue; break; }
                    }

                    break;
                }
                    
                case Attributes.InverseName:
                {
                    ((IReferenceType)node).InverseName = (LocalizedText)attributeValue;
                    break;
                }

                case Attributes.Symmetric:
                {
                    ((IReferenceType)node).Symmetric = (bool)attributeValue;
                    break;
                }     

                case Attributes.Value:
                {
                    ((IVariableBase)node).Value = attributeValue;
                    break;
                }              
            }

            return true;
        }

        /// <summary>
        /// Verifies that the node attributes are consistent with each other.
        /// </summary>
        protected bool VerifyAttributeConsistency(Node node)
        {
            if (((~node.WriteMask) & node.UserWriteMask) != 0)
            {
                Log(
                    "UserWriteMask allows more access that WriteMask for  Node '{0}'. NodeId = {1}, WriteMask = {2}, UserWriteMask = {3}",
                    node,
                    node.NodeId,
                    node.WriteMask,
                    node.UserWriteMask);

                return false;
            }

            IMethod method = node as IMethod;

            if (method != null)
            {
                if (method.UserExecutable && !method.Executable)
                {
                    Log(
                        "UserExecutable allows more access that Executable for  Node '{0}'. NodeId = {1}, Executable = {2}, UserExecutable = {3}",
                        node,
                        node.NodeId,
                        method.Executable,
                        method.UserExecutable);

                    return false;
                }
            }

            IVariableBase variableBase = node as IVariableBase;

            if (variableBase != null)
            {
                if (!VerifyVariableBaseConsistency(variableBase))
                {
                    return false;
                }
            }

            IVariable variable = node as IVariable;

            if (variable != null)
            {
                if (!VerifyVariableConsistency(variable))
                {
                    return false;
                }
            }

            IVariableType variableType = node as IVariableType;
            
            if (variableType != null)
            {
                if (!VerifyVariableTypeConsistency(variableType))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Verifies that the variable or variable type attributes are consistent with each other.
        /// </summary>
        private bool VerifyVariableBaseConsistency(IVariableBase node)
        {
            INode datatype = Session.NodeCache.Find(node.DataType) as INode;

            if (datatype == null || datatype.NodeClass != NodeClass.DataType)
            {
                Log(
                    "DataType is not recognized for Node '{0}'. NodeId = {1}, DataType = {2}",
                    node,
                    node.NodeId,
                    node.DataType);

                return false;
            }

            if (node.ValueRank < -3)
            {
                Log(
                    "ValueRank is invalid for  Node '{0}'. NodeId = {1}, ValueRank = {2}",
                    node,
                    node.NodeId,
                    node.ValueRank);

                return false;
            }

            if (node.ValueRank <= 0)
            {
                if (node.ArrayDimensions != null && node.ArrayDimensions.Count > 0)
                {
                    Log(
                        "ArrayDimensions not allowed for variable length values Node '{0}'. NodeId = {1}, ValueRank = {2}, ArrayDimensions = {3}",
                        node,
                        node.NodeId,
                        node.ValueRank,
                        new Variant(node.ArrayDimensions));

                    return false;
                }
            }

            else
            {
                if (node.ArrayDimensions != null && node.ArrayDimensions.Count > 0 && node.ArrayDimensions.Count != node.ValueRank)
                {
                    Log(
                        "ArrayDimensions length does not match ValueRank values Node '{0}'. NodeId = {1}, Expected = {2}, Actual = {3}",
                        node,
                        node.NodeId,
                        node.ValueRank,
                        node.ArrayDimensions.Count);

                    return false;
                }
            }

            return true;
        }
        
        /// <summary>
        /// Verifies that the variable attributes are consistent with each other.
        /// </summary>
        private bool VerifyVariableConsistency(IVariable node)
        {
            if (((~node.AccessLevel) & node.UserAccessLevel) != 0)
            {
                Log(
                    "UserAccessLevel allows more access that AccessLevel for  Node '{0}'. NodeId = {1}, WriteMask = {2}, UserWriteMask = {3}",
                    node,
                    node.NodeId,
                    node.AccessLevel,
                    node.UserAccessLevel);

                return false;
            }

            if (node.MinimumSamplingInterval < -1)
            {
                Log(
                    "MinimumSamplingInterval is inavlid for  Node '{0}'. NodeId = {1}, MinimumSamplingInterval = {2}",
                    node,
                    node.NodeId,
                    node.MinimumSamplingInterval);

                return false;
            }
            
            // check for error during read.
            StatusCode? status = node.Value as StatusCode?;

            if (status != null)
            {
                if (status.Value == StatusCodes.BadUserAccessDenied)
                {
                    if ((node.UserAccessLevel & AccessLevels.CurrentRead) != 0)
                    {
                        Log(
                            "UserAccessLevel allows CurrentRead but server returned BadUserAccessDenied for Node '{0}'. NodeId = {1}",
                            node,
                            node.NodeId);

                        return false;
                    }
                }

                if (status.Value == StatusCodes.BadNotReadable)
                {
                    if ((node.AccessLevel & AccessLevels.CurrentRead) != 0)
                    {
                        Log(
                            "AccessLevel allows CurrentRead but server returned BadNotReadable for Node '{0}'. NodeId = {1}",
                            node,
                            node.NodeId);

                        return false;
                    }
                }
            }

            // check data type.
            else
            {
                TypeInfo typeInfo = TypeInfo.IsInstanceOfDataType(
                    node.Value,
                    node.DataType,
                    node.ValueRank,
                    Session.NamespaceUris,
                    Session.TypeTree);

                if (typeInfo == null)
                {
                    Log(
                        "Value has incorrect data type for Node '{0}'. NodeId = {1}, DataType = {2}, ValueRank = {3}, Value = {4}",
                        node,
                        node.NodeId,
                        node.DataType,
                        node.ValueRank,
                        new Variant(node.Value));

                    return false;
                }
            }

            return true;
        }
        
        /// <summary>
        /// Verifies that the variable type attributes are consistent with each other.
        /// </summary>
        private bool VerifyVariableTypeConsistency(IVariableType node)
        {
            // check for error during read.
            StatusCode? status = node.Value as StatusCode?;

            if (status == null)
            {
                TypeInfo typeInfo = TypeInfo.IsInstanceOfDataType(
                    node.Value,
                    node.DataType,
                    node.ValueRank,
                    Session.NamespaceUris,
                    Session.TypeTree);

                if (typeInfo == null)
                {
                    Log(
                        "Value has incorrect data type for Node '{0}'. NodeId = {1}, Attribute = {2}, ValueRank = {3}, Value = {4}",
                        node,
                        node.NodeId,
                        node.DataType,
                        node.ValueRank,
                        new Variant(node.Value));

                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Calculates the difference between the two times in milliseconds.
        /// </summary>
        protected double CalculateInterval(DateTime start, DateTime end)
        {
            double delta = end.Ticks - start.Ticks;
            return delta/TimeSpan.TicksPerMillisecond;
        }
        #endregion
        
        #region Private Fields
        private string m_name;
        private int m_iteration;
        private int m_blockSize;
        private bool m_readOnlyTests;
        private bool m_unlockRequired;
        private Session m_session;
        private ServerTestConfiguration m_configuration;
        private ReportMessageEventHandler m_reportMessage;
        private ReportProgressEventHandler m_reportProgress;
        private NodeIdDictionary<Node> m_availableNodes;
        private List<VariableNode> m_writeableVariables;
        #endregion
    }
 
    /// <summary>
    /// Used to log errors during a test run.
    /// </summary>
    internal delegate void ReportMessageEventHandler(TestBase test, string format, params object[] args);
 
    /// <summary>
    /// Used to log errors during a test run.
    /// </summary>
    internal delegate void ReportProgressEventHandler(TestBase test, double current, double final);
}
