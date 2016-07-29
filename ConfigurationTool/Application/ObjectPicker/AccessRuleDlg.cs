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
using System.Security.Principal;
using CubicOrange.Windows.Forms.ActiveDirectory;

using Opc.Ua.Client.Controls;
using Opc.Ua.Configuration;

namespace Opc.Ua.Configuration
{
    /// <summary>
    /// Prompts the user to specify a new access rule for a file.
    /// </summary>
    public partial class AccessRuleDlg : Form
    {
        #region Constructors
        /// <summary>
        /// Initializes the dialog.
        /// </summary>
        public AccessRuleDlg()
        {
            InitializeComponent();
            
            AccessTypeCB.Items.Add(AccessControlType.Allow);
            AccessTypeCB.Items.Add(AccessControlType.Deny);
            
            AccessRightCB.Items.Add(ApplicationAccessRight.Run);
            AccessRightCB.Items.Add(ApplicationAccessRight.Update);
            AccessRightCB.Items.Add(ApplicationAccessRight.Configure);
        }
        #endregion
        
        #region Private Fields
        IdentityReference m_identity;
        #endregion
        
        #region Public Interface
        /// <summary>
        /// Displays the dialog.
        /// </summary>
        public bool ShowDialog(ApplicationAccessRule accessRule)
        {
            AccessTypeCB.SelectedItem = accessRule.RuleType;
            IdentityNameTB.Text = accessRule.IdentityName;
            m_identity = accessRule.IdentityReference;

            if (m_identity == null)
            {
                AccountInfo account = AccountInfo.Create(IdentityNameTB.Text);

                if (account != null)
                {
                    m_identity = account.GetIdentityReference();
                }
            }

            if (accessRule.Right != ApplicationAccessRight.None)
            {
                AccessRightCB.SelectedItem = accessRule.Right;
            }

            if (ShowDialog() != DialogResult.OK)
            {
                return false;
            }
                    
            accessRule.RuleType = (AccessControlType)AccessTypeCB.SelectedItem;
            accessRule.Right = (ApplicationAccessRight)AccessRightCB.SelectedItem;
            accessRule.IdentityReference = m_identity;

            return true;
        }
        #endregion

        #region Event Handlers
        private void OkBTN_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_identity == null)
                {
                    AccountInfo account = AccountInfo.Create(IdentityNameTB.Text);

                    if (account == null)
                    {
                        throw new ApplicationException("Please specified a valid identity.");
                    }

                    m_identity = account.GetIdentityReference();
                }

                // close the dialog.
                DialogResult = DialogResult.OK;
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, System.Reflection.MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void BrowseBTN_Click(object sender, EventArgs e)
        {            
            try
            {
                DirectoryObjectPickerDialog picker = new DirectoryObjectPickerDialog();

                picker.AllowedObjectTypes = CubicOrange.Windows.Forms.ActiveDirectory.ObjectTypes.Computers | CubicOrange.Windows.Forms.ActiveDirectory.ObjectTypes.BuiltInGroups | CubicOrange.Windows.Forms.ActiveDirectory.ObjectTypes.Groups | CubicOrange.Windows.Forms.ActiveDirectory.ObjectTypes.Users | CubicOrange.Windows.Forms.ActiveDirectory.ObjectTypes.WellKnownPrincipals;
                picker.DefaultObjectTypes = picker.AllowedObjectTypes;
                picker.AllowedLocations = CubicOrange.Windows.Forms.ActiveDirectory.Locations.All;
                picker.DefaultLocations = CubicOrange.Windows.Forms.ActiveDirectory.Locations.All;
                picker.MultiSelect = false;
                picker.TargetComputer = null;
                
                if (picker.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                } 
                
                DirectoryObject[] results = picker.SelectedObjects;

                if (results == null || results.Length != 1)
                {
                    return;
                }

                if (!String.IsNullOrEmpty(results[0].Path))
                {
                    string path = results[0].Path;                    
                    string[] fields = path.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                    string domain  = fields[fields.Length-2];
                    string account = fields[fields.Length-1];

                    if (String.Compare(domain, System.Net.Dns.GetHostName(), StringComparison.InvariantCultureIgnoreCase) == 0)
                    {
                        m_identity = new NTAccount(account);
                    }
                    else
                    {
                        m_identity = new NTAccount(domain, account);
                    }
                }
                else
                {
                    m_identity = new NTAccount(results[0].Name);
                }

                if (m_identity != null)
                {
                    IdentityNameTB.Text = m_identity.ToString();
                }
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, System.Reflection.MethodBase.GetCurrentMethod(), exception);
            }
        }
        #endregion
    }
}
