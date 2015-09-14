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
    #region DataType Identifiers
    /// <summary>
    /// A class that declares constants for all DataTypes in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class DataTypes
    {
        /// <summary>
        /// The identifier for the CalibrationDataType DataType.
        /// </summary>
        public const uint CalibrationDataType = 198;
    }
    #endregion

    #region Object Identifiers
    /// <summary>
    /// A class that declares constants for all Objects in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Objects
    {
        /// <summary>
        /// The identifier for the PipeType_FlowTransmitter Object.
        /// </summary>
        public const uint PipeType_FlowTransmitter = 200;

        /// <summary>
        /// The identifier for the PipeType_Valve Object.
        /// </summary>
        public const uint PipeType_Valve = 207;

        /// <summary>
        /// The identifier for the Pipe1 Object.
        /// </summary>
        public const uint Pipe1 = 215;

        /// <summary>
        /// The identifier for the Pipe1_FlowTransmitter Object.
        /// </summary>
        public const uint Pipe1_FlowTransmitter = 216;

        /// <summary>
        /// The identifier for the Pipe1_Valve Object.
        /// </summary>
        public const uint Pipe1_Valve = 223;

        /// <summary>
        /// The identifier for the CalibrationDataType_Encoding_DefaultXml Object.
        /// </summary>
        public const uint CalibrationDataType_Encoding_DefaultXml = 231;

        /// <summary>
        /// The identifier for the CalibrationDataType_Encoding_DefaultBinary Object.
        /// </summary>
        public const uint CalibrationDataType_Encoding_DefaultBinary = 238;
    }
    #endregion

    #region ObjectType Identifiers
    /// <summary>
    /// A class that declares constants for all ObjectTypes in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class ObjectTypes
    {
        /// <summary>
        /// The identifier for the GenericSensorType ObjectType.
        /// </summary>
        public const uint GenericSensorType = 7;

        /// <summary>
        /// The identifier for the GenericActuatorType ObjectType.
        /// </summary>
        public const uint GenericActuatorType = 14;

        /// <summary>
        /// The identifier for the PipeType ObjectType.
        /// </summary>
        public const uint PipeType = 199;
    }
    #endregion

    #region ReferenceType Identifiers
    /// <summary>
    /// A class that declares constants for all ReferenceTypes in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class ReferenceTypes
    {
        /// <summary>
        /// The identifier for the SignalTo ReferenceType.
        /// </summary>
        public const uint SignalTo = 2;
    }
    #endregion

    #region Variable Identifiers
    /// <summary>
    /// A class that declares constants for all Variables in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Variables
    {
        /// <summary>
        /// The identifier for the GenericSensorType_Output Variable.
        /// </summary>
        public const uint GenericSensorType_Output = 8;

        /// <summary>
        /// The identifier for the GenericSensorType_Output_Definition Variable.
        /// </summary>
        public const uint GenericSensorType_Output_Definition = 9;

        /// <summary>
        /// The identifier for the GenericSensorType_Output_ValuePrecision Variable.
        /// </summary>
        public const uint GenericSensorType_Output_ValuePrecision = 10;

        /// <summary>
        /// The identifier for the GenericSensorType_Output_EURange Variable.
        /// </summary>
        public const uint GenericSensorType_Output_EURange = 11;

        /// <summary>
        /// The identifier for the GenericSensorType_Output_InstrumentRange Variable.
        /// </summary>
        public const uint GenericSensorType_Output_InstrumentRange = 12;

        /// <summary>
        /// The identifier for the GenericSensorType_Output_EngineeringUnits Variable.
        /// </summary>
        public const uint GenericSensorType_Output_EngineeringUnits = 13;

        /// <summary>
        /// The identifier for the GenericActuatorType_Input Variable.
        /// </summary>
        public const uint GenericActuatorType_Input = 15;

        /// <summary>
        /// The identifier for the GenericActuatorType_Input_Definition Variable.
        /// </summary>
        public const uint GenericActuatorType_Input_Definition = 16;

        /// <summary>
        /// The identifier for the GenericActuatorType_Input_ValuePrecision Variable.
        /// </summary>
        public const uint GenericActuatorType_Input_ValuePrecision = 17;

        /// <summary>
        /// The identifier for the GenericActuatorType_Input_EURange Variable.
        /// </summary>
        public const uint GenericActuatorType_Input_EURange = 18;

        /// <summary>
        /// The identifier for the GenericActuatorType_Input_InstrumentRange Variable.
        /// </summary>
        public const uint GenericActuatorType_Input_InstrumentRange = 19;

        /// <summary>
        /// The identifier for the GenericActuatorType_Input_EngineeringUnits Variable.
        /// </summary>
        public const uint GenericActuatorType_Input_EngineeringUnits = 20;

        /// <summary>
        /// The identifier for the PipeType_FlowTransmitter_Output Variable.
        /// </summary>
        public const uint PipeType_FlowTransmitter_Output = 201;

        /// <summary>
        /// The identifier for the PipeType_FlowTransmitter_Output_Definition Variable.
        /// </summary>
        public const uint PipeType_FlowTransmitter_Output_Definition = 202;

        /// <summary>
        /// The identifier for the PipeType_FlowTransmitter_Output_ValuePrecision Variable.
        /// </summary>
        public const uint PipeType_FlowTransmitter_Output_ValuePrecision = 203;

        /// <summary>
        /// The identifier for the PipeType_FlowTransmitter_Output_EURange Variable.
        /// </summary>
        public const uint PipeType_FlowTransmitter_Output_EURange = 204;

        /// <summary>
        /// The identifier for the PipeType_FlowTransmitter_Output_InstrumentRange Variable.
        /// </summary>
        public const uint PipeType_FlowTransmitter_Output_InstrumentRange = 205;

        /// <summary>
        /// The identifier for the PipeType_FlowTransmitter_Output_EngineeringUnits Variable.
        /// </summary>
        public const uint PipeType_FlowTransmitter_Output_EngineeringUnits = 206;

        /// <summary>
        /// The identifier for the PipeType_Valve_Input Variable.
        /// </summary>
        public const uint PipeType_Valve_Input = 208;

        /// <summary>
        /// The identifier for the PipeType_Valve_Input_Definition Variable.
        /// </summary>
        public const uint PipeType_Valve_Input_Definition = 209;

        /// <summary>
        /// The identifier for the PipeType_Valve_Input_ValuePrecision Variable.
        /// </summary>
        public const uint PipeType_Valve_Input_ValuePrecision = 210;

        /// <summary>
        /// The identifier for the PipeType_Valve_Input_EURange Variable.
        /// </summary>
        public const uint PipeType_Valve_Input_EURange = 211;

        /// <summary>
        /// The identifier for the PipeType_Valve_Input_InstrumentRange Variable.
        /// </summary>
        public const uint PipeType_Valve_Input_InstrumentRange = 212;

        /// <summary>
        /// The identifier for the PipeType_Valve_Input_EngineeringUnits Variable.
        /// </summary>
        public const uint PipeType_Valve_Input_EngineeringUnits = 213;

        /// <summary>
        /// The identifier for the PipeType_Calibration Variable.
        /// </summary>
        public const uint PipeType_Calibration = 245;

        /// <summary>
        /// The identifier for the Pipe1_FlowTransmitter_Output Variable.
        /// </summary>
        public const uint Pipe1_FlowTransmitter_Output = 217;

        /// <summary>
        /// The identifier for the Pipe1_FlowTransmitter_Output_Definition Variable.
        /// </summary>
        public const uint Pipe1_FlowTransmitter_Output_Definition = 218;

        /// <summary>
        /// The identifier for the Pipe1_FlowTransmitter_Output_ValuePrecision Variable.
        /// </summary>
        public const uint Pipe1_FlowTransmitter_Output_ValuePrecision = 219;

        /// <summary>
        /// The identifier for the Pipe1_FlowTransmitter_Output_EURange Variable.
        /// </summary>
        public const uint Pipe1_FlowTransmitter_Output_EURange = 220;

        /// <summary>
        /// The identifier for the Pipe1_FlowTransmitter_Output_InstrumentRange Variable.
        /// </summary>
        public const uint Pipe1_FlowTransmitter_Output_InstrumentRange = 221;

        /// <summary>
        /// The identifier for the Pipe1_FlowTransmitter_Output_EngineeringUnits Variable.
        /// </summary>
        public const uint Pipe1_FlowTransmitter_Output_EngineeringUnits = 222;

        /// <summary>
        /// The identifier for the Pipe1_Valve_Input Variable.
        /// </summary>
        public const uint Pipe1_Valve_Input = 224;

        /// <summary>
        /// The identifier for the Pipe1_Valve_Input_Definition Variable.
        /// </summary>
        public const uint Pipe1_Valve_Input_Definition = 225;

        /// <summary>
        /// The identifier for the Pipe1_Valve_Input_ValuePrecision Variable.
        /// </summary>
        public const uint Pipe1_Valve_Input_ValuePrecision = 226;

        /// <summary>
        /// The identifier for the Pipe1_Valve_Input_EURange Variable.
        /// </summary>
        public const uint Pipe1_Valve_Input_EURange = 227;

        /// <summary>
        /// The identifier for the Pipe1_Valve_Input_InstrumentRange Variable.
        /// </summary>
        public const uint Pipe1_Valve_Input_InstrumentRange = 228;

        /// <summary>
        /// The identifier for the Pipe1_Valve_Input_EngineeringUnits Variable.
        /// </summary>
        public const uint Pipe1_Valve_Input_EngineeringUnits = 229;

        /// <summary>
        /// The identifier for the Pipe1_Calibration Variable.
        /// </summary>
        public const uint Pipe1_Calibration = 246;

        /// <summary>
        /// The identifier for the Tutorial_XmlSchema Variable.
        /// </summary>
        public const uint Tutorial_XmlSchema = 232;

        /// <summary>
        /// The identifier for the Tutorial_XmlSchema_DataTypeVersion Variable.
        /// </summary>
        public const uint Tutorial_XmlSchema_DataTypeVersion = 233;

        /// <summary>
        /// The identifier for the Tutorial_XmlSchema_NamespaceUri Variable.
        /// </summary>
        public const uint Tutorial_XmlSchema_NamespaceUri = 234;

        /// <summary>
        /// The identifier for the Tutorial_XmlSchema_CalibrationDataType Variable.
        /// </summary>
        public const uint Tutorial_XmlSchema_CalibrationDataType = 235;

        /// <summary>
        /// The identifier for the Tutorial_XmlSchema_CalibrationDataType_DataTypeVersion Variable.
        /// </summary>
        public const uint Tutorial_XmlSchema_CalibrationDataType_DataTypeVersion = 236;

        /// <summary>
        /// The identifier for the Tutorial_XmlSchema_CalibrationDataType_DictionaryFragment Variable.
        /// </summary>
        public const uint Tutorial_XmlSchema_CalibrationDataType_DictionaryFragment = 237;

        /// <summary>
        /// The identifier for the Tutorial_BinarySchema Variable.
        /// </summary>
        public const uint Tutorial_BinarySchema = 239;

        /// <summary>
        /// The identifier for the Tutorial_BinarySchema_DataTypeVersion Variable.
        /// </summary>
        public const uint Tutorial_BinarySchema_DataTypeVersion = 240;

        /// <summary>
        /// The identifier for the Tutorial_BinarySchema_NamespaceUri Variable.
        /// </summary>
        public const uint Tutorial_BinarySchema_NamespaceUri = 241;

        /// <summary>
        /// The identifier for the Tutorial_BinarySchema_CalibrationDataType Variable.
        /// </summary>
        public const uint Tutorial_BinarySchema_CalibrationDataType = 242;

        /// <summary>
        /// The identifier for the Tutorial_BinarySchema_CalibrationDataType_DataTypeVersion Variable.
        /// </summary>
        public const uint Tutorial_BinarySchema_CalibrationDataType_DataTypeVersion = 243;

        /// <summary>
        /// The identifier for the Tutorial_BinarySchema_CalibrationDataType_DictionaryFragment Variable.
        /// </summary>
        public const uint Tutorial_BinarySchema_CalibrationDataType_DictionaryFragment = 244;
    }
    #endregion

    #region DataType Node Identifiers
    /// <summary>
    /// A class that declares constants for all DataTypes in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class DataTypeIds
    {
        /// <summary>
        /// The identifier for the CalibrationDataType DataType.
        /// </summary>
        public static readonly ExpandedNodeId CalibrationDataType = new ExpandedNodeId(TutorialModel.DataTypes.CalibrationDataType, TutorialModel.Namespaces.Tutorial);
    }
    #endregion

    #region Object Node Identifiers
    /// <summary>
    /// A class that declares constants for all Objects in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class ObjectIds
    {
        /// <summary>
        /// The identifier for the PipeType_FlowTransmitter Object.
        /// </summary>
        public static readonly ExpandedNodeId PipeType_FlowTransmitter = new ExpandedNodeId(TutorialModel.Objects.PipeType_FlowTransmitter, TutorialModel.Namespaces.Tutorial);

        /// <summary>
        /// The identifier for the PipeType_Valve Object.
        /// </summary>
        public static readonly ExpandedNodeId PipeType_Valve = new ExpandedNodeId(TutorialModel.Objects.PipeType_Valve, TutorialModel.Namespaces.Tutorial);

        /// <summary>
        /// The identifier for the Pipe1 Object.
        /// </summary>
        public static readonly ExpandedNodeId Pipe1 = new ExpandedNodeId(TutorialModel.Objects.Pipe1, TutorialModel.Namespaces.Tutorial);

        /// <summary>
        /// The identifier for the Pipe1_FlowTransmitter Object.
        /// </summary>
        public static readonly ExpandedNodeId Pipe1_FlowTransmitter = new ExpandedNodeId(TutorialModel.Objects.Pipe1_FlowTransmitter, TutorialModel.Namespaces.Tutorial);

        /// <summary>
        /// The identifier for the Pipe1_Valve Object.
        /// </summary>
        public static readonly ExpandedNodeId Pipe1_Valve = new ExpandedNodeId(TutorialModel.Objects.Pipe1_Valve, TutorialModel.Namespaces.Tutorial);

        /// <summary>
        /// The identifier for the CalibrationDataType_Encoding_DefaultXml Object.
        /// </summary>
        public static readonly ExpandedNodeId CalibrationDataType_Encoding_DefaultXml = new ExpandedNodeId(TutorialModel.Objects.CalibrationDataType_Encoding_DefaultXml, TutorialModel.Namespaces.Tutorial);

        /// <summary>
        /// The identifier for the CalibrationDataType_Encoding_DefaultBinary Object.
        /// </summary>
        public static readonly ExpandedNodeId CalibrationDataType_Encoding_DefaultBinary = new ExpandedNodeId(TutorialModel.Objects.CalibrationDataType_Encoding_DefaultBinary, TutorialModel.Namespaces.Tutorial);
    }
    #endregion

    #region ObjectType Node Identifiers
    /// <summary>
    /// A class that declares constants for all ObjectTypes in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class ObjectTypeIds
    {
        /// <summary>
        /// The identifier for the GenericSensorType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId GenericSensorType = new ExpandedNodeId(TutorialModel.ObjectTypes.GenericSensorType, TutorialModel.Namespaces.Tutorial);

        /// <summary>
        /// The identifier for the GenericActuatorType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId GenericActuatorType = new ExpandedNodeId(TutorialModel.ObjectTypes.GenericActuatorType, TutorialModel.Namespaces.Tutorial);

        /// <summary>
        /// The identifier for the PipeType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId PipeType = new ExpandedNodeId(TutorialModel.ObjectTypes.PipeType, TutorialModel.Namespaces.Tutorial);
    }
    #endregion

    #region ReferenceType Node Identifiers
    /// <summary>
    /// A class that declares constants for all ReferenceTypes in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class ReferenceTypeIds
    {
        /// <summary>
        /// The identifier for the SignalTo ReferenceType.
        /// </summary>
        public static readonly ExpandedNodeId SignalTo = new ExpandedNodeId(TutorialModel.ReferenceTypes.SignalTo, TutorialModel.Namespaces.Tutorial);
    }
    #endregion

    #region Variable Node Identifiers
    /// <summary>
    /// A class that declares constants for all Variables in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class VariableIds
    {
        /// <summary>
        /// The identifier for the GenericSensorType_Output Variable.
        /// </summary>
        public static readonly ExpandedNodeId GenericSensorType_Output = new ExpandedNodeId(TutorialModel.Variables.GenericSensorType_Output, TutorialModel.Namespaces.Tutorial);

        /// <summary>
        /// The identifier for the GenericSensorType_Output_Definition Variable.
        /// </summary>
        public static readonly ExpandedNodeId GenericSensorType_Output_Definition = new ExpandedNodeId(TutorialModel.Variables.GenericSensorType_Output_Definition, TutorialModel.Namespaces.Tutorial);

        /// <summary>
        /// The identifier for the GenericSensorType_Output_ValuePrecision Variable.
        /// </summary>
        public static readonly ExpandedNodeId GenericSensorType_Output_ValuePrecision = new ExpandedNodeId(TutorialModel.Variables.GenericSensorType_Output_ValuePrecision, TutorialModel.Namespaces.Tutorial);

        /// <summary>
        /// The identifier for the GenericSensorType_Output_EURange Variable.
        /// </summary>
        public static readonly ExpandedNodeId GenericSensorType_Output_EURange = new ExpandedNodeId(TutorialModel.Variables.GenericSensorType_Output_EURange, TutorialModel.Namespaces.Tutorial);

        /// <summary>
        /// The identifier for the GenericSensorType_Output_InstrumentRange Variable.
        /// </summary>
        public static readonly ExpandedNodeId GenericSensorType_Output_InstrumentRange = new ExpandedNodeId(TutorialModel.Variables.GenericSensorType_Output_InstrumentRange, TutorialModel.Namespaces.Tutorial);

        /// <summary>
        /// The identifier for the GenericSensorType_Output_EngineeringUnits Variable.
        /// </summary>
        public static readonly ExpandedNodeId GenericSensorType_Output_EngineeringUnits = new ExpandedNodeId(TutorialModel.Variables.GenericSensorType_Output_EngineeringUnits, TutorialModel.Namespaces.Tutorial);

        /// <summary>
        /// The identifier for the GenericActuatorType_Input Variable.
        /// </summary>
        public static readonly ExpandedNodeId GenericActuatorType_Input = new ExpandedNodeId(TutorialModel.Variables.GenericActuatorType_Input, TutorialModel.Namespaces.Tutorial);

        /// <summary>
        /// The identifier for the GenericActuatorType_Input_Definition Variable.
        /// </summary>
        public static readonly ExpandedNodeId GenericActuatorType_Input_Definition = new ExpandedNodeId(TutorialModel.Variables.GenericActuatorType_Input_Definition, TutorialModel.Namespaces.Tutorial);

        /// <summary>
        /// The identifier for the GenericActuatorType_Input_ValuePrecision Variable.
        /// </summary>
        public static readonly ExpandedNodeId GenericActuatorType_Input_ValuePrecision = new ExpandedNodeId(TutorialModel.Variables.GenericActuatorType_Input_ValuePrecision, TutorialModel.Namespaces.Tutorial);

        /// <summary>
        /// The identifier for the GenericActuatorType_Input_EURange Variable.
        /// </summary>
        public static readonly ExpandedNodeId GenericActuatorType_Input_EURange = new ExpandedNodeId(TutorialModel.Variables.GenericActuatorType_Input_EURange, TutorialModel.Namespaces.Tutorial);

        /// <summary>
        /// The identifier for the GenericActuatorType_Input_InstrumentRange Variable.
        /// </summary>
        public static readonly ExpandedNodeId GenericActuatorType_Input_InstrumentRange = new ExpandedNodeId(TutorialModel.Variables.GenericActuatorType_Input_InstrumentRange, TutorialModel.Namespaces.Tutorial);

        /// <summary>
        /// The identifier for the GenericActuatorType_Input_EngineeringUnits Variable.
        /// </summary>
        public static readonly ExpandedNodeId GenericActuatorType_Input_EngineeringUnits = new ExpandedNodeId(TutorialModel.Variables.GenericActuatorType_Input_EngineeringUnits, TutorialModel.Namespaces.Tutorial);

        /// <summary>
        /// The identifier for the PipeType_FlowTransmitter_Output Variable.
        /// </summary>
        public static readonly ExpandedNodeId PipeType_FlowTransmitter_Output = new ExpandedNodeId(TutorialModel.Variables.PipeType_FlowTransmitter_Output, TutorialModel.Namespaces.Tutorial);

        /// <summary>
        /// The identifier for the PipeType_FlowTransmitter_Output_Definition Variable.
        /// </summary>
        public static readonly ExpandedNodeId PipeType_FlowTransmitter_Output_Definition = new ExpandedNodeId(TutorialModel.Variables.PipeType_FlowTransmitter_Output_Definition, TutorialModel.Namespaces.Tutorial);

        /// <summary>
        /// The identifier for the PipeType_FlowTransmitter_Output_ValuePrecision Variable.
        /// </summary>
        public static readonly ExpandedNodeId PipeType_FlowTransmitter_Output_ValuePrecision = new ExpandedNodeId(TutorialModel.Variables.PipeType_FlowTransmitter_Output_ValuePrecision, TutorialModel.Namespaces.Tutorial);

        /// <summary>
        /// The identifier for the PipeType_FlowTransmitter_Output_EURange Variable.
        /// </summary>
        public static readonly ExpandedNodeId PipeType_FlowTransmitter_Output_EURange = new ExpandedNodeId(TutorialModel.Variables.PipeType_FlowTransmitter_Output_EURange, TutorialModel.Namespaces.Tutorial);

        /// <summary>
        /// The identifier for the PipeType_FlowTransmitter_Output_InstrumentRange Variable.
        /// </summary>
        public static readonly ExpandedNodeId PipeType_FlowTransmitter_Output_InstrumentRange = new ExpandedNodeId(TutorialModel.Variables.PipeType_FlowTransmitter_Output_InstrumentRange, TutorialModel.Namespaces.Tutorial);

        /// <summary>
        /// The identifier for the PipeType_FlowTransmitter_Output_EngineeringUnits Variable.
        /// </summary>
        public static readonly ExpandedNodeId PipeType_FlowTransmitter_Output_EngineeringUnits = new ExpandedNodeId(TutorialModel.Variables.PipeType_FlowTransmitter_Output_EngineeringUnits, TutorialModel.Namespaces.Tutorial);

        /// <summary>
        /// The identifier for the PipeType_Valve_Input Variable.
        /// </summary>
        public static readonly ExpandedNodeId PipeType_Valve_Input = new ExpandedNodeId(TutorialModel.Variables.PipeType_Valve_Input, TutorialModel.Namespaces.Tutorial);

        /// <summary>
        /// The identifier for the PipeType_Valve_Input_Definition Variable.
        /// </summary>
        public static readonly ExpandedNodeId PipeType_Valve_Input_Definition = new ExpandedNodeId(TutorialModel.Variables.PipeType_Valve_Input_Definition, TutorialModel.Namespaces.Tutorial);

        /// <summary>
        /// The identifier for the PipeType_Valve_Input_ValuePrecision Variable.
        /// </summary>
        public static readonly ExpandedNodeId PipeType_Valve_Input_ValuePrecision = new ExpandedNodeId(TutorialModel.Variables.PipeType_Valve_Input_ValuePrecision, TutorialModel.Namespaces.Tutorial);

        /// <summary>
        /// The identifier for the PipeType_Valve_Input_EURange Variable.
        /// </summary>
        public static readonly ExpandedNodeId PipeType_Valve_Input_EURange = new ExpandedNodeId(TutorialModel.Variables.PipeType_Valve_Input_EURange, TutorialModel.Namespaces.Tutorial);

        /// <summary>
        /// The identifier for the PipeType_Valve_Input_InstrumentRange Variable.
        /// </summary>
        public static readonly ExpandedNodeId PipeType_Valve_Input_InstrumentRange = new ExpandedNodeId(TutorialModel.Variables.PipeType_Valve_Input_InstrumentRange, TutorialModel.Namespaces.Tutorial);

        /// <summary>
        /// The identifier for the PipeType_Valve_Input_EngineeringUnits Variable.
        /// </summary>
        public static readonly ExpandedNodeId PipeType_Valve_Input_EngineeringUnits = new ExpandedNodeId(TutorialModel.Variables.PipeType_Valve_Input_EngineeringUnits, TutorialModel.Namespaces.Tutorial);

        /// <summary>
        /// The identifier for the PipeType_Calibration Variable.
        /// </summary>
        public static readonly ExpandedNodeId PipeType_Calibration = new ExpandedNodeId(TutorialModel.Variables.PipeType_Calibration, TutorialModel.Namespaces.Tutorial);

        /// <summary>
        /// The identifier for the Pipe1_FlowTransmitter_Output Variable.
        /// </summary>
        public static readonly ExpandedNodeId Pipe1_FlowTransmitter_Output = new ExpandedNodeId(TutorialModel.Variables.Pipe1_FlowTransmitter_Output, TutorialModel.Namespaces.Tutorial);

        /// <summary>
        /// The identifier for the Pipe1_FlowTransmitter_Output_Definition Variable.
        /// </summary>
        public static readonly ExpandedNodeId Pipe1_FlowTransmitter_Output_Definition = new ExpandedNodeId(TutorialModel.Variables.Pipe1_FlowTransmitter_Output_Definition, TutorialModel.Namespaces.Tutorial);

        /// <summary>
        /// The identifier for the Pipe1_FlowTransmitter_Output_ValuePrecision Variable.
        /// </summary>
        public static readonly ExpandedNodeId Pipe1_FlowTransmitter_Output_ValuePrecision = new ExpandedNodeId(TutorialModel.Variables.Pipe1_FlowTransmitter_Output_ValuePrecision, TutorialModel.Namespaces.Tutorial);

        /// <summary>
        /// The identifier for the Pipe1_FlowTransmitter_Output_EURange Variable.
        /// </summary>
        public static readonly ExpandedNodeId Pipe1_FlowTransmitter_Output_EURange = new ExpandedNodeId(TutorialModel.Variables.Pipe1_FlowTransmitter_Output_EURange, TutorialModel.Namespaces.Tutorial);

        /// <summary>
        /// The identifier for the Pipe1_FlowTransmitter_Output_InstrumentRange Variable.
        /// </summary>
        public static readonly ExpandedNodeId Pipe1_FlowTransmitter_Output_InstrumentRange = new ExpandedNodeId(TutorialModel.Variables.Pipe1_FlowTransmitter_Output_InstrumentRange, TutorialModel.Namespaces.Tutorial);

        /// <summary>
        /// The identifier for the Pipe1_FlowTransmitter_Output_EngineeringUnits Variable.
        /// </summary>
        public static readonly ExpandedNodeId Pipe1_FlowTransmitter_Output_EngineeringUnits = new ExpandedNodeId(TutorialModel.Variables.Pipe1_FlowTransmitter_Output_EngineeringUnits, TutorialModel.Namespaces.Tutorial);

        /// <summary>
        /// The identifier for the Pipe1_Valve_Input Variable.
        /// </summary>
        public static readonly ExpandedNodeId Pipe1_Valve_Input = new ExpandedNodeId(TutorialModel.Variables.Pipe1_Valve_Input, TutorialModel.Namespaces.Tutorial);

        /// <summary>
        /// The identifier for the Pipe1_Valve_Input_Definition Variable.
        /// </summary>
        public static readonly ExpandedNodeId Pipe1_Valve_Input_Definition = new ExpandedNodeId(TutorialModel.Variables.Pipe1_Valve_Input_Definition, TutorialModel.Namespaces.Tutorial);

        /// <summary>
        /// The identifier for the Pipe1_Valve_Input_ValuePrecision Variable.
        /// </summary>
        public static readonly ExpandedNodeId Pipe1_Valve_Input_ValuePrecision = new ExpandedNodeId(TutorialModel.Variables.Pipe1_Valve_Input_ValuePrecision, TutorialModel.Namespaces.Tutorial);

        /// <summary>
        /// The identifier for the Pipe1_Valve_Input_EURange Variable.
        /// </summary>
        public static readonly ExpandedNodeId Pipe1_Valve_Input_EURange = new ExpandedNodeId(TutorialModel.Variables.Pipe1_Valve_Input_EURange, TutorialModel.Namespaces.Tutorial);

        /// <summary>
        /// The identifier for the Pipe1_Valve_Input_InstrumentRange Variable.
        /// </summary>
        public static readonly ExpandedNodeId Pipe1_Valve_Input_InstrumentRange = new ExpandedNodeId(TutorialModel.Variables.Pipe1_Valve_Input_InstrumentRange, TutorialModel.Namespaces.Tutorial);

        /// <summary>
        /// The identifier for the Pipe1_Valve_Input_EngineeringUnits Variable.
        /// </summary>
        public static readonly ExpandedNodeId Pipe1_Valve_Input_EngineeringUnits = new ExpandedNodeId(TutorialModel.Variables.Pipe1_Valve_Input_EngineeringUnits, TutorialModel.Namespaces.Tutorial);

        /// <summary>
        /// The identifier for the Pipe1_Calibration Variable.
        /// </summary>
        public static readonly ExpandedNodeId Pipe1_Calibration = new ExpandedNodeId(TutorialModel.Variables.Pipe1_Calibration, TutorialModel.Namespaces.Tutorial);

        /// <summary>
        /// The identifier for the Tutorial_XmlSchema Variable.
        /// </summary>
        public static readonly ExpandedNodeId Tutorial_XmlSchema = new ExpandedNodeId(TutorialModel.Variables.Tutorial_XmlSchema, TutorialModel.Namespaces.Tutorial);

        /// <summary>
        /// The identifier for the Tutorial_XmlSchema_DataTypeVersion Variable.
        /// </summary>
        public static readonly ExpandedNodeId Tutorial_XmlSchema_DataTypeVersion = new ExpandedNodeId(TutorialModel.Variables.Tutorial_XmlSchema_DataTypeVersion, TutorialModel.Namespaces.Tutorial);

        /// <summary>
        /// The identifier for the Tutorial_XmlSchema_NamespaceUri Variable.
        /// </summary>
        public static readonly ExpandedNodeId Tutorial_XmlSchema_NamespaceUri = new ExpandedNodeId(TutorialModel.Variables.Tutorial_XmlSchema_NamespaceUri, TutorialModel.Namespaces.Tutorial);

        /// <summary>
        /// The identifier for the Tutorial_XmlSchema_CalibrationDataType Variable.
        /// </summary>
        public static readonly ExpandedNodeId Tutorial_XmlSchema_CalibrationDataType = new ExpandedNodeId(TutorialModel.Variables.Tutorial_XmlSchema_CalibrationDataType, TutorialModel.Namespaces.Tutorial);

        /// <summary>
        /// The identifier for the Tutorial_XmlSchema_CalibrationDataType_DataTypeVersion Variable.
        /// </summary>
        public static readonly ExpandedNodeId Tutorial_XmlSchema_CalibrationDataType_DataTypeVersion = new ExpandedNodeId(TutorialModel.Variables.Tutorial_XmlSchema_CalibrationDataType_DataTypeVersion, TutorialModel.Namespaces.Tutorial);

        /// <summary>
        /// The identifier for the Tutorial_XmlSchema_CalibrationDataType_DictionaryFragment Variable.
        /// </summary>
        public static readonly ExpandedNodeId Tutorial_XmlSchema_CalibrationDataType_DictionaryFragment = new ExpandedNodeId(TutorialModel.Variables.Tutorial_XmlSchema_CalibrationDataType_DictionaryFragment, TutorialModel.Namespaces.Tutorial);

        /// <summary>
        /// The identifier for the Tutorial_BinarySchema Variable.
        /// </summary>
        public static readonly ExpandedNodeId Tutorial_BinarySchema = new ExpandedNodeId(TutorialModel.Variables.Tutorial_BinarySchema, TutorialModel.Namespaces.Tutorial);

        /// <summary>
        /// The identifier for the Tutorial_BinarySchema_DataTypeVersion Variable.
        /// </summary>
        public static readonly ExpandedNodeId Tutorial_BinarySchema_DataTypeVersion = new ExpandedNodeId(TutorialModel.Variables.Tutorial_BinarySchema_DataTypeVersion, TutorialModel.Namespaces.Tutorial);

        /// <summary>
        /// The identifier for the Tutorial_BinarySchema_NamespaceUri Variable.
        /// </summary>
        public static readonly ExpandedNodeId Tutorial_BinarySchema_NamespaceUri = new ExpandedNodeId(TutorialModel.Variables.Tutorial_BinarySchema_NamespaceUri, TutorialModel.Namespaces.Tutorial);

        /// <summary>
        /// The identifier for the Tutorial_BinarySchema_CalibrationDataType Variable.
        /// </summary>
        public static readonly ExpandedNodeId Tutorial_BinarySchema_CalibrationDataType = new ExpandedNodeId(TutorialModel.Variables.Tutorial_BinarySchema_CalibrationDataType, TutorialModel.Namespaces.Tutorial);

        /// <summary>
        /// The identifier for the Tutorial_BinarySchema_CalibrationDataType_DataTypeVersion Variable.
        /// </summary>
        public static readonly ExpandedNodeId Tutorial_BinarySchema_CalibrationDataType_DataTypeVersion = new ExpandedNodeId(TutorialModel.Variables.Tutorial_BinarySchema_CalibrationDataType_DataTypeVersion, TutorialModel.Namespaces.Tutorial);

        /// <summary>
        /// The identifier for the Tutorial_BinarySchema_CalibrationDataType_DictionaryFragment Variable.
        /// </summary>
        public static readonly ExpandedNodeId Tutorial_BinarySchema_CalibrationDataType_DictionaryFragment = new ExpandedNodeId(TutorialModel.Variables.Tutorial_BinarySchema_CalibrationDataType_DictionaryFragment, TutorialModel.Namespaces.Tutorial);
    }
    #endregion

    #region BrowseName Declarations
    /// <summary>
    /// Declares all of the BrowseNames used in the Model Design.
    /// </summary>
    public static partial class BrowseNames
    {
        /// <summary>
        /// The BrowseName for the Calibration component.
        /// </summary>
        public const string Calibration = "Calibration";

        /// <summary>
        /// The BrowseName for the CalibrationDataType component.
        /// </summary>
        public const string CalibrationDataType = "CalibrationDataType";

        /// <summary>
        /// The BrowseName for the FlowTransmitter component.
        /// </summary>
        public const string FlowTransmitter = "FlowTransmitter";

        /// <summary>
        /// The BrowseName for the GenericActuatorType component.
        /// </summary>
        public const string GenericActuatorType = "GenericActuatorType";

        /// <summary>
        /// The BrowseName for the GenericSensorType component.
        /// </summary>
        public const string GenericSensorType = "GenericSensorType";

        /// <summary>
        /// The BrowseName for the Input component.
        /// </summary>
        public const string Input = "Input";

        /// <summary>
        /// The BrowseName for the Output component.
        /// </summary>
        public const string Output = "Output";

        /// <summary>
        /// The BrowseName for the Pipe1 component.
        /// </summary>
        public const string Pipe1 = "Pipe #1";

        /// <summary>
        /// The BrowseName for the PipeType component.
        /// </summary>
        public const string PipeType = "PipeType";

        /// <summary>
        /// The BrowseName for the SignalTo component.
        /// </summary>
        public const string SignalTo = "SignalTo";

        /// <summary>
        /// The BrowseName for the Tutorial_BinarySchema component.
        /// </summary>
        public const string Tutorial_BinarySchema = "TutorialModel";

        /// <summary>
        /// The BrowseName for the Tutorial_XmlSchema component.
        /// </summary>
        public const string Tutorial_XmlSchema = "TutorialModel";

        /// <summary>
        /// The BrowseName for the Valve component.
        /// </summary>
        public const string Valve = "Valve";
    }
    #endregion

    #region Namespace Declarations
    /// <summary>
    /// Defines constants for all namespaces referenced by the model design.
    /// </summary>
    public static partial class Namespaces
    {
        /// <summary>
        /// The URI for the OpcUa namespace (.NET code namespace is 'Opc.Ua').
        /// </summary>
        public const string OpcUa = "http://opcfoundation.org/UA/";

        /// <summary>
        /// The URI for the OpcUaXsd namespace (.NET code namespace is 'Opc.Ua').
        /// </summary>
        public const string OpcUaXsd = "http://opcfoundation.org/UA/2008/02/Types.xsd";

        /// <summary>
        /// The URI for the Tutorial namespace (.NET code namespace is 'TutorialModel').
        /// </summary>
        public const string Tutorial = "http://somecompany.com/TutorialModel";

        /// <summary>
        /// Returns a namespace table with all of the URIs defined.
        /// </summary>
        /// <remarks>
        /// This table is was used to create any relative paths in the model design.
        /// </remarks>
        public static NamespaceTable GetNamespaceTable()
        {
            FieldInfo[] fields = typeof(Namespaces).GetFields(BindingFlags.Public | BindingFlags.Static);

            NamespaceTable namespaceTable = new NamespaceTable();

            foreach (FieldInfo field in fields)
            {
                string namespaceUri = (string)field.GetValue(typeof(Namespaces));

                if (namespaceTable.GetIndex(namespaceUri) == -1)
                {
                    namespaceTable.Append(namespaceUri);
                }
            }

            return namespaceTable;
        }
    }
    #endregion
}
