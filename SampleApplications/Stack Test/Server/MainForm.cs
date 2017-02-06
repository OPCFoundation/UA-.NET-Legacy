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
using Opc.Ua.Server;

namespace Opc.Ua.StackTest
{
    /// <summary>
    /// A class executes the tests. 
    /// It provides UI functionality for executing the test cases on the server side.
    /// </summary>
    public partial class MainForm : Form
    {
        #region Constructors
        /// <summary>
        /// This constructor gets the test server configuration.
        /// </summary>
        /// <param name="server"></param>
        public MainForm(TestServer server)
        {
            InitializeComponent();
            this.Icon = this.TrayIcon.Icon = Opc.Ua.Configuration.ConfigUtils.GetAppIcon();
            m_server = server;
        }
        #endregion
        
        #region Private Fields
        // This flag is used for exiting from the application        
        private bool m_exit;
        
        // An object of class TestServer <see cref="TestServer"/>        
        private TestServer m_server;
        #endregion
        
        #region Private Methods
        /// <summary>
        /// Shows the diagnostics window and starts the update timer.
        /// </summary>
        private void ShowStatus()
        {            
            this.WindowState = FormWindowState.Normal;
            this.BringToFront();
            Timer.Enabled = true;
        }
        
        /// <summary>
        /// Hides the diagnostics window and starts the update timer.
        /// </summary>
        private void HideStatus()
        {            
            this.WindowState = FormWindowState.Minimized;
            Timer.Enabled = false;
        }

        /// <summary>
        /// This method displays an unhandled exception.
        /// </summary>
        /// <param name="caption">This parameter stores the caption value for the message box.</param>
        /// <param name="method">Method details.</param>
		/// <param name="e">Exception</param>
		public static void HandleException(string caption, MethodBase method, Exception e)
		{
            if (String.IsNullOrEmpty(caption))
            {
                caption = method.Name;
            }

			MessageBox.Show(e.Message, caption);
		}
        #endregion
        
        #region Event Handlers
        /// <summary>
        /// This event is used to exit from the application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitMI_Click(object sender, EventArgs e)
        {
            m_exit = true;
            Close();
        }

        /// <summary>
        /// Shows the diagnostics window and starts the update timer.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void TrayIcon_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                ShowStatus();          
            }
            catch (Exception exception)
            {
				HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        /// <summary>
        /// This event handles the closing of the main form.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">FormClosingEventArgs</param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (e.CloseReason == CloseReason.UserClosing && !m_exit)
                {
                    e.Cancel = true;
                    HideStatus();
                }       
            }
            catch (Exception exception)
            {
				HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        /// <summary>
        /// Shows the diagnostics window and starts the update timer.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void ShowMI_Click(object sender, EventArgs e)
        {
            try
            {
                ShowStatus();          
            }
            catch (Exception exception)
            {
				HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        /// <summary>
        /// This method updates the timer.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                ServerStatusDataType status = m_server.GetStatus();

                StartTimeTB.Text   = Utils.Format("{0:HH:mm:ss.ff}", status.StartTime.ToLocalTime());
                CurrentTimeTB.Text = Utils.Format("{0:HH:mm:ss.ff}", status.CurrentTime.ToLocalTime());
            }
            catch (Exception exception)
            {
				HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }
        #endregion
    }
}
