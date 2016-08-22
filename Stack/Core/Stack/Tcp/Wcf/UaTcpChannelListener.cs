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
using System.Threading;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;

using Opc.Ua.Bindings;

namespace Opc.Ua.Bindings
{
    /// <summary>
    /// The listener for the UA Native Stack
    /// </summary>
    public partial class UaTcpChannelListener : ChannelListenerBase<IReplySessionChannel>
    {
        #region Constructors
        /// <summary>
        /// Initializes the listener from a binding element.
        /// </summary>
        internal UaTcpChannelListener(UaTcpTransportBindingElement bindingElement, BindingContext context) 
        : 
            base(context.Binding)
        {
            // assign a unique guid to the listener.
            m_listenerId = Guid.NewGuid().ToString();

            SetUri(context.ListenUriBaseAddress, context.ListenUriRelativeAddress);
            
            m_descriptions  = bindingElement.Descriptions;
            m_configuration = bindingElement.Configuration;
            
            m_quotas = new TcpChannelQuotas();

            m_quotas.MaxBufferSize         = m_configuration.MaxBufferSize;
            m_quotas.MaxMessageSize        = m_configuration.MaxMessageSize;
            m_quotas.ChannelLifetime       = m_configuration.ChannelLifetime;
            m_quotas.SecurityTokenLifetime = m_configuration.SecurityTokenLifetime;            
            m_quotas.MessageContext        = bindingElement.MessageContext;

            foreach (object parameter in context.BindingParameters)
            {
                ServiceCredentials credentials = parameter as ServiceCredentials;

                if (credentials != null)
                {
                    // TBD - paste the cert with the private key with the additional chain. 
                    m_serverCertificate = CertificateFactory.Create(credentials.ServiceCertificate.Certificate, credentials.ServiceCertificate.Certificate);
                    m_quotas.CertificateValidator = credentials.ClientCertificate.Authentication.CustomCertificateValidator;
                }
            }        
                        
            m_bufferManager  = new BufferManager("Server", (int)bindingElement.MaxBufferPoolSize, m_quotas.MaxBufferSize);
            
            m_channels = new Dictionary<uint,TcpServerChannel>();
            m_channelQueue = new Queue<UaTcpReplyChannel>();
            m_acceptQueue = new Queue<TcpAsyncOperation<IReplySessionChannel>>();

            // link the channel directly to the server.
            // this is a hack designed to work around a bug in the WCF framework that results in lost requests during stress testing.
            if (bindingElement.ServiceHost != null)
            {
                if (bindingElement.ServiceHost.Server is DiscoveryServerBase)
                {
                    m_callback = new DiscoveryEndpoint(bindingElement.ServiceHost);
                }
                else
                {
                    m_callback = new SessionEndpoint(bindingElement.ServiceHost);
                }
            }
        }
        #endregion
        
        #region Overridden Methods
        /// <summary cref="ChannelListenerBase.GetProperty{T}" />
        public override T GetProperty<T>()
        {
            if (typeof(T) == typeof(ISecurityCapabilities))
            {
                return (T)(object)new SecurityCapabilities();
            }
            
            return base.GetProperty<T>();
        }

        /// <summary cref="ChannelListenerBase.Uri" />
        public override Uri Uri
        {
            get { return m_uri; }
        }

        #region Open
        /// <summary cref="CommunicationObject.OnOpen" />
        protected override void OnOpen(TimeSpan timeout)
        {
            IAsyncResult result = OnBeginOpen(timeout, null, null);
            OnEndOpen(result);
        }

        /// <summary cref="CommunicationObject.OnBeginOpen" />
        protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
        {      
            TcpAsyncOperation<int> operation = new TcpAsyncOperation<int>(Utils.GetTimeout(timeout), callback, state);
            ThreadPool.QueueUserWorkItem(new WaitCallback(InternalOpen), operation);
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
                throw ServiceResultException.Create(StatusCodes.BadInternalError, e, "Could not open UA TCP listener.");
            }
        }  

        /// <summary>
        /// Opens the listener.
        /// </summary>
        private void InternalOpen(object state)
        {            
            TcpAsyncOperation<int> operation = (TcpAsyncOperation<int>)state;

            try
            {
                lock (m_lock)
                {
                    Start();
                }

                operation.Complete(0);
            }
            catch (Exception e)
            {
                operation.Fault(e, StatusCodes.BadInternalError, "Could not start UA TCP listener.");
            }
        }
        #endregion
                
        #region Close
        /// <summary cref="CommunicationObject.OnClose" />
        protected override void OnClose(TimeSpan timeout)
        {
            IAsyncResult result = OnBeginClose(timeout, null, null);
            OnEndClose(result);
        }
        
        /// <summary cref="CommunicationObject.OnBeginClose" />
        protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
        {
            TcpAsyncOperation<int> operation = new TcpAsyncOperation<int>(Utils.GetTimeout(timeout), callback, state);
            ThreadPool.QueueUserWorkItem(new WaitCallback(InternalClose), operation);
            return operation;
        }
        
        /// <summary cref="CommunicationObject.OnEndClose" />
        protected override void OnEndClose(IAsyncResult result)
        {
            try
            {
                TcpAsyncOperation<int> operation = (TcpAsyncOperation<int>)result;
                operation.End(Int32.MaxValue);
            }
            catch (Exception e)
            {
                m_fault = ServiceResult.Create(e, StatusCodes.BadInternalError, "Could not close UA TCP listener.");
                Utils.Trace(m_fault.ToLongString());
                Fault();                
            }
        } 

        /// <summary cref="CommunicationObject.OnAbort" />
        protected override void OnAbort()
        {
            lock (m_lock)
            {
                Stop();
            }
        }

        /// <summary>
        /// Closes the listener.
        /// </summary>
        private void InternalClose(object state)
        {            
            TcpAsyncOperation<int> operation = (TcpAsyncOperation<int>)state;

            try
            {
                lock (m_lock)
                {                     
                    while (m_channelQueue.Count > 0)
                    {
                        UaTcpReplyChannel channel = m_channelQueue.Dequeue();
                        channel.Abort();
                    }

                    while (m_acceptQueue.Count > 0)
                    {
                        TcpAsyncOperation<IReplySessionChannel> waitingAccept = m_acceptQueue.Dequeue();
                        waitingAccept.Fault(StatusCodes.BadServerHalted);
                    }      

                    Stop();
                }

                operation.Complete(0);
            }
            catch (Exception e)
            {
                operation.Fault(e, StatusCodes.BadInternalError, "Could not close UA TCP listener.");
            }
        }
        #endregion
                
        #region Accept
        /// <summary cref="ChannelListenerBase{T}.OnAcceptChannel" />
        protected override IReplySessionChannel OnAcceptChannel(TimeSpan timeout)
        {        
            IAsyncResult result = OnBeginAcceptChannel(timeout, null, null);
            return OnEndAcceptChannel(result);
        }

        /// <summary cref="ChannelListenerBase{T}.OnBeginAcceptChannel" />
        protected override IAsyncResult OnBeginAcceptChannel(TimeSpan timeout, AsyncCallback callback, object state)
        {        
            TcpAsyncOperation<IReplySessionChannel> operation = new TcpAsyncOperation<IReplySessionChannel>(Utils.GetTimeout(timeout), callback, state);

            lock (m_lock)
            {
                if (m_channelQueue.Count > 0)
                {
                    UaTcpReplyChannel channel = m_channelQueue.Dequeue();
                    Utils.Trace("Channel Accepted: Id={0}", channel.Id); 
                    operation.Complete(channel);
                    return operation;
                }

                m_acceptQueue.Enqueue(operation);
            }

            return operation;
        }

        /// <summary cref="ChannelListenerBase{T}.OnEndAcceptChannel" />
        protected override IReplySessionChannel OnEndAcceptChannel(IAsyncResult result)
        {
            try
            {
                TcpAsyncOperation<IReplySessionChannel> operation = (TcpAsyncOperation<IReplySessionChannel>)result;
                return operation.End(Int32.MaxValue);
            }
            catch (Exception e)
            {
                m_fault = ServiceResult.Create(e, StatusCodes.BadInternalError, "Error accepting a new UA TCP reply channel.");
                Utils.Trace(m_fault.ToLongString());
                Fault(); 
                return null;
            }
        }
        #endregion
                
        #region WaitForChannel
        /// <summary cref="ChannelListenerBase.OnWaitForChannel" />
        protected override bool OnWaitForChannel(TimeSpan timeout)
        {
            throw new NotImplementedException();
        }

        /// <summary cref="ChannelListenerBase.OnBeginWaitForChannel" />
        protected override IAsyncResult OnBeginWaitForChannel(TimeSpan timeout, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }
        
        /// <summary cref="ChannelListenerBase.OnEndWaitForChannel" />
        protected override bool OnEndWaitForChannel(IAsyncResult result)
        {
            throw new NotImplementedException();
        }    
        #endregion

        #endregion
        
        #region Private Fields
        private Queue<UaTcpReplyChannel> m_channelQueue;
        private Queue<TcpAsyncOperation<IReplySessionChannel>> m_acceptQueue;
        private ServiceResult m_fault;
        #endregion
    }
}
