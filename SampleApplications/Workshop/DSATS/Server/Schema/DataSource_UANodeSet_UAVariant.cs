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

namespace DsatsDemo.DataSource {
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://opcfoundation.org/DSATSDemo/DataSource.xsd")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://opcfoundation.org/DSATSDemo/DataSource.xsd", IsNullable=false)]
    public partial class DataSource {
        
        private string[] namespaceUrisField;
        
        private string[] serverUrisField;
        
        private PhaseType[] phaseField;
        
        private LockType[] lockField;
        
        private DeclarationType[] declarationField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Uri", Namespace="http://opcfoundation.org/UA/2011/03/UANodeSet.xsd", IsNullable=false)]
        public string[] NamespaceUris {
            get {
                return this.namespaceUrisField;
            }
            set {
                this.namespaceUrisField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Uri", Namespace="http://opcfoundation.org/UA/2011/03/UANodeSet.xsd", IsNullable=false)]
        public string[] ServerUris {
            get {
                return this.serverUrisField;
            }
            set {
                this.serverUrisField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Phase")]
        public PhaseType[] Phase {
            get {
                return this.phaseField;
            }
            set {
                this.phaseField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Lock")]
        public LockType[] Lock {
            get {
                return this.lockField;
            }
            set {
                this.lockField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Declaration")]
        public DeclarationType[] Declaration {
            get {
                return this.declarationField;
            }
            set {
                this.declarationField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://opcfoundation.org/DSATSDemo/DataSource.xsd")]
    public partial class PhaseType : BaseObject {
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(DeclarationType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LockType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PhaseType))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://opcfoundation.org/DSATSDemo/DataSource.xsd")]
    public partial class BaseObject {
        
        private LocalizedText[] displayNameField;
        
        private LocalizedText[] descriptionField;
        
        private string browseNameField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("DisplayName")]
        public LocalizedText[] DisplayName {
            get {
                return this.displayNameField;
            }
            set {
                this.displayNameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Description")]
        public LocalizedText[] Description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string BrowseName {
            get {
                return this.browseNameField;
            }
            set {
                this.browseNameField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://opcfoundation.org/UA/2011/03/UANodeSet.xsd")]
    public partial class LocalizedText {
        
        private string localeField;
        
        private string valueField;
        
        public LocalizedText() {
            this.localeField = "";
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute("")]
        public string Locale {
            get {
                return this.localeField;
            }
            set {
                this.localeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://opcfoundation.org/DSATSDemo/DataSource.xsd")]
    public partial class SourceType {
        
        private System.Xml.XmlElement defaultValueField;
        
        private string remoteIdField;
        
        private string pathField;
        
        /// <remarks/>
        public System.Xml.XmlElement DefaultValue {
            get {
                return this.defaultValueField;
            }
            set {
                this.defaultValueField = value;
            }
        }
        
        /// <remarks/>
        public string RemoteId {
            get {
                return this.remoteIdField;
            }
            set {
                this.remoteIdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Path {
            get {
                return this.pathField;
            }
            set {
                this.pathField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://opcfoundation.org/DSATSDemo/DataSource.xsd")]
    public partial class AccessRuleType {
        
        private string phaseField;
        
        private string lockField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Phase {
            get {
                return this.phaseField;
            }
            set {
                this.phaseField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Lock {
            get {
                return this.lockField;
            }
            set {
                this.lockField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://opcfoundation.org/DSATSDemo/DataSource.xsd")]
    public partial class CertificatePermissionType {
        
        private string thumbprintField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Thumbprint {
            get {
                return this.thumbprintField;
            }
            set {
                this.thumbprintField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://opcfoundation.org/DSATSDemo/DataSource.xsd")]
    public partial class DeclarationType : BaseObject {
        
        private AccessRuleType[] accessRulesField;
        
        private SourceType[] sourcesField;
        
        private string pathField;
        
        private string typeDefinitionIdField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("AccessRule", IsNullable=false)]
        public AccessRuleType[] AccessRules {
            get {
                return this.accessRulesField;
            }
            set {
                this.accessRulesField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Source", IsNullable=false)]
        public SourceType[] Sources {
            get {
                return this.sourcesField;
            }
            set {
                this.sourcesField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Path {
            get {
                return this.pathField;
            }
            set {
                this.pathField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string TypeDefinitionId {
            get {
                return this.typeDefinitionIdField;
            }
            set {
                this.typeDefinitionIdField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://opcfoundation.org/DSATSDemo/DataSource.xsd")]
    public partial class LockType : BaseObject {
        
        private CertificatePermissionType[] permissionField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Permission")]
        public CertificatePermissionType[] Permission {
            get {
                return this.permissionField;
            }
            set {
                this.permissionField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://opcfoundation.org/UA/2011/03/UANodeSet.xsd")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://opcfoundation.org/UA/2011/03/UANodeSet.xsd", IsNullable=false)]
    public partial class UANodeSet {
        
        private string[] namespaceUrisField;
        
        private string[] serverUrisField;
        
        private NodeIdAlias[] aliasesField;
        
        private UANode[] itemsField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Uri", IsNullable=false)]
        public string[] NamespaceUris {
            get {
                return this.namespaceUrisField;
            }
            set {
                this.namespaceUrisField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Uri", IsNullable=false)]
        public string[] ServerUris {
            get {
                return this.serverUrisField;
            }
            set {
                this.serverUrisField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Alias", IsNullable=false)]
        public NodeIdAlias[] Aliases {
            get {
                return this.aliasesField;
            }
            set {
                this.aliasesField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("UADataType", typeof(UADataType))]
        [System.Xml.Serialization.XmlElementAttribute("UAMethod", typeof(UAMethod))]
        [System.Xml.Serialization.XmlElementAttribute("UAObject", typeof(UAObject))]
        [System.Xml.Serialization.XmlElementAttribute("UAObjectType", typeof(UAObjectType))]
        [System.Xml.Serialization.XmlElementAttribute("UAReferenceType", typeof(UAReferenceType))]
        [System.Xml.Serialization.XmlElementAttribute("UAVariable", typeof(UAVariable))]
        [System.Xml.Serialization.XmlElementAttribute("UAVariableType", typeof(UAVariableType))]
        [System.Xml.Serialization.XmlElementAttribute("UAView", typeof(UAView))]
        public UANode[] Items {
            get {
                return this.itemsField;
            }
            set {
                this.itemsField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://opcfoundation.org/UA/2011/03/UANodeSet.xsd")]
    public partial class NodeIdAlias {
        
        private string aliasField;
        
        private string valueField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Alias {
            get {
                return this.aliasField;
            }
            set {
                this.aliasField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://opcfoundation.org/UA/2011/03/UANodeSet.xsd")]
    public partial class UADataType : UAType {
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(UAReferenceType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(UADataType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(UAVariableType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(UAObjectType))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://opcfoundation.org/UA/2011/03/UANodeSet.xsd")]
    public partial class UAType : UANode {
        
        private bool isAbstractField;
        
        public UAType() {
            this.isAbstractField = false;
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool IsAbstract {
            get {
                return this.isAbstractField;
            }
            set {
                this.isAbstractField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(UAType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(UAReferenceType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(UADataType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(UAVariableType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(UAObjectType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(UAInstance))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(UAView))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(UAMethod))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(UAVariable))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(UAObject))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://opcfoundation.org/UA/2011/03/UANodeSet.xsd")]
    public partial class UANode {
        
        private LocalizedText[] displayNameField;
        
        private LocalizedText descriptionField;
        
        private Reference[] referencesField;
        
        private string nodeIdField;
        
        private string browseNameField;
        
        private uint writeMaskField;
        
        private uint userWriteMaskField;
        
        public UANode() {
            this.writeMaskField = ((uint)(0));
            this.userWriteMaskField = ((uint)(0));
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("DisplayName")]
        public LocalizedText[] DisplayName {
            get {
                return this.displayNameField;
            }
            set {
                this.displayNameField = value;
            }
        }
        
        /// <remarks/>
        public LocalizedText Description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable=false)]
        public Reference[] References {
            get {
                return this.referencesField;
            }
            set {
                this.referencesField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string NodeId {
            get {
                return this.nodeIdField;
            }
            set {
                this.nodeIdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string BrowseName {
            get {
                return this.browseNameField;
            }
            set {
                this.browseNameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(typeof(uint), "0")]
        public uint WriteMask {
            get {
                return this.writeMaskField;
            }
            set {
                this.writeMaskField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(typeof(uint), "0")]
        public uint UserWriteMask {
            get {
                return this.userWriteMaskField;
            }
            set {
                this.userWriteMaskField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://opcfoundation.org/UA/2011/03/UANodeSet.xsd")]
    public partial class Reference {
        
        private string referenceTypeField;
        
        private bool isForwardField;
        
        private string valueField;
        
        public Reference() {
            this.isForwardField = true;
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ReferenceType {
            get {
                return this.referenceTypeField;
            }
            set {
                this.referenceTypeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(true)]
        public bool IsForward {
            get {
                return this.isForwardField;
            }
            set {
                this.isForwardField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
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
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(UAView))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(UAMethod))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(UAVariable))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(UAObject))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://opcfoundation.org/UA/2011/03/UANodeSet.xsd")]
    public partial class UAInstance : UANode {
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://opcfoundation.org/UA/2011/03/UANodeSet.xsd")]
    public partial class UAView : UAInstance {
        
        private bool containsNoLoopsField;
        
        public UAView() {
            this.containsNoLoopsField = false;
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool ContainsNoLoops {
            get {
                return this.containsNoLoopsField;
            }
            set {
                this.containsNoLoopsField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://opcfoundation.org/UA/2011/03/UANodeSet.xsd")]
    public partial class UAMethod : UAInstance {
        
        private bool executableField;
        
        private bool userExecutableField;
        
        public UAMethod() {
            this.executableField = true;
            this.userExecutableField = true;
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(true)]
        public bool Executable {
            get {
                return this.executableField;
            }
            set {
                this.executableField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(true)]
        public bool UserExecutable {
            get {
                return this.userExecutableField;
            }
            set {
                this.userExecutableField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://opcfoundation.org/UA/2011/03/UANodeSet.xsd")]
    public partial class UAVariable : UAInstance {
        
        private System.Xml.XmlElement valueField;
        
        private string dataTypeField;
        
        private int valueRankField;
        
        private string arrayDimensionsField;
        
        private byte accessLevelField;
        
        private byte userAccessLevelField;
        
        private double minimumSamplingIntervalField;
        
        private bool historizingField;
        
        public UAVariable() {
            this.dataTypeField = "i=24";
            this.valueRankField = -1;
            this.arrayDimensionsField = "";
            this.accessLevelField = ((byte)(1));
            this.userAccessLevelField = ((byte)(1));
            this.minimumSamplingIntervalField = 0;
            this.historizingField = false;
        }
        
        /// <remarks/>
        public System.Xml.XmlElement Value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute("i=24")]
        public string DataType {
            get {
                return this.dataTypeField;
            }
            set {
                this.dataTypeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(-1)]
        public int ValueRank {
            get {
                return this.valueRankField;
            }
            set {
                this.valueRankField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="token")]
        [System.ComponentModel.DefaultValueAttribute("")]
        public string ArrayDimensions {
            get {
                return this.arrayDimensionsField;
            }
            set {
                this.arrayDimensionsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(typeof(byte), "1")]
        public byte AccessLevel {
            get {
                return this.accessLevelField;
            }
            set {
                this.accessLevelField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(typeof(byte), "1")]
        public byte UserAccessLevel {
            get {
                return this.userAccessLevelField;
            }
            set {
                this.userAccessLevelField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(0)]
        public double MinimumSamplingInterval {
            get {
                return this.minimumSamplingIntervalField;
            }
            set {
                this.minimumSamplingIntervalField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool Historizing {
            get {
                return this.historizingField;
            }
            set {
                this.historizingField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://opcfoundation.org/UA/2011/03/UANodeSet.xsd")]
    public partial class UAObject : UAInstance {
        
        private byte eventNotifierField;
        
        public UAObject() {
            this.eventNotifierField = ((byte)(0));
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(typeof(byte), "0")]
        public byte EventNotifier {
            get {
                return this.eventNotifierField;
            }
            set {
                this.eventNotifierField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://opcfoundation.org/UA/2011/03/UANodeSet.xsd")]
    public partial class UAReferenceType : UAType {
        
        private LocalizedText[] inverseNameField;
        
        private bool symmetricField;
        
        public UAReferenceType() {
            this.symmetricField = false;
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("InverseName")]
        public LocalizedText[] InverseName {
            get {
                return this.inverseNameField;
            }
            set {
                this.inverseNameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool Symmetric {
            get {
                return this.symmetricField;
            }
            set {
                this.symmetricField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://opcfoundation.org/UA/2011/03/UANodeSet.xsd")]
    public partial class UAVariableType : UAType {
        
        private System.Xml.XmlElement valueField;
        
        private string dataTypeField;
        
        private int valueRankField;
        
        private string arrayDimensionsField;
        
        public UAVariableType() {
            this.dataTypeField = "i=24";
            this.valueRankField = -1;
            this.arrayDimensionsField = "";
        }
        
        /// <remarks/>
        public System.Xml.XmlElement Value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute("i=24")]
        public string DataType {
            get {
                return this.dataTypeField;
            }
            set {
                this.dataTypeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(-1)]
        public int ValueRank {
            get {
                return this.valueRankField;
            }
            set {
                this.valueRankField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="token")]
        [System.ComponentModel.DefaultValueAttribute("")]
        public string ArrayDimensions {
            get {
                return this.arrayDimensionsField;
            }
            set {
                this.arrayDimensionsField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://opcfoundation.org/UA/2011/03/UANodeSet.xsd")]
    public partial class UAObjectType : UAType {
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://opcfoundation.org/UA/2008/02/Types.xsd", IsNullable=true)]
    public partial class ListOfVariant {
        
        private System.Xml.XmlElement[] variantField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Variant", IsNullable=true)]
        public System.Xml.XmlElement[] Variant {
            get {
                return this.variantField;
            }
            set {
                this.variantField = value;
            }
        }
    }
}
