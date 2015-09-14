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

namespace Opc.Ua.Sample
{
#if INCLUDE_Sample
    #region DataType Identifiers
    /// <summary>
    /// A class that declares constants for all DataTypes in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class DataTypes
    {
        /// <summary>
        /// The identifier for the AddressDataType DataType.
        /// </summary>
        public const uint AddressDataType = 358;

        /// <summary>
        /// The identifier for the ArrayValueDataType DataType.
        /// </summary>
        public const uint ArrayValueDataType = 430;

        /// <summary>
        /// The identifier for the ScalarValueDataType DataType.
        /// </summary>
        public const uint ScalarValueDataType = 401;
    }
    #endregion

    #region Method Identifiers
    /// <summary>
    /// A class that declares constants for all Methods in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Methods
    {
        /// <summary>
        /// The identifier for the AcmeFlowTransmitterType_Calibrate Method.
        /// </summary>
        public const uint AcmeFlowTransmitterType_Calibrate = 318;

        /// <summary>
        /// The identifier for the BoilerType_CreateBoiler Method.
        /// </summary>
        public const uint BoilerType_CreateBoiler = 352;

        /// <summary>
        /// The identifier for the TestDataObjectType_GenerateValues Method.
        /// </summary>
        public const uint TestDataObjectType_GenerateValues = 400;
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
        /// The identifier for the AddressDataType_Encoding_DefaultXml Object.
        /// </summary>
        public const uint AddressDataType_Encoding_DefaultXml = 258;

        /// <summary>
        /// The identifier for the AddressDataType_Encoding_DefaultBinary Object.
        /// </summary>
        public const uint AddressDataType_Encoding_DefaultBinary = 259;

        /// <summary>
        /// The identifier for the ArrayValueDataType_Encoding_DefaultXml Object.
        /// </summary>
        public const uint ArrayValueDataType_Encoding_DefaultXml = 471;

        /// <summary>
        /// The identifier for the ArrayValueDataType_Encoding_DefaultBinary Object.
        /// </summary>
        public const uint ArrayValueDataType_Encoding_DefaultBinary = 472;

        /// <summary>
        /// The identifier for the Boiler1 Object.
        /// </summary>
        public const uint Boiler1 = 363;

        /// <summary>
        /// The identifier for the Boiler1_InputPipe Object.
        /// </summary>
        public const uint Boiler1_InputPipe = 364;

        /// <summary>
        /// The identifier for the Boiler1_InputPipe_FlowTransmitter1 Object.
        /// </summary>
        public const uint Boiler1_InputPipe_FlowTransmitter1 = 365;

        /// <summary>
        /// The identifier for the BoilerDrumType_LevelIndicator Object.
        /// </summary>
        public const uint BoilerDrumType_LevelIndicator = 323;

        /// <summary>
        /// The identifier for the BoilerInputPipeType_FlowTransmitter1 Object.
        /// </summary>
        public const uint BoilerInputPipeType_FlowTransmitter1 = 320;

        /// <summary>
        /// The identifier for the BoilerInputPipeType_Valve Object.
        /// </summary>
        public const uint BoilerInputPipeType_Valve = 321;

        /// <summary>
        /// The identifier for the BoilerOutputPipeType_FlowTransmitter2 Object.
        /// </summary>
        public const uint BoilerOutputPipeType_FlowTransmitter2 = 325;

        /// <summary>
        /// The identifier for the BoilerType_InputPipe Object.
        /// </summary>
        public const uint BoilerType_InputPipe = 327;

        /// <summary>
        /// The identifier for the BoilerType_Drum Object.
        /// </summary>
        public const uint BoilerType_Drum = 332;

        /// <summary>
        /// The identifier for the BoilerType_OutputPipe Object.
        /// </summary>
        public const uint BoilerType_OutputPipe = 335;

        /// <summary>
        /// The identifier for the BoilerType_FlowController Object.
        /// </summary>
        public const uint BoilerType_FlowController = 338;

        /// <summary>
        /// The identifier for the BoilerType_LevelController Object.
        /// </summary>
        public const uint BoilerType_LevelController = 342;

        /// <summary>
        /// The identifier for the BoilerType_CustomController Object.
        /// </summary>
        public const uint BoilerType_CustomController = 346;

        /// <summary>
        /// The identifier for the BoilerType_Drum_LevelIndicator Object.
        /// </summary>
        public const uint BoilerType_Drum_LevelIndicator = 333;

        /// <summary>
        /// The identifier for the BoilerType_InputPipe_FlowTransmitter1 Object.
        /// </summary>
        public const uint BoilerType_InputPipe_FlowTransmitter1 = 328;

        /// <summary>
        /// The identifier for the BoilerType_InputPipe_Valve Object.
        /// </summary>
        public const uint BoilerType_InputPipe_Valve = 330;

        /// <summary>
        /// The identifier for the BoilerType_OutputPipe_FlowTransmitter2 Object.
        /// </summary>
        public const uint BoilerType_OutputPipe_FlowTransmitter2 = 336;

        /// <summary>
        /// The identifier for the Data Object.
        /// </summary>
        public const uint Data = 459;

        /// <summary>
        /// The identifier for the Data_Static Object.
        /// </summary>
        public const uint Data_Static = 460;

        /// <summary>
        /// The identifier for the Data_Static_Scalar Object.
        /// </summary>
        public const uint Data_Static_Scalar = 461;

        /// <summary>
        /// The identifier for the Data_Static_Array Object.
        /// </summary>
        public const uint Data_Static_Array = 462;

        /// <summary>
        /// The identifier for the Samples Object.
        /// </summary>
        public const uint Samples = 394;

        /// <summary>
        /// The identifier for the ScalarValueDataType_Encoding_DefaultXml Object.
        /// </summary>
        public const uint ScalarValueDataType_Encoding_DefaultXml = 469;

        /// <summary>
        /// The identifier for the ScalarValueDataType_Encoding_DefaultBinary Object.
        /// </summary>
        public const uint ScalarValueDataType_Encoding_DefaultBinary = 470;

        /// <summary>
        /// The identifier for the VendorType_Locations Object.
        /// </summary>
        public const uint VendorType_Locations = 362;
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
        /// The identifier for the AcmeFlowTransmitterType ObjectType.
        /// </summary>
        public const uint AcmeFlowTransmitterType = 314;

        /// <summary>
        /// The identifier for the ArrayValueObjectType ObjectType.
        /// </summary>
        public const uint ArrayValueObjectType = 431;

        /// <summary>
        /// The identifier for the BoilerDrumType ObjectType.
        /// </summary>
        public const uint BoilerDrumType = 322;

        /// <summary>
        /// The identifier for the BoilerInputPipeType ObjectType.
        /// </summary>
        public const uint BoilerInputPipeType = 319;

        /// <summary>
        /// The identifier for the BoilerOutputPipeType ObjectType.
        /// </summary>
        public const uint BoilerOutputPipeType = 324;

        /// <summary>
        /// The identifier for the BoilerType ObjectType.
        /// </summary>
        public const uint BoilerType = 326;

        /// <summary>
        /// The identifier for the CustomControllerType ObjectType.
        /// </summary>
        public const uint CustomControllerType = 304;

        /// <summary>
        /// The identifier for the FlowControllerType ObjectType.
        /// </summary>
        public const uint FlowControllerType = 311;

        /// <summary>
        /// The identifier for the FlowTransmitterType ObjectType.
        /// </summary>
        public const uint FlowTransmitterType = 313;

        /// <summary>
        /// The identifier for the GenerateValuesEventType ObjectType.
        /// </summary>
        public const uint GenerateValuesEventType = 395;

        /// <summary>
        /// The identifier for the GenericActuatorType ObjectType.
        /// </summary>
        public const uint GenericActuatorType = 302;

        /// <summary>
        /// The identifier for the GenericControllerType ObjectType.
        /// </summary>
        public const uint GenericControllerType = 290;

        /// <summary>
        /// The identifier for the GenericSensorType ObjectType.
        /// </summary>
        public const uint GenericSensorType = 294;

        /// <summary>
        /// The identifier for the LevelControllerType ObjectType.
        /// </summary>
        public const uint LevelControllerType = 310;

        /// <summary>
        /// The identifier for the LevelIndicatorType ObjectType.
        /// </summary>
        public const uint LevelIndicatorType = 312;

        /// <summary>
        /// The identifier for the Maintenance2EventType ObjectType.
        /// </summary>
        public const uint Maintenance2EventType = 356;

        /// <summary>
        /// The identifier for the MaintenanceEventType ObjectType.
        /// </summary>
        public const uint MaintenanceEventType = 353;

        /// <summary>
        /// The identifier for the ScalarValueObjectType ObjectType.
        /// </summary>
        public const uint ScalarValueObjectType = 402;

        /// <summary>
        /// The identifier for the TestDataObjectType ObjectType.
        /// </summary>
        public const uint TestDataObjectType = 398;

        /// <summary>
        /// The identifier for the ValveType ObjectType.
        /// </summary>
        public const uint ValveType = 309;

        /// <summary>
        /// The identifier for the VendorType ObjectType.
        /// </summary>
        public const uint VendorType = 360;
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
        /// The identifier for the FlowTo ReferenceType.
        /// </summary>
        public const uint FlowTo = 286;

        /// <summary>
        /// The identifier for the HasVendor ReferenceType.
        /// </summary>
        public const uint HasVendor = 289;

        /// <summary>
        /// The identifier for the HotFlowTo ReferenceType.
        /// </summary>
        public const uint HotFlowTo = 287;

        /// <summary>
        /// The identifier for the SignalTo ReferenceType.
        /// </summary>
        public const uint SignalTo = 288;
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
        /// The identifier for the AcmeFlowTransmitterType_SerialNumber Variable.
        /// </summary>
        public const uint AcmeFlowTransmitterType_SerialNumber = 315;

        /// <summary>
        /// The identifier for the AcmeFlowTransmitterType_Documentation Variable.
        /// </summary>
        public const uint AcmeFlowTransmitterType_Documentation = 316;

        /// <summary>
        /// The identifier for the AcmeFlowTransmitterType_CalibrationParameters Variable.
        /// </summary>
        public const uint AcmeFlowTransmitterType_CalibrationParameters = 317;

        /// <summary>
        /// The identifier for the AcmeFlowTransmitterType_Calibrate_InputArguments Variable.
        /// </summary>
        public const uint AcmeFlowTransmitterType_Calibrate_InputArguments = 378;

        /// <summary>
        /// The identifier for the AcmeFlowTransmitterType_Calibrate_OutputArguments Variable.
        /// </summary>
        public const uint AcmeFlowTransmitterType_Calibrate_OutputArguments = 379;

        /// <summary>
        /// The identifier for the ArrayValueObjectType_BooleanValue Variable.
        /// </summary>
        public const uint ArrayValueObjectType_BooleanValue = 432;

        /// <summary>
        /// The identifier for the ArrayValueObjectType_SByteValue Variable.
        /// </summary>
        public const uint ArrayValueObjectType_SByteValue = 433;

        /// <summary>
        /// The identifier for the ArrayValueObjectType_ByteValue Variable.
        /// </summary>
        public const uint ArrayValueObjectType_ByteValue = 434;

        /// <summary>
        /// The identifier for the ArrayValueObjectType_Int16Value Variable.
        /// </summary>
        public const uint ArrayValueObjectType_Int16Value = 435;

        /// <summary>
        /// The identifier for the ArrayValueObjectType_UInt16Value Variable.
        /// </summary>
        public const uint ArrayValueObjectType_UInt16Value = 436;

        /// <summary>
        /// The identifier for the ArrayValueObjectType_Int32Value Variable.
        /// </summary>
        public const uint ArrayValueObjectType_Int32Value = 437;

        /// <summary>
        /// The identifier for the ArrayValueObjectType_UInt32Value Variable.
        /// </summary>
        public const uint ArrayValueObjectType_UInt32Value = 438;

        /// <summary>
        /// The identifier for the ArrayValueObjectType_Int64Value Variable.
        /// </summary>
        public const uint ArrayValueObjectType_Int64Value = 439;

        /// <summary>
        /// The identifier for the ArrayValueObjectType_UInt64Value Variable.
        /// </summary>
        public const uint ArrayValueObjectType_UInt64Value = 440;

        /// <summary>
        /// The identifier for the ArrayValueObjectType_FloatValue Variable.
        /// </summary>
        public const uint ArrayValueObjectType_FloatValue = 441;

        /// <summary>
        /// The identifier for the ArrayValueObjectType_DoubleValue Variable.
        /// </summary>
        public const uint ArrayValueObjectType_DoubleValue = 442;

        /// <summary>
        /// The identifier for the ArrayValueObjectType_StringValue Variable.
        /// </summary>
        public const uint ArrayValueObjectType_StringValue = 443;

        /// <summary>
        /// The identifier for the ArrayValueObjectType_DateTimeValue Variable.
        /// </summary>
        public const uint ArrayValueObjectType_DateTimeValue = 444;

        /// <summary>
        /// The identifier for the ArrayValueObjectType_GuidValue Variable.
        /// </summary>
        public const uint ArrayValueObjectType_GuidValue = 445;

        /// <summary>
        /// The identifier for the ArrayValueObjectType_ByteStringValue Variable.
        /// </summary>
        public const uint ArrayValueObjectType_ByteStringValue = 446;

        /// <summary>
        /// The identifier for the ArrayValueObjectType_XmlElementValue Variable.
        /// </summary>
        public const uint ArrayValueObjectType_XmlElementValue = 447;

        /// <summary>
        /// The identifier for the ArrayValueObjectType_NodeIdValue Variable.
        /// </summary>
        public const uint ArrayValueObjectType_NodeIdValue = 448;

        /// <summary>
        /// The identifier for the ArrayValueObjectType_ExpandedNodeIdValue Variable.
        /// </summary>
        public const uint ArrayValueObjectType_ExpandedNodeIdValue = 449;

        /// <summary>
        /// The identifier for the ArrayValueObjectType_QualifiedNameValue Variable.
        /// </summary>
        public const uint ArrayValueObjectType_QualifiedNameValue = 450;

        /// <summary>
        /// The identifier for the ArrayValueObjectType_LocalizedTextValue Variable.
        /// </summary>
        public const uint ArrayValueObjectType_LocalizedTextValue = 451;

        /// <summary>
        /// The identifier for the ArrayValueObjectType_StatusCodeValue Variable.
        /// </summary>
        public const uint ArrayValueObjectType_StatusCodeValue = 452;

        /// <summary>
        /// The identifier for the ArrayValueObjectType_VariantValue Variable.
        /// </summary>
        public const uint ArrayValueObjectType_VariantValue = 453;

        /// <summary>
        /// The identifier for the ArrayValueObjectType_StructureValue Variable.
        /// </summary>
        public const uint ArrayValueObjectType_StructureValue = 455;

        /// <summary>
        /// The identifier for the BoilerType_CreateBoiler_InputArguments Variable.
        /// </summary>
        public const uint BoilerType_CreateBoiler_InputArguments = 256;

        /// <summary>
        /// The identifier for the BoilerType_CreateBoiler_OutputArguments Variable.
        /// </summary>
        public const uint BoilerType_CreateBoiler_OutputArguments = 257;

        /// <summary>
        /// The identifier for the BoilerType_CustomController_Input1 Variable.
        /// </summary>
        public const uint BoilerType_CustomController_Input1 = 347;

        /// <summary>
        /// The identifier for the BoilerType_CustomController_Input2 Variable.
        /// </summary>
        public const uint BoilerType_CustomController_Input2 = 348;

        /// <summary>
        /// The identifier for the BoilerType_CustomController_Input3 Variable.
        /// </summary>
        public const uint BoilerType_CustomController_Input3 = 349;

        /// <summary>
        /// The identifier for the BoilerType_CustomController_ControlOut Variable.
        /// </summary>
        public const uint BoilerType_CustomController_ControlOut = 350;

        /// <summary>
        /// The identifier for the BoilerType_Drum_LevelIndicator_Output Variable.
        /// </summary>
        public const uint BoilerType_Drum_LevelIndicator_Output = 334;

        /// <summary>
        /// The identifier for the BoilerType_FlowController_Measurement Variable.
        /// </summary>
        public const uint BoilerType_FlowController_Measurement = 339;

        /// <summary>
        /// The identifier for the BoilerType_FlowController_SetPoint Variable.
        /// </summary>
        public const uint BoilerType_FlowController_SetPoint = 340;

        /// <summary>
        /// The identifier for the BoilerType_FlowController_ControlOut Variable.
        /// </summary>
        public const uint BoilerType_FlowController_ControlOut = 341;

        /// <summary>
        /// The identifier for the BoilerType_InputPipe_FlowTransmitter1_Output Variable.
        /// </summary>
        public const uint BoilerType_InputPipe_FlowTransmitter1_Output = 329;

        /// <summary>
        /// The identifier for the BoilerType_InputPipe_Valve_Input Variable.
        /// </summary>
        public const uint BoilerType_InputPipe_Valve_Input = 331;

        /// <summary>
        /// The identifier for the BoilerType_LevelController_Measurement Variable.
        /// </summary>
        public const uint BoilerType_LevelController_Measurement = 343;

        /// <summary>
        /// The identifier for the BoilerType_LevelController_SetPoint Variable.
        /// </summary>
        public const uint BoilerType_LevelController_SetPoint = 344;

        /// <summary>
        /// The identifier for the BoilerType_LevelController_ControlOut Variable.
        /// </summary>
        public const uint BoilerType_LevelController_ControlOut = 345;

        /// <summary>
        /// The identifier for the BoilerType_OutputPipe_FlowTransmitter2_Output Variable.
        /// </summary>
        public const uint BoilerType_OutputPipe_FlowTransmitter2_Output = 337;

        /// <summary>
        /// The identifier for the CustomControllerType_Input1 Variable.
        /// </summary>
        public const uint CustomControllerType_Input1 = 305;

        /// <summary>
        /// The identifier for the CustomControllerType_Input2 Variable.
        /// </summary>
        public const uint CustomControllerType_Input2 = 306;

        /// <summary>
        /// The identifier for the CustomControllerType_Input3 Variable.
        /// </summary>
        public const uint CustomControllerType_Input3 = 307;

        /// <summary>
        /// The identifier for the CustomControllerType_ControlOut Variable.
        /// </summary>
        public const uint CustomControllerType_ControlOut = 308;

        /// <summary>
        /// The identifier for the Dictionary_BinarySchema Variable.
        /// </summary>
        public const uint Dictionary_BinarySchema = 381;

        /// <summary>
        /// The identifier for the Dictionary_BinarySchema_AddressDataType Variable.
        /// </summary>
        public const uint Dictionary_BinarySchema_AddressDataType = 393;

        /// <summary>
        /// The identifier for the Dictionary_BinarySchema_ScalarValueDataType Variable.
        /// </summary>
        public const uint Dictionary_BinarySchema_ScalarValueDataType = 475;

        /// <summary>
        /// The identifier for the Dictionary_BinarySchema_ArrayValueDataType Variable.
        /// </summary>
        public const uint Dictionary_BinarySchema_ArrayValueDataType = 476;

        /// <summary>
        /// The identifier for the Dictionary_XmlSchema Variable.
        /// </summary>
        public const uint Dictionary_XmlSchema = 380;

        /// <summary>
        /// The identifier for the Dictionary_XmlSchema_AddressDataType Variable.
        /// </summary>
        public const uint Dictionary_XmlSchema_AddressDataType = 387;

        /// <summary>
        /// The identifier for the Dictionary_XmlSchema_ScalarValueDataType Variable.
        /// </summary>
        public const uint Dictionary_XmlSchema_ScalarValueDataType = 473;

        /// <summary>
        /// The identifier for the Dictionary_XmlSchema_ArrayValueDataType Variable.
        /// </summary>
        public const uint Dictionary_XmlSchema_ArrayValueDataType = 474;

        /// <summary>
        /// The identifier for the GenerateValuesEventType_Iterations Variable.
        /// </summary>
        public const uint GenerateValuesEventType_Iterations = 396;

        /// <summary>
        /// The identifier for the GenerateValuesEventType_NewValueCount Variable.
        /// </summary>
        public const uint GenerateValuesEventType_NewValueCount = 397;

        /// <summary>
        /// The identifier for the GenericActuatorType_Input Variable.
        /// </summary>
        public const uint GenericActuatorType_Input = 303;

        /// <summary>
        /// The identifier for the GenericControllerType_Measurement Variable.
        /// </summary>
        public const uint GenericControllerType_Measurement = 291;

        /// <summary>
        /// The identifier for the GenericControllerType_SetPoint Variable.
        /// </summary>
        public const uint GenericControllerType_SetPoint = 292;

        /// <summary>
        /// The identifier for the GenericControllerType_ControlOut Variable.
        /// </summary>
        public const uint GenericControllerType_ControlOut = 293;

        /// <summary>
        /// The identifier for the GenericSensorType_Output Variable.
        /// </summary>
        public const uint GenericSensorType_Output = 295;

        /// <summary>
        /// The identifier for the Maintenance2EventType_WorkorderId Variable.
        /// </summary>
        public const uint Maintenance2EventType_WorkorderId = 357;

        /// <summary>
        /// The identifier for the MaintenanceEventType_MustCompleteByDate Variable.
        /// </summary>
        public const uint MaintenanceEventType_MustCompleteByDate = 354;

        /// <summary>
        /// The identifier for the MaintenanceEventType_IsScheduled Variable.
        /// </summary>
        public const uint MaintenanceEventType_IsScheduled = 355;

        /// <summary>
        /// The identifier for the ScalarValueObjectType_BooleanValue Variable.
        /// </summary>
        public const uint ScalarValueObjectType_BooleanValue = 403;

        /// <summary>
        /// The identifier for the ScalarValueObjectType_SByteValue Variable.
        /// </summary>
        public const uint ScalarValueObjectType_SByteValue = 404;

        /// <summary>
        /// The identifier for the ScalarValueObjectType_ByteValue Variable.
        /// </summary>
        public const uint ScalarValueObjectType_ByteValue = 405;

        /// <summary>
        /// The identifier for the ScalarValueObjectType_Int16Value Variable.
        /// </summary>
        public const uint ScalarValueObjectType_Int16Value = 406;

        /// <summary>
        /// The identifier for the ScalarValueObjectType_UInt16Value Variable.
        /// </summary>
        public const uint ScalarValueObjectType_UInt16Value = 407;

        /// <summary>
        /// The identifier for the ScalarValueObjectType_Int32Value Variable.
        /// </summary>
        public const uint ScalarValueObjectType_Int32Value = 408;

        /// <summary>
        /// The identifier for the ScalarValueObjectType_UInt32Value Variable.
        /// </summary>
        public const uint ScalarValueObjectType_UInt32Value = 409;

        /// <summary>
        /// The identifier for the ScalarValueObjectType_Int64Value Variable.
        /// </summary>
        public const uint ScalarValueObjectType_Int64Value = 410;

        /// <summary>
        /// The identifier for the ScalarValueObjectType_UInt64Value Variable.
        /// </summary>
        public const uint ScalarValueObjectType_UInt64Value = 411;

        /// <summary>
        /// The identifier for the ScalarValueObjectType_FloatValue Variable.
        /// </summary>
        public const uint ScalarValueObjectType_FloatValue = 412;

        /// <summary>
        /// The identifier for the ScalarValueObjectType_DoubleValue Variable.
        /// </summary>
        public const uint ScalarValueObjectType_DoubleValue = 413;

        /// <summary>
        /// The identifier for the ScalarValueObjectType_StringValue Variable.
        /// </summary>
        public const uint ScalarValueObjectType_StringValue = 414;

        /// <summary>
        /// The identifier for the ScalarValueObjectType_DateTimeValue Variable.
        /// </summary>
        public const uint ScalarValueObjectType_DateTimeValue = 415;

        /// <summary>
        /// The identifier for the ScalarValueObjectType_GuidValue Variable.
        /// </summary>
        public const uint ScalarValueObjectType_GuidValue = 416;

        /// <summary>
        /// The identifier for the ScalarValueObjectType_ByteStringValue Variable.
        /// </summary>
        public const uint ScalarValueObjectType_ByteStringValue = 417;

        /// <summary>
        /// The identifier for the ScalarValueObjectType_XmlElementValue Variable.
        /// </summary>
        public const uint ScalarValueObjectType_XmlElementValue = 418;

        /// <summary>
        /// The identifier for the ScalarValueObjectType_NodeIdValue Variable.
        /// </summary>
        public const uint ScalarValueObjectType_NodeIdValue = 419;

        /// <summary>
        /// The identifier for the ScalarValueObjectType_ExpandedNodeIdValue Variable.
        /// </summary>
        public const uint ScalarValueObjectType_ExpandedNodeIdValue = 420;

        /// <summary>
        /// The identifier for the ScalarValueObjectType_QualifiedNameValue Variable.
        /// </summary>
        public const uint ScalarValueObjectType_QualifiedNameValue = 421;

        /// <summary>
        /// The identifier for the ScalarValueObjectType_LocalizedTextValue Variable.
        /// </summary>
        public const uint ScalarValueObjectType_LocalizedTextValue = 422;

        /// <summary>
        /// The identifier for the ScalarValueObjectType_StatusCodeValue Variable.
        /// </summary>
        public const uint ScalarValueObjectType_StatusCodeValue = 423;

        /// <summary>
        /// The identifier for the ScalarValueObjectType_VariantValue Variable.
        /// </summary>
        public const uint ScalarValueObjectType_VariantValue = 424;

        /// <summary>
        /// The identifier for the ScalarValueObjectType_StructureValue Variable.
        /// </summary>
        public const uint ScalarValueObjectType_StructureValue = 426;

        /// <summary>
        /// The identifier for the TestDataObjectType_SimulationActive Variable.
        /// </summary>
        public const uint TestDataObjectType_SimulationActive = 399;

        /// <summary>
        /// The identifier for the TestDataObjectType_GenerateValues_InputArguments Variable.
        /// </summary>
        public const uint TestDataObjectType_GenerateValues_InputArguments = 468;

        /// <summary>
        /// The identifier for the VendorType_CompanyName Variable.
        /// </summary>
        public const uint VendorType_CompanyName = 361;
    }
    #endregion

    #region VariableType Identifiers
    /// <summary>
    /// A class that declares constants for all VariableTypes in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class VariableTypes
    {
        /// <summary>
        /// The identifier for the AddressType VariableType.
        /// </summary>
        public const uint AddressType = 359;
    }
    #endregion

    #region BrowseName Declarations
    /// <summary>
    /// Declares all of the BrowseNames used in the Model Design.
    /// </summary>
    public static partial class BrowseNames
    {
        /// <summary>
        /// The BrowseName for the AcmeFlowTransmitterType component.
        /// </summary>
        public const string AcmeFlowTransmitterType = "AcmeFlowTransmitterType";

        /// <summary>
        /// The BrowseName for the AddressDataType component.
        /// </summary>
        public const string AddressDataType = "AddressDataType";

        /// <summary>
        /// The BrowseName for the AddressType component.
        /// </summary>
        public const string AddressType = "AddressType";

        /// <summary>
        /// The BrowseName for the Array component.
        /// </summary>
        public const string Array = "Array";

        /// <summary>
        /// The BrowseName for the ArrayValueDataType component.
        /// </summary>
        public const string ArrayValueDataType = "ArrayValueDataType";

        /// <summary>
        /// The BrowseName for the ArrayValueObjectType component.
        /// </summary>
        public const string ArrayValueObjectType = "ArrayValueObjectType";

        /// <summary>
        /// The BrowseName for the Boiler1 component.
        /// </summary>
        public const string Boiler1 = "Boiler1";

        /// <summary>
        /// The BrowseName for the BoilerDrumType component.
        /// </summary>
        public const string BoilerDrumType = "BoilerDrumType";

        /// <summary>
        /// The BrowseName for the BoilerInputPipeType component.
        /// </summary>
        public const string BoilerInputPipeType = "BoilerInputPipeType";

        /// <summary>
        /// The BrowseName for the BoilerOutputPipeType component.
        /// </summary>
        public const string BoilerOutputPipeType = "BoilerOutputPipeType";

        /// <summary>
        /// The BrowseName for the BoilerType component.
        /// </summary>
        public const string BoilerType = "BoilerType";

        /// <summary>
        /// The BrowseName for the BooleanValue component.
        /// </summary>
        public const string BooleanValue = "BooleanValue";

        /// <summary>
        /// The BrowseName for the ByteStringValue component.
        /// </summary>
        public const string ByteStringValue = "ByteStringValue";

        /// <summary>
        /// The BrowseName for the ByteValue component.
        /// </summary>
        public const string ByteValue = "ByteValue";

        /// <summary>
        /// The BrowseName for the Calibrate component.
        /// </summary>
        public const string Calibrate = "Calibrate";

        /// <summary>
        /// The BrowseName for the CalibrationParameters component.
        /// </summary>
        public const string CalibrationParameters = "CalibrationParameters";

        /// <summary>
        /// The BrowseName for the CompanyName component.
        /// </summary>
        public const string CompanyName = "CompanyName";

        /// <summary>
        /// The BrowseName for the ControlOut component.
        /// </summary>
        public const string ControlOut = "ControlOut";

        /// <summary>
        /// The BrowseName for the CreateBoiler component.
        /// </summary>
        public const string CreateBoiler = "CreateBoiler";

        /// <summary>
        /// The BrowseName for the CreateInstance component.
        /// </summary>
        public const string CreateInstance = "CreateInstance";

        /// <summary>
        /// The BrowseName for the CustomController component.
        /// </summary>
        public const string CustomController = "CCX001";

        /// <summary>
        /// The BrowseName for the CustomControllerType component.
        /// </summary>
        public const string CustomControllerType = "CustomControllerType";

        /// <summary>
        /// The BrowseName for the Data component.
        /// </summary>
        public const string Data = "Data";

        /// <summary>
        /// The BrowseName for the DateTimeValue component.
        /// </summary>
        public const string DateTimeValue = "DateTimeValue";

        /// <summary>
        /// The BrowseName for the Documentation component.
        /// </summary>
        public const string Documentation = "Documentation";

        /// <summary>
        /// The BrowseName for the DoubleValue component.
        /// </summary>
        public const string DoubleValue = "DoubleValue";

        /// <summary>
        /// The BrowseName for the Drum component.
        /// </summary>
        public const string Drum = "DrumX001";

        /// <summary>
        /// The BrowseName for the ExpandedNodeIdValue component.
        /// </summary>
        public const string ExpandedNodeIdValue = "ExpandedNodeIdValue";

        /// <summary>
        /// The BrowseName for the FloatValue component.
        /// </summary>
        public const string FloatValue = "FloatValue";

        /// <summary>
        /// The BrowseName for the FlowController component.
        /// </summary>
        public const string FlowController = "FCX001";

        /// <summary>
        /// The BrowseName for the FlowControllerType component.
        /// </summary>
        public const string FlowControllerType = "FlowControllerType";

        /// <summary>
        /// The BrowseName for the FlowTo component.
        /// </summary>
        public const string FlowTo = "FlowTo";

        /// <summary>
        /// The BrowseName for the FlowTransmitter1 component.
        /// </summary>
        public const string FlowTransmitter1 = "FTX001";

        /// <summary>
        /// The BrowseName for the FlowTransmitter2 component.
        /// </summary>
        public const string FlowTransmitter2 = "FTX002";

        /// <summary>
        /// The BrowseName for the FlowTransmitterType component.
        /// </summary>
        public const string FlowTransmitterType = "FlowTransmitterType";

        /// <summary>
        /// The BrowseName for the GenerateValues component.
        /// </summary>
        public const string GenerateValues = "GenerateValues";

        /// <summary>
        /// The BrowseName for the GenerateValuesEventType component.
        /// </summary>
        public const string GenerateValuesEventType = "GenerateValuesEventType";

        /// <summary>
        /// The BrowseName for the GenerateValuesMethodType component.
        /// </summary>
        public const string GenerateValuesMethodType = "GenerateValuesMethodType";

        /// <summary>
        /// The BrowseName for the GenericActuatorType component.
        /// </summary>
        public const string GenericActuatorType = "GenericActuatorType";

        /// <summary>
        /// The BrowseName for the GenericControllerType component.
        /// </summary>
        public const string GenericControllerType = "GenericControllerType";

        /// <summary>
        /// The BrowseName for the GenericSensorType component.
        /// </summary>
        public const string GenericSensorType = "GenericSensorType";

        /// <summary>
        /// The BrowseName for the GuidValue component.
        /// </summary>
        public const string GuidValue = "GuidValue";

        /// <summary>
        /// The BrowseName for the HasVendor component.
        /// </summary>
        public const string HasVendor = "HasVendor";

        /// <summary>
        /// The BrowseName for the HotFlowTo component.
        /// </summary>
        public const string HotFlowTo = "HotFlowTo";

        /// <summary>
        /// The BrowseName for the Input component.
        /// </summary>
        public const string Input = "Input";

        /// <summary>
        /// The BrowseName for the Input1 component.
        /// </summary>
        public const string Input1 = "Input1";

        /// <summary>
        /// The BrowseName for the Input2 component.
        /// </summary>
        public const string Input2 = "Input2";

        /// <summary>
        /// The BrowseName for the Input3 component.
        /// </summary>
        public const string Input3 = "Input3";

        /// <summary>
        /// The BrowseName for the InputPipe component.
        /// </summary>
        public const string InputPipe = "PipeX001";

        /// <summary>
        /// The BrowseName for the Int16Value component.
        /// </summary>
        public const string Int16Value = "Int16Value";

        /// <summary>
        /// The BrowseName for the Int32Value component.
        /// </summary>
        public const string Int32Value = "Int32Value";

        /// <summary>
        /// The BrowseName for the Int64Value component.
        /// </summary>
        public const string Int64Value = "Int64Value";

        /// <summary>
        /// The BrowseName for the IsScheduled component.
        /// </summary>
        public const string IsScheduled = "IsScheduled";

        /// <summary>
        /// The BrowseName for the Iterations component.
        /// </summary>
        public const string Iterations = "Iterations";

        /// <summary>
        /// The BrowseName for the LevelController component.
        /// </summary>
        public const string LevelController = "LCX001";

        /// <summary>
        /// The BrowseName for the LevelControllerType component.
        /// </summary>
        public const string LevelControllerType = "LevelControllerType";

        /// <summary>
        /// The BrowseName for the LevelIndicator component.
        /// </summary>
        public const string LevelIndicator = "LIX001";

        /// <summary>
        /// The BrowseName for the LevelIndicatorType component.
        /// </summary>
        public const string LevelIndicatorType = "LevelIndicatorType";

        /// <summary>
        /// The BrowseName for the LocalizedTextValue component.
        /// </summary>
        public const string LocalizedTextValue = "LocalizedTextValue";

        /// <summary>
        /// The BrowseName for the Locations component.
        /// </summary>
        public const string Locations = "Locations";

        /// <summary>
        /// The BrowseName for the Maintenance2EventType component.
        /// </summary>
        public const string Maintenance2EventType = "Maintenance2EventType";

        /// <summary>
        /// The BrowseName for the MaintenanceEventType component.
        /// </summary>
        public const string MaintenanceEventType = "MaintenanceEventType";

        /// <summary>
        /// The BrowseName for the Measurement component.
        /// </summary>
        public const string Measurement = "Measurement";

        /// <summary>
        /// The BrowseName for the MustCompleteByDate component.
        /// </summary>
        public const string MustCompleteByDate = "MustCompleteByDate";

        /// <summary>
        /// The BrowseName for the NewValueCount component.
        /// </summary>
        public const string NewValueCount = "NewValueCount";

        /// <summary>
        /// The BrowseName for the NodeIdValue component.
        /// </summary>
        public const string NodeIdValue = "NodeIdValue";

        /// <summary>
        /// The BrowseName for the OpcUaSample component.
        /// </summary>
        public const string OpcUaSample = "Opc.Ua.Sample";

        /// <summary>
        /// The BrowseName for the Output component.
        /// </summary>
        public const string Output = "Output";

        /// <summary>
        /// The BrowseName for the OutputPipe component.
        /// </summary>
        public const string OutputPipe = "PipeX002";

        /// <summary>
        /// The BrowseName for the QualifiedNameValue component.
        /// </summary>
        public const string QualifiedNameValue = "QualifiedNameValue";

        /// <summary>
        /// The BrowseName for the Samples component.
        /// </summary>
        public const string Samples = "Samples";

        /// <summary>
        /// The BrowseName for the SByteValue component.
        /// </summary>
        public const string SByteValue = "SByteValue";

        /// <summary>
        /// The BrowseName for the Scalar component.
        /// </summary>
        public const string Scalar = "Scalar";

        /// <summary>
        /// The BrowseName for the ScalarValueDataType component.
        /// </summary>
        public const string ScalarValueDataType = "ScalarValueDataType";

        /// <summary>
        /// The BrowseName for the ScalarValueObjectType component.
        /// </summary>
        public const string ScalarValueObjectType = "ScalarValueObjectType";

        /// <summary>
        /// The BrowseName for the SerialNumber component.
        /// </summary>
        public const string SerialNumber = "SerialNumber";

        /// <summary>
        /// The BrowseName for the SetPoint component.
        /// </summary>
        public const string SetPoint = "SetPoint";

        /// <summary>
        /// The BrowseName for the SignalTo component.
        /// </summary>
        public const string SignalTo = "SignalTo";

        /// <summary>
        /// The BrowseName for the SimulationActive component.
        /// </summary>
        public const string SimulationActive = "SimulationActive";

        /// <summary>
        /// The BrowseName for the Static component.
        /// </summary>
        public const string Static = "Static";

        /// <summary>
        /// The BrowseName for the StatusCodeValue component.
        /// </summary>
        public const string StatusCodeValue = "StatusCodeValue";

        /// <summary>
        /// The BrowseName for the StringValue component.
        /// </summary>
        public const string StringValue = "StringValue";

        /// <summary>
        /// The BrowseName for the StructureValue component.
        /// </summary>
        public const string StructureValue = "StructureValue";

        /// <summary>
        /// The BrowseName for the TestDataObjectType component.
        /// </summary>
        public const string TestDataObjectType = "TestDataObjectType";

        /// <summary>
        /// The BrowseName for the UInt16Value component.
        /// </summary>
        public const string UInt16Value = "UInt16Value";

        /// <summary>
        /// The BrowseName for the UInt32Value component.
        /// </summary>
        public const string UInt32Value = "UInt32Value";

        /// <summary>
        /// The BrowseName for the UInt64Value component.
        /// </summary>
        public const string UInt64Value = "UInt64Value";

        /// <summary>
        /// The BrowseName for the Valve component.
        /// </summary>
        public const string Valve = "ValveX001";

        /// <summary>
        /// The BrowseName for the ValveType component.
        /// </summary>
        public const string ValveType = "ValveType";

        /// <summary>
        /// The BrowseName for the VariantValue component.
        /// </summary>
        public const string VariantValue = "VariantValue";

        /// <summary>
        /// The BrowseName for the VendorType component.
        /// </summary>
        public const string VendorType = "VendorType";

        /// <summary>
        /// The BrowseName for the WorkorderId component.
        /// </summary>
        public const string WorkorderId = "WorkorderId";

        /// <summary>
        /// The BrowseName for the XmlElementValue component.
        /// </summary>
        public const string XmlElementValue = "XmlElementValue";
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
        /// The URI for the Sample namespace (.NET code namespace is 'Opc.Ua.Sample').
        /// </summary>
        public const string Sample = "http://opcfoundation.org/UA/Sample/";
        
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

    #region AddressDataType Class
    /// <summary>
    /// A description for the AddressDataType DataType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Name = "AddressDataType", Namespace = Opc.Ua.Sample.Namespaces.Sample)]
    public partial class AddressDataType : EncodeableObject
    {
    	#region Constructors
    	/// <summary>
    	/// The default constructor.
    	/// </summary>
    	public AddressDataType()
    	{
    		Initialize();
    	}
        
    	/// <summary>
    	/// Called by the .NET framework during deserialization.
    	/// </summary>
        [OnDeserializing]
    	private void Initialize(StreamingContext context)
    	{
    		Initialize();
    	}

    	/// <summary>
    	/// Sets private members to default values.
    	/// </summary>
    	private void Initialize()
    	{
    		m_street1 = (string)null;
    		m_street2 = (string)null;
    		m_city = (string)null;
    		m_country = (string)null;
    		m_provinceState = (string)null;
    		m_postalCode = (string)null;
    	}
    	#endregion

    	#region Public Properties
    	/// <summary>
    	/// A description for the Street1 field.
    	/// </summary>
    	[DataMember(Name = "Street1", Order = 1)]
    	public string Street1
    	{
    		get { return m_street1;  }
    		set { m_street1 = value; }
    	}

    	/// <summary>
    	/// A description for the Street2 field.
    	/// </summary>
    	[DataMember(Name = "Street2", Order = 2)]
    	public string Street2
    	{
    		get { return m_street2;  }
    		set { m_street2 = value; }
    	}

    	/// <summary>
    	/// A description for the City field.
    	/// </summary>
    	[DataMember(Name = "City", Order = 3)]
    	public string City
    	{
    		get { return m_city;  }
    		set { m_city = value; }
    	}

    	/// <summary>
    	/// A description for the Country field.
    	/// </summary>
    	[DataMember(Name = "Country", Order = 4)]
    	public string Country
    	{
    		get { return m_country;  }
    		set { m_country = value; }
    	}

    	/// <summary>
    	/// A description for the ProvinceState field.
    	/// </summary>
    	[DataMember(Name = "ProvinceState", Order = 5)]
    	public string ProvinceState
    	{
    		get { return m_provinceState;  }
    		set { m_provinceState = value; }
    	}

    	/// <summary>
    	/// A description for the PostalCode field.
    	/// </summary>
    	[DataMember(Name = "PostalCode", Order = 6)]
    	public string PostalCode
    	{
    		get { return m_postalCode;  }
    		set { m_postalCode = value; }
    	}
    	#endregion

        #region IEncodeable Members
        /// <summary cref="IEncodeable.TypeId" />
        public override ExpandedNodeId TypeId
        {
            get { return m_TypeId; }
        }

        private static ExpandedNodeId m_TypeId = new ExpandedNodeId(DataTypes.AddressDataType, Opc.Ua.Sample.Namespaces.Sample);

        /// <summary cref="IEncodeable.BinaryEncodingId" />
        public override ExpandedNodeId BinaryEncodingId
        {
            get { return m_BinaryEncodingId; }
        }

        private static ExpandedNodeId m_BinaryEncodingId = new ExpandedNodeId(Objects.AddressDataType_Encoding_DefaultBinary, Opc.Ua.Sample.Namespaces.Sample);
        
        /// <summary cref="IEncodeable.XmlEncodingId" />
        public override ExpandedNodeId XmlEncodingId
        {
            get { return m_XmlEncodingId; }
        }
        
        private static ExpandedNodeId m_XmlEncodingId = new ExpandedNodeId(Objects.AddressDataType_Encoding_DefaultXml, Opc.Ua.Sample.Namespaces.Sample);

        /// <summary cref="IEncodeable.Encode(IEncoder)" />
        public override void Encode(IEncoder encoder)
        {
            base.Encode(encoder);

            encoder.PushNamespace(Opc.Ua.Sample.Namespaces.Sample);

    		encoder.WriteString("Street1", Street1);
    		encoder.WriteString("Street2", Street2);
    		encoder.WriteString("City", City);
    		encoder.WriteString("Country", Country);
    		encoder.WriteString("ProvinceState", ProvinceState);
    		encoder.WriteString("PostalCode", PostalCode);

            encoder.PopNamespace();
        }
        
        /// <summary cref="IEncodeable.Decode(IDecoder)" />
        public override void Decode(IDecoder decoder)
        {
            base.Decode(decoder);

            decoder.PushNamespace(Opc.Ua.Sample.Namespaces.Sample);

    		Street1 = decoder.ReadString("Street1");
    		Street2 = decoder.ReadString("Street2");
    		City = decoder.ReadString("City");
    		Country = decoder.ReadString("Country");
    		ProvinceState = decoder.ReadString("ProvinceState");
    		PostalCode = decoder.ReadString("PostalCode");

            decoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.IsEqual(IEncodeable)" />
        public override bool IsEqual(IEncodeable encodeable)
        {
            if (Object.ReferenceEquals(this, encodeable))
            {
                return true;
            }
            
            AddressDataType value = encodeable as AddressDataType;
            
            if (value == null)
            {
                return false;
            }

            if (typeof(AddressDataType).BaseType != typeof(EncodeableObject))
            {
                if (!base.IsEqual(encodeable))
                {
                    return false;
                }
            }
            
    		if (!Utils.IsEqual(m_street1, value.m_street1)) return false;
    		if (!Utils.IsEqual(m_street2, value.m_street2)) return false;
    		if (!Utils.IsEqual(m_city, value.m_city)) return false;
    		if (!Utils.IsEqual(m_country, value.m_country)) return false;
    		if (!Utils.IsEqual(m_provinceState, value.m_provinceState)) return false;
    		if (!Utils.IsEqual(m_postalCode, value.m_postalCode)) return false;

            return true;
        }
        
        /// <summary cref="ICloneable.Clone" />
        public override object Clone()
        {
            AddressDataType clone = (AddressDataType)base.Clone();

            clone.m_street1 = (string)Utils.Clone(this.m_street1);
            clone.m_street2 = (string)Utils.Clone(this.m_street2);
            clone.m_city = (string)Utils.Clone(this.m_city);
            clone.m_country = (string)Utils.Clone(this.m_country);
            clone.m_provinceState = (string)Utils.Clone(this.m_provinceState);
            clone.m_postalCode = (string)Utils.Clone(this.m_postalCode);

            return clone;
        }
        #endregion
        
    	#region Private Fields
    	private string m_street1;
    	private string m_street2;
    	private string m_city;
    	private string m_country;
    	private string m_provinceState;
    	private string m_postalCode;
    	#endregion
    }
    
    #region AddressDataTypeCollection Class
    /// <summary>
    /// A collection of AddressDataType objects.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfAddressDataType", Namespace = Opc.Ua.Sample.Namespaces.Sample, ItemName="AddressDataType")]
    public partial class AddressDataTypeCollection : List<AddressDataType>, ICloneable
    {
    	#region Constructors
    	/// <summary>
    	/// Initializes the collection with default values.
    	/// </summary>
    	public AddressDataTypeCollection() {}
    	
    	/// <summary>
    	/// Initializes the collection with an initial capacity.
    	/// </summary>
    	public AddressDataTypeCollection(int capacity) : base(capacity) {}
    	
    	/// <summary>
    	/// Initializes the collection with another collection.
    	/// </summary>
    	public AddressDataTypeCollection(IEnumerable<AddressDataType> collection) : base(collection) {}
    	#endregion
                    
        #region Static Operators
        /// <summary>
        /// Converts an array to a collection.
        /// </summary>
        public static implicit operator AddressDataTypeCollection(AddressDataType[] values)
        {
            if (values != null)
            {
                return new AddressDataTypeCollection(values);
            }

            return new AddressDataTypeCollection();
        }
        
        /// <summary>
        /// Converts a collection to an array.
        /// </summary>
        public static explicit operator AddressDataType[](AddressDataTypeCollection values)
        {
            if (values != null)
            {
                return values.ToArray();
            }

            return null;
        }
        #endregion

        #region ICloneable Methods
        /// <summary>
        /// Creates a deep copy of the collection.
        /// </summary>
        public object Clone()
        {
            AddressDataTypeCollection clone = new AddressDataTypeCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((AddressDataType)Utils.Clone(this[ii]));
            }

            return clone;
        }
        #endregion
    }
    #endregion
    #endregion

    #region ArrayValueDataType Class
    /// <summary>
    /// A description for the ArrayValueDataType DataType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Name = "ArrayValueDataType", Namespace = Opc.Ua.Sample.Namespaces.Sample)]
    public partial class ArrayValueDataType : EncodeableObject
    {
    	#region Constructors
    	/// <summary>
    	/// The default constructor.
    	/// </summary>
    	public ArrayValueDataType()
    	{
    		Initialize();
    	}
        
    	/// <summary>
    	/// Called by the .NET framework during deserialization.
    	/// </summary>
        [OnDeserializing]
    	private void Initialize(StreamingContext context)
    	{
    		Initialize();
    	}

    	/// <summary>
    	/// Sets private members to default values.
    	/// </summary>
    	private void Initialize()
    	{
    		m_booleanValue = new BooleanCollection();
    		m_sByteValue = new SByteCollection();
    		m_byteValue = new ByteCollection();
    		m_int16Value = new Int16Collection();
    		m_uInt16Value = new UInt16Collection();
    		m_int32Value = new Int32Collection();
    		m_uInt32Value = new UInt32Collection();
    		m_int64Value = new Int64Collection();
    		m_uInt64Value = new UInt64Collection();
    		m_floatValue = new FloatCollection();
    		m_doubleValue = new DoubleCollection();
    		m_stringValue = new StringCollection();
    		m_dateTimeValue = new DateTimeCollection();
    		m_guidValue = new UuidCollection();
    		m_byteStringValue = new ByteStringCollection();
    		m_xmlElementValue = new XmlElementCollection();
    		m_nodeIdValue = new NodeIdCollection();
    		m_expandedNodeIdValue = new ExpandedNodeIdCollection();
    		m_qualifiedNameValue = new QualifiedNameCollection();
    		m_localizedTextValue = new LocalizedTextCollection();
    		m_statusCodeValue = new StatusCodeCollection();
    		m_variantValue = new VariantCollection();
    		m_structureValue = new ExtensionObjectCollection();
    	}
    	#endregion

    	#region Public Properties
    	/// <summary>
    	/// A description for the BooleanValue field.
    	/// </summary>
    	[DataMember(Name = "BooleanValue", Order = 1)]
    	public BooleanCollection BooleanValue
    	{
    		get 
    	    { 
    	        return m_booleanValue;  
    	    }
    		
    	    set 
    	    { 
    	        m_booleanValue = value; 

    	        if (value == null)
    	        {
    	            m_booleanValue = new BooleanCollection();
    	        }
    	    }
    	}

    	/// <summary>
    	/// A description for the SByteValue field.
    	/// </summary>
    	[DataMember(Name = "SByteValue", Order = 2)]
    	public SByteCollection SByteValue
    	{
    		get 
    	    { 
    	        return m_sByteValue;  
    	    }
    		
    	    set 
    	    { 
    	        m_sByteValue = value; 

    	        if (value == null)
    	        {
    	            m_sByteValue = new SByteCollection();
    	        }
    	    }
    	}

    	/// <summary>
    	/// A description for the ByteValue field.
    	/// </summary>
    	[DataMember(Name = "ByteValue", Order = 3)]
    	public ByteCollection ByteValue
    	{
    		get 
    	    { 
    	        return m_byteValue;  
    	    }
    		
    	    set 
    	    { 
    	        m_byteValue = value; 

    	        if (value == null)
    	        {
    	            m_byteValue = new ByteCollection();
    	        }
    	    }
    	}

    	/// <summary>
    	/// A description for the Int16Value field.
    	/// </summary>
    	[DataMember(Name = "Int16Value", Order = 4)]
    	public Int16Collection Int16Value
    	{
    		get 
    	    { 
    	        return m_int16Value;  
    	    }
    		
    	    set 
    	    { 
    	        m_int16Value = value; 

    	        if (value == null)
    	        {
    	            m_int16Value = new Int16Collection();
    	        }
    	    }
    	}

    	/// <summary>
    	/// A description for the UInt16Value field.
    	/// </summary>
    	[DataMember(Name = "UInt16Value", Order = 5)]
    	public UInt16Collection UInt16Value
    	{
    		get 
    	    { 
    	        return m_uInt16Value;  
    	    }
    		
    	    set 
    	    { 
    	        m_uInt16Value = value; 

    	        if (value == null)
    	        {
    	            m_uInt16Value = new UInt16Collection();
    	        }
    	    }
    	}

    	/// <summary>
    	/// A description for the Int32Value field.
    	/// </summary>
    	[DataMember(Name = "Int32Value", Order = 6)]
    	public Int32Collection Int32Value
    	{
    		get 
    	    { 
    	        return m_int32Value;  
    	    }
    		
    	    set 
    	    { 
    	        m_int32Value = value; 

    	        if (value == null)
    	        {
    	            m_int32Value = new Int32Collection();
    	        }
    	    }
    	}

    	/// <summary>
    	/// A description for the UInt32Value field.
    	/// </summary>
    	[DataMember(Name = "UInt32Value", Order = 7)]
    	public UInt32Collection UInt32Value
    	{
    		get 
    	    { 
    	        return m_uInt32Value;  
    	    }
    		
    	    set 
    	    { 
    	        m_uInt32Value = value; 

    	        if (value == null)
    	        {
    	            m_uInt32Value = new UInt32Collection();
    	        }
    	    }
    	}

    	/// <summary>
    	/// A description for the Int64Value field.
    	/// </summary>
    	[DataMember(Name = "Int64Value", Order = 8)]
    	public Int64Collection Int64Value
    	{
    		get 
    	    { 
    	        return m_int64Value;  
    	    }
    		
    	    set 
    	    { 
    	        m_int64Value = value; 

    	        if (value == null)
    	        {
    	            m_int64Value = new Int64Collection();
    	        }
    	    }
    	}

    	/// <summary>
    	/// A description for the UInt64Value field.
    	/// </summary>
    	[DataMember(Name = "UInt64Value", Order = 9)]
    	public UInt64Collection UInt64Value
    	{
    		get 
    	    { 
    	        return m_uInt64Value;  
    	    }
    		
    	    set 
    	    { 
    	        m_uInt64Value = value; 

    	        if (value == null)
    	        {
    	            m_uInt64Value = new UInt64Collection();
    	        }
    	    }
    	}

    	/// <summary>
    	/// A description for the FloatValue field.
    	/// </summary>
    	[DataMember(Name = "FloatValue", Order = 10)]
    	public FloatCollection FloatValue
    	{
    		get 
    	    { 
    	        return m_floatValue;  
    	    }
    		
    	    set 
    	    { 
    	        m_floatValue = value; 

    	        if (value == null)
    	        {
    	            m_floatValue = new FloatCollection();
    	        }
    	    }
    	}

    	/// <summary>
    	/// A description for the DoubleValue field.
    	/// </summary>
    	[DataMember(Name = "DoubleValue", Order = 11)]
    	public DoubleCollection DoubleValue
    	{
    		get 
    	    { 
    	        return m_doubleValue;  
    	    }
    		
    	    set 
    	    { 
    	        m_doubleValue = value; 

    	        if (value == null)
    	        {
    	            m_doubleValue = new DoubleCollection();
    	        }
    	    }
    	}

    	/// <summary>
    	/// A description for the StringValue field.
    	/// </summary>
    	[DataMember(Name = "StringValue", Order = 12)]
    	public StringCollection StringValue
    	{
    		get 
    	    { 
    	        return m_stringValue;  
    	    }
    		
    	    set 
    	    { 
    	        m_stringValue = value; 

    	        if (value == null)
    	        {
    	            m_stringValue = new StringCollection();
    	        }
    	    }
    	}

    	/// <summary>
    	/// A description for the DateTimeValue field.
    	/// </summary>
    	[DataMember(Name = "DateTimeValue", Order = 13)]
    	public DateTimeCollection DateTimeValue
    	{
    		get 
    	    { 
    	        return m_dateTimeValue;  
    	    }
    		
    	    set 
    	    { 
    	        m_dateTimeValue = value; 

    	        if (value == null)
    	        {
    	            m_dateTimeValue = new DateTimeCollection();
    	        }
    	    }
    	}

    	/// <summary>
    	/// A description for the GuidValue field.
    	/// </summary>
    	[DataMember(Name = "GuidValue", Order = 14)]
    	public UuidCollection GuidValue
    	{
    		get 
    	    { 
    	        return m_guidValue;  
    	    }
    		
    	    set 
    	    { 
    	        m_guidValue = value; 

    	        if (value == null)
    	        {
    	            m_guidValue = new UuidCollection();
    	        }
    	    }
    	}

    	/// <summary>
    	/// A description for the ByteStringValue field.
    	/// </summary>
    	[DataMember(Name = "ByteStringValue", Order = 15)]
    	public ByteStringCollection ByteStringValue
    	{
    		get 
    	    { 
    	        return m_byteStringValue;  
    	    }
    		
    	    set 
    	    { 
    	        m_byteStringValue = value; 

    	        if (value == null)
    	        {
    	            m_byteStringValue = new ByteStringCollection();
    	        }
    	    }
    	}

    	/// <summary>
    	/// A description for the XmlElementValue field.
    	/// </summary>
    	[DataMember(Name = "XmlElementValue", Order = 16)]
    	public XmlElementCollection XmlElementValue
    	{
    		get 
    	    { 
    	        return m_xmlElementValue;  
    	    }
    		
    	    set 
    	    { 
    	        m_xmlElementValue = value; 

    	        if (value == null)
    	        {
    	            m_xmlElementValue = new XmlElementCollection();
    	        }
    	    }
    	}

    	/// <summary>
    	/// A description for the NodeIdValue field.
    	/// </summary>
    	[DataMember(Name = "NodeIdValue", Order = 17)]
    	public NodeIdCollection NodeIdValue
    	{
    		get 
    	    { 
    	        return m_nodeIdValue;  
    	    }
    		
    	    set 
    	    { 
    	        m_nodeIdValue = value; 

    	        if (value == null)
    	        {
    	            m_nodeIdValue = new NodeIdCollection();
    	        }
    	    }
    	}

    	/// <summary>
    	/// A description for the ExpandedNodeIdValue field.
    	/// </summary>
    	[DataMember(Name = "ExpandedNodeIdValue", Order = 18)]
    	public ExpandedNodeIdCollection ExpandedNodeIdValue
    	{
    		get 
    	    { 
    	        return m_expandedNodeIdValue;  
    	    }
    		
    	    set 
    	    { 
    	        m_expandedNodeIdValue = value; 

    	        if (value == null)
    	        {
    	            m_expandedNodeIdValue = new ExpandedNodeIdCollection();
    	        }
    	    }
    	}

    	/// <summary>
    	/// A description for the QualifiedNameValue field.
    	/// </summary>
    	[DataMember(Name = "QualifiedNameValue", Order = 19)]
    	public QualifiedNameCollection QualifiedNameValue
    	{
    		get 
    	    { 
    	        return m_qualifiedNameValue;  
    	    }
    		
    	    set 
    	    { 
    	        m_qualifiedNameValue = value; 

    	        if (value == null)
    	        {
    	            m_qualifiedNameValue = new QualifiedNameCollection();
    	        }
    	    }
    	}

    	/// <summary>
    	/// A description for the LocalizedTextValue field.
    	/// </summary>
    	[DataMember(Name = "LocalizedTextValue", Order = 20)]
    	public LocalizedTextCollection LocalizedTextValue
    	{
    		get 
    	    { 
    	        return m_localizedTextValue;  
    	    }
    		
    	    set 
    	    { 
    	        m_localizedTextValue = value; 

    	        if (value == null)
    	        {
    	            m_localizedTextValue = new LocalizedTextCollection();
    	        }
    	    }
    	}

    	/// <summary>
    	/// A description for the StatusCodeValue field.
    	/// </summary>
    	[DataMember(Name = "StatusCodeValue", Order = 21)]
    	public StatusCodeCollection StatusCodeValue
    	{
    		get 
    	    { 
    	        return m_statusCodeValue;  
    	    }
    		
    	    set 
    	    { 
    	        m_statusCodeValue = value; 

    	        if (value == null)
    	        {
    	            m_statusCodeValue = new StatusCodeCollection();
    	        }
    	    }
    	}

    	/// <summary>
    	/// A description for the VariantValue field.
    	/// </summary>
    	[DataMember(Name = "VariantValue", Order = 22)]
    	public VariantCollection VariantValue
    	{
    		get 
    	    { 
    	        return m_variantValue;  
    	    }
    		
    	    set 
    	    { 
    	        m_variantValue = value; 

    	        if (value == null)
    	        {
    	            m_variantValue = new VariantCollection();
    	        }
    	    }
    	}

    	/// <summary>
    	/// A description for the StructureValue field.
    	/// </summary>
    	[DataMember(Name = "StructureValue", Order = 23)]
    	public ExtensionObjectCollection StructureValue
    	{
    		get 
    	    { 
    	        return m_structureValue;  
    	    }
    		
    	    set 
    	    { 
    	        m_structureValue = value; 

    	        if (value == null)
    	        {
    	            m_structureValue = new ExtensionObjectCollection();
    	        }
    	    }
    	}
    	#endregion

        #region IEncodeable Members
        /// <summary cref="IEncodeable.TypeId" />
        public override ExpandedNodeId TypeId
        {
            get { return m_TypeId; }
        }

        private static ExpandedNodeId m_TypeId = new ExpandedNodeId(DataTypes.ArrayValueDataType, Opc.Ua.Sample.Namespaces.Sample);

        /// <summary cref="IEncodeable.BinaryEncodingId" />
        public override ExpandedNodeId BinaryEncodingId
        {
            get { return m_BinaryEncodingId; }
        }

        private static ExpandedNodeId m_BinaryEncodingId = new ExpandedNodeId(Objects.ArrayValueDataType_Encoding_DefaultBinary, Opc.Ua.Sample.Namespaces.Sample);
        
        /// <summary cref="IEncodeable.XmlEncodingId" />
        public override ExpandedNodeId XmlEncodingId
        {
            get { return m_XmlEncodingId; }
        }
        
        private static ExpandedNodeId m_XmlEncodingId = new ExpandedNodeId(Objects.ArrayValueDataType_Encoding_DefaultXml, Opc.Ua.Sample.Namespaces.Sample);

        /// <summary cref="IEncodeable.Encode(IEncoder)" />
        public override void Encode(IEncoder encoder)
        {
            base.Encode(encoder);

            encoder.PushNamespace(Opc.Ua.Sample.Namespaces.Sample);

    		encoder.WriteBooleanArray("BooleanValue", BooleanValue);
    		encoder.WriteSByteArray("SByteValue", SByteValue);
    		encoder.WriteByteArray("ByteValue", ByteValue);
    		encoder.WriteInt16Array("Int16Value", Int16Value);
    		encoder.WriteUInt16Array("UInt16Value", UInt16Value);
    		encoder.WriteInt32Array("Int32Value", Int32Value);
    		encoder.WriteUInt32Array("UInt32Value", UInt32Value);
    		encoder.WriteInt64Array("Int64Value", Int64Value);
    		encoder.WriteUInt64Array("UInt64Value", UInt64Value);
    		encoder.WriteFloatArray("FloatValue", FloatValue);
    		encoder.WriteDoubleArray("DoubleValue", DoubleValue);
    		encoder.WriteStringArray("StringValue", StringValue);
    		encoder.WriteDateTimeArray("DateTimeValue", DateTimeValue);
    		encoder.WriteGuidArray("GuidValue", GuidValue);
    		encoder.WriteByteStringArray("ByteStringValue", ByteStringValue);
    		encoder.WriteXmlElementArray("XmlElementValue", XmlElementValue);
    		encoder.WriteNodeIdArray("NodeIdValue", NodeIdValue);
    		encoder.WriteExpandedNodeIdArray("ExpandedNodeIdValue", ExpandedNodeIdValue);
    		encoder.WriteQualifiedNameArray("QualifiedNameValue", QualifiedNameValue);
    		encoder.WriteLocalizedTextArray("LocalizedTextValue", LocalizedTextValue);
    		encoder.WriteStatusCodeArray("StatusCodeValue", StatusCodeValue);
    		encoder.WriteVariantArray("VariantValue", VariantValue);
    		encoder.WriteExtensionObjectArray("StructureValue", StructureValue);

            encoder.PopNamespace();
        }
        
        /// <summary cref="IEncodeable.Decode(IDecoder)" />
        public override void Decode(IDecoder decoder)
        {
            base.Decode(decoder);

            decoder.PushNamespace(Opc.Ua.Sample.Namespaces.Sample);

    		BooleanValue = decoder.ReadBooleanArray("BooleanValue");
    		SByteValue = decoder.ReadSByteArray("SByteValue");
    		ByteValue = decoder.ReadByteArray("ByteValue");
    		Int16Value = decoder.ReadInt16Array("Int16Value");
    		UInt16Value = decoder.ReadUInt16Array("UInt16Value");
    		Int32Value = decoder.ReadInt32Array("Int32Value");
    		UInt32Value = decoder.ReadUInt32Array("UInt32Value");
    		Int64Value = decoder.ReadInt64Array("Int64Value");
    		UInt64Value = decoder.ReadUInt64Array("UInt64Value");
    		FloatValue = decoder.ReadFloatArray("FloatValue");
    		DoubleValue = decoder.ReadDoubleArray("DoubleValue");
    		StringValue = decoder.ReadStringArray("StringValue");
    		DateTimeValue = decoder.ReadDateTimeArray("DateTimeValue");
    		GuidValue = decoder.ReadGuidArray("GuidValue");
    		ByteStringValue = decoder.ReadByteStringArray("ByteStringValue");
    		XmlElementValue = decoder.ReadXmlElementArray("XmlElementValue");
    		NodeIdValue = decoder.ReadNodeIdArray("NodeIdValue");
    		ExpandedNodeIdValue = decoder.ReadExpandedNodeIdArray("ExpandedNodeIdValue");
    		QualifiedNameValue = decoder.ReadQualifiedNameArray("QualifiedNameValue");
    		LocalizedTextValue = decoder.ReadLocalizedTextArray("LocalizedTextValue");
    		StatusCodeValue = decoder.ReadStatusCodeArray("StatusCodeValue");
    		VariantValue = decoder.ReadVariantArray("VariantValue");
    		StructureValue = decoder.ReadExtensionObjectArray("StructureValue");

            decoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.IsEqual(IEncodeable)" />
        public override bool IsEqual(IEncodeable encodeable)
        {
            if (Object.ReferenceEquals(this, encodeable))
            {
                return true;
            }
            
            ArrayValueDataType value = encodeable as ArrayValueDataType;
            
            if (value == null)
            {
                return false;
            }

            if (typeof(ArrayValueDataType).BaseType != typeof(EncodeableObject))
            {
                if (!base.IsEqual(encodeable))
                {
                    return false;
                }
            }
            
    		if (!Utils.IsEqual(m_booleanValue, value.m_booleanValue)) return false;
    		if (!Utils.IsEqual(m_sByteValue, value.m_sByteValue)) return false;
    		if (!Utils.IsEqual(m_byteValue, value.m_byteValue)) return false;
    		if (!Utils.IsEqual(m_int16Value, value.m_int16Value)) return false;
    		if (!Utils.IsEqual(m_uInt16Value, value.m_uInt16Value)) return false;
    		if (!Utils.IsEqual(m_int32Value, value.m_int32Value)) return false;
    		if (!Utils.IsEqual(m_uInt32Value, value.m_uInt32Value)) return false;
    		if (!Utils.IsEqual(m_int64Value, value.m_int64Value)) return false;
    		if (!Utils.IsEqual(m_uInt64Value, value.m_uInt64Value)) return false;
    		if (!Utils.IsEqual(m_floatValue, value.m_floatValue)) return false;
    		if (!Utils.IsEqual(m_doubleValue, value.m_doubleValue)) return false;
    		if (!Utils.IsEqual(m_stringValue, value.m_stringValue)) return false;
    		if (!Utils.IsEqual(m_dateTimeValue, value.m_dateTimeValue)) return false;
    		if (!Utils.IsEqual(m_guidValue, value.m_guidValue)) return false;
    		if (!Utils.IsEqual(m_byteStringValue, value.m_byteStringValue)) return false;
    		if (!Utils.IsEqual(m_xmlElementValue, value.m_xmlElementValue)) return false;
    		if (!Utils.IsEqual(m_nodeIdValue, value.m_nodeIdValue)) return false;
    		if (!Utils.IsEqual(m_expandedNodeIdValue, value.m_expandedNodeIdValue)) return false;
    		if (!Utils.IsEqual(m_qualifiedNameValue, value.m_qualifiedNameValue)) return false;
    		if (!Utils.IsEqual(m_localizedTextValue, value.m_localizedTextValue)) return false;
    		if (!Utils.IsEqual(m_statusCodeValue, value.m_statusCodeValue)) return false;
    		if (!Utils.IsEqual(m_variantValue, value.m_variantValue)) return false;
    		if (!Utils.IsEqual(m_structureValue, value.m_structureValue)) return false;

            return true;
        }
        
        /// <summary cref="ICloneable.Clone" />
        public override object Clone()
        {
            ArrayValueDataType clone = (ArrayValueDataType)base.Clone();

            clone.m_booleanValue = (BooleanCollection)Utils.Clone(this.m_booleanValue);
            clone.m_sByteValue = (SByteCollection)Utils.Clone(this.m_sByteValue);
            clone.m_byteValue = (ByteCollection)Utils.Clone(this.m_byteValue);
            clone.m_int16Value = (Int16Collection)Utils.Clone(this.m_int16Value);
            clone.m_uInt16Value = (UInt16Collection)Utils.Clone(this.m_uInt16Value);
            clone.m_int32Value = (Int32Collection)Utils.Clone(this.m_int32Value);
            clone.m_uInt32Value = (UInt32Collection)Utils.Clone(this.m_uInt32Value);
            clone.m_int64Value = (Int64Collection)Utils.Clone(this.m_int64Value);
            clone.m_uInt64Value = (UInt64Collection)Utils.Clone(this.m_uInt64Value);
            clone.m_floatValue = (FloatCollection)Utils.Clone(this.m_floatValue);
            clone.m_doubleValue = (DoubleCollection)Utils.Clone(this.m_doubleValue);
            clone.m_stringValue = (StringCollection)Utils.Clone(this.m_stringValue);
            clone.m_dateTimeValue = (DateTimeCollection)Utils.Clone(this.m_dateTimeValue);
            clone.m_guidValue = (UuidCollection)Utils.Clone(this.m_guidValue);
            clone.m_byteStringValue = (ByteStringCollection)Utils.Clone(this.m_byteStringValue);
            clone.m_xmlElementValue = (XmlElementCollection)Utils.Clone(this.m_xmlElementValue);
            clone.m_nodeIdValue = (NodeIdCollection)Utils.Clone(this.m_nodeIdValue);
            clone.m_expandedNodeIdValue = (ExpandedNodeIdCollection)Utils.Clone(this.m_expandedNodeIdValue);
            clone.m_qualifiedNameValue = (QualifiedNameCollection)Utils.Clone(this.m_qualifiedNameValue);
            clone.m_localizedTextValue = (LocalizedTextCollection)Utils.Clone(this.m_localizedTextValue);
            clone.m_statusCodeValue = (StatusCodeCollection)Utils.Clone(this.m_statusCodeValue);
            clone.m_variantValue = (VariantCollection)Utils.Clone(this.m_variantValue);
            clone.m_structureValue = (ExtensionObjectCollection)Utils.Clone(this.m_structureValue);

            return clone;
        }
        #endregion
        
    	#region Private Fields
    	private BooleanCollection m_booleanValue;
    	private SByteCollection m_sByteValue;
    	private ByteCollection m_byteValue;
    	private Int16Collection m_int16Value;
    	private UInt16Collection m_uInt16Value;
    	private Int32Collection m_int32Value;
    	private UInt32Collection m_uInt32Value;
    	private Int64Collection m_int64Value;
    	private UInt64Collection m_uInt64Value;
    	private FloatCollection m_floatValue;
    	private DoubleCollection m_doubleValue;
    	private StringCollection m_stringValue;
    	private DateTimeCollection m_dateTimeValue;
    	private UuidCollection m_guidValue;
    	private ByteStringCollection m_byteStringValue;
    	private XmlElementCollection m_xmlElementValue;
    	private NodeIdCollection m_nodeIdValue;
    	private ExpandedNodeIdCollection m_expandedNodeIdValue;
    	private QualifiedNameCollection m_qualifiedNameValue;
    	private LocalizedTextCollection m_localizedTextValue;
    	private StatusCodeCollection m_statusCodeValue;
    	private VariantCollection m_variantValue;
    	private ExtensionObjectCollection m_structureValue;
    	#endregion
    }
    
    #region ArrayValueDataTypeCollection Class
    /// <summary>
    /// A collection of ArrayValueDataType objects.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfArrayValueDataType", Namespace = Opc.Ua.Sample.Namespaces.Sample, ItemName="ArrayValueDataType")]
    public partial class ArrayValueDataTypeCollection : List<ArrayValueDataType>, ICloneable
    {
    	#region Constructors
    	/// <summary>
    	/// Initializes the collection with default values.
    	/// </summary>
    	public ArrayValueDataTypeCollection() {}
    	
    	/// <summary>
    	/// Initializes the collection with an initial capacity.
    	/// </summary>
    	public ArrayValueDataTypeCollection(int capacity) : base(capacity) {}
    	
    	/// <summary>
    	/// Initializes the collection with another collection.
    	/// </summary>
    	public ArrayValueDataTypeCollection(IEnumerable<ArrayValueDataType> collection) : base(collection) {}
    	#endregion
                    
        #region Static Operators
        /// <summary>
        /// Converts an array to a collection.
        /// </summary>
        public static implicit operator ArrayValueDataTypeCollection(ArrayValueDataType[] values)
        {
            if (values != null)
            {
                return new ArrayValueDataTypeCollection(values);
            }

            return new ArrayValueDataTypeCollection();
        }
        
        /// <summary>
        /// Converts a collection to an array.
        /// </summary>
        public static explicit operator ArrayValueDataType[](ArrayValueDataTypeCollection values)
        {
            if (values != null)
            {
                return values.ToArray();
            }

            return null;
        }
        #endregion

        #region ICloneable Methods
        /// <summary>
        /// Creates a deep copy of the collection.
        /// </summary>
        public object Clone()
        {
            ArrayValueDataTypeCollection clone = new ArrayValueDataTypeCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((ArrayValueDataType)Utils.Clone(this[ii]));
            }

            return clone;
        }
        #endregion
    }
    #endregion
    #endregion

    #region ScalarValueDataType Class
    /// <summary>
    /// A description for the ScalarValueDataType DataType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Name = "ScalarValueDataType", Namespace = Opc.Ua.Sample.Namespaces.Sample)]
    public partial class ScalarValueDataType : EncodeableObject
    {
    	#region Constructors
    	/// <summary>
    	/// The default constructor.
    	/// </summary>
    	public ScalarValueDataType()
    	{
    		Initialize();
    	}
        
    	/// <summary>
    	/// Called by the .NET framework during deserialization.
    	/// </summary>
        [OnDeserializing]
    	private void Initialize(StreamingContext context)
    	{
    		Initialize();
    	}

    	/// <summary>
    	/// Sets private members to default values.
    	/// </summary>
    	private void Initialize()
    	{
    		m_booleanValue = false;
    		m_sByteValue = (sbyte)0;
    		m_byteValue = (byte)0;
    		m_int16Value = (short)0;
    		m_uInt16Value = (ushort)0;
    		m_int32Value = (int)0;
    		m_uInt32Value = (uint)0;
    		m_int64Value = (long)0;
    		m_uInt64Value = (ulong)0;
    		m_floatValue = (float)0;
    		m_doubleValue = (double)0;
    		m_stringValue = (string)null;
    		m_dateTimeValue = DateTime.MinValue;
    		m_guidValue = Uuid.Empty;
    		m_byteStringValue = (byte[])null;
    		m_xmlElementValue = (XmlElement)null;
    		m_nodeIdValue = NodeId.Null;
    		m_expandedNodeIdValue = ExpandedNodeId.Null;
    		m_qualifiedNameValue = QualifiedName.Null;
    		m_localizedTextValue = LocalizedText.Null;
    		m_statusCodeValue = (StatusCode)StatusCodes.Good;
    		m_variantValue = Variant.Null;
    		m_structureValue = (ExtensionObject)null;
    	}
    	#endregion

    	#region Public Properties
    	/// <summary>
    	/// A description for the BooleanValue field.
    	/// </summary>
    	[DataMember(Name = "BooleanValue", Order = 1)]
    	public bool BooleanValue
    	{
    		get { return m_booleanValue;  }
    		set { m_booleanValue = value; }
    	}

    	/// <summary>
    	/// A description for the SByteValue field.
    	/// </summary>
    	[DataMember(Name = "SByteValue", Order = 2)]
    	public sbyte SByteValue
    	{
    		get { return m_sByteValue;  }
    		set { m_sByteValue = value; }
    	}

    	/// <summary>
    	/// A description for the ByteValue field.
    	/// </summary>
    	[DataMember(Name = "ByteValue", Order = 3)]
    	public byte ByteValue
    	{
    		get { return m_byteValue;  }
    		set { m_byteValue = value; }
    	}

    	/// <summary>
    	/// A description for the Int16Value field.
    	/// </summary>
    	[DataMember(Name = "Int16Value", Order = 4)]
    	public short Int16Value
    	{
    		get { return m_int16Value;  }
    		set { m_int16Value = value; }
    	}

    	/// <summary>
    	/// A description for the UInt16Value field.
    	/// </summary>
    	[DataMember(Name = "UInt16Value", Order = 5)]
    	public ushort UInt16Value
    	{
    		get { return m_uInt16Value;  }
    		set { m_uInt16Value = value; }
    	}

    	/// <summary>
    	/// A description for the Int32Value field.
    	/// </summary>
    	[DataMember(Name = "Int32Value", Order = 6)]
    	public int Int32Value
    	{
    		get { return m_int32Value;  }
    		set { m_int32Value = value; }
    	}

    	/// <summary>
    	/// A description for the UInt32Value field.
    	/// </summary>
    	[DataMember(Name = "UInt32Value", Order = 7)]
    	public uint UInt32Value
    	{
    		get { return m_uInt32Value;  }
    		set { m_uInt32Value = value; }
    	}

    	/// <summary>
    	/// A description for the Int64Value field.
    	/// </summary>
    	[DataMember(Name = "Int64Value", Order = 8)]
    	public long Int64Value
    	{
    		get { return m_int64Value;  }
    		set { m_int64Value = value; }
    	}

    	/// <summary>
    	/// A description for the UInt64Value field.
    	/// </summary>
    	[DataMember(Name = "UInt64Value", Order = 9)]
    	public ulong UInt64Value
    	{
    		get { return m_uInt64Value;  }
    		set { m_uInt64Value = value; }
    	}

    	/// <summary>
    	/// A description for the FloatValue field.
    	/// </summary>
    	[DataMember(Name = "FloatValue", Order = 10)]
    	public float FloatValue
    	{
    		get { return m_floatValue;  }
    		set { m_floatValue = value; }
    	}

    	/// <summary>
    	/// A description for the DoubleValue field.
    	/// </summary>
    	[DataMember(Name = "DoubleValue", Order = 11)]
    	public double DoubleValue
    	{
    		get { return m_doubleValue;  }
    		set { m_doubleValue = value; }
    	}

    	/// <summary>
    	/// A description for the StringValue field.
    	/// </summary>
    	[DataMember(Name = "StringValue", Order = 12)]
    	public string StringValue
    	{
    		get { return m_stringValue;  }
    		set { m_stringValue = value; }
    	}

    	/// <summary>
    	/// A description for the DateTimeValue field.
    	/// </summary>
    	[DataMember(Name = "DateTimeValue", Order = 13)]
    	public DateTime DateTimeValue
    	{
    		get { return m_dateTimeValue;  }
    		set { m_dateTimeValue = value; }
    	}

    	/// <summary>
    	/// A description for the GuidValue field.
    	/// </summary>
    	[DataMember(Name = "GuidValue", Order = 14)]
    	public Uuid GuidValue
    	{
    		get { return m_guidValue;  }
    		set { m_guidValue = value; }
    	}

    	/// <summary>
    	/// A description for the ByteStringValue field.
    	/// </summary>
    	[DataMember(Name = "ByteStringValue", Order = 15)]
    	public byte[] ByteStringValue
    	{
    		get { return m_byteStringValue;  }
    		set { m_byteStringValue = value; }
    	}

    	/// <summary>
    	/// A description for the XmlElementValue field.
    	/// </summary>
    	[DataMember(Name = "XmlElementValue", Order = 16)]
    	public XmlElement XmlElementValue
    	{
    		get { return m_xmlElementValue;  }
    		set { m_xmlElementValue = value; }
    	}

    	/// <summary>
    	/// A description for the NodeIdValue field.
    	/// </summary>
    	[DataMember(Name = "NodeIdValue", Order = 17)]
    	public NodeId NodeIdValue
    	{
    		get { return m_nodeIdValue;  }
    		set { m_nodeIdValue = value; }
    	}

    	/// <summary>
    	/// A description for the ExpandedNodeIdValue field.
    	/// </summary>
    	[DataMember(Name = "ExpandedNodeIdValue", Order = 18)]
    	public ExpandedNodeId ExpandedNodeIdValue
    	{
    		get { return m_expandedNodeIdValue;  }
    		set { m_expandedNodeIdValue = value; }
    	}

    	/// <summary>
    	/// A description for the QualifiedNameValue field.
    	/// </summary>
    	[DataMember(Name = "QualifiedNameValue", Order = 19)]
    	public QualifiedName QualifiedNameValue
    	{
    		get { return m_qualifiedNameValue;  }
    		set { m_qualifiedNameValue = value; }
    	}

    	/// <summary>
    	/// A description for the LocalizedTextValue field.
    	/// </summary>
    	[DataMember(Name = "LocalizedTextValue", Order = 20)]
    	public LocalizedText LocalizedTextValue
    	{
    		get { return m_localizedTextValue;  }
    		set { m_localizedTextValue = value; }
    	}

    	/// <summary>
    	/// A description for the StatusCodeValue field.
    	/// </summary>
    	[DataMember(Name = "StatusCodeValue", Order = 21)]
    	public StatusCode StatusCodeValue
    	{
    		get { return m_statusCodeValue;  }
    		set { m_statusCodeValue = value; }
    	}

    	/// <summary>
    	/// A description for the VariantValue field.
    	/// </summary>
    	[DataMember(Name = "VariantValue", Order = 22)]
    	public Variant VariantValue
    	{
    		get { return m_variantValue;  }
    		set { m_variantValue = value; }
    	}

    	/// <summary>
    	/// A description for the StructureValue field.
    	/// </summary>
    	[DataMember(Name = "StructureValue", Order = 23)]
    	public ExtensionObject StructureValue
    	{
    		get { return m_structureValue;  }
    		set { m_structureValue = value; }
    	}
    	#endregion

        #region IEncodeable Members
        /// <summary cref="IEncodeable.TypeId" />
        public override ExpandedNodeId TypeId
        {
            get { return m_TypeId; }
        }

        private static ExpandedNodeId m_TypeId = new ExpandedNodeId(DataTypes.ScalarValueDataType, Opc.Ua.Sample.Namespaces.Sample);

        /// <summary cref="IEncodeable.BinaryEncodingId" />
        public override ExpandedNodeId BinaryEncodingId
        {
            get { return m_BinaryEncodingId; }
        }

        private static ExpandedNodeId m_BinaryEncodingId = new ExpandedNodeId(Objects.ScalarValueDataType_Encoding_DefaultBinary, Opc.Ua.Sample.Namespaces.Sample);
        
        /// <summary cref="IEncodeable.XmlEncodingId" />
        public override ExpandedNodeId XmlEncodingId
        {
            get { return m_XmlEncodingId; }
        }
        
        private static ExpandedNodeId m_XmlEncodingId = new ExpandedNodeId(Objects.ScalarValueDataType_Encoding_DefaultXml, Opc.Ua.Sample.Namespaces.Sample);

        /// <summary cref="IEncodeable.Encode(IEncoder)" />
        public override void Encode(IEncoder encoder)
        {
            base.Encode(encoder);

            encoder.PushNamespace(Opc.Ua.Sample.Namespaces.Sample);

    		encoder.WriteBoolean("BooleanValue", BooleanValue);
    		encoder.WriteSByte("SByteValue", SByteValue);
    		encoder.WriteByte("ByteValue", ByteValue);
    		encoder.WriteInt16("Int16Value", Int16Value);
    		encoder.WriteUInt16("UInt16Value", UInt16Value);
    		encoder.WriteInt32("Int32Value", Int32Value);
    		encoder.WriteUInt32("UInt32Value", UInt32Value);
    		encoder.WriteInt64("Int64Value", Int64Value);
    		encoder.WriteUInt64("UInt64Value", UInt64Value);
    		encoder.WriteFloat("FloatValue", FloatValue);
    		encoder.WriteDouble("DoubleValue", DoubleValue);
    		encoder.WriteString("StringValue", StringValue);
    		encoder.WriteDateTime("DateTimeValue", DateTimeValue);
    		encoder.WriteGuid("GuidValue", GuidValue);
    		encoder.WriteByteString("ByteStringValue", ByteStringValue);
    		encoder.WriteXmlElement("XmlElementValue", XmlElementValue);
    		encoder.WriteNodeId("NodeIdValue", NodeIdValue);
    		encoder.WriteExpandedNodeId("ExpandedNodeIdValue", ExpandedNodeIdValue);
    		encoder.WriteQualifiedName("QualifiedNameValue", QualifiedNameValue);
    		encoder.WriteLocalizedText("LocalizedTextValue", LocalizedTextValue);
    		encoder.WriteStatusCode("StatusCodeValue", StatusCodeValue);
    		encoder.WriteVariant("VariantValue", VariantValue);
    		encoder.WriteExtensionObject("StructureValue", StructureValue);

            encoder.PopNamespace();
        }
        
        /// <summary cref="IEncodeable.Decode(IDecoder)" />
        public override void Decode(IDecoder decoder)
        {
            base.Decode(decoder);

            decoder.PushNamespace(Opc.Ua.Sample.Namespaces.Sample);

    		BooleanValue = decoder.ReadBoolean("BooleanValue");
    		SByteValue = decoder.ReadSByte("SByteValue");
    		ByteValue = decoder.ReadByte("ByteValue");
    		Int16Value = decoder.ReadInt16("Int16Value");
    		UInt16Value = decoder.ReadUInt16("UInt16Value");
    		Int32Value = decoder.ReadInt32("Int32Value");
    		UInt32Value = decoder.ReadUInt32("UInt32Value");
    		Int64Value = decoder.ReadInt64("Int64Value");
    		UInt64Value = decoder.ReadUInt64("UInt64Value");
    		FloatValue = decoder.ReadFloat("FloatValue");
    		DoubleValue = decoder.ReadDouble("DoubleValue");
    		StringValue = decoder.ReadString("StringValue");
    		DateTimeValue = decoder.ReadDateTime("DateTimeValue");
    		GuidValue = decoder.ReadGuid("GuidValue");
    		ByteStringValue = decoder.ReadByteString("ByteStringValue");
    		XmlElementValue = decoder.ReadXmlElement("XmlElementValue");
    		NodeIdValue = decoder.ReadNodeId("NodeIdValue");
    		ExpandedNodeIdValue = decoder.ReadExpandedNodeId("ExpandedNodeIdValue");
    		QualifiedNameValue = decoder.ReadQualifiedName("QualifiedNameValue");
    		LocalizedTextValue = decoder.ReadLocalizedText("LocalizedTextValue");
    		StatusCodeValue = decoder.ReadStatusCode("StatusCodeValue");
    		VariantValue = decoder.ReadVariant("VariantValue");
    		StructureValue = decoder.ReadExtensionObject("StructureValue");

            decoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.IsEqual(IEncodeable)" />
        public override bool IsEqual(IEncodeable encodeable)
        {
            if (Object.ReferenceEquals(this, encodeable))
            {
                return true;
            }
            
            ScalarValueDataType value = encodeable as ScalarValueDataType;
            
            if (value == null)
            {
                return false;
            }

            if (typeof(ScalarValueDataType).BaseType != typeof(EncodeableObject))
            {
                if (!base.IsEqual(encodeable))
                {
                    return false;
                }
            }
            
    		if (!Utils.IsEqual(m_booleanValue, value.m_booleanValue)) return false;
    		if (!Utils.IsEqual(m_sByteValue, value.m_sByteValue)) return false;
    		if (!Utils.IsEqual(m_byteValue, value.m_byteValue)) return false;
    		if (!Utils.IsEqual(m_int16Value, value.m_int16Value)) return false;
    		if (!Utils.IsEqual(m_uInt16Value, value.m_uInt16Value)) return false;
    		if (!Utils.IsEqual(m_int32Value, value.m_int32Value)) return false;
    		if (!Utils.IsEqual(m_uInt32Value, value.m_uInt32Value)) return false;
    		if (!Utils.IsEqual(m_int64Value, value.m_int64Value)) return false;
    		if (!Utils.IsEqual(m_uInt64Value, value.m_uInt64Value)) return false;
    		if (!Utils.IsEqual(m_floatValue, value.m_floatValue)) return false;
    		if (!Utils.IsEqual(m_doubleValue, value.m_doubleValue)) return false;
    		if (!Utils.IsEqual(m_stringValue, value.m_stringValue)) return false;
    		if (!Utils.IsEqual(m_dateTimeValue, value.m_dateTimeValue)) return false;
    		if (!Utils.IsEqual(m_guidValue, value.m_guidValue)) return false;
    		if (!Utils.IsEqual(m_byteStringValue, value.m_byteStringValue)) return false;
    		if (!Utils.IsEqual(m_xmlElementValue, value.m_xmlElementValue)) return false;
    		if (!Utils.IsEqual(m_nodeIdValue, value.m_nodeIdValue)) return false;
    		if (!Utils.IsEqual(m_expandedNodeIdValue, value.m_expandedNodeIdValue)) return false;
    		if (!Utils.IsEqual(m_qualifiedNameValue, value.m_qualifiedNameValue)) return false;
    		if (!Utils.IsEqual(m_localizedTextValue, value.m_localizedTextValue)) return false;
    		if (!Utils.IsEqual(m_statusCodeValue, value.m_statusCodeValue)) return false;
    		if (!Utils.IsEqual(m_variantValue, value.m_variantValue)) return false;
    		if (!Utils.IsEqual(m_structureValue, value.m_structureValue)) return false;

            return true;
        }
        
        /// <summary cref="ICloneable.Clone" />
        public override object Clone()
        {
            ScalarValueDataType clone = (ScalarValueDataType)base.Clone();

            clone.m_booleanValue = (bool)Utils.Clone(this.m_booleanValue);
            clone.m_sByteValue = (sbyte)Utils.Clone(this.m_sByteValue);
            clone.m_byteValue = (byte)Utils.Clone(this.m_byteValue);
            clone.m_int16Value = (short)Utils.Clone(this.m_int16Value);
            clone.m_uInt16Value = (ushort)Utils.Clone(this.m_uInt16Value);
            clone.m_int32Value = (int)Utils.Clone(this.m_int32Value);
            clone.m_uInt32Value = (uint)Utils.Clone(this.m_uInt32Value);
            clone.m_int64Value = (long)Utils.Clone(this.m_int64Value);
            clone.m_uInt64Value = (ulong)Utils.Clone(this.m_uInt64Value);
            clone.m_floatValue = (float)Utils.Clone(this.m_floatValue);
            clone.m_doubleValue = (double)Utils.Clone(this.m_doubleValue);
            clone.m_stringValue = (string)Utils.Clone(this.m_stringValue);
            clone.m_dateTimeValue = (DateTime)Utils.Clone(this.m_dateTimeValue);
            clone.m_guidValue = (Uuid)Utils.Clone(this.m_guidValue);
            clone.m_byteStringValue = (byte[])Utils.Clone(this.m_byteStringValue);
            clone.m_xmlElementValue = (XmlElement)Utils.Clone(this.m_xmlElementValue);
            clone.m_nodeIdValue = (NodeId)Utils.Clone(this.m_nodeIdValue);
            clone.m_expandedNodeIdValue = (ExpandedNodeId)Utils.Clone(this.m_expandedNodeIdValue);
            clone.m_qualifiedNameValue = (QualifiedName)Utils.Clone(this.m_qualifiedNameValue);
            clone.m_localizedTextValue = (LocalizedText)Utils.Clone(this.m_localizedTextValue);
            clone.m_statusCodeValue = (StatusCode)Utils.Clone(this.m_statusCodeValue);
            clone.m_variantValue = (Variant)Utils.Clone(this.m_variantValue);
            clone.m_structureValue = (ExtensionObject)Utils.Clone(this.m_structureValue);

            return clone;
        }
        #endregion
        
    	#region Private Fields
    	private bool m_booleanValue;
    	private sbyte m_sByteValue;
    	private byte m_byteValue;
    	private short m_int16Value;
    	private ushort m_uInt16Value;
    	private int m_int32Value;
    	private uint m_uInt32Value;
    	private long m_int64Value;
    	private ulong m_uInt64Value;
    	private float m_floatValue;
    	private double m_doubleValue;
    	private string m_stringValue;
    	private DateTime m_dateTimeValue;
    	private Uuid m_guidValue;
    	private byte[] m_byteStringValue;
    	private XmlElement m_xmlElementValue;
    	private NodeId m_nodeIdValue;
    	private ExpandedNodeId m_expandedNodeIdValue;
    	private QualifiedName m_qualifiedNameValue;
    	private LocalizedText m_localizedTextValue;
    	private StatusCode m_statusCodeValue;
    	private Variant m_variantValue;
    	private ExtensionObject m_structureValue;
    	#endregion
    }
    
    #region ScalarValueDataTypeCollection Class
    /// <summary>
    /// A collection of ScalarValueDataType objects.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfScalarValueDataType", Namespace = Opc.Ua.Sample.Namespaces.Sample, ItemName="ScalarValueDataType")]
    public partial class ScalarValueDataTypeCollection : List<ScalarValueDataType>, ICloneable
    {
    	#region Constructors
    	/// <summary>
    	/// Initializes the collection with default values.
    	/// </summary>
    	public ScalarValueDataTypeCollection() {}
    	
    	/// <summary>
    	/// Initializes the collection with an initial capacity.
    	/// </summary>
    	public ScalarValueDataTypeCollection(int capacity) : base(capacity) {}
    	
    	/// <summary>
    	/// Initializes the collection with another collection.
    	/// </summary>
    	public ScalarValueDataTypeCollection(IEnumerable<ScalarValueDataType> collection) : base(collection) {}
    	#endregion
                    
        #region Static Operators
        /// <summary>
        /// Converts an array to a collection.
        /// </summary>
        public static implicit operator ScalarValueDataTypeCollection(ScalarValueDataType[] values)
        {
            if (values != null)
            {
                return new ScalarValueDataTypeCollection(values);
            }

            return new ScalarValueDataTypeCollection();
        }
        
        /// <summary>
        /// Converts a collection to an array.
        /// </summary>
        public static explicit operator ScalarValueDataType[](ScalarValueDataTypeCollection values)
        {
            if (values != null)
            {
                return values.ToArray();
            }

            return null;
        }
        #endregion

        #region ICloneable Methods
        /// <summary>
        /// Creates a deep copy of the collection.
        /// </summary>
        public object Clone()
        {
            ScalarValueDataTypeCollection clone = new ScalarValueDataTypeCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((ScalarValueDataType)Utils.Clone(this[ii]));
            }

            return clone;
        }
        #endregion
    }
    #endregion
    #endregion
#endif
}
