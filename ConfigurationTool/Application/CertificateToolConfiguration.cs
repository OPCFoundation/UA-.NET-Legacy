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
using System.IO;
using System.Runtime.Serialization;
using Opc.Ua.Configuration;

namespace Opc.Ua.Configuration
{
    /// <summary>
    /// Stores information about an account.
    /// </summary>
    [DataContract(Namespace="http://opcfoundation.org/UA/SDK/CertificateToolConfiguration.xsd")]
    public class CertificateToolConfiguration
    {
        #region Constructors
        /// <summary>
        /// Creates an empty object.
        /// </summary>
        public CertificateToolConfiguration()
        {
            m_applications = new List<ConfigureableApplication>();
            m_stores = new List<CertificateStoreIdentifier>();
        }

        /// <summary>
        /// Initializes the object during deserialization.
        /// </summary>
        [OnDeserializing()]
        private void Initialize(StreamingContext context)
        {
            m_applications = new List<ConfigureableApplication>();
            m_stores = new List<CertificateStoreIdentifier>();
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// The applications known to the tool.
        /// </summary>
        [DataMember(Order = 1)]
        public List<ConfigureableApplication> Applications
        {
            get
            { 
                return m_applications;  
            } 
            
            set 
            { 
                m_applications = value; 

                if (m_applications == null)
                {
                    m_applications = new List<ConfigureableApplication>();
                }
            }
        }

        /// <summary>
        /// The certificate stores known to the tool.
        /// </summary>
        [DataMember(Order = 2)]
        public List<CertificateStoreIdentifier> Stores
        {
            get
            { 
                return m_stores;  
            } 
            
            set 
            { 
                m_stores = value; 

                if (m_stores == null)
                {
                    m_stores = new List<CertificateStoreIdentifier>();
                }
            }
        }
        #endregion 

        #region Private Fields
        private List<ConfigureableApplication> m_applications;
        private List<CertificateStoreIdentifier> m_stores;
        #endregion 
    }
    
    #region ConfigureableApplication Class
    /// <summary>
    /// An application which can be configured by the certificate tool.
    /// </summary>
    [DataContract(Namespace="http://opcfoundation.org/UA/SDK/CertificateToolConfiguration.xsd")]
    public class ConfigureableApplication
    {
        #region Public Properties
        /// <summary>
        /// The location of the configuration file for the application.
        /// </summary>
        [DataMember(Order = 1)]
        public string ConfigurationFile
        {
            get { return m_configurationFile;  } 
            set { m_configurationFile = value; }
        }
        
        /// <summary>
        /// The assembly qualified type name for a class that implements ISecurityConfiguration
        /// </summary>
        [DataMember(Order = 2)]
        public string LoaderType
        {
            get { return m_loaderType;  } 
            set { m_loaderType = value; }
        }
        #endregion 

        #region Private Fields
        private string m_configurationFile;
        private string m_loaderType;
        #endregion 
    }
    #endregion 
}
