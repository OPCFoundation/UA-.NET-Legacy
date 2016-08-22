/* ========================================================================
 * Copyright (c) 2005-2013 The OPC Foundation, Inc. All rights reserved.
 *
 * OPC Reciprocal Community Binary License ("RCBL") Version 1.00
 * 
 * Unless explicitly acquired and licensed from Licensor under another 
 * license, the contents of this file are subject to the Reciprocal 
 * Community Binary License ("RCBL") Version 1.00, or subsequent versions 
 * as allowed by the RCBL, and You may not copy or use this file in either 
 * source code or executable form, except in compliance with the terms and 
 * conditions of the RCBL.
 * 
 * All software distributed under the RCBL is provided strictly on an 
 * "AS IS" basis, WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESS OR IMPLIED, 
 * AND LICENSOR HEREBY DISCLAIMS ALL SUCH WARRANTIES, INCLUDING WITHOUT 
 * LIMITATION, ANY WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR 
 * PURPOSE, QUIET ENJOYMENT, OR NON-INFRINGEMENT. See the RCBL for specific 
 * language governing rights and limitations under the RCBL.
 *
 * The complete license agreement can be found here:
 * http://opcfoundation.org/License/RCBL/1.00/
 * ======================================================================*/

using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using System.Text;

namespace Opc.Ua.Bindings
{
    /// <summary>
    /// The binding element for the UA native stack.
    /// </summary>
    public class UaTcpTransportBindingElement : TransportBindingElement
    {
        #region Constructors
        /// <summary>
        /// Initializes the binding with its default configuration.
        /// </summary>
        public UaTcpTransportBindingElement()
        {
        }

        /// <summary>
        /// Initializes the binding with another binding.
        /// </summary>
        public UaTcpTransportBindingElement(UaTcpTransportBindingElement source) : base(source)
        {
            m_descriptions          = source.m_descriptions;
            m_configuration         = source.m_configuration;
            m_channelLifetime       = source.m_channelLifetime;
            m_securityTokenLifetime = source.m_securityTokenLifetime;
            m_messageContext        = source.m_messageContext;
            m_serviceHost           = source.ServiceHost;
        }
        #endregion
        
        #region Overridden Methods
        /// <summary>
        /// The scheme for the UA TCP transport.
        /// </summary>
        public override string Scheme
        {
            get { return Utils.UriSchemeOpcTcp; }
        }

        /// <summary>
        /// Creates the channel factory object.
        /// </summary>
        public override IChannelFactory<TChannel> BuildChannelFactory<TChannel>(BindingContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
            
            if (!this.CanBuildChannelFactory<TChannel>(context))
            {
                throw new ArgumentException(Utils.Format("Unsupported channel type: {0}.", typeof(TChannel).Name));
            }

            return (IChannelFactory<TChannel>)(object)new UaTcpChannelFactory(this, context);
        }
        
        /// <summary>
        /// Creates the channel listener object.
        /// </summary>
        public override IChannelListener<TChannel> BuildChannelListener<TChannel>(BindingContext context)
        {
            if (context == null) throw new ArgumentNullException("context");

            if (!this.CanBuildChannelListener<TChannel>(context))
            {
                throw new ArgumentException(Utils.Format("Unsupported channel type: {0}.", typeof(TChannel).Name));
            }

            return (IChannelListener<TChannel>)(object)new UaTcpChannelListener(this, context);
        }

        /// <summary>
        /// Used by higher layers to determine what types of channel factories this binding element supports.
        /// </summary>
        public override bool CanBuildChannelFactory<TChannel>(BindingContext context)
        {
            return (typeof(TChannel) == typeof(IRequestSessionChannel));
        }

        /// <summary>
        /// Used by higher layers to determine what types of channel listeners this binding element supports. 
        /// </summary>
        public override bool CanBuildChannelListener<TChannel>(BindingContext context)
        {
            return (typeof(TChannel) == typeof(IReplySessionChannel));
        }

        /// <summary>
        /// Creates a copy of the binding element.
        /// </summary>
        public override BindingElement Clone()
        {
            return new UaTcpTransportBindingElement(this);
        }
        
        /// <summary>
        /// Returns the property associated with the binding element.
        /// </summary>
        public override T GetProperty<T>(BindingContext context)
        {
            if (typeof(T) == typeof(MessageVersion))
            {
                return (T)(object)MessageVersion.Soap12WSAddressing10;
            }

            if (typeof(T) == typeof(ISecurityCapabilities))
            {
                return (T)(object)new Opc.Ua.Bindings.SecurityCapabilities();
            }                        
                                
            return context.GetInnerProperty<T>();
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// The descriptions for the endpoint.
        /// </summary>
        public EndpointDescriptionCollection Descriptions
        {
            get { return m_descriptions;  }
            set { m_descriptions = value; }
        }

        /// <summary>
        /// The configuration of the endpoint.
        /// </summary>
        public EndpointConfiguration Configuration
        {
            get { return m_configuration;  }
            set { m_configuration = value; }
        }

        /// <summary>
        /// The default lifetime for UA TCP connections.
        /// </summary>
        public int ChannelLifetime
        {
            get { return m_channelLifetime;  }
            set { m_channelLifetime = value; }
        }

        /// <summary>
        /// The default lifetime for security tokens.
        /// </summary>
        public int SecurityTokenLifetime
        {
            get { return m_securityTokenLifetime;  }
            set { m_securityTokenLifetime = value; }
        }

        /// <summary>
        /// The service message context to be used by the transport.
        /// </summary>
        public ServiceMessageContext MessageContext
        {
            get { return m_messageContext;  }
            set { m_messageContext = value; }
        }

        /// <summary>
        /// The service host which is configured to use the binding.
        /// </summary>
        /// <remarks>
        /// This property is *only* used by the UA TCP channel implementation to bypass the WCF channel 
        /// handling on the server side. It is a hack which is necessary because the WCF framework
        /// loses requests during stress testing. 
        /// </remarks>
        public ServiceHost ServiceHost
        {
            get { return m_serviceHost;  }
            set { m_serviceHost = value; }
        }
        #endregion

        #region Private Fields
        private EndpointDescriptionCollection m_descriptions;
        private EndpointConfiguration m_configuration;
        private ServiceMessageContext m_messageContext;
        private int m_channelLifetime;
        private int m_securityTokenLifetime;
        private ServiceHost m_serviceHost;
        #endregion
    }
}
