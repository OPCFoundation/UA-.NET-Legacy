/* ========================================================================
 * Copyright (c) 2005-2013 The OPC Foundation, Inc. All rights reserved.
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
using System.Text;
using System.ServiceProcess;
using System.Management;
using System.Collections.Specialized;

namespace Opc.Ua.Configuration
{
    /// <summary>
    /// Provides functionalities to manage Windows services such as Start/Stop service. 
    /// </summary>
    public static class ServiceManager
    {
        #region Start/Stop/Pause Service
        /// <summary>
        /// Start the service with the given name.
        /// This method returns as soon as the Start method on the service 
        /// is called and does not guarantee the running status of the service.
        /// You can call this method after stop or pause the service in order to re-start it.
        /// </summary>
        /// <param name="serviceName">The name of the service</param>
        /// <returns>True for success. Otherwise, false.</returns>
        public static bool StartService(string serviceName)
        {
            return StartService(serviceName, TimeSpan.Zero);
        }

        /// <summary>
        /// Start the service with the given name and wait until the status of the service is running.
        /// If the service status is not running after the given timeout then the service is considered not started.
        /// You can call this method after stop or pause the service in order to re-start it.
        /// </summary>
        /// <param name="serviceName">The name of the service</param>
        /// <param name="timeout">The timeout.</param>
        /// <returns>True if the service has been started. Otherwise, false.</returns>
        public static bool StartService(string serviceName, TimeSpan timeout)
        {
            try
            {
                bool timeoutEnabled = (timeout.CompareTo(TimeSpan.Zero) > 0);
                using (ServiceController c = new ServiceController(serviceName))
                {
                    c.Refresh();
                    if (timeoutEnabled && c.Status == ServiceControllerStatus.Running)
                        return true;
                    if (!timeoutEnabled && (c.Status == ServiceControllerStatus.Running || c.Status == ServiceControllerStatus.StartPending || c.Status == ServiceControllerStatus.ContinuePending))
                        return true;

                    if (c.Status == ServiceControllerStatus.Paused || c.Status == ServiceControllerStatus.ContinuePending)
                        c.Continue();
                    else if (c.Status == ServiceControllerStatus.Stopped || c.Status == ServiceControllerStatus.StartPending)
                        c.Start();
                    if (timeoutEnabled)
                        c.WaitForStatus(ServiceControllerStatus.Running, timeout);
                    return true;
                }
            }
            catch (Exception e)
            {
                Utils.Trace(e, "Unexpected error starting service {0}.", serviceName);
                return false;
            }
        }

        /// <summary>
        /// Stop the service with the given name and wait until the service status is stopped.
        /// If the service status is not stopped after the given timeout then the service is considered not stopped.
        /// </summary>
        /// <param name="serviceName">The name of the service</param>
        /// <param name="timeout">The timeout.</param>
        /// <returns>True if the service has been stopped. Otherwise, false.</returns>
        public static bool StopService(string serviceName, TimeSpan timeout)
        {
            try
            {
                bool timeoutEnabled = (timeout.CompareTo(TimeSpan.Zero) > 0);

                using (ServiceController c = new ServiceController(serviceName))
                {
                    c.Refresh();
                    
                    if (timeoutEnabled && c.Status == ServiceControllerStatus.Stopped)
                        return true;
                    
                    if (!timeoutEnabled && (c.Status == ServiceControllerStatus.Stopped || c.Status == ServiceControllerStatus.StopPending))
                        return true;

                    if (c.CanStop)
                    {
                        c.Stop();

                        if (timeoutEnabled)
                            c.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
                    }

                    return true;
                }
            }
            catch (Exception e)
            {
                Utils.Trace(e, "Unexpected error stopping service {0}.", serviceName);
                return false;
            }
        }

        /// <summary>
        /// Stop the service with the given name. This method returns as soon as the Stop method on the service 
        /// is called and does not guarantee the stopped status of the service.
        /// </summary>
        /// <param name="serviceName">The name of the service</param>
        /// <returns>True for success. Otherwise, false.</returns>
        public static bool StopService(string serviceName)
        {
            return StopService(serviceName, TimeSpan.Zero);
        }

        /// <summary>
        /// Pause the service with the given name and wait until the service status is paused.
        /// If the service status is not paused after the given timeout then the service is considered not paused.
        /// </summary>
        /// <param name="serviceName">The name of the service</param>
        /// <param name="timeout">The timeout.</param>
        /// <returns>True if the service has been paused. Otherwise, false.</returns>
        public static bool PauseService(string serviceName, TimeSpan timeout)
        {
            try
            {
                bool timeoutEnabled = (timeout.CompareTo(TimeSpan.Zero) > 0);

                using (ServiceController c = new ServiceController(serviceName))
                {
                    c.Refresh();
                    if (timeoutEnabled && c.Status == ServiceControllerStatus.Paused)
                        return true;
                    if (!timeoutEnabled && (c.Status == ServiceControllerStatus.Paused || c.Status == ServiceControllerStatus.PausePending))
                        return true;
            
                    c.Pause();
                    if (timeoutEnabled)
                        c.WaitForStatus(ServiceControllerStatus.Paused, timeout);

                    return true;
                }
            }
            catch (Exception e)
            {
                Utils.Trace(e, "Unexpected error pausing service {0}.", serviceName);
                return false;
            }
        }

        /// <summary>
        /// Pause the service with the given name. This method returns as soon as the Pause method on the service 
        /// is called and does not guarantee the paused status of the service.
        /// </summary>
        /// <param name="serviceName">The name of the service</param>
        /// <returns>True for success. Otherwise, false.</returns>
        public static bool PauseService(string serviceName)
        {
            return PauseService(serviceName, TimeSpan.Zero);
        }
        #endregion

        #region Service Status
        /// <summary>
        /// Gets the status of the service with the given name.
        /// </summary>
        /// <param name="serviceName">The name of the service.</param>
        /// <returns>The <see cref="ServiceStatus"/>.</returns>
        public static ServiceStatus GetServiceStatus(string serviceName)
        {
            try
            {
                using (ServiceController c = new ServiceController(serviceName))
                {
                    c.Refresh();
                    return ConvertServiceControllerStatusToServiceStatus(c.Status);
                }
            }
            catch (Exception e)
            {
                Utils.Trace(e, "Unexpected error getting status for service {0}.", serviceName);
                return ServiceStatus.Unknown;
            }
        }

        private static ServiceStatus ConvertServiceControllerStatusToServiceStatus(ServiceControllerStatus status)
        {
            ServiceStatus s = ServiceStatus.Unknown;
            switch (status)
            {
                case ServiceControllerStatus.ContinuePending:
                    s = ServiceStatus.ContinuePending;
                    break;
                case ServiceControllerStatus.PausePending:
                    s = ServiceStatus.PausePending;
                    break;
                case ServiceControllerStatus.Paused:
                    s = ServiceStatus.Paused;
                    break;
                case ServiceControllerStatus.Running:
                    s = ServiceStatus.Running;
                    break;
                case ServiceControllerStatus.StartPending:
                    s = ServiceStatus.StartPending;
                    break;
                case ServiceControllerStatus.StopPending:
                    s = ServiceStatus.StopPending;
                    break;
                case ServiceControllerStatus.Stopped:
                    s = ServiceStatus.Stopped;
                    break;
                default:
                    break;
            }
            return s;
        }

        /// <summary>
        /// Determine whther the service with the given name is running.
        /// </summary>
        /// <param name="serviceName">The name of the service.</param>
        /// <returns>True if the service is running.</returns>
        public static bool IsServiceRunning(string serviceName)
        {
            return (GetServiceStatus(serviceName) == ServiceStatus.Running);
        }

        /// <summary>
        /// Determine whther the service with the given name is stopped.
        /// </summary>
        /// <param name="serviceName">The name of the service.</param>
        /// <returns>True if the service is stopped.</returns>
        public static bool IsServiceStopped(string serviceName)
        {
            return (GetServiceStatus(serviceName) == ServiceStatus.Stopped);
        }

        /// <summary>
        /// Determine whther the service with the given name is paused.
        /// </summary>
        /// <param name="serviceName">The name of the service.</param>
        /// <returns>True if the service is paused..</returns>
        public static bool IsServicePaused(string serviceName)
        {
            return (GetServiceStatus(serviceName) == ServiceStatus.Paused);
        }
        #endregion

        #region Service Start Mode
        /// <summary>
        /// Modifies the start mode of a Windows service. 
        /// </summary>
        /// <param name="serviceName">The service name.</param>
        /// <param name="startMode">The new start mode.</param>
        /// <param name="retValue">The return value.
        /// Return value Description:
        /// 0 Success
        /// 1 Not Supported
        /// 2 Access Denied
        /// 3 Dependent Services Running
        /// 4 Invalid Service Control
        /// 5 Service Cannot Accept Control
        /// 6 Service Not Active
        /// 7 ervice Request Timeout
        /// 8 Unknown Failure
        /// 9 Path Not Found
        /// 10 Service Already Running
        /// 11 Service Database Locked
        /// 12 Service Dependency Deleted
        /// 13 Service Dependency Failure
        /// 14 Service Disabled
        /// 15 Service Logon Failure
        /// 16 Service Marked For Deletion
        /// 17 Service No Thread
        /// 18 Status Circular Dependency
        /// 19 Status Duplicate Name
        /// 20 Status Invalid Name
        /// 21 Status Invalid Parameter
        /// 22 Status Invalid Service Account
        /// 23 Status Service Exists
        /// 24 Service Already Paused
        /// </param>
        /// <returns>True if succeded; othrwise, false.</returns>
        public static bool SetServiceStartMode(string serviceName, StartMode startMode, out uint retValue)
        {
            if (string.IsNullOrEmpty(serviceName)) throw new ArgumentNullException("serviceName");
            
            try
            {
                ManagementPath myPath = new ManagementPath();
                myPath.Server = System.Environment.MachineName;
                myPath.NamespacePath = @"root\CIMV2";
                myPath.RelativePath = "Win32_Service.Name='" + serviceName + "'";
     
                using (ManagementObject service = new ManagementObject(myPath))
                {
                    string mode = ConvertStartModeToString(startMode);
                    object[] inputArgs = new object[] { mode };
                   
                    retValue = (uint)service.InvokeMethod("ChangeStartMode", inputArgs);
                    return retValue == 0;
                }
            }
            catch (Exception e)
            {
                retValue = 8;
                Utils.Trace(e, "Unexpected error setting start mode for service {0}.", serviceName);
                return false;
            }
        }

        /// <summary>
        /// Gets the start mode of the service with the given name.
        /// </summary>
        /// <param name="serviceName">The service name.</param>
        /// <returns>The service start mode.</returns>
        public static StartMode GetServiceStartMode(string serviceName)
        {
            if (string.IsNullOrEmpty(serviceName)) throw new ArgumentNullException("serviceName");
            
            try
            {
                // construct the management path.
                string path = "Win32_Service.Name='" + serviceName + "'";
                ManagementPath p = new ManagementPath(path);

                // construct the management object
                using (ManagementObject ManagementObj = new ManagementObject(p))
                {
                    string startMode = ManagementObj["StartMode"].ToString();
                    return ConvertStringToStartMode(startMode);
                }
            }
            catch (Exception e)
            {
                Utils.Trace(e, "Unexpected error getring start mode for service {0}.", serviceName);
            }

            return StartMode.Disabled;
        }

        private static string ConvertStartModeToString(StartMode startMode)
        {
            switch (startMode)
            {
                case StartMode.Auto: return "Automatic";
                case StartMode.Boot: return "Boot";
                case StartMode.System: return "System";
                case StartMode.Manual: return "Manual";
                case StartMode.Disabled: return "Disabled";
            }
            
            return String.Empty;
        }

        private static StartMode ConvertStringToStartMode(string startMode)
        {
            switch (startMode)
            {
                case "Auto": return StartMode.Auto;
                case "Boot": return StartMode.Boot;
                case "System": return StartMode.System;
                case "Manual": return StartMode.Manual;
                case "Disabled": return StartMode.Disabled;
            }

            return StartMode.Disabled;
        }
        #endregion

        #region GetAllServices, ServiceExists
        /// <summary>
        /// Gets all installed Windows services.
        /// </summary>
        /// <returns>The list of intalled <see cref="Service"/>.</returns>
        public static Service[] GetAllServices()
        {
            List<Service> list = new List<Service>();

            try
            {
                using (ManagementObjectSearcher objSearcher = new ManagementObjectSearcher("Select * from Win32_Service"))
                {
                    using (ManagementObjectCollection winServices = objSearcher.Get())
                    {
                        foreach (ManagementObject service in winServices)
                        {
                            Service s = ServiceFromManagementObject(service);
                            list.Add(s);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Utils.Trace(e, "Unexpected error searching for all services.");
            }

            Service[] serviceArray = new Service[list.Count];
            list.CopyTo(serviceArray);
            return serviceArray;
        }

        /// <summary>
        /// Gets the <see cref="Service"/> with the given name.
        /// </summary>
        /// <param name="serviceName">The service name.</param>
        /// <returns>The <see cref="Service"/> identified by the given name.</returns>
        public static Service GetService(string serviceName)
        {
            try
            {
                using (ManagementObjectSearcher objSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_Service WHERE Name = '" + serviceName.Trim() + "'"))
                {
                    using (ManagementObjectCollection winServices = objSearcher.Get())
                    {
                        foreach (ManagementObject service in winServices)
                        {
                            Service s = ServiceFromManagementObject(service);
                            return s;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Utils.Trace(e, "Unexpected error searching for service {0}.", serviceName);
            }

            return null;
        }

        /// <summary>
        /// Gets a value whteher the service with the given name is installed.
        /// </summary>
        /// <param name="serviceName">The service name.</param>
        /// <returns>True if the service with the given bname exists; otherwise, false.</returns>
        public static bool ServiceExists(string serviceName)
        {
            return GetService(serviceName) != null;
        }
        
        private static Service ServiceFromManagementObject(ManagementBaseObject service)
        {
            try
            {
                string name = service.Properties["Name"].Value as string;
                Service s = new Service(name);
                
                s.Description = service.Properties["Description"].Value as string;
                s.Caption = service.Properties["Caption"].Value as string;
                s.DisplayName = service.Properties["DisplayName"].Value as string;
                s.Path = service.Properties["PathName"].Value as string;
                s.AcceptPause = (bool)service.Properties["AcceptPause"].Value;
                s.AcceptStop = (bool)service.Properties["AcceptStop"].Value;
                
                object pId = service.Properties["ProcessId"].Value;
                
                if (pId != null)
                {
                    try
                    {
                        s.ProcessId = Convert.ToInt32(pId);
                        s.ProcessorAffinity = GetProcessorAffinity(s.ProcessId);
                    }
                    catch { }
                }
                
                s.StartMode = ConvertStringToStartMode(service.Properties["StartMode"].Value as string);
                s.Account = service.Properties["StartName"].Value as string;
                s.Status = ConvertStringToServiceStatus(service.Properties["State"].Value as string);
                return s;
            }
            catch (Exception e)
            {
                Utils.Trace(e, "Unexpected error service from managerment object}.");
                return null;
            }
        }

        private static ServiceStatus ConvertStringToServiceStatus(string status)
        {
            if (string.IsNullOrEmpty(status))
                return ServiceStatus.Unknown;
            if (status == "Stopped")
                return ServiceStatus.Stopped;
            if (status == "Start Pending")
                return ServiceStatus.StartPending;
            if (status == "Stop Pending")
                return ServiceStatus.StopPending;
            if (status == "Running")
                return ServiceStatus.Running;
            if (status == "Continue Pending")
                return ServiceStatus.ContinuePending;
            if (status == "Pause Pending")
                return ServiceStatus.PausePending;
            if (status == "Paused")
                return ServiceStatus.Paused;

            return ServiceStatus.Unknown;
        }        
        #endregion

        #region Processor Affinity

        /// <summary>
        /// Set the processor affinity for the service with the given name.
        /// </summary>
        /// <param name="serviceName">the service name.</param>
        /// <param name="affinity">The affinity bitmask.</param>
        /// <returns>True for success; otherwise, false.</returns>
        /// <remarks>
        /// If the system has 2 processor and the service is running on processor 2 the affinity bit mask will be : [true][false]
        /// If the system has 2 processor and the service is running on both processors the affinity bit mask will be : [true][true]
        /// </remarks>
        public static bool SetServiceProcessorAffinity(string serviceName, bool[] affinity)
        {
            Service service = GetService(serviceName);
            if (service != null && service.ProcessId > 0 && affinity != null && affinity.Length > 0)
            {
                try
                {
                    System.Diagnostics.Process process = System.Diagnostics.Process.GetProcessById(service.ProcessId);
                    int affinityInt = affinity[affinity.Length - 1] ? 1 : 0;
                    for (int i = affinity.Length - 2; i >= 0; i--)
                    {
                        if (affinity[i])
                        {
                            affinityInt = affinityInt + 2 * (affinity.Length - 1 - i);
                        }
                    }
                    IntPtr affinityPtr = new IntPtr(affinityInt);
                    process.ProcessorAffinity = affinityPtr;
                    return true;
                }
                catch { }
            }
            return false;
        }

        /// <summary>
        /// Gets the processor affinity for the process with the given id.
        /// </summary>
        /// <param name="processId"></param>
        /// <returns></returns>
        private static bool[] GetProcessorAffinity(int processId)
        {
            bool[] affinity = new bool[GetNumberOfLogicalProcessors()];
            if (processId > 0)
            {
                try
                {
                    using (System.Diagnostics.Process process = System.Diagnostics.Process.GetProcessById(processId))
                    {
                        IntPtr affinityPtr = process.ProcessorAffinity;
                        int affinityInt = affinityPtr.ToInt32();
                        string affinityStr = Convert.ToString(affinityInt, 2);
                        for (int i = affinityStr.Length - 1; i >= 0; i--)
                        {
                            if (affinityStr[i] == '1')
                            { try { affinity[affinityStr.Length - 1 - i] = true; } catch { } }
                        }
                    }
                }
                catch { }
            }
            return affinity;
        }

        /// <summary>
        /// Gets the affinity for the service with the given name.
        /// </summary>
        /// <param name="serviceName">the service name.</param>
        /// <returns>The affinity bit mask.</returns>
        /// <remarks>
        /// If the system has 2 processor and the service is running on processor 2 the affinity bit mask will be : [true][false]
        /// If the system has 2 processor and the service is running on both processors the affinity bit mask will be : [true][true]
        /// </remarks>
        public static bool[] GetServiceProcessorAffinity(string serviceName)
        {
            Service service = GetService(serviceName);
            int processId = service != null ? service.ProcessId : 0;
            return GetProcessorAffinity(processId);
        }

       
        private static ManagementObject GetComputerSystem()
        {
            using (ManagementObjectSearcher objSearcher = new ManagementObjectSearcher("Select * from Win32_ComputerSystem"))
            {
                using (ManagementObjectCollection system = objSearcher.Get())
                {
                    foreach (ManagementObject pc in system)
                    {
                        return pc;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Gets the number of physical processors on the system. 
        /// </summary>
        /// <returns>The number of physical processors</returns>
        public static int GetNumberOfProcessors()
        {
            ManagementObject system = GetComputerSystem();
            if (system != null)
            {
                object num = system.Properties["NumberOfProcessors"].Value;
                if (num != null)
                    return Convert.ToInt32(num);
            }
            return 1;
        }

        /// <summary>
        /// Gets the number of logical processors on the system. 
        /// </summary>
        /// <returns>The number of logical processors</returns>
        public static int GetNumberOfLogicalProcessors()
        {
            ManagementObject system = GetComputerSystem();
            if (system != null)
            {
                object num = system.Properties["NumberOfLogicalProcessors"].Value;
                if (num != null)
                    return Convert.ToInt32(num);
            }
            return 1;
        }

        #endregion
    }
}
