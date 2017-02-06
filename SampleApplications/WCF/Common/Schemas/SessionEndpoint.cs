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

[assembly: System.Runtime.Serialization.ContractNamespaceAttribute("http://opcfoundation.org/UA/2008/02/Types.xsd", ClrNamespace="opcfoundation.org.UA._2008._02.Types.xsd")]

namespace opcfoundation.org.UA._2008._02.Types.xsd
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EncodeableObject", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.TestStackResponse))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.ServiceFault))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.TestStackExRequest))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.CompositeTestType))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.ScalarTestType))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.ArrayTestType))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.TestStackExResponse))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.CreateSessionRequest))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.ApplicationDescription))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.CreateSessionResponse))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.EndpointDescription))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.UserTokenPolicy))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.SignedSoftwareCertificate))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.SignatureData))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.ActivateSessionRequest))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.ActivateSessionResponse))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.CloseSessionRequest))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.CloseSessionResponse))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.CancelRequest))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.CancelResponse))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.AddNodesRequest))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.AddNodesItem))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.AddNodesResponse))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.AddNodesResult))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.AddReferencesRequest))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.AddReferencesItem))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.AddReferencesResponse))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.DeleteNodesRequest))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.DeleteNodesItem))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.DeleteNodesResponse))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.DeleteReferencesRequest))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.DeleteReferencesItem))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.DeleteReferencesResponse))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.BrowseRequest))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.ViewDescription))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.BrowseDescription))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.BrowseResponse))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.BrowseResult))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.ReferenceDescription))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.BrowseNextRequest))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.BrowseNextResponse))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.TranslateBrowsePathsToNodeIdsRequest))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.BrowsePath))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.RelativePath))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.RelativePathElement))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.TranslateBrowsePathsToNodeIdsResponse))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.BrowsePathResult))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.BrowsePathTarget))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.RegisterNodesRequest))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.RegisterNodesResponse))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.UnregisterNodesRequest))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.UnregisterNodesResponse))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.QueryFirstRequest))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.NodeTypeDescription))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.QueryDataDescription))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.ContentFilter))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.ContentFilterElement))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.QueryFirstResponse))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.QueryDataSet))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.ParsingResult))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.ContentFilterResult))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.ContentFilterElementResult))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.QueryNextRequest))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.QueryNextResponse))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.ReadRequest))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.ReadValueId))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.ReadResponse))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.HistoryReadRequest))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.HistoryReadValueId))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.HistoryReadResponse))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.HistoryReadResult))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.WriteRequest))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.WriteValue))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.WriteResponse))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.HistoryUpdateRequest))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.HistoryUpdateResponse))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.HistoryUpdateResult))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.CallRequest))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.CallMethodRequest))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.CallResponse))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.CallMethodResult))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.CreateMonitoredItemsRequest))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.MonitoredItemCreateRequest))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.MonitoringParameters))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.CreateMonitoredItemsResponse))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.MonitoredItemCreateResult))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.ModifyMonitoredItemsRequest))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.MonitoredItemModifyRequest))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.ModifyMonitoredItemsResponse))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.MonitoredItemModifyResult))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.SetMonitoringModeRequest))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.SetMonitoringModeResponse))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.SetTriggeringRequest))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.SetTriggeringResponse))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.DeleteMonitoredItemsRequest))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.DeleteMonitoredItemsResponse))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.CreateSubscriptionRequest))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.CreateSubscriptionResponse))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.ModifySubscriptionRequest))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.ModifySubscriptionResponse))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.SetPublishingModeRequest))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.SetPublishingModeResponse))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.PublishRequest))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.SubscriptionAcknowledgement))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.PublishResponse))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.NotificationMessage))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.RepublishRequest))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.RepublishResponse))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.TransferSubscriptionsRequest))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.TransferSubscriptionsResponse))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.TransferResult))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.DeleteSubscriptionsRequest))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.DeleteSubscriptionsResponse))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.FindServersRequest))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.FindServersResponse))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.GetEndpointsRequest))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.GetEndpointsResponse))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.TestStackRequest))]
    public partial class EncodeableObject : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RequestHeader", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class RequestHeader : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.NodeId AuthenticationTokenField;
        
        private System.DateTime TimestampField;
        
        private uint RequestHandleField;
        
        private uint ReturnDiagnosticsField;
        
        private string AuditEntryIdField;
        
        private uint TimeoutHintField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ExtensionObject AdditionalHeaderField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.NodeId AuthenticationToken
        {
            get
            {
                return this.AuthenticationTokenField;
            }
            set
            {
                this.AuthenticationTokenField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Timestamp
        {
            get
            {
                return this.TimestampField;
            }
            set
            {
                this.TimestampField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public uint RequestHandle
        {
            get
            {
                return this.RequestHandleField;
            }
            set
            {
                this.RequestHandleField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public uint ReturnDiagnostics
        {
            get
            {
                return this.ReturnDiagnosticsField;
            }
            set
            {
                this.ReturnDiagnosticsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public string AuditEntryId
        {
            get
            {
                return this.AuditEntryIdField;
            }
            set
            {
                this.AuditEntryIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=5)]
        public uint TimeoutHint
        {
            get
            {
                return this.TimeoutHintField;
            }
            set
            {
                this.TimeoutHintField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=6)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ExtensionObject AdditionalHeader
        {
            get
            {
                return this.AdditionalHeaderField;
            }
            set
            {
                this.AdditionalHeaderField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TestStackResponse", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class TestStackResponse : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeaderField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.Variant OutputField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeader
        {
            get
            {
                return this.ResponseHeaderField;
            }
            set
            {
                this.ResponseHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public opcfoundation.org.UA._2008._02.Types.xsd.Variant Output
        {
            get
            {
                return this.OutputField;
            }
            set
            {
                this.OutputField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ResponseHeader", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class ResponseHeader : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private System.DateTime TimestampField;
        
        private uint RequestHandleField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.StatusCode ServiceResultField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.DiagnosticInfo ServiceDiagnosticsField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfString StringTableField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ExtensionObject AdditionalHeaderField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Timestamp
        {
            get
            {
                return this.TimestampField;
            }
            set
            {
                this.TimestampField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public uint RequestHandle
        {
            get
            {
                return this.RequestHandleField;
            }
            set
            {
                this.RequestHandleField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public opcfoundation.org.UA._2008._02.Types.xsd.StatusCode ServiceResult
        {
            get
            {
                return this.ServiceResultField;
            }
            set
            {
                this.ServiceResultField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public opcfoundation.org.UA._2008._02.Types.xsd.DiagnosticInfo ServiceDiagnostics
        {
            get
            {
                return this.ServiceDiagnosticsField;
            }
            set
            {
                this.ServiceDiagnosticsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfString StringTable
        {
            get
            {
                return this.StringTableField;
            }
            set
            {
                this.StringTableField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=5)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ExtensionObject AdditionalHeader
        {
            get
            {
                return this.AdditionalHeaderField;
            }
            set
            {
                this.AdditionalHeaderField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class ServiceFault : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeaderField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeader
        {
            get
            {
                return this.ResponseHeaderField;
            }
            set
            {
                this.ResponseHeaderField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TestStackExRequest", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class TestStackExRequest : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeaderField;
        
        private uint TestIdField;
        
        private int IterationField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.CompositeTestType InputField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeader
        {
            get
            {
                return this.RequestHeaderField;
            }
            set
            {
                this.RequestHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public uint TestId
        {
            get
            {
                return this.TestIdField;
            }
            set
            {
                this.TestIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public int Iteration
        {
            get
            {
                return this.IterationField;
            }
            set
            {
                this.IterationField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public opcfoundation.org.UA._2008._02.Types.xsd.CompositeTestType Input
        {
            get
            {
                return this.InputField;
            }
            set
            {
                this.InputField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CompositeTestType", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class CompositeTestType : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ScalarTestType Field1Field;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ArrayTestType Field2Field;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ScalarTestType Field1
        {
            get
            {
                return this.Field1Field;
            }
            set
            {
                this.Field1Field = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ArrayTestType Field2
        {
            get
            {
                return this.Field2Field;
            }
            set
            {
                this.Field2Field = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ScalarTestType", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class ScalarTestType : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private bool BooleanField;
        
        private sbyte SByteField;
        
        private byte ByteField;
        
        private short Int16Field;
        
        private ushort UInt16Field;
        
        private int Int32Field;
        
        private uint UInt32Field;
        
        private long Int64Field;
        
        private ulong UInt64Field;
        
        private float FloatField;
        
        private double DoubleField;
        
        private string StringField;
        
        private System.DateTime DateTimeField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.Guid GuidField;
        
        private byte[] ByteStringField;
        
        private System.Xml.XmlElement XmlElementField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.NodeId NodeIdField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ExpandedNodeId ExpandedNodeIdField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.StatusCode StatusCodeField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.DiagnosticInfo DiagnosticInfoField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.QualifiedName QualifiedNameField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.LocalizedText LocalizedTextField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ExtensionObject ExtensionObjectField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.DataValue DataValueField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.EnumeratedTestType EnumeratedValueField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Boolean
        {
            get
            {
                return this.BooleanField;
            }
            set
            {
                this.BooleanField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public sbyte SByte
        {
            get
            {
                return this.SByteField;
            }
            set
            {
                this.SByteField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public byte Byte
        {
            get
            {
                return this.ByteField;
            }
            set
            {
                this.ByteField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public short Int16
        {
            get
            {
                return this.Int16Field;
            }
            set
            {
                this.Int16Field = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public ushort UInt16
        {
            get
            {
                return this.UInt16Field;
            }
            set
            {
                this.UInt16Field = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=5)]
        public int Int32
        {
            get
            {
                return this.Int32Field;
            }
            set
            {
                this.Int32Field = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=6)]
        public uint UInt32
        {
            get
            {
                return this.UInt32Field;
            }
            set
            {
                this.UInt32Field = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=7)]
        public long Int64
        {
            get
            {
                return this.Int64Field;
            }
            set
            {
                this.Int64Field = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=8)]
        public ulong UInt64
        {
            get
            {
                return this.UInt64Field;
            }
            set
            {
                this.UInt64Field = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=9)]
        public float Float
        {
            get
            {
                return this.FloatField;
            }
            set
            {
                this.FloatField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=10)]
        public double Double
        {
            get
            {
                return this.DoubleField;
            }
            set
            {
                this.DoubleField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=11)]
        public string String
        {
            get
            {
                return this.StringField;
            }
            set
            {
                this.StringField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=12)]
        public System.DateTime DateTime
        {
            get
            {
                return this.DateTimeField;
            }
            set
            {
                this.DateTimeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=13)]
        public opcfoundation.org.UA._2008._02.Types.xsd.Guid Guid
        {
            get
            {
                return this.GuidField;
            }
            set
            {
                this.GuidField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=14)]
        public byte[] ByteString
        {
            get
            {
                return this.ByteStringField;
            }
            set
            {
                this.ByteStringField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=15)]
        public System.Xml.XmlElement XmlElement
        {
            get
            {
                return this.XmlElementField;
            }
            set
            {
                this.XmlElementField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=16)]
        public opcfoundation.org.UA._2008._02.Types.xsd.NodeId NodeId
        {
            get
            {
                return this.NodeIdField;
            }
            set
            {
                this.NodeIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=17)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ExpandedNodeId ExpandedNodeId
        {
            get
            {
                return this.ExpandedNodeIdField;
            }
            set
            {
                this.ExpandedNodeIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=18)]
        public opcfoundation.org.UA._2008._02.Types.xsd.StatusCode StatusCode
        {
            get
            {
                return this.StatusCodeField;
            }
            set
            {
                this.StatusCodeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=19)]
        public opcfoundation.org.UA._2008._02.Types.xsd.DiagnosticInfo DiagnosticInfo
        {
            get
            {
                return this.DiagnosticInfoField;
            }
            set
            {
                this.DiagnosticInfoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=20)]
        public opcfoundation.org.UA._2008._02.Types.xsd.QualifiedName QualifiedName
        {
            get
            {
                return this.QualifiedNameField;
            }
            set
            {
                this.QualifiedNameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=21)]
        public opcfoundation.org.UA._2008._02.Types.xsd.LocalizedText LocalizedText
        {
            get
            {
                return this.LocalizedTextField;
            }
            set
            {
                this.LocalizedTextField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=22)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ExtensionObject ExtensionObject
        {
            get
            {
                return this.ExtensionObjectField;
            }
            set
            {
                this.ExtensionObjectField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=23)]
        public opcfoundation.org.UA._2008._02.Types.xsd.DataValue DataValue
        {
            get
            {
                return this.DataValueField;
            }
            set
            {
                this.DataValueField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=24)]
        public opcfoundation.org.UA._2008._02.Types.xsd.EnumeratedTestType EnumeratedValue
        {
            get
            {
                return this.EnumeratedValueField;
            }
            set
            {
                this.EnumeratedValueField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ArrayTestType", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class ArrayTestType : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfBoolean BooleansField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfSByte SBytesField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfInt16 Int16sField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfUInt16 UInt16sField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfInt32 Int32sField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfUInt32 UInt32sField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfInt64 Int64sField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfUInt64 UInt64sField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfFloat FloatsField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfDouble DoublesField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfString StringsField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfDateTime DateTimesField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfGuid GuidsField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfByteString ByteStringsField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfXmlElement XmlElementsField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfNodeId NodeIdsField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfExpandedNodeId ExpandedNodeIdsField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfStatusCode StatusCodesField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfDiagnosticInfo DiagnosticInfosField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfQualifiedName QualifiedNamesField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfLocalizedText LocalizedTextsField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfExtensionObject ExtensionObjectsField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfDataValue DataValuesField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfVariant VariantsField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfEnumeratedTestType EnumeratedValuesField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfBoolean Booleans
        {
            get
            {
                return this.BooleansField;
            }
            set
            {
                this.BooleansField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfSByte SBytes
        {
            get
            {
                return this.SBytesField;
            }
            set
            {
                this.SBytesField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfInt16 Int16s
        {
            get
            {
                return this.Int16sField;
            }
            set
            {
                this.Int16sField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfUInt16 UInt16s
        {
            get
            {
                return this.UInt16sField;
            }
            set
            {
                this.UInt16sField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfInt32 Int32s
        {
            get
            {
                return this.Int32sField;
            }
            set
            {
                this.Int32sField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=5)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfUInt32 UInt32s
        {
            get
            {
                return this.UInt32sField;
            }
            set
            {
                this.UInt32sField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=6)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfInt64 Int64s
        {
            get
            {
                return this.Int64sField;
            }
            set
            {
                this.Int64sField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=7)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfUInt64 UInt64s
        {
            get
            {
                return this.UInt64sField;
            }
            set
            {
                this.UInt64sField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=8)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfFloat Floats
        {
            get
            {
                return this.FloatsField;
            }
            set
            {
                this.FloatsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=9)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfDouble Doubles
        {
            get
            {
                return this.DoublesField;
            }
            set
            {
                this.DoublesField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=10)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfString Strings
        {
            get
            {
                return this.StringsField;
            }
            set
            {
                this.StringsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=11)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfDateTime DateTimes
        {
            get
            {
                return this.DateTimesField;
            }
            set
            {
                this.DateTimesField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=12)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfGuid Guids
        {
            get
            {
                return this.GuidsField;
            }
            set
            {
                this.GuidsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=13)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfByteString ByteStrings
        {
            get
            {
                return this.ByteStringsField;
            }
            set
            {
                this.ByteStringsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=14)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfXmlElement XmlElements
        {
            get
            {
                return this.XmlElementsField;
            }
            set
            {
                this.XmlElementsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=15)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfNodeId NodeIds
        {
            get
            {
                return this.NodeIdsField;
            }
            set
            {
                this.NodeIdsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=16)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfExpandedNodeId ExpandedNodeIds
        {
            get
            {
                return this.ExpandedNodeIdsField;
            }
            set
            {
                this.ExpandedNodeIdsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=17)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfStatusCode StatusCodes
        {
            get
            {
                return this.StatusCodesField;
            }
            set
            {
                this.StatusCodesField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=18)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfDiagnosticInfo DiagnosticInfos
        {
            get
            {
                return this.DiagnosticInfosField;
            }
            set
            {
                this.DiagnosticInfosField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=19)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfQualifiedName QualifiedNames
        {
            get
            {
                return this.QualifiedNamesField;
            }
            set
            {
                this.QualifiedNamesField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=20)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfLocalizedText LocalizedTexts
        {
            get
            {
                return this.LocalizedTextsField;
            }
            set
            {
                this.LocalizedTextsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=21)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfExtensionObject ExtensionObjects
        {
            get
            {
                return this.ExtensionObjectsField;
            }
            set
            {
                this.ExtensionObjectsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=22)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfDataValue DataValues
        {
            get
            {
                return this.DataValuesField;
            }
            set
            {
                this.DataValuesField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=23)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfVariant Variants
        {
            get
            {
                return this.VariantsField;
            }
            set
            {
                this.VariantsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=24)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfEnumeratedTestType EnumeratedValues
        {
            get
            {
                return this.EnumeratedValuesField;
            }
            set
            {
                this.EnumeratedValuesField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TestStackExResponse", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class TestStackExResponse : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeaderField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.CompositeTestType OutputField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeader
        {
            get
            {
                return this.ResponseHeaderField;
            }
            set
            {
                this.ResponseHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public opcfoundation.org.UA._2008._02.Types.xsd.CompositeTestType Output
        {
            get
            {
                return this.OutputField;
            }
            set
            {
                this.OutputField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CreateSessionRequest", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class CreateSessionRequest : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeaderField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ApplicationDescription ClientDescriptionField;
        
        private string ServerUriField;
        
        private string EndpointUrlField;
        
        private string SessionNameField;
        
        private byte[] ClientNonceField;
        
        private byte[] ClientCertificateField;
        
        private double RequestedSessionTimeoutField;
        
        private uint MaxResponseMessageSizeField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeader
        {
            get
            {
                return this.RequestHeaderField;
            }
            set
            {
                this.RequestHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ApplicationDescription ClientDescription
        {
            get
            {
                return this.ClientDescriptionField;
            }
            set
            {
                this.ClientDescriptionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public string ServerUri
        {
            get
            {
                return this.ServerUriField;
            }
            set
            {
                this.ServerUriField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public string EndpointUrl
        {
            get
            {
                return this.EndpointUrlField;
            }
            set
            {
                this.EndpointUrlField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public string SessionName
        {
            get
            {
                return this.SessionNameField;
            }
            set
            {
                this.SessionNameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=5)]
        public byte[] ClientNonce
        {
            get
            {
                return this.ClientNonceField;
            }
            set
            {
                this.ClientNonceField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=6)]
        public byte[] ClientCertificate
        {
            get
            {
                return this.ClientCertificateField;
            }
            set
            {
                this.ClientCertificateField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=7)]
        public double RequestedSessionTimeout
        {
            get
            {
                return this.RequestedSessionTimeoutField;
            }
            set
            {
                this.RequestedSessionTimeoutField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=8)]
        public uint MaxResponseMessageSize
        {
            get
            {
                return this.MaxResponseMessageSizeField;
            }
            set
            {
                this.MaxResponseMessageSizeField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ApplicationDescription", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class ApplicationDescription : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private string ApplicationUriField;
        
        private string ProductUriField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.LocalizedText ApplicationNameField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ApplicationType ApplicationTypeField;
        
        private string GatewayServerUriField;
        
        private string DiscoveryProfileUriField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfString DiscoveryUrlsField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ApplicationUri
        {
            get
            {
                return this.ApplicationUriField;
            }
            set
            {
                this.ApplicationUriField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ProductUri
        {
            get
            {
                return this.ProductUriField;
            }
            set
            {
                this.ProductUriField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public opcfoundation.org.UA._2008._02.Types.xsd.LocalizedText ApplicationName
        {
            get
            {
                return this.ApplicationNameField;
            }
            set
            {
                this.ApplicationNameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ApplicationType ApplicationType
        {
            get
            {
                return this.ApplicationTypeField;
            }
            set
            {
                this.ApplicationTypeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public string GatewayServerUri
        {
            get
            {
                return this.GatewayServerUriField;
            }
            set
            {
                this.GatewayServerUriField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=5)]
        public string DiscoveryProfileUri
        {
            get
            {
                return this.DiscoveryProfileUriField;
            }
            set
            {
                this.DiscoveryProfileUriField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=6)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfString DiscoveryUrls
        {
            get
            {
                return this.DiscoveryUrlsField;
            }
            set
            {
                this.DiscoveryUrlsField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CreateSessionResponse", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class CreateSessionResponse : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeaderField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.NodeId SessionIdField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.NodeId AuthenticationTokenField;
        
        private double RevisedSessionTimeoutField;
        
        private byte[] ServerNonceField;
        
        private byte[] ServerCertificateField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfEndpointDescription ServerEndpointsField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfSignedSoftwareCertificate ServerSoftwareCertificatesField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.SignatureData ServerSignatureField;
        
        private uint MaxRequestMessageSizeField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeader
        {
            get
            {
                return this.ResponseHeaderField;
            }
            set
            {
                this.ResponseHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.NodeId SessionId
        {
            get
            {
                return this.SessionIdField;
            }
            set
            {
                this.SessionIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public opcfoundation.org.UA._2008._02.Types.xsd.NodeId AuthenticationToken
        {
            get
            {
                return this.AuthenticationTokenField;
            }
            set
            {
                this.AuthenticationTokenField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public double RevisedSessionTimeout
        {
            get
            {
                return this.RevisedSessionTimeoutField;
            }
            set
            {
                this.RevisedSessionTimeoutField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public byte[] ServerNonce
        {
            get
            {
                return this.ServerNonceField;
            }
            set
            {
                this.ServerNonceField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=5)]
        public byte[] ServerCertificate
        {
            get
            {
                return this.ServerCertificateField;
            }
            set
            {
                this.ServerCertificateField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=6)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfEndpointDescription ServerEndpoints
        {
            get
            {
                return this.ServerEndpointsField;
            }
            set
            {
                this.ServerEndpointsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=7)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfSignedSoftwareCertificate ServerSoftwareCertificates
        {
            get
            {
                return this.ServerSoftwareCertificatesField;
            }
            set
            {
                this.ServerSoftwareCertificatesField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=8)]
        public opcfoundation.org.UA._2008._02.Types.xsd.SignatureData ServerSignature
        {
            get
            {
                return this.ServerSignatureField;
            }
            set
            {
                this.ServerSignatureField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=9)]
        public uint MaxRequestMessageSize
        {
            get
            {
                return this.MaxRequestMessageSizeField;
            }
            set
            {
                this.MaxRequestMessageSizeField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EndpointDescription", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class EndpointDescription : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private string EndpointUrlField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ApplicationDescription ServerField;
        
        private byte[] ServerCertificateField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.MessageSecurityMode SecurityModeField;
        
        private string SecurityPolicyUriField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfUserTokenPolicy UserIdentityTokensField;
        
        private string TransportProfileUriField;
        
        private byte SecurityLevelField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string EndpointUrl
        {
            get
            {
                return this.EndpointUrlField;
            }
            set
            {
                this.EndpointUrlField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ApplicationDescription Server
        {
            get
            {
                return this.ServerField;
            }
            set
            {
                this.ServerField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte[] ServerCertificate
        {
            get
            {
                return this.ServerCertificateField;
            }
            set
            {
                this.ServerCertificateField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public opcfoundation.org.UA._2008._02.Types.xsd.MessageSecurityMode SecurityMode
        {
            get
            {
                return this.SecurityModeField;
            }
            set
            {
                this.SecurityModeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public string SecurityPolicyUri
        {
            get
            {
                return this.SecurityPolicyUriField;
            }
            set
            {
                this.SecurityPolicyUriField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=5)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfUserTokenPolicy UserIdentityTokens
        {
            get
            {
                return this.UserIdentityTokensField;
            }
            set
            {
                this.UserIdentityTokensField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=6)]
        public string TransportProfileUri
        {
            get
            {
                return this.TransportProfileUriField;
            }
            set
            {
                this.TransportProfileUriField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=7)]
        public byte SecurityLevel
        {
            get
            {
                return this.SecurityLevelField;
            }
            set
            {
                this.SecurityLevelField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UserTokenPolicy", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class UserTokenPolicy : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private string PolicyIdField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.UserTokenType TokenTypeField;
        
        private string IssuedTokenTypeField;
        
        private string IssuerEndpointUrlField;
        
        private string SecurityPolicyUriField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PolicyId
        {
            get
            {
                return this.PolicyIdField;
            }
            set
            {
                this.PolicyIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.UserTokenType TokenType
        {
            get
            {
                return this.TokenTypeField;
            }
            set
            {
                this.TokenTypeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public string IssuedTokenType
        {
            get
            {
                return this.IssuedTokenTypeField;
            }
            set
            {
                this.IssuedTokenTypeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public string IssuerEndpointUrl
        {
            get
            {
                return this.IssuerEndpointUrlField;
            }
            set
            {
                this.IssuerEndpointUrlField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public string SecurityPolicyUri
        {
            get
            {
                return this.SecurityPolicyUriField;
            }
            set
            {
                this.SecurityPolicyUriField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SignedSoftwareCertificate", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class SignedSoftwareCertificate : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private byte[] CertificateDataField;
        
        private byte[] SignatureField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte[] CertificateData
        {
            get
            {
                return this.CertificateDataField;
            }
            set
            {
                this.CertificateDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte[] Signature
        {
            get
            {
                return this.SignatureField;
            }
            set
            {
                this.SignatureField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SignatureData", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class SignatureData : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private string AlgorithmField;
        
        private byte[] SignatureField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Algorithm
        {
            get
            {
                return this.AlgorithmField;
            }
            set
            {
                this.AlgorithmField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte[] Signature
        {
            get
            {
                return this.SignatureField;
            }
            set
            {
                this.SignatureField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ActivateSessionRequest", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class ActivateSessionRequest : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeaderField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.SignatureData ClientSignatureField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfSignedSoftwareCertificate ClientSoftwareCertificatesField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfString LocaleIdsField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ExtensionObject UserIdentityTokenField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.SignatureData UserTokenSignatureField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeader
        {
            get
            {
                return this.RequestHeaderField;
            }
            set
            {
                this.RequestHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public opcfoundation.org.UA._2008._02.Types.xsd.SignatureData ClientSignature
        {
            get
            {
                return this.ClientSignatureField;
            }
            set
            {
                this.ClientSignatureField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfSignedSoftwareCertificate ClientSoftwareCertificates
        {
            get
            {
                return this.ClientSoftwareCertificatesField;
            }
            set
            {
                this.ClientSoftwareCertificatesField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfString LocaleIds
        {
            get
            {
                return this.LocaleIdsField;
            }
            set
            {
                this.LocaleIdsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ExtensionObject UserIdentityToken
        {
            get
            {
                return this.UserIdentityTokenField;
            }
            set
            {
                this.UserIdentityTokenField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=5)]
        public opcfoundation.org.UA._2008._02.Types.xsd.SignatureData UserTokenSignature
        {
            get
            {
                return this.UserTokenSignatureField;
            }
            set
            {
                this.UserTokenSignatureField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ActivateSessionResponse", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class ActivateSessionResponse : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeaderField;
        
        private byte[] ServerNonceField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfStatusCode ResultsField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfDiagnosticInfo DiagnosticInfosField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeader
        {
            get
            {
                return this.ResponseHeaderField;
            }
            set
            {
                this.ResponseHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte[] ServerNonce
        {
            get
            {
                return this.ServerNonceField;
            }
            set
            {
                this.ServerNonceField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfStatusCode Results
        {
            get
            {
                return this.ResultsField;
            }
            set
            {
                this.ResultsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfDiagnosticInfo DiagnosticInfos
        {
            get
            {
                return this.DiagnosticInfosField;
            }
            set
            {
                this.DiagnosticInfosField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CloseSessionRequest", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class CloseSessionRequest : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeaderField;
        
        private bool DeleteSubscriptionsField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeader
        {
            get
            {
                return this.RequestHeaderField;
            }
            set
            {
                this.RequestHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public bool DeleteSubscriptions
        {
            get
            {
                return this.DeleteSubscriptionsField;
            }
            set
            {
                this.DeleteSubscriptionsField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CloseSessionResponse", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class CloseSessionResponse : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeaderField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeader
        {
            get
            {
                return this.ResponseHeaderField;
            }
            set
            {
                this.ResponseHeaderField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CancelRequest", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class CancelRequest : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeaderField;
        
        private uint RequestHandleField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeader
        {
            get
            {
                return this.RequestHeaderField;
            }
            set
            {
                this.RequestHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public uint RequestHandle
        {
            get
            {
                return this.RequestHandleField;
            }
            set
            {
                this.RequestHandleField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CancelResponse", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class CancelResponse : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeaderField;
        
        private uint CancelCountField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeader
        {
            get
            {
                return this.ResponseHeaderField;
            }
            set
            {
                this.ResponseHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public uint CancelCount
        {
            get
            {
                return this.CancelCountField;
            }
            set
            {
                this.CancelCountField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AddNodesRequest", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class AddNodesRequest : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeaderField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfAddNodesItem NodesToAddField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeader
        {
            get
            {
                return this.RequestHeaderField;
            }
            set
            {
                this.RequestHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfAddNodesItem NodesToAdd
        {
            get
            {
                return this.NodesToAddField;
            }
            set
            {
                this.NodesToAddField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AddNodesItem", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class AddNodesItem : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ExpandedNodeId ParentNodeIdField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.NodeId ReferenceTypeIdField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ExpandedNodeId RequestedNewNodeIdField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.QualifiedName BrowseNameField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.NodeClass NodeClassField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ExtensionObject NodeAttributesField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ExpandedNodeId TypeDefinitionField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ExpandedNodeId ParentNodeId
        {
            get
            {
                return this.ParentNodeIdField;
            }
            set
            {
                this.ParentNodeIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.NodeId ReferenceTypeId
        {
            get
            {
                return this.ReferenceTypeIdField;
            }
            set
            {
                this.ReferenceTypeIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ExpandedNodeId RequestedNewNodeId
        {
            get
            {
                return this.RequestedNewNodeIdField;
            }
            set
            {
                this.RequestedNewNodeIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public opcfoundation.org.UA._2008._02.Types.xsd.QualifiedName BrowseName
        {
            get
            {
                return this.BrowseNameField;
            }
            set
            {
                this.BrowseNameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public opcfoundation.org.UA._2008._02.Types.xsd.NodeClass NodeClass
        {
            get
            {
                return this.NodeClassField;
            }
            set
            {
                this.NodeClassField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=5)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ExtensionObject NodeAttributes
        {
            get
            {
                return this.NodeAttributesField;
            }
            set
            {
                this.NodeAttributesField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=6)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ExpandedNodeId TypeDefinition
        {
            get
            {
                return this.TypeDefinitionField;
            }
            set
            {
                this.TypeDefinitionField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AddNodesResponse", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class AddNodesResponse : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeaderField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfAddNodesResult ResultsField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfDiagnosticInfo DiagnosticInfosField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeader
        {
            get
            {
                return this.ResponseHeaderField;
            }
            set
            {
                this.ResponseHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfAddNodesResult Results
        {
            get
            {
                return this.ResultsField;
            }
            set
            {
                this.ResultsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfDiagnosticInfo DiagnosticInfos
        {
            get
            {
                return this.DiagnosticInfosField;
            }
            set
            {
                this.DiagnosticInfosField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AddNodesResult", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class AddNodesResult : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.StatusCode StatusCodeField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.NodeId AddedNodeIdField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.StatusCode StatusCode
        {
            get
            {
                return this.StatusCodeField;
            }
            set
            {
                this.StatusCodeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public opcfoundation.org.UA._2008._02.Types.xsd.NodeId AddedNodeId
        {
            get
            {
                return this.AddedNodeIdField;
            }
            set
            {
                this.AddedNodeIdField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AddReferencesRequest", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class AddReferencesRequest : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeaderField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfAddReferencesItem ReferencesToAddField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeader
        {
            get
            {
                return this.RequestHeaderField;
            }
            set
            {
                this.RequestHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfAddReferencesItem ReferencesToAdd
        {
            get
            {
                return this.ReferencesToAddField;
            }
            set
            {
                this.ReferencesToAddField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AddReferencesItem", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class AddReferencesItem : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.NodeId SourceNodeIdField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.NodeId ReferenceTypeIdField;
        
        private bool IsForwardField;
        
        private string TargetServerUriField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ExpandedNodeId TargetNodeIdField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.NodeClass TargetNodeClassField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.NodeId SourceNodeId
        {
            get
            {
                return this.SourceNodeIdField;
            }
            set
            {
                this.SourceNodeIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public opcfoundation.org.UA._2008._02.Types.xsd.NodeId ReferenceTypeId
        {
            get
            {
                return this.ReferenceTypeIdField;
            }
            set
            {
                this.ReferenceTypeIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public bool IsForward
        {
            get
            {
                return this.IsForwardField;
            }
            set
            {
                this.IsForwardField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public string TargetServerUri
        {
            get
            {
                return this.TargetServerUriField;
            }
            set
            {
                this.TargetServerUriField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ExpandedNodeId TargetNodeId
        {
            get
            {
                return this.TargetNodeIdField;
            }
            set
            {
                this.TargetNodeIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=5)]
        public opcfoundation.org.UA._2008._02.Types.xsd.NodeClass TargetNodeClass
        {
            get
            {
                return this.TargetNodeClassField;
            }
            set
            {
                this.TargetNodeClassField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AddReferencesResponse", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class AddReferencesResponse : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeaderField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfStatusCode ResultsField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfDiagnosticInfo DiagnosticInfosField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeader
        {
            get
            {
                return this.ResponseHeaderField;
            }
            set
            {
                this.ResponseHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfStatusCode Results
        {
            get
            {
                return this.ResultsField;
            }
            set
            {
                this.ResultsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfDiagnosticInfo DiagnosticInfos
        {
            get
            {
                return this.DiagnosticInfosField;
            }
            set
            {
                this.DiagnosticInfosField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DeleteNodesRequest", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class DeleteNodesRequest : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeaderField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfDeleteNodesItem NodesToDeleteField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeader
        {
            get
            {
                return this.RequestHeaderField;
            }
            set
            {
                this.RequestHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfDeleteNodesItem NodesToDelete
        {
            get
            {
                return this.NodesToDeleteField;
            }
            set
            {
                this.NodesToDeleteField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DeleteNodesItem", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class DeleteNodesItem : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.NodeId NodeIdField;
        
        private bool DeleteTargetReferencesField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.NodeId NodeId
        {
            get
            {
                return this.NodeIdField;
            }
            set
            {
                this.NodeIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public bool DeleteTargetReferences
        {
            get
            {
                return this.DeleteTargetReferencesField;
            }
            set
            {
                this.DeleteTargetReferencesField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DeleteNodesResponse", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class DeleteNodesResponse : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeaderField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfStatusCode ResultsField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfDiagnosticInfo DiagnosticInfosField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeader
        {
            get
            {
                return this.ResponseHeaderField;
            }
            set
            {
                this.ResponseHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfStatusCode Results
        {
            get
            {
                return this.ResultsField;
            }
            set
            {
                this.ResultsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfDiagnosticInfo DiagnosticInfos
        {
            get
            {
                return this.DiagnosticInfosField;
            }
            set
            {
                this.DiagnosticInfosField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DeleteReferencesRequest", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class DeleteReferencesRequest : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeaderField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfDeleteReferencesItem ReferencesToDeleteField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeader
        {
            get
            {
                return this.RequestHeaderField;
            }
            set
            {
                this.RequestHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfDeleteReferencesItem ReferencesToDelete
        {
            get
            {
                return this.ReferencesToDeleteField;
            }
            set
            {
                this.ReferencesToDeleteField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DeleteReferencesItem", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class DeleteReferencesItem : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.NodeId SourceNodeIdField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.NodeId ReferenceTypeIdField;
        
        private bool IsForwardField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ExpandedNodeId TargetNodeIdField;
        
        private bool DeleteBidirectionalField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.NodeId SourceNodeId
        {
            get
            {
                return this.SourceNodeIdField;
            }
            set
            {
                this.SourceNodeIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public opcfoundation.org.UA._2008._02.Types.xsd.NodeId ReferenceTypeId
        {
            get
            {
                return this.ReferenceTypeIdField;
            }
            set
            {
                this.ReferenceTypeIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public bool IsForward
        {
            get
            {
                return this.IsForwardField;
            }
            set
            {
                this.IsForwardField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ExpandedNodeId TargetNodeId
        {
            get
            {
                return this.TargetNodeIdField;
            }
            set
            {
                this.TargetNodeIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public bool DeleteBidirectional
        {
            get
            {
                return this.DeleteBidirectionalField;
            }
            set
            {
                this.DeleteBidirectionalField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DeleteReferencesResponse", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class DeleteReferencesResponse : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeaderField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfStatusCode ResultsField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfDiagnosticInfo DiagnosticInfosField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeader
        {
            get
            {
                return this.ResponseHeaderField;
            }
            set
            {
                this.ResponseHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfStatusCode Results
        {
            get
            {
                return this.ResultsField;
            }
            set
            {
                this.ResultsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfDiagnosticInfo DiagnosticInfos
        {
            get
            {
                return this.DiagnosticInfosField;
            }
            set
            {
                this.DiagnosticInfosField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BrowseRequest", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class BrowseRequest : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeaderField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ViewDescription ViewField;
        
        private uint RequestedMaxReferencesPerNodeField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfBrowseDescription NodesToBrowseField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeader
        {
            get
            {
                return this.RequestHeaderField;
            }
            set
            {
                this.RequestHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ViewDescription View
        {
            get
            {
                return this.ViewField;
            }
            set
            {
                this.ViewField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public uint RequestedMaxReferencesPerNode
        {
            get
            {
                return this.RequestedMaxReferencesPerNodeField;
            }
            set
            {
                this.RequestedMaxReferencesPerNodeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfBrowseDescription NodesToBrowse
        {
            get
            {
                return this.NodesToBrowseField;
            }
            set
            {
                this.NodesToBrowseField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ViewDescription", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class ViewDescription : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.NodeId ViewIdField;
        
        private System.DateTime TimestampField;
        
        private uint ViewVersionField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.NodeId ViewId
        {
            get
            {
                return this.ViewIdField;
            }
            set
            {
                this.ViewIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public System.DateTime Timestamp
        {
            get
            {
                return this.TimestampField;
            }
            set
            {
                this.TimestampField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public uint ViewVersion
        {
            get
            {
                return this.ViewVersionField;
            }
            set
            {
                this.ViewVersionField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BrowseDescription", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class BrowseDescription : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.NodeId NodeIdField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.BrowseDirection BrowseDirectionField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.NodeId ReferenceTypeIdField;
        
        private bool IncludeSubtypesField;
        
        private uint NodeClassMaskField;
        
        private uint ResultMaskField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.NodeId NodeId
        {
            get
            {
                return this.NodeIdField;
            }
            set
            {
                this.NodeIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public opcfoundation.org.UA._2008._02.Types.xsd.BrowseDirection BrowseDirection
        {
            get
            {
                return this.BrowseDirectionField;
            }
            set
            {
                this.BrowseDirectionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public opcfoundation.org.UA._2008._02.Types.xsd.NodeId ReferenceTypeId
        {
            get
            {
                return this.ReferenceTypeIdField;
            }
            set
            {
                this.ReferenceTypeIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public bool IncludeSubtypes
        {
            get
            {
                return this.IncludeSubtypesField;
            }
            set
            {
                this.IncludeSubtypesField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public uint NodeClassMask
        {
            get
            {
                return this.NodeClassMaskField;
            }
            set
            {
                this.NodeClassMaskField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=5)]
        public uint ResultMask
        {
            get
            {
                return this.ResultMaskField;
            }
            set
            {
                this.ResultMaskField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BrowseResponse", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class BrowseResponse : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeaderField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfBrowseResult ResultsField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfDiagnosticInfo DiagnosticInfosField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeader
        {
            get
            {
                return this.ResponseHeaderField;
            }
            set
            {
                this.ResponseHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfBrowseResult Results
        {
            get
            {
                return this.ResultsField;
            }
            set
            {
                this.ResultsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfDiagnosticInfo DiagnosticInfos
        {
            get
            {
                return this.DiagnosticInfosField;
            }
            set
            {
                this.DiagnosticInfosField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BrowseResult", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class BrowseResult : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.StatusCode StatusCodeField;
        
        private byte[] ContinuationPointField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfReferenceDescription ReferencesField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.StatusCode StatusCode
        {
            get
            {
                return this.StatusCodeField;
            }
            set
            {
                this.StatusCodeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public byte[] ContinuationPoint
        {
            get
            {
                return this.ContinuationPointField;
            }
            set
            {
                this.ContinuationPointField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfReferenceDescription References
        {
            get
            {
                return this.ReferencesField;
            }
            set
            {
                this.ReferencesField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ReferenceDescription", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class ReferenceDescription : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.NodeId ReferenceTypeIdField;
        
        private bool IsForwardField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ExpandedNodeId NodeIdField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.QualifiedName BrowseNameField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.LocalizedText DisplayNameField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.NodeClass NodeClassField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ExpandedNodeId TypeDefinitionField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.NodeId ReferenceTypeId
        {
            get
            {
                return this.ReferenceTypeIdField;
            }
            set
            {
                this.ReferenceTypeIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public bool IsForward
        {
            get
            {
                return this.IsForwardField;
            }
            set
            {
                this.IsForwardField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ExpandedNodeId NodeId
        {
            get
            {
                return this.NodeIdField;
            }
            set
            {
                this.NodeIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public opcfoundation.org.UA._2008._02.Types.xsd.QualifiedName BrowseName
        {
            get
            {
                return this.BrowseNameField;
            }
            set
            {
                this.BrowseNameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public opcfoundation.org.UA._2008._02.Types.xsd.LocalizedText DisplayName
        {
            get
            {
                return this.DisplayNameField;
            }
            set
            {
                this.DisplayNameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=5)]
        public opcfoundation.org.UA._2008._02.Types.xsd.NodeClass NodeClass
        {
            get
            {
                return this.NodeClassField;
            }
            set
            {
                this.NodeClassField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=6)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ExpandedNodeId TypeDefinition
        {
            get
            {
                return this.TypeDefinitionField;
            }
            set
            {
                this.TypeDefinitionField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BrowseNextRequest", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class BrowseNextRequest : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeaderField;
        
        private bool ReleaseContinuationPointsField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfByteString ContinuationPointsField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeader
        {
            get
            {
                return this.RequestHeaderField;
            }
            set
            {
                this.RequestHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public bool ReleaseContinuationPoints
        {
            get
            {
                return this.ReleaseContinuationPointsField;
            }
            set
            {
                this.ReleaseContinuationPointsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfByteString ContinuationPoints
        {
            get
            {
                return this.ContinuationPointsField;
            }
            set
            {
                this.ContinuationPointsField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BrowseNextResponse", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class BrowseNextResponse : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeaderField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfBrowseResult ResultsField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfDiagnosticInfo DiagnosticInfosField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeader
        {
            get
            {
                return this.ResponseHeaderField;
            }
            set
            {
                this.ResponseHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfBrowseResult Results
        {
            get
            {
                return this.ResultsField;
            }
            set
            {
                this.ResultsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfDiagnosticInfo DiagnosticInfos
        {
            get
            {
                return this.DiagnosticInfosField;
            }
            set
            {
                this.DiagnosticInfosField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TranslateBrowsePathsToNodeIdsRequest", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class TranslateBrowsePathsToNodeIdsRequest : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeaderField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfBrowsePath BrowsePathsField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeader
        {
            get
            {
                return this.RequestHeaderField;
            }
            set
            {
                this.RequestHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfBrowsePath BrowsePaths
        {
            get
            {
                return this.BrowsePathsField;
            }
            set
            {
                this.BrowsePathsField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BrowsePath", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class BrowsePath : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.NodeId StartingNodeField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.RelativePath RelativePathField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.NodeId StartingNode
        {
            get
            {
                return this.StartingNodeField;
            }
            set
            {
                this.StartingNodeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public opcfoundation.org.UA._2008._02.Types.xsd.RelativePath RelativePath
        {
            get
            {
                return this.RelativePathField;
            }
            set
            {
                this.RelativePathField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RelativePath", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class RelativePath : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfRelativePathElement ElementsField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfRelativePathElement Elements
        {
            get
            {
                return this.ElementsField;
            }
            set
            {
                this.ElementsField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RelativePathElement", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class RelativePathElement : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.NodeId ReferenceTypeIdField;
        
        private bool IsInverseField;
        
        private bool IncludeSubtypesField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.QualifiedName TargetNameField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.NodeId ReferenceTypeId
        {
            get
            {
                return this.ReferenceTypeIdField;
            }
            set
            {
                this.ReferenceTypeIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public bool IsInverse
        {
            get
            {
                return this.IsInverseField;
            }
            set
            {
                this.IsInverseField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public bool IncludeSubtypes
        {
            get
            {
                return this.IncludeSubtypesField;
            }
            set
            {
                this.IncludeSubtypesField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public opcfoundation.org.UA._2008._02.Types.xsd.QualifiedName TargetName
        {
            get
            {
                return this.TargetNameField;
            }
            set
            {
                this.TargetNameField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TranslateBrowsePathsToNodeIdsResponse", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class TranslateBrowsePathsToNodeIdsResponse : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeaderField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfBrowsePathResult ResultsField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfDiagnosticInfo DiagnosticInfosField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeader
        {
            get
            {
                return this.ResponseHeaderField;
            }
            set
            {
                this.ResponseHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfBrowsePathResult Results
        {
            get
            {
                return this.ResultsField;
            }
            set
            {
                this.ResultsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfDiagnosticInfo DiagnosticInfos
        {
            get
            {
                return this.DiagnosticInfosField;
            }
            set
            {
                this.DiagnosticInfosField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BrowsePathResult", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class BrowsePathResult : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.StatusCode StatusCodeField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfBrowsePathTarget TargetsField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.StatusCode StatusCode
        {
            get
            {
                return this.StatusCodeField;
            }
            set
            {
                this.StatusCodeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfBrowsePathTarget Targets
        {
            get
            {
                return this.TargetsField;
            }
            set
            {
                this.TargetsField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BrowsePathTarget", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class BrowsePathTarget : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ExpandedNodeId TargetIdField;
        
        private uint RemainingPathIndexField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ExpandedNodeId TargetId
        {
            get
            {
                return this.TargetIdField;
            }
            set
            {
                this.TargetIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public uint RemainingPathIndex
        {
            get
            {
                return this.RemainingPathIndexField;
            }
            set
            {
                this.RemainingPathIndexField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RegisterNodesRequest", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class RegisterNodesRequest : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeaderField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfNodeId NodesToRegisterField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeader
        {
            get
            {
                return this.RequestHeaderField;
            }
            set
            {
                this.RequestHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfNodeId NodesToRegister
        {
            get
            {
                return this.NodesToRegisterField;
            }
            set
            {
                this.NodesToRegisterField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RegisterNodesResponse", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class RegisterNodesResponse : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeaderField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfNodeId RegisteredNodeIdsField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeader
        {
            get
            {
                return this.ResponseHeaderField;
            }
            set
            {
                this.ResponseHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfNodeId RegisteredNodeIds
        {
            get
            {
                return this.RegisteredNodeIdsField;
            }
            set
            {
                this.RegisteredNodeIdsField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UnregisterNodesRequest", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class UnregisterNodesRequest : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeaderField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfNodeId NodesToUnregisterField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeader
        {
            get
            {
                return this.RequestHeaderField;
            }
            set
            {
                this.RequestHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfNodeId NodesToUnregister
        {
            get
            {
                return this.NodesToUnregisterField;
            }
            set
            {
                this.NodesToUnregisterField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UnregisterNodesResponse", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class UnregisterNodesResponse : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeaderField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeader
        {
            get
            {
                return this.ResponseHeaderField;
            }
            set
            {
                this.ResponseHeaderField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="QueryFirstRequest", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class QueryFirstRequest : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeaderField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ViewDescription ViewField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfNodeTypeDescription NodeTypesField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ContentFilter FilterField;
        
        private uint MaxDataSetsToReturnField;
        
        private uint MaxReferencesToReturnField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeader
        {
            get
            {
                return this.RequestHeaderField;
            }
            set
            {
                this.RequestHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ViewDescription View
        {
            get
            {
                return this.ViewField;
            }
            set
            {
                this.ViewField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfNodeTypeDescription NodeTypes
        {
            get
            {
                return this.NodeTypesField;
            }
            set
            {
                this.NodeTypesField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ContentFilter Filter
        {
            get
            {
                return this.FilterField;
            }
            set
            {
                this.FilterField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public uint MaxDataSetsToReturn
        {
            get
            {
                return this.MaxDataSetsToReturnField;
            }
            set
            {
                this.MaxDataSetsToReturnField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=5)]
        public uint MaxReferencesToReturn
        {
            get
            {
                return this.MaxReferencesToReturnField;
            }
            set
            {
                this.MaxReferencesToReturnField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="NodeTypeDescription", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class NodeTypeDescription : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ExpandedNodeId TypeDefinitionNodeField;
        
        private bool IncludeSubTypesField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfQueryDataDescription DataToReturnField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ExpandedNodeId TypeDefinitionNode
        {
            get
            {
                return this.TypeDefinitionNodeField;
            }
            set
            {
                this.TypeDefinitionNodeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public bool IncludeSubTypes
        {
            get
            {
                return this.IncludeSubTypesField;
            }
            set
            {
                this.IncludeSubTypesField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfQueryDataDescription DataToReturn
        {
            get
            {
                return this.DataToReturnField;
            }
            set
            {
                this.DataToReturnField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="QueryDataDescription", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class QueryDataDescription : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.RelativePath RelativePathField;
        
        private uint AttributeIdField;
        
        private string IndexRangeField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.RelativePath RelativePath
        {
            get
            {
                return this.RelativePathField;
            }
            set
            {
                this.RelativePathField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public uint AttributeId
        {
            get
            {
                return this.AttributeIdField;
            }
            set
            {
                this.AttributeIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public string IndexRange
        {
            get
            {
                return this.IndexRangeField;
            }
            set
            {
                this.IndexRangeField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ContentFilter", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class ContentFilter : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfContentFilterElement ElementsField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfContentFilterElement Elements
        {
            get
            {
                return this.ElementsField;
            }
            set
            {
                this.ElementsField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ContentFilterElement", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class ContentFilterElement : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.FilterOperator FilterOperatorField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfExtensionObject FilterOperandsField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.FilterOperator FilterOperator
        {
            get
            {
                return this.FilterOperatorField;
            }
            set
            {
                this.FilterOperatorField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfExtensionObject FilterOperands
        {
            get
            {
                return this.FilterOperandsField;
            }
            set
            {
                this.FilterOperandsField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="QueryFirstResponse", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class QueryFirstResponse : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeaderField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfQueryDataSet QueryDataSetsField;
        
        private byte[] ContinuationPointField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfParsingResult ParsingResultsField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfDiagnosticInfo DiagnosticInfosField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ContentFilterResult FilterResultField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeader
        {
            get
            {
                return this.ResponseHeaderField;
            }
            set
            {
                this.ResponseHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfQueryDataSet QueryDataSets
        {
            get
            {
                return this.QueryDataSetsField;
            }
            set
            {
                this.QueryDataSetsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public byte[] ContinuationPoint
        {
            get
            {
                return this.ContinuationPointField;
            }
            set
            {
                this.ContinuationPointField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfParsingResult ParsingResults
        {
            get
            {
                return this.ParsingResultsField;
            }
            set
            {
                this.ParsingResultsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfDiagnosticInfo DiagnosticInfos
        {
            get
            {
                return this.DiagnosticInfosField;
            }
            set
            {
                this.DiagnosticInfosField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=5)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ContentFilterResult FilterResult
        {
            get
            {
                return this.FilterResultField;
            }
            set
            {
                this.FilterResultField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="QueryDataSet", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class QueryDataSet : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ExpandedNodeId NodeIdField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ExpandedNodeId TypeDefinitionNodeField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfVariant ValuesField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ExpandedNodeId NodeId
        {
            get
            {
                return this.NodeIdField;
            }
            set
            {
                this.NodeIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ExpandedNodeId TypeDefinitionNode
        {
            get
            {
                return this.TypeDefinitionNodeField;
            }
            set
            {
                this.TypeDefinitionNodeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfVariant Values
        {
            get
            {
                return this.ValuesField;
            }
            set
            {
                this.ValuesField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ParsingResult", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class ParsingResult : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.StatusCode StatusCodeField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfStatusCode DataStatusCodesField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfDiagnosticInfo DataDiagnosticInfosField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.StatusCode StatusCode
        {
            get
            {
                return this.StatusCodeField;
            }
            set
            {
                this.StatusCodeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfStatusCode DataStatusCodes
        {
            get
            {
                return this.DataStatusCodesField;
            }
            set
            {
                this.DataStatusCodesField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfDiagnosticInfo DataDiagnosticInfos
        {
            get
            {
                return this.DataDiagnosticInfosField;
            }
            set
            {
                this.DataDiagnosticInfosField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ContentFilterResult", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class ContentFilterResult : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfContentFilterElementResult ElementResultsField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfDiagnosticInfo ElementDiagnosticInfosField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfContentFilterElementResult ElementResults
        {
            get
            {
                return this.ElementResultsField;
            }
            set
            {
                this.ElementResultsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfDiagnosticInfo ElementDiagnosticInfos
        {
            get
            {
                return this.ElementDiagnosticInfosField;
            }
            set
            {
                this.ElementDiagnosticInfosField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ContentFilterElementResult", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class ContentFilterElementResult : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.StatusCode StatusCodeField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfStatusCode OperandStatusCodesField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfDiagnosticInfo OperandDiagnosticInfosField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.StatusCode StatusCode
        {
            get
            {
                return this.StatusCodeField;
            }
            set
            {
                this.StatusCodeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfStatusCode OperandStatusCodes
        {
            get
            {
                return this.OperandStatusCodesField;
            }
            set
            {
                this.OperandStatusCodesField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfDiagnosticInfo OperandDiagnosticInfos
        {
            get
            {
                return this.OperandDiagnosticInfosField;
            }
            set
            {
                this.OperandDiagnosticInfosField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="QueryNextRequest", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class QueryNextRequest : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeaderField;
        
        private bool ReleaseContinuationPointField;
        
        private byte[] ContinuationPointField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeader
        {
            get
            {
                return this.RequestHeaderField;
            }
            set
            {
                this.RequestHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public bool ReleaseContinuationPoint
        {
            get
            {
                return this.ReleaseContinuationPointField;
            }
            set
            {
                this.ReleaseContinuationPointField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public byte[] ContinuationPoint
        {
            get
            {
                return this.ContinuationPointField;
            }
            set
            {
                this.ContinuationPointField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="QueryNextResponse", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class QueryNextResponse : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeaderField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfQueryDataSet QueryDataSetsField;
        
        private byte[] RevisedContinuationPointField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeader
        {
            get
            {
                return this.ResponseHeaderField;
            }
            set
            {
                this.ResponseHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfQueryDataSet QueryDataSets
        {
            get
            {
                return this.QueryDataSetsField;
            }
            set
            {
                this.QueryDataSetsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public byte[] RevisedContinuationPoint
        {
            get
            {
                return this.RevisedContinuationPointField;
            }
            set
            {
                this.RevisedContinuationPointField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ReadRequest", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class ReadRequest : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeaderField;
        
        private double MaxAgeField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.TimestampsToReturn TimestampsToReturnField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfReadValueId NodesToReadField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeader
        {
            get
            {
                return this.RequestHeaderField;
            }
            set
            {
                this.RequestHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public double MaxAge
        {
            get
            {
                return this.MaxAgeField;
            }
            set
            {
                this.MaxAgeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public opcfoundation.org.UA._2008._02.Types.xsd.TimestampsToReturn TimestampsToReturn
        {
            get
            {
                return this.TimestampsToReturnField;
            }
            set
            {
                this.TimestampsToReturnField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfReadValueId NodesToRead
        {
            get
            {
                return this.NodesToReadField;
            }
            set
            {
                this.NodesToReadField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ReadValueId", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class ReadValueId : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.NodeId NodeIdField;
        
        private uint AttributeIdField;
        
        private string IndexRangeField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.QualifiedName DataEncodingField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.NodeId NodeId
        {
            get
            {
                return this.NodeIdField;
            }
            set
            {
                this.NodeIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public uint AttributeId
        {
            get
            {
                return this.AttributeIdField;
            }
            set
            {
                this.AttributeIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public string IndexRange
        {
            get
            {
                return this.IndexRangeField;
            }
            set
            {
                this.IndexRangeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public opcfoundation.org.UA._2008._02.Types.xsd.QualifiedName DataEncoding
        {
            get
            {
                return this.DataEncodingField;
            }
            set
            {
                this.DataEncodingField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ReadResponse", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class ReadResponse : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeaderField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfDataValue ResultsField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfDiagnosticInfo DiagnosticInfosField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeader
        {
            get
            {
                return this.ResponseHeaderField;
            }
            set
            {
                this.ResponseHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfDataValue Results
        {
            get
            {
                return this.ResultsField;
            }
            set
            {
                this.ResultsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfDiagnosticInfo DiagnosticInfos
        {
            get
            {
                return this.DiagnosticInfosField;
            }
            set
            {
                this.DiagnosticInfosField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="HistoryReadRequest", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class HistoryReadRequest : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeaderField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ExtensionObject HistoryReadDetailsField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.TimestampsToReturn TimestampsToReturnField;
        
        private bool ReleaseContinuationPointsField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfHistoryReadValueId NodesToReadField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeader
        {
            get
            {
                return this.RequestHeaderField;
            }
            set
            {
                this.RequestHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ExtensionObject HistoryReadDetails
        {
            get
            {
                return this.HistoryReadDetailsField;
            }
            set
            {
                this.HistoryReadDetailsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public opcfoundation.org.UA._2008._02.Types.xsd.TimestampsToReturn TimestampsToReturn
        {
            get
            {
                return this.TimestampsToReturnField;
            }
            set
            {
                this.TimestampsToReturnField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public bool ReleaseContinuationPoints
        {
            get
            {
                return this.ReleaseContinuationPointsField;
            }
            set
            {
                this.ReleaseContinuationPointsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfHistoryReadValueId NodesToRead
        {
            get
            {
                return this.NodesToReadField;
            }
            set
            {
                this.NodesToReadField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="HistoryReadValueId", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class HistoryReadValueId : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.NodeId NodeIdField;
        
        private string IndexRangeField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.QualifiedName DataEncodingField;
        
        private byte[] ContinuationPointField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.NodeId NodeId
        {
            get
            {
                return this.NodeIdField;
            }
            set
            {
                this.NodeIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public string IndexRange
        {
            get
            {
                return this.IndexRangeField;
            }
            set
            {
                this.IndexRangeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public opcfoundation.org.UA._2008._02.Types.xsd.QualifiedName DataEncoding
        {
            get
            {
                return this.DataEncodingField;
            }
            set
            {
                this.DataEncodingField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public byte[] ContinuationPoint
        {
            get
            {
                return this.ContinuationPointField;
            }
            set
            {
                this.ContinuationPointField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="HistoryReadResponse", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class HistoryReadResponse : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeaderField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfHistoryReadResult ResultsField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfDiagnosticInfo DiagnosticInfosField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeader
        {
            get
            {
                return this.ResponseHeaderField;
            }
            set
            {
                this.ResponseHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfHistoryReadResult Results
        {
            get
            {
                return this.ResultsField;
            }
            set
            {
                this.ResultsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfDiagnosticInfo DiagnosticInfos
        {
            get
            {
                return this.DiagnosticInfosField;
            }
            set
            {
                this.DiagnosticInfosField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="HistoryReadResult", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class HistoryReadResult : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.StatusCode StatusCodeField;
        
        private byte[] ContinuationPointField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ExtensionObject HistoryDataField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.StatusCode StatusCode
        {
            get
            {
                return this.StatusCodeField;
            }
            set
            {
                this.StatusCodeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public byte[] ContinuationPoint
        {
            get
            {
                return this.ContinuationPointField;
            }
            set
            {
                this.ContinuationPointField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ExtensionObject HistoryData
        {
            get
            {
                return this.HistoryDataField;
            }
            set
            {
                this.HistoryDataField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="WriteRequest", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class WriteRequest : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeaderField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfWriteValue NodesToWriteField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeader
        {
            get
            {
                return this.RequestHeaderField;
            }
            set
            {
                this.RequestHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfWriteValue NodesToWrite
        {
            get
            {
                return this.NodesToWriteField;
            }
            set
            {
                this.NodesToWriteField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="WriteValue", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class WriteValue : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.NodeId NodeIdField;
        
        private uint AttributeIdField;
        
        private string IndexRangeField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.DataValue ValueField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.NodeId NodeId
        {
            get
            {
                return this.NodeIdField;
            }
            set
            {
                this.NodeIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public uint AttributeId
        {
            get
            {
                return this.AttributeIdField;
            }
            set
            {
                this.AttributeIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public string IndexRange
        {
            get
            {
                return this.IndexRangeField;
            }
            set
            {
                this.IndexRangeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public opcfoundation.org.UA._2008._02.Types.xsd.DataValue Value
        {
            get
            {
                return this.ValueField;
            }
            set
            {
                this.ValueField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="WriteResponse", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class WriteResponse : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeaderField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfStatusCode ResultsField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfDiagnosticInfo DiagnosticInfosField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeader
        {
            get
            {
                return this.ResponseHeaderField;
            }
            set
            {
                this.ResponseHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfStatusCode Results
        {
            get
            {
                return this.ResultsField;
            }
            set
            {
                this.ResultsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfDiagnosticInfo DiagnosticInfos
        {
            get
            {
                return this.DiagnosticInfosField;
            }
            set
            {
                this.DiagnosticInfosField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="HistoryUpdateRequest", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class HistoryUpdateRequest : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeaderField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfExtensionObject HistoryUpdateDetailsField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeader
        {
            get
            {
                return this.RequestHeaderField;
            }
            set
            {
                this.RequestHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfExtensionObject HistoryUpdateDetails
        {
            get
            {
                return this.HistoryUpdateDetailsField;
            }
            set
            {
                this.HistoryUpdateDetailsField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="HistoryUpdateResponse", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class HistoryUpdateResponse : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeaderField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfHistoryUpdateResult ResultsField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfDiagnosticInfo DiagnosticInfosField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeader
        {
            get
            {
                return this.ResponseHeaderField;
            }
            set
            {
                this.ResponseHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfHistoryUpdateResult Results
        {
            get
            {
                return this.ResultsField;
            }
            set
            {
                this.ResultsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfDiagnosticInfo DiagnosticInfos
        {
            get
            {
                return this.DiagnosticInfosField;
            }
            set
            {
                this.DiagnosticInfosField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="HistoryUpdateResult", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class HistoryUpdateResult : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.StatusCode StatusCodeField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfStatusCode OperationResultsField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfDiagnosticInfo DiagnosticInfosField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.StatusCode StatusCode
        {
            get
            {
                return this.StatusCodeField;
            }
            set
            {
                this.StatusCodeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfStatusCode OperationResults
        {
            get
            {
                return this.OperationResultsField;
            }
            set
            {
                this.OperationResultsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfDiagnosticInfo DiagnosticInfos
        {
            get
            {
                return this.DiagnosticInfosField;
            }
            set
            {
                this.DiagnosticInfosField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CallRequest", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class CallRequest : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeaderField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfCallMethodRequest MethodsToCallField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeader
        {
            get
            {
                return this.RequestHeaderField;
            }
            set
            {
                this.RequestHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfCallMethodRequest MethodsToCall
        {
            get
            {
                return this.MethodsToCallField;
            }
            set
            {
                this.MethodsToCallField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CallMethodRequest", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class CallMethodRequest : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.NodeId ObjectIdField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.NodeId MethodIdField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfVariant InputArgumentsField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.NodeId ObjectId
        {
            get
            {
                return this.ObjectIdField;
            }
            set
            {
                this.ObjectIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public opcfoundation.org.UA._2008._02.Types.xsd.NodeId MethodId
        {
            get
            {
                return this.MethodIdField;
            }
            set
            {
                this.MethodIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfVariant InputArguments
        {
            get
            {
                return this.InputArgumentsField;
            }
            set
            {
                this.InputArgumentsField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CallResponse", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class CallResponse : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeaderField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfCallMethodResult ResultsField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfDiagnosticInfo DiagnosticInfosField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeader
        {
            get
            {
                return this.ResponseHeaderField;
            }
            set
            {
                this.ResponseHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfCallMethodResult Results
        {
            get
            {
                return this.ResultsField;
            }
            set
            {
                this.ResultsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfDiagnosticInfo DiagnosticInfos
        {
            get
            {
                return this.DiagnosticInfosField;
            }
            set
            {
                this.DiagnosticInfosField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CallMethodResult", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class CallMethodResult : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.StatusCode StatusCodeField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfStatusCode InputArgumentResultsField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfDiagnosticInfo InputArgumentDiagnosticInfosField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfVariant OutputArgumentsField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.StatusCode StatusCode
        {
            get
            {
                return this.StatusCodeField;
            }
            set
            {
                this.StatusCodeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfStatusCode InputArgumentResults
        {
            get
            {
                return this.InputArgumentResultsField;
            }
            set
            {
                this.InputArgumentResultsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfDiagnosticInfo InputArgumentDiagnosticInfos
        {
            get
            {
                return this.InputArgumentDiagnosticInfosField;
            }
            set
            {
                this.InputArgumentDiagnosticInfosField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfVariant OutputArguments
        {
            get
            {
                return this.OutputArgumentsField;
            }
            set
            {
                this.OutputArgumentsField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CreateMonitoredItemsRequest", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class CreateMonitoredItemsRequest : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeaderField;
        
        private uint SubscriptionIdField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.TimestampsToReturn TimestampsToReturnField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfMonitoredItemCreateRequest ItemsToCreateField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeader
        {
            get
            {
                return this.RequestHeaderField;
            }
            set
            {
                this.RequestHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public uint SubscriptionId
        {
            get
            {
                return this.SubscriptionIdField;
            }
            set
            {
                this.SubscriptionIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.TimestampsToReturn TimestampsToReturn
        {
            get
            {
                return this.TimestampsToReturnField;
            }
            set
            {
                this.TimestampsToReturnField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfMonitoredItemCreateRequest ItemsToCreate
        {
            get
            {
                return this.ItemsToCreateField;
            }
            set
            {
                this.ItemsToCreateField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MonitoredItemCreateRequest", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class MonitoredItemCreateRequest : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ReadValueId ItemToMonitorField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.MonitoringMode MonitoringModeField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.MonitoringParameters RequestedParametersField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ReadValueId ItemToMonitor
        {
            get
            {
                return this.ItemToMonitorField;
            }
            set
            {
                this.ItemToMonitorField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.MonitoringMode MonitoringMode
        {
            get
            {
                return this.MonitoringModeField;
            }
            set
            {
                this.MonitoringModeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.MonitoringParameters RequestedParameters
        {
            get
            {
                return this.RequestedParametersField;
            }
            set
            {
                this.RequestedParametersField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MonitoringParameters", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class MonitoringParameters : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private uint ClientHandleField;
        
        private double SamplingIntervalField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ExtensionObject FilterField;
        
        private uint QueueSizeField;
        
        private bool DiscardOldestField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public uint ClientHandle
        {
            get
            {
                return this.ClientHandleField;
            }
            set
            {
                this.ClientHandleField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double SamplingInterval
        {
            get
            {
                return this.SamplingIntervalField;
            }
            set
            {
                this.SamplingIntervalField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ExtensionObject Filter
        {
            get
            {
                return this.FilterField;
            }
            set
            {
                this.FilterField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public uint QueueSize
        {
            get
            {
                return this.QueueSizeField;
            }
            set
            {
                this.QueueSizeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public bool DiscardOldest
        {
            get
            {
                return this.DiscardOldestField;
            }
            set
            {
                this.DiscardOldestField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CreateMonitoredItemsResponse", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class CreateMonitoredItemsResponse : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeaderField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfMonitoredItemCreateResult ResultsField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfDiagnosticInfo DiagnosticInfosField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeader
        {
            get
            {
                return this.ResponseHeaderField;
            }
            set
            {
                this.ResponseHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfMonitoredItemCreateResult Results
        {
            get
            {
                return this.ResultsField;
            }
            set
            {
                this.ResultsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfDiagnosticInfo DiagnosticInfos
        {
            get
            {
                return this.DiagnosticInfosField;
            }
            set
            {
                this.DiagnosticInfosField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MonitoredItemCreateResult", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class MonitoredItemCreateResult : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.StatusCode StatusCodeField;
        
        private uint MonitoredItemIdField;
        
        private double RevisedSamplingIntervalField;
        
        private uint RevisedQueueSizeField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ExtensionObject FilterResultField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.StatusCode StatusCode
        {
            get
            {
                return this.StatusCodeField;
            }
            set
            {
                this.StatusCodeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public uint MonitoredItemId
        {
            get
            {
                return this.MonitoredItemIdField;
            }
            set
            {
                this.MonitoredItemIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public double RevisedSamplingInterval
        {
            get
            {
                return this.RevisedSamplingIntervalField;
            }
            set
            {
                this.RevisedSamplingIntervalField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public uint RevisedQueueSize
        {
            get
            {
                return this.RevisedQueueSizeField;
            }
            set
            {
                this.RevisedQueueSizeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ExtensionObject FilterResult
        {
            get
            {
                return this.FilterResultField;
            }
            set
            {
                this.FilterResultField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ModifyMonitoredItemsRequest", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class ModifyMonitoredItemsRequest : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeaderField;
        
        private uint SubscriptionIdField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.TimestampsToReturn TimestampsToReturnField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfMonitoredItemModifyRequest ItemsToModifyField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeader
        {
            get
            {
                return this.RequestHeaderField;
            }
            set
            {
                this.RequestHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public uint SubscriptionId
        {
            get
            {
                return this.SubscriptionIdField;
            }
            set
            {
                this.SubscriptionIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.TimestampsToReturn TimestampsToReturn
        {
            get
            {
                return this.TimestampsToReturnField;
            }
            set
            {
                this.TimestampsToReturnField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfMonitoredItemModifyRequest ItemsToModify
        {
            get
            {
                return this.ItemsToModifyField;
            }
            set
            {
                this.ItemsToModifyField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MonitoredItemModifyRequest", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class MonitoredItemModifyRequest : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private uint MonitoredItemIdField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.MonitoringParameters RequestedParametersField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public uint MonitoredItemId
        {
            get
            {
                return this.MonitoredItemIdField;
            }
            set
            {
                this.MonitoredItemIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.MonitoringParameters RequestedParameters
        {
            get
            {
                return this.RequestedParametersField;
            }
            set
            {
                this.RequestedParametersField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ModifyMonitoredItemsResponse", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class ModifyMonitoredItemsResponse : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeaderField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfMonitoredItemModifyResult ResultsField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfDiagnosticInfo DiagnosticInfosField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeader
        {
            get
            {
                return this.ResponseHeaderField;
            }
            set
            {
                this.ResponseHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfMonitoredItemModifyResult Results
        {
            get
            {
                return this.ResultsField;
            }
            set
            {
                this.ResultsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfDiagnosticInfo DiagnosticInfos
        {
            get
            {
                return this.DiagnosticInfosField;
            }
            set
            {
                this.DiagnosticInfosField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MonitoredItemModifyResult", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class MonitoredItemModifyResult : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.StatusCode StatusCodeField;
        
        private double RevisedSamplingIntervalField;
        
        private uint RevisedQueueSizeField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ExtensionObject FilterResultField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.StatusCode StatusCode
        {
            get
            {
                return this.StatusCodeField;
            }
            set
            {
                this.StatusCodeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public double RevisedSamplingInterval
        {
            get
            {
                return this.RevisedSamplingIntervalField;
            }
            set
            {
                this.RevisedSamplingIntervalField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public uint RevisedQueueSize
        {
            get
            {
                return this.RevisedQueueSizeField;
            }
            set
            {
                this.RevisedQueueSizeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ExtensionObject FilterResult
        {
            get
            {
                return this.FilterResultField;
            }
            set
            {
                this.FilterResultField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SetMonitoringModeRequest", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class SetMonitoringModeRequest : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeaderField;
        
        private uint SubscriptionIdField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.MonitoringMode MonitoringModeField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfUInt32 MonitoredItemIdsField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeader
        {
            get
            {
                return this.RequestHeaderField;
            }
            set
            {
                this.RequestHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public uint SubscriptionId
        {
            get
            {
                return this.SubscriptionIdField;
            }
            set
            {
                this.SubscriptionIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public opcfoundation.org.UA._2008._02.Types.xsd.MonitoringMode MonitoringMode
        {
            get
            {
                return this.MonitoringModeField;
            }
            set
            {
                this.MonitoringModeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfUInt32 MonitoredItemIds
        {
            get
            {
                return this.MonitoredItemIdsField;
            }
            set
            {
                this.MonitoredItemIdsField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SetMonitoringModeResponse", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class SetMonitoringModeResponse : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeaderField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfStatusCode ResultsField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfDiagnosticInfo DiagnosticInfosField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeader
        {
            get
            {
                return this.ResponseHeaderField;
            }
            set
            {
                this.ResponseHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfStatusCode Results
        {
            get
            {
                return this.ResultsField;
            }
            set
            {
                this.ResultsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfDiagnosticInfo DiagnosticInfos
        {
            get
            {
                return this.DiagnosticInfosField;
            }
            set
            {
                this.DiagnosticInfosField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SetTriggeringRequest", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class SetTriggeringRequest : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeaderField;
        
        private uint SubscriptionIdField;
        
        private uint TriggeringItemIdField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfUInt32 LinksToAddField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfUInt32 LinksToRemoveField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeader
        {
            get
            {
                return this.RequestHeaderField;
            }
            set
            {
                this.RequestHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public uint SubscriptionId
        {
            get
            {
                return this.SubscriptionIdField;
            }
            set
            {
                this.SubscriptionIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public uint TriggeringItemId
        {
            get
            {
                return this.TriggeringItemIdField;
            }
            set
            {
                this.TriggeringItemIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfUInt32 LinksToAdd
        {
            get
            {
                return this.LinksToAddField;
            }
            set
            {
                this.LinksToAddField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfUInt32 LinksToRemove
        {
            get
            {
                return this.LinksToRemoveField;
            }
            set
            {
                this.LinksToRemoveField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SetTriggeringResponse", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class SetTriggeringResponse : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeaderField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfStatusCode AddResultsField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfDiagnosticInfo AddDiagnosticInfosField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfStatusCode RemoveResultsField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfDiagnosticInfo RemoveDiagnosticInfosField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeader
        {
            get
            {
                return this.ResponseHeaderField;
            }
            set
            {
                this.ResponseHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfStatusCode AddResults
        {
            get
            {
                return this.AddResultsField;
            }
            set
            {
                this.AddResultsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfDiagnosticInfo AddDiagnosticInfos
        {
            get
            {
                return this.AddDiagnosticInfosField;
            }
            set
            {
                this.AddDiagnosticInfosField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfStatusCode RemoveResults
        {
            get
            {
                return this.RemoveResultsField;
            }
            set
            {
                this.RemoveResultsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfDiagnosticInfo RemoveDiagnosticInfos
        {
            get
            {
                return this.RemoveDiagnosticInfosField;
            }
            set
            {
                this.RemoveDiagnosticInfosField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DeleteMonitoredItemsRequest", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class DeleteMonitoredItemsRequest : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeaderField;
        
        private uint SubscriptionIdField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfUInt32 MonitoredItemIdsField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeader
        {
            get
            {
                return this.RequestHeaderField;
            }
            set
            {
                this.RequestHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public uint SubscriptionId
        {
            get
            {
                return this.SubscriptionIdField;
            }
            set
            {
                this.SubscriptionIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfUInt32 MonitoredItemIds
        {
            get
            {
                return this.MonitoredItemIdsField;
            }
            set
            {
                this.MonitoredItemIdsField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DeleteMonitoredItemsResponse", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class DeleteMonitoredItemsResponse : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeaderField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfStatusCode ResultsField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfDiagnosticInfo DiagnosticInfosField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeader
        {
            get
            {
                return this.ResponseHeaderField;
            }
            set
            {
                this.ResponseHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfStatusCode Results
        {
            get
            {
                return this.ResultsField;
            }
            set
            {
                this.ResultsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfDiagnosticInfo DiagnosticInfos
        {
            get
            {
                return this.DiagnosticInfosField;
            }
            set
            {
                this.DiagnosticInfosField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CreateSubscriptionRequest", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class CreateSubscriptionRequest : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeaderField;
        
        private double RequestedPublishingIntervalField;
        
        private uint RequestedLifetimeCountField;
        
        private uint RequestedMaxKeepAliveCountField;
        
        private uint MaxNotificationsPerPublishField;
        
        private bool PublishingEnabledField;
        
        private byte PriorityField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeader
        {
            get
            {
                return this.RequestHeaderField;
            }
            set
            {
                this.RequestHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double RequestedPublishingInterval
        {
            get
            {
                return this.RequestedPublishingIntervalField;
            }
            set
            {
                this.RequestedPublishingIntervalField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public uint RequestedLifetimeCount
        {
            get
            {
                return this.RequestedLifetimeCountField;
            }
            set
            {
                this.RequestedLifetimeCountField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public uint RequestedMaxKeepAliveCount
        {
            get
            {
                return this.RequestedMaxKeepAliveCountField;
            }
            set
            {
                this.RequestedMaxKeepAliveCountField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public uint MaxNotificationsPerPublish
        {
            get
            {
                return this.MaxNotificationsPerPublishField;
            }
            set
            {
                this.MaxNotificationsPerPublishField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=5)]
        public bool PublishingEnabled
        {
            get
            {
                return this.PublishingEnabledField;
            }
            set
            {
                this.PublishingEnabledField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=6)]
        public byte Priority
        {
            get
            {
                return this.PriorityField;
            }
            set
            {
                this.PriorityField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CreateSubscriptionResponse", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class CreateSubscriptionResponse : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeaderField;
        
        private uint SubscriptionIdField;
        
        private double RevisedPublishingIntervalField;
        
        private uint RevisedLifetimeCountField;
        
        private uint RevisedMaxKeepAliveCountField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeader
        {
            get
            {
                return this.ResponseHeaderField;
            }
            set
            {
                this.ResponseHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public uint SubscriptionId
        {
            get
            {
                return this.SubscriptionIdField;
            }
            set
            {
                this.SubscriptionIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public double RevisedPublishingInterval
        {
            get
            {
                return this.RevisedPublishingIntervalField;
            }
            set
            {
                this.RevisedPublishingIntervalField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public uint RevisedLifetimeCount
        {
            get
            {
                return this.RevisedLifetimeCountField;
            }
            set
            {
                this.RevisedLifetimeCountField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public uint RevisedMaxKeepAliveCount
        {
            get
            {
                return this.RevisedMaxKeepAliveCountField;
            }
            set
            {
                this.RevisedMaxKeepAliveCountField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ModifySubscriptionRequest", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class ModifySubscriptionRequest : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeaderField;
        
        private uint SubscriptionIdField;
        
        private double RequestedPublishingIntervalField;
        
        private uint RequestedLifetimeCountField;
        
        private uint RequestedMaxKeepAliveCountField;
        
        private uint MaxNotificationsPerPublishField;
        
        private byte PriorityField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeader
        {
            get
            {
                return this.RequestHeaderField;
            }
            set
            {
                this.RequestHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public uint SubscriptionId
        {
            get
            {
                return this.SubscriptionIdField;
            }
            set
            {
                this.SubscriptionIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public double RequestedPublishingInterval
        {
            get
            {
                return this.RequestedPublishingIntervalField;
            }
            set
            {
                this.RequestedPublishingIntervalField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public uint RequestedLifetimeCount
        {
            get
            {
                return this.RequestedLifetimeCountField;
            }
            set
            {
                this.RequestedLifetimeCountField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public uint RequestedMaxKeepAliveCount
        {
            get
            {
                return this.RequestedMaxKeepAliveCountField;
            }
            set
            {
                this.RequestedMaxKeepAliveCountField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=5)]
        public uint MaxNotificationsPerPublish
        {
            get
            {
                return this.MaxNotificationsPerPublishField;
            }
            set
            {
                this.MaxNotificationsPerPublishField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=6)]
        public byte Priority
        {
            get
            {
                return this.PriorityField;
            }
            set
            {
                this.PriorityField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ModifySubscriptionResponse", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class ModifySubscriptionResponse : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeaderField;
        
        private double RevisedPublishingIntervalField;
        
        private uint RevisedLifetimeCountField;
        
        private uint RevisedMaxKeepAliveCountField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeader
        {
            get
            {
                return this.ResponseHeaderField;
            }
            set
            {
                this.ResponseHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double RevisedPublishingInterval
        {
            get
            {
                return this.RevisedPublishingIntervalField;
            }
            set
            {
                this.RevisedPublishingIntervalField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public uint RevisedLifetimeCount
        {
            get
            {
                return this.RevisedLifetimeCountField;
            }
            set
            {
                this.RevisedLifetimeCountField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public uint RevisedMaxKeepAliveCount
        {
            get
            {
                return this.RevisedMaxKeepAliveCountField;
            }
            set
            {
                this.RevisedMaxKeepAliveCountField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SetPublishingModeRequest", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class SetPublishingModeRequest : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeaderField;
        
        private bool PublishingEnabledField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfUInt32 SubscriptionIdsField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeader
        {
            get
            {
                return this.RequestHeaderField;
            }
            set
            {
                this.RequestHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public bool PublishingEnabled
        {
            get
            {
                return this.PublishingEnabledField;
            }
            set
            {
                this.PublishingEnabledField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfUInt32 SubscriptionIds
        {
            get
            {
                return this.SubscriptionIdsField;
            }
            set
            {
                this.SubscriptionIdsField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SetPublishingModeResponse", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class SetPublishingModeResponse : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeaderField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfStatusCode ResultsField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfDiagnosticInfo DiagnosticInfosField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeader
        {
            get
            {
                return this.ResponseHeaderField;
            }
            set
            {
                this.ResponseHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfStatusCode Results
        {
            get
            {
                return this.ResultsField;
            }
            set
            {
                this.ResultsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfDiagnosticInfo DiagnosticInfos
        {
            get
            {
                return this.DiagnosticInfosField;
            }
            set
            {
                this.DiagnosticInfosField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PublishRequest", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class PublishRequest : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeaderField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfSubscriptionAcknowledgement SubscriptionAcknowledgementsField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeader
        {
            get
            {
                return this.RequestHeaderField;
            }
            set
            {
                this.RequestHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfSubscriptionAcknowledgement SubscriptionAcknowledgements
        {
            get
            {
                return this.SubscriptionAcknowledgementsField;
            }
            set
            {
                this.SubscriptionAcknowledgementsField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SubscriptionAcknowledgement", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class SubscriptionAcknowledgement : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private uint SubscriptionIdField;
        
        private uint SequenceNumberField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public uint SubscriptionId
        {
            get
            {
                return this.SubscriptionIdField;
            }
            set
            {
                this.SubscriptionIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public uint SequenceNumber
        {
            get
            {
                return this.SequenceNumberField;
            }
            set
            {
                this.SequenceNumberField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PublishResponse", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class PublishResponse : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeaderField;
        
        private uint SubscriptionIdField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfUInt32 AvailableSequenceNumbersField;
        
        private bool MoreNotificationsField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.NotificationMessage NotificationMessageField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfStatusCode ResultsField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfDiagnosticInfo DiagnosticInfosField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeader
        {
            get
            {
                return this.ResponseHeaderField;
            }
            set
            {
                this.ResponseHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public uint SubscriptionId
        {
            get
            {
                return this.SubscriptionIdField;
            }
            set
            {
                this.SubscriptionIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfUInt32 AvailableSequenceNumbers
        {
            get
            {
                return this.AvailableSequenceNumbersField;
            }
            set
            {
                this.AvailableSequenceNumbersField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public bool MoreNotifications
        {
            get
            {
                return this.MoreNotificationsField;
            }
            set
            {
                this.MoreNotificationsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public opcfoundation.org.UA._2008._02.Types.xsd.NotificationMessage NotificationMessage
        {
            get
            {
                return this.NotificationMessageField;
            }
            set
            {
                this.NotificationMessageField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=5)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfStatusCode Results
        {
            get
            {
                return this.ResultsField;
            }
            set
            {
                this.ResultsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=6)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfDiagnosticInfo DiagnosticInfos
        {
            get
            {
                return this.DiagnosticInfosField;
            }
            set
            {
                this.DiagnosticInfosField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="NotificationMessage", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class NotificationMessage : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private uint SequenceNumberField;
        
        private System.DateTime PublishTimeField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfExtensionObject NotificationDataField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public uint SequenceNumber
        {
            get
            {
                return this.SequenceNumberField;
            }
            set
            {
                this.SequenceNumberField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public System.DateTime PublishTime
        {
            get
            {
                return this.PublishTimeField;
            }
            set
            {
                this.PublishTimeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfExtensionObject NotificationData
        {
            get
            {
                return this.NotificationDataField;
            }
            set
            {
                this.NotificationDataField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RepublishRequest", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class RepublishRequest : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeaderField;
        
        private uint SubscriptionIdField;
        
        private uint RetransmitSequenceNumberField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeader
        {
            get
            {
                return this.RequestHeaderField;
            }
            set
            {
                this.RequestHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public uint SubscriptionId
        {
            get
            {
                return this.SubscriptionIdField;
            }
            set
            {
                this.SubscriptionIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public uint RetransmitSequenceNumber
        {
            get
            {
                return this.RetransmitSequenceNumberField;
            }
            set
            {
                this.RetransmitSequenceNumberField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RepublishResponse", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class RepublishResponse : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeaderField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.NotificationMessage NotificationMessageField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeader
        {
            get
            {
                return this.ResponseHeaderField;
            }
            set
            {
                this.ResponseHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public opcfoundation.org.UA._2008._02.Types.xsd.NotificationMessage NotificationMessage
        {
            get
            {
                return this.NotificationMessageField;
            }
            set
            {
                this.NotificationMessageField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TransferSubscriptionsRequest", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class TransferSubscriptionsRequest : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeaderField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfUInt32 SubscriptionIdsField;
        
        private bool SendInitialValuesField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeader
        {
            get
            {
                return this.RequestHeaderField;
            }
            set
            {
                this.RequestHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfUInt32 SubscriptionIds
        {
            get
            {
                return this.SubscriptionIdsField;
            }
            set
            {
                this.SubscriptionIdsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public bool SendInitialValues
        {
            get
            {
                return this.SendInitialValuesField;
            }
            set
            {
                this.SendInitialValuesField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TransferSubscriptionsResponse", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class TransferSubscriptionsResponse : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeaderField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfTransferResult ResultsField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfDiagnosticInfo DiagnosticInfosField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeader
        {
            get
            {
                return this.ResponseHeaderField;
            }
            set
            {
                this.ResponseHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfTransferResult Results
        {
            get
            {
                return this.ResultsField;
            }
            set
            {
                this.ResultsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfDiagnosticInfo DiagnosticInfos
        {
            get
            {
                return this.DiagnosticInfosField;
            }
            set
            {
                this.DiagnosticInfosField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TransferResult", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class TransferResult : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.StatusCode StatusCodeField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfUInt32 AvailableSequenceNumbersField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.StatusCode StatusCode
        {
            get
            {
                return this.StatusCodeField;
            }
            set
            {
                this.StatusCodeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfUInt32 AvailableSequenceNumbers
        {
            get
            {
                return this.AvailableSequenceNumbersField;
            }
            set
            {
                this.AvailableSequenceNumbersField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DeleteSubscriptionsRequest", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class DeleteSubscriptionsRequest : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeaderField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfUInt32 SubscriptionIdsField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeader
        {
            get
            {
                return this.RequestHeaderField;
            }
            set
            {
                this.RequestHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfUInt32 SubscriptionIds
        {
            get
            {
                return this.SubscriptionIdsField;
            }
            set
            {
                this.SubscriptionIdsField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DeleteSubscriptionsResponse", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class DeleteSubscriptionsResponse : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeaderField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfStatusCode ResultsField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfDiagnosticInfo DiagnosticInfosField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeader
        {
            get
            {
                return this.ResponseHeaderField;
            }
            set
            {
                this.ResponseHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfStatusCode Results
        {
            get
            {
                return this.ResultsField;
            }
            set
            {
                this.ResultsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfDiagnosticInfo DiagnosticInfos
        {
            get
            {
                return this.DiagnosticInfosField;
            }
            set
            {
                this.DiagnosticInfosField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="FindServersRequest", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class FindServersRequest : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeaderField;
        
        private string EndpointUrlField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfString LocaleIdsField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfString ServerUrisField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeader
        {
            get
            {
                return this.RequestHeaderField;
            }
            set
            {
                this.RequestHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public string EndpointUrl
        {
            get
            {
                return this.EndpointUrlField;
            }
            set
            {
                this.EndpointUrlField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfString LocaleIds
        {
            get
            {
                return this.LocaleIdsField;
            }
            set
            {
                this.LocaleIdsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfString ServerUris
        {
            get
            {
                return this.ServerUrisField;
            }
            set
            {
                this.ServerUrisField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="FindServersResponse", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class FindServersResponse : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeaderField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfApplicationDescription ServersField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeader
        {
            get
            {
                return this.ResponseHeaderField;
            }
            set
            {
                this.ResponseHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfApplicationDescription Servers
        {
            get
            {
                return this.ServersField;
            }
            set
            {
                this.ServersField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="GetEndpointsRequest", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class GetEndpointsRequest : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeaderField;
        
        private string EndpointUrlField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfString LocaleIdsField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfString ProfileUrisField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeader
        {
            get
            {
                return this.RequestHeaderField;
            }
            set
            {
                this.RequestHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public string EndpointUrl
        {
            get
            {
                return this.EndpointUrlField;
            }
            set
            {
                this.EndpointUrlField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfString LocaleIds
        {
            get
            {
                return this.LocaleIdsField;
            }
            set
            {
                this.LocaleIdsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfString ProfileUris
        {
            get
            {
                return this.ProfileUrisField;
            }
            set
            {
                this.ProfileUrisField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="GetEndpointsResponse", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class GetEndpointsResponse : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeaderField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.ListOfEndpointDescription EndpointsField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.ResponseHeader ResponseHeader
        {
            get
            {
                return this.ResponseHeaderField;
            }
            set
            {
                this.ResponseHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public opcfoundation.org.UA._2008._02.Types.xsd.ListOfEndpointDescription Endpoints
        {
            get
            {
                return this.EndpointsField;
            }
            set
            {
                this.EndpointsField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TestStackRequest", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class TestStackRequest : opcfoundation.org.UA._2008._02.Types.xsd.EncodeableObject
    {
        
        private opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeaderField;
        
        private uint TestIdField;
        
        private int IterationField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.Variant InputField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.RequestHeader RequestHeader
        {
            get
            {
                return this.RequestHeaderField;
            }
            set
            {
                this.RequestHeaderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public uint TestId
        {
            get
            {
                return this.TestIdField;
            }
            set
            {
                this.TestIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public int Iteration
        {
            get
            {
                return this.IterationField;
            }
            set
            {
                this.IterationField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public opcfoundation.org.UA._2008._02.Types.xsd.Variant Input
        {
            get
            {
                return this.InputField;
            }
            set
            {
                this.InputField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Variant", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial struct Variant : System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private System.Xml.XmlElement ValueField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Xml.XmlElement Value
        {
            get
            {
                return this.ValueField;
            }
            set
            {
                this.ValueField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="NodeId", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class NodeId : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string IdentifierField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Identifier
        {
            get
            {
                return this.IdentifierField;
            }
            set
            {
                this.IdentifierField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ExtensionObject", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class ExtensionObject : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.NodeId TypeIdField;
        
        private System.Xml.XmlElement BodyField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.NodeId TypeId
        {
            get
            {
                return this.TypeIdField;
            }
            set
            {
                this.TypeIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public System.Xml.XmlElement Body
        {
            get
            {
                return this.BodyField;
            }
            set
            {
                this.BodyField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="StatusCode", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial struct StatusCode : System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private uint CodeField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public uint Code
        {
            get
            {
                return this.CodeField;
            }
            set
            {
                this.CodeField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DiagnosticInfo", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class DiagnosticInfo : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int SymbolicIdField;
        
        private int NamespaceUriField;
        
        private int LocaleField;
        
        private int LocalizedTextField;
        
        private string AdditionalInfoField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.StatusCode InnerStatusCodeField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.DiagnosticInfo InnerDiagnosticInfoField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int SymbolicId
        {
            get
            {
                return this.SymbolicIdField;
            }
            set
            {
                this.SymbolicIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public int NamespaceUri
        {
            get
            {
                return this.NamespaceUriField;
            }
            set
            {
                this.NamespaceUriField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public int Locale
        {
            get
            {
                return this.LocaleField;
            }
            set
            {
                this.LocaleField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public int LocalizedText
        {
            get
            {
                return this.LocalizedTextField;
            }
            set
            {
                this.LocalizedTextField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public string AdditionalInfo
        {
            get
            {
                return this.AdditionalInfoField;
            }
            set
            {
                this.AdditionalInfoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=5)]
        public opcfoundation.org.UA._2008._02.Types.xsd.StatusCode InnerStatusCode
        {
            get
            {
                return this.InnerStatusCodeField;
            }
            set
            {
                this.InnerStatusCodeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=6)]
        public opcfoundation.org.UA._2008._02.Types.xsd.DiagnosticInfo InnerDiagnosticInfo
        {
            get
            {
                return this.InnerDiagnosticInfoField;
            }
            set
            {
                this.InnerDiagnosticInfoField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfString", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName="String")]
    public class ListOfString : System.Collections.Generic.List<string>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Guid", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial struct Guid : System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string StringField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string String
        {
            get
            {
                return this.StringField;
            }
            set
            {
                this.StringField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ExpandedNodeId", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class ExpandedNodeId : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string IdentifierField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Identifier
        {
            get
            {
                return this.IdentifierField;
            }
            set
            {
                this.IdentifierField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="QualifiedName", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class QualifiedName : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private ushort NamespaceIndexField;
        
        private string NameField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ushort NamespaceIndex
        {
            get
            {
                return this.NamespaceIndexField;
            }
            set
            {
                this.NamespaceIndexField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public string Name
        {
            get
            {
                return this.NameField;
            }
            set
            {
                this.NameField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="LocalizedText", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class LocalizedText : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string LocaleField;
        
        private string TextField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Locale
        {
            get
            {
                return this.LocaleField;
            }
            set
            {
                this.LocaleField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Text
        {
            get
            {
                return this.TextField;
            }
            set
            {
                this.TextField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DataValue", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public partial class DataValue : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.Variant ValueField;
        
        private opcfoundation.org.UA._2008._02.Types.xsd.StatusCode StatusCodeField;
        
        private System.DateTime SourceTimestampField;
        
        private ushort SourcePicosecondsField;
        
        private System.DateTime ServerTimestampField;
        
        private ushort ServerPicosecondsField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public opcfoundation.org.UA._2008._02.Types.xsd.Variant Value
        {
            get
            {
                return this.ValueField;
            }
            set
            {
                this.ValueField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public opcfoundation.org.UA._2008._02.Types.xsd.StatusCode StatusCode
        {
            get
            {
                return this.StatusCodeField;
            }
            set
            {
                this.StatusCodeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public System.DateTime SourceTimestamp
        {
            get
            {
                return this.SourceTimestampField;
            }
            set
            {
                this.SourceTimestampField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public ushort SourcePicoseconds
        {
            get
            {
                return this.SourcePicosecondsField;
            }
            set
            {
                this.SourcePicosecondsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public System.DateTime ServerTimestamp
        {
            get
            {
                return this.ServerTimestampField;
            }
            set
            {
                this.ServerTimestampField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=5)]
        public ushort ServerPicoseconds
        {
            get
            {
                return this.ServerPicosecondsField;
            }
            set
            {
                this.ServerPicosecondsField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EnumeratedTestType", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public enum EnumeratedTestType : int
    {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Red_1 = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Yellow_4 = 4,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Green_5 = 5,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfBoolean", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName="Boolean")]
    public class ListOfBoolean : System.Collections.Generic.List<bool>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfSByte", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName="SByte")]
    public class ListOfSByte : System.Collections.Generic.List<sbyte>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfInt16", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName="Int16")]
    public class ListOfInt16 : System.Collections.Generic.List<short>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfUInt16", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName="UInt16")]
    public class ListOfUInt16 : System.Collections.Generic.List<ushort>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfInt32", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName="Int32")]
    public class ListOfInt32 : System.Collections.Generic.List<int>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfUInt32", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName="UInt32")]
    public class ListOfUInt32 : System.Collections.Generic.List<uint>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfInt64", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName="Int64")]
    public class ListOfInt64 : System.Collections.Generic.List<long>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfUInt64", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName="UInt64")]
    public class ListOfUInt64 : System.Collections.Generic.List<ulong>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfFloat", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName="Float")]
    public class ListOfFloat : System.Collections.Generic.List<float>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfDouble", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName="Double")]
    public class ListOfDouble : System.Collections.Generic.List<double>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfDateTime", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName="DateTime")]
    public class ListOfDateTime : System.Collections.Generic.List<System.DateTime>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfGuid", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName="Guid")]
    public class ListOfGuid : System.Collections.Generic.List<opcfoundation.org.UA._2008._02.Types.xsd.Guid>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfByteString", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName="ByteString")]
    public class ListOfByteString : System.Collections.Generic.List<byte[]>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfXmlElement", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName="XmlElement")]
    public class ListOfXmlElement : System.Collections.Generic.List<System.Xml.XmlElement>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfNodeId", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName="NodeId")]
    public class ListOfNodeId : System.Collections.Generic.List<opcfoundation.org.UA._2008._02.Types.xsd.NodeId>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfExpandedNodeId", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName="ExpandedNodeId")]
    public class ListOfExpandedNodeId : System.Collections.Generic.List<opcfoundation.org.UA._2008._02.Types.xsd.ExpandedNodeId>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfStatusCode", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName="StatusCode")]
    public class ListOfStatusCode : System.Collections.Generic.List<opcfoundation.org.UA._2008._02.Types.xsd.StatusCode>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfDiagnosticInfo", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName="DiagnosticInfo")]
    public class ListOfDiagnosticInfo : System.Collections.Generic.List<opcfoundation.org.UA._2008._02.Types.xsd.DiagnosticInfo>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfQualifiedName", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName="QualifiedName")]
    public class ListOfQualifiedName : System.Collections.Generic.List<opcfoundation.org.UA._2008._02.Types.xsd.QualifiedName>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfLocalizedText", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName="LocalizedText")]
    public class ListOfLocalizedText : System.Collections.Generic.List<opcfoundation.org.UA._2008._02.Types.xsd.LocalizedText>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfExtensionObject", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName="ExtensionObject")]
    public class ListOfExtensionObject : System.Collections.Generic.List<opcfoundation.org.UA._2008._02.Types.xsd.ExtensionObject>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfDataValue", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName="DataValue")]
    public class ListOfDataValue : System.Collections.Generic.List<opcfoundation.org.UA._2008._02.Types.xsd.DataValue>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfVariant", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName="Variant")]
    public class ListOfVariant : System.Collections.Generic.List<opcfoundation.org.UA._2008._02.Types.xsd.Variant>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfEnumeratedTestType", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName="EnumeratedTestType")]
    public class ListOfEnumeratedTestType : System.Collections.Generic.List<opcfoundation.org.UA._2008._02.Types.xsd.EnumeratedTestType>
    {
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ApplicationType", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public enum ApplicationType : int
    {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Server_0 = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Client_1 = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ClientAndServer_2 = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        DiscoveryServer_3 = 3,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfEndpointDescription", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName="EndpointDescription")]
    public class ListOfEndpointDescription : System.Collections.Generic.List<opcfoundation.org.UA._2008._02.Types.xsd.EndpointDescription>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfSignedSoftwareCertificate", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName="SignedSoftwareCertificate")]
    public class ListOfSignedSoftwareCertificate : System.Collections.Generic.List<opcfoundation.org.UA._2008._02.Types.xsd.SignedSoftwareCertificate>
    {
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MessageSecurityMode", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public enum MessageSecurityMode : int
    {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Invalid_0 = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        None_1 = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Sign_2 = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        SignAndEncrypt_3 = 3,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfUserTokenPolicy", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName="UserTokenPolicy")]
    public class ListOfUserTokenPolicy : System.Collections.Generic.List<opcfoundation.org.UA._2008._02.Types.xsd.UserTokenPolicy>
    {
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UserTokenType", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public enum UserTokenType : int
    {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Anonymous_0 = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        UserName_1 = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Certificate_2 = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        IssuedToken_3 = 3,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfAddNodesItem", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName="AddNodesItem")]
    public class ListOfAddNodesItem : System.Collections.Generic.List<opcfoundation.org.UA._2008._02.Types.xsd.AddNodesItem>
    {
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="NodeClass", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public enum NodeClass : int
    {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Unspecified_0 = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Object_1 = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Variable_2 = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Method_4 = 4,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ObjectType_8 = 8,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        VariableType_16 = 16,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ReferenceType_32 = 32,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        DataType_64 = 64,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        View_128 = 128,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfAddNodesResult", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName="AddNodesResult")]
    public class ListOfAddNodesResult : System.Collections.Generic.List<opcfoundation.org.UA._2008._02.Types.xsd.AddNodesResult>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfAddReferencesItem", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName="AddReferencesItem")]
    public class ListOfAddReferencesItem : System.Collections.Generic.List<opcfoundation.org.UA._2008._02.Types.xsd.AddReferencesItem>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfDeleteNodesItem", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName="DeleteNodesItem")]
    public class ListOfDeleteNodesItem : System.Collections.Generic.List<opcfoundation.org.UA._2008._02.Types.xsd.DeleteNodesItem>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfDeleteReferencesItem", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName="DeleteReferencesItem")]
    public class ListOfDeleteReferencesItem : System.Collections.Generic.List<opcfoundation.org.UA._2008._02.Types.xsd.DeleteReferencesItem>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfBrowseDescription", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName="BrowseDescription")]
    public class ListOfBrowseDescription : System.Collections.Generic.List<opcfoundation.org.UA._2008._02.Types.xsd.BrowseDescription>
    {
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BrowseDirection", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public enum BrowseDirection : int
    {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Forward_0 = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Inverse_1 = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Both_2 = 2,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfBrowseResult", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName="BrowseResult")]
    public class ListOfBrowseResult : System.Collections.Generic.List<opcfoundation.org.UA._2008._02.Types.xsd.BrowseResult>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfReferenceDescription", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName="ReferenceDescription")]
    public class ListOfReferenceDescription : System.Collections.Generic.List<opcfoundation.org.UA._2008._02.Types.xsd.ReferenceDescription>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfBrowsePath", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName="BrowsePath")]
    public class ListOfBrowsePath : System.Collections.Generic.List<opcfoundation.org.UA._2008._02.Types.xsd.BrowsePath>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfRelativePathElement", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName="RelativePathElement")]
    public class ListOfRelativePathElement : System.Collections.Generic.List<opcfoundation.org.UA._2008._02.Types.xsd.RelativePathElement>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfBrowsePathResult", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName="BrowsePathResult")]
    public class ListOfBrowsePathResult : System.Collections.Generic.List<opcfoundation.org.UA._2008._02.Types.xsd.BrowsePathResult>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfBrowsePathTarget", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName="BrowsePathTarget")]
    public class ListOfBrowsePathTarget : System.Collections.Generic.List<opcfoundation.org.UA._2008._02.Types.xsd.BrowsePathTarget>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfNodeTypeDescription", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName="NodeTypeDescription")]
    public class ListOfNodeTypeDescription : System.Collections.Generic.List<opcfoundation.org.UA._2008._02.Types.xsd.NodeTypeDescription>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfQueryDataDescription", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName="QueryDataDescription")]
    public class ListOfQueryDataDescription : System.Collections.Generic.List<opcfoundation.org.UA._2008._02.Types.xsd.QueryDataDescription>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfContentFilterElement", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName="ContentFilterElement")]
    public class ListOfContentFilterElement : System.Collections.Generic.List<opcfoundation.org.UA._2008._02.Types.xsd.ContentFilterElement>
    {
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="FilterOperator", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public enum FilterOperator : int
    {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Equals_0 = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        IsNull_1 = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        GreaterThan_2 = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        LessThan_3 = 3,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        GreaterThanOrEqual_4 = 4,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        LessThanOrEqual_5 = 5,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Like_6 = 6,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Not_7 = 7,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Between_8 = 8,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        InList_9 = 9,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        And_10 = 10,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Or_11 = 11,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Cast_12 = 12,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        InView_13 = 13,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        OfType_14 = 14,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        RelatedTo_15 = 15,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        BitwiseAnd_16 = 16,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        BitwiseOr_17 = 17,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfQueryDataSet", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName="QueryDataSet")]
    public class ListOfQueryDataSet : System.Collections.Generic.List<opcfoundation.org.UA._2008._02.Types.xsd.QueryDataSet>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfParsingResult", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName="ParsingResult")]
    public class ListOfParsingResult : System.Collections.Generic.List<opcfoundation.org.UA._2008._02.Types.xsd.ParsingResult>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfContentFilterElementResult", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName="ContentFilterElementResult")]
    public class ListOfContentFilterElementResult : System.Collections.Generic.List<opcfoundation.org.UA._2008._02.Types.xsd.ContentFilterElementResult>
    {
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TimestampsToReturn", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public enum TimestampsToReturn : int
    {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Source_0 = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Server_1 = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Both_2 = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Neither_3 = 3,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfReadValueId", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName="ReadValueId")]
    public class ListOfReadValueId : System.Collections.Generic.List<opcfoundation.org.UA._2008._02.Types.xsd.ReadValueId>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfHistoryReadValueId", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName="HistoryReadValueId")]
    public class ListOfHistoryReadValueId : System.Collections.Generic.List<opcfoundation.org.UA._2008._02.Types.xsd.HistoryReadValueId>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfHistoryReadResult", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName="HistoryReadResult")]
    public class ListOfHistoryReadResult : System.Collections.Generic.List<opcfoundation.org.UA._2008._02.Types.xsd.HistoryReadResult>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfWriteValue", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName="WriteValue")]
    public class ListOfWriteValue : System.Collections.Generic.List<opcfoundation.org.UA._2008._02.Types.xsd.WriteValue>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfHistoryUpdateResult", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName="HistoryUpdateResult")]
    public class ListOfHistoryUpdateResult : System.Collections.Generic.List<opcfoundation.org.UA._2008._02.Types.xsd.HistoryUpdateResult>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfCallMethodRequest", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName="CallMethodRequest")]
    public class ListOfCallMethodRequest : System.Collections.Generic.List<opcfoundation.org.UA._2008._02.Types.xsd.CallMethodRequest>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfCallMethodResult", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName="CallMethodResult")]
    public class ListOfCallMethodResult : System.Collections.Generic.List<opcfoundation.org.UA._2008._02.Types.xsd.CallMethodResult>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfMonitoredItemCreateRequest", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName="MonitoredItemCreateRequest")]
    public class ListOfMonitoredItemCreateRequest : System.Collections.Generic.List<opcfoundation.org.UA._2008._02.Types.xsd.MonitoredItemCreateRequest>
    {
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MonitoringMode", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    public enum MonitoringMode : int
    {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Disabled_0 = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Sampling_1 = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Reporting_2 = 2,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfMonitoredItemCreateResult", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName="MonitoredItemCreateResult")]
    public class ListOfMonitoredItemCreateResult : System.Collections.Generic.List<opcfoundation.org.UA._2008._02.Types.xsd.MonitoredItemCreateResult>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfMonitoredItemModifyRequest", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName="MonitoredItemModifyRequest")]
    public class ListOfMonitoredItemModifyRequest : System.Collections.Generic.List<opcfoundation.org.UA._2008._02.Types.xsd.MonitoredItemModifyRequest>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfMonitoredItemModifyResult", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName="MonitoredItemModifyResult")]
    public class ListOfMonitoredItemModifyResult : System.Collections.Generic.List<opcfoundation.org.UA._2008._02.Types.xsd.MonitoredItemModifyResult>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfSubscriptionAcknowledgement", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName="SubscriptionAcknowledgement")]
    public class ListOfSubscriptionAcknowledgement : System.Collections.Generic.List<opcfoundation.org.UA._2008._02.Types.xsd.SubscriptionAcknowledgement>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfTransferResult", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName="TransferResult")]
    public class ListOfTransferResult : System.Collections.Generic.List<opcfoundation.org.UA._2008._02.Types.xsd.TransferResult>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfApplicationDescription", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName="ApplicationDescription")]
    public class ListOfApplicationDescription : System.Collections.Generic.List<opcfoundation.org.UA._2008._02.Types.xsd.ApplicationDescription>
    {
    }
}


[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Services.wsdl", ConfigurationName="ISessionEndpoint")]
public interface ISessionEndpoint
{
    
    // CODEGEN: Generating message contract since the operation InvokeService is neither RPC nor document wrapped.
    [System.ServiceModel.OperationContractAttribute(ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/InvokeService", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/InvokeServiceResponse")]
    InvokeServiceResponseMessage InvokeService(InvokeServiceMessage request);
    
    // CODEGEN: Generating message contract since the operation TestStack is neither RPC nor document wrapped.
    [System.ServiceModel.OperationContractAttribute(ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/TestStack", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/TestStackResponse")]
    [System.ServiceModel.FaultContractAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/TestStackFault", ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    TestStackResponseMessage TestStack(TestStackMessage request);
    
    // CODEGEN: Generating message contract since the operation TestStackEx is neither RPC nor document wrapped.
    [System.ServiceModel.OperationContractAttribute(ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/TestStackEx", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/TestStackExResponse")]
    [System.ServiceModel.FaultContractAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/TestStackExFault", ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    TestStackExResponseMessage TestStackEx(TestStackExMessage request);
    
    // CODEGEN: Generating message contract since the operation CreateSession is neither RPC nor document wrapped.
    [System.ServiceModel.OperationContractAttribute(ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/CreateSession", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/CreateSessionResponse")]
    [System.ServiceModel.FaultContractAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/CreateSessionFault", ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    CreateSessionResponseMessage CreateSession(CreateSessionMessage request);
    
    // CODEGEN: Generating message contract since the operation ActivateSession is neither RPC nor document wrapped.
    [System.ServiceModel.OperationContractAttribute(ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/ActivateSession", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/ActivateSessionResponse")]
    [System.ServiceModel.FaultContractAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/ActivateSessionFault", ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    ActivateSessionResponseMessage ActivateSession(ActivateSessionMessage request);
    
    // CODEGEN: Generating message contract since the operation CloseSession is neither RPC nor document wrapped.
    [System.ServiceModel.OperationContractAttribute(ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/CloseSession", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/CloseSessionResponse")]
    [System.ServiceModel.FaultContractAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/CloseSessionFault", ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    CloseSessionResponseMessage CloseSession(CloseSessionMessage request);
    
    // CODEGEN: Generating message contract since the operation Cancel is neither RPC nor document wrapped.
    [System.ServiceModel.OperationContractAttribute(ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/Cancel", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/CancelResponse")]
    [System.ServiceModel.FaultContractAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/CancelFault", ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    CancelResponseMessage Cancel(CancelMessage request);
    
    // CODEGEN: Generating message contract since the operation AddNodes is neither RPC nor document wrapped.
    [System.ServiceModel.OperationContractAttribute(ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/AddNodes", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/AddNodesResponse")]
    [System.ServiceModel.FaultContractAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/AddNodesFault", ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    AddNodesResponseMessage AddNodes(AddNodesMessage request);
    
    // CODEGEN: Generating message contract since the operation AddReferences is neither RPC nor document wrapped.
    [System.ServiceModel.OperationContractAttribute(ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/AddReferences", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/AddReferencesResponse")]
    [System.ServiceModel.FaultContractAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/AddReferencesFault", ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    AddReferencesResponseMessage AddReferences(AddReferencesMessage request);
    
    // CODEGEN: Generating message contract since the operation DeleteNodes is neither RPC nor document wrapped.
    [System.ServiceModel.OperationContractAttribute(ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/DeleteNodes", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/DeleteNodesResponse")]
    [System.ServiceModel.FaultContractAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/DeleteNodesFault", ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    DeleteNodesResponseMessage DeleteNodes(DeleteNodesMessage request);
    
    // CODEGEN: Generating message contract since the operation DeleteReferences is neither RPC nor document wrapped.
    [System.ServiceModel.OperationContractAttribute(ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/DeleteReferences", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/DeleteReferencesResponse")]
    [System.ServiceModel.FaultContractAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/DeleteReferencesFault", ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    DeleteReferencesResponseMessage DeleteReferences(DeleteReferencesMessage request);
    
    // CODEGEN: Generating message contract since the operation Browse is neither RPC nor document wrapped.
    [System.ServiceModel.OperationContractAttribute(ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/Browse", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/BrowseResponse")]
    [System.ServiceModel.FaultContractAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/BrowseFault", ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    BrowseResponseMessage Browse(BrowseMessage request);
    
    // CODEGEN: Generating message contract since the operation BrowseNext is neither RPC nor document wrapped.
    [System.ServiceModel.OperationContractAttribute(ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/BrowseNext", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/BrowseNextResponse")]
    [System.ServiceModel.FaultContractAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/BrowseNextFault", ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    BrowseNextResponseMessage BrowseNext(BrowseNextMessage request);
    
    // CODEGEN: Generating message contract since the operation TranslateBrowsePathsToNodeIds is neither RPC nor document wrapped.
    [System.ServiceModel.OperationContractAttribute(ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/TranslateBrowsePathsToNodeIds", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/TranslateBrowsePathsToNodeIdsRe" +
        "sponse")]
    [System.ServiceModel.FaultContractAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/TranslateBrowsePathsToNodeIdsFa" +
        "ult", ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    TranslateBrowsePathsToNodeIdsResponseMessage TranslateBrowsePathsToNodeIds(TranslateBrowsePathsToNodeIdsMessage request);
    
    // CODEGEN: Generating message contract since the operation RegisterNodes is neither RPC nor document wrapped.
    [System.ServiceModel.OperationContractAttribute(ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/RegisterNodes", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/RegisterNodesResponse")]
    [System.ServiceModel.FaultContractAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/RegisterNodesFault", ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    RegisterNodesResponseMessage RegisterNodes(RegisterNodesMessage request);
    
    // CODEGEN: Generating message contract since the operation UnregisterNodes is neither RPC nor document wrapped.
    [System.ServiceModel.OperationContractAttribute(ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/UnregisterNodes", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/UnregisterNodesResponse")]
    [System.ServiceModel.FaultContractAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/UnregisterNodesFault", ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    UnregisterNodesResponseMessage UnregisterNodes(UnregisterNodesMessage request);
    
    // CODEGEN: Generating message contract since the operation QueryFirst is neither RPC nor document wrapped.
    [System.ServiceModel.OperationContractAttribute(ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/QueryFirst", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/QueryFirstResponse")]
    [System.ServiceModel.FaultContractAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/QueryFirstFault", ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    QueryFirstResponseMessage QueryFirst(QueryFirstMessage request);
    
    // CODEGEN: Generating message contract since the operation QueryNext is neither RPC nor document wrapped.
    [System.ServiceModel.OperationContractAttribute(ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/QueryNext", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/QueryNextResponse")]
    [System.ServiceModel.FaultContractAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/QueryNextFault", ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    QueryNextResponseMessage QueryNext(QueryNextMessage request);
    
    // CODEGEN: Generating message contract since the operation Read is neither RPC nor document wrapped.
    [System.ServiceModel.OperationContractAttribute(ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/Read", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/ReadResponse")]
    [System.ServiceModel.FaultContractAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/ReadFault", ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    ReadResponseMessage Read(ReadMessage request);
    
    // CODEGEN: Generating message contract since the operation HistoryRead is neither RPC nor document wrapped.
    [System.ServiceModel.OperationContractAttribute(ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/HistoryRead", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/HistoryReadResponse")]
    [System.ServiceModel.FaultContractAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/HistoryReadFault", ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    HistoryReadResponseMessage HistoryRead(HistoryReadMessage request);
    
    // CODEGEN: Generating message contract since the operation Write is neither RPC nor document wrapped.
    [System.ServiceModel.OperationContractAttribute(ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/Write", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/WriteResponse")]
    [System.ServiceModel.FaultContractAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/WriteFault", ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    WriteResponseMessage Write(WriteMessage request);
    
    // CODEGEN: Generating message contract since the operation HistoryUpdate is neither RPC nor document wrapped.
    [System.ServiceModel.OperationContractAttribute(ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/HistoryUpdate", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/HistoryUpdateResponse")]
    [System.ServiceModel.FaultContractAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/HistoryUpdateFault", ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    HistoryUpdateResponseMessage HistoryUpdate(HistoryUpdateMessage request);
    
    // CODEGEN: Generating message contract since the operation Call is neither RPC nor document wrapped.
    [System.ServiceModel.OperationContractAttribute(ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/Call", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/CallResponse")]
    [System.ServiceModel.FaultContractAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/CallFault", ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    CallResponseMessage Call(CallMessage request);
    
    // CODEGEN: Generating message contract since the operation CreateMonitoredItems is neither RPC nor document wrapped.
    [System.ServiceModel.OperationContractAttribute(ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/CreateMonitoredItems", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/CreateMonitoredItemsResponse")]
    [System.ServiceModel.FaultContractAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/CreateMonitoredItemsFault", ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    CreateMonitoredItemsResponseMessage CreateMonitoredItems(CreateMonitoredItemsMessage request);
    
    // CODEGEN: Generating message contract since the operation ModifyMonitoredItems is neither RPC nor document wrapped.
    [System.ServiceModel.OperationContractAttribute(ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/ModifyMonitoredItems", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/ModifyMonitoredItemsResponse")]
    [System.ServiceModel.FaultContractAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/ModifyMonitoredItemsFault", ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    ModifyMonitoredItemsResponseMessage ModifyMonitoredItems(ModifyMonitoredItemsMessage request);
    
    // CODEGEN: Generating message contract since the operation SetMonitoringMode is neither RPC nor document wrapped.
    [System.ServiceModel.OperationContractAttribute(ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/SetMonitoringMode", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/SetMonitoringModeResponse")]
    [System.ServiceModel.FaultContractAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/SetMonitoringModeFault", ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    SetMonitoringModeResponseMessage SetMonitoringMode(SetMonitoringModeMessage request);
    
    // CODEGEN: Generating message contract since the operation SetTriggering is neither RPC nor document wrapped.
    [System.ServiceModel.OperationContractAttribute(ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/SetTriggering", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/SetTriggeringResponse")]
    [System.ServiceModel.FaultContractAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/SetTriggeringFault", ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    SetTriggeringResponseMessage SetTriggering(SetTriggeringMessage request);
    
    // CODEGEN: Generating message contract since the operation DeleteMonitoredItems is neither RPC nor document wrapped.
    [System.ServiceModel.OperationContractAttribute(ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/DeleteMonitoredItems", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/DeleteMonitoredItemsResponse")]
    [System.ServiceModel.FaultContractAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/DeleteMonitoredItemsFault", ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    DeleteMonitoredItemsResponseMessage DeleteMonitoredItems(DeleteMonitoredItemsMessage request);
    
    // CODEGEN: Generating message contract since the operation CreateSubscription is neither RPC nor document wrapped.
    [System.ServiceModel.OperationContractAttribute(ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/CreateSubscription", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/CreateSubscriptionResponse")]
    [System.ServiceModel.FaultContractAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/CreateSubscriptionFault", ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    CreateSubscriptionResponseMessage CreateSubscription(CreateSubscriptionMessage request);
    
    // CODEGEN: Generating message contract since the operation ModifySubscription is neither RPC nor document wrapped.
    [System.ServiceModel.OperationContractAttribute(ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/ModifySubscription", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/ModifySubscriptionResponse")]
    [System.ServiceModel.FaultContractAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/ModifySubscriptionFault", ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    ModifySubscriptionResponseMessage ModifySubscription(ModifySubscriptionMessage request);
    
    // CODEGEN: Generating message contract since the operation SetPublishingMode is neither RPC nor document wrapped.
    [System.ServiceModel.OperationContractAttribute(ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/SetPublishingMode", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/SetPublishingModeResponse")]
    [System.ServiceModel.FaultContractAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/SetPublishingModeFault", ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    SetPublishingModeResponseMessage SetPublishingMode(SetPublishingModeMessage request);
    
    // CODEGEN: Generating message contract since the operation Publish is neither RPC nor document wrapped.
    [System.ServiceModel.OperationContractAttribute(ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/Publish", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/PublishResponse")]
    [System.ServiceModel.FaultContractAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/PublishFault", ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    PublishResponseMessage Publish(PublishMessage request);
    
    // CODEGEN: Generating message contract since the operation Republish is neither RPC nor document wrapped.
    [System.ServiceModel.OperationContractAttribute(ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/Republish", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/RepublishResponse")]
    [System.ServiceModel.FaultContractAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/RepublishFault", ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    RepublishResponseMessage Republish(RepublishMessage request);
    
    // CODEGEN: Generating message contract since the operation TransferSubscriptions is neither RPC nor document wrapped.
    [System.ServiceModel.OperationContractAttribute(ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/TransferSubscriptions", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/TransferSubscriptionsResponse")]
    [System.ServiceModel.FaultContractAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/TransferSubscriptionsFault", ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    TransferSubscriptionsResponseMessage TransferSubscriptions(TransferSubscriptionsMessage request);
    
    // CODEGEN: Generating message contract since the operation DeleteSubscriptions is neither RPC nor document wrapped.
    [System.ServiceModel.OperationContractAttribute(ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/DeleteSubscriptions", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/DeleteSubscriptionsResponse")]
    [System.ServiceModel.FaultContractAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/DeleteSubscriptionsFault", ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    DeleteSubscriptionsResponseMessage DeleteSubscriptions(DeleteSubscriptionsMessage request);
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
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class TestStackMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.TestStackRequest TestStackRequest;
    
    public TestStackMessage()
    {
    }
    
    public TestStackMessage(opcfoundation.org.UA._2008._02.Types.xsd.TestStackRequest TestStackRequest)
    {
        this.TestStackRequest = TestStackRequest;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class TestStackResponseMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.TestStackResponse TestStackResponse;
    
    public TestStackResponseMessage()
    {
    }
    
    public TestStackResponseMessage(opcfoundation.org.UA._2008._02.Types.xsd.TestStackResponse TestStackResponse)
    {
        this.TestStackResponse = TestStackResponse;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class TestStackExMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.TestStackExRequest TestStackExRequest;
    
    public TestStackExMessage()
    {
    }
    
    public TestStackExMessage(opcfoundation.org.UA._2008._02.Types.xsd.TestStackExRequest TestStackExRequest)
    {
        this.TestStackExRequest = TestStackExRequest;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class TestStackExResponseMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.TestStackExResponse TestStackExResponse;
    
    public TestStackExResponseMessage()
    {
    }
    
    public TestStackExResponseMessage(opcfoundation.org.UA._2008._02.Types.xsd.TestStackExResponse TestStackExResponse)
    {
        this.TestStackExResponse = TestStackExResponse;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class CreateSessionMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.CreateSessionRequest CreateSessionRequest;
    
    public CreateSessionMessage()
    {
    }
    
    public CreateSessionMessage(opcfoundation.org.UA._2008._02.Types.xsd.CreateSessionRequest CreateSessionRequest)
    {
        this.CreateSessionRequest = CreateSessionRequest;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class CreateSessionResponseMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.CreateSessionResponse CreateSessionResponse;
    
    public CreateSessionResponseMessage()
    {
    }
    
    public CreateSessionResponseMessage(opcfoundation.org.UA._2008._02.Types.xsd.CreateSessionResponse CreateSessionResponse)
    {
        this.CreateSessionResponse = CreateSessionResponse;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class ActivateSessionMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.ActivateSessionRequest ActivateSessionRequest;
    
    public ActivateSessionMessage()
    {
    }
    
    public ActivateSessionMessage(opcfoundation.org.UA._2008._02.Types.xsd.ActivateSessionRequest ActivateSessionRequest)
    {
        this.ActivateSessionRequest = ActivateSessionRequest;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class ActivateSessionResponseMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.ActivateSessionResponse ActivateSessionResponse;
    
    public ActivateSessionResponseMessage()
    {
    }
    
    public ActivateSessionResponseMessage(opcfoundation.org.UA._2008._02.Types.xsd.ActivateSessionResponse ActivateSessionResponse)
    {
        this.ActivateSessionResponse = ActivateSessionResponse;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class CloseSessionMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.CloseSessionRequest CloseSessionRequest;
    
    public CloseSessionMessage()
    {
    }
    
    public CloseSessionMessage(opcfoundation.org.UA._2008._02.Types.xsd.CloseSessionRequest CloseSessionRequest)
    {
        this.CloseSessionRequest = CloseSessionRequest;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class CloseSessionResponseMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.CloseSessionResponse CloseSessionResponse;
    
    public CloseSessionResponseMessage()
    {
    }
    
    public CloseSessionResponseMessage(opcfoundation.org.UA._2008._02.Types.xsd.CloseSessionResponse CloseSessionResponse)
    {
        this.CloseSessionResponse = CloseSessionResponse;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class CancelMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.CancelRequest CancelRequest;
    
    public CancelMessage()
    {
    }
    
    public CancelMessage(opcfoundation.org.UA._2008._02.Types.xsd.CancelRequest CancelRequest)
    {
        this.CancelRequest = CancelRequest;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class CancelResponseMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.CancelResponse CancelResponse;
    
    public CancelResponseMessage()
    {
    }
    
    public CancelResponseMessage(opcfoundation.org.UA._2008._02.Types.xsd.CancelResponse CancelResponse)
    {
        this.CancelResponse = CancelResponse;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class AddNodesMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.AddNodesRequest AddNodesRequest;
    
    public AddNodesMessage()
    {
    }
    
    public AddNodesMessage(opcfoundation.org.UA._2008._02.Types.xsd.AddNodesRequest AddNodesRequest)
    {
        this.AddNodesRequest = AddNodesRequest;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class AddNodesResponseMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.AddNodesResponse AddNodesResponse;
    
    public AddNodesResponseMessage()
    {
    }
    
    public AddNodesResponseMessage(opcfoundation.org.UA._2008._02.Types.xsd.AddNodesResponse AddNodesResponse)
    {
        this.AddNodesResponse = AddNodesResponse;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class AddReferencesMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.AddReferencesRequest AddReferencesRequest;
    
    public AddReferencesMessage()
    {
    }
    
    public AddReferencesMessage(opcfoundation.org.UA._2008._02.Types.xsd.AddReferencesRequest AddReferencesRequest)
    {
        this.AddReferencesRequest = AddReferencesRequest;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class AddReferencesResponseMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.AddReferencesResponse AddReferencesResponse;
    
    public AddReferencesResponseMessage()
    {
    }
    
    public AddReferencesResponseMessage(opcfoundation.org.UA._2008._02.Types.xsd.AddReferencesResponse AddReferencesResponse)
    {
        this.AddReferencesResponse = AddReferencesResponse;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class DeleteNodesMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.DeleteNodesRequest DeleteNodesRequest;
    
    public DeleteNodesMessage()
    {
    }
    
    public DeleteNodesMessage(opcfoundation.org.UA._2008._02.Types.xsd.DeleteNodesRequest DeleteNodesRequest)
    {
        this.DeleteNodesRequest = DeleteNodesRequest;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class DeleteNodesResponseMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.DeleteNodesResponse DeleteNodesResponse;
    
    public DeleteNodesResponseMessage()
    {
    }
    
    public DeleteNodesResponseMessage(opcfoundation.org.UA._2008._02.Types.xsd.DeleteNodesResponse DeleteNodesResponse)
    {
        this.DeleteNodesResponse = DeleteNodesResponse;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class DeleteReferencesMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.DeleteReferencesRequest DeleteReferencesRequest;
    
    public DeleteReferencesMessage()
    {
    }
    
    public DeleteReferencesMessage(opcfoundation.org.UA._2008._02.Types.xsd.DeleteReferencesRequest DeleteReferencesRequest)
    {
        this.DeleteReferencesRequest = DeleteReferencesRequest;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class DeleteReferencesResponseMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.DeleteReferencesResponse DeleteReferencesResponse;
    
    public DeleteReferencesResponseMessage()
    {
    }
    
    public DeleteReferencesResponseMessage(opcfoundation.org.UA._2008._02.Types.xsd.DeleteReferencesResponse DeleteReferencesResponse)
    {
        this.DeleteReferencesResponse = DeleteReferencesResponse;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class BrowseMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.BrowseRequest BrowseRequest;
    
    public BrowseMessage()
    {
    }
    
    public BrowseMessage(opcfoundation.org.UA._2008._02.Types.xsd.BrowseRequest BrowseRequest)
    {
        this.BrowseRequest = BrowseRequest;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class BrowseResponseMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.BrowseResponse BrowseResponse;
    
    public BrowseResponseMessage()
    {
    }
    
    public BrowseResponseMessage(opcfoundation.org.UA._2008._02.Types.xsd.BrowseResponse BrowseResponse)
    {
        this.BrowseResponse = BrowseResponse;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class BrowseNextMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.BrowseNextRequest BrowseNextRequest;
    
    public BrowseNextMessage()
    {
    }
    
    public BrowseNextMessage(opcfoundation.org.UA._2008._02.Types.xsd.BrowseNextRequest BrowseNextRequest)
    {
        this.BrowseNextRequest = BrowseNextRequest;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class BrowseNextResponseMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.BrowseNextResponse BrowseNextResponse;
    
    public BrowseNextResponseMessage()
    {
    }
    
    public BrowseNextResponseMessage(opcfoundation.org.UA._2008._02.Types.xsd.BrowseNextResponse BrowseNextResponse)
    {
        this.BrowseNextResponse = BrowseNextResponse;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class TranslateBrowsePathsToNodeIdsMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.TranslateBrowsePathsToNodeIdsRequest TranslateBrowsePathsToNodeIdsRequest;
    
    public TranslateBrowsePathsToNodeIdsMessage()
    {
    }
    
    public TranslateBrowsePathsToNodeIdsMessage(opcfoundation.org.UA._2008._02.Types.xsd.TranslateBrowsePathsToNodeIdsRequest TranslateBrowsePathsToNodeIdsRequest)
    {
        this.TranslateBrowsePathsToNodeIdsRequest = TranslateBrowsePathsToNodeIdsRequest;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class TranslateBrowsePathsToNodeIdsResponseMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.TranslateBrowsePathsToNodeIdsResponse TranslateBrowsePathsToNodeIdsResponse;
    
    public TranslateBrowsePathsToNodeIdsResponseMessage()
    {
    }
    
    public TranslateBrowsePathsToNodeIdsResponseMessage(opcfoundation.org.UA._2008._02.Types.xsd.TranslateBrowsePathsToNodeIdsResponse TranslateBrowsePathsToNodeIdsResponse)
    {
        this.TranslateBrowsePathsToNodeIdsResponse = TranslateBrowsePathsToNodeIdsResponse;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class RegisterNodesMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.RegisterNodesRequest RegisterNodesRequest;
    
    public RegisterNodesMessage()
    {
    }
    
    public RegisterNodesMessage(opcfoundation.org.UA._2008._02.Types.xsd.RegisterNodesRequest RegisterNodesRequest)
    {
        this.RegisterNodesRequest = RegisterNodesRequest;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class RegisterNodesResponseMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.RegisterNodesResponse RegisterNodesResponse;
    
    public RegisterNodesResponseMessage()
    {
    }
    
    public RegisterNodesResponseMessage(opcfoundation.org.UA._2008._02.Types.xsd.RegisterNodesResponse RegisterNodesResponse)
    {
        this.RegisterNodesResponse = RegisterNodesResponse;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class UnregisterNodesMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.UnregisterNodesRequest UnregisterNodesRequest;
    
    public UnregisterNodesMessage()
    {
    }
    
    public UnregisterNodesMessage(opcfoundation.org.UA._2008._02.Types.xsd.UnregisterNodesRequest UnregisterNodesRequest)
    {
        this.UnregisterNodesRequest = UnregisterNodesRequest;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class UnregisterNodesResponseMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.UnregisterNodesResponse UnregisterNodesResponse;
    
    public UnregisterNodesResponseMessage()
    {
    }
    
    public UnregisterNodesResponseMessage(opcfoundation.org.UA._2008._02.Types.xsd.UnregisterNodesResponse UnregisterNodesResponse)
    {
        this.UnregisterNodesResponse = UnregisterNodesResponse;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class QueryFirstMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.QueryFirstRequest QueryFirstRequest;
    
    public QueryFirstMessage()
    {
    }
    
    public QueryFirstMessage(opcfoundation.org.UA._2008._02.Types.xsd.QueryFirstRequest QueryFirstRequest)
    {
        this.QueryFirstRequest = QueryFirstRequest;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class QueryFirstResponseMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.QueryFirstResponse QueryFirstResponse;
    
    public QueryFirstResponseMessage()
    {
    }
    
    public QueryFirstResponseMessage(opcfoundation.org.UA._2008._02.Types.xsd.QueryFirstResponse QueryFirstResponse)
    {
        this.QueryFirstResponse = QueryFirstResponse;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class QueryNextMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.QueryNextRequest QueryNextRequest;
    
    public QueryNextMessage()
    {
    }
    
    public QueryNextMessage(opcfoundation.org.UA._2008._02.Types.xsd.QueryNextRequest QueryNextRequest)
    {
        this.QueryNextRequest = QueryNextRequest;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class QueryNextResponseMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.QueryNextResponse QueryNextResponse;
    
    public QueryNextResponseMessage()
    {
    }
    
    public QueryNextResponseMessage(opcfoundation.org.UA._2008._02.Types.xsd.QueryNextResponse QueryNextResponse)
    {
        this.QueryNextResponse = QueryNextResponse;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class ReadMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.ReadRequest ReadRequest;
    
    public ReadMessage()
    {
    }
    
    public ReadMessage(opcfoundation.org.UA._2008._02.Types.xsd.ReadRequest ReadRequest)
    {
        this.ReadRequest = ReadRequest;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class ReadResponseMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.ReadResponse ReadResponse;
    
    public ReadResponseMessage()
    {
    }
    
    public ReadResponseMessage(opcfoundation.org.UA._2008._02.Types.xsd.ReadResponse ReadResponse)
    {
        this.ReadResponse = ReadResponse;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class HistoryReadMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.HistoryReadRequest HistoryReadRequest;
    
    public HistoryReadMessage()
    {
    }
    
    public HistoryReadMessage(opcfoundation.org.UA._2008._02.Types.xsd.HistoryReadRequest HistoryReadRequest)
    {
        this.HistoryReadRequest = HistoryReadRequest;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class HistoryReadResponseMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.HistoryReadResponse HistoryReadResponse;
    
    public HistoryReadResponseMessage()
    {
    }
    
    public HistoryReadResponseMessage(opcfoundation.org.UA._2008._02.Types.xsd.HistoryReadResponse HistoryReadResponse)
    {
        this.HistoryReadResponse = HistoryReadResponse;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class WriteMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.WriteRequest WriteRequest;
    
    public WriteMessage()
    {
    }
    
    public WriteMessage(opcfoundation.org.UA._2008._02.Types.xsd.WriteRequest WriteRequest)
    {
        this.WriteRequest = WriteRequest;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class WriteResponseMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.WriteResponse WriteResponse;
    
    public WriteResponseMessage()
    {
    }
    
    public WriteResponseMessage(opcfoundation.org.UA._2008._02.Types.xsd.WriteResponse WriteResponse)
    {
        this.WriteResponse = WriteResponse;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class HistoryUpdateMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.HistoryUpdateRequest HistoryUpdateRequest;
    
    public HistoryUpdateMessage()
    {
    }
    
    public HistoryUpdateMessage(opcfoundation.org.UA._2008._02.Types.xsd.HistoryUpdateRequest HistoryUpdateRequest)
    {
        this.HistoryUpdateRequest = HistoryUpdateRequest;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class HistoryUpdateResponseMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.HistoryUpdateResponse HistoryUpdateResponse;
    
    public HistoryUpdateResponseMessage()
    {
    }
    
    public HistoryUpdateResponseMessage(opcfoundation.org.UA._2008._02.Types.xsd.HistoryUpdateResponse HistoryUpdateResponse)
    {
        this.HistoryUpdateResponse = HistoryUpdateResponse;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class CallMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.CallRequest CallRequest;
    
    public CallMessage()
    {
    }
    
    public CallMessage(opcfoundation.org.UA._2008._02.Types.xsd.CallRequest CallRequest)
    {
        this.CallRequest = CallRequest;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class CallResponseMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.CallResponse CallResponse;
    
    public CallResponseMessage()
    {
    }
    
    public CallResponseMessage(opcfoundation.org.UA._2008._02.Types.xsd.CallResponse CallResponse)
    {
        this.CallResponse = CallResponse;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class CreateMonitoredItemsMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.CreateMonitoredItemsRequest CreateMonitoredItemsRequest;
    
    public CreateMonitoredItemsMessage()
    {
    }
    
    public CreateMonitoredItemsMessage(opcfoundation.org.UA._2008._02.Types.xsd.CreateMonitoredItemsRequest CreateMonitoredItemsRequest)
    {
        this.CreateMonitoredItemsRequest = CreateMonitoredItemsRequest;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class CreateMonitoredItemsResponseMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.CreateMonitoredItemsResponse CreateMonitoredItemsResponse;
    
    public CreateMonitoredItemsResponseMessage()
    {
    }
    
    public CreateMonitoredItemsResponseMessage(opcfoundation.org.UA._2008._02.Types.xsd.CreateMonitoredItemsResponse CreateMonitoredItemsResponse)
    {
        this.CreateMonitoredItemsResponse = CreateMonitoredItemsResponse;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class ModifyMonitoredItemsMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.ModifyMonitoredItemsRequest ModifyMonitoredItemsRequest;
    
    public ModifyMonitoredItemsMessage()
    {
    }
    
    public ModifyMonitoredItemsMessage(opcfoundation.org.UA._2008._02.Types.xsd.ModifyMonitoredItemsRequest ModifyMonitoredItemsRequest)
    {
        this.ModifyMonitoredItemsRequest = ModifyMonitoredItemsRequest;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class ModifyMonitoredItemsResponseMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.ModifyMonitoredItemsResponse ModifyMonitoredItemsResponse;
    
    public ModifyMonitoredItemsResponseMessage()
    {
    }
    
    public ModifyMonitoredItemsResponseMessage(opcfoundation.org.UA._2008._02.Types.xsd.ModifyMonitoredItemsResponse ModifyMonitoredItemsResponse)
    {
        this.ModifyMonitoredItemsResponse = ModifyMonitoredItemsResponse;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class SetMonitoringModeMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.SetMonitoringModeRequest SetMonitoringModeRequest;
    
    public SetMonitoringModeMessage()
    {
    }
    
    public SetMonitoringModeMessage(opcfoundation.org.UA._2008._02.Types.xsd.SetMonitoringModeRequest SetMonitoringModeRequest)
    {
        this.SetMonitoringModeRequest = SetMonitoringModeRequest;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class SetMonitoringModeResponseMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.SetMonitoringModeResponse SetMonitoringModeResponse;
    
    public SetMonitoringModeResponseMessage()
    {
    }
    
    public SetMonitoringModeResponseMessage(opcfoundation.org.UA._2008._02.Types.xsd.SetMonitoringModeResponse SetMonitoringModeResponse)
    {
        this.SetMonitoringModeResponse = SetMonitoringModeResponse;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class SetTriggeringMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.SetTriggeringRequest SetTriggeringRequest;
    
    public SetTriggeringMessage()
    {
    }
    
    public SetTriggeringMessage(opcfoundation.org.UA._2008._02.Types.xsd.SetTriggeringRequest SetTriggeringRequest)
    {
        this.SetTriggeringRequest = SetTriggeringRequest;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class SetTriggeringResponseMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.SetTriggeringResponse SetTriggeringResponse;
    
    public SetTriggeringResponseMessage()
    {
    }
    
    public SetTriggeringResponseMessage(opcfoundation.org.UA._2008._02.Types.xsd.SetTriggeringResponse SetTriggeringResponse)
    {
        this.SetTriggeringResponse = SetTriggeringResponse;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class DeleteMonitoredItemsMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.DeleteMonitoredItemsRequest DeleteMonitoredItemsRequest;
    
    public DeleteMonitoredItemsMessage()
    {
    }
    
    public DeleteMonitoredItemsMessage(opcfoundation.org.UA._2008._02.Types.xsd.DeleteMonitoredItemsRequest DeleteMonitoredItemsRequest)
    {
        this.DeleteMonitoredItemsRequest = DeleteMonitoredItemsRequest;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class DeleteMonitoredItemsResponseMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.DeleteMonitoredItemsResponse DeleteMonitoredItemsResponse;
    
    public DeleteMonitoredItemsResponseMessage()
    {
    }
    
    public DeleteMonitoredItemsResponseMessage(opcfoundation.org.UA._2008._02.Types.xsd.DeleteMonitoredItemsResponse DeleteMonitoredItemsResponse)
    {
        this.DeleteMonitoredItemsResponse = DeleteMonitoredItemsResponse;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class CreateSubscriptionMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.CreateSubscriptionRequest CreateSubscriptionRequest;
    
    public CreateSubscriptionMessage()
    {
    }
    
    public CreateSubscriptionMessage(opcfoundation.org.UA._2008._02.Types.xsd.CreateSubscriptionRequest CreateSubscriptionRequest)
    {
        this.CreateSubscriptionRequest = CreateSubscriptionRequest;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class CreateSubscriptionResponseMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.CreateSubscriptionResponse CreateSubscriptionResponse;
    
    public CreateSubscriptionResponseMessage()
    {
    }
    
    public CreateSubscriptionResponseMessage(opcfoundation.org.UA._2008._02.Types.xsd.CreateSubscriptionResponse CreateSubscriptionResponse)
    {
        this.CreateSubscriptionResponse = CreateSubscriptionResponse;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class ModifySubscriptionMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.ModifySubscriptionRequest ModifySubscriptionRequest;
    
    public ModifySubscriptionMessage()
    {
    }
    
    public ModifySubscriptionMessage(opcfoundation.org.UA._2008._02.Types.xsd.ModifySubscriptionRequest ModifySubscriptionRequest)
    {
        this.ModifySubscriptionRequest = ModifySubscriptionRequest;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class ModifySubscriptionResponseMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.ModifySubscriptionResponse ModifySubscriptionResponse;
    
    public ModifySubscriptionResponseMessage()
    {
    }
    
    public ModifySubscriptionResponseMessage(opcfoundation.org.UA._2008._02.Types.xsd.ModifySubscriptionResponse ModifySubscriptionResponse)
    {
        this.ModifySubscriptionResponse = ModifySubscriptionResponse;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class SetPublishingModeMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.SetPublishingModeRequest SetPublishingModeRequest;
    
    public SetPublishingModeMessage()
    {
    }
    
    public SetPublishingModeMessage(opcfoundation.org.UA._2008._02.Types.xsd.SetPublishingModeRequest SetPublishingModeRequest)
    {
        this.SetPublishingModeRequest = SetPublishingModeRequest;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class SetPublishingModeResponseMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.SetPublishingModeResponse SetPublishingModeResponse;
    
    public SetPublishingModeResponseMessage()
    {
    }
    
    public SetPublishingModeResponseMessage(opcfoundation.org.UA._2008._02.Types.xsd.SetPublishingModeResponse SetPublishingModeResponse)
    {
        this.SetPublishingModeResponse = SetPublishingModeResponse;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class PublishMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.PublishRequest PublishRequest;
    
    public PublishMessage()
    {
    }
    
    public PublishMessage(opcfoundation.org.UA._2008._02.Types.xsd.PublishRequest PublishRequest)
    {
        this.PublishRequest = PublishRequest;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class PublishResponseMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.PublishResponse PublishResponse;
    
    public PublishResponseMessage()
    {
    }
    
    public PublishResponseMessage(opcfoundation.org.UA._2008._02.Types.xsd.PublishResponse PublishResponse)
    {
        this.PublishResponse = PublishResponse;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class RepublishMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.RepublishRequest RepublishRequest;
    
    public RepublishMessage()
    {
    }
    
    public RepublishMessage(opcfoundation.org.UA._2008._02.Types.xsd.RepublishRequest RepublishRequest)
    {
        this.RepublishRequest = RepublishRequest;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class RepublishResponseMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.RepublishResponse RepublishResponse;
    
    public RepublishResponseMessage()
    {
    }
    
    public RepublishResponseMessage(opcfoundation.org.UA._2008._02.Types.xsd.RepublishResponse RepublishResponse)
    {
        this.RepublishResponse = RepublishResponse;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class TransferSubscriptionsMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.TransferSubscriptionsRequest TransferSubscriptionsRequest;
    
    public TransferSubscriptionsMessage()
    {
    }
    
    public TransferSubscriptionsMessage(opcfoundation.org.UA._2008._02.Types.xsd.TransferSubscriptionsRequest TransferSubscriptionsRequest)
    {
        this.TransferSubscriptionsRequest = TransferSubscriptionsRequest;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class TransferSubscriptionsResponseMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.TransferSubscriptionsResponse TransferSubscriptionsResponse;
    
    public TransferSubscriptionsResponseMessage()
    {
    }
    
    public TransferSubscriptionsResponseMessage(opcfoundation.org.UA._2008._02.Types.xsd.TransferSubscriptionsResponse TransferSubscriptionsResponse)
    {
        this.TransferSubscriptionsResponse = TransferSubscriptionsResponse;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class DeleteSubscriptionsMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.DeleteSubscriptionsRequest DeleteSubscriptionsRequest;
    
    public DeleteSubscriptionsMessage()
    {
    }
    
    public DeleteSubscriptionsMessage(opcfoundation.org.UA._2008._02.Types.xsd.DeleteSubscriptionsRequest DeleteSubscriptionsRequest)
    {
        this.DeleteSubscriptionsRequest = DeleteSubscriptionsRequest;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class DeleteSubscriptionsResponseMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.DeleteSubscriptionsResponse DeleteSubscriptionsResponse;
    
    public DeleteSubscriptionsResponseMessage()
    {
    }
    
    public DeleteSubscriptionsResponseMessage(opcfoundation.org.UA._2008._02.Types.xsd.DeleteSubscriptionsResponse DeleteSubscriptionsResponse)
    {
        this.DeleteSubscriptionsResponse = DeleteSubscriptionsResponse;
    }
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public interface ISessionEndpointChannel : ISessionEndpoint, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public partial class SessionEndpointClient : System.ServiceModel.ClientBase<ISessionEndpoint>, ISessionEndpoint
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
    InvokeServiceResponseMessage ISessionEndpoint.InvokeService(InvokeServiceMessage request)
    {
        return base.Channel.InvokeService(request);
    }
    
    public byte[] InvokeService(byte[] InvokeServiceRequest)
    {
        InvokeServiceMessage inValue = new InvokeServiceMessage();
        inValue.InvokeServiceRequest = InvokeServiceRequest;
        InvokeServiceResponseMessage retVal = ((ISessionEndpoint)(this)).InvokeService(inValue);
        return retVal.InvokeServiceResponse;
    }
    
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    TestStackResponseMessage ISessionEndpoint.TestStack(TestStackMessage request)
    {
        return base.Channel.TestStack(request);
    }
    
    public opcfoundation.org.UA._2008._02.Types.xsd.TestStackResponse TestStack(opcfoundation.org.UA._2008._02.Types.xsd.TestStackRequest TestStackRequest)
    {
        TestStackMessage inValue = new TestStackMessage();
        inValue.TestStackRequest = TestStackRequest;
        TestStackResponseMessage retVal = ((ISessionEndpoint)(this)).TestStack(inValue);
        return retVal.TestStackResponse;
    }
    
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    TestStackExResponseMessage ISessionEndpoint.TestStackEx(TestStackExMessage request)
    {
        return base.Channel.TestStackEx(request);
    }
    
    public opcfoundation.org.UA._2008._02.Types.xsd.TestStackExResponse TestStackEx(opcfoundation.org.UA._2008._02.Types.xsd.TestStackExRequest TestStackExRequest)
    {
        TestStackExMessage inValue = new TestStackExMessage();
        inValue.TestStackExRequest = TestStackExRequest;
        TestStackExResponseMessage retVal = ((ISessionEndpoint)(this)).TestStackEx(inValue);
        return retVal.TestStackExResponse;
    }
    
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    CreateSessionResponseMessage ISessionEndpoint.CreateSession(CreateSessionMessage request)
    {
        return base.Channel.CreateSession(request);
    }
    
    public opcfoundation.org.UA._2008._02.Types.xsd.CreateSessionResponse CreateSession(opcfoundation.org.UA._2008._02.Types.xsd.CreateSessionRequest CreateSessionRequest)
    {
        CreateSessionMessage inValue = new CreateSessionMessage();
        inValue.CreateSessionRequest = CreateSessionRequest;
        CreateSessionResponseMessage retVal = ((ISessionEndpoint)(this)).CreateSession(inValue);
        return retVal.CreateSessionResponse;
    }
    
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    ActivateSessionResponseMessage ISessionEndpoint.ActivateSession(ActivateSessionMessage request)
    {
        return base.Channel.ActivateSession(request);
    }
    
    public opcfoundation.org.UA._2008._02.Types.xsd.ActivateSessionResponse ActivateSession(opcfoundation.org.UA._2008._02.Types.xsd.ActivateSessionRequest ActivateSessionRequest)
    {
        ActivateSessionMessage inValue = new ActivateSessionMessage();
        inValue.ActivateSessionRequest = ActivateSessionRequest;
        ActivateSessionResponseMessage retVal = ((ISessionEndpoint)(this)).ActivateSession(inValue);
        return retVal.ActivateSessionResponse;
    }
    
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    CloseSessionResponseMessage ISessionEndpoint.CloseSession(CloseSessionMessage request)
    {
        return base.Channel.CloseSession(request);
    }
    
    public opcfoundation.org.UA._2008._02.Types.xsd.CloseSessionResponse CloseSession(opcfoundation.org.UA._2008._02.Types.xsd.CloseSessionRequest CloseSessionRequest)
    {
        CloseSessionMessage inValue = new CloseSessionMessage();
        inValue.CloseSessionRequest = CloseSessionRequest;
        CloseSessionResponseMessage retVal = ((ISessionEndpoint)(this)).CloseSession(inValue);
        return retVal.CloseSessionResponse;
    }
    
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    CancelResponseMessage ISessionEndpoint.Cancel(CancelMessage request)
    {
        return base.Channel.Cancel(request);
    }
    
    public opcfoundation.org.UA._2008._02.Types.xsd.CancelResponse Cancel(opcfoundation.org.UA._2008._02.Types.xsd.CancelRequest CancelRequest)
    {
        CancelMessage inValue = new CancelMessage();
        inValue.CancelRequest = CancelRequest;
        CancelResponseMessage retVal = ((ISessionEndpoint)(this)).Cancel(inValue);
        return retVal.CancelResponse;
    }
    
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    AddNodesResponseMessage ISessionEndpoint.AddNodes(AddNodesMessage request)
    {
        return base.Channel.AddNodes(request);
    }
    
    public opcfoundation.org.UA._2008._02.Types.xsd.AddNodesResponse AddNodes(opcfoundation.org.UA._2008._02.Types.xsd.AddNodesRequest AddNodesRequest)
    {
        AddNodesMessage inValue = new AddNodesMessage();
        inValue.AddNodesRequest = AddNodesRequest;
        AddNodesResponseMessage retVal = ((ISessionEndpoint)(this)).AddNodes(inValue);
        return retVal.AddNodesResponse;
    }
    
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    AddReferencesResponseMessage ISessionEndpoint.AddReferences(AddReferencesMessage request)
    {
        return base.Channel.AddReferences(request);
    }
    
    public opcfoundation.org.UA._2008._02.Types.xsd.AddReferencesResponse AddReferences(opcfoundation.org.UA._2008._02.Types.xsd.AddReferencesRequest AddReferencesRequest)
    {
        AddReferencesMessage inValue = new AddReferencesMessage();
        inValue.AddReferencesRequest = AddReferencesRequest;
        AddReferencesResponseMessage retVal = ((ISessionEndpoint)(this)).AddReferences(inValue);
        return retVal.AddReferencesResponse;
    }
    
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    DeleteNodesResponseMessage ISessionEndpoint.DeleteNodes(DeleteNodesMessage request)
    {
        return base.Channel.DeleteNodes(request);
    }
    
    public opcfoundation.org.UA._2008._02.Types.xsd.DeleteNodesResponse DeleteNodes(opcfoundation.org.UA._2008._02.Types.xsd.DeleteNodesRequest DeleteNodesRequest)
    {
        DeleteNodesMessage inValue = new DeleteNodesMessage();
        inValue.DeleteNodesRequest = DeleteNodesRequest;
        DeleteNodesResponseMessage retVal = ((ISessionEndpoint)(this)).DeleteNodes(inValue);
        return retVal.DeleteNodesResponse;
    }
    
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    DeleteReferencesResponseMessage ISessionEndpoint.DeleteReferences(DeleteReferencesMessage request)
    {
        return base.Channel.DeleteReferences(request);
    }
    
    public opcfoundation.org.UA._2008._02.Types.xsd.DeleteReferencesResponse DeleteReferences(opcfoundation.org.UA._2008._02.Types.xsd.DeleteReferencesRequest DeleteReferencesRequest)
    {
        DeleteReferencesMessage inValue = new DeleteReferencesMessage();
        inValue.DeleteReferencesRequest = DeleteReferencesRequest;
        DeleteReferencesResponseMessage retVal = ((ISessionEndpoint)(this)).DeleteReferences(inValue);
        return retVal.DeleteReferencesResponse;
    }
    
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    BrowseResponseMessage ISessionEndpoint.Browse(BrowseMessage request)
    {
        return base.Channel.Browse(request);
    }
    
    public opcfoundation.org.UA._2008._02.Types.xsd.BrowseResponse Browse(opcfoundation.org.UA._2008._02.Types.xsd.BrowseRequest BrowseRequest)
    {
        BrowseMessage inValue = new BrowseMessage();
        inValue.BrowseRequest = BrowseRequest;
        BrowseResponseMessage retVal = ((ISessionEndpoint)(this)).Browse(inValue);
        return retVal.BrowseResponse;
    }
    
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    BrowseNextResponseMessage ISessionEndpoint.BrowseNext(BrowseNextMessage request)
    {
        return base.Channel.BrowseNext(request);
    }
    
    public opcfoundation.org.UA._2008._02.Types.xsd.BrowseNextResponse BrowseNext(opcfoundation.org.UA._2008._02.Types.xsd.BrowseNextRequest BrowseNextRequest)
    {
        BrowseNextMessage inValue = new BrowseNextMessage();
        inValue.BrowseNextRequest = BrowseNextRequest;
        BrowseNextResponseMessage retVal = ((ISessionEndpoint)(this)).BrowseNext(inValue);
        return retVal.BrowseNextResponse;
    }
    
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    TranslateBrowsePathsToNodeIdsResponseMessage ISessionEndpoint.TranslateBrowsePathsToNodeIds(TranslateBrowsePathsToNodeIdsMessage request)
    {
        return base.Channel.TranslateBrowsePathsToNodeIds(request);
    }
    
    public opcfoundation.org.UA._2008._02.Types.xsd.TranslateBrowsePathsToNodeIdsResponse TranslateBrowsePathsToNodeIds(opcfoundation.org.UA._2008._02.Types.xsd.TranslateBrowsePathsToNodeIdsRequest TranslateBrowsePathsToNodeIdsRequest)
    {
        TranslateBrowsePathsToNodeIdsMessage inValue = new TranslateBrowsePathsToNodeIdsMessage();
        inValue.TranslateBrowsePathsToNodeIdsRequest = TranslateBrowsePathsToNodeIdsRequest;
        TranslateBrowsePathsToNodeIdsResponseMessage retVal = ((ISessionEndpoint)(this)).TranslateBrowsePathsToNodeIds(inValue);
        return retVal.TranslateBrowsePathsToNodeIdsResponse;
    }
    
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    RegisterNodesResponseMessage ISessionEndpoint.RegisterNodes(RegisterNodesMessage request)
    {
        return base.Channel.RegisterNodes(request);
    }
    
    public opcfoundation.org.UA._2008._02.Types.xsd.RegisterNodesResponse RegisterNodes(opcfoundation.org.UA._2008._02.Types.xsd.RegisterNodesRequest RegisterNodesRequest)
    {
        RegisterNodesMessage inValue = new RegisterNodesMessage();
        inValue.RegisterNodesRequest = RegisterNodesRequest;
        RegisterNodesResponseMessage retVal = ((ISessionEndpoint)(this)).RegisterNodes(inValue);
        return retVal.RegisterNodesResponse;
    }
    
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    UnregisterNodesResponseMessage ISessionEndpoint.UnregisterNodes(UnregisterNodesMessage request)
    {
        return base.Channel.UnregisterNodes(request);
    }
    
    public opcfoundation.org.UA._2008._02.Types.xsd.UnregisterNodesResponse UnregisterNodes(opcfoundation.org.UA._2008._02.Types.xsd.UnregisterNodesRequest UnregisterNodesRequest)
    {
        UnregisterNodesMessage inValue = new UnregisterNodesMessage();
        inValue.UnregisterNodesRequest = UnregisterNodesRequest;
        UnregisterNodesResponseMessage retVal = ((ISessionEndpoint)(this)).UnregisterNodes(inValue);
        return retVal.UnregisterNodesResponse;
    }
    
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    QueryFirstResponseMessage ISessionEndpoint.QueryFirst(QueryFirstMessage request)
    {
        return base.Channel.QueryFirst(request);
    }
    
    public opcfoundation.org.UA._2008._02.Types.xsd.QueryFirstResponse QueryFirst(opcfoundation.org.UA._2008._02.Types.xsd.QueryFirstRequest QueryFirstRequest)
    {
        QueryFirstMessage inValue = new QueryFirstMessage();
        inValue.QueryFirstRequest = QueryFirstRequest;
        QueryFirstResponseMessage retVal = ((ISessionEndpoint)(this)).QueryFirst(inValue);
        return retVal.QueryFirstResponse;
    }
    
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    QueryNextResponseMessage ISessionEndpoint.QueryNext(QueryNextMessage request)
    {
        return base.Channel.QueryNext(request);
    }
    
    public opcfoundation.org.UA._2008._02.Types.xsd.QueryNextResponse QueryNext(opcfoundation.org.UA._2008._02.Types.xsd.QueryNextRequest QueryNextRequest)
    {
        QueryNextMessage inValue = new QueryNextMessage();
        inValue.QueryNextRequest = QueryNextRequest;
        QueryNextResponseMessage retVal = ((ISessionEndpoint)(this)).QueryNext(inValue);
        return retVal.QueryNextResponse;
    }
    
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    ReadResponseMessage ISessionEndpoint.Read(ReadMessage request)
    {
        return base.Channel.Read(request);
    }
    
    public opcfoundation.org.UA._2008._02.Types.xsd.ReadResponse Read(opcfoundation.org.UA._2008._02.Types.xsd.ReadRequest ReadRequest)
    {
        ReadMessage inValue = new ReadMessage();
        inValue.ReadRequest = ReadRequest;
        ReadResponseMessage retVal = ((ISessionEndpoint)(this)).Read(inValue);
        return retVal.ReadResponse;
    }
    
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    HistoryReadResponseMessage ISessionEndpoint.HistoryRead(HistoryReadMessage request)
    {
        return base.Channel.HistoryRead(request);
    }
    
    public opcfoundation.org.UA._2008._02.Types.xsd.HistoryReadResponse HistoryRead(opcfoundation.org.UA._2008._02.Types.xsd.HistoryReadRequest HistoryReadRequest)
    {
        HistoryReadMessage inValue = new HistoryReadMessage();
        inValue.HistoryReadRequest = HistoryReadRequest;
        HistoryReadResponseMessage retVal = ((ISessionEndpoint)(this)).HistoryRead(inValue);
        return retVal.HistoryReadResponse;
    }
    
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    WriteResponseMessage ISessionEndpoint.Write(WriteMessage request)
    {
        return base.Channel.Write(request);
    }
    
    public opcfoundation.org.UA._2008._02.Types.xsd.WriteResponse Write(opcfoundation.org.UA._2008._02.Types.xsd.WriteRequest WriteRequest)
    {
        WriteMessage inValue = new WriteMessage();
        inValue.WriteRequest = WriteRequest;
        WriteResponseMessage retVal = ((ISessionEndpoint)(this)).Write(inValue);
        return retVal.WriteResponse;
    }
    
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    HistoryUpdateResponseMessage ISessionEndpoint.HistoryUpdate(HistoryUpdateMessage request)
    {
        return base.Channel.HistoryUpdate(request);
    }
    
    public opcfoundation.org.UA._2008._02.Types.xsd.HistoryUpdateResponse HistoryUpdate(opcfoundation.org.UA._2008._02.Types.xsd.HistoryUpdateRequest HistoryUpdateRequest)
    {
        HistoryUpdateMessage inValue = new HistoryUpdateMessage();
        inValue.HistoryUpdateRequest = HistoryUpdateRequest;
        HistoryUpdateResponseMessage retVal = ((ISessionEndpoint)(this)).HistoryUpdate(inValue);
        return retVal.HistoryUpdateResponse;
    }
    
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    CallResponseMessage ISessionEndpoint.Call(CallMessage request)
    {
        return base.Channel.Call(request);
    }
    
    public opcfoundation.org.UA._2008._02.Types.xsd.CallResponse Call(opcfoundation.org.UA._2008._02.Types.xsd.CallRequest CallRequest)
    {
        CallMessage inValue = new CallMessage();
        inValue.CallRequest = CallRequest;
        CallResponseMessage retVal = ((ISessionEndpoint)(this)).Call(inValue);
        return retVal.CallResponse;
    }
    
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    CreateMonitoredItemsResponseMessage ISessionEndpoint.CreateMonitoredItems(CreateMonitoredItemsMessage request)
    {
        return base.Channel.CreateMonitoredItems(request);
    }
    
    public opcfoundation.org.UA._2008._02.Types.xsd.CreateMonitoredItemsResponse CreateMonitoredItems(opcfoundation.org.UA._2008._02.Types.xsd.CreateMonitoredItemsRequest CreateMonitoredItemsRequest)
    {
        CreateMonitoredItemsMessage inValue = new CreateMonitoredItemsMessage();
        inValue.CreateMonitoredItemsRequest = CreateMonitoredItemsRequest;
        CreateMonitoredItemsResponseMessage retVal = ((ISessionEndpoint)(this)).CreateMonitoredItems(inValue);
        return retVal.CreateMonitoredItemsResponse;
    }
    
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    ModifyMonitoredItemsResponseMessage ISessionEndpoint.ModifyMonitoredItems(ModifyMonitoredItemsMessage request)
    {
        return base.Channel.ModifyMonitoredItems(request);
    }
    
    public opcfoundation.org.UA._2008._02.Types.xsd.ModifyMonitoredItemsResponse ModifyMonitoredItems(opcfoundation.org.UA._2008._02.Types.xsd.ModifyMonitoredItemsRequest ModifyMonitoredItemsRequest)
    {
        ModifyMonitoredItemsMessage inValue = new ModifyMonitoredItemsMessage();
        inValue.ModifyMonitoredItemsRequest = ModifyMonitoredItemsRequest;
        ModifyMonitoredItemsResponseMessage retVal = ((ISessionEndpoint)(this)).ModifyMonitoredItems(inValue);
        return retVal.ModifyMonitoredItemsResponse;
    }
    
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    SetMonitoringModeResponseMessage ISessionEndpoint.SetMonitoringMode(SetMonitoringModeMessage request)
    {
        return base.Channel.SetMonitoringMode(request);
    }
    
    public opcfoundation.org.UA._2008._02.Types.xsd.SetMonitoringModeResponse SetMonitoringMode(opcfoundation.org.UA._2008._02.Types.xsd.SetMonitoringModeRequest SetMonitoringModeRequest)
    {
        SetMonitoringModeMessage inValue = new SetMonitoringModeMessage();
        inValue.SetMonitoringModeRequest = SetMonitoringModeRequest;
        SetMonitoringModeResponseMessage retVal = ((ISessionEndpoint)(this)).SetMonitoringMode(inValue);
        return retVal.SetMonitoringModeResponse;
    }
    
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    SetTriggeringResponseMessage ISessionEndpoint.SetTriggering(SetTriggeringMessage request)
    {
        return base.Channel.SetTriggering(request);
    }
    
    public opcfoundation.org.UA._2008._02.Types.xsd.SetTriggeringResponse SetTriggering(opcfoundation.org.UA._2008._02.Types.xsd.SetTriggeringRequest SetTriggeringRequest)
    {
        SetTriggeringMessage inValue = new SetTriggeringMessage();
        inValue.SetTriggeringRequest = SetTriggeringRequest;
        SetTriggeringResponseMessage retVal = ((ISessionEndpoint)(this)).SetTriggering(inValue);
        return retVal.SetTriggeringResponse;
    }
    
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    DeleteMonitoredItemsResponseMessage ISessionEndpoint.DeleteMonitoredItems(DeleteMonitoredItemsMessage request)
    {
        return base.Channel.DeleteMonitoredItems(request);
    }
    
    public opcfoundation.org.UA._2008._02.Types.xsd.DeleteMonitoredItemsResponse DeleteMonitoredItems(opcfoundation.org.UA._2008._02.Types.xsd.DeleteMonitoredItemsRequest DeleteMonitoredItemsRequest)
    {
        DeleteMonitoredItemsMessage inValue = new DeleteMonitoredItemsMessage();
        inValue.DeleteMonitoredItemsRequest = DeleteMonitoredItemsRequest;
        DeleteMonitoredItemsResponseMessage retVal = ((ISessionEndpoint)(this)).DeleteMonitoredItems(inValue);
        return retVal.DeleteMonitoredItemsResponse;
    }
    
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    CreateSubscriptionResponseMessage ISessionEndpoint.CreateSubscription(CreateSubscriptionMessage request)
    {
        return base.Channel.CreateSubscription(request);
    }
    
    public opcfoundation.org.UA._2008._02.Types.xsd.CreateSubscriptionResponse CreateSubscription(opcfoundation.org.UA._2008._02.Types.xsd.CreateSubscriptionRequest CreateSubscriptionRequest)
    {
        CreateSubscriptionMessage inValue = new CreateSubscriptionMessage();
        inValue.CreateSubscriptionRequest = CreateSubscriptionRequest;
        CreateSubscriptionResponseMessage retVal = ((ISessionEndpoint)(this)).CreateSubscription(inValue);
        return retVal.CreateSubscriptionResponse;
    }
    
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    ModifySubscriptionResponseMessage ISessionEndpoint.ModifySubscription(ModifySubscriptionMessage request)
    {
        return base.Channel.ModifySubscription(request);
    }
    
    public opcfoundation.org.UA._2008._02.Types.xsd.ModifySubscriptionResponse ModifySubscription(opcfoundation.org.UA._2008._02.Types.xsd.ModifySubscriptionRequest ModifySubscriptionRequest)
    {
        ModifySubscriptionMessage inValue = new ModifySubscriptionMessage();
        inValue.ModifySubscriptionRequest = ModifySubscriptionRequest;
        ModifySubscriptionResponseMessage retVal = ((ISessionEndpoint)(this)).ModifySubscription(inValue);
        return retVal.ModifySubscriptionResponse;
    }
    
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    SetPublishingModeResponseMessage ISessionEndpoint.SetPublishingMode(SetPublishingModeMessage request)
    {
        return base.Channel.SetPublishingMode(request);
    }
    
    public opcfoundation.org.UA._2008._02.Types.xsd.SetPublishingModeResponse SetPublishingMode(opcfoundation.org.UA._2008._02.Types.xsd.SetPublishingModeRequest SetPublishingModeRequest)
    {
        SetPublishingModeMessage inValue = new SetPublishingModeMessage();
        inValue.SetPublishingModeRequest = SetPublishingModeRequest;
        SetPublishingModeResponseMessage retVal = ((ISessionEndpoint)(this)).SetPublishingMode(inValue);
        return retVal.SetPublishingModeResponse;
    }
    
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    PublishResponseMessage ISessionEndpoint.Publish(PublishMessage request)
    {
        return base.Channel.Publish(request);
    }
    
    public opcfoundation.org.UA._2008._02.Types.xsd.PublishResponse Publish(opcfoundation.org.UA._2008._02.Types.xsd.PublishRequest PublishRequest)
    {
        PublishMessage inValue = new PublishMessage();
        inValue.PublishRequest = PublishRequest;
        PublishResponseMessage retVal = ((ISessionEndpoint)(this)).Publish(inValue);
        return retVal.PublishResponse;
    }
    
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    RepublishResponseMessage ISessionEndpoint.Republish(RepublishMessage request)
    {
        return base.Channel.Republish(request);
    }
    
    public opcfoundation.org.UA._2008._02.Types.xsd.RepublishResponse Republish(opcfoundation.org.UA._2008._02.Types.xsd.RepublishRequest RepublishRequest)
    {
        RepublishMessage inValue = new RepublishMessage();
        inValue.RepublishRequest = RepublishRequest;
        RepublishResponseMessage retVal = ((ISessionEndpoint)(this)).Republish(inValue);
        return retVal.RepublishResponse;
    }
    
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    TransferSubscriptionsResponseMessage ISessionEndpoint.TransferSubscriptions(TransferSubscriptionsMessage request)
    {
        return base.Channel.TransferSubscriptions(request);
    }
    
    public opcfoundation.org.UA._2008._02.Types.xsd.TransferSubscriptionsResponse TransferSubscriptions(opcfoundation.org.UA._2008._02.Types.xsd.TransferSubscriptionsRequest TransferSubscriptionsRequest)
    {
        TransferSubscriptionsMessage inValue = new TransferSubscriptionsMessage();
        inValue.TransferSubscriptionsRequest = TransferSubscriptionsRequest;
        TransferSubscriptionsResponseMessage retVal = ((ISessionEndpoint)(this)).TransferSubscriptions(inValue);
        return retVal.TransferSubscriptionsResponse;
    }
    
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    DeleteSubscriptionsResponseMessage ISessionEndpoint.DeleteSubscriptions(DeleteSubscriptionsMessage request)
    {
        return base.Channel.DeleteSubscriptions(request);
    }
    
    public opcfoundation.org.UA._2008._02.Types.xsd.DeleteSubscriptionsResponse DeleteSubscriptions(opcfoundation.org.UA._2008._02.Types.xsd.DeleteSubscriptionsRequest DeleteSubscriptionsRequest)
    {
        DeleteSubscriptionsMessage inValue = new DeleteSubscriptionsMessage();
        inValue.DeleteSubscriptionsRequest = DeleteSubscriptionsRequest;
        DeleteSubscriptionsResponseMessage retVal = ((ISessionEndpoint)(this)).DeleteSubscriptions(inValue);
        return retVal.DeleteSubscriptionsResponse;
    }
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Services.wsdl", ConfigurationName="IDiscoveryEndpoint")]
public interface IDiscoveryEndpoint
{
    
    // CODEGEN: Generating message contract since the operation InvokeService is neither RPC nor document wrapped.
    [System.ServiceModel.OperationContractAttribute(Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/InvokeService", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/InvokeServiceResponse")]
    InvokeServiceResponseMessage InvokeService(InvokeServiceMessage request);
    
    // CODEGEN: Generating message contract since the operation FindServers is neither RPC nor document wrapped.
    [System.ServiceModel.OperationContractAttribute(Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/FindServers", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/FindServersResponse")]
    [System.ServiceModel.FaultContractAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/FindServersFault", Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    FindServersResponseMessage FindServers(FindServersMessage request);
    
    // CODEGEN: Generating message contract since the operation GetEndpoints is neither RPC nor document wrapped.
    [System.ServiceModel.OperationContractAttribute(Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/GetEndpoints", ReplyAction="http://opcfoundation.org/UA/2008/02/Services.wsdl/GetEndpointsResponse")]
    [System.ServiceModel.FaultContractAttribute(typeof(opcfoundation.org.UA._2008._02.Types.xsd.ServiceFault), Action="http://opcfoundation.org/UA/2008/02/Services.wsdl/GetEndpointsFault", Name="ServiceFault", Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    GetEndpointsResponseMessage GetEndpoints(GetEndpointsMessage request);
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class FindServersMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.FindServersRequest FindServersRequest;
    
    public FindServersMessage()
    {
    }
    
    public FindServersMessage(opcfoundation.org.UA._2008._02.Types.xsd.FindServersRequest FindServersRequest)
    {
        this.FindServersRequest = FindServersRequest;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class FindServersResponseMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.FindServersResponse FindServersResponse;
    
    public FindServersResponseMessage()
    {
    }
    
    public FindServersResponseMessage(opcfoundation.org.UA._2008._02.Types.xsd.FindServersResponse FindServersResponse)
    {
        this.FindServersResponse = FindServersResponse;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class GetEndpointsMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.GetEndpointsRequest GetEndpointsRequest;
    
    public GetEndpointsMessage()
    {
    }
    
    public GetEndpointsMessage(opcfoundation.org.UA._2008._02.Types.xsd.GetEndpointsRequest GetEndpointsRequest)
    {
        this.GetEndpointsRequest = GetEndpointsRequest;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class GetEndpointsResponseMessage
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", Order=0)]
    public opcfoundation.org.UA._2008._02.Types.xsd.GetEndpointsResponse GetEndpointsResponse;
    
    public GetEndpointsResponseMessage()
    {
    }
    
    public GetEndpointsResponseMessage(opcfoundation.org.UA._2008._02.Types.xsd.GetEndpointsResponse GetEndpointsResponse)
    {
        this.GetEndpointsResponse = GetEndpointsResponse;
    }
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public interface IDiscoveryEndpointChannel : IDiscoveryEndpoint, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public partial class DiscoveryEndpointClient : System.ServiceModel.ClientBase<IDiscoveryEndpoint>, IDiscoveryEndpoint
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
    InvokeServiceResponseMessage IDiscoveryEndpoint.InvokeService(InvokeServiceMessage request)
    {
        return base.Channel.InvokeService(request);
    }
    
    public byte[] InvokeService(byte[] InvokeServiceRequest)
    {
        InvokeServiceMessage inValue = new InvokeServiceMessage();
        inValue.InvokeServiceRequest = InvokeServiceRequest;
        InvokeServiceResponseMessage retVal = ((IDiscoveryEndpoint)(this)).InvokeService(inValue);
        return retVal.InvokeServiceResponse;
    }
    
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    FindServersResponseMessage IDiscoveryEndpoint.FindServers(FindServersMessage request)
    {
        return base.Channel.FindServers(request);
    }
    
    public opcfoundation.org.UA._2008._02.Types.xsd.FindServersResponse FindServers(opcfoundation.org.UA._2008._02.Types.xsd.FindServersRequest FindServersRequest)
    {
        FindServersMessage inValue = new FindServersMessage();
        inValue.FindServersRequest = FindServersRequest;
        FindServersResponseMessage retVal = ((IDiscoveryEndpoint)(this)).FindServers(inValue);
        return retVal.FindServersResponse;
    }
    
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    GetEndpointsResponseMessage IDiscoveryEndpoint.GetEndpoints(GetEndpointsMessage request)
    {
        return base.Channel.GetEndpoints(request);
    }
    
    public opcfoundation.org.UA._2008._02.Types.xsd.GetEndpointsResponse GetEndpoints(opcfoundation.org.UA._2008._02.Types.xsd.GetEndpointsRequest GetEndpointsRequest)
    {
        GetEndpointsMessage inValue = new GetEndpointsMessage();
        inValue.GetEndpointsRequest = GetEndpointsRequest;
        GetEndpointsResponseMessage retVal = ((IDiscoveryEndpoint)(this)).GetEndpoints(inValue);
        return retVal.GetEndpointsResponse;
    }
}
