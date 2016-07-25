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
    internal class WriteTest : TestBase
    {
        #region Constructors
        /// <summary>
        /// Creates the test object.
        /// </summary>
        public WriteTest(
            Session session,
            ServerTestConfiguration configuration,
            ReportMessageEventHandler reportMessage,
            ReportProgressEventHandler reportProgress,
            TestBase template)
        : 
            base("Write", session, configuration, reportMessage, reportProgress, template)
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
            try
            {
                LockServer();

                Iteration = iteration;

                if (ReadOnlyTests)
                {
                    Log("WARNING: TestCase {0} skipped because client could not acquire a lock on the Server.", testcase.Name);
                    return true;
                }

                // need fetch nodes used for the test if not already available.
                if (AvailableNodes.Count == 0)
                {
                    if (!GetNodesInHierarchy())
                    {
                        return false;
                    }
                }

                // get the writeable variables.
                if (WriteableVariables.Count == 0)
                {
                    if (!GetWriteableVariablesInHierarchy())
                    {
                        Log("WARNING: No writeable variables found.");
                        Log(g_WriteableVariableHelpText);
                        return true;
                    }
                }

                // do secondary test.
                switch (testcase.Name)
                {
                    case "TypeMismatch":
                    {
                        return DoWriteBadTypeTest();
                    }

                    default:
                    {
                        return DoWriteTest();
                    }
                }
            }
            finally
            {
                UnlockServer();
            }
        }        
        #endregion
        
        private class TestVariable
        {
            public VariableNode Variable;
            public BuiltInType DataType;
            public List<DataValue> Values;
        }

        public const string g_WriteableVariableHelpText = 
            "This test requires that a Server provide writeable variables\r\n" +
            "which do not change unless written to. The test client application\r\n" +
            "looks for Nodes within the set of Nodes returned in the Browse/Hierarchial Test\r\n" +
            "that have a BrowseName of static or are specified in the writeable variables list.\r\n" +
            "Any variables found as direct or indirect children of these Nodes are assumed to behave as required.";

        #region Test Methods
        /// <summary>
        /// Reads an verifies all of the nodes.
        /// </summary>
        private bool DoWriteTest()
        {
            // follow tree from each starting node.
            bool success = true;

            // collection writeable variables that don't change during the test.
            List<TestVariable> variables = new List<TestVariable>();

            for (int ii = 0; ii < WriteableVariables.Count; ii++)
            {
                TestVariable test = new TestVariable();

                test.Variable = WriteableVariables[ii];
                test.DataType = TypeInfo.GetBuiltInType(WriteableVariables[ii].DataType, Session.TypeTree);
                test.Values = new List<DataValue>();

                variables.Add(test);
            }

            Log("Starting WriteTest for {0} Nodes", variables.Count);
            
            double increment = MaxProgress/(10*variables.Count);
            double position  = 0;

            WriteValueCollection nodesToWrite = new WriteValueCollection();
            
            for (int ii = 0; success && ii < 10; ii++)
            {
                int nodes = 0;
                int operations = 0;

                foreach (TestVariable variable in variables)
                {          
                    variable.Values.Clear();

                    nodes++;

                    AddWriteValues(variable, nodesToWrite);

                    // process batch.
                    if (nodesToWrite.Count > BlockSize/2)
                    {
                        operations += nodesToWrite.Count;

                        if (!Write(nodesToWrite))
                        {
                            success = false;
                            break;
                        }

                        if (nodes > (10*variables.Count)/5)
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
                        
                        nodesToWrite.Clear();
                    }
                }
            }

            return success;
        }

        /// <summary>
        /// Reads an verifies all of the nodes.
        /// </summary>
        private bool DoWriteBadTypeTest()
        {
            // follow tree from each starting node.
            bool success = true;

            // collection writeable variables that don't change during the test.
            List<TestVariable> variables = new List<TestVariable>();

            for (int ii = 0; ii < WriteableVariables.Count; ii++)
            {
                TestVariable test = new TestVariable();

                test.Variable = WriteableVariables[ii];
                test.DataType = TypeInfo.GetBuiltInType(WriteableVariables[ii].DataType, Session.TypeTree);
                test.Values = new List<DataValue>();

                variables.Add(test);
            }

            Log("Starting WriteBadTypeTest for {0} Nodes", variables.Count);
            
            double increment = MaxProgress/variables.Count;
            double position  = 0;

            WriteValueCollection nodesToWrite = new WriteValueCollection();
            
            int nodes = 0;
            int operations = 0;

            foreach (TestVariable variable in variables)
            {               
                nodes++;

                AddWriteBadValues(variable, nodesToWrite);

                // process batch.
                if (nodesToWrite.Count > 100)
                {
                    operations += nodesToWrite.Count;

                    if (!WriteBadValues(nodesToWrite))
                    {
                        success = false;
                        break;
                    }

                    if (nodes > variables.Count/5)
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

                    if (!WriteBadValues(nodesToWrite))
                    {
                        success = false;
                    }
                    else
                    {
                        Log("Wrote {0} attribute values for {1} nodes.", operations, nodes);
                    }

                    nodesToWrite.Clear();
                }
            }

            return success;
        }
        #endregion

        /// <summary>
        /// Reads the attributes, verifies the results and updates the nodes.
        /// </summary>
        private bool Write(WriteValueCollection nodesToWrite)
        {
            bool success = true;

            StatusCodeCollection results = null;
            DiagnosticInfoCollection diagnosticInfos = null;

            RequestHeader requestHeader = new RequestHeader();
            requestHeader.ReturnDiagnostics = 0;

            try
            {
                Session.Write(
                    requestHeader,
                    nodesToWrite,
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
            
            ClientBase.ValidateResponse(results, nodesToWrite);
            ClientBase.ValidateDiagnosticInfos(diagnosticInfos, nodesToWrite);
            
            // check diagnostics.
            if (diagnosticInfos != null && diagnosticInfos.Count > 0)
            {
                Log("Returned non-empty DiagnosticInfos array during Write.");
                return false;
            }
            
            // check results.
            ReadValueIdCollection nodesToRead = new ReadValueIdCollection();

            for (int ii = 0; ii < nodesToWrite.Count; ii++)
            {
                WriteValue request = nodesToWrite[ii];
                TestVariable variable = (TestVariable)request.Handle;

                if (results[ii] == StatusCodes.BadUserAccessDenied)
                {
                    continue;
                }

                if (results[ii] == StatusCodes.BadNotWritable)
                {
                    Log(
                        "Write failed when writing a writeable value '{0}'. NodeId = {1}, Value = {2}, StatusCode = {3}",
                        variable.Variable,
                        variable.Variable.NodeId,
                        request.Value.WrappedValue,
                        results[ii]);

                    success = false;
                    break;
                }

                if (StatusCode.IsBad(results[ii]))
                {
                    if (request.Value.StatusCode != StatusCodes.Good)
                    {
                        if (results[ii] != StatusCodes.BadWriteNotSupported)
                        {
                            Log(
                                "Unexpected error when writing the StatusCode for a Value '{0}'. NodeId = {1}, Value = {2}, StatusCode = {3}",
                                variable.Variable,
                                variable.Variable.NodeId,
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
                                "Unexpected error when writing the Timestamp for a Value '{0}'. NodeId = {1}, Value = {2}, StatusCode = {3}",
                                variable.Variable,
                                variable.Variable.NodeId,
                                request.Value.WrappedValue, 
                                results[ii]);

                            success = false;
                            break;
                        }

                        continue;
                    }

                    if (results[ii] != StatusCodes.BadTypeMismatch && results[ii] != StatusCodes.BadOutOfRange)
                    {
                        Log(
                            "Unexpected error when writing a valid value '{0}'. NodeId = {1}, Value = {2}, StatusCode = {3}",
                            variable.Variable,
                            variable.Variable.NodeId,
                            request.Value.WrappedValue, 
                            results[ii]);

                        success = false;
                        break;
                    }

                    continue;
                }
                
                ReadValueId nodeToRead = new ReadValueId();
                
                nodeToRead.NodeId = request.NodeId;
                nodeToRead.AttributeId = request.AttributeId;
                nodeToRead.IndexRange = request.IndexRange;
                nodeToRead.Handle = request.Handle;

                nodesToRead.Add(nodeToRead);
            }
            
            // skip read back on failed.
            if (!success)
            {
                return success;
            }

            // check if nothing more do to.
            if (nodesToRead.Count == 0)
            {
                return true;
            }

            requestHeader = new RequestHeader();
            requestHeader.ReturnDiagnostics = 0;

            DataValueCollection values = new DataValueCollection();

            try
            {
                Session.Read(
                    requestHeader,
                    0,
                    TimestampsToReturn.Both,
                    nodesToRead,
                    out values,
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
            
            ClientBase.ValidateResponse(values, nodesToRead);
            ClientBase.ValidateDiagnosticInfos(diagnosticInfos, nodesToRead);
            
            // check diagnostics.
            if (diagnosticInfos != null && diagnosticInfos.Count > 0)
            {
                Log("Returned non-empty DiagnosticInfos array during Read.");
                return false;
            }

            for (int ii = 0; ii < nodesToRead.Count; ii++)
            {
                ReadValueId request = nodesToRead[ii];
                TestVariable variable = (TestVariable)request.Handle;
                DataValue valueWritten = variable.Values[variable.Values.Count-1];
                                
                if (StatusCode.IsBad(values[ii].StatusCode) && StatusCode.IsNotBad(valueWritten.StatusCode))
                {
                    Log(
                        "Could not read back the value written '{0}'. NodeId = {1}, Value = {2}, StatusCode = {3}",
                        variable.Variable,
                        variable.Variable.NodeId,
                        valueWritten.WrappedValue, 
                        values[ii].StatusCode);

                    success = false;
                    break;
                }

                Opc.Ua.Test.DataComparer comparer = new Opc.Ua.Test.DataComparer(Session.MessageContext);
                comparer.ThrowOnError = false;

                if (!comparer.CompareVariant(values[ii].WrappedValue, valueWritten.WrappedValue))
                {
                    Log(
                        "Read back value does not match the value written '{0}'. NodeId = {1}, Value = {2}, ReadValue = {3}",
                        variable.Variable,
                        variable.Variable.NodeId,
                        valueWritten.WrappedValue, 
                        values[ii].WrappedValue);

                    success = false;
                    break;
                }

                if (valueWritten.StatusCode != StatusCodes.Good)
                {
                    if (values[ii].StatusCode != valueWritten.StatusCode)
                    {
                        Log(
                            "Read back StatusCode does not match the StatusCode written '{0}'. NodeId = {1}, StatusCode = {2}, ReadStatusCode = {3}",
                            variable.Variable,
                            variable.Variable.NodeId,
                            valueWritten.StatusCode, 
                            values[ii].StatusCode);

                        success = false;
                        break;
                    }
                }

                if (valueWritten.SourceTimestamp != DateTime.MinValue)
                {
                    if (values[ii].SourceTimestamp != valueWritten.SourceTimestamp)
                    {
                        Log(
                            "Read back ServerTimestamp does not match the ServerTimestamp written '{0}'. NodeId = {1}, Timestamp = {2}, ReadTimestamp = {3}",
                            variable.Variable,
                            variable.Variable.NodeId,
                            valueWritten.SourceTimestamp, 
                            values[ii].SourceTimestamp);

                        success = false;
                        break;
                    }
                }
            }

            return success;
        }
        
        /// <summary>
        /// Reads the attributes, verifies the results and updates the nodes.
        /// </summary>
        private bool WriteBadValues(WriteValueCollection nodesToWrite)
        {
            bool success = true;

            StatusCodeCollection results;
            DiagnosticInfoCollection diagnosticInfos;
            
            RequestHeader requestHeader = new RequestHeader();
            requestHeader.ReturnDiagnostics = 0;
            
            try
            {
                Session.Write(
                    requestHeader,
                    nodesToWrite,
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
            
            ClientBase.ValidateResponse(results, nodesToWrite);
            ClientBase.ValidateDiagnosticInfos(diagnosticInfos, nodesToWrite);
            
            // check diagnostics.
            if (diagnosticInfos != null && diagnosticInfos.Count > 0)
            {
                Log("Returned non-empty DiagnosticInfos array during Write.");
                return false;
            }
            
            // check results.
            ReadValueIdCollection nodesToRead = new ReadValueIdCollection();

            for (int ii = 0; ii < nodesToWrite.Count; ii++)
            {
                WriteValue request = nodesToWrite[ii];
                TestVariable variable = (TestVariable)request.Handle;
                
                // allow access denied even if the node was theorectically writeable.
                if (results[ii] == StatusCodes.BadUserAccessDenied)
                {
                    continue;
                }

                if (results[ii] == StatusCodes.BadNotWritable)
                {
                    Log(
                        "Write failed when writing a writeable value '{0}'. NodeId = {1}, Value = {2}, StatusCode = {3}",
                        variable.Variable,
                        variable.Variable.NodeId,
                        request.Value.WrappedValue,
                        results[ii]);

                    success = false;
                    break;
                }
                
                TypeInfo typeInfo = TypeInfo.IsInstanceOfDataType(
                    request.Value.Value,
                    variable.Variable.DataType,
                    variable.Variable.ValueRank,
                    Session.NamespaceUris,
                    Session.TypeTree);

                if (typeInfo != null)
                {
                    if (results[ii] != StatusCodes.Good && results[ii] != StatusCodes.BadTypeMismatch && results[ii] != StatusCodes.BadOutOfRange)
                    {
                        Log(
                            "Unexpected error when writing a valid value for a Variable '{0}'. NodeId = {1}, Value = {2}, StatusCode = {3}",
                            variable.Variable,
                            variable.Variable.NodeId,
                            request.Value.WrappedValue, 
                            results[ii]);

                        success = false;
                        break;
                    }
                        
                    continue;
                }

                if (results[ii] != StatusCodes.BadTypeMismatch && results[ii] != StatusCodes.BadOutOfRange)
                {
                    Log(
                        "Unexpected error when writing a bad value for a Variable '{0}'. NodeId = {1}, Value = {2}, StatusCode = {3}",
                        variable.Variable,
                        variable.Variable.NodeId,
                        request.Value.WrappedValue, 
                        results[ii]);

                    success = false;
                    break;
                }
            }
            
            return success;
        }

        /// <summary>
        /// Adds random values to write.
        /// </summary>
        private void AddWriteValues(
            TestVariable variable, 
            WriteValueCollection nodesToWrite)
        {            
            WriteValue nodeToWrite = new WriteValue();
        
            nodeToWrite.NodeId = variable.Variable.NodeId;
            nodeToWrite.AttributeId = Attributes.Value;

            DataValue value = new DataValue();
            
            value.Value = m_generator.GetRandom(
                variable.Variable.DataType,
                variable.Variable.ValueRank,
                variable.Variable.ArrayDimensions,
                Session.TypeTree);
                
            value.StatusCode = StatusCodes.Good;
            value.ServerTimestamp = DateTime.MinValue;
            value.SourceTimestamp = DateTime.MinValue;

            variable.Values.Add(value);

            nodeToWrite.Value = value;
            nodeToWrite.Handle = variable;

            nodesToWrite.Add(nodeToWrite);
        }

        /// <summary>
        /// Adds random values to write.
        /// </summary>
        private void AddWriteBadValues(
            TestVariable variable, 
            WriteValueCollection nodesToWrite)
        {           
            for (BuiltInType ii = BuiltInType.Null; ii < BuiltInType.DataValue; ii++)
            {
                if (variable.DataType != ii || variable.Variable.ValueRank >= 0)
                {
                    // add random scalar.
                    WriteValue nodeToWrite = new WriteValue();
                
                    nodeToWrite.NodeId = variable.Variable.NodeId;
                    nodeToWrite.AttributeId = Attributes.Value;

                    DataValue value = new DataValue();
                    
                    value.Value = m_generator.GetRandom(ii);                        
                    value.StatusCode = StatusCodes.Good;
                    value.ServerTimestamp = DateTime.MinValue;
                    value.SourceTimestamp = DateTime.MinValue;

                    variable.Values.Add(value);

                    nodeToWrite.Value = value;
                    nodeToWrite.Handle = variable;

                    nodesToWrite.Add(nodeToWrite);
                }

                if (variable.DataType != ii || variable.Variable.ValueRank == ValueRanks.Scalar)
                {
                    // add random array.
                    WriteValue nodeToWrite = new WriteValue();
                
                    nodeToWrite.NodeId = variable.Variable.NodeId;
                    nodeToWrite.AttributeId = Attributes.Value;

                    DataValue value = new DataValue();
                    
                    value.Value = m_generator.GetRandomArray(ii, true, 100, false);                        
                    value.StatusCode = StatusCodes.Good;
                    value.ServerTimestamp = DateTime.MinValue;
                    value.SourceTimestamp = DateTime.MinValue;

                    variable.Values.Add(value);

                    nodeToWrite.Value = value;
                    nodeToWrite.Handle = variable;

                    nodesToWrite.Add(nodeToWrite);
                }
            }
        }
    }
}
