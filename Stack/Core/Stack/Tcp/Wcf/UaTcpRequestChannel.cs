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
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.Serialization;
using System.Xml;
using System.IO;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

using Opc.Ua.Bindings;

namespace Opc.Ua.Bindings
{
    /// <summary>
    /// A channel used to apply the UA message security to a message.
    /// </summary>
    public class UaTcpRequestChannel : ChannelBase, IRequestSessionChannel, IOutputSession, IBinaryEncodingCapabilities, IDisposable
    {
        #region Constructors
        /// <summary>
        /// Initializes the channel with a channel manager. 
        /// </summary>
        internal UaTcpRequestChannel(
            ChannelManagerBase  manager,
            string              factoryId,
            EndpointAddress     address,
            Uri                 via,
            BufferManager       bufferManager,
            TcpChannelQuotas    quotas,
            X509Certificate2    clientCertificate,
            X509Certificate2    serverCertificate,
            EndpointDescription endpointDescription)
        :
            base(manager)
        {    
            m_factoryId = factoryId;
            m_address   = address;
            m_via       = via;
            m_quotas    = quotas;

            m_channel = new TcpClientChannel(
                m_factoryId,
                bufferManager, 
                quotas,
                clientCertificate,
                serverCertificate,
                endpointDescription);

            m_ResponseCallack = new AsyncCallback(OnResponse);
        }

        /// <summary>
        /// Initializes the request channel for use as a subtype. 
        /// </summary>
        protected UaTcpRequestChannel(
            ChannelManagerBase  manager,
            string              factoryId,
            EndpointAddress     address,
            Uri                 via,
            TcpChannelQuotas    quotas)
        :
            base(manager)
        {    
            m_factoryId = factoryId;
            m_address   = address;
            m_via       = via;
            m_quotas    = quotas;

            m_ResponseCallack = new AsyncCallback(OnResponse);
        }
        #endregion
        
        #region IDisposable Members
        /// <summary>
        /// Frees any unmanaged resources.
        /// </summary>
        public void Dispose()
        {   
            Dispose(true);
        }

        /// <summary>
        /// An overrideable version of the Dispose.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2213:DisposableFieldsShouldBeDisposed", MessageId = "m_channel")]
        protected virtual void Dispose(bool disposing)
        {
            if (disposing) 
            {
                Utils.SilentDispose(m_channel);
                m_channel = null;
            }
        }
        #endregion

        #region Overridden Methods
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
            return InternalBeginConnect(m_via, Utils.GetTimeout(timeout), callback, state);
        }

        /// <summary cref="CommunicationObject.OnEndOpen" />
        protected override void OnEndOpen(IAsyncResult result)
        {
            try
            {
                InternalEndConnect(result);
            }
            catch (Exception e)
            {
                throw ServiceResultException.Create(StatusCodes.BadInternalError, e, "Could not open UA TCP request channel.");
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
                m_fault = ServiceResult.Create(e, StatusCodes.BadInternalError, "Could not close UA TCP client channel.");
                Utils.Trace(m_fault.ToLongString());
                Fault();
            }
        }
        
        /// <summary cref="CommunicationObject.OnAbort" />
        protected override void OnAbort()
        {
            try
            {
                InternalClose(500);
            }
            catch (Exception e)
            {
                m_fault = ServiceResult.Create(e, StatusCodes.BadInternalError, "Could not close UA TCP client channel.");
                Utils.Trace(m_fault.ToLongString());
            }
        }        

        /// <summary>
        /// Closes the channel.
        /// </summary>
        private void InternalClose(object state)
        {
            TcpAsyncOperation<int> operation = (TcpAsyncOperation<int>)state;

            try
            {
                InternalClose(Int32.MaxValue);
                operation.Complete(0);
            }
            catch (Exception e)
            {
                operation.Fault(e, StatusCodes.BadInternalError, "Could not close UA TCP request channel.");
            }
        }
        #endregion

        /// <summary cref="ChannelBase.GetProperty{T}" />
        public override T GetProperty<T>()
        {
            if (typeof(T) == typeof(ISession))
            {
                return (T)(object)this;
            }           

            if (typeof(T) == typeof(TcpChannelQuotas))
            {
                return (T)(object)m_quotas;
            }
            
            return base.GetProperty<T>();
        }
        #endregion
        
        #region IBinaryEncodingCapabilities Members
        /// <summary cref="IBinaryEncodingCapabilities.EncodingSupport" />
        public BinaryEncodingSupport EncodingSupport
        {
            get { return BinaryEncodingSupport.Required; }
        }
        #endregion

        #region IRequestSessionChannel Members
        /// <summary cref="IRequestChannel.RemoteAddress" />
        public EndpointAddress RemoteAddress
        {
            get { return m_address; }
        }
        
        /// <summary cref="IRequestChannel.Via" />
        public Uri Via
        {
            get { return m_via; }
        }
        
        /// <summary cref="IRequestChannel.Request(Message)" />
        public Message Request(Message message)
        {
            return Request(message, TimeSpan.MaxValue);
        }
        
        /// <summary cref="IRequestChannel.Request(Message, TimeSpan)" />
        public Message Request(Message message, TimeSpan timeout)
        {
            IAsyncResult result = BeginRequest(message, timeout, null, null);
            return EndRequest(result);
        }
        
        /// <summary cref="IRequestChannel.BeginRequest(Message, AsyncCallback, object)" />
        public IAsyncResult BeginRequest(Message message, AsyncCallback callback, object state)
        {
            return BeginRequest(message, TimeSpan.MaxValue, callback, state);
        }

        /// <summary cref="IRequestChannel.BeginRequest(Message, TimeSpan, AsyncCallback, object)" />
        public IAsyncResult BeginRequest(Message message, TimeSpan timeout, AsyncCallback callback, object state)
        {
            int milliseconds = Utils.GetTimeout(timeout);

            SendOperation operation = new SendOperation(milliseconds, callback, state);
            
            // save message id for use in response.
            operation.MessageId = message.Headers.MessageId;

            // extract the request from the message properties (put there by the message inspector).
            IServiceRequest request = (IServiceRequest)message.Properties[MessageProperties.UnencodedBody];

            // start the request.
            InternalBeginSendRequest(request, milliseconds, m_ResponseCallack, operation);

            return operation;
        }
        
        /// <summary cref="IRequestChannel.EndRequest" />
        public Message EndRequest(IAsyncResult result)
        {
            SendOperation operation = (SendOperation)result;

            // wait for operation to complete.
            IServiceResponse response = null;

            try
            {
                response = operation.End(Int32.MaxValue);
            }
            catch (ServiceResultException e)
            {
                if (e.StatusCode == StatusCodes.BadRequestInterrupted)
                {
                    throw new TimeoutException();
                }

                throw new ServiceResultException(e, StatusCodes.BadUnexpectedError);
            }
                        
            // create response.
            Message message = Message.CreateMessage(
                MessageVersion.Soap12WSAddressing10,
                Namespaces.OpcUaWsdl + "/InvokeServiceResponse",
                new InvokeServiceBodyWriter(null, false));

            // update headers.
            message.Headers.From = this.m_address;
            message.Headers.RelatesTo = operation.MessageId;

            // save the response.
            message.Properties[MessageProperties.UnencodedBody] = response;

            return message;
        }
        #endregion
        
        #region ISessionChannel<IOutputSession> Members
        /// <summary cref="ISessionChannel{T}.Session" />
        public IOutputSession Session
        {
            get { return this; }
        }
        #endregion

        #region ISession Members
        /// <summary cref="ISession.Id" />
        public string Id
        {
            get
            {
                return Utils.Format("{0}-{1}", m_factoryId, ChannelId);
            }
        }
        #endregion        
        
        #region Channel Event Handlers
        /// <summary>
        /// Called when a response arrives from the channel.
        /// </summary>
        private void OnResponse(IAsyncResult result)
        {
            SendOperation operation = (SendOperation)result.AsyncState;

            try
            {
                IServiceResponse response = InternalEndSendRequest(result);                   
                operation.Complete(response);
            }
            catch (Exception e)
            {
                operation.Fault(e, StatusCodes.BadInternalError, "Error receiving response from channel.");
            }
        }                    
        #endregion

        #region SendOperation Class
        /// <summary>
        /// Stores the state of an asynchronous send operation.
        /// </summary>
        protected class SendOperation : TcpAsyncOperation<IServiceResponse>
        {
            /// <summary>
            /// Initializes the operation.
            /// </summary>
            public SendOperation(int timeout, AsyncCallback callback, object state) : base(timeout, callback, state)
            {
            }

            /// <summary>
            /// The unique identifier assigned by WCF to the operation.
            /// </summary>
            public UniqueId MessageId
            {
                get { return m_messageId; }
                set { m_messageId = value; }
            }    

            /// <summary>
            /// An optional unique identifier for the operation.
            /// </summary>
            public int RequestId
            {
                get { return m_requestId; }
                set { m_requestId = value; }
            }

            #region Private Fields
            private UniqueId m_messageId;
            private int m_requestId;
            #endregion
        }    
        #endregion
        
        #region Protected Members
        /// <summary>
        /// The quotas to use with the channel.
        /// </summary>
        protected TcpChannelQuotas Quotas
        {
            get { return m_quotas; }
        }

        /// <summary>
        /// Returns the unique identifier assigned to the channel.
        /// </summary>
        protected virtual uint ChannelId
        {
            get 
            {
                if (m_channel != null)
                {
                    return m_channel.Id;
                }

                return 0;
            }
        }

        /// <summary>
        /// Creates a connection with the server.
        /// </summary>
        protected virtual IAsyncResult InternalBeginConnect(Uri url, int timeout, AsyncCallback callback, object state)
        {
            return m_channel.BeginConnect(url, timeout, callback, state);
        }
  
        /// <summary>
        /// Finishes a connect operation.
        /// </summary>
        protected virtual void InternalEndConnect(IAsyncResult result)
        {            
            m_channel.EndConnect(result);
        }
        
        /// <summary>
        /// Closes a connection with the server.
        /// </summary>
        protected virtual void InternalClose(int timeout)
        {
            m_channel.Close(timeout);
        }

        /// <summary>
        /// Sends a request to the server.
        /// </summary>
        protected virtual IAsyncResult InternalBeginSendRequest(
            IServiceRequest request, 
            int             timeout, 
            AsyncCallback   callback,
            object          state)
        {
            return m_channel.BeginSendRequest(request, timeout, callback, state);
        }
  
        /// <summary>
        /// Returns the response to a previously sent request.
        /// </summary>
        protected virtual IServiceResponse InternalEndSendRequest(IAsyncResult result)
        {
            return m_channel.EndSendRequest(result);
        }
        #endregion

        #region Private Fields
        private string m_factoryId;
        private EndpointAddress m_address;
        private Uri m_via;
        private TcpChannelQuotas m_quotas;
        private TcpClientChannel m_channel;  
        private AsyncCallback m_ResponseCallack;     
        private ServiceResult m_fault;
        #endregion
    }
}
