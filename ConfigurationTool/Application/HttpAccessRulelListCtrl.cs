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
using System.Reflection;
using System.Windows.Forms;
using Opc.Ua.Client.Controls;

namespace Opc.Ua.Configuration
{
    public partial class HttpAccessRulelListCtrl : Opc.Ua.Client.Controls.BaseListCtrl
    {
        #region Constructors
        public HttpAccessRulelListCtrl()
        {
            InitializeComponent();

            SetColumns(m_ColumnNames);
        }
        #endregion
       
        #region Private Fields
		// The columns to display in the control.		
		private readonly object[][] m_ColumnNames = new object[][]
		{ 
			new object[] { "Url", HorizontalAlignment.Left, null },
			new object[] { "User", HorizontalAlignment.Left, null },
			new object[] { "Rule", HorizontalAlignment.Left, null }
		};
        #endregion

        #region Public Interface
        /// <summary>
        /// The currently selected certificate.
        /// </summary>
        public CertificateIdentifier SelectedCertificate
        {
            get
            {
                return SelectedTag as CertificateIdentifier;
            }
        }

        /// <summary>
        /// Removes all items in the list.
        /// </summary>
        internal void Clear()
        {
            ItemsLV.Items.Clear();
            Instructions = String.Empty;
            AdjustColumns();            
        }
        

        /// <summary>
        /// Displays the applications in the control.
        /// </summary>
        internal void Initialize()
        {
            ItemsLV.Items.Clear();

            try
            {
                IList<HttpAccessRule> accessRules = HttpAccessRule.GetAccessRules(null);

                if (accessRules == null || accessRules.Count == 0)
                {
                    Instructions = "No HTTP access rules defined.";
                    AdjustColumns();
                    return;
                }

                // display the list.
                foreach (HttpAccessRule accessRule in accessRules)
                {
                    AddItem(accessRule);
                }

                AdjustColumns();
            }
            catch (Exception e)
            {
                Instructions = e.Message;
                AdjustColumns();
            }
        }
        #endregion
        
        #region Overridden Methods
        /// <summary>
        /// Handles a double click event.
        /// </summary>
        protected override void PickItems()
        {
            base.PickItems();
            ViewMI_Click(this, null);
        }

        /// <summary>
        /// Updates an item in the view.
        /// </summary>
        protected override void UpdateItem(ListViewItem listItem, object item)
        {
            HttpAccessRule value = item as HttpAccessRule;

            if (value == null)
            {
                base.UpdateItem(listItem, item);
                return;
            }

            listItem.SubItems[0].Text = value.UrlPrefix;
            listItem.SubItems[1].Text = value.IdentityName;
            listItem.SubItems[2].Text = value.Right.ToString();

            listItem.ImageKey = GuiUtils.Icons.Method;
            listItem.Tag = item;
        }

        /// <summary>
        /// Enables the menu items based on the current selection.
        /// </summary>
        protected override void EnableMenuItems(ListViewItem clickedItem)
        {
            base.EnableMenuItems(clickedItem);
            DeleteMI.Enabled = ItemsLV.SelectedItems.Count > 0;
        }
        #endregion

        #region Event Handlers
        private void ViewMI_Click(object sender, EventArgs e)
        {
            try
            {
                string value = SelectedTag as string;

                if (value == null)
                {
                    return;
                }

                value = new StringValueEditDlg().ShowDialog(value);

                if (String.IsNullOrEmpty(value))
                {
                    return;
                }

                value = new Uri(value).ToString();
                // UpdateItem(ItemsLV.SelectedItems[0], value);
                AdjustColumns();
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void DeleteMI_Click(object sender, EventArgs e)
        {
            try
			{            
                if (ItemsLV.SelectedItems.Count < 1)
                {
                    return;
                }    

                DialogResult result = MessageBox.Show(
                    "Are you sure you wish to delete the rules from the list?", 
                    "Delete Certificate",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Exclamation);

                if (result != DialogResult.Yes)
                {
                    return;
                }

                // remove the items.
                Dictionary<string, List<HttpAccessRule>> rulesToDelete = new Dictionary<string, List<HttpAccessRule>>();

                while (ItemsLV.SelectedItems.Count > 0)
                {
                    HttpAccessRule rule = ItemsLV.SelectedItems[0].Tag as HttpAccessRule;

                    List<HttpAccessRule> rules = null;

                    if (!rulesToDelete.TryGetValue(rule.UrlPrefix, out rules))
                    {
                        rulesToDelete[rule.UrlPrefix] = rules = new List<HttpAccessRule>();
                    }

                    rules.Add(rule);
                    ItemsLV.SelectedItems[0].Remove();
                }

                // delete rules.
                foreach (KeyValuePair<string, List<HttpAccessRule>> pair in rulesToDelete)
                {
                    IList<HttpAccessRule> existingRules = HttpAccessRule.GetAccessRules(pair.Key);
                    
                    List<HttpAccessRule> remainingRules = new List<HttpAccessRule>();

                    for (int ii = 0; ii < existingRules.Count; ii++)
                    {
                        HttpAccessRule existingRule = existingRules[ii];

                        bool found = false;

                        for (int jj = 0; jj < pair.Value.Count; jj++)
                        {
                            HttpAccessRule ruleToDelete = pair.Value[jj];

                            if (ruleToDelete.IdentityName == existingRule.IdentityName)
                            {
                                continue;
                            }

                            if (ruleToDelete.Right == existingRule.Right)
                            {
                                continue;
                            }

                            found = true;
                            break;
                        }

                        if (!found)
                        {
                            remainingRules.Add(existingRule);
                        }
                    }

                    HttpAccessRule.SetAccessRules(pair.Key, remainingRules, true);
                }
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }
        #endregion
    }
}
