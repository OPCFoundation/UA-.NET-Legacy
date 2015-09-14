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
using System.Windows.Forms;
using System.Text;
using Opc.Ua;
using Opc.Ua.Client;
using Opc.Ua.Client.Controls;

namespace TutorialClient
{
    /// <summary>
    /// Prompts the user to edit a value.
    /// </summary>
    public partial class WriteValueDlg : Form
    {
        #region Constructors
        /// <summary>
        /// Creates an empty form.
        /// </summary>
        public WriteValueDlg()
        {
            InitializeComponent();
        }
        #endregion
        
        #region Private Fields
        private Session m_session;
        private NodeId m_nodeId;
        private TypeInfo m_sourceType;
        private Variant m_value;
        #endregion
        
        #region Public Interface
        /// <summary>
        /// Prompts the user to edit a value.
        /// </summary>
        public Variant ShowDialog(Session session, NodeId nodeId)
        {
            m_session = session;
            m_nodeId = nodeId;

            #region Task #B2 - Write Value
            // generate a default value based on the data type.
            m_value = Variant.Null;
            m_sourceType = GetExpectedType(session, nodeId);

            if (m_sourceType != null)
            {
                m_value = new Variant(TypeInfo.GetDefaultValue(m_sourceType.BuiltInType), m_sourceType);
            }

            // cast the value to a string.
            ValueTB.Text = (string)TypeInfo.Cast(m_value.Value, m_value.TypeInfo, BuiltInType.String);
            #endregion

            if (ShowDialog() != DialogResult.OK)
            {
                return Variant.Null;
            }

            return m_value;
        }
        #endregion

        #region Task #B2 - Write Value
        /// <summary>
        /// Returns the expected data type.
        /// </summary>
        private TypeInfo GetExpectedType(Session session, NodeId nodeId)
        {
            // build list of attributes to read.
            ReadValueIdCollection nodesToRead = new ReadValueIdCollection();

            foreach (uint attributeId in new uint[] { Attributes.DataType, Attributes.ValueRank })
            {
                ReadValueId nodeToRead = new ReadValueId();
                nodeToRead.NodeId = nodeId;
                nodeToRead.AttributeId = attributeId;
                nodesToRead.Add(nodeToRead);
            }

            // read the attributes.
            DataValueCollection results = null;
            DiagnosticInfoCollection diagnosticInfos = null;

            session.Read(
                null,
                0,
                TimestampsToReturn.Neither,
                nodesToRead,
                out results,
                out diagnosticInfos);

            ClientBase.ValidateResponse(results, nodesToRead);
            ClientBase.ValidateDiagnosticInfos(diagnosticInfos, nodesToRead);

            // this call checks for error and checks the data type of the value.
            // if an error or mismatch occurs the default value is returned.
            NodeId dataTypeId = results[0].GetValue<NodeId>(null);
            int valueRank = results[1].GetValue<int>(ValueRanks.Scalar);

            // use the local type cache to look up the base type for the data type.
            BuiltInType builtInType = DataTypes.GetBuiltInType(dataTypeId, session.NodeCache.TypeTree);

            // the type info object is used in cast and compare functions.
            return new TypeInfo(builtInType, valueRank);
        }

        /// <summary>
        /// Writes the value
        /// </summary>
        private Variant WriteValue(Session session, NodeId nodeId)
        {
            // cast the value to a string.
            object value = TypeInfo.Cast(ValueTB.Text, TypeInfo.Scalars.String, m_sourceType.BuiltInType);

            // build list of attributes to read.
            WriteValueCollection nodesToWrite = new WriteValueCollection();

            WriteValue nodeToWrite = new WriteValue();
            nodeToWrite.NodeId = nodeId;
            nodeToWrite.AttributeId = Attributes.Value;

            // using the WrappedValue instead of the Value property because we know the TypeInfo.
            // this makes the assignment more efficient by avoiding reflection to determine type.
            nodeToWrite.Value.WrappedValue = new Variant(value, m_sourceType);

            nodesToWrite.Add(nodeToWrite);

            // override the diagnostic masks (other parameters are set to defaults).
            RequestHeader requestHeader = new RequestHeader();
            requestHeader.ReturnDiagnostics = (uint)DiagnosticsMasks.All;

            // read the attributes.
            StatusCodeCollection results = null;
            DiagnosticInfoCollection diagnosticInfos = null;

            ResponseHeader responseHeader = session.Write(
                requestHeader,
                nodesToWrite,
                out results,
                out diagnosticInfos);

            ClientBase.ValidateResponse(results, nodesToWrite);
            ClientBase.ValidateDiagnosticInfos(diagnosticInfos, nodesToWrite);

            // check status.
            if (StatusCode.IsBad(results[0]))
            {
                // embed the diagnostic information in a exception.
                throw ServiceResultException.Create(results[0], 0, diagnosticInfos, responseHeader.StringTable);
            }

            // return valid value.
            return nodeToWrite.Value.WrappedValue;
        }
        #endregion
        #region Private Methods
        #endregion

        #region Event Handlers
        /// <summary>
        /// Handles the click event for the OK button.
        /// </summary>
        private void OkBTN_Click(object sender, EventArgs e)
        {
            try
            {
                #region Task #B2 - Write Value
                Variant value = WriteValue(m_session, m_nodeId);
                m_value = value;
                #endregion

                DialogResult = DialogResult.OK;
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }
        #endregion
    }
}
