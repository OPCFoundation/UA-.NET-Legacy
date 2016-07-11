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
using Opc.Ua.Client.Controls;

namespace Opc.Ua.NetworkTester
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            
            ListenerUrlTB.Text = "opc.tcp://localhost:7001";
            ServerUrlTB.Text = "opc.tcp://localhost:61210";

            StopBTN.Enabled = false;
        }

        private Server m_server;

        private void StartBTN_Click(object sender, EventArgs e)
        {   
            try
            {
                if (m_server != null)
                {
                    m_server.Stop();
                    m_server = null;
                }

                m_server = new Server(ListenerUrlTB.Text, ServerUrlTB.Text);
                m_server.Start();

                StopBTN.Enabled = true;
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void StopBTN_Click(object sender, EventArgs e)
        {   
            try
            {
                if (m_server != null)
                {
                    m_server.Stop();
                    m_server = null;
                }

                StopBTN.Enabled = false;
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }
    }
}
