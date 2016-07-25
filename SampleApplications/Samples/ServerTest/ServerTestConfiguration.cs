/* ========================================================================
 * Copyright (c) 2005-2016 The OPC Foundation, Inc. All rights reserved.
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

namespace Opc.Ua.ServerTest
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ServerTestCase", Namespace="http://opcfoundation.org/UA/SDK/ServerTest/Configuration.xsd")]
    public partial class ServerTestCase : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string NameField;
        
        private string ParentField;
        
        private bool EnabledField;
        
        private bool BreakpointField;
        
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
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false)]
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
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string Parent
        {
            get
            {
                return this.ParentField;
            }
            set
            {
                this.ParentField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public bool Enabled
        {
            get
            {
                return this.EnabledField;
            }
            set
            {
                this.EnabledField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public bool Breakpoint
        {
            get
            {
                return this.BreakpointField;
            }
            set
            {
                this.BreakpointField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfServerTestCase", Namespace="http://opcfoundation.org/UA/SDK/ServerTest/Configuration.xsd", ItemName="ServerTestCase")]
    public class ListOfServerTestCase : System.Collections.Generic.List<Opc.Ua.ServerTest.ServerTestCase>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TestNode", Namespace="http://opcfoundation.org/UA/SDK/ServerTest/Configuration.xsd")]
    public partial class TestNode : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string IdField;
        
        private string NameField;
        
        private string PurposeField;
        
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
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                this.IdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
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
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string Purpose
        {
            get
            {
                return this.PurposeField;
            }
            set
            {
                this.PurposeField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfTestNode", Namespace="http://opcfoundation.org/UA/SDK/ServerTest/Configuration.xsd", ItemName="TestNode")]
    public class ListOfTestNode : System.Collections.Generic.List<Opc.Ua.ServerTest.TestNode>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ListOfString", Namespace="http://opcfoundation.org/UA/SDK/ServerTest/Configuration.xsd", ItemName="String")]
    public class ListOfString : System.Collections.Generic.List<string>
    {
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EndpointSelection", Namespace="http://opcfoundation.org/UA/SDK/ServerTest/Configuration.xsd")]
    public enum EndpointSelection : int
    {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Single = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        All = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        AllEncryptAndSign = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        AllSign = 3,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        AllNoSecurity = 4,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        AllUaTcp = 5,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        AllHttpBinary = 6,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        AllHttpXml = 7,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ServerTestConfiguration", Namespace="http://opcfoundation.org/UA/SDK/ServerTest/Configuration.xsd")]
    public partial class ServerTestConfiguration : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private Opc.Ua.ServerTest.ListOfServerTestCase TestCasesField;
        
        private bool ConnectToAllEndpointsField;
        
        private Opc.Ua.ServerTest.EndpointSelection EndpointSelectionField;
        
        private uint IterationsField;
        
        private uint CoverageField;
        
        private int SeedField;
        
        private Opc.Ua.ServerTest.ListOfTestNode BrowseRootsField;
        
        private Opc.Ua.ServerTest.ListOfTestNode WriteableVariablesField;
        
        private Opc.Ua.ServerTest.ListOfString NamespaceUrisField;
        
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
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public Opc.Ua.ServerTest.ListOfServerTestCase TestCases
        {
            get
            {
                return this.TestCasesField;
            }
            set
            {
                this.TestCasesField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public bool ConnectToAllEndpoints
        {
            get
            {
                return this.ConnectToAllEndpointsField;
            }
            set
            {
                this.ConnectToAllEndpointsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public Opc.Ua.ServerTest.EndpointSelection EndpointSelection
        {
            get
            {
                return this.EndpointSelectionField;
            }
            set
            {
                this.EndpointSelectionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public uint Iterations
        {
            get
            {
                return this.IterationsField;
            }
            set
            {
                this.IterationsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public uint Coverage
        {
            get
            {
                return this.CoverageField;
            }
            set
            {
                this.CoverageField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=5)]
        public int Seed
        {
            get
            {
                return this.SeedField;
            }
            set
            {
                this.SeedField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=6)]
        public Opc.Ua.ServerTest.ListOfTestNode BrowseRoots
        {
            get
            {
                return this.BrowseRootsField;
            }
            set
            {
                this.BrowseRootsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=7)]
        public Opc.Ua.ServerTest.ListOfTestNode WriteableVariables
        {
            get
            {
                return this.WriteableVariablesField;
            }
            set
            {
                this.WriteableVariablesField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=8)]
        public Opc.Ua.ServerTest.ListOfString NamespaceUris
        {
            get
            {
                return this.NamespaceUrisField;
            }
            set
            {
                this.NamespaceUrisField = value;
            }
        }
    }
}
