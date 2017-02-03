/* Copyright (c) 1996-2016, OPC Foundation. All rights reserved.

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
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Opc.Ua.Server;

namespace Opc.Ua.GdsServer
{
    /// <summary>
    /// Stores the configuration the data access node manager.
    /// </summary>
    [DataContract(Namespace=Opc.Ua.Gds.Namespaces.OpcUaGds + "Configuration.xsd")]
    public class GlobalDiscoveryServerConfiguration
    {
        #region Constructors
        /// <summary>
        /// The default constructor.
        /// </summary>
        public GlobalDiscoveryServerConfiguration()
        {
            Initialize();
        }

        /// <summary>
        /// Initializes the object during deserialization.
        /// </summary>
        [OnDeserializing()]
        private void Initialize(StreamingContext context)
        {
            Initialize();
        }

        /// <summary>
        /// Sets private members to default values.
        /// </summary>
        private void Initialize()
        {
        }
        #endregion

        #region Public Properties
        [DataMember(Order = 1)]
        public string AuthoritiesStorePath { get; set; }

        [DataMember(Order = 2)]
        public string ApplicationCertificatesStorePath { get; set; }

        [DataMember(Order = 3)]
        public string DefaultSubjectNameContext { get; set; }

        [DataMember(Order = 4)]
        public CertificateGroupConfigurationCollection CertificateGroups { get; set; }

        [DataMember(Order = 5)]
        public StringCollection KnownHostNames { get; set; }

        [DataMember(Order = 6)]
        public GdsServerAuthorizationServiceConfigurationCollection AuthorizationServices { get; set; }
        #endregion

        #region Private Members
        #endregion
    }

    /// <summary>
    /// Stores the configuration the data access node manager.
    /// </summary>
    [DataContract(Namespace = Opc.Ua.Gds.Namespaces.OpcUaGds + "Configuration.xsd")]
    public class CertificateGroupConfiguration
    {
        #region Constructors
        /// <summary>
        /// The default constructor.
        /// </summary>
        public CertificateGroupConfiguration()
        {
            Initialize();
        }

        /// <summary>
        /// Initializes the object during deserialization.
        /// </summary>
        [OnDeserializing()]
        private void Initialize(StreamingContext context)
        {
            Initialize();
        }

        /// <summary>
        /// Sets private members to default values.
        /// </summary>
        private void Initialize()
        {
        }
        #endregion

        #region Public Properties
        [DataMember(Order = 1)]
        public string Id { get; set; }

        [DataMember(Order = 2)]
        public string SubjectName { get; set; }

        [DataMember(Order = 3)]
        public string BaseStorePath { get; set; }

        [DataMember(Order = 4)]
        public ushort DefaultCertificateLifetime { get; set; }

        [DataMember(Order = 5)]
        public ushort DefaultCertificateKeySize { get; set; }
        #endregion

        #region Private Members
        #endregion
    }

    [CollectionDataContract(Name = "ListOfCertificateGroupConfiguration", Namespace = Opc.Ua.Gds.Namespaces.OpcUaGds + "Configuration.xsd", ItemName = "CertificateGroupConfiguration")]
    public partial class CertificateGroupConfigurationCollection : List<CertificateGroupConfiguration>
    {
        /// <summary>
        /// Initializes an empty collection.
        /// </summary>
        public CertificateGroupConfigurationCollection() { }

        /// <summary>
        /// Initializes the collection from another collection.
        /// </summary>
        /// <param name="collection">A collection of values to add to this new collection</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// 	<paramref name="collection"/> is null.
        /// </exception>
        public CertificateGroupConfigurationCollection(IEnumerable<CertificateGroupConfiguration> collection) : base(collection) { }

        /// <summary>
        /// Initializes the collection with the specified capacity.
        /// </summary>
        /// <param name="capacity">The capacity.</param>
        public CertificateGroupConfigurationCollection(int capacity) : base(capacity) { }
    }

    /// <summary>
    /// Stores the configuration the data access node manager.
    /// </summary>
    [DataContract(Name = "AuthorizationService", Namespace = Opc.Ua.Gds.Namespaces.OpcUaGds + "Configuration.xsd")]
    public class GdsServerAuthorizationServiceConfiguration
    {
        #region Constructors
        /// <summary>
        /// The default constructor.
        /// </summary>
        public GdsServerAuthorizationServiceConfiguration()
        {
            Initialize();
        }

        /// <summary>
        /// Initializes the object during deserialization.
        /// </summary>
        [OnDeserializing()]
        private void Initialize(StreamingContext context)
        {
            Initialize();
        }

        /// <summary>
        /// Sets private members to default values.
        /// </summary>
        private void Initialize()
        {
        }
        #endregion

        #region Public Properties
        [DataMember(Order = 1)]
        public string ServiceName { get; set; }

        [DataMember(Order = 2)]
        public UserTokenPolicyCollection UserTokenPolicies { get; set; }
        #endregion

        #region Private Members
        #endregion
    }

    [CollectionDataContract(Name = "ListOfAuthorizationService", Namespace = Opc.Ua.Gds.Namespaces.OpcUaGds + "Configuration.xsd", ItemName = "AuthorizationService")]
    public partial class GdsServerAuthorizationServiceConfigurationCollection : List<GdsServerAuthorizationServiceConfiguration>
    {
        /// <summary>
        /// Initializes an empty collection.
        /// </summary>
        public GdsServerAuthorizationServiceConfigurationCollection() { }

        /// <summary>
        /// Initializes the collection from another collection.
        /// </summary>
        /// <param name="collection">A collection of values to add to this new collection</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// 	<paramref name="collection"/> is null.
        /// </exception>
        public GdsServerAuthorizationServiceConfigurationCollection(IEnumerable<GdsServerAuthorizationServiceConfiguration> collection) : base(collection) { }

        /// <summary>
        /// Initializes the collection with the specified capacity.
        /// </summary>
        /// <param name="capacity">The capacity.</param>
        public GdsServerAuthorizationServiceConfigurationCollection(int capacity) : base(capacity) { }
    }
}
