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
using System.Text;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Xml;
using System.Runtime.Serialization;
using System.Management;
using Microsoft.Win32;

namespace Opc.Ua.Configuration
{
    /// <summary>
    /// Utility functions used by COM applications.
    /// </summary>
    public static class ConfigUtils
    {
        /// <summary>
        /// Gets or sets a directory which contains files representing users roles.
        /// </summary>
        /// <remarks>
        /// The write permissions on these files are used to determine which users are allowed to act in the role.
        /// </remarks>
        public static string UserRoleDirectory { get; set; }

        /// <summary>
        /// Gets the log file directory and ensures it is writeable.
        /// </summary>
        public static string GetLogFileDirectory()
        {
            // try the program data directory.
            string logFileDirectory = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            logFileDirectory += "\\OPC Foundation\\Logs";

            try
            {
                // create the directory.
                if (!Directory.Exists(logFileDirectory))
                {
                    Directory.CreateDirectory(logFileDirectory);
                }

                // ensure everyone has write access to it.
                List<ApplicationAccessRule> rules = new List<ApplicationAccessRule>();

                ApplicationAccessRule rule = new ApplicationAccessRule();

                rule.IdentityName = WellKnownSids.Users;
                rule.Right = ApplicationAccessRight.Configure;
                rule.RuleType = AccessControlType.Allow;

                rules.Add(rule);

                rule = new ApplicationAccessRule();

                rule.IdentityName = WellKnownSids.NetworkService;
                rule.Right = ApplicationAccessRight.Configure;
                rule.RuleType = AccessControlType.Allow;

                rules.Add(rule);

                rule = new ApplicationAccessRule();

                rule.IdentityName = WellKnownSids.LocalService;
                rule.Right = ApplicationAccessRight.Configure;
                rule.RuleType = AccessControlType.Allow;

                rules.Add(rule);

                ApplicationAccessRule.SetAccessRules(logFileDirectory, rules, false);
            }
            catch (Exception)
            {
                // try the MyDocuments directory instead.
                logFileDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                logFileDirectory += "OPC Foundation\\Logs";

                if (!Directory.Exists(logFileDirectory))
                {
                    Directory.CreateDirectory(logFileDirectory);
                }
            }

            return logFileDirectory;
        }

        /// <summary>
        /// Checks if command line arguments specify configuration commands.
        /// </summary>
        /// <returns>
        /// True if a configuration argument was specified and the arguments were processed. False otherwise.
        /// </returns>
        public static bool ProcessCommandLine()
        {
            // check if running in command line mode.
            string[] args = Environment.GetCommandLineArgs();

            // need to remove the executable name from the list of args.
            string[] args2 = new string[args.Length-1];
            Array.Copy(args, 1, args2, 0, args2.Length);

            // process the arguments.
            return ConfigUtils.ProcessCommandLine(args2);
        }

        /// <summary>
        /// Checks if arguments specify configuration commands.
        /// </summary>
        /// <param name="args">The arguments passed to the executable.</param>
        /// <returns>True if a configuration argument was specified and the arguments were processed. False otherwise.</returns>
        public static bool ProcessCommandLine(string[] args)
        {
            // print the arguments provided.
            StringBuilder commandLine = new StringBuilder();

            for (int ii = 1; ii < args.Length; ii++)
            {
                commandLine.Append(args[ii]);
                commandLine.Append(' ');
            }

            Utils.Trace("Processing Arguments: {0}", commandLine); 

            // check that there are enough arguments left.
            if (args.Length < 2)
            {
                return false;
            }

            // the first arguement specifies the type of configuration command.
            string configureCommand = args[0];

            if (String.IsNullOrEmpty(configureCommand) || !configureCommand.StartsWith("-"))
            {
                return false;
            }

            switch (configureCommand)
            {
                // Install and Configure UA Applications
                case "-ra":
                case "-ia":
                case "-ias":
                {
                    break;
                }

                // Uninstall and UA Applications
                case "-ur":
                case "-ua":
                case "-uas":
                {
                    break;
                }

                // Register UA COM Pseudo-Servers
                case "-rp":
                case "-rps":
                {
                    break;
                }

                // Unregister UA COM Pseudo-Servers
                case "-up":
                case "-ups":
                {
                    break;
                }

                // Register a COM DLL
                case "-rc":
                case "-rcs":
                {
                    break;
                }

                // Unregister a COM DLL
                case "-uc":
                case "-ucs":
                {
                    break;
                }

                // non-configuration command.
                default:
                {
                    return false;
                }
            }

            Utils.SetTraceOutput(Utils.TraceOutput.FileOnly);
            Utils.SetTraceMask(Int32.MaxValue);

            string logFilePath = GetLogFileDirectory() + "\\Opc.Ua.ConfigurationTool.log.txt";
            Utils.SetTraceLog(logFilePath, false);
            Utils.Trace("Log File Set to: {0}", logFilePath);

            // check the file path.
            string filePath = Utils.GetAbsoluteFilePath(args[1], true, false, false);

            if (filePath == null)
            {
                if (configureCommand.EndsWith("s", StringComparison.Ordinal))
                {
                    Utils.Trace("File does not exist: {0}", args[1]);
                    return true;
                }

                throw ServiceResultException.Create(StatusCodes.Bad, "File does not exist: {0}", args[1]);
            }

            // check for additional options.
            bool autostart = true;
            bool configureFirewall = true;
            
            for (int ii = 2; ii < args.Length; ii++)
            {
                if (args[ii] == "-firewall")
                {
                    if (ii < args.Length-1 && !args[ii+1].StartsWith("-"))
                    {
                        configureFirewall = false;
                        continue;
                    }
                }

                if (args[ii] == "-autostart")
                {
                    if (ii < args.Length-1 && !args[ii+1].StartsWith("-"))
                    {
                        autostart = false;
                        continue;
                    }
                }
            }

            switch (configureCommand)
            {
                // Register a COM DLL
                case "-rc":
                case "-rcs":
                {
                    ConfigUtils.RegisterComTypes(filePath);
                    Utils.Trace("Registered COM DLL '{0}'", filePath); 
                    break;
                }
                    
                // Unregister a COM DLL
                case "-uc":
                case "-ucs":
                {
                    ConfigUtils.UnregisterComTypes(filePath);
                    Utils.Trace("Unregistered COM DLL '{0}'", filePath); 
                    break;
                }

                // Install and Configure UA Applications
                case "-ia":
                case "-ias":
                {
                    // save the current directory so it can be restored.
                    string currentDirectory = Environment.CurrentDirectory;

                    try
                    {
                        Environment.CurrentDirectory = new FileInfo(filePath).DirectoryName;

                        // load the configurations from the file.
                        InstalledApplicationCollection applications = null;

                        try
                        {
                            applications = InstalledApplication.Load(filePath);
                        }
                        catch (Exception e)
                        {
                            throw ServiceResultException.Create(
                                StatusCodes.BadConfigurationError,
                                e,
                                "Could not read configuration file. {0}",
                                filePath);
                        }

                        // update the application configuration.
                        foreach (InstalledApplication application in applications)
                        {
                            try
                            {
                                ConfigUtils.InstallApplication(application, autostart, configureFirewall);
                                Utils.Trace("Installed application '{0}'", application.ApplicationName);
                            }
                            catch (Exception e)
                            {
                                Utils.Trace(e, "Error installing application '{0}': {1}", application.ApplicationName, e.Message);
                            }
                        }
                    }
                    finally
                    {
                        Environment.CurrentDirectory = currentDirectory;
                    }
                    
                    break;
                }

                // Uninstall and UA Applications
                case "-ua":
                case "-uas":
                {
                    // save the current directory so it can be restored.
                    string currentDirectory = Environment.CurrentDirectory;

                    try
                    {
                        Environment.CurrentDirectory = new FileInfo(filePath).DirectoryName;

                        // load the configurations from the file.
                        InstalledApplicationCollection applications = null;

                        try
                        {
                            applications = InstalledApplication.Load(filePath);
                        }
                        catch (Exception e)
                        {
                            throw ServiceResultException.Create(
                                StatusCodes.BadConfigurationError, 
                                e,
                                "Could not read configuration file. {0}", 
                                filePath);
                        }

                        // update the application configuration.
                        foreach (InstalledApplication application in applications)
                        {
                            try
                            {
                                ConfigUtils.UninstallApplication(application);
                                Utils.Trace("Uninstalled application '{0}'", application.ApplicationName); 
                            }
                            catch (Exception e)
                            {
                                Utils.Trace("Error uninstalling application '{0}': {1}", application.ApplicationName, e.Message); 
                            }
                        }
                    }
                    finally
                    {
                        Environment.CurrentDirectory = currentDirectory;
                    }
                    
                    break;
                }
                    
                // Register UA COM Pseudo-Servers
                case "-rp":
                case "-rps":
                {
                    // save the current directory so it can be restored.
                    string currentDirectory = Environment.CurrentDirectory;

                    try
                    {
                        Environment.CurrentDirectory = new FileInfo(filePath).DirectoryName;

                        // load the endpoints from the file.
                        ConfiguredEndpointCollection endpoints = null;

                        try
                        {
                            endpoints = ConfiguredEndpointCollection.Load(filePath);
                        }
                        catch (Exception e)
                        {
                            throw ServiceResultException.Create(
                                StatusCodes.BadConfigurationError,
                                e,
                                "Could not read configuration file. {0}",
                                filePath);
                        }

                        // update the application configuration.
                        foreach (ConfiguredEndpoint endpoint in endpoints.Endpoints)
                        {
                            if (endpoint.ComIdentity == null)
                            {
                                continue;
                            }

                            try
                            {
                                PseudoComServer.Save(endpoint);
                                Utils.Trace("Registered COM pseudo-server '{0}'", endpoint.ComIdentity.ProgId);
                            }
                            catch (Exception e)
                            {
                                Utils.Trace("Error Registering COM pseudo-server '{0}': {1}", endpoint.ComIdentity.ProgId, e.Message);
                            }
                        }
                    }
                    finally
                    {
                        Environment.CurrentDirectory = currentDirectory;
                    }
                    
                    break;
                }
                    
                // Unregister UA COM Pseudo-Servers
                case "-up":
                case "-ups":
                {
                    // save the current directory so it can be restored.
                    string currentDirectory = Environment.CurrentDirectory;

                    try
                    {
                        Environment.CurrentDirectory = new FileInfo(filePath).DirectoryName;

                        // load the endpoints from the file.
                        ConfiguredEndpointCollection endpoints = null;

                        try
                        {
                            endpoints = ConfiguredEndpointCollection.Load(filePath);
                        }
                        catch (Exception e)
                        {
                            throw ServiceResultException.Create(
                                StatusCodes.BadConfigurationError,
                                e,
                                "Could not read configuration file. {0}",
                                filePath);
                        }

                        // update the application configuration.
                        foreach (ConfiguredEndpoint endpoint in endpoints.Endpoints)
                        {
                            if (endpoint.ComIdentity == null)
                            {
                                continue;
                            }

                            try
                            {
                                PseudoComServer.Delete(endpoint.ComIdentity.Clsid);
                                Utils.Trace("Unregistered COM pseudo-server '{0}'", endpoint.ComIdentity.ProgId);
                            }
                            catch (Exception e)
                            {
                                Utils.Trace("Error unregistered COM pseudo-server '{0}': {1}", endpoint.ComIdentity.ProgId, e.Message);
                            }
                        }
                    }
                    finally
                    {
                        Environment.CurrentDirectory = currentDirectory;
                    }
                    
                    break;
                }

                // some other command which is ignored.
                default:
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Finds the first child element with the specified name.
        /// </summary>
        private static XmlElement FindFirstElement(XmlElement parent, string localName, string namespaceUri)
        {
            if (parent == null)
            {
                return null;
            }

            for (XmlNode child = parent.FirstChild; child != null; child = child.NextSibling)
            {
                XmlElement element = child as XmlElement;

                if (element != null)
                {
                    if (element.LocalName == localName && element.NamespaceURI == namespaceUri)
                    {
                        return element;
                    }

                    break;
                }
            }

            return null;
        }

        /// <summary>
        /// Updates the configuration location for the specified 
        /// </summary>
        public static void UpdateConfigurationLocation(string executablePath, string configurationPath)
        {
            string configFilePath = Utils.Format("{0}.config", executablePath);

            // not all apps have an app.config file.
            if (!File.Exists(configFilePath))
            {
                return;
            }

            // load from file.
            XmlDocument document = new XmlDocument();
            document.Load(configFilePath);

            for (XmlNode child = document.DocumentElement.FirstChild; child != null; child = child.NextSibling)
            {
                // ignore non-element.
                XmlElement element = child as XmlElement;

                if (element == null)
                {
                    continue;
                }

                // look for the configuration location.
                XmlElement location = FindFirstElement(element, "ConfigurationLocation", Namespaces.OpcUaConfig);

                if (location == null)
                {
                    continue;
                }
                
                // find the file path.
                XmlElement filePath = FindFirstElement(location, "FilePath", Namespaces.OpcUaConfig);

                if (filePath == null)
                {
                    filePath = location.OwnerDocument.CreateElement("FilePath", Namespaces.OpcUaConfig);
                    location.InsertBefore(filePath, location.FirstChild);
                }
                
                filePath.InnerText = configurationPath;
                break;
            }
            
            // save configuration file.
            Stream ostrm = File.Open(configFilePath, FileMode.Create, FileAccess.Write);
			XmlTextWriter writer = new XmlTextWriter(ostrm, System.Text.Encoding.UTF8);
            writer.Formatting = Formatting.Indented;    

            try
            {            
                document.Save(writer);
            }
            finally
            {
                writer.Close();
            }
        }
        
        /// <summary>
        /// Sets the defaults for all fields.
        /// </summary>
        /// <param name="application">The application.</param>
        private static void SetDefaults(InstalledApplication application)
        { 
            // create a default product name.
            if (String.IsNullOrEmpty(application.ProductName))
            {
                application.ProductName = application.ApplicationName;
            }

            // create a default uri.
            if (String.IsNullOrEmpty(application.ApplicationUri))
            {
                application.ApplicationUri = Utils.Format("http://localhost/{0}/{1}", application.ApplicationName, Guid.NewGuid());
            }

            // make the uri specify the local machine.
            application.ApplicationUri = Utils.ReplaceLocalhost(application.ApplicationUri);

            // set a default application store.
            if (application.ApplicationCertificate == null)
            {
                application.ApplicationCertificate = new Opc.Ua.Security.CertificateIdentifier();
                application.ApplicationCertificate.StoreType = Utils.DefaultStoreType;
                application.ApplicationCertificate.StorePath = Utils.DefaultStorePath;
                application.ApplicationCertificate.SubjectName = application.ApplicationName;
            }

            if (application.IssuerCertificateStore == null)
            {
                application.IssuerCertificateStore = new Opc.Ua.Security.CertificateStoreIdentifier();
                application.IssuerCertificateStore.StoreType = Utils.DefaultStoreType;
                application.IssuerCertificateStore.StorePath = Utils.DefaultStorePath;
            }

            if (application.TrustedCertificateStore == null)
            {
                application.TrustedCertificateStore = new Opc.Ua.Security.CertificateStoreIdentifier();
                application.TrustedCertificateStore.StoreType = Utils.DefaultStoreType;
                application.TrustedCertificateStore.StorePath = Utils.DefaultStorePath;
            }

            try
            {
                Utils.GetAbsoluteDirectoryPath(application.ApplicationCertificate.StorePath, true, true, true);
            }
            catch (Exception e)
            {
                Utils.Trace("Could not access the machine directory: {0} '{1}'", application.ApplicationCertificate.StorePath, e);
            }

            if (application.RejectedCertificatesStore == null)
            {
                application.RejectedCertificatesStore = new Opc.Ua.Security.CertificateStoreIdentifier();
                application.RejectedCertificatesStore.StoreType = CertificateStoreType.Directory;
                application.RejectedCertificatesStore.StorePath = "%CommonApplicationData%\\OPC Foundation\\CertificateStores\\RejectedCertificates";
            }

            if (application.RejectedCertificatesStore.StoreType == CertificateStoreType.Directory)
            {
                try
                {
                    Utils.GetAbsoluteDirectoryPath(application.RejectedCertificatesStore.StorePath, true, true, true);
                }
                catch (Exception e)
                {
                    Utils.Trace("Could not access rejected certificates directory: {0} '{1}'", application.RejectedCertificatesStore.StorePath, e);
                }
            }
        }

        /// <summary>
        /// Installs a UA application.
        /// </summary>
        public static void InstallApplication(
            InstalledApplication application, 
            bool autostart, 
            bool configureFirewall)
        {
            // validate the executable file.
            string executableFile = Utils.GetAbsoluteFilePath(application.ExecutableFile, true, true, false);
            
            // get the default application name from the executable file.
            FileInfo executableFileInfo = new FileInfo(executableFile);

            string applicationName = executableFileInfo.Name.Substring(0, executableFileInfo.Name.Length-4);

            // choose a default configuration file.
            if (String.IsNullOrEmpty(application.ConfigurationFile))
            {
                application.ConfigurationFile = Utils.Format(
                    "{0}\\{1}.Config.xml", 
                    executableFileInfo.DirectoryName, 
                    applicationName);                
            }

            // validate the configuration file.
            string configurationFile = Utils.GetAbsoluteFilePath(application.ConfigurationFile, true, false, false);
            
            // create a new file if one does not exist.
            bool useExisting = true;

            if (configurationFile == null)
            {
                configurationFile = Utils.GetAbsoluteFilePath(application.ConfigurationFile, true, true, true);
                useExisting = false;
            }

            // create the default configuration file.

            if (useExisting)
            {
                try
                {
                    Opc.Ua.Security.SecuredApplication existingSettings = new Opc.Ua.Security.SecurityConfigurationManager().ReadConfiguration(configurationFile);
                    
                    // copy current settings
                    application.ApplicationType = existingSettings.ApplicationType;
                    application.BaseAddresses = existingSettings.BaseAddresses;
                    application.ApplicationCertificate = existingSettings.ApplicationCertificate;
                    application.ApplicationName = existingSettings.ApplicationName;
                    application.ProductName = existingSettings.ProductName;
                    application.RejectedCertificatesStore = existingSettings.RejectedCertificatesStore;
                    application.TrustedCertificateStore = existingSettings.TrustedCertificateStore;
                    application.TrustedCertificates = existingSettings.TrustedCertificates;
                    application.IssuerCertificateStore = existingSettings.IssuerCertificateStore;
                    application.IssuerCertificates = application.IssuerCertificates;
                    application.UseDefaultCertificateStores = false;
                }
                catch (Exception e)
                {
                    useExisting = false;
                    Utils.Trace("WARNING. Existing configuration file could not be loaded: {0}.\r\nReplacing with default: {1}", e.Message, configurationFile);
                    File.Copy(configurationFile, configurationFile + ".bak", true);
                }
            }
            
            // create the configuration file from the default.
            if (!useExisting)
            {
                try
                {
                    string installationFile = Utils.Format(
                        "{0}\\Install\\{1}.Config.xml", 
                        executableFileInfo.Directory.Parent.FullName, 
                        applicationName);
                    
                    if (!File.Exists(installationFile))
                    {
                        Utils.Trace("Could not find default configuation at: {0}", installationFile);
                    }
                        
                    File.Copy(installationFile, configurationFile, true);
                    Utils.Trace("File.Copy({0}, {1})", installationFile, configurationFile);
                }
                catch (Exception e)
                {
                    Utils.Trace("Could not copy default configuation to: {0}. Error={1}.", configurationFile, e.Message);
                }
            }

            // create a default application name.
            if (String.IsNullOrEmpty(application.ApplicationName))
            {
                application.ApplicationName = applicationName;
            }
                        
            // create a default product name.
            if (String.IsNullOrEmpty(application.ProductName))
            {
                application.ProductName = application.ApplicationName;
            }

            // create a default uri.
            if (String.IsNullOrEmpty(application.ApplicationUri))
            {
                application.ApplicationUri = Utils.Format("http://localhost/{0}/{1}", applicationName, Guid.NewGuid());
            }
            
            // make the uri specify the local machine.
            application.ApplicationUri = Utils.ReplaceLocalhost(application.ApplicationUri);

            // set a default application store.
            if (application.ApplicationCertificate == null)
            {
                application.ApplicationCertificate = new Opc.Ua.Security.CertificateIdentifier();
                application.ApplicationCertificate.StoreType = Utils.DefaultStoreType;
                application.ApplicationCertificate.StorePath = Utils.DefaultStorePath;
            }
            
            if (application.UseDefaultCertificateStores)
            {
                if (application.IssuerCertificateStore == null)
                {
                    application.IssuerCertificateStore = new Opc.Ua.Security.CertificateStoreIdentifier();
                    application.IssuerCertificateStore.StoreType = Utils.DefaultStoreType;
                    application.IssuerCertificateStore.StorePath = Utils.DefaultStorePath;
                }

                if (application.TrustedCertificateStore == null)
                {
                    application.TrustedCertificateStore = new Opc.Ua.Security.CertificateStoreIdentifier();
                    application.TrustedCertificateStore.StoreType = Utils.DefaultStoreType;
                    application.TrustedCertificateStore.StorePath = Utils.DefaultStorePath;
                }
                
                try
                {
                    Utils.GetAbsoluteDirectoryPath(application.TrustedCertificateStore.StorePath, true, true, true);
                }
                catch (Exception e)
                {
                    Utils.Trace("Could not access the machine directory: {0} '{1}'", application.RejectedCertificatesStore.StorePath, e);
                }

                if (application.RejectedCertificatesStore == null)
                {
                    application.RejectedCertificatesStore = new Opc.Ua.Security.CertificateStoreIdentifier();
                    application.RejectedCertificatesStore.StoreType = CertificateStoreType.Directory;
                    application.RejectedCertificatesStore.StorePath = "%CommonApplicationData%\\OPC Foundation\\CertificateStores\\RejectedCertificates";

                    StringBuilder buffer = new StringBuilder();

                    buffer.Append(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));
                    buffer.Append("\\OPC Foundation");
                    buffer.Append("\\RejectedCertificates");

                    string folderPath = buffer.ToString();

                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }
                }
            }


            // check for valid certificate (discard invalid certificates).
            CertificateIdentifier applicationCertificate = Opc.Ua.Security.SecuredApplication.FromCertificateIdentifier(application.ApplicationCertificate); 
            X509Certificate2 certificate = applicationCertificate.Find(true);

            if (certificate == null)
            {
                certificate = applicationCertificate.Find(false);

                if (certificate != null)
                {
                    Utils.Trace(
                        "Found existing certificate but it does not have a private key: Store={0}, Certificate={1}", 
                        application.ApplicationCertificate.StorePath,
                        application.ApplicationCertificate);
                }
                else
                {            
                    Utils.Trace(
                        "Existing certificate could not be found: Store={0}, Certificate={1}", 
                        application.ApplicationCertificate.StorePath,
                        application.ApplicationCertificate);
                }
            }
            
            // check if no certificate exists.
            if (certificate == null)
            {
                certificate = CreateCertificateForApplication(application);
            }
            
            // ensure the application certificate is in the trusted peers store.
            try
            {
                CertificateStoreIdentifier certificateStore = Opc.Ua.Security.SecuredApplication.FromCertificateStoreIdentifier(application.TrustedCertificateStore);

                using (ICertificateStore store = certificateStore.OpenStore())
                {
                    X509Certificate2 peerCertificate = store.FindByThumbprint(certificate.Thumbprint);
 
                    if (peerCertificate == null)
                    {
                        store.Add(new X509Certificate2(certificate.GetRawCertData()));
                    }
                }
            }
            catch (Exception e)
            {
                Utils.Trace(
                    "Could not add certificate '{0}' to trusted peer store '{1}'. Error={2}", 
                    certificate.Subject,
                    application.TrustedCertificateStore, 
                    e.Message);
            }

            // locally register the certficate OIDs.
            if (application.LocallyRegisterOIDs)
            {
                try
                {
                    LocallyRegisterCertificateOIDs(certificate);
                }
                catch (Exception e)
                {
                    Utils.Trace(
                        "Could not register OIDs used for certificate '{0}'. Error={1}", 
                        certificate.Subject, 
                        e.Message);
                }
            }

            // update configuration file location.
            UpdateConfigurationLocation(executableFile, configurationFile);

            // update configuration file.
            new Opc.Ua.Security.SecurityConfigurationManager().WriteConfiguration(configurationFile, application);
            
            // configure firewall.
            if (configureFirewall && application.ConfigureFirewall)
            {
                if (application.BaseAddresses != null && application.BaseAddresses.Count > 0)
                {
                    try
                    {
                        SetFirewallAccess(application, executableFile);
                    }
                    catch (Exception e)
                    {
                        Utils.Trace("Could not set firewall access for executable: {0}. Error={1}", executableFile, e.Message);
                    }
                }
            }

            ApplicationAccessRuleCollection accessRules = application.AccessRules;
            bool noRulesDefined = application.AccessRules == null || application.AccessRules.Count == 0;
            
            // add the default access rules.
            if (noRulesDefined)
            {
                ApplicationAccessRule rule = new ApplicationAccessRule();
                
                rule.IdentityName = WellKnownSids.Administrators;
                rule.RuleType     = AccessControlType.Allow;
                rule.Right        = ApplicationAccessRight.Configure;

                accessRules.Add(rule);

                rule = new ApplicationAccessRule();
                
                rule.IdentityName = WellKnownSids.Users;
                rule.RuleType     = AccessControlType.Allow;
                rule.Right        = ApplicationAccessRight.Update;

                accessRules.Add(rule);
            }
             
            // ensure the service account has priviledges.
            if (application.InstallAsService)
            {
                // check if a specific account is assigned.
                AccountInfo accountInfo = null;

                if (!String.IsNullOrEmpty(application.ServiceUserName))
                {
                    accountInfo = AccountInfo.Create(application.ServiceUserName);
                }

                // choose a built-in service account.
                if (accountInfo == null)
                {
                    accountInfo = AccountInfo.Create(WellKnownSids.NetworkService);
                    
                    if (accountInfo == null)
                    {
                        accountInfo = AccountInfo.Create(WellKnownSids.LocalSystem);
                    }
                }

                ApplicationAccessRule rule = new ApplicationAccessRule();
                
                rule.IdentityName = accountInfo.ToString();
                rule.RuleType     = AccessControlType.Allow;
                rule.Right        = ApplicationAccessRight.Run;

                accessRules.Add(rule);
            }

            // set the permissions for the HTTP endpoints used by the application.
            if (configureFirewall && application.BaseAddresses != null && application.BaseAddresses.Count > 0)
            {
                for (int ii = 0; ii < application.BaseAddresses.Count; ii++)
                {
                    Uri url = Utils.ParseUri(application.BaseAddresses[ii]);

                    if (url != null)
                    {
                        if (url.Scheme == Uri.UriSchemeHttp || url.Scheme == Uri.UriSchemeHttps)
                        {
                            try
                            {
                                HttpAccessRule.SetAccessRules(url, accessRules, true);                    
                                Utils.Trace("Added HTTP access rules for URL: {0}", url);    
                            }
                            catch (Exception e)
                            {
                                Utils.Trace("Could not set HTTP access rules for URL: {0}. Error={1}", url, e.Message);

                                for (int jj = 0; jj < accessRules.Count; jj++)
                                {
                                    ApplicationAccessRule rule = accessRules[jj];

                                    Utils.Trace(
                                        (int)Utils.TraceMasks.Error,
                                        "IdentityName={0}, Right={1}, RuleType={2}",
                                        rule.IdentityName,
                                        rule.Right,
                                        rule.RuleType);
                                }
                            }
                        }
                    }
                }
            }
            
            // set permissions on the local certificate store.
            SetCertificatePermissions(
                application,
                applicationCertificate, 
                accessRules, 
                false);

           // set permissions on the local certificate store.
            if (application.RejectedCertificatesStore != null)
            {
                // need to grant full control to certificates in the RejectedCertificatesStore.
                foreach (ApplicationAccessRule rule in accessRules)
                {
                    if (rule.RuleType == AccessControlType.Allow)
                    {
                        rule.Right = ApplicationAccessRight.Configure;
                    }
                }

                CertificateStoreIdentifier rejectedCertificates = Opc.Ua.Security.SecuredApplication.FromCertificateStoreIdentifier(application.RejectedCertificatesStore);

                using (ICertificateStore store = rejectedCertificates.OpenStore())
                {
                    if (store.SupportsAccessControl)
                    {
                        store.SetAccessRules(accessRules, false);
                    }
                }
            }

            // install as a service.
            if (application.InstallAsService)
            {
                ServiceInstaller.UnInstallService(application.ApplicationName);

                StartMode startMode = application.ServiceStartMode;

                if (!autostart)
                {
                    startMode = StartMode.Manual;
                }

                bool start = true;

                bool result = ServiceInstaller.InstallService(
                    executableFileInfo.FullName,
                    application.ApplicationName,
                    application.ApplicationName,
                    application.ServiceDescription,
                    startMode,
                    application.ServiceUserName,
                    application.ServicePassword,
                    ref start);

                if (!result)
                {
                    throw new ApplicationException("Could not install service.");
                }
            }
        }

        /// <summary>
        /// Creates a new certificate for application.
        /// </summary>
        /// <param name="application">The application.</param>
        private static X509Certificate2 CreateCertificateForApplication(InstalledApplication application)
        {
            // build list of domains.
            List<string> domains = new List<string>();

            if (application.BaseAddresses != null)
            {
                foreach (string baseAddress in application.BaseAddresses)
                {
                    Uri uri = Utils.ParseUri(baseAddress);

                    if (uri != null)
                    {
                        string domain = uri.DnsSafeHost;

                        if (String.Compare(domain, "localhost", StringComparison.OrdinalIgnoreCase) == 0)
                        {
                            domain = System.Net.Dns.GetHostName();
                        }

                        if (!Utils.FindStringIgnoreCase(domains, domain))
                        {
                            domains.Add(domain);
                        }
                    }
                }
            }

            // must at least of the localhost.
            if (domains.Count == 0)
            {
                domains.Add(System.Net.Dns.GetHostName());
            }

            // create the certificate.
            X509Certificate2 certificate = Opc.Ua.CertificateFactory.CreateCertificate(
                application.ApplicationCertificate.StoreType,
                application.ApplicationCertificate.StorePath,
                application.ApplicationUri,
                application.ApplicationName,
                Utils.Format("CN={0}/DC={1}", application.ApplicationName, domains[0]),
                domains,
                1024,
                300);

            CertificateIdentifier applicationCertificate = Opc.Ua.Security.SecuredApplication.FromCertificateIdentifier(application.ApplicationCertificate);
            return applicationCertificate.LoadPrivateKey(null);
        }

        /// <summary>
        /// Updates the access permissions for the certificate store.
        /// </summary>
        private static void SetCertificatePermissions(
            Opc.Ua.Security.SecuredApplication application,
            CertificateIdentifier id,
            IList<ApplicationAccessRule> accessRules,
            bool replaceExisting)
        {
            if (id == null || accessRules == null || accessRules.Count == 0)
            {
                return;
            }

            try
            {
                using (ICertificateStore store = id.OpenStore())
                {
                    if (store.SupportsCertificateAccessControl)
                    {
                        store.SetAccessRules(id.Thumbprint, accessRules, replaceExisting);
                    }
                }
            }
            catch (Exception e)
            {
                Utils.Trace("Could not set permissions for certificate store: {0}. Error={1}", id, e.Message);

                for (int jj = 0; jj < accessRules.Count; jj++)
                {
                    ApplicationAccessRule rule = accessRules[jj];

                    Utils.Trace(
                        (int)Utils.TraceMasks.Error,
                        "IdentityName={0}, Right={1}, RuleType={2}",
                        rule.IdentityName,
                        rule.Right,
                        rule.RuleType);
                }
            }
        }

        /// <summary>
        /// Uninstalls a UA application.
        /// </summary>
        public static void UninstallApplication(InstalledApplication application)
        {
            // validate the executable file.
            string executableFile = Utils.GetAbsoluteFilePath(application.ExecutableFile, true, true, false); 
            
            // get the default application name from the executable file.
            FileInfo executableFileInfo = new FileInfo(executableFile);
            string applicationName = executableFileInfo.Name.Substring(0, executableFileInfo.Name.Length-4);

            // choose a default configuration file.
            if (String.IsNullOrEmpty(application.ConfigurationFile))
            {
                application.ConfigurationFile = Utils.Format(
                    "{0}\\{1}.Config.xml", 
                    executableFileInfo.DirectoryName, 
                    applicationName);                
            }
            
            // install as a service.
            if (application.InstallAsService)
            {
                ServiceInstaller.UnInstallService(application.ApplicationName);
            }

            // validate the configuration file.
            string configurationFile = Utils.GetAbsoluteFilePath(application.ConfigurationFile, true, false, false); 
            
            if (configurationFile != null)
            {
                // load the current configuration.
                Opc.Ua.Security.SecuredApplication security = new Opc.Ua.Security.SecurityConfigurationManager().ReadConfiguration(configurationFile);

                // delete the application certificates.
                if (application.DeleteCertificatesOnUninstall)
                {
                    CertificateIdentifier id = Opc.Ua.Security.SecuredApplication.FromCertificateIdentifier(security.ApplicationCertificate);
                                        
                    // delete public key from trusted peers certificate store.
                    try
                    {
                        CertificateStoreIdentifier certificateStore = Opc.Ua.Security.SecuredApplication.FromCertificateStoreIdentifier(security.TrustedCertificateStore);

                        using (ICertificateStore store = certificateStore.OpenStore())
                        {
                            X509Certificate2 peerCertificate = store.FindByThumbprint(id.Thumbprint);

                            if (peerCertificate != null)
                            {
                                store.Delete(peerCertificate.Thumbprint);
                            }
                        }                      
                    }
                    catch (Exception e)
                    {
                        Utils.Trace("Could not delete certificate '{0}' from store. Error={1}", id, e.Message);
                    }    

                    // delete private key from application certificate store.
                    try
                    {
                        using (ICertificateStore store = id.OpenStore())
                        {
                            store.Delete(id.Thumbprint);
                        }
                    }
                    catch (Exception e)
                    {
                        Utils.Trace("Could not delete certificate '{0}' from store. Error={1}", id, e.Message);
                    }        
                    
                    // permentently delete any UA defined stores if they are now empty.
                    try
                    {
                        WindowsCertificateStore store = new WindowsCertificateStore();
                        store.Open("LocalMachine\\UA Applications");

                        if (store.Enumerate().Count == 0)
                        {
                            store.PermanentlyDeleteStore();
                        }
                    }
                    catch (Exception e)
                    {
                        Utils.Trace("Could not delete certificate '{0}' from store. Error={1}", id, e.Message);
                    }
                }

                // configure firewall.
                if (application.ConfigureFirewall)
                {
                    if (security.BaseAddresses != null && security.BaseAddresses.Count > 0)
                    {
                        try
                        {
                            RemoveFirewallAccess(security, executableFile);
                        }
                        catch (Exception e)
                        {
                            Utils.Trace("Could not remove firewall access for executable: {0}. Error={1}", executableFile, e.Message);
                        }
                    }
                }

                // remove the permissions for the HTTP endpoints used by the application.
                if (application.BaseAddresses != null && application.BaseAddresses.Count > 0)
                {
                    List<ApplicationAccessRule> noRules = new List<ApplicationAccessRule>();

                    for (int ii = 0; ii < application.BaseAddresses.Count; ii++)
                    {
                        Uri url = Utils.ParseUri(application.BaseAddresses[ii]);

                        if (url != null)
                        {
                            if (url.Scheme == Uri.UriSchemeHttp || url.Scheme == Uri.UriSchemeHttps)
                            {
                                try
                                {
                                    HttpAccessRule.SetAccessRules(url, noRules, true);                                    
                                    Utils.Trace("Removed HTTP access rules for URL: {0}", url);    
                                }
                                catch (Exception e)
                                {
                                    Utils.Trace("Could not remove HTTP access rules for URL: {0}. Error={1}", url, e.Message);
                                }
                            }
                        }
                    }
                }
            }
        }

		/// <summary>
		/// Registers the COM types in the specified assembly.
		/// </summary>
		public static List<System.Type> RegisterComTypes(string filePath)
		{
			// load assmebly.
			Assembly assembly = Assembly.LoadFrom(filePath);

			// check that the correct assembly is being registered.
			VerifyCodebase(assembly, filePath);

			RegistrationServices services = new RegistrationServices();

			// list types to register/unregister.
			List<System.Type> types = new List<System.Type>(services.GetRegistrableTypesInAssembly(assembly));

			// register types.
			if (types.Count > 0)
			{
				// unregister types first.	
				if (!services.UnregisterAssembly(assembly))
				{
					throw new ApplicationException("Unregister COM Types Failed.");
				}

				// register types.	
				if (!services.RegisterAssembly(assembly, AssemblyRegistrationFlags.SetCodeBase))
				{
					throw new ApplicationException("Register COM Types Failed.");
				}
			}

			return types;
		}

		/// <summary>
		/// Checks that the assembly loaded has the expected codebase.
		/// </summary>
		private static void VerifyCodebase(Assembly assembly, string filepath)
		{
			string codebase = assembly.CodeBase.ToLower();
			string normalizedPath = filepath.Replace('\\', '/').Replace("//", "/").ToLower();

			if (!normalizedPath.StartsWith("file:///"))
			{
				normalizedPath = "file:///" + normalizedPath;
			}

			if (codebase != normalizedPath)
			{
				throw new ApplicationException(String.Format("Duplicate assembly loaded. You need to restart the configuration tool.\r\n{0}\r\n{1}", codebase, normalizedPath));
			}
		}

		/// <summary>
		/// Unregisters the COM types in the specified assembly.
		/// </summary>
		public static List<System.Type> UnregisterComTypes(string filePath)
		{
			// load assmebly.
			Assembly assembly = Assembly.LoadFrom(filePath);

			// check that the correct assembly is being unregistered.
			VerifyCodebase(assembly, filePath);

			RegistrationServices services = new RegistrationServices();

			// list types to register/unregister.
			List<System.Type> types = new List<System.Type>(services.GetRegistrableTypesInAssembly(assembly));

			// unregister types.	
			if (!services.UnregisterAssembly(assembly))
			{
				throw new ApplicationException("Unregister COM Types Failed.");
			}

			return types;
		}

        /// <summary>
        /// Creates an instance of the NetFwMgr Class
        /// </summary>
        public static NetFwTypeLib.INetFwMgr GetNetFwMgr()
        {
            Type type = Type.GetTypeFromCLSID(new Guid("{304CE942-6E39-40D8-943A-B913C40C9CD4}"));
            return (NetFwTypeLib.INetFwMgr)Activator.CreateInstance(type);
        }
        
        /// <summary>
        /// Creates an instance of the NetFwAuthorizedApplication Class
        /// </summary>
        public static NetFwTypeLib.INetFwAuthorizedApplication GetNetFwAuthorizedApplication()
        {
            Type type = Type.GetTypeFromCLSID(new Guid("{EC9846B3-2762-4A6B-A214-6ACB603462D2}"));
            return (NetFwTypeLib.INetFwAuthorizedApplication)Activator.CreateInstance(type);
        }
        
        /// <summary>
        /// Creates an instance of the NetFwOpenPort Class
        /// </summary>
        public static NetFwTypeLib.INetFwOpenPort GetNetFwOpenPort()
        {
            Type type = Type.GetTypeFromCLSID(new Guid("{0CA545C6-37AD-4A6C-BF92-9F7610067EF5}"));
            return (NetFwTypeLib.INetFwOpenPort)Activator.CreateInstance(type);
        }
        
        /// <summary>
        /// Configures the firewall to allow access to the specified application.
        /// </summary>
        public static void SetFirewallAccess(Opc.Ua.Security.SecuredApplication application, string executablePath)
        {
            if (application != null)
            {
                SetFirewallAccess(application.ApplicationName, executablePath, application.BaseAddresses);
            }
        }

        /// <summary>
        /// Configures the firewall to allow access to the specified application.
        /// </summary>
        public static void SetFirewallAccess(string applicationName, string executablePath, IList<string> baseAddresses)
        {
            NetFwTypeLib.INetFwMgr fwm = GetNetFwMgr();

            NetFwTypeLib.INetFwAuthorizedApplication app = GetNetFwAuthorizedApplication();

            app.ProcessImageFileName = executablePath;
            app.IpVersion            = NetFwTypeLib.NET_FW_IP_VERSION_.NET_FW_IP_VERSION_ANY;
            app.Name                 = applicationName;
            app.Scope                = NetFwTypeLib.NET_FW_SCOPE_.NET_FW_SCOPE_ALL;
            app.Enabled              = true;

            fwm.LocalPolicy.CurrentProfile.AuthorizedApplications.Add(app);

            if (baseAddresses != null)
            {
                for (int ii = 0; ii < baseAddresses.Count; ii++)
                {
                    Uri url = Utils.ParseUri(baseAddresses[ii]);

                    // ignore invalid urls.
                    if (url == null || url.Port == -1)
                    {
                        continue;
                    }

                    NetFwTypeLib.INetFwOpenPort port = GetNetFwOpenPort();

                    port.Name = String.Format("{0} ({1} {2})", applicationName, url.Scheme.ToUpper(), url.Port);
                    port.Port = url.Port;
                    port.Protocol = NetFwTypeLib.NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP;
                    port.Scope = NetFwTypeLib.NET_FW_SCOPE_.NET_FW_SCOPE_ALL;
                    port.IpVersion = NetFwTypeLib.NET_FW_IP_VERSION_.NET_FW_IP_VERSION_ANY;
                    port.Enabled = true;

                    fwm.LocalPolicy.CurrentProfile.GloballyOpenPorts.Add(port);
                }
            }
        }

        /// <summary>
        /// Checks if the firewall has been configured.
        /// </summary>
        public static bool CheckFirewallAccess(string executablePath, StringCollection baseAddresses)
        {
            NetFwTypeLib.INetFwMgr fwm = GetNetFwMgr();

            bool found = false;

            foreach (NetFwTypeLib.INetFwAuthorizedApplication app in fwm.LocalPolicy.CurrentProfile.AuthorizedApplications)
            {
                if (app.ProcessImageFileName == executablePath)
                {
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                return false;
            }

            if (baseAddresses != null)
            {
                for (int ii = 0; ii < baseAddresses.Count; ii++)
                {
                    Uri url = Utils.ParseUri(baseAddresses[ii]);

                    // ignore invalid urls.
                    if (url == null || url.Port == -1)
                    {
                        continue;
                    }

                    foreach (NetFwTypeLib.INetFwOpenPort port in fwm.LocalPolicy.CurrentProfile.GloballyOpenPorts)
                    {
                        if (port.Port == url.Port)
                        {
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Returns the firewall access granted to an application.
        /// </summary>
        public static int[] GetFirewallAccess(string executablePath)
        {
            NetFwTypeLib.INetFwMgr fwm = GetNetFwMgr();

            string applicationName = null;

            foreach (NetFwTypeLib.INetFwAuthorizedApplication app in fwm.LocalPolicy.CurrentProfile.AuthorizedApplications)
            {
                if (app.Enabled && app.ProcessImageFileName == executablePath)
                {
                    applicationName = app.Name;
                    break;
                }
            }

            if (applicationName == null)
            {
                return null;
            }

            List<int> ports = new List<int>();

            foreach (NetFwTypeLib.INetFwOpenPort port in fwm.LocalPolicy.CurrentProfile.GloballyOpenPorts)
            {
                if (!port.Enabled || port.Protocol != NetFwTypeLib.NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP)
                {
                    continue;
                }

                ports.Add(port.Port);
            }

            return ports.ToArray();
        }

        /// <summary>
        /// Returns the firewall access granted to an application.
        /// </summary>
        public static void SetFirewallAccess(string executablePath, params int[] ports)
        {
            NetFwTypeLib.INetFwMgr fwm = GetNetFwMgr();

            string applicationName = null;

            foreach (NetFwTypeLib.INetFwAuthorizedApplication app in fwm.LocalPolicy.CurrentProfile.AuthorizedApplications)
            {
                if (app.ProcessImageFileName == executablePath)
                {
                    applicationName = app.Name;

                    if (!app.Enabled)
                    {
                        app.Enabled = true;
                    }

                    break;
                }
            }

            if (applicationName == null)
            {
                FileInfo fileInfo = new FileInfo(executablePath);
                applicationName = fileInfo.Name.Substring(0, fileInfo.Name.Length - fileInfo.Extension.Length);
                
                NetFwTypeLib.INetFwAuthorizedApplication app = GetNetFwAuthorizedApplication();

                app.ProcessImageFileName = executablePath;
                app.IpVersion = NetFwTypeLib.NET_FW_IP_VERSION_.NET_FW_IP_VERSION_ANY;
                app.Name = applicationName;
                app.Scope = NetFwTypeLib.NET_FW_SCOPE_.NET_FW_SCOPE_ALL;
                app.Enabled = true;

                fwm.LocalPolicy.CurrentProfile.AuthorizedApplications.Add(app);
            }

            if (ports != null)
            {
                for (int ii = 0; ii < ports.Length; ii++)
                {
                    NetFwTypeLib.INetFwOpenPort port = null;

                    foreach (NetFwTypeLib.INetFwOpenPort entry in fwm.LocalPolicy.CurrentProfile.GloballyOpenPorts)
                    {
                        if (entry.Port == ports[ii] && entry.Protocol == NetFwTypeLib.NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP)
                        {
                            port = entry;
                            break;
                        }
                    }

                    if (port == null)
                    {
                        port = GetNetFwOpenPort();

                        port.Name = String.Format("OPC UA {0}", ports[ii]);
                        port.Port = ports[ii];
                        port.Protocol = NetFwTypeLib.NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP;
                        port.Scope = NetFwTypeLib.NET_FW_SCOPE_.NET_FW_SCOPE_ALL;
                        port.IpVersion = NetFwTypeLib.NET_FW_IP_VERSION_.NET_FW_IP_VERSION_ANY;
                        port.Enabled = true;

                        fwm.LocalPolicy.CurrentProfile.GloballyOpenPorts.Add(port);
                    }

                    if (!port.Enabled)
                    {
                        port.Enabled = true;
                    }
                }
            }
        }

        /// <summary>
        /// Removes the firewall access granted to the specified ports.
        /// </summary>
        public static void RemoveFirewallAccess(params int[] ports)
        {
            NetFwTypeLib.INetFwMgr fwm = GetNetFwMgr();

            if (ports != null)
            {
                for (int ii = 0; ii < ports.Length; ii++)
                {
                    fwm.LocalPolicy.CurrentProfile.GloballyOpenPorts.Remove(
                       ports[ii],
                       NetFwTypeLib.NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP);
                }
            }
        }      

        /// <summary>
        /// Configures the firewall to remove access to the specified application.
        /// </summary>
        public static void RemoveFirewallAccess(Opc.Ua.Security.SecuredApplication application, string executablePath)
        {
            if (application != null)
            {
                RemoveFirewallAccess(executablePath, application.BaseAddresses);
            }
        }

        /// <summary>
        /// Configures the firewall to remove access to the specified application.
        /// </summary>
        public static void RemoveFirewallAccess(string executablePath, IList<string> baseAddresses)
        {
            NetFwTypeLib.INetFwMgr fwm = GetNetFwMgr();

            // remove access to the application.
            try
            {
                fwm.LocalPolicy.CurrentProfile.AuthorizedApplications.Remove(executablePath);
            }
            catch (Exception e)
            {
                Utils.Trace("Could not remove firewall access for application: {0}. Error={1}", executablePath, e.Message);
            }

            // remove any ports.
            if (baseAddresses != null)
            {
                for (int ii = 0; ii < baseAddresses.Count; ii++)
                {
                    Uri url = Utils.ParseUri(baseAddresses[ii]);

                    // ignore invalid urls.
                    if (url == null || url.Port == -1)
                    {
                        continue;
                    }

                    try
                    {
                        fwm.LocalPolicy.CurrentProfile.GloballyOpenPorts.Remove(
                           url.Port,
                           NetFwTypeLib.NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP);
                    }
                    catch (Exception e)
                    {
                        Utils.Trace("Could not remove firewall access for port: {0}. Error={1}", url.Port, e.Message);
                    }
                }
            }
        }
        
        /// <summary>
        /// Returns the name of the workgroup or domain that the computer belongs to.
        /// </summary>
        public static string GetComputerWorkgroupOrDomain() 
        {
            SelectQuery query = new SelectQuery("Win32_ComputerSystem");

            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);

            foreach (ManagementObject item in searcher.Get()) 
            {
                return item["Domain"] as string;
            }

            return null;
        }
        
		/// <summary>
		/// Returns the prog id from the clsid.
		/// </summary>
		public static string ProgIDFromCLSID(Guid clsid)
		{
			RegistryKey key = Registry.ClassesRoot.OpenSubKey(String.Format(@"CLSID\{{{0}}}\ProgId", clsid));
					
			if (key != null)
			{
				try
				{
					return key.GetValue("") as string;
				}
				finally
				{
					key.Close();
				}
			}

			return null;
		}

		/// <summary>
		/// Returns the prog id from the clsid.
		/// </summary>
		public static Guid CLSIDFromProgID(string progID)
		{
			if (String.IsNullOrEmpty(progID))
			{
				return Guid.Empty;
			}

			RegistryKey key = Registry.ClassesRoot.OpenSubKey(String.Format(@"{0}\CLSID", progID));
					
			if (key != null)
			{
				try
				{
					string clsid = key.GetValue(null) as string;

					if (clsid != null)
					{
						return new Guid(clsid.Substring(1, clsid.Length-2));
					}
				}
				finally
				{
					key.Close();
				}
			}

			return Guid.Empty;
		}
        
        
        /// <summary>
        /// Returns the implemented categories for the class.
        /// </summary>
        public static List<Guid> GetImplementedCategories(Guid clsid)
        {
            List<Guid> categories = new List<Guid>();

			string categoriesKey = String.Format(@"CLSID\{{{0}}}\Implemented Categories", clsid);
			
			RegistryKey key = Registry.ClassesRoot.OpenSubKey(categoriesKey);

			if (key != null)
			{
                try
                {
				    foreach (string catid in key.GetSubKeyNames())
				    {
                        try
                        {
                            Guid guid = new Guid(catid.Substring(1, catid.Length-2));
                            categories.Add(guid);
                        }
                        catch (Exception)
                        {
                            // ignore invalid keys.
                        }
				    }
                }
                finally
                {
                    key.Close();
                }
			}

            return categories;
        }

		/// <summary>
		/// Fetches the classes in the specified category.
		/// </summary>
		public static List<Guid> EnumClassesInCategory(Guid category)
		{
			ICatInformation manager = (ICatInformation)CreateServer(CLSID_StdComponentCategoriesMgr);
	
			object unknown = null;

			try
			{
				manager.EnumClassesOfCategories(
					1, 
					new Guid[] { category }, 
					0, 
					null,
					out unknown);
                
				IEnumGUID enumerator = (IEnumGUID)unknown;

				List<Guid> classes = new List<Guid>();

				Guid[] buffer = new Guid[10];

				while (true)
				{
					int fetched = 0;

                    IntPtr pGuids = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(Guid))*buffer.Length);
                    
                    try
                    {
					    enumerator.Next(buffer.Length, pGuids, out fetched);

					    if (fetched == 0)
					    {
						    break;
					    }
                        
			            IntPtr pos = pGuids;

			            for (int ii = 0; ii < fetched; ii++)
			            {
				            buffer[ii] = (Guid)Marshal.PtrToStructure(pos, typeof(Guid));
				            pos = (IntPtr)(pos.ToInt64() + Marshal.SizeOf(typeof(Guid)));
			            }
                    }
                    finally
                    {
                        Marshal.FreeCoTaskMem(pGuids);
                    }

					for (int ii = 0; ii < fetched; ii++)
					{
						classes.Add(buffer[ii]);
					}
				}
			
				return classes;
			}
			finally
			{
				ReleaseServer(unknown);
				ReleaseServer(manager);
			}
        }

        /// <summary>
        /// The category identifier for UA servers that are registered as COM servers on a machine.
        /// </summary>
        public static readonly Guid CATID_PseudoComServers = new Guid("899A3076-F94E-4695-9DF8-0ED25B02BDBA");

        /// <summary>
        /// The CLSID for the UA COM DA server host process (note: will be eventually replaced the proxy server).
        /// </summary>
        public static readonly Guid CLSID_UaComDaProxyServer = new Guid("B25384BD-D0DD-4d4d-805C-6E9F309F27C1");

        /// <summary>
        /// The CLSID for the UA COM AE server host process (note: will be eventually replaced the proxy server).
        /// </summary>
        public static readonly Guid CLSID_UaComAeProxyServer = new Guid("4DF1784C-085A-403d-AF8A-B140639B10B3");

        /// <summary>
        /// The CLSID for the UA COM HDA server host process (note: will be eventually replaced the proxy server).
        /// </summary>
        public static readonly Guid CLSID_UaComHdaProxyServer = new Guid("2DA58B69-2D85-4de0-A934-7751322132E2");
        
        /// <summary>
        /// COM servers that support the DA 2.0 specification.
        /// </summary>
        public static readonly Guid CATID_OPCDAServer20  = new Guid("63D5F432-CFE4-11d1-B2C8-0060083BA1FB");

        /// <summary>
        /// COM servers that support the DA 3.0 specification.
        /// </summary>
        public static readonly Guid CATID_OPCDAServer30  = new Guid("CC603642-66D7-48f1-B69A-B625E73652D7");

        /// <summary>
        /// COM servers that support the AE 1.0 specification.
        /// </summary>
        public static readonly Guid CATID_OPCAEServer10  = new Guid("58E13251-AC87-11d1-84D5-00608CB8A7E9");

        /// <summary>
        /// COM servers that support the HDA 1.0 specification.
        /// </summary>
        public static readonly Guid CATID_OPCHDAServer10 = new Guid("7DE5B060-E089-11d2-A5E6-000086339399");

		/// <summary>
		/// Returns the location of the COM server executable.
		/// </summary>
		public static string GetExecutablePath(Guid clsid)
		{
			RegistryKey key = Registry.ClassesRoot.OpenSubKey(String.Format(@"CLSID\{{{0}}}\LocalServer32", clsid));

			if (key == null)
			{
				key	= Registry.ClassesRoot.OpenSubKey(String.Format(@"CLSID\{{{0}}}\InprocServer32", clsid));
			}

			if (key != null)
			{
				try
				{
					string codebase = key.GetValue("Codebase") as string;

					if (codebase == null)
					{
						return key.GetValue(null) as string;
					}

					return codebase;
				}
				finally
				{
					key.Close();
				}
			}

			return null;
		}

		/// <summary>
		/// Creates an instance of a COM server.
		/// </summary>
		public static object CreateServer(Guid clsid)
		{
			COSERVERINFO coserverInfo = new COSERVERINFO();

			coserverInfo.pwszName     = null;
			coserverInfo.pAuthInfo    = IntPtr.Zero;
			coserverInfo.dwReserved1  = 0;
			coserverInfo.dwReserved2  = 0;

			GCHandle hIID = GCHandle.Alloc(IID_IUnknown, GCHandleType.Pinned);

			MULTI_QI[] results = new MULTI_QI[1];

			results[0].iid  = hIID.AddrOfPinnedObject();
			results[0].pItf = null;
			results[0].hr   = 0;

			try
			{
				// create an instance.
				CoCreateInstanceEx(
					ref clsid,
					null,
					CLSCTX_INPROC_SERVER | CLSCTX_LOCAL_SERVER,
					ref coserverInfo,
					1,
					results);
			}
			finally
			{
				hIID.Free();
			}

			if (results[0].hr != 0)
			{
				throw new ExternalException("CoCreateInstanceEx: 0x{0:X8}" + results[0].hr);
			}

			return results[0].pItf;
		}

        /// <summary>
		/// Releases the server if it is a true COM server.
		/// </summary>
		public static void ReleaseServer(object server)
		{
			if (server != null && server.GetType().IsCOMObject)
			{
				Marshal.ReleaseComObject(server);
			}
		}
        
		/// <summary>
		/// Registers the classes in the specified category.
		/// </summary>
		public static void RegisterClassInCategory(Guid clsid, Guid catid)
		{
			RegisterClassInCategory(clsid, catid, null);
		}

		/// <summary>
		/// Registers the classes in the specified category.
		/// </summary>
		public static void RegisterClassInCategory(Guid clsid, Guid catid, string description)
		{
			ICatRegister manager = (ICatRegister)CreateServer(CLSID_StdComponentCategoriesMgr);
	
			try
			{
				string existingDescription = null;

				try
				{
					((ICatInformation)manager).GetCategoryDesc(catid, 0, out existingDescription);
				}
				catch (Exception e)
				{
					existingDescription = description;

					if (String.IsNullOrEmpty(existingDescription))
					{
						if (catid == CATID_OPCDAServer20)
						{
							existingDescription = CATID_OPCDAServer20_Description;
						}
						else if (catid == CATID_OPCDAServer30)
						{
							existingDescription = CATID_OPCDAServer30_Description;
						}
						else if (catid == CATID_OPCAEServer10)
						{
							existingDescription = CATID_OPCAEServer10_Description;
						}
						else if (catid == CATID_OPCHDAServer10)
						{
							existingDescription = CATID_OPCHDAServer10_Description;
						}
						else
						{
							throw new ApplicationException("No description for category available", e);
						}
					}

					CATEGORYINFO info;

					info.catid         = catid;
					info.lcid          = 0;
					info.szDescription = existingDescription;

					// register category.
					manager.RegisterCategories(1, new CATEGORYINFO[] { info });
				}

				// register class in category.
				manager.RegisterClassImplCategories(clsid, 1, new Guid[] { catid });
			}
			finally
			{
				ReleaseServer(manager);
			}
		}

        /// <summary>
        /// Removes the registration for a COM server from the registry.
        /// </summary>
        public static void UnregisterComServer(Guid clsid)
        {
			// unregister class in categories.
			string categoriesKey = String.Format(@"CLSID\{{{0}}}\Implemented Categories", clsid);
			
			RegistryKey key = Registry.ClassesRoot.OpenSubKey(categoriesKey);

			if (key != null)
			{
				try	  
				{ 
					foreach (string catid in key.GetSubKeyNames())
					{
						try	  
						{ 
							ConfigUtils.UnregisterClassInCategory(clsid, new Guid(catid.Substring(1, catid.Length-2)));
						}
						catch (Exception)
						{
							// ignore errors.
						}
					}
				}
				finally
				{
					key.Close();
				}
			}

			string progidKey = String.Format(@"CLSID\{{{0}}}\ProgId", clsid);

			// delete prog id.
			key = Registry.ClassesRoot.OpenSubKey(progidKey);
					
			if (key != null)
			{
				string progId = key.GetValue(null) as string;
				key.Close();

				if (!String.IsNullOrEmpty(progId))
				{
					try	  
					{ 
						Registry.ClassesRoot.DeleteSubKeyTree(progId); 
					}
					catch (Exception)
					{
						// ignore errors.
					}
				}
			}

			// delete clsid.
			try	  
			{ 
				Registry.ClassesRoot.DeleteSubKeyTree(String.Format(@"CLSID\{{{0}}}", clsid)); 
			}
			catch (Exception)
			{
				// ignore errors.
			}
        }

		/// <summary>
		/// Unregisters the classes in the specified category.
		/// </summary>
		public static void UnregisterClassInCategory(Guid clsid, Guid catid)
		{
			ICatRegister manager = (ICatRegister)CreateServer(CLSID_StdComponentCategoriesMgr);
	
			try
			{
				manager.UnRegisterClassImplCategories(clsid, 1, new Guid[] { catid });
			}
			finally
			{
				ReleaseServer(manager);
			}
		}

        #region COM Interop Declarations
		[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
		private struct COSERVERINFO
		{
			public uint         dwReserved1;
			[MarshalAs(UnmanagedType.LPWStr)]
			public string       pwszName;
			public IntPtr       pAuthInfo;
			public uint         dwReserved2;
		};

		[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
		private struct MULTI_QI
		{
			public IntPtr iid;
			[MarshalAs(UnmanagedType.IUnknown)]
			public object pItf;
			public uint   hr;
		}
		
		private const uint CLSCTX_INPROC_SERVER	 = 0x1;
		private const uint CLSCTX_INPROC_HANDLER = 0x2;
		private const uint CLSCTX_LOCAL_SERVER	 = 0x4;
		private const uint CLSCTX_REMOTE_SERVER	 = 0x10;

		private static readonly Guid IID_IUnknown = new Guid("00000000-0000-0000-C000-000000000046");
		
		[DllImport("ole32.dll")]
		private static extern void CoCreateInstanceEx(
			ref Guid         clsid,
			[MarshalAs(UnmanagedType.IUnknown)]
			object           punkOuter,
			uint             dwClsCtx,
			[In]
			ref COSERVERINFO pServerInfo,
			uint             dwCount,
			[In, Out]
			MULTI_QI[]       pResults);

	    [ComImport]
	    [GuidAttribute("0002E000-0000-0000-C000-000000000046")]
	    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)] 
        private interface IEnumGUID 
        {
            void Next(
		        [MarshalAs(UnmanagedType.I4)]
                int celt,
                [Out]
                IntPtr rgelt,
                [Out][MarshalAs(UnmanagedType.I4)]
                out int pceltFetched);

            void Skip(
		        [MarshalAs(UnmanagedType.I4)]
                int celt);

            void Reset();

            void Clone(
                [Out]
                out IEnumGUID ppenum);
        }

        [ComImport]
		[GuidAttribute("0002E013-0000-0000-C000-000000000046")]
		[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)] 
		private interface ICatInformation
		{
			void EnumCategories( 
				int lcid,				
				[MarshalAs(UnmanagedType.Interface)]
				[Out] out object ppenumCategoryInfo);
        
			void GetCategoryDesc( 
				[MarshalAs(UnmanagedType.LPStruct)] 
				Guid rcatid,
				int lcid,
				[MarshalAs(UnmanagedType.LPWStr)]
				[Out] out string pszDesc);
        
			void EnumClassesOfCategories( 
				int cImplemented,
				[MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPStruct, SizeParamIndex=0)] 
				Guid[] rgcatidImpl,
				int cRequired,
				[MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPStruct, SizeParamIndex=2)] 
				Guid[] rgcatidReq,
				[MarshalAs(UnmanagedType.Interface)]
				[Out] out object ppenumClsid);
        
			void IsClassOfCategories( 
				[MarshalAs(UnmanagedType.LPStruct)] 
				Guid rclsid,
				int cImplemented,
				[MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPStruct, SizeParamIndex=1)] 
				Guid[] rgcatidImpl,
				int cRequired,
				[MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPStruct, SizeParamIndex=3)] 
				Guid[] rgcatidReq);
        
			void EnumImplCategoriesOfClass( 
				[MarshalAs(UnmanagedType.LPStruct)] 
				Guid rclsid,
				[MarshalAs(UnmanagedType.Interface)]
				[Out] out object ppenumCatid);
        
			void EnumReqCategoriesOfClass(
				[MarshalAs(UnmanagedType.LPStruct)] 
				Guid rclsid,
				[MarshalAs(UnmanagedType.Interface)]
				[Out] out object ppenumCatid);
		}

		[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Unicode)]
		struct CATEGORYINFO 
		{
			public Guid catid;
			public int lcid;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst=127)] 
			public string szDescription;
		}

		[ComImport]
		[GuidAttribute("0002E012-0000-0000-C000-000000000046")]
		[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)] 
		private interface ICatRegister
		{
			void RegisterCategories(
				int cCategories,
				[MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPStruct, SizeParamIndex=0)] 
				CATEGORYINFO[] rgCategoryInfo);

			void UnRegisterCategories(
				int cCategories,
				[MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPStruct, SizeParamIndex=0)] 
				Guid[] rgcatid);

			void RegisterClassImplCategories(
				[MarshalAs(UnmanagedType.LPStruct)] 
				Guid rclsid,
				int cCategories,
				[MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPStruct, SizeParamIndex=1)] 
				Guid[] rgcatid);

			void UnRegisterClassImplCategories(
				[MarshalAs(UnmanagedType.LPStruct)] 
				Guid rclsid,
				int cCategories,
				[MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPStruct, SizeParamIndex=1)] 
				Guid[] rgcatid);

			void RegisterClassReqCategories(
				[MarshalAs(UnmanagedType.LPStruct)] 
				Guid rclsid,
				int cCategories,
				[MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPStruct, SizeParamIndex=1)] 
				Guid[] rgcatid);

			void UnRegisterClassReqCategories(
				[MarshalAs(UnmanagedType.LPStruct)] 
				Guid rclsid,
				int cCategories,
				[MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPStruct, SizeParamIndex=1)] 
				Guid[] rgcatid);
		}
        
        private static readonly Guid CLSID_StdComponentCategoriesMgr = new Guid("0002E005-0000-0000-C000-000000000046");

        private const string CATID_OPCDAServer20_Description  = "OPC Data Access Servers Version 2.0";
        private const string CATID_OPCDAServer30_Description  = "OPC Data Access Servers Version 3.0";
        private const string CATID_OPCAEServer10_Description  = "OPC Alarm & Event Server Version 1.0";
        private const string CATID_OPCHDAServer10_Description = "OPC History Data Access Servers Version 1.0";
        #endregion

        private static class NativeMethods
        {
            [DllImport("user32.dll", CharSet = CharSet.Unicode)]
            static extern internal IntPtr LoadIcon(IntPtr hInstance, string lpIconName);

            [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
            static extern internal IntPtr LoadLibrary(string lpFileName);
        }

        /// <summary>
        /// Gets the application icon.
        /// </summary>
        public static System.Drawing.Icon GetAppIcon()
        {
            string fileName = Assembly.GetEntryAssembly().Location;
            IntPtr hLibrary = NativeMethods.LoadLibrary(fileName);

            if (hLibrary != IntPtr.Zero)
            {
                IntPtr hIcon = NativeMethods.LoadIcon(hLibrary, "#32512");

                if (hIcon != IntPtr.Zero)
                {
                    return System.Drawing.Icon.FromHandle(hIcon);
                }
            }

            return null;
        }

        /// <summary>
        /// Registers the object ids required to access the certificate.
        /// </summary>
        public static void LocallyRegisterCertificateOIDs(X509Certificate2 certificate)
        {
            List<string> oids = new List<string>();
            oids.Add(certificate.PublicKey.Oid.Value);
            oids.Add(certificate.SignatureAlgorithm.Value);
            LocallyRegisterCertificateOIDs(oids.ToArray());
        }

        /// <summary>
        /// Registers the object ids required to access the certificate.
        /// </summary>
        /// <remarks>
        /// This function is used to work around a bug in .NET which results in long delays while OIDs are looked up in Active Directory.
        /// 
        /// CryptFindOIDInfo is supposed to work like this:
        /// 
        /// 1. A table of OID entries is constructed from registry entries with the CRYPT_INSTALL_OID_INFO_BEFORE_FLAG flag.  This table is searched first.
        /// 2. An internal table of OID entries is then searched. Default OIDs that Microsoft knows about.
        /// 3. A table of OIDs constructed from the registry entries without the CRYPT_INSTALL_OID_INFO_BEFORE_FLAG flag is then searched.
        /// 4. Active Directory is searched.        
        ///
        /// When registering the OID information with CryptRegisterOIDInfo(ptrInfo, 0) and hack the registry this is what will happen:
        /// 
        /// 1. Any application that searches for an OID (with the OID flag) will find it at step 2.  The OID will be correct as well as the friendly name since it uses CryptoAPI's internal table.
        /// 2. Any application that searches for a friendly name (with the friendly name flag) will find it as step 2.  The OID info is good as stated above.
        /// 3. .NET code which searches for an OID (with the friendly name flag) will find the entry in step 3 because of our hack.
        /// 4. Any OIDs that isn't found at this point will be searched in the Active Directory.
        /// 
        /// This code needs to be run once for each public key type.
        /// </remarks>
        public static void LocallyRegisterCertificateOIDs(string[] OIDs)
        {
            IntPtr pInfo;
            IntPtr pOID;

            RegistryKey key = null;
            CRYPT_OID_INFO oidInfo = new CRYPT_OID_INFO();

            for (int ii = 0; ii < OIDs.Length; ii++)
            {
                pOID = Marshal.StringToHGlobalAnsi(OIDs[ii]);
                pInfo = CryptFindOIDInfo(CRYPT_OID_INFO_OID_KEY, pOID, 0);
                Marshal.FreeHGlobal(pOID);

                if (pInfo != IntPtr.Zero)
                {
                    Marshal.PtrToStructure(pInfo, oidInfo);
                    
                    if (CryptRegisterOIDInfo(pInfo, CRYPT_INSTALL_OID_INFO_BEFORE_FLAG))
                    {
                        string strRegKey = 
                            "Software\\Microsoft\\Cryptography\\OID\\EncodingType 0\\CryptDllFindOIDInfo\\" 
                            + oidInfo.pszOID 
                            + "!" 
                            + oidInfo.dwGroupId.ToString();                        
                        
                        key = Registry.LocalMachine.CreateSubKey(strRegKey);
                        key.SetValue("Name", oidInfo.pszOID);
                        key.Close();            
                    }
                }
            }            
        }

        [DllImport("Crypt32.dll", EntryPoint = "CryptRegisterOIDInfo", CharSet = CharSet.Auto, SetLastError = true)]
        static extern Boolean CryptRegisterOIDInfo(IntPtr pInfo, Int32 dwFlags);

        [DllImport("Crypt32.dll", EntryPoint = "CryptFindOIDInfo", CharSet = CharSet.Auto, SetLastError = true)]
        static extern IntPtr CryptFindOIDInfo(Int32 dwKeyType, IntPtr pvKey, Int32 dwGroupId);

        private const Int32 CRYPT_OID_INFO_OID_KEY = 1;
        private const Int32  CRYPT_INSTALL_OID_INFO_BEFORE_FLAG  = 1;

        [StructLayout(LayoutKind.Sequential)]
        private class CRYPT_DATA_BLOB
        {
            public uint cbData;
            public IntPtr pbData;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        private class CRYPT_OID_INFO
        {
            public UInt32 cbSize;
            [MarshalAs(UnmanagedType.LPStr)]
            public String pszOID;
            [MarshalAs(UnmanagedType.LPWStr)]
            public String pwszName;
            public UInt32 dwGroupId;
            public Int32 dwValue; // Use either dwValue or Algid or dwLen - they are a union
            // public UInt32 Algid;
            // public Int32 dwLength;
            public CRYPT_DATA_BLOB ExtraInfo;            
        };
    }
}
