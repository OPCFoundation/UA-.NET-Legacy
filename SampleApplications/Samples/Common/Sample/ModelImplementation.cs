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
using Opc.Ua.Server;
using Opc.Ua.Sample;

namespace Opc.Ua.Sample
{
#if INCLUDE_Sample
    #region GenericControllerType Class
    /// <summary>
    /// Represents the GenericControllerType ObjectType in the address space.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class GenericControllerType : ObjectTypeSource
    {
        #region Constructors
        /// <summary>
        /// Initializes the object with default values.
        /// </summary>
        public GenericControllerType(IServerInternal server) : base(server)
        {
            Initialize(
                new NodeId(Opc.Ua.Sample.ObjectTypes.GenericControllerType, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                new QualifiedName(Opc.Ua.Sample.BrowseNames.GenericControllerType, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                new NodeId(Opc.Ua.ObjectTypes.BaseObjectType, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)));
                    
            server.TypeSources.SetTypeSource(this.NodeId, this);
        }

        /// <summary>
        /// Finds the source for the type definition (creates it if it does not exist).
        /// </summary>
        public static new GenericControllerType FindSource(IServerInternal server)
        {
            GenericControllerType type = null;
                    
            lock (server.TypeSources.SyncRoot)
            {
                NodeId typeId = new NodeId(Opc.Ua.Sample.ObjectTypes.GenericControllerType, server.NamespaceUris.GetIndexOrAppend(Opc.Ua.Sample.Namespaces.Sample));

                type = server.TypeSources.FindTypeSource(typeId) as GenericControllerType;

                if (type != null)
                {
                    return type;
                }

                type = new GenericControllerType(server);
            }

            return type;
        }
        #endregion
             
        #region ICloneable Members
        /// <summary cref="NodeSource.Clone(NodeSource)" />
        public override NodeSource Clone(NodeSource parent)
        {
            lock (DataLock)
            {
                GenericControllerType clone = new GenericControllerType(Server);
                clone.Initialize(this);
                return clone;
            }
        }
        #endregion
      
        #region Public Properties
        #region Measurement
        /// <summary>
        /// A description for the Measurement Property.
        /// </summary>
        public Property<double> Measurement
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_measurement; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_measurement != null)
                    {
                        RemoveChild(m_measurement);
                    }

                    m_measurement = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceMeasurement(Property<double> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                Measurement = replacement;

                Measurement.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.Measurement, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.GenericControllerType_Measurement,
                    null);
            }
        }
        #endregion

        #region SetPoint
        /// <summary>
        /// A description for the SetPoint Property.
        /// </summary>
        public Property<double> SetPoint
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_setPoint; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_setPoint != null)
                    {
                        RemoveChild(m_setPoint);
                    }

                    m_setPoint = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceSetPoint(Property<double> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                SetPoint = replacement;

                SetPoint.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.SetPoint, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.GenericControllerType_SetPoint,
                    null);
            }
        }
        #endregion

        #region ControlOut
        /// <summary>
        /// A description for the ControlOut Property.
        /// </summary>
        public Property<double> ControlOut
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_controlOut; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_controlOut != null)
                    {
                        RemoveChild(m_controlOut);
                    }

                    m_controlOut = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceControlOut(Property<double> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                ControlOut = replacement;

                ControlOut.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.ControlOut, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.GenericControllerType_ControlOut,
                    null);
            }
        }
        #endregion
        #endregion

        #region Overridden Methods
        /// <summary cref="NodeSource.Initialize(NodeSource)" />
        public override void Initialize(NodeSource source)
        {
            lock (DataLock)
            {
                base.Initialize(source);
                
                GenericControllerType type = source as GenericControllerType;

                if (type != null && type.Measurement != null)
                {
                    Measurement = (Property<double>)type.Measurement.Clone(this);
                    Measurement.Initialize(type.Measurement);
                }

                if (type != null && type.SetPoint != null)
                {
                    SetPoint = (Property<double>)type.SetPoint.Clone(this);
                    SetPoint.Initialize(type.SetPoint);
                }

                if (type != null && type.ControlOut != null)
                {
                    ControlOut = (Property<double>)type.ControlOut.Clone(this);
                    ControlOut.Initialize(type.ControlOut);
                }
            }
        }

        /// <summary cref="NodeSource.InitializeChildren" />
        protected override void InitializeChildren()
        {
            base.InitializeChildren();
                
            m_measurement = Property<double>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.GenericControllerType_Measurement, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.Measurement, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.GenericControllerType_Measurement);

            m_setPoint = Property<double>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.GenericControllerType_SetPoint, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.SetPoint, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.GenericControllerType_SetPoint);

            m_controlOut = Property<double>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.GenericControllerType_ControlOut, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.ControlOut, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.GenericControllerType_ControlOut);
        }
        #endregion

        #region Private Fields
        Property<double> m_measurement;
        Property<double> m_setPoint;
        Property<double> m_controlOut;
        #endregion
    }
    #endregion

    #region GenericController Class
    /// <summary>
    /// Represents an instance of the GenericControllerType ObjectType in the address space.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class GenericController : ObjectSource
    {
        #region Constructors
        /// <summary>
        /// Initializes the object with default values.
        /// </summary>
        protected GenericController(IServerInternal server, NodeSource parent) 
        : 
            base(server, parent)
        {
            m_typeDefinition = GenericControllerType.FindSource(server);
        }

        /// <summary>
        /// Creates a new instance of the node.
        /// </summary>
        public static new GenericController Construct(
            IServerInternal server, 
            NodeSource      parent, 
            NodeId          referenceTypeId,
            NodeId          nodeId,
            QualifiedName   browseName,
            uint            numericId)
        {
            GenericController instance = new GenericController(server, parent);
            instance.Initialize(referenceTypeId, nodeId, browseName, numericId, instance.m_typeDefinition.NodeId);
            return instance;
        }

        /// <summary>
        /// Creates a new instance of the node without any parent.
        /// </summary>
        public static new GenericController Construct(IServerInternal server)
        {
            GenericController instance = new GenericController(server, (NodeSource)null);
            instance.Initialize(null, null, null, 0, instance.m_typeDefinition.NodeId);
            return instance;
        }
        #endregion
           
        #region ICloneable Members
        /// <summary cref="NodeSource.Clone(NodeSource)" />
        public override NodeSource Clone(NodeSource parent)
        {
            lock (DataLock)
            {
                GenericController clone = new GenericController(Server, parent);
                clone.Initialize(this);
                return clone;
            } 
        }
        #endregion

        #region Public Properties
        #region Measurement
        /// <summary>
        /// A description for the Measurement Property.
        /// </summary>
        public Property<double> Measurement
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_measurement; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_measurement != null)
                    {
                        RemoveChild(m_measurement);
                    }

                    m_measurement = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceMeasurement(Property<double> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                Measurement = replacement;

                Measurement.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.Measurement, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.GenericControllerType_Measurement,
                    null);
            }
        }
        #endregion

        #region SetPoint
        /// <summary>
        /// A description for the SetPoint Property.
        /// </summary>
        public Property<double> SetPoint
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_setPoint; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_setPoint != null)
                    {
                        RemoveChild(m_setPoint);
                    }

                    m_setPoint = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceSetPoint(Property<double> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                SetPoint = replacement;

                SetPoint.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.SetPoint, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.GenericControllerType_SetPoint,
                    null);
            }
        }
        #endregion

        #region ControlOut
        /// <summary>
        /// A description for the ControlOut Property.
        /// </summary>
        public Property<double> ControlOut
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_controlOut; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_controlOut != null)
                    {
                        RemoveChild(m_controlOut);
                    }

                    m_controlOut = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceControlOut(Property<double> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                ControlOut = replacement;

                ControlOut.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.ControlOut, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.GenericControllerType_ControlOut,
                    null);
            }
        }
        #endregion
        #endregion

        #region Overridden Methods
        /// <summary cref="NodeSource.Initialize(NodeSource)" />
        public override void Initialize(NodeSource source)
        {
            lock (DataLock)
            {            
                GenericController instance = source as GenericController;

                if (instance != null)
                {
                    base.Initialize(source);
                }

                GenericControllerType type = source as GenericControllerType;

                if (type != null && type.Measurement != null)
                {
                    Measurement = (Property<double>)type.Measurement.Clone(this);
                    Measurement.Initialize(type.Measurement);
                }
                else if (instance != null && instance.Measurement != null)
                {
                    Measurement = (Property<double>)instance.Measurement.Clone(this);
                    Measurement.Initialize(instance.Measurement);
                }

                if (type != null && type.SetPoint != null)
                {
                    SetPoint = (Property<double>)type.SetPoint.Clone(this);
                    SetPoint.Initialize(type.SetPoint);
                }
                else if (instance != null && instance.SetPoint != null)
                {
                    SetPoint = (Property<double>)instance.SetPoint.Clone(this);
                    SetPoint.Initialize(instance.SetPoint);
                }

                if (type != null && type.ControlOut != null)
                {
                    ControlOut = (Property<double>)type.ControlOut.Clone(this);
                    ControlOut.Initialize(type.ControlOut);
                }
                else if (instance != null && instance.ControlOut != null)
                {
                    ControlOut = (Property<double>)instance.ControlOut.Clone(this);
                    ControlOut.Initialize(instance.ControlOut);
                }
            }
        }

        /// <summary cref="NodeSource.InitializeChildren" />
        protected override void InitializeChildren()
        {
            base.InitializeChildren();
                
            m_measurement = Property<double>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.Measurement, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.GenericControllerType_Measurement);

            m_setPoint = Property<double>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.SetPoint, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.GenericControllerType_SetPoint);

            m_controlOut = Property<double>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.ControlOut, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.GenericControllerType_ControlOut);
        }
        #endregion

        #region Private Fields
        private GenericControllerType m_typeDefinition;
        Property<double> m_measurement;
        Property<double> m_setPoint;
        Property<double> m_controlOut;
        #endregion
    }
    #endregion

    #region GenericSensorType Class
    /// <summary>
    /// Represents the GenericSensorType ObjectType in the address space.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class GenericSensorType : ObjectTypeSource
    {
        #region Constructors
        /// <summary>
        /// Initializes the object with default values.
        /// </summary>
        public GenericSensorType(IServerInternal server) : base(server)
        {
            Initialize(
                new NodeId(Opc.Ua.Sample.ObjectTypes.GenericSensorType, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                new QualifiedName(Opc.Ua.Sample.BrowseNames.GenericSensorType, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                new NodeId(Opc.Ua.ObjectTypes.BaseObjectType, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)));
                    
            server.TypeSources.SetTypeSource(this.NodeId, this);
        }

        /// <summary>
        /// Finds the source for the type definition (creates it if it does not exist).
        /// </summary>
        public static new GenericSensorType FindSource(IServerInternal server)
        {
            GenericSensorType type = null;
                    
            lock (server.TypeSources.SyncRoot)
            {
                NodeId typeId = new NodeId(Opc.Ua.Sample.ObjectTypes.GenericSensorType, server.NamespaceUris.GetIndexOrAppend(Opc.Ua.Sample.Namespaces.Sample));

                type = server.TypeSources.FindTypeSource(typeId) as GenericSensorType;

                if (type != null)
                {
                    return type;
                }

                type = new GenericSensorType(server);
            }

            return type;
        }
        #endregion
             
        #region ICloneable Members
        /// <summary cref="NodeSource.Clone(NodeSource)" />
        public override NodeSource Clone(NodeSource parent)
        {
            lock (DataLock)
            {
                GenericSensorType clone = new GenericSensorType(Server);
                clone.Initialize(this);
                return clone;
            }
        }
        #endregion
      
        #region Public Properties
        #region Output
        /// <summary>
        /// A description for the Output Variable.
        /// </summary>
        public AnalogItem<double> Output
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_output; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_output != null)
                    {
                        RemoveChild(m_output);
                    }

                    m_output = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceOutput(AnalogItem<double> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                Output = replacement;

                Output.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.Output, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.GenericSensorType_Output,
                    null);
            }
        }
        #endregion
        #endregion

        #region Overridden Methods
        /// <summary cref="NodeSource.Initialize(NodeSource)" />
        public override void Initialize(NodeSource source)
        {
            lock (DataLock)
            {
                base.Initialize(source);
                
                GenericSensorType type = source as GenericSensorType;

                if (type != null && type.Output != null)
                {
                    Output = (AnalogItem<double>)type.Output.Clone(this);
                    Output.Initialize(type.Output);
                }
            }
        }

        /// <summary cref="NodeSource.InitializeChildren" />
        protected override void InitializeChildren()
        {
            base.InitializeChildren();
                
            m_output = AnalogItem<double>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.GenericSensorType_Output, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.Output, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.GenericSensorType_Output);
        }
        #endregion

        #region Private Fields
        AnalogItem<double> m_output;
        #endregion
    }
    #endregion

    #region GenericSensor Class
    /// <summary>
    /// Represents an instance of the GenericSensorType ObjectType in the address space.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class GenericSensor : ObjectSource
    {
        #region Constructors
        /// <summary>
        /// Initializes the object with default values.
        /// </summary>
        protected GenericSensor(IServerInternal server, NodeSource parent) 
        : 
            base(server, parent)
        {
            m_typeDefinition = GenericSensorType.FindSource(server);
        }

        /// <summary>
        /// Creates a new instance of the node.
        /// </summary>
        public static new GenericSensor Construct(
            IServerInternal server, 
            NodeSource      parent, 
            NodeId          referenceTypeId,
            NodeId          nodeId,
            QualifiedName   browseName,
            uint            numericId)
        {
            GenericSensor instance = new GenericSensor(server, parent);
            instance.Initialize(referenceTypeId, nodeId, browseName, numericId, instance.m_typeDefinition.NodeId);
            return instance;
        }

        /// <summary>
        /// Creates a new instance of the node without any parent.
        /// </summary>
        public static new GenericSensor Construct(IServerInternal server)
        {
            GenericSensor instance = new GenericSensor(server, (NodeSource)null);
            instance.Initialize(null, null, null, 0, instance.m_typeDefinition.NodeId);
            return instance;
        }
        #endregion
           
        #region ICloneable Members
        /// <summary cref="NodeSource.Clone(NodeSource)" />
        public override NodeSource Clone(NodeSource parent)
        {
            lock (DataLock)
            {
                GenericSensor clone = new GenericSensor(Server, parent);
                clone.Initialize(this);
                return clone;
            } 
        }
        #endregion

        #region Public Properties
        #region Output
        /// <summary>
        /// A description for the Output Variable.
        /// </summary>
        public AnalogItem<double> Output
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_output; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_output != null)
                    {
                        RemoveChild(m_output);
                    }

                    m_output = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceOutput(AnalogItem<double> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                Output = replacement;

                Output.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.Output, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.GenericSensorType_Output,
                    null);
            }
        }
        #endregion
        #endregion

        #region Overridden Methods
        /// <summary cref="NodeSource.Initialize(NodeSource)" />
        public override void Initialize(NodeSource source)
        {
            lock (DataLock)
            {            
                GenericSensor instance = source as GenericSensor;

                if (instance != null)
                {
                    base.Initialize(source);
                }

                GenericSensorType type = source as GenericSensorType;

                if (type != null && type.Output != null)
                {
                    Output = (AnalogItem<double>)type.Output.Clone(this);
                    Output.Initialize(type.Output);
                }
                else if (instance != null && instance.Output != null)
                {
                    Output = (AnalogItem<double>)instance.Output.Clone(this);
                    Output.Initialize(instance.Output);
                }
            }
        }

        /// <summary cref="NodeSource.InitializeChildren" />
        protected override void InitializeChildren()
        {
            base.InitializeChildren();
                
            m_output = AnalogItem<double>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.Output, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.GenericSensorType_Output);
        }
        #endregion

        #region Private Fields
        private GenericSensorType m_typeDefinition;
        AnalogItem<double> m_output;
        #endregion
    }
    #endregion

    #region GenericActuatorType Class
    /// <summary>
    /// Represents the GenericActuatorType ObjectType in the address space.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class GenericActuatorType : ObjectTypeSource
    {
        #region Constructors
        /// <summary>
        /// Initializes the object with default values.
        /// </summary>
        public GenericActuatorType(IServerInternal server) : base(server)
        {
            Initialize(
                new NodeId(Opc.Ua.Sample.ObjectTypes.GenericActuatorType, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                new QualifiedName(Opc.Ua.Sample.BrowseNames.GenericActuatorType, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                new NodeId(Opc.Ua.ObjectTypes.BaseObjectType, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)));
                    
            server.TypeSources.SetTypeSource(this.NodeId, this);
        }

        /// <summary>
        /// Finds the source for the type definition (creates it if it does not exist).
        /// </summary>
        public static new GenericActuatorType FindSource(IServerInternal server)
        {
            GenericActuatorType type = null;
                    
            lock (server.TypeSources.SyncRoot)
            {
                NodeId typeId = new NodeId(Opc.Ua.Sample.ObjectTypes.GenericActuatorType, server.NamespaceUris.GetIndexOrAppend(Opc.Ua.Sample.Namespaces.Sample));

                type = server.TypeSources.FindTypeSource(typeId) as GenericActuatorType;

                if (type != null)
                {
                    return type;
                }

                type = new GenericActuatorType(server);
            }

            return type;
        }
        #endregion
             
        #region ICloneable Members
        /// <summary cref="NodeSource.Clone(NodeSource)" />
        public override NodeSource Clone(NodeSource parent)
        {
            lock (DataLock)
            {
                GenericActuatorType clone = new GenericActuatorType(Server);
                clone.Initialize(this);
                return clone;
            }
        }
        #endregion
      
        #region Public Properties
        #region Input
        /// <summary>
        /// A description for the Input Variable.
        /// </summary>
        public AnalogItem<double> Input
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_input; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_input != null)
                    {
                        RemoveChild(m_input);
                    }

                    m_input = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceInput(AnalogItem<double> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                Input = replacement;

                Input.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.Input, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.GenericActuatorType_Input,
                    null);
            }
        }
        #endregion
        #endregion

        #region Overridden Methods
        /// <summary cref="NodeSource.Initialize(NodeSource)" />
        public override void Initialize(NodeSource source)
        {
            lock (DataLock)
            {
                base.Initialize(source);
                
                GenericActuatorType type = source as GenericActuatorType;

                if (type != null && type.Input != null)
                {
                    Input = (AnalogItem<double>)type.Input.Clone(this);
                    Input.Initialize(type.Input);
                }
            }
        }

        /// <summary cref="NodeSource.InitializeChildren" />
        protected override void InitializeChildren()
        {
            base.InitializeChildren();
                
            m_input = AnalogItem<double>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.GenericActuatorType_Input, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.Input, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.GenericActuatorType_Input);
        }
        #endregion

        #region Private Fields
        AnalogItem<double> m_input;
        #endregion
    }
    #endregion

    #region GenericActuator Class
    /// <summary>
    /// Represents an instance of the GenericActuatorType ObjectType in the address space.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class GenericActuator : ObjectSource
    {
        #region Constructors
        /// <summary>
        /// Initializes the object with default values.
        /// </summary>
        protected GenericActuator(IServerInternal server, NodeSource parent) 
        : 
            base(server, parent)
        {
            m_typeDefinition = GenericActuatorType.FindSource(server);
        }

        /// <summary>
        /// Creates a new instance of the node.
        /// </summary>
        public static new GenericActuator Construct(
            IServerInternal server, 
            NodeSource      parent, 
            NodeId          referenceTypeId,
            NodeId          nodeId,
            QualifiedName   browseName,
            uint            numericId)
        {
            GenericActuator instance = new GenericActuator(server, parent);
            instance.Initialize(referenceTypeId, nodeId, browseName, numericId, instance.m_typeDefinition.NodeId);
            return instance;
        }

        /// <summary>
        /// Creates a new instance of the node without any parent.
        /// </summary>
        public static new GenericActuator Construct(IServerInternal server)
        {
            GenericActuator instance = new GenericActuator(server, (NodeSource)null);
            instance.Initialize(null, null, null, 0, instance.m_typeDefinition.NodeId);
            return instance;
        }
        #endregion
           
        #region ICloneable Members
        /// <summary cref="NodeSource.Clone(NodeSource)" />
        public override NodeSource Clone(NodeSource parent)
        {
            lock (DataLock)
            {
                GenericActuator clone = new GenericActuator(Server, parent);
                clone.Initialize(this);
                return clone;
            } 
        }
        #endregion

        #region Public Properties
        #region Input
        /// <summary>
        /// A description for the Input Variable.
        /// </summary>
        public AnalogItem<double> Input
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_input; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_input != null)
                    {
                        RemoveChild(m_input);
                    }

                    m_input = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceInput(AnalogItem<double> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                Input = replacement;

                Input.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.Input, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.GenericActuatorType_Input,
                    null);
            }
        }
        #endregion
        #endregion

        #region Overridden Methods
        /// <summary cref="NodeSource.Initialize(NodeSource)" />
        public override void Initialize(NodeSource source)
        {
            lock (DataLock)
            {            
                GenericActuator instance = source as GenericActuator;

                if (instance != null)
                {
                    base.Initialize(source);
                }

                GenericActuatorType type = source as GenericActuatorType;

                if (type != null && type.Input != null)
                {
                    Input = (AnalogItem<double>)type.Input.Clone(this);
                    Input.Initialize(type.Input);
                }
                else if (instance != null && instance.Input != null)
                {
                    Input = (AnalogItem<double>)instance.Input.Clone(this);
                    Input.Initialize(instance.Input);
                }
            }
        }

        /// <summary cref="NodeSource.InitializeChildren" />
        protected override void InitializeChildren()
        {
            base.InitializeChildren();
                
            m_input = AnalogItem<double>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.Input, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.GenericActuatorType_Input);
        }
        #endregion

        #region Private Fields
        private GenericActuatorType m_typeDefinition;
        AnalogItem<double> m_input;
        #endregion
    }
    #endregion

    #region CustomControllerType Class
    /// <summary>
    /// Represents the CustomControllerType ObjectType in the address space.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class CustomControllerType : ObjectTypeSource
    {
        #region Constructors
        /// <summary>
        /// Initializes the object with default values.
        /// </summary>
        public CustomControllerType(IServerInternal server) : base(server)
        {
            Initialize(
                new NodeId(Opc.Ua.Sample.ObjectTypes.CustomControllerType, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                new QualifiedName(Opc.Ua.Sample.BrowseNames.CustomControllerType, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                new NodeId(Opc.Ua.ObjectTypes.BaseObjectType, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)));
                    
            server.TypeSources.SetTypeSource(this.NodeId, this);
        }

        /// <summary>
        /// Finds the source for the type definition (creates it if it does not exist).
        /// </summary>
        public static new CustomControllerType FindSource(IServerInternal server)
        {
            CustomControllerType type = null;
                    
            lock (server.TypeSources.SyncRoot)
            {
                NodeId typeId = new NodeId(Opc.Ua.Sample.ObjectTypes.CustomControllerType, server.NamespaceUris.GetIndexOrAppend(Opc.Ua.Sample.Namespaces.Sample));

                type = server.TypeSources.FindTypeSource(typeId) as CustomControllerType;

                if (type != null)
                {
                    return type;
                }

                type = new CustomControllerType(server);
            }

            return type;
        }
        #endregion
             
        #region ICloneable Members
        /// <summary cref="NodeSource.Clone(NodeSource)" />
        public override NodeSource Clone(NodeSource parent)
        {
            lock (DataLock)
            {
                CustomControllerType clone = new CustomControllerType(Server);
                clone.Initialize(this);
                return clone;
            }
        }
        #endregion
      
        #region Public Properties
        #region Input1
        /// <summary>
        /// A description for the Input1 Property.
        /// </summary>
        public Property<double> Input1
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_input1; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_input1 != null)
                    {
                        RemoveChild(m_input1);
                    }

                    m_input1 = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceInput1(Property<double> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                Input1 = replacement;

                Input1.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.Input1, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.CustomControllerType_Input1,
                    null);
            }
        }
        #endregion

        #region Input2
        /// <summary>
        /// A description for the Input2 Property.
        /// </summary>
        public Property<double> Input2
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_input2; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_input2 != null)
                    {
                        RemoveChild(m_input2);
                    }

                    m_input2 = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceInput2(Property<double> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                Input2 = replacement;

                Input2.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.Input2, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.CustomControllerType_Input2,
                    null);
            }
        }
        #endregion

        #region Input3
        /// <summary>
        /// A description for the Input3 Property.
        /// </summary>
        public Property<double> Input3
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_input3; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_input3 != null)
                    {
                        RemoveChild(m_input3);
                    }

                    m_input3 = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceInput3(Property<double> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                Input3 = replacement;

                Input3.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.Input3, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.CustomControllerType_Input3,
                    null);
            }
        }
        #endregion

        #region ControlOut
        /// <summary>
        /// A description for the ControlOut Property.
        /// </summary>
        public Property<double> ControlOut
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_controlOut; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_controlOut != null)
                    {
                        RemoveChild(m_controlOut);
                    }

                    m_controlOut = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceControlOut(Property<double> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                ControlOut = replacement;

                ControlOut.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.ControlOut, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.CustomControllerType_ControlOut,
                    null);
            }
        }
        #endregion
        #endregion

        #region Overridden Methods
        /// <summary cref="NodeSource.Initialize(NodeSource)" />
        public override void Initialize(NodeSource source)
        {
            lock (DataLock)
            {
                base.Initialize(source);
                
                CustomControllerType type = source as CustomControllerType;

                if (type != null && type.Input1 != null)
                {
                    Input1 = (Property<double>)type.Input1.Clone(this);
                    Input1.Initialize(type.Input1);
                }

                if (type != null && type.Input2 != null)
                {
                    Input2 = (Property<double>)type.Input2.Clone(this);
                    Input2.Initialize(type.Input2);
                }

                if (type != null && type.Input3 != null)
                {
                    Input3 = (Property<double>)type.Input3.Clone(this);
                    Input3.Initialize(type.Input3);
                }

                if (type != null && type.ControlOut != null)
                {
                    ControlOut = (Property<double>)type.ControlOut.Clone(this);
                    ControlOut.Initialize(type.ControlOut);
                }
            }
        }

        /// <summary cref="NodeSource.InitializeChildren" />
        protected override void InitializeChildren()
        {
            base.InitializeChildren();
                
            m_input1 = Property<double>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.CustomControllerType_Input1, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.Input1, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.CustomControllerType_Input1);

            m_input2 = Property<double>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.CustomControllerType_Input2, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.Input2, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.CustomControllerType_Input2);

            m_input3 = Property<double>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.CustomControllerType_Input3, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.Input3, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.CustomControllerType_Input3);

            m_controlOut = Property<double>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.CustomControllerType_ControlOut, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.ControlOut, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.CustomControllerType_ControlOut);
        }
        #endregion

        #region Private Fields
        Property<double> m_input1;
        Property<double> m_input2;
        Property<double> m_input3;
        Property<double> m_controlOut;
        #endregion
    }
    #endregion

    #region CustomController Class
    /// <summary>
    /// Represents an instance of the CustomControllerType ObjectType in the address space.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class CustomController : ObjectSource
    {
        #region Constructors
        /// <summary>
        /// Initializes the object with default values.
        /// </summary>
        protected CustomController(IServerInternal server, NodeSource parent) 
        : 
            base(server, parent)
        {
            m_typeDefinition = CustomControllerType.FindSource(server);
        }

        /// <summary>
        /// Creates a new instance of the node.
        /// </summary>
        public static new CustomController Construct(
            IServerInternal server, 
            NodeSource      parent, 
            NodeId          referenceTypeId,
            NodeId          nodeId,
            QualifiedName   browseName,
            uint            numericId)
        {
            CustomController instance = new CustomController(server, parent);
            instance.Initialize(referenceTypeId, nodeId, browseName, numericId, instance.m_typeDefinition.NodeId);
            return instance;
        }

        /// <summary>
        /// Creates a new instance of the node without any parent.
        /// </summary>
        public static new CustomController Construct(IServerInternal server)
        {
            CustomController instance = new CustomController(server, (NodeSource)null);
            instance.Initialize(null, null, null, 0, instance.m_typeDefinition.NodeId);
            return instance;
        }
        #endregion
           
        #region ICloneable Members
        /// <summary cref="NodeSource.Clone(NodeSource)" />
        public override NodeSource Clone(NodeSource parent)
        {
            lock (DataLock)
            {
                CustomController clone = new CustomController(Server, parent);
                clone.Initialize(this);
                return clone;
            } 
        }
        #endregion

        #region Public Properties
        #region Input1
        /// <summary>
        /// A description for the Input1 Property.
        /// </summary>
        public Property<double> Input1
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_input1; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_input1 != null)
                    {
                        RemoveChild(m_input1);
                    }

                    m_input1 = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceInput1(Property<double> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                Input1 = replacement;

                Input1.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.Input1, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.CustomControllerType_Input1,
                    null);
            }
        }
        #endregion

        #region Input2
        /// <summary>
        /// A description for the Input2 Property.
        /// </summary>
        public Property<double> Input2
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_input2; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_input2 != null)
                    {
                        RemoveChild(m_input2);
                    }

                    m_input2 = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceInput2(Property<double> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                Input2 = replacement;

                Input2.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.Input2, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.CustomControllerType_Input2,
                    null);
            }
        }
        #endregion

        #region Input3
        /// <summary>
        /// A description for the Input3 Property.
        /// </summary>
        public Property<double> Input3
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_input3; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_input3 != null)
                    {
                        RemoveChild(m_input3);
                    }

                    m_input3 = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceInput3(Property<double> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                Input3 = replacement;

                Input3.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.Input3, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.CustomControllerType_Input3,
                    null);
            }
        }
        #endregion

        #region ControlOut
        /// <summary>
        /// A description for the ControlOut Property.
        /// </summary>
        public Property<double> ControlOut
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_controlOut; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_controlOut != null)
                    {
                        RemoveChild(m_controlOut);
                    }

                    m_controlOut = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceControlOut(Property<double> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                ControlOut = replacement;

                ControlOut.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.ControlOut, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.CustomControllerType_ControlOut,
                    null);
            }
        }
        #endregion
        #endregion

        #region Overridden Methods
        /// <summary cref="NodeSource.Initialize(NodeSource)" />
        public override void Initialize(NodeSource source)
        {
            lock (DataLock)
            {            
                CustomController instance = source as CustomController;

                if (instance != null)
                {
                    base.Initialize(source);
                }

                CustomControllerType type = source as CustomControllerType;

                if (type != null && type.Input1 != null)
                {
                    Input1 = (Property<double>)type.Input1.Clone(this);
                    Input1.Initialize(type.Input1);
                }
                else if (instance != null && instance.Input1 != null)
                {
                    Input1 = (Property<double>)instance.Input1.Clone(this);
                    Input1.Initialize(instance.Input1);
                }

                if (type != null && type.Input2 != null)
                {
                    Input2 = (Property<double>)type.Input2.Clone(this);
                    Input2.Initialize(type.Input2);
                }
                else if (instance != null && instance.Input2 != null)
                {
                    Input2 = (Property<double>)instance.Input2.Clone(this);
                    Input2.Initialize(instance.Input2);
                }

                if (type != null && type.Input3 != null)
                {
                    Input3 = (Property<double>)type.Input3.Clone(this);
                    Input3.Initialize(type.Input3);
                }
                else if (instance != null && instance.Input3 != null)
                {
                    Input3 = (Property<double>)instance.Input3.Clone(this);
                    Input3.Initialize(instance.Input3);
                }

                if (type != null && type.ControlOut != null)
                {
                    ControlOut = (Property<double>)type.ControlOut.Clone(this);
                    ControlOut.Initialize(type.ControlOut);
                }
                else if (instance != null && instance.ControlOut != null)
                {
                    ControlOut = (Property<double>)instance.ControlOut.Clone(this);
                    ControlOut.Initialize(instance.ControlOut);
                }
            }
        }

        /// <summary cref="NodeSource.InitializeChildren" />
        protected override void InitializeChildren()
        {
            base.InitializeChildren();
                
            m_input1 = Property<double>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.Input1, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.CustomControllerType_Input1);

            m_input2 = Property<double>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.Input2, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.CustomControllerType_Input2);

            m_input3 = Property<double>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.Input3, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.CustomControllerType_Input3);

            m_controlOut = Property<double>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.ControlOut, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.CustomControllerType_ControlOut);
        }
        #endregion

        #region Private Fields
        private CustomControllerType m_typeDefinition;
        Property<double> m_input1;
        Property<double> m_input2;
        Property<double> m_input3;
        Property<double> m_controlOut;
        #endregion
    }
    #endregion

    #region ValveType Class
    /// <summary>
    /// Represents the ValveType ObjectType in the address space.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class ValveType : ObjectTypeSource
    {
        #region Constructors
        /// <summary>
        /// Initializes the object with default values.
        /// </summary>
        public ValveType(IServerInternal server) : base(server)
        {
            Initialize(
                new NodeId(Opc.Ua.Sample.ObjectTypes.ValveType, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                new QualifiedName(Opc.Ua.Sample.BrowseNames.ValveType, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                new NodeId(Opc.Ua.Sample.ObjectTypes.GenericActuatorType, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)));
                    
            server.TypeSources.SetTypeSource(this.NodeId, this);
        }

        /// <summary>
        /// Finds the source for the type definition (creates it if it does not exist).
        /// </summary>
        public static new ValveType FindSource(IServerInternal server)
        {
            ValveType type = null;
                    
            lock (server.TypeSources.SyncRoot)
            {
                NodeId typeId = new NodeId(Opc.Ua.Sample.ObjectTypes.ValveType, server.NamespaceUris.GetIndexOrAppend(Opc.Ua.Sample.Namespaces.Sample));

                type = server.TypeSources.FindTypeSource(typeId) as ValveType;

                if (type != null)
                {
                    return type;
                }

                type = new ValveType(server);
            }

            return type;
        }
        #endregion
             
        #region ICloneable Members
        /// <summary cref="NodeSource.Clone(NodeSource)" />
        public override NodeSource Clone(NodeSource parent)
        {
            lock (DataLock)
            {
                ValveType clone = new ValveType(Server);
                clone.Initialize(this);
                return clone;
            }
        }
        #endregion
      
        #region Public Properties
        #endregion

        #region Overridden Methods
        /// <summary cref="NodeSource.Initialize(NodeSource)" />
        public override void Initialize(NodeSource source)
        {
            lock (DataLock)
            {
                base.Initialize(source);
                
                ValveType type = source as ValveType;

            }
        }

        /// <summary cref="NodeSource.InitializeChildren" />
        protected override void InitializeChildren()
        {
            base.InitializeChildren();
                
        }
        #endregion

        #region Private Fields
        #endregion
    }
    #endregion

    #region Valve Class
    /// <summary>
    /// Represents an instance of the ValveType ObjectType in the address space.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class Valve : GenericActuator
    {
        #region Constructors
        /// <summary>
        /// Initializes the object with default values.
        /// </summary>
        protected Valve(IServerInternal server, NodeSource parent) 
        : 
            base(server, parent)
        {
            m_typeDefinition = ValveType.FindSource(server);
        }

        /// <summary>
        /// Creates a new instance of the node.
        /// </summary>
        public static new Valve Construct(
            IServerInternal server, 
            NodeSource      parent, 
            NodeId          referenceTypeId,
            NodeId          nodeId,
            QualifiedName   browseName,
            uint            numericId)
        {
            Valve instance = new Valve(server, parent);
            instance.Initialize(referenceTypeId, nodeId, browseName, numericId, instance.m_typeDefinition.NodeId);
            return instance;
        }

        /// <summary>
        /// Creates a new instance of the node without any parent.
        /// </summary>
        public static new Valve Construct(IServerInternal server)
        {
            Valve instance = new Valve(server, (NodeSource)null);
            instance.Initialize(null, null, null, 0, instance.m_typeDefinition.NodeId);
            return instance;
        }
        #endregion
           
        #region ICloneable Members
        /// <summary cref="NodeSource.Clone(NodeSource)" />
        public override NodeSource Clone(NodeSource parent)
        {
            lock (DataLock)
            {
                Valve clone = new Valve(Server, parent);
                clone.Initialize(this);
                return clone;
            } 
        }
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        /// <summary cref="NodeSource.Initialize(NodeSource)" />
        public override void Initialize(NodeSource source)
        {
            lock (DataLock)
            {            
                Valve instance = source as Valve;

                if (instance != null)
                {
                    base.Initialize(source);
                }

                ValveType type = source as ValveType;

            }
        }

        /// <summary cref="NodeSource.InitializeChildren" />
        protected override void InitializeChildren()
        {
            base.InitializeChildren();
                
        }
        #endregion

        #region Private Fields
        private ValveType m_typeDefinition;
        #endregion
    }
    #endregion

    #region LevelControllerType Class
    /// <summary>
    /// Represents the LevelControllerType ObjectType in the address space.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class LevelControllerType : ObjectTypeSource
    {
        #region Constructors
        /// <summary>
        /// Initializes the object with default values.
        /// </summary>
        public LevelControllerType(IServerInternal server) : base(server)
        {
            Initialize(
                new NodeId(Opc.Ua.Sample.ObjectTypes.LevelControllerType, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                new QualifiedName(Opc.Ua.Sample.BrowseNames.LevelControllerType, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                new NodeId(Opc.Ua.Sample.ObjectTypes.GenericControllerType, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)));
                    
            server.TypeSources.SetTypeSource(this.NodeId, this);
        }

        /// <summary>
        /// Finds the source for the type definition (creates it if it does not exist).
        /// </summary>
        public static new LevelControllerType FindSource(IServerInternal server)
        {
            LevelControllerType type = null;
                    
            lock (server.TypeSources.SyncRoot)
            {
                NodeId typeId = new NodeId(Opc.Ua.Sample.ObjectTypes.LevelControllerType, server.NamespaceUris.GetIndexOrAppend(Opc.Ua.Sample.Namespaces.Sample));

                type = server.TypeSources.FindTypeSource(typeId) as LevelControllerType;

                if (type != null)
                {
                    return type;
                }

                type = new LevelControllerType(server);
            }

            return type;
        }
        #endregion
             
        #region ICloneable Members
        /// <summary cref="NodeSource.Clone(NodeSource)" />
        public override NodeSource Clone(NodeSource parent)
        {
            lock (DataLock)
            {
                LevelControllerType clone = new LevelControllerType(Server);
                clone.Initialize(this);
                return clone;
            }
        }
        #endregion
      
        #region Public Properties
        #endregion

        #region Overridden Methods
        /// <summary cref="NodeSource.Initialize(NodeSource)" />
        public override void Initialize(NodeSource source)
        {
            lock (DataLock)
            {
                base.Initialize(source);
                
                LevelControllerType type = source as LevelControllerType;

            }
        }

        /// <summary cref="NodeSource.InitializeChildren" />
        protected override void InitializeChildren()
        {
            base.InitializeChildren();
                
        }
        #endregion

        #region Private Fields
        #endregion
    }
    #endregion

    #region LevelController Class
    /// <summary>
    /// Represents an instance of the LevelControllerType ObjectType in the address space.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class LevelController : GenericController
    {
        #region Constructors
        /// <summary>
        /// Initializes the object with default values.
        /// </summary>
        protected LevelController(IServerInternal server, NodeSource parent) 
        : 
            base(server, parent)
        {
            m_typeDefinition = LevelControllerType.FindSource(server);
        }

        /// <summary>
        /// Creates a new instance of the node.
        /// </summary>
        public static new LevelController Construct(
            IServerInternal server, 
            NodeSource      parent, 
            NodeId          referenceTypeId,
            NodeId          nodeId,
            QualifiedName   browseName,
            uint            numericId)
        {
            LevelController instance = new LevelController(server, parent);
            instance.Initialize(referenceTypeId, nodeId, browseName, numericId, instance.m_typeDefinition.NodeId);
            return instance;
        }

        /// <summary>
        /// Creates a new instance of the node without any parent.
        /// </summary>
        public static new LevelController Construct(IServerInternal server)
        {
            LevelController instance = new LevelController(server, (NodeSource)null);
            instance.Initialize(null, null, null, 0, instance.m_typeDefinition.NodeId);
            return instance;
        }
        #endregion
           
        #region ICloneable Members
        /// <summary cref="NodeSource.Clone(NodeSource)" />
        public override NodeSource Clone(NodeSource parent)
        {
            lock (DataLock)
            {
                LevelController clone = new LevelController(Server, parent);
                clone.Initialize(this);
                return clone;
            } 
        }
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        /// <summary cref="NodeSource.Initialize(NodeSource)" />
        public override void Initialize(NodeSource source)
        {
            lock (DataLock)
            {            
                LevelController instance = source as LevelController;

                if (instance != null)
                {
                    base.Initialize(source);
                }

                LevelControllerType type = source as LevelControllerType;

            }
        }

        /// <summary cref="NodeSource.InitializeChildren" />
        protected override void InitializeChildren()
        {
            base.InitializeChildren();
                
        }
        #endregion

        #region Private Fields
        private LevelControllerType m_typeDefinition;
        #endregion
    }
    #endregion

    #region FlowControllerType Class
    /// <summary>
    /// Represents the FlowControllerType ObjectType in the address space.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class FlowControllerType : ObjectTypeSource
    {
        #region Constructors
        /// <summary>
        /// Initializes the object with default values.
        /// </summary>
        public FlowControllerType(IServerInternal server) : base(server)
        {
            Initialize(
                new NodeId(Opc.Ua.Sample.ObjectTypes.FlowControllerType, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                new QualifiedName(Opc.Ua.Sample.BrowseNames.FlowControllerType, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                new NodeId(Opc.Ua.Sample.ObjectTypes.GenericControllerType, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)));
                    
            server.TypeSources.SetTypeSource(this.NodeId, this);
        }

        /// <summary>
        /// Finds the source for the type definition (creates it if it does not exist).
        /// </summary>
        public static new FlowControllerType FindSource(IServerInternal server)
        {
            FlowControllerType type = null;
                    
            lock (server.TypeSources.SyncRoot)
            {
                NodeId typeId = new NodeId(Opc.Ua.Sample.ObjectTypes.FlowControllerType, server.NamespaceUris.GetIndexOrAppend(Opc.Ua.Sample.Namespaces.Sample));

                type = server.TypeSources.FindTypeSource(typeId) as FlowControllerType;

                if (type != null)
                {
                    return type;
                }

                type = new FlowControllerType(server);
            }

            return type;
        }
        #endregion
             
        #region ICloneable Members
        /// <summary cref="NodeSource.Clone(NodeSource)" />
        public override NodeSource Clone(NodeSource parent)
        {
            lock (DataLock)
            {
                FlowControllerType clone = new FlowControllerType(Server);
                clone.Initialize(this);
                return clone;
            }
        }
        #endregion
      
        #region Public Properties
        #endregion

        #region Overridden Methods
        /// <summary cref="NodeSource.Initialize(NodeSource)" />
        public override void Initialize(NodeSource source)
        {
            lock (DataLock)
            {
                base.Initialize(source);
                
                FlowControllerType type = source as FlowControllerType;

            }
        }

        /// <summary cref="NodeSource.InitializeChildren" />
        protected override void InitializeChildren()
        {
            base.InitializeChildren();
                
        }
        #endregion

        #region Private Fields
        #endregion
    }
    #endregion

    #region FlowController Class
    /// <summary>
    /// Represents an instance of the FlowControllerType ObjectType in the address space.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class FlowController : GenericController
    {
        #region Constructors
        /// <summary>
        /// Initializes the object with default values.
        /// </summary>
        protected FlowController(IServerInternal server, NodeSource parent) 
        : 
            base(server, parent)
        {
            m_typeDefinition = FlowControllerType.FindSource(server);
        }

        /// <summary>
        /// Creates a new instance of the node.
        /// </summary>
        public static new FlowController Construct(
            IServerInternal server, 
            NodeSource      parent, 
            NodeId          referenceTypeId,
            NodeId          nodeId,
            QualifiedName   browseName,
            uint            numericId)
        {
            FlowController instance = new FlowController(server, parent);
            instance.Initialize(referenceTypeId, nodeId, browseName, numericId, instance.m_typeDefinition.NodeId);
            return instance;
        }

        /// <summary>
        /// Creates a new instance of the node without any parent.
        /// </summary>
        public static new FlowController Construct(IServerInternal server)
        {
            FlowController instance = new FlowController(server, (NodeSource)null);
            instance.Initialize(null, null, null, 0, instance.m_typeDefinition.NodeId);
            return instance;
        }
        #endregion
           
        #region ICloneable Members
        /// <summary cref="NodeSource.Clone(NodeSource)" />
        public override NodeSource Clone(NodeSource parent)
        {
            lock (DataLock)
            {
                FlowController clone = new FlowController(Server, parent);
                clone.Initialize(this);
                return clone;
            } 
        }
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        /// <summary cref="NodeSource.Initialize(NodeSource)" />
        public override void Initialize(NodeSource source)
        {
            lock (DataLock)
            {            
                FlowController instance = source as FlowController;

                if (instance != null)
                {
                    base.Initialize(source);
                }

                FlowControllerType type = source as FlowControllerType;

            }
        }

        /// <summary cref="NodeSource.InitializeChildren" />
        protected override void InitializeChildren()
        {
            base.InitializeChildren();
                
        }
        #endregion

        #region Private Fields
        private FlowControllerType m_typeDefinition;
        #endregion
    }
    #endregion

    #region LevelIndicatorType Class
    /// <summary>
    /// Represents the LevelIndicatorType ObjectType in the address space.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class LevelIndicatorType : ObjectTypeSource
    {
        #region Constructors
        /// <summary>
        /// Initializes the object with default values.
        /// </summary>
        public LevelIndicatorType(IServerInternal server) : base(server)
        {
            Initialize(
                new NodeId(Opc.Ua.Sample.ObjectTypes.LevelIndicatorType, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                new QualifiedName(Opc.Ua.Sample.BrowseNames.LevelIndicatorType, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                new NodeId(Opc.Ua.Sample.ObjectTypes.GenericSensorType, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)));
                    
            server.TypeSources.SetTypeSource(this.NodeId, this);
        }

        /// <summary>
        /// Finds the source for the type definition (creates it if it does not exist).
        /// </summary>
        public static new LevelIndicatorType FindSource(IServerInternal server)
        {
            LevelIndicatorType type = null;
                    
            lock (server.TypeSources.SyncRoot)
            {
                NodeId typeId = new NodeId(Opc.Ua.Sample.ObjectTypes.LevelIndicatorType, server.NamespaceUris.GetIndexOrAppend(Opc.Ua.Sample.Namespaces.Sample));

                type = server.TypeSources.FindTypeSource(typeId) as LevelIndicatorType;

                if (type != null)
                {
                    return type;
                }

                type = new LevelIndicatorType(server);
            }

            return type;
        }
        #endregion
             
        #region ICloneable Members
        /// <summary cref="NodeSource.Clone(NodeSource)" />
        public override NodeSource Clone(NodeSource parent)
        {
            lock (DataLock)
            {
                LevelIndicatorType clone = new LevelIndicatorType(Server);
                clone.Initialize(this);
                return clone;
            }
        }
        #endregion
      
        #region Public Properties
        #endregion

        #region Overridden Methods
        /// <summary cref="NodeSource.Initialize(NodeSource)" />
        public override void Initialize(NodeSource source)
        {
            lock (DataLock)
            {
                base.Initialize(source);
                
                LevelIndicatorType type = source as LevelIndicatorType;

            }
        }

        /// <summary cref="NodeSource.InitializeChildren" />
        protected override void InitializeChildren()
        {
            base.InitializeChildren();
                
        }
        #endregion

        #region Private Fields
        #endregion
    }
    #endregion

    #region LevelIndicator Class
    /// <summary>
    /// Represents an instance of the LevelIndicatorType ObjectType in the address space.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class LevelIndicator : GenericSensor
    {
        #region Constructors
        /// <summary>
        /// Initializes the object with default values.
        /// </summary>
        protected LevelIndicator(IServerInternal server, NodeSource parent) 
        : 
            base(server, parent)
        {
            m_typeDefinition = LevelIndicatorType.FindSource(server);
        }

        /// <summary>
        /// Creates a new instance of the node.
        /// </summary>
        public static new LevelIndicator Construct(
            IServerInternal server, 
            NodeSource      parent, 
            NodeId          referenceTypeId,
            NodeId          nodeId,
            QualifiedName   browseName,
            uint            numericId)
        {
            LevelIndicator instance = new LevelIndicator(server, parent);
            instance.Initialize(referenceTypeId, nodeId, browseName, numericId, instance.m_typeDefinition.NodeId);
            return instance;
        }

        /// <summary>
        /// Creates a new instance of the node without any parent.
        /// </summary>
        public static new LevelIndicator Construct(IServerInternal server)
        {
            LevelIndicator instance = new LevelIndicator(server, (NodeSource)null);
            instance.Initialize(null, null, null, 0, instance.m_typeDefinition.NodeId);
            return instance;
        }
        #endregion
           
        #region ICloneable Members
        /// <summary cref="NodeSource.Clone(NodeSource)" />
        public override NodeSource Clone(NodeSource parent)
        {
            lock (DataLock)
            {
                LevelIndicator clone = new LevelIndicator(Server, parent);
                clone.Initialize(this);
                return clone;
            } 
        }
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        /// <summary cref="NodeSource.Initialize(NodeSource)" />
        public override void Initialize(NodeSource source)
        {
            lock (DataLock)
            {            
                LevelIndicator instance = source as LevelIndicator;

                if (instance != null)
                {
                    base.Initialize(source);
                }

                LevelIndicatorType type = source as LevelIndicatorType;

            }
        }

        /// <summary cref="NodeSource.InitializeChildren" />
        protected override void InitializeChildren()
        {
            base.InitializeChildren();
                
        }
        #endregion

        #region Private Fields
        private LevelIndicatorType m_typeDefinition;
        #endregion
    }
    #endregion

    #region FlowTransmitterType Class
    /// <summary>
    /// Represents the FlowTransmitterType ObjectType in the address space.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class FlowTransmitterType : ObjectTypeSource
    {
        #region Constructors
        /// <summary>
        /// Initializes the object with default values.
        /// </summary>
        public FlowTransmitterType(IServerInternal server) : base(server)
        {
            Initialize(
                new NodeId(Opc.Ua.Sample.ObjectTypes.FlowTransmitterType, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                new QualifiedName(Opc.Ua.Sample.BrowseNames.FlowTransmitterType, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                new NodeId(Opc.Ua.Sample.ObjectTypes.GenericSensorType, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)));
                    
            server.TypeSources.SetTypeSource(this.NodeId, this);
        }

        /// <summary>
        /// Finds the source for the type definition (creates it if it does not exist).
        /// </summary>
        public static new FlowTransmitterType FindSource(IServerInternal server)
        {
            FlowTransmitterType type = null;
                    
            lock (server.TypeSources.SyncRoot)
            {
                NodeId typeId = new NodeId(Opc.Ua.Sample.ObjectTypes.FlowTransmitterType, server.NamespaceUris.GetIndexOrAppend(Opc.Ua.Sample.Namespaces.Sample));

                type = server.TypeSources.FindTypeSource(typeId) as FlowTransmitterType;

                if (type != null)
                {
                    return type;
                }

                type = new FlowTransmitterType(server);
            }

            return type;
        }
        #endregion
             
        #region ICloneable Members
        /// <summary cref="NodeSource.Clone(NodeSource)" />
        public override NodeSource Clone(NodeSource parent)
        {
            lock (DataLock)
            {
                FlowTransmitterType clone = new FlowTransmitterType(Server);
                clone.Initialize(this);
                return clone;
            }
        }
        #endregion
      
        #region Public Properties
        #endregion

        #region Overridden Methods
        /// <summary cref="NodeSource.Initialize(NodeSource)" />
        public override void Initialize(NodeSource source)
        {
            lock (DataLock)
            {
                base.Initialize(source);
                
                FlowTransmitterType type = source as FlowTransmitterType;

            }
        }

        /// <summary cref="NodeSource.InitializeChildren" />
        protected override void InitializeChildren()
        {
            base.InitializeChildren();
                
        }
        #endregion

        #region Private Fields
        #endregion
    }
    #endregion

    #region FlowTransmitter Class
    /// <summary>
    /// Represents an instance of the FlowTransmitterType ObjectType in the address space.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class FlowTransmitter : GenericSensor
    {
        #region Constructors
        /// <summary>
        /// Initializes the object with default values.
        /// </summary>
        protected FlowTransmitter(IServerInternal server, NodeSource parent) 
        : 
            base(server, parent)
        {
            m_typeDefinition = FlowTransmitterType.FindSource(server);
        }

        /// <summary>
        /// Creates a new instance of the node.
        /// </summary>
        public static new FlowTransmitter Construct(
            IServerInternal server, 
            NodeSource      parent, 
            NodeId          referenceTypeId,
            NodeId          nodeId,
            QualifiedName   browseName,
            uint            numericId)
        {
            FlowTransmitter instance = new FlowTransmitter(server, parent);
            instance.Initialize(referenceTypeId, nodeId, browseName, numericId, instance.m_typeDefinition.NodeId);
            return instance;
        }

        /// <summary>
        /// Creates a new instance of the node without any parent.
        /// </summary>
        public static new FlowTransmitter Construct(IServerInternal server)
        {
            FlowTransmitter instance = new FlowTransmitter(server, (NodeSource)null);
            instance.Initialize(null, null, null, 0, instance.m_typeDefinition.NodeId);
            return instance;
        }
        #endregion
           
        #region ICloneable Members
        /// <summary cref="NodeSource.Clone(NodeSource)" />
        public override NodeSource Clone(NodeSource parent)
        {
            lock (DataLock)
            {
                FlowTransmitter clone = new FlowTransmitter(Server, parent);
                clone.Initialize(this);
                return clone;
            } 
        }
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        /// <summary cref="NodeSource.Initialize(NodeSource)" />
        public override void Initialize(NodeSource source)
        {
            lock (DataLock)
            {            
                FlowTransmitter instance = source as FlowTransmitter;

                if (instance != null)
                {
                    base.Initialize(source);
                }

                FlowTransmitterType type = source as FlowTransmitterType;

            }
        }

        /// <summary cref="NodeSource.InitializeChildren" />
        protected override void InitializeChildren()
        {
            base.InitializeChildren();
                
        }
        #endregion

        #region Private Fields
        private FlowTransmitterType m_typeDefinition;
        #endregion
    }
    #endregion

    #region AcmeFlowTransmitterType Class
    /// <summary>
    /// Represents the AcmeFlowTransmitterType ObjectType in the address space.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class AcmeFlowTransmitterType : ObjectTypeSource
    {
        #region Constructors
        /// <summary>
        /// Initializes the object with default values.
        /// </summary>
        public AcmeFlowTransmitterType(IServerInternal server) : base(server)
        {
            Initialize(
                new NodeId(Opc.Ua.Sample.ObjectTypes.AcmeFlowTransmitterType, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                new QualifiedName(Opc.Ua.Sample.BrowseNames.AcmeFlowTransmitterType, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                new NodeId(Opc.Ua.Sample.ObjectTypes.FlowTransmitterType, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)));
                    
            server.TypeSources.SetTypeSource(this.NodeId, this);
        }

        /// <summary>
        /// Finds the source for the type definition (creates it if it does not exist).
        /// </summary>
        public static new AcmeFlowTransmitterType FindSource(IServerInternal server)
        {
            AcmeFlowTransmitterType type = null;
                    
            lock (server.TypeSources.SyncRoot)
            {
                NodeId typeId = new NodeId(Opc.Ua.Sample.ObjectTypes.AcmeFlowTransmitterType, server.NamespaceUris.GetIndexOrAppend(Opc.Ua.Sample.Namespaces.Sample));

                type = server.TypeSources.FindTypeSource(typeId) as AcmeFlowTransmitterType;

                if (type != null)
                {
                    return type;
                }

                type = new AcmeFlowTransmitterType(server);
            }

            return type;
        }
        #endregion
             
        #region ICloneable Members
        /// <summary cref="NodeSource.Clone(NodeSource)" />
        public override NodeSource Clone(NodeSource parent)
        {
            lock (DataLock)
            {
                AcmeFlowTransmitterType clone = new AcmeFlowTransmitterType(Server);
                clone.Initialize(this);
                return clone;
            }
        }
        #endregion
      
        #region Public Properties
        #region SerialNumber
        /// <summary>
        /// A description for the SerialNumber Property.
        /// </summary>
        public Property<string> SerialNumber
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_serialNumber; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_serialNumber != null)
                    {
                        RemoveChild(m_serialNumber);
                    }

                    m_serialNumber = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceSerialNumber(Property<string> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                SerialNumber = replacement;

                SerialNumber.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.SerialNumber, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.AcmeFlowTransmitterType_SerialNumber,
                    null);
            }
        }
        #endregion

        #region Documentation
        /// <summary>
        /// A description for the Documentation Property.
        /// </summary>
        public Property<LocalizedText> Documentation
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_documentation; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_documentation != null)
                    {
                        RemoveChild(m_documentation);
                    }

                    m_documentation = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceDocumentation(Property<LocalizedText> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                Documentation = replacement;

                Documentation.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.Documentation, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.AcmeFlowTransmitterType_Documentation,
                    null);
            }
        }
        #endregion

        #region CalibrationParameters
        /// <summary>
        /// A description for the CalibrationParameters Property.
        /// </summary>
        public Property<IList<double>> CalibrationParameters
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_calibrationParameters; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_calibrationParameters != null)
                    {
                        RemoveChild(m_calibrationParameters);
                    }

                    m_calibrationParameters = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceCalibrationParameters(Property<IList<double>> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                CalibrationParameters = replacement;

                CalibrationParameters.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.CalibrationParameters, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.AcmeFlowTransmitterType_CalibrationParameters,
                    null);
            }
        }
        #endregion

        #region CalibrateMethod
        /// <summary>
        /// A description for the Calibrate Method.
        /// </summary>
        public AcmeFlowTransmitterType.CalibrateMethodSource CalibrateMethod
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_calibrateMethod; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_calibrateMethod != null)
                    {
                        RemoveChild(m_calibrateMethod);
                    }

                    m_calibrateMethod = value; 
                }
            }
        }
            
        /// <summary>
        /// Calls the Calibrate method.
        /// </summary>
        public string Calibrate(
            OperationContext context,
            double           scanRate,
            double           duration)
        {     
            lock (DataLock)
            {     
                return CalibrateMethod.Call(
                    context,
                    this,
                    scanRate,
                    duration);
            }
        }
            
        /// <summary>
        /// Sets the callback to use when the Calibrate method is called.
        /// </summary>
        public void SetCalibrateCallback(AcmeFlowTransmitterType.CalibrateMethodHandler callback)
        {
            lock (DataLock)
            {  
                CalibrateMethod.SetCallback(this, callback);
            }
        }
        #endregion
        #endregion
        
        #region Method Declarations
        #region CalibrateMethodSource Class
        /// <summary>
        /// Implements a method which may be used by many nodes.
        /// </summary>
        public partial class CalibrateMethodSource : MethodSource
        {
            #region Constructors
            /// <summary>
            /// Initializes the object with default values.
            /// </summary>
            public CalibrateMethodSource(IServerInternal server, NodeSource parent) : base(server, parent)
            {
                Arguments = CreateArguments();
            }
            
            /// <summary>
            /// Creates a new instance of the node.
            /// </summary>
            public static new CalibrateMethodSource Construct(
                IServerInternal server, 
                NodeSource      parent, 
                NodeId          referenceTypeId,
                NodeId          nodeId,
                QualifiedName   browseName,
                uint            numericId)
            {
                CalibrateMethodSource instance = new CalibrateMethodSource(server, parent);
                instance.Initialize(referenceTypeId, nodeId, browseName, numericId, null);
                return instance;
            }
            #endregion
             
            #region ICloneable Members
            /// <summary cref="NodeSource.Clone(NodeSource)" />
            public override NodeSource Clone(NodeSource parent)
            {
                lock (DataLock)
                {
                    CalibrateMethodSource clone = new CalibrateMethodSource(Server, parent);
                    clone.Initialize(this);
                    return clone;
                }
            }
            #endregion

            #region Public Interface
            /// <summary>
            /// Calls the Calibrate method.
            /// </summary>
            public string Call(
                OperationContext context,
                NodeSource       target,
                double           scanRate,
                double           duration)
            {    
                List<object> inputArguments = new List<object>();
                List<ServiceResult> argumentErrors = new List<ServiceResult>();
                List<object> outputArguments = new List<object>();
                
                inputArguments.Add(scanRate);
                inputArguments.Add(duration);

                ServiceResult result = Call(
                    context, 
                    NodeId, 
                    null, 
                    Parent.NodeId, 
                    inputArguments, 
                    argumentErrors, 
                    outputArguments);

                if (ServiceResult.IsBad(result))
                {
                    throw new ServiceResultException(result);
                }
                    
                return (string)outputArguments[0];
            }
            #endregion
            
            #region Protected Methods
            /// <summary>
            /// Called when the Calibrate method is called.
            /// </summary>
            protected override void Call(
                OperationContext     context, 
                NodeSource           target,
                Delegate             methodToCall,
                IList<object>        inputArguments,
                IList<ServiceResult> argumentErrors,
                IList<object>        outputArguments)
            {
                CalibrateMethodHandler Callback = methodToCall as CalibrateMethodHandler;

                if (Callback == null)
                {
                    base.Call(context, target, methodToCall, inputArguments, argumentErrors, outputArguments);
                    return;
                }

                double scanRate = (double)inputArguments[0];
                double duration = (double)inputArguments[1];
                string report = (string)null;

                report = Callback(
                    context,
                    target,
                    scanRate,
                    duration);
                
                outputArguments.Add(report);
            }

            /// <summary>
            /// Creates the arguments for the Calibrate method.
            /// </summary>
            protected MethodArguments CreateArguments()
            {
                MethodArguments arguments = new MethodArguments();

                Argument argument = null;
                
                // ScanRate
                argument = new Argument();

                argument.Name = "ScanRate";
                argument.DataType = Opc.Ua.DataTypes.Double;
                argument.ValueRank = ValueRanks.Scalar;
                argument.Description = new LocalizedText("AcmeFlowTransmitterType_Calibrate_InputArgument_ScanRate_Description", "en", "How frequently to scan values when calibrating.");

                arguments.Input.Add(argument);

                // Duration
                argument = new Argument();

                argument.Name = "Duration";
                argument.DataType = Opc.Ua.DataTypes.Double;
                argument.ValueRank = ValueRanks.Scalar;
                argument.Description = new LocalizedText("AcmeFlowTransmitterType_Calibrate_InputArgument_Duration_Description", "en", "The duration of the calibration cycle in seconds.");

                arguments.Input.Add(argument);
                
                // Report
                argument = new Argument();

                argument.Name = "Report";
                argument.DataType = Opc.Ua.DataTypes.String;
                argument.ValueRank = ValueRanks.Scalar;
                argument.Description = new LocalizedText("AcmeFlowTransmitterType_Calibrate_OutputArgument_Report_Description", "en", "A text report containing the calibration parameters.");

                arguments.Output.Add(argument);

                return arguments;
            }
            #endregion
        }

        /// <summary>
        /// A delegate used to receive notifications when the method is called.
        /// </summary>
        public delegate string CalibrateMethodHandler(
            OperationContext context,
            NodeSource       target,
            double           scanRate,
            double           duration);
        #endregion
        #endregion

        #region Overridden Methods
        /// <summary cref="NodeSource.Initialize(NodeSource)" />
        public override void Initialize(NodeSource source)
        {
            lock (DataLock)
            {
                base.Initialize(source);
                
                AcmeFlowTransmitterType type = source as AcmeFlowTransmitterType;

                if (type != null && type.SerialNumber != null)
                {
                    SerialNumber = (Property<string>)type.SerialNumber.Clone(this);
                    SerialNumber.Initialize(type.SerialNumber);
                }

                if (type != null && type.Documentation != null)
                {
                    Documentation = (Property<LocalizedText>)type.Documentation.Clone(this);
                    Documentation.Initialize(type.Documentation);
                }

                if (type != null && type.CalibrationParameters != null)
                {
                    CalibrationParameters = (Property<IList<double>>)type.CalibrationParameters.Clone(this);
                    CalibrationParameters.Initialize(type.CalibrationParameters);
                }
            }
        }

        /// <summary cref="NodeSource.InitializeChildren" />
        protected override void InitializeChildren()
        {
            base.InitializeChildren();
                
            m_serialNumber = Property<string>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.AcmeFlowTransmitterType_SerialNumber, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.SerialNumber, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.AcmeFlowTransmitterType_SerialNumber);

            m_documentation = Property<LocalizedText>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.AcmeFlowTransmitterType_Documentation, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.Documentation, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.AcmeFlowTransmitterType_Documentation);

            m_calibrationParameters = Property<IList<double>>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.AcmeFlowTransmitterType_CalibrationParameters, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.CalibrationParameters, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.AcmeFlowTransmitterType_CalibrationParameters);

            m_calibrateMethod = AcmeFlowTransmitterType.CalibrateMethodSource.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Methods.AcmeFlowTransmitterType_Calibrate, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.Calibrate, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Methods.AcmeFlowTransmitterType_Calibrate);
        }
        #endregion

        #region Private Fields
        Property<string> m_serialNumber;
        Property<LocalizedText> m_documentation;
        Property<IList<double>> m_calibrationParameters;
        AcmeFlowTransmitterType.CalibrateMethodSource m_calibrateMethod;
        #endregion
    }
    #endregion

    #region AcmeFlowTransmitter Class
    /// <summary>
    /// Represents an instance of the AcmeFlowTransmitterType ObjectType in the address space.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class AcmeFlowTransmitter : FlowTransmitter
    {
        #region Constructors
        /// <summary>
        /// Initializes the object with default values.
        /// </summary>
        protected AcmeFlowTransmitter(IServerInternal server, NodeSource parent) 
        : 
            base(server, parent)
        {
            m_typeDefinition = AcmeFlowTransmitterType.FindSource(server);
        }

        /// <summary>
        /// Creates a new instance of the node.
        /// </summary>
        public static new AcmeFlowTransmitter Construct(
            IServerInternal server, 
            NodeSource      parent, 
            NodeId          referenceTypeId,
            NodeId          nodeId,
            QualifiedName   browseName,
            uint            numericId)
        {
            AcmeFlowTransmitter instance = new AcmeFlowTransmitter(server, parent);
            instance.Initialize(referenceTypeId, nodeId, browseName, numericId, instance.m_typeDefinition.NodeId);
            return instance;
        }

        /// <summary>
        /// Creates a new instance of the node without any parent.
        /// </summary>
        public static new AcmeFlowTransmitter Construct(IServerInternal server)
        {
            AcmeFlowTransmitter instance = new AcmeFlowTransmitter(server, (NodeSource)null);
            instance.Initialize(null, null, null, 0, instance.m_typeDefinition.NodeId);
            return instance;
        }
        #endregion
           
        #region ICloneable Members
        /// <summary cref="NodeSource.Clone(NodeSource)" />
        public override NodeSource Clone(NodeSource parent)
        {
            lock (DataLock)
            {
                AcmeFlowTransmitter clone = new AcmeFlowTransmitter(Server, parent);
                clone.Initialize(this);
                return clone;
            } 
        }
        #endregion

        #region Public Properties
        #region SerialNumber
        /// <summary>
        /// A description for the SerialNumber Property.
        /// </summary>
        public Property<string> SerialNumber
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_serialNumber; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_serialNumber != null)
                    {
                        RemoveChild(m_serialNumber);
                    }

                    m_serialNumber = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceSerialNumber(Property<string> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                SerialNumber = replacement;

                SerialNumber.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.SerialNumber, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.AcmeFlowTransmitterType_SerialNumber,
                    null);
            }
        }
        #endregion

        #region Documentation
            /// <summary>
        /// A description for the Documentation Property.
        /// </summary>
        public Property<LocalizedText> Documentation
        {
        	get 
            {
                lock (DataLock)
                {
                    if (DocumentationReplaced)
                    {
                        return m_documentation;
                    }

                    if (m_typeDefinition != null)
                    {
                        return m_typeDefinition.Documentation;
                    }

                    return null;
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_documentation != null)
                    {
                        RemoveChild(m_documentation);
                    }

                    m_documentation = value; 
                }
            }
        }

        /// <summary>
        /// Whether the shared Documentation node has been replaced for node.
        /// </summary>
        public bool DocumentationReplaced
        {
        	get 
            { 
                lock (DataLock)
                {
                    return m_documentation != null && m_documentation.Parent == this; 
                }
            }
        }

        /// <summary>
        /// Replaces the shared child with another node.
        /// </summary>
        public void ReplaceDocumentation(Property<LocalizedText> replacement)
        {
            CheckNodeManagerState();

            lock (DataLock)
            {
                if (DocumentationReplaced)
                {
                    Documentation = (Property<LocalizedText>)DeleteReplacedChild(m_documentation);
                }

                if (replacement != null)
                {
                    Documentation = replacement;

                    Documentation.Create(
                        this.NodeId, 
                        new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                        null,
                        new QualifiedName(Opc.Ua.Sample.BrowseNames.Documentation, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                        Opc.Ua.Sample.Variables.AcmeFlowTransmitterType_Documentation,
                        null);
                }
            }
        }
        #endregion

        #region CalibrationParameters
        /// <summary>
        /// A description for the CalibrationParameters Property.
        /// </summary>
        public Property<IList<double>> CalibrationParameters
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_calibrationParameters; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_calibrationParameters != null)
                    {
                        RemoveChild(m_calibrationParameters);
                    }

                    m_calibrationParameters = value; 
                }
            }
        }

        /// <summary>
        /// Whether the CalibrationParameters node is specified for the node.
        /// </summary>
        public bool CalibrationParametersSpecified
        {
        	get 
            { 
                lock (DataLock)
                {
                    return m_calibrationParameters != null; 
                }
            }
        }

        /// <summary>
        /// Specifies the optional child.
        /// </summary>
        public void SpecifyCalibrationParameters(Property<IList<double>> replacement)
        {
            CheckNodeManagerState();

            lock (DataLock)
            {
                if (CalibrationParametersSpecified)
                {
                    CalibrationParameters = (Property<IList<double>>)DeleteChild(m_calibrationParameters);
                }

                if (replacement != null)
                {       
                    CalibrationParameters = replacement;

                    CalibrationParameters.Create(
                        this.NodeId, 
                        new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                        null,
                        new QualifiedName(Opc.Ua.Sample.BrowseNames.CalibrationParameters, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                        Opc.Ua.Sample.Variables.AcmeFlowTransmitterType_CalibrationParameters,
                        null);
                }
            }
        }
        #endregion

        #region CalibrateMethod
        /// <summary>
        /// A description for the Calibrate Method.
        /// </summary>
        public AcmeFlowTransmitterType.CalibrateMethodSource CalibrateMethod
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_calibrateMethod; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_calibrateMethod != null)
                    {
                        RemoveChild(m_calibrateMethod);
                    }

                    m_calibrateMethod = value; 
                }
            }
        }
            
        /// <summary>
        /// Calls the Calibrate method.
        /// </summary>
        public string Calibrate(
            OperationContext context,
            double           scanRate,
            double           duration)
        {     
            lock (DataLock)
            {     
                return CalibrateMethod.Call(
                    context,
                    this,
                    scanRate,
                    duration);
            }
        }
            
        /// <summary>
        /// Sets the callback to use when the Calibrate method is called.
        /// </summary>
        public void SetCalibrateCallback(AcmeFlowTransmitterType.CalibrateMethodHandler callback)
        {
            lock (DataLock)
            {  
                CalibrateMethod.SetCallback(this, callback);
            }
        }
        #endregion
        #endregion

        #region Overridden Methods
        /// <summary cref="NodeSource.Initialize(NodeSource)" />
        public override void Initialize(NodeSource source)
        {
            lock (DataLock)
            {            
                AcmeFlowTransmitter instance = source as AcmeFlowTransmitter;

                if (instance != null)
                {
                    base.Initialize(source);
                }

                AcmeFlowTransmitterType type = source as AcmeFlowTransmitterType;

                if (type != null && type.SerialNumber != null)
                {
                    SerialNumber = (Property<string>)type.SerialNumber.Clone(this);
                    SerialNumber.Initialize(type.SerialNumber);
                }
                else if (instance != null && instance.SerialNumber != null)
                {
                    SerialNumber = (Property<string>)instance.SerialNumber.Clone(this);
                    SerialNumber.Initialize(instance.SerialNumber);
                }

                if (type != null && type.Documentation != null)
                {
                    Documentation = (Property<LocalizedText>)type.Documentation.Clone(this);
                    Documentation.Initialize(type.Documentation);
                }
                else if (instance != null && instance.Documentation != null)
                {
                    Documentation = (Property<LocalizedText>)instance.Documentation.Clone(this);
                    Documentation.Initialize(instance.Documentation);
                }

                if (type != null && type.CalibrationParameters != null)
                {
                    CalibrationParameters = (Property<IList<double>>)type.CalibrationParameters.Clone(this);
                    CalibrationParameters.Initialize(type.CalibrationParameters);
                }
                else if (instance != null && instance.CalibrationParameters != null)
                {
                    CalibrationParameters = (Property<IList<double>>)instance.CalibrationParameters.Clone(this);
                    CalibrationParameters.Initialize(instance.CalibrationParameters);
                }

                if (type != null && type.CalibrateMethod != null)
                {
                    CalibrateMethod = (AcmeFlowTransmitterType.CalibrateMethodSource)type.CalibrateMethod.Clone(this);
                    CalibrateMethod.Initialize(type.CalibrateMethod);
                }
                else if (instance != null && instance.CalibrateMethod != null)
                {
                    CalibrateMethod = (AcmeFlowTransmitterType.CalibrateMethodSource)instance.CalibrateMethod.Clone(this);
                    CalibrateMethod.Initialize(instance.CalibrateMethod);
                }
            }
        }

        /// <summary cref="NodeSource.InitializeChildren" />
        protected override void InitializeChildren()
        {
            base.InitializeChildren();
                
            m_serialNumber = Property<string>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.SerialNumber, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.AcmeFlowTransmitterType_SerialNumber);

            m_calibrateMethod = AcmeFlowTransmitterType.CalibrateMethodSource.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.Calibrate, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Methods.AcmeFlowTransmitterType_Calibrate);
        }
        
        /// <summary cref="NodeSource.CreateChildren" />
        protected override void CreateChildren(object configuration)
        {
            base.CreateChildren(configuration);
                            
            Documentation = (Property<LocalizedText>)InitializeSharedChild(
                (m_typeDefinition != null)?m_typeDefinition.Documentation:null,
                new ConstructInstanceDelegate(Property<LocalizedText>.Construct), 
                new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.Documentation, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.AcmeFlowTransmitterType_Documentation,
                configuration);

            CalibrationParameters = (Property<IList<double>>)InitializeOptionalChild(
                new ConstructInstanceDelegate(Property<IList<double>>.Construct), 
                new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.CalibrationParameters, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.AcmeFlowTransmitterType_CalibrationParameters,
                configuration);
        }
        #endregion

        #region Private Fields
        private AcmeFlowTransmitterType m_typeDefinition;
        Property<string> m_serialNumber;
        Property<LocalizedText> m_documentation;
        Property<IList<double>> m_calibrationParameters;
        AcmeFlowTransmitterType.CalibrateMethodSource m_calibrateMethod;
        #endregion
    }
    #endregion

    #region CreateInstanceMethodSource Class
    /// <summary>
    /// Implements a method which may be used by many nodes.
    /// </summary>
    public partial class CreateInstanceMethodSource : MethodSource
    {
        #region Constructors
        /// <summary>
        /// Initializes the object with default values.
        /// </summary>
        public CreateInstanceMethodSource(IServerInternal server, NodeSource parent) : base(server, parent)
        {
            Arguments = CreateArguments();
        }
        
        /// <summary>
        /// Creates a new instance of the node.
        /// </summary>
        public static new CreateInstanceMethodSource Construct(
            IServerInternal server, 
            NodeSource      parent, 
            NodeId          referenceTypeId,
            NodeId          nodeId,
            QualifiedName   browseName,
            uint            numericId)
        {
            CreateInstanceMethodSource instance = new CreateInstanceMethodSource(server, parent);
            instance.Initialize(referenceTypeId, nodeId, browseName, numericId, null);
            return instance;
        }
        #endregion
         
        #region ICloneable Members
        /// <summary cref="NodeSource.Clone(NodeSource)" />
        public override NodeSource Clone(NodeSource parent)
        {
            lock (DataLock)
            {
                CreateInstanceMethodSource clone = new CreateInstanceMethodSource(Server, parent);
                clone.Initialize(this);
                return clone;
            }
        }
        #endregion

        #region Public Interface
        /// <summary>
        /// Calls the CreateInstance method.
        /// </summary>
        public NodeId Call(
            OperationContext context,
            NodeSource       target,
            NodeId           parentId,
            NodeId           referenceTypeId,
            QualifiedName    browseName)
        {    
            List<object> inputArguments = new List<object>();
            List<ServiceResult> argumentErrors = new List<ServiceResult>();
            List<object> outputArguments = new List<object>();
            
            inputArguments.Add(parentId);
            inputArguments.Add(referenceTypeId);
            inputArguments.Add(browseName);

            ServiceResult result = Call(
                context, 
                NodeId, 
                null, 
                Parent.NodeId, 
                inputArguments, 
                argumentErrors, 
                outputArguments);

            if (ServiceResult.IsBad(result))
            {
                throw new ServiceResultException(result);
            }
                
            return (NodeId)outputArguments[0];
        }
        #endregion
        
        #region Protected Methods
        /// <summary>
        /// Called when the CreateInstance method is called.
        /// </summary>
        protected override void Call(
            OperationContext     context, 
            NodeSource           target,
            Delegate             methodToCall,
            IList<object>        inputArguments,
            IList<ServiceResult> argumentErrors,
            IList<object>        outputArguments)
        {
            CreateInstanceMethodHandler Callback = methodToCall as CreateInstanceMethodHandler;

            if (Callback == null)
            {
                base.Call(context, target, methodToCall, inputArguments, argumentErrors, outputArguments);
                return;
            }

            NodeId parentId = (NodeId)inputArguments[0];
            NodeId referenceTypeId = (NodeId)inputArguments[1];
            QualifiedName browseName = (QualifiedName)inputArguments[2];
            NodeId instanceId = NodeId.Null;

            instanceId = Callback(
                context,
                target,
                parentId,
                referenceTypeId,
                browseName);
            
            outputArguments.Add(instanceId);
        }

        /// <summary>
        /// Creates the arguments for the CreateInstance method.
        /// </summary>
        protected MethodArguments CreateArguments()
        {
            MethodArguments arguments = new MethodArguments();

            Argument argument = null;
            
            // ParentId
            argument = new Argument();

            argument.Name = "ParentId";
            argument.DataType = Opc.Ua.DataTypes.NodeId;
            argument.ValueRank = ValueRanks.Scalar;
            argument.Description = new LocalizedText("CreateInstance_InputArgument_ParentId_Description", "en", "The parent of the new instance.");

            arguments.Input.Add(argument);

            // ReferenceTypeId
            argument = new Argument();

            argument.Name = "ReferenceTypeId";
            argument.DataType = Opc.Ua.DataTypes.NodeId;
            argument.ValueRank = ValueRanks.Scalar;
            argument.Description = new LocalizedText("CreateInstance_InputArgument_ReferenceTypeId_Description", "en", "The reference from the parent to the new instance.");

            arguments.Input.Add(argument);

            // BrowseName
            argument = new Argument();

            argument.Name = "BrowseName";
            argument.DataType = Opc.Ua.DataTypes.QualifiedName;
            argument.ValueRank = ValueRanks.Scalar;
            argument.Description = new LocalizedText("CreateInstance_InputArgument_BrowseName_Description", "en", "The browse name for the new instance.");

            arguments.Input.Add(argument);
            
            // InstanceId
            argument = new Argument();

            argument.Name = "InstanceId";
            argument.DataType = Opc.Ua.DataTypes.NodeId;
            argument.ValueRank = ValueRanks.Scalar;
            argument.Description = new LocalizedText("CreateInstance_OutputArgument_InstanceId_Description", "en", "The identifier assigned to the new instance.");

            arguments.Output.Add(argument);

            return arguments;
        }
        #endregion
    }

    /// <summary>
    /// A delegate used to receive notifications when the method is called.
    /// </summary>
    public delegate NodeId CreateInstanceMethodHandler(
        OperationContext context,
        NodeSource       target,
        NodeId           parentId,
        NodeId           referenceTypeId,
        QualifiedName    browseName);
    #endregion

    #region BoilerInputPipeType Class
    /// <summary>
    /// Represents the BoilerInputPipeType ObjectType in the address space.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class BoilerInputPipeType : ObjectTypeSource
    {
        #region Constructors
        /// <summary>
        /// Initializes the object with default values.
        /// </summary>
        public BoilerInputPipeType(IServerInternal server) : base(server)
        {
            Initialize(
                new NodeId(Opc.Ua.Sample.ObjectTypes.BoilerInputPipeType, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                new QualifiedName(Opc.Ua.Sample.BrowseNames.BoilerInputPipeType, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                new NodeId(Opc.Ua.ObjectTypes.FolderType, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)));
                    
            server.TypeSources.SetTypeSource(this.NodeId, this);
        }

        /// <summary>
        /// Finds the source for the type definition (creates it if it does not exist).
        /// </summary>
        public static new BoilerInputPipeType FindSource(IServerInternal server)
        {
            BoilerInputPipeType type = null;
                    
            lock (server.TypeSources.SyncRoot)
            {
                NodeId typeId = new NodeId(Opc.Ua.Sample.ObjectTypes.BoilerInputPipeType, server.NamespaceUris.GetIndexOrAppend(Opc.Ua.Sample.Namespaces.Sample));

                type = server.TypeSources.FindTypeSource(typeId) as BoilerInputPipeType;

                if (type != null)
                {
                    return type;
                }

                type = new BoilerInputPipeType(server);
            }

            return type;
        }
        #endregion
             
        #region ICloneable Members
        /// <summary cref="NodeSource.Clone(NodeSource)" />
        public override NodeSource Clone(NodeSource parent)
        {
            lock (DataLock)
            {
                BoilerInputPipeType clone = new BoilerInputPipeType(Server);
                clone.Initialize(this);
                return clone;
            }
        }
        #endregion
      
        #region Public Properties
        #region FlowTransmitter1
        /// <summary>
        /// A description for the FTX001 Object.
        /// </summary>
        public FlowTransmitter FlowTransmitter1
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_flowTransmitter1; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_flowTransmitter1 != null)
                    {
                        RemoveChild(m_flowTransmitter1);
                    }

                    m_flowTransmitter1 = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceFlowTransmitter1(FlowTransmitter replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                FlowTransmitter1 = replacement;

                FlowTransmitter1.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.FlowTransmitter1, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Objects.BoilerInputPipeType_FlowTransmitter1,
                    null);
            }
        }
        #endregion

        #region Valve
        /// <summary>
        /// A description for the ValveX001 Object.
        /// </summary>
        public Valve Valve
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_valve; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_valve != null)
                    {
                        RemoveChild(m_valve);
                    }

                    m_valve = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceValve(Valve replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                Valve = replacement;

                Valve.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.Valve, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Objects.BoilerInputPipeType_Valve,
                    null);
            }
        }
        #endregion
        #endregion

        #region Overridden Methods
        /// <summary cref="NodeSource.Initialize(NodeSource)" />
        public override void Initialize(NodeSource source)
        {
            lock (DataLock)
            {
                base.Initialize(source);
                
                BoilerInputPipeType type = source as BoilerInputPipeType;

                if (type != null && type.FlowTransmitter1 != null)
                {
                    FlowTransmitter1 = (FlowTransmitter)type.FlowTransmitter1.Clone(this);
                    FlowTransmitter1.Initialize(type.FlowTransmitter1);
                }

                if (type != null && type.Valve != null)
                {
                    Valve = (Valve)type.Valve.Clone(this);
                    Valve.Initialize(type.Valve);
                }
            }
        }

        /// <summary cref="NodeSource.InitializeChildren" />
        protected override void InitializeChildren()
        {
            base.InitializeChildren();
                
            m_flowTransmitter1 = FlowTransmitter.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Objects.BoilerInputPipeType_FlowTransmitter1, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.FlowTransmitter1, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Objects.BoilerInputPipeType_FlowTransmitter1);

            m_valve = Valve.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Objects.BoilerInputPipeType_Valve, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.Valve, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Objects.BoilerInputPipeType_Valve);
        }
        #endregion

        #region Private Fields
        FlowTransmitter m_flowTransmitter1;
        Valve m_valve;
        #endregion
    }
    #endregion

    #region BoilerInputPipe Class
    /// <summary>
    /// Represents an instance of the BoilerInputPipeType ObjectType in the address space.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class BoilerInputPipe : Folder
    {
        #region Constructors
        /// <summary>
        /// Initializes the object with default values.
        /// </summary>
        protected BoilerInputPipe(IServerInternal server, NodeSource parent) 
        : 
            base(server, parent)
        {
            m_typeDefinition = BoilerInputPipeType.FindSource(server);
        }

        /// <summary>
        /// Creates a new instance of the node.
        /// </summary>
        public static new BoilerInputPipe Construct(
            IServerInternal server, 
            NodeSource      parent, 
            NodeId          referenceTypeId,
            NodeId          nodeId,
            QualifiedName   browseName,
            uint            numericId)
        {
            BoilerInputPipe instance = new BoilerInputPipe(server, parent);
            instance.Initialize(referenceTypeId, nodeId, browseName, numericId, instance.m_typeDefinition.NodeId);
            return instance;
        }

        /// <summary>
        /// Creates a new instance of the node without any parent.
        /// </summary>
        public static new BoilerInputPipe Construct(IServerInternal server)
        {
            BoilerInputPipe instance = new BoilerInputPipe(server, (NodeSource)null);
            instance.Initialize(null, null, null, 0, instance.m_typeDefinition.NodeId);
            return instance;
        }
        #endregion
           
        #region ICloneable Members
        /// <summary cref="NodeSource.Clone(NodeSource)" />
        public override NodeSource Clone(NodeSource parent)
        {
            lock (DataLock)
            {
                BoilerInputPipe clone = new BoilerInputPipe(Server, parent);
                clone.Initialize(this);
                return clone;
            } 
        }
        #endregion

        #region Public Properties
        #region FlowTransmitter1
        /// <summary>
        /// A description for the FTX001 Object.
        /// </summary>
        public FlowTransmitter FlowTransmitter1
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_flowTransmitter1; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_flowTransmitter1 != null)
                    {
                        RemoveChild(m_flowTransmitter1);
                    }

                    m_flowTransmitter1 = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceFlowTransmitter1(FlowTransmitter replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                FlowTransmitter1 = replacement;

                FlowTransmitter1.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.FlowTransmitter1, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Objects.BoilerInputPipeType_FlowTransmitter1,
                    null);
            }
        }
        #endregion

        #region Valve
        /// <summary>
        /// A description for the ValveX001 Object.
        /// </summary>
        public Valve Valve
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_valve; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_valve != null)
                    {
                        RemoveChild(m_valve);
                    }

                    m_valve = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceValve(Valve replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                Valve = replacement;

                Valve.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.Valve, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Objects.BoilerInputPipeType_Valve,
                    null);
            }
        }
        #endregion
        #endregion

        #region Overridden Methods
        /// <summary cref="NodeSource.Initialize(NodeSource)" />
        public override void Initialize(NodeSource source)
        {
            lock (DataLock)
            {            
                BoilerInputPipe instance = source as BoilerInputPipe;

                if (instance != null)
                {
                    base.Initialize(source);
                }

                BoilerInputPipeType type = source as BoilerInputPipeType;

                if (type != null && type.FlowTransmitter1 != null)
                {
                    FlowTransmitter1 = (FlowTransmitter)type.FlowTransmitter1.Clone(this);
                    FlowTransmitter1.Initialize(type.FlowTransmitter1);
                }
                else if (instance != null && instance.FlowTransmitter1 != null)
                {
                    FlowTransmitter1 = (FlowTransmitter)instance.FlowTransmitter1.Clone(this);
                    FlowTransmitter1.Initialize(instance.FlowTransmitter1);
                }

                if (type != null && type.Valve != null)
                {
                    Valve = (Valve)type.Valve.Clone(this);
                    Valve.Initialize(type.Valve);
                }
                else if (instance != null && instance.Valve != null)
                {
                    Valve = (Valve)instance.Valve.Clone(this);
                    Valve.Initialize(instance.Valve);
                }
            }
        }

        /// <summary cref="NodeSource.InitializeChildren" />
        protected override void InitializeChildren()
        {
            base.InitializeChildren();
                
            m_flowTransmitter1 = FlowTransmitter.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.FlowTransmitter1, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Objects.BoilerInputPipeType_FlowTransmitter1);

            m_valve = Valve.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.Valve, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Objects.BoilerInputPipeType_Valve);
        }
        #endregion

        #region Private Fields
        private BoilerInputPipeType m_typeDefinition;
        FlowTransmitter m_flowTransmitter1;
        Valve m_valve;
        #endregion
    }
    #endregion

    #region BoilerDrumType Class
    /// <summary>
    /// Represents the BoilerDrumType ObjectType in the address space.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class BoilerDrumType : ObjectTypeSource
    {
        #region Constructors
        /// <summary>
        /// Initializes the object with default values.
        /// </summary>
        public BoilerDrumType(IServerInternal server) : base(server)
        {
            Initialize(
                new NodeId(Opc.Ua.Sample.ObjectTypes.BoilerDrumType, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                new QualifiedName(Opc.Ua.Sample.BrowseNames.BoilerDrumType, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                new NodeId(Opc.Ua.ObjectTypes.FolderType, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)));
                    
            server.TypeSources.SetTypeSource(this.NodeId, this);
        }

        /// <summary>
        /// Finds the source for the type definition (creates it if it does not exist).
        /// </summary>
        public static new BoilerDrumType FindSource(IServerInternal server)
        {
            BoilerDrumType type = null;
                    
            lock (server.TypeSources.SyncRoot)
            {
                NodeId typeId = new NodeId(Opc.Ua.Sample.ObjectTypes.BoilerDrumType, server.NamespaceUris.GetIndexOrAppend(Opc.Ua.Sample.Namespaces.Sample));

                type = server.TypeSources.FindTypeSource(typeId) as BoilerDrumType;

                if (type != null)
                {
                    return type;
                }

                type = new BoilerDrumType(server);
            }

            return type;
        }
        #endregion
             
        #region ICloneable Members
        /// <summary cref="NodeSource.Clone(NodeSource)" />
        public override NodeSource Clone(NodeSource parent)
        {
            lock (DataLock)
            {
                BoilerDrumType clone = new BoilerDrumType(Server);
                clone.Initialize(this);
                return clone;
            }
        }
        #endregion
      
        #region Public Properties
        #region LevelIndicator
        /// <summary>
        /// A description for the LIX001 Object.
        /// </summary>
        public LevelIndicator LevelIndicator
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_levelIndicator; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_levelIndicator != null)
                    {
                        RemoveChild(m_levelIndicator);
                    }

                    m_levelIndicator = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceLevelIndicator(LevelIndicator replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                LevelIndicator = replacement;

                LevelIndicator.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.LevelIndicator, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Objects.BoilerDrumType_LevelIndicator,
                    null);
            }
        }
        #endregion
        #endregion

        #region Overridden Methods
        /// <summary cref="NodeSource.Initialize(NodeSource)" />
        public override void Initialize(NodeSource source)
        {
            lock (DataLock)
            {
                base.Initialize(source);
                
                BoilerDrumType type = source as BoilerDrumType;

                if (type != null && type.LevelIndicator != null)
                {
                    LevelIndicator = (LevelIndicator)type.LevelIndicator.Clone(this);
                    LevelIndicator.Initialize(type.LevelIndicator);
                }
            }
        }

        /// <summary cref="NodeSource.InitializeChildren" />
        protected override void InitializeChildren()
        {
            base.InitializeChildren();
                
            m_levelIndicator = LevelIndicator.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Objects.BoilerDrumType_LevelIndicator, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.LevelIndicator, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Objects.BoilerDrumType_LevelIndicator);
        }
        #endregion

        #region Private Fields
        LevelIndicator m_levelIndicator;
        #endregion
    }
    #endregion

    #region BoilerDrum Class
    /// <summary>
    /// Represents an instance of the BoilerDrumType ObjectType in the address space.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class BoilerDrum : Folder
    {
        #region Constructors
        /// <summary>
        /// Initializes the object with default values.
        /// </summary>
        protected BoilerDrum(IServerInternal server, NodeSource parent) 
        : 
            base(server, parent)
        {
            m_typeDefinition = BoilerDrumType.FindSource(server);
        }

        /// <summary>
        /// Creates a new instance of the node.
        /// </summary>
        public static new BoilerDrum Construct(
            IServerInternal server, 
            NodeSource      parent, 
            NodeId          referenceTypeId,
            NodeId          nodeId,
            QualifiedName   browseName,
            uint            numericId)
        {
            BoilerDrum instance = new BoilerDrum(server, parent);
            instance.Initialize(referenceTypeId, nodeId, browseName, numericId, instance.m_typeDefinition.NodeId);
            return instance;
        }

        /// <summary>
        /// Creates a new instance of the node without any parent.
        /// </summary>
        public static new BoilerDrum Construct(IServerInternal server)
        {
            BoilerDrum instance = new BoilerDrum(server, (NodeSource)null);
            instance.Initialize(null, null, null, 0, instance.m_typeDefinition.NodeId);
            return instance;
        }
        #endregion
           
        #region ICloneable Members
        /// <summary cref="NodeSource.Clone(NodeSource)" />
        public override NodeSource Clone(NodeSource parent)
        {
            lock (DataLock)
            {
                BoilerDrum clone = new BoilerDrum(Server, parent);
                clone.Initialize(this);
                return clone;
            } 
        }
        #endregion

        #region Public Properties
        #region LevelIndicator
        /// <summary>
        /// A description for the LIX001 Object.
        /// </summary>
        public LevelIndicator LevelIndicator
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_levelIndicator; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_levelIndicator != null)
                    {
                        RemoveChild(m_levelIndicator);
                    }

                    m_levelIndicator = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceLevelIndicator(LevelIndicator replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                LevelIndicator = replacement;

                LevelIndicator.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.LevelIndicator, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Objects.BoilerDrumType_LevelIndicator,
                    null);
            }
        }
        #endregion
        #endregion

        #region Overridden Methods
        /// <summary cref="NodeSource.Initialize(NodeSource)" />
        public override void Initialize(NodeSource source)
        {
            lock (DataLock)
            {            
                BoilerDrum instance = source as BoilerDrum;

                if (instance != null)
                {
                    base.Initialize(source);
                }

                BoilerDrumType type = source as BoilerDrumType;

                if (type != null && type.LevelIndicator != null)
                {
                    LevelIndicator = (LevelIndicator)type.LevelIndicator.Clone(this);
                    LevelIndicator.Initialize(type.LevelIndicator);
                }
                else if (instance != null && instance.LevelIndicator != null)
                {
                    LevelIndicator = (LevelIndicator)instance.LevelIndicator.Clone(this);
                    LevelIndicator.Initialize(instance.LevelIndicator);
                }
            }
        }

        /// <summary cref="NodeSource.InitializeChildren" />
        protected override void InitializeChildren()
        {
            base.InitializeChildren();
                
            m_levelIndicator = LevelIndicator.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.LevelIndicator, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Objects.BoilerDrumType_LevelIndicator);
        }
        #endregion

        #region Private Fields
        private BoilerDrumType m_typeDefinition;
        LevelIndicator m_levelIndicator;
        #endregion
    }
    #endregion

    #region BoilerOutputPipeType Class
    /// <summary>
    /// Represents the BoilerOutputPipeType ObjectType in the address space.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class BoilerOutputPipeType : ObjectTypeSource
    {
        #region Constructors
        /// <summary>
        /// Initializes the object with default values.
        /// </summary>
        public BoilerOutputPipeType(IServerInternal server) : base(server)
        {
            Initialize(
                new NodeId(Opc.Ua.Sample.ObjectTypes.BoilerOutputPipeType, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                new QualifiedName(Opc.Ua.Sample.BrowseNames.BoilerOutputPipeType, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                new NodeId(Opc.Ua.ObjectTypes.FolderType, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)));
                    
            server.TypeSources.SetTypeSource(this.NodeId, this);
        }

        /// <summary>
        /// Finds the source for the type definition (creates it if it does not exist).
        /// </summary>
        public static new BoilerOutputPipeType FindSource(IServerInternal server)
        {
            BoilerOutputPipeType type = null;
                    
            lock (server.TypeSources.SyncRoot)
            {
                NodeId typeId = new NodeId(Opc.Ua.Sample.ObjectTypes.BoilerOutputPipeType, server.NamespaceUris.GetIndexOrAppend(Opc.Ua.Sample.Namespaces.Sample));

                type = server.TypeSources.FindTypeSource(typeId) as BoilerOutputPipeType;

                if (type != null)
                {
                    return type;
                }

                type = new BoilerOutputPipeType(server);
            }

            return type;
        }
        #endregion
             
        #region ICloneable Members
        /// <summary cref="NodeSource.Clone(NodeSource)" />
        public override NodeSource Clone(NodeSource parent)
        {
            lock (DataLock)
            {
                BoilerOutputPipeType clone = new BoilerOutputPipeType(Server);
                clone.Initialize(this);
                return clone;
            }
        }
        #endregion
      
        #region Public Properties
        #region FlowTransmitter2
        /// <summary>
        /// A description for the FTX002 Object.
        /// </summary>
        public FlowTransmitter FlowTransmitter2
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_flowTransmitter2; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_flowTransmitter2 != null)
                    {
                        RemoveChild(m_flowTransmitter2);
                    }

                    m_flowTransmitter2 = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceFlowTransmitter2(FlowTransmitter replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                FlowTransmitter2 = replacement;

                FlowTransmitter2.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.FlowTransmitter2, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Objects.BoilerOutputPipeType_FlowTransmitter2,
                    null);
            }
        }
        #endregion
        #endregion

        #region Overridden Methods
        /// <summary cref="NodeSource.Initialize(NodeSource)" />
        public override void Initialize(NodeSource source)
        {
            lock (DataLock)
            {
                base.Initialize(source);
                
                BoilerOutputPipeType type = source as BoilerOutputPipeType;

                if (type != null && type.FlowTransmitter2 != null)
                {
                    FlowTransmitter2 = (FlowTransmitter)type.FlowTransmitter2.Clone(this);
                    FlowTransmitter2.Initialize(type.FlowTransmitter2);
                }
            }
        }

        /// <summary cref="NodeSource.InitializeChildren" />
        protected override void InitializeChildren()
        {
            base.InitializeChildren();
                
            m_flowTransmitter2 = FlowTransmitter.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Objects.BoilerOutputPipeType_FlowTransmitter2, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.FlowTransmitter2, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Objects.BoilerOutputPipeType_FlowTransmitter2);
        }
        #endregion

        #region Private Fields
        FlowTransmitter m_flowTransmitter2;
        #endregion
    }
    #endregion

    #region BoilerOutputPipe Class
    /// <summary>
    /// Represents an instance of the BoilerOutputPipeType ObjectType in the address space.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class BoilerOutputPipe : Folder
    {
        #region Constructors
        /// <summary>
        /// Initializes the object with default values.
        /// </summary>
        protected BoilerOutputPipe(IServerInternal server, NodeSource parent) 
        : 
            base(server, parent)
        {
            m_typeDefinition = BoilerOutputPipeType.FindSource(server);
        }

        /// <summary>
        /// Creates a new instance of the node.
        /// </summary>
        public static new BoilerOutputPipe Construct(
            IServerInternal server, 
            NodeSource      parent, 
            NodeId          referenceTypeId,
            NodeId          nodeId,
            QualifiedName   browseName,
            uint            numericId)
        {
            BoilerOutputPipe instance = new BoilerOutputPipe(server, parent);
            instance.Initialize(referenceTypeId, nodeId, browseName, numericId, instance.m_typeDefinition.NodeId);
            return instance;
        }

        /// <summary>
        /// Creates a new instance of the node without any parent.
        /// </summary>
        public static new BoilerOutputPipe Construct(IServerInternal server)
        {
            BoilerOutputPipe instance = new BoilerOutputPipe(server, (NodeSource)null);
            instance.Initialize(null, null, null, 0, instance.m_typeDefinition.NodeId);
            return instance;
        }
        #endregion
           
        #region ICloneable Members
        /// <summary cref="NodeSource.Clone(NodeSource)" />
        public override NodeSource Clone(NodeSource parent)
        {
            lock (DataLock)
            {
                BoilerOutputPipe clone = new BoilerOutputPipe(Server, parent);
                clone.Initialize(this);
                return clone;
            } 
        }
        #endregion

        #region Public Properties
        #region FlowTransmitter2
        /// <summary>
        /// A description for the FTX002 Object.
        /// </summary>
        public FlowTransmitter FlowTransmitter2
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_flowTransmitter2; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_flowTransmitter2 != null)
                    {
                        RemoveChild(m_flowTransmitter2);
                    }

                    m_flowTransmitter2 = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceFlowTransmitter2(FlowTransmitter replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                FlowTransmitter2 = replacement;

                FlowTransmitter2.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.FlowTransmitter2, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Objects.BoilerOutputPipeType_FlowTransmitter2,
                    null);
            }
        }
        #endregion
        #endregion

        #region Overridden Methods
        /// <summary cref="NodeSource.Initialize(NodeSource)" />
        public override void Initialize(NodeSource source)
        {
            lock (DataLock)
            {            
                BoilerOutputPipe instance = source as BoilerOutputPipe;

                if (instance != null)
                {
                    base.Initialize(source);
                }

                BoilerOutputPipeType type = source as BoilerOutputPipeType;

                if (type != null && type.FlowTransmitter2 != null)
                {
                    FlowTransmitter2 = (FlowTransmitter)type.FlowTransmitter2.Clone(this);
                    FlowTransmitter2.Initialize(type.FlowTransmitter2);
                }
                else if (instance != null && instance.FlowTransmitter2 != null)
                {
                    FlowTransmitter2 = (FlowTransmitter)instance.FlowTransmitter2.Clone(this);
                    FlowTransmitter2.Initialize(instance.FlowTransmitter2);
                }
            }
        }

        /// <summary cref="NodeSource.InitializeChildren" />
        protected override void InitializeChildren()
        {
            base.InitializeChildren();
                
            m_flowTransmitter2 = FlowTransmitter.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.FlowTransmitter2, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Objects.BoilerOutputPipeType_FlowTransmitter2);
        }
        #endregion

        #region Private Fields
        private BoilerOutputPipeType m_typeDefinition;
        FlowTransmitter m_flowTransmitter2;
        #endregion
    }
    #endregion

    #region BoilerType Class
    /// <summary>
    /// Represents the BoilerType ObjectType in the address space.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class BoilerType : ObjectTypeSource
    {
        #region Constructors
        /// <summary>
        /// Initializes the object with default values.
        /// </summary>
        public BoilerType(IServerInternal server) : base(server)
        {
            Initialize(
                new NodeId(Opc.Ua.Sample.ObjectTypes.BoilerType, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                new QualifiedName(Opc.Ua.Sample.BrowseNames.BoilerType, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                new NodeId(Opc.Ua.ObjectTypes.BaseObjectType, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)));
                    
            server.TypeSources.SetTypeSource(this.NodeId, this);
        }

        /// <summary>
        /// Finds the source for the type definition (creates it if it does not exist).
        /// </summary>
        public static new BoilerType FindSource(IServerInternal server)
        {
            BoilerType type = null;
                    
            lock (server.TypeSources.SyncRoot)
            {
                NodeId typeId = new NodeId(Opc.Ua.Sample.ObjectTypes.BoilerType, server.NamespaceUris.GetIndexOrAppend(Opc.Ua.Sample.Namespaces.Sample));

                type = server.TypeSources.FindTypeSource(typeId) as BoilerType;

                if (type != null)
                {
                    return type;
                }

                type = new BoilerType(server);
            }

            return type;
        }
        #endregion
             
        #region ICloneable Members
        /// <summary cref="NodeSource.Clone(NodeSource)" />
        public override NodeSource Clone(NodeSource parent)
        {
            lock (DataLock)
            {
                BoilerType clone = new BoilerType(Server);
                clone.Initialize(this);
                return clone;
            }
        }
        #endregion
      
        #region Public Properties
        #region InputPipe
        /// <summary>
        /// A description for the PipeX001 Object.
        /// </summary>
        public BoilerInputPipe InputPipe
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_inputPipe; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_inputPipe != null)
                    {
                        RemoveChild(m_inputPipe);
                    }

                    m_inputPipe = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceInputPipe(BoilerInputPipe replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                InputPipe = replacement;

                InputPipe.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.InputPipe, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Objects.BoilerType_InputPipe,
                    null);
            }
        }
        #endregion

        #region Drum
        /// <summary>
        /// A description for the DrumX001 Object.
        /// </summary>
        public BoilerDrum Drum
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_drum; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_drum != null)
                    {
                        RemoveChild(m_drum);
                    }

                    m_drum = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceDrum(BoilerDrum replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                Drum = replacement;

                Drum.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.Drum, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Objects.BoilerType_Drum,
                    null);
            }
        }
        #endregion

        #region OutputPipe
        /// <summary>
        /// A description for the PipeX002 Object.
        /// </summary>
        public BoilerOutputPipe OutputPipe
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_outputPipe; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_outputPipe != null)
                    {
                        RemoveChild(m_outputPipe);
                    }

                    m_outputPipe = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceOutputPipe(BoilerOutputPipe replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                OutputPipe = replacement;

                OutputPipe.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.OutputPipe, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Objects.BoilerType_OutputPipe,
                    null);
            }
        }
        #endregion

        #region FlowController
        /// <summary>
        /// A description for the FCX001 Object.
        /// </summary>
        public FlowController FlowController
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_flowController; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_flowController != null)
                    {
                        RemoveChild(m_flowController);
                    }

                    m_flowController = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceFlowController(FlowController replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                FlowController = replacement;

                FlowController.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.FlowController, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Objects.BoilerType_FlowController,
                    null);
            }
        }
        #endregion

        #region LevelController
        /// <summary>
        /// A description for the LCX001 Object.
        /// </summary>
        public LevelController LevelController
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_levelController; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_levelController != null)
                    {
                        RemoveChild(m_levelController);
                    }

                    m_levelController = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceLevelController(LevelController replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                LevelController = replacement;

                LevelController.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.LevelController, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Objects.BoilerType_LevelController,
                    null);
            }
        }
        #endregion

        #region CustomController
        /// <summary>
        /// A description for the CCX001 Object.
        /// </summary>
        public CustomController CustomController
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_customController; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_customController != null)
                    {
                        RemoveChild(m_customController);
                    }

                    m_customController = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceCustomController(CustomController replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                CustomController = replacement;

                CustomController.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.CustomController, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Objects.BoilerType_CustomController,
                    null);
            }
        }
        #endregion

        #region CreateBoilerMethod
        /// <summary>
        /// A description for the CreateBoiler Method.
        /// </summary>
        public CreateInstanceMethodSource CreateBoilerMethod
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_createBoilerMethod; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_createBoilerMethod != null)
                    {
                        RemoveChild(m_createBoilerMethod);
                    }

                    m_createBoilerMethod = value; 
                }
            }
        }
            
        /// <summary>
        /// Calls the CreateBoiler method.
        /// </summary>
        public NodeId CreateBoiler(
            OperationContext context,
            NodeId           parentId,
            NodeId           referenceTypeId,
            QualifiedName    browseName)
        {     
            lock (DataLock)
            {     
                return CreateBoilerMethod.Call(
                    context,
                    this,
                    parentId,
                    referenceTypeId,
                    browseName);
            }
        }
            
        /// <summary>
        /// Sets the callback to use when the CreateBoiler method is called.
        /// </summary>
        public void SetCreateBoilerCallback(CreateInstanceMethodHandler callback)
        {
            lock (DataLock)
            {  
                CreateBoilerMethod.SetCallback(this, callback);
            }
        }
        #endregion
        #endregion

        #region Overridden Methods
        /// <summary cref="NodeSource.Initialize(NodeSource)" />
        public override void Initialize(NodeSource source)
        {
            lock (DataLock)
            {
                base.Initialize(source);
                
                BoilerType type = source as BoilerType;

                if (type != null && type.InputPipe != null)
                {
                    InputPipe = (BoilerInputPipe)type.InputPipe.Clone(this);
                    InputPipe.Initialize(type.InputPipe);
                }

                if (type != null && type.Drum != null)
                {
                    Drum = (BoilerDrum)type.Drum.Clone(this);
                    Drum.Initialize(type.Drum);
                }

                if (type != null && type.OutputPipe != null)
                {
                    OutputPipe = (BoilerOutputPipe)type.OutputPipe.Clone(this);
                    OutputPipe.Initialize(type.OutputPipe);
                }

                if (type != null && type.FlowController != null)
                {
                    FlowController = (FlowController)type.FlowController.Clone(this);
                    FlowController.Initialize(type.FlowController);
                }

                if (type != null && type.LevelController != null)
                {
                    LevelController = (LevelController)type.LevelController.Clone(this);
                    LevelController.Initialize(type.LevelController);
                }

                if (type != null && type.CustomController != null)
                {
                    CustomController = (CustomController)type.CustomController.Clone(this);
                    CustomController.Initialize(type.CustomController);
                }

                if (type != null && type.CreateBoilerMethod != null)
                {
                    CreateBoilerMethod = (CreateInstanceMethodSource)type.CreateBoilerMethod.Clone(this);
                    CreateBoilerMethod.Initialize(type.CreateBoilerMethod);
                }
            }
        }

        /// <summary cref="NodeSource.InitializeChildren" />
        protected override void InitializeChildren()
        {
            base.InitializeChildren();
                
            m_inputPipe = BoilerInputPipe.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Objects.BoilerType_InputPipe, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.InputPipe, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Objects.BoilerType_InputPipe);

            m_drum = BoilerDrum.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Objects.BoilerType_Drum, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.Drum, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Objects.BoilerType_Drum);

            m_outputPipe = BoilerOutputPipe.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Objects.BoilerType_OutputPipe, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.OutputPipe, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Objects.BoilerType_OutputPipe);

            m_flowController = FlowController.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Objects.BoilerType_FlowController, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.FlowController, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Objects.BoilerType_FlowController);

            m_levelController = LevelController.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Objects.BoilerType_LevelController, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.LevelController, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Objects.BoilerType_LevelController);

            m_customController = CustomController.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Objects.BoilerType_CustomController, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.CustomController, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Objects.BoilerType_CustomController);

            m_createBoilerMethod = CreateInstanceMethodSource.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Methods.BoilerType_CreateBoiler, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.CreateBoiler, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Methods.BoilerType_CreateBoiler);
        }
        #endregion

        #region Private Fields
        BoilerInputPipe m_inputPipe;
        BoilerDrum m_drum;
        BoilerOutputPipe m_outputPipe;
        FlowController m_flowController;
        LevelController m_levelController;
        CustomController m_customController;
        CreateInstanceMethodSource m_createBoilerMethod;
        #endregion
    }
    #endregion

    #region Boiler Class
    /// <summary>
    /// Represents an instance of the BoilerType ObjectType in the address space.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class Boiler : ObjectSource
    {
        #region Constructors
        /// <summary>
        /// Initializes the object with default values.
        /// </summary>
        protected Boiler(IServerInternal server, NodeSource parent) 
        : 
            base(server, parent)
        {
            m_typeDefinition = BoilerType.FindSource(server);
        }

        /// <summary>
        /// Creates a new instance of the node.
        /// </summary>
        public static new Boiler Construct(
            IServerInternal server, 
            NodeSource      parent, 
            NodeId          referenceTypeId,
            NodeId          nodeId,
            QualifiedName   browseName,
            uint            numericId)
        {
            Boiler instance = new Boiler(server, parent);
            instance.Initialize(referenceTypeId, nodeId, browseName, numericId, instance.m_typeDefinition.NodeId);
            return instance;
        }

        /// <summary>
        /// Creates a new instance of the node without any parent.
        /// </summary>
        public static new Boiler Construct(IServerInternal server)
        {
            Boiler instance = new Boiler(server, (NodeSource)null);
            instance.Initialize(null, null, null, 0, instance.m_typeDefinition.NodeId);
            return instance;
        }
        #endregion
           
        #region ICloneable Members
        /// <summary cref="NodeSource.Clone(NodeSource)" />
        public override NodeSource Clone(NodeSource parent)
        {
            lock (DataLock)
            {
                Boiler clone = new Boiler(Server, parent);
                clone.Initialize(this);
                return clone;
            } 
        }
        #endregion

        #region Public Properties
        #region InputPipe
        /// <summary>
        /// A description for the PipeX001 Object.
        /// </summary>
        public BoilerInputPipe InputPipe
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_inputPipe; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_inputPipe != null)
                    {
                        RemoveChild(m_inputPipe);
                    }

                    m_inputPipe = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceInputPipe(BoilerInputPipe replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                InputPipe = replacement;

                InputPipe.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.InputPipe, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Objects.BoilerType_InputPipe,
                    null);
            }
        }
        #endregion

        #region Drum
        /// <summary>
        /// A description for the DrumX001 Object.
        /// </summary>
        public BoilerDrum Drum
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_drum; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_drum != null)
                    {
                        RemoveChild(m_drum);
                    }

                    m_drum = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceDrum(BoilerDrum replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                Drum = replacement;

                Drum.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.Drum, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Objects.BoilerType_Drum,
                    null);
            }
        }
        #endregion

        #region OutputPipe
        /// <summary>
        /// A description for the PipeX002 Object.
        /// </summary>
        public BoilerOutputPipe OutputPipe
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_outputPipe; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_outputPipe != null)
                    {
                        RemoveChild(m_outputPipe);
                    }

                    m_outputPipe = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceOutputPipe(BoilerOutputPipe replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                OutputPipe = replacement;

                OutputPipe.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.OutputPipe, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Objects.BoilerType_OutputPipe,
                    null);
            }
        }
        #endregion

        #region FlowController
        /// <summary>
        /// A description for the FCX001 Object.
        /// </summary>
        public FlowController FlowController
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_flowController; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_flowController != null)
                    {
                        RemoveChild(m_flowController);
                    }

                    m_flowController = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceFlowController(FlowController replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                FlowController = replacement;

                FlowController.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.FlowController, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Objects.BoilerType_FlowController,
                    null);
            }
        }
        #endregion

        #region LevelController
        /// <summary>
        /// A description for the LCX001 Object.
        /// </summary>
        public LevelController LevelController
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_levelController; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_levelController != null)
                    {
                        RemoveChild(m_levelController);
                    }

                    m_levelController = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceLevelController(LevelController replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                LevelController = replacement;

                LevelController.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.LevelController, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Objects.BoilerType_LevelController,
                    null);
            }
        }
        #endregion

        #region CustomController
        /// <summary>
        /// A description for the CCX001 Object.
        /// </summary>
        public CustomController CustomController
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_customController; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_customController != null)
                    {
                        RemoveChild(m_customController);
                    }

                    m_customController = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceCustomController(CustomController replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                CustomController = replacement;

                CustomController.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.CustomController, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Objects.BoilerType_CustomController,
                    null);
            }
        }
        #endregion
        #endregion

        #region Overridden Methods
        /// <summary cref="NodeSource.Initialize(NodeSource)" />
        public override void Initialize(NodeSource source)
        {
            lock (DataLock)
            {            
                Boiler instance = source as Boiler;

                if (instance != null)
                {
                    base.Initialize(source);
                }

                BoilerType type = source as BoilerType;

                if (type != null && type.InputPipe != null)
                {
                    InputPipe = (BoilerInputPipe)type.InputPipe.Clone(this);
                    InputPipe.Initialize(type.InputPipe);
                }
                else if (instance != null && instance.InputPipe != null)
                {
                    InputPipe = (BoilerInputPipe)instance.InputPipe.Clone(this);
                    InputPipe.Initialize(instance.InputPipe);
                }

                if (type != null && type.Drum != null)
                {
                    Drum = (BoilerDrum)type.Drum.Clone(this);
                    Drum.Initialize(type.Drum);
                }
                else if (instance != null && instance.Drum != null)
                {
                    Drum = (BoilerDrum)instance.Drum.Clone(this);
                    Drum.Initialize(instance.Drum);
                }

                if (type != null && type.OutputPipe != null)
                {
                    OutputPipe = (BoilerOutputPipe)type.OutputPipe.Clone(this);
                    OutputPipe.Initialize(type.OutputPipe);
                }
                else if (instance != null && instance.OutputPipe != null)
                {
                    OutputPipe = (BoilerOutputPipe)instance.OutputPipe.Clone(this);
                    OutputPipe.Initialize(instance.OutputPipe);
                }

                if (type != null && type.FlowController != null)
                {
                    FlowController = (FlowController)type.FlowController.Clone(this);
                    FlowController.Initialize(type.FlowController);
                }
                else if (instance != null && instance.FlowController != null)
                {
                    FlowController = (FlowController)instance.FlowController.Clone(this);
                    FlowController.Initialize(instance.FlowController);
                }

                if (type != null && type.LevelController != null)
                {
                    LevelController = (LevelController)type.LevelController.Clone(this);
                    LevelController.Initialize(type.LevelController);
                }
                else if (instance != null && instance.LevelController != null)
                {
                    LevelController = (LevelController)instance.LevelController.Clone(this);
                    LevelController.Initialize(instance.LevelController);
                }

                if (type != null && type.CustomController != null)
                {
                    CustomController = (CustomController)type.CustomController.Clone(this);
                    CustomController.Initialize(type.CustomController);
                }
                else if (instance != null && instance.CustomController != null)
                {
                    CustomController = (CustomController)instance.CustomController.Clone(this);
                    CustomController.Initialize(instance.CustomController);
                }
            }
        }

        /// <summary cref="NodeSource.InitializeChildren" />
        protected override void InitializeChildren()
        {
            base.InitializeChildren();
                
            m_inputPipe = BoilerInputPipe.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.InputPipe, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Objects.BoilerType_InputPipe);

            m_drum = BoilerDrum.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.Drum, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Objects.BoilerType_Drum);

            m_outputPipe = BoilerOutputPipe.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.OutputPipe, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Objects.BoilerType_OutputPipe);

            m_flowController = FlowController.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.FlowController, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Objects.BoilerType_FlowController);

            m_levelController = LevelController.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.LevelController, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Objects.BoilerType_LevelController);

            m_customController = CustomController.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.CustomController, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Objects.BoilerType_CustomController);
        }
        #endregion

        #region Private Fields
        private BoilerType m_typeDefinition;
        BoilerInputPipe m_inputPipe;
        BoilerDrum m_drum;
        BoilerOutputPipe m_outputPipe;
        FlowController m_flowController;
        LevelController m_levelController;
        CustomController m_customController;
        #endregion
    }
    #endregion

    #region MaintenanceEventType Class
    /// <summary>
    /// Represents the MaintenanceEventType ObjectType in the address space.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class MaintenanceEventType : ObjectTypeSource
    {
        #region Constructors
        /// <summary>
        /// Initializes the object with default values.
        /// </summary>
        public MaintenanceEventType(IServerInternal server) : base(server)
        {
            Initialize(
                new NodeId(Opc.Ua.Sample.ObjectTypes.MaintenanceEventType, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                new QualifiedName(Opc.Ua.Sample.BrowseNames.MaintenanceEventType, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                new NodeId(Opc.Ua.ObjectTypes.BaseEventType, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)));
                    
            server.TypeSources.SetTypeSource(this.NodeId, this);
        }

        /// <summary>
        /// Finds the source for the type definition (creates it if it does not exist).
        /// </summary>
        public static new MaintenanceEventType FindSource(IServerInternal server)
        {
            MaintenanceEventType type = null;
                    
            lock (server.TypeSources.SyncRoot)
            {
                NodeId typeId = new NodeId(Opc.Ua.Sample.ObjectTypes.MaintenanceEventType, server.NamespaceUris.GetIndexOrAppend(Opc.Ua.Sample.Namespaces.Sample));

                type = server.TypeSources.FindTypeSource(typeId) as MaintenanceEventType;

                if (type != null)
                {
                    return type;
                }

                type = new MaintenanceEventType(server);
            }

            return type;
        }
        #endregion
             
        #region ICloneable Members
        /// <summary cref="NodeSource.Clone(NodeSource)" />
        public override NodeSource Clone(NodeSource parent)
        {
            lock (DataLock)
            {
                MaintenanceEventType clone = new MaintenanceEventType(Server);
                clone.Initialize(this);
                return clone;
            }
        }
        #endregion
      
        #region Public Properties
        #region MustCompleteByDate
        /// <summary>
        /// When the maintenence must be completed.
        /// </summary>
        public Property<DateTime> MustCompleteByDate
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_mustCompleteByDate; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_mustCompleteByDate != null)
                    {
                        RemoveChild(m_mustCompleteByDate);
                    }

                    m_mustCompleteByDate = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceMustCompleteByDate(Property<DateTime> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                MustCompleteByDate = replacement;

                MustCompleteByDate.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.MustCompleteByDate, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.MaintenanceEventType_MustCompleteByDate,
                    null);
            }
        }
        #endregion

        #region IsScheduled
        /// <summary>
        /// True if the required maintenence is regularily scheduled.
        /// </summary>
        public Property<bool> IsScheduled
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_isScheduled; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_isScheduled != null)
                    {
                        RemoveChild(m_isScheduled);
                    }

                    m_isScheduled = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceIsScheduled(Property<bool> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                IsScheduled = replacement;

                IsScheduled.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.IsScheduled, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.MaintenanceEventType_IsScheduled,
                    null);
            }
        }
        #endregion
        #endregion

        #region Overridden Methods
        /// <summary cref="NodeSource.Initialize(NodeSource)" />
        public override void Initialize(NodeSource source)
        {
            lock (DataLock)
            {
                base.Initialize(source);
                
                MaintenanceEventType type = source as MaintenanceEventType;

                if (type != null && type.MustCompleteByDate != null)
                {
                    MustCompleteByDate = (Property<DateTime>)type.MustCompleteByDate.Clone(this);
                    MustCompleteByDate.Initialize(type.MustCompleteByDate);
                }

                if (type != null && type.IsScheduled != null)
                {
                    IsScheduled = (Property<bool>)type.IsScheduled.Clone(this);
                    IsScheduled.Initialize(type.IsScheduled);
                }
            }
        }

        /// <summary cref="NodeSource.InitializeChildren" />
        protected override void InitializeChildren()
        {
            base.InitializeChildren();
                
            m_mustCompleteByDate = Property<DateTime>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.MaintenanceEventType_MustCompleteByDate, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.MustCompleteByDate, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.MaintenanceEventType_MustCompleteByDate);

            m_isScheduled = Property<bool>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.MaintenanceEventType_IsScheduled, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.IsScheduled, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.MaintenanceEventType_IsScheduled);
        }
        #endregion

        #region Private Fields
        Property<DateTime> m_mustCompleteByDate;
        Property<bool> m_isScheduled;
        #endregion
    }
    #endregion

    #region MaintenanceEvent Class
    /// <summary>
    /// Represents an instance of the MaintenanceEventType ObjectType in the address space.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class MaintenanceEvent : BaseEvent
    {
        #region Constructors
        /// <summary>
        /// Initializes the object with default values.
        /// </summary>
        protected MaintenanceEvent(IServerInternal server, NodeSource parent) 
        : 
            base(server, parent)
        {
            m_typeDefinition = MaintenanceEventType.FindSource(server);
        }

        /// <summary>
        /// Creates a new instance of the node.
        /// </summary>
        public static new MaintenanceEvent Construct(
            IServerInternal server, 
            NodeSource      parent, 
            NodeId          referenceTypeId,
            NodeId          nodeId,
            QualifiedName   browseName,
            uint            numericId)
        {
            MaintenanceEvent instance = new MaintenanceEvent(server, parent);
            instance.Initialize(referenceTypeId, nodeId, browseName, numericId, instance.m_typeDefinition.NodeId);
            return instance;
        }

        /// <summary>
        /// Creates a new instance of the node without any parent.
        /// </summary>
        public static new MaintenanceEvent Construct(IServerInternal server)
        {
            MaintenanceEvent instance = new MaintenanceEvent(server, (NodeSource)null);
            instance.Initialize(null, null, null, 0, instance.m_typeDefinition.NodeId);
            return instance;
        }
        #endregion
           
        #region ICloneable Members
        /// <summary cref="NodeSource.Clone(NodeSource)" />
        public override NodeSource Clone(NodeSource parent)
        {
            lock (DataLock)
            {
                MaintenanceEvent clone = new MaintenanceEvent(Server, parent);
                clone.Initialize(this);
                return clone;
            } 
        }
        #endregion

        #region Public Properties
        #region MustCompleteByDate
        /// <summary>
        /// When the maintenence must be completed.
        /// </summary>
        public Property<DateTime> MustCompleteByDate
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_mustCompleteByDate; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_mustCompleteByDate != null)
                    {
                        RemoveChild(m_mustCompleteByDate);
                    }

                    m_mustCompleteByDate = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceMustCompleteByDate(Property<DateTime> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                MustCompleteByDate = replacement;

                MustCompleteByDate.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.MustCompleteByDate, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.MaintenanceEventType_MustCompleteByDate,
                    null);
            }
        }
        #endregion

        #region IsScheduled
        /// <summary>
        /// True if the required maintenence is regularily scheduled.
        /// </summary>
        public Property<bool> IsScheduled
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_isScheduled; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_isScheduled != null)
                    {
                        RemoveChild(m_isScheduled);
                    }

                    m_isScheduled = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceIsScheduled(Property<bool> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                IsScheduled = replacement;

                IsScheduled.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.IsScheduled, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.MaintenanceEventType_IsScheduled,
                    null);
            }
        }
        #endregion
        #endregion

        #region Overridden Methods
        /// <summary cref="NodeSource.Initialize(NodeSource)" />
        public override void Initialize(NodeSource source)
        {
            lock (DataLock)
            {            
                MaintenanceEvent instance = source as MaintenanceEvent;

                if (instance != null)
                {
                    base.Initialize(source);
                }

                MaintenanceEventType type = source as MaintenanceEventType;

                if (type != null && type.MustCompleteByDate != null)
                {
                    MustCompleteByDate = (Property<DateTime>)type.MustCompleteByDate.Clone(this);
                    MustCompleteByDate.Initialize(type.MustCompleteByDate);
                }
                else if (instance != null && instance.MustCompleteByDate != null)
                {
                    MustCompleteByDate = (Property<DateTime>)instance.MustCompleteByDate.Clone(this);
                    MustCompleteByDate.Initialize(instance.MustCompleteByDate);
                }

                if (type != null && type.IsScheduled != null)
                {
                    IsScheduled = (Property<bool>)type.IsScheduled.Clone(this);
                    IsScheduled.Initialize(type.IsScheduled);
                }
                else if (instance != null && instance.IsScheduled != null)
                {
                    IsScheduled = (Property<bool>)instance.IsScheduled.Clone(this);
                    IsScheduled.Initialize(instance.IsScheduled);
                }
            }
        }

        /// <summary cref="NodeSource.InitializeChildren" />
        protected override void InitializeChildren()
        {
            base.InitializeChildren();
                
            m_mustCompleteByDate = Property<DateTime>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.MustCompleteByDate, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.MaintenanceEventType_MustCompleteByDate);

            m_isScheduled = Property<bool>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.IsScheduled, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.MaintenanceEventType_IsScheduled);
        }
        #endregion

        #region Private Fields
        private MaintenanceEventType m_typeDefinition;
        Property<DateTime> m_mustCompleteByDate;
        Property<bool> m_isScheduled;
        #endregion
    }
    #endregion

    #region Maintenance2EventType Class
    /// <summary>
    /// Represents the Maintenance2EventType ObjectType in the address space.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class Maintenance2EventType : ObjectTypeSource
    {
        #region Constructors
        /// <summary>
        /// Initializes the object with default values.
        /// </summary>
        public Maintenance2EventType(IServerInternal server) : base(server)
        {
            Initialize(
                new NodeId(Opc.Ua.Sample.ObjectTypes.Maintenance2EventType, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                new QualifiedName(Opc.Ua.Sample.BrowseNames.Maintenance2EventType, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                new NodeId(Opc.Ua.Sample.ObjectTypes.MaintenanceEventType, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)));
                    
            server.TypeSources.SetTypeSource(this.NodeId, this);
        }

        /// <summary>
        /// Finds the source for the type definition (creates it if it does not exist).
        /// </summary>
        public static new Maintenance2EventType FindSource(IServerInternal server)
        {
            Maintenance2EventType type = null;
                    
            lock (server.TypeSources.SyncRoot)
            {
                NodeId typeId = new NodeId(Opc.Ua.Sample.ObjectTypes.Maintenance2EventType, server.NamespaceUris.GetIndexOrAppend(Opc.Ua.Sample.Namespaces.Sample));

                type = server.TypeSources.FindTypeSource(typeId) as Maintenance2EventType;

                if (type != null)
                {
                    return type;
                }

                type = new Maintenance2EventType(server);
            }

            return type;
        }
        #endregion
             
        #region ICloneable Members
        /// <summary cref="NodeSource.Clone(NodeSource)" />
        public override NodeSource Clone(NodeSource parent)
        {
            lock (DataLock)
            {
                Maintenance2EventType clone = new Maintenance2EventType(Server);
                clone.Initialize(this);
                return clone;
            }
        }
        #endregion
      
        #region Public Properties
        #region WorkorderId
        /// <summary>
        /// The identifier for the work order.
        /// </summary>
        public Property<string> WorkorderId
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_workorderId; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_workorderId != null)
                    {
                        RemoveChild(m_workorderId);
                    }

                    m_workorderId = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceWorkorderId(Property<string> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                WorkorderId = replacement;

                WorkorderId.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.WorkorderId, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.Maintenance2EventType_WorkorderId,
                    null);
            }
        }
        #endregion
        #endregion

        #region Overridden Methods
        /// <summary cref="NodeSource.Initialize(NodeSource)" />
        public override void Initialize(NodeSource source)
        {
            lock (DataLock)
            {
                base.Initialize(source);
                
                Maintenance2EventType type = source as Maintenance2EventType;

                if (type != null && type.WorkorderId != null)
                {
                    WorkorderId = (Property<string>)type.WorkorderId.Clone(this);
                    WorkorderId.Initialize(type.WorkorderId);
                }
            }
        }

        /// <summary cref="NodeSource.InitializeChildren" />
        protected override void InitializeChildren()
        {
            base.InitializeChildren();
                
            m_workorderId = Property<string>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.Maintenance2EventType_WorkorderId, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.WorkorderId, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.Maintenance2EventType_WorkorderId);
        }
        #endregion

        #region Private Fields
        Property<string> m_workorderId;
        #endregion
    }
    #endregion

    #region Maintenance2Event Class
    /// <summary>
    /// Represents an instance of the Maintenance2EventType ObjectType in the address space.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class Maintenance2Event : MaintenanceEvent
    {
        #region Constructors
        /// <summary>
        /// Initializes the object with default values.
        /// </summary>
        protected Maintenance2Event(IServerInternal server, NodeSource parent) 
        : 
            base(server, parent)
        {
            m_typeDefinition = Maintenance2EventType.FindSource(server);
        }

        /// <summary>
        /// Creates a new instance of the node.
        /// </summary>
        public static new Maintenance2Event Construct(
            IServerInternal server, 
            NodeSource      parent, 
            NodeId          referenceTypeId,
            NodeId          nodeId,
            QualifiedName   browseName,
            uint            numericId)
        {
            Maintenance2Event instance = new Maintenance2Event(server, parent);
            instance.Initialize(referenceTypeId, nodeId, browseName, numericId, instance.m_typeDefinition.NodeId);
            return instance;
        }

        /// <summary>
        /// Creates a new instance of the node without any parent.
        /// </summary>
        public static new Maintenance2Event Construct(IServerInternal server)
        {
            Maintenance2Event instance = new Maintenance2Event(server, (NodeSource)null);
            instance.Initialize(null, null, null, 0, instance.m_typeDefinition.NodeId);
            return instance;
        }
        #endregion
           
        #region ICloneable Members
        /// <summary cref="NodeSource.Clone(NodeSource)" />
        public override NodeSource Clone(NodeSource parent)
        {
            lock (DataLock)
            {
                Maintenance2Event clone = new Maintenance2Event(Server, parent);
                clone.Initialize(this);
                return clone;
            } 
        }
        #endregion

        #region Public Properties
        #region WorkorderId
        /// <summary>
        /// The identifier for the work order.
        /// </summary>
        public Property<string> WorkorderId
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_workorderId; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_workorderId != null)
                    {
                        RemoveChild(m_workorderId);
                    }

                    m_workorderId = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceWorkorderId(Property<string> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                WorkorderId = replacement;

                WorkorderId.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.WorkorderId, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.Maintenance2EventType_WorkorderId,
                    null);
            }
        }
        #endregion
        #endregion

        #region Overridden Methods
        /// <summary cref="NodeSource.Initialize(NodeSource)" />
        public override void Initialize(NodeSource source)
        {
            lock (DataLock)
            {            
                Maintenance2Event instance = source as Maintenance2Event;

                if (instance != null)
                {
                    base.Initialize(source);
                }

                Maintenance2EventType type = source as Maintenance2EventType;

                if (type != null && type.WorkorderId != null)
                {
                    WorkorderId = (Property<string>)type.WorkorderId.Clone(this);
                    WorkorderId.Initialize(type.WorkorderId);
                }
                else if (instance != null && instance.WorkorderId != null)
                {
                    WorkorderId = (Property<string>)instance.WorkorderId.Clone(this);
                    WorkorderId.Initialize(instance.WorkorderId);
                }
            }
        }

        /// <summary cref="NodeSource.InitializeChildren" />
        protected override void InitializeChildren()
        {
            base.InitializeChildren();
                
            m_workorderId = Property<string>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.WorkorderId, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.Maintenance2EventType_WorkorderId);
        }
        #endregion

        #region Private Fields
        private Maintenance2EventType m_typeDefinition;
        Property<string> m_workorderId;
        #endregion
    }
    #endregion

    #region AddressType Class
    /// <summary>
    /// Represents the AddressType VariableType in the address space.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class AddressType : VariableTypeSource<AddressDataType>
    {
        #region Constructors
        /// <summary>
        /// Initializes the object with default values.
        /// </summary>
        public AddressType(IServerInternal server) : base(server)
        {
            Initialize(
                new NodeId(Opc.Ua.Sample.VariableTypes.AddressType, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                new QualifiedName(Opc.Ua.Sample.BrowseNames.AddressType, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                new NodeId(Opc.Ua.VariableTypes.BaseDataVariableType, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)));
                    
            server.TypeSources.SetTypeSource(this.NodeId, this);
        }

        /// <summary>
        /// Finds the source for the type definition (creates it if it does not exist).
        /// </summary>
        public static new AddressType FindSource(IServerInternal server)
        {
            AddressType type = null;
                    
            lock (server.TypeSources.SyncRoot)
            {
                NodeId typeId = new NodeId(Opc.Ua.Sample.VariableTypes.AddressType, server.NamespaceUris.GetIndexOrAppend(Opc.Ua.Sample.Namespaces.Sample));

                type = server.TypeSources.FindTypeSource(typeId) as AddressType;

                if (type != null)
                {
                    return type;
                }

                type = new AddressType(server);
            }

            return type;
        }
        #endregion
             
        #region ICloneable Members
        /// <summary cref="NodeSource.Clone(NodeSource)" />
        public override NodeSource Clone(NodeSource parent)
        {
            lock (DataLock)
            {
                AddressType clone = new AddressType(Server);
                clone.Initialize(this);
                return clone;
            }
        }
        #endregion
      
        #region Public Properties
        #endregion

        #region Overridden Methods
        /// <summary cref="NodeSource.Initialize(NodeSource)" />
        public override void Initialize(NodeSource source)
        {
            lock (DataLock)
            {
                base.Initialize(source);
                
                AddressType type = source as AddressType;

            }
        }

        /// <summary cref="NodeSource.InitializeChildren" />
        protected override void InitializeChildren()
        {
            base.InitializeChildren();
                
        }
        #endregion

        #region Private Fields
        #endregion
    }
    #endregion

    #region Address Class
    /// <summary>
    /// Represents an instance of the AddressType VariableType in the address space.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class Address : DataVariable<AddressDataType>
    {
        #region Constructors
        /// <summary>
        /// Initializes the object with default values.
        /// </summary>
        protected Address(IServerInternal server, NodeSource parent) 
        : 
            base(server, parent)
        {
            m_typeDefinition = AddressType.FindSource(server);
        }

        /// <summary>
        /// Creates a new instance of the node.
        /// </summary>
        public static new Address Construct(
            IServerInternal server, 
            NodeSource      parent, 
            NodeId          referenceTypeId,
            NodeId          nodeId,
            QualifiedName   browseName,
            uint            numericId)
        {
            Address instance = new Address(server, parent);
            instance.Initialize(referenceTypeId, nodeId, browseName, numericId, instance.m_typeDefinition.NodeId);
            return instance;
        }

        /// <summary>
        /// Creates a new instance of the node without any parent.
        /// </summary>
        public static new Address Construct(IServerInternal server)
        {
            Address instance = new Address(server, (NodeSource)null);
            instance.Initialize(null, null, null, 0, instance.m_typeDefinition.NodeId);
            return instance;
        }
        #endregion
           
        #region ICloneable Members
        /// <summary cref="NodeSource.Clone(NodeSource)" />
        public override NodeSource Clone(NodeSource parent)
        {
            lock (DataLock)
            {
                Address clone = new Address(Server, parent);
                clone.Initialize(this);
                return clone;
            } 
        }
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        /// <summary cref="NodeSource.Initialize(NodeSource)" />
        public override void Initialize(NodeSource source)
        {
            lock (DataLock)
            {            
                Address instance = source as Address;

                if (instance != null)
                {
                    base.Initialize(source);
                }

                AddressType type = source as AddressType;

            }
        }

        /// <summary cref="NodeSource.InitializeChildren" />
        protected override void InitializeChildren()
        {
            base.InitializeChildren();
                
        }
        #endregion

        #region Private Fields
        private AddressType m_typeDefinition;
        #endregion
    }
    #endregion

    #region VendorType Class
    /// <summary>
    /// Represents the VendorType ObjectType in the address space.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class VendorType : ObjectTypeSource
    {
        #region Constructors
        /// <summary>
        /// Initializes the object with default values.
        /// </summary>
        public VendorType(IServerInternal server) : base(server)
        {
            Initialize(
                new NodeId(Opc.Ua.Sample.ObjectTypes.VendorType, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                new QualifiedName(Opc.Ua.Sample.BrowseNames.VendorType, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                new NodeId(Opc.Ua.ObjectTypes.BaseObjectType, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)));
                    
            server.TypeSources.SetTypeSource(this.NodeId, this);
        }

        /// <summary>
        /// Finds the source for the type definition (creates it if it does not exist).
        /// </summary>
        public static new VendorType FindSource(IServerInternal server)
        {
            VendorType type = null;
                    
            lock (server.TypeSources.SyncRoot)
            {
                NodeId typeId = new NodeId(Opc.Ua.Sample.ObjectTypes.VendorType, server.NamespaceUris.GetIndexOrAppend(Opc.Ua.Sample.Namespaces.Sample));

                type = server.TypeSources.FindTypeSource(typeId) as VendorType;

                if (type != null)
                {
                    return type;
                }

                type = new VendorType(server);
            }

            return type;
        }
        #endregion
             
        #region ICloneable Members
        /// <summary cref="NodeSource.Clone(NodeSource)" />
        public override NodeSource Clone(NodeSource parent)
        {
            lock (DataLock)
            {
                VendorType clone = new VendorType(Server);
                clone.Initialize(this);
                return clone;
            }
        }
        #endregion
      
        #region Public Properties
        #region CompanyName
        /// <summary>
        /// The name of the company.
        /// </summary>
        public Property<string> CompanyName
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_companyName; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_companyName != null)
                    {
                        RemoveChild(m_companyName);
                    }

                    m_companyName = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceCompanyName(Property<string> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                CompanyName = replacement;

                CompanyName.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.CompanyName, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.VendorType_CompanyName,
                    null);
            }
        }
        #endregion

        #region Locations
        /// <summary>
        /// The locations for the company.
        /// </summary>
        public Folder Locations
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_locations; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_locations != null)
                    {
                        RemoveChild(m_locations);
                    }

                    m_locations = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceLocations(Folder replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                Locations = replacement;

                Locations.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.Locations, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Objects.VendorType_Locations,
                    null);
            }
        }
        #endregion
        #endregion

        #region Overridden Methods
        /// <summary cref="NodeSource.Initialize(NodeSource)" />
        public override void Initialize(NodeSource source)
        {
            lock (DataLock)
            {
                base.Initialize(source);
                
                VendorType type = source as VendorType;

                if (type != null && type.CompanyName != null)
                {
                    CompanyName = (Property<string>)type.CompanyName.Clone(this);
                    CompanyName.Initialize(type.CompanyName);
                }

                if (type != null && type.Locations != null)
                {
                    Locations = (Folder)type.Locations.Clone(this);
                    Locations.Initialize(type.Locations);
                }
            }
        }

        /// <summary cref="NodeSource.InitializeChildren" />
        protected override void InitializeChildren()
        {
            base.InitializeChildren();
                
            m_companyName = Property<string>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.VendorType_CompanyName, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.CompanyName, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.VendorType_CompanyName);

            m_locations = Folder.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Objects.VendorType_Locations, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.Locations, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Objects.VendorType_Locations);
        }
        #endregion

        #region Private Fields
        Property<string> m_companyName;
        Folder m_locations;
        #endregion
    }
    #endregion

    #region Vendor Class
    /// <summary>
    /// Represents an instance of the VendorType ObjectType in the address space.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class Vendor : ObjectSource
    {
        #region Constructors
        /// <summary>
        /// Initializes the object with default values.
        /// </summary>
        protected Vendor(IServerInternal server, NodeSource parent) 
        : 
            base(server, parent)
        {
            m_typeDefinition = VendorType.FindSource(server);
        }

        /// <summary>
        /// Creates a new instance of the node.
        /// </summary>
        public static new Vendor Construct(
            IServerInternal server, 
            NodeSource      parent, 
            NodeId          referenceTypeId,
            NodeId          nodeId,
            QualifiedName   browseName,
            uint            numericId)
        {
            Vendor instance = new Vendor(server, parent);
            instance.Initialize(referenceTypeId, nodeId, browseName, numericId, instance.m_typeDefinition.NodeId);
            return instance;
        }

        /// <summary>
        /// Creates a new instance of the node without any parent.
        /// </summary>
        public static new Vendor Construct(IServerInternal server)
        {
            Vendor instance = new Vendor(server, (NodeSource)null);
            instance.Initialize(null, null, null, 0, instance.m_typeDefinition.NodeId);
            return instance;
        }
        #endregion
           
        #region ICloneable Members
        /// <summary cref="NodeSource.Clone(NodeSource)" />
        public override NodeSource Clone(NodeSource parent)
        {
            lock (DataLock)
            {
                Vendor clone = new Vendor(Server, parent);
                clone.Initialize(this);
                return clone;
            } 
        }
        #endregion

        #region Public Properties
        #region CompanyName
        /// <summary>
        /// The name of the company.
        /// </summary>
        public Property<string> CompanyName
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_companyName; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_companyName != null)
                    {
                        RemoveChild(m_companyName);
                    }

                    m_companyName = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceCompanyName(Property<string> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                CompanyName = replacement;

                CompanyName.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.CompanyName, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.VendorType_CompanyName,
                    null);
            }
        }
        #endregion

        #region Locations
        /// <summary>
        /// The locations for the company.
        /// </summary>
        public Folder Locations
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_locations; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_locations != null)
                    {
                        RemoveChild(m_locations);
                    }

                    m_locations = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceLocations(Folder replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                Locations = replacement;

                Locations.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.Locations, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Objects.VendorType_Locations,
                    null);
            }
        }
        #endregion
        #endregion

        #region Overridden Methods
        /// <summary cref="NodeSource.Initialize(NodeSource)" />
        public override void Initialize(NodeSource source)
        {
            lock (DataLock)
            {            
                Vendor instance = source as Vendor;

                if (instance != null)
                {
                    base.Initialize(source);
                }

                VendorType type = source as VendorType;

                if (type != null && type.CompanyName != null)
                {
                    CompanyName = (Property<string>)type.CompanyName.Clone(this);
                    CompanyName.Initialize(type.CompanyName);
                }
                else if (instance != null && instance.CompanyName != null)
                {
                    CompanyName = (Property<string>)instance.CompanyName.Clone(this);
                    CompanyName.Initialize(instance.CompanyName);
                }

                if (type != null && type.Locations != null)
                {
                    Locations = (Folder)type.Locations.Clone(this);
                    Locations.Initialize(type.Locations);
                }
                else if (instance != null && instance.Locations != null)
                {
                    Locations = (Folder)instance.Locations.Clone(this);
                    Locations.Initialize(instance.Locations);
                }
            }
        }

        /// <summary cref="NodeSource.InitializeChildren" />
        protected override void InitializeChildren()
        {
            base.InitializeChildren();
                
            m_companyName = Property<string>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.CompanyName, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.VendorType_CompanyName);

            m_locations = Folder.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.Locations, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Objects.VendorType_Locations);
        }
        #endregion

        #region Private Fields
        private VendorType m_typeDefinition;
        Property<string> m_companyName;
        Folder m_locations;
        #endregion
    }
    #endregion

    #region GenerateValuesMethodTypeMethodSource Class
    /// <summary>
    /// Implements a method which may be used by many nodes.
    /// </summary>
    public partial class GenerateValuesMethodTypeMethodSource : MethodSource
    {
        #region Constructors
        /// <summary>
        /// Initializes the object with default values.
        /// </summary>
        public GenerateValuesMethodTypeMethodSource(IServerInternal server, NodeSource parent) : base(server, parent)
        {
            Arguments = CreateArguments();
        }
        
        /// <summary>
        /// Creates a new instance of the node.
        /// </summary>
        public static new GenerateValuesMethodTypeMethodSource Construct(
            IServerInternal server, 
            NodeSource      parent, 
            NodeId          referenceTypeId,
            NodeId          nodeId,
            QualifiedName   browseName,
            uint            numericId)
        {
            GenerateValuesMethodTypeMethodSource instance = new GenerateValuesMethodTypeMethodSource(server, parent);
            instance.Initialize(referenceTypeId, nodeId, browseName, numericId, null);
            return instance;
        }
        #endregion
         
        #region ICloneable Members
        /// <summary cref="NodeSource.Clone(NodeSource)" />
        public override NodeSource Clone(NodeSource parent)
        {
            lock (DataLock)
            {
                GenerateValuesMethodTypeMethodSource clone = new GenerateValuesMethodTypeMethodSource(Server, parent);
                clone.Initialize(this);
                return clone;
            }
        }
        #endregion

        #region Public Interface
        /// <summary>
        /// Calls the GenerateValuesMethodType method.
        /// </summary>
        public void Call(OperationContext context, NodeSource target, uint iterations)
        {    
            List<object> inputArguments = new List<object>();
            List<ServiceResult> argumentErrors = new List<ServiceResult>();
            List<object> outputArguments = new List<object>();
            
            inputArguments.Add(iterations);

            ServiceResult result = Call(
                context, 
                NodeId, 
                null, 
                Parent.NodeId, 
                inputArguments, 
                argumentErrors, 
                outputArguments);

            if (ServiceResult.IsBad(result))
            {
                throw new ServiceResultException(result);
            }
                
        }
        #endregion
        
        #region Protected Methods
        /// <summary>
        /// Called when the GenerateValuesMethodType method is called.
        /// </summary>
        protected override void Call(
            OperationContext     context, 
            NodeSource           target,
            Delegate             methodToCall,
            IList<object>        inputArguments,
            IList<ServiceResult> argumentErrors,
            IList<object>        outputArguments)
        {
            GenerateValuesMethodTypeMethodHandler Callback = methodToCall as GenerateValuesMethodTypeMethodHandler;

            if (Callback == null)
            {
                base.Call(context, target, methodToCall, inputArguments, argumentErrors, outputArguments);
                return;
            }

            uint iterations = (uint)inputArguments[0];

            Callback(context, target, iterations);
        }

        /// <summary>
        /// Creates the arguments for the GenerateValuesMethodType method.
        /// </summary>
        protected MethodArguments CreateArguments()
        {
            MethodArguments arguments = new MethodArguments();

            Argument argument = null;
            
            // Iterations
            argument = new Argument();

            argument.Name = "Iterations";
            argument.DataType = Opc.Ua.DataTypes.UInt32;
            argument.ValueRank = ValueRanks.Scalar;
            argument.Description = new LocalizedText("GenerateValuesMethodType_InputArgument_Iterations_Description", "en", "The number of new values to generate.");

            arguments.Input.Add(argument);
            

            return arguments;
        }
        #endregion
    }

    /// <summary>
    /// A delegate used to receive notifications when the method is called.
    /// </summary>
    public delegate void GenerateValuesMethodTypeMethodHandler(OperationContext context, NodeSource target, uint iterations);
    #endregion

    #region GenerateValuesEventType Class
    /// <summary>
    /// Represents the GenerateValuesEventType ObjectType in the address space.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class GenerateValuesEventType : ObjectTypeSource
    {
        #region Constructors
        /// <summary>
        /// Initializes the object with default values.
        /// </summary>
        public GenerateValuesEventType(IServerInternal server) : base(server)
        {
            Initialize(
                new NodeId(Opc.Ua.Sample.ObjectTypes.GenerateValuesEventType, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                new QualifiedName(Opc.Ua.Sample.BrowseNames.GenerateValuesEventType, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                new NodeId(Opc.Ua.ObjectTypes.BaseEventType, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)));
                    
            server.TypeSources.SetTypeSource(this.NodeId, this);
        }

        /// <summary>
        /// Finds the source for the type definition (creates it if it does not exist).
        /// </summary>
        public static new GenerateValuesEventType FindSource(IServerInternal server)
        {
            GenerateValuesEventType type = null;
                    
            lock (server.TypeSources.SyncRoot)
            {
                NodeId typeId = new NodeId(Opc.Ua.Sample.ObjectTypes.GenerateValuesEventType, server.NamespaceUris.GetIndexOrAppend(Opc.Ua.Sample.Namespaces.Sample));

                type = server.TypeSources.FindTypeSource(typeId) as GenerateValuesEventType;

                if (type != null)
                {
                    return type;
                }

                type = new GenerateValuesEventType(server);
            }

            return type;
        }
        #endregion
             
        #region ICloneable Members
        /// <summary cref="NodeSource.Clone(NodeSource)" />
        public override NodeSource Clone(NodeSource parent)
        {
            lock (DataLock)
            {
                GenerateValuesEventType clone = new GenerateValuesEventType(Server);
                clone.Initialize(this);
                return clone;
            }
        }
        #endregion
      
        #region Public Properties
        #region Iterations
        /// <summary>
        /// A description for the Iterations Property.
        /// </summary>
        public Property<uint> Iterations
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_iterations; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_iterations != null)
                    {
                        RemoveChild(m_iterations);
                    }

                    m_iterations = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceIterations(Property<uint> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                Iterations = replacement;

                Iterations.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.Iterations, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.GenerateValuesEventType_Iterations,
                    null);
            }
        }
        #endregion

        #region NewValueCount
        /// <summary>
        /// A description for the NewValueCount Property.
        /// </summary>
        public Property<uint> NewValueCount
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_newValueCount; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_newValueCount != null)
                    {
                        RemoveChild(m_newValueCount);
                    }

                    m_newValueCount = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceNewValueCount(Property<uint> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                NewValueCount = replacement;

                NewValueCount.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.NewValueCount, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.GenerateValuesEventType_NewValueCount,
                    null);
            }
        }
        #endregion
        #endregion

        #region Overridden Methods
        /// <summary cref="NodeSource.Initialize(NodeSource)" />
        public override void Initialize(NodeSource source)
        {
            lock (DataLock)
            {
                base.Initialize(source);
                
                GenerateValuesEventType type = source as GenerateValuesEventType;

                if (type != null && type.Iterations != null)
                {
                    Iterations = (Property<uint>)type.Iterations.Clone(this);
                    Iterations.Initialize(type.Iterations);
                }

                if (type != null && type.NewValueCount != null)
                {
                    NewValueCount = (Property<uint>)type.NewValueCount.Clone(this);
                    NewValueCount.Initialize(type.NewValueCount);
                }
            }
        }

        /// <summary cref="NodeSource.InitializeChildren" />
        protected override void InitializeChildren()
        {
            base.InitializeChildren();
                
            m_iterations = Property<uint>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.GenerateValuesEventType_Iterations, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.Iterations, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.GenerateValuesEventType_Iterations);

            m_newValueCount = Property<uint>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.GenerateValuesEventType_NewValueCount, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.NewValueCount, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.GenerateValuesEventType_NewValueCount);
        }
        #endregion

        #region Private Fields
        Property<uint> m_iterations;
        Property<uint> m_newValueCount;
        #endregion
    }
    #endregion

    #region GenerateValuesEvent Class
    /// <summary>
    /// Represents an instance of the GenerateValuesEventType ObjectType in the address space.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class GenerateValuesEvent : BaseEvent
    {
        #region Constructors
        /// <summary>
        /// Initializes the object with default values.
        /// </summary>
        protected GenerateValuesEvent(IServerInternal server, NodeSource parent) 
        : 
            base(server, parent)
        {
            m_typeDefinition = GenerateValuesEventType.FindSource(server);
        }

        /// <summary>
        /// Creates a new instance of the node.
        /// </summary>
        public static new GenerateValuesEvent Construct(
            IServerInternal server, 
            NodeSource      parent, 
            NodeId          referenceTypeId,
            NodeId          nodeId,
            QualifiedName   browseName,
            uint            numericId)
        {
            GenerateValuesEvent instance = new GenerateValuesEvent(server, parent);
            instance.Initialize(referenceTypeId, nodeId, browseName, numericId, instance.m_typeDefinition.NodeId);
            return instance;
        }

        /// <summary>
        /// Creates a new instance of the node without any parent.
        /// </summary>
        public static new GenerateValuesEvent Construct(IServerInternal server)
        {
            GenerateValuesEvent instance = new GenerateValuesEvent(server, (NodeSource)null);
            instance.Initialize(null, null, null, 0, instance.m_typeDefinition.NodeId);
            return instance;
        }
        #endregion
           
        #region ICloneable Members
        /// <summary cref="NodeSource.Clone(NodeSource)" />
        public override NodeSource Clone(NodeSource parent)
        {
            lock (DataLock)
            {
                GenerateValuesEvent clone = new GenerateValuesEvent(Server, parent);
                clone.Initialize(this);
                return clone;
            } 
        }
        #endregion

        #region Public Properties
        #region Iterations
        /// <summary>
        /// A description for the Iterations Property.
        /// </summary>
        public Property<uint> Iterations
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_iterations; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_iterations != null)
                    {
                        RemoveChild(m_iterations);
                    }

                    m_iterations = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceIterations(Property<uint> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                Iterations = replacement;

                Iterations.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.Iterations, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.GenerateValuesEventType_Iterations,
                    null);
            }
        }
        #endregion

        #region NewValueCount
        /// <summary>
        /// A description for the NewValueCount Property.
        /// </summary>
        public Property<uint> NewValueCount
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_newValueCount; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_newValueCount != null)
                    {
                        RemoveChild(m_newValueCount);
                    }

                    m_newValueCount = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceNewValueCount(Property<uint> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                NewValueCount = replacement;

                NewValueCount.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.NewValueCount, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.GenerateValuesEventType_NewValueCount,
                    null);
            }
        }
        #endregion
        #endregion

        #region Overridden Methods
        /// <summary cref="NodeSource.Initialize(NodeSource)" />
        public override void Initialize(NodeSource source)
        {
            lock (DataLock)
            {            
                GenerateValuesEvent instance = source as GenerateValuesEvent;

                if (instance != null)
                {
                    base.Initialize(source);
                }

                GenerateValuesEventType type = source as GenerateValuesEventType;

                if (type != null && type.Iterations != null)
                {
                    Iterations = (Property<uint>)type.Iterations.Clone(this);
                    Iterations.Initialize(type.Iterations);
                }
                else if (instance != null && instance.Iterations != null)
                {
                    Iterations = (Property<uint>)instance.Iterations.Clone(this);
                    Iterations.Initialize(instance.Iterations);
                }

                if (type != null && type.NewValueCount != null)
                {
                    NewValueCount = (Property<uint>)type.NewValueCount.Clone(this);
                    NewValueCount.Initialize(type.NewValueCount);
                }
                else if (instance != null && instance.NewValueCount != null)
                {
                    NewValueCount = (Property<uint>)instance.NewValueCount.Clone(this);
                    NewValueCount.Initialize(instance.NewValueCount);
                }
            }
        }

        /// <summary cref="NodeSource.InitializeChildren" />
        protected override void InitializeChildren()
        {
            base.InitializeChildren();
                
            m_iterations = Property<uint>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.Iterations, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.GenerateValuesEventType_Iterations);

            m_newValueCount = Property<uint>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.NewValueCount, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.GenerateValuesEventType_NewValueCount);
        }
        #endregion

        #region Private Fields
        private GenerateValuesEventType m_typeDefinition;
        Property<uint> m_iterations;
        Property<uint> m_newValueCount;
        #endregion
    }
    #endregion

    #region TestDataObjectType Class
    /// <summary>
    /// Represents the TestDataObjectType ObjectType in the address space.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class TestDataObjectType : ObjectTypeSource
    {
        #region Constructors
        /// <summary>
        /// Initializes the object with default values.
        /// </summary>
        public TestDataObjectType(IServerInternal server) : base(server)
        {
            Initialize(
                new NodeId(Opc.Ua.Sample.ObjectTypes.TestDataObjectType, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                new QualifiedName(Opc.Ua.Sample.BrowseNames.TestDataObjectType, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                new NodeId(Opc.Ua.ObjectTypes.BaseObjectType, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)));
                    
            server.TypeSources.SetTypeSource(this.NodeId, this);
        }

        /// <summary>
        /// Finds the source for the type definition (creates it if it does not exist).
        /// </summary>
        public static new TestDataObjectType FindSource(IServerInternal server)
        {
            TestDataObjectType type = null;
                    
            lock (server.TypeSources.SyncRoot)
            {
                NodeId typeId = new NodeId(Opc.Ua.Sample.ObjectTypes.TestDataObjectType, server.NamespaceUris.GetIndexOrAppend(Opc.Ua.Sample.Namespaces.Sample));

                type = server.TypeSources.FindTypeSource(typeId) as TestDataObjectType;

                if (type != null)
                {
                    return type;
                }

                type = new TestDataObjectType(server);
            }

            return type;
        }
        #endregion
             
        #region ICloneable Members
        /// <summary cref="NodeSource.Clone(NodeSource)" />
        public override NodeSource Clone(NodeSource parent)
        {
            lock (DataLock)
            {
                TestDataObjectType clone = new TestDataObjectType(Server);
                clone.Initialize(this);
                return clone;
            }
        }
        #endregion
      
        #region Public Properties
        #region SimulationActive
        /// <summary>
        /// If true the server will produce new values for each monitored variable.
        /// </summary>
        public Property<bool> SimulationActive
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_simulationActive; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_simulationActive != null)
                    {
                        RemoveChild(m_simulationActive);
                    }

                    m_simulationActive = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceSimulationActive(Property<bool> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                SimulationActive = replacement;

                SimulationActive.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.SimulationActive, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.TestDataObjectType_SimulationActive,
                    null);
            }
        }
        #endregion

        #region GenerateValuesMethod
        /// <summary>
        /// A description for the GenerateValues Method.
        /// </summary>
        public GenerateValuesMethodTypeMethodSource GenerateValuesMethod
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_generateValuesMethod; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_generateValuesMethod != null)
                    {
                        RemoveChild(m_generateValuesMethod);
                    }

                    m_generateValuesMethod = value; 
                }
            }
        }
            
        /// <summary>
        /// Calls the GenerateValues method.
        /// </summary>
        public void GenerateValues(OperationContext context, uint iterations)
        {     
            lock (DataLock)
            {     
                GenerateValuesMethod.Call(context, this, iterations);
            }
        }
            
        /// <summary>
        /// Sets the callback to use when the GenerateValues method is called.
        /// </summary>
        public void SetGenerateValuesCallback(GenerateValuesMethodTypeMethodHandler callback)
        {
            lock (DataLock)
            {  
                GenerateValuesMethod.SetCallback(this, callback);
            }
        }
        #endregion
        #endregion

        #region Overridden Methods
        /// <summary cref="NodeSource.Initialize(NodeSource)" />
        public override void Initialize(NodeSource source)
        {
            lock (DataLock)
            {
                base.Initialize(source);
                
                TestDataObjectType type = source as TestDataObjectType;

                if (type != null && type.SimulationActive != null)
                {
                    SimulationActive = (Property<bool>)type.SimulationActive.Clone(this);
                    SimulationActive.Initialize(type.SimulationActive);
                }
            }
        }

        /// <summary cref="NodeSource.InitializeChildren" />
        protected override void InitializeChildren()
        {
            base.InitializeChildren();
                
            m_simulationActive = Property<bool>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.TestDataObjectType_SimulationActive, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.SimulationActive, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.TestDataObjectType_SimulationActive);

            m_generateValuesMethod = GenerateValuesMethodTypeMethodSource.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Methods.TestDataObjectType_GenerateValues, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.GenerateValues, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Methods.TestDataObjectType_GenerateValues);
        }
        #endregion

        #region Private Fields
        Property<bool> m_simulationActive;
        GenerateValuesMethodTypeMethodSource m_generateValuesMethod;
        #endregion
    }
    #endregion

    #region TestDataObject Class
    /// <summary>
    /// Represents an instance of the TestDataObjectType ObjectType in the address space.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class TestDataObject : ObjectSource
    {
        #region Constructors
        /// <summary>
        /// Initializes the object with default values.
        /// </summary>
        protected TestDataObject(IServerInternal server, NodeSource parent) 
        : 
            base(server, parent)
        {
            m_typeDefinition = TestDataObjectType.FindSource(server);
        }

        /// <summary>
        /// Creates a new instance of the node.
        /// </summary>
        public static new TestDataObject Construct(
            IServerInternal server, 
            NodeSource      parent, 
            NodeId          referenceTypeId,
            NodeId          nodeId,
            QualifiedName   browseName,
            uint            numericId)
        {
            TestDataObject instance = new TestDataObject(server, parent);
            instance.Initialize(referenceTypeId, nodeId, browseName, numericId, instance.m_typeDefinition.NodeId);
            return instance;
        }

        /// <summary>
        /// Creates a new instance of the node without any parent.
        /// </summary>
        public static new TestDataObject Construct(IServerInternal server)
        {
            TestDataObject instance = new TestDataObject(server, (NodeSource)null);
            instance.Initialize(null, null, null, 0, instance.m_typeDefinition.NodeId);
            return instance;
        }
        #endregion
           
        #region ICloneable Members
        /// <summary cref="NodeSource.Clone(NodeSource)" />
        public override NodeSource Clone(NodeSource parent)
        {
            lock (DataLock)
            {
                TestDataObject clone = new TestDataObject(Server, parent);
                clone.Initialize(this);
                return clone;
            } 
        }
        #endregion

        #region Public Properties
        #region SimulationActive
        /// <summary>
        /// If true the server will produce new values for each monitored variable.
        /// </summary>
        public Property<bool> SimulationActive
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_simulationActive; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_simulationActive != null)
                    {
                        RemoveChild(m_simulationActive);
                    }

                    m_simulationActive = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceSimulationActive(Property<bool> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                SimulationActive = replacement;

                SimulationActive.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.SimulationActive, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.TestDataObjectType_SimulationActive,
                    null);
            }
        }
        #endregion

        #region GenerateValuesMethod
        /// <summary>
        /// A description for the GenerateValues Method.
        /// </summary>
        public GenerateValuesMethodTypeMethodSource GenerateValuesMethod
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_generateValuesMethod; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_generateValuesMethod != null)
                    {
                        RemoveChild(m_generateValuesMethod);
                    }

                    m_generateValuesMethod = value; 
                }
            }
        }
            
        /// <summary>
        /// Calls the GenerateValues method.
        /// </summary>
        public void GenerateValues(OperationContext context, uint iterations)
        {     
            lock (DataLock)
            {     
                GenerateValuesMethod.Call(context, this, iterations);
            }
        }
            
        /// <summary>
        /// Sets the callback to use when the GenerateValues method is called.
        /// </summary>
        public void SetGenerateValuesCallback(GenerateValuesMethodTypeMethodHandler callback)
        {
            lock (DataLock)
            {  
                GenerateValuesMethod.SetCallback(this, callback);
            }
        }
        #endregion
        #endregion

        #region Overridden Methods
        /// <summary cref="NodeSource.Initialize(NodeSource)" />
        public override void Initialize(NodeSource source)
        {
            lock (DataLock)
            {            
                TestDataObject instance = source as TestDataObject;

                if (instance != null)
                {
                    base.Initialize(source);
                }

                TestDataObjectType type = source as TestDataObjectType;

                if (type != null && type.SimulationActive != null)
                {
                    SimulationActive = (Property<bool>)type.SimulationActive.Clone(this);
                    SimulationActive.Initialize(type.SimulationActive);
                }
                else if (instance != null && instance.SimulationActive != null)
                {
                    SimulationActive = (Property<bool>)instance.SimulationActive.Clone(this);
                    SimulationActive.Initialize(instance.SimulationActive);
                }

                if (type != null && type.GenerateValuesMethod != null)
                {
                    GenerateValuesMethod = (GenerateValuesMethodTypeMethodSource)type.GenerateValuesMethod.Clone(this);
                    GenerateValuesMethod.Initialize(type.GenerateValuesMethod);
                }
                else if (instance != null && instance.GenerateValuesMethod != null)
                {
                    GenerateValuesMethod = (GenerateValuesMethodTypeMethodSource)instance.GenerateValuesMethod.Clone(this);
                    GenerateValuesMethod.Initialize(instance.GenerateValuesMethod);
                }
            }
        }

        /// <summary cref="NodeSource.InitializeChildren" />
        protected override void InitializeChildren()
        {
            base.InitializeChildren();
                
            m_simulationActive = Property<bool>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasProperty, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.SimulationActive, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.TestDataObjectType_SimulationActive);

            m_generateValuesMethod = GenerateValuesMethodTypeMethodSource.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.GenerateValues, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Methods.TestDataObjectType_GenerateValues);
        }
        #endregion

        #region Private Fields
        private TestDataObjectType m_typeDefinition;
        Property<bool> m_simulationActive;
        GenerateValuesMethodTypeMethodSource m_generateValuesMethod;
        #endregion
    }
    #endregion

    #region ScalarValueObjectType Class
    /// <summary>
    /// Represents the ScalarValueObjectType ObjectType in the address space.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class ScalarValueObjectType : ObjectTypeSource
    {
        #region Constructors
        /// <summary>
        /// Initializes the object with default values.
        /// </summary>
        public ScalarValueObjectType(IServerInternal server) : base(server)
        {
            Initialize(
                new NodeId(Opc.Ua.Sample.ObjectTypes.ScalarValueObjectType, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                new QualifiedName(Opc.Ua.Sample.BrowseNames.ScalarValueObjectType, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                new NodeId(Opc.Ua.Sample.ObjectTypes.TestDataObjectType, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)));
                    
            server.TypeSources.SetTypeSource(this.NodeId, this);
        }

        /// <summary>
        /// Finds the source for the type definition (creates it if it does not exist).
        /// </summary>
        public static new ScalarValueObjectType FindSource(IServerInternal server)
        {
            ScalarValueObjectType type = null;
                    
            lock (server.TypeSources.SyncRoot)
            {
                NodeId typeId = new NodeId(Opc.Ua.Sample.ObjectTypes.ScalarValueObjectType, server.NamespaceUris.GetIndexOrAppend(Opc.Ua.Sample.Namespaces.Sample));

                type = server.TypeSources.FindTypeSource(typeId) as ScalarValueObjectType;

                if (type != null)
                {
                    return type;
                }

                type = new ScalarValueObjectType(server);
            }

            return type;
        }
        #endregion
             
        #region ICloneable Members
        /// <summary cref="NodeSource.Clone(NodeSource)" />
        public override NodeSource Clone(NodeSource parent)
        {
            lock (DataLock)
            {
                ScalarValueObjectType clone = new ScalarValueObjectType(Server);
                clone.Initialize(this);
                return clone;
            }
        }
        #endregion
      
        #region Public Properties
        #region BooleanValue
        /// <summary>
        /// A description for the BooleanValue Variable.
        /// </summary>
        public DataVariable<bool> BooleanValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_booleanValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_booleanValue != null)
                    {
                        RemoveChild(m_booleanValue);
                    }

                    m_booleanValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceBooleanValue(DataVariable<bool> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                BooleanValue = replacement;

                BooleanValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.BooleanValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ScalarValueObjectType_BooleanValue,
                    null);
            }
        }
        #endregion

        #region SByteValue
        /// <summary>
        /// A description for the SByteValue Variable.
        /// </summary>
        public DataVariable<sbyte> SByteValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_sByteValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_sByteValue != null)
                    {
                        RemoveChild(m_sByteValue);
                    }

                    m_sByteValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceSByteValue(DataVariable<sbyte> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                SByteValue = replacement;

                SByteValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.SByteValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ScalarValueObjectType_SByteValue,
                    null);
            }
        }
        #endregion

        #region ByteValue
        /// <summary>
        /// A description for the ByteValue Variable.
        /// </summary>
        public DataVariable<byte> ByteValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_byteValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_byteValue != null)
                    {
                        RemoveChild(m_byteValue);
                    }

                    m_byteValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceByteValue(DataVariable<byte> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                ByteValue = replacement;

                ByteValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.ByteValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ScalarValueObjectType_ByteValue,
                    null);
            }
        }
        #endregion

        #region Int16Value
        /// <summary>
        /// A description for the Int16Value Variable.
        /// </summary>
        public DataVariable<short> Int16Value
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_int16Value; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_int16Value != null)
                    {
                        RemoveChild(m_int16Value);
                    }

                    m_int16Value = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceInt16Value(DataVariable<short> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                Int16Value = replacement;

                Int16Value.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.Int16Value, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ScalarValueObjectType_Int16Value,
                    null);
            }
        }
        #endregion

        #region UInt16Value
        /// <summary>
        /// A description for the UInt16Value Variable.
        /// </summary>
        public DataVariable<ushort> UInt16Value
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_uInt16Value; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_uInt16Value != null)
                    {
                        RemoveChild(m_uInt16Value);
                    }

                    m_uInt16Value = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceUInt16Value(DataVariable<ushort> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                UInt16Value = replacement;

                UInt16Value.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.UInt16Value, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ScalarValueObjectType_UInt16Value,
                    null);
            }
        }
        #endregion

        #region Int32Value
        /// <summary>
        /// A description for the Int32Value Variable.
        /// </summary>
        public DataVariable<int> Int32Value
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_int32Value; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_int32Value != null)
                    {
                        RemoveChild(m_int32Value);
                    }

                    m_int32Value = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceInt32Value(DataVariable<int> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                Int32Value = replacement;

                Int32Value.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.Int32Value, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ScalarValueObjectType_Int32Value,
                    null);
            }
        }
        #endregion

        #region UInt32Value
        /// <summary>
        /// A description for the UInt32Value Variable.
        /// </summary>
        public DataVariable<uint> UInt32Value
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_uInt32Value; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_uInt32Value != null)
                    {
                        RemoveChild(m_uInt32Value);
                    }

                    m_uInt32Value = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceUInt32Value(DataVariable<uint> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                UInt32Value = replacement;

                UInt32Value.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.UInt32Value, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ScalarValueObjectType_UInt32Value,
                    null);
            }
        }
        #endregion

        #region Int64Value
        /// <summary>
        /// A description for the Int64Value Variable.
        /// </summary>
        public DataVariable<long> Int64Value
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_int64Value; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_int64Value != null)
                    {
                        RemoveChild(m_int64Value);
                    }

                    m_int64Value = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceInt64Value(DataVariable<long> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                Int64Value = replacement;

                Int64Value.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.Int64Value, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ScalarValueObjectType_Int64Value,
                    null);
            }
        }
        #endregion

        #region UInt64Value
        /// <summary>
        /// A description for the UInt64Value Variable.
        /// </summary>
        public DataVariable<ulong> UInt64Value
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_uInt64Value; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_uInt64Value != null)
                    {
                        RemoveChild(m_uInt64Value);
                    }

                    m_uInt64Value = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceUInt64Value(DataVariable<ulong> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                UInt64Value = replacement;

                UInt64Value.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.UInt64Value, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ScalarValueObjectType_UInt64Value,
                    null);
            }
        }
        #endregion

        #region FloatValue
        /// <summary>
        /// A description for the FloatValue Variable.
        /// </summary>
        public DataVariable<float> FloatValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_floatValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_floatValue != null)
                    {
                        RemoveChild(m_floatValue);
                    }

                    m_floatValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceFloatValue(DataVariable<float> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                FloatValue = replacement;

                FloatValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.FloatValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ScalarValueObjectType_FloatValue,
                    null);
            }
        }
        #endregion

        #region DoubleValue
        /// <summary>
        /// A description for the DoubleValue Variable.
        /// </summary>
        public DataVariable<double> DoubleValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_doubleValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_doubleValue != null)
                    {
                        RemoveChild(m_doubleValue);
                    }

                    m_doubleValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceDoubleValue(DataVariable<double> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                DoubleValue = replacement;

                DoubleValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.DoubleValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ScalarValueObjectType_DoubleValue,
                    null);
            }
        }
        #endregion

        #region StringValue
        /// <summary>
        /// A description for the StringValue Variable.
        /// </summary>
        public DataVariable<string> StringValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_stringValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_stringValue != null)
                    {
                        RemoveChild(m_stringValue);
                    }

                    m_stringValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceStringValue(DataVariable<string> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                StringValue = replacement;

                StringValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.StringValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ScalarValueObjectType_StringValue,
                    null);
            }
        }
        #endregion

        #region DateTimeValue
        /// <summary>
        /// A description for the DateTimeValue Variable.
        /// </summary>
        public DataVariable<DateTime> DateTimeValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_dateTimeValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_dateTimeValue != null)
                    {
                        RemoveChild(m_dateTimeValue);
                    }

                    m_dateTimeValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceDateTimeValue(DataVariable<DateTime> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                DateTimeValue = replacement;

                DateTimeValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.DateTimeValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ScalarValueObjectType_DateTimeValue,
                    null);
            }
        }
        #endregion

        #region GuidValue
        /// <summary>
        /// A description for the GuidValue Variable.
        /// </summary>
        public DataVariable<Guid> GuidValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_guidValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_guidValue != null)
                    {
                        RemoveChild(m_guidValue);
                    }

                    m_guidValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceGuidValue(DataVariable<Guid> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                GuidValue = replacement;

                GuidValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.GuidValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ScalarValueObjectType_GuidValue,
                    null);
            }
        }
        #endregion

        #region ByteStringValue
        /// <summary>
        /// A description for the ByteStringValue Variable.
        /// </summary>
        public DataVariable<byte[]> ByteStringValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_byteStringValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_byteStringValue != null)
                    {
                        RemoveChild(m_byteStringValue);
                    }

                    m_byteStringValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceByteStringValue(DataVariable<byte[]> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                ByteStringValue = replacement;

                ByteStringValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.ByteStringValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ScalarValueObjectType_ByteStringValue,
                    null);
            }
        }
        #endregion

        #region XmlElementValue
        /// <summary>
        /// A description for the XmlElementValue Variable.
        /// </summary>
        public DataVariable<XmlElement> XmlElementValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_xmlElementValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_xmlElementValue != null)
                    {
                        RemoveChild(m_xmlElementValue);
                    }

                    m_xmlElementValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceXmlElementValue(DataVariable<XmlElement> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                XmlElementValue = replacement;

                XmlElementValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.XmlElementValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ScalarValueObjectType_XmlElementValue,
                    null);
            }
        }
        #endregion

        #region NodeIdValue
        /// <summary>
        /// A description for the NodeIdValue Variable.
        /// </summary>
        public DataVariable<NodeId> NodeIdValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_nodeIdValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_nodeIdValue != null)
                    {
                        RemoveChild(m_nodeIdValue);
                    }

                    m_nodeIdValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceNodeIdValue(DataVariable<NodeId> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                NodeIdValue = replacement;

                NodeIdValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.NodeIdValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ScalarValueObjectType_NodeIdValue,
                    null);
            }
        }
        #endregion

        #region ExpandedNodeIdValue
        /// <summary>
        /// A description for the ExpandedNodeIdValue Variable.
        /// </summary>
        public DataVariable<ExpandedNodeId> ExpandedNodeIdValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_expandedNodeIdValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_expandedNodeIdValue != null)
                    {
                        RemoveChild(m_expandedNodeIdValue);
                    }

                    m_expandedNodeIdValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceExpandedNodeIdValue(DataVariable<ExpandedNodeId> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                ExpandedNodeIdValue = replacement;

                ExpandedNodeIdValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.ExpandedNodeIdValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ScalarValueObjectType_ExpandedNodeIdValue,
                    null);
            }
        }
        #endregion

        #region QualifiedNameValue
        /// <summary>
        /// A description for the QualifiedNameValue Variable.
        /// </summary>
        public DataVariable<QualifiedName> QualifiedNameValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_qualifiedNameValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_qualifiedNameValue != null)
                    {
                        RemoveChild(m_qualifiedNameValue);
                    }

                    m_qualifiedNameValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceQualifiedNameValue(DataVariable<QualifiedName> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                QualifiedNameValue = replacement;

                QualifiedNameValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.QualifiedNameValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ScalarValueObjectType_QualifiedNameValue,
                    null);
            }
        }
        #endregion

        #region LocalizedTextValue
        /// <summary>
        /// A description for the LocalizedTextValue Variable.
        /// </summary>
        public DataVariable<LocalizedText> LocalizedTextValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_localizedTextValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_localizedTextValue != null)
                    {
                        RemoveChild(m_localizedTextValue);
                    }

                    m_localizedTextValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceLocalizedTextValue(DataVariable<LocalizedText> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                LocalizedTextValue = replacement;

                LocalizedTextValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.LocalizedTextValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ScalarValueObjectType_LocalizedTextValue,
                    null);
            }
        }
        #endregion

        #region StatusCodeValue
        /// <summary>
        /// A description for the StatusCodeValue Variable.
        /// </summary>
        public DataVariable<StatusCode> StatusCodeValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_statusCodeValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_statusCodeValue != null)
                    {
                        RemoveChild(m_statusCodeValue);
                    }

                    m_statusCodeValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceStatusCodeValue(DataVariable<StatusCode> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                StatusCodeValue = replacement;

                StatusCodeValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.StatusCodeValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ScalarValueObjectType_StatusCodeValue,
                    null);
            }
        }
        #endregion

        #region VariantValue
        /// <summary>
        /// A description for the VariantValue Variable.
        /// </summary>
        public DataVariable<object> VariantValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_variantValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_variantValue != null)
                    {
                        RemoveChild(m_variantValue);
                    }

                    m_variantValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceVariantValue(DataVariable<object> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                VariantValue = replacement;

                VariantValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.VariantValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ScalarValueObjectType_VariantValue,
                    null);
            }
        }
        #endregion

        #region StructureValue
        /// <summary>
        /// A description for the StructureValue Variable.
        /// </summary>
        public DataVariable<IEncodeable> StructureValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_structureValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_structureValue != null)
                    {
                        RemoveChild(m_structureValue);
                    }

                    m_structureValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceStructureValue(DataVariable<IEncodeable> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                StructureValue = replacement;

                StructureValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.StructureValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ScalarValueObjectType_StructureValue,
                    null);
            }
        }
        #endregion
        #endregion

        #region Overridden Methods
        /// <summary cref="NodeSource.Initialize(NodeSource)" />
        public override void Initialize(NodeSource source)
        {
            lock (DataLock)
            {
                base.Initialize(source);
                
                ScalarValueObjectType type = source as ScalarValueObjectType;

                if (type != null && type.BooleanValue != null)
                {
                    BooleanValue = (DataVariable<bool>)type.BooleanValue.Clone(this);
                    BooleanValue.Initialize(type.BooleanValue);
                }

                if (type != null && type.SByteValue != null)
                {
                    SByteValue = (DataVariable<sbyte>)type.SByteValue.Clone(this);
                    SByteValue.Initialize(type.SByteValue);
                }

                if (type != null && type.ByteValue != null)
                {
                    ByteValue = (DataVariable<byte>)type.ByteValue.Clone(this);
                    ByteValue.Initialize(type.ByteValue);
                }

                if (type != null && type.Int16Value != null)
                {
                    Int16Value = (DataVariable<short>)type.Int16Value.Clone(this);
                    Int16Value.Initialize(type.Int16Value);
                }

                if (type != null && type.UInt16Value != null)
                {
                    UInt16Value = (DataVariable<ushort>)type.UInt16Value.Clone(this);
                    UInt16Value.Initialize(type.UInt16Value);
                }

                if (type != null && type.Int32Value != null)
                {
                    Int32Value = (DataVariable<int>)type.Int32Value.Clone(this);
                    Int32Value.Initialize(type.Int32Value);
                }

                if (type != null && type.UInt32Value != null)
                {
                    UInt32Value = (DataVariable<uint>)type.UInt32Value.Clone(this);
                    UInt32Value.Initialize(type.UInt32Value);
                }

                if (type != null && type.Int64Value != null)
                {
                    Int64Value = (DataVariable<long>)type.Int64Value.Clone(this);
                    Int64Value.Initialize(type.Int64Value);
                }

                if (type != null && type.UInt64Value != null)
                {
                    UInt64Value = (DataVariable<ulong>)type.UInt64Value.Clone(this);
                    UInt64Value.Initialize(type.UInt64Value);
                }

                if (type != null && type.FloatValue != null)
                {
                    FloatValue = (DataVariable<float>)type.FloatValue.Clone(this);
                    FloatValue.Initialize(type.FloatValue);
                }

                if (type != null && type.DoubleValue != null)
                {
                    DoubleValue = (DataVariable<double>)type.DoubleValue.Clone(this);
                    DoubleValue.Initialize(type.DoubleValue);
                }

                if (type != null && type.StringValue != null)
                {
                    StringValue = (DataVariable<string>)type.StringValue.Clone(this);
                    StringValue.Initialize(type.StringValue);
                }

                if (type != null && type.DateTimeValue != null)
                {
                    DateTimeValue = (DataVariable<DateTime>)type.DateTimeValue.Clone(this);
                    DateTimeValue.Initialize(type.DateTimeValue);
                }

                if (type != null && type.GuidValue != null)
                {
                    GuidValue = (DataVariable<Guid>)type.GuidValue.Clone(this);
                    GuidValue.Initialize(type.GuidValue);
                }

                if (type != null && type.ByteStringValue != null)
                {
                    ByteStringValue = (DataVariable<byte[]>)type.ByteStringValue.Clone(this);
                    ByteStringValue.Initialize(type.ByteStringValue);
                }

                if (type != null && type.XmlElementValue != null)
                {
                    XmlElementValue = (DataVariable<XmlElement>)type.XmlElementValue.Clone(this);
                    XmlElementValue.Initialize(type.XmlElementValue);
                }

                if (type != null && type.NodeIdValue != null)
                {
                    NodeIdValue = (DataVariable<NodeId>)type.NodeIdValue.Clone(this);
                    NodeIdValue.Initialize(type.NodeIdValue);
                }

                if (type != null && type.ExpandedNodeIdValue != null)
                {
                    ExpandedNodeIdValue = (DataVariable<ExpandedNodeId>)type.ExpandedNodeIdValue.Clone(this);
                    ExpandedNodeIdValue.Initialize(type.ExpandedNodeIdValue);
                }

                if (type != null && type.QualifiedNameValue != null)
                {
                    QualifiedNameValue = (DataVariable<QualifiedName>)type.QualifiedNameValue.Clone(this);
                    QualifiedNameValue.Initialize(type.QualifiedNameValue);
                }

                if (type != null && type.LocalizedTextValue != null)
                {
                    LocalizedTextValue = (DataVariable<LocalizedText>)type.LocalizedTextValue.Clone(this);
                    LocalizedTextValue.Initialize(type.LocalizedTextValue);
                }

                if (type != null && type.StatusCodeValue != null)
                {
                    StatusCodeValue = (DataVariable<StatusCode>)type.StatusCodeValue.Clone(this);
                    StatusCodeValue.Initialize(type.StatusCodeValue);
                }

                if (type != null && type.VariantValue != null)
                {
                    VariantValue = (DataVariable<object>)type.VariantValue.Clone(this);
                    VariantValue.Initialize(type.VariantValue);
                }

                if (type != null && type.StructureValue != null)
                {
                    StructureValue = (DataVariable<IEncodeable>)type.StructureValue.Clone(this);
                    StructureValue.Initialize(type.StructureValue);
                }
            }
        }

        /// <summary cref="NodeSource.InitializeChildren" />
        protected override void InitializeChildren()
        {
            base.InitializeChildren();
                
            m_booleanValue = DataVariable<bool>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.ScalarValueObjectType_BooleanValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.BooleanValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ScalarValueObjectType_BooleanValue);

            m_sByteValue = DataVariable<sbyte>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.ScalarValueObjectType_SByteValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.SByteValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ScalarValueObjectType_SByteValue);

            m_byteValue = DataVariable<byte>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.ScalarValueObjectType_ByteValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.ByteValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ScalarValueObjectType_ByteValue);

            m_int16Value = DataVariable<short>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.ScalarValueObjectType_Int16Value, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.Int16Value, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ScalarValueObjectType_Int16Value);

            m_uInt16Value = DataVariable<ushort>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.ScalarValueObjectType_UInt16Value, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.UInt16Value, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ScalarValueObjectType_UInt16Value);

            m_int32Value = DataVariable<int>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.ScalarValueObjectType_Int32Value, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.Int32Value, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ScalarValueObjectType_Int32Value);

            m_uInt32Value = DataVariable<uint>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.ScalarValueObjectType_UInt32Value, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.UInt32Value, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ScalarValueObjectType_UInt32Value);

            m_int64Value = DataVariable<long>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.ScalarValueObjectType_Int64Value, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.Int64Value, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ScalarValueObjectType_Int64Value);

            m_uInt64Value = DataVariable<ulong>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.ScalarValueObjectType_UInt64Value, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.UInt64Value, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ScalarValueObjectType_UInt64Value);

            m_floatValue = DataVariable<float>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.ScalarValueObjectType_FloatValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.FloatValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ScalarValueObjectType_FloatValue);

            m_doubleValue = DataVariable<double>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.ScalarValueObjectType_DoubleValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.DoubleValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ScalarValueObjectType_DoubleValue);

            m_stringValue = DataVariable<string>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.ScalarValueObjectType_StringValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.StringValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ScalarValueObjectType_StringValue);

            m_dateTimeValue = DataVariable<DateTime>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.ScalarValueObjectType_DateTimeValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.DateTimeValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ScalarValueObjectType_DateTimeValue);

            m_guidValue = DataVariable<Guid>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.ScalarValueObjectType_GuidValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.GuidValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ScalarValueObjectType_GuidValue);

            m_byteStringValue = DataVariable<byte[]>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.ScalarValueObjectType_ByteStringValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.ByteStringValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ScalarValueObjectType_ByteStringValue);

            m_xmlElementValue = DataVariable<XmlElement>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.ScalarValueObjectType_XmlElementValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.XmlElementValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ScalarValueObjectType_XmlElementValue);

            m_nodeIdValue = DataVariable<NodeId>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.ScalarValueObjectType_NodeIdValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.NodeIdValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ScalarValueObjectType_NodeIdValue);

            m_expandedNodeIdValue = DataVariable<ExpandedNodeId>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.ScalarValueObjectType_ExpandedNodeIdValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.ExpandedNodeIdValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ScalarValueObjectType_ExpandedNodeIdValue);

            m_qualifiedNameValue = DataVariable<QualifiedName>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.ScalarValueObjectType_QualifiedNameValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.QualifiedNameValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ScalarValueObjectType_QualifiedNameValue);

            m_localizedTextValue = DataVariable<LocalizedText>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.ScalarValueObjectType_LocalizedTextValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.LocalizedTextValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ScalarValueObjectType_LocalizedTextValue);

            m_statusCodeValue = DataVariable<StatusCode>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.ScalarValueObjectType_StatusCodeValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.StatusCodeValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ScalarValueObjectType_StatusCodeValue);

            m_variantValue = DataVariable<object>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.ScalarValueObjectType_VariantValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.VariantValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ScalarValueObjectType_VariantValue);

            m_structureValue = DataVariable<IEncodeable>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.ScalarValueObjectType_StructureValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.StructureValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ScalarValueObjectType_StructureValue);
        }
        #endregion

        #region Private Fields
        DataVariable<bool> m_booleanValue;
        DataVariable<sbyte> m_sByteValue;
        DataVariable<byte> m_byteValue;
        DataVariable<short> m_int16Value;
        DataVariable<ushort> m_uInt16Value;
        DataVariable<int> m_int32Value;
        DataVariable<uint> m_uInt32Value;
        DataVariable<long> m_int64Value;
        DataVariable<ulong> m_uInt64Value;
        DataVariable<float> m_floatValue;
        DataVariable<double> m_doubleValue;
        DataVariable<string> m_stringValue;
        DataVariable<DateTime> m_dateTimeValue;
        DataVariable<Guid> m_guidValue;
        DataVariable<byte[]> m_byteStringValue;
        DataVariable<XmlElement> m_xmlElementValue;
        DataVariable<NodeId> m_nodeIdValue;
        DataVariable<ExpandedNodeId> m_expandedNodeIdValue;
        DataVariable<QualifiedName> m_qualifiedNameValue;
        DataVariable<LocalizedText> m_localizedTextValue;
        DataVariable<StatusCode> m_statusCodeValue;
        DataVariable<object> m_variantValue;
        DataVariable<IEncodeable> m_structureValue;
        #endregion
    }
    #endregion

    #region ScalarValueObject Class
    /// <summary>
    /// Represents an instance of the ScalarValueObjectType ObjectType in the address space.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class ScalarValueObject : TestDataObject
    {
        #region Constructors
        /// <summary>
        /// Initializes the object with default values.
        /// </summary>
        protected ScalarValueObject(IServerInternal server, NodeSource parent) 
        : 
            base(server, parent)
        {
            m_typeDefinition = ScalarValueObjectType.FindSource(server);
        }

        /// <summary>
        /// Creates a new instance of the node.
        /// </summary>
        public static new ScalarValueObject Construct(
            IServerInternal server, 
            NodeSource      parent, 
            NodeId          referenceTypeId,
            NodeId          nodeId,
            QualifiedName   browseName,
            uint            numericId)
        {
            ScalarValueObject instance = new ScalarValueObject(server, parent);
            instance.Initialize(referenceTypeId, nodeId, browseName, numericId, instance.m_typeDefinition.NodeId);
            return instance;
        }

        /// <summary>
        /// Creates a new instance of the node without any parent.
        /// </summary>
        public static new ScalarValueObject Construct(IServerInternal server)
        {
            ScalarValueObject instance = new ScalarValueObject(server, (NodeSource)null);
            instance.Initialize(null, null, null, 0, instance.m_typeDefinition.NodeId);
            return instance;
        }
        #endregion
           
        #region ICloneable Members
        /// <summary cref="NodeSource.Clone(NodeSource)" />
        public override NodeSource Clone(NodeSource parent)
        {
            lock (DataLock)
            {
                ScalarValueObject clone = new ScalarValueObject(Server, parent);
                clone.Initialize(this);
                return clone;
            } 
        }
        #endregion

        #region Public Properties
        #region BooleanValue
        /// <summary>
        /// A description for the BooleanValue Variable.
        /// </summary>
        public DataVariable<bool> BooleanValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_booleanValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_booleanValue != null)
                    {
                        RemoveChild(m_booleanValue);
                    }

                    m_booleanValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceBooleanValue(DataVariable<bool> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                BooleanValue = replacement;

                BooleanValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.BooleanValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ScalarValueObjectType_BooleanValue,
                    null);
            }
        }
        #endregion

        #region SByteValue
        /// <summary>
        /// A description for the SByteValue Variable.
        /// </summary>
        public DataVariable<sbyte> SByteValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_sByteValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_sByteValue != null)
                    {
                        RemoveChild(m_sByteValue);
                    }

                    m_sByteValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceSByteValue(DataVariable<sbyte> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                SByteValue = replacement;

                SByteValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.SByteValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ScalarValueObjectType_SByteValue,
                    null);
            }
        }
        #endregion

        #region ByteValue
        /// <summary>
        /// A description for the ByteValue Variable.
        /// </summary>
        public DataVariable<byte> ByteValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_byteValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_byteValue != null)
                    {
                        RemoveChild(m_byteValue);
                    }

                    m_byteValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceByteValue(DataVariable<byte> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                ByteValue = replacement;

                ByteValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.ByteValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ScalarValueObjectType_ByteValue,
                    null);
            }
        }
        #endregion

        #region Int16Value
        /// <summary>
        /// A description for the Int16Value Variable.
        /// </summary>
        public DataVariable<short> Int16Value
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_int16Value; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_int16Value != null)
                    {
                        RemoveChild(m_int16Value);
                    }

                    m_int16Value = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceInt16Value(DataVariable<short> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                Int16Value = replacement;

                Int16Value.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.Int16Value, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ScalarValueObjectType_Int16Value,
                    null);
            }
        }
        #endregion

        #region UInt16Value
        /// <summary>
        /// A description for the UInt16Value Variable.
        /// </summary>
        public DataVariable<ushort> UInt16Value
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_uInt16Value; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_uInt16Value != null)
                    {
                        RemoveChild(m_uInt16Value);
                    }

                    m_uInt16Value = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceUInt16Value(DataVariable<ushort> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                UInt16Value = replacement;

                UInt16Value.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.UInt16Value, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ScalarValueObjectType_UInt16Value,
                    null);
            }
        }
        #endregion

        #region Int32Value
        /// <summary>
        /// A description for the Int32Value Variable.
        /// </summary>
        public DataVariable<int> Int32Value
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_int32Value; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_int32Value != null)
                    {
                        RemoveChild(m_int32Value);
                    }

                    m_int32Value = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceInt32Value(DataVariable<int> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                Int32Value = replacement;

                Int32Value.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.Int32Value, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ScalarValueObjectType_Int32Value,
                    null);
            }
        }
        #endregion

        #region UInt32Value
        /// <summary>
        /// A description for the UInt32Value Variable.
        /// </summary>
        public DataVariable<uint> UInt32Value
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_uInt32Value; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_uInt32Value != null)
                    {
                        RemoveChild(m_uInt32Value);
                    }

                    m_uInt32Value = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceUInt32Value(DataVariable<uint> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                UInt32Value = replacement;

                UInt32Value.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.UInt32Value, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ScalarValueObjectType_UInt32Value,
                    null);
            }
        }
        #endregion

        #region Int64Value
        /// <summary>
        /// A description for the Int64Value Variable.
        /// </summary>
        public DataVariable<long> Int64Value
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_int64Value; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_int64Value != null)
                    {
                        RemoveChild(m_int64Value);
                    }

                    m_int64Value = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceInt64Value(DataVariable<long> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                Int64Value = replacement;

                Int64Value.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.Int64Value, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ScalarValueObjectType_Int64Value,
                    null);
            }
        }
        #endregion

        #region UInt64Value
        /// <summary>
        /// A description for the UInt64Value Variable.
        /// </summary>
        public DataVariable<ulong> UInt64Value
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_uInt64Value; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_uInt64Value != null)
                    {
                        RemoveChild(m_uInt64Value);
                    }

                    m_uInt64Value = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceUInt64Value(DataVariable<ulong> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                UInt64Value = replacement;

                UInt64Value.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.UInt64Value, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ScalarValueObjectType_UInt64Value,
                    null);
            }
        }
        #endregion

        #region FloatValue
        /// <summary>
        /// A description for the FloatValue Variable.
        /// </summary>
        public DataVariable<float> FloatValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_floatValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_floatValue != null)
                    {
                        RemoveChild(m_floatValue);
                    }

                    m_floatValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceFloatValue(DataVariable<float> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                FloatValue = replacement;

                FloatValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.FloatValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ScalarValueObjectType_FloatValue,
                    null);
            }
        }
        #endregion

        #region DoubleValue
        /// <summary>
        /// A description for the DoubleValue Variable.
        /// </summary>
        public DataVariable<double> DoubleValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_doubleValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_doubleValue != null)
                    {
                        RemoveChild(m_doubleValue);
                    }

                    m_doubleValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceDoubleValue(DataVariable<double> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                DoubleValue = replacement;

                DoubleValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.DoubleValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ScalarValueObjectType_DoubleValue,
                    null);
            }
        }
        #endregion

        #region StringValue
        /// <summary>
        /// A description for the StringValue Variable.
        /// </summary>
        public DataVariable<string> StringValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_stringValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_stringValue != null)
                    {
                        RemoveChild(m_stringValue);
                    }

                    m_stringValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceStringValue(DataVariable<string> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                StringValue = replacement;

                StringValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.StringValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ScalarValueObjectType_StringValue,
                    null);
            }
        }
        #endregion

        #region DateTimeValue
        /// <summary>
        /// A description for the DateTimeValue Variable.
        /// </summary>
        public DataVariable<DateTime> DateTimeValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_dateTimeValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_dateTimeValue != null)
                    {
                        RemoveChild(m_dateTimeValue);
                    }

                    m_dateTimeValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceDateTimeValue(DataVariable<DateTime> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                DateTimeValue = replacement;

                DateTimeValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.DateTimeValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ScalarValueObjectType_DateTimeValue,
                    null);
            }
        }
        #endregion

        #region GuidValue
        /// <summary>
        /// A description for the GuidValue Variable.
        /// </summary>
        public DataVariable<Guid> GuidValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_guidValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_guidValue != null)
                    {
                        RemoveChild(m_guidValue);
                    }

                    m_guidValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceGuidValue(DataVariable<Guid> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                GuidValue = replacement;

                GuidValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.GuidValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ScalarValueObjectType_GuidValue,
                    null);
            }
        }
        #endregion

        #region ByteStringValue
        /// <summary>
        /// A description for the ByteStringValue Variable.
        /// </summary>
        public DataVariable<byte[]> ByteStringValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_byteStringValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_byteStringValue != null)
                    {
                        RemoveChild(m_byteStringValue);
                    }

                    m_byteStringValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceByteStringValue(DataVariable<byte[]> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                ByteStringValue = replacement;

                ByteStringValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.ByteStringValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ScalarValueObjectType_ByteStringValue,
                    null);
            }
        }
        #endregion

        #region XmlElementValue
        /// <summary>
        /// A description for the XmlElementValue Variable.
        /// </summary>
        public DataVariable<XmlElement> XmlElementValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_xmlElementValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_xmlElementValue != null)
                    {
                        RemoveChild(m_xmlElementValue);
                    }

                    m_xmlElementValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceXmlElementValue(DataVariable<XmlElement> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                XmlElementValue = replacement;

                XmlElementValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.XmlElementValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ScalarValueObjectType_XmlElementValue,
                    null);
            }
        }
        #endregion

        #region NodeIdValue
        /// <summary>
        /// A description for the NodeIdValue Variable.
        /// </summary>
        public DataVariable<NodeId> NodeIdValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_nodeIdValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_nodeIdValue != null)
                    {
                        RemoveChild(m_nodeIdValue);
                    }

                    m_nodeIdValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceNodeIdValue(DataVariable<NodeId> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                NodeIdValue = replacement;

                NodeIdValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.NodeIdValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ScalarValueObjectType_NodeIdValue,
                    null);
            }
        }
        #endregion

        #region ExpandedNodeIdValue
        /// <summary>
        /// A description for the ExpandedNodeIdValue Variable.
        /// </summary>
        public DataVariable<ExpandedNodeId> ExpandedNodeIdValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_expandedNodeIdValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_expandedNodeIdValue != null)
                    {
                        RemoveChild(m_expandedNodeIdValue);
                    }

                    m_expandedNodeIdValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceExpandedNodeIdValue(DataVariable<ExpandedNodeId> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                ExpandedNodeIdValue = replacement;

                ExpandedNodeIdValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.ExpandedNodeIdValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ScalarValueObjectType_ExpandedNodeIdValue,
                    null);
            }
        }
        #endregion

        #region QualifiedNameValue
        /// <summary>
        /// A description for the QualifiedNameValue Variable.
        /// </summary>
        public DataVariable<QualifiedName> QualifiedNameValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_qualifiedNameValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_qualifiedNameValue != null)
                    {
                        RemoveChild(m_qualifiedNameValue);
                    }

                    m_qualifiedNameValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceQualifiedNameValue(DataVariable<QualifiedName> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                QualifiedNameValue = replacement;

                QualifiedNameValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.QualifiedNameValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ScalarValueObjectType_QualifiedNameValue,
                    null);
            }
        }
        #endregion

        #region LocalizedTextValue
        /// <summary>
        /// A description for the LocalizedTextValue Variable.
        /// </summary>
        public DataVariable<LocalizedText> LocalizedTextValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_localizedTextValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_localizedTextValue != null)
                    {
                        RemoveChild(m_localizedTextValue);
                    }

                    m_localizedTextValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceLocalizedTextValue(DataVariable<LocalizedText> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                LocalizedTextValue = replacement;

                LocalizedTextValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.LocalizedTextValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ScalarValueObjectType_LocalizedTextValue,
                    null);
            }
        }
        #endregion

        #region StatusCodeValue
        /// <summary>
        /// A description for the StatusCodeValue Variable.
        /// </summary>
        public DataVariable<StatusCode> StatusCodeValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_statusCodeValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_statusCodeValue != null)
                    {
                        RemoveChild(m_statusCodeValue);
                    }

                    m_statusCodeValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceStatusCodeValue(DataVariable<StatusCode> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                StatusCodeValue = replacement;

                StatusCodeValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.StatusCodeValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ScalarValueObjectType_StatusCodeValue,
                    null);
            }
        }
        #endregion

        #region VariantValue
        /// <summary>
        /// A description for the VariantValue Variable.
        /// </summary>
        public DataVariable<object> VariantValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_variantValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_variantValue != null)
                    {
                        RemoveChild(m_variantValue);
                    }

                    m_variantValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceVariantValue(DataVariable<object> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                VariantValue = replacement;

                VariantValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.VariantValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ScalarValueObjectType_VariantValue,
                    null);
            }
        }
        #endregion

        #region StructureValue
        /// <summary>
        /// A description for the StructureValue Variable.
        /// </summary>
        public DataVariable<IEncodeable> StructureValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_structureValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_structureValue != null)
                    {
                        RemoveChild(m_structureValue);
                    }

                    m_structureValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceStructureValue(DataVariable<IEncodeable> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                StructureValue = replacement;

                StructureValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.StructureValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ScalarValueObjectType_StructureValue,
                    null);
            }
        }
        #endregion
        #endregion

        #region Overridden Methods
        /// <summary cref="NodeSource.Initialize(NodeSource)" />
        public override void Initialize(NodeSource source)
        {
            lock (DataLock)
            {            
                ScalarValueObject instance = source as ScalarValueObject;

                if (instance != null)
                {
                    base.Initialize(source);
                }

                ScalarValueObjectType type = source as ScalarValueObjectType;

                if (type != null && type.BooleanValue != null)
                {
                    BooleanValue = (DataVariable<bool>)type.BooleanValue.Clone(this);
                    BooleanValue.Initialize(type.BooleanValue);
                }
                else if (instance != null && instance.BooleanValue != null)
                {
                    BooleanValue = (DataVariable<bool>)instance.BooleanValue.Clone(this);
                    BooleanValue.Initialize(instance.BooleanValue);
                }

                if (type != null && type.SByteValue != null)
                {
                    SByteValue = (DataVariable<sbyte>)type.SByteValue.Clone(this);
                    SByteValue.Initialize(type.SByteValue);
                }
                else if (instance != null && instance.SByteValue != null)
                {
                    SByteValue = (DataVariable<sbyte>)instance.SByteValue.Clone(this);
                    SByteValue.Initialize(instance.SByteValue);
                }

                if (type != null && type.ByteValue != null)
                {
                    ByteValue = (DataVariable<byte>)type.ByteValue.Clone(this);
                    ByteValue.Initialize(type.ByteValue);
                }
                else if (instance != null && instance.ByteValue != null)
                {
                    ByteValue = (DataVariable<byte>)instance.ByteValue.Clone(this);
                    ByteValue.Initialize(instance.ByteValue);
                }

                if (type != null && type.Int16Value != null)
                {
                    Int16Value = (DataVariable<short>)type.Int16Value.Clone(this);
                    Int16Value.Initialize(type.Int16Value);
                }
                else if (instance != null && instance.Int16Value != null)
                {
                    Int16Value = (DataVariable<short>)instance.Int16Value.Clone(this);
                    Int16Value.Initialize(instance.Int16Value);
                }

                if (type != null && type.UInt16Value != null)
                {
                    UInt16Value = (DataVariable<ushort>)type.UInt16Value.Clone(this);
                    UInt16Value.Initialize(type.UInt16Value);
                }
                else if (instance != null && instance.UInt16Value != null)
                {
                    UInt16Value = (DataVariable<ushort>)instance.UInt16Value.Clone(this);
                    UInt16Value.Initialize(instance.UInt16Value);
                }

                if (type != null && type.Int32Value != null)
                {
                    Int32Value = (DataVariable<int>)type.Int32Value.Clone(this);
                    Int32Value.Initialize(type.Int32Value);
                }
                else if (instance != null && instance.Int32Value != null)
                {
                    Int32Value = (DataVariable<int>)instance.Int32Value.Clone(this);
                    Int32Value.Initialize(instance.Int32Value);
                }

                if (type != null && type.UInt32Value != null)
                {
                    UInt32Value = (DataVariable<uint>)type.UInt32Value.Clone(this);
                    UInt32Value.Initialize(type.UInt32Value);
                }
                else if (instance != null && instance.UInt32Value != null)
                {
                    UInt32Value = (DataVariable<uint>)instance.UInt32Value.Clone(this);
                    UInt32Value.Initialize(instance.UInt32Value);
                }

                if (type != null && type.Int64Value != null)
                {
                    Int64Value = (DataVariable<long>)type.Int64Value.Clone(this);
                    Int64Value.Initialize(type.Int64Value);
                }
                else if (instance != null && instance.Int64Value != null)
                {
                    Int64Value = (DataVariable<long>)instance.Int64Value.Clone(this);
                    Int64Value.Initialize(instance.Int64Value);
                }

                if (type != null && type.UInt64Value != null)
                {
                    UInt64Value = (DataVariable<ulong>)type.UInt64Value.Clone(this);
                    UInt64Value.Initialize(type.UInt64Value);
                }
                else if (instance != null && instance.UInt64Value != null)
                {
                    UInt64Value = (DataVariable<ulong>)instance.UInt64Value.Clone(this);
                    UInt64Value.Initialize(instance.UInt64Value);
                }

                if (type != null && type.FloatValue != null)
                {
                    FloatValue = (DataVariable<float>)type.FloatValue.Clone(this);
                    FloatValue.Initialize(type.FloatValue);
                }
                else if (instance != null && instance.FloatValue != null)
                {
                    FloatValue = (DataVariable<float>)instance.FloatValue.Clone(this);
                    FloatValue.Initialize(instance.FloatValue);
                }

                if (type != null && type.DoubleValue != null)
                {
                    DoubleValue = (DataVariable<double>)type.DoubleValue.Clone(this);
                    DoubleValue.Initialize(type.DoubleValue);
                }
                else if (instance != null && instance.DoubleValue != null)
                {
                    DoubleValue = (DataVariable<double>)instance.DoubleValue.Clone(this);
                    DoubleValue.Initialize(instance.DoubleValue);
                }

                if (type != null && type.StringValue != null)
                {
                    StringValue = (DataVariable<string>)type.StringValue.Clone(this);
                    StringValue.Initialize(type.StringValue);
                }
                else if (instance != null && instance.StringValue != null)
                {
                    StringValue = (DataVariable<string>)instance.StringValue.Clone(this);
                    StringValue.Initialize(instance.StringValue);
                }

                if (type != null && type.DateTimeValue != null)
                {
                    DateTimeValue = (DataVariable<DateTime>)type.DateTimeValue.Clone(this);
                    DateTimeValue.Initialize(type.DateTimeValue);
                }
                else if (instance != null && instance.DateTimeValue != null)
                {
                    DateTimeValue = (DataVariable<DateTime>)instance.DateTimeValue.Clone(this);
                    DateTimeValue.Initialize(instance.DateTimeValue);
                }

                if (type != null && type.GuidValue != null)
                {
                    GuidValue = (DataVariable<Guid>)type.GuidValue.Clone(this);
                    GuidValue.Initialize(type.GuidValue);
                }
                else if (instance != null && instance.GuidValue != null)
                {
                    GuidValue = (DataVariable<Guid>)instance.GuidValue.Clone(this);
                    GuidValue.Initialize(instance.GuidValue);
                }

                if (type != null && type.ByteStringValue != null)
                {
                    ByteStringValue = (DataVariable<byte[]>)type.ByteStringValue.Clone(this);
                    ByteStringValue.Initialize(type.ByteStringValue);
                }
                else if (instance != null && instance.ByteStringValue != null)
                {
                    ByteStringValue = (DataVariable<byte[]>)instance.ByteStringValue.Clone(this);
                    ByteStringValue.Initialize(instance.ByteStringValue);
                }

                if (type != null && type.XmlElementValue != null)
                {
                    XmlElementValue = (DataVariable<XmlElement>)type.XmlElementValue.Clone(this);
                    XmlElementValue.Initialize(type.XmlElementValue);
                }
                else if (instance != null && instance.XmlElementValue != null)
                {
                    XmlElementValue = (DataVariable<XmlElement>)instance.XmlElementValue.Clone(this);
                    XmlElementValue.Initialize(instance.XmlElementValue);
                }

                if (type != null && type.NodeIdValue != null)
                {
                    NodeIdValue = (DataVariable<NodeId>)type.NodeIdValue.Clone(this);
                    NodeIdValue.Initialize(type.NodeIdValue);
                }
                else if (instance != null && instance.NodeIdValue != null)
                {
                    NodeIdValue = (DataVariable<NodeId>)instance.NodeIdValue.Clone(this);
                    NodeIdValue.Initialize(instance.NodeIdValue);
                }

                if (type != null && type.ExpandedNodeIdValue != null)
                {
                    ExpandedNodeIdValue = (DataVariable<ExpandedNodeId>)type.ExpandedNodeIdValue.Clone(this);
                    ExpandedNodeIdValue.Initialize(type.ExpandedNodeIdValue);
                }
                else if (instance != null && instance.ExpandedNodeIdValue != null)
                {
                    ExpandedNodeIdValue = (DataVariable<ExpandedNodeId>)instance.ExpandedNodeIdValue.Clone(this);
                    ExpandedNodeIdValue.Initialize(instance.ExpandedNodeIdValue);
                }

                if (type != null && type.QualifiedNameValue != null)
                {
                    QualifiedNameValue = (DataVariable<QualifiedName>)type.QualifiedNameValue.Clone(this);
                    QualifiedNameValue.Initialize(type.QualifiedNameValue);
                }
                else if (instance != null && instance.QualifiedNameValue != null)
                {
                    QualifiedNameValue = (DataVariable<QualifiedName>)instance.QualifiedNameValue.Clone(this);
                    QualifiedNameValue.Initialize(instance.QualifiedNameValue);
                }

                if (type != null && type.LocalizedTextValue != null)
                {
                    LocalizedTextValue = (DataVariable<LocalizedText>)type.LocalizedTextValue.Clone(this);
                    LocalizedTextValue.Initialize(type.LocalizedTextValue);
                }
                else if (instance != null && instance.LocalizedTextValue != null)
                {
                    LocalizedTextValue = (DataVariable<LocalizedText>)instance.LocalizedTextValue.Clone(this);
                    LocalizedTextValue.Initialize(instance.LocalizedTextValue);
                }

                if (type != null && type.StatusCodeValue != null)
                {
                    StatusCodeValue = (DataVariable<StatusCode>)type.StatusCodeValue.Clone(this);
                    StatusCodeValue.Initialize(type.StatusCodeValue);
                }
                else if (instance != null && instance.StatusCodeValue != null)
                {
                    StatusCodeValue = (DataVariable<StatusCode>)instance.StatusCodeValue.Clone(this);
                    StatusCodeValue.Initialize(instance.StatusCodeValue);
                }

                if (type != null && type.VariantValue != null)
                {
                    VariantValue = (DataVariable<object>)type.VariantValue.Clone(this);
                    VariantValue.Initialize(type.VariantValue);
                }
                else if (instance != null && instance.VariantValue != null)
                {
                    VariantValue = (DataVariable<object>)instance.VariantValue.Clone(this);
                    VariantValue.Initialize(instance.VariantValue);
                }

                if (type != null && type.StructureValue != null)
                {
                    StructureValue = (DataVariable<IEncodeable>)type.StructureValue.Clone(this);
                    StructureValue.Initialize(type.StructureValue);
                }
                else if (instance != null && instance.StructureValue != null)
                {
                    StructureValue = (DataVariable<IEncodeable>)instance.StructureValue.Clone(this);
                    StructureValue.Initialize(instance.StructureValue);
                }
            }
        }

        /// <summary cref="NodeSource.InitializeChildren" />
        protected override void InitializeChildren()
        {
            base.InitializeChildren();
                
            m_booleanValue = DataVariable<bool>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.BooleanValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ScalarValueObjectType_BooleanValue);

            m_sByteValue = DataVariable<sbyte>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.SByteValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ScalarValueObjectType_SByteValue);

            m_byteValue = DataVariable<byte>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.ByteValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ScalarValueObjectType_ByteValue);

            m_int16Value = DataVariable<short>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.Int16Value, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ScalarValueObjectType_Int16Value);

            m_uInt16Value = DataVariable<ushort>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.UInt16Value, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ScalarValueObjectType_UInt16Value);

            m_int32Value = DataVariable<int>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.Int32Value, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ScalarValueObjectType_Int32Value);

            m_uInt32Value = DataVariable<uint>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.UInt32Value, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ScalarValueObjectType_UInt32Value);

            m_int64Value = DataVariable<long>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.Int64Value, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ScalarValueObjectType_Int64Value);

            m_uInt64Value = DataVariable<ulong>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.UInt64Value, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ScalarValueObjectType_UInt64Value);

            m_floatValue = DataVariable<float>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.FloatValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ScalarValueObjectType_FloatValue);

            m_doubleValue = DataVariable<double>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.DoubleValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ScalarValueObjectType_DoubleValue);

            m_stringValue = DataVariable<string>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.StringValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ScalarValueObjectType_StringValue);

            m_dateTimeValue = DataVariable<DateTime>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.DateTimeValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ScalarValueObjectType_DateTimeValue);

            m_guidValue = DataVariable<Guid>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.GuidValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ScalarValueObjectType_GuidValue);

            m_byteStringValue = DataVariable<byte[]>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.ByteStringValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ScalarValueObjectType_ByteStringValue);

            m_xmlElementValue = DataVariable<XmlElement>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.XmlElementValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ScalarValueObjectType_XmlElementValue);

            m_nodeIdValue = DataVariable<NodeId>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.NodeIdValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ScalarValueObjectType_NodeIdValue);

            m_expandedNodeIdValue = DataVariable<ExpandedNodeId>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.ExpandedNodeIdValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ScalarValueObjectType_ExpandedNodeIdValue);

            m_qualifiedNameValue = DataVariable<QualifiedName>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.QualifiedNameValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ScalarValueObjectType_QualifiedNameValue);

            m_localizedTextValue = DataVariable<LocalizedText>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.LocalizedTextValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ScalarValueObjectType_LocalizedTextValue);

            m_statusCodeValue = DataVariable<StatusCode>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.StatusCodeValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ScalarValueObjectType_StatusCodeValue);

            m_variantValue = DataVariable<object>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.VariantValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ScalarValueObjectType_VariantValue);

            m_structureValue = DataVariable<IEncodeable>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.StructureValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ScalarValueObjectType_StructureValue);
        }
        #endregion

        #region Private Fields
        private ScalarValueObjectType m_typeDefinition;
        DataVariable<bool> m_booleanValue;
        DataVariable<sbyte> m_sByteValue;
        DataVariable<byte> m_byteValue;
        DataVariable<short> m_int16Value;
        DataVariable<ushort> m_uInt16Value;
        DataVariable<int> m_int32Value;
        DataVariable<uint> m_uInt32Value;
        DataVariable<long> m_int64Value;
        DataVariable<ulong> m_uInt64Value;
        DataVariable<float> m_floatValue;
        DataVariable<double> m_doubleValue;
        DataVariable<string> m_stringValue;
        DataVariable<DateTime> m_dateTimeValue;
        DataVariable<Guid> m_guidValue;
        DataVariable<byte[]> m_byteStringValue;
        DataVariable<XmlElement> m_xmlElementValue;
        DataVariable<NodeId> m_nodeIdValue;
        DataVariable<ExpandedNodeId> m_expandedNodeIdValue;
        DataVariable<QualifiedName> m_qualifiedNameValue;
        DataVariable<LocalizedText> m_localizedTextValue;
        DataVariable<StatusCode> m_statusCodeValue;
        DataVariable<object> m_variantValue;
        DataVariable<IEncodeable> m_structureValue;
        #endregion
    }
    #endregion

    #region ArrayValueObjectType Class
    /// <summary>
    /// Represents the ArrayValueObjectType ObjectType in the address space.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class ArrayValueObjectType : ObjectTypeSource
    {
        #region Constructors
        /// <summary>
        /// Initializes the object with default values.
        /// </summary>
        public ArrayValueObjectType(IServerInternal server) : base(server)
        {
            Initialize(
                new NodeId(Opc.Ua.Sample.ObjectTypes.ArrayValueObjectType, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                new QualifiedName(Opc.Ua.Sample.BrowseNames.ArrayValueObjectType, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                new NodeId(Opc.Ua.Sample.ObjectTypes.TestDataObjectType, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)));
                    
            server.TypeSources.SetTypeSource(this.NodeId, this);
        }

        /// <summary>
        /// Finds the source for the type definition (creates it if it does not exist).
        /// </summary>
        public static new ArrayValueObjectType FindSource(IServerInternal server)
        {
            ArrayValueObjectType type = null;
                    
            lock (server.TypeSources.SyncRoot)
            {
                NodeId typeId = new NodeId(Opc.Ua.Sample.ObjectTypes.ArrayValueObjectType, server.NamespaceUris.GetIndexOrAppend(Opc.Ua.Sample.Namespaces.Sample));

                type = server.TypeSources.FindTypeSource(typeId) as ArrayValueObjectType;

                if (type != null)
                {
                    return type;
                }

                type = new ArrayValueObjectType(server);
            }

            return type;
        }
        #endregion
             
        #region ICloneable Members
        /// <summary cref="NodeSource.Clone(NodeSource)" />
        public override NodeSource Clone(NodeSource parent)
        {
            lock (DataLock)
            {
                ArrayValueObjectType clone = new ArrayValueObjectType(Server);
                clone.Initialize(this);
                return clone;
            }
        }
        #endregion
      
        #region Public Properties
        #region BooleanValue
        /// <summary>
        /// A description for the BooleanValue Variable.
        /// </summary>
        public DataVariable<IList<bool>> BooleanValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_booleanValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_booleanValue != null)
                    {
                        RemoveChild(m_booleanValue);
                    }

                    m_booleanValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceBooleanValue(DataVariable<IList<bool>> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                BooleanValue = replacement;

                BooleanValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.BooleanValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ArrayValueObjectType_BooleanValue,
                    null);
            }
        }
        #endregion

        #region SByteValue
        /// <summary>
        /// A description for the SByteValue Variable.
        /// </summary>
        public DataVariable<IList<sbyte>> SByteValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_sByteValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_sByteValue != null)
                    {
                        RemoveChild(m_sByteValue);
                    }

                    m_sByteValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceSByteValue(DataVariable<IList<sbyte>> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                SByteValue = replacement;

                SByteValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.SByteValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ArrayValueObjectType_SByteValue,
                    null);
            }
        }
        #endregion

        #region ByteValue
        /// <summary>
        /// A description for the ByteValue Variable.
        /// </summary>
        public DataVariable<IList<byte>> ByteValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_byteValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_byteValue != null)
                    {
                        RemoveChild(m_byteValue);
                    }

                    m_byteValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceByteValue(DataVariable<IList<byte>> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                ByteValue = replacement;

                ByteValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.ByteValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ArrayValueObjectType_ByteValue,
                    null);
            }
        }
        #endregion

        #region Int16Value
        /// <summary>
        /// A description for the Int16Value Variable.
        /// </summary>
        public DataVariable<IList<short>> Int16Value
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_int16Value; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_int16Value != null)
                    {
                        RemoveChild(m_int16Value);
                    }

                    m_int16Value = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceInt16Value(DataVariable<IList<short>> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                Int16Value = replacement;

                Int16Value.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.Int16Value, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ArrayValueObjectType_Int16Value,
                    null);
            }
        }
        #endregion

        #region UInt16Value
        /// <summary>
        /// A description for the UInt16Value Variable.
        /// </summary>
        public DataVariable<IList<ushort>> UInt16Value
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_uInt16Value; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_uInt16Value != null)
                    {
                        RemoveChild(m_uInt16Value);
                    }

                    m_uInt16Value = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceUInt16Value(DataVariable<IList<ushort>> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                UInt16Value = replacement;

                UInt16Value.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.UInt16Value, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ArrayValueObjectType_UInt16Value,
                    null);
            }
        }
        #endregion

        #region Int32Value
        /// <summary>
        /// A description for the Int32Value Variable.
        /// </summary>
        public DataVariable<IList<int>> Int32Value
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_int32Value; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_int32Value != null)
                    {
                        RemoveChild(m_int32Value);
                    }

                    m_int32Value = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceInt32Value(DataVariable<IList<int>> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                Int32Value = replacement;

                Int32Value.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.Int32Value, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ArrayValueObjectType_Int32Value,
                    null);
            }
        }
        #endregion

        #region UInt32Value
        /// <summary>
        /// A description for the UInt32Value Variable.
        /// </summary>
        public DataVariable<IList<uint>> UInt32Value
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_uInt32Value; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_uInt32Value != null)
                    {
                        RemoveChild(m_uInt32Value);
                    }

                    m_uInt32Value = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceUInt32Value(DataVariable<IList<uint>> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                UInt32Value = replacement;

                UInt32Value.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.UInt32Value, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ArrayValueObjectType_UInt32Value,
                    null);
            }
        }
        #endregion

        #region Int64Value
        /// <summary>
        /// A description for the Int64Value Variable.
        /// </summary>
        public DataVariable<IList<long>> Int64Value
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_int64Value; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_int64Value != null)
                    {
                        RemoveChild(m_int64Value);
                    }

                    m_int64Value = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceInt64Value(DataVariable<IList<long>> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                Int64Value = replacement;

                Int64Value.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.Int64Value, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ArrayValueObjectType_Int64Value,
                    null);
            }
        }
        #endregion

        #region UInt64Value
        /// <summary>
        /// A description for the UInt64Value Variable.
        /// </summary>
        public DataVariable<IList<ulong>> UInt64Value
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_uInt64Value; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_uInt64Value != null)
                    {
                        RemoveChild(m_uInt64Value);
                    }

                    m_uInt64Value = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceUInt64Value(DataVariable<IList<ulong>> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                UInt64Value = replacement;

                UInt64Value.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.UInt64Value, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ArrayValueObjectType_UInt64Value,
                    null);
            }
        }
        #endregion

        #region FloatValue
        /// <summary>
        /// A description for the FloatValue Variable.
        /// </summary>
        public DataVariable<IList<float>> FloatValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_floatValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_floatValue != null)
                    {
                        RemoveChild(m_floatValue);
                    }

                    m_floatValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceFloatValue(DataVariable<IList<float>> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                FloatValue = replacement;

                FloatValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.FloatValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ArrayValueObjectType_FloatValue,
                    null);
            }
        }
        #endregion

        #region DoubleValue
        /// <summary>
        /// A description for the DoubleValue Variable.
        /// </summary>
        public DataVariable<IList<double>> DoubleValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_doubleValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_doubleValue != null)
                    {
                        RemoveChild(m_doubleValue);
                    }

                    m_doubleValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceDoubleValue(DataVariable<IList<double>> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                DoubleValue = replacement;

                DoubleValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.DoubleValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ArrayValueObjectType_DoubleValue,
                    null);
            }
        }
        #endregion

        #region StringValue
        /// <summary>
        /// A description for the StringValue Variable.
        /// </summary>
        public DataVariable<IList<string>> StringValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_stringValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_stringValue != null)
                    {
                        RemoveChild(m_stringValue);
                    }

                    m_stringValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceStringValue(DataVariable<IList<string>> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                StringValue = replacement;

                StringValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.StringValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ArrayValueObjectType_StringValue,
                    null);
            }
        }
        #endregion

        #region DateTimeValue
        /// <summary>
        /// A description for the DateTimeValue Variable.
        /// </summary>
        public DataVariable<IList<DateTime>> DateTimeValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_dateTimeValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_dateTimeValue != null)
                    {
                        RemoveChild(m_dateTimeValue);
                    }

                    m_dateTimeValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceDateTimeValue(DataVariable<IList<DateTime>> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                DateTimeValue = replacement;

                DateTimeValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.DateTimeValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ArrayValueObjectType_DateTimeValue,
                    null);
            }
        }
        #endregion

        #region GuidValue
        /// <summary>
        /// A description for the GuidValue Variable.
        /// </summary>
        public DataVariable<IList<Guid>> GuidValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_guidValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_guidValue != null)
                    {
                        RemoveChild(m_guidValue);
                    }

                    m_guidValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceGuidValue(DataVariable<IList<Guid>> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                GuidValue = replacement;

                GuidValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.GuidValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ArrayValueObjectType_GuidValue,
                    null);
            }
        }
        #endregion

        #region ByteStringValue
        /// <summary>
        /// A description for the ByteStringValue Variable.
        /// </summary>
        public DataVariable<IList<byte[]>> ByteStringValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_byteStringValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_byteStringValue != null)
                    {
                        RemoveChild(m_byteStringValue);
                    }

                    m_byteStringValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceByteStringValue(DataVariable<IList<byte[]>> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                ByteStringValue = replacement;

                ByteStringValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.ByteStringValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ArrayValueObjectType_ByteStringValue,
                    null);
            }
        }
        #endregion

        #region XmlElementValue
        /// <summary>
        /// A description for the XmlElementValue Variable.
        /// </summary>
        public DataVariable<IList<XmlElement>> XmlElementValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_xmlElementValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_xmlElementValue != null)
                    {
                        RemoveChild(m_xmlElementValue);
                    }

                    m_xmlElementValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceXmlElementValue(DataVariable<IList<XmlElement>> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                XmlElementValue = replacement;

                XmlElementValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.XmlElementValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ArrayValueObjectType_XmlElementValue,
                    null);
            }
        }
        #endregion

        #region NodeIdValue
        /// <summary>
        /// A description for the NodeIdValue Variable.
        /// </summary>
        public DataVariable<IList<NodeId>> NodeIdValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_nodeIdValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_nodeIdValue != null)
                    {
                        RemoveChild(m_nodeIdValue);
                    }

                    m_nodeIdValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceNodeIdValue(DataVariable<IList<NodeId>> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                NodeIdValue = replacement;

                NodeIdValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.NodeIdValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ArrayValueObjectType_NodeIdValue,
                    null);
            }
        }
        #endregion

        #region ExpandedNodeIdValue
        /// <summary>
        /// A description for the ExpandedNodeIdValue Variable.
        /// </summary>
        public DataVariable<IList<ExpandedNodeId>> ExpandedNodeIdValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_expandedNodeIdValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_expandedNodeIdValue != null)
                    {
                        RemoveChild(m_expandedNodeIdValue);
                    }

                    m_expandedNodeIdValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceExpandedNodeIdValue(DataVariable<IList<ExpandedNodeId>> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                ExpandedNodeIdValue = replacement;

                ExpandedNodeIdValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.ExpandedNodeIdValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ArrayValueObjectType_ExpandedNodeIdValue,
                    null);
            }
        }
        #endregion

        #region QualifiedNameValue
        /// <summary>
        /// A description for the QualifiedNameValue Variable.
        /// </summary>
        public DataVariable<IList<QualifiedName>> QualifiedNameValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_qualifiedNameValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_qualifiedNameValue != null)
                    {
                        RemoveChild(m_qualifiedNameValue);
                    }

                    m_qualifiedNameValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceQualifiedNameValue(DataVariable<IList<QualifiedName>> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                QualifiedNameValue = replacement;

                QualifiedNameValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.QualifiedNameValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ArrayValueObjectType_QualifiedNameValue,
                    null);
            }
        }
        #endregion

        #region LocalizedTextValue
        /// <summary>
        /// A description for the LocalizedTextValue Variable.
        /// </summary>
        public DataVariable<IList<LocalizedText>> LocalizedTextValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_localizedTextValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_localizedTextValue != null)
                    {
                        RemoveChild(m_localizedTextValue);
                    }

                    m_localizedTextValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceLocalizedTextValue(DataVariable<IList<LocalizedText>> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                LocalizedTextValue = replacement;

                LocalizedTextValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.LocalizedTextValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ArrayValueObjectType_LocalizedTextValue,
                    null);
            }
        }
        #endregion

        #region StatusCodeValue
        /// <summary>
        /// A description for the StatusCodeValue Variable.
        /// </summary>
        public DataVariable<IList<StatusCode>> StatusCodeValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_statusCodeValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_statusCodeValue != null)
                    {
                        RemoveChild(m_statusCodeValue);
                    }

                    m_statusCodeValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceStatusCodeValue(DataVariable<IList<StatusCode>> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                StatusCodeValue = replacement;

                StatusCodeValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.StatusCodeValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ArrayValueObjectType_StatusCodeValue,
                    null);
            }
        }
        #endregion

        #region VariantValue
        /// <summary>
        /// A description for the VariantValue Variable.
        /// </summary>
        public DataVariable<IList<object>> VariantValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_variantValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_variantValue != null)
                    {
                        RemoveChild(m_variantValue);
                    }

                    m_variantValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceVariantValue(DataVariable<IList<object>> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                VariantValue = replacement;

                VariantValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.VariantValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ArrayValueObjectType_VariantValue,
                    null);
            }
        }
        #endregion

        #region StructureValue
        /// <summary>
        /// A description for the StructureValue Variable.
        /// </summary>
        public DataVariable<IList<IEncodeable>> StructureValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_structureValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_structureValue != null)
                    {
                        RemoveChild(m_structureValue);
                    }

                    m_structureValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceStructureValue(DataVariable<IList<IEncodeable>> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                StructureValue = replacement;

                StructureValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.StructureValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ArrayValueObjectType_StructureValue,
                    null);
            }
        }
        #endregion
        #endregion

        #region Overridden Methods
        /// <summary cref="NodeSource.Initialize(NodeSource)" />
        public override void Initialize(NodeSource source)
        {
            lock (DataLock)
            {
                base.Initialize(source);
                
                ArrayValueObjectType type = source as ArrayValueObjectType;

                if (type != null && type.BooleanValue != null)
                {
                    BooleanValue = (DataVariable<IList<bool>>)type.BooleanValue.Clone(this);
                    BooleanValue.Initialize(type.BooleanValue);
                }

                if (type != null && type.SByteValue != null)
                {
                    SByteValue = (DataVariable<IList<sbyte>>)type.SByteValue.Clone(this);
                    SByteValue.Initialize(type.SByteValue);
                }

                if (type != null && type.ByteValue != null)
                {
                    ByteValue = (DataVariable<IList<byte>>)type.ByteValue.Clone(this);
                    ByteValue.Initialize(type.ByteValue);
                }

                if (type != null && type.Int16Value != null)
                {
                    Int16Value = (DataVariable<IList<short>>)type.Int16Value.Clone(this);
                    Int16Value.Initialize(type.Int16Value);
                }

                if (type != null && type.UInt16Value != null)
                {
                    UInt16Value = (DataVariable<IList<ushort>>)type.UInt16Value.Clone(this);
                    UInt16Value.Initialize(type.UInt16Value);
                }

                if (type != null && type.Int32Value != null)
                {
                    Int32Value = (DataVariable<IList<int>>)type.Int32Value.Clone(this);
                    Int32Value.Initialize(type.Int32Value);
                }

                if (type != null && type.UInt32Value != null)
                {
                    UInt32Value = (DataVariable<IList<uint>>)type.UInt32Value.Clone(this);
                    UInt32Value.Initialize(type.UInt32Value);
                }

                if (type != null && type.Int64Value != null)
                {
                    Int64Value = (DataVariable<IList<long>>)type.Int64Value.Clone(this);
                    Int64Value.Initialize(type.Int64Value);
                }

                if (type != null && type.UInt64Value != null)
                {
                    UInt64Value = (DataVariable<IList<ulong>>)type.UInt64Value.Clone(this);
                    UInt64Value.Initialize(type.UInt64Value);
                }

                if (type != null && type.FloatValue != null)
                {
                    FloatValue = (DataVariable<IList<float>>)type.FloatValue.Clone(this);
                    FloatValue.Initialize(type.FloatValue);
                }

                if (type != null && type.DoubleValue != null)
                {
                    DoubleValue = (DataVariable<IList<double>>)type.DoubleValue.Clone(this);
                    DoubleValue.Initialize(type.DoubleValue);
                }

                if (type != null && type.StringValue != null)
                {
                    StringValue = (DataVariable<IList<string>>)type.StringValue.Clone(this);
                    StringValue.Initialize(type.StringValue);
                }

                if (type != null && type.DateTimeValue != null)
                {
                    DateTimeValue = (DataVariable<IList<DateTime>>)type.DateTimeValue.Clone(this);
                    DateTimeValue.Initialize(type.DateTimeValue);
                }

                if (type != null && type.GuidValue != null)
                {
                    GuidValue = (DataVariable<IList<Guid>>)type.GuidValue.Clone(this);
                    GuidValue.Initialize(type.GuidValue);
                }

                if (type != null && type.ByteStringValue != null)
                {
                    ByteStringValue = (DataVariable<IList<byte[]>>)type.ByteStringValue.Clone(this);
                    ByteStringValue.Initialize(type.ByteStringValue);
                }

                if (type != null && type.XmlElementValue != null)
                {
                    XmlElementValue = (DataVariable<IList<XmlElement>>)type.XmlElementValue.Clone(this);
                    XmlElementValue.Initialize(type.XmlElementValue);
                }

                if (type != null && type.NodeIdValue != null)
                {
                    NodeIdValue = (DataVariable<IList<NodeId>>)type.NodeIdValue.Clone(this);
                    NodeIdValue.Initialize(type.NodeIdValue);
                }

                if (type != null && type.ExpandedNodeIdValue != null)
                {
                    ExpandedNodeIdValue = (DataVariable<IList<ExpandedNodeId>>)type.ExpandedNodeIdValue.Clone(this);
                    ExpandedNodeIdValue.Initialize(type.ExpandedNodeIdValue);
                }

                if (type != null && type.QualifiedNameValue != null)
                {
                    QualifiedNameValue = (DataVariable<IList<QualifiedName>>)type.QualifiedNameValue.Clone(this);
                    QualifiedNameValue.Initialize(type.QualifiedNameValue);
                }

                if (type != null && type.LocalizedTextValue != null)
                {
                    LocalizedTextValue = (DataVariable<IList<LocalizedText>>)type.LocalizedTextValue.Clone(this);
                    LocalizedTextValue.Initialize(type.LocalizedTextValue);
                }

                if (type != null && type.StatusCodeValue != null)
                {
                    StatusCodeValue = (DataVariable<IList<StatusCode>>)type.StatusCodeValue.Clone(this);
                    StatusCodeValue.Initialize(type.StatusCodeValue);
                }

                if (type != null && type.VariantValue != null)
                {
                    VariantValue = (DataVariable<IList<object>>)type.VariantValue.Clone(this);
                    VariantValue.Initialize(type.VariantValue);
                }

                if (type != null && type.StructureValue != null)
                {
                    StructureValue = (DataVariable<IList<IEncodeable>>)type.StructureValue.Clone(this);
                    StructureValue.Initialize(type.StructureValue);
                }
            }
        }

        /// <summary cref="NodeSource.InitializeChildren" />
        protected override void InitializeChildren()
        {
            base.InitializeChildren();
                
            m_booleanValue = DataVariable<IList<bool>>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.ArrayValueObjectType_BooleanValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.BooleanValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ArrayValueObjectType_BooleanValue);

            m_sByteValue = DataVariable<IList<sbyte>>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.ArrayValueObjectType_SByteValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.SByteValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ArrayValueObjectType_SByteValue);

            m_byteValue = DataVariable<IList<byte>>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.ArrayValueObjectType_ByteValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.ByteValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ArrayValueObjectType_ByteValue);

            m_int16Value = DataVariable<IList<short>>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.ArrayValueObjectType_Int16Value, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.Int16Value, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ArrayValueObjectType_Int16Value);

            m_uInt16Value = DataVariable<IList<ushort>>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.ArrayValueObjectType_UInt16Value, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.UInt16Value, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ArrayValueObjectType_UInt16Value);

            m_int32Value = DataVariable<IList<int>>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.ArrayValueObjectType_Int32Value, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.Int32Value, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ArrayValueObjectType_Int32Value);

            m_uInt32Value = DataVariable<IList<uint>>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.ArrayValueObjectType_UInt32Value, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.UInt32Value, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ArrayValueObjectType_UInt32Value);

            m_int64Value = DataVariable<IList<long>>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.ArrayValueObjectType_Int64Value, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.Int64Value, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ArrayValueObjectType_Int64Value);

            m_uInt64Value = DataVariable<IList<ulong>>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.ArrayValueObjectType_UInt64Value, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.UInt64Value, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ArrayValueObjectType_UInt64Value);

            m_floatValue = DataVariable<IList<float>>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.ArrayValueObjectType_FloatValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.FloatValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ArrayValueObjectType_FloatValue);

            m_doubleValue = DataVariable<IList<double>>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.ArrayValueObjectType_DoubleValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.DoubleValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ArrayValueObjectType_DoubleValue);

            m_stringValue = DataVariable<IList<string>>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.ArrayValueObjectType_StringValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.StringValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ArrayValueObjectType_StringValue);

            m_dateTimeValue = DataVariable<IList<DateTime>>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.ArrayValueObjectType_DateTimeValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.DateTimeValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ArrayValueObjectType_DateTimeValue);

            m_guidValue = DataVariable<IList<Guid>>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.ArrayValueObjectType_GuidValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.GuidValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ArrayValueObjectType_GuidValue);

            m_byteStringValue = DataVariable<IList<byte[]>>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.ArrayValueObjectType_ByteStringValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.ByteStringValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ArrayValueObjectType_ByteStringValue);

            m_xmlElementValue = DataVariable<IList<XmlElement>>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.ArrayValueObjectType_XmlElementValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.XmlElementValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ArrayValueObjectType_XmlElementValue);

            m_nodeIdValue = DataVariable<IList<NodeId>>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.ArrayValueObjectType_NodeIdValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.NodeIdValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ArrayValueObjectType_NodeIdValue);

            m_expandedNodeIdValue = DataVariable<IList<ExpandedNodeId>>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.ArrayValueObjectType_ExpandedNodeIdValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.ExpandedNodeIdValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ArrayValueObjectType_ExpandedNodeIdValue);

            m_qualifiedNameValue = DataVariable<IList<QualifiedName>>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.ArrayValueObjectType_QualifiedNameValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.QualifiedNameValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ArrayValueObjectType_QualifiedNameValue);

            m_localizedTextValue = DataVariable<IList<LocalizedText>>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.ArrayValueObjectType_LocalizedTextValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.LocalizedTextValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ArrayValueObjectType_LocalizedTextValue);

            m_statusCodeValue = DataVariable<IList<StatusCode>>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.ArrayValueObjectType_StatusCodeValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.StatusCodeValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ArrayValueObjectType_StatusCodeValue);

            m_variantValue = DataVariable<IList<object>>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.ArrayValueObjectType_VariantValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.VariantValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ArrayValueObjectType_VariantValue);

            m_structureValue = DataVariable<IList<IEncodeable>>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                new NodeId(Opc.Ua.Sample.Variables.ArrayValueObjectType_StructureValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)), 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.StructureValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ArrayValueObjectType_StructureValue);
        }
        #endregion

        #region Private Fields
        DataVariable<IList<bool>> m_booleanValue;
        DataVariable<IList<sbyte>> m_sByteValue;
        DataVariable<IList<byte>> m_byteValue;
        DataVariable<IList<short>> m_int16Value;
        DataVariable<IList<ushort>> m_uInt16Value;
        DataVariable<IList<int>> m_int32Value;
        DataVariable<IList<uint>> m_uInt32Value;
        DataVariable<IList<long>> m_int64Value;
        DataVariable<IList<ulong>> m_uInt64Value;
        DataVariable<IList<float>> m_floatValue;
        DataVariable<IList<double>> m_doubleValue;
        DataVariable<IList<string>> m_stringValue;
        DataVariable<IList<DateTime>> m_dateTimeValue;
        DataVariable<IList<Guid>> m_guidValue;
        DataVariable<IList<byte[]>> m_byteStringValue;
        DataVariable<IList<XmlElement>> m_xmlElementValue;
        DataVariable<IList<NodeId>> m_nodeIdValue;
        DataVariable<IList<ExpandedNodeId>> m_expandedNodeIdValue;
        DataVariable<IList<QualifiedName>> m_qualifiedNameValue;
        DataVariable<IList<LocalizedText>> m_localizedTextValue;
        DataVariable<IList<StatusCode>> m_statusCodeValue;
        DataVariable<IList<object>> m_variantValue;
        DataVariable<IList<IEncodeable>> m_structureValue;
        #endregion
    }
    #endregion

    #region ArrayValueObject Class
    /// <summary>
    /// Represents an instance of the ArrayValueObjectType ObjectType in the address space.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class ArrayValueObject : TestDataObject
    {
        #region Constructors
        /// <summary>
        /// Initializes the object with default values.
        /// </summary>
        protected ArrayValueObject(IServerInternal server, NodeSource parent) 
        : 
            base(server, parent)
        {
            m_typeDefinition = ArrayValueObjectType.FindSource(server);
        }

        /// <summary>
        /// Creates a new instance of the node.
        /// </summary>
        public static new ArrayValueObject Construct(
            IServerInternal server, 
            NodeSource      parent, 
            NodeId          referenceTypeId,
            NodeId          nodeId,
            QualifiedName   browseName,
            uint            numericId)
        {
            ArrayValueObject instance = new ArrayValueObject(server, parent);
            instance.Initialize(referenceTypeId, nodeId, browseName, numericId, instance.m_typeDefinition.NodeId);
            return instance;
        }

        /// <summary>
        /// Creates a new instance of the node without any parent.
        /// </summary>
        public static new ArrayValueObject Construct(IServerInternal server)
        {
            ArrayValueObject instance = new ArrayValueObject(server, (NodeSource)null);
            instance.Initialize(null, null, null, 0, instance.m_typeDefinition.NodeId);
            return instance;
        }
        #endregion
           
        #region ICloneable Members
        /// <summary cref="NodeSource.Clone(NodeSource)" />
        public override NodeSource Clone(NodeSource parent)
        {
            lock (DataLock)
            {
                ArrayValueObject clone = new ArrayValueObject(Server, parent);
                clone.Initialize(this);
                return clone;
            } 
        }
        #endregion

        #region Public Properties
        #region BooleanValue
        /// <summary>
        /// A description for the BooleanValue Variable.
        /// </summary>
        public DataVariable<IList<bool>> BooleanValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_booleanValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_booleanValue != null)
                    {
                        RemoveChild(m_booleanValue);
                    }

                    m_booleanValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceBooleanValue(DataVariable<IList<bool>> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                BooleanValue = replacement;

                BooleanValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.BooleanValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ArrayValueObjectType_BooleanValue,
                    null);
            }
        }
        #endregion

        #region SByteValue
        /// <summary>
        /// A description for the SByteValue Variable.
        /// </summary>
        public DataVariable<IList<sbyte>> SByteValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_sByteValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_sByteValue != null)
                    {
                        RemoveChild(m_sByteValue);
                    }

                    m_sByteValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceSByteValue(DataVariable<IList<sbyte>> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                SByteValue = replacement;

                SByteValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.SByteValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ArrayValueObjectType_SByteValue,
                    null);
            }
        }
        #endregion

        #region ByteValue
        /// <summary>
        /// A description for the ByteValue Variable.
        /// </summary>
        public DataVariable<IList<byte>> ByteValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_byteValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_byteValue != null)
                    {
                        RemoveChild(m_byteValue);
                    }

                    m_byteValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceByteValue(DataVariable<IList<byte>> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                ByteValue = replacement;

                ByteValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.ByteValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ArrayValueObjectType_ByteValue,
                    null);
            }
        }
        #endregion

        #region Int16Value
        /// <summary>
        /// A description for the Int16Value Variable.
        /// </summary>
        public DataVariable<IList<short>> Int16Value
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_int16Value; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_int16Value != null)
                    {
                        RemoveChild(m_int16Value);
                    }

                    m_int16Value = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceInt16Value(DataVariable<IList<short>> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                Int16Value = replacement;

                Int16Value.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.Int16Value, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ArrayValueObjectType_Int16Value,
                    null);
            }
        }
        #endregion

        #region UInt16Value
        /// <summary>
        /// A description for the UInt16Value Variable.
        /// </summary>
        public DataVariable<IList<ushort>> UInt16Value
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_uInt16Value; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_uInt16Value != null)
                    {
                        RemoveChild(m_uInt16Value);
                    }

                    m_uInt16Value = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceUInt16Value(DataVariable<IList<ushort>> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                UInt16Value = replacement;

                UInt16Value.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.UInt16Value, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ArrayValueObjectType_UInt16Value,
                    null);
            }
        }
        #endregion

        #region Int32Value
        /// <summary>
        /// A description for the Int32Value Variable.
        /// </summary>
        public DataVariable<IList<int>> Int32Value
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_int32Value; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_int32Value != null)
                    {
                        RemoveChild(m_int32Value);
                    }

                    m_int32Value = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceInt32Value(DataVariable<IList<int>> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                Int32Value = replacement;

                Int32Value.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.Int32Value, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ArrayValueObjectType_Int32Value,
                    null);
            }
        }
        #endregion

        #region UInt32Value
        /// <summary>
        /// A description for the UInt32Value Variable.
        /// </summary>
        public DataVariable<IList<uint>> UInt32Value
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_uInt32Value; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_uInt32Value != null)
                    {
                        RemoveChild(m_uInt32Value);
                    }

                    m_uInt32Value = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceUInt32Value(DataVariable<IList<uint>> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                UInt32Value = replacement;

                UInt32Value.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.UInt32Value, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ArrayValueObjectType_UInt32Value,
                    null);
            }
        }
        #endregion

        #region Int64Value
        /// <summary>
        /// A description for the Int64Value Variable.
        /// </summary>
        public DataVariable<IList<long>> Int64Value
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_int64Value; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_int64Value != null)
                    {
                        RemoveChild(m_int64Value);
                    }

                    m_int64Value = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceInt64Value(DataVariable<IList<long>> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                Int64Value = replacement;

                Int64Value.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.Int64Value, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ArrayValueObjectType_Int64Value,
                    null);
            }
        }
        #endregion

        #region UInt64Value
        /// <summary>
        /// A description for the UInt64Value Variable.
        /// </summary>
        public DataVariable<IList<ulong>> UInt64Value
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_uInt64Value; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_uInt64Value != null)
                    {
                        RemoveChild(m_uInt64Value);
                    }

                    m_uInt64Value = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceUInt64Value(DataVariable<IList<ulong>> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                UInt64Value = replacement;

                UInt64Value.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.UInt64Value, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ArrayValueObjectType_UInt64Value,
                    null);
            }
        }
        #endregion

        #region FloatValue
        /// <summary>
        /// A description for the FloatValue Variable.
        /// </summary>
        public DataVariable<IList<float>> FloatValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_floatValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_floatValue != null)
                    {
                        RemoveChild(m_floatValue);
                    }

                    m_floatValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceFloatValue(DataVariable<IList<float>> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                FloatValue = replacement;

                FloatValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.FloatValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ArrayValueObjectType_FloatValue,
                    null);
            }
        }
        #endregion

        #region DoubleValue
        /// <summary>
        /// A description for the DoubleValue Variable.
        /// </summary>
        public DataVariable<IList<double>> DoubleValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_doubleValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_doubleValue != null)
                    {
                        RemoveChild(m_doubleValue);
                    }

                    m_doubleValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceDoubleValue(DataVariable<IList<double>> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                DoubleValue = replacement;

                DoubleValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.DoubleValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ArrayValueObjectType_DoubleValue,
                    null);
            }
        }
        #endregion

        #region StringValue
        /// <summary>
        /// A description for the StringValue Variable.
        /// </summary>
        public DataVariable<IList<string>> StringValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_stringValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_stringValue != null)
                    {
                        RemoveChild(m_stringValue);
                    }

                    m_stringValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceStringValue(DataVariable<IList<string>> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                StringValue = replacement;

                StringValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.StringValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ArrayValueObjectType_StringValue,
                    null);
            }
        }
        #endregion

        #region DateTimeValue
        /// <summary>
        /// A description for the DateTimeValue Variable.
        /// </summary>
        public DataVariable<IList<DateTime>> DateTimeValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_dateTimeValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_dateTimeValue != null)
                    {
                        RemoveChild(m_dateTimeValue);
                    }

                    m_dateTimeValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceDateTimeValue(DataVariable<IList<DateTime>> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                DateTimeValue = replacement;

                DateTimeValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.DateTimeValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ArrayValueObjectType_DateTimeValue,
                    null);
            }
        }
        #endregion

        #region GuidValue
        /// <summary>
        /// A description for the GuidValue Variable.
        /// </summary>
        public DataVariable<IList<Guid>> GuidValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_guidValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_guidValue != null)
                    {
                        RemoveChild(m_guidValue);
                    }

                    m_guidValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceGuidValue(DataVariable<IList<Guid>> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                GuidValue = replacement;

                GuidValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.GuidValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ArrayValueObjectType_GuidValue,
                    null);
            }
        }
        #endregion

        #region ByteStringValue
        /// <summary>
        /// A description for the ByteStringValue Variable.
        /// </summary>
        public DataVariable<IList<byte[]>> ByteStringValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_byteStringValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_byteStringValue != null)
                    {
                        RemoveChild(m_byteStringValue);
                    }

                    m_byteStringValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceByteStringValue(DataVariable<IList<byte[]>> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                ByteStringValue = replacement;

                ByteStringValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.ByteStringValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ArrayValueObjectType_ByteStringValue,
                    null);
            }
        }
        #endregion

        #region XmlElementValue
        /// <summary>
        /// A description for the XmlElementValue Variable.
        /// </summary>
        public DataVariable<IList<XmlElement>> XmlElementValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_xmlElementValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_xmlElementValue != null)
                    {
                        RemoveChild(m_xmlElementValue);
                    }

                    m_xmlElementValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceXmlElementValue(DataVariable<IList<XmlElement>> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                XmlElementValue = replacement;

                XmlElementValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.XmlElementValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ArrayValueObjectType_XmlElementValue,
                    null);
            }
        }
        #endregion

        #region NodeIdValue
        /// <summary>
        /// A description for the NodeIdValue Variable.
        /// </summary>
        public DataVariable<IList<NodeId>> NodeIdValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_nodeIdValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_nodeIdValue != null)
                    {
                        RemoveChild(m_nodeIdValue);
                    }

                    m_nodeIdValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceNodeIdValue(DataVariable<IList<NodeId>> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                NodeIdValue = replacement;

                NodeIdValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.NodeIdValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ArrayValueObjectType_NodeIdValue,
                    null);
            }
        }
        #endregion

        #region ExpandedNodeIdValue
        /// <summary>
        /// A description for the ExpandedNodeIdValue Variable.
        /// </summary>
        public DataVariable<IList<ExpandedNodeId>> ExpandedNodeIdValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_expandedNodeIdValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_expandedNodeIdValue != null)
                    {
                        RemoveChild(m_expandedNodeIdValue);
                    }

                    m_expandedNodeIdValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceExpandedNodeIdValue(DataVariable<IList<ExpandedNodeId>> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                ExpandedNodeIdValue = replacement;

                ExpandedNodeIdValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.ExpandedNodeIdValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ArrayValueObjectType_ExpandedNodeIdValue,
                    null);
            }
        }
        #endregion

        #region QualifiedNameValue
        /// <summary>
        /// A description for the QualifiedNameValue Variable.
        /// </summary>
        public DataVariable<IList<QualifiedName>> QualifiedNameValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_qualifiedNameValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_qualifiedNameValue != null)
                    {
                        RemoveChild(m_qualifiedNameValue);
                    }

                    m_qualifiedNameValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceQualifiedNameValue(DataVariable<IList<QualifiedName>> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                QualifiedNameValue = replacement;

                QualifiedNameValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.QualifiedNameValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ArrayValueObjectType_QualifiedNameValue,
                    null);
            }
        }
        #endregion

        #region LocalizedTextValue
        /// <summary>
        /// A description for the LocalizedTextValue Variable.
        /// </summary>
        public DataVariable<IList<LocalizedText>> LocalizedTextValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_localizedTextValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_localizedTextValue != null)
                    {
                        RemoveChild(m_localizedTextValue);
                    }

                    m_localizedTextValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceLocalizedTextValue(DataVariable<IList<LocalizedText>> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                LocalizedTextValue = replacement;

                LocalizedTextValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.LocalizedTextValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ArrayValueObjectType_LocalizedTextValue,
                    null);
            }
        }
        #endregion

        #region StatusCodeValue
        /// <summary>
        /// A description for the StatusCodeValue Variable.
        /// </summary>
        public DataVariable<IList<StatusCode>> StatusCodeValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_statusCodeValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_statusCodeValue != null)
                    {
                        RemoveChild(m_statusCodeValue);
                    }

                    m_statusCodeValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceStatusCodeValue(DataVariable<IList<StatusCode>> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                StatusCodeValue = replacement;

                StatusCodeValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.StatusCodeValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ArrayValueObjectType_StatusCodeValue,
                    null);
            }
        }
        #endregion

        #region VariantValue
        /// <summary>
        /// A description for the VariantValue Variable.
        /// </summary>
        public DataVariable<IList<object>> VariantValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_variantValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_variantValue != null)
                    {
                        RemoveChild(m_variantValue);
                    }

                    m_variantValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceVariantValue(DataVariable<IList<object>> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                VariantValue = replacement;

                VariantValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.VariantValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ArrayValueObjectType_VariantValue,
                    null);
            }
        }
        #endregion

        #region StructureValue
        /// <summary>
        /// A description for the StructureValue Variable.
        /// </summary>
        public DataVariable<IList<IEncodeable>> StructureValue
        {
        	get 
            {
                lock (DataLock)
                {      
                    return m_structureValue; 
                }
            }

            protected set
            {
                lock (DataLock)
                {      
                    if (m_structureValue != null)
                    {
                        RemoveChild(m_structureValue);
                    }

                    m_structureValue = value; 
                }
            }
        }
            
        /// <summary>
        /// Replaces the child with another node.
        /// </summary>
        public void ReplaceStructureValue(DataVariable<IList<IEncodeable>> replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            
            CheckNodeManagerState();

            lock (DataLock)
            {
                StructureValue = replacement;

                StructureValue.Create(
                    this.NodeId,
                    new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                    null,
                    new QualifiedName(Opc.Ua.Sample.BrowseNames.StructureValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                    Opc.Ua.Sample.Variables.ArrayValueObjectType_StructureValue,
                    null);
            }
        }
        #endregion
        #endregion

        #region Overridden Methods
        /// <summary cref="NodeSource.Initialize(NodeSource)" />
        public override void Initialize(NodeSource source)
        {
            lock (DataLock)
            {            
                ArrayValueObject instance = source as ArrayValueObject;

                if (instance != null)
                {
                    base.Initialize(source);
                }

                ArrayValueObjectType type = source as ArrayValueObjectType;

                if (type != null && type.BooleanValue != null)
                {
                    BooleanValue = (DataVariable<IList<bool>>)type.BooleanValue.Clone(this);
                    BooleanValue.Initialize(type.BooleanValue);
                }
                else if (instance != null && instance.BooleanValue != null)
                {
                    BooleanValue = (DataVariable<IList<bool>>)instance.BooleanValue.Clone(this);
                    BooleanValue.Initialize(instance.BooleanValue);
                }

                if (type != null && type.SByteValue != null)
                {
                    SByteValue = (DataVariable<IList<sbyte>>)type.SByteValue.Clone(this);
                    SByteValue.Initialize(type.SByteValue);
                }
                else if (instance != null && instance.SByteValue != null)
                {
                    SByteValue = (DataVariable<IList<sbyte>>)instance.SByteValue.Clone(this);
                    SByteValue.Initialize(instance.SByteValue);
                }

                if (type != null && type.ByteValue != null)
                {
                    ByteValue = (DataVariable<IList<byte>>)type.ByteValue.Clone(this);
                    ByteValue.Initialize(type.ByteValue);
                }
                else if (instance != null && instance.ByteValue != null)
                {
                    ByteValue = (DataVariable<IList<byte>>)instance.ByteValue.Clone(this);
                    ByteValue.Initialize(instance.ByteValue);
                }

                if (type != null && type.Int16Value != null)
                {
                    Int16Value = (DataVariable<IList<short>>)type.Int16Value.Clone(this);
                    Int16Value.Initialize(type.Int16Value);
                }
                else if (instance != null && instance.Int16Value != null)
                {
                    Int16Value = (DataVariable<IList<short>>)instance.Int16Value.Clone(this);
                    Int16Value.Initialize(instance.Int16Value);
                }

                if (type != null && type.UInt16Value != null)
                {
                    UInt16Value = (DataVariable<IList<ushort>>)type.UInt16Value.Clone(this);
                    UInt16Value.Initialize(type.UInt16Value);
                }
                else if (instance != null && instance.UInt16Value != null)
                {
                    UInt16Value = (DataVariable<IList<ushort>>)instance.UInt16Value.Clone(this);
                    UInt16Value.Initialize(instance.UInt16Value);
                }

                if (type != null && type.Int32Value != null)
                {
                    Int32Value = (DataVariable<IList<int>>)type.Int32Value.Clone(this);
                    Int32Value.Initialize(type.Int32Value);
                }
                else if (instance != null && instance.Int32Value != null)
                {
                    Int32Value = (DataVariable<IList<int>>)instance.Int32Value.Clone(this);
                    Int32Value.Initialize(instance.Int32Value);
                }

                if (type != null && type.UInt32Value != null)
                {
                    UInt32Value = (DataVariable<IList<uint>>)type.UInt32Value.Clone(this);
                    UInt32Value.Initialize(type.UInt32Value);
                }
                else if (instance != null && instance.UInt32Value != null)
                {
                    UInt32Value = (DataVariable<IList<uint>>)instance.UInt32Value.Clone(this);
                    UInt32Value.Initialize(instance.UInt32Value);
                }

                if (type != null && type.Int64Value != null)
                {
                    Int64Value = (DataVariable<IList<long>>)type.Int64Value.Clone(this);
                    Int64Value.Initialize(type.Int64Value);
                }
                else if (instance != null && instance.Int64Value != null)
                {
                    Int64Value = (DataVariable<IList<long>>)instance.Int64Value.Clone(this);
                    Int64Value.Initialize(instance.Int64Value);
                }

                if (type != null && type.UInt64Value != null)
                {
                    UInt64Value = (DataVariable<IList<ulong>>)type.UInt64Value.Clone(this);
                    UInt64Value.Initialize(type.UInt64Value);
                }
                else if (instance != null && instance.UInt64Value != null)
                {
                    UInt64Value = (DataVariable<IList<ulong>>)instance.UInt64Value.Clone(this);
                    UInt64Value.Initialize(instance.UInt64Value);
                }

                if (type != null && type.FloatValue != null)
                {
                    FloatValue = (DataVariable<IList<float>>)type.FloatValue.Clone(this);
                    FloatValue.Initialize(type.FloatValue);
                }
                else if (instance != null && instance.FloatValue != null)
                {
                    FloatValue = (DataVariable<IList<float>>)instance.FloatValue.Clone(this);
                    FloatValue.Initialize(instance.FloatValue);
                }

                if (type != null && type.DoubleValue != null)
                {
                    DoubleValue = (DataVariable<IList<double>>)type.DoubleValue.Clone(this);
                    DoubleValue.Initialize(type.DoubleValue);
                }
                else if (instance != null && instance.DoubleValue != null)
                {
                    DoubleValue = (DataVariable<IList<double>>)instance.DoubleValue.Clone(this);
                    DoubleValue.Initialize(instance.DoubleValue);
                }

                if (type != null && type.StringValue != null)
                {
                    StringValue = (DataVariable<IList<string>>)type.StringValue.Clone(this);
                    StringValue.Initialize(type.StringValue);
                }
                else if (instance != null && instance.StringValue != null)
                {
                    StringValue = (DataVariable<IList<string>>)instance.StringValue.Clone(this);
                    StringValue.Initialize(instance.StringValue);
                }

                if (type != null && type.DateTimeValue != null)
                {
                    DateTimeValue = (DataVariable<IList<DateTime>>)type.DateTimeValue.Clone(this);
                    DateTimeValue.Initialize(type.DateTimeValue);
                }
                else if (instance != null && instance.DateTimeValue != null)
                {
                    DateTimeValue = (DataVariable<IList<DateTime>>)instance.DateTimeValue.Clone(this);
                    DateTimeValue.Initialize(instance.DateTimeValue);
                }

                if (type != null && type.GuidValue != null)
                {
                    GuidValue = (DataVariable<IList<Guid>>)type.GuidValue.Clone(this);
                    GuidValue.Initialize(type.GuidValue);
                }
                else if (instance != null && instance.GuidValue != null)
                {
                    GuidValue = (DataVariable<IList<Guid>>)instance.GuidValue.Clone(this);
                    GuidValue.Initialize(instance.GuidValue);
                }

                if (type != null && type.ByteStringValue != null)
                {
                    ByteStringValue = (DataVariable<IList<byte[]>>)type.ByteStringValue.Clone(this);
                    ByteStringValue.Initialize(type.ByteStringValue);
                }
                else if (instance != null && instance.ByteStringValue != null)
                {
                    ByteStringValue = (DataVariable<IList<byte[]>>)instance.ByteStringValue.Clone(this);
                    ByteStringValue.Initialize(instance.ByteStringValue);
                }

                if (type != null && type.XmlElementValue != null)
                {
                    XmlElementValue = (DataVariable<IList<XmlElement>>)type.XmlElementValue.Clone(this);
                    XmlElementValue.Initialize(type.XmlElementValue);
                }
                else if (instance != null && instance.XmlElementValue != null)
                {
                    XmlElementValue = (DataVariable<IList<XmlElement>>)instance.XmlElementValue.Clone(this);
                    XmlElementValue.Initialize(instance.XmlElementValue);
                }

                if (type != null && type.NodeIdValue != null)
                {
                    NodeIdValue = (DataVariable<IList<NodeId>>)type.NodeIdValue.Clone(this);
                    NodeIdValue.Initialize(type.NodeIdValue);
                }
                else if (instance != null && instance.NodeIdValue != null)
                {
                    NodeIdValue = (DataVariable<IList<NodeId>>)instance.NodeIdValue.Clone(this);
                    NodeIdValue.Initialize(instance.NodeIdValue);
                }

                if (type != null && type.ExpandedNodeIdValue != null)
                {
                    ExpandedNodeIdValue = (DataVariable<IList<ExpandedNodeId>>)type.ExpandedNodeIdValue.Clone(this);
                    ExpandedNodeIdValue.Initialize(type.ExpandedNodeIdValue);
                }
                else if (instance != null && instance.ExpandedNodeIdValue != null)
                {
                    ExpandedNodeIdValue = (DataVariable<IList<ExpandedNodeId>>)instance.ExpandedNodeIdValue.Clone(this);
                    ExpandedNodeIdValue.Initialize(instance.ExpandedNodeIdValue);
                }

                if (type != null && type.QualifiedNameValue != null)
                {
                    QualifiedNameValue = (DataVariable<IList<QualifiedName>>)type.QualifiedNameValue.Clone(this);
                    QualifiedNameValue.Initialize(type.QualifiedNameValue);
                }
                else if (instance != null && instance.QualifiedNameValue != null)
                {
                    QualifiedNameValue = (DataVariable<IList<QualifiedName>>)instance.QualifiedNameValue.Clone(this);
                    QualifiedNameValue.Initialize(instance.QualifiedNameValue);
                }

                if (type != null && type.LocalizedTextValue != null)
                {
                    LocalizedTextValue = (DataVariable<IList<LocalizedText>>)type.LocalizedTextValue.Clone(this);
                    LocalizedTextValue.Initialize(type.LocalizedTextValue);
                }
                else if (instance != null && instance.LocalizedTextValue != null)
                {
                    LocalizedTextValue = (DataVariable<IList<LocalizedText>>)instance.LocalizedTextValue.Clone(this);
                    LocalizedTextValue.Initialize(instance.LocalizedTextValue);
                }

                if (type != null && type.StatusCodeValue != null)
                {
                    StatusCodeValue = (DataVariable<IList<StatusCode>>)type.StatusCodeValue.Clone(this);
                    StatusCodeValue.Initialize(type.StatusCodeValue);
                }
                else if (instance != null && instance.StatusCodeValue != null)
                {
                    StatusCodeValue = (DataVariable<IList<StatusCode>>)instance.StatusCodeValue.Clone(this);
                    StatusCodeValue.Initialize(instance.StatusCodeValue);
                }

                if (type != null && type.VariantValue != null)
                {
                    VariantValue = (DataVariable<IList<object>>)type.VariantValue.Clone(this);
                    VariantValue.Initialize(type.VariantValue);
                }
                else if (instance != null && instance.VariantValue != null)
                {
                    VariantValue = (DataVariable<IList<object>>)instance.VariantValue.Clone(this);
                    VariantValue.Initialize(instance.VariantValue);
                }

                if (type != null && type.StructureValue != null)
                {
                    StructureValue = (DataVariable<IList<IEncodeable>>)type.StructureValue.Clone(this);
                    StructureValue.Initialize(type.StructureValue);
                }
                else if (instance != null && instance.StructureValue != null)
                {
                    StructureValue = (DataVariable<IList<IEncodeable>>)instance.StructureValue.Clone(this);
                    StructureValue.Initialize(instance.StructureValue);
                }
            }
        }

        /// <summary cref="NodeSource.InitializeChildren" />
        protected override void InitializeChildren()
        {
            base.InitializeChildren();
                
            m_booleanValue = DataVariable<IList<bool>>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.BooleanValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ArrayValueObjectType_BooleanValue);

            m_sByteValue = DataVariable<IList<sbyte>>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.SByteValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ArrayValueObjectType_SByteValue);

            m_byteValue = DataVariable<IList<byte>>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.ByteValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ArrayValueObjectType_ByteValue);

            m_int16Value = DataVariable<IList<short>>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.Int16Value, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ArrayValueObjectType_Int16Value);

            m_uInt16Value = DataVariable<IList<ushort>>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.UInt16Value, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ArrayValueObjectType_UInt16Value);

            m_int32Value = DataVariable<IList<int>>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.Int32Value, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ArrayValueObjectType_Int32Value);

            m_uInt32Value = DataVariable<IList<uint>>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.UInt32Value, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ArrayValueObjectType_UInt32Value);

            m_int64Value = DataVariable<IList<long>>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.Int64Value, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ArrayValueObjectType_Int64Value);

            m_uInt64Value = DataVariable<IList<ulong>>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.UInt64Value, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ArrayValueObjectType_UInt64Value);

            m_floatValue = DataVariable<IList<float>>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.FloatValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ArrayValueObjectType_FloatValue);

            m_doubleValue = DataVariable<IList<double>>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.DoubleValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ArrayValueObjectType_DoubleValue);

            m_stringValue = DataVariable<IList<string>>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.StringValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ArrayValueObjectType_StringValue);

            m_dateTimeValue = DataVariable<IList<DateTime>>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.DateTimeValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ArrayValueObjectType_DateTimeValue);

            m_guidValue = DataVariable<IList<Guid>>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.GuidValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ArrayValueObjectType_GuidValue);

            m_byteStringValue = DataVariable<IList<byte[]>>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.ByteStringValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ArrayValueObjectType_ByteStringValue);

            m_xmlElementValue = DataVariable<IList<XmlElement>>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.XmlElementValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ArrayValueObjectType_XmlElementValue);

            m_nodeIdValue = DataVariable<IList<NodeId>>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.NodeIdValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ArrayValueObjectType_NodeIdValue);

            m_expandedNodeIdValue = DataVariable<IList<ExpandedNodeId>>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.ExpandedNodeIdValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ArrayValueObjectType_ExpandedNodeIdValue);

            m_qualifiedNameValue = DataVariable<IList<QualifiedName>>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.QualifiedNameValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ArrayValueObjectType_QualifiedNameValue);

            m_localizedTextValue = DataVariable<IList<LocalizedText>>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.LocalizedTextValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ArrayValueObjectType_LocalizedTextValue);

            m_statusCodeValue = DataVariable<IList<StatusCode>>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.StatusCodeValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ArrayValueObjectType_StatusCodeValue);

            m_variantValue = DataVariable<IList<object>>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.VariantValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ArrayValueObjectType_VariantValue);

            m_structureValue = DataVariable<IList<IEncodeable>>.Construct(
                Server, 
                this, 
                new NodeId(Opc.Ua.ReferenceTypes.HasComponent, GetNamespaceIndex(Opc.Ua.Namespaces.OpcUa)), 
                null, 
                new QualifiedName(Opc.Ua.Sample.BrowseNames.StructureValue, GetNamespaceIndex(Opc.Ua.Sample.Namespaces.Sample)),
                Opc.Ua.Sample.Variables.ArrayValueObjectType_StructureValue);
        }
        #endregion

        #region Private Fields
        private ArrayValueObjectType m_typeDefinition;
        DataVariable<IList<bool>> m_booleanValue;
        DataVariable<IList<sbyte>> m_sByteValue;
        DataVariable<IList<byte>> m_byteValue;
        DataVariable<IList<short>> m_int16Value;
        DataVariable<IList<ushort>> m_uInt16Value;
        DataVariable<IList<int>> m_int32Value;
        DataVariable<IList<uint>> m_uInt32Value;
        DataVariable<IList<long>> m_int64Value;
        DataVariable<IList<ulong>> m_uInt64Value;
        DataVariable<IList<float>> m_floatValue;
        DataVariable<IList<double>> m_doubleValue;
        DataVariable<IList<string>> m_stringValue;
        DataVariable<IList<DateTime>> m_dateTimeValue;
        DataVariable<IList<Guid>> m_guidValue;
        DataVariable<IList<byte[]>> m_byteStringValue;
        DataVariable<IList<XmlElement>> m_xmlElementValue;
        DataVariable<IList<NodeId>> m_nodeIdValue;
        DataVariable<IList<ExpandedNodeId>> m_expandedNodeIdValue;
        DataVariable<IList<QualifiedName>> m_qualifiedNameValue;
        DataVariable<IList<LocalizedText>> m_localizedTextValue;
        DataVariable<IList<StatusCode>> m_statusCodeValue;
        DataVariable<IList<object>> m_variantValue;
        DataVariable<IList<IEncodeable>> m_structureValue;
        #endregion
    }
    #endregion
#endif
}
