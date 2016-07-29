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
    internal class CallTest : TestBase
    {
        #region Constructors
        /// <summary>
        /// Creates the test object.
        /// </summary>
        public CallTest(
            Session session,
            ServerTestConfiguration configuration,
            ReportMessageEventHandler reportMessage,
            ReportProgressEventHandler reportProgress,
            TestBase template)
        : 
            base("Call", session, configuration, reportMessage, reportProgress, template)
        {
            m_generator = new Opc.Ua.Test.DataGenerator(new Opc.Ua.Test.RandomSource(configuration.Seed));
            m_generator.NamespaceUris = Session.NamespaceUris;
            m_generator.ServerUris = Session.ServerUris;
            m_generator.MaxArrayLength = 3;
            m_generator.MaxStringLength = 10;
            m_generator.MaxXmlElementCount = 3;
            m_generator.MaxXmlAttributeCount = 3;
        }
        #endregion
        
        private Opc.Ua.Test.DataGenerator m_generator;

        #region Public Methods
        /// <summary>
        /// Runs the test for all of the browse roots.
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
                case "Errors":
                {
                    return DoCallTest(true);
                }

                default:
                {
                    return DoCallTest(false);
                }
            }
        }        
        #endregion
        
        private class TestMethod
        {
            public Node Parent;
            public MethodNode Method;
            public IList<Argument> InputArguments;
            public IList<Argument> OutputArguments;
            public List<object> Inputs;
        }

        /// <summary>
        /// Collects the child methods of a Node.
        /// </summary>
        private bool CollectMethods(Node node, bool testErrors, List<TestMethod> methods)
        {
            if (node == null || node.NodeClass != NodeClass.Method)
            {
                return true;
            }
            
            MethodNode method = node as MethodNode;

            IList<INode> parents = Session.NodeCache.Find(
                node.NodeId,
                ReferenceTypeIds.HasComponent,
                true,
                true);

            for (int ii = 0; ii < parents.Count; ii++)
            {
                ObjectNode parent = parents[ii] as ObjectNode;

                if (parent != null && method != null)
                {
                    if (!testErrors && parent.BrowseName.Name != "MethodTest")
                    {
                        continue;
                    }

                    bool found = false;

                    for (int jj = 0; jj < methods.Count; jj++)
                    {
                        if (Object.ReferenceEquals(method, methods[jj].Method))
                        {
                            found = true;
                            break;
                        }
                    }

                    if (found)
                    {
                        continue;
                    }
                     
                    TestMethod test = new TestMethod();

                    test.Parent = parent;
                    test.Method = method;
                    test.InputArguments = new Argument[0];
                    test.OutputArguments = new Argument[0];
                    test.Inputs = new List<object>();

                    methods.Add(test);

                    if (methods.Count%25 == 0)
                    {
                        Log("Found for {0} Methods to Call", methods.Count);
                    }

                    IList<INode> properties = Session.NodeCache.Find(
                        method.NodeId,
                        ReferenceTypeIds.HasProperty,
                        false,
                        true);

                    for (int jj = 0; jj < properties.Count; jj++)
                    {
                        VariableNode property = properties[jj] as VariableNode;
                        
                        if (property != null)
                        {
                            if (property.BrowseName == BrowseNames.InputArguments)
                            {
                                if (property.Value.Value == null)
                                {
                                    DataValue value = Session.ReadValue(property.NodeId);
                                    property.Value = value.WrappedValue;
                                }

                                test.InputArguments = (Argument[])ExtensionObject.ToArray(property.Value.Value as Array, typeof(Argument));

                                if (test.InputArguments == null)
                                {
                                    Log(
                                        "Could not read input arguments for method '{0}'. NodeId = {1}, Method = {2}",
                                        test.Parent,
                                        test.Parent.NodeId,
                                        test.Method);

                                    return false;
                                }

                                continue;
                            }

                            if (property.BrowseName == BrowseNames.OutputArguments)
                            {
                                if (property.Value.Value == null)
                                {
                                    DataValue value = Session.ReadValue(property.NodeId);
                                    property.Value = value.WrappedValue;
                                }

                                test.OutputArguments = (Argument[])ExtensionObject.ToArray(property.Value.Value as Array, typeof(Argument));
                                
                                if (test.OutputArguments == null)
                                {
                                    Log(
                                        "Could not read output arguments for method '{0}'. NodeId = {1}, Method = {2}",
                                        test.Parent,
                                        test.Parent.NodeId,
                                        test.Method);

                                    return false;
                                }

                                continue;
                            }
                        }
                    }
                }
            }

            return true;
        }

        #region Test Methods
        /// <summary>
        /// Reads an verifies all of the nodes.
        /// </summary>
        private bool DoCallTest(bool testErrors)
        {
            // follow tree from each starting node.
            bool success = true;
                                 
            // collection writeable variables that don't change during the test.
            List<TestMethod> methods = new List<TestMethod>();

            foreach (Node node in AvailableNodes.Values)
            {
                if (!CollectMethods(node, testErrors, methods))
                {
                    return false;
                }
            }

            Log("Starting CallTest for {0} Methods", methods.Count);
            
            double increment = MaxProgress/(10*methods.Count);
            double position  = 0;

            CallMethodRequestCollection methodsToCall = new CallMethodRequestCollection();
            
            for (int ii = 0; success && ii < 10; ii++)
            {
                int nodes = 0;
                int operations = 0;

                foreach (TestMethod method in methods)
                {               
                    nodes++;

                    AddMethodCall(method, methodsToCall, testErrors);

                    // process batch.
                    if (methodsToCall.Count > 100)
                    {
                        operations += methodsToCall.Count;

                        if (!Call(methodsToCall))
                        {
                            success = false;
                            break;
                        }

                        if (nodes > (10*methods.Count)/5)
                        {
                            Log("Called {1} methods {0} times.", operations, nodes);
                            nodes = 0;
                            operations = 0;
                        }

                        methodsToCall.Clear();
                    }

                    position += increment;
                    ReportProgress(position);
                }   
             
                // process final batch.
                if (success)
                {
                    if (methodsToCall.Count > 0)
                    {
                        operations += methodsToCall.Count;

                        if (!Call(methodsToCall))
                        {
                            success = false;
                        }
                        else
                        {
                            Log("Called {1} methods {0} times.", operations, nodes);
                        }

                        methodsToCall.Clear();
                    }
                }

                if (testErrors)
                {
                    break;
                }
            }

            return success;
        }
        #endregion

        /// <summary>
        /// Reads the attributes, verifies the results and updates the nodes.
        /// </summary>
        private bool Call(CallMethodRequestCollection methodsToCall)
        {
           Opc.Ua.Test.DataComparer comparer = new Opc.Ua.Test.DataComparer(Session.MessageContext);

            bool success = true;

            CallMethodResultCollection results = null;
            DiagnosticInfoCollection diagnosticInfos = null;
            
            RequestHeader requestHeader = new RequestHeader();
            requestHeader.ReturnDiagnostics = 0;

            try
            {
                Session.Call(
                    requestHeader,
                    methodsToCall,
                    out results,
                    out diagnosticInfos);
            }
            catch (System.ServiceModel.CommunicationException e)
            {
                Log("WARNING: Communication error (random data may have resulted in a message that is too large). {0}", e.Message);
                return true;
            }   
            catch (System.Xml.XmlException e)
            {
                Log("WARNING: XML parsing error (random data may have resulted in a message that is too large). {0}", e.Message);
                return true;
            } 
            catch (ServiceResultException e)
            {
                if (e.StatusCode == StatusCodes.BadEncodingLimitsExceeded)
                {
                    Log("WARNING: Communication error (random data may have resulted in a message that is too large). {0}", e.Message);
                    return true;
                }

                throw new ServiceResultException(new ServiceResult(e));
            }

            ClientBase.ValidateResponse(results, methodsToCall);
            ClientBase.ValidateDiagnosticInfos(diagnosticInfos, methodsToCall);
            
            // check diagnostics.
            if (diagnosticInfos != null && diagnosticInfos.Count > 0)
            {
                Log("Returned non-empty DiagnosticInfos array during Call.");
                return false;
            }
            
            // check results.
            for (int ii = 0; ii < methodsToCall.Count; ii++)
            {
                CallMethodRequest request = methodsToCall[ii];
                TestMethod method = (TestMethod)request.Handle;

                if (request.ObjectId != method.Parent.NodeId)
                {
                    if (results[ii].StatusCode != StatusCodes.BadMethodInvalid)
                    {
                        Log(
                            "Invalid result when method called on wrong object '{0}'. NodeId = {1}, Method = {2}, StatusCode = {3}",
                            method.Parent,
                            method.Parent.NodeId,
                            method.Method,
                            results[ii].StatusCode);

                        success = false;
                        break;
                    }

                    continue;
                }
     
                if (results[ii].StatusCode == StatusCodes.BadUserAccessDenied)
                {
                    if (method.Method.UserExecutable)
                    {
                        Log(
                            "Call failed when calling an executable method '{0}'. NodeId = {1}, Method = {2}, StatusCode = {3}",
                            method.Parent,
                            method.Parent.NodeId,
                            method.Method,
                            results[ii].StatusCode);

                        success = false;
                        break;
                    }

                    continue;
                }

                if (results[ii].StatusCode == StatusCodes.BadNotImplemented)
                {
                    continue;
                }                           
                    
                if (request.InputArguments.Count != method.InputArguments.Count)
                {                
                    if (results[ii].StatusCode != StatusCodes.BadArgumentsMissing)
                    {
                        Log(
                            "Incorrect error returned when passing method wrong number of arguments '{0}'. NodeId = {1}, Method = {2}, StatusCode = {3}",
                            method.Parent,
                            method.Parent.NodeId,
                            method.Method,
                            results[ii].StatusCode);

                        success = false;
                        break;
                    }

                    continue;
                }
                
                if (results[ii].StatusCode == StatusCodes.BadInvalidArgument || results[ii].StatusCode == StatusCodes.BadOutOfRange)
                {
                    if (results[ii].InputArgumentResults.Count != request.InputArguments.Count)
                    {
                        Log(
                            "Incorrect number of result returned when reporting argument error '{0}'. NodeId = {1}, Method = {2}, Expected = {3}, Actual = {4}",
                            method.Parent,
                            method.Parent.NodeId,
                            method.Method,
                            request.InputArguments.Count,
                            results[ii].InputArgumentResults.Count);

                        success = false;
                        break;
                    }

                    bool errorFound = false;

                    for (int jj = 0; jj < method.InputArguments.Count; jj++)
                    {
                        if (results[ii].InputArgumentResults[jj] != results[ii].StatusCode)
                        {
                            errorFound = true;
                        }

                        Argument argument = method.InputArguments[jj];

                        // check if data type matches.
                        TypeInfo typeInfo = TypeInfo.IsInstanceOfDataType(
                            request.InputArguments[jj].Value,
                            argument.DataType,
                            argument.ValueRank,
                            Session.NamespaceUris,
                            Session.TypeTree);

                        if (typeInfo == null)
                        {
                            if (results[ii].InputArgumentResults[jj] != StatusCodes.BadTypeMismatch)
                            {
                                Log(
                                    "Incorrect error returned for invalid argument '{0}'. NodeId = {1}, Method = {2}, Argument = {3}, StatusCode = {4}",
                                    method.Parent,
                                    method.Parent.NodeId,
                                    method.Method,
                                    method.InputArguments[jj].Name,
                                    results[ii].InputArgumentResults[jj]);

                                success = false;
                            }
                                
                            continue;
                        }
                        
                        if (results[ii].InputArgumentResults[jj] != StatusCodes.Good && results[ii].InputArgumentResults[jj] != StatusCodes.BadOutOfRange)
                        {
                            Log(
                                "Incorrect error returned for valid argument '{0}'. NodeId = {1}, Method = {2}, Argument = {3}, StatusCode = {4}",
                                method.Parent,
                                method.Parent.NodeId,
                                method.Method,
                                method.InputArguments[jj].Name,
                                results[ii].InputArgumentResults[jj]);

                            success = false;
                        }
                    }

                    if (!success)
                    {
                        break;
                    }

                    if (!errorFound)
                    {
                        Log(
                            "No matching argument level error for method '{0}'. NodeId = {1}, Method = {2}, StatusCode = {4}",
                            method.Parent,
                            method.Parent.NodeId,
                            method.Method,
                            results[ii].StatusCode);
                        
                        success = false;
                        break;
                    }

                    continue;
                }

                if (StatusCode.IsBad(results[ii].StatusCode))
                {
                    if (results[ii].StatusCode != StatusCodes.BadNotImplemented)
                    {
                        Log(
                            "Unexpected error when calling method '{0}'. NodeId = {1}, Method = {2}, StatusCode = {3}",
                            method.Parent,
                            method.Parent.NodeId,
                            method.Method,
                            results[ii].StatusCode);

                        success = false;
                        break;
                    }

                    continue;
                }

                if (results[ii].OutputArguments.Count != method.OutputArguments.Count)
                {
                    Log(
                        "Incorrect number of output arguments '{0}'. NodeId = {1}, Method = {2}, Expected = {3}, Actual = {4}",
                        method.Parent,
                        method.Parent.NodeId,
                        method.Method,
                        method.OutputArguments.Count,
                        results[ii].OutputArguments.Count);

                    success = false;
                    break;
                }
                 
                for (int jj = 0; jj < method.OutputArguments.Count; jj++)
                {
                    Argument argument = method.OutputArguments[jj];

                    // check if data type matches.
                    TypeInfo typeInfo = TypeInfo.IsInstanceOfDataType(
                        results[ii].OutputArguments[jj].Value,
                        argument.DataType,
                        argument.ValueRank,
                        Session.NamespaceUris,
                        Session.TypeTree);

                    if (typeInfo == null)
                    {
                        Log(
                            "Datatype for output argument is invalid '{0}'. NodeId = {1}, Method = {2}, Argument = {3}, Value = {4}",
                            method.Parent,
                            method.Parent.NodeId,
                            method.Method,
                            method.OutputArguments[jj].Name,
                            results[ii].OutputArguments[jj]);

                        success = false;                            
                        continue;
                    }

                    // check for special test methods that return the input parameters.
                    if (method.Parent.BrowseName.Name == "MethodTest")
                    {
                        if (jj < request.InputArguments.Count)
                        {
                            if (!comparer.CompareVariant(request.InputArguments[jj], results[ii].OutputArguments[jj]))
                            {
                                Log(
                                    "Output argument did not match input '{0}'. NodeId = {1}, Method = {2}, Argument = {3}, Value = {4}, Output = {5}",
                                    method.Parent,
                                    method.Parent.NodeId,
                                    method.Method,
                                    method.OutputArguments[jj].Name,
                                    request.InputArguments[jj],
                                    results[ii].OutputArguments[jj]);

                                success = false;                            
                                continue;
                            }
                        }
                    }
                }

                if (!success)
                {
                    break;
                }
            }
            
            return success;
        }
        
        /// <summary>
        /// Adds random parameters
        /// </summary>
        private void AddMethodCall(
            TestMethod method, 
            CallMethodRequestCollection methodsToCall,
            bool testErrors)
        {            
            VariantCollection inputArguments = new VariantCollection();

            for (int ii = 0; ii < method.InputArguments.Count; ii++)
            {
                Argument argument = method.InputArguments[ii];

                object value = m_generator.GetRandom(
                    argument.DataType,
                    argument.ValueRank,
                    argument.ArrayDimensions,
                    Session.TypeTree);
                
                inputArguments.Add(new Variant(value));
            }
         
            CallMethodRequest request = null;

            // add valid method.
            if (!testErrors)
            {
                request = new CallMethodRequest();

                request.ObjectId = method.Parent.NodeId;
                request.MethodId = method.Method.NodeId;
                request.Handle = method;
                request.InputArguments = new VariantCollection(inputArguments);

                methodsToCall.Add(request);

                return;
            }
                     
            // add invalid object.
            request = new CallMethodRequest();

            request.ObjectId = Objects.RootFolder;
            request.MethodId = method.Method.NodeId;
            request.Handle = method;
            request.InputArguments = new VariantCollection(inputArguments);

            methodsToCall.Add(request);
                                 
            if (inputArguments.Count > 0)
            {
                // add too few parameters.
                request = new CallMethodRequest();

                request.ObjectId = method.Parent.NodeId;
                request.MethodId = method.Method.NodeId;
                request.Handle = method;
                request.InputArguments = new VariantCollection(inputArguments);
                request.InputArguments.RemoveAt(request.InputArguments.Count-1);

                methodsToCall.Add(request);
                
                // add invalid parameter.
                request = new CallMethodRequest();

                request.ObjectId = method.Parent.NodeId;
                request.MethodId = method.Method.NodeId;
                request.Handle = method;
                request.InputArguments = new VariantCollection(inputArguments);
                
                Argument argument = method.InputArguments[inputArguments.Count/2];      
          
                if (TypeInfo.GetBuiltInType(argument.DataType, Session.TypeTree) != BuiltInType.Variant)
                {
                    TypeInfo typeInfo = null;

                    do
                    { 
                        Variant arg = (Variant)m_generator.GetRandom(BuiltInType.Variant);

                        typeInfo = TypeInfo.IsInstanceOfDataType(
                            arg.Value,
                            argument.DataType,
                            argument.ValueRank,
                            Session.NamespaceUris,
                            Session.TypeTree);

                        if (typeInfo == null)
                        {
                            request.InputArguments[inputArguments.Count/2] = arg;
                            methodsToCall.Add(request);
                            break;
                        }
                    }
                    while (typeInfo != null);
                }
            }

            // add extra parameters.
            request = new CallMethodRequest();

            request.ObjectId = method.Parent.NodeId;
            request.MethodId = method.Method.NodeId;
            request.Handle = method;
            request.InputArguments = new VariantCollection(inputArguments);
            request.InputArguments.Add(new Variant(m_generator.GetRandom(BuiltInType.Variant)));

            methodsToCall.Add(request);
        }
    }
}
