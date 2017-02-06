/* ========================================================================
 * Copyright (c) 2005-2017 The OPC Foundation, Inc. All rights reserved.
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
using Opc.Ua.Client.Controls;

namespace Opc.Ua.StackTest
{
    public partial class TestCasesCtrl : Opc.Ua.Client.Controls.BaseListCtrl
    {
        /// <summary>
        /// Initializes GUI Components.
        /// Initializes column names.
        /// </summary>
        public TestCasesCtrl()
        {
            InitializeComponent();                 
			SetColumns(m_ColumnNames);
        }

        #region Private Fields
        
        // An object of type TestSequence. <see cref="TestSequence"/>      
        private TestSequence m_sequence;
        
        // An object of type TestParametersCtrl. <see cref="TestParametersCtrl"/>       
        private TestParametersCtrl m_ParametersCTRL;
       
		// The columns to display in the control.		
		private readonly object[][] m_ColumnNames = new object[][]
		{
			new object[] { "ID",    HorizontalAlignment.Center, null },  
			new object[] { "Name",  HorizontalAlignment.Left,   null }
		};
		#endregion
        
        /// <summary>
        /// The control used to display the parameters for the selected test case.
        /// </summary>
        public TestParametersCtrl ParametersCTRL
        {
            get { return m_ParametersCTRL;  }
            set { m_ParametersCTRL = value; }
        }

        /// <summary>
        /// The test sequence, which the client must execute.
        /// </summary>
        public TestSequence SequenceToExecute
        {
            get { return m_sequence; }
        }

        /// <summary>
        /// Displays a test sequence in the control.
        /// </summary>
        public void Initialize(TestSequence sequence)
        {
            ItemsLV.Items.Clear();

            m_sequence = sequence;

            if (sequence != null)
            {
                foreach (TestCase testcase in sequence.TestCase)
                {
                    AddItem(testcase);
                }
            }

            AdjustColumns();
        } 

        #region Overridden Methods
        /// <see cref="Opc.Ua.Client.Controls.BaseListCtrl.SelectItems" />
        protected override void SelectItems()
        {
            if (ItemsLV.SelectedItems.Count == 1)
            {
                m_ParametersCTRL.Initialize(ItemsLV.SelectedItems[0].Tag as TestCase);
            }

            base.SelectItems();
        }

        /// <see cref="Opc.Ua.Client.Controls.BaseListCtrl.EnableMenuItems" />
		protected override void EnableMenuItems(ListViewItem clickedItem)
		{
            foreach (ListViewItem item in ItemsLV.SelectedItems)
            {
                TestCase testcase = item.Tag as TestCase;

                if (testcase != null)
                {
                    IncludeTestMI.Checked = !testcase.SkipTest;
                    IncludeTestMI.Enabled = true;
                    break;
                }
            }
		}

        /// <see cref="Opc.Ua.Client.Controls.BaseListCtrl.UpdateItem(ListViewItem,object)" />
        protected override void UpdateItem(ListViewItem listItem, object item)
        {
			TestCase testcase = item as TestCase;

			if (testcase == null)
			{
				base.UpdateItem(listItem, item);
				return;
			}
            
			listItem.SubItems[0].Text = String.Format("{0}", testcase.TestId);

            if (!String.IsNullOrEmpty(testcase.DisplayText))
            {
			    listItem.SubItems[1].Text = String.Format("{0}", testcase.DisplayText);
            }
            else
            {
			    listItem.SubItems[1].Text = String.Format("{0}", testcase.Name);
            }

            if (testcase.SkipTest)
            {
                listItem.ImageKey = "Property";
            }
            else
            {
                listItem.ImageKey = "Method";
            }

			listItem.Tag = item;
        }

        private void IncludeTestMI_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem item in ItemsLV.SelectedItems)
                {
                    TestCase testcase = item.Tag as TestCase;

                    if (testcase != null)
                    {
                        testcase.SkipTest = !IncludeTestMI.Checked;
                        UpdateItem(item, testcase);
                    }
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
