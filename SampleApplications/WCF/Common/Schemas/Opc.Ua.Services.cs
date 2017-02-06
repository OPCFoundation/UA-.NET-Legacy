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

namespace Opc.Ua
{
    using System.Runtime.Serialization;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Services.wsdl", ConfigurationName="Opc.Ua.ISessionEndpoint")]
    public interface ISessionEndpoint
    {
        
        // CODEGEN: Generating message contract since the operation InvokeService is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/InvokeService", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/InvokeServiceResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Opc.Ua.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/InvokeServiceFault", Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
        Opc.Ua.InvokeServiceResponseMessage InvokeService(Opc.Ua.InvokeServiceMessage request);
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://opcfoundation.org/UA/2008/02/Types.xsd) of message CreateSessionMessage does not match the default value (http://opcfoundation.org/UA/2008/02/Services.wsdl)
        [System.ServiceModel.OperationContractAttribute(Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/CreateSession", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/CreateSessionResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Opc.Ua.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/CreateSessionFault", Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
        Opc.Ua.CreateSessionResponseMessage CreateSession(Opc.Ua.CreateSessionMessage request);
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://opcfoundation.org/UA/2008/02/Types.xsd) of message ActivateSessionMessage does not match the default value (http://opcfoundation.org/UA/2008/02/Services.wsdl)
        [System.ServiceModel.OperationContractAttribute(Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/ActivateSession", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/ActivateSessionResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Opc.Ua.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/ActivateSessionFault", Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
        Opc.Ua.ActivateSessionResponseMessage ActivateSession(Opc.Ua.ActivateSessionMessage request);
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://opcfoundation.org/UA/2008/02/Types.xsd) of message CloseSessionMessage does not match the default value (http://opcfoundation.org/UA/2008/02/Services.wsdl)
        [System.ServiceModel.OperationContractAttribute(Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/CloseSession", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/CloseSessionResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Opc.Ua.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/CloseSessionFault", Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
        Opc.Ua.CloseSessionResponseMessage CloseSession(Opc.Ua.CloseSessionMessage request);
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://opcfoundation.org/UA/2008/02/Types.xsd) of message CancelMessage does not match the default value (http://opcfoundation.org/UA/2008/02/Services.wsdl)
        [System.ServiceModel.OperationContractAttribute(Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/Cancel", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/CancelResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Opc.Ua.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/CancelFault", Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
        Opc.Ua.CancelResponseMessage Cancel(Opc.Ua.CancelMessage request);
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://opcfoundation.org/UA/2008/02/Types.xsd) of message AddNodesMessage does not match the default value (http://opcfoundation.org/UA/2008/02/Services.wsdl)
        [System.ServiceModel.OperationContractAttribute(Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/AddNodes", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/AddNodesResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Opc.Ua.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/AddNodesFault", Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
        Opc.Ua.AddNodesResponseMessage AddNodes(Opc.Ua.AddNodesMessage request);
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://opcfoundation.org/UA/2008/02/Types.xsd) of message AddReferencesMessage does not match the default value (http://opcfoundation.org/UA/2008/02/Services.wsdl)
        [System.ServiceModel.OperationContractAttribute(Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/AddReferences", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/AddReferencesResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Opc.Ua.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/AddReferencesFault", Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
        Opc.Ua.AddReferencesResponseMessage AddReferences(Opc.Ua.AddReferencesMessage request);
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://opcfoundation.org/UA/2008/02/Types.xsd) of message DeleteNodesMessage does not match the default value (http://opcfoundation.org/UA/2008/02/Services.wsdl)
        [System.ServiceModel.OperationContractAttribute(Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/DeleteNodes", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/DeleteNodesResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Opc.Ua.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/DeleteNodesFault", Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
        Opc.Ua.DeleteNodesResponseMessage DeleteNodes(Opc.Ua.DeleteNodesMessage request);
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://opcfoundation.org/UA/2008/02/Types.xsd) of message DeleteReferencesMessage does not match the default value (http://opcfoundation.org/UA/2008/02/Services.wsdl)
        [System.ServiceModel.OperationContractAttribute(Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/DeleteReferences", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/DeleteReferencesResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Opc.Ua.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/DeleteReferencesFault", Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
        Opc.Ua.DeleteReferencesResponseMessage DeleteReferences(Opc.Ua.DeleteReferencesMessage request);
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://opcfoundation.org/UA/2008/02/Types.xsd) of message BrowseMessage does not match the default value (http://opcfoundation.org/UA/2008/02/Services.wsdl)
        [System.ServiceModel.OperationContractAttribute(Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/Browse", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/BrowseResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Opc.Ua.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/BrowseFault", Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
        Opc.Ua.BrowseResponseMessage Browse(Opc.Ua.BrowseMessage request);
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://opcfoundation.org/UA/2008/02/Types.xsd) of message BrowseNextMessage does not match the default value (http://opcfoundation.org/UA/2008/02/Services.wsdl)
        [System.ServiceModel.OperationContractAttribute(Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/BrowseNext", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/BrowseNextResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Opc.Ua.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/BrowseNextFault", Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
        Opc.Ua.BrowseNextResponseMessage BrowseNext(Opc.Ua.BrowseNextMessage request);
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://opcfoundation.org/UA/2008/02/Types.xsd) of message TranslateBrowsePathsToNodeIdsMessage does not match the default value (http://opcfoundation.org/UA/2008/02/Services.wsdl)
        [System.ServiceModel.OperationContractAttribute(Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/TranslateBrowsePathsToNodeIds", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/TranslateBrowsePathsToNodeIdsRe" +
            "sponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Opc.Ua.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/TranslateBrowsePathsToNodeIdsFa" +
            "ult", Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
        Opc.Ua.TranslateBrowsePathsToNodeIdsResponseMessage TranslateBrowsePathsToNodeIds(Opc.Ua.TranslateBrowsePathsToNodeIdsMessage request);
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://opcfoundation.org/UA/2008/02/Types.xsd) of message RegisterNodesMessage does not match the default value (http://opcfoundation.org/UA/2008/02/Services.wsdl)
        [System.ServiceModel.OperationContractAttribute(Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/RegisterNodes", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/RegisterNodesResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Opc.Ua.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/RegisterNodesFault", Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
        Opc.Ua.RegisterNodesResponseMessage RegisterNodes(Opc.Ua.RegisterNodesMessage request);
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://opcfoundation.org/UA/2008/02/Types.xsd) of message UnregisterNodesMessage does not match the default value (http://opcfoundation.org/UA/2008/02/Services.wsdl)
        [System.ServiceModel.OperationContractAttribute(Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/UnregisterNodes", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/UnregisterNodesResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Opc.Ua.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/UnregisterNodesFault", Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
        Opc.Ua.UnregisterNodesResponseMessage UnregisterNodes(Opc.Ua.UnregisterNodesMessage request);
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://opcfoundation.org/UA/2008/02/Types.xsd) of message QueryFirstMessage does not match the default value (http://opcfoundation.org/UA/2008/02/Services.wsdl)
        [System.ServiceModel.OperationContractAttribute(Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/QueryFirst", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/QueryFirstResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Opc.Ua.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/QueryFirstFault", Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
        Opc.Ua.QueryFirstResponseMessage QueryFirst(Opc.Ua.QueryFirstMessage request);
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://opcfoundation.org/UA/2008/02/Types.xsd) of message QueryNextMessage does not match the default value (http://opcfoundation.org/UA/2008/02/Services.wsdl)
        [System.ServiceModel.OperationContractAttribute(Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/QueryNext", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/QueryNextResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Opc.Ua.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/QueryNextFault", Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
        Opc.Ua.QueryNextResponseMessage QueryNext(Opc.Ua.QueryNextMessage request);
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://opcfoundation.org/UA/2008/02/Types.xsd) of message ReadMessage does not match the default value (http://opcfoundation.org/UA/2008/02/Services.wsdl)
        [System.ServiceModel.OperationContractAttribute(Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/Read", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/ReadResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Opc.Ua.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/ReadFault", Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
        Opc.Ua.ReadResponseMessage Read(Opc.Ua.ReadMessage request);
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://opcfoundation.org/UA/2008/02/Types.xsd) of message HistoryReadMessage does not match the default value (http://opcfoundation.org/UA/2008/02/Services.wsdl)
        [System.ServiceModel.OperationContractAttribute(Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/HistoryRead", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/HistoryReadResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Opc.Ua.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/HistoryReadFault", Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
        Opc.Ua.HistoryReadResponseMessage HistoryRead(Opc.Ua.HistoryReadMessage request);
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://opcfoundation.org/UA/2008/02/Types.xsd) of message WriteMessage does not match the default value (http://opcfoundation.org/UA/2008/02/Services.wsdl)
        [System.ServiceModel.OperationContractAttribute(Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/Write", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/WriteResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Opc.Ua.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/WriteFault", Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
        Opc.Ua.WriteResponseMessage Write(Opc.Ua.WriteMessage request);
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://opcfoundation.org/UA/2008/02/Types.xsd) of message HistoryUpdateMessage does not match the default value (http://opcfoundation.org/UA/2008/02/Services.wsdl)
        [System.ServiceModel.OperationContractAttribute(Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/HistoryUpdate", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/HistoryUpdateResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Opc.Ua.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/HistoryUpdateFault", Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
        Opc.Ua.HistoryUpdateResponseMessage HistoryUpdate(Opc.Ua.HistoryUpdateMessage request);
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://opcfoundation.org/UA/2008/02/Types.xsd) of message CallMessage does not match the default value (http://opcfoundation.org/UA/2008/02/Services.wsdl)
        [System.ServiceModel.OperationContractAttribute(Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/Call", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/CallResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Opc.Ua.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/CallFault", Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
        Opc.Ua.CallResponseMessage Call(Opc.Ua.CallMessage request);
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://opcfoundation.org/UA/2008/02/Types.xsd) of message CreateMonitoredItemsMessage does not match the default value (http://opcfoundation.org/UA/2008/02/Services.wsdl)
        [System.ServiceModel.OperationContractAttribute(Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/CreateMonitoredItems", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/CreateMonitoredItemsResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Opc.Ua.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/CreateMonitoredItemsFault", Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
        Opc.Ua.CreateMonitoredItemsResponseMessage CreateMonitoredItems(Opc.Ua.CreateMonitoredItemsMessage request);
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://opcfoundation.org/UA/2008/02/Types.xsd) of message ModifyMonitoredItemsMessage does not match the default value (http://opcfoundation.org/UA/2008/02/Services.wsdl)
        [System.ServiceModel.OperationContractAttribute(Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/ModifyMonitoredItems", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/ModifyMonitoredItemsResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Opc.Ua.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/ModifyMonitoredItemsFault", Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
        Opc.Ua.ModifyMonitoredItemsResponseMessage ModifyMonitoredItems(Opc.Ua.ModifyMonitoredItemsMessage request);
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://opcfoundation.org/UA/2008/02/Types.xsd) of message SetMonitoringModeMessage does not match the default value (http://opcfoundation.org/UA/2008/02/Services.wsdl)
        [System.ServiceModel.OperationContractAttribute(Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/SetMonitoringMode", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/SetMonitoringModeResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Opc.Ua.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/SetMonitoringModeFault", Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
        Opc.Ua.SetMonitoringModeResponseMessage SetMonitoringMode(Opc.Ua.SetMonitoringModeMessage request);
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://opcfoundation.org/UA/2008/02/Types.xsd) of message SetTriggeringMessage does not match the default value (http://opcfoundation.org/UA/2008/02/Services.wsdl)
        [System.ServiceModel.OperationContractAttribute(Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/SetTriggering", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/SetTriggeringResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Opc.Ua.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/SetTriggeringFault", Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
        Opc.Ua.SetTriggeringResponseMessage SetTriggering(Opc.Ua.SetTriggeringMessage request);
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://opcfoundation.org/UA/2008/02/Types.xsd) of message DeleteMonitoredItemsMessage does not match the default value (http://opcfoundation.org/UA/2008/02/Services.wsdl)
        [System.ServiceModel.OperationContractAttribute(Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/DeleteMonitoredItems", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/DeleteMonitoredItemsResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Opc.Ua.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/DeleteMonitoredItemsFault", Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
        Opc.Ua.DeleteMonitoredItemsResponseMessage DeleteMonitoredItems(Opc.Ua.DeleteMonitoredItemsMessage request);
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://opcfoundation.org/UA/2008/02/Types.xsd) of message CreateSubscriptionMessage does not match the default value (http://opcfoundation.org/UA/2008/02/Services.wsdl)
        [System.ServiceModel.OperationContractAttribute(Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/CreateSubscription", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/CreateSubscriptionResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Opc.Ua.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/CreateSubscriptionFault", Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
        Opc.Ua.CreateSubscriptionResponseMessage CreateSubscription(Opc.Ua.CreateSubscriptionMessage request);
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://opcfoundation.org/UA/2008/02/Types.xsd) of message ModifySubscriptionMessage does not match the default value (http://opcfoundation.org/UA/2008/02/Services.wsdl)
        [System.ServiceModel.OperationContractAttribute(Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/ModifySubscription", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/ModifySubscriptionResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Opc.Ua.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/ModifySubscriptionFault", Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
        Opc.Ua.ModifySubscriptionResponseMessage ModifySubscription(Opc.Ua.ModifySubscriptionMessage request);
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://opcfoundation.org/UA/2008/02/Types.xsd) of message SetPublishingModeMessage does not match the default value (http://opcfoundation.org/UA/2008/02/Services.wsdl)
        [System.ServiceModel.OperationContractAttribute(Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/SetPublishingMode", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/SetPublishingModeResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Opc.Ua.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/SetPublishingModeFault", Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
        Opc.Ua.SetPublishingModeResponseMessage SetPublishingMode(Opc.Ua.SetPublishingModeMessage request);
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://opcfoundation.org/UA/2008/02/Types.xsd) of message PublishMessage does not match the default value (http://opcfoundation.org/UA/2008/02/Services.wsdl)
        [System.ServiceModel.OperationContractAttribute(Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/Publish", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/PublishResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Opc.Ua.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/PublishFault", Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
        Opc.Ua.PublishResponseMessage Publish(Opc.Ua.PublishMessage request);
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://opcfoundation.org/UA/2008/02/Types.xsd) of message RepublishMessage does not match the default value (http://opcfoundation.org/UA/2008/02/Services.wsdl)
        [System.ServiceModel.OperationContractAttribute(Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/Republish", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/RepublishResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Opc.Ua.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/RepublishFault", Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
        Opc.Ua.RepublishResponseMessage Republish(Opc.Ua.RepublishMessage request);
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://opcfoundation.org/UA/2008/02/Types.xsd) of message TransferSubscriptionsMessage does not match the default value (http://opcfoundation.org/UA/2008/02/Services.wsdl)
        [System.ServiceModel.OperationContractAttribute(Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/TransferSubscriptions", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/TransferSubscriptionsResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Opc.Ua.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/TransferSubscriptionsFault", Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
        Opc.Ua.TransferSubscriptionsResponseMessage TransferSubscriptions(Opc.Ua.TransferSubscriptionsMessage request);
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://opcfoundation.org/UA/2008/02/Types.xsd) of message DeleteSubscriptionsMessage does not match the default value (http://opcfoundation.org/UA/2008/02/Services.wsdl)
        [System.ServiceModel.OperationContractAttribute(Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/DeleteSubscriptions", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/DeleteSubscriptionsResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Opc.Ua.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/DeleteSubscriptionsFault", Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
        Opc.Ua.DeleteSubscriptionsResponseMessage DeleteSubscriptions(Opc.Ua.DeleteSubscriptionsMessage request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class InvokeServiceMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public byte[] InvokeServiceRequest;
        
        public InvokeServiceMessage()
        {
        }
        
        public InvokeServiceMessage(byte[] InvokeServiceRequest)
        {
            this.InvokeServiceRequest = InvokeServiceRequest;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class InvokeServiceResponseMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public byte[] InvokeServiceResponse;
        
        public InvokeServiceResponseMessage()
        {
        }
        
        public InvokeServiceResponseMessage(byte[] InvokeServiceResponse)
        {
            this.InvokeServiceResponse = InvokeServiceResponse;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="CreateSessionRequest", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class CreateSessionMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.RequestHeader RequestHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public Opc.Ua.ApplicationDescription ClientDescription;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=2)]
        public string ServerUri;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=3)]
        public string EndpointUrl;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=4)]
        public string SessionName;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=5)]
        public byte[] ClientNonce;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=6)]
        public byte[] ClientCertificate;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=7)]
        public double RequestedSessionTimeout;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=8)]
        public uint MaxResponseMessageSize;
        
        public CreateSessionMessage()
        {
        }
        
        public CreateSessionMessage(Opc.Ua.RequestHeader RequestHeader, Opc.Ua.ApplicationDescription ClientDescription, string ServerUri, string EndpointUrl, string SessionName, byte[] ClientNonce, byte[] ClientCertificate, double RequestedSessionTimeout, uint MaxResponseMessageSize)
        {
            this.RequestHeader = RequestHeader;
            this.ClientDescription = ClientDescription;
            this.ServerUri = ServerUri;
            this.EndpointUrl = EndpointUrl;
            this.SessionName = SessionName;
            this.ClientNonce = ClientNonce;
            this.ClientCertificate = ClientCertificate;
            this.RequestedSessionTimeout = RequestedSessionTimeout;
            this.MaxResponseMessageSize = MaxResponseMessageSize;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="CreateSessionResponse", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class CreateSessionResponseMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.ResponseHeader ResponseHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public Opc.Ua.NodeId SessionId;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=2)]
        public Opc.Ua.NodeId AuthenticationToken;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=3)]
        public double RevisedSessionTimeout;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=4)]
        public byte[] ServerNonce;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=5)]
        public byte[] ServerCertificate;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=6)]
        public Opc.Ua.ListOfEndpointDescription ServerEndpoints;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=7)]
        public Opc.Ua.ListOfSignedSoftwareCertificate ServerSoftwareCertificates;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=8)]
        public Opc.Ua.SignatureData ServerSignature;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=9)]
        public uint MaxRequestMessageSize;
        
        public CreateSessionResponseMessage()
        {
        }
        
        public CreateSessionResponseMessage(Opc.Ua.ResponseHeader ResponseHeader, Opc.Ua.NodeId SessionId, Opc.Ua.NodeId AuthenticationToken, double RevisedSessionTimeout, byte[] ServerNonce, byte[] ServerCertificate, Opc.Ua.ListOfEndpointDescription ServerEndpoints, Opc.Ua.ListOfSignedSoftwareCertificate ServerSoftwareCertificates, Opc.Ua.SignatureData ServerSignature, uint MaxRequestMessageSize)
        {
            this.ResponseHeader = ResponseHeader;
            this.SessionId = SessionId;
            this.AuthenticationToken = AuthenticationToken;
            this.RevisedSessionTimeout = RevisedSessionTimeout;
            this.ServerNonce = ServerNonce;
            this.ServerCertificate = ServerCertificate;
            this.ServerEndpoints = ServerEndpoints;
            this.ServerSoftwareCertificates = ServerSoftwareCertificates;
            this.ServerSignature = ServerSignature;
            this.MaxRequestMessageSize = MaxRequestMessageSize;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ActivateSessionRequest", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class ActivateSessionMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.RequestHeader RequestHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public Opc.Ua.SignatureData ClientSignature;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=2)]
        public Opc.Ua.ListOfSignedSoftwareCertificate ClientSoftwareCertificates;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=3)]
        public Opc.Ua.ListOfString LocaleIds;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=4)]
        public Opc.Ua.ExtensionObject UserIdentityToken;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=5)]
        public Opc.Ua.SignatureData UserTokenSignature;
        
        public ActivateSessionMessage()
        {
        }
        
        public ActivateSessionMessage(Opc.Ua.RequestHeader RequestHeader, Opc.Ua.SignatureData ClientSignature, Opc.Ua.ListOfSignedSoftwareCertificate ClientSoftwareCertificates, Opc.Ua.ListOfString LocaleIds, Opc.Ua.ExtensionObject UserIdentityToken, Opc.Ua.SignatureData UserTokenSignature)
        {
            this.RequestHeader = RequestHeader;
            this.ClientSignature = ClientSignature;
            this.ClientSoftwareCertificates = ClientSoftwareCertificates;
            this.LocaleIds = LocaleIds;
            this.UserIdentityToken = UserIdentityToken;
            this.UserTokenSignature = UserTokenSignature;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ActivateSessionResponse", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class ActivateSessionResponseMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.ResponseHeader ResponseHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public byte[] ServerNonce;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=2)]
        public Opc.Ua.ListOfStatusCode Results;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=3)]
        public Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos;
        
        public ActivateSessionResponseMessage()
        {
        }
        
        public ActivateSessionResponseMessage(Opc.Ua.ResponseHeader ResponseHeader, byte[] ServerNonce, Opc.Ua.ListOfStatusCode Results, Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos)
        {
            this.ResponseHeader = ResponseHeader;
            this.ServerNonce = ServerNonce;
            this.Results = Results;
            this.DiagnosticInfos = DiagnosticInfos;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="CloseSessionRequest", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class CloseSessionMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.RequestHeader RequestHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public bool DeleteSubscriptions;
        
        public CloseSessionMessage()
        {
        }
        
        public CloseSessionMessage(Opc.Ua.RequestHeader RequestHeader, bool DeleteSubscriptions)
        {
            this.RequestHeader = RequestHeader;
            this.DeleteSubscriptions = DeleteSubscriptions;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="CloseSessionResponse", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class CloseSessionResponseMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.ResponseHeader ResponseHeader;
        
        public CloseSessionResponseMessage()
        {
        }
        
        public CloseSessionResponseMessage(Opc.Ua.ResponseHeader ResponseHeader)
        {
            this.ResponseHeader = ResponseHeader;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="CancelRequest", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class CancelMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.RequestHeader RequestHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public uint RequestHandle;
        
        public CancelMessage()
        {
        }
        
        public CancelMessage(Opc.Ua.RequestHeader RequestHeader, uint RequestHandle)
        {
            this.RequestHeader = RequestHeader;
            this.RequestHandle = RequestHandle;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="CancelResponse", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class CancelResponseMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.ResponseHeader ResponseHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public uint CancelCount;
        
        public CancelResponseMessage()
        {
        }
        
        public CancelResponseMessage(Opc.Ua.ResponseHeader ResponseHeader, uint CancelCount)
        {
            this.ResponseHeader = ResponseHeader;
            this.CancelCount = CancelCount;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="AddNodesRequest", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class AddNodesMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.RequestHeader RequestHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public Opc.Ua.ListOfAddNodesItem NodesToAdd;
        
        public AddNodesMessage()
        {
        }
        
        public AddNodesMessage(Opc.Ua.RequestHeader RequestHeader, Opc.Ua.ListOfAddNodesItem NodesToAdd)
        {
            this.RequestHeader = RequestHeader;
            this.NodesToAdd = NodesToAdd;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="AddNodesResponse", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class AddNodesResponseMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.ResponseHeader ResponseHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public Opc.Ua.ListOfAddNodesResult Results;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=2)]
        public Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos;
        
        public AddNodesResponseMessage()
        {
        }
        
        public AddNodesResponseMessage(Opc.Ua.ResponseHeader ResponseHeader, Opc.Ua.ListOfAddNodesResult Results, Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos)
        {
            this.ResponseHeader = ResponseHeader;
            this.Results = Results;
            this.DiagnosticInfos = DiagnosticInfos;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="AddReferencesRequest", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class AddReferencesMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.RequestHeader RequestHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public Opc.Ua.ListOfAddReferencesItem ReferencesToAdd;
        
        public AddReferencesMessage()
        {
        }
        
        public AddReferencesMessage(Opc.Ua.RequestHeader RequestHeader, Opc.Ua.ListOfAddReferencesItem ReferencesToAdd)
        {
            this.RequestHeader = RequestHeader;
            this.ReferencesToAdd = ReferencesToAdd;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="AddReferencesResponse", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class AddReferencesResponseMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.ResponseHeader ResponseHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public Opc.Ua.ListOfStatusCode Results;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=2)]
        public Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos;
        
        public AddReferencesResponseMessage()
        {
        }
        
        public AddReferencesResponseMessage(Opc.Ua.ResponseHeader ResponseHeader, Opc.Ua.ListOfStatusCode Results, Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos)
        {
            this.ResponseHeader = ResponseHeader;
            this.Results = Results;
            this.DiagnosticInfos = DiagnosticInfos;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="DeleteNodesRequest", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class DeleteNodesMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.RequestHeader RequestHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public Opc.Ua.ListOfDeleteNodesItem NodesToDelete;
        
        public DeleteNodesMessage()
        {
        }
        
        public DeleteNodesMessage(Opc.Ua.RequestHeader RequestHeader, Opc.Ua.ListOfDeleteNodesItem NodesToDelete)
        {
            this.RequestHeader = RequestHeader;
            this.NodesToDelete = NodesToDelete;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="DeleteNodesResponse", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class DeleteNodesResponseMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.ResponseHeader ResponseHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public Opc.Ua.ListOfStatusCode Results;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=2)]
        public Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos;
        
        public DeleteNodesResponseMessage()
        {
        }
        
        public DeleteNodesResponseMessage(Opc.Ua.ResponseHeader ResponseHeader, Opc.Ua.ListOfStatusCode Results, Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos)
        {
            this.ResponseHeader = ResponseHeader;
            this.Results = Results;
            this.DiagnosticInfos = DiagnosticInfos;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="DeleteReferencesRequest", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class DeleteReferencesMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.RequestHeader RequestHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public Opc.Ua.ListOfDeleteReferencesItem ReferencesToDelete;
        
        public DeleteReferencesMessage()
        {
        }
        
        public DeleteReferencesMessage(Opc.Ua.RequestHeader RequestHeader, Opc.Ua.ListOfDeleteReferencesItem ReferencesToDelete)
        {
            this.RequestHeader = RequestHeader;
            this.ReferencesToDelete = ReferencesToDelete;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="DeleteReferencesResponse", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class DeleteReferencesResponseMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.ResponseHeader ResponseHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public Opc.Ua.ListOfStatusCode Results;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=2)]
        public Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos;
        
        public DeleteReferencesResponseMessage()
        {
        }
        
        public DeleteReferencesResponseMessage(Opc.Ua.ResponseHeader ResponseHeader, Opc.Ua.ListOfStatusCode Results, Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos)
        {
            this.ResponseHeader = ResponseHeader;
            this.Results = Results;
            this.DiagnosticInfos = DiagnosticInfos;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="BrowseRequest", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class BrowseMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.RequestHeader RequestHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public Opc.Ua.ViewDescription View;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=2)]
        public uint RequestedMaxReferencesPerNode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=3)]
        public Opc.Ua.ListOfBrowseDescription NodesToBrowse;
        
        public BrowseMessage()
        {
        }
        
        public BrowseMessage(Opc.Ua.RequestHeader RequestHeader, Opc.Ua.ViewDescription View, uint RequestedMaxReferencesPerNode, Opc.Ua.ListOfBrowseDescription NodesToBrowse)
        {
            this.RequestHeader = RequestHeader;
            this.View = View;
            this.RequestedMaxReferencesPerNode = RequestedMaxReferencesPerNode;
            this.NodesToBrowse = NodesToBrowse;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="BrowseResponse", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class BrowseResponseMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.ResponseHeader ResponseHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public Opc.Ua.ListOfBrowseResult Results;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=2)]
        public Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos;
        
        public BrowseResponseMessage()
        {
        }
        
        public BrowseResponseMessage(Opc.Ua.ResponseHeader ResponseHeader, Opc.Ua.ListOfBrowseResult Results, Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos)
        {
            this.ResponseHeader = ResponseHeader;
            this.Results = Results;
            this.DiagnosticInfos = DiagnosticInfos;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="BrowseNextRequest", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class BrowseNextMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.RequestHeader RequestHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public bool ReleaseContinuationPoints;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=2)]
        public Opc.Ua.ListOfByteString ContinuationPoints;
        
        public BrowseNextMessage()
        {
        }
        
        public BrowseNextMessage(Opc.Ua.RequestHeader RequestHeader, bool ReleaseContinuationPoints, Opc.Ua.ListOfByteString ContinuationPoints)
        {
            this.RequestHeader = RequestHeader;
            this.ReleaseContinuationPoints = ReleaseContinuationPoints;
            this.ContinuationPoints = ContinuationPoints;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="BrowseNextResponse", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class BrowseNextResponseMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.ResponseHeader ResponseHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public Opc.Ua.ListOfBrowseResult Results;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=2)]
        public Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos;
        
        public BrowseNextResponseMessage()
        {
        }
        
        public BrowseNextResponseMessage(Opc.Ua.ResponseHeader ResponseHeader, Opc.Ua.ListOfBrowseResult Results, Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos)
        {
            this.ResponseHeader = ResponseHeader;
            this.Results = Results;
            this.DiagnosticInfos = DiagnosticInfos;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="TranslateBrowsePathsToNodeIdsRequest", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class TranslateBrowsePathsToNodeIdsMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.RequestHeader RequestHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public Opc.Ua.ListOfBrowsePath BrowsePaths;
        
        public TranslateBrowsePathsToNodeIdsMessage()
        {
        }
        
        public TranslateBrowsePathsToNodeIdsMessage(Opc.Ua.RequestHeader RequestHeader, Opc.Ua.ListOfBrowsePath BrowsePaths)
        {
            this.RequestHeader = RequestHeader;
            this.BrowsePaths = BrowsePaths;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="TranslateBrowsePathsToNodeIdsResponse", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class TranslateBrowsePathsToNodeIdsResponseMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.ResponseHeader ResponseHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public Opc.Ua.ListOfBrowsePathResult Results;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=2)]
        public Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos;
        
        public TranslateBrowsePathsToNodeIdsResponseMessage()
        {
        }
        
        public TranslateBrowsePathsToNodeIdsResponseMessage(Opc.Ua.ResponseHeader ResponseHeader, Opc.Ua.ListOfBrowsePathResult Results, Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos)
        {
            this.ResponseHeader = ResponseHeader;
            this.Results = Results;
            this.DiagnosticInfos = DiagnosticInfos;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="RegisterNodesRequest", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class RegisterNodesMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.RequestHeader RequestHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public Opc.Ua.ListOfNodeId NodesToRegister;
        
        public RegisterNodesMessage()
        {
        }
        
        public RegisterNodesMessage(Opc.Ua.RequestHeader RequestHeader, Opc.Ua.ListOfNodeId NodesToRegister)
        {
            this.RequestHeader = RequestHeader;
            this.NodesToRegister = NodesToRegister;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="RegisterNodesResponse", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class RegisterNodesResponseMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.ResponseHeader ResponseHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public Opc.Ua.ListOfNodeId RegisteredNodeIds;
        
        public RegisterNodesResponseMessage()
        {
        }
        
        public RegisterNodesResponseMessage(Opc.Ua.ResponseHeader ResponseHeader, Opc.Ua.ListOfNodeId RegisteredNodeIds)
        {
            this.ResponseHeader = ResponseHeader;
            this.RegisteredNodeIds = RegisteredNodeIds;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="UnregisterNodesRequest", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class UnregisterNodesMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.RequestHeader RequestHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public Opc.Ua.ListOfNodeId NodesToUnregister;
        
        public UnregisterNodesMessage()
        {
        }
        
        public UnregisterNodesMessage(Opc.Ua.RequestHeader RequestHeader, Opc.Ua.ListOfNodeId NodesToUnregister)
        {
            this.RequestHeader = RequestHeader;
            this.NodesToUnregister = NodesToUnregister;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="UnregisterNodesResponse", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class UnregisterNodesResponseMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.ResponseHeader ResponseHeader;
        
        public UnregisterNodesResponseMessage()
        {
        }
        
        public UnregisterNodesResponseMessage(Opc.Ua.ResponseHeader ResponseHeader)
        {
            this.ResponseHeader = ResponseHeader;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="QueryFirstRequest", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class QueryFirstMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.RequestHeader RequestHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public Opc.Ua.ViewDescription View;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=2)]
        public Opc.Ua.ListOfNodeTypeDescription NodeTypes;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=3)]
        public Opc.Ua.ContentFilter Filter;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=4)]
        public uint MaxDataSetsToReturn;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=5)]
        public uint MaxReferencesToReturn;
        
        public QueryFirstMessage()
        {
        }
        
        public QueryFirstMessage(Opc.Ua.RequestHeader RequestHeader, Opc.Ua.ViewDescription View, Opc.Ua.ListOfNodeTypeDescription NodeTypes, Opc.Ua.ContentFilter Filter, uint MaxDataSetsToReturn, uint MaxReferencesToReturn)
        {
            this.RequestHeader = RequestHeader;
            this.View = View;
            this.NodeTypes = NodeTypes;
            this.Filter = Filter;
            this.MaxDataSetsToReturn = MaxDataSetsToReturn;
            this.MaxReferencesToReturn = MaxReferencesToReturn;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="QueryFirstResponse", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class QueryFirstResponseMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.ResponseHeader ResponseHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public Opc.Ua.ListOfQueryDataSet QueryDataSets;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=2)]
        public byte[] ContinuationPoint;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=3)]
        public Opc.Ua.ListOfParsingResult ParsingResults;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=4)]
        public Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=5)]
        public Opc.Ua.ContentFilterResult FilterResult;
        
        public QueryFirstResponseMessage()
        {
        }
        
        public QueryFirstResponseMessage(Opc.Ua.ResponseHeader ResponseHeader, Opc.Ua.ListOfQueryDataSet QueryDataSets, byte[] ContinuationPoint, Opc.Ua.ListOfParsingResult ParsingResults, Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos, Opc.Ua.ContentFilterResult FilterResult)
        {
            this.ResponseHeader = ResponseHeader;
            this.QueryDataSets = QueryDataSets;
            this.ContinuationPoint = ContinuationPoint;
            this.ParsingResults = ParsingResults;
            this.DiagnosticInfos = DiagnosticInfos;
            this.FilterResult = FilterResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="QueryNextRequest", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class QueryNextMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.RequestHeader RequestHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public bool ReleaseContinuationPoint;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=2)]
        public byte[] ContinuationPoint;
        
        public QueryNextMessage()
        {
        }
        
        public QueryNextMessage(Opc.Ua.RequestHeader RequestHeader, bool ReleaseContinuationPoint, byte[] ContinuationPoint)
        {
            this.RequestHeader = RequestHeader;
            this.ReleaseContinuationPoint = ReleaseContinuationPoint;
            this.ContinuationPoint = ContinuationPoint;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="QueryNextResponse", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class QueryNextResponseMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.ResponseHeader ResponseHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public Opc.Ua.ListOfQueryDataSet QueryDataSets;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=2)]
        public byte[] RevisedContinuationPoint;
        
        public QueryNextResponseMessage()
        {
        }
        
        public QueryNextResponseMessage(Opc.Ua.ResponseHeader ResponseHeader, Opc.Ua.ListOfQueryDataSet QueryDataSets, byte[] RevisedContinuationPoint)
        {
            this.ResponseHeader = ResponseHeader;
            this.QueryDataSets = QueryDataSets;
            this.RevisedContinuationPoint = RevisedContinuationPoint;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ReadRequest", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class ReadMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.RequestHeader RequestHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public double MaxAge;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=2)]
        public Opc.Ua.TimestampsToReturn TimestampsToReturn;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=3)]
        public Opc.Ua.ListOfReadValueId NodesToRead;
        
        public ReadMessage()
        {
        }
        
        public ReadMessage(Opc.Ua.RequestHeader RequestHeader, double MaxAge, Opc.Ua.TimestampsToReturn TimestampsToReturn, Opc.Ua.ListOfReadValueId NodesToRead)
        {
            this.RequestHeader = RequestHeader;
            this.MaxAge = MaxAge;
            this.TimestampsToReturn = TimestampsToReturn;
            this.NodesToRead = NodesToRead;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ReadResponse", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class ReadResponseMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.ResponseHeader ResponseHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public Opc.Ua.ListOfDataValue Results;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=2)]
        public Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos;
        
        public ReadResponseMessage()
        {
        }
        
        public ReadResponseMessage(Opc.Ua.ResponseHeader ResponseHeader, Opc.Ua.ListOfDataValue Results, Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos)
        {
            this.ResponseHeader = ResponseHeader;
            this.Results = Results;
            this.DiagnosticInfos = DiagnosticInfos;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="HistoryReadRequest", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class HistoryReadMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.RequestHeader RequestHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public Opc.Ua.ExtensionObject HistoryReadDetails;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=2)]
        public Opc.Ua.TimestampsToReturn TimestampsToReturn;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=3)]
        public bool ReleaseContinuationPoints;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=4)]
        public Opc.Ua.ListOfHistoryReadValueId NodesToRead;
        
        public HistoryReadMessage()
        {
        }
        
        public HistoryReadMessage(Opc.Ua.RequestHeader RequestHeader, Opc.Ua.ExtensionObject HistoryReadDetails, Opc.Ua.TimestampsToReturn TimestampsToReturn, bool ReleaseContinuationPoints, Opc.Ua.ListOfHistoryReadValueId NodesToRead)
        {
            this.RequestHeader = RequestHeader;
            this.HistoryReadDetails = HistoryReadDetails;
            this.TimestampsToReturn = TimestampsToReturn;
            this.ReleaseContinuationPoints = ReleaseContinuationPoints;
            this.NodesToRead = NodesToRead;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="HistoryReadResponse", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class HistoryReadResponseMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.ResponseHeader ResponseHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public Opc.Ua.ListOfHistoryReadResult Results;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=2)]
        public Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos;
        
        public HistoryReadResponseMessage()
        {
        }
        
        public HistoryReadResponseMessage(Opc.Ua.ResponseHeader ResponseHeader, Opc.Ua.ListOfHistoryReadResult Results, Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos)
        {
            this.ResponseHeader = ResponseHeader;
            this.Results = Results;
            this.DiagnosticInfos = DiagnosticInfos;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="WriteRequest", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class WriteMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.RequestHeader RequestHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public Opc.Ua.ListOfWriteValue NodesToWrite;
        
        public WriteMessage()
        {
        }
        
        public WriteMessage(Opc.Ua.RequestHeader RequestHeader, Opc.Ua.ListOfWriteValue NodesToWrite)
        {
            this.RequestHeader = RequestHeader;
            this.NodesToWrite = NodesToWrite;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="WriteResponse", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class WriteResponseMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.ResponseHeader ResponseHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public Opc.Ua.ListOfStatusCode Results;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=2)]
        public Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos;
        
        public WriteResponseMessage()
        {
        }
        
        public WriteResponseMessage(Opc.Ua.ResponseHeader ResponseHeader, Opc.Ua.ListOfStatusCode Results, Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos)
        {
            this.ResponseHeader = ResponseHeader;
            this.Results = Results;
            this.DiagnosticInfos = DiagnosticInfos;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="HistoryUpdateRequest", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class HistoryUpdateMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.RequestHeader RequestHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public Opc.Ua.ListOfExtensionObject HistoryUpdateDetails;
        
        public HistoryUpdateMessage()
        {
        }
        
        public HistoryUpdateMessage(Opc.Ua.RequestHeader RequestHeader, Opc.Ua.ListOfExtensionObject HistoryUpdateDetails)
        {
            this.RequestHeader = RequestHeader;
            this.HistoryUpdateDetails = HistoryUpdateDetails;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="HistoryUpdateResponse", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class HistoryUpdateResponseMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.ResponseHeader ResponseHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public Opc.Ua.ListOfHistoryUpdateResult Results;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=2)]
        public Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos;
        
        public HistoryUpdateResponseMessage()
        {
        }
        
        public HistoryUpdateResponseMessage(Opc.Ua.ResponseHeader ResponseHeader, Opc.Ua.ListOfHistoryUpdateResult Results, Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos)
        {
            this.ResponseHeader = ResponseHeader;
            this.Results = Results;
            this.DiagnosticInfos = DiagnosticInfos;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="CallRequest", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class CallMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.RequestHeader RequestHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public Opc.Ua.ListOfCallMethodRequest MethodsToCall;
        
        public CallMessage()
        {
        }
        
        public CallMessage(Opc.Ua.RequestHeader RequestHeader, Opc.Ua.ListOfCallMethodRequest MethodsToCall)
        {
            this.RequestHeader = RequestHeader;
            this.MethodsToCall = MethodsToCall;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="CallResponse", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class CallResponseMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.ResponseHeader ResponseHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public Opc.Ua.ListOfCallMethodResult Results;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=2)]
        public Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos;
        
        public CallResponseMessage()
        {
        }
        
        public CallResponseMessage(Opc.Ua.ResponseHeader ResponseHeader, Opc.Ua.ListOfCallMethodResult Results, Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos)
        {
            this.ResponseHeader = ResponseHeader;
            this.Results = Results;
            this.DiagnosticInfos = DiagnosticInfos;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="CreateMonitoredItemsRequest", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class CreateMonitoredItemsMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.RequestHeader RequestHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public uint SubscriptionId;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=2)]
        public Opc.Ua.TimestampsToReturn TimestampsToReturn;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=3)]
        public Opc.Ua.ListOfMonitoredItemCreateRequest ItemsToCreate;
        
        public CreateMonitoredItemsMessage()
        {
        }
        
        public CreateMonitoredItemsMessage(Opc.Ua.RequestHeader RequestHeader, uint SubscriptionId, Opc.Ua.TimestampsToReturn TimestampsToReturn, Opc.Ua.ListOfMonitoredItemCreateRequest ItemsToCreate)
        {
            this.RequestHeader = RequestHeader;
            this.SubscriptionId = SubscriptionId;
            this.TimestampsToReturn = TimestampsToReturn;
            this.ItemsToCreate = ItemsToCreate;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="CreateMonitoredItemsResponse", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class CreateMonitoredItemsResponseMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.ResponseHeader ResponseHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public Opc.Ua.ListOfMonitoredItemCreateResult Results;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=2)]
        public Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos;
        
        public CreateMonitoredItemsResponseMessage()
        {
        }
        
        public CreateMonitoredItemsResponseMessage(Opc.Ua.ResponseHeader ResponseHeader, Opc.Ua.ListOfMonitoredItemCreateResult Results, Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos)
        {
            this.ResponseHeader = ResponseHeader;
            this.Results = Results;
            this.DiagnosticInfos = DiagnosticInfos;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ModifyMonitoredItemsRequest", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class ModifyMonitoredItemsMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.RequestHeader RequestHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public uint SubscriptionId;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=2)]
        public Opc.Ua.TimestampsToReturn TimestampsToReturn;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=3)]
        public Opc.Ua.ListOfMonitoredItemModifyRequest ItemsToModify;
        
        public ModifyMonitoredItemsMessage()
        {
        }
        
        public ModifyMonitoredItemsMessage(Opc.Ua.RequestHeader RequestHeader, uint SubscriptionId, Opc.Ua.TimestampsToReturn TimestampsToReturn, Opc.Ua.ListOfMonitoredItemModifyRequest ItemsToModify)
        {
            this.RequestHeader = RequestHeader;
            this.SubscriptionId = SubscriptionId;
            this.TimestampsToReturn = TimestampsToReturn;
            this.ItemsToModify = ItemsToModify;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ModifyMonitoredItemsResponse", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class ModifyMonitoredItemsResponseMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.ResponseHeader ResponseHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public Opc.Ua.ListOfMonitoredItemModifyResult Results;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=2)]
        public Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos;
        
        public ModifyMonitoredItemsResponseMessage()
        {
        }
        
        public ModifyMonitoredItemsResponseMessage(Opc.Ua.ResponseHeader ResponseHeader, Opc.Ua.ListOfMonitoredItemModifyResult Results, Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos)
        {
            this.ResponseHeader = ResponseHeader;
            this.Results = Results;
            this.DiagnosticInfos = DiagnosticInfos;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="SetMonitoringModeRequest", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class SetMonitoringModeMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.RequestHeader RequestHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public uint SubscriptionId;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=2)]
        public Opc.Ua.MonitoringMode MonitoringMode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=3)]
        public Opc.Ua.ListOfUInt32 MonitoredItemIds;
        
        public SetMonitoringModeMessage()
        {
        }
        
        public SetMonitoringModeMessage(Opc.Ua.RequestHeader RequestHeader, uint SubscriptionId, Opc.Ua.MonitoringMode MonitoringMode, Opc.Ua.ListOfUInt32 MonitoredItemIds)
        {
            this.RequestHeader = RequestHeader;
            this.SubscriptionId = SubscriptionId;
            this.MonitoringMode = MonitoringMode;
            this.MonitoredItemIds = MonitoredItemIds;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="SetMonitoringModeResponse", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class SetMonitoringModeResponseMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.ResponseHeader ResponseHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public Opc.Ua.ListOfStatusCode Results;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=2)]
        public Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos;
        
        public SetMonitoringModeResponseMessage()
        {
        }
        
        public SetMonitoringModeResponseMessage(Opc.Ua.ResponseHeader ResponseHeader, Opc.Ua.ListOfStatusCode Results, Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos)
        {
            this.ResponseHeader = ResponseHeader;
            this.Results = Results;
            this.DiagnosticInfos = DiagnosticInfos;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="SetTriggeringRequest", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class SetTriggeringMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.RequestHeader RequestHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public uint SubscriptionId;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=2)]
        public uint TriggeringItemId;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=3)]
        public Opc.Ua.ListOfUInt32 LinksToAdd;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=4)]
        public Opc.Ua.ListOfUInt32 LinksToRemove;
        
        public SetTriggeringMessage()
        {
        }
        
        public SetTriggeringMessage(Opc.Ua.RequestHeader RequestHeader, uint SubscriptionId, uint TriggeringItemId, Opc.Ua.ListOfUInt32 LinksToAdd, Opc.Ua.ListOfUInt32 LinksToRemove)
        {
            this.RequestHeader = RequestHeader;
            this.SubscriptionId = SubscriptionId;
            this.TriggeringItemId = TriggeringItemId;
            this.LinksToAdd = LinksToAdd;
            this.LinksToRemove = LinksToRemove;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="SetTriggeringResponse", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class SetTriggeringResponseMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.ResponseHeader ResponseHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public Opc.Ua.ListOfStatusCode AddResults;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=2)]
        public Opc.Ua.ListOfDiagnosticInfo AddDiagnosticInfos;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=3)]
        public Opc.Ua.ListOfStatusCode RemoveResults;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=4)]
        public Opc.Ua.ListOfDiagnosticInfo RemoveDiagnosticInfos;
        
        public SetTriggeringResponseMessage()
        {
        }
        
        public SetTriggeringResponseMessage(Opc.Ua.ResponseHeader ResponseHeader, Opc.Ua.ListOfStatusCode AddResults, Opc.Ua.ListOfDiagnosticInfo AddDiagnosticInfos, Opc.Ua.ListOfStatusCode RemoveResults, Opc.Ua.ListOfDiagnosticInfo RemoveDiagnosticInfos)
        {
            this.ResponseHeader = ResponseHeader;
            this.AddResults = AddResults;
            this.AddDiagnosticInfos = AddDiagnosticInfos;
            this.RemoveResults = RemoveResults;
            this.RemoveDiagnosticInfos = RemoveDiagnosticInfos;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="DeleteMonitoredItemsRequest", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class DeleteMonitoredItemsMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.RequestHeader RequestHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public uint SubscriptionId;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=2)]
        public Opc.Ua.ListOfUInt32 MonitoredItemIds;
        
        public DeleteMonitoredItemsMessage()
        {
        }
        
        public DeleteMonitoredItemsMessage(Opc.Ua.RequestHeader RequestHeader, uint SubscriptionId, Opc.Ua.ListOfUInt32 MonitoredItemIds)
        {
            this.RequestHeader = RequestHeader;
            this.SubscriptionId = SubscriptionId;
            this.MonitoredItemIds = MonitoredItemIds;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="DeleteMonitoredItemsResponse", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class DeleteMonitoredItemsResponseMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.ResponseHeader ResponseHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public Opc.Ua.ListOfStatusCode Results;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=2)]
        public Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos;
        
        public DeleteMonitoredItemsResponseMessage()
        {
        }
        
        public DeleteMonitoredItemsResponseMessage(Opc.Ua.ResponseHeader ResponseHeader, Opc.Ua.ListOfStatusCode Results, Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos)
        {
            this.ResponseHeader = ResponseHeader;
            this.Results = Results;
            this.DiagnosticInfos = DiagnosticInfos;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="CreateSubscriptionRequest", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class CreateSubscriptionMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.RequestHeader RequestHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public double RequestedPublishingInterval;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=2)]
        public uint RequestedLifetimeCount;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=3)]
        public uint RequestedMaxKeepAliveCount;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=4)]
        public uint MaxNotificationsPerPublish;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=5)]
        public bool PublishingEnabled;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=6)]
        public byte Priority;
        
        public CreateSubscriptionMessage()
        {
        }
        
        public CreateSubscriptionMessage(Opc.Ua.RequestHeader RequestHeader, double RequestedPublishingInterval, uint RequestedLifetimeCount, uint RequestedMaxKeepAliveCount, uint MaxNotificationsPerPublish, bool PublishingEnabled, byte Priority)
        {
            this.RequestHeader = RequestHeader;
            this.RequestedPublishingInterval = RequestedPublishingInterval;
            this.RequestedLifetimeCount = RequestedLifetimeCount;
            this.RequestedMaxKeepAliveCount = RequestedMaxKeepAliveCount;
            this.MaxNotificationsPerPublish = MaxNotificationsPerPublish;
            this.PublishingEnabled = PublishingEnabled;
            this.Priority = Priority;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="CreateSubscriptionResponse", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class CreateSubscriptionResponseMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.ResponseHeader ResponseHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public uint SubscriptionId;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=2)]
        public double RevisedPublishingInterval;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=3)]
        public uint RevisedLifetimeCount;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=4)]
        public uint RevisedMaxKeepAliveCount;
        
        public CreateSubscriptionResponseMessage()
        {
        }
        
        public CreateSubscriptionResponseMessage(Opc.Ua.ResponseHeader ResponseHeader, uint SubscriptionId, double RevisedPublishingInterval, uint RevisedLifetimeCount, uint RevisedMaxKeepAliveCount)
        {
            this.ResponseHeader = ResponseHeader;
            this.SubscriptionId = SubscriptionId;
            this.RevisedPublishingInterval = RevisedPublishingInterval;
            this.RevisedLifetimeCount = RevisedLifetimeCount;
            this.RevisedMaxKeepAliveCount = RevisedMaxKeepAliveCount;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ModifySubscriptionRequest", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class ModifySubscriptionMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.RequestHeader RequestHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public uint SubscriptionId;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=2)]
        public double RequestedPublishingInterval;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=3)]
        public uint RequestedLifetimeCount;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=4)]
        public uint RequestedMaxKeepAliveCount;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=5)]
        public uint MaxNotificationsPerPublish;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=6)]
        public byte Priority;
        
        public ModifySubscriptionMessage()
        {
        }
        
        public ModifySubscriptionMessage(Opc.Ua.RequestHeader RequestHeader, uint SubscriptionId, double RequestedPublishingInterval, uint RequestedLifetimeCount, uint RequestedMaxKeepAliveCount, uint MaxNotificationsPerPublish, byte Priority)
        {
            this.RequestHeader = RequestHeader;
            this.SubscriptionId = SubscriptionId;
            this.RequestedPublishingInterval = RequestedPublishingInterval;
            this.RequestedLifetimeCount = RequestedLifetimeCount;
            this.RequestedMaxKeepAliveCount = RequestedMaxKeepAliveCount;
            this.MaxNotificationsPerPublish = MaxNotificationsPerPublish;
            this.Priority = Priority;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ModifySubscriptionResponse", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class ModifySubscriptionResponseMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.ResponseHeader ResponseHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public double RevisedPublishingInterval;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=2)]
        public uint RevisedLifetimeCount;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=3)]
        public uint RevisedMaxKeepAliveCount;
        
        public ModifySubscriptionResponseMessage()
        {
        }
        
        public ModifySubscriptionResponseMessage(Opc.Ua.ResponseHeader ResponseHeader, double RevisedPublishingInterval, uint RevisedLifetimeCount, uint RevisedMaxKeepAliveCount)
        {
            this.ResponseHeader = ResponseHeader;
            this.RevisedPublishingInterval = RevisedPublishingInterval;
            this.RevisedLifetimeCount = RevisedLifetimeCount;
            this.RevisedMaxKeepAliveCount = RevisedMaxKeepAliveCount;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="SetPublishingModeRequest", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class SetPublishingModeMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.RequestHeader RequestHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public bool PublishingEnabled;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=2)]
        public Opc.Ua.ListOfUInt32 SubscriptionIds;
        
        public SetPublishingModeMessage()
        {
        }
        
        public SetPublishingModeMessage(Opc.Ua.RequestHeader RequestHeader, bool PublishingEnabled, Opc.Ua.ListOfUInt32 SubscriptionIds)
        {
            this.RequestHeader = RequestHeader;
            this.PublishingEnabled = PublishingEnabled;
            this.SubscriptionIds = SubscriptionIds;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="SetPublishingModeResponse", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class SetPublishingModeResponseMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.ResponseHeader ResponseHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public Opc.Ua.ListOfStatusCode Results;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=2)]
        public Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos;
        
        public SetPublishingModeResponseMessage()
        {
        }
        
        public SetPublishingModeResponseMessage(Opc.Ua.ResponseHeader ResponseHeader, Opc.Ua.ListOfStatusCode Results, Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos)
        {
            this.ResponseHeader = ResponseHeader;
            this.Results = Results;
            this.DiagnosticInfos = DiagnosticInfos;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="PublishRequest", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class PublishMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.RequestHeader RequestHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public Opc.Ua.ListOfSubscriptionAcknowledgement SubscriptionAcknowledgements;
        
        public PublishMessage()
        {
        }
        
        public PublishMessage(Opc.Ua.RequestHeader RequestHeader, Opc.Ua.ListOfSubscriptionAcknowledgement SubscriptionAcknowledgements)
        {
            this.RequestHeader = RequestHeader;
            this.SubscriptionAcknowledgements = SubscriptionAcknowledgements;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="PublishResponse", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class PublishResponseMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.ResponseHeader ResponseHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public uint SubscriptionId;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=2)]
        public Opc.Ua.ListOfUInt32 AvailableSequenceNumbers;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=3)]
        public bool MoreNotifications;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=4)]
        public Opc.Ua.NotificationMessage NotificationMessage;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=5)]
        public Opc.Ua.ListOfStatusCode Results;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=6)]
        public Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos;
        
        public PublishResponseMessage()
        {
        }
        
        public PublishResponseMessage(Opc.Ua.ResponseHeader ResponseHeader, uint SubscriptionId, Opc.Ua.ListOfUInt32 AvailableSequenceNumbers, bool MoreNotifications, Opc.Ua.NotificationMessage NotificationMessage, Opc.Ua.ListOfStatusCode Results, Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos)
        {
            this.ResponseHeader = ResponseHeader;
            this.SubscriptionId = SubscriptionId;
            this.AvailableSequenceNumbers = AvailableSequenceNumbers;
            this.MoreNotifications = MoreNotifications;
            this.NotificationMessage = NotificationMessage;
            this.Results = Results;
            this.DiagnosticInfos = DiagnosticInfos;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="RepublishRequest", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class RepublishMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.RequestHeader RequestHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public uint SubscriptionId;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=2)]
        public uint RetransmitSequenceNumber;
        
        public RepublishMessage()
        {
        }
        
        public RepublishMessage(Opc.Ua.RequestHeader RequestHeader, uint SubscriptionId, uint RetransmitSequenceNumber)
        {
            this.RequestHeader = RequestHeader;
            this.SubscriptionId = SubscriptionId;
            this.RetransmitSequenceNumber = RetransmitSequenceNumber;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="RepublishResponse", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class RepublishResponseMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.ResponseHeader ResponseHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public Opc.Ua.NotificationMessage NotificationMessage;
        
        public RepublishResponseMessage()
        {
        }
        
        public RepublishResponseMessage(Opc.Ua.ResponseHeader ResponseHeader, Opc.Ua.NotificationMessage NotificationMessage)
        {
            this.ResponseHeader = ResponseHeader;
            this.NotificationMessage = NotificationMessage;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="TransferSubscriptionsRequest", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class TransferSubscriptionsMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.RequestHeader RequestHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public Opc.Ua.ListOfUInt32 SubscriptionIds;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=2)]
        public bool SendInitialValues;
        
        public TransferSubscriptionsMessage()
        {
        }
        
        public TransferSubscriptionsMessage(Opc.Ua.RequestHeader RequestHeader, Opc.Ua.ListOfUInt32 SubscriptionIds, bool SendInitialValues)
        {
            this.RequestHeader = RequestHeader;
            this.SubscriptionIds = SubscriptionIds;
            this.SendInitialValues = SendInitialValues;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="TransferSubscriptionsResponse", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class TransferSubscriptionsResponseMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.ResponseHeader ResponseHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public Opc.Ua.ListOfTransferResult Results;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=2)]
        public Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos;
        
        public TransferSubscriptionsResponseMessage()
        {
        }
        
        public TransferSubscriptionsResponseMessage(Opc.Ua.ResponseHeader ResponseHeader, Opc.Ua.ListOfTransferResult Results, Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos)
        {
            this.ResponseHeader = ResponseHeader;
            this.Results = Results;
            this.DiagnosticInfos = DiagnosticInfos;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="DeleteSubscriptionsRequest", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class DeleteSubscriptionsMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.RequestHeader RequestHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public Opc.Ua.ListOfUInt32 SubscriptionIds;
        
        public DeleteSubscriptionsMessage()
        {
        }
        
        public DeleteSubscriptionsMessage(Opc.Ua.RequestHeader RequestHeader, Opc.Ua.ListOfUInt32 SubscriptionIds)
        {
            this.RequestHeader = RequestHeader;
            this.SubscriptionIds = SubscriptionIds;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="DeleteSubscriptionsResponse", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class DeleteSubscriptionsResponseMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.ResponseHeader ResponseHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public Opc.Ua.ListOfStatusCode Results;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=2)]
        public Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos;
        
        public DeleteSubscriptionsResponseMessage()
        {
        }
        
        public DeleteSubscriptionsResponseMessage(Opc.Ua.ResponseHeader ResponseHeader, Opc.Ua.ListOfStatusCode Results, Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos)
        {
            this.ResponseHeader = ResponseHeader;
            this.Results = Results;
            this.DiagnosticInfos = DiagnosticInfos;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface ISessionEndpointChannel : Opc.Ua.ISessionEndpoint, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class SessionEndpointClient : System.ServiceModel.ClientBase<Opc.Ua.ISessionEndpoint>, Opc.Ua.ISessionEndpoint
    {
        
        public SessionEndpointClient()
        {
        }
        
        public SessionEndpointClient(string endpointConfigurationName) : 
                base(endpointConfigurationName)
        {
        }
        
        public SessionEndpointClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }
        
        public SessionEndpointClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }
        
        public SessionEndpointClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Opc.Ua.InvokeServiceResponseMessage Opc.Ua.ISessionEndpoint.InvokeService(Opc.Ua.InvokeServiceMessage request)
        {
            return base.Channel.InvokeService(request);
        }
        
        public byte[] InvokeService(byte[] InvokeServiceRequest)
        {
            Opc.Ua.InvokeServiceMessage inValue = new Opc.Ua.InvokeServiceMessage();
            inValue.InvokeServiceRequest = InvokeServiceRequest;
            Opc.Ua.InvokeServiceResponseMessage retVal = ((Opc.Ua.ISessionEndpoint)(this)).InvokeService(inValue);
            return retVal.InvokeServiceResponse;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Opc.Ua.CreateSessionResponseMessage Opc.Ua.ISessionEndpoint.CreateSession(Opc.Ua.CreateSessionMessage request)
        {
            return base.Channel.CreateSession(request);
        }
        
        public Opc.Ua.ResponseHeader CreateSession(
                    Opc.Ua.RequestHeader RequestHeader, 
                    Opc.Ua.ApplicationDescription ClientDescription, 
                    string ServerUri, 
                    string EndpointUrl, 
                    string SessionName, 
                    byte[] ClientNonce, 
                    byte[] ClientCertificate, 
                    double RequestedSessionTimeout, 
                    uint MaxResponseMessageSize, 
                    out Opc.Ua.NodeId SessionId, 
                    out Opc.Ua.NodeId AuthenticationToken, 
                    out double RevisedSessionTimeout, 
                    out byte[] ServerNonce, 
                    out byte[] ServerCertificate, 
                    out Opc.Ua.ListOfEndpointDescription ServerEndpoints, 
                    out Opc.Ua.ListOfSignedSoftwareCertificate ServerSoftwareCertificates, 
                    out Opc.Ua.SignatureData ServerSignature, 
                    out uint MaxRequestMessageSize)
        {
            Opc.Ua.CreateSessionMessage inValue = new Opc.Ua.CreateSessionMessage();
            inValue.RequestHeader = RequestHeader;
            inValue.ClientDescription = ClientDescription;
            inValue.ServerUri = ServerUri;
            inValue.EndpointUrl = EndpointUrl;
            inValue.SessionName = SessionName;
            inValue.ClientNonce = ClientNonce;
            inValue.ClientCertificate = ClientCertificate;
            inValue.RequestedSessionTimeout = RequestedSessionTimeout;
            inValue.MaxResponseMessageSize = MaxResponseMessageSize;
            Opc.Ua.CreateSessionResponseMessage retVal = ((Opc.Ua.ISessionEndpoint)(this)).CreateSession(inValue);
            SessionId = retVal.SessionId;
            AuthenticationToken = retVal.AuthenticationToken;
            RevisedSessionTimeout = retVal.RevisedSessionTimeout;
            ServerNonce = retVal.ServerNonce;
            ServerCertificate = retVal.ServerCertificate;
            ServerEndpoints = retVal.ServerEndpoints;
            ServerSoftwareCertificates = retVal.ServerSoftwareCertificates;
            ServerSignature = retVal.ServerSignature;
            MaxRequestMessageSize = retVal.MaxRequestMessageSize;
            return retVal.ResponseHeader;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Opc.Ua.ActivateSessionResponseMessage Opc.Ua.ISessionEndpoint.ActivateSession(Opc.Ua.ActivateSessionMessage request)
        {
            return base.Channel.ActivateSession(request);
        }
        
        public Opc.Ua.ResponseHeader ActivateSession(Opc.Ua.RequestHeader RequestHeader, Opc.Ua.SignatureData ClientSignature, Opc.Ua.ListOfSignedSoftwareCertificate ClientSoftwareCertificates, Opc.Ua.ListOfString LocaleIds, Opc.Ua.ExtensionObject UserIdentityToken, Opc.Ua.SignatureData UserTokenSignature, out byte[] ServerNonce, out Opc.Ua.ListOfStatusCode Results, out Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos)
        {
            Opc.Ua.ActivateSessionMessage inValue = new Opc.Ua.ActivateSessionMessage();
            inValue.RequestHeader = RequestHeader;
            inValue.ClientSignature = ClientSignature;
            inValue.ClientSoftwareCertificates = ClientSoftwareCertificates;
            inValue.LocaleIds = LocaleIds;
            inValue.UserIdentityToken = UserIdentityToken;
            inValue.UserTokenSignature = UserTokenSignature;
            Opc.Ua.ActivateSessionResponseMessage retVal = ((Opc.Ua.ISessionEndpoint)(this)).ActivateSession(inValue);
            ServerNonce = retVal.ServerNonce;
            Results = retVal.Results;
            DiagnosticInfos = retVal.DiagnosticInfos;
            return retVal.ResponseHeader;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Opc.Ua.CloseSessionResponseMessage Opc.Ua.ISessionEndpoint.CloseSession(Opc.Ua.CloseSessionMessage request)
        {
            return base.Channel.CloseSession(request);
        }
        
        public Opc.Ua.ResponseHeader CloseSession(Opc.Ua.RequestHeader RequestHeader, bool DeleteSubscriptions)
        {
            Opc.Ua.CloseSessionMessage inValue = new Opc.Ua.CloseSessionMessage();
            inValue.RequestHeader = RequestHeader;
            inValue.DeleteSubscriptions = DeleteSubscriptions;
            Opc.Ua.CloseSessionResponseMessage retVal = ((Opc.Ua.ISessionEndpoint)(this)).CloseSession(inValue);
            return retVal.ResponseHeader;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Opc.Ua.CancelResponseMessage Opc.Ua.ISessionEndpoint.Cancel(Opc.Ua.CancelMessage request)
        {
            return base.Channel.Cancel(request);
        }
        
        public Opc.Ua.ResponseHeader Cancel(Opc.Ua.RequestHeader RequestHeader, uint RequestHandle, out uint CancelCount)
        {
            Opc.Ua.CancelMessage inValue = new Opc.Ua.CancelMessage();
            inValue.RequestHeader = RequestHeader;
            inValue.RequestHandle = RequestHandle;
            Opc.Ua.CancelResponseMessage retVal = ((Opc.Ua.ISessionEndpoint)(this)).Cancel(inValue);
            CancelCount = retVal.CancelCount;
            return retVal.ResponseHeader;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Opc.Ua.AddNodesResponseMessage Opc.Ua.ISessionEndpoint.AddNodes(Opc.Ua.AddNodesMessage request)
        {
            return base.Channel.AddNodes(request);
        }
        
        public Opc.Ua.ResponseHeader AddNodes(Opc.Ua.RequestHeader RequestHeader, Opc.Ua.ListOfAddNodesItem NodesToAdd, out Opc.Ua.ListOfAddNodesResult Results, out Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos)
        {
            Opc.Ua.AddNodesMessage inValue = new Opc.Ua.AddNodesMessage();
            inValue.RequestHeader = RequestHeader;
            inValue.NodesToAdd = NodesToAdd;
            Opc.Ua.AddNodesResponseMessage retVal = ((Opc.Ua.ISessionEndpoint)(this)).AddNodes(inValue);
            Results = retVal.Results;
            DiagnosticInfos = retVal.DiagnosticInfos;
            return retVal.ResponseHeader;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Opc.Ua.AddReferencesResponseMessage Opc.Ua.ISessionEndpoint.AddReferences(Opc.Ua.AddReferencesMessage request)
        {
            return base.Channel.AddReferences(request);
        }
        
        public Opc.Ua.ResponseHeader AddReferences(Opc.Ua.RequestHeader RequestHeader, Opc.Ua.ListOfAddReferencesItem ReferencesToAdd, out Opc.Ua.ListOfStatusCode Results, out Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos)
        {
            Opc.Ua.AddReferencesMessage inValue = new Opc.Ua.AddReferencesMessage();
            inValue.RequestHeader = RequestHeader;
            inValue.ReferencesToAdd = ReferencesToAdd;
            Opc.Ua.AddReferencesResponseMessage retVal = ((Opc.Ua.ISessionEndpoint)(this)).AddReferences(inValue);
            Results = retVal.Results;
            DiagnosticInfos = retVal.DiagnosticInfos;
            return retVal.ResponseHeader;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Opc.Ua.DeleteNodesResponseMessage Opc.Ua.ISessionEndpoint.DeleteNodes(Opc.Ua.DeleteNodesMessage request)
        {
            return base.Channel.DeleteNodes(request);
        }
        
        public Opc.Ua.ResponseHeader DeleteNodes(Opc.Ua.RequestHeader RequestHeader, Opc.Ua.ListOfDeleteNodesItem NodesToDelete, out Opc.Ua.ListOfStatusCode Results, out Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos)
        {
            Opc.Ua.DeleteNodesMessage inValue = new Opc.Ua.DeleteNodesMessage();
            inValue.RequestHeader = RequestHeader;
            inValue.NodesToDelete = NodesToDelete;
            Opc.Ua.DeleteNodesResponseMessage retVal = ((Opc.Ua.ISessionEndpoint)(this)).DeleteNodes(inValue);
            Results = retVal.Results;
            DiagnosticInfos = retVal.DiagnosticInfos;
            return retVal.ResponseHeader;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Opc.Ua.DeleteReferencesResponseMessage Opc.Ua.ISessionEndpoint.DeleteReferences(Opc.Ua.DeleteReferencesMessage request)
        {
            return base.Channel.DeleteReferences(request);
        }
        
        public Opc.Ua.ResponseHeader DeleteReferences(Opc.Ua.RequestHeader RequestHeader, Opc.Ua.ListOfDeleteReferencesItem ReferencesToDelete, out Opc.Ua.ListOfStatusCode Results, out Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos)
        {
            Opc.Ua.DeleteReferencesMessage inValue = new Opc.Ua.DeleteReferencesMessage();
            inValue.RequestHeader = RequestHeader;
            inValue.ReferencesToDelete = ReferencesToDelete;
            Opc.Ua.DeleteReferencesResponseMessage retVal = ((Opc.Ua.ISessionEndpoint)(this)).DeleteReferences(inValue);
            Results = retVal.Results;
            DiagnosticInfos = retVal.DiagnosticInfos;
            return retVal.ResponseHeader;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Opc.Ua.BrowseResponseMessage Opc.Ua.ISessionEndpoint.Browse(Opc.Ua.BrowseMessage request)
        {
            return base.Channel.Browse(request);
        }
        
        public Opc.Ua.ResponseHeader Browse(Opc.Ua.RequestHeader RequestHeader, Opc.Ua.ViewDescription View, uint RequestedMaxReferencesPerNode, Opc.Ua.ListOfBrowseDescription NodesToBrowse, out Opc.Ua.ListOfBrowseResult Results, out Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos)
        {
            Opc.Ua.BrowseMessage inValue = new Opc.Ua.BrowseMessage();
            inValue.RequestHeader = RequestHeader;
            inValue.View = View;
            inValue.RequestedMaxReferencesPerNode = RequestedMaxReferencesPerNode;
            inValue.NodesToBrowse = NodesToBrowse;
            Opc.Ua.BrowseResponseMessage retVal = ((Opc.Ua.ISessionEndpoint)(this)).Browse(inValue);
            Results = retVal.Results;
            DiagnosticInfos = retVal.DiagnosticInfos;
            return retVal.ResponseHeader;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Opc.Ua.BrowseNextResponseMessage Opc.Ua.ISessionEndpoint.BrowseNext(Opc.Ua.BrowseNextMessage request)
        {
            return base.Channel.BrowseNext(request);
        }
        
        public Opc.Ua.ResponseHeader BrowseNext(Opc.Ua.RequestHeader RequestHeader, bool ReleaseContinuationPoints, Opc.Ua.ListOfByteString ContinuationPoints, out Opc.Ua.ListOfBrowseResult Results, out Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos)
        {
            Opc.Ua.BrowseNextMessage inValue = new Opc.Ua.BrowseNextMessage();
            inValue.RequestHeader = RequestHeader;
            inValue.ReleaseContinuationPoints = ReleaseContinuationPoints;
            inValue.ContinuationPoints = ContinuationPoints;
            Opc.Ua.BrowseNextResponseMessage retVal = ((Opc.Ua.ISessionEndpoint)(this)).BrowseNext(inValue);
            Results = retVal.Results;
            DiagnosticInfos = retVal.DiagnosticInfos;
            return retVal.ResponseHeader;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Opc.Ua.TranslateBrowsePathsToNodeIdsResponseMessage Opc.Ua.ISessionEndpoint.TranslateBrowsePathsToNodeIds(Opc.Ua.TranslateBrowsePathsToNodeIdsMessage request)
        {
            return base.Channel.TranslateBrowsePathsToNodeIds(request);
        }
        
        public Opc.Ua.ResponseHeader TranslateBrowsePathsToNodeIds(Opc.Ua.RequestHeader RequestHeader, Opc.Ua.ListOfBrowsePath BrowsePaths, out Opc.Ua.ListOfBrowsePathResult Results, out Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos)
        {
            Opc.Ua.TranslateBrowsePathsToNodeIdsMessage inValue = new Opc.Ua.TranslateBrowsePathsToNodeIdsMessage();
            inValue.RequestHeader = RequestHeader;
            inValue.BrowsePaths = BrowsePaths;
            Opc.Ua.TranslateBrowsePathsToNodeIdsResponseMessage retVal = ((Opc.Ua.ISessionEndpoint)(this)).TranslateBrowsePathsToNodeIds(inValue);
            Results = retVal.Results;
            DiagnosticInfos = retVal.DiagnosticInfos;
            return retVal.ResponseHeader;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Opc.Ua.RegisterNodesResponseMessage Opc.Ua.ISessionEndpoint.RegisterNodes(Opc.Ua.RegisterNodesMessage request)
        {
            return base.Channel.RegisterNodes(request);
        }
        
        public Opc.Ua.ResponseHeader RegisterNodes(Opc.Ua.RequestHeader RequestHeader, Opc.Ua.ListOfNodeId NodesToRegister, out Opc.Ua.ListOfNodeId RegisteredNodeIds)
        {
            Opc.Ua.RegisterNodesMessage inValue = new Opc.Ua.RegisterNodesMessage();
            inValue.RequestHeader = RequestHeader;
            inValue.NodesToRegister = NodesToRegister;
            Opc.Ua.RegisterNodesResponseMessage retVal = ((Opc.Ua.ISessionEndpoint)(this)).RegisterNodes(inValue);
            RegisteredNodeIds = retVal.RegisteredNodeIds;
            return retVal.ResponseHeader;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Opc.Ua.UnregisterNodesResponseMessage Opc.Ua.ISessionEndpoint.UnregisterNodes(Opc.Ua.UnregisterNodesMessage request)
        {
            return base.Channel.UnregisterNodes(request);
        }
        
        public Opc.Ua.ResponseHeader UnregisterNodes(Opc.Ua.RequestHeader RequestHeader, Opc.Ua.ListOfNodeId NodesToUnregister)
        {
            Opc.Ua.UnregisterNodesMessage inValue = new Opc.Ua.UnregisterNodesMessage();
            inValue.RequestHeader = RequestHeader;
            inValue.NodesToUnregister = NodesToUnregister;
            Opc.Ua.UnregisterNodesResponseMessage retVal = ((Opc.Ua.ISessionEndpoint)(this)).UnregisterNodes(inValue);
            return retVal.ResponseHeader;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Opc.Ua.QueryFirstResponseMessage Opc.Ua.ISessionEndpoint.QueryFirst(Opc.Ua.QueryFirstMessage request)
        {
            return base.Channel.QueryFirst(request);
        }
        
        public Opc.Ua.ResponseHeader QueryFirst(Opc.Ua.RequestHeader RequestHeader, Opc.Ua.ViewDescription View, Opc.Ua.ListOfNodeTypeDescription NodeTypes, Opc.Ua.ContentFilter Filter, uint MaxDataSetsToReturn, uint MaxReferencesToReturn, out Opc.Ua.ListOfQueryDataSet QueryDataSets, out byte[] ContinuationPoint, out Opc.Ua.ListOfParsingResult ParsingResults, out Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos, out Opc.Ua.ContentFilterResult FilterResult)
        {
            Opc.Ua.QueryFirstMessage inValue = new Opc.Ua.QueryFirstMessage();
            inValue.RequestHeader = RequestHeader;
            inValue.View = View;
            inValue.NodeTypes = NodeTypes;
            inValue.Filter = Filter;
            inValue.MaxDataSetsToReturn = MaxDataSetsToReturn;
            inValue.MaxReferencesToReturn = MaxReferencesToReturn;
            Opc.Ua.QueryFirstResponseMessage retVal = ((Opc.Ua.ISessionEndpoint)(this)).QueryFirst(inValue);
            QueryDataSets = retVal.QueryDataSets;
            ContinuationPoint = retVal.ContinuationPoint;
            ParsingResults = retVal.ParsingResults;
            DiagnosticInfos = retVal.DiagnosticInfos;
            FilterResult = retVal.FilterResult;
            return retVal.ResponseHeader;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Opc.Ua.QueryNextResponseMessage Opc.Ua.ISessionEndpoint.QueryNext(Opc.Ua.QueryNextMessage request)
        {
            return base.Channel.QueryNext(request);
        }
        
        public Opc.Ua.ResponseHeader QueryNext(Opc.Ua.RequestHeader RequestHeader, bool ReleaseContinuationPoint, byte[] ContinuationPoint, out Opc.Ua.ListOfQueryDataSet QueryDataSets, out byte[] RevisedContinuationPoint)
        {
            Opc.Ua.QueryNextMessage inValue = new Opc.Ua.QueryNextMessage();
            inValue.RequestHeader = RequestHeader;
            inValue.ReleaseContinuationPoint = ReleaseContinuationPoint;
            inValue.ContinuationPoint = ContinuationPoint;
            Opc.Ua.QueryNextResponseMessage retVal = ((Opc.Ua.ISessionEndpoint)(this)).QueryNext(inValue);
            QueryDataSets = retVal.QueryDataSets;
            RevisedContinuationPoint = retVal.RevisedContinuationPoint;
            return retVal.ResponseHeader;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Opc.Ua.ReadResponseMessage Opc.Ua.ISessionEndpoint.Read(Opc.Ua.ReadMessage request)
        {
            return base.Channel.Read(request);
        }
        
        public Opc.Ua.ResponseHeader Read(Opc.Ua.RequestHeader RequestHeader, double MaxAge, Opc.Ua.TimestampsToReturn TimestampsToReturn, Opc.Ua.ListOfReadValueId NodesToRead, out Opc.Ua.ListOfDataValue Results, out Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos)
        {
            Opc.Ua.ReadMessage inValue = new Opc.Ua.ReadMessage();
            inValue.RequestHeader = RequestHeader;
            inValue.MaxAge = MaxAge;
            inValue.TimestampsToReturn = TimestampsToReturn;
            inValue.NodesToRead = NodesToRead;
            Opc.Ua.ReadResponseMessage retVal = ((Opc.Ua.ISessionEndpoint)(this)).Read(inValue);
            Results = retVal.Results;
            DiagnosticInfos = retVal.DiagnosticInfos;
            return retVal.ResponseHeader;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Opc.Ua.HistoryReadResponseMessage Opc.Ua.ISessionEndpoint.HistoryRead(Opc.Ua.HistoryReadMessage request)
        {
            return base.Channel.HistoryRead(request);
        }
        
        public Opc.Ua.ResponseHeader HistoryRead(Opc.Ua.RequestHeader RequestHeader, Opc.Ua.ExtensionObject HistoryReadDetails, Opc.Ua.TimestampsToReturn TimestampsToReturn, bool ReleaseContinuationPoints, Opc.Ua.ListOfHistoryReadValueId NodesToRead, out Opc.Ua.ListOfHistoryReadResult Results, out Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos)
        {
            Opc.Ua.HistoryReadMessage inValue = new Opc.Ua.HistoryReadMessage();
            inValue.RequestHeader = RequestHeader;
            inValue.HistoryReadDetails = HistoryReadDetails;
            inValue.TimestampsToReturn = TimestampsToReturn;
            inValue.ReleaseContinuationPoints = ReleaseContinuationPoints;
            inValue.NodesToRead = NodesToRead;
            Opc.Ua.HistoryReadResponseMessage retVal = ((Opc.Ua.ISessionEndpoint)(this)).HistoryRead(inValue);
            Results = retVal.Results;
            DiagnosticInfos = retVal.DiagnosticInfos;
            return retVal.ResponseHeader;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Opc.Ua.WriteResponseMessage Opc.Ua.ISessionEndpoint.Write(Opc.Ua.WriteMessage request)
        {
            return base.Channel.Write(request);
        }
        
        public Opc.Ua.ResponseHeader Write(Opc.Ua.RequestHeader RequestHeader, Opc.Ua.ListOfWriteValue NodesToWrite, out Opc.Ua.ListOfStatusCode Results, out Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos)
        {
            Opc.Ua.WriteMessage inValue = new Opc.Ua.WriteMessage();
            inValue.RequestHeader = RequestHeader;
            inValue.NodesToWrite = NodesToWrite;
            Opc.Ua.WriteResponseMessage retVal = ((Opc.Ua.ISessionEndpoint)(this)).Write(inValue);
            Results = retVal.Results;
            DiagnosticInfos = retVal.DiagnosticInfos;
            return retVal.ResponseHeader;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Opc.Ua.HistoryUpdateResponseMessage Opc.Ua.ISessionEndpoint.HistoryUpdate(Opc.Ua.HistoryUpdateMessage request)
        {
            return base.Channel.HistoryUpdate(request);
        }
        
        public Opc.Ua.ResponseHeader HistoryUpdate(Opc.Ua.RequestHeader RequestHeader, Opc.Ua.ListOfExtensionObject HistoryUpdateDetails, out Opc.Ua.ListOfHistoryUpdateResult Results, out Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos)
        {
            Opc.Ua.HistoryUpdateMessage inValue = new Opc.Ua.HistoryUpdateMessage();
            inValue.RequestHeader = RequestHeader;
            inValue.HistoryUpdateDetails = HistoryUpdateDetails;
            Opc.Ua.HistoryUpdateResponseMessage retVal = ((Opc.Ua.ISessionEndpoint)(this)).HistoryUpdate(inValue);
            Results = retVal.Results;
            DiagnosticInfos = retVal.DiagnosticInfos;
            return retVal.ResponseHeader;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Opc.Ua.CallResponseMessage Opc.Ua.ISessionEndpoint.Call(Opc.Ua.CallMessage request)
        {
            return base.Channel.Call(request);
        }
        
        public Opc.Ua.ResponseHeader Call(Opc.Ua.RequestHeader RequestHeader, Opc.Ua.ListOfCallMethodRequest MethodsToCall, out Opc.Ua.ListOfCallMethodResult Results, out Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos)
        {
            Opc.Ua.CallMessage inValue = new Opc.Ua.CallMessage();
            inValue.RequestHeader = RequestHeader;
            inValue.MethodsToCall = MethodsToCall;
            Opc.Ua.CallResponseMessage retVal = ((Opc.Ua.ISessionEndpoint)(this)).Call(inValue);
            Results = retVal.Results;
            DiagnosticInfos = retVal.DiagnosticInfos;
            return retVal.ResponseHeader;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Opc.Ua.CreateMonitoredItemsResponseMessage Opc.Ua.ISessionEndpoint.CreateMonitoredItems(Opc.Ua.CreateMonitoredItemsMessage request)
        {
            return base.Channel.CreateMonitoredItems(request);
        }
        
        public Opc.Ua.ResponseHeader CreateMonitoredItems(Opc.Ua.RequestHeader RequestHeader, uint SubscriptionId, Opc.Ua.TimestampsToReturn TimestampsToReturn, Opc.Ua.ListOfMonitoredItemCreateRequest ItemsToCreate, out Opc.Ua.ListOfMonitoredItemCreateResult Results, out Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos)
        {
            Opc.Ua.CreateMonitoredItemsMessage inValue = new Opc.Ua.CreateMonitoredItemsMessage();
            inValue.RequestHeader = RequestHeader;
            inValue.SubscriptionId = SubscriptionId;
            inValue.TimestampsToReturn = TimestampsToReturn;
            inValue.ItemsToCreate = ItemsToCreate;
            Opc.Ua.CreateMonitoredItemsResponseMessage retVal = ((Opc.Ua.ISessionEndpoint)(this)).CreateMonitoredItems(inValue);
            Results = retVal.Results;
            DiagnosticInfos = retVal.DiagnosticInfos;
            return retVal.ResponseHeader;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Opc.Ua.ModifyMonitoredItemsResponseMessage Opc.Ua.ISessionEndpoint.ModifyMonitoredItems(Opc.Ua.ModifyMonitoredItemsMessage request)
        {
            return base.Channel.ModifyMonitoredItems(request);
        }
        
        public Opc.Ua.ResponseHeader ModifyMonitoredItems(Opc.Ua.RequestHeader RequestHeader, uint SubscriptionId, Opc.Ua.TimestampsToReturn TimestampsToReturn, Opc.Ua.ListOfMonitoredItemModifyRequest ItemsToModify, out Opc.Ua.ListOfMonitoredItemModifyResult Results, out Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos)
        {
            Opc.Ua.ModifyMonitoredItemsMessage inValue = new Opc.Ua.ModifyMonitoredItemsMessage();
            inValue.RequestHeader = RequestHeader;
            inValue.SubscriptionId = SubscriptionId;
            inValue.TimestampsToReturn = TimestampsToReturn;
            inValue.ItemsToModify = ItemsToModify;
            Opc.Ua.ModifyMonitoredItemsResponseMessage retVal = ((Opc.Ua.ISessionEndpoint)(this)).ModifyMonitoredItems(inValue);
            Results = retVal.Results;
            DiagnosticInfos = retVal.DiagnosticInfos;
            return retVal.ResponseHeader;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Opc.Ua.SetMonitoringModeResponseMessage Opc.Ua.ISessionEndpoint.SetMonitoringMode(Opc.Ua.SetMonitoringModeMessage request)
        {
            return base.Channel.SetMonitoringMode(request);
        }
        
        public Opc.Ua.ResponseHeader SetMonitoringMode(Opc.Ua.RequestHeader RequestHeader, uint SubscriptionId, Opc.Ua.MonitoringMode MonitoringMode, Opc.Ua.ListOfUInt32 MonitoredItemIds, out Opc.Ua.ListOfStatusCode Results, out Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos)
        {
            Opc.Ua.SetMonitoringModeMessage inValue = new Opc.Ua.SetMonitoringModeMessage();
            inValue.RequestHeader = RequestHeader;
            inValue.SubscriptionId = SubscriptionId;
            inValue.MonitoringMode = MonitoringMode;
            inValue.MonitoredItemIds = MonitoredItemIds;
            Opc.Ua.SetMonitoringModeResponseMessage retVal = ((Opc.Ua.ISessionEndpoint)(this)).SetMonitoringMode(inValue);
            Results = retVal.Results;
            DiagnosticInfos = retVal.DiagnosticInfos;
            return retVal.ResponseHeader;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Opc.Ua.SetTriggeringResponseMessage Opc.Ua.ISessionEndpoint.SetTriggering(Opc.Ua.SetTriggeringMessage request)
        {
            return base.Channel.SetTriggering(request);
        }
        
        public Opc.Ua.ResponseHeader SetTriggering(Opc.Ua.RequestHeader RequestHeader, uint SubscriptionId, uint TriggeringItemId, Opc.Ua.ListOfUInt32 LinksToAdd, Opc.Ua.ListOfUInt32 LinksToRemove, out Opc.Ua.ListOfStatusCode AddResults, out Opc.Ua.ListOfDiagnosticInfo AddDiagnosticInfos, out Opc.Ua.ListOfStatusCode RemoveResults, out Opc.Ua.ListOfDiagnosticInfo RemoveDiagnosticInfos)
        {
            Opc.Ua.SetTriggeringMessage inValue = new Opc.Ua.SetTriggeringMessage();
            inValue.RequestHeader = RequestHeader;
            inValue.SubscriptionId = SubscriptionId;
            inValue.TriggeringItemId = TriggeringItemId;
            inValue.LinksToAdd = LinksToAdd;
            inValue.LinksToRemove = LinksToRemove;
            Opc.Ua.SetTriggeringResponseMessage retVal = ((Opc.Ua.ISessionEndpoint)(this)).SetTriggering(inValue);
            AddResults = retVal.AddResults;
            AddDiagnosticInfos = retVal.AddDiagnosticInfos;
            RemoveResults = retVal.RemoveResults;
            RemoveDiagnosticInfos = retVal.RemoveDiagnosticInfos;
            return retVal.ResponseHeader;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Opc.Ua.DeleteMonitoredItemsResponseMessage Opc.Ua.ISessionEndpoint.DeleteMonitoredItems(Opc.Ua.DeleteMonitoredItemsMessage request)
        {
            return base.Channel.DeleteMonitoredItems(request);
        }
        
        public Opc.Ua.ResponseHeader DeleteMonitoredItems(Opc.Ua.RequestHeader RequestHeader, uint SubscriptionId, Opc.Ua.ListOfUInt32 MonitoredItemIds, out Opc.Ua.ListOfStatusCode Results, out Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos)
        {
            Opc.Ua.DeleteMonitoredItemsMessage inValue = new Opc.Ua.DeleteMonitoredItemsMessage();
            inValue.RequestHeader = RequestHeader;
            inValue.SubscriptionId = SubscriptionId;
            inValue.MonitoredItemIds = MonitoredItemIds;
            Opc.Ua.DeleteMonitoredItemsResponseMessage retVal = ((Opc.Ua.ISessionEndpoint)(this)).DeleteMonitoredItems(inValue);
            Results = retVal.Results;
            DiagnosticInfos = retVal.DiagnosticInfos;
            return retVal.ResponseHeader;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Opc.Ua.CreateSubscriptionResponseMessage Opc.Ua.ISessionEndpoint.CreateSubscription(Opc.Ua.CreateSubscriptionMessage request)
        {
            return base.Channel.CreateSubscription(request);
        }
        
        public Opc.Ua.ResponseHeader CreateSubscription(Opc.Ua.RequestHeader RequestHeader, double RequestedPublishingInterval, uint RequestedLifetimeCount, uint RequestedMaxKeepAliveCount, uint MaxNotificationsPerPublish, bool PublishingEnabled, byte Priority, out uint SubscriptionId, out double RevisedPublishingInterval, out uint RevisedLifetimeCount, out uint RevisedMaxKeepAliveCount)
        {
            Opc.Ua.CreateSubscriptionMessage inValue = new Opc.Ua.CreateSubscriptionMessage();
            inValue.RequestHeader = RequestHeader;
            inValue.RequestedPublishingInterval = RequestedPublishingInterval;
            inValue.RequestedLifetimeCount = RequestedLifetimeCount;
            inValue.RequestedMaxKeepAliveCount = RequestedMaxKeepAliveCount;
            inValue.MaxNotificationsPerPublish = MaxNotificationsPerPublish;
            inValue.PublishingEnabled = PublishingEnabled;
            inValue.Priority = Priority;
            Opc.Ua.CreateSubscriptionResponseMessage retVal = ((Opc.Ua.ISessionEndpoint)(this)).CreateSubscription(inValue);
            SubscriptionId = retVal.SubscriptionId;
            RevisedPublishingInterval = retVal.RevisedPublishingInterval;
            RevisedLifetimeCount = retVal.RevisedLifetimeCount;
            RevisedMaxKeepAliveCount = retVal.RevisedMaxKeepAliveCount;
            return retVal.ResponseHeader;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Opc.Ua.ModifySubscriptionResponseMessage Opc.Ua.ISessionEndpoint.ModifySubscription(Opc.Ua.ModifySubscriptionMessage request)
        {
            return base.Channel.ModifySubscription(request);
        }
        
        public Opc.Ua.ResponseHeader ModifySubscription(Opc.Ua.RequestHeader RequestHeader, uint SubscriptionId, double RequestedPublishingInterval, uint RequestedLifetimeCount, uint RequestedMaxKeepAliveCount, uint MaxNotificationsPerPublish, byte Priority, out double RevisedPublishingInterval, out uint RevisedLifetimeCount, out uint RevisedMaxKeepAliveCount)
        {
            Opc.Ua.ModifySubscriptionMessage inValue = new Opc.Ua.ModifySubscriptionMessage();
            inValue.RequestHeader = RequestHeader;
            inValue.SubscriptionId = SubscriptionId;
            inValue.RequestedPublishingInterval = RequestedPublishingInterval;
            inValue.RequestedLifetimeCount = RequestedLifetimeCount;
            inValue.RequestedMaxKeepAliveCount = RequestedMaxKeepAliveCount;
            inValue.MaxNotificationsPerPublish = MaxNotificationsPerPublish;
            inValue.Priority = Priority;
            Opc.Ua.ModifySubscriptionResponseMessage retVal = ((Opc.Ua.ISessionEndpoint)(this)).ModifySubscription(inValue);
            RevisedPublishingInterval = retVal.RevisedPublishingInterval;
            RevisedLifetimeCount = retVal.RevisedLifetimeCount;
            RevisedMaxKeepAliveCount = retVal.RevisedMaxKeepAliveCount;
            return retVal.ResponseHeader;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Opc.Ua.SetPublishingModeResponseMessage Opc.Ua.ISessionEndpoint.SetPublishingMode(Opc.Ua.SetPublishingModeMessage request)
        {
            return base.Channel.SetPublishingMode(request);
        }
        
        public Opc.Ua.ResponseHeader SetPublishingMode(Opc.Ua.RequestHeader RequestHeader, bool PublishingEnabled, Opc.Ua.ListOfUInt32 SubscriptionIds, out Opc.Ua.ListOfStatusCode Results, out Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos)
        {
            Opc.Ua.SetPublishingModeMessage inValue = new Opc.Ua.SetPublishingModeMessage();
            inValue.RequestHeader = RequestHeader;
            inValue.PublishingEnabled = PublishingEnabled;
            inValue.SubscriptionIds = SubscriptionIds;
            Opc.Ua.SetPublishingModeResponseMessage retVal = ((Opc.Ua.ISessionEndpoint)(this)).SetPublishingMode(inValue);
            Results = retVal.Results;
            DiagnosticInfos = retVal.DiagnosticInfos;
            return retVal.ResponseHeader;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Opc.Ua.PublishResponseMessage Opc.Ua.ISessionEndpoint.Publish(Opc.Ua.PublishMessage request)
        {
            return base.Channel.Publish(request);
        }
        
        public Opc.Ua.ResponseHeader Publish(Opc.Ua.RequestHeader RequestHeader, Opc.Ua.ListOfSubscriptionAcknowledgement SubscriptionAcknowledgements, out uint SubscriptionId, out Opc.Ua.ListOfUInt32 AvailableSequenceNumbers, out bool MoreNotifications, out Opc.Ua.NotificationMessage NotificationMessage, out Opc.Ua.ListOfStatusCode Results, out Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos)
        {
            Opc.Ua.PublishMessage inValue = new Opc.Ua.PublishMessage();
            inValue.RequestHeader = RequestHeader;
            inValue.SubscriptionAcknowledgements = SubscriptionAcknowledgements;
            Opc.Ua.PublishResponseMessage retVal = ((Opc.Ua.ISessionEndpoint)(this)).Publish(inValue);
            SubscriptionId = retVal.SubscriptionId;
            AvailableSequenceNumbers = retVal.AvailableSequenceNumbers;
            MoreNotifications = retVal.MoreNotifications;
            NotificationMessage = retVal.NotificationMessage;
            Results = retVal.Results;
            DiagnosticInfos = retVal.DiagnosticInfos;
            return retVal.ResponseHeader;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Opc.Ua.RepublishResponseMessage Opc.Ua.ISessionEndpoint.Republish(Opc.Ua.RepublishMessage request)
        {
            return base.Channel.Republish(request);
        }
        
        public Opc.Ua.ResponseHeader Republish(Opc.Ua.RequestHeader RequestHeader, uint SubscriptionId, uint RetransmitSequenceNumber, out Opc.Ua.NotificationMessage NotificationMessage)
        {
            Opc.Ua.RepublishMessage inValue = new Opc.Ua.RepublishMessage();
            inValue.RequestHeader = RequestHeader;
            inValue.SubscriptionId = SubscriptionId;
            inValue.RetransmitSequenceNumber = RetransmitSequenceNumber;
            Opc.Ua.RepublishResponseMessage retVal = ((Opc.Ua.ISessionEndpoint)(this)).Republish(inValue);
            NotificationMessage = retVal.NotificationMessage;
            return retVal.ResponseHeader;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Opc.Ua.TransferSubscriptionsResponseMessage Opc.Ua.ISessionEndpoint.TransferSubscriptions(Opc.Ua.TransferSubscriptionsMessage request)
        {
            return base.Channel.TransferSubscriptions(request);
        }
        
        public Opc.Ua.ResponseHeader TransferSubscriptions(Opc.Ua.RequestHeader RequestHeader, Opc.Ua.ListOfUInt32 SubscriptionIds, bool SendInitialValues, out Opc.Ua.ListOfTransferResult Results, out Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos)
        {
            Opc.Ua.TransferSubscriptionsMessage inValue = new Opc.Ua.TransferSubscriptionsMessage();
            inValue.RequestHeader = RequestHeader;
            inValue.SubscriptionIds = SubscriptionIds;
            inValue.SendInitialValues = SendInitialValues;
            Opc.Ua.TransferSubscriptionsResponseMessage retVal = ((Opc.Ua.ISessionEndpoint)(this)).TransferSubscriptions(inValue);
            Results = retVal.Results;
            DiagnosticInfos = retVal.DiagnosticInfos;
            return retVal.ResponseHeader;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Opc.Ua.DeleteSubscriptionsResponseMessage Opc.Ua.ISessionEndpoint.DeleteSubscriptions(Opc.Ua.DeleteSubscriptionsMessage request)
        {
            return base.Channel.DeleteSubscriptions(request);
        }
        
        public Opc.Ua.ResponseHeader DeleteSubscriptions(Opc.Ua.RequestHeader RequestHeader, Opc.Ua.ListOfUInt32 SubscriptionIds, out Opc.Ua.ListOfStatusCode Results, out Opc.Ua.ListOfDiagnosticInfo DiagnosticInfos)
        {
            Opc.Ua.DeleteSubscriptionsMessage inValue = new Opc.Ua.DeleteSubscriptionsMessage();
            inValue.RequestHeader = RequestHeader;
            inValue.SubscriptionIds = SubscriptionIds;
            Opc.Ua.DeleteSubscriptionsResponseMessage retVal = ((Opc.Ua.ISessionEndpoint)(this)).DeleteSubscriptions(inValue);
            Results = retVal.Results;
            DiagnosticInfos = retVal.DiagnosticInfos;
            return retVal.ResponseHeader;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Services.wsdl", ConfigurationName="Opc.Ua.IDiscoveryEndpoint")]
    public interface IDiscoveryEndpoint
    {
        
        // CODEGEN: Generating message contract since the operation InvokeService is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/InvokeService", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/InvokeServiceResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Opc.Ua.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/InvokeServiceFault", Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
        Opc.Ua.InvokeServiceResponseMessage InvokeService(Opc.Ua.InvokeServiceMessage request);
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://opcfoundation.org/UA/2008/02/Types.xsd) of message FindServersMessage does not match the default value (http://opcfoundation.org/UA/2008/02/Services.wsdl)
        [System.ServiceModel.OperationContractAttribute(Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/FindServers", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/FindServersResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Opc.Ua.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/FindServersFault", Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
        Opc.Ua.FindServersResponseMessage FindServers(Opc.Ua.FindServersMessage request);
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://opcfoundation.org/UA/2008/02/Types.xsd) of message GetEndpointsMessage does not match the default value (http://opcfoundation.org/UA/2008/02/Services.wsdl)
        [System.ServiceModel.OperationContractAttribute(Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/GetEndpoints", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/GetEndpointsResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Opc.Ua.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/GetEndpointsFault", Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
        Opc.Ua.GetEndpointsResponseMessage GetEndpoints(Opc.Ua.GetEndpointsMessage request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="FindServersRequest", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class FindServersMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.RequestHeader RequestHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public string EndpointUrl;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=2)]
        public Opc.Ua.ListOfString LocaleIds;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=3)]
        public Opc.Ua.ListOfString ServerUris;
        
        public FindServersMessage()
        {
        }
        
        public FindServersMessage(Opc.Ua.RequestHeader RequestHeader, string EndpointUrl, Opc.Ua.ListOfString LocaleIds, Opc.Ua.ListOfString ServerUris)
        {
            this.RequestHeader = RequestHeader;
            this.EndpointUrl = EndpointUrl;
            this.LocaleIds = LocaleIds;
            this.ServerUris = ServerUris;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="FindServersResponse", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class FindServersResponseMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.ResponseHeader ResponseHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public Opc.Ua.ListOfApplicationDescription Servers;
        
        public FindServersResponseMessage()
        {
        }
        
        public FindServersResponseMessage(Opc.Ua.ResponseHeader ResponseHeader, Opc.Ua.ListOfApplicationDescription Servers)
        {
            this.ResponseHeader = ResponseHeader;
            this.Servers = Servers;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetEndpointsRequest", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class GetEndpointsMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.RequestHeader RequestHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public string EndpointUrl;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=2)]
        public Opc.Ua.ListOfString LocaleIds;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=3)]
        public Opc.Ua.ListOfString ProfileUris;
        
        public GetEndpointsMessage()
        {
        }
        
        public GetEndpointsMessage(Opc.Ua.RequestHeader RequestHeader, string EndpointUrl, Opc.Ua.ListOfString LocaleIds, Opc.Ua.ListOfString ProfileUris)
        {
            this.RequestHeader = RequestHeader;
            this.EndpointUrl = EndpointUrl;
            this.LocaleIds = LocaleIds;
            this.ProfileUris = ProfileUris;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetEndpointsResponse", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class GetEndpointsResponseMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.ResponseHeader ResponseHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public Opc.Ua.ListOfEndpointDescription Endpoints;
        
        public GetEndpointsResponseMessage()
        {
        }
        
        public GetEndpointsResponseMessage(Opc.Ua.ResponseHeader ResponseHeader, Opc.Ua.ListOfEndpointDescription Endpoints)
        {
            this.ResponseHeader = ResponseHeader;
            this.Endpoints = Endpoints;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface IDiscoveryEndpointChannel : Opc.Ua.IDiscoveryEndpoint, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class DiscoveryEndpointClient : System.ServiceModel.ClientBase<Opc.Ua.IDiscoveryEndpoint>, Opc.Ua.IDiscoveryEndpoint
    {
        
        public DiscoveryEndpointClient()
        {
        }
        
        public DiscoveryEndpointClient(string endpointConfigurationName) : 
                base(endpointConfigurationName)
        {
        }
        
        public DiscoveryEndpointClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }
        
        public DiscoveryEndpointClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }
        
        public DiscoveryEndpointClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Opc.Ua.InvokeServiceResponseMessage Opc.Ua.IDiscoveryEndpoint.InvokeService(Opc.Ua.InvokeServiceMessage request)
        {
            return base.Channel.InvokeService(request);
        }
        
        public byte[] InvokeService(byte[] InvokeServiceRequest)
        {
            Opc.Ua.InvokeServiceMessage inValue = new Opc.Ua.InvokeServiceMessage();
            inValue.InvokeServiceRequest = InvokeServiceRequest;
            Opc.Ua.InvokeServiceResponseMessage retVal = ((Opc.Ua.IDiscoveryEndpoint)(this)).InvokeService(inValue);
            return retVal.InvokeServiceResponse;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Opc.Ua.FindServersResponseMessage Opc.Ua.IDiscoveryEndpoint.FindServers(Opc.Ua.FindServersMessage request)
        {
            return base.Channel.FindServers(request);
        }
        
        public Opc.Ua.ResponseHeader FindServers(Opc.Ua.RequestHeader RequestHeader, string EndpointUrl, Opc.Ua.ListOfString LocaleIds, Opc.Ua.ListOfString ServerUris, out Opc.Ua.ListOfApplicationDescription Servers)
        {
            Opc.Ua.FindServersMessage inValue = new Opc.Ua.FindServersMessage();
            inValue.RequestHeader = RequestHeader;
            inValue.EndpointUrl = EndpointUrl;
            inValue.LocaleIds = LocaleIds;
            inValue.ServerUris = ServerUris;
            Opc.Ua.FindServersResponseMessage retVal = ((Opc.Ua.IDiscoveryEndpoint)(this)).FindServers(inValue);
            Servers = retVal.Servers;
            return retVal.ResponseHeader;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Opc.Ua.GetEndpointsResponseMessage Opc.Ua.IDiscoveryEndpoint.GetEndpoints(Opc.Ua.GetEndpointsMessage request)
        {
            return base.Channel.GetEndpoints(request);
        }
        
        public Opc.Ua.ResponseHeader GetEndpoints(Opc.Ua.RequestHeader RequestHeader, string EndpointUrl, Opc.Ua.ListOfString LocaleIds, Opc.Ua.ListOfString ProfileUris, out Opc.Ua.ListOfEndpointDescription Endpoints)
        {
            Opc.Ua.GetEndpointsMessage inValue = new Opc.Ua.GetEndpointsMessage();
            inValue.RequestHeader = RequestHeader;
            inValue.EndpointUrl = EndpointUrl;
            inValue.LocaleIds = LocaleIds;
            inValue.ProfileUris = ProfileUris;
            Opc.Ua.GetEndpointsResponseMessage retVal = ((Opc.Ua.IDiscoveryEndpoint)(this)).GetEndpoints(inValue);
            Endpoints = retVal.Endpoints;
            return retVal.ResponseHeader;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Services.wsdl", ConfigurationName="Opc.Ua.IRegistrationEndpoint")]
    public interface IRegistrationEndpoint
    {
        
        // CODEGEN: Generating message contract since the operation InvokeService is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/InvokeService", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/InvokeServiceResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Opc.Ua.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/InvokeServiceFault", Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
        Opc.Ua.InvokeServiceResponseMessage InvokeService(Opc.Ua.InvokeServiceMessage request);
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://opcfoundation.org/UA/2008/02/Types.xsd) of message RegisterServerMessage does not match the default value (http://opcfoundation.org/UA/2008/02/Services.wsdl)
        [System.ServiceModel.OperationContractAttribute(Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/RegisterServer", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/RegisterServerResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Opc.Ua.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/RegisterServerFault", Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
        Opc.Ua.RegisterServerResponseMessage RegisterServer(Opc.Ua.RegisterServerMessage request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="RegisterServerRequest", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class RegisterServerMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.RequestHeader RequestHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=1)]
        public Opc.Ua.RegisteredServer Server;
        
        public RegisterServerMessage()
        {
        }
        
        public RegisterServerMessage(Opc.Ua.RequestHeader RequestHeader, Opc.Ua.RegisteredServer Server)
        {
            this.RequestHeader = RequestHeader;
            this.Server = Server;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="RegisterServerResponse", WrapperNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsWrapped=true)]
    public partial class RegisterServerResponseMessage
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
        public Opc.Ua.ResponseHeader ResponseHeader;
        
        public RegisterServerResponseMessage()
        {
        }
        
        public RegisterServerResponseMessage(Opc.Ua.ResponseHeader ResponseHeader)
        {
            this.ResponseHeader = ResponseHeader;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface IRegistrationEndpointChannel : Opc.Ua.IRegistrationEndpoint, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class RegistrationEndpointClient : System.ServiceModel.ClientBase<Opc.Ua.IRegistrationEndpoint>, Opc.Ua.IRegistrationEndpoint
    {
        
        public RegistrationEndpointClient()
        {
        }
        
        public RegistrationEndpointClient(string endpointConfigurationName) : 
                base(endpointConfigurationName)
        {
        }
        
        public RegistrationEndpointClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }
        
        public RegistrationEndpointClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }
        
        public RegistrationEndpointClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Opc.Ua.InvokeServiceResponseMessage Opc.Ua.IRegistrationEndpoint.InvokeService(Opc.Ua.InvokeServiceMessage request)
        {
            return base.Channel.InvokeService(request);
        }
        
        public byte[] InvokeService(byte[] InvokeServiceRequest)
        {
            Opc.Ua.InvokeServiceMessage inValue = new Opc.Ua.InvokeServiceMessage();
            inValue.InvokeServiceRequest = InvokeServiceRequest;
            Opc.Ua.InvokeServiceResponseMessage retVal = ((Opc.Ua.IRegistrationEndpoint)(this)).InvokeService(inValue);
            return retVal.InvokeServiceResponse;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Opc.Ua.RegisterServerResponseMessage Opc.Ua.IRegistrationEndpoint.RegisterServer(Opc.Ua.RegisterServerMessage request)
        {
            return base.Channel.RegisterServer(request);
        }
        
        public Opc.Ua.ResponseHeader RegisterServer(Opc.Ua.RequestHeader RequestHeader, Opc.Ua.RegisteredServer Server)
        {
            Opc.Ua.RegisterServerMessage inValue = new Opc.Ua.RegisterServerMessage();
            inValue.RequestHeader = RequestHeader;
            inValue.Server = Server;
            Opc.Ua.RegisterServerResponseMessage retVal = ((Opc.Ua.IRegistrationEndpoint)(this)).RegisterServer(inValue);
            return retVal.ResponseHeader;
        }
    }
}
