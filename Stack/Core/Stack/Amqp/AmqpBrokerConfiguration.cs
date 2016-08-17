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
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Opc.Ua.Bindings
{
    [DataContract(Namespace = Namespaces.OpcUaConfig)]
    public class AmqpBrokerKeySet
    {
        [DataMember(Order = 1)]
        public string AmqpNode { get; set; }

        [DataMember(Order = 2)]
        public string KeyName { get; set; }

        [DataMember(Order = 3)]
        public string KeyValue { get; set; }
    }

    [CollectionDataContract(Name = "ListOfAmqpBrokerKeySet", Namespace = Namespaces.OpcUaConfig, ItemName = "AmqpBrokerKeySet")]
    public partial class AmqpBrokerKeySetCollection : List<AmqpBrokerKeySet>
    {
    }

    [DataContract(Namespace = Namespaces.OpcUaConfig)]
    public enum BrokerTransport
    { 
        [EnumMember()]
        Amqps,

        [EnumMember()]
        Amqp,

        [EnumMember()]
        Wss
    }

    [DataContract(Namespace = Namespaces.OpcUaConfig)]
    public class AmqpBrokerConfiguration
    {
        #region Constructors
        /// <summary>
        /// The default constructor.
        /// </summary>
        public AmqpBrokerConfiguration()
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
        public string BrokerAddress { get; set; }

        [DataMember(Order = 2)]
        public BrokerTransport BrokerTransport { get; set; }

        [DataMember(Order = 3)]
        public string IncomingAmqpNode { get; set; }

        [DataMember(Order = 4)]
        public bool UseSasl { get; set; }

        [DataMember(Order = 5)]
        public string ReceiveKeyName { get; set; }

        [DataMember(Order = 6)]
        public string ReceiveKeyValue { get; set; }

        [DataMember(Order = 7)]
        public string SendKeyName { get; set; }

        [DataMember(Order = 8)]
        public string SendKeyValue { get; set; }

        [DataMember(Order = 9)]
        public AmqpBrokerKeySetCollection ServerKeys { get; set; }

        public IAmqpListener Listener { get; set; }
        #endregion
    }

    public class TargetKey
    {
        public string TargetName;
        public BrokerTransport BrokerTransport;
        public bool UseSasl;
        public string KeyName;
        public string KeyValue;
    }

    [CollectionDataContract(Name = "ListOfAmqpBrokerConfiguration", Namespace = Namespaces.OpcUaConfig, ItemName = "AmqpBrokerConfiguration")]
    public partial class AmqpBrokerConfigurationCollection : List<AmqpBrokerConfiguration>
    {
        public static AmqpBrokerConfigurationCollection Load(ApplicationConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException("configuration");
            }

            AmqpBrokerConfigurationCollection brokers = null;

            lock (configuration.PropertiesLock)
            {
                object value = null;

                if (configuration.Properties.TryGetValue("AmqpBrokers", out value))
                {
                    brokers = value as AmqpBrokerConfigurationCollection;
                }

                if (brokers == null)
                {
                    brokers = configuration.ParseExtension<AmqpBrokerConfigurationCollection>();

                    if (brokers == null)
                    {
                        brokers = new AmqpBrokerConfigurationCollection();
                    }

                    configuration.Properties["AmqpBrokers"] = brokers;
                }
            }

            return brokers;
        }

        public TargetKey FindTargetKeys(Uri brokerUrl, string amqpNodeName)
        {
            TargetKey target = new TargetKey();

            foreach (var broker in this)
            {
                if (brokerUrl.DnsSafeHost.EndsWith(broker.BrokerAddress))
                {
                    target.UseSasl = broker.UseSasl;

                    if (amqpNodeName == broker.IncomingAmqpNode)
                    {
                        target.TargetName = broker.IncomingAmqpNode;
                        target.KeyName = broker.SendKeyName;
                        target.KeyValue = broker.SendKeyValue;

                        return target;
                    }

                        
                    if (broker.ServerKeys != null && broker.ServerKeys.Count > 0)
                    {
                        foreach (var serverKey in broker.ServerKeys)
                        {
                            if (serverKey.AmqpNode == amqpNodeName)
                            {
                                target.TargetName = serverKey.AmqpNode;
                                target.KeyName = Uri.UnescapeDataString(serverKey.KeyName);
                                target.KeyValue = Uri.UnescapeDataString(serverKey.KeyValue);

                                return target;
                            }
                        }
                    }

                    break;
                }
            }

            return null;
        }

        public async Task<IAmqpListener> SelectListenerAsync(Uri endpointUrl, TcpChannelQuotas quotas)
        {
            IAmqpListener listener = null;
                    
            string amqpNodeName = endpointUrl.PathAndQuery.Substring(1);

            while (amqpNodeName.EndsWith("/"))
            {
                amqpNodeName = amqpNodeName.Substring(0, amqpNodeName.Length - 1);
            }

            foreach (var broker in this)
            {
                if (endpointUrl.DnsSafeHost.EndsWith(broker.BrokerAddress))
                {
                    listener = broker.Listener;

                    if (listener == null)
                    {
                        // listener = broker.Listener = new ServiceBusListener() { MessageSize = quotas.MaxMessageSize, ChunkSize = quotas.MaxBufferSize };
                        listener = broker.Listener = new GenericAmqpListener() { MessageSize = quotas.MaxMessageSize, ChunkSize = quotas.MaxBufferSize };

                        UriBuilder url = new UriBuilder();
                        url.Scheme = broker.BrokerTransport.ToString().ToLowerInvariant();
                        url.Host = broker.BrokerAddress;
                        url.Port = endpointUrl.Port;

                        var settings = new AmqpListenerSettings()
                        {
                            BrokerUrl = url.ToString(),
                            BrokerTransport = broker.BrokerTransport,
                            UseSasl = broker.UseSasl,
                            TokenRenewalInterval = 60000,
                            ServerKeys = new Dictionary<string, KeyValuePair<string, string>>()
                        };

                        if (!String.IsNullOrEmpty(broker.ReceiveKeyName))
                        {
                            settings.ReceiveKeyName = Uri.UnescapeDataString(broker.ReceiveKeyName);
                            settings.ReceiveKeyValue = Uri.UnescapeDataString(broker.ReceiveKeyValue);
                        }

                        if (!String.IsNullOrEmpty(broker.SendKeyName))
                        {
                            settings.SendKeyName = Uri.UnescapeDataString(broker.SendKeyName);
                            settings.SendKeyValue = Uri.UnescapeDataString(broker.SendKeyValue);
                        }

                        if (broker.ServerKeys != null && broker.ServerKeys.Count > 0)
                        {
                            foreach (var serverKey in broker.ServerKeys)
                            {
                                if (serverKey.AmqpNode != null)
                                {
                                    settings.ServerKeys[serverKey.AmqpNode] = new KeyValuePair<string, string>(Uri.UnescapeDataString(serverKey.KeyName), Uri.UnescapeDataString(serverKey.KeyValue));
                                }
                            }
                        }

                        await listener.ListenAsync(settings, String.IsNullOrEmpty(broker.IncomingAmqpNode) ? amqpNodeName : broker.IncomingAmqpNode);
                    }

                    break;
                }
            }

            if (listener == null)
            {
                throw new ServiceResultException(new ServiceResult(StatusCodes.BadConfigurationError, "No configuration information for the AMQP broker at " + endpointUrl));
            }

            return listener;
        }
    }
}
