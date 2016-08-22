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
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.Serialization;
using System.Xml;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

using Opc.Ua.Bindings;

namespace Opc.Ua.Bindings
{
    /// <summary>
    /// Dispatches messages on the server.
    /// </summary>
	public class BinaryEncodingMessageFormatter : IDispatchMessageFormatter, IClientMessageFormatter, IOperationBehavior
	{
        #region IOperationBehavior Members
        /// <summary cref="IOperationBehavior.AddBindingParameters" />    
        public void AddBindingParameters(OperationDescription operationDescription, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
		{
		}
        
        /// <summary cref="IOperationBehavior.ApplyClientBehavior" />    
        public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
		{
            m_clientFormatter = clientOperation.Formatter;
            clientOperation.Formatter = this;	
		}
        
        /// <summary cref="IOperationBehavior.ApplyDispatchBehavior" />    
        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
		{
            m_dispatchFormatter = dispatchOperation.Formatter;
            dispatchOperation.Formatter = this;
		}
        
        /// <summary cref="IOperationBehavior.Validate" />    
        public void Validate(OperationDescription operationDescription)
		{
        }
        #endregion

        #region IDispatchFormatter Members
        /// <summary cref="IDispatchMessageFormatter.DeserializeRequest" />        
        public void DeserializeRequest(System.ServiceModel.Channels.Message message, object[] parameters)
		{
            // check if the transport channel has already deserialized the request.
            object request = null;

            if (message.Properties.TryGetValue(MessageProperties.UnencodedBody, out request))
            {
                // Utils.Trace("DeserializeRequest: TypeId={0}", ((IServiceRequest)request).BinaryEncodingId);
                parameters[0] = request;
                return;
            }

            // use the default deserialization.
            m_dispatchFormatter.DeserializeRequest(message, parameters);
		}
        
        /// <summary cref="IDispatchMessageFormatter.SerializeReply" />    
		public System.ServiceModel.Channels.Message SerializeReply(System.ServiceModel.Channels.MessageVersion messageVersion, object[] parameters, object result)
		{            
            // check if the operation invoker called the endpoint directly.
            if (result is IServiceResponse)
            {
                Message message = Message.CreateMessage(
                    messageVersion,
                    Namespaces.OpcUaWsdl + "/InvokeServiceResponse",
                    new InvokeServiceBodyWriter(null, false));
                
                message.Properties.Add(MessageProperties.UnencodedBody, result);
                
                return message;
            }

            // use the default serialization.
            return m_dispatchFormatter.SerializeReply(messageVersion, parameters, result);
		}
		#endregion
                
        #region IClientMessageFormatter Members
        /// <summary cref="IClientMessageFormatter.DeserializeReply" />
        public object DeserializeReply(System.ServiceModel.Channels.Message message, object[] parameters)
        {
            // check if the message has already been decoded.
            object response = null;

            if (message.Properties.TryGetValue(MessageProperties.UnencodedBody, out response))
            {
                return response;
            }

            return m_clientFormatter.DeserializeReply(message, parameters);
        }

        /// <summary cref="IClientMessageFormatter.SerializeRequest" />
        public System.ServiceModel.Channels.Message SerializeRequest(System.ServiceModel.Channels.MessageVersion messageVersion, object[] parameters)
        {
            Message message = m_clientFormatter.SerializeRequest(messageVersion, parameters);
            message.Properties.Add(MessageProperties.RequestBody, parameters[0]);
            return message;
        }
        #endregion
        
		#region Private Fields
        private IClientMessageFormatter m_clientFormatter;
		private IDispatchMessageFormatter m_dispatchFormatter;
        #endregion
	}
    	
    /// <summary>
    /// Bypasses XML processing when dealing with UA binary encoded messages.
    /// </summary>
    public class BinaryEncodingOperationInvoker: IOperationInvoker, IOperationBehavior
	{
		#region IOperationBehavior Members
        /// <summary cref="IOperationBehavior.AddBindingParameters" />    
        public void AddBindingParameters(OperationDescription operationDescription, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
		{
		}
        
        /// <summary cref="IOperationBehavior.ApplyClientBehavior" />    
        public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
		{
		}
        
        /// <summary cref="IOperationBehavior.ApplyDispatchBehavior" />   
        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
		{
            this.m_defaultInvoker = dispatchOperation.Invoker;
            dispatchOperation.Invoker = this;
		}
        
        /// <summary cref="IOperationBehavior.Validate" />   
        public void Validate(OperationDescription operationDescription)
		{
		}
		#endregion

		#region IOperationInvoker Members
        /// <summary cref="IOperationInvoker.AllocateInputs" />   
		public object[] AllocateInputs()
		{
			object[] inputs = this.m_defaultInvoker.AllocateInputs();
            return inputs;
		}
        
        /// <summary cref="IOperationInvoker.Invoke" />   
		public object Invoke(object instance, object[] inputs, out object[] outputs)
		{
            outputs = null;

            // process request directly if the decoding was done in the transport layer.
            IServiceRequest request = inputs[0] as IServiceRequest;
            
            if (request != null)
            {
                IServiceResponse response = ((SessionEndpoint)instance).ProcessRequest(request);
			    return response;                
            }

            return m_defaultInvoker.Invoke(instance, inputs, out outputs);
		}

        /// <summary cref="IOperationInvoker.InvokeBegin" />   
		public IAsyncResult InvokeBegin(object instance, object[] inputs, AsyncCallback callback, object state)
		{
			return this.m_defaultInvoker.InvokeBegin(instance, inputs, callback, state);
		}
        
        /// <summary cref="IOperationInvoker.InvokeEnd" />   
		public object InvokeEnd(object instance, out object[] outputs, IAsyncResult result)
		{
			return this.m_defaultInvoker.InvokeEnd(instance,out outputs,result);
		}
        
        /// <summary cref="IOperationInvoker.IsSynchronous" />   
		public bool IsSynchronous
		{
			get 
			{ 
				return this.m_defaultInvoker.IsSynchronous; 
			}
		}
		#endregion

		#region Private Fields
		private IOperationInvoker m_defaultInvoker = null;
        #endregion
	}
    
    /// <summary>
    /// Translates messages to and from binary encoded UA messages.
    /// </summary>
    public class BinaryEncodingMessageInspector : IClientMessageInspector, IEndpointBehavior
    {
        #region Constructors
        /// <summary>
        /// Initializes the formatter with default values.
        /// </summary>
        public BinaryEncodingMessageInspector(Binding binding)
        {
            BaseBinding baseBinding = binding as BaseBinding;

            if (baseBinding != null)
            {
                m_messageContext = baseBinding.MessageContext;
            }
            else
            {
                m_messageContext = ServiceMessageContext.GlobalContext;
            }
        }
        #endregion

        #region IEndpointBehavior Members
        /// <summary cref="IEndpointBehavior.AddBindingParameters" />
        public void AddBindingParameters(System.ServiceModel.Description.ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }

        /// <summary cref="IEndpointBehavior.ApplyClientBehavior" />
        public void ApplyClientBehavior(System.ServiceModel.Description.ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.MessageInspectors.Add(this);

            foreach (OperationDescription description in endpoint.Contract.Operations)
            {
                description.Behaviors.Add(new BinaryEncodingMessageFormatter());
            }
        }

        /// <summary cref="IEndpointBehavior.ApplyDispatchBehavior" />
        public void ApplyDispatchBehavior(System.ServiceModel.Description.ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
        }

        /// <summary cref="IEndpointBehavior.Validate" />
        public void Validate(System.ServiceModel.Description.ServiceEndpoint endpoint)
        {            
            m_transportSupportsEncoding = false; // TBD endpoint.Address.Uri.Scheme == Utils.UriSchemeOpcTcp2;
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// The message context to during for serialization.
        /// </summary>
        public ServiceMessageContext MessageContext
        {
            get { return m_messageContext;  }
            set { m_messageContext = value; }
        }
        #endregion

        #region IClientMessageInspector Members
        /// <summary cref="IClientMessageInspector.BeforeSendRequest" />
        public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel)
        {
            // extract request body from message object.
            IServiceMessage requestBody = (IServiceMessage)request.Properties[MessageProperties.RequestBody];

            // extract the request from the message body.
            IEncodeable encodeable = requestBody.GetRequest();
            
            byte[] encodedBody = null;

            if (!m_transportSupportsEncoding)
            {
                encodedBody = BinaryEncoder.EncodeMessage(encodeable, m_messageContext);
            }

            // create encoded message.
            Message encodedRequest = Message.CreateMessage(
                request.Version,
                Namespaces.OpcUaWsdl + "/InvokeService",
                new InvokeServiceBodyWriter(encodedBody, true));

            encodedRequest.Headers.To = request.Headers.To;
            encodedRequest.Headers.MessageId = request.Headers.MessageId;
            encodedRequest.Headers.From = request.Headers.From;
            
            if (encodedBody != null)
            {
                encodedRequest.Properties.Add(MessageProperties.EncodedBody, encodedBody);
            }

            encodedRequest.Properties.Add(MessageProperties.UnencodedBody, encodeable);

            // save information need to process reply.
            object correlationState = new object[] { request.Version, request.Headers.Action, requestBody };

            // replace the outgoing message.
            request = encodedRequest;

            return correlationState;
        }

        /// <summary cref="IClientMessageInspector.AfterReceiveReply" />
        public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
		{
            // check for fault.
            if (reply.IsFault)
            {
                return;
            }

            // parse request parameters.
            object[] parameters = correlationState as object[];
            
            if (parameters == null || parameters.Length != 3)
            {
                throw new InvalidOperationException("Cannot decode request because the IClientMessageInspector not configured properly.");
            }
            
            // extract request parameters.
            MessageVersion  messageVersion = parameters[0] as MessageVersion;
            string          action         = parameters[1] as string;
            IServiceMessage request        = parameters[2] as IServiceMessage;
  
            object encodeable = null;

            if (!reply.Properties.TryGetValue(MessageProperties.UnencodedBody, out encodeable))
            {
                // extract binary encoded response from body.
                XmlDictionaryReader reader = reply.GetReaderAtBodyContents();
                reader.MoveToStartElement("InvokeServiceResponse", Namespaces.OpcUaXsd);                
                byte[] response  = reader.ReadElementContentAsBase64();
               
                // decode body.
                try
                {
                    encodeable = BinaryDecoder.DecodeMessage(response, null, m_messageContext);
                }
                catch (Exception e)
                {
                    ServiceResult error = ServiceResult.Create(
                        e, 
                        StatusCodes.BadDecodingError, 
                        "Could not decoding incoming response message.");

                    ServiceFault fault = new ServiceFault();

                    fault.ResponseHeader.RequestHandle = request.GetRequest().RequestHeader.RequestHandle;
                    fault.ResponseHeader.Timestamp     = DateTime.UtcNow;
                    fault.ResponseHeader.ServiceResult = error.Code;

                    StringTable stringTable = new StringTable();

                    fault.ResponseHeader.ServiceDiagnostics = new DiagnosticInfo(
                        error, 
                        DiagnosticsMasks.NoInnerStatus, 
                        true, 
                        stringTable);

                    fault.ResponseHeader.StringTable = stringTable.ToArray();

                    encodeable = fault;
                }
            }
            
            object unencodedBody = request.CreateResponse((IServiceResponse)encodeable);

            // create the unencoded reply message.
            Message unencodedReply = Message.CreateMessage(
                messageVersion,
                action + "Response",
                unencodedBody);

            unencodedReply.Headers.MessageId = reply.Headers.MessageId;
            unencodedReply.Headers.RelatesTo = reply.Headers.RelatesTo;

            unencodedReply.Properties.Add(MessageProperties.UnencodedBody, unencodedBody);

            // replace the incoming message.
            reply = unencodedReply;
		}
        #endregion

        #region Private Fields
        private bool m_transportSupportsEncoding;
        private ServiceMessageContext m_messageContext;
        #endregion
    }
}
