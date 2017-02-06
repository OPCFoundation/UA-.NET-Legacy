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
using System.Text;
using System.Reflection;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Opc.Ua
{
    /// <summary>
	/// The properties of the current server instance.
	/// </summary>
	public class ServerProperties
	{
		#region Constructors
		/// <summary>
		/// The default constructor.
		/// </summary>
		public ServerProperties()
		{
			Initialize();

            // assume calling assembly is the main assembly for the product.
            Assembly assembly = Assembly.GetCallingAssembly();

            if (assembly != null)
            {
                Initialize(assembly);
            }
		}

		/// <summary>
		/// Sets private members to default values.
		/// </summary>
		private void Initialize()
		{
		    m_productUri = null;
		    m_manufacturerName = null;
		    m_productName = null;
		    m_softwareVersion = null;
		    m_buildNumber = null;
		    m_buildDate = DateTime.MinValue;
            m_datatypeAssemblies = new StringCollection();
            m_softwareCertificates = new SignedSoftwareCertificateCollection();
		}
        
        /// <summary>
        /// Initializes the server properties from the assembly properties.
        /// </summary>
        private void Initialize(Assembly assembly)
        {            
            m_productUri = assembly.FullName;
            
            AssemblyTitleAttribute attribute1 = Attribute.GetCustomAttribute(assembly, typeof(AssemblyTitleAttribute)) as AssemblyTitleAttribute;

            if (attribute1 != null)
            {
                m_productName = attribute1.Title;
            }
            
            AssemblyCompanyAttribute attribute2 = Attribute.GetCustomAttribute(assembly, typeof(AssemblyCompanyAttribute)) as AssemblyCompanyAttribute;

            if (attribute2 != null)
            {
                m_manufacturerName = attribute2.Company;
            }
               
            Version version = assembly.GetName().Version;

            m_softwareVersion = Utils.Format("{0}.{1}", version.Major, version.Minor);
            m_buildNumber     = Utils.Format("{0}.{1}", version.Revision, version.Build);
            m_buildDate       = new FileInfo(assembly.Location).CreationTimeUtc;
        }
		#endregion

		#region Public Properties
		/// <summary>
		/// The unique identifier for the product.
		/// </summary>
		public string ProductUri
		{
			get { return m_productUri;  }
			set { m_productUri = value; }
		}
     
		/// <summary>
		/// The name of the product
		/// </summary>
		public string ProductName
		{
			get { return m_productName;  }
			set { m_productName = value; }
		}     
     
		/// <summary>
		/// The name of the manufacturer
		/// </summary>
		public string ManufacturerName
		{
			get { return m_manufacturerName;  }
			set { m_manufacturerName = value; }
		}  
     
		/// <summary>
		/// The software version for the application
		/// </summary>
		public string SoftwareVersion
		{
			get { return m_softwareVersion;  }
			set { m_softwareVersion = value; }
		}       
     
		/// <summary>
		/// The build number for the application
		/// </summary>
		public string BuildNumber
		{
			get { return m_buildNumber;  }
			set { m_buildNumber = value; }
		}       
     
		/// <summary>
		/// When the application was built.
        /// </summary>
		public DateTime BuildDate
		{
			get { return m_buildDate;  }
			set { m_buildDate = value; }
		}       
                
		/// <summary>
		/// The assemblies that contain encodeable types that could be uses a variable values.
		/// </summary>
		public StringCollection DatatypeAssemblies
		{
			get { return m_datatypeAssemblies; }
		}

        /// <summary>
        /// The software certificates granted to the server.
        /// </summary>
        public SignedSoftwareCertificateCollection SoftwareCertificates
        {
            get { return m_softwareCertificates; }
        }
		#endregion

		#region Private Members
		private string m_productUri;
		private string m_productName;
		private string m_manufacturerName;
		private string m_softwareVersion;
		private string m_buildNumber;
		private DateTime m_buildDate;
        private StringCollection m_datatypeAssemblies;
        private SignedSoftwareCertificateCollection m_softwareCertificates;
		#endregion
	}
}
