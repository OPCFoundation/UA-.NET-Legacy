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
using System.Text;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;

using Opc.Ua.Bindings;

namespace Opc.Ua.Bindings
{
    /// <summary>
    /// The channel factory for the UA Secure Conversation protocol
    /// </summary>
    public class UaTcpChannelFactory : ChannelFactoryBase<IRequestSessionChannel>
    {
        #region Constructors
        /// <summary>
        /// Initializes the listener from a binding element.
        /// </summary>
        public UaTcpChannelFactory(UaTcpTransportBindingElement bindingElement, BindingContext context) : base(context.Binding)
        {   
            // assign a unique id to the instance.
            m_id = Guid.NewGuid().ToString();

            // initialize the quotas from the binding configuration.
            EndpointConfiguration configuration = bindingElement.Configuration;

            m_quotas = new TcpChannelQuotas();

            m_quotas.MaxBufferSize         = configuration.MaxBufferSize;
            m_quotas.MaxMessageSize        = configuration.MaxMessageSize;
            m_quotas.ChannelLifetime       = configuration.ChannelLifetime;
            m_quotas.SecurityTokenLifetime = configuration.SecurityTokenLifetime;            
            m_quotas.MessageContext        = bindingElement.MessageContext;

            m_bufferManager = new BufferManager("Client", (int)bindingElement.MaxBufferPoolSize, m_quotas.MaxBufferSize);
                   
            // extract the security mode from the endpoint description.
            m_endpointDescription = null;

            if (bindingElement.Descriptions != null && bindingElement.Descriptions.Count > 0)
            {
                m_endpointDescription = bindingElement.Descriptions[0];
            }

            // find the client credentials in the binding parameters.
            foreach (object parameter in context.BindingParameters)
            {
                ClientCredentials credentials = parameter as ClientCredentials;

                if (credentials != null)
                {
                    m_credentials = credentials;
                    m_quotas.CertificateValidator = credentials.ServiceCertificate.Authentication.CustomCertificateValidator;
                    break;
                }
            }
        }
        #endregion
             
        #region Overridden Methods
        /// <summary cref="ChannelFactoryBase{T}.OnCreateChannel" />
        protected override IRequestSessionChannel OnCreateChannel(EndpointAddress address, Uri via)
        {
            X509Certificate2 clientCertificate = null;

            if (m_credentials.ClientCertificate.Certificate != null)
            {
                clientCertificate = m_credentials.ClientCertificate.Certificate;
            }

            X509Certificate2 serverCertificate = null;

            if (m_endpointDescription != null)
            {
                serverCertificate = CertificateFactory.Create(m_endpointDescription.ServerCertificate, true);
            }

            UaTcpRequestChannel channel = new UaTcpRequestChannel(
                this, 
                m_id,
                address, 
                via, 
                m_bufferManager,
                m_quotas,
                clientCertificate,
                serverCertificate,
                m_endpointDescription);

            return channel;
        }

        /// <summary cref="CommunicationObject.OnOpen" />
        protected override void OnOpen(TimeSpan timeout)
        {
            // do nothing.
        }

        /// <summary cref="CommunicationObject.OnBeginOpen" />
        protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
        {
            TcpAsyncOperation<int> operation = new TcpAsyncOperation<int>(Int32.MaxValue, callback, state);
            operation.Complete(0);
            return operation; 
        }
        
        /// <summary cref="CommunicationObject.OnEndOpen" />
        protected override void OnEndOpen(IAsyncResult result)
        {
            try
            {
                TcpAsyncOperation<int> operation = (TcpAsyncOperation<int>)result;
                operation.End(Int32.MaxValue);
            }
            catch (Exception e)
            {
                throw ServiceResultException.Create(StatusCodes.BadInternalError, e, "Could not open UA TCP channel factory.");
            }
        }

        /// <summary cref="CommunicationObject.OnClose" />
        protected override void OnClose(TimeSpan timeout)
        {
            // do nothing.
        }

        /// <summary cref="CommunicationObject.OnBeginClose" />
        protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return base.OnBeginClose(timeout, callback, state);
        }
        
        /// <summary cref="CommunicationObject.OnEndClose" />
        protected override void OnEndClose(IAsyncResult result)
        {
            base.OnEndClose(result);
        }

        /// <summary cref="ChannelFactoryBase.GetProperty{T}" />
        public override T GetProperty<T>()
        {
            if (typeof(T) == typeof(ISecurityCapabilities))
            {
                return (T)(object)new SecurityCapabilities();
            }

            if (typeof(T) == typeof(TcpChannelQuotas))
            {
                return (T)(object)m_quotas;
            }
            
            return base.GetProperty<T>();
        }
        #endregion
        
        #region Protected Properties
        /// <summary>
        /// A unique identifier for the factory.
        /// </summary>
        protected string Id
        {
            get { return m_id; }
        }
        
        /// <summary>
        /// The client credentials to use when connecting.
        /// </summary>
        protected ClientCredentials Credentials
        {
            get { return m_credentials; }
        }
        
        /// <summary>
        /// The resource quotas to use.
        /// </summary>
        protected TcpChannelQuotas Quotas
        {
            get { return m_quotas; }
        }
        
        /// <summary>
        /// The security mode to use.
        /// </summary>
        protected EndpointDescription EndpointDescription
        {
            get { return m_endpointDescription; }
        }
        #endregion

        #region Private Fields
        private string m_id;
        private ClientCredentials m_credentials;
        private TcpChannelQuotas m_quotas;
        private BufferManager m_bufferManager;
        private EndpointDescription m_endpointDescription;
        #endregion
    }
}
