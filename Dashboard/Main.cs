using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Microsoft.Win32;
using System.IO;
using System.Reflection;
namespace WelcomeApplication
{
    public partial class frmMain : Form
    {
        private System.Threading.Timer _timerCheckApps;
        private List<ApplicationUserControl> _lstControls;
        
        
        public frmMain()
        {
            InitializeComponent();
            
            _lstControls = new List<ApplicationUserControl>();
            _lstControls.Add(appUaConfigTool);
            _lstControls.Add(appDiscoveryServer);
            _lstControls.Add(appDAServer);
            _lstControls.Add(appDAClient);
            _lstControls.Add(appGnServer);
            _lstControls.Add(appGnClient);
            _lstControls.Add(appRefServer);
            _lstControls.Add(appRefClient);
            _lstControls.Add(appACServer);
            _lstControls.Add(appACClient);
            _lstControls.Add(appHAServer);
            _lstControls.Add(appHAClient);
            _lstControls.Add(appHEServer);
            _lstControls.Add(appHEClient);

            foreach (ApplicationUserControl app in _lstControls)
            {
                app.Initialize(OnHelpFileEvent, OnApplicationLaunchEvent);
            }


            wbOPCFoundation.Navigate(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), Properties.Settings.Default.WelcomeHelp));
            _timerCheckApps = new System.Threading.Timer(OnTimer, null, 2000, 2000);


            /* NP 12-16-2011: this application's assembly (file) version matches
             *                all othe applications. Use this information to show the
             *                build information in the title-bar. */
            labelSdkBuild.Text = string.Format("OPC UA .NET API Build: {0}", Assembly.GetEntryAssembly().GetName().Version);
        }

            
        private void OnTimer(object state)
        {
            try
            {
                _timerCheckApps.Change(0, Timeout.Infinite);
                foreach (ApplicationUserControl app in _lstControls)
                {
                    app.AppState.GetState();
                    
                }
                _timerCheckApps.Change(2000, 2000);
            }
            catch (System.Exception)
            { }
            

        }


        private void OnHelpFileEvent(string fileName,bool state, string description)
        {
            if (state)
            {
                lblState.Text = "Running";
            }
            else
            {
                lblState.Text = "Not running";
            }
            lblInfo.Text = description;
            string completePath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), fileName);

            try
            {
                //NP removed: Process.Start(fileName);
                wbOPCFoundation.Url = new Uri(completePath);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Could open help file. Error Message:" + ex.Message, "OPC UA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void OnApplicationLaunchEvent( string filename)
        {
            string completePath = "";
            try
            {
                completePath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), filename );
                Process.Start(completePath);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Application could not be launched. Error Message:" + ex.Message + "\nAttempting to launch: " + completePath, "OPC UA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        
        private void lnkOpc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start("https://www.opcfoundation.org");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Failed to open url. Error Message:" + ex.Message, "OPC UA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void lnkOPCCertification_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
        {
            try
            {
                Process.Start("www.opcfoundation.org/certification");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Failed to open url. Error Message:" + ex.Message, "OPC UA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkReportABug_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
        {
            try
            {
                Process.Start("https://github.com/OPCFoundation/UA-.NET/issues");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show( "Failed to open url. Error Message:" + ex.Message, "OPC UA", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }

        private void lnkAskForHelp_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
        {
            try
            {
                Process.Start( "http://www.opcfoundation.org/forum" );
            }
            catch (System.Exception ex)
            {
                MessageBox.Show( "Failed to open url. Error Message:" + ex.Message, "OPC UA", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }
        
        private void lnkLaunchBrowser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start(wbOPCFoundation.Url.ToString());
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Failed to open url. Error Message:" + ex.Message, "OPC UA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            foreach (ApplicationUserControl app in _lstControls)
            {
                if (app.PendingRefresh)
                {
                    app.PendingRefresh = false;
                    app.Refresh();
                }
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Do you want to close this window?", "OPC UA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;
        }

        private void imgOPCLogo_Click(object sender, EventArgs e)
        {
            lnkOpc_LinkClicked(sender, null);
        }
    }
}
