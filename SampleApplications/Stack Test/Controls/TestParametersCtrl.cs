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

namespace Opc.Ua.StackTest
{
    /// <summary>
    /// A class which displays the test parameters for a test case.
    /// </summary>
    public partial class TestParametersCtrl : Opc.Ua.Client.Controls.BaseListCtrl
    {
        /// <summary>
        /// Initializes GUI Components.
        /// Initializes column names.
        /// </summary>
        public TestParametersCtrl()
        {
            InitializeComponent();              
			SetColumns(m_ColumnNames);
        }

        #region Private Fields
       
        // An object of type TestCase.<see ref="TestCase"/>      
        private TestCase m_testcase;
       
		// The columns to display in the control.		
		private readonly object[][] m_ColumnNames = new object[][]
		{
			new object[] { "Name",  HorizontalAlignment.Left, null },  
			new object[] { "Value", HorizontalAlignment.Left,   null }
		};
		#endregion
        
        /// <summary>
        /// Displays a test case in the control.
        /// </summary>
        public void Initialize(TestCase testcase)
        {
            ItemsLV.Items.Clear();

            m_testcase = testcase;

            if (testcase != null)
            {
                AddParamater("TestID",   testcase.TestId);
                AddParamater("TestCase", testcase.Name);

                if (testcase.SeedSpecified)
                {
                    AddParamater("Seed", testcase.Seed);
                }
                
                if (testcase.StartSpecified)
                {
                    AddParamater("Start", testcase.Start);
                }
                
                if (testcase.CountSpecified)
                {
                    AddParamater("Count", testcase.Count);
                }

                AddParamater("SkipTest", testcase.SkipTest);

                if (testcase.Parameter != null)
                {
                    foreach (TestParameter parameter in testcase.Parameter)
                    {
                        AddItem(parameter);
                    }
                }
            }

            AdjustColumns();
        } 

        private void AddParamater(string name, object value)
        {
            TestParameter parameter = new TestParameter();

            parameter.Name  = name;
            parameter.Value = String.Format("{0}", value);

            AddItem(parameter);
        }

        #region Overridden Methods
        /// <see cref="Opc.Ua.Client.Controls.BaseListCtrl.EnableMenuItems" />
		protected override void EnableMenuItems(ListViewItem clickedItem)
		{
            // TBD
		}

        /// <see cref="Opc.Ua.Client.Controls.BaseListCtrl.UpdateItem(ListViewItem,object)" />
        protected override void UpdateItem(ListViewItem listItem, object item)
        {
			TestParameter parameter = item as TestParameter;

			if (parameter == null)
			{
				base.UpdateItem(listItem, item);
				return;
			}

			listItem.SubItems[0].Text = String.Format("{0}", parameter.Name);
			listItem.SubItems[1].Text = String.Format("{0}", parameter.Value);

            listItem.ImageKey = "SimpleItem";
			listItem.Tag = item;
        }
        #endregion
    }
}
