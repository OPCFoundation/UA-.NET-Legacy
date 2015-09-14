using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WelcomeApplication
{    
    
    public class ApplicationState
    {        
        public string ApplicationName { get; set; }
        
        public bool State { get; set; }
        
        public string HelpFile { get; set; }
        public string ApplicationDescription { get; set; }
        public string ExeFilePath { get; set; }
        public string ProcessName
        {
            get
            {
                try
                {
                    return System.IO.Path.GetFileNameWithoutExtension( ExeFilePath );
                }
                catch
                {
                    return null;
                }
            }
        }
        public object ProcessObject { get; set; }

        public event Action<bool> StateChanged;
        
        public ApplicationState()
        {
            State = false;
            ApplicationName = "";
            HelpFile = "";
            ApplicationDescription = "";
            ExeFilePath = "";
            ProcessObject = null;
        }

        public void GetState()
        {
            try
            {
                List<Process> allProcesses = new List<Process>( Process.GetProcesses() );
                int index = allProcesses.FindIndex( p => p.ProcessName.ToLower() == ProcessName.ToLower() );
                if (index >= 0 && !State)
                {
                    State = true;
                    if (StateChanged != null)
                        StateChanged.Invoke( State );
                }
                else if (index < 0 && State)
                {
                    State = false;
                    if (StateChanged != null)
                        StateChanged.Invoke( State );
                }
            }
            catch (System.Exception ex)
            {
                Debug.Assert( false, "Error in GetState()\n\n" + ex.Message );
            }

        }
    }
}
