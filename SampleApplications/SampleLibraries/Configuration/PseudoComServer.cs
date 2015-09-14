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
using System.Net;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.IO;
using System.Text;

using Microsoft.Win32;

namespace Opc.Ua.Configuration
{
	/// <summary>
	/// A class that describes a Pseudo COM server which 
	/// </summary>
	public class PseudoComServer
	{
        /// <summary>
        /// Loads the endpoint information from the registry.
        /// </summary>
        public static ConfiguredEndpoint Load(Guid clsid)
        {
            // load the configuration.
            ConfiguredEndpoint endpoint = LoadConfiguredEndpoint(clsid);

            // create a dummy configuration.
            if (endpoint == null)
            {
                ApplicationDescription server = new ApplicationDescription();

                server.ApplicationName = "(Missing Configuration File)";
                server.ApplicationType = ApplicationType.Server;
                server.ApplicationUri  = clsid.ToString();

                endpoint = new ConfiguredEndpoint(server, null);
            }

            // update the COM identity based on what is actually in the registry.
            endpoint.ComIdentity = new EndpointComIdentity();
            endpoint.ComIdentity.Clsid  = clsid;
            endpoint.ComIdentity.ProgId = ConfigUtils.ProgIDFromCLSID(clsid);
            
            List<Guid> categories = ConfigUtils.GetImplementedCategories(clsid);

            for (int ii = 0; ii < categories.Count; ii++)
            {
                if (categories[ii] == ConfigUtils.CATID_OPCDAServer20)
                {
                    endpoint.ComIdentity.Specification = ComSpecification.DA;
                    break;
                }

                if (categories[ii] == ConfigUtils.CATID_OPCDAServer30)
                {
                    endpoint.ComIdentity.Specification = ComSpecification.DA;
                    break;
                }

                if (categories[ii] == ConfigUtils.CATID_OPCAEServer10)
                {
                    endpoint.ComIdentity.Specification = ComSpecification.AE;
                    break;
                }

                if (categories[ii] == ConfigUtils.CATID_OPCHDAServer10)
                {
                    endpoint.ComIdentity.Specification = ComSpecification.HDA;
                    break;
                }
            }

            return endpoint;
        }

        /// <summary>
        /// Returns the CLSID of the host process to use for the specification.
        /// </summary>
        public static Guid GetServerHostClsid(ComSpecification specification)
        {
            if (specification == ComSpecification.AE)
            {
                return ConfigUtils.CLSID_UaComAeProxyServer;
            }

            else if (specification == ComSpecification.HDA)
            {
                return ConfigUtils.CLSID_UaComHdaProxyServer;
            }
                
            return ConfigUtils.CLSID_UaComDaProxyServer;
        }

        /// <summary>
        /// Imports the configured endpoints from a collection saved on disk.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>An empty string on success. A list of errors otherwise.</returns>
        public static string Import(string filePath)
        {
            StringBuilder errors = new StringBuilder();

            ConfiguredEndpointCollection collection = ConfiguredEndpointCollection.Load(filePath);

            int loaded = 0;
            int imported = 0;

            foreach (ConfiguredEndpoint endpoint in collection.Endpoints)
            {
                loaded++;

                try
                {
                    Save(endpoint);
                    imported++;
                }
                catch (Exception e)
                {
                    if (errors.Length > 0)
                    {
                        errors.AppendFormat("\r\n");
                    }

                    errors.AppendFormat("Endpoint #{0} - {1}", loaded, e.Message);
                }
            }

            if (errors.Length > 0)
            {
                errors.AppendFormat("\r\n\r\n{0} of {0} endpoints imported successfully.", imported, loaded);
            }

            return errors.ToString();
        }
        
        /// <summary>
        /// Deletes the configured endpoints conatined a collection saved on disk.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>An empty string on success. A list of errors otherwise.</returns>
        public static string Delete(string filePath)
        {
            StringBuilder errors = new StringBuilder();

            ConfiguredEndpointCollection collection = ConfiguredEndpointCollection.Load(filePath);

            int loaded = 0;
            int deleted = 0;

            foreach (ConfiguredEndpoint endpoint in collection.Endpoints)
            {
                loaded++;

                try
                {
                    Delete(endpoint.ComIdentity.Clsid);
                    deleted++;
                }
                catch (Exception e)
                {
                    if (errors.Length > 0)
                    {
                        errors.AppendFormat("\r\n");
                    }

                    errors.AppendFormat("Endpoint #{0} - {1}", loaded, e.Message);
                }
            }

            if (errors.Length > 0)
            {
                errors.AppendFormat("\r\n\r\n{0} of {0} endpoints deleted successfully.", deleted, loaded);
            }

            return errors.ToString();
        }

        /// <summary>
        /// Exports COM endpoint configurations to the specified file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="progIds">The prog ids. All endpoints are exported if null.</param>
        public static void Export(string filePath, params string[] progIds)
        {
            List<ConfiguredEndpoint> endpoints = Enumerate();
            ConfiguredEndpointCollection collection = new ConfiguredEndpointCollection();
            
            for (int ii = 0; ii < endpoints.Count; ii++)
            {
                ConfiguredEndpoint endpoint = endpoints[ii];

                if (endpoint.ComIdentity == null)
                {
                    continue;
                }

                if (progIds == null || progIds.Length == 0)
                {
                    collection.Add(endpoint);
                    continue;
                }

                for (int jj = 0; jj < progIds.Length; jj++)
                {
                    if (progIds[jj] == endpoint.ComIdentity.ProgId)
                    {
                        collection.Add(endpoint);
                        break;
                    }
                }
            }

            if (collection.Count > 0)
            {
                collection.Save(filePath);
            }
        }

        /// <summary>
		/// Saves the endpoint information in the registry.
		/// </summary>
		public static void Save(ConfiguredEndpoint endpoint)
		{
            if (endpoint == null) throw new ArgumentNullException("endpoint");

			if (endpoint.ComIdentity == null)
			{
				throw new ApplicationException("Endpoint does not have a COM identity specified.");
			}
            
            // choose the clsid for the host process.
            Guid hostClsid = GetServerHostClsid(endpoint.ComIdentity.Specification);
            
            // check of COM host process registered.
            string wrapperPath = ConfigUtils.GetExecutablePath(hostClsid);

            if (String.IsNullOrEmpty(wrapperPath))
            {
				throw new ApplicationException("The UA COM Host process is not registered on the machine.");
            }

			// verify prog id.
			string progId = endpoint.ComIdentity.ProgId;

			if (String.IsNullOrEmpty(progId))
			{
				throw new ApplicationException("Endpoint does not have a valid ProgId.");
			}

            // remove existing CLSID.
            Guid existingClsid = ConfigUtils.CLSIDFromProgID(progId);

            if (existingClsid != Guid.Empty)
            {
                ConfigUtils.UnregisterComServer(existingClsid);
            }

            // determine CLSID to use.
            Guid clsid = endpoint.ComIdentity.Clsid;

            if (clsid == Guid.Empty)
            {
                clsid = existingClsid;

                if (clsid == Guid.Empty)
                {
                    clsid = Guid.NewGuid();
                }

                endpoint.ComIdentity.Clsid = clsid;
            }
            
            // remove existing clsid.
            ConfigUtils.UnregisterComServer(clsid);

			string clsidKey = String.Format(@"CLSID\{{{0}}}", clsid.ToString().ToUpper());

			// create new entries.					
			RegistryKey key = Registry.ClassesRoot.CreateSubKey(clsidKey);
			
			if (key == null)
			{
				throw new ApplicationException("Could not create key: " + clsidKey);
			}

			// save description.
            if (endpoint.Description.Server.ApplicationName != null)
            {
                key.SetValue(null, endpoint.Description.Server.ApplicationName);
            }

			try
			{
				// create local server key.
				RegistryKey subkey = key.CreateSubKey("LocalServer32");

				if (subkey == null)
				{
					throw new ApplicationException("Could not create key: LocalServer32");
				}

				subkey.SetValue(null, wrapperPath);
				subkey.Close();

				// create prog id key.
				subkey = key.CreateSubKey("ProgId");

				if (subkey == null)
				{
					throw new ApplicationException("Could not create key: ProgId");
				}

				subkey.SetValue(null, progId);
				subkey.Close();
			}
			finally
			{
				key.Close();
			} 

            // save the configuration.
            SaveConfiguredEndpoint(clsid, endpoint);

			// create prog id key.
			key = Registry.ClassesRoot.CreateSubKey(progId);
			
			if (key == null)
			{
				throw new ApplicationException("Could not create key: " + progId);
			}

			try
			{	
				// create clsid key.
				RegistryKey subkey = key.CreateSubKey("CLSID");

				if (subkey == null)
				{
					throw new ApplicationException("Could not create key: CLSID");
				}

				subkey.SetValue(null, String.Format("{{{0}}}", clsid.ToString().ToUpper()));
				subkey.Close();

				// create the OPC key use with DA 2.0 servers.
                if (endpoint.ComIdentity.Specification == ComSpecification.DA)
                {
				    subkey = key.CreateSubKey("OPC");

				    if (subkey == null)
				    {
					    throw new ApplicationException("Could not create key: OPC");
				    }

				    subkey.Close();
                }
			}
			finally
			{
				key.Close();
			} 

			// register as wrapper server.
            ConfigUtils.RegisterClassInCategory(clsid, ConfigUtils.CATID_PseudoComServers, "OPC UA COM Pseudo-Servers");

            // register in OPC component categories.
            if (endpoint.ComIdentity.Specification == ComSpecification.DA)
            {
			    ConfigUtils.RegisterClassInCategory(clsid, ConfigUtils.CATID_OPCDAServer20);
#if !OPCUA_NODA3_SUPPORT
			    ConfigUtils.RegisterClassInCategory(clsid, ConfigUtils.CATID_OPCDAServer30);
#endif
            }
             
            else if (endpoint.ComIdentity.Specification == ComSpecification.AE)
            {
			    ConfigUtils.RegisterClassInCategory(clsid, ConfigUtils.CATID_OPCAEServer10);
            }
            
            else if (endpoint.ComIdentity.Specification == ComSpecification.HDA)
            {
			    ConfigUtils.RegisterClassInCategory(clsid, ConfigUtils.CATID_OPCHDAServer10);
            }
		}
         
        /// <summary>
		/// Deletes the pseudoserver from the registry.
		/// </summary>
		public static void Delete(Guid clsid)
		{
            ConfigUtils.UnregisterComServer(clsid);
            DeleteConfiguredEndpointFile(clsid);
		}

		/// <summary>
		/// Returns the UA COM Pseudo-servers registered on the local computer.
		/// </summary>
		public static List<ConfiguredEndpoint> Enumerate()
		{
			// enumerate server clsids.
			List<Guid> clsids = ConfigUtils.EnumClassesInCategory(ConfigUtils.CATID_PseudoComServers);

			// initialize server objects.
			List<ConfiguredEndpoint> servers = new List<ConfiguredEndpoint>();

			for (int ii = 0; ii < clsids.Count; ii++)
			{
                ConfiguredEndpoint server = null;

                try
                {
                    server = Load(clsids[ii]);
                    servers.Add(server);
                }
                catch (Exception e)
                {
                    Utils.Trace(e, "Unexpected error loading psuedo-server: {0}", clsids[ii]);
                    continue;
                }
                
                // ensure the Pseudo-server points to the correct host process.
                Guid hostClsid = Guid.Empty;

                if (server.ComIdentity != null)
                {
                    hostClsid = GetServerHostClsid(server.ComIdentity.Specification);
                }

				string hostPath = ConfigUtils.GetExecutablePath(hostClsid);

				if (String.IsNullOrEmpty(hostPath))
				{
					continue;
				}
	
				RegistryKey key = Registry.ClassesRoot.OpenSubKey(String.Format(@"CLSID\{{{0}}}\LocalServer32", clsids[ii]), false);
		
				if (key != null)
				{
                    if (hostPath != (string)key.GetValue(null, ""))
                    {
                        try
                        {
					        key.Close();
                            key = Registry.ClassesRoot.OpenSubKey(String.Format(@"CLSID\{{{0}}}\LocalServer32", clsids[ii]), true);
                            key.SetValue(null, hostPath);
                        }
                        catch (Exception)
                        {
                            Utils.Trace("Could not update COM proxy server path for {0}.", server.ComIdentity.ProgId); 
                        }
                    }

					key.Close();
				}
			}

			return servers;
		}

        /// <summary>
        /// Creates a ProgId from a URI
        /// </summary>
        public static string CreateProgIdFromUrl(ComSpecification specification, string uri)
        {           
            if (String.IsNullOrEmpty(uri))
            {
                return null;
            }

            StringBuilder buffer = new StringBuilder();

            switch (specification)
            {
                case ComSpecification.DA:
                {
                    buffer.Append("OpcDa.");
                    break;
                }

                case ComSpecification.AE:
                {
                    buffer.Append("OpcAe.");
                    break;
                }

                case ComSpecification.HDA:
                {
                    buffer.Append("OpcHda.");
                    break;
                }
            }

            bool punctuation = false;

            for (int ii = 0; ii < uri.Length; ii++)
            {
                switch (uri[ii])
                {
                    case '/':
                    case ':':
                    case '?':
                    case '&':
                    case '%':
                    {
                        if (!punctuation)
                        {
                            buffer.Append('.');
                        }

                        punctuation = true;
                        break;
                    }

                    default:
                    {
                        buffer.Append(uri[ii]);
                        punctuation = false;
                        break;
                    }
                }
            }                 
            
            return buffer.ToString();       
        }

		#region Private Members
        /// <summary>
        /// The directory that stores the configuration for the COM psuedo servers.
        /// </summary>
        private const string ComPseudoServersDirectory = "%CommonApplicationData%\\OPC Foundation\\ComPseudoServers";

		/// <summary>
		/// Returns the description 
		/// </summary>
		private static string GetDescription(Guid server)
		{
			string clsidKey = String.Format(@"CLSID\{{{0}}}", server.ToString().ToUpper());
		
			RegistryKey key = Registry.ClassesRoot.OpenSubKey(clsidKey);
			
			if (key != null)
			{
				try
				{
					return key.GetValue(null) as string;
				}
				finally
				{
					key.Close();
				}
			}

			return String.Empty;
		}
		
        /// <summary>
        /// Reads the UA endpoint information associated the CLSID
        /// </summary>
        /// <param name="clsid">The CLSID used to activate the COM server.</param>
        /// <returns>The endpoint.</returns>
        private static ConfiguredEndpoint LoadConfiguredEndpoint(Guid clsid)
        {
            ConfiguredEndpoint endpoint = LoadConfiguredEndpointFromFile(clsid);

            if (endpoint == null)
            {
                endpoint = LoadConfiguredEndpointFromRegistry(clsid);

                // save the endpoint from the registry to a file.
                if (endpoint != null)
                {
                    SaveConfiguredEndpointToFile(clsid, endpoint);
                }
            }

            return endpoint;
        }

        /// <summary>
        /// Saves the UA endpoint information associated the CLSID.
        /// </summary>
        /// <param name="clsid">The CLSID used to activate the COM server.</param>
        /// <param name="endpoint">The endpoint.</param>
        private static void SaveConfiguredEndpoint(Guid clsid, ConfiguredEndpoint endpoint)
        {
            SaveConfiguredEndpointToFile(clsid, endpoint);
        }

        /// <summary>
        /// Deletes the file containing the configured endpoint.
        /// </summary>
        /// <param name="clsid">The CLSID.</param>
        private static void DeleteConfiguredEndpointFile(Guid clsid)
        {
            try
            {
                string relativePath = Utils.Format("{0}\\{1}.xml", ComPseudoServersDirectory, clsid);
                string absolutePath = Utils.GetAbsoluteFilePath(relativePath, false, false, false);

                // oops - nothing found.
                if (absolutePath == null)
                {
                    return;
                }

                File.Delete(absolutePath);
            }
            catch (Exception e)
            {
                Utils.Trace(e, "Unexpected error deleting endpoint configuration for COM Proxy with CLSID={0}.", clsid);
            }
        }

        /// <summary>
        /// Reads the UA endpoint information associated the CLSID
        /// </summary>
        /// <param name="clsid">The CLSID used to activate the COM server.</param>
        /// <returns>The endpoint.</returns>
        private static ConfiguredEndpoint LoadConfiguredEndpointFromFile(Guid clsid)
        {
            try
            {
                string relativePath = Utils.Format("{0}\\{1}.xml", ComPseudoServersDirectory, clsid);
                string absolutePath = Utils.GetAbsoluteFilePath(relativePath, false, false, false);

                // oops - nothing found.
                if (absolutePath == null)
                {
                    return null;
                }

                // open the file.
                FileStream istrm = File.Open(absolutePath, FileMode.Open, FileAccess.Read);

                using (XmlTextReader reader = new XmlTextReader(istrm))
                {
                    DataContractSerializer serializer = new DataContractSerializer(typeof(ConfiguredEndpoint));
                    return (ConfiguredEndpoint)serializer.ReadObject(reader, false);
                }
            }
            catch (Exception e)
            {
                Utils.Trace(e, "Unexpected error loading endpoint configuration for COM Proxy with CLSID={0}.", clsid);
                return null;
            }
        }

        /// <summary>
        /// Saves the UA endpoint information associated the CLSID.
        /// </summary>
        /// <param name="clsid">The CLSID used to activate the COM server.</param>
        /// <param name="endpoint">The endpoint.</param>
        private static void SaveConfiguredEndpointToFile(Guid clsid, ConfiguredEndpoint endpoint)
        {
            try
            {
                string relativePath = Utils.Format("{0}\\{1}.xml", ComPseudoServersDirectory, clsid);
                string absolutePath = Utils.GetAbsoluteFilePath(relativePath, false, false, true);

                // oops - nothing found.
                if (absolutePath == null)
                {
                    absolutePath = Utils.GetAbsoluteFilePath(relativePath, true, false, true);
                }

                // open the file.
                FileStream ostrm = File.Open(absolutePath, FileMode.Create, FileAccess.ReadWrite);

                using (XmlTextWriter writer = new XmlTextWriter(ostrm, System.Text.Encoding.UTF8))
                {
                    DataContractSerializer serializer = new DataContractSerializer(typeof(ConfiguredEndpoint));
                    serializer.WriteObject(writer, endpoint);
                }
            }
            catch (Exception e)
            {
                Utils.Trace(e, "Unexpected error saving endpoint configuration for COM Proxy with CLSID={0}.", clsid);
            }
        }
                        
        /// <summary>
        /// Reads the ConfiguredEndpoint from the registry.
        /// </summary>
        private static ConfiguredEndpoint LoadConfiguredEndpointFromRegistry(Guid clsid)
		{
			RegistryKey key = Registry.ClassesRoot.OpenSubKey(String.Format(@"CLSID\{{{0}}}\{1}", clsid, "Endpoint"));

			if (key != null)
			{                
                byte[] encodedEndpoint = null;

				try
				{
                    encodedEndpoint = key.GetValue(null) as byte[];
				}
				finally
				{
					key.Close();
				}

                if (encodedEndpoint == null)
                {
                    key = Registry.LocalMachine.OpenSubKey(String.Format(@"SOFTWARE\Wow6432Node\Classes\CLSID\{{{0}}}\{1}", clsid, "Endpoint"), true);

                    if (key != null)
                    {
                        try
                        {
                            encodedEndpoint = key.GetValue(null) as byte[];
                        }
                        finally
                        {
                            key.Close();
                        }
                    }
                }

                if (encodedEndpoint == null)
                {
                    return null;
                }

                MemoryStream istrm = new MemoryStream(encodedEndpoint, false);

                try
                {
                    DataContractSerializer serializer = new DataContractSerializer(typeof(ConfiguredEndpoint));
                    return (ConfiguredEndpoint)serializer.ReadObject(istrm);
                }
                finally
                {
                    istrm.Close();
                }
            }

            return null;
		}

        /// <summary>
        /// Saves the ConfiguredEndpoint from the registry.
        /// </summary>
        private static void SaveConfiguredEndpointToRegistry(Guid clsid, ConfiguredEndpoint endpoint)
        {
            // serialize the object.
            MemoryStream ostrm = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(ostrm, System.Text.Encoding.UTF8);

            try
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(ConfiguredEndpoint));
                serializer.WriteObject(writer, endpoint);
            }
            finally
            {
                writer.Close();
            }

            // save it in the registry key.
			RegistryKey key = Registry.ClassesRoot.CreateSubKey(String.Format(@"CLSID\{{{0}}}\{1}", clsid, "Endpoint"));

			if (key != null)
			{              
				try
				{
                    key.SetValue(null, ostrm.ToArray(), RegistryValueKind.Binary);
				}
				finally
				{
					key.Close();
				}
            }

            // save it in the registry key.
            key = Registry.LocalMachine.OpenSubKey(String.Format(@"SOFTWARE\Wow6432Node\Classes\CLSID\{{{0}}}\{1}", clsid, "Endpoint"), true);

			if (key != null)
			{              
				try
				{
                    key.SetValue(null, ostrm.ToArray(), RegistryValueKind.Binary);
				}
				finally
				{
					key.Close();
				}
            }
		}
		#endregion
	}
}
