/* Copyright (c) 1996-2017, OPC Foundation. All rights reserved.

   The source code in this file is covered under a dual-license scenario:
     - RCL: for OPC Foundation members in good-standing
     - GPL V2: everybody else

   RCL license terms accompanied with this source code. See http://opcfoundation.org/License/RCL/1.00/

   GNU General Public License as published by the Free Software Foundation;
   version 2 of the License are accompanied with this source code. See http://opcfoundation.org/License/GPLv2

   This source code is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
*/

using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Security.Cryptography.X509Certificates;

namespace Opc.Ua
{
    #if !SILVERLIGHT
    /// <summary>
	/// Loads the configuration section for an application.
	/// </summary>
	public class ApplicationConfigurationSection : IConfigurationSectionHandler	
	{
		#region IConfigurationSectionHandler Members	
        /// <summary>
        /// Creates the configuration object from the configuration section.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        /// <param name="configContext">The configuration context object.</param>
        /// <param name="section">The section as XML node.</param>
        /// <returns>The created section handler object.</returns>
		public object Create(object parent, object configContext, System.Xml.XmlNode section)
		{
            if (section == null)
            {
                throw new ArgumentNullException("section");
            }

			XmlNode element = section.FirstChild;

			while (element != null && !typeof(XmlElement).IsInstanceOfType(element))
			{
				element = element.NextSibling;
			}
            
			XmlNodeReader reader = new XmlNodeReader(element);

            try
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(ConfigurationLocation));
                ConfigurationLocation configuration = serializer.ReadObject(reader) as ConfigurationLocation;
                return configuration;
            }
            finally
            {
                reader.Close();
            }
		}
		#endregion
	}
    #endif

    /// <summary>
    /// Represents the location of a configuration file.
    /// </summary>
    [DataContract(Namespace = Namespaces.OpcUaConfig)]
    public class ConfigurationLocation
    {
        #region Persistent Properties
        /// <summary>
        /// Gets or sets the relative or absolute path to the configuration file.
        /// </summary>
        /// <value>The file path.</value>
        [DataMember(IsRequired=true, Order=0)]
        public string FilePath
        {
            get { return m_filePath; }
            set { m_filePath = value; }
        }
        #endregion

        #region Private Fields
        private string m_filePath;
        #endregion
    }

    /// <summary>
    /// Stores the configurable configuration information for a UA application.
    /// </summary>
    public partial class ApplicationConfiguration
    {        
        #region Public Methods
        /// <summary>
        /// Gets the file that was used to load the configuration.
        /// </summary>
        /// <value>The source file path.</value>
        public string SourceFilePath
        {
            get { return m_sourceFilePath;  }
        }
        
        #if !SILVERLIGHT
        /// <summary>
        /// Gets or sets a certificate validator created from the configuration.
        /// </summary>
        /// <value>The certificate validator.</value>
        /// <remarks>
        /// If the configuration is changed the CertificateValidator.Update method must be called.
        /// </remarks>
        public CertificateValidator CertificateValidator
        {
            get { return m_certificateValidator;  }
            set { m_certificateValidator = value; }
        }
        #endif

        /// <summary>
        /// Returns the domain names which the server is configured to use.
        /// </summary>
        /// <returns>A list of domain names.</returns>
        public IList<string> GetServerDomainNames()
        {
            List<string> domainNames = new List<string>();

            StringCollection baseAddresses = new StringCollection();

            if (this.ServerConfiguration != null)
            {
                if (this.ServerConfiguration.BaseAddresses != null)
                {
                    baseAddresses.AddRange(this.ServerConfiguration.BaseAddresses);
                }

                if (this.ServerConfiguration.AlternateBaseAddresses != null)
                {
                    baseAddresses.AddRange(this.ServerConfiguration.AlternateBaseAddresses);
                }
            }

            if (this.DiscoveryServerConfiguration != null)
            {
                if (this.DiscoveryServerConfiguration.BaseAddresses != null)
                {
                    baseAddresses.AddRange(this.DiscoveryServerConfiguration.BaseAddresses);
                }

                if (this.DiscoveryServerConfiguration.AlternateBaseAddresses != null)
                {
                    baseAddresses.AddRange(this.DiscoveryServerConfiguration.AlternateBaseAddresses);
                }
            }

            for (int ii = 0; ii < baseAddresses.Count; ii++)
            {
                Uri url = Utils.ParseUri(baseAddresses[ii]);

                if (url == null)
                {
                    continue;
                }

                string domainName = url.DnsSafeHost;

                if (String.Compare(domainName, "localhost", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    domainName = System.Net.Dns.GetHostName();
                }

                if (!Utils.FindStringIgnoreCase(domainNames, domainName))
                {
                    domainNames.Add(domainName);
                }
            }

            return domainNames;
        }
        
        #if !SILVERLIGHT
        /// <summary>
        /// Gets or sets a value indicating whether the native (ANSI C) implementation of UA-TCP should be used.
        /// </summary>
        /// <value><c>true</c> if the native stack is used; otherwise, <c>false</c>.</value>
        public bool UseNativeStack
        {
            get
            {
                for (int ii = 0; ii < TransportConfigurations.Count; ii++)
                {
                    TransportConfiguration transport = TransportConfigurations[ii];

                    if (transport.UriScheme == Utils.UriSchemeOpcTcp)
                    {
                        return transport.TypeName == Utils.UaTcpBindingNativeStack;
                    }
                }

                return false;
            }

            set
            {
                for (int ii = 0; ii < TransportConfigurations.Count; ii++)
                {
                    TransportConfiguration transport = TransportConfigurations[ii];

                    if (transport.UriScheme == Utils.UriSchemeOpcTcp)
                    {
                        if (value)
                        {
                            transport.TypeName = Utils.UaTcpBindingNativeStack;
                        }
                        else
                        {
                            transport.TypeName = Utils.UaTcpBindingDefault;
                        }

                        break;
                    }
                }
            }
        }
        #endif

        /// <summary>
        /// Creates the message context from the configuration.
        /// </summary>
        /// <returns>A new instance of a ServiceMessageContext object.</returns>
        public ServiceMessageContext CreateMessageContext()
        {
            ServiceMessageContext messageContext = new ServiceMessageContext();

            if (m_transportQuotas != null)
            {
                messageContext.MaxArrayLength = m_transportQuotas.MaxArrayLength;
                messageContext.MaxByteStringLength = m_transportQuotas.MaxByteStringLength;
                messageContext.MaxStringLength = m_transportQuotas.MaxStringLength;
                messageContext.MaxMessageSize = m_transportQuotas.MaxMessageSize;
            }

            messageContext.NamespaceUris = new NamespaceTable();
            messageContext.ServerUris = new StringTable();
            messageContext.Factory = EncodeableFactory.GlobalFactory;

            return messageContext;
        }

        #if !SILVERLIGHT
        /// <summary>
        /// Creates the message context from the configuration.
        /// </summary>
        /// <value>A new instance of a ServiceMessageContext object.</value>
        [Obsolete("Warning: Behavoir changed return a copy instead of a reference. Should call CreateMessageContext() instead.")]
        public ServiceMessageContext MessageContext
        {
            get 
            {
                if (m_messageContext == null)
                {
                    m_messageContext = CreateMessageContext();
                }

                return m_messageContext;
            }
        }

        /// <summary>
        /// Loads and validates the application configuration from a configuration section.
        /// </summary>
        /// <param name="sectionName">Name of configuration section for the current application's default configuration containing <see cref="ConfigurationLocation"/>.</param>
        /// <param name="applicationType">Type of the application.</param>
        /// <returns>Application configuration</returns>
        public static ApplicationConfiguration Load(string sectionName, ApplicationType applicationType)
        {
            return Load(sectionName, applicationType, typeof(ApplicationConfiguration));
        }

        /// <summary>
        /// Loads and validates the application configuration from a configuration section.
        /// </summary>
        /// <param name="sectionName">Name of configuration section for the current application's default configuration containing <see cref="ConfigurationLocation"/>.</param>
        /// <param name="applicationType">A description for the ApplicationType DataType.</param>
        /// <param name="systemType">A user type of the configuration instance.</param>
        /// <returns>Application configuration</returns>
        public static ApplicationConfiguration Load(string sectionName, ApplicationType applicationType, Type systemType)
        {
            string filePath = GetFilePathFromAppConfig(sectionName);
            
            FileInfo file = new FileInfo(filePath);

            if (!file.Exists)
            {
                throw ServiceResultException.Create(
                    StatusCodes.BadConfigurationError,
                    "Configuration file does not exist: {0}\r\nCurrent directory is: {1}",
                    filePath,
                    Environment.CurrentDirectory);
            }

            return Load(file, applicationType, systemType);
        }
        
        /// <summary>
        /// Loads but does not validate the application configuration from a configuration section.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="systemType">Type of the system.</param>
        /// <returns>Application configuration</returns>
        /// <remarks>Use this method to ensure the configuration is not changed during loading.</remarks>
        public static ApplicationConfiguration LoadWithNoValidation(FileInfo file, Type systemType)
        {
            XmlTextReader reader = new XmlTextReader(file.Open(FileMode.Open, FileAccess.Read));

            try
            {
                DataContractSerializer serializer = new DataContractSerializer(systemType);

                ApplicationConfiguration configuration = serializer.ReadObject(reader, false) as ApplicationConfiguration;

                if (configuration != null)
                {
                    configuration.m_sourceFilePath = file.FullName;
                }

                return configuration;
            }
            catch (Exception e)
            {
                throw ServiceResultException.Create(
                    StatusCodes.BadConfigurationError,
                    e,
                    "Configuration file could not be loaded: {0}\r\nError is: {1}",
                    file.FullName,
                    e.Message);
            }
            finally
            {
                reader.Close();
            }
        }
        
        /// <summary>
        /// Loads and validates the application configuration from a configuration section.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="applicationType">Type of the application.</param>
        /// <param name="systemType">Type of the system.</param>
        /// <returns>Application configuration</returns>
        public static ApplicationConfiguration Load(FileInfo file, ApplicationType applicationType, Type systemType)
        {
            return ApplicationConfiguration.Load(file, applicationType, systemType, true);
        }
           
        /// <summary>
        /// Loads and validates the application configuration from a configuration section.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="applicationType">Type of the application.</param>
        /// <param name="systemType">Type of the system.</param>
        /// <param name="applyTraceSettings">if set to <c>true</c> apply trace settings after validation.</param>
        /// <returns>Application configuration</returns>
        public static ApplicationConfiguration Load(FileInfo file, ApplicationType applicationType, Type systemType, bool applyTraceSettings)
        {
            ApplicationConfiguration configuration = null;

            if (systemType == null)
            {
                systemType = typeof(ApplicationConfiguration);
            }

			XmlTextReader reader = new XmlTextReader(file.Open(FileMode.Open, FileAccess.Read));

            try
            {
                DataContractSerializer serializer = new DataContractSerializer(systemType);
                configuration = serializer.ReadObject(reader, false) as ApplicationConfiguration;
            }
            catch (Exception e)
            {
                throw ServiceResultException.Create(
                    StatusCodes.BadConfigurationError,
                    e,
                    "Configuration file could not be loaded: {0}\r\nError is: {1}",
                    file.FullName,
                    e.Message);
            }
            finally
            {
                reader.Close();
            }

            if (configuration != null)
            {
                // should not be here but need to preserve old behavoir.
                if (applyTraceSettings && configuration.TraceConfiguration != null)
                {
                    configuration.TraceConfiguration.ApplySettings();
                }

                configuration.Validate(applicationType);
                configuration.m_sourceFilePath = file.FullName;
            }

            return configuration;
        }
#endif

        /// <summary>
        /// Reads the file path from the application configuration file.
        /// </summary>
	    /// <param name="sectionName">Name of configuration section for the current application's default configuration containing <see cref="ConfigurationLocation"/>.
	    /// </param>
        /// <returns>File path from the application configuration file.</returns>
        public static string GetFilePathFromAppConfig(string sectionName)
        {
            string filePath = null;
            
            #if !SILVERLIGHT
            ConfigurationLocation location = ConfigurationManager.GetSection(sectionName) as ConfigurationLocation;

            if (location != null)
            {
                filePath = location.FilePath;
            }

            if (String.IsNullOrEmpty(filePath))
            {
                // get the default application name from the executable file.
                FileInfo file = new FileInfo(Environment.GetCommandLineArgs()[0]);

                // choose a default configuration file.
                filePath = Utils.Format(
                    "{0}\\{1}.Config.xml", 
                    file.DirectoryName, 
                    file.Name.Substring(0, file.Name.Length-4));
            }

            // convert to absolute file path (expands environment strings).
            string absolutePath = Utils.GetAbsoluteFilePath(filePath, true, false, false);

            if (absolutePath != null)
            {
                return absolutePath;
            }
            #endif

            // return the invalid file path.
            return filePath;
        }

        /// <summary>
        /// Saves the configuration file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <remarks>Calls GetType() on the current instance and passes that to the DataContractSerializer.</remarks>
        public void SaveToFile(string filePath)
        {            
            Stream ostrm = File.Open(filePath, FileMode.Create, FileAccess.ReadWrite);

            XmlWriterSettings settings = new XmlWriterSettings();

            settings.Encoding = System.Text.Encoding.UTF8;
            settings.Indent = true;
            settings.CloseOutput = true;

            XmlWriter writer = XmlDictionaryWriter.Create(ostrm, settings);

            try
            {
                DataContractSerializer serializer = new DataContractSerializer(GetType());                
                serializer.WriteObject(writer, this);
            }
            finally
            {
                writer.Close();
            }
        }

        /// <summary>
        /// Ensures that the application configuration is valid.
        /// </summary>
        /// <param name="applicationType">Type of the application.</param>
        public virtual void Validate(ApplicationType applicationType)
        {
            if (String.IsNullOrEmpty(ApplicationName))
            {
                throw ServiceResultException.Create(StatusCodes.BadConfigurationError, "ApplicationName must be specified.");
            }

#if !SILVERLIGHT
            if (SecurityConfiguration == null)
            {
                throw ServiceResultException.Create(StatusCodes.BadConfigurationError, "SecurityConfiguration must be specified.");
            }

            SecurityConfiguration.Validate();

            // ensure application uri matches the certificate.
            X509Certificate2 certificate = SecurityConfiguration.ApplicationCertificate.LoadPrivateKey(null);

            if (certificate != null)
            {
                ApplicationUri = Utils.GetApplicationUriFromCertficate(certificate);
            }
#endif

            //  generate a default uri.
            if (String.IsNullOrEmpty(ApplicationUri))
            {
                StringBuilder buffer = new StringBuilder();

                buffer.Append("urn:");
                buffer.Append(System.Net.Dns.GetHostName());
                buffer.Append(":");
                buffer.Append(ApplicationName);

                m_applicationUri = buffer.ToString();
            }

            if (applicationType == ApplicationType.Client || applicationType == ApplicationType.ClientAndServer)
            {
                if (ClientConfiguration == null)
                {
                    throw ServiceResultException.Create(StatusCodes.BadConfigurationError, "ClientConfiguration must be specified.");
                }

                ClientConfiguration.Validate();
            }

            if (applicationType == ApplicationType.Server || applicationType == ApplicationType.ClientAndServer)
            {
                if (ServerConfiguration == null)
                {
                    throw ServiceResultException.Create(StatusCodes.BadConfigurationError, "ServerConfiguration must be specified.");
                }

                ServerConfiguration.Validate();
            }

            if (applicationType == ApplicationType.DiscoveryServer)
            {
                if (DiscoveryServerConfiguration == null)
                {
                    throw ServiceResultException.Create(StatusCodes.BadConfigurationError, "DiscoveryServerConfiguration must be specified.");
                }

                DiscoveryServerConfiguration.Validate();
            }

            // toggle the state of the hi-res clock.
            HiResClock.Disabled = m_disableHiResClock;

            if (m_disableHiResClock)
            {
                if (m_serverConfiguration != null)
                {
                    if (m_serverConfiguration.PublishingResolution < 50)
                    {
                        m_serverConfiguration.PublishingResolution = 50;
                    }
                }
            }

            #if !SILVERLIGHT
            // create the certificate validator.
            m_certificateValidator = new CertificateValidator();
            m_certificateValidator.Update(this.SecurityConfiguration);
            #endif
        }
                
        /// <summary>
        /// Loads the endpoints cached on disk.
        /// </summary>
        /// <param name="createAlways">if set to <c>true</c> ConfiguredEndpointCollection is always returned,
		///	even if loading from disk fails</param>
        /// <returns>Colection of configured endpoints from the disk.</returns>
        public ConfiguredEndpointCollection LoadCachedEndpoints(bool createAlways)
        {
            return LoadCachedEndpoints(createAlways, false);
        }

        /// <summary>
        /// Loads the endpoints cached on disk.
        /// </summary>
        /// <param name="createAlways">if set to <c>true</c> ConfiguredEndpointCollection is always returned,
        /// even if loading from disk fails</param>
        /// <param name="overrideConfiguration">if set to <c>true</c> overrides the configuration.</param>
        /// <returns>
        /// Colection of configured endpoints from the disk.
        /// </returns>
        public ConfiguredEndpointCollection LoadCachedEndpoints(bool createAlways, bool overrideConfiguration)
        {
            #if !SILVERLIGHT
            if (m_clientConfiguration == null) throw new InvalidOperationException("Only valid for client configurations.");

            string filePath = Utils.GetAbsoluteFilePath(m_clientConfiguration.EndpointCacheFilePath, true, false, false);
            
            if (filePath == null)
            {
                filePath = m_clientConfiguration.EndpointCacheFilePath;

                if (!filePath.StartsWith("\\\\", StringComparison.Ordinal) && filePath.IndexOf(":", StringComparison.Ordinal) != 1)
                {
                    FileInfo sourceFile = new FileInfo(this.SourceFilePath);                    
                    filePath = Utils.Format("{0}\\{1}", sourceFile.DirectoryName, filePath);
                }
            }

            if (!createAlways)
            {
                return ConfiguredEndpointCollection.Load(this, filePath, overrideConfiguration);
            }

            try
            {
                return ConfiguredEndpointCollection.Load(this, filePath, overrideConfiguration);
            }
            catch (Exception e)
            {
                Utils.Trace(e, "Could not load configuration from file: {0}", filePath);
                ConfiguredEndpointCollection endpoints = new ConfiguredEndpointCollection(this);
                endpoints.Save(filePath);
                return endpoints;
            }
            #else
            return new ConfiguredEndpointCollection(); 
            #endif
        }

        /// <summary>
        /// Looks for an extension with the specified type and uses the DataContractSerializer to parse it.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>
        /// The deserialized extension. Null if an error occurs.
        /// </returns>
        /// <remarks>
        /// The containing element must use the name and namespace uri specified by the DataContractAttribute for the type.
        /// </remarks>
        public T ParseExtension<T>()
        {
            return ParseExtension<T>(null);
        }

        /// <summary>
        /// Looks for an extension with the specified type and uses the DataContractSerializer to parse it.
        /// </summary>
        /// <typeparam name="T">The type of extension.</typeparam>
        /// <param name="elementName">Name of the element (null means use type name).</param>
        /// <returns>The extension if found. Null otherwise.</returns>
        public T ParseExtension<T>(XmlQualifiedName elementName)
        {
            return Utils.ParseExtension<T>(m_extensions, elementName);
        }

        /// <summary>
        /// Updates the extension.
        /// </summary>
        /// <typeparam name="T">The type of extension.</typeparam>
        /// <param name="elementName">Name of the element (null means use type name).</param>
        /// <param name="value">The value.</param>
        public void UpdateExtension<T>(XmlQualifiedName elementName, object value)
        {
            Utils.UpdateExtension<T>(ref m_extensions, elementName, value);
        }

        /// <summary>
        /// Updates the extension.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="value">The value.</param>
        [Obsolete("Not non-functional. Replaced by a template version UpdateExtension<T>")]
        public void UpdateExtension(Type type, object value)
        {
        }
        #endregion
    }

    #region TraceConfiguration Class
    /// <summary>
    /// Specifies parameters used for tracing.
    /// </summary>
    public partial class TraceConfiguration
    {
        #region Public Methods
        /// <summary>
        /// Applies the trace settings to the current process.
        /// </summary>
        public void ApplySettings()
        {           
            Utils.SetTraceLog(m_outputFilePath, m_deleteOnLoad);
            Utils.SetTraceMask(m_traceMasks);

            if (m_traceMasks == 0)
            {
                Utils.SetTraceOutput(Utils.TraceOutput.Off);
            }
            else
            {
                Utils.SetTraceOutput(Utils.TraceOutput.DebugAndFile);
            }
        }
        #endregion
    }
    #endregion

    #region ServerBaseConfiguration Class
    /// <summary>
    /// Specifies the configuration for a server application.
    /// </summary>
    public partial class ServerBaseConfiguration
    {
        #region Public Methods
        /// <summary>
        /// Validates the configuration.
        /// </summary>
        public virtual void Validate()
        {
            if (m_securityPolicies.Count == 0)
            {
                m_securityPolicies.Add(new ServerSecurityPolicy());
            }
        }
        #endregion
    }
    #endregion

    #region ServerConfiguration Class
    /// <summary>
    /// Specifies the configuration for a server application.
    /// </summary>
    public partial class ServerConfiguration : ServerBaseConfiguration
    {
        #region Public Methods
        /// <summary>
        /// Validates the configuration.
        /// </summary>
        public override void Validate()
        {
            base.Validate();

            if (m_userTokenPolicies.Count == 0)
            {
                m_userTokenPolicies.Add(new UserTokenPolicy());
            }
        }
        #endregion
    }
    #endregion

    #region ClientConfiguration Class
    /// <summary>
    /// The configuration for a client application.
    /// </summary>
    public partial class ClientConfiguration
    {
        #region Public Methods
        /// <summary>
        /// Validates the configuration.
        /// </summary>
        public void Validate()
        {
            if (WellKnownDiscoveryUrls.Count == 0)
            {
                WellKnownDiscoveryUrls.AddRange(Utils.DiscoveryUrls);
            }
        }
        #endregion
    }
    #endregion
}
