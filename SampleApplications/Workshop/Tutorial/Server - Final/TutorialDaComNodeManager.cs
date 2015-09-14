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
using Opc.Ua.Com;
using Opc.Ua.Com.Client;

namespace TutorialServer
{
    /// <summary>
    /// A node manager that customizes the COM DA wrapper.
    /// </summary>
    public class TutorialDaComNodeManager : ComDaClientNodeManager
    {
        #region Constructors
        /// <summary>
        /// Initializes the node manager.
        /// </summary>
        public TutorialDaComNodeManager(IServerInternal server, string namespaceUri, ComDaClientConfiguration configuration, bool ownsTypeModel)
        :
            base(server, namespaceUri, configuration, ownsTypeModel)
        {
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

        #region Overridden Methods
        #region Task #C5 - Extend Wrapper by Adding a Method
        public override void CreateAddressSpace(IDictionary<NodeId, IList<IReference>> externalReferences)
        {
            base.CreateAddressSpace(externalReferences);
            
            // hard code  a sample branch that has the method added.
            NodeId branchId = DaModelUtils.ConstructIdForDaElement("Static/Simple Types", -1, NamespaceIndex);

            // create the method.
            MethodState method = new MethodState(null);

            method.NodeId = GenerateNodeId();
            method.BrowseName = new QualifiedName("GenerateRandomValues", NamespaceIndex);
            method.DisplayName = method.BrowseName.Name;
            method.Executable = true;
            method.UserExecutable = true;
            method.ReferenceTypeId = ReferenceTypeIds.HasComponent;
            method.Handle = "Static/Simple Types";
            
            method.AddReference(ReferenceTypeIds.HasComponent, true, branchId);
            m_references[branchId] = new IReference[] { new NodeStateReference(ReferenceTypeIds.HasComponent, false, method) };
            
            // save the node for later lookup (all tightly coupled children are added with this call).
            AddPredefinedNode(SystemContext, method);
            
            // register handler.
            method.OnCallMethod = new GenericMethodCalledEventHandler(DoGenerateRandomValues);
        }

        /// <summary>
        /// Handles a method call.
        /// </summary>
        private ServiceResult DoGenerateRandomValues(
            ISystemContext context,
            MethodState method,
            IList<object> inputArguments,
            IList<object> outputArguments)
        {
            ComDaClientManager system = (ComDaClientManager)this.SystemContext.SystemHandle;
            ComDaClient client = system.SelectClient((ServerSystemContext)context, false);

            Opc.Ua.Test.DataGenerator generator = new Opc.Ua.Test.DataGenerator(null);

            IDaElementBrowser browser = client.CreateBrowser((string)method.Handle);

            // create write requests.
            WriteRequestCollection requests = new WriteRequestCollection();

            try
            {
                for (DaElement element = browser.Next(); element != null; element = browser.Next())
                {
                    if (element.ElementType == DaElementType.Branch)
                    {
                        continue;
                    }

                    // generate a random value of the correct data tyoe.
                    bool isArray = false;
                    NodeId dataTypeId = ComUtils.GetDataTypeId(element.DataType, out isArray);
                    
                    object value = generator.GetRandom(
                        dataTypeId, 
                        (isArray)?ValueRanks.OneDimension:ValueRanks.Scalar, 
                        null, 
                        context.TypeTable);

                    // create a request.
                    requests.Add(new Opc.Ua.Com.Client.WriteRequest(element.ItemId, new DataValue(new Variant(value)), 0));
                }
            }
            finally
            {
                browser.Dispose();
            }

            // write values.
            client.Write(requests);

            return ServiceResult.Good;
        }

        /// <summary>
        /// Allows sub-class to add additional references to a element node after validation.
        /// </summary>
        protected override void AddAdditionalElementReferences(ServerSystemContext context, NodeState node)
        {
            IList<IReference> references = null;

            if (m_references.TryGetValue(node.NodeId, out references))
            {
                node.AddReferences(references);
            }
        }

        /// <summary>
        /// Stores addition references which have been added to the address space.
        /// </summary>
        private Dictionary<NodeId, IList<IReference>> m_references = new Dictionary<NodeId, IList<IReference>>();
        #endregion
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
        #endregion
    }
}
