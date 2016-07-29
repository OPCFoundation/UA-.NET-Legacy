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
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

using Opc.Ua.Client.Controls;

namespace Opc.Ua.Configuration
{
    /// <summary>
    /// Prompts the user to edit a ApplicationDescription.
    /// </summary>
    public partial class AccessRuleListDlg : Form
    {
        public AccessRuleListDlg()
        {
            InitializeComponent();

            InstructionsTB.Text =
            "The access rules displayed in this dialog are simplified versions of the operating system access rights. " +
            "If applied they will be mapped to the appropriate combination of operating system access rights.";
        }

        private List<string> m_objectPaths;

        /// <summary>
        /// Displays the dialog.
        /// </summary>
        public bool ShowDialog(IList<SecuredObject> objectTypes, IList<string> objectPaths)
        {
            ObjectTypeCB.Items.Clear();
            m_objectPaths = new List<string>();

            if (objectTypes != null && objectPaths != null)
            {
                for (int ii = 0; ii < objectTypes.Count; ii++)
                {
                    if (ii < objectPaths.Count && !String.IsNullOrEmpty(objectPaths[ii]))
                    {
                        ObjectTypeCB.Items.Add(objectTypes[ii]);
                        m_objectPaths.Add(objectPaths[ii]);
                    }
                }
            }

            if (ObjectTypeCB.Items.Count > 0)
            {
                ObjectTypeCB.SelectedIndex = 0;
            }

            if (ShowDialog() != DialogResult.OK)
            {
                return false;
            }

            return true;
        }
        
        private void OkBTN_Click(object sender, EventArgs e)
        {
            try
            {
                IList<ApplicationAccessRule> rules = AccessRulesCTRL.GetAccessRules();
                ApplicationAccessRule.SetAccessRules(ObjectPathTB.Text, rules, true);
                AccessRulesCTRL.Initialize((SecuredObject)ObjectTypeCB.SelectedItem, ObjectPathTB.Text);

                if (sender == OkBTN)
                {
                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void ObjectTypeCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ObjectTypeCB.SelectedIndex < m_objectPaths.Count)
                {
                    ObjectPathTB.Text = m_objectPaths[ObjectTypeCB.SelectedIndex];
                    AccessRulesCTRL.Initialize((SecuredObject)ObjectTypeCB.SelectedItem, ObjectPathTB.Text);
                }
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void ApplyAllBTN_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder buffer = new StringBuilder();
                buffer.Append("The following objects will be affected:");
                buffer.Append("\r\n\r\n");

                foreach (SecuredObject objectType in ObjectTypeCB.Items)
                {
                    buffer.Append(objectType);
                    buffer.Append("\r\n");
                }

                buffer.Append("\r\n");
                buffer.Append("Are you sure you would like to apply access control changes to all of the objects listed above?");

                if (new YesNoDlg().ShowDialog(buffer.ToString(), "Confirm Access Rule Changes") != DialogResult.Yes)
                {
                    return;
                }

                IList<ApplicationAccessRule> rules = AccessRulesCTRL.GetAccessRules();

                for (int ii = 0; ii < m_objectPaths.Count; ii++)
                {
                    ApplicationAccessRule.SetAccessRules(m_objectPaths[ii], rules, true);
                }

                AccessRulesCTRL.Initialize((SecuredObject)ObjectTypeCB.SelectedItem, ObjectPathTB.Text);
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }
    }
}
