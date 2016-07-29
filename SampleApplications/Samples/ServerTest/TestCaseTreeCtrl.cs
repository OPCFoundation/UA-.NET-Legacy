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
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Xml;
using System.Runtime.Serialization;
using System.IO;

using Opc.Ua.Client;
using Opc.Ua.Client.Controls;

namespace Opc.Ua.ServerTest
{
    public partial class TestCaseTreeCtrl : Opc.Ua.Client.Controls.BaseTreeCtrl
    {
        #region Contructors
        public TestCaseTreeCtrl()
        {
            InitializeComponent();

            foreach (EndpointSelection selection in Enum.GetValues(typeof(EndpointSelection)))
            {
                EndpointSelectionCB.Items.Add(selection);
            }
        }
        #endregion

        #region Private Fields
        private ServerTestConfiguration m_configuration;
        #endregion
        
        #region Public Interface
        public void Initialize(ServerTestConfiguration configuration)
        {
            m_configuration = configuration;
            
            NodesTV.Nodes.Clear();

            if (m_configuration != null)
            {
                IterationsCTRL.Value = (decimal)m_configuration.Iterations;

                if (m_configuration.Coverage != 0)
                {
                    CoverageCTRL.Value = (decimal)m_configuration.Coverage;
                }
                else
                {
                    CoverageCTRL.Value = 100;
                }

                if (m_configuration.ConnectToAllEndpoints)
                {
                    EndpointSelectionCB.SelectedItem = EndpointSelection.All;
                }
                else
                {
                    EndpointSelectionCB.SelectedItem = m_configuration.EndpointSelection;
                }

                AddTestCases(null, m_configuration.TestCases, null);
            }
        }
        #endregion
        
        #region Overridden Members
        /// <see cref="BaseTreeCtrl.EnableMenuItems" />
        protected override void EnableMenuItems(TreeNode clickedNode)
        {
            if (clickedNode != null)
            {                
                ServerTestCase testCase = clickedNode.Tag as ServerTestCase;

                if (testCase != null)
                {
                    BreakpointMI.Enabled = true;
                    BreakpointMI.Checked = testCase.Breakpoint;
                }
            }
        }
        
        /// <see cref="BaseTreeCtrl.UpdateNode" />
		protected override void UpdateNode(TreeNode treeNode, object item, string text, string icon)
        {
            base.UpdateNode(treeNode, item, text, icon);

            ServerTestCase testCase = item as ServerTestCase;

            if (testCase != null)
            {
                treeNode.Checked = testCase.Enabled;
            }

            if (testCase.Breakpoint)
            {
                treeNode.ImageKey = treeNode.SelectedImageKey = GuiUtils.Icons.Method;
            }
            else
            {
                treeNode.ImageKey = treeNode.SelectedImageKey = GuiUtils.Icons.Property;
            }
        }
        #endregion

        #region Private Members
        /// <summary>
        /// Adds the child test cases to parent node.
        /// </summary>
        private void AddTestCases(TreeNode parent, IList<ServerTestCase> testCases, string parentName)
        {
            foreach (ServerTestCase testCase in testCases)
            {
                // ignore test cases that are not immediate children.
                if (testCase.Parent != parentName)
                {
                    continue;
                }

                // add the child.
                TreeNode node = AddNode(parent, testCase, testCase.Name, "ClosedFolder");
                
                // recursively add child test cases.
                AddTestCases(node, testCases, testCase.Name);
            }
        }

        /// <summary>
        /// Recursively changes the check state for child nodes.
        /// </summary>
        private void CheckChildren(TreeNode parent, bool check)
        {
            foreach (TreeNode child in parent.Nodes)
            {
                ServerTestCase testcase = child.Tag as ServerTestCase;

                if (testcase == null)
                {
                    continue;
                }

                child.Checked = check;
                testcase.Enabled = check;

                CheckChildren(child, check);
            }
        }
        #endregion       

        #region Event Handlers
        private void NodesTV_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                TreeNode selectedNode = NodesTV.SelectedNode;

                if (selectedNode == null)
                {
                    return;
                }

                ServerTestCase testcase = selectedNode.Tag as ServerTestCase;

                if (testcase == null)
                {
                    return;
                }

                if (testcase.Enabled != selectedNode.Checked)
                {
                    testcase.Enabled = selectedNode.Checked;
                    CheckChildren(selectedNode, selectedNode.Checked);
                }
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void BreakpointMI_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (NodesTV.SelectedNode != null)
                {     
                    ServerTestCase testCase = NodesTV.SelectedNode.Tag as ServerTestCase;

                    if (testCase != null)
                    {
                        testCase.Breakpoint = BreakpointMI.Checked;
                        UpdateNode(NodesTV.SelectedNode, testCase, testCase.Name, null);
                    }
                }
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        /// <summary>
        /// Recursively toggles the check state for the nodes.
        /// </summary>
        private void SetCheckState(TreeNode parent, bool isChecked)
        {
            parent.Checked = isChecked;

            ServerTestCase testCase = parent.Tag as ServerTestCase;

            if (testCase != null)
            {
                testCase.Enabled = isChecked;
            }

            foreach (TreeNode child in parent.Nodes)
            {
                SetCheckState(child, isChecked);
            }
        }

        private void AllBTN_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (TreeNode node in NodesTV.Nodes)
                {
                    SetCheckState(node, true);
                }
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void NoneBTN_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (TreeNode node in NodesTV.Nodes)
                {
                    SetCheckState(node, false);
                }
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void IterationsCTRL_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                m_configuration.Iterations = (uint)IterationsCTRL.Value;
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void CoverageCTRL_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                m_configuration.Coverage = (uint)CoverageCTRL.Value;
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void EndpointSelectionCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                EndpointSelection selection = (EndpointSelection)EndpointSelectionCB.SelectedItem;
                m_configuration.ConnectToAllEndpoints = selection != EndpointSelection.Single;
                m_configuration.EndpointSelection = selection;
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }
        #endregion
    }
}
