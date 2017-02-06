/* ========================================================================
 * Copyright (c) 2005-2017 The OPC Foundation, Inc. All rights reserved.
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
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Threading;
using System.Security.Cryptography.X509Certificates;
using System.Globalization;
using System.IO;
using System.ServiceModel.Web;

using Opc.Ua;

namespace Opc.Ua.Sample
{
    /// <summary>
    /// This object implements the UA web service contract. This implementation is configured to use a single instance of this object for all clients.
    /// </summary>
    [ServiceBehavior(Namespace = Namespaces.OpcUaWsdl, InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]  
    class MyService : Opc.Ua.ISessionEndpoint, Opc.Ua.IDiscoveryEndpoint, IDisposable
    {
        Stream StringToStream(string result)
        {
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/xml";
            return new MemoryStream(Encoding.UTF8.GetBytes(result));
        }
        public Stream GetSilverlightPolicy()
        {
            string result = @"<?xml version=""1.0"" encoding=""utf-8""?>
<access-policy>
    <cross-domain-access>
        <policy>
            <allow-from http-request-headers=""*"">
                <domain uri=""*""/>
            </allow-from>
            <grant-to>
                <resource path=""/"" include-subpaths=""true""/>
            </grant-to>
        </policy>
    </cross-domain-access>
</access-policy>";
            return StringToStream(result);
        }
        public Stream GetFlashPolicy()
        {
            string result = @"<cross-domain-policy>
  <allow-http-request-headers-from domain=""*"" headers=""*""/>
</cross-domain-policy>";
            return StringToStream(result);
        }

        /// <summary>
        /// All application instances must have a globally unique id. This should be constructed when the application is installed.
        /// </summary>
        public const string ApplicationUri = "http://localhost/MyServer";

        /// <summary>
        /// Initializes the service before it is opened.
        /// </summary>
        public MyService()
        {
            // the node manager provides access to the server's address space.
            m_nodeManager = new NodeManager();
            m_nodeManager.Create();

            // the server object stores the current server status information.
            m_serverObject = new ServerObject(ApplicationUri, m_nodeManager);
        }
        
        #region IDisposable Members
        /// <summary>
        /// Must ensure the server shuts down cleanly.
        /// </summary>
        public void Dispose()
        {
            // TBD - release resources.
        }
        #endregion

        #region Private Fields
        private object m_lock = new object();
        private ApplicationDescription m_application;
        private ListOfEndpointDescription m_endpoints;
        private X509Certificate2 m_serverCertificate;
        private Dictionary<string, Session> m_sessions = new Dictionary<string, Session>();
        private Dictionary<uint, Subscription> m_subscriptions = new Dictionary<uint, Subscription>();
        private LinkedList<QueuedMessage> m_messages = new LinkedList<QueuedMessage>();
        private LinkedList<QueuedRequest> m_requests = new LinkedList<QueuedRequest>();
        private NodeManager m_nodeManager;
        private ServerObject m_serverObject;
        #endregion

        #region QueuedMessage Class
        /// <summary>
        /// Stores a notification message that is ready to be sent to the client.
        /// </summary>
        private class QueuedMessage
        {
            public Session Session;
            public Subscription Subscription;
            public NotificationMessage Message;
        }
        #endregion

        #region QueuedRequest Class
        /// <summary>
        /// Stores an publish request from the client.
        /// </summary>
        private class QueuedRequest
        {
            public Session Session;
            public DateTime Timeout;
            public ManualResetEvent Signal;
            public uint SubscriptionId;
            public NotificationMessage Message;
        }
        #endregion

        #region Helper Functions
        /// <summary>
        /// Creates a response header.
        /// </summary>
        private ResponseHeader CreateResponseHeader(RequestHeader requestHeader)
        {
            ResponseHeader responseHeader = new ResponseHeader();

            // echo the handle provided by the client.
            responseHeader.RequestHandle = requestHeader.RequestHandle;

            // these fields are used when a fault is produced.
            responseHeader.ServiceResult = StatusCode.Good;
            responseHeader.ServiceDiagnostics = new DiagnosticInfo();

            // stores the diagnostic strings returned with operation level results.
            responseHeader.StringTable = new ListOfString();
            responseHeader.Timestamp = DateTime.UtcNow;

            // always null - reserved for future use.
            responseHeader.AdditionalHeader = new ExtensionObject();

            return responseHeader;
        }

        /// <summary>
        /// Caches application description and list of available endpoints.
        /// </summary>
        private void InitializeApplicationDescription()
        {
            // this method is caches the information the first time a client connects.
            if (m_application == null)
            {
                // the serviceCertificate element in the app.config file controls what certificate is loaded.
                m_serverCertificate = OperationContext.Current.Host.Credentials.ServiceCertificate.Certificate;

                // the URL may be the discovery or the session endpoint. need to store the session endpoint.
                string endpointUrl = OperationContext.Current.Channel.LocalAddress.ToString();
                
                if (endpointUrl.EndsWith("/discovery", StringComparison.InvariantCulture))
                {
                    endpointUrl = endpointUrl.Substring(0, endpointUrl.Length - "/discovery".Length);
                }

                // The EndpointDescription stores the information specified in the ISessionEndpoint binding.
                // This structure is used in the UA discovery services and allows client applications to 
                // discover what security settings are used by the server. 

                EndpointDescription endpoint = new EndpointDescription();

                endpoint.EndpointUrl = endpointUrl;
                endpoint.SecurityMode = MessageSecurityMode.SignAndEncrypt_3;
                endpoint.SecurityPolicyUri = SecurityPolicies.Basic128Rsa15;
                endpoint.ServerCertificate = m_serverCertificate.GetRawCertData();
                endpoint.TransportProfileUri = Profiles.WsHttpXmlTransport;

                endpoint.Server = new ApplicationDescription();
                endpoint.Server.ApplicationUri = ApplicationUri;
                endpoint.Server.ApplicationType = ApplicationType.Server_0;
                endpoint.Server.DiscoveryUrls = new ListOfString();
                endpoint.Server.DiscoveryUrls.Add(endpointUrl + "/discovery");

                // no authorization supported at this time.
                UserTokenPolicy userTokenPolicy = new UserTokenPolicy();
                userTokenPolicy.TokenType = UserTokenType.Anonymous_0;
                endpoint.UserIdentityTokens = new ListOfUserTokenPolicy();
                endpoint.UserIdentityTokens.Add(userTokenPolicy);

                m_application = endpoint.Server;

                // If the server supports multiple bindings it will need multiple EndpointDescriptions. These
                // structures can be constructed automatically from the bindings in the OperationContext object
                // This example simply hard codes the settings so a mismatch between the app.config could cause
                // problems.
                
                m_endpoints = new ListOfEndpointDescription();
                m_endpoints.Add(endpoint);
            }
        }

        /// <summary>
        /// Returns the session object if it is valid.
        /// </summary>
        private Session VerifySession(RequestHeader requestHeader, bool activating)
        {
            lock (m_lock)
            {
                // uses the authorization token to lookup the session associated with the incoming request.
                Session session = null;

                if (requestHeader.AuthenticationToken != null && requestHeader.AuthenticationToken.Identifier != null)
                {
                    m_sessions.TryGetValue(requestHeader.AuthenticationToken.Identifier, out session);
                }

                // session closed or it never existed.
                if (session == null)
                {
                    throw new StatusCodeException(StatusCodes.BadSessionIdInvalid, "Session not longer exists");
                }

                // must make sure the the current secure channel is allowed to access the session.
                // this also updates the session keep alive counter to ensure it is not freed.
                session.VerifySecureChannel(activating);

                return session;
            }
        }

        /// <summary>
        /// Creates a UA fault message from an exception.
        /// </summary>
        protected virtual Exception CreateSoapFault(RequestHeader requestHeader, Exception e)
        {
            ServiceFault fault = new ServiceFault();
            fault.ResponseHeader = CreateResponseHeader(requestHeader);

            // specify a code.
            StatusCodeException sce = e as StatusCodeException;

            if (sce != null)
            {
                fault.ResponseHeader.ServiceResult = new StatusCode(sce.Code);
            }
            else
            {
                fault.ResponseHeader.ServiceResult = new StatusCode(StatusCodes.BadUnexpectedError);
            }

            // return the message for the exception (add it to the string table first and store the index in the diagnostics).
            if ((requestHeader.ReturnDiagnostics & (uint)DiagnosticsMasks.ServiceLocalizedText) != 0)
            {
                fault.ResponseHeader.StringTable.Add(e.Message);
                fault.ResponseHeader.ServiceDiagnostics.LocalizedText = fault.ResponseHeader.StringTable.Count-1;
            }

            // return the stack trace for the exception.
            // this is really handy for debugging but is a security risk and never should be done in a production system.
            if ((requestHeader.ReturnDiagnostics & (uint)DiagnosticsMasks.ServiceAdditionalInfo) != 0)
            {
                fault.ResponseHeader.ServiceDiagnostics.AdditionalInfo = e.StackTrace;
            }
                
            // construct the fault code and fault reason.
            FaultCode code = new FaultCode(StatusCodes.GetBrowseName(fault.ResponseHeader.ServiceResult.Code), Namespaces.OpcUa);
            FaultReason reason = new FaultReason(e.Message);;

            // return the fault.
            return new FaultException<ServiceFault>(fault, reason, code);
        }
        
        #endregion

        #region ISessionEndpoint Members
        public InvokeServiceResponseMessage InvokeService(InvokeServiceMessage request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a session with the server that is independent of the network connection.
        /// </summary>
        public CreateSessionResponseMessage CreateSession(CreateSessionMessage request)
        {
            try
            {
                lock (m_lock)
                {
                    InitializeApplicationDescription();

                    // create a new session object.
                    Session session = new Session();

                    NodeId sessionId;
                    NodeId authenticationToken;
                    byte[] serverNonce;
                    double revisedSessionTimeout;

                    EndpointDescription endpoint = m_endpoints[0];

                    // the session object validates the incoming parameters and produces faults on error.
                    session.Create(
                        endpoint,
                        request.ClientDescription,
                        request.ClientCertificate,
                        request.SessionName,
                        request.RequestedSessionTimeout,
                        out sessionId,
                        out authenticationToken,
                        out serverNonce,
                        out revisedSessionTimeout);

                    // save the session.
                    m_sessions.Add(authenticationToken.Identifier, session);

                    // the server application must authenticate itself to the client by providing a signature.
                    // this process is redundant for applications using WS-SecureConversation with mutual certificate 
                    // exchange, however, the UA specification requires this step to ensure that secure channel 
                    // technologies such as machine-to-machine VPNs can be used instead without sacrificing the 
                    // ability to identify the remote applications.

                    byte[] dataToSign = SecurityUtils.Append(request.ClientCertificate, request.ClientNonce);

                    SignatureData serverSignature = SecurityUtils.Sign(
                        m_serverCertificate,
                        endpoint.SecurityPolicyUri,
                        dataToSign);

                    // contruct the response.
                    CreateSessionResponseMessage response = new CreateSessionResponseMessage();

                    response.ResponseHeader = CreateResponseHeader(request.RequestHeader);
                    response.SessionId = sessionId;
                    response.AuthenticationToken = authenticationToken;
                    response.MaxRequestMessageSize = request.MaxResponseMessageSize;
                    response.RevisedSessionTimeout = revisedSessionTimeout;
                    response.ServerNonce = serverNonce;
                    response.ServerCertificate = m_serverCertificate.GetRawCertData();
                    response.ServerSignature = serverSignature;
                    response.ServerEndpoints = m_endpoints;
                    response.ServerSoftwareCertificates = new ListOfSignedSoftwareCertificate();

                    return response;
                }
            }
            catch (Exception e)
            {
                throw CreateSoapFault(request.RequestHeader, e);
            }
        }

        /// <summary>
        /// Activates a previously created session or transfers the session to a new secure channel.
        /// </summary>
        public ActivateSessionResponseMessage ActivateSession(ActivateSessionMessage request)
        {
            try
            {
                lock (m_lock)
                {
                    // verify that the session is still valid.
                    Session session = VerifySession(request.RequestHeader, true);

                    // validate the client and return a new nonce that can be used for subsequent calls to activate.
                    byte[] serverNonce = session.Activate(
                        request.ClientSignature, 
                        request.LocaleIds, 
                        request.UserIdentityToken, 
                        request.UserTokenSignature);

                    // construct the response.
                    ActivateSessionResponseMessage response = new ActivateSessionResponseMessage();

                    response.ResponseHeader = CreateResponseHeader(request.RequestHeader);
                    response.ServerNonce = serverNonce;
                    response.Results = new ListOfStatusCode();
                    response.DiagnosticInfos = new ListOfDiagnosticInfo();

                    return response;
                }
            }
            catch (Exception e)
            {
                throw CreateSoapFault(request.RequestHeader, e);
            }
        }

        public CloseSessionResponseMessage CloseSession(CloseSessionMessage request)
        {
            throw new NotImplementedException();
        }

        public CancelResponseMessage Cancel(CancelMessage request)
        {
            throw new NotImplementedException();
        }

        public AddNodesResponseMessage AddNodes(AddNodesMessage request)
        {
            throw new NotImplementedException();
        }

        public AddReferencesResponseMessage AddReferences(AddReferencesMessage request)
        {
            throw new NotImplementedException();
        }

        public DeleteNodesResponseMessage DeleteNodes(DeleteNodesMessage request)
        {
            throw new NotImplementedException();
        }

        public DeleteReferencesResponseMessage DeleteReferences(DeleteReferencesMessage request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the references that meet the filter criteria for one or more nodes.
        /// </summary>
        public BrowseResponseMessage Browse(BrowseMessage request)
        {
            try
            {
                lock (m_lock)
                {
                    // verify the session.
                    VerifySession(request.RequestHeader, false);

                    // process each node being browsed.
                    ListOfBrowseResult results = new ListOfBrowseResult();
                    ListOfDiagnosticInfo diagnosticInfos = new ListOfDiagnosticInfo();

                    for (int ii = 0; ii < request.NodesToBrowse.Count; ii++)
                    {
                        BrowseResult result = new BrowseResult();
                        DiagnosticInfo diagnosticInfo = new DiagnosticInfo();

                        m_nodeManager.Browse(
                            request.NodesToBrowse[ii],
                            result,
                            diagnosticInfo);

                        results.Add(result);
                        diagnosticInfos.Add(diagnosticInfo);
                    }

                    // return the response.
                    BrowseResponseMessage response = new BrowseResponseMessage();

                    response.ResponseHeader = CreateResponseHeader(request.RequestHeader);
                    response.Results = results;
                    response.DiagnosticInfos = diagnosticInfos;

                    return response;
                }
            }
            catch (Exception e)
            {
                throw CreateSoapFault(request.RequestHeader, e);
            }
        }

        public BrowseNextResponseMessage BrowseNext(BrowseNextMessage request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the target nodes found by following a browse path from a starting node.
        /// </summary>
        public TranslateBrowsePathsToNodeIdsResponseMessage TranslateBrowsePathsToNodeIds(TranslateBrowsePathsToNodeIdsMessage request)
        {
            try
            {
                lock (m_lock)
                {
                    // verify that the session is still valid. 
                    VerifySession(request.RequestHeader, false);

                    // process each path being followed.
                    ListOfBrowsePathResult results = new ListOfBrowsePathResult();
                    ListOfDiagnosticInfo diagnosticInfos = new ListOfDiagnosticInfo();

                    for (int ii = 0; ii < request.BrowsePaths.Count; ii++)
                    {
                        BrowsePathResult result = new BrowsePathResult();
                        DiagnosticInfo diagnosticInfo = new DiagnosticInfo();

                        m_nodeManager.TranslateBrowsePath(
                            request.BrowsePaths[ii],
                            result,
                            diagnosticInfo);

                        results.Add(result);
                        diagnosticInfos.Add(diagnosticInfo);
                    }

                    // return the response.
                    TranslateBrowsePathsToNodeIdsResponseMessage response = new TranslateBrowsePathsToNodeIdsResponseMessage();

                    response.ResponseHeader = CreateResponseHeader(request.RequestHeader);
                    response.Results = results;
                    response.DiagnosticInfos = diagnosticInfos;

                    return response;
                }
            }
            catch (Exception e)
            {
                throw CreateSoapFault(request.RequestHeader, e);
            }
        }

        public RegisterNodesResponseMessage RegisterNodes(RegisterNodesMessage request)
        {
            throw new NotImplementedException();
        }

        public UnregisterNodesResponseMessage UnregisterNodes(UnregisterNodesMessage request)
        {
            throw new NotImplementedException();
        }

        public QueryFirstResponseMessage QueryFirst(QueryFirstMessage request)
        {
            throw new NotImplementedException();
        }

        public QueryNextResponseMessage QueryNext(QueryNextMessage request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads the values for one or more attributes.
        /// </summary>
        public ReadResponseMessage Read(ReadMessage request)
        {
            try
            {
                lock (m_lock)
                {
                    // verify that the session is still valid. 
                    VerifySession(request.RequestHeader, false);

                    // process each attribute.
                    ListOfDataValue results = new ListOfDataValue();
                    ListOfDiagnosticInfo diagnosticInfos = new ListOfDiagnosticInfo();

                    for (int ii = 0; ii < request.NodesToRead.Count; ii++)
                    {
                        DataValue result = new DataValue();
                        DiagnosticInfo diagnosticInfo = new DiagnosticInfo();

                        m_nodeManager.Read(
                            request.NodesToRead[ii],
                            result,
                            diagnosticInfo);

                        results.Add(result);
                        diagnosticInfos.Add(diagnosticInfo);
                    }

                    // return the response.
                    ReadResponseMessage response = new ReadResponseMessage();

                    response.ResponseHeader = CreateResponseHeader(request.RequestHeader);
                    response.Results = results;
                    response.DiagnosticInfos = diagnosticInfos;

                    return response;
                }
            }
            catch (Exception e)
            {
                throw CreateSoapFault(request.RequestHeader, e);
            }
        }

        public HistoryReadResponseMessage HistoryRead(HistoryReadMessage request)
        {
            throw new NotImplementedException();
        }

        public WriteResponseMessage Write(WriteMessage request)
        {
            throw new NotImplementedException();
        }

        public HistoryUpdateResponseMessage HistoryUpdate(HistoryUpdateMessage request)
        {
            throw new NotImplementedException();
        }

        public CallResponseMessage Call(CallMessage request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Specifies one or more nodes to monitor for data changes or events. 
        /// </summary>
        public CreateMonitoredItemsResponseMessage CreateMonitoredItems(CreateMonitoredItemsMessage request)
        {
            try
            {
                lock (m_lock)
                {
                    // verify session.
                    VerifySession(request.RequestHeader, false);

                    // look up subscription.
                    Subscription subscription = null;

                    if (!m_subscriptions.TryGetValue(request.SubscriptionId, out subscription))
                    {
                        throw new StatusCodeException(StatusCodes.BadSubscriptionIdInvalid, "Could not find subscription");
                    }

                    // process each item.
                    ListOfMonitoredItemCreateResult results = new ListOfMonitoredItemCreateResult();
                    ListOfDiagnosticInfo diagnosticInfos = new ListOfDiagnosticInfo();

                    for (int ii = 0; ii < request.ItemsToCreate.Count; ii++)
                    {
                        MonitoredItemCreateResult result = new MonitoredItemCreateResult();
                        DiagnosticInfo diagnosticInfo = new DiagnosticInfo();

                        subscription.CreateMonitoredItem(
                            request.TimestampsToReturn,
                            request.ItemsToCreate[ii],
                            result,
                            diagnosticInfo);

                        results.Add(result);
                        diagnosticInfos.Add(diagnosticInfo);
                    }
                    
                    // return the response.
                    CreateMonitoredItemsResponseMessage response = new CreateMonitoredItemsResponseMessage();

                    response.ResponseHeader = CreateResponseHeader(request.RequestHeader);
                    response.Results = results;
                    response.DiagnosticInfos = diagnosticInfos;

                    return response;
                }
            }
            catch (Exception e)
            {
                throw CreateSoapFault(request.RequestHeader, e);
            }
        }

        public ModifyMonitoredItemsResponseMessage ModifyMonitoredItems(ModifyMonitoredItemsMessage request)
        {
            throw new NotImplementedException();
        }

        public SetMonitoringModeResponseMessage SetMonitoringMode(SetMonitoringModeMessage request)
        {
            throw new NotImplementedException();
        }

        public SetTriggeringResponseMessage SetTriggering(SetTriggeringMessage request)
        {
            throw new NotImplementedException();
        }

        public DeleteMonitoredItemsResponseMessage DeleteMonitoredItems(DeleteMonitoredItemsMessage request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a subscription that can be used to recieve data change or event notifications. 
        /// </summary>
        public CreateSubscriptionResponseMessage CreateSubscription(CreateSubscriptionMessage request)
        {
            try
            {
                lock (m_lock)
                {
                    // verify the session.
                    Session session = VerifySession(request.RequestHeader, false);

                    // create a new subscription.
                    Subscription subscription = new Subscription();

                    uint subscriptionId;
                    double publishingInterval;
                    uint lifetimeCount;
                    uint keepAliveCount;

                    // the subscription validates the parameters and throws exceptions on error.
                    subscription.Create(
                        session,
                        m_nodeManager,
                        request.RequestedPublishingInterval,
                        request.RequestedLifetimeCount,
                        request.RequestedMaxKeepAliveCount,
                        request.MaxNotificationsPerPublish,
                        request.PublishingEnabled,
                        request.Priority,
                        out subscriptionId,
                        out publishingInterval,
                        out lifetimeCount,
                        out keepAliveCount);

                    // save the subscription.
                    m_subscriptions.Add(subscriptionId, subscription);

                    // start the publish thread if it has not already been started.
                    if (m_subscriptions.Count == 1)
                    {
                        ThreadPool.QueueUserWorkItem(PublishSubscriptions);
                    }

                    // return the response.
                    CreateSubscriptionResponseMessage response = new CreateSubscriptionResponseMessage();

                    response.ResponseHeader = CreateResponseHeader(request.RequestHeader);
                    response.SubscriptionId = subscriptionId;
                    response.RevisedPublishingInterval = publishingInterval;
                    response.RevisedLifetimeCount = lifetimeCount;
                    response.RevisedMaxKeepAliveCount = keepAliveCount;

                    return response;
                }
            }
            catch (Exception e)
            {
                throw CreateSoapFault(request.RequestHeader, e);
            }
        }

        public ModifySubscriptionResponseMessage ModifySubscription(ModifySubscriptionMessage request)
        {
            throw new NotImplementedException();
        }

        public SetPublishingModeResponseMessage SetPublishingMode(SetPublishingModeMessage request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Tells the server that the client is ready to receive notifications from the server.
        /// </summary>
        public PublishResponseMessage Publish(PublishMessage request)
        {
            try
            {
                // validate the sesion
                Session session = VerifySession(request.RequestHeader, false);

                uint subscriptionId = 0;
                NotificationMessage message = null;

                QueuedRequest queuedRequest = new QueuedRequest();

                lock (m_messages)
                {
                    // first check if there are any messages waiting to be published.
                    for (LinkedListNode<QueuedMessage> node = m_messages.First; node != null; node = node.Next)
                    {
                        // ensure the message belongs to the current session
                        if (Object.ReferenceEquals(session, node.Value.Session))
                        {
                            // pull the message off the queue and return.
                            subscriptionId = node.Value.Subscription.Id;
                            message = node.Value.Message;
                            m_messages.Remove(node);
                            break;
                        }
                    }

                    // must process requests in the order that they arrive.
                    if (message == null)
                    {
                        queuedRequest.Session = session;
                        queuedRequest.Timeout = DateTime.UtcNow.AddMilliseconds(request.RequestHeader.TimeoutHint);
                        queuedRequest.Signal = new ManualResetEvent(false);
                        m_requests.AddLast(queuedRequest);
                    }
                }

                // wait for a notification.
                if (message == null)
                {
                    try
                    {
                        queuedRequest.Signal.WaitOne();

                        if (queuedRequest.Message == null)
                        {
                            throw new StatusCodeException(StatusCodes.BadTimeout, "Timed out waiting for notifications.");
                        }

                        subscriptionId = queuedRequest.SubscriptionId;
                        message = queuedRequest.Message;
                    }
                    finally
                    {
                        queuedRequest.Signal.Close();
                    }
                }

                // sent response.
                PublishResponseMessage response = new PublishResponseMessage();

                response.ResponseHeader = CreateResponseHeader(request.RequestHeader);
                response.SubscriptionId = subscriptionId;
                response.NotificationMessage = message;
                response.MoreNotifications = false;
                response.Results = new ListOfStatusCode();
                response.DiagnosticInfos = new ListOfDiagnosticInfo();
                response.AvailableSequenceNumbers = new ListOfUInt32();

                return response;
            }
            catch (Exception e)
            {
                throw CreateSoapFault(request.RequestHeader, e);
            }
        }

        /// <summary>
        /// Dispatches a notification message produced by a subscription.
        /// </summary>
        private void DispatchMessage(Subscription subscription, NotificationMessage notification)
        {
            lock (m_messages)
            {
                for (LinkedListNode<QueuedRequest> node = m_requests.First; node != null; node = node.Next)
                {
                    // wake up timed out requests and force them to return a fault.
                    if (node.Value.Timeout < DateTime.UtcNow)
                    {
                        node.Value.Signal.Set();
                        m_requests.Remove(node);
                        continue;
                    }

                    // check for a request that matches the session.
                    if (Object.ReferenceEquals(subscription.Session, node.Value.Session))
                    {
                        // pass the message to the request and wake up the request thread.
                        node.Value.SubscriptionId = subscription.Id;
                        node.Value.Message = notification;
                        node.Value.Signal.Set();
                        m_requests.Remove(node);
                        return;
                    }
                }

                // messages only go on the publish queue if no threads are waiting.
                QueuedMessage message = new QueuedMessage();

                message.Session = subscription.Session;
                message.Subscription = subscription;
                message.Message = notification;
                m_messages.AddLast(message);

                // ensure queue does not grow too large.
                while (m_messages.Count > 50)
                {
                    m_messages.RemoveFirst();
                }
            }
        }

        /// <summary>
        /// Periodically checks each subscription to see if it has notifications to publish.
        /// </summary>
        private void PublishSubscriptions(object state)
        {
            while (true)
            {
                Thread.Sleep(100);

                List<Subscription> subscriptions = null;

                lock (m_lock)
                {
                    subscriptions = new List<Subscription>(m_subscriptions.Values);
                }

                foreach (Subscription subscription in subscriptions)
                {
                    // check for notifications.
                    NotificationMessage notification = subscription.Publish();

                    if (notification == null)
                    {
                        continue;
                    }

                    // dispatch the message.
                    DispatchMessage(subscription, notification);
                }
            }
        }

        public RepublishResponseMessage Republish(RepublishMessage request)
        {
            throw new NotImplementedException();
        }

        public TransferSubscriptionsResponseMessage TransferSubscriptions(TransferSubscriptionsMessage request)
        {
            throw new NotImplementedException();
        }

        public DeleteSubscriptionsResponseMessage DeleteSubscriptions(DeleteSubscriptionsMessage request)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region IDiscoveryEndpoint Members
        /// <summary>
        /// Returns the servers known to the discovery endpoint.
        /// </summary>
        public FindServersResponseMessage FindServers(FindServersMessage request)
        {
            lock (m_lock)
            {
                // update the list of supported endpoints by looking in the service description associated with the host.
                InitializeApplicationDescription();

                FindServersResponseMessage response = new FindServersResponseMessage();

                response.ResponseHeader = CreateResponseHeader(request.RequestHeader);
                response.Servers = new ListOfApplicationDescription();

                // only one server to return must still must check the filter if specified.
                bool filtered = false;

                if (request.ServerUris != null && request.ServerUris.Count != 0)
                {
                    filtered = true;

                    foreach (string serverUri in request.ServerUris)
                    {
                        if (serverUri == m_application.ApplicationUri)
                        {
                            filtered = false;
                            break;
                        }
                    }
                }

                // return an empty list if no match on the filter.
                if (!filtered)
                {
                    response.Servers.Add(m_application);
                }

                return response;
            }
        }

        /// <summary>
        /// Returns the endpoints supported by the server. 
        /// </summary>
        public GetEndpointsResponseMessage GetEndpoints(GetEndpointsMessage request)
        {
            lock (m_lock)
            {
                // update the list of supported endpoints by looking in the service description associated with the host.
                InitializeApplicationDescription();

                GetEndpointsResponseMessage response = new GetEndpointsResponseMessage();

                response.ResponseHeader = CreateResponseHeader(request.RequestHeader);
                response.Endpoints = new ListOfEndpointDescription();

                // only return endpoints which support the request transport profile.
                foreach (EndpointDescription endpoint in m_endpoints)
                {
                    bool filtered = false;

                    if (request.ProfileUris != null && request.ProfileUris.Count != 0)
                    {
                        filtered = true;

                        foreach (string profileUri in request.ProfileUris)
                        {
                            if (profileUri == endpoint.TransportProfileUri)
                            {
                                filtered = false;
                                break;
                            }
                        }
                    }

                    // return an empty list if none found.
                    if (!filtered)
                    {
                        response.Endpoints.Add(endpoint);
                    }
                }

                return response;
            }
        }
        #endregion
    }
}
