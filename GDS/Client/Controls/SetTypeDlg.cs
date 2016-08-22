/* Copyright (c) 1996-2016, OPC Foundation. All rights reserved.

   The source code in this file is covered under a dual-license scenario:
     - RCL: for OPC Foundation members in good-standing
     - GPL V2: everybody else

   RCL license terms accompanied with this source code. See http://opcfoundation.org/License/RCL/1.00/

   GNU General Public License as published by the Free Software Foundation;
   version 2 of the License are accompanied with this source code. See http://opcfoundation.org/License/GPLv2

   This source code is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
*/

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using Opc.Ua;

namespace Opc.Ua.GdsClient
{
    /// <summary>
    /// Prompts the user to select an area to use as an event filter.
    /// </summary>
    public partial class SetTypeDlg : Form
    {
        #region Constructors
        /// <summary>
        /// Creates an empty form.
        /// </summary>
        public SetTypeDlg()
        {
            InitializeComponent();

            ErrorHandlingCB.Items.Add("Use Default Value");
            ErrorHandlingCB.Items.Add("Throw Exception");
        }
        #endregion
        
        #region Private Fields
        private SetTypeResult m_result;
        private TypeInfo m_typeInfo;
        #endregion

        #region SetTypeResult Class
        /// <summary>
        /// The values updated by the dialog.
        /// </summary>
        public class SetTypeResult
        {
            /// <summary>
            /// The new type info.
            /// </summary>
            public TypeInfo TypeInfo { get; set; }

            /// <summary>
            /// The data type id for structured types.
            /// </summary>
            public NodeId DataTypeId { get; set; }

            /// <summary>
            /// The dimensions for array types.
            /// </summary>
            public int[] ArrayDimensions { get; set; }

            /// <summary>
            /// If true then the default value will be used if a conversion error occurs.
            /// </summary>
            public bool UseDefaultOnError { get; set; }
        }
        #endregion

        #region Public Interface
        /// <summary>
        /// Displays the available areas in a tree view.
        /// </summary>
        public SetTypeResult ShowDialog(TypeInfo typeInfo, int[] dimensions)
        {
            m_typeInfo = typeInfo;

            StructureTypeLB.Visible = false;
            StructureTypeTB.Visible = false;
            ArrayDimensionsLB.Visible = dimensions != null;
            ArrayDimensionsTB.Visible = dimensions != null;

            ErrorHandlingCB.SelectedIndex = 0;
                        
            StringBuilder builder = new StringBuilder();

            // display the current dimensions.
            if (typeInfo.ValueRank >= 0 && dimensions != null)
            {
                for (int ii = 0; ii < dimensions.Length; ii++)
                {
                    if (builder.Length > 0)
                    {
                        builder.Append(", ");
                    }

                    builder.Append(dimensions[ii]);
                }
            }

            ArrayDimensionsTB.Text = builder.ToString();

            // display the dialog.
            if (base.ShowDialog() != DialogResult.OK)
            {
                return null;
            }

            return m_result;
        }
        #endregion
        
        #region Private Methods
        #endregion

        #region Event Handlers
        private void OkBTN_Click(object sender, EventArgs e)
        {
            try
            {
                // parse the array dimensions.
                string text = ArrayDimensionsTB.Text.Trim();
                List<int> dimensions = new List<int>();

                if (!String.IsNullOrEmpty(text))
                {
                    int dimension = 0;
                    const string digits = "0123456789";

                    for (int ii = 0; ii < text.Length; ii++)
                    {
                        if (Char.IsWhiteSpace(text, ii))
                        {
                            continue;
                        }

                        if (text[ii] == ',')
                        {
                            dimensions.Add(dimension);
                            dimension = 0;
                            continue;
                        }

                        if (!Char.IsDigit(text, ii))
                        {
                            throw new FormatException("Invalid character in array index. Use numbers seperated by commas.");
                        }

                        dimension *= 10;
                        dimension += digits.IndexOf(text[ii]);
                    }

                    dimensions.Add(dimension);
                }
                
                // save the result.
                int valueRank = (dimensions.Count < 1) ? ValueRanks.Scalar : dimensions.Count;

                m_result = new SetTypeResult();
                m_result.TypeInfo = new TypeInfo(m_typeInfo.BuiltInType, valueRank);
                m_result.ArrayDimensions = dimensions.ToArray();
                m_result.UseDefaultOnError = ErrorHandlingCB.SelectedIndex == 0;

                /*
                if (m_typeInfo.BuiltInType == BuiltInType.ExtensionObject)
                {
                    m_result.DataTypeId = StructureTypeBTN.SelectedNode;
                }
                */

                DialogResult = DialogResult.OK;
            }
            catch (Exception exception)
            {
                Opc.Ua.Configuration.ExceptionDlg.Show(this.Text, exception);
            }
        }
        #endregion
    }
}
