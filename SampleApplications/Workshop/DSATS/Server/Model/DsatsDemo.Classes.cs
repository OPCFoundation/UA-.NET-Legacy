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

using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Xml;
using System.Runtime.Serialization;
using Opc.Ua;

namespace DsatsDemo
{
    #region PhaseState Class
    #if (!OPCUA_EXCLUDE_PhaseState)
    /// <summary>
    /// Stores an instance of the PhaseType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class PhaseState : BaseObjectState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public PhaseState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(DsatsDemo.ObjectTypes.PhaseType, DsatsDemo.Namespaces.DsatsDemo, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AQAAACIAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvRFNBVFNEZW1v/////wRggAABAAAAAQARAAAA" +
           "UGhhc2VUeXBlSW5zdGFuY2UBAccAAQHHAP////8AAAAA";
        #endregion
        #endif
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        #endregion

        #region Private Fields
        #endregion
    }
    #endif
    #endregion

    #region LockStateMachineState Class
    #if (!OPCUA_EXCLUDE_LockStateMachineState)
    /// <summary>
    /// Stores an instance of the LockStateMachineType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class LockStateMachineState : FiniteStateMachineState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public LockStateMachineState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(DsatsDemo.ObjectTypes.LockStateMachineType, DsatsDemo.Namespaces.DsatsDemo, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AQAAACIAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvRFNBVFNEZW1v/////wRggAABAAAAAQAcAAAA" +
           "TG9ja1N0YXRlTWFjaGluZVR5cGVJbnN0YW5jZQEBOgIBAToC/////wEAAAAVYIkKAgAAAAAADAAAAEN1" +
           "cnJlbnRTdGF0ZQEBOwIALwEAyAo7AgAAABX/////AQH/////AQAAABVgiQoCAAAAAAACAAAASWQBATwC" +
           "AC4ARDwCAAAAEf////8BAf////8AAAAA";
        #endregion
        #endif
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        #endregion

        #region Private Fields
        #endregion
    }
    #endif
    #endregion

    #region LockConditionState Class
    #if (!OPCUA_EXCLUDE_LockConditionState)
    /// <summary>
    /// Stores an instance of the LockConditionType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class LockConditionState : ConditionState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public LockConditionState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(DsatsDemo.ObjectTypes.LockConditionType, DsatsDemo.Namespaces.DsatsDemo, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AQAAACIAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvRFNBVFNEZW1v/////wRggAABAAAAAQAZAAAA" +
           "TG9ja0NvbmRpdGlvblR5cGVJbnN0YW5jZQEBVgIBAVYC/////xwAAAA1YIkKAgAAAAAABwAAAEV2ZW50" +
           "SWQBAVcCAwAAAAArAAAAQSBnbG9iYWxseSB1bmlxdWUgaWRlbnRpZmllciBmb3IgdGhlIGV2ZW50LgAu" +
           "AERXAgAAAA//////AQH/////AAAAADVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQFYAgMAAAAAIgAAAFRo" +
           "ZSBpZGVudGlmaWVyIGZvciB0aGUgZXZlbnQgdHlwZS4ALgBEWAIAAAAR/////wEB/////wAAAAA1YIkK" +
           "AgAAAAAACgAAAFNvdXJjZU5vZGUBAVkCAwAAAAAYAAAAVGhlIHNvdXJjZSBvZiB0aGUgZXZlbnQuAC4A" +
           "RFkCAAAAEf////8BAf////8AAAAANWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQFaAgMAAAAAKQAAAEEg" +
           "ZGVzY3JpcHRpb24gb2YgdGhlIHNvdXJjZSBvZiB0aGUgZXZlbnQuAC4ARFoCAAAADP////8BAf////8A" +
           "AAAANWCJCgIAAAAAAAQAAABUaW1lAQFbAgMAAAAAGAAAAFdoZW4gdGhlIGV2ZW50IG9jY3VycmVkLgAu" +
           "AERbAgAAAQAmAf////8BAf////8AAAAANWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEBXAIDAAAAAD4A" +
           "AABXaGVuIHRoZSBzZXJ2ZXIgcmVjZWl2ZWQgdGhlIGV2ZW50IGZyb20gdGhlIHVuZGVybHlpbmcgc3lz" +
           "dGVtLgAuAERcAgAAAQAmAf////8BAf////8AAAAANWCJCgIAAAAAAAkAAABMb2NhbFRpbWUBAV0CAwAA" +
           "AAA8AAAASW5mb3JtYXRpb24gYWJvdXQgdGhlIGxvY2FsIHRpbWUgd2hlcmUgdGhlIGV2ZW50IG9yaWdp" +
           "bmF0ZWQuAC4ARF0CAAABANAi/////wEB/////wAAAAA1YIkKAgAAAAAABwAAAE1lc3NhZ2UBAV4CAwAA" +
           "AAAlAAAAQSBsb2NhbGl6ZWQgZGVzY3JpcHRpb24gb2YgdGhlIGV2ZW50LgAuAEReAgAAABX/////AQH/" +
           "////AAAAADVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAV8CAwAAAAAhAAAASW5kaWNhdGVzIGhvdyB1cmdl" +
           "bnQgYW4gZXZlbnQgaXMuAC4ARF8CAAAABf////8BAf////8AAAAAFWCJCgIAAAAAABAAAABDb25kaXRp" +
           "b25DbGFzc0lkAQFgAgAuAERgAgAAABH/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ29uZGl0aW9u" +
           "Q2xhc3NOYW1lAQFhAgAuAERhAgAAABX/////AQH/////AAAAABVgiQoCAAAAAAANAAAAQ29uZGl0aW9u" +
           "TmFtZQEBYgIALgBEYgIAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAEJyYW5jaElkAQFjAgAu" +
           "AERjAgAAABH/////AQH/////AAAAABVgiQoCAAAAAAAGAAAAUmV0YWluAQFkAgAuAERkAgAAAAH/////" +
           "AQH/////AAAAABVgiQoCAAAAAQAMAAAARW5hYmxlZFN0YXRlAQFlAgAvAQAjI2UCAAAAFf////8BAQEA" +
           "AAABACwjAAEBfgIBAAAAFWCJCgIAAAAAAAIAAABJZAEBZgIALgBEZgIAAAAB/////wEB/////wAAAAAV" +
           "YIkKAgAAAAAABwAAAFF1YWxpdHkBAW4CAC8BACojbgIAAAAT/////wEB/////wEAAAAVYIkKAgAAAAAA" +
           "DwAAAFNvdXJjZVRpbWVzdGFtcAEBbwIALgBEbwIAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAM" +
           "AAAATGFzdFNldmVyaXR5AQFwAgAvAQAqI3ACAAAABf////8BAf////8BAAAAFWCJCgIAAAAAAA8AAABT" +
           "b3VyY2VUaW1lc3RhbXABAXECAC4ARHECAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAENv" +
           "bW1lbnQBAXICAC8BACojcgIAAAAV/////wEB/////wEAAAAVYIkKAgAAAAAADwAAAFNvdXJjZVRpbWVz" +
           "dGFtcAEBcwIALgBEcwIAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAQAMAAAAQ2xpZW50VXNlcklk" +
           "AQF0AgAuAER0AgAAAAz/////AQH/////AAAAAARhggoEAAAAAAAGAAAARW5hYmxlAQF1AgAvAQBDI3UC" +
           "AAABAQEAAAABAPkLAAEA8woAAAAABGGCCgQAAAAAAAcAAABEaXNhYmxlAQF2AgAvAQBEI3YCAAABAQEA" +
           "AAABAPkLAAEA8woAAAAAFWCJCgIAAAABAAkAAABTZXNzaW9uSWQBAXsCAC4ARHsCAAAAEf////8BAf//" +
           "//8AAAAAFWCJCgIAAAABAAsAAABTdWJqZWN0TmFtZQEBtAIALgBEtAIAAAAM/////wEB/////wAAAAAE" +
           "YIAKAQAAAAEACQAAAExvY2tTdGF0ZQEBfgIALwEBOgJ+AgAAAQAAAAEALCMBAQFlAgEAAAAVYIkKAgAA" +
           "AAEADAAAAEN1cnJlbnRTdGF0ZQEBfwIALwEAyAp/AgAAABX/////AwP/////AQAAABVgiQoCAAAAAAAC" +
           "AAAASWQBAYACAC4ARIACAAAAEf////8BAf////8AAAAAFWCJCgIAAAABABEAAABMb2NrU3RhdGVBc1N0" +
           "cmluZwEBbAMALgBEbAMAAAAM/////wMD/////wAAAAAEYYIKBAAAAAEABwAAAFJlcXVlc3QBAZoCAC8B" +
           "AZoCmgIAAAEB/////wAAAAAEYYIKBAAAAAEABwAAAFJlbGVhc2UBAZsCAC8BAZsCmwIAAAEB/////wAA" +
           "AAAEYYIKBAAAAAEABwAAAEFwcHJvdmUBAZwCAC8BAZwCnAIAAAEB/////wAAAAA=";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// A description for the SessionId Property.
        /// </summary>
        public PropertyState<NodeId> SessionId
        {
            get
            { 
                return m_sessionId;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_sessionId, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_sessionId = value;
            }
        }

        /// <summary>
        /// A description for the SubjectName Property.
        /// </summary>
        public PropertyState<string> SubjectName
        {
            get
            { 
                return m_subjectName;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_subjectName, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_subjectName = value;
            }
        }

        /// <summary>
        /// A description for the LockState Object.
        /// </summary>
        public LockStateMachineState LockState
        {
            get
            { 
                return m_lockState;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_lockState, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_lockState = value;
            }
        }

        /// <summary>
        /// A description for the LockStateAsString Property.
        /// </summary>
        public PropertyState<string> LockStateAsString
        {
            get
            { 
                return m_lockStateAsString;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_lockStateAsString, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_lockStateAsString = value;
            }
        }

        /// <summary>
        /// A description for the Request Method.
        /// </summary>
        public MethodState Request
        {
            get
            { 
                return m_requestMethod;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_requestMethod, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_requestMethod = value;
            }
        }

        /// <summary>
        /// A description for the Release Method.
        /// </summary>
        public MethodState Release
        {
            get
            { 
                return m_releaseMethod;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_releaseMethod, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_releaseMethod = value;
            }
        }

        /// <summary>
        /// A description for the Approve Method.
        /// </summary>
        public MethodState Approve
        {
            get
            { 
                return m_approveMethod;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_approveMethod, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_approveMethod = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_sessionId != null)
            {
                children.Add(m_sessionId);
            }

            if (m_subjectName != null)
            {
                children.Add(m_subjectName);
            }

            if (m_lockState != null)
            {
                children.Add(m_lockState);
            }

            if (m_lockStateAsString != null)
            {
                children.Add(m_lockStateAsString);
            }

            if (m_requestMethod != null)
            {
                children.Add(m_requestMethod);
            }

            if (m_releaseMethod != null)
            {
                children.Add(m_releaseMethod);
            }

            if (m_approveMethod != null)
            {
                children.Add(m_approveMethod);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case DsatsDemo.BrowseNames.SessionId:
                {
                    if (createOrReplace)
                    {
                        if (SessionId == null)
                        {
                            if (replacement == null)
                            {
                                SessionId = new PropertyState<NodeId>(this);
                            }
                            else
                            {
                                SessionId = (PropertyState<NodeId>)replacement;
                            }
                        }
                    }

                    instance = SessionId;
                    break;
                }

                case DsatsDemo.BrowseNames.SubjectName:
                {
                    if (createOrReplace)
                    {
                        if (SubjectName == null)
                        {
                            if (replacement == null)
                            {
                                SubjectName = new PropertyState<string>(this);
                            }
                            else
                            {
                                SubjectName = (PropertyState<string>)replacement;
                            }
                        }
                    }

                    instance = SubjectName;
                    break;
                }

                case DsatsDemo.BrowseNames.LockState:
                {
                    if (createOrReplace)
                    {
                        if (LockState == null)
                        {
                            if (replacement == null)
                            {
                                LockState = new LockStateMachineState(this);
                            }
                            else
                            {
                                LockState = (LockStateMachineState)replacement;
                            }
                        }
                    }

                    instance = LockState;
                    break;
                }

                case DsatsDemo.BrowseNames.LockStateAsString:
                {
                    if (createOrReplace)
                    {
                        if (LockStateAsString == null)
                        {
                            if (replacement == null)
                            {
                                LockStateAsString = new PropertyState<string>(this);
                            }
                            else
                            {
                                LockStateAsString = (PropertyState<string>)replacement;
                            }
                        }
                    }

                    instance = LockStateAsString;
                    break;
                }

                case DsatsDemo.BrowseNames.Request:
                {
                    if (createOrReplace)
                    {
                        if (Request == null)
                        {
                            if (replacement == null)
                            {
                                Request = new MethodState(this);
                            }
                            else
                            {
                                Request = (MethodState)replacement;
                            }
                        }
                    }

                    instance = Request;
                    break;
                }

                case DsatsDemo.BrowseNames.Release:
                {
                    if (createOrReplace)
                    {
                        if (Release == null)
                        {
                            if (replacement == null)
                            {
                                Release = new MethodState(this);
                            }
                            else
                            {
                                Release = (MethodState)replacement;
                            }
                        }
                    }

                    instance = Release;
                    break;
                }

                case DsatsDemo.BrowseNames.Approve:
                {
                    if (createOrReplace)
                    {
                        if (Approve == null)
                        {
                            if (replacement == null)
                            {
                                Approve = new MethodState(this);
                            }
                            else
                            {
                                Approve = (MethodState)replacement;
                            }
                        }
                    }

                    instance = Approve;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private PropertyState<NodeId> m_sessionId;
        private PropertyState<string> m_subjectName;
        private LockStateMachineState m_lockState;
        private PropertyState<string> m_lockStateAsString;
        private MethodState m_requestMethod;
        private MethodState m_releaseMethod;
        private MethodState m_approveMethod;
        #endregion
    }
    #endif
    #endregion

    #region AssetInfoFolderState Class
    #if (!OPCUA_EXCLUDE_AssetInfoFolderState)
    /// <summary>
    /// Stores an instance of the AssetInfoFolderType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class AssetInfoFolderState : FolderState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public AssetInfoFolderState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(DsatsDemo.ObjectTypes.AssetInfoFolderType, DsatsDemo.Namespaces.DsatsDemo, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AQAAACIAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvRFNBVFNEZW1v/////wRggAABAAAAAQAbAAAA" +
           "QXNzZXRJbmZvRm9sZGVyVHlwZUluc3RhbmNlAQFIAQEBSAH/////AwAAABVgiQoCAAAAAQAMAAAATWFu" +
           "dWZhY3R1cmVyAQFJAQAuAERJAQAAAAz/////AQH/////AAAAABVgiQoCAAAAAQALAAAATW9kZWxOdW1i" +
           "ZXIBAUoBAC4AREoBAAAADP////8BAf////8AAAAAFWCJCgIAAAABAAwAAABTZXJpYWxOdW1iZXIBAUsB" +
           "AC4AREsBAAAADP////8BAf////8AAAAA";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// A description for the Manufacturer Property.
        /// </summary>
        public PropertyState<string> Manufacturer
        {
            get
            { 
                return m_manufacturer;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_manufacturer, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_manufacturer = value;
            }
        }

        /// <summary>
        /// A description for the ModelNumber Property.
        /// </summary>
        public PropertyState<string> ModelNumber
        {
            get
            { 
                return m_modelNumber;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_modelNumber, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_modelNumber = value;
            }
        }

        /// <summary>
        /// A description for the SerialNumber Property.
        /// </summary>
        public PropertyState<string> SerialNumber
        {
            get
            { 
                return m_serialNumber;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_serialNumber, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_serialNumber = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_manufacturer != null)
            {
                children.Add(m_manufacturer);
            }

            if (m_modelNumber != null)
            {
                children.Add(m_modelNumber);
            }

            if (m_serialNumber != null)
            {
                children.Add(m_serialNumber);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case DsatsDemo.BrowseNames.Manufacturer:
                {
                    if (createOrReplace)
                    {
                        if (Manufacturer == null)
                        {
                            if (replacement == null)
                            {
                                Manufacturer = new PropertyState<string>(this);
                            }
                            else
                            {
                                Manufacturer = (PropertyState<string>)replacement;
                            }
                        }
                    }

                    instance = Manufacturer;
                    break;
                }

                case DsatsDemo.BrowseNames.ModelNumber:
                {
                    if (createOrReplace)
                    {
                        if (ModelNumber == null)
                        {
                            if (replacement == null)
                            {
                                ModelNumber = new PropertyState<string>(this);
                            }
                            else
                            {
                                ModelNumber = (PropertyState<string>)replacement;
                            }
                        }
                    }

                    instance = ModelNumber;
                    break;
                }

                case DsatsDemo.BrowseNames.SerialNumber:
                {
                    if (createOrReplace)
                    {
                        if (SerialNumber == null)
                        {
                            if (replacement == null)
                            {
                                SerialNumber = new PropertyState<string>(this);
                            }
                            else
                            {
                                SerialNumber = (PropertyState<string>)replacement;
                            }
                        }
                    }

                    instance = SerialNumber;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private PropertyState<string> m_manufacturer;
        private PropertyState<string> m_modelNumber;
        private PropertyState<string> m_serialNumber;
        #endregion
    }
    #endif
    #endregion

    #region ToolState Class
    #if (!OPCUA_EXCLUDE_ToolState)
    /// <summary>
    /// Stores an instance of the ToolType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class ToolState : BaseObjectState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public ToolState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(DsatsDemo.ObjectTypes.ToolType, DsatsDemo.Namespaces.DsatsDemo, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AQAAACIAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvRFNBVFNEZW1v/////wRggAABAAAAAQAQAAAA" +
           "VG9vbFR5cGVJbnN0YW5jZQEBnQIBAZ0C/////wsAAAAVYIkKAgAAAAEABwAAAEVuYWJsZWQBAZ4CAC4A" +
           "RJ4CAAAAAf////8BAf////8AAAAAFWCJCgIAAAABAAsAAABEZXZpY2VSZWFkeQEB+AIALgBE+AIAAAAB" +
           "/////wEB/////wAAAAAVYIkKAgAAAAEADAAAAExvY2FsQ29udHJvbAEB+QIALgBE+QIAAAAB/////wEB" +
           "/////wAAAAAVYIkKAgAAAAEADwAAAFdhdGNoZG9nQ291bnRlcgEBwgIALgBEwgIAAAAH/////wMD////" +
           "/wAAAAAVYIkKAgAAAAEADAAAAEFjdGl2ZUxvY2tJZAEBxwIALgBExwIAAAAM/////wMD/////wAAAAAE" +
           "YIAKAQAAAAEACQAAAEFzc2V0SW5mbwEBnwIALwEBSAGfAgAA/////wMAAAAVYIkKAgAAAAEADAAAAE1h" +
           "bnVmYWN0dXJlcgEBoAIALgBEoAIAAAAM/////wEB/////wAAAAAVYIkKAgAAAAEACwAAAE1vZGVsTnVt" +
           "YmVyAQGhAgAuAEShAgAAAAz/////AQH/////AAAAABVgiQoCAAAAAQAMAAAAU2VyaWFsTnVtYmVyAQGi" +
           "AgAuAESiAgAAAAz/////AQH/////AAAAAARggAoBAAAAAQAMAAAATWVhc3VyZW1lbnRzAQGjAgAvAD2j" +
           "AgAA/////wAAAAAEYIAKAQAAAAEACQAAAFNldFBvaW50cwEBpAIALwA9pAIAAP////8AAAAABGCACgEA" +
           "AAABAAYAAABMaW1pdHMBAaUCAC8APaUCAAD/////AAAAAARggAoBAAAAAQARAAAAT3BlcmF0aW9uYWxM" +
           "aW1pdHMBAfoCAC8APfoCAAD/////AAAAAARggAoBAAAAAQALAAAAQWNjZXNzUnVsZXMBAaYCAC8APaYC" +
           "AAD/////AAAAAA==";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// A description for the Enabled Property.
        /// </summary>
        public PropertyState<bool> Enabled
        {
            get
            { 
                return m_enabled;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_enabled, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_enabled = value;
            }
        }

        /// <summary>
        /// A description for the DeviceReady Property.
        /// </summary>
        public PropertyState<bool> DeviceReady
        {
            get
            { 
                return m_deviceReady;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_deviceReady, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_deviceReady = value;
            }
        }

        /// <summary>
        /// A description for the LocalControl Property.
        /// </summary>
        public PropertyState<bool> LocalControl
        {
            get
            { 
                return m_localControl;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_localControl, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_localControl = value;
            }
        }

        /// <summary>
        /// A description for the WatchdogCounter Property.
        /// </summary>
        public PropertyState<uint> WatchdogCounter
        {
            get
            { 
                return m_watchdogCounter;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_watchdogCounter, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_watchdogCounter = value;
            }
        }

        /// <summary>
        /// A description for the ActiveLockId Property.
        /// </summary>
        public PropertyState<string> ActiveLockId
        {
            get
            { 
                return m_activeLockId;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_activeLockId, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_activeLockId = value;
            }
        }

        /// <summary>
        /// A description for the AssetInfo Object.
        /// </summary>
        public AssetInfoFolderState AssetInfo
        {
            get
            { 
                return m_assetInfo;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_assetInfo, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_assetInfo = value;
            }
        }

        /// <summary>
        /// A description for the Measurements Object.
        /// </summary>
        public FolderState Measurements
        {
            get
            { 
                return m_measurements;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_measurements, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_measurements = value;
            }
        }

        /// <summary>
        /// A description for the SetPoints Object.
        /// </summary>
        public FolderState SetPoints
        {
            get
            { 
                return m_setPoints;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_setPoints, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_setPoints = value;
            }
        }

        /// <summary>
        /// A description for the Limits Object.
        /// </summary>
        public FolderState Limits
        {
            get
            { 
                return m_limits;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_limits, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_limits = value;
            }
        }

        /// <summary>
        /// A description for the OperationalLimits Object.
        /// </summary>
        public FolderState OperationalLimits
        {
            get
            { 
                return m_operationalLimits;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_operationalLimits, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_operationalLimits = value;
            }
        }

        /// <summary>
        /// A description for the AccessRules Object.
        /// </summary>
        public FolderState AccessRules
        {
            get
            { 
                return m_accessRules;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_accessRules, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_accessRules = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_enabled != null)
            {
                children.Add(m_enabled);
            }

            if (m_deviceReady != null)
            {
                children.Add(m_deviceReady);
            }

            if (m_localControl != null)
            {
                children.Add(m_localControl);
            }

            if (m_watchdogCounter != null)
            {
                children.Add(m_watchdogCounter);
            }

            if (m_activeLockId != null)
            {
                children.Add(m_activeLockId);
            }

            if (m_assetInfo != null)
            {
                children.Add(m_assetInfo);
            }

            if (m_measurements != null)
            {
                children.Add(m_measurements);
            }

            if (m_setPoints != null)
            {
                children.Add(m_setPoints);
            }

            if (m_limits != null)
            {
                children.Add(m_limits);
            }

            if (m_operationalLimits != null)
            {
                children.Add(m_operationalLimits);
            }

            if (m_accessRules != null)
            {
                children.Add(m_accessRules);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case DsatsDemo.BrowseNames.Enabled:
                {
                    if (createOrReplace)
                    {
                        if (Enabled == null)
                        {
                            if (replacement == null)
                            {
                                Enabled = new PropertyState<bool>(this);
                            }
                            else
                            {
                                Enabled = (PropertyState<bool>)replacement;
                            }
                        }
                    }

                    instance = Enabled;
                    break;
                }

                case DsatsDemo.BrowseNames.DeviceReady:
                {
                    if (createOrReplace)
                    {
                        if (DeviceReady == null)
                        {
                            if (replacement == null)
                            {
                                DeviceReady = new PropertyState<bool>(this);
                            }
                            else
                            {
                                DeviceReady = (PropertyState<bool>)replacement;
                            }
                        }
                    }

                    instance = DeviceReady;
                    break;
                }

                case DsatsDemo.BrowseNames.LocalControl:
                {
                    if (createOrReplace)
                    {
                        if (LocalControl == null)
                        {
                            if (replacement == null)
                            {
                                LocalControl = new PropertyState<bool>(this);
                            }
                            else
                            {
                                LocalControl = (PropertyState<bool>)replacement;
                            }
                        }
                    }

                    instance = LocalControl;
                    break;
                }

                case DsatsDemo.BrowseNames.WatchdogCounter:
                {
                    if (createOrReplace)
                    {
                        if (WatchdogCounter == null)
                        {
                            if (replacement == null)
                            {
                                WatchdogCounter = new PropertyState<uint>(this);
                            }
                            else
                            {
                                WatchdogCounter = (PropertyState<uint>)replacement;
                            }
                        }
                    }

                    instance = WatchdogCounter;
                    break;
                }

                case DsatsDemo.BrowseNames.ActiveLockId:
                {
                    if (createOrReplace)
                    {
                        if (ActiveLockId == null)
                        {
                            if (replacement == null)
                            {
                                ActiveLockId = new PropertyState<string>(this);
                            }
                            else
                            {
                                ActiveLockId = (PropertyState<string>)replacement;
                            }
                        }
                    }

                    instance = ActiveLockId;
                    break;
                }

                case DsatsDemo.BrowseNames.AssetInfo:
                {
                    if (createOrReplace)
                    {
                        if (AssetInfo == null)
                        {
                            if (replacement == null)
                            {
                                AssetInfo = new AssetInfoFolderState(this);
                            }
                            else
                            {
                                AssetInfo = (AssetInfoFolderState)replacement;
                            }
                        }
                    }

                    instance = AssetInfo;
                    break;
                }

                case DsatsDemo.BrowseNames.Measurements:
                {
                    if (createOrReplace)
                    {
                        if (Measurements == null)
                        {
                            if (replacement == null)
                            {
                                Measurements = new FolderState(this);
                            }
                            else
                            {
                                Measurements = (FolderState)replacement;
                            }
                        }
                    }

                    instance = Measurements;
                    break;
                }

                case DsatsDemo.BrowseNames.SetPoints:
                {
                    if (createOrReplace)
                    {
                        if (SetPoints == null)
                        {
                            if (replacement == null)
                            {
                                SetPoints = new FolderState(this);
                            }
                            else
                            {
                                SetPoints = (FolderState)replacement;
                            }
                        }
                    }

                    instance = SetPoints;
                    break;
                }

                case DsatsDemo.BrowseNames.Limits:
                {
                    if (createOrReplace)
                    {
                        if (Limits == null)
                        {
                            if (replacement == null)
                            {
                                Limits = new FolderState(this);
                            }
                            else
                            {
                                Limits = (FolderState)replacement;
                            }
                        }
                    }

                    instance = Limits;
                    break;
                }

                case DsatsDemo.BrowseNames.OperationalLimits:
                {
                    if (createOrReplace)
                    {
                        if (OperationalLimits == null)
                        {
                            if (replacement == null)
                            {
                                OperationalLimits = new FolderState(this);
                            }
                            else
                            {
                                OperationalLimits = (FolderState)replacement;
                            }
                        }
                    }

                    instance = OperationalLimits;
                    break;
                }

                case DsatsDemo.BrowseNames.AccessRules:
                {
                    if (createOrReplace)
                    {
                        if (AccessRules == null)
                        {
                            if (replacement == null)
                            {
                                AccessRules = new FolderState(this);
                            }
                            else
                            {
                                AccessRules = (FolderState)replacement;
                            }
                        }
                    }

                    instance = AccessRules;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private PropertyState<bool> m_enabled;
        private PropertyState<bool> m_deviceReady;
        private PropertyState<bool> m_localControl;
        private PropertyState<uint> m_watchdogCounter;
        private PropertyState<string> m_activeLockId;
        private AssetInfoFolderState m_assetInfo;
        private FolderState m_measurements;
        private FolderState m_setPoints;
        private FolderState m_limits;
        private FolderState m_operationalLimits;
        private FolderState m_accessRules;
        #endregion
    }
    #endif
    #endregion

    #region AccessRuleState Class
    #if (!OPCUA_EXCLUDE_AccessRuleState)
    /// <summary>
    /// Stores an instance of the AccessRuleType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class AccessRuleState : BaseObjectState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public AccessRuleState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(DsatsDemo.ObjectTypes.AccessRuleType, DsatsDemo.Namespaces.DsatsDemo, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AQAAACIAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvRFNBVFNEZW1v/////wRggAABAAAAAQAWAAAA" +
           "QWNjZXNzUnVsZVR5cGVJbnN0YW5jZQEB9AABAfQA/////wAAAAA=";
        #endregion
        #endif
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        #endregion

        #region Private Fields
        #endregion
    }
    #endif
    #endregion

    #region TopDriveMeasurementsFolderState Class
    #if (!OPCUA_EXCLUDE_TopDriveMeasurementsFolderState)
    /// <summary>
    /// Stores an instance of the TopDriveMeasurementsFolderType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class TopDriveMeasurementsFolderState : FolderState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public TopDriveMeasurementsFolderState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(DsatsDemo.ObjectTypes.TopDriveMeasurementsFolderType, DsatsDemo.Namespaces.DsatsDemo, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AQAAACIAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvRFNBVFNEZW1v/////wRggAABAAAAAQAmAAAA" +
           "VG9wRHJpdmVNZWFzdXJlbWVudHNGb2xkZXJUeXBlSW5zdGFuY2UBAVABAQFQAf////8GAAAAFWCJCgIA" +
           "AAABAAMAAABSUE0BAVEBAC8BAEAJUQEAAAAK/////wEB/////wEAAAAVYIkKAgAAAAAABwAAAEVVUmFu" +
           "Z2UBAVQBAC4ARFQBAAABAHQD/////wEB/////wAAAAAVYIkKAgAAAAEABgAAAFRvcnF1ZQEBVwEALwEA" +
           "QAlXAQAAAAr/////AQH/////AQAAABVgiQoCAAAAAAAHAAAARVVSYW5nZQEBWgEALgBEWgEAAAEAdAP/" +
           "////AQH/////AAAAABVgiQoCAAAAAQAHAAAAQW1wZXJlcwEBXQEALwEAQAldAQAAAAr/////AQH/////" +
           "AQAAABVgiQoCAAAAAAAHAAAARVVSYW5nZQEBYAEALgBEYAEAAAEAdAP/////AQH/////AAAAABVgiQoC" +
           "AAAAAQALAAAAQnJha2VTdGF0dXMBAWMBAC8BAEUJYwEAAAAB/////wEB/////wIAAAAVYIkKAgAAAAAA" +
           "CgAAAEZhbHNlU3RhdGUBAWYBAC4ARGYBAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABUcnVl" +
           "U3RhdGUBAWcBAC4ARGcBAAAAFf////8BAf////8AAAAAFWCJCgIAAAABAAsAAABPcmllbnRhdGlvbgEB" +
           "aAEALwEAQAloAQAAAAr/////AQH/////AQAAABVgiQoCAAAAAAAHAAAARVVSYW5nZQEBawEALgBEawEA" +
           "AAEAdAP/////AQH/////AAAAABVgiQoCAAAAAQATAAAASXNSb3RhdGluZ0Nsb2Nrd2lzZQEBbgEALwEA" +
           "RQluAQAAAAH/////AQH/////AgAAABVgiQoCAAAAAAAKAAAARmFsc2VTdGF0ZQEBcQEALgBEcQEAAAAV" +
           "/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAFRydWVTdGF0ZQEBcgEALgBEcgEAAAAV/////wEB////" +
           "/wAAAAA=";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// A description for the RPM Variable.
        /// </summary>
        public AnalogItemState<float> RPM
        {
            get
            { 
                return m_rPM;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_rPM, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_rPM = value;
            }
        }

        /// <summary>
        /// A description for the Torque Variable.
        /// </summary>
        public AnalogItemState<float> Torque
        {
            get
            { 
                return m_torque;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_torque, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_torque = value;
            }
        }

        /// <summary>
        /// A description for the Amperes Variable.
        /// </summary>
        public AnalogItemState<float> Amperes
        {
            get
            { 
                return m_amperes;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_amperes, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_amperes = value;
            }
        }

        /// <summary>
        /// A description for the BrakeStatus Variable.
        /// </summary>
        public TwoStateDiscreteState BrakeStatus
        {
            get
            { 
                return m_brakeStatus;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_brakeStatus, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_brakeStatus = value;
            }
        }

        /// <summary>
        /// A description for the Orientation Variable.
        /// </summary>
        public AnalogItemState<float> Orientation
        {
            get
            { 
                return m_orientation;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_orientation, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_orientation = value;
            }
        }

        /// <summary>
        /// A description for the IsRotatingClockwise Variable.
        /// </summary>
        public TwoStateDiscreteState IsRotatingClockwise
        {
            get
            { 
                return m_isRotatingClockwise;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_isRotatingClockwise, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_isRotatingClockwise = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_rPM != null)
            {
                children.Add(m_rPM);
            }

            if (m_torque != null)
            {
                children.Add(m_torque);
            }

            if (m_amperes != null)
            {
                children.Add(m_amperes);
            }

            if (m_brakeStatus != null)
            {
                children.Add(m_brakeStatus);
            }

            if (m_orientation != null)
            {
                children.Add(m_orientation);
            }

            if (m_isRotatingClockwise != null)
            {
                children.Add(m_isRotatingClockwise);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case DsatsDemo.BrowseNames.RPM:
                {
                    if (createOrReplace)
                    {
                        if (RPM == null)
                        {
                            if (replacement == null)
                            {
                                RPM = new AnalogItemState<float>(this);
                            }
                            else
                            {
                                RPM = (AnalogItemState<float>)replacement;
                            }
                        }
                    }

                    instance = RPM;
                    break;
                }

                case DsatsDemo.BrowseNames.Torque:
                {
                    if (createOrReplace)
                    {
                        if (Torque == null)
                        {
                            if (replacement == null)
                            {
                                Torque = new AnalogItemState<float>(this);
                            }
                            else
                            {
                                Torque = (AnalogItemState<float>)replacement;
                            }
                        }
                    }

                    instance = Torque;
                    break;
                }

                case DsatsDemo.BrowseNames.Amperes:
                {
                    if (createOrReplace)
                    {
                        if (Amperes == null)
                        {
                            if (replacement == null)
                            {
                                Amperes = new AnalogItemState<float>(this);
                            }
                            else
                            {
                                Amperes = (AnalogItemState<float>)replacement;
                            }
                        }
                    }

                    instance = Amperes;
                    break;
                }

                case DsatsDemo.BrowseNames.BrakeStatus:
                {
                    if (createOrReplace)
                    {
                        if (BrakeStatus == null)
                        {
                            if (replacement == null)
                            {
                                BrakeStatus = new TwoStateDiscreteState(this);
                            }
                            else
                            {
                                BrakeStatus = (TwoStateDiscreteState)replacement;
                            }
                        }
                    }

                    instance = BrakeStatus;
                    break;
                }

                case DsatsDemo.BrowseNames.Orientation:
                {
                    if (createOrReplace)
                    {
                        if (Orientation == null)
                        {
                            if (replacement == null)
                            {
                                Orientation = new AnalogItemState<float>(this);
                            }
                            else
                            {
                                Orientation = (AnalogItemState<float>)replacement;
                            }
                        }
                    }

                    instance = Orientation;
                    break;
                }

                case DsatsDemo.BrowseNames.IsRotatingClockwise:
                {
                    if (createOrReplace)
                    {
                        if (IsRotatingClockwise == null)
                        {
                            if (replacement == null)
                            {
                                IsRotatingClockwise = new TwoStateDiscreteState(this);
                            }
                            else
                            {
                                IsRotatingClockwise = (TwoStateDiscreteState)replacement;
                            }
                        }
                    }

                    instance = IsRotatingClockwise;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private AnalogItemState<float> m_rPM;
        private AnalogItemState<float> m_torque;
        private AnalogItemState<float> m_amperes;
        private TwoStateDiscreteState m_brakeStatus;
        private AnalogItemState<float> m_orientation;
        private TwoStateDiscreteState m_isRotatingClockwise;
        #endregion
    }
    #endif
    #endregion

    #region TopDriveSetPointsFolderState Class
    #if (!OPCUA_EXCLUDE_TopDriveSetPointsFolderState)
    /// <summary>
    /// Stores an instance of the TopDriveSetPointsFolderType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class TopDriveSetPointsFolderState : FolderState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public TopDriveSetPointsFolderState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(DsatsDemo.ObjectTypes.TopDriveSetPointsFolderType, DsatsDemo.Namespaces.DsatsDemo, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AQAAACIAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvRFNBVFNEZW1v/////wRggAABAAAAAQAjAAAA" +
           "VG9wRHJpdmVTZXRQb2ludHNGb2xkZXJUeXBlSW5zdGFuY2UBAXMBAQFzAf////8CAAAAFWCJCgIAAAAB" +
           "AAMAAABSUE0BAXQBAC8BAEAJdAEAAAAK/////wMD/////wEAAAAVYIkKAgAAAAAABwAAAEVVUmFuZ2UB" +
           "AXcBAC4ARHcBAAABAHQD/////wEB/////wAAAAAVYIkKAgAAAAEABgAAAFRvcnF1ZQEBzAIALwEAQAnM" +
           "AgAAAAr/////AwP/////AQAAABVgiQoCAAAAAAAHAAAARVVSYW5nZQEBzwIALgBEzwIAAAEAdAP/////" +
           "AQH/////AAAAAA==";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// A description for the RPM Variable.
        /// </summary>
        public AnalogItemState<float> RPM
        {
            get
            { 
                return m_rPM;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_rPM, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_rPM = value;
            }
        }

        /// <summary>
        /// A description for the Torque Variable.
        /// </summary>
        public AnalogItemState<float> Torque
        {
            get
            { 
                return m_torque;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_torque, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_torque = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_rPM != null)
            {
                children.Add(m_rPM);
            }

            if (m_torque != null)
            {
                children.Add(m_torque);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case DsatsDemo.BrowseNames.RPM:
                {
                    if (createOrReplace)
                    {
                        if (RPM == null)
                        {
                            if (replacement == null)
                            {
                                RPM = new AnalogItemState<float>(this);
                            }
                            else
                            {
                                RPM = (AnalogItemState<float>)replacement;
                            }
                        }
                    }

                    instance = RPM;
                    break;
                }

                case DsatsDemo.BrowseNames.Torque:
                {
                    if (createOrReplace)
                    {
                        if (Torque == null)
                        {
                            if (replacement == null)
                            {
                                Torque = new AnalogItemState<float>(this);
                            }
                            else
                            {
                                Torque = (AnalogItemState<float>)replacement;
                            }
                        }
                    }

                    instance = Torque;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private AnalogItemState<float> m_rPM;
        private AnalogItemState<float> m_torque;
        #endregion
    }
    #endif
    #endregion

    #region TopDriveOperationalLimitsFolderState Class
    #if (!OPCUA_EXCLUDE_TopDriveOperationalLimitsFolderState)
    /// <summary>
    /// Stores an instance of the TopDriveOperationalLimitsFolderType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class TopDriveOperationalLimitsFolderState : FolderState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public TopDriveOperationalLimitsFolderState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(DsatsDemo.ObjectTypes.TopDriveOperationalLimitsFolderType, DsatsDemo.Namespaces.DsatsDemo, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AQAAACIAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvRFNBVFNEZW1v/////wRggAABAAAAAQArAAAA" +
           "VG9wRHJpdmVPcGVyYXRpb25hbExpbWl0c0ZvbGRlclR5cGVJbnN0YW5jZQEB+wIBAfsC/////wQAAAAV" +
           "YIkKAgAAAAEABgAAAE1heFJQTQEB/AIALwEAQAn8AgAAAAr/////AQH/////AQAAABVgiQoCAAAAAAAH" +
           "AAAARVVSYW5nZQEB/wIALgBE/wIAAAEAdAP/////AQH/////AAAAABVgiQoCAAAAAQAGAAAATWluUlBN" +
           "AQECAwAvAQBACQIDAAAACv////8BAf////8BAAAAFWCJCgIAAAAAAAcAAABFVVJhbmdlAQEFAwAuAEQF" +
           "AwAAAQB0A/////8BAf////8AAAAAFWCJCgIAAAABAAkAAABNYXhUb3JxdWUBAQgDAC8BAEAJCAMAAAAK" +
           "/////wEB/////wEAAAAVYIkKAgAAAAAABwAAAEVVUmFuZ2UBAQsDAC4ARAsDAAABAHQD/////wEB////" +
           "/wAAAAAVYIkKAgAAAAEACQAAAE1pblRvcnF1ZQEBDgMALwEAQAkOAwAAAAr/////AQH/////AQAAABVg" +
           "iQoCAAAAAAAHAAAARVVSYW5nZQEBEQMALgBEEQMAAAEAdAP/////AQH/////AAAAAA==";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// A description for the MaxRPM Variable.
        /// </summary>
        public AnalogItemState<float> MaxRPM
        {
            get
            { 
                return m_maxRPM;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_maxRPM, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_maxRPM = value;
            }
        }

        /// <summary>
        /// A description for the MinRPM Variable.
        /// </summary>
        public AnalogItemState<float> MinRPM
        {
            get
            { 
                return m_minRPM;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_minRPM, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_minRPM = value;
            }
        }

        /// <summary>
        /// A description for the MaxTorque Variable.
        /// </summary>
        public AnalogItemState<float> MaxTorque
        {
            get
            { 
                return m_maxTorque;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_maxTorque, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_maxTorque = value;
            }
        }

        /// <summary>
        /// A description for the MinTorque Variable.
        /// </summary>
        public AnalogItemState<float> MinTorque
        {
            get
            { 
                return m_minTorque;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_minTorque, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_minTorque = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_maxRPM != null)
            {
                children.Add(m_maxRPM);
            }

            if (m_minRPM != null)
            {
                children.Add(m_minRPM);
            }

            if (m_maxTorque != null)
            {
                children.Add(m_maxTorque);
            }

            if (m_minTorque != null)
            {
                children.Add(m_minTorque);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case DsatsDemo.BrowseNames.MaxRPM:
                {
                    if (createOrReplace)
                    {
                        if (MaxRPM == null)
                        {
                            if (replacement == null)
                            {
                                MaxRPM = new AnalogItemState<float>(this);
                            }
                            else
                            {
                                MaxRPM = (AnalogItemState<float>)replacement;
                            }
                        }
                    }

                    instance = MaxRPM;
                    break;
                }

                case DsatsDemo.BrowseNames.MinRPM:
                {
                    if (createOrReplace)
                    {
                        if (MinRPM == null)
                        {
                            if (replacement == null)
                            {
                                MinRPM = new AnalogItemState<float>(this);
                            }
                            else
                            {
                                MinRPM = (AnalogItemState<float>)replacement;
                            }
                        }
                    }

                    instance = MinRPM;
                    break;
                }

                case DsatsDemo.BrowseNames.MaxTorque:
                {
                    if (createOrReplace)
                    {
                        if (MaxTorque == null)
                        {
                            if (replacement == null)
                            {
                                MaxTorque = new AnalogItemState<float>(this);
                            }
                            else
                            {
                                MaxTorque = (AnalogItemState<float>)replacement;
                            }
                        }
                    }

                    instance = MaxTorque;
                    break;
                }

                case DsatsDemo.BrowseNames.MinTorque:
                {
                    if (createOrReplace)
                    {
                        if (MinTorque == null)
                        {
                            if (replacement == null)
                            {
                                MinTorque = new AnalogItemState<float>(this);
                            }
                            else
                            {
                                MinTorque = (AnalogItemState<float>)replacement;
                            }
                        }
                    }

                    instance = MinTorque;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private AnalogItemState<float> m_maxRPM;
        private AnalogItemState<float> m_minRPM;
        private AnalogItemState<float> m_maxTorque;
        private AnalogItemState<float> m_minTorque;
        #endregion
    }
    #endif
    #endregion

    #region TopDriveState Class
    #if (!OPCUA_EXCLUDE_TopDriveState)
    /// <summary>
    /// Stores an instance of the TopDriveType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class TopDriveState : ToolState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public TopDriveState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(DsatsDemo.ObjectTypes.TopDriveType, DsatsDemo.Namespaces.DsatsDemo, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AQAAACIAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvRFNBVFNEZW1v/////wRggAABAAAAAQAUAAAA" +
           "VG9wRHJpdmVUeXBlSW5zdGFuY2UBAdkAAQHZAP////8LAAAAFWCJCgIAAAABAAcAAABFbmFibGVkAQEw" +
           "AgAuAEQwAgAAAAH/////AQH/////AAAAABVgiQoCAAAAAQALAAAARGV2aWNlUmVhZHkBARQDAC4ARBQD" +
           "AAAAAf////8BAf////8AAAAAFWCJCgIAAAABAAwAAABMb2NhbENvbnRyb2wBARUDAC4ARBUDAAAAAf//" +
           "//8BAf////8AAAAAFWCJCgIAAAABAA8AAABXYXRjaGRvZ0NvdW50ZXIBAcMCAC4ARMMCAAAAB/////8D" +
           "A/////8AAAAAFWCJCgIAAAABAAwAAABBY3RpdmVMb2NrSWQBAcgCAC4ARMgCAAAADP////8DA/////8A" +
           "AAAABGCACgEAAAABAAkAAABBc3NldEluZm8BAYkBAC8BAUgBiQEAAP////8DAAAAFWCJCgIAAAABAAwA" +
           "AABNYW51ZmFjdHVyZXIBAYoBAC4ARIoBAAAADP////8BAf////8AAAAAFWCJCgIAAAABAAsAAABNb2Rl" +
           "bE51bWJlcgEBiwEALgBEiwEAAAAM/////wEB/////wAAAAAVYIkKAgAAAAEADAAAAFNlcmlhbE51bWJl" +
           "cgEBjAEALgBEjAEAAAAM/////wEB/////wAAAAAEYIAKAQAAAAEADAAAAE1lYXN1cmVtZW50cwEB9QAA" +
           "LwEBUAH1AAAA/////wYAAAAVYIkKAgAAAAEAAwAAAFJQTQEB+QAALwEAQAn5AAAAAAr/////AQH/////" +
           "AQAAABVgiQoCAAAAAAAHAAAARVVSYW5nZQEBjwEALgBEjwEAAAEAdAP/////AQH/////AAAAABVgiQoC" +
           "AAAAAQAGAAAAVG9ycXVlAQH6AAAvAQBACfoAAAAACv////8BAf////8BAAAAFWCJCgIAAAAAAAcAAABF" +
           "VVJhbmdlAQGUAQAuAESUAQAAAQB0A/////8BAf////8AAAAAFWCJCgIAAAABAAcAAABBbXBlcmVzAQH7" +
           "AAAvAQBACfsAAAAACv////8BAf////8BAAAAFWCJCgIAAAAAAAcAAABFVVJhbmdlAQGZAQAuAESZAQAA" +
           "AQB0A/////8BAf////8AAAAAFWCJCgIAAAABAAsAAABCcmFrZVN0YXR1cwEB/AAALwEARQn8AAAAAAH/" +
           "////AQH/////AgAAABVgiQoCAAAAAAAKAAAARmFsc2VTdGF0ZQEBngEALgBEngEAAAAV/////wEB////" +
           "/wAAAAAVYIkKAgAAAAAACQAAAFRydWVTdGF0ZQEBnwEALgBEnwEAAAAV/////wEB/////wAAAAAVYIkK" +
           "AgAAAAEACwAAAE9yaWVudGF0aW9uAQH9AAAvAQBACf0AAAAACv////8BAf////8BAAAAFWCJCgIAAAAA" +
           "AAcAAABFVVJhbmdlAQGiAQAuAESiAQAAAQB0A/////8BAf////8AAAAAFWCJCgIAAAABABMAAABJc1Jv" +
           "dGF0aW5nQ2xvY2t3aXNlAQGlAQAvAQBFCaUBAAAAAf////8BAf////8CAAAAFWCJCgIAAAAAAAoAAABG" +
           "YWxzZVN0YXRlAQGoAQAuAESoAQAAABX/////AQH/////AAAAABVgiQoCAAAAAAAJAAAAVHJ1ZVN0YXRl" +
           "AQGpAQAuAESpAQAAABX/////AQH/////AAAAAARggAoBAAAAAQAJAAAAU2V0UG9pbnRzAQH3AAAvAQFz" +
           "AfcAAAD/////AgAAABVgiQoCAAAAAQADAAAAUlBNAQGqAQAvAQBACaoBAAAACv////8DA/////8BAAAA" +
           "FWCJCgIAAAAAAAcAAABFVVJhbmdlAQGtAQAuAEStAQAAAQB0A/////8BAf////8AAAAAFWCJCgIAAAAB" +
           "AAYAAABUb3JxdWUBAdICAC8BAEAJ0gIAAAAK/////wMD/////wEAAAAVYIkKAgAAAAAABwAAAEVVUmFu" +
           "Z2UBAdUCAC4ARNUCAAABAHQD/////wEB/////wAAAAAEYIAKAQAAAAEABgAAAExpbWl0cwEB9gAALwA9" +
           "9gAAAP////8AAAAABGCACgEAAAABABEAAABPcGVyYXRpb25hbExpbWl0cwEBFgMALwEB+wIWAwAA////" +
           "/wQAAAAVYIkKAgAAAAEABgAAAE1heFJQTQEBFwMALwEAQAkXAwAAAAr/////AQH/////AQAAABVgiQoC" +
           "AAAAAAAHAAAARVVSYW5nZQEBGgMALgBEGgMAAAEAdAP/////AQH/////AAAAABVgiQoCAAAAAQAGAAAA" +
           "TWluUlBNAQEdAwAvAQBACR0DAAAACv////8BAf////8BAAAAFWCJCgIAAAAAAAcAAABFVVJhbmdlAQEg" +
           "AwAuAEQgAwAAAQB0A/////8BAf////8AAAAAFWCJCgIAAAABAAkAAABNYXhUb3JxdWUBASMDAC8BAEAJ" +
           "IwMAAAAK/////wEB/////wEAAAAVYIkKAgAAAAAABwAAAEVVUmFuZ2UBASYDAC4ARCYDAAABAHQD////" +
           "/wEB/////wAAAAAVYIkKAgAAAAEACQAAAE1pblRvcnF1ZQEBKQMALwEAQAkpAwAAAAr/////AQH/////" +
           "AQAAABVgiQoCAAAAAAAHAAAARVVSYW5nZQEBLAMALgBELAMAAAEAdAP/////AQH/////AAAAAARggAoB" +
           "AAAAAQALAAAAQWNjZXNzUnVsZXMBAfgAAC8APfgAAAD/////AAAAAA==";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// A description for the Measurements Object.
        /// </summary>
        public new TopDriveMeasurementsFolderState Measurements
        {
            get { return (TopDriveMeasurementsFolderState)base.Measurements; }
            set { base.Measurements = value; }
        }

        /// <summary>
        /// A description for the SetPoints Object.
        /// </summary>
        public new TopDriveSetPointsFolderState SetPoints
        {
            get { return (TopDriveSetPointsFolderState)base.SetPoints; }
            set { base.SetPoints = value; }
        }

        /// <summary>
        /// A description for the OperationalLimits Object.
        /// </summary>
        public new TopDriveOperationalLimitsFolderState OperationalLimits
        {
            get { return (TopDriveOperationalLimitsFolderState)base.OperationalLimits; }
            set { base.OperationalLimits = value; }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case DsatsDemo.BrowseNames.Measurements:
                {
                    if (createOrReplace)
                    {
                        if (Measurements == null)
                        {
                            if (replacement == null)
                            {
                                Measurements = new TopDriveMeasurementsFolderState(this);
                            }
                            else
                            {
                                Measurements = (TopDriveMeasurementsFolderState)replacement;
                            }
                        }
                    }

                    instance = Measurements;
                    break;
                }

                case DsatsDemo.BrowseNames.SetPoints:
                {
                    if (createOrReplace)
                    {
                        if (SetPoints == null)
                        {
                            if (replacement == null)
                            {
                                SetPoints = new TopDriveSetPointsFolderState(this);
                            }
                            else
                            {
                                SetPoints = (TopDriveSetPointsFolderState)replacement;
                            }
                        }
                    }

                    instance = SetPoints;
                    break;
                }

                case DsatsDemo.BrowseNames.OperationalLimits:
                {
                    if (createOrReplace)
                    {
                        if (OperationalLimits == null)
                        {
                            if (replacement == null)
                            {
                                OperationalLimits = new TopDriveOperationalLimitsFolderState(this);
                            }
                            else
                            {
                                OperationalLimits = (TopDriveOperationalLimitsFolderState)replacement;
                            }
                        }
                    }

                    instance = OperationalLimits;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        #endregion
    }
    #endif
    #endregion

    #region MudPumpMeasurementsFolderState Class
    #if (!OPCUA_EXCLUDE_MudPumpMeasurementsFolderState)
    /// <summary>
    /// Stores an instance of the MudPumpMeasurementsFolderType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class MudPumpMeasurementsFolderState : FolderState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public MudPumpMeasurementsFolderState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(DsatsDemo.ObjectTypes.MudPumpMeasurementsFolderType, DsatsDemo.Namespaces.DsatsDemo, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AQAAACIAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvRFNBVFNEZW1v/////wRggAABAAAAAQAlAAAA" +
           "TXVkUHVtcE1lYXN1cmVtZW50c0ZvbGRlclR5cGVJbnN0YW5jZQEBpwIBAacC/////wEAAAAVYIkKAgAA" +
           "AAEAAwAAAFNQTQEBqAIALwEAQAmoAgAAAAv/////AQH/////AQAAABVgiQoCAAAAAAAHAAAARVVSYW5n" +
           "ZQEBqwIALgBEqwIAAAEAdAP/////AQH/////AAAAAA==";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// A description for the SPM Variable.
        /// </summary>
        public AnalogItemState<double> SPM
        {
            get
            { 
                return m_sPM;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_sPM, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_sPM = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_sPM != null)
            {
                children.Add(m_sPM);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case DsatsDemo.BrowseNames.SPM:
                {
                    if (createOrReplace)
                    {
                        if (SPM == null)
                        {
                            if (replacement == null)
                            {
                                SPM = new AnalogItemState<double>(this);
                            }
                            else
                            {
                                SPM = (AnalogItemState<double>)replacement;
                            }
                        }
                    }

                    instance = SPM;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private AnalogItemState<double> m_sPM;
        #endregion
    }
    #endif
    #endregion

    #region MudPumpSetPointsFolderState Class
    #if (!OPCUA_EXCLUDE_MudPumpSetPointsFolderState)
    /// <summary>
    /// Stores an instance of the MudPumpSetPointsFolderType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class MudPumpSetPointsFolderState : FolderState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public MudPumpSetPointsFolderState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(DsatsDemo.ObjectTypes.MudPumpSetPointsFolderType, DsatsDemo.Namespaces.DsatsDemo, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AQAAACIAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvRFNBVFNEZW1v/////wRggAABAAAAAQAiAAAA" +
           "TXVkUHVtcFNldFBvaW50c0ZvbGRlclR5cGVJbnN0YW5jZQEBtQIBAbUC/////wEAAAAVYIkKAgAAAAEA" +
           "AwAAAFNQTQEBtgIALwEAQAm2AgAAAAv/////AwP/////AQAAABVgiQoCAAAAAAAHAAAARVVSYW5nZQEB" +
           "uQIALgBEuQIAAAEAdAP/////AQH/////AAAAAA==";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// A description for the SPM Variable.
        /// </summary>
        public AnalogItemState<double> SPM
        {
            get
            { 
                return m_sPM;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_sPM, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_sPM = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_sPM != null)
            {
                children.Add(m_sPM);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case DsatsDemo.BrowseNames.SPM:
                {
                    if (createOrReplace)
                    {
                        if (SPM == null)
                        {
                            if (replacement == null)
                            {
                                SPM = new AnalogItemState<double>(this);
                            }
                            else
                            {
                                SPM = (AnalogItemState<double>)replacement;
                            }
                        }
                    }

                    instance = SPM;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private AnalogItemState<double> m_sPM;
        #endregion
    }
    #endif
    #endregion

    #region MudPumpState Class
    #if (!OPCUA_EXCLUDE_MudPumpState)
    /// <summary>
    /// Stores an instance of the MudPumpType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class MudPumpState : ToolState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public MudPumpState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(DsatsDemo.ObjectTypes.MudPumpType, DsatsDemo.Namespaces.DsatsDemo, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AQAAACIAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvRFNBVFNEZW1v/////wRggAABAAAAAQATAAAA" +
           "TXVkUHVtcFR5cGVJbnN0YW5jZQEBAwEBAQMB/////wsAAAAVYIkKAgAAAAEABwAAAEVuYWJsZWQBATEC" +
           "AC4ARDECAAAAAf////8BAf////8AAAAAFWCJCgIAAAABAAsAAABEZXZpY2VSZWFkeQEBLwMALgBELwMA" +
           "AAAB/////wEB/////wAAAAAVYIkKAgAAAAEADAAAAExvY2FsQ29udHJvbAEBMAMALgBEMAMAAAAB////" +
           "/wEB/////wAAAAAVYIkKAgAAAAEADwAAAFdhdGNoZG9nQ291bnRlcgEBxAIALgBExAIAAAAH/////wMD" +
           "/////wAAAAAVYIkKAgAAAAEADAAAAEFjdGl2ZUxvY2tJZAEByQIALgBEyQIAAAAM/////wMD/////wAA" +
           "AAAEYIAKAQAAAAEACQAAAEFzc2V0SW5mbwEBugEALwEBSAG6AQAA/////wMAAAAVYIkKAgAAAAEADAAA" +
           "AE1hbnVmYWN0dXJlcgEBuwEALgBEuwEAAAAM/////wEB/////wAAAAAVYIkKAgAAAAEACwAAAE1vZGVs" +
           "TnVtYmVyAQG8AQAuAES8AQAAAAz/////AQH/////AAAAABVgiQoCAAAAAQAMAAAAU2VyaWFsTnVtYmVy" +
           "AQG9AQAuAES9AQAAAAz/////AQH/////AAAAAARggAoBAAAAAQAMAAAATWVhc3VyZW1lbnRzAQEHAQAv" +
           "AQGnAgcBAAD/////AQAAABVgiQoCAAAAAQADAAAAU1BNAQGuAgAvAQBACa4CAAAAC/////8BAf////8B" +
           "AAAAFWCJCgIAAAAAAAcAAABFVVJhbmdlAQGxAgAuAESxAgAAAQB0A/////8BAf////8AAAAABGCACgEA" +
           "AAABAAkAAABTZXRQb2ludHMBAQkBAC8BAbUCCQEAAP////8BAAAAFWCJCgIAAAABAAMAAABTUE0BAbwC" +
           "AC8BAEAJvAIAAAAL/////wMD/////wEAAAAVYIkKAgAAAAAABwAAAEVVUmFuZ2UBAb8CAC4ARL8CAAAB" +
           "AHQD/////wEB/////wAAAAAEYIAKAQAAAAEABgAAAExpbWl0cwEBCAEALwA9CAEAAP////8AAAAABGCA" +
           "CgEAAAABABEAAABPcGVyYXRpb25hbExpbWl0cwEBMQMALwA9MQMAAP////8AAAAABGCACgEAAAABAAsA" +
           "AABBY2Nlc3NSdWxlcwEBCgEALwA9CgEAAP////8AAAAA";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// A description for the Measurements Object.
        /// </summary>
        public new MudPumpMeasurementsFolderState Measurements
        {
            get { return (MudPumpMeasurementsFolderState)base.Measurements; }
            set { base.Measurements = value; }
        }

        /// <summary>
        /// A description for the SetPoints Object.
        /// </summary>
        public new MudPumpSetPointsFolderState SetPoints
        {
            get { return (MudPumpSetPointsFolderState)base.SetPoints; }
            set { base.SetPoints = value; }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case DsatsDemo.BrowseNames.Measurements:
                {
                    if (createOrReplace)
                    {
                        if (Measurements == null)
                        {
                            if (replacement == null)
                            {
                                Measurements = new MudPumpMeasurementsFolderState(this);
                            }
                            else
                            {
                                Measurements = (MudPumpMeasurementsFolderState)replacement;
                            }
                        }
                    }

                    instance = Measurements;
                    break;
                }

                case DsatsDemo.BrowseNames.SetPoints:
                {
                    if (createOrReplace)
                    {
                        if (SetPoints == null)
                        {
                            if (replacement == null)
                            {
                                SetPoints = new MudPumpSetPointsFolderState(this);
                            }
                            else
                            {
                                SetPoints = (MudPumpSetPointsFolderState)replacement;
                            }
                        }
                    }

                    instance = SetPoints;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        #endregion
    }
    #endif
    #endregion

    #region ChangePhaseMethodState Class
    #if (!OPCUA_EXCLUDE_ChangePhaseMethodState)
    /// <summary>
    /// Stores an instance of the ChangePhaseMethodType Method.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class ChangePhaseMethodState : MethodState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public ChangePhaseMethodState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Constructs an instance of a node.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <returns>The new node.</returns>
        public new static NodeState Construct(NodeState parent)
        {
            return new ChangePhaseMethodState(parent);
        }
        
        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AQAAACIAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvRFNBVFNEZW1v/////wRhggoEAAAAAQAVAAAA" +
           "Q2hhbmdlUGhhc2VNZXRob2RUeXBlAQE0AgAvAQE0AjQCAAABAf////8BAAAAFWCpCgIAAAAAAA4AAABJ" +
           "bnB1dEFyZ3VtZW50cwEBNQIALgBENQIAAJYBAAAAAQAqAQE9AAAABwAAAFBoYXNlSWQAEf////8AAAAA" +
           "AwAAAAAfAAAAVGhlIE5vZGVJZCBvZiB0aGUgdGFyZ2V0IFBoYXNlLgEAKAEBAAAAAQH/////AAAAAA==";
        #endregion
        #endif
        #endregion
        
        #region Event Callbacks
        /// <summary>
        /// Raised when the the method is called.
        /// </summary>
        public ChangePhaseMethodStateMethodCallHandler OnCall;
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Invokes the method, returns the result and output argument.
        /// </summary>
        /// <param name="context">The current context.</param>
        /// <param name="objectId">The id of the object.</param>
        /// <param name="inputArguments">The input arguments which have been already validated.</param>
        /// <param name="outputArguments">The output arguments which have initialized with thier default values.</param>
        /// <returns></returns>
        protected override ServiceResult Call(
            ISystemContext context,
            NodeId objectId,
            IList<object> inputArguments,
            IList<object> outputArguments)
        {
            if (OnCall == null)
            {
                return base.Call(context, objectId, inputArguments, outputArguments);
            }

            ServiceResult result = null;
            
            NodeId phaseId = (NodeId)inputArguments[0];

            if (OnCall != null)
            {
                result = OnCall(
                    context,
                    this,
                    objectId,
                    phaseId);
            }

            return result;
        }
        #endregion

        #region Private Fields
        #endregion
    }

    /// <summary>
    /// Used to receive notifications when the method is called.
    /// </summary>
    /// <exclude />
    public delegate ServiceResult ChangePhaseMethodStateMethodCallHandler(
        ISystemContext context,
        MethodState method,
        NodeId objectId,
        NodeId phaseId);
    #endif
    #endregion

    #region RigState Class
    #if (!OPCUA_EXCLUDE_RigState)
    /// <summary>
    /// Stores an instance of the RigType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class RigState : BaseObjectState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public RigState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(DsatsDemo.ObjectTypes.RigType, DsatsDemo.Namespaces.DsatsDemo, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AQAAACIAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvRFNBVFNEZW1v/////wRggAABAAAAAQAPAAAA" +
           "UmlnVHlwZUluc3RhbmNlAQHJAAEByQACAAAAADAAAQHKAAAwAAEBKAIHAAAABGGCCgQAAAABAAsAAABD" +
           "aGFuZ2VQaGFzZQEBNgIALwEBNgI2AgAAAQH/////AQAAABVgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVu" +
           "dHMBATcCAC4ARDcCAACWAQAAAAEAKgEBPQAAAAcAAABQaGFzZUlkABH/////AAAAAAMAAAAAHwAAAFRo" +
           "ZSBOb2RlSWQgb2YgdGhlIHRhcmdldCBQaGFzZS4BACgBAQAAAAEB/////wAAAAAVYIkKAgAAAAEAFQAA" +
           "AENoYW5nZVBoYXNlV2l0aFN0cmluZwEBbQMALgBEbQMAAAAM/////wMD/////wAAAAAVYIkKAgAAAAEA" +
           "DAAAAEN1cnJlbnRQaGFzZQEBGgEALwA/GgEAAAAR/////wEB/////wAAAAAEYIAKAQAAAAEABgAAAFBo" +
           "YXNlcwEBygAALwA9ygAAAAEAAAAAMAEBAckAAAAAAARggAoBAAAAAQAFAAAATG9ja3MBASgCAC8APSgC" +
           "AAABAAAAADABAQHJAAAAAAAEYIAKAQAAAAEACAAAAFRvcERyaXZlAQHgAAAvAQHZAOAAAAD/////CwAA" +
           "ABVgiQoCAAAAAQAHAAAARW5hYmxlZAEBMgIALgBEMgIAAAAB/////wEB/////wAAAAAVYIkKAgAAAAEA" +
           "CwAAAERldmljZVJlYWR5AQEyAwAuAEQyAwAAAAH/////AQH/////AAAAABVgiQoCAAAAAQAMAAAATG9j" +
           "YWxDb250cm9sAQEzAwAuAEQzAwAAAAH/////AQH/////AAAAABVgiQoCAAAAAQAPAAAAV2F0Y2hkb2dD" +
           "b3VudGVyAQHFAgAuAETFAgAAAAf/////AwP/////AAAAABVgiQoCAAAAAQAMAAAAQWN0aXZlTG9ja0lk" +
           "AQHKAgAuAETKAgAAAAz/////AwP/////AAAAAARggAoBAAAAAQAJAAAAQXNzZXRJbmZvAQG+AQAvAQFI" +
           "Ab4BAAD/////AwAAABVgiQoCAAAAAQAMAAAATWFudWZhY3R1cmVyAQG/AQAuAES/AQAAAAz/////AQH/" +
           "////AAAAABVgiQoCAAAAAQALAAAATW9kZWxOdW1iZXIBAcABAC4ARMABAAAADP////8BAf////8AAAAA" +
           "FWCJCgIAAAABAAwAAABTZXJpYWxOdW1iZXIBAcEBAC4ARMEBAAAADP////8BAf////8AAAAABGCACgEA" +
           "AAABAAwAAABNZWFzdXJlbWVudHMBAQsBAC8BAVABCwEAAP////8GAAAAFWCJCgIAAAABAAMAAABSUE0B" +
           "AQ8BAC8BAEAJDwEAAAAK/////wEB/////wEAAAAVYIkKAgAAAAAABwAAAEVVUmFuZ2UBAcQBAC4ARMQB" +
           "AAABAHQD/////wEB/////wAAAAAVYIkKAgAAAAEABgAAAFRvcnF1ZQEBEAEALwEAQAkQAQAAAAr/////" +
           "AQH/////AQAAABVgiQoCAAAAAAAHAAAARVVSYW5nZQEByQEALgBEyQEAAAEAdAP/////AQH/////AAAA" +
           "ABVgiQoCAAAAAQAHAAAAQW1wZXJlcwEBEQEALwEAQAkRAQAAAAr/////AQH/////AQAAABVgiQoCAAAA" +
           "AAAHAAAARVVSYW5nZQEBzgEALgBEzgEAAAEAdAP/////AQH/////AAAAABVgiQoCAAAAAQALAAAAQnJh" +
           "a2VTdGF0dXMBARIBAC8BAEUJEgEAAAAB/////wEB/////wIAAAAVYIkKAgAAAAAACgAAAEZhbHNlU3Rh" +
           "dGUBAdMBAC4ARNMBAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABUcnVlU3RhdGUBAdQBAC4A" +
           "RNQBAAAAFf////8BAf////8AAAAAFWCJCgIAAAABAAsAAABPcmllbnRhdGlvbgEBEwEALwEAQAkTAQAA" +
           "AAr/////AQH/////AQAAABVgiQoCAAAAAAAHAAAARVVSYW5nZQEB1wEALgBE1wEAAAEAdAP/////AQH/" +
           "////AAAAABVgiQoCAAAAAQATAAAASXNSb3RhdGluZ0Nsb2Nrd2lzZQEB2gEALwEARQnaAQAAAAH/////" +
           "AQH/////AgAAABVgiQoCAAAAAAAKAAAARmFsc2VTdGF0ZQEB3QEALgBE3QEAAAAV/////wEB/////wAA" +
           "AAAVYIkKAgAAAAAACQAAAFRydWVTdGF0ZQEB3gEALgBE3gEAAAAV/////wEB/////wAAAAAEYIAKAQAA" +
           "AAEACQAAAFNldFBvaW50cwEBDQEALwEBcwENAQAA/////wIAAAAVYIkKAgAAAAEAAwAAAFJQTQEB3wEA" +
           "LwEAQAnfAQAAAAr/////AwP/////AQAAABVgiQoCAAAAAAAHAAAARVVSYW5nZQEB4gEALgBE4gEAAAEA" +
           "dAP/////AQH/////AAAAABVgiQoCAAAAAQAGAAAAVG9ycXVlAQHYAgAvAQBACdgCAAAACv////8DA///" +
           "//8BAAAAFWCJCgIAAAAAAAcAAABFVVJhbmdlAQHbAgAuAETbAgAAAQB0A/////8BAf////8AAAAABGCA" +
           "CgEAAAABAAYAAABMaW1pdHMBAQwBAC8APQwBAAD/////AAAAAARggAoBAAAAAQARAAAAT3BlcmF0aW9u" +
           "YWxMaW1pdHMBATQDAC8BAfsCNAMAAP////8EAAAAFWCJCgIAAAABAAYAAABNYXhSUE0BATUDAC8BAEAJ" +
           "NQMAAAAK/////wEB/////wEAAAAVYIkKAgAAAAAABwAAAEVVUmFuZ2UBATgDAC4ARDgDAAABAHQD////" +
           "/wEB/////wAAAAAVYIkKAgAAAAEABgAAAE1pblJQTQEBOwMALwEAQAk7AwAAAAr/////AQH/////AQAA" +
           "ABVgiQoCAAAAAAAHAAAARVVSYW5nZQEBPgMALgBEPgMAAAEAdAP/////AQH/////AAAAABVgiQoCAAAA" +
           "AQAJAAAATWF4VG9ycXVlAQFBAwAvAQBACUEDAAAACv////8BAf////8BAAAAFWCJCgIAAAAAAAcAAABF" +
           "VVJhbmdlAQFEAwAuAEREAwAAAQB0A/////8BAf////8AAAAAFWCJCgIAAAABAAkAAABNaW5Ub3JxdWUB" +
           "AUcDAC8BAEAJRwMAAAAK/////wEB/////wEAAAAVYIkKAgAAAAAABwAAAEVVUmFuZ2UBAUoDAC4AREoD" +
           "AAABAHQD/////wEB/////wAAAAAEYIAKAQAAAAEACwAAAEFjY2Vzc1J1bGVzAQEOAQAvAD0OAQAA////" +
           "/wAAAAAEYIAKAQAAAAEACAAAAE11ZFB1bXBzAQEZAQAvAD0ZAQAA/////wAAAAA=";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// A description for the ChangePhaseMethodType Method.
        /// </summary>
        public ChangePhaseMethodState ChangePhase
        {
            get
            { 
                return m_changePhaseMethod;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_changePhaseMethod, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_changePhaseMethod = value;
            }
        }

        /// <summary>
        /// A description for the ChangePhaseWithString Property.
        /// </summary>
        public PropertyState<string> ChangePhaseWithString
        {
            get
            { 
                return m_changePhaseWithString;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_changePhaseWithString, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_changePhaseWithString = value;
            }
        }

        /// <summary>
        /// A description for the CurrentPhase Variable.
        /// </summary>
        public BaseDataVariableState<NodeId> CurrentPhase
        {
            get
            { 
                return m_currentPhase;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_currentPhase, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_currentPhase = value;
            }
        }

        /// <summary>
        /// A description for the Phases Object.
        /// </summary>
        public FolderState Phases
        {
            get
            { 
                return m_phases;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_phases, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_phases = value;
            }
        }

        /// <summary>
        /// A description for the Locks Object.
        /// </summary>
        public FolderState Locks
        {
            get
            { 
                return m_locks;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_locks, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_locks = value;
            }
        }

        /// <summary>
        /// A description for the TopDrive Object.
        /// </summary>
        public TopDriveState TopDrive
        {
            get
            { 
                return m_topDrive;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_topDrive, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_topDrive = value;
            }
        }

        /// <summary>
        /// A description for the MudPumps Object.
        /// </summary>
        public FolderState MudPumps
        {
            get
            { 
                return m_mudPumps;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_mudPumps, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_mudPumps = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_changePhaseMethod != null)
            {
                children.Add(m_changePhaseMethod);
            }

            if (m_changePhaseWithString != null)
            {
                children.Add(m_changePhaseWithString);
            }

            if (m_currentPhase != null)
            {
                children.Add(m_currentPhase);
            }

            if (m_phases != null)
            {
                children.Add(m_phases);
            }

            if (m_locks != null)
            {
                children.Add(m_locks);
            }

            if (m_topDrive != null)
            {
                children.Add(m_topDrive);
            }

            if (m_mudPumps != null)
            {
                children.Add(m_mudPumps);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case DsatsDemo.BrowseNames.ChangePhase:
                {
                    if (createOrReplace)
                    {
                        if (ChangePhase == null)
                        {
                            if (replacement == null)
                            {
                                ChangePhase = new ChangePhaseMethodState(this);
                            }
                            else
                            {
                                ChangePhase = (ChangePhaseMethodState)replacement;
                            }
                        }
                    }

                    instance = ChangePhase;
                    break;
                }

                case DsatsDemo.BrowseNames.ChangePhaseWithString:
                {
                    if (createOrReplace)
                    {
                        if (ChangePhaseWithString == null)
                        {
                            if (replacement == null)
                            {
                                ChangePhaseWithString = new PropertyState<string>(this);
                            }
                            else
                            {
                                ChangePhaseWithString = (PropertyState<string>)replacement;
                            }
                        }
                    }

                    instance = ChangePhaseWithString;
                    break;
                }

                case DsatsDemo.BrowseNames.CurrentPhase:
                {
                    if (createOrReplace)
                    {
                        if (CurrentPhase == null)
                        {
                            if (replacement == null)
                            {
                                CurrentPhase = new BaseDataVariableState<NodeId>(this);
                            }
                            else
                            {
                                CurrentPhase = (BaseDataVariableState<NodeId>)replacement;
                            }
                        }
                    }

                    instance = CurrentPhase;
                    break;
                }

                case DsatsDemo.BrowseNames.Phases:
                {
                    if (createOrReplace)
                    {
                        if (Phases == null)
                        {
                            if (replacement == null)
                            {
                                Phases = new FolderState(this);
                            }
                            else
                            {
                                Phases = (FolderState)replacement;
                            }
                        }
                    }

                    instance = Phases;
                    break;
                }

                case DsatsDemo.BrowseNames.Locks:
                {
                    if (createOrReplace)
                    {
                        if (Locks == null)
                        {
                            if (replacement == null)
                            {
                                Locks = new FolderState(this);
                            }
                            else
                            {
                                Locks = (FolderState)replacement;
                            }
                        }
                    }

                    instance = Locks;
                    break;
                }

                case DsatsDemo.BrowseNames.TopDrive:
                {
                    if (createOrReplace)
                    {
                        if (TopDrive == null)
                        {
                            if (replacement == null)
                            {
                                TopDrive = new TopDriveState(this);
                            }
                            else
                            {
                                TopDrive = (TopDriveState)replacement;
                            }
                        }
                    }

                    instance = TopDrive;
                    break;
                }

                case DsatsDemo.BrowseNames.MudPumps:
                {
                    if (createOrReplace)
                    {
                        if (MudPumps == null)
                        {
                            if (replacement == null)
                            {
                                MudPumps = new FolderState(this);
                            }
                            else
                            {
                                MudPumps = (FolderState)replacement;
                            }
                        }
                    }

                    instance = MudPumps;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private ChangePhaseMethodState m_changePhaseMethod;
        private PropertyState<string> m_changePhaseWithString;
        private BaseDataVariableState<NodeId> m_currentPhase;
        private FolderState m_phases;
        private FolderState m_locks;
        private TopDriveState m_topDrive;
        private FolderState m_mudPumps;
        #endregion
    }
    #endif
    #endregion
}
