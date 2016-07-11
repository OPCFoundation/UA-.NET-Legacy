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
    #region Method Identifiers
    /// <summary>
    /// A class that declares constants for all Methods in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Methods
    {
        /// <summary>
        /// The identifier for the LockConditionType_Request Method.
        /// </summary>
        public const uint LockConditionType_Request = 666;

        /// <summary>
        /// The identifier for the LockConditionType_Release Method.
        /// </summary>
        public const uint LockConditionType_Release = 667;

        /// <summary>
        /// The identifier for the LockConditionType_Approve Method.
        /// </summary>
        public const uint LockConditionType_Approve = 668;

        /// <summary>
        /// The identifier for the ChangePhaseMethodType Method.
        /// </summary>
        public const uint ChangePhaseMethodType = 564;

        /// <summary>
        /// The identifier for the RigType_ChangePhase Method.
        /// </summary>
        public const uint RigType_ChangePhase = 566;

        /// <summary>
        /// The identifier for the Rig_ChangePhase Method.
        /// </summary>
        public const uint Rig_ChangePhase = 568;
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
        /// The identifier for the LockStateMachineType_Unlocked Object.
        /// </summary>
        public const uint LockStateMachineType_Unlocked = 582;

        /// <summary>
        /// The identifier for the LockStateMachineType_Locked Object.
        /// </summary>
        public const uint LockStateMachineType_Locked = 584;

        /// <summary>
        /// The identifier for the LockStateMachineType_WaitingForApproval Object.
        /// </summary>
        public const uint LockStateMachineType_WaitingForApproval = 586;

        /// <summary>
        /// The identifier for the LockStateMachineType_UnlockedToLocked Object.
        /// </summary>
        public const uint LockStateMachineType_UnlockedToLocked = 588;

        /// <summary>
        /// The identifier for the LockStateMachineType_UnlockedToWaitingForApproval Object.
        /// </summary>
        public const uint LockStateMachineType_UnlockedToWaitingForApproval = 590;

        /// <summary>
        /// The identifier for the LockStateMachineType_LockedToUnlocked Object.
        /// </summary>
        public const uint LockStateMachineType_LockedToUnlocked = 592;

        /// <summary>
        /// The identifier for the LockStateMachineType_WaitingForApprovalToUnlocked Object.
        /// </summary>
        public const uint LockStateMachineType_WaitingForApprovalToUnlocked = 594;

        /// <summary>
        /// The identifier for the LockStateMachineType_WaitingForApprovalToLocked Object.
        /// </summary>
        public const uint LockStateMachineType_WaitingForApprovalToLocked = 596;

        /// <summary>
        /// The identifier for the LockConditionType_LockState Object.
        /// </summary>
        public const uint LockConditionType_LockState = 638;

        /// <summary>
        /// The identifier for the ToolType_AssetInfo Object.
        /// </summary>
        public const uint ToolType_AssetInfo = 671;

        /// <summary>
        /// The identifier for the ToolType_Measurements Object.
        /// </summary>
        public const uint ToolType_Measurements = 675;

        /// <summary>
        /// The identifier for the ToolType_SetPoints Object.
        /// </summary>
        public const uint ToolType_SetPoints = 676;

        /// <summary>
        /// The identifier for the ToolType_Limits Object.
        /// </summary>
        public const uint ToolType_Limits = 677;

        /// <summary>
        /// The identifier for the ToolType_OperationalLimits Object.
        /// </summary>
        public const uint ToolType_OperationalLimits = 762;

        /// <summary>
        /// The identifier for the ToolType_AccessRules Object.
        /// </summary>
        public const uint ToolType_AccessRules = 678;

        /// <summary>
        /// The identifier for the TopDriveType_Measurements Object.
        /// </summary>
        public const uint TopDriveType_Measurements = 245;

        /// <summary>
        /// The identifier for the TopDriveType_SetPoints Object.
        /// </summary>
        public const uint TopDriveType_SetPoints = 247;

        /// <summary>
        /// The identifier for the TopDriveType_OperationalLimits Object.
        /// </summary>
        public const uint TopDriveType_OperationalLimits = 790;

        /// <summary>
        /// The identifier for the MudPumpType_Measurements Object.
        /// </summary>
        public const uint MudPumpType_Measurements = 263;

        /// <summary>
        /// The identifier for the MudPumpType_SetPoints Object.
        /// </summary>
        public const uint MudPumpType_SetPoints = 265;

        /// <summary>
        /// The identifier for the RigType_Phases Object.
        /// </summary>
        public const uint RigType_Phases = 202;

        /// <summary>
        /// The identifier for the RigType_Locks Object.
        /// </summary>
        public const uint RigType_Locks = 552;

        /// <summary>
        /// The identifier for the RigType_TopDrive Object.
        /// </summary>
        public const uint RigType_TopDrive = 224;

        /// <summary>
        /// The identifier for the RigType_MudPumps Object.
        /// </summary>
        public const uint RigType_MudPumps = 281;

        /// <summary>
        /// The identifier for the Rig Object.
        /// </summary>
        public const uint Rig = 205;

        /// <summary>
        /// The identifier for the Rig_Phases Object.
        /// </summary>
        public const uint Rig_Phases = 206;

        /// <summary>
        /// The identifier for the Rig_Locks Object.
        /// </summary>
        public const uint Rig_Locks = 553;

        /// <summary>
        /// The identifier for the Rig_TopDrive Object.
        /// </summary>
        public const uint Rig_TopDrive = 231;

        /// <summary>
        /// The identifier for the Rig_TopDrive_AssetInfo Object.
        /// </summary>
        public const uint Rig_TopDrive_AssetInfo = 497;

        /// <summary>
        /// The identifier for the Rig_TopDrive_Measurements Object.
        /// </summary>
        public const uint Rig_TopDrive_Measurements = 283;

        /// <summary>
        /// The identifier for the Rig_TopDrive_SetPoints Object.
        /// </summary>
        public const uint Rig_TopDrive_SetPoints = 285;

        /// <summary>
        /// The identifier for the Rig_TopDrive_Limits Object.
        /// </summary>
        public const uint Rig_TopDrive_Limits = 284;

        /// <summary>
        /// The identifier for the Rig_TopDrive_OperationalLimits Object.
        /// </summary>
        public const uint Rig_TopDrive_OperationalLimits = 847;

        /// <summary>
        /// The identifier for the Rig_TopDrive_AccessRules Object.
        /// </summary>
        public const uint Rig_TopDrive_AccessRules = 286;

        /// <summary>
        /// The identifier for the Rig_MudPumps Object.
        /// </summary>
        public const uint Rig_MudPumps = 297;
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
        /// The identifier for the PhaseType ObjectType.
        /// </summary>
        public const uint PhaseType = 199;

        /// <summary>
        /// The identifier for the LockStateMachineType ObjectType.
        /// </summary>
        public const uint LockStateMachineType = 570;

        /// <summary>
        /// The identifier for the LockConditionType ObjectType.
        /// </summary>
        public const uint LockConditionType = 598;

        /// <summary>
        /// The identifier for the AssetInfoFolderType ObjectType.
        /// </summary>
        public const uint AssetInfoFolderType = 328;

        /// <summary>
        /// The identifier for the ToolType ObjectType.
        /// </summary>
        public const uint ToolType = 669;

        /// <summary>
        /// The identifier for the AccessRuleType ObjectType.
        /// </summary>
        public const uint AccessRuleType = 244;

        /// <summary>
        /// The identifier for the TopDriveMeasurementsFolderType ObjectType.
        /// </summary>
        public const uint TopDriveMeasurementsFolderType = 336;

        /// <summary>
        /// The identifier for the TopDriveSetPointsFolderType ObjectType.
        /// </summary>
        public const uint TopDriveSetPointsFolderType = 371;

        /// <summary>
        /// The identifier for the TopDriveOperationalLimitsFolderType ObjectType.
        /// </summary>
        public const uint TopDriveOperationalLimitsFolderType = 763;

        /// <summary>
        /// The identifier for the TopDriveType ObjectType.
        /// </summary>
        public const uint TopDriveType = 217;

        /// <summary>
        /// The identifier for the MudPumpMeasurementsFolderType ObjectType.
        /// </summary>
        public const uint MudPumpMeasurementsFolderType = 679;

        /// <summary>
        /// The identifier for the MudPumpSetPointsFolderType ObjectType.
        /// </summary>
        public const uint MudPumpSetPointsFolderType = 693;

        /// <summary>
        /// The identifier for the MudPumpType ObjectType.
        /// </summary>
        public const uint MudPumpType = 259;

        /// <summary>
        /// The identifier for the RigType ObjectType.
        /// </summary>
        public const uint RigType = 201;
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
        /// The identifier for the HasPhase ReferenceType.
        /// </summary>
        public const uint HasPhase = 242;

        /// <summary>
        /// The identifier for the HasLock ReferenceType.
        /// </summary>
        public const uint HasLock = 551;
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
        /// The identifier for the LockConditionType_EnabledState Variable.
        /// </summary>
        public const uint LockConditionType_EnabledState = 613;

        /// <summary>
        /// The identifier for the LockConditionType_ClientUserId Variable.
        /// </summary>
        public const uint LockConditionType_ClientUserId = 628;

        /// <summary>
        /// The identifier for the LockConditionType_SessionId Variable.
        /// </summary>
        public const uint LockConditionType_SessionId = 635;

        /// <summary>
        /// The identifier for the LockConditionType_SubjectName Variable.
        /// </summary>
        public const uint LockConditionType_SubjectName = 692;

        /// <summary>
        /// The identifier for the LockConditionType_LockState_CurrentState Variable.
        /// </summary>
        public const uint LockConditionType_LockState_CurrentState = 639;

        /// <summary>
        /// The identifier for the LockConditionType_LockState_LastTransition Variable.
        /// </summary>
        public const uint LockConditionType_LockState_LastTransition = 644;

        /// <summary>
        /// The identifier for the LockConditionType_LockState_LastTransition_TransitionTime Variable.
        /// </summary>
        public const uint LockConditionType_LockState_LastTransition_TransitionTime = 648;

        /// <summary>
        /// The identifier for the LockConditionType_LockStateAsString Variable.
        /// </summary>
        public const uint LockConditionType_LockStateAsString = 876;

        /// <summary>
        /// The identifier for the AssetInfoFolderType_Manufacturer Variable.
        /// </summary>
        public const uint AssetInfoFolderType_Manufacturer = 329;

        /// <summary>
        /// The identifier for the AssetInfoFolderType_ModelNumber Variable.
        /// </summary>
        public const uint AssetInfoFolderType_ModelNumber = 330;

        /// <summary>
        /// The identifier for the AssetInfoFolderType_SerialNumber Variable.
        /// </summary>
        public const uint AssetInfoFolderType_SerialNumber = 331;

        /// <summary>
        /// The identifier for the ToolType_Enabled Variable.
        /// </summary>
        public const uint ToolType_Enabled = 670;

        /// <summary>
        /// The identifier for the ToolType_DeviceReady Variable.
        /// </summary>
        public const uint ToolType_DeviceReady = 760;

        /// <summary>
        /// The identifier for the ToolType_LocalControl Variable.
        /// </summary>
        public const uint ToolType_LocalControl = 761;

        /// <summary>
        /// The identifier for the ToolType_WatchdogCounter Variable.
        /// </summary>
        public const uint ToolType_WatchdogCounter = 706;

        /// <summary>
        /// The identifier for the ToolType_ActiveLockId Variable.
        /// </summary>
        public const uint ToolType_ActiveLockId = 711;

        /// <summary>
        /// The identifier for the TopDriveMeasurementsFolderType_RPM Variable.
        /// </summary>
        public const uint TopDriveMeasurementsFolderType_RPM = 337;

        /// <summary>
        /// The identifier for the TopDriveMeasurementsFolderType_Torque Variable.
        /// </summary>
        public const uint TopDriveMeasurementsFolderType_Torque = 343;

        /// <summary>
        /// The identifier for the TopDriveMeasurementsFolderType_Amperes Variable.
        /// </summary>
        public const uint TopDriveMeasurementsFolderType_Amperes = 349;

        /// <summary>
        /// The identifier for the TopDriveMeasurementsFolderType_BrakeStatus Variable.
        /// </summary>
        public const uint TopDriveMeasurementsFolderType_BrakeStatus = 355;

        /// <summary>
        /// The identifier for the TopDriveMeasurementsFolderType_Orientation Variable.
        /// </summary>
        public const uint TopDriveMeasurementsFolderType_Orientation = 360;

        /// <summary>
        /// The identifier for the TopDriveMeasurementsFolderType_IsRotatingClockwise Variable.
        /// </summary>
        public const uint TopDriveMeasurementsFolderType_IsRotatingClockwise = 366;

        /// <summary>
        /// The identifier for the TopDriveSetPointsFolderType_RPM Variable.
        /// </summary>
        public const uint TopDriveSetPointsFolderType_RPM = 372;

        /// <summary>
        /// The identifier for the TopDriveSetPointsFolderType_Torque Variable.
        /// </summary>
        public const uint TopDriveSetPointsFolderType_Torque = 716;

        /// <summary>
        /// The identifier for the TopDriveOperationalLimitsFolderType_MaxRPM Variable.
        /// </summary>
        public const uint TopDriveOperationalLimitsFolderType_MaxRPM = 764;

        /// <summary>
        /// The identifier for the TopDriveOperationalLimitsFolderType_MinRPM Variable.
        /// </summary>
        public const uint TopDriveOperationalLimitsFolderType_MinRPM = 770;

        /// <summary>
        /// The identifier for the TopDriveOperationalLimitsFolderType_MaxTorque Variable.
        /// </summary>
        public const uint TopDriveOperationalLimitsFolderType_MaxTorque = 776;

        /// <summary>
        /// The identifier for the TopDriveOperationalLimitsFolderType_MinTorque Variable.
        /// </summary>
        public const uint TopDriveOperationalLimitsFolderType_MinTorque = 782;

        /// <summary>
        /// The identifier for the MudPumpMeasurementsFolderType_SPM Variable.
        /// </summary>
        public const uint MudPumpMeasurementsFolderType_SPM = 680;

        /// <summary>
        /// The identifier for the MudPumpSetPointsFolderType_SPM Variable.
        /// </summary>
        public const uint MudPumpSetPointsFolderType_SPM = 694;

        /// <summary>
        /// The identifier for the ChangePhaseMethodType_InputArguments Variable.
        /// </summary>
        public const uint ChangePhaseMethodType_InputArguments = 565;

        /// <summary>
        /// The identifier for the RigType_ChangePhase_InputArguments Variable.
        /// </summary>
        public const uint RigType_ChangePhase_InputArguments = 567;

        /// <summary>
        /// The identifier for the RigType_ChangePhaseWithString Variable.
        /// </summary>
        public const uint RigType_ChangePhaseWithString = 877;

        /// <summary>
        /// The identifier for the RigType_CurrentPhase Variable.
        /// </summary>
        public const uint RigType_CurrentPhase = 282;

        /// <summary>
        /// The identifier for the Rig_ChangePhase_InputArguments Variable.
        /// </summary>
        public const uint Rig_ChangePhase_InputArguments = 569;

        /// <summary>
        /// The identifier for the Rig_ChangePhaseWithString Variable.
        /// </summary>
        public const uint Rig_ChangePhaseWithString = 878;

        /// <summary>
        /// The identifier for the Rig_CurrentPhase Variable.
        /// </summary>
        public const uint Rig_CurrentPhase = 298;

        /// <summary>
        /// The identifier for the Rig_TopDrive_Enabled Variable.
        /// </summary>
        public const uint Rig_TopDrive_Enabled = 563;

        /// <summary>
        /// The identifier for the Rig_TopDrive_DeviceReady Variable.
        /// </summary>
        public const uint Rig_TopDrive_DeviceReady = 845;

        /// <summary>
        /// The identifier for the Rig_TopDrive_LocalControl Variable.
        /// </summary>
        public const uint Rig_TopDrive_LocalControl = 846;

        /// <summary>
        /// The identifier for the Rig_TopDrive_WatchdogCounter Variable.
        /// </summary>
        public const uint Rig_TopDrive_WatchdogCounter = 710;

        /// <summary>
        /// The identifier for the Rig_TopDrive_ActiveLockId Variable.
        /// </summary>
        public const uint Rig_TopDrive_ActiveLockId = 715;

        /// <summary>
        /// The identifier for the Rig_TopDrive_AssetInfo_Manufacturer Variable.
        /// </summary>
        public const uint Rig_TopDrive_AssetInfo_Manufacturer = 498;

        /// <summary>
        /// The identifier for the Rig_TopDrive_AssetInfo_ModelNumber Variable.
        /// </summary>
        public const uint Rig_TopDrive_AssetInfo_ModelNumber = 499;

        /// <summary>
        /// The identifier for the Rig_TopDrive_AssetInfo_SerialNumber Variable.
        /// </summary>
        public const uint Rig_TopDrive_AssetInfo_SerialNumber = 500;

        /// <summary>
        /// The identifier for the Rig_TopDrive_Measurements_RPM Variable.
        /// </summary>
        public const uint Rig_TopDrive_Measurements_RPM = 287;

        /// <summary>
        /// The identifier for the Rig_TopDrive_Measurements_RPM_EURange Variable.
        /// </summary>
        public const uint Rig_TopDrive_Measurements_RPM_EURange = 503;

        /// <summary>
        /// The identifier for the Rig_TopDrive_Measurements_Torque Variable.
        /// </summary>
        public const uint Rig_TopDrive_Measurements_Torque = 288;

        /// <summary>
        /// The identifier for the Rig_TopDrive_Measurements_Torque_EURange Variable.
        /// </summary>
        public const uint Rig_TopDrive_Measurements_Torque_EURange = 508;

        /// <summary>
        /// The identifier for the Rig_TopDrive_Measurements_Amperes Variable.
        /// </summary>
        public const uint Rig_TopDrive_Measurements_Amperes = 289;

        /// <summary>
        /// The identifier for the Rig_TopDrive_Measurements_Amperes_EURange Variable.
        /// </summary>
        public const uint Rig_TopDrive_Measurements_Amperes_EURange = 513;

        /// <summary>
        /// The identifier for the Rig_TopDrive_Measurements_BrakeStatus Variable.
        /// </summary>
        public const uint Rig_TopDrive_Measurements_BrakeStatus = 290;

        /// <summary>
        /// The identifier for the Rig_TopDrive_Measurements_BrakeStatus_FalseState Variable.
        /// </summary>
        public const uint Rig_TopDrive_Measurements_BrakeStatus_FalseState = 518;

        /// <summary>
        /// The identifier for the Rig_TopDrive_Measurements_BrakeStatus_TrueState Variable.
        /// </summary>
        public const uint Rig_TopDrive_Measurements_BrakeStatus_TrueState = 519;

        /// <summary>
        /// The identifier for the Rig_TopDrive_Measurements_Orientation Variable.
        /// </summary>
        public const uint Rig_TopDrive_Measurements_Orientation = 291;

        /// <summary>
        /// The identifier for the Rig_TopDrive_Measurements_Orientation_EURange Variable.
        /// </summary>
        public const uint Rig_TopDrive_Measurements_Orientation_EURange = 522;

        /// <summary>
        /// The identifier for the Rig_TopDrive_Measurements_IsRotatingClockwise Variable.
        /// </summary>
        public const uint Rig_TopDrive_Measurements_IsRotatingClockwise = 525;

        /// <summary>
        /// The identifier for the Rig_TopDrive_Measurements_IsRotatingClockwise_FalseState Variable.
        /// </summary>
        public const uint Rig_TopDrive_Measurements_IsRotatingClockwise_FalseState = 528;

        /// <summary>
        /// The identifier for the Rig_TopDrive_Measurements_IsRotatingClockwise_TrueState Variable.
        /// </summary>
        public const uint Rig_TopDrive_Measurements_IsRotatingClockwise_TrueState = 529;

        /// <summary>
        /// The identifier for the Rig_TopDrive_SetPoints_RPM Variable.
        /// </summary>
        public const uint Rig_TopDrive_SetPoints_RPM = 530;

        /// <summary>
        /// The identifier for the Rig_TopDrive_SetPoints_RPM_EURange Variable.
        /// </summary>
        public const uint Rig_TopDrive_SetPoints_RPM_EURange = 533;

        /// <summary>
        /// The identifier for the Rig_TopDrive_SetPoints_Torque Variable.
        /// </summary>
        public const uint Rig_TopDrive_SetPoints_Torque = 734;

        /// <summary>
        /// The identifier for the Rig_TopDrive_SetPoints_Torque_EURange Variable.
        /// </summary>
        public const uint Rig_TopDrive_SetPoints_Torque_EURange = 737;

        /// <summary>
        /// The identifier for the Rig_TopDrive_OperationalLimits_MaxRPM Variable.
        /// </summary>
        public const uint Rig_TopDrive_OperationalLimits_MaxRPM = 848;

        /// <summary>
        /// The identifier for the Rig_TopDrive_OperationalLimits_MaxRPM_EURange Variable.
        /// </summary>
        public const uint Rig_TopDrive_OperationalLimits_MaxRPM_EURange = 851;

        /// <summary>
        /// The identifier for the Rig_TopDrive_OperationalLimits_MinRPM Variable.
        /// </summary>
        public const uint Rig_TopDrive_OperationalLimits_MinRPM = 854;

        /// <summary>
        /// The identifier for the Rig_TopDrive_OperationalLimits_MinRPM_EURange Variable.
        /// </summary>
        public const uint Rig_TopDrive_OperationalLimits_MinRPM_EURange = 857;

        /// <summary>
        /// The identifier for the Rig_TopDrive_OperationalLimits_MaxTorque Variable.
        /// </summary>
        public const uint Rig_TopDrive_OperationalLimits_MaxTorque = 860;

        /// <summary>
        /// The identifier for the Rig_TopDrive_OperationalLimits_MaxTorque_EURange Variable.
        /// </summary>
        public const uint Rig_TopDrive_OperationalLimits_MaxTorque_EURange = 863;

        /// <summary>
        /// The identifier for the Rig_TopDrive_OperationalLimits_MinTorque Variable.
        /// </summary>
        public const uint Rig_TopDrive_OperationalLimits_MinTorque = 866;

        /// <summary>
        /// The identifier for the Rig_TopDrive_OperationalLimits_MinTorque_EURange Variable.
        /// </summary>
        public const uint Rig_TopDrive_OperationalLimits_MinTorque_EURange = 869;
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
        /// The identifier for the LockConditionType_Request Method.
        /// </summary>
        public static readonly ExpandedNodeId LockConditionType_Request = new ExpandedNodeId(DsatsDemo.Methods.LockConditionType_Request, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the LockConditionType_Release Method.
        /// </summary>
        public static readonly ExpandedNodeId LockConditionType_Release = new ExpandedNodeId(DsatsDemo.Methods.LockConditionType_Release, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the LockConditionType_Approve Method.
        /// </summary>
        public static readonly ExpandedNodeId LockConditionType_Approve = new ExpandedNodeId(DsatsDemo.Methods.LockConditionType_Approve, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the ChangePhaseMethodType Method.
        /// </summary>
        public static readonly ExpandedNodeId ChangePhaseMethodType = new ExpandedNodeId(DsatsDemo.Methods.ChangePhaseMethodType, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the RigType_ChangePhase Method.
        /// </summary>
        public static readonly ExpandedNodeId RigType_ChangePhase = new ExpandedNodeId(DsatsDemo.Methods.RigType_ChangePhase, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the Rig_ChangePhase Method.
        /// </summary>
        public static readonly ExpandedNodeId Rig_ChangePhase = new ExpandedNodeId(DsatsDemo.Methods.Rig_ChangePhase, DsatsDemo.Namespaces.DsatsDemo);
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
        /// The identifier for the LockStateMachineType_Unlocked Object.
        /// </summary>
        public static readonly ExpandedNodeId LockStateMachineType_Unlocked = new ExpandedNodeId(DsatsDemo.Objects.LockStateMachineType_Unlocked, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the LockStateMachineType_Locked Object.
        /// </summary>
        public static readonly ExpandedNodeId LockStateMachineType_Locked = new ExpandedNodeId(DsatsDemo.Objects.LockStateMachineType_Locked, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the LockStateMachineType_WaitingForApproval Object.
        /// </summary>
        public static readonly ExpandedNodeId LockStateMachineType_WaitingForApproval = new ExpandedNodeId(DsatsDemo.Objects.LockStateMachineType_WaitingForApproval, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the LockStateMachineType_UnlockedToLocked Object.
        /// </summary>
        public static readonly ExpandedNodeId LockStateMachineType_UnlockedToLocked = new ExpandedNodeId(DsatsDemo.Objects.LockStateMachineType_UnlockedToLocked, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the LockStateMachineType_UnlockedToWaitingForApproval Object.
        /// </summary>
        public static readonly ExpandedNodeId LockStateMachineType_UnlockedToWaitingForApproval = new ExpandedNodeId(DsatsDemo.Objects.LockStateMachineType_UnlockedToWaitingForApproval, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the LockStateMachineType_LockedToUnlocked Object.
        /// </summary>
        public static readonly ExpandedNodeId LockStateMachineType_LockedToUnlocked = new ExpandedNodeId(DsatsDemo.Objects.LockStateMachineType_LockedToUnlocked, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the LockStateMachineType_WaitingForApprovalToUnlocked Object.
        /// </summary>
        public static readonly ExpandedNodeId LockStateMachineType_WaitingForApprovalToUnlocked = new ExpandedNodeId(DsatsDemo.Objects.LockStateMachineType_WaitingForApprovalToUnlocked, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the LockStateMachineType_WaitingForApprovalToLocked Object.
        /// </summary>
        public static readonly ExpandedNodeId LockStateMachineType_WaitingForApprovalToLocked = new ExpandedNodeId(DsatsDemo.Objects.LockStateMachineType_WaitingForApprovalToLocked, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the LockConditionType_LockState Object.
        /// </summary>
        public static readonly ExpandedNodeId LockConditionType_LockState = new ExpandedNodeId(DsatsDemo.Objects.LockConditionType_LockState, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the ToolType_AssetInfo Object.
        /// </summary>
        public static readonly ExpandedNodeId ToolType_AssetInfo = new ExpandedNodeId(DsatsDemo.Objects.ToolType_AssetInfo, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the ToolType_Measurements Object.
        /// </summary>
        public static readonly ExpandedNodeId ToolType_Measurements = new ExpandedNodeId(DsatsDemo.Objects.ToolType_Measurements, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the ToolType_SetPoints Object.
        /// </summary>
        public static readonly ExpandedNodeId ToolType_SetPoints = new ExpandedNodeId(DsatsDemo.Objects.ToolType_SetPoints, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the ToolType_Limits Object.
        /// </summary>
        public static readonly ExpandedNodeId ToolType_Limits = new ExpandedNodeId(DsatsDemo.Objects.ToolType_Limits, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the ToolType_OperationalLimits Object.
        /// </summary>
        public static readonly ExpandedNodeId ToolType_OperationalLimits = new ExpandedNodeId(DsatsDemo.Objects.ToolType_OperationalLimits, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the ToolType_AccessRules Object.
        /// </summary>
        public static readonly ExpandedNodeId ToolType_AccessRules = new ExpandedNodeId(DsatsDemo.Objects.ToolType_AccessRules, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the TopDriveType_Measurements Object.
        /// </summary>
        public static readonly ExpandedNodeId TopDriveType_Measurements = new ExpandedNodeId(DsatsDemo.Objects.TopDriveType_Measurements, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the TopDriveType_SetPoints Object.
        /// </summary>
        public static readonly ExpandedNodeId TopDriveType_SetPoints = new ExpandedNodeId(DsatsDemo.Objects.TopDriveType_SetPoints, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the TopDriveType_OperationalLimits Object.
        /// </summary>
        public static readonly ExpandedNodeId TopDriveType_OperationalLimits = new ExpandedNodeId(DsatsDemo.Objects.TopDriveType_OperationalLimits, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the MudPumpType_Measurements Object.
        /// </summary>
        public static readonly ExpandedNodeId MudPumpType_Measurements = new ExpandedNodeId(DsatsDemo.Objects.MudPumpType_Measurements, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the MudPumpType_SetPoints Object.
        /// </summary>
        public static readonly ExpandedNodeId MudPumpType_SetPoints = new ExpandedNodeId(DsatsDemo.Objects.MudPumpType_SetPoints, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the RigType_Phases Object.
        /// </summary>
        public static readonly ExpandedNodeId RigType_Phases = new ExpandedNodeId(DsatsDemo.Objects.RigType_Phases, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the RigType_Locks Object.
        /// </summary>
        public static readonly ExpandedNodeId RigType_Locks = new ExpandedNodeId(DsatsDemo.Objects.RigType_Locks, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the RigType_TopDrive Object.
        /// </summary>
        public static readonly ExpandedNodeId RigType_TopDrive = new ExpandedNodeId(DsatsDemo.Objects.RigType_TopDrive, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the RigType_MudPumps Object.
        /// </summary>
        public static readonly ExpandedNodeId RigType_MudPumps = new ExpandedNodeId(DsatsDemo.Objects.RigType_MudPumps, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the Rig Object.
        /// </summary>
        public static readonly ExpandedNodeId Rig = new ExpandedNodeId(DsatsDemo.Objects.Rig, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the Rig_Phases Object.
        /// </summary>
        public static readonly ExpandedNodeId Rig_Phases = new ExpandedNodeId(DsatsDemo.Objects.Rig_Phases, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the Rig_Locks Object.
        /// </summary>
        public static readonly ExpandedNodeId Rig_Locks = new ExpandedNodeId(DsatsDemo.Objects.Rig_Locks, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the Rig_TopDrive Object.
        /// </summary>
        public static readonly ExpandedNodeId Rig_TopDrive = new ExpandedNodeId(DsatsDemo.Objects.Rig_TopDrive, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the Rig_TopDrive_AssetInfo Object.
        /// </summary>
        public static readonly ExpandedNodeId Rig_TopDrive_AssetInfo = new ExpandedNodeId(DsatsDemo.Objects.Rig_TopDrive_AssetInfo, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the Rig_TopDrive_Measurements Object.
        /// </summary>
        public static readonly ExpandedNodeId Rig_TopDrive_Measurements = new ExpandedNodeId(DsatsDemo.Objects.Rig_TopDrive_Measurements, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the Rig_TopDrive_SetPoints Object.
        /// </summary>
        public static readonly ExpandedNodeId Rig_TopDrive_SetPoints = new ExpandedNodeId(DsatsDemo.Objects.Rig_TopDrive_SetPoints, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the Rig_TopDrive_Limits Object.
        /// </summary>
        public static readonly ExpandedNodeId Rig_TopDrive_Limits = new ExpandedNodeId(DsatsDemo.Objects.Rig_TopDrive_Limits, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the Rig_TopDrive_OperationalLimits Object.
        /// </summary>
        public static readonly ExpandedNodeId Rig_TopDrive_OperationalLimits = new ExpandedNodeId(DsatsDemo.Objects.Rig_TopDrive_OperationalLimits, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the Rig_TopDrive_AccessRules Object.
        /// </summary>
        public static readonly ExpandedNodeId Rig_TopDrive_AccessRules = new ExpandedNodeId(DsatsDemo.Objects.Rig_TopDrive_AccessRules, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the Rig_MudPumps Object.
        /// </summary>
        public static readonly ExpandedNodeId Rig_MudPumps = new ExpandedNodeId(DsatsDemo.Objects.Rig_MudPumps, DsatsDemo.Namespaces.DsatsDemo);
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
        /// The identifier for the PhaseType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId PhaseType = new ExpandedNodeId(DsatsDemo.ObjectTypes.PhaseType, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the LockStateMachineType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId LockStateMachineType = new ExpandedNodeId(DsatsDemo.ObjectTypes.LockStateMachineType, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the LockConditionType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId LockConditionType = new ExpandedNodeId(DsatsDemo.ObjectTypes.LockConditionType, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the AssetInfoFolderType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId AssetInfoFolderType = new ExpandedNodeId(DsatsDemo.ObjectTypes.AssetInfoFolderType, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the ToolType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId ToolType = new ExpandedNodeId(DsatsDemo.ObjectTypes.ToolType, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the AccessRuleType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId AccessRuleType = new ExpandedNodeId(DsatsDemo.ObjectTypes.AccessRuleType, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the TopDriveMeasurementsFolderType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId TopDriveMeasurementsFolderType = new ExpandedNodeId(DsatsDemo.ObjectTypes.TopDriveMeasurementsFolderType, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the TopDriveSetPointsFolderType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId TopDriveSetPointsFolderType = new ExpandedNodeId(DsatsDemo.ObjectTypes.TopDriveSetPointsFolderType, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the TopDriveOperationalLimitsFolderType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId TopDriveOperationalLimitsFolderType = new ExpandedNodeId(DsatsDemo.ObjectTypes.TopDriveOperationalLimitsFolderType, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the TopDriveType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId TopDriveType = new ExpandedNodeId(DsatsDemo.ObjectTypes.TopDriveType, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the MudPumpMeasurementsFolderType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId MudPumpMeasurementsFolderType = new ExpandedNodeId(DsatsDemo.ObjectTypes.MudPumpMeasurementsFolderType, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the MudPumpSetPointsFolderType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId MudPumpSetPointsFolderType = new ExpandedNodeId(DsatsDemo.ObjectTypes.MudPumpSetPointsFolderType, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the MudPumpType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId MudPumpType = new ExpandedNodeId(DsatsDemo.ObjectTypes.MudPumpType, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the RigType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId RigType = new ExpandedNodeId(DsatsDemo.ObjectTypes.RigType, DsatsDemo.Namespaces.DsatsDemo);
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
        /// The identifier for the HasPhase ReferenceType.
        /// </summary>
        public static readonly ExpandedNodeId HasPhase = new ExpandedNodeId(DsatsDemo.ReferenceTypes.HasPhase, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the HasLock ReferenceType.
        /// </summary>
        public static readonly ExpandedNodeId HasLock = new ExpandedNodeId(DsatsDemo.ReferenceTypes.HasLock, DsatsDemo.Namespaces.DsatsDemo);
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
        /// The identifier for the LockConditionType_EnabledState Variable.
        /// </summary>
        public static readonly ExpandedNodeId LockConditionType_EnabledState = new ExpandedNodeId(DsatsDemo.Variables.LockConditionType_EnabledState, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the LockConditionType_ClientUserId Variable.
        /// </summary>
        public static readonly ExpandedNodeId LockConditionType_ClientUserId = new ExpandedNodeId(DsatsDemo.Variables.LockConditionType_ClientUserId, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the LockConditionType_SessionId Variable.
        /// </summary>
        public static readonly ExpandedNodeId LockConditionType_SessionId = new ExpandedNodeId(DsatsDemo.Variables.LockConditionType_SessionId, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the LockConditionType_SubjectName Variable.
        /// </summary>
        public static readonly ExpandedNodeId LockConditionType_SubjectName = new ExpandedNodeId(DsatsDemo.Variables.LockConditionType_SubjectName, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the LockConditionType_LockState_CurrentState Variable.
        /// </summary>
        public static readonly ExpandedNodeId LockConditionType_LockState_CurrentState = new ExpandedNodeId(DsatsDemo.Variables.LockConditionType_LockState_CurrentState, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the LockConditionType_LockState_LastTransition Variable.
        /// </summary>
        public static readonly ExpandedNodeId LockConditionType_LockState_LastTransition = new ExpandedNodeId(DsatsDemo.Variables.LockConditionType_LockState_LastTransition, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the LockConditionType_LockState_LastTransition_TransitionTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId LockConditionType_LockState_LastTransition_TransitionTime = new ExpandedNodeId(DsatsDemo.Variables.LockConditionType_LockState_LastTransition_TransitionTime, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the LockConditionType_LockStateAsString Variable.
        /// </summary>
        public static readonly ExpandedNodeId LockConditionType_LockStateAsString = new ExpandedNodeId(DsatsDemo.Variables.LockConditionType_LockStateAsString, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the AssetInfoFolderType_Manufacturer Variable.
        /// </summary>
        public static readonly ExpandedNodeId AssetInfoFolderType_Manufacturer = new ExpandedNodeId(DsatsDemo.Variables.AssetInfoFolderType_Manufacturer, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the AssetInfoFolderType_ModelNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId AssetInfoFolderType_ModelNumber = new ExpandedNodeId(DsatsDemo.Variables.AssetInfoFolderType_ModelNumber, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the AssetInfoFolderType_SerialNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId AssetInfoFolderType_SerialNumber = new ExpandedNodeId(DsatsDemo.Variables.AssetInfoFolderType_SerialNumber, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the ToolType_Enabled Variable.
        /// </summary>
        public static readonly ExpandedNodeId ToolType_Enabled = new ExpandedNodeId(DsatsDemo.Variables.ToolType_Enabled, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the ToolType_DeviceReady Variable.
        /// </summary>
        public static readonly ExpandedNodeId ToolType_DeviceReady = new ExpandedNodeId(DsatsDemo.Variables.ToolType_DeviceReady, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the ToolType_LocalControl Variable.
        /// </summary>
        public static readonly ExpandedNodeId ToolType_LocalControl = new ExpandedNodeId(DsatsDemo.Variables.ToolType_LocalControl, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the ToolType_WatchdogCounter Variable.
        /// </summary>
        public static readonly ExpandedNodeId ToolType_WatchdogCounter = new ExpandedNodeId(DsatsDemo.Variables.ToolType_WatchdogCounter, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the ToolType_ActiveLockId Variable.
        /// </summary>
        public static readonly ExpandedNodeId ToolType_ActiveLockId = new ExpandedNodeId(DsatsDemo.Variables.ToolType_ActiveLockId, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the TopDriveMeasurementsFolderType_RPM Variable.
        /// </summary>
        public static readonly ExpandedNodeId TopDriveMeasurementsFolderType_RPM = new ExpandedNodeId(DsatsDemo.Variables.TopDriveMeasurementsFolderType_RPM, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the TopDriveMeasurementsFolderType_Torque Variable.
        /// </summary>
        public static readonly ExpandedNodeId TopDriveMeasurementsFolderType_Torque = new ExpandedNodeId(DsatsDemo.Variables.TopDriveMeasurementsFolderType_Torque, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the TopDriveMeasurementsFolderType_Amperes Variable.
        /// </summary>
        public static readonly ExpandedNodeId TopDriveMeasurementsFolderType_Amperes = new ExpandedNodeId(DsatsDemo.Variables.TopDriveMeasurementsFolderType_Amperes, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the TopDriveMeasurementsFolderType_BrakeStatus Variable.
        /// </summary>
        public static readonly ExpandedNodeId TopDriveMeasurementsFolderType_BrakeStatus = new ExpandedNodeId(DsatsDemo.Variables.TopDriveMeasurementsFolderType_BrakeStatus, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the TopDriveMeasurementsFolderType_Orientation Variable.
        /// </summary>
        public static readonly ExpandedNodeId TopDriveMeasurementsFolderType_Orientation = new ExpandedNodeId(DsatsDemo.Variables.TopDriveMeasurementsFolderType_Orientation, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the TopDriveMeasurementsFolderType_IsRotatingClockwise Variable.
        /// </summary>
        public static readonly ExpandedNodeId TopDriveMeasurementsFolderType_IsRotatingClockwise = new ExpandedNodeId(DsatsDemo.Variables.TopDriveMeasurementsFolderType_IsRotatingClockwise, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the TopDriveSetPointsFolderType_RPM Variable.
        /// </summary>
        public static readonly ExpandedNodeId TopDriveSetPointsFolderType_RPM = new ExpandedNodeId(DsatsDemo.Variables.TopDriveSetPointsFolderType_RPM, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the TopDriveSetPointsFolderType_Torque Variable.
        /// </summary>
        public static readonly ExpandedNodeId TopDriveSetPointsFolderType_Torque = new ExpandedNodeId(DsatsDemo.Variables.TopDriveSetPointsFolderType_Torque, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the TopDriveOperationalLimitsFolderType_MaxRPM Variable.
        /// </summary>
        public static readonly ExpandedNodeId TopDriveOperationalLimitsFolderType_MaxRPM = new ExpandedNodeId(DsatsDemo.Variables.TopDriveOperationalLimitsFolderType_MaxRPM, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the TopDriveOperationalLimitsFolderType_MinRPM Variable.
        /// </summary>
        public static readonly ExpandedNodeId TopDriveOperationalLimitsFolderType_MinRPM = new ExpandedNodeId(DsatsDemo.Variables.TopDriveOperationalLimitsFolderType_MinRPM, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the TopDriveOperationalLimitsFolderType_MaxTorque Variable.
        /// </summary>
        public static readonly ExpandedNodeId TopDriveOperationalLimitsFolderType_MaxTorque = new ExpandedNodeId(DsatsDemo.Variables.TopDriveOperationalLimitsFolderType_MaxTorque, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the TopDriveOperationalLimitsFolderType_MinTorque Variable.
        /// </summary>
        public static readonly ExpandedNodeId TopDriveOperationalLimitsFolderType_MinTorque = new ExpandedNodeId(DsatsDemo.Variables.TopDriveOperationalLimitsFolderType_MinTorque, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the MudPumpMeasurementsFolderType_SPM Variable.
        /// </summary>
        public static readonly ExpandedNodeId MudPumpMeasurementsFolderType_SPM = new ExpandedNodeId(DsatsDemo.Variables.MudPumpMeasurementsFolderType_SPM, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the MudPumpSetPointsFolderType_SPM Variable.
        /// </summary>
        public static readonly ExpandedNodeId MudPumpSetPointsFolderType_SPM = new ExpandedNodeId(DsatsDemo.Variables.MudPumpSetPointsFolderType_SPM, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the ChangePhaseMethodType_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId ChangePhaseMethodType_InputArguments = new ExpandedNodeId(DsatsDemo.Variables.ChangePhaseMethodType_InputArguments, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the RigType_ChangePhase_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId RigType_ChangePhase_InputArguments = new ExpandedNodeId(DsatsDemo.Variables.RigType_ChangePhase_InputArguments, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the RigType_ChangePhaseWithString Variable.
        /// </summary>
        public static readonly ExpandedNodeId RigType_ChangePhaseWithString = new ExpandedNodeId(DsatsDemo.Variables.RigType_ChangePhaseWithString, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the RigType_CurrentPhase Variable.
        /// </summary>
        public static readonly ExpandedNodeId RigType_CurrentPhase = new ExpandedNodeId(DsatsDemo.Variables.RigType_CurrentPhase, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the Rig_ChangePhase_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Rig_ChangePhase_InputArguments = new ExpandedNodeId(DsatsDemo.Variables.Rig_ChangePhase_InputArguments, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the Rig_ChangePhaseWithString Variable.
        /// </summary>
        public static readonly ExpandedNodeId Rig_ChangePhaseWithString = new ExpandedNodeId(DsatsDemo.Variables.Rig_ChangePhaseWithString, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the Rig_CurrentPhase Variable.
        /// </summary>
        public static readonly ExpandedNodeId Rig_CurrentPhase = new ExpandedNodeId(DsatsDemo.Variables.Rig_CurrentPhase, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the Rig_TopDrive_Enabled Variable.
        /// </summary>
        public static readonly ExpandedNodeId Rig_TopDrive_Enabled = new ExpandedNodeId(DsatsDemo.Variables.Rig_TopDrive_Enabled, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the Rig_TopDrive_DeviceReady Variable.
        /// </summary>
        public static readonly ExpandedNodeId Rig_TopDrive_DeviceReady = new ExpandedNodeId(DsatsDemo.Variables.Rig_TopDrive_DeviceReady, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the Rig_TopDrive_LocalControl Variable.
        /// </summary>
        public static readonly ExpandedNodeId Rig_TopDrive_LocalControl = new ExpandedNodeId(DsatsDemo.Variables.Rig_TopDrive_LocalControl, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the Rig_TopDrive_WatchdogCounter Variable.
        /// </summary>
        public static readonly ExpandedNodeId Rig_TopDrive_WatchdogCounter = new ExpandedNodeId(DsatsDemo.Variables.Rig_TopDrive_WatchdogCounter, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the Rig_TopDrive_ActiveLockId Variable.
        /// </summary>
        public static readonly ExpandedNodeId Rig_TopDrive_ActiveLockId = new ExpandedNodeId(DsatsDemo.Variables.Rig_TopDrive_ActiveLockId, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the Rig_TopDrive_AssetInfo_Manufacturer Variable.
        /// </summary>
        public static readonly ExpandedNodeId Rig_TopDrive_AssetInfo_Manufacturer = new ExpandedNodeId(DsatsDemo.Variables.Rig_TopDrive_AssetInfo_Manufacturer, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the Rig_TopDrive_AssetInfo_ModelNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId Rig_TopDrive_AssetInfo_ModelNumber = new ExpandedNodeId(DsatsDemo.Variables.Rig_TopDrive_AssetInfo_ModelNumber, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the Rig_TopDrive_AssetInfo_SerialNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId Rig_TopDrive_AssetInfo_SerialNumber = new ExpandedNodeId(DsatsDemo.Variables.Rig_TopDrive_AssetInfo_SerialNumber, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the Rig_TopDrive_Measurements_RPM Variable.
        /// </summary>
        public static readonly ExpandedNodeId Rig_TopDrive_Measurements_RPM = new ExpandedNodeId(DsatsDemo.Variables.Rig_TopDrive_Measurements_RPM, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the Rig_TopDrive_Measurements_RPM_EURange Variable.
        /// </summary>
        public static readonly ExpandedNodeId Rig_TopDrive_Measurements_RPM_EURange = new ExpandedNodeId(DsatsDemo.Variables.Rig_TopDrive_Measurements_RPM_EURange, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the Rig_TopDrive_Measurements_Torque Variable.
        /// </summary>
        public static readonly ExpandedNodeId Rig_TopDrive_Measurements_Torque = new ExpandedNodeId(DsatsDemo.Variables.Rig_TopDrive_Measurements_Torque, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the Rig_TopDrive_Measurements_Torque_EURange Variable.
        /// </summary>
        public static readonly ExpandedNodeId Rig_TopDrive_Measurements_Torque_EURange = new ExpandedNodeId(DsatsDemo.Variables.Rig_TopDrive_Measurements_Torque_EURange, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the Rig_TopDrive_Measurements_Amperes Variable.
        /// </summary>
        public static readonly ExpandedNodeId Rig_TopDrive_Measurements_Amperes = new ExpandedNodeId(DsatsDemo.Variables.Rig_TopDrive_Measurements_Amperes, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the Rig_TopDrive_Measurements_Amperes_EURange Variable.
        /// </summary>
        public static readonly ExpandedNodeId Rig_TopDrive_Measurements_Amperes_EURange = new ExpandedNodeId(DsatsDemo.Variables.Rig_TopDrive_Measurements_Amperes_EURange, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the Rig_TopDrive_Measurements_BrakeStatus Variable.
        /// </summary>
        public static readonly ExpandedNodeId Rig_TopDrive_Measurements_BrakeStatus = new ExpandedNodeId(DsatsDemo.Variables.Rig_TopDrive_Measurements_BrakeStatus, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the Rig_TopDrive_Measurements_BrakeStatus_FalseState Variable.
        /// </summary>
        public static readonly ExpandedNodeId Rig_TopDrive_Measurements_BrakeStatus_FalseState = new ExpandedNodeId(DsatsDemo.Variables.Rig_TopDrive_Measurements_BrakeStatus_FalseState, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the Rig_TopDrive_Measurements_BrakeStatus_TrueState Variable.
        /// </summary>
        public static readonly ExpandedNodeId Rig_TopDrive_Measurements_BrakeStatus_TrueState = new ExpandedNodeId(DsatsDemo.Variables.Rig_TopDrive_Measurements_BrakeStatus_TrueState, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the Rig_TopDrive_Measurements_Orientation Variable.
        /// </summary>
        public static readonly ExpandedNodeId Rig_TopDrive_Measurements_Orientation = new ExpandedNodeId(DsatsDemo.Variables.Rig_TopDrive_Measurements_Orientation, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the Rig_TopDrive_Measurements_Orientation_EURange Variable.
        /// </summary>
        public static readonly ExpandedNodeId Rig_TopDrive_Measurements_Orientation_EURange = new ExpandedNodeId(DsatsDemo.Variables.Rig_TopDrive_Measurements_Orientation_EURange, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the Rig_TopDrive_Measurements_IsRotatingClockwise Variable.
        /// </summary>
        public static readonly ExpandedNodeId Rig_TopDrive_Measurements_IsRotatingClockwise = new ExpandedNodeId(DsatsDemo.Variables.Rig_TopDrive_Measurements_IsRotatingClockwise, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the Rig_TopDrive_Measurements_IsRotatingClockwise_FalseState Variable.
        /// </summary>
        public static readonly ExpandedNodeId Rig_TopDrive_Measurements_IsRotatingClockwise_FalseState = new ExpandedNodeId(DsatsDemo.Variables.Rig_TopDrive_Measurements_IsRotatingClockwise_FalseState, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the Rig_TopDrive_Measurements_IsRotatingClockwise_TrueState Variable.
        /// </summary>
        public static readonly ExpandedNodeId Rig_TopDrive_Measurements_IsRotatingClockwise_TrueState = new ExpandedNodeId(DsatsDemo.Variables.Rig_TopDrive_Measurements_IsRotatingClockwise_TrueState, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the Rig_TopDrive_SetPoints_RPM Variable.
        /// </summary>
        public static readonly ExpandedNodeId Rig_TopDrive_SetPoints_RPM = new ExpandedNodeId(DsatsDemo.Variables.Rig_TopDrive_SetPoints_RPM, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the Rig_TopDrive_SetPoints_RPM_EURange Variable.
        /// </summary>
        public static readonly ExpandedNodeId Rig_TopDrive_SetPoints_RPM_EURange = new ExpandedNodeId(DsatsDemo.Variables.Rig_TopDrive_SetPoints_RPM_EURange, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the Rig_TopDrive_SetPoints_Torque Variable.
        /// </summary>
        public static readonly ExpandedNodeId Rig_TopDrive_SetPoints_Torque = new ExpandedNodeId(DsatsDemo.Variables.Rig_TopDrive_SetPoints_Torque, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the Rig_TopDrive_SetPoints_Torque_EURange Variable.
        /// </summary>
        public static readonly ExpandedNodeId Rig_TopDrive_SetPoints_Torque_EURange = new ExpandedNodeId(DsatsDemo.Variables.Rig_TopDrive_SetPoints_Torque_EURange, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the Rig_TopDrive_OperationalLimits_MaxRPM Variable.
        /// </summary>
        public static readonly ExpandedNodeId Rig_TopDrive_OperationalLimits_MaxRPM = new ExpandedNodeId(DsatsDemo.Variables.Rig_TopDrive_OperationalLimits_MaxRPM, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the Rig_TopDrive_OperationalLimits_MaxRPM_EURange Variable.
        /// </summary>
        public static readonly ExpandedNodeId Rig_TopDrive_OperationalLimits_MaxRPM_EURange = new ExpandedNodeId(DsatsDemo.Variables.Rig_TopDrive_OperationalLimits_MaxRPM_EURange, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the Rig_TopDrive_OperationalLimits_MinRPM Variable.
        /// </summary>
        public static readonly ExpandedNodeId Rig_TopDrive_OperationalLimits_MinRPM = new ExpandedNodeId(DsatsDemo.Variables.Rig_TopDrive_OperationalLimits_MinRPM, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the Rig_TopDrive_OperationalLimits_MinRPM_EURange Variable.
        /// </summary>
        public static readonly ExpandedNodeId Rig_TopDrive_OperationalLimits_MinRPM_EURange = new ExpandedNodeId(DsatsDemo.Variables.Rig_TopDrive_OperationalLimits_MinRPM_EURange, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the Rig_TopDrive_OperationalLimits_MaxTorque Variable.
        /// </summary>
        public static readonly ExpandedNodeId Rig_TopDrive_OperationalLimits_MaxTorque = new ExpandedNodeId(DsatsDemo.Variables.Rig_TopDrive_OperationalLimits_MaxTorque, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the Rig_TopDrive_OperationalLimits_MaxTorque_EURange Variable.
        /// </summary>
        public static readonly ExpandedNodeId Rig_TopDrive_OperationalLimits_MaxTorque_EURange = new ExpandedNodeId(DsatsDemo.Variables.Rig_TopDrive_OperationalLimits_MaxTorque_EURange, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the Rig_TopDrive_OperationalLimits_MinTorque Variable.
        /// </summary>
        public static readonly ExpandedNodeId Rig_TopDrive_OperationalLimits_MinTorque = new ExpandedNodeId(DsatsDemo.Variables.Rig_TopDrive_OperationalLimits_MinTorque, DsatsDemo.Namespaces.DsatsDemo);

        /// <summary>
        /// The identifier for the Rig_TopDrive_OperationalLimits_MinTorque_EURange Variable.
        /// </summary>
        public static readonly ExpandedNodeId Rig_TopDrive_OperationalLimits_MinTorque_EURange = new ExpandedNodeId(DsatsDemo.Variables.Rig_TopDrive_OperationalLimits_MinTorque_EURange, DsatsDemo.Namespaces.DsatsDemo);
    }
    #endregion

    #region BrowseName Declarations
    /// <summary>
    /// Declares all of the BrowseNames used in the Model Design.
    /// </summary>
    public static partial class BrowseNames
    {
        /// <summary>
        /// The BrowseName for the AccessRules component.
        /// </summary>
        public const string AccessRules = "AccessRules";

        /// <summary>
        /// The BrowseName for the AccessRuleType component.
        /// </summary>
        public const string AccessRuleType = "AccessRuleType";

        /// <summary>
        /// The BrowseName for the ActiveLockId component.
        /// </summary>
        public const string ActiveLockId = "ActiveLockId";

        /// <summary>
        /// The BrowseName for the Amperes component.
        /// </summary>
        public const string Amperes = "Amperes";

        /// <summary>
        /// The BrowseName for the Approve component.
        /// </summary>
        public const string Approve = "Approve";

        /// <summary>
        /// The BrowseName for the AssetInfo component.
        /// </summary>
        public const string AssetInfo = "AssetInfo";

        /// <summary>
        /// The BrowseName for the AssetInfoFolderType component.
        /// </summary>
        public const string AssetInfoFolderType = "AssetInfoFolderType";

        /// <summary>
        /// The BrowseName for the BrakeStatus component.
        /// </summary>
        public const string BrakeStatus = "BrakeStatus";

        /// <summary>
        /// The BrowseName for the ChangePhase component.
        /// </summary>
        public const string ChangePhase = "ChangePhase";

        /// <summary>
        /// The BrowseName for the ChangePhaseMethodType component.
        /// </summary>
        public const string ChangePhaseMethodType = "ChangePhaseMethodType";

        /// <summary>
        /// The BrowseName for the ChangePhaseWithString component.
        /// </summary>
        public const string ChangePhaseWithString = "ChangePhaseWithString";

        /// <summary>
        /// The BrowseName for the ClientUserId component.
        /// </summary>
        public const string ClientUserId = "ClientUserId";

        /// <summary>
        /// The BrowseName for the CurrentPhase component.
        /// </summary>
        public const string CurrentPhase = "CurrentPhase";

        /// <summary>
        /// The BrowseName for the DeviceReady component.
        /// </summary>
        public const string DeviceReady = "DeviceReady";

        /// <summary>
        /// The BrowseName for the Enabled component.
        /// </summary>
        public const string Enabled = "Enabled";

        /// <summary>
        /// The BrowseName for the EnabledState component.
        /// </summary>
        public const string EnabledState = "EnabledState";

        /// <summary>
        /// The BrowseName for the HasLock component.
        /// </summary>
        public const string HasLock = "HasLock";

        /// <summary>
        /// The BrowseName for the HasPhase component.
        /// </summary>
        public const string HasPhase = "HasPhase";

        /// <summary>
        /// The BrowseName for the IsRotatingClockwise component.
        /// </summary>
        public const string IsRotatingClockwise = "IsRotatingClockwise";

        /// <summary>
        /// The BrowseName for the Limits component.
        /// </summary>
        public const string Limits = "Limits";

        /// <summary>
        /// The BrowseName for the LocalControl component.
        /// </summary>
        public const string LocalControl = "LocalControl";

        /// <summary>
        /// The BrowseName for the LockConditionType component.
        /// </summary>
        public const string LockConditionType = "LockConditionType";

        /// <summary>
        /// The BrowseName for the Locked component.
        /// </summary>
        public const string Locked = "Locked";

        /// <summary>
        /// The BrowseName for the LockedToUnlocked component.
        /// </summary>
        public const string LockedToUnlocked = "LockedToUnlocked";

        /// <summary>
        /// The BrowseName for the Locks component.
        /// </summary>
        public const string Locks = "Locks";

        /// <summary>
        /// The BrowseName for the LockState component.
        /// </summary>
        public const string LockState = "LockState";

        /// <summary>
        /// The BrowseName for the LockStateAsString component.
        /// </summary>
        public const string LockStateAsString = "LockStateAsString";

        /// <summary>
        /// The BrowseName for the LockStateMachineType component.
        /// </summary>
        public const string LockStateMachineType = "LockStateMachineType";

        /// <summary>
        /// The BrowseName for the Manufacturer component.
        /// </summary>
        public const string Manufacturer = "Manufacturer";

        /// <summary>
        /// The BrowseName for the MaxRPM component.
        /// </summary>
        public const string MaxRPM = "MaxRPM";

        /// <summary>
        /// The BrowseName for the MaxTorque component.
        /// </summary>
        public const string MaxTorque = "MaxTorque";

        /// <summary>
        /// The BrowseName for the Measurements component.
        /// </summary>
        public const string Measurements = "Measurements";

        /// <summary>
        /// The BrowseName for the MinRPM component.
        /// </summary>
        public const string MinRPM = "MinRPM";

        /// <summary>
        /// The BrowseName for the MinTorque component.
        /// </summary>
        public const string MinTorque = "MinTorque";

        /// <summary>
        /// The BrowseName for the ModelNumber component.
        /// </summary>
        public const string ModelNumber = "ModelNumber";

        /// <summary>
        /// The BrowseName for the MudPumpMeasurementsFolderType component.
        /// </summary>
        public const string MudPumpMeasurementsFolderType = "MudPumpMeasurementsFolderType";

        /// <summary>
        /// The BrowseName for the MudPumps component.
        /// </summary>
        public const string MudPumps = "MudPumps";

        /// <summary>
        /// The BrowseName for the MudPumpSetPointsFolderType component.
        /// </summary>
        public const string MudPumpSetPointsFolderType = "MudPumpSetPointsFolderType";

        /// <summary>
        /// The BrowseName for the MudPumpType component.
        /// </summary>
        public const string MudPumpType = "MudPumpType";

        /// <summary>
        /// The BrowseName for the OperationalLimits component.
        /// </summary>
        public const string OperationalLimits = "OperationalLimits";

        /// <summary>
        /// The BrowseName for the Orientation component.
        /// </summary>
        public const string Orientation = "Orientation";

        /// <summary>
        /// The BrowseName for the Phases component.
        /// </summary>
        public const string Phases = "Phases";

        /// <summary>
        /// The BrowseName for the PhaseType component.
        /// </summary>
        public const string PhaseType = "PhaseType";

        /// <summary>
        /// The BrowseName for the Release component.
        /// </summary>
        public const string Release = "Release";

        /// <summary>
        /// The BrowseName for the Request component.
        /// </summary>
        public const string Request = "Request";

        /// <summary>
        /// The BrowseName for the Rig component.
        /// </summary>
        public const string Rig = "Rig";

        /// <summary>
        /// The BrowseName for the RigType component.
        /// </summary>
        public const string RigType = "RigType";

        /// <summary>
        /// The BrowseName for the RPM component.
        /// </summary>
        public const string RPM = "RPM";

        /// <summary>
        /// The BrowseName for the SerialNumber component.
        /// </summary>
        public const string SerialNumber = "SerialNumber";

        /// <summary>
        /// The BrowseName for the SessionId component.
        /// </summary>
        public const string SessionId = "SessionId";

        /// <summary>
        /// The BrowseName for the SetPoints component.
        /// </summary>
        public const string SetPoints = "SetPoints";

        /// <summary>
        /// The BrowseName for the SPM component.
        /// </summary>
        public const string SPM = "SPM";

        /// <summary>
        /// The BrowseName for the SubjectName component.
        /// </summary>
        public const string SubjectName = "SubjectName";

        /// <summary>
        /// The BrowseName for the ToolType component.
        /// </summary>
        public const string ToolType = "ToolType";

        /// <summary>
        /// The BrowseName for the TopDrive component.
        /// </summary>
        public const string TopDrive = "TopDrive";

        /// <summary>
        /// The BrowseName for the TopDriveMeasurementsFolderType component.
        /// </summary>
        public const string TopDriveMeasurementsFolderType = "TopDriveMeasurementsFolderType";

        /// <summary>
        /// The BrowseName for the TopDriveOperationalLimitsFolderType component.
        /// </summary>
        public const string TopDriveOperationalLimitsFolderType = "TopDriveOperationalLimitsFolderType";

        /// <summary>
        /// The BrowseName for the TopDriveSetPointsFolderType component.
        /// </summary>
        public const string TopDriveSetPointsFolderType = "TopDriveSetPointsFolderType";

        /// <summary>
        /// The BrowseName for the TopDriveType component.
        /// </summary>
        public const string TopDriveType = "TopDriveType";

        /// <summary>
        /// The BrowseName for the Torque component.
        /// </summary>
        public const string Torque = "Torque";

        /// <summary>
        /// The BrowseName for the Unlocked component.
        /// </summary>
        public const string Unlocked = "Unlocked";

        /// <summary>
        /// The BrowseName for the UnlockedToLocked component.
        /// </summary>
        public const string UnlockedToLocked = "UnlockedToLocked";

        /// <summary>
        /// The BrowseName for the UnlockedToWaitingForApproval component.
        /// </summary>
        public const string UnlockedToWaitingForApproval = "UnlockedToWaitingForApproval";

        /// <summary>
        /// The BrowseName for the WaitingForApproval component.
        /// </summary>
        public const string WaitingForApproval = "WaitingForApproval";

        /// <summary>
        /// The BrowseName for the WaitingForApprovalToLocked component.
        /// </summary>
        public const string WaitingForApprovalToLocked = "WaitingForApprovalToLocked";

        /// <summary>
        /// The BrowseName for the WaitingForApprovalToUnlocked component.
        /// </summary>
        public const string WaitingForApprovalToUnlocked = "WaitingForApprovalToUnlocked";

        /// <summary>
        /// The BrowseName for the WatchdogCounter component.
        /// </summary>
        public const string WatchdogCounter = "WatchdogCounter";
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
        /// The URI for the DsatsDemo namespace (.NET code namespace is 'DsatsDemo').
        /// </summary>
        public const string DsatsDemo = "http://opcfoundation.org/DSATSDemo";

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
