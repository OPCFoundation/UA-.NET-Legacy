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
    /// Translates browse paths and verifies the results.
    /// </summary>
    internal class TranslatePathTest : TestBase
    {
        #region Constructors
        /// <summary>
        /// Creates the test object.
        /// </summary>
        public TranslatePathTest(
            Session session,
            ServerTestConfiguration configuration,
            ReportMessageEventHandler reportMessage,
            ReportProgressEventHandler reportProgress,
            TestBase template)
        : 
            base("TranslatePath", session, configuration, reportMessage, reportProgress, template)
        {
        }
        #endregion
        
        #region Public Methods
        /// <summary>
        /// Runs the test.
        /// </summary>
        public override bool Run(ServerTestCase testcase, int iteration)
        {
            Iteration = iteration;

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
                case "MultiHop":
                {
                    return DoMultiHopTest(3);
                }

                default:
                {
                    return DoMultiHopTest(0);
                }
            }
        }        
        #endregion
        
        #region Test Methods
        /// <summary>
        /// Reads an verifies all of the nodes.
        /// </summary>
        private bool DoMultiHopTest(int hops)
        {
            // follow tree from each starting node.
            bool success = true;
                     
            Log("Starting TranslatePath with {2} hops for {0} Nodes ({1}% Coverage)", AvailableNodes.Values.Count, Configuration.Coverage, hops+1);
            
            // collect the available paths.
            BrowsePathCollection availablePaths = new BrowsePathCollection();
              
            int counter = 0;

            foreach (Node node in AvailableNodes.Values)
            {         
                if (!CheckCoverage(ref counter))
                {
                    continue;
                }
                      
                if (hops <= 0)
                {
                    AddSingleHopPaths(node, availablePaths);
                }
                else
                {
                    AddMultiHopPaths(node, node, null, availablePaths, hops);
                }
            }   
         
            // process paths in blocks.
            int paths = 0;
            
            double increment = MaxProgress/availablePaths.Count;
            double position  = 0;
            
            BrowsePathCollection pathsToTranslate = new BrowsePathCollection();

            for (int ii = 0; ii < availablePaths.Count; ii++)
            {             
                paths++;

                pathsToTranslate.Add(availablePaths[ii]);

                // process batch.
                if (pathsToTranslate.Count > 500)
                {
                    if (!Translate(pathsToTranslate))
                    {
                        success = false;
                        break;
                    }
                    
                    if (paths > availablePaths.Count/5)
                    {
                        Log("Translated {0} browse paths.", paths);
                        paths = 0;
                    }

                    pathsToTranslate.Clear();
                }

                position += increment;
                ReportProgress(position);
            }   
         
            // process final batch.
            if (success)
            {
                if (pathsToTranslate.Count > 0)
                {
                    if (!Translate(pathsToTranslate))
                    {
                        success = false;
                    }
                    else
                    {
                        Log("Translated {0} browse paths.", paths);
                    }
                }
            }

            return success;
        }

        /// <summary>
        /// Reads the attributes, verifies the results and updates the nodes.
        /// </summary>
        private bool Translate(BrowsePathCollection pathsToTranslate)
        {
            bool success = true;

            BrowsePathResultCollection results;
            DiagnosticInfoCollection diagnosticInfos;
            
            RequestHeader requestHeader = new RequestHeader();
            requestHeader.ReturnDiagnostics = 0;

            Session.TranslateBrowsePathsToNodeIds(
                requestHeader,
                pathsToTranslate,
                out results,
                out diagnosticInfos);
            
            ClientBase.ValidateResponse(results, pathsToTranslate);
            ClientBase.ValidateDiagnosticInfos(diagnosticInfos, pathsToTranslate);
            
            // check diagnostics.
            if (diagnosticInfos != null && diagnosticInfos.Count > 0)
            {
                Log("Returned non-empty DiagnosticInfos array during Read.");
                return false;
            }
            
            // check results.
            for (int ii = 0; ii < pathsToTranslate.Count; ii++)
            {
                BrowsePath request = pathsToTranslate[ii];
                Node node = (Node)request.Handle;

                if (!VerifyPaths(node, request, results[ii]))
                {
                    success = false;
                    continue;
                }
            }

            return success;
        }

        /// <summary>
        /// Adds a single hop path for all references for the node.
        /// </summary>
        private void AddSingleHopPaths(Node node, BrowsePathCollection pathsToTranslate)
        {
            ReferenceDescriptionCollection references = node.Handle as ReferenceDescriptionCollection;

            if (references == null)
            {
                return;
            }

            for (int ii = 0; ii < references.Count; ii++)
            {
                BrowsePath browsePath = new BrowsePath();
                browsePath.StartingNode = node.NodeId;
                browsePath.Handle = node;

                RelativePathElement element = new RelativePathElement();

                element.ReferenceTypeId = references[ii].ReferenceTypeId;
                element.IsInverse = !references[ii].IsForward;
                element.IncludeSubtypes = false;
                element.TargetName = references[ii].BrowseName;

                browsePath.RelativePath.Elements.Add(element);
                pathsToTranslate.Add(browsePath);
            }
        }
        
        /// <summary>
        /// Adds a single hop path for all references for the node.
        /// </summary>
        private void AddMultiHopPaths(
            Node node, 
            Node baseNode,
            IList<RelativePathElement> basePath,
            BrowsePathCollection pathsToTranslate,
            int hops)
        {
            ReferenceDescriptionCollection references = node.Handle as ReferenceDescriptionCollection;

            if (references == null)
            {
                return;
            }

            for (int ii = 0; ii < references.Count; ii++)
            {
                ReferenceDescription reference = references[ii];
                
                BrowsePath browsePath = new BrowsePath();

                browsePath.StartingNode = baseNode.NodeId;
                browsePath.Handle = baseNode;

                if (basePath != null)
                {
                    browsePath.RelativePath.Elements.AddRange(basePath);
                }
                
                RelativePathElement element = new RelativePathElement();

                element.ReferenceTypeId = ReferenceTypeIds.NonHierarchicalReferences;
                element.IsInverse = !reference.IsForward;
                element.IncludeSubtypes = true;
                element.TargetName = reference.BrowseName;

                browsePath.RelativePath.Elements.Add(element);
                pathsToTranslate.Add(browsePath);

                // only follow forward heiarchical
                if (!Session.TypeTree.IsTypeOf(reference.ReferenceTypeId, ReferenceTypeIds.HierarchicalReferences))
                {
                    continue;
                }

                element.ReferenceTypeId = ReferenceTypeIds.HierarchicalReferences;

                // can't do anything with absolute or inverse references.
                if (!reference.IsForward || reference.NodeId.IsAbsolute)
                {
                    continue;
                }
                                    
                // look up target
                if (browsePath.RelativePath.Elements.Count < hops)
                {
                    Node target = null;

                    if (!AvailableNodes.TryGetValue((NodeId)reference.NodeId, out target))
                    {
                        continue;
                    }

                    AddMultiHopPaths(target, baseNode, browsePath.RelativePath.Elements, pathsToTranslate, hops);
                }
            }
        }
        #endregion

        #region Validation Methods
        /// <summary>
        /// Recursively finds the targets of the specified path.
        /// </summary>
        private void GetTargets(Node start, IList<RelativePathElement> path, int index, BrowsePathResult result)
        {
            // check for invalid parameters.
            if (index >= path.Count)
            {
                return;
            }

            // look for list of references for node.
            ReferenceDescriptionCollection references = start.Handle as ReferenceDescriptionCollection;

            if (references == null || references.Count == 0)
            {
                return;
            }

            RelativePathElement element = path[index];

            // each list of references.
            for (int ii = 0; ii < references.Count; ii++)
            {
                ReferenceDescription reference = references[ii];

                // check for a reference match.
                if (element.IsInverse == reference.IsForward)
                {
                    continue;
                }

                if (element.ReferenceTypeId != reference.ReferenceTypeId)
                {
                    if (!element.IncludeSubtypes)
                    {
                        continue;
                    }

                    if (!Session.TypeTree.IsTypeOf(reference.ReferenceTypeId, element.ReferenceTypeId))
                    {
                        continue;
                    }
                }

                // check for a browse name match.
                if (element.TargetName != reference.BrowseName)
                {
                    continue;
                }
                
                // check for end of list.
                if (index == path.Count-1)
                {
                    BrowsePathTarget item = new BrowsePathTarget();
                    item.TargetId = reference.NodeId;
                    item.RemainingPathIndex = UInt32.MaxValue;
                    result.Targets.Add(item);
                    continue;
                }

                // check for external reference.
                if (reference.NodeId.IsAbsolute)
                {
                    BrowsePathTarget item = new BrowsePathTarget();
                    item.TargetId = reference.NodeId;
                    item.RemainingPathIndex = (uint)index+1;
                    result.Targets.Add(item);
                    continue;
                }

                // check for targets.
                Node target = null;

                if (!AvailableNodes.TryGetValue((NodeId)reference.NodeId, out target))
                {
                    BrowsePathTarget item = new BrowsePathTarget();
                    item.TargetId = reference.NodeId;
                    item.RemainingPathIndex = (uint)index+1;
                    result.Targets.Add(item);
                    continue;
                }

                // recursively follow targets.
                GetTargets(target, path, index+1, result);
            }
        }

        /// <summary>
        /// Formats the relative path of the string.
        /// </summary>
        private string GetRelativePath(IList<RelativePathElement> path)
        {
            StringBuilder buffer = new StringBuilder();

            for (int ii = 0; ii < path.Count; ii++)
            {
                buffer.AppendFormat("/{0}", path[ii].TargetName);
            }

            return buffer.ToString();
        }

        /// <summary>
        /// Verifies that the timestamps match the requested filter.
        /// </summary>
        private bool VerifyPaths(
            Node node, 
            BrowsePath request, 
            BrowsePathResult result)
        {
            // check empty path.
            if (request.RelativePath.Elements == null || request.RelativePath.Elements.Count == 0)
            {  
                if (result.StatusCode != StatusCodes.BadBrowseNameInvalid)
                {
                    Log(
                        "Unexpected error returned during translate for Node '{0}'. NodeId = {1}, Expected = {2}, Actual = {3}",
                        node,
                        node.NodeId,
                        (StatusCode)StatusCodes.BadBrowseNameInvalid,
                        result.StatusCode);

                    return false;
                }
            }
                      
            BrowsePathResult expectedResult = new BrowsePathResult();
            GetTargets(node, request.RelativePath.Elements, 0, expectedResult);

            if (result.StatusCode == StatusCodes.BadNoMatch)
            {
                if (expectedResult.Targets.Count > 0)
                {
                    Log(
                        "Translate returned BadNoMatch when targets expected '{0}'. NodeId = {1}, Path = {2}, ExpectedCount = {3}",
                        node,
                        node.NodeId,
                        GetRelativePath(request.RelativePath.Elements),
                        expectedResult.Targets.Count);

                 
                    return false;
                }

                if (result.Targets.Count > 0)
                {
                    Log(
                        "Translate returned targets with a BadNoMatch code '{0}'. NodeId = {1}, Path = {2}, ActualCount = {3}",
                        node,
                        node.NodeId,
                        GetRelativePath(request.RelativePath.Elements),
                        result.Targets.Count);

                    return false;
                }

                return true;
            }

            if (expectedResult.Targets.Count == 0)
            {
                Log(
                    "Translate returned invalided error code when no targets exist '{0}'. NodeId = {1}, Path = {2}, StatusCode = {3}",
                    node,
                    node.NodeId,
                    GetRelativePath(request.RelativePath.Elements),
                    (StatusCode)result.StatusCode);

                return false;
            }

            // check status code.
            if (result.StatusCode != StatusCodes.Good)
            {
                Log(
                    "Translate returned an error for Node '{0}'. NodeId = {1}, Path = {2}, StatusCode = {3}",
                    node,
                    node.NodeId,
                    GetRelativePath(request.RelativePath.Elements),
                    (StatusCode)result.StatusCode);

                return false;
            }

            // check for expected targets.
            for (int ii = 0; ii < expectedResult.Targets.Count; ii++)
            {
                BrowsePathTarget expectedTarget = expectedResult.Targets[ii];

                bool found = false;

                for (int jj = 0; jj < result.Targets.Count; jj++)
                {
                    BrowsePathTarget actualTarget = result.Targets[jj];

                    if (actualTarget.TargetId != expectedTarget.TargetId)
                    {
                        continue;
                    }
                    
                    found = true;

                    if (actualTarget.RemainingPathIndex != expectedTarget.RemainingPathIndex)
                    {
                        Log(
                            "Translate did not return correct remaining path index for target Node '{0}'. NodeId = {1}, Path = {2}, Expected = {3}, Actual = {4}",
                            node,
                            node.NodeId,
                            GetRelativePath(request.RelativePath.Elements),
                            expectedTarget.RemainingPathIndex,
                            actualTarget.RemainingPathIndex);

                        return false;
                    }
                        
                    break;
                }

                if (!found)
                {
                    Log(
                        "Translate did not return expected target Node '{0}'. NodeId = {1}, Path = {2}, TargetId = {3}",
                        node,
                        node.NodeId,
                        GetRelativePath(request.RelativePath.Elements),
                        expectedTarget.TargetId);

                    return false;
                }
            }
            
            // check for unexpected targets.
            for (int ii = 0; ii < result.Targets.Count; ii++)
            {
                BrowsePathTarget actualTarget = result.Targets[ii];

                bool found = false;

                for (int jj = 0; jj < expectedResult.Targets.Count; jj++)
                {
                    BrowsePathTarget expectedTarget = expectedResult.Targets[jj];

                    if (actualTarget.TargetId == expectedTarget.TargetId)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    Log(
                        "Translate returned unexpected target Node '{0}'. NodeId = {1}, Path = {2}, TargetId = {3}",
                        node,
                        node.NodeId,
                        GetRelativePath(request.RelativePath.Elements),
                        actualTarget.TargetId);

                    return false;
                }
            }

            // all ok.
            return true;
        }        
        #endregion
    }
}
