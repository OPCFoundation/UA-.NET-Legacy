/* ========================================================================
 * Copyright (c) 2005-2013 The OPC Foundation, Inc. All rights reserved.
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

namespace TutorialModel
{
    #region GenericSensorState Class
    #if (!OPCUA_EXCLUDE_GenericSensorState)
    /// <summary>
    /// Stores an instance of the GenericSensorType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class GenericSensorState : BaseObjectState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public GenericSensorState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(TutorialModel.ObjectTypes.GenericSensorType, TutorialModel.Namespaces.Tutorial, namespaceUris);
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
           "AQAAACQAAABodHRwOi8vc29tZWNvbXBhbnkuY29tL1R1dG9yaWFsTW9kZWz/////JGCAAAEAAAABABkA" +
           "AABHZW5lcmljU2Vuc29yVHlwZUluc3RhbmNlAQEHAAMAAAAAKwAAAEEgZ2VuZXJpYyBzZW5zb3IgdGhh" +
           "dCByZWFkIGEgcHJvY2VzcyB2YWx1ZS4BAQcA/////wEAAAAVYIkKAgAAAAEABgAAAE91dHB1dAEBCAAA" +
           "LwEAQAkIAAAAAAv/////AQH/////AQAAABVgiQoCAAAAAAAHAAAARVVSYW5nZQEBCwAALgBECwAAAAEA" +
           "dAP/////AQH/////AAAAAA==";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// A description for the Output Variable.
        /// </summary>
        public AnalogItemState<double> Output
        {
            get
            { 
                return m_output;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_output, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_output = value;
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
            if (m_output != null)
            {
                children.Add(m_output);
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
                case TutorialModel.BrowseNames.Output:
                {
                    if (createOrReplace)
                    {
                        if (Output == null)
                        {
                            if (replacement == null)
                            {
                                Output = new AnalogItemState<double>(this);
                            }
                            else
                            {
                                Output = (AnalogItemState<double>)replacement;
                            }
                        }
                    }

                    instance = Output;
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
        private AnalogItemState<double> m_output;
        #endregion
    }
    #endif
    #endregion

    #region GenericActuatorState Class
    #if (!OPCUA_EXCLUDE_GenericActuatorState)
    /// <summary>
    /// Stores an instance of the GenericActuatorType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class GenericActuatorState : BaseObjectState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public GenericActuatorState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(TutorialModel.ObjectTypes.GenericActuatorType, TutorialModel.Namespaces.Tutorial, namespaceUris);
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
           "AQAAACQAAABodHRwOi8vc29tZWNvbXBhbnkuY29tL1R1dG9yaWFsTW9kZWz/////JGCAAAEAAAABABsA" +
           "AABHZW5lcmljQWN0dWF0b3JUeXBlSW5zdGFuY2UBAQ4AAwAAAABBAAAAUmVwcmVzZW50cyBhIHBpZWNl" +
           "IG9mIGVxdWlwbWVudCB0aGF0IGNhdXNlcyBzb21lIGFjdGlvbiB0byBvY2N1ci4BAQ4A/////wEAAAAV" +
           "YIkKAgAAAAEABQAAAElucHV0AQEPAAAvAQBACQ8AAAAAC/////8CAv////8BAAAAFWCJCgIAAAAAAAcA" +
           "AABFVVJhbmdlAQESAAAuAEQSAAAAAQB0A/////8BAf////8AAAAA";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// A description for the Input Variable.
        /// </summary>
        public AnalogItemState<double> Input
        {
            get
            { 
                return m_input;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_input, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_input = value;
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
            if (m_input != null)
            {
                children.Add(m_input);
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
                case TutorialModel.BrowseNames.Input:
                {
                    if (createOrReplace)
                    {
                        if (Input == null)
                        {
                            if (replacement == null)
                            {
                                Input = new AnalogItemState<double>(this);
                            }
                            else
                            {
                                Input = (AnalogItemState<double>)replacement;
                            }
                        }
                    }

                    instance = Input;
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
        private AnalogItemState<double> m_input;
        #endregion
    }
    #endif
    #endregion

    #region PipeState Class
    #if (!OPCUA_EXCLUDE_PipeState)
    /// <summary>
    /// Stores an instance of the PipeType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class PipeState : BaseObjectState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public PipeState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(TutorialModel.ObjectTypes.PipeType, TutorialModel.Namespaces.Tutorial, namespaceUris);
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
           "AQAAACQAAABodHRwOi8vc29tZWNvbXBhbnkuY29tL1R1dG9yaWFsTW9kZWz/////pGCAAAEAAAABABAA" +
           "AABQaXBlVHlwZUluc3RhbmNlAQHHAAMAAAAAMgAAAEEgcGlwZSB3aXRoIGEgZmxvdyB0cmFuc21pdHRl" +
           "ciBhbmQgdmFsdmUgYXR0YWNoZWQuAQHHAAH/////AwAAAIRggAoBAAAAAQAPAAAARmxvd1RyYW5zbWl0" +
           "dGVyAQHIAAAvAQEHAMgAAAAB/////wEAAAAVYIkKAgAAAAEABgAAAE91dHB1dAEByQAALgBEyQAAAAAL" +
           "/////wEBAQAAAAEBAgABAQHQAAEAAAAVYIkKAgAAAAAABwAAAEVVUmFuZ2UBAcwAAC4ARMwAAAABAHQD" +
           "/////wEB/////wAAAACEYIAKAQAAAAEABQAAAFZhbHZlAQHPAAAvAQEOAM8AAAAB/////wEAAAAVYIkK" +
           "AgAAAAEABQAAAElucHV0AQHQAAAuAETQAAAAAAv/////AgIBAAAAAQECAAABAckAAQAAABVgiQoCAAAA" +
           "AAAHAAAARVVSYW5nZQEB0wAALgBE0wAAAAEAdAP/////AQH/////AAAAABVgqQoCAAAAAQALAAAAQ2Fs" +
           "aWJyYXRpb24BAfUAAC8AP/UAAAAWAQHnAAJ8AAAAPENhbGlicmF0aW9uRGF0YVR5cGUgeG1sbnM9Imh0" +
           "dHA6Ly9zb21lY29tcGFueS5jb20vVHV0b3JpYWxNb2RlbCI+PE9mZnNldD4xPC9PZmZzZXQ+PFBlcmlv" +
           "ZD4xPC9QZXJpb2Q+PC9DYWxpYnJhdGlvbkRhdGFUeXBlPgEBxgD/////AQH/////AAAAAA==";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// A description for the FlowTransmitter Object.
        /// </summary>
        public GenericSensorState FlowTransmitter
        {
            get
            { 
                return m_flowTransmitter;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_flowTransmitter, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_flowTransmitter = value;
            }
        }

        /// <summary>
        /// A description for the Valve Object.
        /// </summary>
        public GenericActuatorState Valve
        {
            get
            { 
                return m_valve;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_valve, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_valve = value;
            }
        }

        /// <summary>
        /// A description for the Calibration Variable.
        /// </summary>
        public BaseDataVariableState<CalibrationDataType> Calibration
        {
            get
            { 
                return m_calibration;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_calibration, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_calibration = value;
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
            if (m_flowTransmitter != null)
            {
                children.Add(m_flowTransmitter);
            }

            if (m_valve != null)
            {
                children.Add(m_valve);
            }

            if (m_calibration != null)
            {
                children.Add(m_calibration);
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
                case TutorialModel.BrowseNames.FlowTransmitter:
                {
                    if (createOrReplace)
                    {
                        if (FlowTransmitter == null)
                        {
                            if (replacement == null)
                            {
                                FlowTransmitter = new GenericSensorState(this);
                            }
                            else
                            {
                                FlowTransmitter = (GenericSensorState)replacement;
                            }
                        }
                    }

                    instance = FlowTransmitter;
                    break;
                }

                case TutorialModel.BrowseNames.Valve:
                {
                    if (createOrReplace)
                    {
                        if (Valve == null)
                        {
                            if (replacement == null)
                            {
                                Valve = new GenericActuatorState(this);
                            }
                            else
                            {
                                Valve = (GenericActuatorState)replacement;
                            }
                        }
                    }

                    instance = Valve;
                    break;
                }

                case TutorialModel.BrowseNames.Calibration:
                {
                    if (createOrReplace)
                    {
                        if (Calibration == null)
                        {
                            if (replacement == null)
                            {
                                Calibration = new BaseDataVariableState<CalibrationDataType>(this);
                            }
                            else
                            {
                                Calibration = (BaseDataVariableState<CalibrationDataType>)replacement;
                            }
                        }
                    }

                    instance = Calibration;
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
        private GenericSensorState m_flowTransmitter;
        private GenericActuatorState m_valve;
        private BaseDataVariableState<CalibrationDataType> m_calibration;
        #endregion
    }
    #endif
    #endregion
}
