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
using System.IO;
using System.Security.Principal;
using System.Security.AccessControl;

using Opc.Ua.Client.Controls;
using Opc.Ua.Configuration;

namespace Opc.Ua.Configuration
{
    public partial class AccessRulesListCtrl : Opc.Ua.Client.Controls.BaseListCtrl
    {
        #region Constructors
        /// <summary>
        /// Initalize the control.
        /// </summary>
        public AccessRulesListCtrl()
        {
            InitializeComponent();
            SetColumns(m_ColumnNames);
            ItemsLV.MultiSelect = false;
        }
        #endregion
        
        #region Private Fields 
        private SecuredObject m_objectType;

        // The columns to display in the control.		
		private readonly object[][] m_ColumnNames = new object[][]
		{ 
			new object[] { "Type", HorizontalAlignment.Left, null },  
			new object[] { "Name", HorizontalAlignment.Left, null },
			new object[] { "Effective Rights", HorizontalAlignment.Left, null },
			new object[] { "Actual Rights", HorizontalAlignment.Left, null },
			new object[] { "Inherited",  HorizontalAlignment.Center, null },
		};
        #endregion
        
        #region Public Interface
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
        /// Displays the access rights for the file in the control.
        /// </summary>
        public void Initialize(IList<ApplicationAccessRule> accessRules)
        {
            ItemsLV.Items.Clear();

            if (accessRules == null || accessRules.Count == 0)
            {
                Instructions = "No access rules are defined.";
                AdjustColumns();
                return;
            }
            
            foreach (ApplicationAccessRule rule in accessRules)
            {
                AddItem(rule);
            }

            AdjustColumns();
        }
        
        /// <summary>
        /// Returns the rules in the control.
        /// </summary>
        public IList<ApplicationAccessRule> GetAccessRules()
        {
            if (ItemsLV.Items.Count == 1)
            {
                if (ItemsLV.Items[0].Text == Instructions)
                {
                    return new ApplicationAccessRule[0];
                }
            }

            List<ApplicationAccessRule> rules = new List<ApplicationAccessRule>();

            for (int ii = 0; ii < ItemsLV.Items.Count; ii++)
            {
                ApplicationAccessRule applicationRule = ItemsLV.Items[ii].Tag as ApplicationAccessRule;

                if (applicationRule != null)
                {
                    rules.Add(applicationRule);
                    continue;
                }

                FileSystemAccessRule fileSystemRule = ItemsLV.Items[ii].Tag as FileSystemAccessRule;

                if (fileSystemRule != null)
                {
                    applicationRule = new ApplicationAccessRule();
                    applicationRule.RuleType = ApplicationAccessRule.Convert(fileSystemRule.AccessControlType);
                    applicationRule.Right = GetEffectiveRight(fileSystemRule);
                    applicationRule.IdentityReference = fileSystemRule.IdentityReference;
                    rules.Add(applicationRule);
                    continue;
                }
            }

            return rules.ToArray();
        }
        #endregion

        /// <summary>
        /// Displays the access rules for the file.
        /// </summary>
        public void Initialize(SecuredObject objectType, string objectPath)
        {
            m_objectType = objectType;

            ItemsLV.Items.Clear();

            AuthorizationRuleCollection authorizationRules = null;

            // determine if a file or directory.
            FileInfo fileInfo = new FileInfo(objectPath);

            if (fileInfo.Exists)
            {
                FileSystemSecurity security = fileInfo.GetAccessControl(AccessControlSections.Access);
                authorizationRules = security.GetAccessRules(true, true, typeof(NTAccount));
            }
            else
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(objectPath);

                if (directoryInfo.Exists)
                {
                    FileSystemSecurity security = directoryInfo.GetAccessControl(AccessControlSections.Access);
                    authorizationRules = security.GetAccessRules(true, true, typeof(NTAccount));
                }
            }
            
            // set a message indicating no access rules.
            if (authorizationRules == null || authorizationRules.Count == 0)
            {
                Instructions = "It is not possible to set the access rules.";
                AdjustColumns();
                return;
            }

            // display the access rules.
            for (int ii = 0; ii < authorizationRules.Count; ii++)
            {
                FileSystemAccessRule accessRule = authorizationRules[ii] as FileSystemAccessRule;

                if (accessRule == null)
                {
                    continue;
                }

                if (GetEffectiveRight(accessRule) == ApplicationAccessRight.None)
                {
                    continue;
                }

                AddItem(accessRule);
            }

            AdjustColumns();
        }

        /// <summary>
        /// Displays the access rules for the directory.
        /// </summary>
        public void Initialize(DirectoryInfo filePath)
        {
            ItemsLV.Items.Clear();

            AuthorizationRuleCollection authorizationRules = null;

            if (filePath != null && filePath.Exists)
            {
                FileSystemSecurity security = filePath.GetAccessControl(AccessControlSections.Access);
                authorizationRules = security.GetAccessRules(true, true, typeof(NTAccount));
            }

            if (authorizationRules == null || authorizationRules.Count == 0)
            {
                Instructions = "No access rules are defined.";
                AdjustColumns();
                return;
            }

            for (int ii = 0; ii < authorizationRules.Count; ii++)
            {
                FileSystemAccessRule accessRule = authorizationRules[ii] as FileSystemAccessRule;

                if (accessRule == null)
                {
                    continue;
                }

                AddItem(accessRule);
            }

            AdjustColumns();
        }

        #region Overridden Methods
        /// <summary>
        /// Enables the menu items based on the current selection.
        /// </summary>
        protected override void EnableMenuItems(ListViewItem clickedItem)
        {
            base.EnableMenuItems(clickedItem);

            NewMI.Enabled = true;

            FileSystemAccessRule fileSystemRule = SelectedTag as FileSystemAccessRule;
            ApplicationAccessRule applicationRule = SelectedTag as ApplicationAccessRule;

            if (fileSystemRule != null || applicationRule != null)
            {
                EditMI.Enabled = true;
                DeleteMI.Enabled = true;
            }
        }

        private int CheckAndAddRight(int rights, FileSystemRights rightToCheck, List<string> strings)
        {
            if ((rights & (int)rightToCheck) == (int)rightToCheck)
            {
                rights &= ~(int)rightToCheck;
                strings.Add(rightToCheck.ToString());
            }

            return rights;
        }

        private string GetRightsForFile(FileSystemRights fileSystemRights)
        {
            int rights =  (int)fileSystemRights;

            List<string> strings = new List<string>();

            rights = CheckAndAddRight(rights, FileSystemRights.FullControl, strings);
            rights = CheckAndAddRight(rights, FileSystemRights.Modify, strings);
            rights = CheckAndAddRight(rights, FileSystemRights.ReadAndExecute, strings);
            rights = CheckAndAddRight(rights, FileSystemRights.Read, strings);
            rights = CheckAndAddRight(rights, FileSystemRights.ReadData, strings);
            rights = CheckAndAddRight(rights, FileSystemRights.WriteData, strings);
            rights = CheckAndAddRight(rights, FileSystemRights.AppendData, strings);
            rights = CheckAndAddRight(rights, FileSystemRights.ExecuteFile, strings);
            rights = CheckAndAddRight(rights, FileSystemRights.Delete, strings);
            rights = CheckAndAddRight(rights, FileSystemRights.ReadExtendedAttributes, strings);
            rights = CheckAndAddRight(rights, FileSystemRights.WriteExtendedAttributes, strings);
            rights = CheckAndAddRight(rights, FileSystemRights.ReadPermissions, strings);
            rights = CheckAndAddRight(rights, FileSystemRights.ChangePermissions, strings);
            rights = CheckAndAddRight(rights, FileSystemRights.TakeOwnership, strings);
            rights = CheckAndAddRight(rights, FileSystemRights.Synchronize, strings);

            StringBuilder buffer = new StringBuilder();

            for (int ii = 0; ii < strings.Count; ii++)
            {
                if (buffer.Length > 0)
                {
                    buffer.Append(',');
                }

                buffer.Append(strings[ii]);
            }

            return buffer.ToString();
        }

        private string GetRightsForDirectory(FileSystemRights fileSystemRights)
        {
            int rights = (int)fileSystemRights;

            List<string> strings = new List<string>();
            
            rights = CheckAndAddRight(rights, FileSystemRights.FullControl, strings);
            rights = CheckAndAddRight(rights, FileSystemRights.Modify, strings);
            rights = CheckAndAddRight(rights, FileSystemRights.ReadAndExecute, strings);
            rights = CheckAndAddRight(rights, FileSystemRights.Read, strings);
            rights = CheckAndAddRight(rights, FileSystemRights.ListDirectory, strings);
            rights = CheckAndAddRight(rights, FileSystemRights.CreateFiles, strings);
            rights = CheckAndAddRight(rights, FileSystemRights.CreateDirectories, strings);
            rights = CheckAndAddRight(rights, FileSystemRights.Traverse, strings);
            rights = CheckAndAddRight(rights, FileSystemRights.Delete, strings);
            rights = CheckAndAddRight(rights, FileSystemRights.ReadExtendedAttributes, strings);
            rights = CheckAndAddRight(rights, FileSystemRights.WriteExtendedAttributes, strings);
            rights = CheckAndAddRight(rights, FileSystemRights.ReadPermissions, strings);
            rights = CheckAndAddRight(rights, FileSystemRights.ChangePermissions, strings);
            rights = CheckAndAddRight(rights, FileSystemRights.TakeOwnership, strings);
            rights = CheckAndAddRight(rights, FileSystemRights.Synchronize, strings);

            StringBuilder buffer = new StringBuilder();

            for (int ii = 0; ii < strings.Count; ii++)
            {
                if (buffer.Length > 0)
                {
                    buffer.Append(',');
                }

                buffer.Append(strings[ii]);
            }

            return buffer.ToString();
        }

        /// <summary>
        /// Gets the effective right for the rule.
        /// </summary>
        private ApplicationAccessRight GetEffectiveRight(FileSystemAccessRule rule)
        {
            switch (m_objectType)
            {
                case SecuredObject.ExecutableFile:
                {
                    return GetEffectiveRightForExe(rule);
                }

                case SecuredObject.TrustList:
                {
                    return GetEffectiveRightForDirectory(rule);
                }
            }

            return GetEffectiveRightForFile(rule);            
        }

        /// <summary>
        /// The list of effective rights.
        /// </summary>
        [Flags]
        private enum EffectiveRights
        {
            Configure = (FileSystemRights.TakeOwnership | FileSystemRights.ChangePermissions),
            Run = (FileSystemRights.ReadAndExecute),
            ReadFile = (FileSystemRights.ReadData),
            WriteFile = (FileSystemRights.WriteData),
            ReadDirectory = (FileSystemRights.ListDirectory),
            WriteDirectory = (FileSystemRights.CreateFiles | FileSystemRights.DeleteSubdirectoriesAndFiles)
        }

        /// <summary>
        /// Gets the effective right for an executable.
        /// </summary>
        private ApplicationAccessRight GetEffectiveRightForExe(FileSystemAccessRule rule)
        {
            ApplicationAccessRight effectiveRight = ApplicationAccessRight.None;
            
            if (rule.AccessControlType == System.Security.AccessControl.AccessControlType.Allow)
            {
                if (((EffectiveRights)rule.FileSystemRights & EffectiveRights.Run) == EffectiveRights.Run)
                {
                    effectiveRight = ApplicationAccessRight.Run;
                }

                if (((EffectiveRights)rule.FileSystemRights & EffectiveRights.Configure) == EffectiveRights.Configure)
                {
                    effectiveRight = ApplicationAccessRight.Configure;
                }
            }
            else
            {
                if (((EffectiveRights)rule.FileSystemRights & EffectiveRights.Run) != 0)
                {
                    effectiveRight = ApplicationAccessRight.Run;
                }

                if (((EffectiveRights)rule.FileSystemRights & EffectiveRights.Configure) != 0)
                {
                    effectiveRight = ApplicationAccessRight.Configure;
                }
            }

            return effectiveRight;
        }

        /// <summary>
        /// Gets the effective right for a file.
        /// </summary>
        private ApplicationAccessRight GetEffectiveRightForFile(FileSystemAccessRule rule)
        {
            ApplicationAccessRight effectiveRight = ApplicationAccessRight.None;

            if (rule.AccessControlType == System.Security.AccessControl.AccessControlType.Allow)
            {
                if (((EffectiveRights)rule.FileSystemRights & EffectiveRights.ReadFile) == EffectiveRights.ReadFile)
                {
                    effectiveRight = ApplicationAccessRight.Run;
                }

                if (((EffectiveRights)rule.FileSystemRights & EffectiveRights.WriteFile) == EffectiveRights.WriteFile)
                {
                    effectiveRight = ApplicationAccessRight.Update;
                }

                if (((EffectiveRights)rule.FileSystemRights & EffectiveRights.Configure) == EffectiveRights.Configure)
                {
                    effectiveRight = ApplicationAccessRight.Configure;
                }
            }
            else
            {
                if (((EffectiveRights)rule.FileSystemRights & EffectiveRights.ReadFile) != 0)
                {
                    effectiveRight = ApplicationAccessRight.Run;
                }

                if (((EffectiveRights)rule.FileSystemRights & EffectiveRights.WriteFile) != 0)
                {
                    effectiveRight = ApplicationAccessRight.Update;
                }

                if (((EffectiveRights)rule.FileSystemRights & EffectiveRights.Configure) != 0)
                {
                    effectiveRight = ApplicationAccessRight.Configure;
                }
            }

            return effectiveRight;
        }

        /// <summary>
        /// Gets the effective right for a directory.
        /// </summary>
        private ApplicationAccessRight GetEffectiveRightForDirectory(FileSystemAccessRule rule)
        {
            ApplicationAccessRight effectiveRight = ApplicationAccessRight.None;

            if (rule.AccessControlType == System.Security.AccessControl.AccessControlType.Allow)
            {
                if (((EffectiveRights)rule.FileSystemRights & EffectiveRights.ReadDirectory) == EffectiveRights.ReadDirectory)
                {
                    effectiveRight = ApplicationAccessRight.Run;
                }

                if (((EffectiveRights)rule.FileSystemRights & EffectiveRights.WriteDirectory) == EffectiveRights.WriteDirectory)
                {
                    effectiveRight = ApplicationAccessRight.Update;
                }

                if (((EffectiveRights)rule.FileSystemRights & EffectiveRights.Configure) == EffectiveRights.Configure)
                {
                    effectiveRight = ApplicationAccessRight.Configure;
                }
            }
            else
            {
                if (((EffectiveRights)rule.FileSystemRights & EffectiveRights.ReadDirectory) != 0)
                {
                    effectiveRight = ApplicationAccessRight.Run;
                }

                if (((EffectiveRights)rule.FileSystemRights & EffectiveRights.WriteDirectory) != 0)
                {
                    effectiveRight = ApplicationAccessRight.Update;
                }

                if (((EffectiveRights)rule.FileSystemRights & EffectiveRights.Configure) != 0)
                {
                    effectiveRight = ApplicationAccessRight.Configure;
                }
            }

            return effectiveRight;
        }

        /// <summary>
        /// Updates an item in the control.
        /// </summary>
        protected override void UpdateItem(ListViewItem listItem, object item)
        {
            FileSystemAccessRule fileSystemRule = item as FileSystemAccessRule;
            ApplicationAccessRule applicationRule = item as ApplicationAccessRule;

            if (fileSystemRule == null && applicationRule == null)
            {
                base.UpdateItem(listItem, item);
                return;
            }

            if (fileSystemRule != null)
            {
                listItem.SubItems[0].Text = fileSystemRule.AccessControlType.ToString();
                listItem.SubItems[1].Text = fileSystemRule.IdentityReference.Value;
                listItem.SubItems[2].Text = GetEffectiveRight(fileSystemRule).ToString();
                listItem.SubItems[3].Text = GetRightsForFile(fileSystemRule.FileSystemRights);
                listItem.SubItems[4].Text = (fileSystemRule.IsInherited)?"Yes":"No"; 
                listItem.ImageKey = (fileSystemRule.AccessControlType == System.Security.AccessControl.AccessControlType.Allow) ? GuiUtils.Icons.Users : GuiUtils.Icons.UsersRedCross;
            }

            if (applicationRule != null)
            {
                listItem.SubItems[0].Text = applicationRule.RuleType.ToString();
                listItem.SubItems[1].Text = applicationRule.IdentityName;
                listItem.SubItems[2].Text = applicationRule.Right.ToString();
                listItem.SubItems[3].Text = null;
                listItem.SubItems[4].Text = null;
                listItem.ImageKey = (applicationRule.RuleType == AccessControlType.Allow) ? GuiUtils.Icons.Users : GuiUtils.Icons.UsersRedCross;
            }

            listItem.Tag = item;
        }
        #endregion
        
        #region Event Handlers
        private void NewMI_Click(object sender, EventArgs e)
        {            
            try
            {
                ApplicationAccessRule accessRule = new ApplicationAccessRule();

                accessRule.RuleType = AccessControlType.Allow;
                accessRule.Right = ApplicationAccessRight.Run;

                if (!new AccessRuleDlg().ShowDialog(accessRule))
                {
                    return;
                }

                AddItem(accessRule);
                AdjustColumns();
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, System.Reflection.MethodBase.GetCurrentMethod(), exception);
            }
        }
        
        private void EditMI_Click(object sender, EventArgs e)
        {            
            try
            {
                FileSystemAccessRule fileSystemRule = SelectedTag as FileSystemAccessRule;
                ApplicationAccessRule applicationRule = SelectedTag as ApplicationAccessRule;

                if (fileSystemRule == null && applicationRule == null)
                {
                    return;
                }

                if (fileSystemRule != null)
                {
                    applicationRule = new ApplicationAccessRule();
                    applicationRule.RuleType = ApplicationAccessRule.Convert(fileSystemRule.AccessControlType);
                    applicationRule.Right = GetEffectiveRight(fileSystemRule);
                    applicationRule.IdentityReference = fileSystemRule.IdentityReference;
                }

                if (!new AccessRuleDlg().ShowDialog(applicationRule))
                {
                    return;
                }

                UpdateItem(ItemsLV.SelectedItems[0], applicationRule);
                AdjustColumns();
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, System.Reflection.MethodBase.GetCurrentMethod(), exception);
            }
        }
        
        private void DeleteMI_Click(object sender, EventArgs e)
        {            
            try
            {
                FileSystemAccessRule fileSystemRule = SelectedTag as FileSystemAccessRule;
                ApplicationAccessRule applicationRule = SelectedTag as ApplicationAccessRule;

                if (fileSystemRule == null && applicationRule == null)
                {
                    return;
                }

                ItemsLV.SelectedItems[0].Remove();
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, System.Reflection.MethodBase.GetCurrentMethod(), exception);
            }
        }
        #endregion
    }
}
