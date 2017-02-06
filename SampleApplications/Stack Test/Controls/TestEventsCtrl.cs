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

    public partial class TestEventsCtrl : Opc.Ua.Client.Controls.BaseListCtrl
    {
        #region Constructors
        /// <summary>
        /// Initializes GUI Components.
        /// Initializes column names.
        /// </summary>
        public TestEventsCtrl()
        {
            InitializeComponent();
            SetColumns(m_ColumnNames);
        }
        #endregion

        #region Private Fields        
        // The columns to display in the control.       
        private readonly object[][] m_ColumnNames = new object[][]
		{            
			new object[] { "Time",  HorizontalAlignment.Center, null, 150 },  
            new object[] { "Test Id",  HorizontalAlignment.Center, null, 75 }, 
			new object[] { "Iteration", HorizontalAlignment.Center,   null, 75 } ,
            new object[] { "EventType  ",  HorizontalAlignment.Center, null, 100 },  
            new object[] { "Details",  HorizontalAlignment.Center, null, 500 }           
		};
        #endregion

        #region Public Methods
        /// <summary>
        /// Clears all events in the list.
        /// </summary>  
        public void Clear()
        {
            ItemsLV.Items.Clear();
        }

        /// <summary>
        /// This method adds new event in the list.
        /// </summary>  
        /// <param name="testEvent">Test event.</param>
        public void AddEvent(TestEvent testEvent)
        {
            List<TestEvent> events = new List<TestEvent>();

            foreach (ListViewItem item in ItemsLV.Items)
            {
                events.Add((TestEvent)item.Tag);
            }

            events.Add(testEvent);

            this.BeginUpdate();

            for (int ii = 0; ii < events.Count; ii++)
            {
                AddItem(events[ii]);
            }

            EndUpdate();

            ItemsLV.Items[ItemsLV.Items.Count-1].EnsureVisible();
        }

        /// <summary>
        /// Initializes the list.
        /// </summary>
        public void Initialize()
        {
            string icon = "SimpleItem";          

            // switch to detail view as soon as an item is added.
            if (ItemsLV.View == View.List)
            {
                ItemsLV.Items.Clear();
                ItemsLV.View = View.Details;
            }

            ListViewItem listItem = new ListViewItem();

            listItem.Text = String.Empty;
            listItem.ImageKey = icon;

            // fill columns with blanks.
            for (int ii = listItem.SubItems.Count; ii < ItemsLV.Columns.Count - 1; ii++)
            {
                listItem.SubItems.Add(String.Empty);
            }            
        }

        /// <summary>
        /// Remove Item from the list.
        /// </summary>
        public void RemoveItems()
        {
            foreach (ListViewItem item in ItemsLV.Items)
            {
                item.Remove();
            }
        }
        #endregion

        #region Overridden Methods
        /// <see cref="Opc.Ua.Client.Controls.BaseListCtrl.EnableMenuItems" />
        protected override void EnableMenuItems(ListViewItem clickedItem)
        {
            // TBD
        }

        /// <see cref="Opc.Ua.Client.Controls.BaseListCtrl.EnableMenuItems" />
        protected override void UpdateItem(ListViewItem listItem, object item)
        {
            TestEvent testEvent = item as TestEvent;

            if (testEvent == null)
            {
                base.UpdateItem(listItem, item);
                return;
            }

            listItem.SubItems[0].Text = String.Format("{0}", testEvent.Timestamp);
            listItem.SubItems[1].Text = String.Format("{0}", testEvent.TestId);
            listItem.SubItems[2].Text = String.Format("{0}", testEvent.Iteration);
            listItem.SubItems[3].Text = String.Format("{0}", testEvent.EventType);
            listItem.SubItems[4].Text = String.Format("{0}", testEvent.Details);

            listItem.ImageKey = "SimpleItem";
            listItem.Tag = item;
        }

        /// <see cref="Opc.Ua.Client.Controls.BaseListCtrl.EnableMenuItems" />
        protected override void AdjustColumns()
        {
            for (int ii = 0; ii < m_ColumnNames.Length && ii < ItemsLV.Columns.Count; ii++)
            {
                if (m_ColumnNames[ii][3] != null)
                {
                    int width = Convert.ToInt32(m_ColumnNames[ii][3]);

                    if (ItemsLV.Columns[ii].Width < width)
                    {
                        ItemsLV.Columns[ii].Width = width;
                    }

                    continue;
                }
            }

            if (ItemsLV.Columns.Count > 0)
            {
                ItemsLV.Columns[ItemsLV.Columns.Count - 1].Width = 0;
            }
        }
        #endregion
    }
}
