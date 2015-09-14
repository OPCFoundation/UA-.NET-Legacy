using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;
using System.Diagnostics;

namespace WelcomeApplication
{
    public partial class ApplicationUserControl : UserControl
    {
        [Browsable(true)]
        public string ApplicationName
        { 
            get
            {
                return AppState.ApplicationName;
            }
            set
            {
                AppState.ApplicationName = value;
                lblAppName.Text = value;
            }
        }

        [Browsable(false)]
        public string ProcessName
        {
            get
            {
                return AppState.ProcessName;
            }            
        }

        [Browsable( true )]
        public string ExeFilePath
        {
            get
            {
                return AppState.ExeFilePath;
            }

            set
            {
                AppState.ExeFilePath = value;

                if (!this.DesignMode && !string.IsNullOrEmpty( value ))
                {
                    this.Visible = File.Exists( Path.Combine( Application.StartupPath, value ) );
                }
            }
        }

        [Browsable(true)]
        public string HelpFile
        {
            get
            {
                return AppState.HelpFile;
            }
            set
            {
                AppState.HelpFile = value;
            }
        }

        [Browsable(true)]
        public string ApplicationDescription
        {
            get
            {
                return AppState.ApplicationDescription;
            }
            set
            {
                AppState.ApplicationDescription = value;
            }
        }

        public bool PendingRefresh { get; set; }
        public ApplicationState AppState { get; set; }
        public ApplicationUserControl()
        {
            InitializeComponent();
            AppState = new ApplicationState();
            PendingRefresh = false;
        }

        
        public void Initialize(Action<string,bool,string> OnHelpFileEvent, Action<string> OnApplicationLaunchEvent)
        {
            
            AppState.StateChanged += OnStateChanged;
            HelpFileEvent += OnHelpFileEvent;
            ApplicationLaunchEvent += OnApplicationLaunchEvent;
        }
        

        // Events Treated by the Main Application
        Action<string, bool, string> HelpFileEvent;
        public event Action<string> ApplicationLaunchEvent;

        private void btnPlay_Click(object sender, EventArgs e)
        {
            try
            {
                if (ApplicationLaunchEvent != null)
                    ApplicationLaunchEvent.Invoke(ExeFilePath);
            }
            catch (Exception)
            {  }
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            try
            {
                if (HelpFileEvent != null)
                    HelpFileEvent.Invoke(AppState.HelpFile, AppState.State, AppState.ApplicationDescription);
            }
            catch (System.Exception)
            {  }

        }

        private delegate void stateChangedDelegate(bool newState);

        private void OnStateChanged(bool newState)
        {
            PendingRefresh = true;
            /* NP Jan-20-2012:
             * Check if the form is running in another thread, if so then marshall to other thread */
            if (ParentForm.InvokeRequired)
            {
                ParentForm.Invoke(new stateChangedDelegate(OnStateChanged), newState);
            }
            else
            {
                if (newState)
                {
                    ovsState.FillColor = Color.Green;
                    btnPlay.Enabled = false;
                }
                else
                {
                    ovsState.FillColor = Color.Red;
                    btnPlay.Enabled = true;
                }
            }
        }
    }
}

