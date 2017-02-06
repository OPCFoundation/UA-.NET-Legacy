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

namespace Opc.Ua.StackTest {
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.312")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://opcfoundation.org/UA/Test")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://opcfoundation.org/UA/Test", IsNullable=false)]
    public partial class TestSequence {
        
        private TestCase[] testCaseField;
        
        private bool haltOnErrorField;
        
        private int randomDataStepSizeField;
        
        private uint logDetailLevelField;
        
        /// <summary />
        public TestSequence() {
            this.haltOnErrorField = false;
            this.randomDataStepSizeField = 7;
            this.logDetailLevelField = ((uint)(4294967295));
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("TestCase")]
        public TestCase[] TestCase {
            get {
                return this.testCaseField;
            }
            set {
                this.testCaseField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool HaltOnError {
            get {
                return this.haltOnErrorField;
            }
            set {
                this.haltOnErrorField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(7)]
        public int RandomDataStepSize {
            get {
                return this.randomDataStepSizeField;
            }
            set {
                this.randomDataStepSizeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(typeof(uint), "4294967295")]
        public uint LogDetailLevel {
            get {
                return this.logDetailLevelField;
            }
            set {
                this.logDetailLevelField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.312")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://opcfoundation.org/UA/Test")]
    public partial class TestCase {
        
        private string nameField;
        
        private string displayTextField;
        
        private uint seedField;
        
        private bool seedFieldSpecified;
        
        private uint responseSeedField;
        
        private bool responseSeedFieldSpecified;
        
        private int startField;
        
        private bool startFieldSpecified;
        
        private int countField;
        
        private bool countFieldSpecified;
        
        private TestParameter[] parameterField;
        
        private uint testIdField;
        
        private bool skipTestField;
        
        /// <summary />
        public TestCase() {
            this.testIdField = ((uint)(0));
            this.skipTestField = false;
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="NCName")]
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        public string DisplayText {
            get {
                return this.displayTextField;
            }
            set {
                this.displayTextField = value;
            }
        }
        
        /// <remarks/>
        public uint Seed {
            get {
                return this.seedField;
            }
            set {
                this.seedField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SeedSpecified {
            get {
                return this.seedFieldSpecified;
            }
            set {
                this.seedFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public uint ResponseSeed {
            get {
                return this.responseSeedField;
            }
            set {
                this.responseSeedField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ResponseSeedSpecified {
            get {
                return this.responseSeedFieldSpecified;
            }
            set {
                this.responseSeedFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public int Start {
            get {
                return this.startField;
            }
            set {
                this.startField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StartSpecified {
            get {
                return this.startFieldSpecified;
            }
            set {
                this.startFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public int Count {
            get {
                return this.countField;
            }
            set {
                this.countField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CountSpecified {
            get {
                return this.countFieldSpecified;
            }
            set {
                this.countFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Parameter")]
        public TestParameter[] Parameter {
            get {
                return this.parameterField;
            }
            set {
                this.parameterField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(typeof(uint), "0")]
        public uint TestId {
            get {
                return this.testIdField;
            }
            set {
                this.testIdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool SkipTest {
            get {
                return this.skipTestField;
            }
            set {
                this.skipTestField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.312")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://opcfoundation.org/UA/Test")]
    public partial class TestParameter {
        
        private string nameField;
        
        private string valueField;
        
        /// <remarks/>
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        public string Value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.312")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://opcfoundation.org/UA/Test")]
    public partial class StackEvent {
        
        private StackEventType eventTypeField;
        
        private System.DateTime timestampField;
        
        private uint requestIdField;
        
        private bool requestIdFieldSpecified;
        
        private StackMessageType messageTypeField;
        
        private bool messageTypeFieldSpecified;
        
        private TestParameter[] fieldField;
        
        /// <remarks/>
        public StackEventType EventType {
            get {
                return this.eventTypeField;
            }
            set {
                this.eventTypeField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime Timestamp {
            get {
                return this.timestampField;
            }
            set {
                this.timestampField = value;
            }
        }
        
        /// <remarks/>
        public uint RequestId {
            get {
                return this.requestIdField;
            }
            set {
                this.requestIdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RequestIdSpecified {
            get {
                return this.requestIdFieldSpecified;
            }
            set {
                this.requestIdFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public StackMessageType MessageType {
            get {
                return this.messageTypeField;
            }
            set {
                this.messageTypeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MessageTypeSpecified {
            get {
                return this.messageTypeFieldSpecified;
            }
            set {
                this.messageTypeFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Field")]
        public TestParameter[] Field {
            get {
                return this.fieldField;
            }
            set {
                this.fieldField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.312")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://opcfoundation.org/UA/Test")]
    public enum StackEventType {
        
        /// <remarks/>
        SocketConnected,
        
        /// <remarks/>
        SocketConnectFailed,
        
        /// <remarks/>
        SocketClosed,
        
        /// <remarks/>
        RequestQueued,
        
        /// <remarks/>
        RequestSent,
        
        /// <remarks/>
        RequestReceived,
        
        /// <remarks/>
        RequestComplete,
        
        /// <remarks/>
        ResponseQueued,
        
        /// <remarks/>
        ResponseSent,
        
        /// <remarks/>
        ResponseReceived,
        
        /// <remarks/>
        ResponseComplete,
        
        /// <remarks/>
        MessageSent,
        
        /// <remarks/>
        MessageReceived,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.312")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://opcfoundation.org/UA/Test")]
    public enum StackMessageType {
        
        /// <remarks/>
        Hello,
        
        /// <remarks/>
        Acknowledge,
        
        /// <remarks/>
        Disconnect,
        
        /// <remarks/>
        DataChunk,
        
        /// <remarks/>
        DataFinal,
        
        /// <remarks/>
        Abort,
        
        /// <remarks/>
        Error,
        
        /// <remarks/>
        Unknown,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.312")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://opcfoundation.org/UA/Test")]
    public partial class TestEvent {
        
        private uint testIdField;
        
        private int iterationField;
        
        private System.DateTime timestampField;
        
        private TestEventType eventTypeField;
        
        private string detailsField;
        
        private TestParameter[] resultsField;
        
        private StackEvent[] stackEventsField;
        
        /// <remarks/>
        public uint TestId {
            get {
                return this.testIdField;
            }
            set {
                this.testIdField = value;
            }
        }
        
        /// <remarks/>
        public int Iteration {
            get {
                return this.iterationField;
            }
            set {
                this.iterationField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime Timestamp {
            get {
                return this.timestampField;
            }
            set {
                this.timestampField = value;
            }
        }
        
        /// <remarks/>
        public TestEventType EventType {
            get {
                return this.eventTypeField;
            }
            set {
                this.eventTypeField = value;
            }
        }
        
        /// <remarks/>
        public string Details {
            get {
                return this.detailsField;
            }
            set {
                this.detailsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Results")]
        public TestParameter[] Results {
            get {
                return this.resultsField;
            }
            set {
                this.resultsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("StackEvents")]
        public StackEvent[] StackEvents {
            get {
                return this.stackEventsField;
            }
            set {
                this.stackEventsField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.312")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://opcfoundation.org/UA/Test")]
    public enum TestEventType {
        
        /// <remarks/>
        NotValidated,
        
        /// <remarks/>
        Started,
        
        /// <remarks/>
        Failed,
        
        /// <remarks/>
        Completed,
        
        /// <remarks/>
        StackEvents,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.312")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://opcfoundation.org/UA/Test")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://opcfoundation.org/UA/Test", IsNullable=false)]
    public partial class TestLog {
        
        private string processNameField;
        
        private string secureChannelIdField;
        
        private string testCaseFileField;
        
        private string randomDataFileField;
        
        private System.DateTime createTimeField;
        
        private TestEvent[] testEventField;
        
        /// <remarks/>
        public string ProcessName {
            get {
                return this.processNameField;
            }
            set {
                this.processNameField = value;
            }
        }
        
        /// <remarks/>
        public string SecureChannelId {
            get {
                return this.secureChannelIdField;
            }
            set {
                this.secureChannelIdField = value;
            }
        }
        
        /// <remarks/>
        public string TestCaseFile {
            get {
                return this.testCaseFileField;
            }
            set {
                this.testCaseFileField = value;
            }
        }
        
        /// <remarks/>
        public string RandomDataFile {
            get {
                return this.randomDataFileField;
            }
            set {
                this.randomDataFileField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime CreateTime {
            get {
                return this.createTimeField;
            }
            set {
                this.createTimeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("TestEvent")]
        public TestEvent[] TestEvent {
            get {
                return this.testEventField;
            }
            set {
                this.testEventField = value;
            }
        }
    }
}
