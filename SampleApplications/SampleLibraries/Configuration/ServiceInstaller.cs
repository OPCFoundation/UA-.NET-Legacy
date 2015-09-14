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
using System.Runtime.InteropServices;

namespace Opc.Ua.Configuration
{
    /// <summary>
    /// Provides functionalities to install/uninstall Windows services.
    /// </summary>
    public static class ServiceInstaller
    {
        #region DLLImport
        [DllImport("advapi32.dll")]
        private static extern IntPtr OpenSCManagerW(
            [MarshalAs(UnmanagedType.LPWStr)]
            string lpMachineName,
            [MarshalAs(UnmanagedType.LPWStr)]
            string lpSCDB, 
            uint scParameter);
        
        [DllImport("Advapi32.dll")]
        private static extern IntPtr CreateServiceW(
            IntPtr SC_HANDLE,
            [MarshalAs(UnmanagedType.LPWStr)]
            string lpSvcName,
            [MarshalAs(UnmanagedType.LPWStr)]
            string lpDisplayName,
            uint dwDesiredAccess, 
            uint dwServiceType, 
            uint dwStartType,
            uint dwErrorControl,
            [MarshalAs(UnmanagedType.LPWStr)]
            string lpPathName,
            [MarshalAs(UnmanagedType.LPWStr)]
            string lpLoadOrderGroup,
            int lpdwTagId,
            [MarshalAs(UnmanagedType.LPWStr)]
            string lpDependencies,
            [MarshalAs(UnmanagedType.LPWStr)]
            string lpServiceStartName,
            [MarshalAs(UnmanagedType.LPWStr)]
            string lpPassword);

        [DllImport("advapi32.dll")]
        private static extern void CloseServiceHandle(IntPtr SCHANDLE);   
   
        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern IntPtr OpenServiceW(
            IntPtr SCHANDLE,
            [MarshalAs(UnmanagedType.LPWStr)]
            string lpSvcName, 
            int dwNumServiceArgs);
        
        [DllImport("advapi32.dll")]
        private static extern int DeleteService(IntPtr SVHANDLE);

        [DllImport("advapi32.dll")]
        private static extern int ChangeServiceConfig2W(
          IntPtr hService,
          int    dwInfoLevel,
          IntPtr lpInfo);
        
        [StructLayout(LayoutKind.Sequential)]
        private struct SERVICE_DESCRIPTION 
        {  
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpDescription;
        };
        
        private const int SERVICE_CONFIG_DESCRIPTION = 1;

        [DllImport("kernel32.dll")]
        private static extern int GetLastError();        
        #endregion DLLImport

        /// <summary>
        /// Stops the service.
        /// </summary>
        /// <param name="serviceName">Name of the service.</param>
        /// <returns>True if stopped successfully.</returns>
        public static bool StartService(string serviceName)
        {
            IntPtr svHandle = IntPtr.Zero;

            try
            {
                IntPtr scHandle = OpenSCManagerW(null, null, (uint)ServiceAccess.GenericWrite);

                if (scHandle.ToInt64() != 0)
                {
                    svHandle = OpenServiceW(scHandle, serviceName, (int)ServiceAccess.AllAccess);

                    if (svHandle.ToInt64() == 0)
                    {
                        Utils.Trace("OpenService Error: {0}", GetLastError());
                        return false;
                    }

                    // stop the service.
                    bool running = ServiceManager.IsServiceRunning(serviceName);

                    if (!running)
                    {
                        if (ServiceManager.StartService(serviceName, new TimeSpan(0, 0, 0, 60)))
                        {
                            Utils.Trace("{0} Service Started", serviceName);
                            return true;
                        }
                    }

                    return false;
                }
            }
            catch (Exception e)
            {
                Utils.Trace(e, "Unexpected error stopping service.");
            }
            finally
            {
                SafeCloseServiceHandle(svHandle);
            }

            return false;
        }

        /// <summary>
        /// Stops the service.
        /// </summary>
        /// <param name="serviceName">Name of the service.</param>
        /// <returns>True if stopped successfully.</returns>
        public static bool StopService(string serviceName)
        {
            IntPtr svHandle = IntPtr.Zero;

            try
            {
                IntPtr scHandle = OpenSCManagerW(null, null, (uint)ServiceAccess.GenericWrite);

                if (scHandle.ToInt64() != 0)
                {
                    svHandle = OpenServiceW(scHandle, serviceName, (int)ServiceAccess.AllAccess);

                    if (svHandle.ToInt64() == 0)
                    {
                        Utils.Trace("OpenService Error: {0}", GetLastError());
                        return false;
                    }

                    // stop the service.
                    bool stopped = ServiceManager.IsServiceStopped(serviceName);

                    if (stopped)
                    {
                        if (ServiceManager.StopService(serviceName, new TimeSpan(0, 0, 0, 60)))
                        {
                            Utils.Trace("{0} Service Stopped", serviceName);
                            return true;
                        }
                    }

                    return false;
                }
            }
            catch (Exception e)
            {
                Utils.Trace(e, "Unexpected error stopping service.");
            }
            finally
            {
                SafeCloseServiceHandle(svHandle);
            }

            return false;
        }

        /// <summary>
        /// Set the Log-On As Service privilege to the given user.
        /// </summary>
        /// <param name="userName">The account name (domain\name).</param>
        /// <returns>True for success; otherwise, false.</returns>
        public static bool SetLogonAsServicePrivilege(string userName)
        {
            try
            {
                using (LocalSecurityPolicy policy = new LocalSecurityPolicy())
                {
                    policy.AddLogonAsServicePrivilege(userName); 
                    return true; 
                }
            }
            catch { }

            return false;
        }

        /// <summary>
        /// Installs and optionally starts the service.
        /// </summary>
        /// <param name="path">The full path of the service exe.</param>
        /// <param name="name">The name of the service.</param>
        /// <param name="displayName">The display name of the service.</param>
        /// <param name="description">The description for the service.</param>
        /// <param name="startMode">The service start mode.</param>
        /// <param name="start">True to start the service after the installation; otherwise, false. 
        /// Once the method returns you can use this parameter to check whether the service is running or not.</param>
        /// <returns>True for success. Otherwise, false.</returns> 
        public static bool InstallService(
            string    path, 
            string    name, 
            string    displayName,
            string    description,
            StartMode startMode, 
            ref bool  start)
        { 
            return InstallService(path, name, displayName, description, startMode, null, null, ref start, null); 
        }

        /// <summary>
        /// Installs and optionally starts the service.
        /// </summary>
        /// <param name="path">The full path of the service exe.</param>
        /// <param name="name">The name of the service.</param>
        /// <param name="displayName">The display name of the service.</param>
        /// <param name="description">The description for the service.</param>
        /// <param name="startMode">The service start mode.</param>
        /// <param name="userName">The account name. Null to use the default account (LocalSystem).</param>
        /// <param name="password">The account password.</param>
        /// <param name="start">True to start the service after the installation; otherwise, false. 
        /// Once the method returns you can use this parameter to check whether the service is running or not.</param>
        /// <returns>True for success. Otherwise, false.</returns> 
        public static bool InstallService(
            string    path, 
            string    name, 
            string    displayName, 
            string    description,
            StartMode startMode, 
            string    userName, 
            string    password, 
            ref bool  start)
        { 
            return InstallService(path, name, displayName, description, startMode, userName, password, ref start, null);
        }

        /// <summary>
        /// Installs and optionally starts the service.
        /// </summary>
        /// <param name="path">The full path of the service exe.</param>
        /// <param name="name">The name of the service.</param>
        /// <param name="displayName">The display name of the service.</param>
        /// <param name="description">The description for the service.</param>
        /// <param name="startMode">The service start mode.</param>
        /// <param name="userName">The account name. Null to use the default account (LocalSystem).</param>
        /// <param name="password">The account password.</param>
        /// <param name="start">True to start the service after the installation; otherwise, false. 
        /// Once the method returns you can use this parameter to check whether the service is running or not.</param>
        /// <param name="dependencies">The list of dependencies services. Null if there are no dependencies.</param>
        /// <returns>True for success. Otherwise, false.</returns> 
        public static bool InstallService(
            string    path, 
            string    name, 
            string    displayName, 
            string    description,
            StartMode startMode, 
            string    userName,
            string    password, 
            ref bool  start, 
            string[]  dependencies)
        {
            uint SC_MANAGER_CREATE_SERVICE = 0x0002;

            if (string.IsNullOrEmpty(userName))
            {
                userName = null;
                password = null;
            }

            // check if an existing service needs to uninstalled.
            try
            {
                Service existingService = ServiceManager.GetService(name);

                if (existingService != null)
                {
                    if (existingService.StartMode != StartMode.Disabled && existingService.Path == path)
                    {
                        if (existingService.Status == ServiceStatus.Stopped)
                        {
                            ServiceManager.StartService(name);
                        }

                        return true;
                    }

                    UnInstallService(name);
                }
            }
            catch (Exception e)
            {
                Utils.Trace(e, "CreateService Exception");
            }

            IntPtr svHandle = IntPtr.Zero;
            
            try
            {
                IntPtr scHandle = OpenSCManagerW(null, null, SC_MANAGER_CREATE_SERVICE);

                if (scHandle.ToInt64() != 0)
                {
                    string dependencyServices = string.Empty;
                
                    if(dependencies!=null && dependencies.Length > 0)
                    {
                        for (int i = 0; i < dependencies.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(dependencies[i]))
                            {
                                dependencyServices += dependencies[i].Trim();
                                if (i < dependencies.Length - 1)
                                    dependencyServices += "\0";//add a null char separator
                            }
                        }
                    }
                    
                    if (dependencyServices == string.Empty)
                        dependencyServices = null;

                    // lpDependencies, if not null, must be a series of strings concatenated with the null character as a delimiter, including a trailing one. 

                    svHandle = CreateServiceW(
                        scHandle, 
                        name, 
                        displayName, 
                        (uint)ServiceAccess.AllAccess, 
                        (uint)ServiceType.OwnProcess, 
                        (uint)startMode, 
                        (uint)ServiceError.ErrorNormal, 
                        path, 
                        null, 
                        0, 
                        dependencyServices, 
                        userName,
                        password);
                    
                    if (svHandle.ToInt64() == 0)
                    {          
                        int error = GetLastError();
                        Utils.Trace("CreateService Error: {0}", error);
                        return false;
                    }
                     
                    // set the description.
                    if (!String.IsNullOrEmpty(description))
                    {
                        SERVICE_DESCRIPTION info = new SERVICE_DESCRIPTION();
                        info.lpDescription = description;

                        IntPtr pInfo = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(SERVICE_DESCRIPTION)));
                        Marshal.StructureToPtr(info, pInfo, false);

                        try
                        {
                            int result = ChangeServiceConfig2W(svHandle, SERVICE_CONFIG_DESCRIPTION, pInfo);

                            if (result == 0)
                            {
                                Utils.Trace("Could not set description for service: {0}", displayName);
                            }
                        }
                        finally
                        {
                            Marshal.DestroyStructure(pInfo, typeof(SERVICE_DESCRIPTION));
                            Marshal.FreeCoTaskMem(pInfo);
                        }
                    }

                    // start the service.
                    if (start)
                    {
                        start = ServiceManager.StartService(name, new TimeSpan(0, 0, 0, 60));
                    }

                    return true;
                }
            }
            catch (Exception e)
            {
                Utils.Trace(e, "CreateService Exception");
            }
            finally 
            { 
                SafeCloseServiceHandle(svHandle); 
            }
            
            return false;
        }

        /// <summary>
        /// Uninstalls the service with the given name.
        /// </summary>
        /// <param name="name">The name of the service to uninstall.</param>
        /// <returns>True for success. Otherwise, false.</returns> 
        public static bool UnInstallService(string name)
        {
            IntPtr svHandle = IntPtr.Zero;
            
            try
            {
                IntPtr scHandle = OpenSCManagerW(null, null, (uint)ServiceAccess.GenericWrite);
                
                if (scHandle.ToInt64() != 0)
                {
                    int DELETE = 0x10000;
                    svHandle = OpenServiceW(scHandle, name, DELETE);
            
                    if (svHandle.ToInt64() == 0)
                    {
                        Utils.Trace("OpenService Error: {0}", GetLastError());
                        return false;
                    }

                    // stop the service.
                    bool running = !ServiceManager.IsServiceStopped(name);

                    if (running)
                    {
                        if (ServiceManager.StopService(name, new TimeSpan(0, 0, 0, 60)))
                        {
                            running = false;
                            Utils.Trace("{0} Service Stopped", name);
                        }
                    }

                    bool uninstalled = (DeleteService(svHandle) != 0);
            
                    if (uninstalled)
                    {
                        // If the service was running the delete marks the service
                        // for deletion. We need to stop the service to fully uninstall it.
                        if (running)
                        {
                            ServiceManager.StopService(name, new TimeSpan(0, 0, 0, 60));
                        }

                        return true;
                    }
                    
                    Utils.Trace("DeleteService Failed: {0}", name);
                    return false;
                }
            }
            catch (Exception e)
            {
                Utils.Trace(e, "UnInstallService Exception");
            }
            finally 
            { 
                SafeCloseServiceHandle(svHandle); 
            }
            
            return false;
        }

        /// <summary>
        /// Safe close the service hanlde
        /// </summary>
        /// <param name="handle"></param>
        private static void SafeCloseServiceHandle(IntPtr handle)
        {
            try { CloseServiceHandle(handle); }
            catch { }
        }
    }
}
