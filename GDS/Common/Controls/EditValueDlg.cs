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

namespace Opc.Ua.Gds
{
    /// <summary>
    /// Prompts the user to edit a value.
    /// </summary>
    public partial class EditValueDlg : Form
    {
        #region Constructors
        /// <summary>
        /// Creates an empty form.
        /// </summary>
        public EditValueDlg()
        {
            InitializeComponent();

            for (BuiltInType ii = BuiltInType.Boolean; ii <= BuiltInType.StatusCode; ii++)
            {
                SetTypeCB.Items.Add(ii);
            }

            SetTypeCB.SelectedItem = BuiltInType.String;
        }
        #endregion
      
        #region Private Fields
        #endregion

        #region Public Interface
        /// <summary>
        /// Prompts the user to edit the value.
        /// </summary>
        public object ShowDialog(
            TypeInfo expectedType,
            string name,
            object value,
            bool readOnly,
            string caption)
        {
            if (!String.IsNullOrEmpty(caption))
            {
                this.Text = caption;
            }

            OkBTN.Visible = true;

            ValueCTRL.ShowValue(expectedType, name, value, readOnly);

            if (base.ShowDialog() != DialogResult.OK)
            {
                return null;
            }

            return ValueCTRL.GetValue();
        }
        #endregion

        #region Event Handlers
        private void ValueCTRL_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                BackBTN.Visible = ValueCTRL.CanGoBack;
                SetTypeCB.Visible = ValueCTRL.CanChangeType;
                SetTypeCB.SelectedItem = ValueCTRL.CurrentType;
                SetArraySizeBTN.Visible = ValueCTRL.CanSetArraySize;
            }
            catch (Exception exception)
            {
                Opc.Ua.Configuration.ExceptionDlg.Show(this.Text, exception);
            }
        }

        private void BackBTN_Click(object sender, EventArgs e)
        {
            try
            {
                ValueCTRL.Back();
            }
            catch (Exception exception)
            {
                Opc.Ua.Configuration.ExceptionDlg.Show(this.Text, exception);
            }
        }

        private void OkBTN_Click(object sender, EventArgs e)
        {
            try
            {
                ValueCTRL.EndEdit();
                DialogResult = DialogResult.OK;
            }
            catch (Exception exception)
            {
                Opc.Ua.Configuration.ExceptionDlg.Show(this.Text, exception);
            }
        }

        private void SetTypeBTN_Click(object sender, EventArgs e)
        {
            try
            {
                ValueCTRL.SetArraySize();
            }
            catch (Exception exception)
            {
                Opc.Ua.Configuration.ExceptionDlg.Show(this.Text, exception);
            }
        }

        private void SetTypeCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ValueCTRL.SetType((BuiltInType)SetTypeCB.SelectedItem);
            }
            catch (Exception exception)
            {
                Opc.Ua.Configuration.ExceptionDlg.Show(this.Text, exception);
            }
        }
        #endregion
    }
}
