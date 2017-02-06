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
using System.Configuration;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Xml;
using System.Reflection;
using System.IO;
        
namespace Opc.Ua.StackTest
{
	/// <summary>
	/// A class specifies the configuration for a test application.
	/// </summary>
    [DataContract(Namespace=Namespaces.OpcUaXsd)]
	public class TestConfiguration 
	{
		#region Constructors
		/// <summary>
		/// The default constructor.
		/// </summary>
		public TestConfiguration()
		{
			Initialize();
		}

		/// <summary>
		/// Sets private members to default values.
		/// </summary>
		private void Initialize()
		{
            m_testFilePath   = null;
            m_randomFilePath = null;
            m_logFilePath    = null;
            m_endpoint       = null;
		}

        /// <summary>
        /// Initializes the object during deserialization.
        /// </summary>
        [OnDeserializing()]
        private void Initialize(StreamingContext context)
        {
            Initialize();
        }
		#endregion
        
		#region Public Properties
		/// <summary>
		/// The path to file that specifies the tests to run.
        /// </summary>
        [DataMember(Order = 1)]
		public string TestFilePath
		{
			get { return m_testFilePath;  }
			set { m_testFilePath = value; }
		}

		/// <summary>
		/// The path to file that specifies the random number table to use.
        /// </summary>
        [DataMember(Order = 2)]
		public string RandomFilePath
		{
			get { return m_randomFilePath;  }
			set { m_randomFilePath = value; }
		}

		/// <summary>
		/// The step size to use when generating random data.
        /// </summary>
        [DataMember(Order = 3)]
		public uint RandomDataStepSize
		{
			get { return m_randomDataStepSize;  }
			set { m_randomDataStepSize = value; }
		}

		/// <summary>
		/// The path to file that contains the output of the test.
        /// </summary>
        [DataMember(Order = 4)]
		public string LogFilePath
		{
			get { return m_logFilePath;  }
			set { m_logFilePath = value; }
		}

		/// <summary>
		/// The endpoint of the server to test.
        /// </summary>
        [DataMember(Order = 5)]
		public EndpointDescription Endpoint
		{
			get { return m_endpoint;  }
			set { m_endpoint = value; }
		}
		#endregion
        
		#region Static Members

        /// <summary>
        ///  Loads the configuration from the application configuration file.
        /// </summary>
        /// <param name="sectionName">Name of the section to be loaded.</param>
        /// <returns></returns>
        public static TestConfiguration Load(string sectionName)
        {
            // load the configuration.
            TestConfiguration configuration = null;

            try
            {
                configuration = ConfigurationManager.GetSection(sectionName) as TestConfiguration;

                if (configuration == null)
                {
                    configuration = LoadDefault();
                }
            }
            catch (Exception e)
            {
                Utils.Trace(e, "Unexpected error loading configuration file.");
                configuration = LoadDefault();
            }

            return configuration;
        }

        /// <summary>
        /// This method loads the default configuration from an embedded resource.
        /// </summary>
        public static TestConfiguration LoadDefault()
        {
            XmlTextReader reader = null;

            try
            {
                // get embedded resource containing default configuration.
                Stream istrm = Assembly.GetExecutingAssembly().GetManifestResourceStream("Opc.Ua.StackTest.TestConfiguration.xml");

                reader = new XmlTextReader(istrm);                
                DataContractSerializer serializer = new DataContractSerializer(typeof(TestConfiguration));
                return serializer.ReadObject(reader) as TestConfiguration;
           }
            catch (Exception e)
            {
                throw new ServiceResultException(StatusCodes.BadConfigurationError, e);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }
		#endregion

		#region Private Fields
        // Test case file path.        
        private string m_testFilePath;
        
        // Random number file path.        
        private string m_randomFilePath;
        
        // Log file path.        
        private string m_logFilePath;
        
        // Random data step size.        
        private uint m_randomDataStepSize;
        
        // Server endpoint.        
        private EndpointDescription m_endpoint;
		#endregion
	}

	/// <summary>
	/// This class loads the configuration section for an application.
	/// </summary>
	public class TestConfigurationSection : IConfigurationSectionHandler
	{
		#region IConfigurationSectionHandler Members	
        /// <summary>
        /// Creates the configuration object from the configuration section.
        /// <see cref="IConfigurationSectionHandler.Create"/>
        /// </summary>	
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
                DataContractSerializer serializer = new DataContractSerializer(typeof(TestConfiguration));
                return serializer.ReadObject(reader) as TestConfiguration;
            }
            finally
            {
                reader.Close();
            }
		}
		#endregion
	}
}
