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
    internal class ReadTest : TestBase
    {
        #region Constructors
        /// <summary>
        /// Creates the test object.
        /// </summary>
        public ReadTest(
            Session session,
            ServerTestConfiguration configuration,
            ReportMessageEventHandler reportMessage,
            ReportProgressEventHandler reportProgress,
            TestBase template)
        : 
            base("Read", session, configuration, reportMessage, reportProgress, template)
        {
        }
        #endregion
        
        #region Public Methods
        /// <summary>
        /// Runs the test for all of the browse roots.
        /// </summary>
        public override bool Run(ServerTestCase testcase, int iteration)
        {
            Iteration = iteration;

            // need fetch nodes used for the test if not already available.
            bool fetched = false;

            if (AvailableNodes.Count == 0)
            {
                fetched = true;

                if (!GetNodesInHierarchy())
                {
                    return false;
                }
            }

            // do secondary test.
            switch (testcase.Name)
            {
                case "IndexRanges":
                {
                    if (fetched)
                    {
                        if (!DoReadTest())
                        {
                            return false;
                        }
                    }

                    return DoReadIndexRangeTest();
                }

                case "DataEncodings":
                {
                    if (fetched)
                    {
                        if (!DoReadTest())
                        {
                            return false;
                        }
                    }

                    return DoReadDataEncodingTest();
                }

                case "ReadWrite":
                {
                    try
                    {
                        LockServer();

                        if (ReadOnlyTests)
                        {
                            Log("WARNING: TestCase {0} skipped because client could not acquire a lock on the Server.", testcase.Name);
                            return true;
                        }

                        if (fetched)
                        {
                            if (!DoReadTest())
                            {
                                return false;
                            }
                        }

                        return DoReadWriteTest();
                    }
                    finally
                    {
                        UnlockServer();
                    }
                }

                default:
                {
                    return DoReadTest();
                }
            }
        }        
        #endregion
        
        #region Test Methods
        /// <summary>
        /// Reads an verifies all of the nodes.
        /// </summary>
        private bool DoReadTest()
        {
            // follow tree from each starting node.
            bool success = true;
                     
            double increment = MaxProgress/AvailableNodes.Count;
            double position  = 0;
            
            Log("Starting ReadTest for {0} Nodes", AvailableNodes.Values.Count);
            
            ReadValueIdCollection nodesToRead = new ReadValueIdCollection();
            
            uint[] attributeIds = Attributes.GetIdentifiers();
            
            int nodes = 0;
            int operations = 0;

            foreach (Node node in AvailableNodes.Values)
            {               
                nodes++;

                AddAttributes(node, nodesToRead, attributeIds);

                // process batch.
                if (nodesToRead.Count > BlockSize)
                {
                    operations += nodesToRead.Count;

                    if (!Read(nodesToRead))
                    {
                        success = false;
                        break;
                    }

                    if (nodes > AvailableNodes.Count/5)
                    {
                        Log("Read {0} attribute values for {1} nodes.", operations, nodes);
                        nodes = 0;
                        operations = 0;
                    }

                    nodesToRead.Clear();
                }

                position += increment;
                ReportProgress(position);
            }   
         
            // process final batch.
            if (success)
            {
                if (nodesToRead.Count > 0)
                {
                    operations += nodesToRead.Count;

                    if (!Read(nodesToRead))
                    {
                        success = false;
                    }
                    else
                    {
                        Log("Read {0} attribute values for {1} nodes.", operations, nodes);
                    }
                }
            }

            return success;
        }

        /// <summary>
        /// Reads an verifies all of the nodes.
        /// </summary>
        private bool DoReadIndexRangeTest()
        {
            // follow tree from each starting node.
            bool success = true;
                     
            double increment = MaxProgress/AvailableNodes.Count;
            double position  = 0;
            
            Log("Starting ReadIndexRangeTest for {0} Nodes", AvailableNodes.Values.Count);
            
            ReadValueIdCollection nodesToRead = new ReadValueIdCollection();
            
            int nodes = 0;
            int operations = 0;

            uint[] attributeIds = Attributes.GetIdentifiers();

            foreach (Node node in AvailableNodes.Values)
            {               
                nodes++;

                AddIndexRanges(node, nodesToRead, attributeIds);

                // process batch.
                if (nodesToRead.Count > BlockSize)
                {
                    operations += nodesToRead.Count;

                    if (!Read(nodesToRead))
                    {
                        success = false;
                        break;
                    }

                    if (nodes > AvailableNodes.Count/5)
                    {
                        Log("Read {0} attribute values for {1} nodes.", operations, nodes);
                        nodes = 0;
                        operations = 0;
                    }

                    nodesToRead.Clear();
                }

                position += increment;
                ReportProgress(position);
            }   
         
            // process final batch.
            if (success)
            {
                if (nodesToRead.Count > 0)
                {
                    operations += nodesToRead.Count;

                    if (!Read(nodesToRead))
                    {
                        success = false;
                    }
                    else
                    {
                        Log("Read {0} attribute values for {1} nodes.", operations, nodes);
                    }
                }
            }

            return success;
        }
        
        /// <summary>
        /// Reads an verifies all of the nodes.
        /// </summary>
        private bool DoReadDataEncodingTest()
        {
            // follow tree from each starting node.
            bool success = true;
                     
            double increment = MaxProgress/AvailableNodes.Count;
            double position  = 0;
            
            Log("Starting ReadDataEncodingTest for {0} Nodes", AvailableNodes.Values.Count);
            
            ReadValueIdCollection nodesToRead = new ReadValueIdCollection();
            
            int nodes = 0;
            int operations = 0;
            
            uint[] attributeIds = Attributes.GetIdentifiers();

            foreach (Node node in AvailableNodes.Values)
            {               
                nodes++;

                AddDataEncodings(node, nodesToRead, attributeIds);

                // process batch.
                if (nodesToRead.Count > BlockSize)
                {
                    operations += nodesToRead.Count;

                    if (!Read(nodesToRead))
                    {
                        success = false;
                        break;
                    }

                    if (nodes > AvailableNodes.Count/5)
                    {
                        Log("Read {0} attribute values for {1} nodes.", operations, nodes);
                        nodes = 0;
                        operations = 0;
                    }

                    nodesToRead.Clear();
                }

                position += increment;
                ReportProgress(position);
            }   
         
            // process final batch.
            if (success)
            {
                if (nodesToRead.Count > 0)
                {
                    operations += nodesToRead.Count;

                    if (!Read(nodesToRead))
                    {
                        success = false;
                    }
                    else
                    {
                        Log("Read {0} attribute values for {1} nodes.", operations, nodes);
                    }
                }
            }

            return success;
        }        
        
        /// <summary>
        /// Reads an verifies all of the nodes.
        /// </summary>
        private bool DoReadWriteTest()
        {
            // follow tree from each starting node.
            bool success = true;
                     
            double increment = MaxProgress/AvailableNodes.Count;
            double position  = 0;
            
            Log("Starting ReadWriteTest for {0} Nodes", AvailableNodes.Values.Count);
            
            WriteValueCollection nodesToWrite = new WriteValueCollection();
            
            int nodes = 0;
            int operations = 0;
            
            uint[] attributeIds = Attributes.GetIdentifiers();

            foreach (Node node in AvailableNodes.Values)
            {               
                nodes++;

                AddWriteValues(node, nodesToWrite, attributeIds);

                // process batch.
                if (nodesToWrite.Count > BlockSize)
                {
                    operations += nodesToWrite.Count;

                    if (!Write(nodesToWrite))
                    {
                        success = false;
                        break;
                    }

                    if (nodes > AvailableNodes.Count/5)
                    {
                        Log("Wrote {0} attribute values for {1} nodes.", operations, nodes);
                        nodes = 0;
                        operations = 0;
                    }

                    nodesToWrite.Clear();
                }

                position += increment;
                ReportProgress(position);
            }   
         
            // process final batch.
            if (success)
            {
                if (nodesToWrite.Count > 0)
                {
                    operations += nodesToWrite.Count;

                    if (!Write(nodesToWrite))
                    {
                        success = false;
                    }
                    else
                    {
                        Log("Wrote {0} attribute values for {1} nodes.", operations, nodes);
                    }
                }
            }

            return success;
        }
        #endregion

        /// <summary>
        /// Reads the attributes, verifies the results and updates the nodes.
        /// </summary>
        private bool Read(ReadValueIdCollection nodesToRead)
        {
            bool success = true;

            DataValueCollection results;
            DiagnosticInfoCollection diagnosticInfos;
            
            RequestHeader requestHeader = new RequestHeader();
            requestHeader.ReturnDiagnostics = 0;

            Session.Read(
                requestHeader,
                0,
                TimestampsToReturn.Both,
                nodesToRead,
                out results,
                out diagnosticInfos);
            
            ClientBase.ValidateResponse(results, nodesToRead);
            ClientBase.ValidateDiagnosticInfos(diagnosticInfos, nodesToRead);
            
            // check diagnostics.
            if (diagnosticInfos != null && diagnosticInfos.Count > 0)
            {
                Log("Returned non-empty DiagnosticInfos array during Read.");
                return false;
            }
            
            // check results.
            for (int ii = 0; ii < nodesToRead.Count; ii++)
            {
                ReadValueId request = nodesToRead[ii];
                Node node = (Node)request.Handle;

                if (!VerifyTimestamps(node, request.AttributeId, TimestampsToReturn.Both, results[ii]))
                {
                    success = false;
                    continue;
                }

                if (request.IndexRange == null && request.DataEncoding == null)
                {
                    if (StatusCode.IsBad(results[ii].StatusCode))
                    {
                        if (!VerifyBadAttribute(node, request.AttributeId, results[ii].StatusCode))
                        {
                            success = false;                        
                        }

                        continue;
                    }
                    
                    if (!VerifyGoodAttribute(node, request.AttributeId, results[ii]))
                    {
                        success = false;
                        continue;                      
                    }
                }
                else if (request.IndexRange != null)
                {
                    if (request.AttributeId != Attributes.Value || (node.NodeClass != NodeClass.Variable && node.NodeClass != NodeClass.VariableType))
                    {
                        if (results[ii].StatusCode != StatusCodes.BadAttributeIdInvalid && results[ii].StatusCode != StatusCodes.BadIndexRangeInvalid)
                        {
                            Log(
                                "IndexRange not valid for non-value attributes '{0}'. NodeId = {1}, Attribute = {2}, StatusCode = {3}",
                                node,
                                node.NodeId,
                                Attributes.GetBrowseName(request.AttributeId),
                                results[ii].StatusCode);

                            success = false;
                            break;
                        }

                        continue; 
                    }
                    
                    // check for variable types with no value.
                    if (node.NodeClass == NodeClass.VariableType)
                    {
                        if (results[ii].StatusCode == StatusCodes.BadAttributeIdInvalid)
                        {
                            continue; 
                        }
                    }
                    
                    // index range can be ignored if the value is null.
                    if (StatusCode.IsGood(results[ii].StatusCode) && results[ii].Value == null)
                    {
                        continue;                      
                    }

                    // check for access errors.
                    if (results[ii].StatusCode == StatusCodes.BadNotReadable || results[ii].StatusCode == StatusCodes.BadUserAccessDenied)
                    {
                        continue;                      
                    }

                    // check the result against the expected data type.
                    IVariableBase variable = node as IVariableBase;
                    BuiltInType type = TypeInfo.GetBuiltInType(variable.DataType, Session.TypeTree);

                    if (variable.ValueRank == ValueRanks.Scalar)
                    {
                        if (!VerifyIndexRangeForScalar(variable, type, results[ii]))
                        {
                            success = false;
                            break;
                        }
                    }
                    else
                    {
                        if (!VerifyIndexRangeForArray(variable, type, request.IndexRange, results[ii]))
                        {
                            success = false;
                            break;
                        }
                    }
                }

                if (request.DataEncoding != null)
                {
                    if (request.AttributeId != Attributes.Value || (node.NodeClass != NodeClass.Variable && node.NodeClass != NodeClass.VariableType))
                    {
                        if (results[ii].StatusCode != StatusCodes.BadAttributeIdInvalid && results[ii].StatusCode != StatusCodes.BadDataEncodingInvalid && results[ii].StatusCode != StatusCodes.BadDataEncodingUnsupported)
                        {
                            Log(
                                "DataEncoding not valid for non-value attributes '{0}'. NodeId = {1}, Attribute = {2}, StatusCode = {3}",
                                node,
                                node.NodeId,
                                Attributes.GetBrowseName(request.AttributeId),
                                results[ii].StatusCode);

                            success = false;
                            break;
                        }

                        continue; 
                    }
                    
                    // check for variable types with no value.
                    if (node.NodeClass == NodeClass.VariableType)
                    {
                        if (results[ii].StatusCode == StatusCodes.BadAttributeIdInvalid)
                        {
                            continue; 
                        }
                    }
                    
                    // data encoding can be ignored if the value is null.
                    if (StatusCode.IsGood(results[ii].StatusCode) && results[ii].Value == null)
                    {
                        continue;                      
                    }

                    // check for access errors.
                    if (results[ii].StatusCode == StatusCodes.BadNotReadable || results[ii].StatusCode == StatusCodes.BadUserAccessDenied)
                    {
                        continue;                      
                    }

                    // check the result against the expected data type.
                    IVariableBase variable = node as IVariableBase;
                    BuiltInType type = TypeInfo.GetBuiltInType(variable.DataType, Session.TypeTree);

                    if (type != BuiltInType.ExtensionObject)
                    {
                        if (!IsDaBadStatus(results[ii].StatusCode))
                        {
                            if (results[ii].StatusCode != StatusCodes.BadDataEncodingInvalid && results[ii].StatusCode != StatusCodes.BadDataEncodingUnsupported)
                            {
                                Log(
                                    "Wrong error code when reading value with data encoding '{0}'. NodeId = {1}, Value = {2}, StatusCode = {3}",
                                    variable,
                                    variable.NodeId,
                                    variable.Value,
                                    results[ii].StatusCode);

                                success = false;
                                break;
                            }
                        }
                    }
                    else
                    {       
                        if (!VerifyDataEncoding(variable, type, request.DataEncoding, results[ii]))
                        {
                            success = false;
                            break;
                        } 
                    }
                }
            }
            
            // check attribute consistency.
            if (success)
            {
                Node current = null;

                for (int ii = 0; ii < nodesToRead.Count; ii++)
                {
                    if (Object.ReferenceEquals(current, nodesToRead[ii].Handle))
                    {
                        continue;
                    }

                    current = (Node)nodesToRead[ii].Handle;

                    if (!VerifyAttributeConsistency(current))
                    {
                        success = false;
                        continue; 
                    }
                }
            }

            return success;
        }
        
        /// <summary>
        /// Reads the attributes, verifies the results and updates the nodes.
        /// </summary>
        private bool Write(WriteValueCollection nodesToWrite)
        {
            bool success = true;

            StatusCodeCollection results;
            DiagnosticInfoCollection diagnosticInfos;
            
            RequestHeader requestHeader = new RequestHeader();
            requestHeader.ReturnDiagnostics = 0;

            Session.Write(
                requestHeader,
                nodesToWrite,
                out results,
                out diagnosticInfos);
            
            ClientBase.ValidateResponse(results, nodesToWrite);
            ClientBase.ValidateDiagnosticInfos(diagnosticInfos, nodesToWrite);
            
            // check diagnostics.
            if (diagnosticInfos != null && diagnosticInfos.Count > 0)
            {
                Log("Returned non-empty DiagnosticInfos array during Write.");
                return false;
            }
            
            // check results.
            for (int ii = 0; ii < nodesToWrite.Count; ii++)
            {
                WriteValue request = nodesToWrite[ii];
                Node node = (Node)request.Handle;
                
                if (results[ii] == StatusCodes.BadNotWritable)
                {
                    IVariable variable = node as IVariable;

                    if (request.AttributeId == Attributes.Value && variable != null && ((variable.UserAccessLevel & AccessLevels.CurrentReadOrWrite) == AccessLevels.CurrentReadOrWrite))
                    {
                        Log(
                            "Write failed when writing a writeable value '{0}'. NodeId = {1}, Value = {2}, StatusCode = {3}",
                            node,
                            node.NodeId,
                            variable.Value,
                            results[ii]);

                        success = false;
                        break;
                    }

                    if (Attributes.IsWriteable(request.AttributeId, node.UserWriteMask))
                    {
                        Log(
                            "Write failed when writing a writeable attribute '{0}'. NodeId = {1}, attribute = {2}, StatusCode = {3}",
                            node,
                            node.NodeId,
                            Attributes.GetBrowseName(request.AttributeId),
                            results[ii]);

                        success = false;
                        break;
                    }

                    continue;
                }

                if (results[ii] == StatusCodes.BadAttributeIdInvalid)
                { 
                    continue;
                }

                if (results[ii] == StatusCodes.BadUserAccessDenied)
                { 
                    continue;
                }

                if (results[ii] == StatusCodes.BadTypeMismatch || results[ii] == StatusCodes.BadOutOfRange)
                {
                    if (request.Value.Value == null && request.IndexRange != null)
                    {
                        continue;
                    }

                    // unreadable values will have a status code for the locally cached value.
                    if (request.Value.Value is StatusCode)
                    {
                        continue;
                    }

                    // allow for byte string and string values to have undocumented syntaxes.
                    if (request.Value.Value is byte[] || request.Value.Value is string)
                    {
                        continue;
                    }
                }

                if (StatusCode.IsBad(results[ii]))
                {
                    if (request.IndexRange != null)
                    {
                        if (results[ii] == StatusCodes.BadWriteNotSupported || results[ii] == StatusCodes.BadIndexRangeInvalid || results[ii] == StatusCodes.BadIndexRangeNoData)
                        {
                            continue;
                        }
                    }

                    if (request.Value.StatusCode != StatusCodes.Good)
                    {
                        if (results[ii] != StatusCodes.BadWriteNotSupported)
                        {
                            Log(
                                "Unexpected error when writing the StatusCode for a Value '{0}'. NodeId = {1}, Attribute = {2}, Value = {3}, StatusCode = {4}",
                                node,
                                node.NodeId,
                                Attributes.GetBrowseName(request.AttributeId),
                                request.Value.WrappedValue, 
                                results[ii]);

                            success = false;
                            break;
                        }

                        continue;
                    }
                    
                    if (request.Value.SourceTimestamp != DateTime.MinValue || request.Value.ServerTimestamp != DateTime.MinValue)
                    {
                        if (results[ii] != StatusCodes.BadWriteNotSupported)
                        {
                            Log(
                                "Unexpected error when writing the Timestamp for a Value '{0}'. NodeId = {1}, Attribute = {2}, Value = {3}, StatusCode = {4}",
                                node,
                                node.NodeId,
                                Attributes.GetBrowseName(request.AttributeId),
                                request.Value.WrappedValue, 
                                results[ii]);

                            success = false;
                            break;
                        }

                        continue;
                    }

                    Log(
                        "Unexpected error when writing a valid Attribute '{0}'. NodeId = {1}, Attribute = {2}, Value = {3}, StatusCode = {4}",
                        node,
                        node.NodeId,
                        Attributes.GetBrowseName(request.AttributeId),
                        request.Value.WrappedValue, 
                        results[ii]);

                    success = false;
                    break;
                }
            }

            return success;
        }

        private bool VerifyDataEncoding(IVariableBase variable, BuiltInType type, QualifiedName dataEncoding, DataValue result)
        {  
            // allow DA status codes to be returned before checking the 
            if (IsDaBadStatus(result.StatusCode))
            {
                return true;
            }

            IList<INode> encodings = Session.NodeCache.Find(
                variable.DataType,
                ReferenceTypeIds.HasEncoding,
                false,
                true);

            if (StatusCode.IsBad(result.StatusCode))
            {
                for (int ii = 0; ii < encodings.Count; ii++)
                {
                    if (encodings[ii].BrowseName == dataEncoding)
                    {
                        Log(
                            "Did not return a valid value for a supported data encoding '{0}'. NodeId = {1}, Value = {2}, StatusCode = {3}",
                            variable,
                            variable.NodeId,
                            variable.Value,
                            result.StatusCode);

                        return false;
                    }
                }

                return true;
            }
                        
            ExtensionObject extension = result.Value as ExtensionObject;

            if (extension != null)
            {
                for (int ii = 0; ii < encodings.Count; ii++)
                {
                    if (encodings[ii].BrowseName == dataEncoding)
                    {
                        if (ExpandedNodeId.ToNodeId(extension.TypeId, Session.NamespaceUris) != encodings[ii].NodeId)
                        {
                            Log(
                                "Did not return value with correct data encoding '{0}'. NodeId = {1}, Expected = {2}, Actual = {3}",
                                variable,
                                variable.NodeId,
                                encodings[ii].NodeId,
                                extension.TypeId);

                            return false;
                        }
                    }
                }
            }
                        
            ExtensionObject[] extensions = result.Value as ExtensionObject[];

            if (extensions != null)
            {
                for (int jj = 0; jj < extensions.Length; jj++)
                {
                    extension = extensions[jj];

                    for (int ii = 0; ii < encodings.Count; ii++)
                    {
                        if (encodings[ii].BrowseName == dataEncoding)
                        {
                            if (ExpandedNodeId.ToNodeId(extension.TypeId, Session.NamespaceUris) != encodings[ii].NodeId)
                            {
                                Log(
                                    "Did not return value with correct data encoding '{0}'. NodeId = {1}, Expected = {2}, Actual = {3}",
                                    variable,
                                    variable.NodeId,
                                    encodings[ii].NodeId,
                                    extension.TypeId);

                                return false;
                            }
                        }
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Checks for a DA quality code value.
        /// </summary>
        private bool IsDaBadStatus(StatusCode statusCode)
        {
            switch (statusCode.CodeBits)
            {
                case StatusCodes.BadConfigurationError:
                case StatusCodes.BadNotConnected:
                case StatusCodes.BadDeviceFailure:
                case StatusCodes.BadSensorFailure:
                case StatusCodes.BadOutOfService:
                {
                    return true;
                }

                default:
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Verifies the index range result for a scalar value.
        /// </summary>
        private bool VerifyIndexRangeForScalar(IVariableBase variable, BuiltInType type, DataValue result)
        {
            // allow DA status codes to be returned before checking the 
            if (IsDaBadStatus(result.StatusCode))
            {
                return true;
            }

            if (result.StatusCode != StatusCodes.BadIndexRangeInvalid)
            {
                if (type != BuiltInType.ByteString && type != BuiltInType.String && type != BuiltInType.Variant)
                {
                    Log(
                        "Wrong error code when reading index range for scalar value '{0}'. NodeId = {1}, Value = {2}, StatusCode = {3}",
                        variable,
                        variable.NodeId,
                        variable.Value,
                        result.StatusCode);

                    return false;
                }

                if (type == BuiltInType.String)
                {
                    string value = result.Value as string;

                    if (value != null && value.Length > 2)
                    {
                        Log(
                            "Too much data return when reading index range for sting value '{0}'. NodeId = {1}, Value = {2}, ReturnedValue = {3}",
                            variable,
                            variable.NodeId,
                            variable.Value,
                            result.Value);

                        return false;
                    }
                }

                if (type == BuiltInType.ByteString)
                {
                    byte[] value = result.Value as byte[];

                    if (value != null && value.Length > 2)
                    {
                        Log(
                            "Too much data return when reading index range for ByteString value '{0}'. NodeId = {1}, Value = {2}, ReturnedValue = {3}",
                            variable,
                            variable.NodeId,
                            variable.Value,
                            result.Value);

                        return false;
                    }
                }

                if (type == BuiltInType.Variant)
                {
                    Array value = result.Value as Array;

                    if (value != null && value.Length > 2)
                    {
                        Log(
                            "Too much data return when reading index range for Variant value '{0}'. NodeId = {1}, Value = {2}, ReturnedValue = {3}",
                            variable,
                            variable.NodeId,
                            variable.Value,
                            result.Value);

                        return false;
                    }
                }
            }
            else
            {
                if (type == BuiltInType.ByteString || type == BuiltInType.String)
                {
                    Log(
                        "Error returned reading index range for ByteString or String value '{0}'. NodeId = {1}, Value = {2}, StatusCode = {3}",
                        variable,
                        variable.NodeId,
                        variable.Value,
                        result.StatusCode);

                    return false;
                }
            }

            return true;
        }
        
        /// <summary>
        /// Verifies the index range result for a scalar value.
        /// </summary>
        private bool VerifyIndexRangeForArray(IVariableBase variable, BuiltInType type, string indexRange, DataValue result)
        {
            // allow DA status codes.
            if (IsDaBadStatus(result.StatusCode))
            {
                return true;
            }

            Array array = result.Value as Array;

            if (array == null)
            {
                if (result.StatusCode != StatusCodes.BadIndexRangeNoData)
                {
                    Log(
                        "Wrong error code when reading index range for array value '{0}'. NodeId = {1}, Value = {2}, StatusCode = {3}",
                        variable,
                        variable.NodeId,
                        variable.Value,
                        result.StatusCode);

                    return false;
                }

                return true;
            }

            if (indexRange == "10000000:20000000")
            {
                Log(
                    "Expected BadIndexRangeNoData for array value '{0}'. NodeId = {1}, Value = {2}, ReturnedValue = {3}",
                    variable,
                    variable.NodeId,
                    variable.Value,
                    result.Value);

                return false;
            }
            
            if (array.Length > 2)
            {
                Log(
                    "Too much data return when reading index range for array value '{0}'. NodeId = {1}, Value = {2}, ReturnedValue = {3}",
                    variable,
                    variable.NodeId,
                    variable.Value,
                    result.Value);

                return false;
            }


            return true;
        }

        /// <summary>
        /// Adds the attributes to the request collection.
        /// </summary>
        private void AddAttributes(
            Node node, 
            ReadValueIdCollection nodesToRead, 
            params uint[] attributeIds)
        {
            if (attributeIds != null)
            {
                for (int ii = 0; ii < attributeIds.Length; ii++)
                {
                    ReadValueId nodeToRead = new ReadValueId();

                    nodeToRead.NodeId = node.NodeId;
                    nodeToRead.AttributeId = attributeIds[ii];
                    nodeToRead.Handle = node;

                    nodesToRead.Add(nodeToRead);
                }
            }
        }

        /// <summary>
        /// Adds index ranges to the collection.
        /// </summary>
        private void AddIndexRanges(
            Node node, 
            ReadValueIdCollection nodesToRead, 
            params uint[] attributeIds)
        {
            if (attributeIds != null)
            {
                for (int ii = 0; ii < attributeIds.Length; ii++)
                {
                    ReadValueId nodeToRead = new ReadValueId();

                    nodeToRead.NodeId = node.NodeId;
                    nodeToRead.AttributeId = attributeIds[ii];
                    nodeToRead.IndexRange = "1:2";
                    nodeToRead.Handle = node;

                    nodesToRead.Add(nodeToRead);
                    
                    nodeToRead = new ReadValueId();

                    nodeToRead.NodeId = node.NodeId;
                    nodeToRead.AttributeId = attributeIds[ii];
                    nodeToRead.IndexRange = "10000000:20000000";
                    nodeToRead.Handle = node;

                    nodesToRead.Add(nodeToRead);
                }
            }
        }

        /// <summary>
        /// Adds index ranges to the collection.
        /// </summary>
        private void AddDataEncodings(
            Node node, 
            ReadValueIdCollection nodesToRead, 
            params uint[] attributeIds)
        {
            if (attributeIds != null)
            {
                for (int ii = 0; ii < attributeIds.Length; ii++)
                {
                    ReadValueId nodeToRead = new ReadValueId();

                    nodeToRead.NodeId = node.NodeId;
                    nodeToRead.AttributeId = attributeIds[ii];
                    nodeToRead.DataEncoding = BrowseNames.DefaultBinary;
                    nodeToRead.Handle = node;

                    nodesToRead.Add(nodeToRead);

                    nodeToRead = new ReadValueId();

                    nodeToRead.NodeId = node.NodeId;
                    nodeToRead.AttributeId = attributeIds[ii];
                    nodeToRead.DataEncoding = BrowseNames.DefaultXml;
                    nodeToRead.Handle = node;

                    nodesToRead.Add(nodeToRead);
                }
            }
        }

        /// <summary>
        /// Adds index ranges to the collection.
        /// </summary>
        private void AddWriteValues(
            Node node, 
            WriteValueCollection nodesToWrite, 
            params uint[] attributeIds)
        {            
            if (attributeIds != null)
            {
                for (int ii = 0; ii < attributeIds.Length; ii++)
                {
                    WriteValue nodeToWrite = new WriteValue();
                
                    nodeToWrite.NodeId = node.NodeId;
                    nodeToWrite.AttributeId = attributeIds[ii];

                    DataValue value = new DataValue();

                    ServiceResult result = node.Read(
                        null,
                        attributeIds[ii],
                        value);
                
                    value.StatusCode = StatusCodes.Good;
                    value.ServerTimestamp = DateTime.MinValue;
                    value.SourceTimestamp = DateTime.MinValue;

                    if (ServiceResult.IsBad(result))
                    {
                        value.Value = null;
                    }

                    nodeToWrite.Value = value;
                    nodeToWrite.Handle = node;

                    nodesToWrite.Add(nodeToWrite);

                    Array array = value.Value as Array;

                    if (array != null)
                    {
                        NumericRange range = new NumericRange(0, 1);

                        object subarray = array;
                        range.ApplyRange(ref subarray);

                        nodeToWrite = new WriteValue();
                
                        nodeToWrite.Value = new DataValue();
                        nodeToWrite.Value.Value = subarray;
                        nodeToWrite.Value.StatusCode = StatusCodes.Good;
                        nodeToWrite.Value.ServerTimestamp = DateTime.MinValue;
                        nodeToWrite.Value.SourceTimestamp = DateTime.MinValue;
                        nodeToWrite.NodeId = node.NodeId;
                        nodeToWrite.AttributeId = attributeIds[ii];
                        nodeToWrite.IndexRange = "0";
                        nodeToWrite.Handle = node;
                    
                        nodesToWrite.Add(nodeToWrite);
                    }

                    nodeToWrite = new WriteValue();
            
                    nodeToWrite.Value = new DataValue();
                    nodeToWrite.Value.Value = value.Value;
                    nodeToWrite.Value.StatusCode = StatusCodes.Uncertain;
                    nodeToWrite.Value.ServerTimestamp = DateTime.MinValue;
                    nodeToWrite.Value.SourceTimestamp = DateTime.MinValue;
                    nodeToWrite.NodeId = node.NodeId;
                    nodeToWrite.AttributeId = attributeIds[ii];
                    nodeToWrite.Handle = node;
                
                    nodesToWrite.Add(nodeToWrite);

                    nodeToWrite = new WriteValue();
            
                    nodeToWrite.Value = new DataValue();
                    nodeToWrite.Value.Value = value.Value;
                    nodeToWrite.Value.StatusCode = StatusCodes.Good;
                    nodeToWrite.Value.ServerTimestamp = DateTime.UtcNow;
                    nodeToWrite.Value.SourceTimestamp = DateTime.MinValue;
                    nodeToWrite.NodeId = node.NodeId;
                    nodeToWrite.AttributeId = attributeIds[ii];
                    nodeToWrite.Handle = node;
                
                    nodesToWrite.Add(nodeToWrite);

                    nodeToWrite = new WriteValue();
            
                    nodeToWrite.Value = new DataValue();
                    nodeToWrite.Value.Value = value.Value;
                    nodeToWrite.Value.StatusCode = StatusCodes.Good;
                    nodeToWrite.Value.ServerTimestamp = DateTime.MinValue;
                    nodeToWrite.Value.SourceTimestamp = DateTime.UtcNow;
                    nodeToWrite.NodeId = node.NodeId;
                    nodeToWrite.AttributeId = attributeIds[ii];
                    nodeToWrite.Handle = node;
                
                    nodesToWrite.Add(nodeToWrite);
                }
            }
        }
        
    }
}
