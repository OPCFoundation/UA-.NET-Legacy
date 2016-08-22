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
using System.ServiceModel.Dispatcher;
using System.Net.Sockets;
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;
using System.Xml;

using Opc.Ua.Bindings;

namespace Opc.Ua.Bindings
{        
    /// <summary>
    /// IReplyChannel implementation for the OPC UA Native Stack
    /// </summary>
    class UaTcpReplyChannel : ChannelBase, IReplySessionChannel, IInputSession
    {
        #region Constructors
        /// <summary>
        /// Initializes the channel with a channel manager. 
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal UaTcpReplyChannel(
            ChannelManagerBase manager, 
            string             listenerId,
            EndpointAddress    address, 
            TcpServerChannel   channel,
            TcpChannelQuotas   quotas) 
        : 
            base(manager)
        {    
            m_listenerId = listenerId;
            m_address    = address;
            m_channel    = channel;
            m_quotas     = quotas;

            m_requestQueue = new Queue<RequestContext>();
            m_operationQueue = new Queue<TcpAsyncOperation<RequestContext>>();

            m_RequestReceivedCallback = new TcpChannelRequestEventHandler(OnRequestReceived);

            // register for notifications.
            m_channel.SetRequestReceivedCallback(m_RequestReceivedCallback);
        }
        #endregion

        #region RequestContext Class
        /// <summary>
        /// The request context.
        /// </summary>
        private class RequestContext : System.ServiceModel.Channels.RequestContext
        {
            #region Constructor
            /// <summary>
            /// Saves the request message.
            /// </summary>
            public RequestContext(TcpServerChannel channel, uint requestId, Message message, IServiceRequest request)
            {
                m_channel        = channel;
                m_requestId      = requestId;
                m_requestMessage = message;
            }
            #endregion

            #region Overridden Members
            /// <summary cref="System.ServiceModel.Channels.RequestContext.RequestMessage" />
            public override Message RequestMessage
            {
                get 
                {               
                    // Utils.Trace("Request Fetched: ChannelId={0}, RequestId={1}", this.m_channel.Id, m_requestId);  
                    return m_requestMessage; 
                }
            }
            
            /// <summary cref="System.ServiceModel.Channels.RequestContext.Reply(Message)" />
            public override void Reply(Message message)
            {
                IAsyncResult result = BeginReply(message, TimeSpan.MaxValue, null, null);
                EndReply(result);
            }
            
            /// <summary cref="System.ServiceModel.Channels.RequestContext.Reply(Message, TimeSpan)" />
            public override void Reply(Message message, TimeSpan timeout)
            {
                IAsyncResult result = BeginReply(message, timeout, null, null);
                EndReply(result);
            }
            
            /// <summary cref="System.ServiceModel.Channels.RequestContext.BeginReply(Message, AsyncCallback, object)" />
            public override IAsyncResult BeginReply(Message message, AsyncCallback callback, object state)
            {
                return BeginReply(message, TimeSpan.MaxValue, callback, state);
            }
            
            /// <summary cref="System.ServiceModel.Channels.RequestContext.BeginReply(Message, TimeSpan, AsyncCallback, object)" />
            public override IAsyncResult BeginReply(Message message, TimeSpan timeout, AsyncCallback callback, object state)
            {
                TcpAsyncOperation<uint> operation = new TcpAsyncOperation<uint>(Utils.GetTimeout(timeout), callback, state);
                
                IServiceResponse response = null;

                lock (m_lock)
                {
                    if (m_channel != null)
                    {         
                        response = (IServiceResponse)message.Properties[MessageProperties.UnencodedBody];                        
                        // Utils.Trace("Reply Sent: ChannelId={0}, RequestId={1}", this.m_channel.Id, m_requestId); 
                        m_channel.SendResponse(m_requestId, response);
                        m_channel = null;            
                    }
                }
                                   
                operation.Complete(StatusCodes.Good);
                return operation;
            }
            
            /// <summary cref="System.ServiceModel.Channels.RequestContext.EndReply(IAsyncResult)" />
            public override void EndReply(IAsyncResult result)
            {
                try
                {
                    TcpAsyncOperation<uint> operation = (TcpAsyncOperation<uint>)result;
                    operation.End(Int32.MaxValue);
                }
                catch (Exception e)
                {
                    Utils.Trace(e, "Could not send reply to request.");
                }
            }
            
            /// <summary cref="System.ServiceModel.Channels.RequestContext.Close()" />
            public override void Close()
            {
                Close(TimeSpan.MaxValue);
            }
            
            /// <summary cref="System.ServiceModel.Channels.RequestContext.Close(TimeSpan)" />
            public override void Close(TimeSpan timeout)
            {        
                lock (m_lock)
                {
                    if (m_channel != null)
                    {
                        ServiceFault fault = new ServiceFault();

                        fault.ResponseHeader.Timestamp     = DateTime.UtcNow;
                        fault.ResponseHeader.ServiceResult = StatusCodes.BadInternalError;
                                   
                        // Utils.Trace("Reply Faulted: ChannelId={0}, RequestId={1}", this.m_channel.Id, m_requestId); 
                        m_channel.SendResponse(m_requestId, fault);
                        m_channel = null;                
                    }
                }
            }
            
            /// <summary cref="System.ServiceModel.Channels.RequestContext.Abort()" />
            public override void Abort()
            {
                lock (m_lock)
                {
                    if (m_channel != null)
                    {
                        m_channel = null;                
                    }
                }
            }
            #endregion

            #region Private Fields
            private object m_lock = new object();
            private TcpServerChannel m_channel;
            private uint m_requestId;
            private Message m_requestMessage;
            #endregion
        }
        #endregion

        #region Overridden Methods
        #region Open
        /// <summary cref="CommunicationObject.OnOpen" />
        protected override void OnOpen(TimeSpan timeout)
        {   
            // nothing to do.
        }
        
        /// <summary cref="CommunicationObject.OnBeginOpen" />
        protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
        {
            TcpAsyncOperation<int> operation = new TcpAsyncOperation<int>(Utils.GetTimeout(timeout), callback, state);
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
                throw ServiceResultException.Create(StatusCodes.BadInternalError, e, "Could not open UA TCP reply channel.");
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
            TcpAsyncOperation<int> operation = (TcpAsyncOperation<int>)result;
            
            try
            {
                operation.End(Int32.MaxValue);
            }
            catch (Exception e)
            {
                m_fault = ServiceResult.Create(e, StatusCodes.BadInternalError, "Could not close UA TCP server channel.");
                Utils.Trace(m_fault.ToLongString());
            }
        }   
    
        /// <summary cref="CommunicationObject.OnAbort" />
        protected override void OnAbort()
        {
            try
            {
                lock (m_lock)
                {
                    while (m_requestQueue.Count > 0)
                    {
                        RequestContext context = m_requestQueue.Dequeue();
                        // Utils.Trace("Request Aborted: ChannelId={0}, RequestId={1}", this.m_channel.Id, context.RequestId); 
                        context.Abort();
                    }
                    
                    while (m_operationQueue.Count > 0)
                    {
                        TcpAsyncOperation<RequestContext> receiveOperation = m_operationQueue.Dequeue();
                        receiveOperation.Complete(null);
                    }
                }
            }
            catch (Exception)
            {
                // ignore exceptions on abort.
            }
        } 

        /// <summary>
        /// Cancels all outstanding requests.
        /// </summary>
        private void InternalClose(object state)
        {
            TcpAsyncOperation<int> operation = (TcpAsyncOperation<int>)state;

            try
            {
                lock (m_lock)
                {
                    while (m_requestQueue.Count > 0)
                    {
                        RequestContext context = m_requestQueue.Dequeue();;
                        // Utils.Trace("Request Aborted: ChannelId={0}, RequestId={1}", this.m_channel.Id, context.RequestId); 
                        context.Abort();
                    }
                    
                    while (m_operationQueue.Count > 0)
                    {
                        TcpAsyncOperation<RequestContext> receiveOperation = m_operationQueue.Dequeue();
                        receiveOperation.Complete(null);
                    }
                }

                operation.Complete(0);
            }
            catch (Exception e)
            {
                operation.Fault(e, StatusCodes.BadInternalError, "Could not close a UA TCP reply channel.");
            }
        }
        #endregion
        #endregion

        #region ChannelBase Members
        /// <summary cref="ChannelBase.GetProperty{T}" />
        public override T GetProperty<T>()
        {
            if (typeof(T) == typeof(TcpChannelQuotas))
            {
                return (T)(object)m_quotas;
            }
                        
            if (typeof(T) == typeof(IUaTcpSecureChannel))
            {
                return (T)(object)this.m_channel;
            }         

            return base.GetProperty<T>();
        }        
        #endregion

        #region IReplySessionChannel Members
        /// <summary cref="IReplyChannel.LocalAddress" />
        public EndpointAddress LocalAddress
        {
            get { return m_address; }
        }

        #region ReceiveRequest
        /// <summary cref="IReplyChannel.ReceiveRequest()" />
        public System.ServiceModel.Channels.RequestContext ReceiveRequest()
        {
            return ReceiveRequest(TimeSpan.MaxValue);
        }

        /// <summary cref="IReplyChannel.ReceiveRequest(TimeSpan)" />
        public System.ServiceModel.Channels.RequestContext ReceiveRequest(TimeSpan timeout)
        {
            System.ServiceModel.Channels.RequestContext context = null;

            if (!TryReceiveRequest(timeout, out context))
            {
                throw new TimeoutException();
            }

            return context;
        }
        
        /// <summary cref="IReplyChannel.BeginReceiveRequest(AsyncCallback, object)" />
        public IAsyncResult BeginReceiveRequest(AsyncCallback callback, object state)
        {
            return BeginTryReceiveRequest(TimeSpan.MaxValue, null, null);
        }
        
        /// <summary cref="IReplyChannel.BeginReceiveRequest(TimeSpan, AsyncCallback, object)" />
        public IAsyncResult BeginReceiveRequest(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return BeginTryReceiveRequest(timeout, callback, state);
        }        
        
        /// <summary cref="IReplyChannel.EndReceiveRequest" />
        public System.ServiceModel.Channels.RequestContext EndReceiveRequest(IAsyncResult result)
        {
            System.ServiceModel.Channels.RequestContext context = null;

            if (!EndTryReceiveRequest(result, out context))
            {
                throw new TimeoutException();
            }

            return context;
        }
        
        /// <summary cref="IReplyChannel.TryReceiveRequest" />
        public bool TryReceiveRequest(TimeSpan timeout, out System.ServiceModel.Channels.RequestContext context)
        {            
            ThrowIfDisposedOrNotOpen();
            IAsyncResult result = BeginTryReceiveRequest(timeout, null, null);
            return EndTryReceiveRequest(result, out context);
        }
        
        /// <summary cref="IReplyChannel.BeginTryReceiveRequest" />
        public IAsyncResult BeginTryReceiveRequest(TimeSpan timeout, AsyncCallback callback, object state)
        {
            ThrowIfDisposedOrNotOpen();
         
            try
            {
                TcpAsyncOperation<RequestContext> operation = new TcpAsyncOperation<RequestContext>(Utils.GetTimeout(timeout), callback, state);

                lock (m_lock)
                {
                    if (m_requestQueue.Count > 0)
                    {
                        RequestContext request = m_requestQueue.Dequeue();;
                        // Utils.Trace("Request Accepted (S): ChannelId={0}, RequestId={1}", this.m_channel.Id, request.RequestId); 
                        operation.Complete(request);
                        return operation;
                    }

                    m_operationQueue.Enqueue(operation);
                }

                return operation;
            }
            catch (Exception e)
            {
                Utils.Trace(e, "BeginTryReceiveRequest Error");
                throw;
            }
        }
        
        /// <summary cref="IReplyChannel.EndTryReceiveRequest" />
        public bool EndTryReceiveRequest(IAsyncResult result, out System.ServiceModel.Channels.RequestContext context)
        {            
            context = null;
            TcpAsyncOperation<RequestContext> operation = (TcpAsyncOperation<RequestContext>)result;

            try
            {
                context = operation.End(Int32.MaxValue);
                return true;
            }
            catch (TimeoutException)
            {
                return false;
            }
            catch (Exception e)
            {
                m_fault = ServiceResult.Create(e, StatusCodes.BadInternalError, "Could not receive request from a UA TCP channel.");
                Utils.Trace(m_fault.ToLongString());
                return false;
            }
        }
        #endregion
        
        #region WaitForRequest
        /// <summary cref="IReplyChannel.WaitForRequest" />
        public bool WaitForRequest(TimeSpan timeout)
        {
            throw new NotImplementedException();
        }
        
        /// <summary cref="IReplyChannel.BeginWaitForRequest" />
        public IAsyncResult BeginWaitForRequest(TimeSpan timeout, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }
        
        /// <summary cref="IReplyChannel.EndWaitForRequest" />
        public bool EndWaitForRequest(IAsyncResult result)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        
        #region ISessionChannel<IInputSession> Members
        /// <summary cref="ISessionChannel{T}.Session" />
        public IInputSession Session
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
                return Utils.Format("{0}-{1}", m_listenerId, m_channel.Id);
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Handles requests arriving from a channel.
        /// </summary>
        private void OnRequestReceived(TcpServerChannel channel, uint requestId, IServiceRequest request)
        {
            RequestContext context = null;

            lock (m_lock)
            {
                // create message.
                Message message = Message.CreateMessage(
                    MessageVersion.Soap12WSAddressing10,
                    Namespaces.OpcUaWsdl + "/InvokeService",
                    new InvokeServiceBodyWriter(null, true));
                
                string messageId = Utils.Format("urn:uuid:{0}", Guid.NewGuid());

                // update headers.
                message.Headers.To = m_address.Uri;
                message.Headers.MessageId = new UniqueId(messageId);

                // add the raw object to the message properties.
                message.Properties.Add(MessageProperties.UnencodedBody, request);

                // create request.
                context = new RequestContext(channel, requestId, message, request);
                // Utils.Trace("Request Received: ChannelId={0}, RequestId={1}, RequestType={2}", this.m_channel.Id, requestId, request.BinaryEncodingId); 
            }
            
            // notify any waiting threads.
            bool received = false;

            do
            {
                TcpAsyncOperation<RequestContext> operation = null;
                
                lock (m_lock)
                {
                    if (m_operationQueue.Count == 0)
                    {
                        m_requestQueue.Enqueue(context);
                        break;
                    }
                    
                    // Utils.Trace("Request Accepted (A): ChannelId={0}, RequestId={1}", this.m_channel.Id, requestId); 
                    operation = m_operationQueue.Dequeue();
                }     
           
                try
                {
                    received = operation.Complete(true, context);
                }
                catch (Exception e)
                {
                    Utils.Trace(e, "Error receiving request");
                    received = false;
                }
            }
            while (!received);
        }
        #endregion
        
        #region Private Fields
        private object m_lock = new object();
        private string m_listenerId;
        private EndpointAddress m_address;
        private TcpServerChannel m_channel;
        private TcpChannelQuotas m_quotas;
        private TcpChannelRequestEventHandler m_RequestReceivedCallback;
        private Queue<RequestContext> m_requestQueue;
        private Queue<TcpAsyncOperation<RequestContext>> m_operationQueue;
        private ServiceResult m_fault;
        #endregion
    }
}
