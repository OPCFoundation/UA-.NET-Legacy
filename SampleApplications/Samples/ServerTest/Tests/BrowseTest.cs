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
    /// Browses all of the nodes in the hierarchies.
    /// </summary>
    internal class BrowseTest : TestBase
    {
        #region Constructors
        /// <summary>
        /// Creates the test object.
        /// </summary>
        public BrowseTest(
            Session session,
            ServerTestConfiguration configuration,
            ReportMessageEventHandler reportMessage,
            ReportProgressEventHandler reportProgress,
            TestBase template)
        : 
            base("Browse", session, configuration, reportMessage, reportProgress, template)
        {
            m_view = new ViewDescription();
            m_view.ViewId = null;
            m_view.Timestamp = DateTime.MinValue;
            m_view.ViewVersion = 0;
            m_maxReferencesPerNode = 0;
        }
        #endregion
        
        #region Public Methods
        /// <summary>
        /// Runs the test for all of the browse roots.
        /// </summary>
        public override bool Run(ServerTestCase testcase, int iteration)
        {
            Iteration = iteration;

            // always re-fetch for Hierarchical test. 
            if (testcase.Name == "Hierarchical")
            {
                AvailableNodes.Clear();
            }

            // need fetch nodes used for the test if not already available.
            if (AvailableNodes.Count == 0)
            {
                if (!GetNodesInHierarchy())
                {
                    return false;
                }
            }

            // do secondary test.
            switch (testcase.Name)
            {
                case "ReferenceType":
                {
                    return DoReferenceTypeTest();
                }

                case "NodeClass":
                {
                    return DoNodeClassTest();
                }

                case "BrowseResultMask":
                {
                    return DoBrowseResultMaskTest();
                }

                case "BrowseNext":
                {
                    return DoBrowseNextTest();
                }
            }

            return true;
        }        
        #endregion
        
        #region Test Methods
        /// <summary>
        /// Verifies that the server does no ignore the BrowseResultMask.
        /// </summary>
        private bool DoBrowseResultMaskTest()
        {
            // follow tree from each starting node.
            bool success = true;
                     
            double increment = MaxProgress/AvailableNodes.Count;
            double position  = 0;
            
            Log("Starting BrowseResultMaskTest for {0} Nodes ({1}% Coverage)", AvailableNodes.Values.Count, Configuration.Coverage);
            
            int counter = 0;

            foreach (Node node in AvailableNodes.Values)
            {          
                if (!CheckCoverage(ref counter))
                {
                    continue;
                }
                
                try
                {
                    BrowseDescription nodeToBrowse = new BrowseDescription();
                    
                    nodeToBrowse.NodeId = node.NodeId;
                    nodeToBrowse.BrowseDirection = BrowseDirection.Both;
                    nodeToBrowse.IncludeSubtypes = true;
                    nodeToBrowse.NodeClassMask = 0;
                    nodeToBrowse.ReferenceTypeId = ReferenceTypeIds.References;
                    nodeToBrowse.ResultMask = (uint)BrowseResultMask.None;
                    
                    ReferenceDescriptionCollection references = new ReferenceDescriptionCollection();
                    
                    if (!Browse(node, nodeToBrowse, references))
                    {
                        success = false;
                        break;
                    }
                }
                catch (Exception e)
                {
                    success = false;
                    Log(e, "BrowseResultMaskTest Failed for Node '{0}'. NodeId = {1}", node, node.NodeId);
                }

                position += increment;
                ReportProgress(position);
            }   
         
            return success;
        }
        
        /// <summary>
        /// Verifies that the server does no ignore the NodeClass filter.
        /// </summary>
        private bool DoNodeClassTest()
        {
            // follow tree from each starting node.
            bool success = true;
                     
            double increment = MaxProgress/AvailableNodes.Count;
            double position  = 0;
            
            Log("Starting NodeClassTest for {0} Nodes ({1}% Coverage)", AvailableNodes.Values.Count, Configuration.Coverage);
            
            List<Node> nodes = new List<Node>();
            BrowseDescriptionCollection nodesToBrowse = new BrowseDescriptionCollection();
            List<ReferenceDescriptionCollection> references = new List<ReferenceDescriptionCollection>();

            int counter = 0;

            foreach (Node node in AvailableNodes.Values)
            {         
                if (!CheckCoverage(ref counter))
                {
                    continue;
                }
           
                try
                {
                    NodeClass mask = (NodeClass.Object | NodeClass.View | NodeClass.Method | NodeClass.Variable);
                        
                    AddNodeClassTest(node, mask, nodes, nodesToBrowse, references, true);

                    if (!Browse(nodes, nodesToBrowse, references))
                    {
                        success = false;
                        break;
                    }

                    mask = ( NodeClass.ObjectType | NodeClass.DataType | NodeClass.ReferenceType | NodeClass.VariableType);
                        
                    AddNodeClassTest(node, mask, nodes, nodesToBrowse, references, true);

                    if (!Browse(nodes, nodesToBrowse, references))
                    {
                        success = false;
                        break;
                    }
                }
                catch (Exception e)
                {
                    success = false;
                    Log(e, "BrowseResultMaskTest Failed for Node '{0}'. NodeId = {1}", node, node.NodeId);
                }

                position += increment;
                ReportProgress(position);
            }   
         
            return success;
        }

        /// <summary>
        /// Verifies that the server does no ignore the NodeClass filter.
        /// </summary>
        private bool DoReferenceTypeTest()
        {
            // follow tree from each starting node.
            bool success = true;
                     
            double increment = MaxProgress/AvailableNodes.Count;
            double position  = 0;
            
            Log("Starting ReferenceType for {0} Nodes ({1}% Coverage)", AvailableNodes.Values.Count, Configuration.Coverage);
           
            List<Node> nodes = new List<Node>();
            BrowseDescriptionCollection nodesToBrowse = new BrowseDescriptionCollection();
            List<ReferenceDescriptionCollection> references = new List<ReferenceDescriptionCollection>();

            int counter = 0;

            foreach (Node node in AvailableNodes.Values)
            {         
                if (!CheckCoverage(ref counter))
                {
                    continue;
                }
                           
                // inverse filter test.
                AddReferenceTypeTest(node, ReferenceTypeIds.NonHierarchicalReferences, true, true, nodes, nodesToBrowse, references, true);

                if (!Browse(nodes, nodesToBrowse, references))
                {
                    success = false;
                    break;
                }

                // forward filter test.
                AddReferenceTypeTest(node, ReferenceTypeIds.NonHierarchicalReferences, false, true, nodes, nodesToBrowse, references, true);

                if (!Browse(nodes, nodesToBrowse, references))
                {
                    success = false;
                    break;
                }

                // subtype test with concrete leaf reference.
                AddReferenceTypeTest(node, ReferenceTypeIds.HasOrderedComponent, false, true, nodes, nodesToBrowse, references, true);

                if (!Browse(nodes, nodesToBrowse, references))
                {
                    success = false;
                    break;
                }

                // no-subtype test with abstract reference.
                AddReferenceTypeTest(node, ReferenceTypeIds.HasChild, false, false, nodes, nodesToBrowse, references, true);

                if (!Browse(nodes, nodesToBrowse, references))
                {
                    success = false;
                    break;
                }

                // inverse hierarchial test.
                AddReferenceTypeTest(node, ReferenceTypeIds.HierarchicalReferences, true, true, nodes, nodesToBrowse, references, true);

                if (!Browse(nodes, nodesToBrowse, references))
                {
                    success = false;
                    break;
                }

                position += increment;
                ReportProgress(position);
            }   
         
            return success;
        }

        
        /// <summary>
        /// Verifies that the server does no ignore the NodeClass filter.
        /// </summary>
        private bool DoBrowseNextTest()
        {
            // follow tree from each starting node.
            bool success = true;
                     
            double increment = MaxProgress/AvailableNodes.Count;
            double position  = 0;
            
            Log("Starting BrowseNextTest for {0} Nodes ({1}% Coverage).", AvailableNodes.Values.Count, Configuration.Coverage);
            
            List<Node> nodes = new List<Node>();
            BrowseDescriptionCollection nodesToBrowse = new BrowseDescriptionCollection();
            List<ReferenceDescriptionCollection> references = new List<ReferenceDescriptionCollection>();

            int counter = 0;

            foreach (Node node in AvailableNodes.Values)
            {         
                if (!CheckCoverage(ref counter))
                {
                    continue;
                }
      
                try
                {
                    m_maxReferencesPerNode = 3;
                    
                    // all references test.
                    AddNodeClassTest(node, NodeClass.Unspecified, nodes, nodesToBrowse, references, true);
                                        
                    // forward non-hierarchical test.
                    AddReferenceTypeTest(node, ReferenceTypeIds.NonHierarchicalReferences, false, true, nodes, nodesToBrowse, references, false);

                    if (!Browse(nodes, nodesToBrowse, references))
                    {
                        success = false;
                        break;
                    }

                    m_maxReferencesPerNode = 3;
                    
                    // node class filter test.
                    AddNodeClassTest(node, (NodeClass.Object | NodeClass.View | NodeClass.Method | NodeClass.Variable), nodes, nodesToBrowse, references, true);
                                        
                    // forward non-hierarchical test.
                    AddReferenceTypeTest(node, ReferenceTypeIds.HierarchicalReferences, false, true, nodes, nodesToBrowse, references, false);

                    if (!Browse(nodes, nodesToBrowse, references))
                    {
                        success = false;
                        break;
                    }
                }
                catch (Exception e)
                {
                    success = false;
                    Log(e, "BrowseNextTest Failed for Node '{0}'. NodeId = {1}", node, node.NodeId);
                }

                position += increment;
                ReportProgress(position);
            }   
         
            return success;
        }
        
        /// <summary>
        /// Browses the node and verifies the results.
        /// </summary>
        protected override bool Browse(
            Node node,
            BrowseDescription nodeToBrowse, 
            ReferenceDescriptionCollection references)
        {            
            List<Node> nodes = new List<Node>();
            BrowseDescriptionCollection nodesToBrowse = new BrowseDescriptionCollection();
            List<ReferenceDescriptionCollection> referenceLists = new List<ReferenceDescriptionCollection>();
            
            nodes.Add(node);
            nodesToBrowse.Add(nodeToBrowse);
            referenceLists.Add(references);

            return Browse(nodes, nodesToBrowse, referenceLists);
        }
        
        /// <summary>
        /// Browses the node and verifies the results.
        /// </summary>
        private bool Browse(
            List<Node> nodes,
            BrowseDescriptionCollection nodesToBrowse, 
            List<ReferenceDescriptionCollection> references)
        {            
            BrowseResultCollection results;
            DiagnosticInfoCollection diagnosticInfos;
            
            RequestHeader requestHeader = new RequestHeader();
            requestHeader.ReturnDiagnostics = 0;

            Session.Browse(
                requestHeader,
                m_view,
                m_maxReferencesPerNode,
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
            
            List<Node> originalNodes = nodes;
            BrowseDescriptionCollection originalNodesToBrowse = nodesToBrowse;
            List<ReferenceDescriptionCollection> originalReferences = references;

            List<Node> remainingNodes = new List<Node>();
            BrowseDescriptionCollection remainingNodesToBrowse = new BrowseDescriptionCollection();
            List<ReferenceDescriptionCollection> remainingReferences = new List<ReferenceDescriptionCollection>();
            ByteStringCollection continuationPoints = new ByteStringCollection();

            // process results.
            for (int ii = 0; ii < results.Count; ii++)
            {
                // check status code.
                if (StatusCode.IsBad(results[ii].StatusCode))
                {
                    Log(
                        "HierarchicalBrowseTest Failed for Node '{0}'. Status = {2}, NodeId = {1}", 
                        nodes[ii], 
                        nodes[ii].NodeId, 
                        results[ii].StatusCode);

                    return false;
                }

                // check max references.
                if (m_maxReferencesPerNode > 0 && m_maxReferencesPerNode < results[ii].References.Count)
                {
                    Log(
                        "Too many references returned for Node '{0}'. NodeId = {1}, Expected = {2}, Actual = {3}",
                        nodes[ii], 
                        nodes[ii].NodeId, 
                        m_maxReferencesPerNode, 
                        results[ii].References.Count);
                   
                    return false;
                }

                // verify references returned.
                if (!VerifyReferences(nodes[ii], nodesToBrowse[ii], results[ii].References))
                {
                    return false;
                }
                
                // save references.
                references[ii].AddRange(results[ii].References);

                if (results[ii].ContinuationPoint != null)
                {
                    // check max references.
                    if (results[ii].References.Count == 0)
                    {
                        Log(
                            "No references returned with a continuation point for Node '{0}'. NodeId = {1}, Expected = {2}",
                            nodes[ii], 
                            nodes[ii].NodeId, 
                            m_maxReferencesPerNode);
                       
                        return false;
                    }

                    // add to list to rebrowse.
                    remainingNodes.Add(nodes[ii]);
                    remainingNodesToBrowse.Add(nodesToBrowse[ii]);
                    remainingReferences.Add(references[ii]);
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
                
                nodes = remainingNodes;
                nodesToBrowse = remainingNodesToBrowse;
                references = remainingReferences;

                // process results.
                remainingNodes = new List<Node>();
                remainingNodesToBrowse = new BrowseDescriptionCollection();
                remainingReferences = new List<ReferenceDescriptionCollection>();
                continuationPoints = new ByteStringCollection();

                for (int ii = 0; ii < results.Count; ii++)
                {
                    // check status code.
                    if (StatusCode.IsBad(results[ii].StatusCode))
                    {
                        Log(
                            "BrowseNext Failed for Node '{0}'. Status = {2}, NodeId = {1}", 
                            nodes[ii], 
                            nodes[ii].NodeId, 
                            results[ii].StatusCode);

                        return false;
                    }

                    // check max references.
                    if (m_maxReferencesPerNode > 0 && m_maxReferencesPerNode < results[ii].References.Count)
                    {
                        Log(
                            "Too many references returned for Node '{0}'. NodeId = {1}, Expected = {2}, Actual = {3}",
                            nodes[ii], 
                            nodes[ii].NodeId, 
                            m_maxReferencesPerNode, 
                            results[ii].References.Count);
                       
                        return false;
                    }

                    // verify references returned.
                    if (!VerifyReferences(nodes[ii], nodesToBrowse[ii], results[ii].References))
                    {
                        return false;
                    }
                    
                    // save references.
                    references[ii].AddRange(results[ii].References);

                    if (results[ii].ContinuationPoint != null)
                    {
                        // check max references.
                        if (results[ii].References.Count == 0)
                        {
                            Log(
                                "No references returned with a continuation point for Node '{0}'. NodeId = {1}, Expected = {2}",
                                nodes[ii], 
                                nodes[ii].NodeId, 
                                m_maxReferencesPerNode);
                           
                            return false;
                        }

                        // add to list to rebrowse.
                        remainingNodes.Add(nodes[ii]);
                        remainingNodesToBrowse.Add(nodesToBrowse[ii]);
                        remainingReferences.Add(references[ii]);
                        continuationPoints.Add(results[ii].ContinuationPoint);
                    }
                }
            }
            
            // verify filters.
            for (int ii = 0; ii < originalNodes.Count; ii++)
            {
                if (!VerifyFilterResults(originalNodes[ii], originalNodesToBrowse[ii], originalReferences[ii]))
                {
                    return false;
                }
            }

            return true;
        }
        
        /// <summary>
        /// Creates a browse description for a node class test.
        /// </summary>
        private void AddNodeClassTest(
            Node node, 
            NodeClass nodeClassMask,            
            List<Node> nodes,
            BrowseDescriptionCollection nodesToBrowse, 
            List<ReferenceDescriptionCollection> references,
            bool clearLists)
        {
            if (clearLists)
            {
                nodes.Clear();
                nodesToBrowse.Clear();
                references.Clear();
            }

            nodes.Add(node);

            BrowseDescription nodeToBrowse = new BrowseDescription();

            nodeToBrowse.NodeId = node.NodeId;
            nodeToBrowse.ReferenceTypeId = ReferenceTypeIds.References;
            nodeToBrowse.IncludeSubtypes = true;
            nodeToBrowse.BrowseDirection = BrowseDirection.Both;
            nodeToBrowse.NodeClassMask = (uint)nodeClassMask;
            nodeToBrowse.ResultMask = (uint)(BrowseResultMask.DisplayName | BrowseResultMask.NodeClass | BrowseResultMask.ReferenceTypeId | BrowseResultMask.IsForward);

            nodesToBrowse.Add(nodeToBrowse);

            references.Add(new ReferenceDescriptionCollection());
        }
        
        /// <summary>
        /// Creates a browse description for a node class test.
        /// </summary>
        private void AddReferenceTypeTest(
            Node node, 
            NodeId referenceTypeId,
            bool isInverse,
            bool includeSubtypes,
            List<Node> nodes,
            BrowseDescriptionCollection nodesToBrowse, 
            List<ReferenceDescriptionCollection> references,
            bool clearLists)
        {
            if (clearLists)
            {
                nodes.Clear();
                nodesToBrowse.Clear();
                references.Clear();
            }

            nodes.Add(node);

            BrowseDescription nodeToBrowse = new BrowseDescription();

            nodeToBrowse.NodeId = node.NodeId;
            nodeToBrowse.ReferenceTypeId = referenceTypeId;
            nodeToBrowse.IncludeSubtypes = includeSubtypes;
            nodeToBrowse.BrowseDirection = (isInverse)?BrowseDirection.Inverse:BrowseDirection.Forward;
            nodeToBrowse.NodeClassMask = (uint)NodeClass.Unspecified;
            nodeToBrowse.ResultMask = (uint)(BrowseResultMask.DisplayName | BrowseResultMask.NodeClass | BrowseResultMask.ReferenceTypeId | BrowseResultMask.IsForward);

            nodesToBrowse.Add(nodeToBrowse);

            references.Add(new ReferenceDescriptionCollection());
        }
        #endregion
        
        #region Verification Methods
        /// <summary>
        /// Verifies the results of a browse filter.
        /// </summary>
        private bool VerifyFilterResults(
            Node node, 
            BrowseDescription description,
            ReferenceDescriptionCollection actualList)
        {
            NodeId referenceTypeId = description.ReferenceTypeId; 
            BrowseDirection browseDirection = description.BrowseDirection;
            bool includeSubtypes = description.IncludeSubtypes;
            NodeClass nodeClassMask = (NodeClass)description.NodeClassMask;

            // nothing to verify if no master list.
            ReferenceDescriptionCollection masterList = node.Handle as ReferenceDescriptionCollection;

            if (masterList == null)
            {
                return true;
            }

            // cannot verify filter if filter criteria not returned.
            BrowseResultMask requiredMask = (BrowseResultMask.ReferenceTypeId | BrowseResultMask.IsForward | BrowseResultMask.NodeClass);

            if ((description.ResultMask & (uint)requiredMask) != (uint)requiredMask)
            {
                return true;
            }
            
            bool success = true;

            // look for missing references.
            for (int ii = 0; ii < masterList.Count; ii++)
            {
                ReferenceDescription reference = masterList[ii];
                
                if (nodeClassMask != NodeClass.Unspecified && (reference.NodeClass & nodeClassMask) == 0)
                {
                    continue;
                }

                if ((browseDirection == BrowseDirection.Inverse && reference.IsForward) || (browseDirection == BrowseDirection.Forward && !reference.IsForward))
                {
                    continue;
                }

                if (reference.ReferenceTypeId != referenceTypeId)
                {
                    if (!includeSubtypes)
                    {
                        continue;
                    }

                    if (!Session.TypeTree.IsTypeOf(reference.ReferenceTypeId, referenceTypeId))
                    {
                        continue;
                    }
                }
                
                bool found = false;

                for (int jj = 0; jj < actualList.Count; jj++)
                {
                    if (actualList[jj].NodeId == reference.NodeId && actualList[jj].IsForward == reference.IsForward && actualList[jj].ReferenceTypeId == reference.ReferenceTypeId)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    Log(
                        "Did not return expected target when browsing  Node '{0}'. NodeId = {1}, NodeClassMask = {2}, ReferenceFilter = {3}, TargetName = {4}, NodeClass = {5}, ReferenceType = {6}, TargetId = {7}.",
                        node, 
                        node.NodeId,
                        nodeClassMask,
                        Session.TypeTree.FindReferenceTypeName(referenceTypeId),
                        reference.DisplayName,
                        reference.NodeClass,
                        Session.TypeTree.FindReferenceTypeName(reference.ReferenceTypeId),
                        reference.NodeId);

                    success = false;
                }
            }
            
            // look for extra references.
            for (int ii = 0; ii < actualList.Count; ii++)
            {                
                bool found = false;

                for (int jj = 0; jj < masterList.Count; jj++)
                {
                    ReferenceDescription reference = masterList[jj];
                    
                    if (nodeClassMask != NodeClass.Unspecified && (reference.NodeClass & nodeClassMask) == 0)
                    {
                        continue;
                    }

                    if (actualList[ii].NodeId != reference.NodeId || actualList[ii].IsForward != reference.IsForward || actualList[ii].ReferenceTypeId != reference.ReferenceTypeId)
                    {
                        continue;
                    }
                                    
                    if ((browseDirection != BrowseDirection.Inverse && reference.IsForward) || (browseDirection != BrowseDirection.Forward && !reference.IsForward))
                    {
                        if (!includeSubtypes)
                        {
                            if (reference.ReferenceTypeId == referenceTypeId)
                            {
                                found = true;
                                break;
                            }
                        }
                        else
                        {
                            if (Session.TypeTree.IsTypeOf(reference.ReferenceTypeId, referenceTypeId))
                            {
                                found = true;
                                break;
                            }
                        }
                    }

                    Log(
                        "Returned invalid target when browsing Node '{0}'. NodeId = {1}, NodeClassMask = {2}, ReferenceFilter = {3}, TargetName = {4}, NodeClass = {5}, ReferenceType = {6}, TargetId = {7}.",
                        node, 
                        node.NodeId,
                        nodeClassMask,
                        Session.TypeTree.FindReferenceTypeName(referenceTypeId),
                        reference.DisplayName,
                        reference.NodeClass,
                        Session.TypeTree.FindReferenceTypeName(reference.ReferenceTypeId),
                        reference.NodeId);

                    success = false;
                    break;
                }

                if (!found)
                {
                    Log(
                        "Returned unexpected target when browsing Node '{0}'. NodeId = {1}, NodeClassMask = {2}, ReferenceFilter = {3}, TargetName = {4}, NodeClass = {5}, ReferenceType = {6}, TargetId = {7}.",
                        node, 
                        node.NodeId,
                        nodeClassMask,
                        Session.TypeTree.FindReferenceTypeName(referenceTypeId),
                        actualList[ii].DisplayName,
                        actualList[ii].NodeClass,
                        Session.TypeTree.FindReferenceTypeName(actualList[ii].ReferenceTypeId),
                        actualList[ii].NodeId);

                    success = false;
                    continue;
                }
            }

            return success;
        }         
                 
        /// <summary>
        /// Verifies the references returned for a node.
        /// </summary>
        private bool VerifyReferences(
            Node node, 
            BrowseDescription description, 
            ReferenceDescriptionCollection references)
        {
            bool success = true;
                 
            for (int ii = 0; ii < references.Count; ii++)
            {
                ReferenceDescription reference = references[ii];

                if (reference == null)
                {
                    Log("Returned null ReferenceDescription when Browsing Node '{0}'. NodeId = {1}", node, node.NodeId);
                    success = false;
                    continue;
                }

                if (!VerifyTargetId(node, description, reference))
                {
                    success = false;
                    continue;
                }

                if (!VerifyReferenceTypeId(node, description, reference))
                {
                    success = false;
                    continue;
                }

                if (!VerifyIsForward(node, description, reference))
                {
                    success = false;
                    continue;
                }
            }

            // read the attributes to verify the reference is correct. 
            try
            {
                if (!VerifyTargetAttributes(node, description, references))
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Log(e, "Could not verify target attributes when Browsing Node '{0}'. NodeId = {1}", node, node.NodeId);
                return false;
            }
   
            // verify type definitions.
            try
            {
                if (!VerifyTypeDefinitions(node, description, references))
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Log(e, "Could not verify type definitions when Browsing Node '{0}'. NodeId = {1}", node, node.NodeId);
                return false;
            }
   
            return success;   
        }

        /// <summary>
        /// Verifies the target.
        /// </summary>
        private bool VerifyTargetId(Node node, BrowseDescription description, ReferenceDescription reference)
        {     
            // check for null.
            if (NodeId.IsNull(reference.NodeId))
            {
                Log("Returned unexpected null NodeId when Browsing Node '{0}'. NodeId = {1}", node, node.NodeId);
                return false;
            }

            // check for local id.
            if (reference.NodeId.ServerIndex == 0)
            {
                if (!String.IsNullOrEmpty(reference.NodeId.NamespaceUri))
                {
                    Log("Returned NamespaceUri for local node when Browsing Node '{0}'. NodeId = {1}, TargetId = {2}", node, node.NodeId, reference.NodeId);
                    return false;
                }
            }
                
            return true;
        }

        /// <summary>
        /// Verifies the reference type id.
        /// </summary>
        private bool VerifyReferenceTypeId(Node node, BrowseDescription description, ReferenceDescription reference)
        {      
            // check if field was not requested.
            if ((description.ResultMask & (uint)BrowseResultMask.ReferenceTypeId) == 0)
            {
                if (!NodeId.IsNull(reference.ReferenceTypeId))
                {
                    Log("Returned unexpected non-null ReferenceTypeId when Browsing Node '{0}'. NodeId = {1}", node, node.NodeId);
                    return false;
                }

                return true;
            }
            
            // check for null.
            if (NodeId.IsNull(reference.ReferenceTypeId))
            {
                Log("Returned unexpected null ReferenceTypeId when Browsing Node '{0}'. NodeId = {1}", node, node.NodeId);
                return false;
            }

            // check for valid reference.
            IReferenceType referenceType = Session.NodeCache.Find(reference.ReferenceTypeId) as IReferenceType;
            
            if (NodeId.IsNull(reference.ReferenceTypeId))
            {
                Log("Returned invalid ReferenceTypeId when Browsing Node '{0}'. NodeId = {1}, ReferenceTypeId = {2}", node, node.NodeId, reference.ReferenceTypeId);
                return false;
            }
            
            // check for valid subtype.
            if (!Session.TypeTree.IsTypeOf(referenceType.NodeId, description.ReferenceTypeId))
            {                
                string expectedName = description.ReferenceTypeId.ToString();
                
                IReferenceType expectedType = Session.NodeCache.Find(description.ReferenceTypeId) as IReferenceType;

                if (expectedType != null)
                {
                    expectedName = Utils.Format("{0}", expectedType.DisplayName);
                }
            
                Log("ReferenceType {2} is not a subtype of {3} when browsing Node '{0}'. NodeId = {1}", node, node.NodeId, referenceType.DisplayName, expectedName);
                return false;
            }

            return true;
        }
        
        /// <summary>
        /// Verifies the isforward flag.
        /// </summary>
        private bool VerifyIsForward(Node node, BrowseDescription description, ReferenceDescription reference)
        {      
            // check if field was not requested.
            if ((description.ResultMask & (uint)BrowseResultMask.IsForward) == 0)
            {
                if (reference.IsForward)
                {
                    Log("Returned unexpected IsForward=True when Browsing Node '{0}'. NodeId = {1}", node, node.NodeId);
                    return false;
                }

                return true;
            }

            if (reference.IsForward)
            {
                if (description.BrowseDirection == BrowseDirection.Inverse)
                {
                    Log("Returned unexpected IsForward=False when Browsing Node '{0}'. NodeId = {1}", node, node.NodeId);
                    return false;
                }
            }
            else
            {
                if (description.BrowseDirection == BrowseDirection.Forward)
                {
                    Log("Returned unexpected IsForward=True when Browsing Node '{0}'. NodeId = {1}", node, node.NodeId);
                    return false;
                }
            }
                
            return true;
        }
        
        /// <summary>
        /// Reads the attribute values in order to compare them to the returned results.
        /// </summary>
        private bool VerifyTargetAttributes(
            Node node, 
            BrowseDescription description, 
            ReferenceDescriptionCollection references)
        {
            // check if nothing to do.
            if (references.Count == 0)
            {
                return true;
            }
            
            bool error = false;

            // build list of values to read.
            ReadValueIdCollection valuesToRead = new ReadValueIdCollection();

            for (int ii = 0; ii < references.Count; ii++)
            {
                ReferenceDescription reference = references[ii];

                // ignore invalid or external references.
                if (reference == null || reference.NodeId == null || reference.NodeId.IsAbsolute)
                {
                    continue;
                }

                ReadValueId valueToRead = new ReadValueId();

                valueToRead.NodeId = (NodeId)reference.NodeId;
                valueToRead.AttributeId = Attributes.NodeId;
                valueToRead.Handle = reference;

                valuesToRead.Add(valueToRead);
                                
                if ((description.ResultMask & (uint)BrowseResultMask.NodeClass) != 0)
                {
                    valueToRead = new ReadValueId();

                    valueToRead.NodeId = (NodeId)reference.NodeId;
                    valueToRead.AttributeId = Attributes.NodeClass;
                    valueToRead.Handle = reference;

                    valuesToRead.Add(valueToRead);
                }
                else
                {
                    if (reference.NodeClass != 0)
                    {
                        error = true;
                        
                        Log(
                            "Unexpected NodeClass when Browsing Node '{0}'. NodeId = {1}, TargetId = {2}, NodeClass = {3}", 
                            node, 
                            node.NodeId, 
                            reference.NodeId, 
                            reference.NodeClass);

                        continue;
                    }
                }
                                
                if ((description.ResultMask & (uint)BrowseResultMask.BrowseName) != 0)
                {
                    valueToRead = new ReadValueId();

                    valueToRead.NodeId = (NodeId)reference.NodeId;
                    valueToRead.AttributeId = Attributes.BrowseName;
                    valueToRead.Handle = reference;

                    valuesToRead.Add(valueToRead);
                }
                else
                {
                    if (!QualifiedName.IsNull(reference.BrowseName))
                    {
                        error = true;
                        
                        Log(
                            "Unexpected BrowseName when Browsing Node '{0}'. NodeId = {1}, TargetId = {2}, BrowseName = {3}", 
                            node, 
                            node.NodeId, 
                            reference.NodeId, 
                            reference.BrowseName);

                        continue;
                    }
                }
                                
                if ((description.ResultMask & (uint)BrowseResultMask.DisplayName) != 0)
                {
                    valueToRead = new ReadValueId();

                    valueToRead.NodeId = (NodeId)reference.NodeId;
                    valueToRead.AttributeId = Attributes.DisplayName;
                    valueToRead.Handle = reference;

                    valuesToRead.Add(valueToRead);
                }
                else
                {
                    if (!LocalizedText.IsNullOrEmpty(reference.DisplayName))
                    {
                        error = true;
                        
                        Log(
                            "Unexpected DisplayName when Browsing Node '{0}'. NodeId = {1}, TargetId = {2}, DisplayName = {3}", 
                            node, 
                            node.NodeId, 
                            reference.NodeId, 
                            reference.DisplayName);

                        continue;
                    }
                }
            }
            
            // halt if errors occured.
            if (error)
            {
                return false;
            }

            // read values from server.
            DataValueCollection results;
            DiagnosticInfoCollection diagnosticInfos;

            RequestHeader requestHeader = new RequestHeader();
            requestHeader.ReturnDiagnostics = 0;

            Session.Read(
                requestHeader,
                0,
                TimestampsToReturn.Neither,
                valuesToRead,
                out results,
                out diagnosticInfos);
            
            ClientBase.ValidateResponse(results, valuesToRead);
            ClientBase.ValidateDiagnosticInfos(diagnosticInfos, valuesToRead);
            
            // check diagnostics.
            if (diagnosticInfos != null && diagnosticInfos.Count > 0)
            {
                Log("Returned non-empty DiagnosticInfos array when Reading Attributes while Browsing Node '{0}'. NodeId = {1}", node, node.NodeId);
                return false;
            }

            for (int ii = 0; ii < valuesToRead.Count; ii++)
            {
                if (results[ii].StatusCode != StatusCodes.Good)
                {
                    error = true;
                    
                    Log(
                        "Could not read {2} when Browsing Node '{0}'. NodeId = {1}, TargetId = {3}, Status = {4}", 
                        node, 
                        node.NodeId, 
                        Attributes.GetBrowseName(valuesToRead[ii].AttributeId), 
                        valuesToRead[ii].NodeId,
                        results[ii].StatusCode);

                    continue;
                }
                
                ReferenceDescription reference = (ReferenceDescription)valuesToRead[ii].Handle;

                if (valuesToRead[ii].AttributeId == Attributes.NodeId)
                {
                    NodeId expectedId = results[ii].Value as NodeId;

                    if (expectedId != reference.NodeId)
                    {
                        error = true;
                        
                        Log(
                            "Incorrect NodeId Browsing Node '{0}'. NodeId = {1}, TargetId = {2}, Expected = {3}, Actual = {4}", 
                            node, 
                            node.NodeId, 
                            reference.NodeId,
                            expectedId,
                            reference.NodeId);
                    }

                    continue;
                }
                
                if (valuesToRead[ii].AttributeId == Attributes.NodeClass)
                {
                    int? expectedClass = results[ii].Value as int?;

                    if (expectedClass == null || expectedClass.Value != (int)reference.NodeClass)
                    {
                        error = true;
                        
                        Log(
                            "Incorrect NodeClass Browsing Node '{0}'. NodeId = {1}, TargetId = {2}, Expected = {3}, Actual = {4}", 
                            node, 
                            node.NodeId, 
                            reference.NodeId,
                            expectedClass,
                            reference.NodeClass);
                    }

                    continue;
                }

                if (valuesToRead[ii].AttributeId == Attributes.BrowseName)
                {
                    QualifiedName expectedName = results[ii].Value as QualifiedName;

                    if (expectedName != reference.BrowseName)
                    {
                        error = true;
                        
                        Log(
                            "Incorrect BrowseName Browsing Node '{0}'. NodeId = {1}, TargetId = {2}, Expected = {3}, Actual = {4}", 
                            node, 
                            node.NodeId, 
                            reference.NodeId,
                            expectedName,
                            reference.BrowseName);
                    }

                    continue;
                }

                if (valuesToRead[ii].AttributeId == Attributes.DisplayName)
                {
                    LocalizedText expectedName = results[ii].Value as LocalizedText;

                    if (expectedName != reference.DisplayName)
                    {
                        error = true;
                        
                        Log(
                            "Incorrect DisplayName Browsing Node '{0}'. NodeId = {1}, TargetId = {2}, Expected = {3}, Actual = {4}", 
                            node, 
                            node.NodeId, 
                            reference.NodeId,
                            expectedName,
                            reference.DisplayName);
                    }

                    continue;
                }
            }

            return !error;
        }
        
        /// <summary>
        /// Reads the attribute values in order to compare them to the returned results.
        /// </summary>
        private bool VerifyTypeDefinitions(
            Node node, 
            BrowseDescription description, 
            ReferenceDescriptionCollection references)
        {
            // check if nothing to do.
            if (references.Count == 0)
            {
                return true;
            }

            bool success = true;

            BrowseDescriptionCollection nodesToBrowse = new BrowseDescriptionCollection();
            
            for (int ii = 0; ii < references.Count; ii++)
            {
                ReferenceDescription reference = references[ii];

                if ((description.ResultMask & (uint)BrowseResultMask.TypeDefinition) == 0)
                {
                    if (!NodeId.IsNull(reference.TypeDefinition))
                    {
                        success = false;

                        Log(
                            "Unexpected TypeDefinition returned for Node '{0}'. NodeId = {1}, TargetId = {2}, TypeDefinition = {3}",
                            node, 
                            node.NodeId, 
                            reference.NodeId,
                            reference.TypeDefinition);
                    }

                    continue;
                }

                // ignore invalid or external references.
                if (reference == null || reference.NodeId == null || reference.NodeId.IsAbsolute)
                {
                    continue;
                }

                BrowseDescription nodeToBrowse = new BrowseDescription();
                
                nodeToBrowse.NodeId = (NodeId)reference.NodeId;
                nodeToBrowse.BrowseDirection = BrowseDirection.Forward;
                nodeToBrowse.IncludeSubtypes = false;
                nodeToBrowse.NodeClassMask = 0;
                nodeToBrowse.ReferenceTypeId = ReferenceTypeIds.HasTypeDefinition;
                nodeToBrowse.ResultMask = (uint)BrowseResultMask.None;
                nodeToBrowse.Handle = references[ii];
                
                nodesToBrowse.Add(nodeToBrowse);
            }

            // nothing more to do if no type definitions requested.
            if ((description.ResultMask & (uint)BrowseResultMask.TypeDefinition) == 0)
            {
                return success;
            }

            // browse.
            BrowseResultCollection results;
            DiagnosticInfoCollection diagnosticInfos;
            
            RequestHeader requestHeader = new RequestHeader();
            requestHeader.ReturnDiagnostics = 0;

            Session.Browse(
                null,
                m_view,
                0,
                nodesToBrowse,
                out results,
                out diagnosticInfos);
            
            ClientBase.ValidateResponse(results, nodesToBrowse);
            ClientBase.ValidateDiagnosticInfos(diagnosticInfos, nodesToBrowse);
            
            // check diagnostics.
            if (diagnosticInfos != null && diagnosticInfos.Count > 0)
            {
                Log("Returned non-empty DiagnosticInfos array when Browsing TypeDefinition while Browsing Node '{0}'. NodeId = {1}", node, node.NodeId);
                return false;
            }

            bool error = false;

            for (int ii = 0; ii < nodesToBrowse.Count; ii++)
            {
                BrowseResult result = results[ii];
                
                if (StatusCode.IsBad(result.StatusCode))
                {
                    error = true;

                    Log(
                        "Browse TypeDefinition Failed for Node '{0}'. NodeId = {1}, TargetId = {2}, Status = {3}",
                        node, 
                        node.NodeId, 
                        nodesToBrowse[ii].NodeId,
                        results[0].StatusCode);
                    
                    continue;
                }

                ReferenceDescription reference = (ReferenceDescription)nodesToBrowse[ii].Handle;

                if (result.References.Count == 0)
                {
                    if (!NodeId.IsNull(reference.TypeDefinition))
                    {
                        error = true;

                        Log(
                            "Unexpected TypeDefinition returned for Node '{0}'. NodeId = {1}, TargetId = {2}, TypeDefinition = {3}",
                            node, 
                            node.NodeId, 
                            nodesToBrowse[ii].NodeId,
                            reference.TypeDefinition);
                    
                        continue;
                    }
                }
                else
                {
                    if (result.References.Count != 1)
                    {
                        error = true;

                        Log(
                            "Too many TypeDefinitions returned for Node '{0}'. NodeId = {1}, TargetId = {2}, Count = {3}",
                            node, 
                            node.NodeId, 
                            nodesToBrowse[ii].NodeId,
                            result.References.Count);
                    
                        continue;
                    }

                    if (result.References[0].NodeId != reference.TypeDefinition)
                    {
                        error = true;

                        Log(
                            "Incorrect TypeDefinition returned for Node '{0}'. NodeId = {1}, TargetId = {2}, Expected = {3}, Actual = {4}",
                            node, 
                            node.NodeId, 
                            nodesToBrowse[ii].NodeId,
                            result.References[0].NodeId,
                            reference.TypeDefinition);
                    
                        continue;
                    }
                }
            }

            return !error;
        }
        #endregion

        #region Private Fields
        private ViewDescription m_view;
        private uint m_maxReferencesPerNode;
        #endregion
    }
}
