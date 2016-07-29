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

namespace FileSystem
{
    #region Method Identifiers
    /// <summary>
    /// A class that declares constants for all Methods in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Methods
    {
        /// <summary>
        /// The identifier for the CreateControllerMethodType Method.
        /// </summary>
        public const uint CreateControllerMethodType = 13;

        /// <summary>
        /// The identifier for the AreaType_CreateController Method.
        /// </summary>
        public const uint AreaType_CreateController = 18;

        /// <summary>
        /// The identifier for the ControllerType_Start Method.
        /// </summary>
        public const uint ControllerType_Start = 38;

        /// <summary>
        /// The identifier for the ControllerType_Stop Method.
        /// </summary>
        public const uint ControllerType_Stop = 39;
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
        /// The identifier for the ControllerEventType ObjectType.
        /// </summary>
        public const uint ControllerEventType = 1;

        /// <summary>
        /// The identifier for the AreaType ObjectType.
        /// </summary>
        public const uint AreaType = 16;

        /// <summary>
        /// The identifier for the ControllerType ObjectType.
        /// </summary>
        public const uint ControllerType = 21;

        /// <summary>
        /// The identifier for the FurnaceControllerType ObjectType.
        /// </summary>
        public const uint FurnaceControllerType = 40;

        /// <summary>
        /// The identifier for the AirConditionerControllerType ObjectType.
        /// </summary>
        public const uint AirConditionerControllerType = 63;
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
        /// The identifier for the ControllerEventType_Temperature Variable.
        /// </summary>
        public const uint ControllerEventType_Temperature = 11;

        /// <summary>
        /// The identifier for the ControllerEventType_State Variable.
        /// </summary>
        public const uint ControllerEventType_State = 12;

        /// <summary>
        /// The identifier for the CreateControllerMethodType_InputArguments Variable.
        /// </summary>
        public const uint CreateControllerMethodType_InputArguments = 14;

        /// <summary>
        /// The identifier for the CreateControllerMethodType_OutputArguments Variable.
        /// </summary>
        public const uint CreateControllerMethodType_OutputArguments = 15;

        /// <summary>
        /// The identifier for the AreaType_LastUpdateTime Variable.
        /// </summary>
        public const uint AreaType_LastUpdateTime = 17;

        /// <summary>
        /// The identifier for the AreaType_CreateController_InputArguments Variable.
        /// </summary>
        public const uint AreaType_CreateController_InputArguments = 19;

        /// <summary>
        /// The identifier for the AreaType_CreateController_OutputArguments Variable.
        /// </summary>
        public const uint AreaType_CreateController_OutputArguments = 20;

        /// <summary>
        /// The identifier for the ControllerType_Temperature Variable.
        /// </summary>
        public const uint ControllerType_Temperature = 22;

        /// <summary>
        /// The identifier for the ControllerType_Temperature_EURange Variable.
        /// </summary>
        public const uint ControllerType_Temperature_EURange = 25;

        /// <summary>
        /// The identifier for the ControllerType_Temperature_EngineeringUnits Variable.
        /// </summary>
        public const uint ControllerType_Temperature_EngineeringUnits = 27;

        /// <summary>
        /// The identifier for the ControllerType_TemperatureSetPoint Variable.
        /// </summary>
        public const uint ControllerType_TemperatureSetPoint = 28;

        /// <summary>
        /// The identifier for the ControllerType_TemperatureSetPoint_EURange Variable.
        /// </summary>
        public const uint ControllerType_TemperatureSetPoint_EURange = 31;

        /// <summary>
        /// The identifier for the ControllerType_State Variable.
        /// </summary>
        public const uint ControllerType_State = 34;

        /// <summary>
        /// The identifier for the ControllerType_PowerConsumption Variable.
        /// </summary>
        public const uint ControllerType_PowerConsumption = 35;

        /// <summary>
        /// The identifier for the FurnaceControllerType_State Variable.
        /// </summary>
        public const uint FurnaceControllerType_State = 53;

        /// <summary>
        /// The identifier for the FurnaceControllerType_State_EnumStrings Variable.
        /// </summary>
        public const uint FurnaceControllerType_State_EnumStrings = 59;

        /// <summary>
        /// The identifier for the FurnaceControllerType_GasFlow Variable.
        /// </summary>
        public const uint FurnaceControllerType_GasFlow = 60;

        /// <summary>
        /// The identifier for the AirConditionerControllerType_State Variable.
        /// </summary>
        public const uint AirConditionerControllerType_State = 76;

        /// <summary>
        /// The identifier for the AirConditionerControllerType_State_EnumStrings Variable.
        /// </summary>
        public const uint AirConditionerControllerType_State_EnumStrings = 82;

        /// <summary>
        /// The identifier for the AirConditionerControllerType_Humidity Variable.
        /// </summary>
        public const uint AirConditionerControllerType_Humidity = 83;

        /// <summary>
        /// The identifier for the AirConditionerControllerType_Humidity_EURange Variable.
        /// </summary>
        public const uint AirConditionerControllerType_Humidity_EURange = 86;

        /// <summary>
        /// The identifier for the AirConditionerControllerType_HumiditySetPoint Variable.
        /// </summary>
        public const uint AirConditionerControllerType_HumiditySetPoint = 89;

        /// <summary>
        /// The identifier for the AirConditionerControllerType_HumiditySetPoint_EURange Variable.
        /// </summary>
        public const uint AirConditionerControllerType_HumiditySetPoint_EURange = 92;
    }
    #endregion

    #region Method Node Identifiers
    /// <summary>
    /// A class that declares constants for all Methods in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class MethodIds
    {
        /// <summary>
        /// The identifier for the CreateControllerMethodType Method.
        /// </summary>
        public static readonly ExpandedNodeId CreateControllerMethodType = new ExpandedNodeId(FileSystem.Methods.CreateControllerMethodType, FileSystem.Namespaces.FileSystem);

        /// <summary>
        /// The identifier for the AreaType_CreateController Method.
        /// </summary>
        public static readonly ExpandedNodeId AreaType_CreateController = new ExpandedNodeId(FileSystem.Methods.AreaType_CreateController, FileSystem.Namespaces.FileSystem);

        /// <summary>
        /// The identifier for the ControllerType_Start Method.
        /// </summary>
        public static readonly ExpandedNodeId ControllerType_Start = new ExpandedNodeId(FileSystem.Methods.ControllerType_Start, FileSystem.Namespaces.FileSystem);

        /// <summary>
        /// The identifier for the ControllerType_Stop Method.
        /// </summary>
        public static readonly ExpandedNodeId ControllerType_Stop = new ExpandedNodeId(FileSystem.Methods.ControllerType_Stop, FileSystem.Namespaces.FileSystem);
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
        /// The identifier for the ControllerEventType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId ControllerEventType = new ExpandedNodeId(FileSystem.ObjectTypes.ControllerEventType, FileSystem.Namespaces.FileSystem);

        /// <summary>
        /// The identifier for the AreaType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId AreaType = new ExpandedNodeId(FileSystem.ObjectTypes.AreaType, FileSystem.Namespaces.FileSystem);

        /// <summary>
        /// The identifier for the ControllerType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId ControllerType = new ExpandedNodeId(FileSystem.ObjectTypes.ControllerType, FileSystem.Namespaces.FileSystem);

        /// <summary>
        /// The identifier for the FurnaceControllerType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId FurnaceControllerType = new ExpandedNodeId(FileSystem.ObjectTypes.FurnaceControllerType, FileSystem.Namespaces.FileSystem);

        /// <summary>
        /// The identifier for the AirConditionerControllerType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId AirConditionerControllerType = new ExpandedNodeId(FileSystem.ObjectTypes.AirConditionerControllerType, FileSystem.Namespaces.FileSystem);
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
        /// The identifier for the ControllerEventType_Temperature Variable.
        /// </summary>
        public static readonly ExpandedNodeId ControllerEventType_Temperature = new ExpandedNodeId(FileSystem.Variables.ControllerEventType_Temperature, FileSystem.Namespaces.FileSystem);

        /// <summary>
        /// The identifier for the ControllerEventType_State Variable.
        /// </summary>
        public static readonly ExpandedNodeId ControllerEventType_State = new ExpandedNodeId(FileSystem.Variables.ControllerEventType_State, FileSystem.Namespaces.FileSystem);

        /// <summary>
        /// The identifier for the CreateControllerMethodType_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CreateControllerMethodType_InputArguments = new ExpandedNodeId(FileSystem.Variables.CreateControllerMethodType_InputArguments, FileSystem.Namespaces.FileSystem);

        /// <summary>
        /// The identifier for the CreateControllerMethodType_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CreateControllerMethodType_OutputArguments = new ExpandedNodeId(FileSystem.Variables.CreateControllerMethodType_OutputArguments, FileSystem.Namespaces.FileSystem);

        /// <summary>
        /// The identifier for the AreaType_LastUpdateTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId AreaType_LastUpdateTime = new ExpandedNodeId(FileSystem.Variables.AreaType_LastUpdateTime, FileSystem.Namespaces.FileSystem);

        /// <summary>
        /// The identifier for the AreaType_CreateController_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId AreaType_CreateController_InputArguments = new ExpandedNodeId(FileSystem.Variables.AreaType_CreateController_InputArguments, FileSystem.Namespaces.FileSystem);

        /// <summary>
        /// The identifier for the AreaType_CreateController_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId AreaType_CreateController_OutputArguments = new ExpandedNodeId(FileSystem.Variables.AreaType_CreateController_OutputArguments, FileSystem.Namespaces.FileSystem);

        /// <summary>
        /// The identifier for the ControllerType_Temperature Variable.
        /// </summary>
        public static readonly ExpandedNodeId ControllerType_Temperature = new ExpandedNodeId(FileSystem.Variables.ControllerType_Temperature, FileSystem.Namespaces.FileSystem);

        /// <summary>
        /// The identifier for the ControllerType_Temperature_EURange Variable.
        /// </summary>
        public static readonly ExpandedNodeId ControllerType_Temperature_EURange = new ExpandedNodeId(FileSystem.Variables.ControllerType_Temperature_EURange, FileSystem.Namespaces.FileSystem);

        /// <summary>
        /// The identifier for the ControllerType_Temperature_EngineeringUnits Variable.
        /// </summary>
        public static readonly ExpandedNodeId ControllerType_Temperature_EngineeringUnits = new ExpandedNodeId(FileSystem.Variables.ControllerType_Temperature_EngineeringUnits, FileSystem.Namespaces.FileSystem);

        /// <summary>
        /// The identifier for the ControllerType_TemperatureSetPoint Variable.
        /// </summary>
        public static readonly ExpandedNodeId ControllerType_TemperatureSetPoint = new ExpandedNodeId(FileSystem.Variables.ControllerType_TemperatureSetPoint, FileSystem.Namespaces.FileSystem);

        /// <summary>
        /// The identifier for the ControllerType_TemperatureSetPoint_EURange Variable.
        /// </summary>
        public static readonly ExpandedNodeId ControllerType_TemperatureSetPoint_EURange = new ExpandedNodeId(FileSystem.Variables.ControllerType_TemperatureSetPoint_EURange, FileSystem.Namespaces.FileSystem);

        /// <summary>
        /// The identifier for the ControllerType_State Variable.
        /// </summary>
        public static readonly ExpandedNodeId ControllerType_State = new ExpandedNodeId(FileSystem.Variables.ControllerType_State, FileSystem.Namespaces.FileSystem);

        /// <summary>
        /// The identifier for the ControllerType_PowerConsumption Variable.
        /// </summary>
        public static readonly ExpandedNodeId ControllerType_PowerConsumption = new ExpandedNodeId(FileSystem.Variables.ControllerType_PowerConsumption, FileSystem.Namespaces.FileSystem);

        /// <summary>
        /// The identifier for the FurnaceControllerType_State Variable.
        /// </summary>
        public static readonly ExpandedNodeId FurnaceControllerType_State = new ExpandedNodeId(FileSystem.Variables.FurnaceControllerType_State, FileSystem.Namespaces.FileSystem);

        /// <summary>
        /// The identifier for the FurnaceControllerType_State_EnumStrings Variable.
        /// </summary>
        public static readonly ExpandedNodeId FurnaceControllerType_State_EnumStrings = new ExpandedNodeId(FileSystem.Variables.FurnaceControllerType_State_EnumStrings, FileSystem.Namespaces.FileSystem);

        /// <summary>
        /// The identifier for the FurnaceControllerType_GasFlow Variable.
        /// </summary>
        public static readonly ExpandedNodeId FurnaceControllerType_GasFlow = new ExpandedNodeId(FileSystem.Variables.FurnaceControllerType_GasFlow, FileSystem.Namespaces.FileSystem);

        /// <summary>
        /// The identifier for the AirConditionerControllerType_State Variable.
        /// </summary>
        public static readonly ExpandedNodeId AirConditionerControllerType_State = new ExpandedNodeId(FileSystem.Variables.AirConditionerControllerType_State, FileSystem.Namespaces.FileSystem);

        /// <summary>
        /// The identifier for the AirConditionerControllerType_State_EnumStrings Variable.
        /// </summary>
        public static readonly ExpandedNodeId AirConditionerControllerType_State_EnumStrings = new ExpandedNodeId(FileSystem.Variables.AirConditionerControllerType_State_EnumStrings, FileSystem.Namespaces.FileSystem);

        /// <summary>
        /// The identifier for the AirConditionerControllerType_Humidity Variable.
        /// </summary>
        public static readonly ExpandedNodeId AirConditionerControllerType_Humidity = new ExpandedNodeId(FileSystem.Variables.AirConditionerControllerType_Humidity, FileSystem.Namespaces.FileSystem);

        /// <summary>
        /// The identifier for the AirConditionerControllerType_Humidity_EURange Variable.
        /// </summary>
        public static readonly ExpandedNodeId AirConditionerControllerType_Humidity_EURange = new ExpandedNodeId(FileSystem.Variables.AirConditionerControllerType_Humidity_EURange, FileSystem.Namespaces.FileSystem);

        /// <summary>
        /// The identifier for the AirConditionerControllerType_HumiditySetPoint Variable.
        /// </summary>
        public static readonly ExpandedNodeId AirConditionerControllerType_HumiditySetPoint = new ExpandedNodeId(FileSystem.Variables.AirConditionerControllerType_HumiditySetPoint, FileSystem.Namespaces.FileSystem);

        /// <summary>
        /// The identifier for the AirConditionerControllerType_HumiditySetPoint_EURange Variable.
        /// </summary>
        public static readonly ExpandedNodeId AirConditionerControllerType_HumiditySetPoint_EURange = new ExpandedNodeId(FileSystem.Variables.AirConditionerControllerType_HumiditySetPoint_EURange, FileSystem.Namespaces.FileSystem);
    }
    #endregion

    #region BrowseName Declarations
    /// <summary>
    /// Declares all of the BrowseNames used in the Model Design.
    /// </summary>
    public static partial class BrowseNames
    {
        /// <summary>
        /// The BrowseName for the AirConditionerControllerType component.
        /// </summary>
        public const string AirConditionerControllerType = "AirConditionerControllerType";

        /// <summary>
        /// The BrowseName for the AreaType component.
        /// </summary>
        public const string AreaType = "AreaType";

        /// <summary>
        /// The BrowseName for the ControllerEventType component.
        /// </summary>
        public const string ControllerEventType = "ControllerEventType";

        /// <summary>
        /// The BrowseName for the ControllerType component.
        /// </summary>
        public const string ControllerType = "ControllerType";

        /// <summary>
        /// The BrowseName for the CreateController component.
        /// </summary>
        public const string CreateController = "CreateController";

        /// <summary>
        /// The BrowseName for the CreateControllerMethodType component.
        /// </summary>
        public const string CreateControllerMethodType = "CreateControllerMethodType";

        /// <summary>
        /// The BrowseName for the FurnaceControllerType component.
        /// </summary>
        public const string FurnaceControllerType = "FurnaceControllerType";

        /// <summary>
        /// The BrowseName for the GasFlow component.
        /// </summary>
        public const string GasFlow = "GasFlow";

        /// <summary>
        /// The BrowseName for the Humidity component.
        /// </summary>
        public const string Humidity = "Humidity";

        /// <summary>
        /// The BrowseName for the HumiditySetPoint component.
        /// </summary>
        public const string HumiditySetPoint = "HumiditySetPoint";

        /// <summary>
        /// The BrowseName for the LastUpdateTime component.
        /// </summary>
        public const string LastUpdateTime = "LastUpdateTime";

        /// <summary>
        /// The BrowseName for the PowerConsumption component.
        /// </summary>
        public const string PowerConsumption = "PowerConsumption";

        /// <summary>
        /// The BrowseName for the Start component.
        /// </summary>
        public const string Start = "Start";

        /// <summary>
        /// The BrowseName for the State component.
        /// </summary>
        public const string State = "State";

        /// <summary>
        /// The BrowseName for the Stop component.
        /// </summary>
        public const string Stop = "Stop";

        /// <summary>
        /// The BrowseName for the Temperature component.
        /// </summary>
        public const string Temperature = "Temperature";

        /// <summary>
        /// The BrowseName for the TemperatureSetPoint component.
        /// </summary>
        public const string TemperatureSetPoint = "TemperatureSetPoint";
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
        /// The URI for the FileSystem namespace (.NET code namespace is 'FileSystem').
        /// </summary>
        public const string FileSystem = "http://tempuri.org/UA/FileSystem/";
    }
    #endregion

    #region ControllerEventState Class
    #if (!OPCUA_EXCLUDE_ControllerEventState)
    /// <summary>
    /// Stores an instance of the ControllerEventType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class ControllerEventState : BaseEventState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public ControllerEventState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(FileSystem.ObjectTypes.ControllerEventType, FileSystem.Namespaces.FileSystem, namespaceUris);
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
           "AQAAACEAAABodHRwOi8vdGVtcHVyaS5vcmcvVUEvRmlsZVN5c3RlbS//////BGCAAAEAAAABABsAAABD" +
           "b250cm9sbGVyRXZlbnRUeXBlSW5zdGFuY2UBAQEAAQEBAP////8LAAAANWCJCgIAAAAAAAcAAABFdmVu" +
           "dElkAQECAAMAAAAAKwAAAEEgZ2xvYmFsbHkgdW5pcXVlIGlkZW50aWZpZXIgZm9yIHRoZSBldmVudC4A" +
           "LgBEAgAAAAAP/////wEB/////wAAAAA1YIkKAgAAAAAACQAAAEV2ZW50VHlwZQEBAwADAAAAACIAAABU" +
           "aGUgaWRlbnRpZmllciBmb3IgdGhlIGV2ZW50IHR5cGUuAC4ARAMAAAAAEf////8BAf////8AAAAANWCJ" +
           "CgIAAAAAAAoAAABTb3VyY2VOb2RlAQEEAAMAAAAAGAAAAFRoZSBzb3VyY2Ugb2YgdGhlIGV2ZW50LgAu" +
           "AEQEAAAAABH/////AQH/////AAAAADVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEBBQADAAAAACkAAABB" +
           "IGRlc2NyaXB0aW9uIG9mIHRoZSBzb3VyY2Ugb2YgdGhlIGV2ZW50LgAuAEQFAAAAAAz/////AQH/////" +
           "AAAAADVgiQoCAAAAAAAEAAAAVGltZQEBBgADAAAAABgAAABXaGVuIHRoZSBldmVudCBvY2N1cnJlZC4A" +
           "LgBEBgAAAAEAJgH/////AQH/////AAAAADVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBAQcAAwAAAAA+" +
           "AAAAV2hlbiB0aGUgc2VydmVyIHJlY2VpdmVkIHRoZSBldmVudCBmcm9tIHRoZSB1bmRlcmx5aW5nIHN5" +
           "c3RlbS4ALgBEBwAAAAEAJgH/////AQH/////AAAAADVgiQoCAAAAAAAJAAAATG9jYWxUaW1lAQEIAAMA" +
           "AAAAPAAAAEluZm9ybWF0aW9uIGFib3V0IHRoZSBsb2NhbCB0aW1lIHdoZXJlIHRoZSBldmVudCBvcmln" +
           "aW5hdGVkLgAuAEQIAAAAAQDQIv////8BAf////8AAAAANWCJCgIAAAAAAAcAAABNZXNzYWdlAQEJAAMA" +
           "AAAAJQAAAEEgbG9jYWxpemVkIGRlc2NyaXB0aW9uIG9mIHRoZSBldmVudC4ALgBECQAAAAAV/////wEB" +
           "/////wAAAAA1YIkKAgAAAAAACAAAAFNldmVyaXR5AQEKAAMAAAAAIQAAAEluZGljYXRlcyBob3cgdXJn" +
           "ZW50IGFuIGV2ZW50IGlzLgAuAEQKAAAAAAX/////AQH/////AAAAABVgiQoCAAAAAQALAAAAVGVtcGVy" +
           "YXR1cmUBAQsAAC4ARAsAAAAAC/////8BAf////8AAAAAFWCJCgIAAAABAAUAAABTdGF0ZQEBDAAALgBE" +
           "DAAAAAAG/////wMD/////wAAAAA=";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// A description for the Temperature Property.
        /// </summary>
        public PropertyState<double> Temperature
        {
            get
            {
                return m_temperature;
            }

            set
            {
                if (!Object.ReferenceEquals(m_temperature, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_temperature = value;
            }
        }

        /// <summary>
        /// A description for the State Property.
        /// </summary>
        public PropertyState<int> State
        {
            get
            {
                return m_state;
            }

            set
            {
                if (!Object.ReferenceEquals(m_state, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_state = value;
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
            if (m_temperature != null)
            {
                children.Add(m_temperature);
            }

            if (m_state != null)
            {
                children.Add(m_state);
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
                case FileSystem.BrowseNames.Temperature:
                {
                    if (createOrReplace)
                    {
                        if (Temperature == null)
                        {
                            if (replacement == null)
                            {
                                Temperature = new PropertyState<double>(this);
                            }
                            else
                            {
                                Temperature = (PropertyState<double>)replacement;
                            }
                        }
                    }

                    instance = Temperature;
                    break;
                }

                case FileSystem.BrowseNames.State:
                {
                    if (createOrReplace)
                    {
                        if (State == null)
                        {
                            if (replacement == null)
                            {
                                State = new PropertyState<int>(this);
                            }
                            else
                            {
                                State = (PropertyState<int>)replacement;
                            }
                        }
                    }

                    instance = State;
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
        private PropertyState<double> m_temperature;
        private PropertyState<int> m_state;
        #endregion
    }
    #endif
    #endregion

    #region CreateControllerMethodState Class
    #if (!OPCUA_EXCLUDE_CreateControllerMethodState)
    /// <summary>
    /// Stores an instance of the CreateControllerMethodType Method.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class CreateControllerMethodState : MethodState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public CreateControllerMethodState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Constructs an instance of a node.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <returns>The new node.</returns>
        public new static NodeState Construct(NodeState parent)
        {
            return new CreateControllerMethodState(parent);
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
           "AQAAACEAAABodHRwOi8vdGVtcHVyaS5vcmcvVUEvRmlsZVN5c3RlbS//////BGGCCgQAAAABABoAAABD" +
           "cmVhdGVDb250cm9sbGVyTWV0aG9kVHlwZQEBDQAALwEBDQANAAAAAQH/////AgAAABVgqQoCAAAAAAAO" +
           "AAAASW5wdXRBcmd1bWVudHMBAQ4AAC4ARA4AAACWAQAAAAEAKgEBQAAAAAQAAABOYW1lAAz/////AAAA" +
           "AAMAAAAAJQAAAFRoZSBuYW1lIG9mIHRoZSBjb250cm9sbGVyIHRvIGNyZWF0ZS4BACgBAQAAAAEB////" +
           "/wAAAAAVYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEBDwAALgBEDwAAAJYBAAAAAQAqAQFLAAAA" +
           "BgAAAE5vZGVJZAAR/////wAAAAADAAAAAC4AAABUaGUgTm9kZUlkIGZvciB0aGUgY29udHJvbGxlciB0" +
           "aGF0IHdhcyBjcmVhdGVkAQAoAQEAAAABAf////8AAAAA";
        #endregion
        #endif
        #endregion

        #region Event Callbacks
        /// <summary>
        /// Raised when the the method is called.
        /// </summary>
        public CreateControllerMethodStateMethodCallHandler OnCall;
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

            string name = (string)inputArguments[0];

            NodeId nodeId = (NodeId)outputArguments[0];

            if (OnCall != null)
            {
                result = OnCall(
                    context,
                    this,
                    objectId,
                    name,
                    ref nodeId);
            }

            outputArguments[0] = nodeId;

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
    public delegate ServiceResult CreateControllerMethodStateMethodCallHandler(
        ISystemContext context,
        MethodState method,
        NodeId objectId,
        string name,
        ref NodeId nodeId);
    #endif
    #endregion

    #region AreaState Class
    #if (!OPCUA_EXCLUDE_AreaState)
    /// <summary>
    /// Stores an instance of the AreaType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class AreaState : FolderState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public AreaState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(FileSystem.ObjectTypes.AreaType, FileSystem.Namespaces.FileSystem, namespaceUris);
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
           "AQAAACEAAABodHRwOi8vdGVtcHVyaS5vcmcvVUEvRmlsZVN5c3RlbS//////BGCAAAEAAAABABAAAABB" +
           "cmVhVHlwZUluc3RhbmNlAQEQAAEBEAD/////AgAAABVgiQoCAAAAAQAOAAAATGFzdFVwZGF0ZVRpbWUB" +
           "AREAAC4ARBEAAAAADf////8BAf////8AAAAABGGCCgQAAAABABAAAABDcmVhdGVDb250cm9sbGVyAQES" +
           "AAAvAQESABIAAAABAf////8CAAAAFWCpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEBEwAALgBEEwAA" +
           "AJYBAAAAAQAqAQFAAAAABAAAAE5hbWUADP////8AAAAAAwAAAAAlAAAAVGhlIG5hbWUgb2YgdGhlIGNv" +
           "bnRyb2xsZXIgdG8gY3JlYXRlLgEAKAEBAAAAAQH/////AAAAABVgqQoCAAAAAAAPAAAAT3V0cHV0QXJn" +
           "dW1lbnRzAQEUAAAuAEQUAAAAlgEAAAABACoBAUsAAAAGAAAATm9kZUlkABH/////AAAAAAMAAAAALgAA" +
           "AFRoZSBOb2RlSWQgZm9yIHRoZSBjb250cm9sbGVyIHRoYXQgd2FzIGNyZWF0ZWQBACgBAQAAAAEB////" +
           "/wAAAAA=";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// A description for the LastUpdateTime Property.
        /// </summary>
        public PropertyState<DateTime> LastUpdateTime
        {
            get
            {
                return m_lastUpdateTime;
            }

            set
            {
                if (!Object.ReferenceEquals(m_lastUpdateTime, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_lastUpdateTime = value;
            }
        }

        /// <summary>
        /// A description for the CreateControllerMethodType Method.
        /// </summary>
        public CreateControllerMethodState CreateController
        {
            get
            {
                return m_createControllerMethod;
            }

            set
            {
                if (!Object.ReferenceEquals(m_createControllerMethod, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_createControllerMethod = value;
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
            if (m_lastUpdateTime != null)
            {
                children.Add(m_lastUpdateTime);
            }

            if (m_createControllerMethod != null)
            {
                children.Add(m_createControllerMethod);
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
                case FileSystem.BrowseNames.LastUpdateTime:
                {
                    if (createOrReplace)
                    {
                        if (LastUpdateTime == null)
                        {
                            if (replacement == null)
                            {
                                LastUpdateTime = new PropertyState<DateTime>(this);
                            }
                            else
                            {
                                LastUpdateTime = (PropertyState<DateTime>)replacement;
                            }
                        }
                    }

                    instance = LastUpdateTime;
                    break;
                }

                case FileSystem.BrowseNames.CreateController:
                {
                    if (createOrReplace)
                    {
                        if (CreateController == null)
                        {
                            if (replacement == null)
                            {
                                CreateController = new CreateControllerMethodState(this);
                            }
                            else
                            {
                                CreateController = (CreateControllerMethodState)replacement;
                            }
                        }
                    }

                    instance = CreateController;
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
        private PropertyState<DateTime> m_lastUpdateTime;
        private CreateControllerMethodState m_createControllerMethod;
        #endregion
    }
    #endif
    #endregion

    #region ControllerState Class
    #if (!OPCUA_EXCLUDE_ControllerState)
    /// <summary>
    /// Stores an instance of the ControllerType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class ControllerState : BaseObjectState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public ControllerState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(FileSystem.ObjectTypes.ControllerType, FileSystem.Namespaces.FileSystem, namespaceUris);
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
           "AQAAACEAAABodHRwOi8vdGVtcHVyaS5vcmcvVUEvRmlsZVN5c3RlbS//////BGCAAAEAAAABABYAAABD" +
           "b250cm9sbGVyVHlwZUluc3RhbmNlAQEVAAEBFQABAAAAACkAAQEBAAYAAAAVYIkKAgAAAAEACwAAAFRl" +
           "bXBlcmF0dXJlAQEWAAAvAQBACRYAAAAAC/////8BAf////8CAAAAFWCpCgIAAAAAAAcAAABFVVJhbmdl" +
           "AQEZAAAuAEQZAAAAFgEAdgMBEAAAAAAAAAAAAD7AAAAAAAAAREABAHQD/////wEB/////wAAAAAVYKkK" +
           "AgAAAAAAEAAAAEVuZ2luZWVyaW5nVW5pdHMBARsAAC4ARBsAAAAWAQB5AwE+AAAAIQAAAGh0dHA6Ly90" +
           "ZW1wdXJpLm9yZy9VQS9GaWxlU3lzdGVtLwEAAAACAQAAAEMCCgAAAENlbnRpZ3JhZGUBAHcD/////wEB" +
           "/////wAAAAAVYIkKAgAAAAEAEwAAAFRlbXBlcmF0dXJlU2V0UG9pbnQBARwAAC8BAEAJHAAAAAAL////" +
           "/wMD/////wEAAAAVYIkKAgAAAAAABwAAAEVVUmFuZ2UBAR8AAC4ARB8AAAABAHQD/////wEB/////wAA" +
           "AAAVYIkKAgAAAAEABQAAAFN0YXRlAQEiAAAvAD8iAAAAAAb/////AQH/////AAAAABVgiQoCAAAAAQAQ" +
           "AAAAUG93ZXJDb25zdW1wdGlvbgEBIwAALwEAPQkjAAAAAAv/////AQH/////AAAAAARhggoEAAAAAQAF" +
           "AAAAU3RhcnQBASYAAC8BASYAJgAAAAEB/////wAAAAAEYYIKBAAAAAEABAAAAFN0b3ABAScAAC8BAScA" +
           "JwAAAAEB/////wAAAAA=";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// A description for the Temperature Variable.
        /// </summary>
        public AnalogItemState<double> Temperature
        {
            get
            {
                return m_temperature;
            }

            set
            {
                if (!Object.ReferenceEquals(m_temperature, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_temperature = value;
            }
        }

        /// <summary>
        /// A description for the TemperatureSetPoint Variable.
        /// </summary>
        public AnalogItemState<double> TemperatureSetPoint
        {
            get
            {
                return m_temperatureSetPoint;
            }

            set
            {
                if (!Object.ReferenceEquals(m_temperatureSetPoint, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_temperatureSetPoint = value;
            }
        }

        /// <summary>
        /// A description for the State Variable.
        /// </summary>
        public BaseDataVariableState<int> State
        {
            get
            {
                return m_state;
            }

            set
            {
                if (!Object.ReferenceEquals(m_state, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_state = value;
            }
        }

        /// <summary>
        /// A description for the PowerConsumption Variable.
        /// </summary>
        public DataItemState<double> PowerConsumption
        {
            get
            {
                return m_powerConsumption;
            }

            set
            {
                if (!Object.ReferenceEquals(m_powerConsumption, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_powerConsumption = value;
            }
        }

        /// <summary>
        /// A description for the Start Method.
        /// </summary>
        public MethodState Start
        {
            get
            {
                return m_startMethod;
            }

            set
            {
                if (!Object.ReferenceEquals(m_startMethod, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_startMethod = value;
            }
        }

        /// <summary>
        /// A description for the Stop Method.
        /// </summary>
        public MethodState Stop
        {
            get
            {
                return m_stopMethod;
            }

            set
            {
                if (!Object.ReferenceEquals(m_stopMethod, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_stopMethod = value;
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
            if (m_temperature != null)
            {
                children.Add(m_temperature);
            }

            if (m_temperatureSetPoint != null)
            {
                children.Add(m_temperatureSetPoint);
            }

            if (m_state != null)
            {
                children.Add(m_state);
            }

            if (m_powerConsumption != null)
            {
                children.Add(m_powerConsumption);
            }

            if (m_startMethod != null)
            {
                children.Add(m_startMethod);
            }

            if (m_stopMethod != null)
            {
                children.Add(m_stopMethod);
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
                case FileSystem.BrowseNames.Temperature:
                {
                    if (createOrReplace)
                    {
                        if (Temperature == null)
                        {
                            if (replacement == null)
                            {
                                Temperature = new AnalogItemState<double>(this);
                            }
                            else
                            {
                                Temperature = (AnalogItemState<double>)replacement;
                            }
                        }
                    }

                    instance = Temperature;
                    break;
                }

                case FileSystem.BrowseNames.TemperatureSetPoint:
                {
                    if (createOrReplace)
                    {
                        if (TemperatureSetPoint == null)
                        {
                            if (replacement == null)
                            {
                                TemperatureSetPoint = new AnalogItemState<double>(this);
                            }
                            else
                            {
                                TemperatureSetPoint = (AnalogItemState<double>)replacement;
                            }
                        }
                    }

                    instance = TemperatureSetPoint;
                    break;
                }

                case FileSystem.BrowseNames.State:
                {
                    if (createOrReplace)
                    {
                        if (State == null)
                        {
                            if (replacement == null)
                            {
                                State = new BaseDataVariableState<int>(this);
                            }
                            else
                            {
                                State = (BaseDataVariableState<int>)replacement;
                            }
                        }
                    }

                    instance = State;
                    break;
                }

                case FileSystem.BrowseNames.PowerConsumption:
                {
                    if (createOrReplace)
                    {
                        if (PowerConsumption == null)
                        {
                            if (replacement == null)
                            {
                                PowerConsumption = new DataItemState<double>(this);
                            }
                            else
                            {
                                PowerConsumption = (DataItemState<double>)replacement;
                            }
                        }
                    }

                    instance = PowerConsumption;
                    break;
                }

                case FileSystem.BrowseNames.Start:
                {
                    if (createOrReplace)
                    {
                        if (Start == null)
                        {
                            if (replacement == null)
                            {
                                Start = new MethodState(this);
                            }
                            else
                            {
                                Start = (MethodState)replacement;
                            }
                        }
                    }

                    instance = Start;
                    break;
                }

                case FileSystem.BrowseNames.Stop:
                {
                    if (createOrReplace)
                    {
                        if (Stop == null)
                        {
                            if (replacement == null)
                            {
                                Stop = new MethodState(this);
                            }
                            else
                            {
                                Stop = (MethodState)replacement;
                            }
                        }
                    }

                    instance = Stop;
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
        private AnalogItemState<double> m_temperature;
        private AnalogItemState<double> m_temperatureSetPoint;
        private BaseDataVariableState<int> m_state;
        private DataItemState<double> m_powerConsumption;
        private MethodState m_startMethod;
        private MethodState m_stopMethod;
        #endregion
    }
    #endif
    #endregion

    #region FurnaceControllerState Class
    #if (!OPCUA_EXCLUDE_FurnaceControllerState)
    /// <summary>
    /// Stores an instance of the FurnaceControllerType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class FurnaceControllerState : ControllerState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public FurnaceControllerState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(FileSystem.ObjectTypes.FurnaceControllerType, FileSystem.Namespaces.FileSystem, namespaceUris);
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
           "AQAAACEAAABodHRwOi8vdGVtcHVyaS5vcmcvVUEvRmlsZVN5c3RlbS//////BGCAAAEAAAABAB0AAABG" +
           "dXJuYWNlQ29udHJvbGxlclR5cGVJbnN0YW5jZQEBKAABASgAAQAAAAApAAEBAQAHAAAAFWCJCgIAAAAB" +
           "AAsAAABUZW1wZXJhdHVyZQEBKQAALwEAQAkpAAAAAAv/////AQH/////AQAAABVgqQoCAAAAAAAHAAAA" +
           "RVVSYW5nZQEBLAAALgBELAAAABYBAHYDARAAAAAAAAAAAAA+wAAAAAAAAERAAQB0A/////8BAf////8A" +
           "AAAAFWCJCgIAAAABABMAAABUZW1wZXJhdHVyZVNldFBvaW50AQEvAAAvAQBACS8AAAAAC/////8DA///" +
           "//8BAAAAFWCJCgIAAAAAAAcAAABFVVJhbmdlAQEyAAAuAEQyAAAAAQB0A/////8BAf////8AAAAAFWCJ" +
           "CgIAAAABAAUAAABTdGF0ZQEBNQAALwA/NQAAAAAG/////wEB/////wEAAAAVYKkKAgAAAAAACwAAAEVu" +
           "dW1TdHJpbmdzAQE7AAAuAEQ7AAAAlQIAAAACBwAAAEhlYXRpbmcCAwAAAE9mZgAYAQAAAAEB/////wAA" +
           "AAAVYIkKAgAAAAEAEAAAAFBvd2VyQ29uc3VtcHRpb24BATYAAC8BAD0JNgAAAAAL/////wEB/////wAA" +
           "AAAEYYIKBAAAAAEABQAAAFN0YXJ0AQE5AAAvAQEmADkAAAABAf////8AAAAABGGCCgQAAAABAAQAAABT" +
           "dG9wAQE6AAAvAQEnADoAAAABAf////8AAAAAFWCJCgIAAAABAAcAAABHYXNGbG93AQE8AAAvAQA9CTwA" +
           "AAAAC/////8BAf////8AAAAA";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// A description for the GasFlow Variable.
        /// </summary>
        public DataItemState<double> GasFlow
        {
            get
            {
                return m_gasFlow;
            }

            set
            {
                if (!Object.ReferenceEquals(m_gasFlow, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_gasFlow = value;
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
            if (m_gasFlow != null)
            {
                children.Add(m_gasFlow);
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
                case FileSystem.BrowseNames.GasFlow:
                {
                    if (createOrReplace)
                    {
                        if (GasFlow == null)
                        {
                            if (replacement == null)
                            {
                                GasFlow = new DataItemState<double>(this);
                            }
                            else
                            {
                                GasFlow = (DataItemState<double>)replacement;
                            }
                        }
                    }

                    instance = GasFlow;
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
        private DataItemState<double> m_gasFlow;
        #endregion
    }
    #endif
    #endregion

    #region AirConditionerControllerState Class
    #if (!OPCUA_EXCLUDE_AirConditionerControllerState)
    /// <summary>
    /// Stores an instance of the AirConditionerControllerType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class AirConditionerControllerState : ControllerState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public AirConditionerControllerState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(FileSystem.ObjectTypes.AirConditionerControllerType, FileSystem.Namespaces.FileSystem, namespaceUris);
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
           "AQAAACEAAABodHRwOi8vdGVtcHVyaS5vcmcvVUEvRmlsZVN5c3RlbS//////BGCAAAEAAAABACQAAABB" +
           "aXJDb25kaXRpb25lckNvbnRyb2xsZXJUeXBlSW5zdGFuY2UBAT8AAQE/AAEAAAAAKQABAQEACAAAABVg" +
           "iQoCAAAAAQALAAAAVGVtcGVyYXR1cmUBAUAAAC8BAEAJQAAAAAAL/////wEB/////wEAAAAVYKkKAgAA" +
           "AAAABwAAAEVVUmFuZ2UBAUMAAC4AREMAAAAWAQB2AwEQAAAAAAAAAAAAPsAAAAAAAABEQAEAdAP/////" +
           "AQH/////AAAAABVgiQoCAAAAAQATAAAAVGVtcGVyYXR1cmVTZXRQb2ludAEBRgAALwEAQAlGAAAAAAv/" +
           "////AwP/////AQAAABVgiQoCAAAAAAAHAAAARVVSYW5nZQEBSQAALgBESQAAAAEAdAP/////AQH/////" +
           "AAAAABVgiQoCAAAAAQAFAAAAU3RhdGUBAUwAAC8AP0wAAAAABv////8BAf////8BAAAAFWCpCgIAAAAA" +
           "AAsAAABFbnVtU3RyaW5ncwEBUgAALgBEUgAAAJUCAAAAAgcAAABDb29saW5nAgMAAABPZmYAGAEAAAAB" +
           "Af////8AAAAAFWCJCgIAAAABABAAAABQb3dlckNvbnN1bXB0aW9uAQFNAAAvAQA9CU0AAAAAC/////8B" +
           "Af////8AAAAABGGCCgQAAAABAAUAAABTdGFydAEBUAAALwEBJgBQAAAAAQH/////AAAAAARhggoEAAAA" +
           "AQAEAAAAU3RvcAEBUQAALwEBJwBRAAAAAQH/////AAAAABVgiQoCAAAAAQAIAAAASHVtaWRpdHkBAVMA" +
           "AC8BAEAJUwAAAAAL/////wEB/////wEAAAAVYIkKAgAAAAAABwAAAEVVUmFuZ2UBAVYAAC4ARFYAAAAB" +
           "AHQD/////wEB/////wAAAAAVYIkKAgAAAAEAEAAAAEh1bWlkaXR5U2V0UG9pbnQBAVkAAC8BAEAJWQAA" +
           "AAAL/////wMD/////wEAAAAVYIkKAgAAAAAABwAAAEVVUmFuZ2UBAVwAAC4ARFwAAAABAHQD/////wEB" +
           "/////wAAAAA=";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// A description for the Humidity Variable.
        /// </summary>
        public AnalogItemState<double> Humidity
        {
            get
            {
                return m_humidity;
            }

            set
            {
                if (!Object.ReferenceEquals(m_humidity, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_humidity = value;
            }
        }

        /// <summary>
        /// A description for the HumiditySetPoint Variable.
        /// </summary>
        public AnalogItemState<double> HumiditySetPoint
        {
            get
            {
                return m_humiditySetPoint;
            }

            set
            {
                if (!Object.ReferenceEquals(m_humiditySetPoint, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_humiditySetPoint = value;
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
            if (m_humidity != null)
            {
                children.Add(m_humidity);
            }

            if (m_humiditySetPoint != null)
            {
                children.Add(m_humiditySetPoint);
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
                case FileSystem.BrowseNames.Humidity:
                {
                    if (createOrReplace)
                    {
                        if (Humidity == null)
                        {
                            if (replacement == null)
                            {
                                Humidity = new AnalogItemState<double>(this);
                            }
                            else
                            {
                                Humidity = (AnalogItemState<double>)replacement;
                            }
                        }
                    }

                    instance = Humidity;
                    break;
                }

                case FileSystem.BrowseNames.HumiditySetPoint:
                {
                    if (createOrReplace)
                    {
                        if (HumiditySetPoint == null)
                        {
                            if (replacement == null)
                            {
                                HumiditySetPoint = new AnalogItemState<double>(this);
                            }
                            else
                            {
                                HumiditySetPoint = (AnalogItemState<double>)replacement;
                            }
                        }
                    }

                    instance = HumiditySetPoint;
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
        private AnalogItemState<double> m_humidity;
        private AnalogItemState<double> m_humiditySetPoint;
        #endregion
    }
    #endif
    #endregion
}