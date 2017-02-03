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

namespace Opc.Ua.Gds
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
        /// The identifier for the ApplicationRecordDataType DataType.
        /// </summary>
        public const uint ApplicationRecordDataType = 1;
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
        /// The identifier for the OPCUAGDSNamespaceMetadata_NamespaceFile_Open Method.
        /// </summary>
        public const uint OPCUAGDSNamespaceMetadata_NamespaceFile_Open = 735;

        /// <summary>
        /// The identifier for the OPCUAGDSNamespaceMetadata_NamespaceFile_Close Method.
        /// </summary>
        public const uint OPCUAGDSNamespaceMetadata_NamespaceFile_Close = 738;

        /// <summary>
        /// The identifier for the OPCUAGDSNamespaceMetadata_NamespaceFile_Read Method.
        /// </summary>
        public const uint OPCUAGDSNamespaceMetadata_NamespaceFile_Read = 740;

        /// <summary>
        /// The identifier for the OPCUAGDSNamespaceMetadata_NamespaceFile_Write Method.
        /// </summary>
        public const uint OPCUAGDSNamespaceMetadata_NamespaceFile_Write = 743;

        /// <summary>
        /// The identifier for the OPCUAGDSNamespaceMetadata_NamespaceFile_GetPosition Method.
        /// </summary>
        public const uint OPCUAGDSNamespaceMetadata_NamespaceFile_GetPosition = 745;

        /// <summary>
        /// The identifier for the OPCUAGDSNamespaceMetadata_NamespaceFile_SetPosition Method.
        /// </summary>
        public const uint OPCUAGDSNamespaceMetadata_NamespaceFile_SetPosition = 748;

        /// <summary>
        /// The identifier for the DirectoryType_FindApplications Method.
        /// </summary>
        public const uint DirectoryType_FindApplications = 15;

        /// <summary>
        /// The identifier for the DirectoryType_RegisterApplication Method.
        /// </summary>
        public const uint DirectoryType_RegisterApplication = 18;

        /// <summary>
        /// The identifier for the DirectoryType_UpdateApplication Method.
        /// </summary>
        public const uint DirectoryType_UpdateApplication = 188;

        /// <summary>
        /// The identifier for the DirectoryType_UnregisterApplication Method.
        /// </summary>
        public const uint DirectoryType_UnregisterApplication = 21;

        /// <summary>
        /// The identifier for the DirectoryType_GetApplication Method.
        /// </summary>
        public const uint DirectoryType_GetApplication = 210;

        /// <summary>
        /// The identifier for the DirectoryType_QueryServers Method.
        /// </summary>
        public const uint DirectoryType_QueryServers = 23;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_Open Method.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_Open = 519;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_Close Method.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_Close = 522;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_Read Method.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_Read = 524;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_Write Method.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_Write = 527;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_GetPosition Method.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_GetPosition = 529;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_SetPosition Method.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_SetPosition = 532;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_OpenWithMasks Method.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_OpenWithMasks = 535;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_Open Method.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_Open = 553;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_Close Method.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_Close = 556;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_Read Method.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_Read = 558;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_Write Method.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_Write = 561;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_GetPosition Method.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_GetPosition = 563;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_SetPosition Method.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_SetPosition = 566;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_OpenWithMasks Method.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_OpenWithMasks = 569;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_Open Method.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_Open = 587;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_Close Method.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_Close = 590;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_Read Method.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_Read = 592;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_Write Method.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_Write = 595;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_GetPosition Method.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_GetPosition = 597;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_SetPosition Method.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_SetPosition = 600;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_OpenWithMasks Method.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_OpenWithMasks = 603;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_StartSigningRequest Method.
        /// </summary>
        public const uint CertificateDirectoryType_StartSigningRequest = 79;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_StartNewKeyPairRequest Method.
        /// </summary>
        public const uint CertificateDirectoryType_StartNewKeyPairRequest = 76;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_FinishRequest Method.
        /// </summary>
        public const uint CertificateDirectoryType_FinishRequest = 85;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_GetCertificateGroups Method.
        /// </summary>
        public const uint CertificateDirectoryType_GetCertificateGroups = 369;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_GetTrustList Method.
        /// </summary>
        public const uint CertificateDirectoryType_GetTrustList = 197;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_GetCertificateStatus Method.
        /// </summary>
        public const uint CertificateDirectoryType_GetCertificateStatus = 222;

        /// <summary>
        /// The identifier for the Directory_FindApplications Method.
        /// </summary>
        public const uint Directory_FindApplications = 143;

        /// <summary>
        /// The identifier for the Directory_RegisterApplication Method.
        /// </summary>
        public const uint Directory_RegisterApplication = 146;

        /// <summary>
        /// The identifier for the Directory_UpdateApplication Method.
        /// </summary>
        public const uint Directory_UpdateApplication = 200;

        /// <summary>
        /// The identifier for the Directory_UnregisterApplication Method.
        /// </summary>
        public const uint Directory_UnregisterApplication = 149;

        /// <summary>
        /// The identifier for the Directory_GetApplication Method.
        /// </summary>
        public const uint Directory_GetApplication = 216;

        /// <summary>
        /// The identifier for the Directory_QueryServers Method.
        /// </summary>
        public const uint Directory_QueryServers = 151;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList_Open Method.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultApplicationGroup_TrustList_Open = 622;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList_Close Method.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultApplicationGroup_TrustList_Close = 625;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList_Read Method.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultApplicationGroup_TrustList_Read = 627;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList_Write Method.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultApplicationGroup_TrustList_Write = 630;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList_GetPosition Method.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultApplicationGroup_TrustList_GetPosition = 632;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList_SetPosition Method.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultApplicationGroup_TrustList_SetPosition = 635;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList_OpenWithMasks Method.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultApplicationGroup_TrustList_OpenWithMasks = 638;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList_CloseAndUpdate Method.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultApplicationGroup_TrustList_CloseAndUpdate = 641;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList_AddCertificate Method.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultApplicationGroup_TrustList_AddCertificate = 644;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList_RemoveCertificate Method.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultApplicationGroup_TrustList_RemoveCertificate = 646;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList_Open Method.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultHttpsGroup_TrustList_Open = 656;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList_Close Method.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultHttpsGroup_TrustList_Close = 659;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList_Read Method.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultHttpsGroup_TrustList_Read = 661;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList_Write Method.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultHttpsGroup_TrustList_Write = 664;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList_GetPosition Method.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultHttpsGroup_TrustList_GetPosition = 666;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList_SetPosition Method.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultHttpsGroup_TrustList_SetPosition = 669;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList_OpenWithMasks Method.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultHttpsGroup_TrustList_OpenWithMasks = 672;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList_CloseAndUpdate Method.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultHttpsGroup_TrustList_CloseAndUpdate = 675;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList_AddCertificate Method.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultHttpsGroup_TrustList_AddCertificate = 678;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList_RemoveCertificate Method.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultHttpsGroup_TrustList_RemoveCertificate = 680;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_Open Method.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_Open = 690;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_Close Method.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_Close = 693;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_Read Method.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_Read = 695;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_Write Method.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_Write = 698;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_GetPosition Method.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_GetPosition = 700;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_SetPosition Method.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_SetPosition = 703;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_OpenWithMasks Method.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_OpenWithMasks = 706;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_CloseAndUpdate Method.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_CloseAndUpdate = 709;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_AddCertificate Method.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_AddCertificate = 712;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_RemoveCertificate Method.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_RemoveCertificate = 714;

        /// <summary>
        /// The identifier for the Directory_StartSigningRequest Method.
        /// </summary>
        public const uint Directory_StartSigningRequest = 157;

        /// <summary>
        /// The identifier for the Directory_StartNewKeyPairRequest Method.
        /// </summary>
        public const uint Directory_StartNewKeyPairRequest = 154;

        /// <summary>
        /// The identifier for the Directory_FinishRequest Method.
        /// </summary>
        public const uint Directory_FinishRequest = 163;

        /// <summary>
        /// The identifier for the Directory_GetCertificateGroups Method.
        /// </summary>
        public const uint Directory_GetCertificateGroups = 508;

        /// <summary>
        /// The identifier for the Directory_GetTrustList Method.
        /// </summary>
        public const uint Directory_GetTrustList = 204;

        /// <summary>
        /// The identifier for the Directory_GetCertificateStatus Method.
        /// </summary>
        public const uint Directory_GetCertificateStatus = 225;

        /// <summary>
        /// The identifier for the NetworkServiceFolderType_ServiceName_Placeholder_StartCredentialRequest Method.
        /// </summary>
        public const uint NetworkServiceFolderType_ServiceName_Placeholder_StartCredentialRequest = 867;

        /// <summary>
        /// The identifier for the NetworkServiceFolderType_ServiceName_Placeholder_FinishCredentialRequest Method.
        /// </summary>
        public const uint NetworkServiceFolderType_ServiceName_Placeholder_FinishCredentialRequest = 870;

        /// <summary>
        /// The identifier for the AuthorizationServices_ServiceName_Placeholder_StartCredentialRequest Method.
        /// </summary>
        public const uint AuthorizationServices_ServiceName_Placeholder_StartCredentialRequest = 877;

        /// <summary>
        /// The identifier for the AuthorizationServices_ServiceName_Placeholder_FinishCredentialRequest Method.
        /// </summary>
        public const uint AuthorizationServices_ServiceName_Placeholder_FinishCredentialRequest = 880;

        /// <summary>
        /// The identifier for the CredentialManagementType_StartCredentialRequest Method.
        /// </summary>
        public const uint CredentialManagementType_StartCredentialRequest = 786;

        /// <summary>
        /// The identifier for the CredentialManagementType_FinishCredentialRequest Method.
        /// </summary>
        public const uint CredentialManagementType_FinishCredentialRequest = 789;

        /// <summary>
        /// The identifier for the CredentialManagementType_RevokeCredential Method.
        /// </summary>
        public const uint CredentialManagementType_RevokeCredential = 792;

        /// <summary>
        /// The identifier for the NetworkServiceType_CredentialManagement_StartCredentialRequest Method.
        /// </summary>
        public const uint NetworkServiceType_CredentialManagement_StartCredentialRequest = 890;

        /// <summary>
        /// The identifier for the NetworkServiceType_CredentialManagement_FinishCredentialRequest Method.
        /// </summary>
        public const uint NetworkServiceType_CredentialManagement_FinishCredentialRequest = 893;

        /// <summary>
        /// The identifier for the AuthorizationServiceType_CredentialManagement_StartCredentialRequest Method.
        /// </summary>
        public const uint AuthorizationServiceType_CredentialManagement_StartCredentialRequest = 903;

        /// <summary>
        /// The identifier for the AuthorizationServiceType_CredentialManagement_FinishCredentialRequest Method.
        /// </summary>
        public const uint AuthorizationServiceType_CredentialManagement_FinishCredentialRequest = 906;

        /// <summary>
        /// The identifier for the AuthorizationServiceType_RequestAccessToken Method.
        /// </summary>
        public const uint AuthorizationServiceType_RequestAccessToken = 912;
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
        /// The identifier for the OPCUAGDSNamespaceMetadata Object.
        /// </summary>
        public const uint OPCUAGDSNamespaceMetadata = 721;

        /// <summary>
        /// The identifier for the DirectoryType_Applications Object.
        /// </summary>
        public const uint DirectoryType_Applications = 14;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups Object.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups = 511;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup Object.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup = 512;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList Object.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList = 513;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList Object.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList = 547;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList Object.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList = 581;

        /// <summary>
        /// The identifier for the Directory Object.
        /// </summary>
        public const uint Directory = 141;

        /// <summary>
        /// The identifier for the Directory_Applications Object.
        /// </summary>
        public const uint Directory_Applications = 142;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups Object.
        /// </summary>
        public const uint Directory_CertificateGroups = 614;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup Object.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultApplicationGroup = 615;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList Object.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultApplicationGroup_TrustList = 616;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup Object.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultHttpsGroup = 649;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList Object.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultHttpsGroup_TrustList = 650;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup Object.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultUserTokenGroup = 683;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList Object.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultUserTokenGroup_TrustList = 684;

        /// <summary>
        /// The identifier for the NetworkServiceFolderType_ServiceName_Placeholder Object.
        /// </summary>
        public const uint NetworkServiceFolderType_ServiceName_Placeholder = 866;

        /// <summary>
        /// The identifier for the AuthorizationServices Object.
        /// </summary>
        public const uint AuthorizationServices = 875;

        /// <summary>
        /// The identifier for the NetworkServiceType_CredentialManagement Object.
        /// </summary>
        public const uint NetworkServiceType_CredentialManagement = 889;

        /// <summary>
        /// The identifier for the ApplicationRecordDataType_Encoding_DefaultXml Object.
        /// </summary>
        public const uint ApplicationRecordDataType_Encoding_DefaultXml = 127;

        /// <summary>
        /// The identifier for the ApplicationRecordDataType_Encoding_DefaultBinary Object.
        /// </summary>
        public const uint ApplicationRecordDataType_Encoding_DefaultBinary = 134;
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
        /// The identifier for the DirectoryType ObjectType.
        /// </summary>
        public const uint DirectoryType = 13;

        /// <summary>
        /// The identifier for the ApplicationRegistrationChangedAuditEventType ObjectType.
        /// </summary>
        public const uint ApplicationRegistrationChangedAuditEventType = 26;

        /// <summary>
        /// The identifier for the CertificateDirectoryType ObjectType.
        /// </summary>
        public const uint CertificateDirectoryType = 63;

        /// <summary>
        /// The identifier for the CertificateRequestedAuditEventType ObjectType.
        /// </summary>
        public const uint CertificateRequestedAuditEventType = 91;

        /// <summary>
        /// The identifier for the CertificateDeliveredAuditEventType ObjectType.
        /// </summary>
        public const uint CertificateDeliveredAuditEventType = 109;

        /// <summary>
        /// The identifier for the NetworkServiceFolderType ObjectType.
        /// </summary>
        public const uint NetworkServiceFolderType = 865;

        /// <summary>
        /// The identifier for the CredentialManagementType ObjectType.
        /// </summary>
        public const uint CredentialManagementType = 783;

        /// <summary>
        /// The identifier for the NetworkServiceType ObjectType.
        /// </summary>
        public const uint NetworkServiceType = 885;

        /// <summary>
        /// The identifier for the AuthorizationServiceType ObjectType.
        /// </summary>
        public const uint AuthorizationServiceType = 898;

        /// <summary>
        /// The identifier for the CredentialRequestedAuditEventType ObjectType.
        /// </summary>
        public const uint CredentialRequestedAuditEventType = 808;

        /// <summary>
        /// The identifier for the CredentialDeliveredAuditEventType ObjectType.
        /// </summary>
        public const uint CredentialDeliveredAuditEventType = 826;

        /// <summary>
        /// The identifier for the CredentialRevokedAuditEventType ObjectType.
        /// </summary>
        public const uint CredentialRevokedAuditEventType = 844;
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
        /// The identifier for the OPCUAGDSNamespaceMetadata_NamespaceUri Variable.
        /// </summary>
        public const uint OPCUAGDSNamespaceMetadata_NamespaceUri = 722;

        /// <summary>
        /// The identifier for the OPCUAGDSNamespaceMetadata_NamespaceVersion Variable.
        /// </summary>
        public const uint OPCUAGDSNamespaceMetadata_NamespaceVersion = 723;

        /// <summary>
        /// The identifier for the OPCUAGDSNamespaceMetadata_NamespacePublicationDate Variable.
        /// </summary>
        public const uint OPCUAGDSNamespaceMetadata_NamespacePublicationDate = 724;

        /// <summary>
        /// The identifier for the OPCUAGDSNamespaceMetadata_IsNamespaceSubset Variable.
        /// </summary>
        public const uint OPCUAGDSNamespaceMetadata_IsNamespaceSubset = 725;

        /// <summary>
        /// The identifier for the OPCUAGDSNamespaceMetadata_StaticNodeIdTypes Variable.
        /// </summary>
        public const uint OPCUAGDSNamespaceMetadata_StaticNodeIdTypes = 726;

        /// <summary>
        /// The identifier for the OPCUAGDSNamespaceMetadata_StaticNumericNodeIdRange Variable.
        /// </summary>
        public const uint OPCUAGDSNamespaceMetadata_StaticNumericNodeIdRange = 727;

        /// <summary>
        /// The identifier for the OPCUAGDSNamespaceMetadata_StaticStringNodeIdPattern Variable.
        /// </summary>
        public const uint OPCUAGDSNamespaceMetadata_StaticStringNodeIdPattern = 728;

        /// <summary>
        /// The identifier for the OPCUAGDSNamespaceMetadata_NamespaceFile_Size Variable.
        /// </summary>
        public const uint OPCUAGDSNamespaceMetadata_NamespaceFile_Size = 730;

        /// <summary>
        /// The identifier for the OPCUAGDSNamespaceMetadata_NamespaceFile_Writable Variable.
        /// </summary>
        public const uint OPCUAGDSNamespaceMetadata_NamespaceFile_Writable = 731;

        /// <summary>
        /// The identifier for the OPCUAGDSNamespaceMetadata_NamespaceFile_UserWritable Variable.
        /// </summary>
        public const uint OPCUAGDSNamespaceMetadata_NamespaceFile_UserWritable = 732;

        /// <summary>
        /// The identifier for the OPCUAGDSNamespaceMetadata_NamespaceFile_OpenCount Variable.
        /// </summary>
        public const uint OPCUAGDSNamespaceMetadata_NamespaceFile_OpenCount = 733;

        /// <summary>
        /// The identifier for the OPCUAGDSNamespaceMetadata_NamespaceFile_Open_InputArguments Variable.
        /// </summary>
        public const uint OPCUAGDSNamespaceMetadata_NamespaceFile_Open_InputArguments = 736;

        /// <summary>
        /// The identifier for the OPCUAGDSNamespaceMetadata_NamespaceFile_Open_OutputArguments Variable.
        /// </summary>
        public const uint OPCUAGDSNamespaceMetadata_NamespaceFile_Open_OutputArguments = 737;

        /// <summary>
        /// The identifier for the OPCUAGDSNamespaceMetadata_NamespaceFile_Close_InputArguments Variable.
        /// </summary>
        public const uint OPCUAGDSNamespaceMetadata_NamespaceFile_Close_InputArguments = 739;

        /// <summary>
        /// The identifier for the OPCUAGDSNamespaceMetadata_NamespaceFile_Read_InputArguments Variable.
        /// </summary>
        public const uint OPCUAGDSNamespaceMetadata_NamespaceFile_Read_InputArguments = 741;

        /// <summary>
        /// The identifier for the OPCUAGDSNamespaceMetadata_NamespaceFile_Read_OutputArguments Variable.
        /// </summary>
        public const uint OPCUAGDSNamespaceMetadata_NamespaceFile_Read_OutputArguments = 742;

        /// <summary>
        /// The identifier for the OPCUAGDSNamespaceMetadata_NamespaceFile_Write_InputArguments Variable.
        /// </summary>
        public const uint OPCUAGDSNamespaceMetadata_NamespaceFile_Write_InputArguments = 744;

        /// <summary>
        /// The identifier for the OPCUAGDSNamespaceMetadata_NamespaceFile_GetPosition_InputArguments Variable.
        /// </summary>
        public const uint OPCUAGDSNamespaceMetadata_NamespaceFile_GetPosition_InputArguments = 746;

        /// <summary>
        /// The identifier for the OPCUAGDSNamespaceMetadata_NamespaceFile_GetPosition_OutputArguments Variable.
        /// </summary>
        public const uint OPCUAGDSNamespaceMetadata_NamespaceFile_GetPosition_OutputArguments = 747;

        /// <summary>
        /// The identifier for the OPCUAGDSNamespaceMetadata_NamespaceFile_SetPosition_InputArguments Variable.
        /// </summary>
        public const uint OPCUAGDSNamespaceMetadata_NamespaceFile_SetPosition_InputArguments = 749;

        /// <summary>
        /// The identifier for the OPCUAGDSNamespaceMetadata_DefaultRolePermissions Variable.
        /// </summary>
        public const uint OPCUAGDSNamespaceMetadata_DefaultRolePermissions = 862;

        /// <summary>
        /// The identifier for the OPCUAGDSNamespaceMetadata_DefaultUserRolePermissions Variable.
        /// </summary>
        public const uint OPCUAGDSNamespaceMetadata_DefaultUserRolePermissions = 863;

        /// <summary>
        /// The identifier for the OPCUAGDSNamespaceMetadata_DefaultAccessRestrictions Variable.
        /// </summary>
        public const uint OPCUAGDSNamespaceMetadata_DefaultAccessRestrictions = 864;

        /// <summary>
        /// The identifier for the DirectoryType_FindApplications_InputArguments Variable.
        /// </summary>
        public const uint DirectoryType_FindApplications_InputArguments = 16;

        /// <summary>
        /// The identifier for the DirectoryType_FindApplications_OutputArguments Variable.
        /// </summary>
        public const uint DirectoryType_FindApplications_OutputArguments = 17;

        /// <summary>
        /// The identifier for the DirectoryType_RegisterApplication_InputArguments Variable.
        /// </summary>
        public const uint DirectoryType_RegisterApplication_InputArguments = 19;

        /// <summary>
        /// The identifier for the DirectoryType_RegisterApplication_OutputArguments Variable.
        /// </summary>
        public const uint DirectoryType_RegisterApplication_OutputArguments = 20;

        /// <summary>
        /// The identifier for the DirectoryType_UpdateApplication_InputArguments Variable.
        /// </summary>
        public const uint DirectoryType_UpdateApplication_InputArguments = 189;

        /// <summary>
        /// The identifier for the DirectoryType_UnregisterApplication_InputArguments Variable.
        /// </summary>
        public const uint DirectoryType_UnregisterApplication_InputArguments = 22;

        /// <summary>
        /// The identifier for the DirectoryType_GetApplication_InputArguments Variable.
        /// </summary>
        public const uint DirectoryType_GetApplication_InputArguments = 211;

        /// <summary>
        /// The identifier for the DirectoryType_GetApplication_OutputArguments Variable.
        /// </summary>
        public const uint DirectoryType_GetApplication_OutputArguments = 212;

        /// <summary>
        /// The identifier for the DirectoryType_QueryServers_InputArguments Variable.
        /// </summary>
        public const uint DirectoryType_QueryServers_InputArguments = 24;

        /// <summary>
        /// The identifier for the DirectoryType_QueryServers_OutputArguments Variable.
        /// </summary>
        public const uint DirectoryType_QueryServers_OutputArguments = 25;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_FindApplications_InputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_FindApplications_InputArguments = 66;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_FindApplications_OutputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_FindApplications_OutputArguments = 67;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_RegisterApplication_InputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_RegisterApplication_InputArguments = 69;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_RegisterApplication_OutputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_RegisterApplication_OutputArguments = 70;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_UpdateApplication_InputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_UpdateApplication_InputArguments = 194;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_UnregisterApplication_InputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_UnregisterApplication_InputArguments = 72;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_GetApplication_InputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_GetApplication_InputArguments = 214;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_GetApplication_OutputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_GetApplication_OutputArguments = 215;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_QueryServers_InputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_QueryServers_InputArguments = 74;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_QueryServers_OutputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_QueryServers_OutputArguments = 75;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_Size Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_Size = 514;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_Writable Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_Writable = 515;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_UserWritable Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_UserWritable = 516;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_OpenCount Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_OpenCount = 517;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_Open_InputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_Open_InputArguments = 520;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_Open_OutputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_Open_OutputArguments = 521;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_Close_InputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_Close_InputArguments = 523;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_Read_InputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_Read_InputArguments = 525;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_Read_OutputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_Read_OutputArguments = 526;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_Write_InputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_Write_InputArguments = 528;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_GetPosition_InputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_GetPosition_InputArguments = 530;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_GetPosition_OutputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_GetPosition_OutputArguments = 531;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_SetPosition_InputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_SetPosition_InputArguments = 533;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_LastUpdateTime Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_LastUpdateTime = 534;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_OpenWithMasks_InputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_OpenWithMasks_InputArguments = 536;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_OpenWithMasks_OutputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_OpenWithMasks_OutputArguments = 537;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_CloseAndUpdate_InputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_CloseAndUpdate_InputArguments = 539;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_CloseAndUpdate_OutputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_CloseAndUpdate_OutputArguments = 540;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_AddCertificate_InputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_AddCertificate_InputArguments = 542;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_RemoveCertificate_InputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_RemoveCertificate_InputArguments = 544;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_CertificateTypes Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_CertificateTypes = 545;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_Size Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_Size = 548;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_Writable Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_Writable = 549;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_UserWritable Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_UserWritable = 550;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_OpenCount Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_OpenCount = 551;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_Open_InputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_Open_InputArguments = 554;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_Open_OutputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_Open_OutputArguments = 555;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_Close_InputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_Close_InputArguments = 557;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_Read_InputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_Read_InputArguments = 559;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_Read_OutputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_Read_OutputArguments = 560;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_Write_InputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_Write_InputArguments = 562;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_GetPosition_InputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_GetPosition_InputArguments = 564;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_GetPosition_OutputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_GetPosition_OutputArguments = 565;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_SetPosition_InputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_SetPosition_InputArguments = 567;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_LastUpdateTime Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_LastUpdateTime = 568;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_OpenWithMasks_InputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_OpenWithMasks_InputArguments = 570;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_OpenWithMasks_OutputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_OpenWithMasks_OutputArguments = 571;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_CloseAndUpdate_InputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_CloseAndUpdate_InputArguments = 573;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_CloseAndUpdate_OutputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_CloseAndUpdate_OutputArguments = 574;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_AddCertificate_InputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_AddCertificate_InputArguments = 576;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_RemoveCertificate_InputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_RemoveCertificate_InputArguments = 578;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_CertificateTypes Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_CertificateTypes = 579;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_Size Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_Size = 582;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_Writable Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_Writable = 583;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_UserWritable Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_UserWritable = 584;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_OpenCount Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_OpenCount = 585;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_Open_InputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_Open_InputArguments = 588;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_Open_OutputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_Open_OutputArguments = 589;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_Close_InputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_Close_InputArguments = 591;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_Read_InputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_Read_InputArguments = 593;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_Read_OutputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_Read_OutputArguments = 594;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_Write_InputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_Write_InputArguments = 596;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_GetPosition_InputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_GetPosition_InputArguments = 598;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_GetPosition_OutputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_GetPosition_OutputArguments = 599;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_SetPosition_InputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_SetPosition_InputArguments = 601;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_LastUpdateTime Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_LastUpdateTime = 602;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_OpenWithMasks_InputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_OpenWithMasks_InputArguments = 604;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_OpenWithMasks_OutputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_OpenWithMasks_OutputArguments = 605;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_CloseAndUpdate_InputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_CloseAndUpdate_InputArguments = 607;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_CloseAndUpdate_OutputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_CloseAndUpdate_OutputArguments = 608;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_AddCertificate_InputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_AddCertificate_InputArguments = 610;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_RemoveCertificate_InputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_RemoveCertificate_InputArguments = 612;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_CertificateTypes Variable.
        /// </summary>
        public const uint CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_CertificateTypes = 613;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_StartSigningRequest_InputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_StartSigningRequest_InputArguments = 80;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_StartSigningRequest_OutputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_StartSigningRequest_OutputArguments = 81;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_StartNewKeyPairRequest_InputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_StartNewKeyPairRequest_InputArguments = 77;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_StartNewKeyPairRequest_OutputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_StartNewKeyPairRequest_OutputArguments = 78;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_FinishRequest_InputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_FinishRequest_InputArguments = 86;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_FinishRequest_OutputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_FinishRequest_OutputArguments = 87;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_GetCertificateGroups_InputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_GetCertificateGroups_InputArguments = 370;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_GetCertificateGroups_OutputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_GetCertificateGroups_OutputArguments = 371;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_GetTrustList_InputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_GetTrustList_InputArguments = 198;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_GetTrustList_OutputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_GetTrustList_OutputArguments = 199;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_GetCertificateStatus_InputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_GetCertificateStatus_InputArguments = 223;

        /// <summary>
        /// The identifier for the CertificateDirectoryType_GetCertificateStatus_OutputArguments Variable.
        /// </summary>
        public const uint CertificateDirectoryType_GetCertificateStatus_OutputArguments = 224;

        /// <summary>
        /// The identifier for the CertificateRequestedAuditEventType_CertificateGroup Variable.
        /// </summary>
        public const uint CertificateRequestedAuditEventType_CertificateGroup = 717;

        /// <summary>
        /// The identifier for the CertificateRequestedAuditEventType_CertificateType Variable.
        /// </summary>
        public const uint CertificateRequestedAuditEventType_CertificateType = 718;

        /// <summary>
        /// The identifier for the CertificateDeliveredAuditEventType_CertificateGroup Variable.
        /// </summary>
        public const uint CertificateDeliveredAuditEventType_CertificateGroup = 719;

        /// <summary>
        /// The identifier for the CertificateDeliveredAuditEventType_CertificateType Variable.
        /// </summary>
        public const uint CertificateDeliveredAuditEventType_CertificateType = 720;

        /// <summary>
        /// The identifier for the Directory_FindApplications_InputArguments Variable.
        /// </summary>
        public const uint Directory_FindApplications_InputArguments = 144;

        /// <summary>
        /// The identifier for the Directory_FindApplications_OutputArguments Variable.
        /// </summary>
        public const uint Directory_FindApplications_OutputArguments = 145;

        /// <summary>
        /// The identifier for the Directory_RegisterApplication_InputArguments Variable.
        /// </summary>
        public const uint Directory_RegisterApplication_InputArguments = 147;

        /// <summary>
        /// The identifier for the Directory_RegisterApplication_OutputArguments Variable.
        /// </summary>
        public const uint Directory_RegisterApplication_OutputArguments = 148;

        /// <summary>
        /// The identifier for the Directory_UpdateApplication_InputArguments Variable.
        /// </summary>
        public const uint Directory_UpdateApplication_InputArguments = 201;

        /// <summary>
        /// The identifier for the Directory_UnregisterApplication_InputArguments Variable.
        /// </summary>
        public const uint Directory_UnregisterApplication_InputArguments = 150;

        /// <summary>
        /// The identifier for the Directory_GetApplication_InputArguments Variable.
        /// </summary>
        public const uint Directory_GetApplication_InputArguments = 217;

        /// <summary>
        /// The identifier for the Directory_GetApplication_OutputArguments Variable.
        /// </summary>
        public const uint Directory_GetApplication_OutputArguments = 218;

        /// <summary>
        /// The identifier for the Directory_QueryServers_InputArguments Variable.
        /// </summary>
        public const uint Directory_QueryServers_InputArguments = 152;

        /// <summary>
        /// The identifier for the Directory_QueryServers_OutputArguments Variable.
        /// </summary>
        public const uint Directory_QueryServers_OutputArguments = 153;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList_Size Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultApplicationGroup_TrustList_Size = 617;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList_Writable Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultApplicationGroup_TrustList_Writable = 618;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList_UserWritable Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultApplicationGroup_TrustList_UserWritable = 619;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList_OpenCount Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultApplicationGroup_TrustList_OpenCount = 620;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList_Open_InputArguments Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultApplicationGroup_TrustList_Open_InputArguments = 623;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList_Open_OutputArguments Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultApplicationGroup_TrustList_Open_OutputArguments = 624;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList_Close_InputArguments Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultApplicationGroup_TrustList_Close_InputArguments = 626;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList_Read_InputArguments Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultApplicationGroup_TrustList_Read_InputArguments = 628;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList_Read_OutputArguments Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultApplicationGroup_TrustList_Read_OutputArguments = 629;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList_Write_InputArguments Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultApplicationGroup_TrustList_Write_InputArguments = 631;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList_GetPosition_InputArguments Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultApplicationGroup_TrustList_GetPosition_InputArguments = 633;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList_GetPosition_OutputArguments Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultApplicationGroup_TrustList_GetPosition_OutputArguments = 634;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList_SetPosition_InputArguments Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultApplicationGroup_TrustList_SetPosition_InputArguments = 636;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList_LastUpdateTime Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultApplicationGroup_TrustList_LastUpdateTime = 637;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList_OpenWithMasks_InputArguments Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultApplicationGroup_TrustList_OpenWithMasks_InputArguments = 639;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList_OpenWithMasks_OutputArguments Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultApplicationGroup_TrustList_OpenWithMasks_OutputArguments = 640;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList_CloseAndUpdate_InputArguments Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultApplicationGroup_TrustList_CloseAndUpdate_InputArguments = 642;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList_CloseAndUpdate_OutputArguments Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultApplicationGroup_TrustList_CloseAndUpdate_OutputArguments = 643;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList_AddCertificate_InputArguments Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultApplicationGroup_TrustList_AddCertificate_InputArguments = 645;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList_RemoveCertificate_InputArguments Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultApplicationGroup_TrustList_RemoveCertificate_InputArguments = 647;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_CertificateTypes Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultApplicationGroup_CertificateTypes = 648;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList_Size Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultHttpsGroup_TrustList_Size = 651;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList_Writable Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultHttpsGroup_TrustList_Writable = 652;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList_UserWritable Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultHttpsGroup_TrustList_UserWritable = 653;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList_OpenCount Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultHttpsGroup_TrustList_OpenCount = 654;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList_Open_InputArguments Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultHttpsGroup_TrustList_Open_InputArguments = 657;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList_Open_OutputArguments Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultHttpsGroup_TrustList_Open_OutputArguments = 658;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList_Close_InputArguments Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultHttpsGroup_TrustList_Close_InputArguments = 660;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList_Read_InputArguments Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultHttpsGroup_TrustList_Read_InputArguments = 662;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList_Read_OutputArguments Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultHttpsGroup_TrustList_Read_OutputArguments = 663;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList_Write_InputArguments Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultHttpsGroup_TrustList_Write_InputArguments = 665;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList_GetPosition_InputArguments Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultHttpsGroup_TrustList_GetPosition_InputArguments = 667;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList_GetPosition_OutputArguments Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultHttpsGroup_TrustList_GetPosition_OutputArguments = 668;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList_SetPosition_InputArguments Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultHttpsGroup_TrustList_SetPosition_InputArguments = 670;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList_LastUpdateTime Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultHttpsGroup_TrustList_LastUpdateTime = 671;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList_OpenWithMasks_InputArguments Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultHttpsGroup_TrustList_OpenWithMasks_InputArguments = 673;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList_OpenWithMasks_OutputArguments Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultHttpsGroup_TrustList_OpenWithMasks_OutputArguments = 674;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList_CloseAndUpdate_InputArguments Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultHttpsGroup_TrustList_CloseAndUpdate_InputArguments = 676;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList_CloseAndUpdate_OutputArguments Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultHttpsGroup_TrustList_CloseAndUpdate_OutputArguments = 677;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList_AddCertificate_InputArguments Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultHttpsGroup_TrustList_AddCertificate_InputArguments = 679;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList_RemoveCertificate_InputArguments Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultHttpsGroup_TrustList_RemoveCertificate_InputArguments = 681;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_CertificateTypes Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultHttpsGroup_CertificateTypes = 682;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_Size Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_Size = 685;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_Writable Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_Writable = 686;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_UserWritable Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_UserWritable = 687;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_OpenCount Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_OpenCount = 688;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_Open_InputArguments Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_Open_InputArguments = 691;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_Open_OutputArguments Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_Open_OutputArguments = 692;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_Close_InputArguments Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_Close_InputArguments = 694;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_Read_InputArguments Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_Read_InputArguments = 696;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_Read_OutputArguments Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_Read_OutputArguments = 697;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_Write_InputArguments Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_Write_InputArguments = 699;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_GetPosition_InputArguments Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_GetPosition_InputArguments = 701;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_GetPosition_OutputArguments Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_GetPosition_OutputArguments = 702;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_SetPosition_InputArguments Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_SetPosition_InputArguments = 704;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_LastUpdateTime Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_LastUpdateTime = 705;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_OpenWithMasks_InputArguments Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_OpenWithMasks_InputArguments = 707;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_OpenWithMasks_OutputArguments Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_OpenWithMasks_OutputArguments = 708;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_CloseAndUpdate_InputArguments Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_CloseAndUpdate_InputArguments = 710;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_CloseAndUpdate_OutputArguments Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_CloseAndUpdate_OutputArguments = 711;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_AddCertificate_InputArguments Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_AddCertificate_InputArguments = 713;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_RemoveCertificate_InputArguments Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_RemoveCertificate_InputArguments = 715;

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_CertificateTypes Variable.
        /// </summary>
        public const uint Directory_CertificateGroups_DefaultUserTokenGroup_CertificateTypes = 716;

        /// <summary>
        /// The identifier for the Directory_StartSigningRequest_InputArguments Variable.
        /// </summary>
        public const uint Directory_StartSigningRequest_InputArguments = 158;

        /// <summary>
        /// The identifier for the Directory_StartSigningRequest_OutputArguments Variable.
        /// </summary>
        public const uint Directory_StartSigningRequest_OutputArguments = 159;

        /// <summary>
        /// The identifier for the Directory_StartNewKeyPairRequest_InputArguments Variable.
        /// </summary>
        public const uint Directory_StartNewKeyPairRequest_InputArguments = 155;

        /// <summary>
        /// The identifier for the Directory_StartNewKeyPairRequest_OutputArguments Variable.
        /// </summary>
        public const uint Directory_StartNewKeyPairRequest_OutputArguments = 156;

        /// <summary>
        /// The identifier for the Directory_FinishRequest_InputArguments Variable.
        /// </summary>
        public const uint Directory_FinishRequest_InputArguments = 164;

        /// <summary>
        /// The identifier for the Directory_FinishRequest_OutputArguments Variable.
        /// </summary>
        public const uint Directory_FinishRequest_OutputArguments = 165;

        /// <summary>
        /// The identifier for the Directory_GetCertificateGroups_InputArguments Variable.
        /// </summary>
        public const uint Directory_GetCertificateGroups_InputArguments = 509;

        /// <summary>
        /// The identifier for the Directory_GetCertificateGroups_OutputArguments Variable.
        /// </summary>
        public const uint Directory_GetCertificateGroups_OutputArguments = 510;

        /// <summary>
        /// The identifier for the Directory_GetTrustList_InputArguments Variable.
        /// </summary>
        public const uint Directory_GetTrustList_InputArguments = 205;

        /// <summary>
        /// The identifier for the Directory_GetTrustList_OutputArguments Variable.
        /// </summary>
        public const uint Directory_GetTrustList_OutputArguments = 206;

        /// <summary>
        /// The identifier for the Directory_GetCertificateStatus_InputArguments Variable.
        /// </summary>
        public const uint Directory_GetCertificateStatus_InputArguments = 226;

        /// <summary>
        /// The identifier for the Directory_GetCertificateStatus_OutputArguments Variable.
        /// </summary>
        public const uint Directory_GetCertificateStatus_OutputArguments = 227;

        /// <summary>
        /// The identifier for the NetworkServiceFolderType_ServiceName_Placeholder_StartCredentialRequest_InputArguments Variable.
        /// </summary>
        public const uint NetworkServiceFolderType_ServiceName_Placeholder_StartCredentialRequest_InputArguments = 868;

        /// <summary>
        /// The identifier for the NetworkServiceFolderType_ServiceName_Placeholder_StartCredentialRequest_OutputArguments Variable.
        /// </summary>
        public const uint NetworkServiceFolderType_ServiceName_Placeholder_StartCredentialRequest_OutputArguments = 869;

        /// <summary>
        /// The identifier for the NetworkServiceFolderType_ServiceName_Placeholder_FinishCredentialRequest_InputArguments Variable.
        /// </summary>
        public const uint NetworkServiceFolderType_ServiceName_Placeholder_FinishCredentialRequest_InputArguments = 871;

        /// <summary>
        /// The identifier for the NetworkServiceFolderType_ServiceName_Placeholder_FinishCredentialRequest_OutputArguments Variable.
        /// </summary>
        public const uint NetworkServiceFolderType_ServiceName_Placeholder_FinishCredentialRequest_OutputArguments = 872;

        /// <summary>
        /// The identifier for the NetworkServiceFolderType_ServiceName_Placeholder_RevokeCredential_InputArguments Variable.
        /// </summary>
        public const uint NetworkServiceFolderType_ServiceName_Placeholder_RevokeCredential_InputArguments = 874;

        /// <summary>
        /// The identifier for the AuthorizationServices_ServiceName_Placeholder_StartCredentialRequest_InputArguments Variable.
        /// </summary>
        public const uint AuthorizationServices_ServiceName_Placeholder_StartCredentialRequest_InputArguments = 878;

        /// <summary>
        /// The identifier for the AuthorizationServices_ServiceName_Placeholder_StartCredentialRequest_OutputArguments Variable.
        /// </summary>
        public const uint AuthorizationServices_ServiceName_Placeholder_StartCredentialRequest_OutputArguments = 879;

        /// <summary>
        /// The identifier for the AuthorizationServices_ServiceName_Placeholder_FinishCredentialRequest_InputArguments Variable.
        /// </summary>
        public const uint AuthorizationServices_ServiceName_Placeholder_FinishCredentialRequest_InputArguments = 881;

        /// <summary>
        /// The identifier for the AuthorizationServices_ServiceName_Placeholder_FinishCredentialRequest_OutputArguments Variable.
        /// </summary>
        public const uint AuthorizationServices_ServiceName_Placeholder_FinishCredentialRequest_OutputArguments = 882;

        /// <summary>
        /// The identifier for the AuthorizationServices_ServiceName_Placeholder_RevokeCredential_InputArguments Variable.
        /// </summary>
        public const uint AuthorizationServices_ServiceName_Placeholder_RevokeCredential_InputArguments = 884;

        /// <summary>
        /// The identifier for the CredentialManagementType_StartCredentialRequest_InputArguments Variable.
        /// </summary>
        public const uint CredentialManagementType_StartCredentialRequest_InputArguments = 787;

        /// <summary>
        /// The identifier for the CredentialManagementType_StartCredentialRequest_OutputArguments Variable.
        /// </summary>
        public const uint CredentialManagementType_StartCredentialRequest_OutputArguments = 788;

        /// <summary>
        /// The identifier for the CredentialManagementType_FinishCredentialRequest_InputArguments Variable.
        /// </summary>
        public const uint CredentialManagementType_FinishCredentialRequest_InputArguments = 790;

        /// <summary>
        /// The identifier for the CredentialManagementType_FinishCredentialRequest_OutputArguments Variable.
        /// </summary>
        public const uint CredentialManagementType_FinishCredentialRequest_OutputArguments = 791;

        /// <summary>
        /// The identifier for the CredentialManagementType_RevokeCredential_InputArguments Variable.
        /// </summary>
        public const uint CredentialManagementType_RevokeCredential_InputArguments = 793;

        /// <summary>
        /// The identifier for the NetworkServiceType_ServiceUri Variable.
        /// </summary>
        public const uint NetworkServiceType_ServiceUri = 886;

        /// <summary>
        /// The identifier for the NetworkServiceType_ServiceProfileUri Variable.
        /// </summary>
        public const uint NetworkServiceType_ServiceProfileUri = 887;

        /// <summary>
        /// The identifier for the NetworkServiceType_ServiceEndpointUrls Variable.
        /// </summary>
        public const uint NetworkServiceType_ServiceEndpointUrls = 888;

        /// <summary>
        /// The identifier for the NetworkServiceType_CredentialManagement_StartCredentialRequest_InputArguments Variable.
        /// </summary>
        public const uint NetworkServiceType_CredentialManagement_StartCredentialRequest_InputArguments = 891;

        /// <summary>
        /// The identifier for the NetworkServiceType_CredentialManagement_StartCredentialRequest_OutputArguments Variable.
        /// </summary>
        public const uint NetworkServiceType_CredentialManagement_StartCredentialRequest_OutputArguments = 892;

        /// <summary>
        /// The identifier for the NetworkServiceType_CredentialManagement_FinishCredentialRequest_InputArguments Variable.
        /// </summary>
        public const uint NetworkServiceType_CredentialManagement_FinishCredentialRequest_InputArguments = 894;

        /// <summary>
        /// The identifier for the NetworkServiceType_CredentialManagement_FinishCredentialRequest_OutputArguments Variable.
        /// </summary>
        public const uint NetworkServiceType_CredentialManagement_FinishCredentialRequest_OutputArguments = 895;

        /// <summary>
        /// The identifier for the NetworkServiceType_CredentialManagement_RevokeCredential_InputArguments Variable.
        /// </summary>
        public const uint NetworkServiceType_CredentialManagement_RevokeCredential_InputArguments = 897;

        /// <summary>
        /// The identifier for the AuthorizationServiceType_CredentialManagement_StartCredentialRequest_InputArguments Variable.
        /// </summary>
        public const uint AuthorizationServiceType_CredentialManagement_StartCredentialRequest_InputArguments = 904;

        /// <summary>
        /// The identifier for the AuthorizationServiceType_CredentialManagement_StartCredentialRequest_OutputArguments Variable.
        /// </summary>
        public const uint AuthorizationServiceType_CredentialManagement_StartCredentialRequest_OutputArguments = 905;

        /// <summary>
        /// The identifier for the AuthorizationServiceType_CredentialManagement_FinishCredentialRequest_InputArguments Variable.
        /// </summary>
        public const uint AuthorizationServiceType_CredentialManagement_FinishCredentialRequest_InputArguments = 907;

        /// <summary>
        /// The identifier for the AuthorizationServiceType_CredentialManagement_FinishCredentialRequest_OutputArguments Variable.
        /// </summary>
        public const uint AuthorizationServiceType_CredentialManagement_FinishCredentialRequest_OutputArguments = 908;

        /// <summary>
        /// The identifier for the AuthorizationServiceType_CredentialManagement_RevokeCredential_InputArguments Variable.
        /// </summary>
        public const uint AuthorizationServiceType_CredentialManagement_RevokeCredential_InputArguments = 910;

        /// <summary>
        /// The identifier for the AuthorizationServiceType_UserTokenPolicies Variable.
        /// </summary>
        public const uint AuthorizationServiceType_UserTokenPolicies = 911;

        /// <summary>
        /// The identifier for the AuthorizationServiceType_RequestAccessToken_InputArguments Variable.
        /// </summary>
        public const uint AuthorizationServiceType_RequestAccessToken_InputArguments = 913;

        /// <summary>
        /// The identifier for the AuthorizationServiceType_RequestAccessToken_OutputArguments Variable.
        /// </summary>
        public const uint AuthorizationServiceType_RequestAccessToken_OutputArguments = 914;

        /// <summary>
        /// The identifier for the CredentialRequestedAuditEventType_ServiceUri Variable.
        /// </summary>
        public const uint CredentialRequestedAuditEventType_ServiceUri = 825;

        /// <summary>
        /// The identifier for the CredentialDeliveredAuditEventType_ServiceUri Variable.
        /// </summary>
        public const uint CredentialDeliveredAuditEventType_ServiceUri = 843;

        /// <summary>
        /// The identifier for the CredentialRevokedAuditEventType_ServiceUri Variable.
        /// </summary>
        public const uint CredentialRevokedAuditEventType_ServiceUri = 861;

        /// <summary>
        /// The identifier for the OpcUaGds_XmlSchema Variable.
        /// </summary>
        public const uint OpcUaGds_XmlSchema = 128;

        /// <summary>
        /// The identifier for the OpcUaGds_XmlSchema_NamespaceUri Variable.
        /// </summary>
        public const uint OpcUaGds_XmlSchema_NamespaceUri = 130;

        /// <summary>
        /// The identifier for the OpcUaGds_XmlSchema_ApplicationRecordDataType Variable.
        /// </summary>
        public const uint OpcUaGds_XmlSchema_ApplicationRecordDataType = 131;

        /// <summary>
        /// The identifier for the OpcUaGds_BinarySchema Variable.
        /// </summary>
        public const uint OpcUaGds_BinarySchema = 135;

        /// <summary>
        /// The identifier for the OpcUaGds_BinarySchema_NamespaceUri Variable.
        /// </summary>
        public const uint OpcUaGds_BinarySchema_NamespaceUri = 137;

        /// <summary>
        /// The identifier for the OpcUaGds_BinarySchema_ApplicationRecordDataType Variable.
        /// </summary>
        public const uint OpcUaGds_BinarySchema_ApplicationRecordDataType = 138;
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
        /// The identifier for the ApplicationRecordDataType DataType.
        /// </summary>
        public static readonly ExpandedNodeId ApplicationRecordDataType = new ExpandedNodeId(Opc.Ua.Gds.DataTypes.ApplicationRecordDataType, Opc.Ua.Gds.Namespaces.OpcUaGds);
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
        /// The identifier for the OPCUAGDSNamespaceMetadata_NamespaceFile_Open Method.
        /// </summary>
        public static readonly ExpandedNodeId OPCUAGDSNamespaceMetadata_NamespaceFile_Open = new ExpandedNodeId(Opc.Ua.Gds.Methods.OPCUAGDSNamespaceMetadata_NamespaceFile_Open, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the OPCUAGDSNamespaceMetadata_NamespaceFile_Close Method.
        /// </summary>
        public static readonly ExpandedNodeId OPCUAGDSNamespaceMetadata_NamespaceFile_Close = new ExpandedNodeId(Opc.Ua.Gds.Methods.OPCUAGDSNamespaceMetadata_NamespaceFile_Close, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the OPCUAGDSNamespaceMetadata_NamespaceFile_Read Method.
        /// </summary>
        public static readonly ExpandedNodeId OPCUAGDSNamespaceMetadata_NamespaceFile_Read = new ExpandedNodeId(Opc.Ua.Gds.Methods.OPCUAGDSNamespaceMetadata_NamespaceFile_Read, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the OPCUAGDSNamespaceMetadata_NamespaceFile_Write Method.
        /// </summary>
        public static readonly ExpandedNodeId OPCUAGDSNamespaceMetadata_NamespaceFile_Write = new ExpandedNodeId(Opc.Ua.Gds.Methods.OPCUAGDSNamespaceMetadata_NamespaceFile_Write, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the OPCUAGDSNamespaceMetadata_NamespaceFile_GetPosition Method.
        /// </summary>
        public static readonly ExpandedNodeId OPCUAGDSNamespaceMetadata_NamespaceFile_GetPosition = new ExpandedNodeId(Opc.Ua.Gds.Methods.OPCUAGDSNamespaceMetadata_NamespaceFile_GetPosition, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the OPCUAGDSNamespaceMetadata_NamespaceFile_SetPosition Method.
        /// </summary>
        public static readonly ExpandedNodeId OPCUAGDSNamespaceMetadata_NamespaceFile_SetPosition = new ExpandedNodeId(Opc.Ua.Gds.Methods.OPCUAGDSNamespaceMetadata_NamespaceFile_SetPosition, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the DirectoryType_FindApplications Method.
        /// </summary>
        public static readonly ExpandedNodeId DirectoryType_FindApplications = new ExpandedNodeId(Opc.Ua.Gds.Methods.DirectoryType_FindApplications, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the DirectoryType_RegisterApplication Method.
        /// </summary>
        public static readonly ExpandedNodeId DirectoryType_RegisterApplication = new ExpandedNodeId(Opc.Ua.Gds.Methods.DirectoryType_RegisterApplication, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the DirectoryType_UpdateApplication Method.
        /// </summary>
        public static readonly ExpandedNodeId DirectoryType_UpdateApplication = new ExpandedNodeId(Opc.Ua.Gds.Methods.DirectoryType_UpdateApplication, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the DirectoryType_UnregisterApplication Method.
        /// </summary>
        public static readonly ExpandedNodeId DirectoryType_UnregisterApplication = new ExpandedNodeId(Opc.Ua.Gds.Methods.DirectoryType_UnregisterApplication, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the DirectoryType_GetApplication Method.
        /// </summary>
        public static readonly ExpandedNodeId DirectoryType_GetApplication = new ExpandedNodeId(Opc.Ua.Gds.Methods.DirectoryType_GetApplication, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the DirectoryType_QueryServers Method.
        /// </summary>
        public static readonly ExpandedNodeId DirectoryType_QueryServers = new ExpandedNodeId(Opc.Ua.Gds.Methods.DirectoryType_QueryServers, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_Open Method.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_Open = new ExpandedNodeId(Opc.Ua.Gds.Methods.CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_Open, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_Close Method.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_Close = new ExpandedNodeId(Opc.Ua.Gds.Methods.CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_Close, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_Read Method.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_Read = new ExpandedNodeId(Opc.Ua.Gds.Methods.CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_Read, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_Write Method.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_Write = new ExpandedNodeId(Opc.Ua.Gds.Methods.CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_Write, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_GetPosition Method.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_GetPosition = new ExpandedNodeId(Opc.Ua.Gds.Methods.CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_GetPosition, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_SetPosition Method.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_SetPosition = new ExpandedNodeId(Opc.Ua.Gds.Methods.CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_SetPosition, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_OpenWithMasks Method.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_OpenWithMasks = new ExpandedNodeId(Opc.Ua.Gds.Methods.CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_OpenWithMasks, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_Open Method.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_Open = new ExpandedNodeId(Opc.Ua.Gds.Methods.CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_Open, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_Close Method.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_Close = new ExpandedNodeId(Opc.Ua.Gds.Methods.CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_Close, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_Read Method.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_Read = new ExpandedNodeId(Opc.Ua.Gds.Methods.CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_Read, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_Write Method.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_Write = new ExpandedNodeId(Opc.Ua.Gds.Methods.CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_Write, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_GetPosition Method.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_GetPosition = new ExpandedNodeId(Opc.Ua.Gds.Methods.CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_GetPosition, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_SetPosition Method.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_SetPosition = new ExpandedNodeId(Opc.Ua.Gds.Methods.CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_SetPosition, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_OpenWithMasks Method.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_OpenWithMasks = new ExpandedNodeId(Opc.Ua.Gds.Methods.CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_OpenWithMasks, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_Open Method.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_Open = new ExpandedNodeId(Opc.Ua.Gds.Methods.CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_Open, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_Close Method.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_Close = new ExpandedNodeId(Opc.Ua.Gds.Methods.CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_Close, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_Read Method.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_Read = new ExpandedNodeId(Opc.Ua.Gds.Methods.CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_Read, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_Write Method.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_Write = new ExpandedNodeId(Opc.Ua.Gds.Methods.CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_Write, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_GetPosition Method.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_GetPosition = new ExpandedNodeId(Opc.Ua.Gds.Methods.CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_GetPosition, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_SetPosition Method.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_SetPosition = new ExpandedNodeId(Opc.Ua.Gds.Methods.CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_SetPosition, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_OpenWithMasks Method.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_OpenWithMasks = new ExpandedNodeId(Opc.Ua.Gds.Methods.CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_OpenWithMasks, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_StartSigningRequest Method.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_StartSigningRequest = new ExpandedNodeId(Opc.Ua.Gds.Methods.CertificateDirectoryType_StartSigningRequest, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_StartNewKeyPairRequest Method.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_StartNewKeyPairRequest = new ExpandedNodeId(Opc.Ua.Gds.Methods.CertificateDirectoryType_StartNewKeyPairRequest, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_FinishRequest Method.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_FinishRequest = new ExpandedNodeId(Opc.Ua.Gds.Methods.CertificateDirectoryType_FinishRequest, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_GetCertificateGroups Method.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_GetCertificateGroups = new ExpandedNodeId(Opc.Ua.Gds.Methods.CertificateDirectoryType_GetCertificateGroups, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_GetTrustList Method.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_GetTrustList = new ExpandedNodeId(Opc.Ua.Gds.Methods.CertificateDirectoryType_GetTrustList, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_GetCertificateStatus Method.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_GetCertificateStatus = new ExpandedNodeId(Opc.Ua.Gds.Methods.CertificateDirectoryType_GetCertificateStatus, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_FindApplications Method.
        /// </summary>
        public static readonly ExpandedNodeId Directory_FindApplications = new ExpandedNodeId(Opc.Ua.Gds.Methods.Directory_FindApplications, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_RegisterApplication Method.
        /// </summary>
        public static readonly ExpandedNodeId Directory_RegisterApplication = new ExpandedNodeId(Opc.Ua.Gds.Methods.Directory_RegisterApplication, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_UpdateApplication Method.
        /// </summary>
        public static readonly ExpandedNodeId Directory_UpdateApplication = new ExpandedNodeId(Opc.Ua.Gds.Methods.Directory_UpdateApplication, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_UnregisterApplication Method.
        /// </summary>
        public static readonly ExpandedNodeId Directory_UnregisterApplication = new ExpandedNodeId(Opc.Ua.Gds.Methods.Directory_UnregisterApplication, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_GetApplication Method.
        /// </summary>
        public static readonly ExpandedNodeId Directory_GetApplication = new ExpandedNodeId(Opc.Ua.Gds.Methods.Directory_GetApplication, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_QueryServers Method.
        /// </summary>
        public static readonly ExpandedNodeId Directory_QueryServers = new ExpandedNodeId(Opc.Ua.Gds.Methods.Directory_QueryServers, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList_Open Method.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultApplicationGroup_TrustList_Open = new ExpandedNodeId(Opc.Ua.Gds.Methods.Directory_CertificateGroups_DefaultApplicationGroup_TrustList_Open, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList_Close Method.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultApplicationGroup_TrustList_Close = new ExpandedNodeId(Opc.Ua.Gds.Methods.Directory_CertificateGroups_DefaultApplicationGroup_TrustList_Close, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList_Read Method.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultApplicationGroup_TrustList_Read = new ExpandedNodeId(Opc.Ua.Gds.Methods.Directory_CertificateGroups_DefaultApplicationGroup_TrustList_Read, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList_Write Method.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultApplicationGroup_TrustList_Write = new ExpandedNodeId(Opc.Ua.Gds.Methods.Directory_CertificateGroups_DefaultApplicationGroup_TrustList_Write, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList_GetPosition Method.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultApplicationGroup_TrustList_GetPosition = new ExpandedNodeId(Opc.Ua.Gds.Methods.Directory_CertificateGroups_DefaultApplicationGroup_TrustList_GetPosition, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList_SetPosition Method.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultApplicationGroup_TrustList_SetPosition = new ExpandedNodeId(Opc.Ua.Gds.Methods.Directory_CertificateGroups_DefaultApplicationGroup_TrustList_SetPosition, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList_OpenWithMasks Method.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultApplicationGroup_TrustList_OpenWithMasks = new ExpandedNodeId(Opc.Ua.Gds.Methods.Directory_CertificateGroups_DefaultApplicationGroup_TrustList_OpenWithMasks, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList_CloseAndUpdate Method.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultApplicationGroup_TrustList_CloseAndUpdate = new ExpandedNodeId(Opc.Ua.Gds.Methods.Directory_CertificateGroups_DefaultApplicationGroup_TrustList_CloseAndUpdate, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList_AddCertificate Method.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultApplicationGroup_TrustList_AddCertificate = new ExpandedNodeId(Opc.Ua.Gds.Methods.Directory_CertificateGroups_DefaultApplicationGroup_TrustList_AddCertificate, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList_RemoveCertificate Method.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultApplicationGroup_TrustList_RemoveCertificate = new ExpandedNodeId(Opc.Ua.Gds.Methods.Directory_CertificateGroups_DefaultApplicationGroup_TrustList_RemoveCertificate, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList_Open Method.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultHttpsGroup_TrustList_Open = new ExpandedNodeId(Opc.Ua.Gds.Methods.Directory_CertificateGroups_DefaultHttpsGroup_TrustList_Open, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList_Close Method.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultHttpsGroup_TrustList_Close = new ExpandedNodeId(Opc.Ua.Gds.Methods.Directory_CertificateGroups_DefaultHttpsGroup_TrustList_Close, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList_Read Method.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultHttpsGroup_TrustList_Read = new ExpandedNodeId(Opc.Ua.Gds.Methods.Directory_CertificateGroups_DefaultHttpsGroup_TrustList_Read, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList_Write Method.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultHttpsGroup_TrustList_Write = new ExpandedNodeId(Opc.Ua.Gds.Methods.Directory_CertificateGroups_DefaultHttpsGroup_TrustList_Write, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList_GetPosition Method.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultHttpsGroup_TrustList_GetPosition = new ExpandedNodeId(Opc.Ua.Gds.Methods.Directory_CertificateGroups_DefaultHttpsGroup_TrustList_GetPosition, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList_SetPosition Method.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultHttpsGroup_TrustList_SetPosition = new ExpandedNodeId(Opc.Ua.Gds.Methods.Directory_CertificateGroups_DefaultHttpsGroup_TrustList_SetPosition, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList_OpenWithMasks Method.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultHttpsGroup_TrustList_OpenWithMasks = new ExpandedNodeId(Opc.Ua.Gds.Methods.Directory_CertificateGroups_DefaultHttpsGroup_TrustList_OpenWithMasks, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList_CloseAndUpdate Method.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultHttpsGroup_TrustList_CloseAndUpdate = new ExpandedNodeId(Opc.Ua.Gds.Methods.Directory_CertificateGroups_DefaultHttpsGroup_TrustList_CloseAndUpdate, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList_AddCertificate Method.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultHttpsGroup_TrustList_AddCertificate = new ExpandedNodeId(Opc.Ua.Gds.Methods.Directory_CertificateGroups_DefaultHttpsGroup_TrustList_AddCertificate, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList_RemoveCertificate Method.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultHttpsGroup_TrustList_RemoveCertificate = new ExpandedNodeId(Opc.Ua.Gds.Methods.Directory_CertificateGroups_DefaultHttpsGroup_TrustList_RemoveCertificate, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_Open Method.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_Open = new ExpandedNodeId(Opc.Ua.Gds.Methods.Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_Open, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_Close Method.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_Close = new ExpandedNodeId(Opc.Ua.Gds.Methods.Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_Close, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_Read Method.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_Read = new ExpandedNodeId(Opc.Ua.Gds.Methods.Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_Read, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_Write Method.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_Write = new ExpandedNodeId(Opc.Ua.Gds.Methods.Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_Write, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_GetPosition Method.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_GetPosition = new ExpandedNodeId(Opc.Ua.Gds.Methods.Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_GetPosition, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_SetPosition Method.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_SetPosition = new ExpandedNodeId(Opc.Ua.Gds.Methods.Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_SetPosition, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_OpenWithMasks Method.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_OpenWithMasks = new ExpandedNodeId(Opc.Ua.Gds.Methods.Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_OpenWithMasks, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_CloseAndUpdate Method.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_CloseAndUpdate = new ExpandedNodeId(Opc.Ua.Gds.Methods.Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_CloseAndUpdate, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_AddCertificate Method.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_AddCertificate = new ExpandedNodeId(Opc.Ua.Gds.Methods.Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_AddCertificate, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_RemoveCertificate Method.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_RemoveCertificate = new ExpandedNodeId(Opc.Ua.Gds.Methods.Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_RemoveCertificate, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_StartSigningRequest Method.
        /// </summary>
        public static readonly ExpandedNodeId Directory_StartSigningRequest = new ExpandedNodeId(Opc.Ua.Gds.Methods.Directory_StartSigningRequest, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_StartNewKeyPairRequest Method.
        /// </summary>
        public static readonly ExpandedNodeId Directory_StartNewKeyPairRequest = new ExpandedNodeId(Opc.Ua.Gds.Methods.Directory_StartNewKeyPairRequest, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_FinishRequest Method.
        /// </summary>
        public static readonly ExpandedNodeId Directory_FinishRequest = new ExpandedNodeId(Opc.Ua.Gds.Methods.Directory_FinishRequest, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_GetCertificateGroups Method.
        /// </summary>
        public static readonly ExpandedNodeId Directory_GetCertificateGroups = new ExpandedNodeId(Opc.Ua.Gds.Methods.Directory_GetCertificateGroups, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_GetTrustList Method.
        /// </summary>
        public static readonly ExpandedNodeId Directory_GetTrustList = new ExpandedNodeId(Opc.Ua.Gds.Methods.Directory_GetTrustList, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_GetCertificateStatus Method.
        /// </summary>
        public static readonly ExpandedNodeId Directory_GetCertificateStatus = new ExpandedNodeId(Opc.Ua.Gds.Methods.Directory_GetCertificateStatus, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the NetworkServiceFolderType_ServiceName_Placeholder_StartCredentialRequest Method.
        /// </summary>
        public static readonly ExpandedNodeId NetworkServiceFolderType_ServiceName_Placeholder_StartCredentialRequest = new ExpandedNodeId(Opc.Ua.Gds.Methods.NetworkServiceFolderType_ServiceName_Placeholder_StartCredentialRequest, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the NetworkServiceFolderType_ServiceName_Placeholder_FinishCredentialRequest Method.
        /// </summary>
        public static readonly ExpandedNodeId NetworkServiceFolderType_ServiceName_Placeholder_FinishCredentialRequest = new ExpandedNodeId(Opc.Ua.Gds.Methods.NetworkServiceFolderType_ServiceName_Placeholder_FinishCredentialRequest, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the AuthorizationServices_ServiceName_Placeholder_StartCredentialRequest Method.
        /// </summary>
        public static readonly ExpandedNodeId AuthorizationServices_ServiceName_Placeholder_StartCredentialRequest = new ExpandedNodeId(Opc.Ua.Gds.Methods.AuthorizationServices_ServiceName_Placeholder_StartCredentialRequest, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the AuthorizationServices_ServiceName_Placeholder_FinishCredentialRequest Method.
        /// </summary>
        public static readonly ExpandedNodeId AuthorizationServices_ServiceName_Placeholder_FinishCredentialRequest = new ExpandedNodeId(Opc.Ua.Gds.Methods.AuthorizationServices_ServiceName_Placeholder_FinishCredentialRequest, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CredentialManagementType_StartCredentialRequest Method.
        /// </summary>
        public static readonly ExpandedNodeId CredentialManagementType_StartCredentialRequest = new ExpandedNodeId(Opc.Ua.Gds.Methods.CredentialManagementType_StartCredentialRequest, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CredentialManagementType_FinishCredentialRequest Method.
        /// </summary>
        public static readonly ExpandedNodeId CredentialManagementType_FinishCredentialRequest = new ExpandedNodeId(Opc.Ua.Gds.Methods.CredentialManagementType_FinishCredentialRequest, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CredentialManagementType_RevokeCredential Method.
        /// </summary>
        public static readonly ExpandedNodeId CredentialManagementType_RevokeCredential = new ExpandedNodeId(Opc.Ua.Gds.Methods.CredentialManagementType_RevokeCredential, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the NetworkServiceType_CredentialManagement_StartCredentialRequest Method.
        /// </summary>
        public static readonly ExpandedNodeId NetworkServiceType_CredentialManagement_StartCredentialRequest = new ExpandedNodeId(Opc.Ua.Gds.Methods.NetworkServiceType_CredentialManagement_StartCredentialRequest, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the NetworkServiceType_CredentialManagement_FinishCredentialRequest Method.
        /// </summary>
        public static readonly ExpandedNodeId NetworkServiceType_CredentialManagement_FinishCredentialRequest = new ExpandedNodeId(Opc.Ua.Gds.Methods.NetworkServiceType_CredentialManagement_FinishCredentialRequest, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the AuthorizationServiceType_CredentialManagement_StartCredentialRequest Method.
        /// </summary>
        public static readonly ExpandedNodeId AuthorizationServiceType_CredentialManagement_StartCredentialRequest = new ExpandedNodeId(Opc.Ua.Gds.Methods.AuthorizationServiceType_CredentialManagement_StartCredentialRequest, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the AuthorizationServiceType_CredentialManagement_FinishCredentialRequest Method.
        /// </summary>
        public static readonly ExpandedNodeId AuthorizationServiceType_CredentialManagement_FinishCredentialRequest = new ExpandedNodeId(Opc.Ua.Gds.Methods.AuthorizationServiceType_CredentialManagement_FinishCredentialRequest, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the AuthorizationServiceType_RequestAccessToken Method.
        /// </summary>
        public static readonly ExpandedNodeId AuthorizationServiceType_RequestAccessToken = new ExpandedNodeId(Opc.Ua.Gds.Methods.AuthorizationServiceType_RequestAccessToken, Opc.Ua.Gds.Namespaces.OpcUaGds);
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
        /// The identifier for the OPCUAGDSNamespaceMetadata Object.
        /// </summary>
        public static readonly ExpandedNodeId OPCUAGDSNamespaceMetadata = new ExpandedNodeId(Opc.Ua.Gds.Objects.OPCUAGDSNamespaceMetadata, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the DirectoryType_Applications Object.
        /// </summary>
        public static readonly ExpandedNodeId DirectoryType_Applications = new ExpandedNodeId(Opc.Ua.Gds.Objects.DirectoryType_Applications, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups Object.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups = new ExpandedNodeId(Opc.Ua.Gds.Objects.CertificateDirectoryType_CertificateGroups, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup Object.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup = new ExpandedNodeId(Opc.Ua.Gds.Objects.CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList Object.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList = new ExpandedNodeId(Opc.Ua.Gds.Objects.CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList Object.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList = new ExpandedNodeId(Opc.Ua.Gds.Objects.CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList Object.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList = new ExpandedNodeId(Opc.Ua.Gds.Objects.CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory Object.
        /// </summary>
        public static readonly ExpandedNodeId Directory = new ExpandedNodeId(Opc.Ua.Gds.Objects.Directory, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_Applications Object.
        /// </summary>
        public static readonly ExpandedNodeId Directory_Applications = new ExpandedNodeId(Opc.Ua.Gds.Objects.Directory_Applications, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups Object.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups = new ExpandedNodeId(Opc.Ua.Gds.Objects.Directory_CertificateGroups, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup Object.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultApplicationGroup = new ExpandedNodeId(Opc.Ua.Gds.Objects.Directory_CertificateGroups_DefaultApplicationGroup, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList Object.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultApplicationGroup_TrustList = new ExpandedNodeId(Opc.Ua.Gds.Objects.Directory_CertificateGroups_DefaultApplicationGroup_TrustList, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup Object.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultHttpsGroup = new ExpandedNodeId(Opc.Ua.Gds.Objects.Directory_CertificateGroups_DefaultHttpsGroup, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList Object.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultHttpsGroup_TrustList = new ExpandedNodeId(Opc.Ua.Gds.Objects.Directory_CertificateGroups_DefaultHttpsGroup_TrustList, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup Object.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultUserTokenGroup = new ExpandedNodeId(Opc.Ua.Gds.Objects.Directory_CertificateGroups_DefaultUserTokenGroup, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList Object.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultUserTokenGroup_TrustList = new ExpandedNodeId(Opc.Ua.Gds.Objects.Directory_CertificateGroups_DefaultUserTokenGroup_TrustList, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the NetworkServiceFolderType_ServiceName_Placeholder Object.
        /// </summary>
        public static readonly ExpandedNodeId NetworkServiceFolderType_ServiceName_Placeholder = new ExpandedNodeId(Opc.Ua.Gds.Objects.NetworkServiceFolderType_ServiceName_Placeholder, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the AuthorizationServices Object.
        /// </summary>
        public static readonly ExpandedNodeId AuthorizationServices = new ExpandedNodeId(Opc.Ua.Gds.Objects.AuthorizationServices, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the NetworkServiceType_CredentialManagement Object.
        /// </summary>
        public static readonly ExpandedNodeId NetworkServiceType_CredentialManagement = new ExpandedNodeId(Opc.Ua.Gds.Objects.NetworkServiceType_CredentialManagement, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the ApplicationRecordDataType_Encoding_DefaultXml Object.
        /// </summary>
        public static readonly ExpandedNodeId ApplicationRecordDataType_Encoding_DefaultXml = new ExpandedNodeId(Opc.Ua.Gds.Objects.ApplicationRecordDataType_Encoding_DefaultXml, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the ApplicationRecordDataType_Encoding_DefaultBinary Object.
        /// </summary>
        public static readonly ExpandedNodeId ApplicationRecordDataType_Encoding_DefaultBinary = new ExpandedNodeId(Opc.Ua.Gds.Objects.ApplicationRecordDataType_Encoding_DefaultBinary, Opc.Ua.Gds.Namespaces.OpcUaGds);
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
        /// The identifier for the DirectoryType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId DirectoryType = new ExpandedNodeId(Opc.Ua.Gds.ObjectTypes.DirectoryType, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the ApplicationRegistrationChangedAuditEventType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId ApplicationRegistrationChangedAuditEventType = new ExpandedNodeId(Opc.Ua.Gds.ObjectTypes.ApplicationRegistrationChangedAuditEventType, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType = new ExpandedNodeId(Opc.Ua.Gds.ObjectTypes.CertificateDirectoryType, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateRequestedAuditEventType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId CertificateRequestedAuditEventType = new ExpandedNodeId(Opc.Ua.Gds.ObjectTypes.CertificateRequestedAuditEventType, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDeliveredAuditEventType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDeliveredAuditEventType = new ExpandedNodeId(Opc.Ua.Gds.ObjectTypes.CertificateDeliveredAuditEventType, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the NetworkServiceFolderType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId NetworkServiceFolderType = new ExpandedNodeId(Opc.Ua.Gds.ObjectTypes.NetworkServiceFolderType, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CredentialManagementType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId CredentialManagementType = new ExpandedNodeId(Opc.Ua.Gds.ObjectTypes.CredentialManagementType, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the NetworkServiceType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId NetworkServiceType = new ExpandedNodeId(Opc.Ua.Gds.ObjectTypes.NetworkServiceType, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the AuthorizationServiceType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId AuthorizationServiceType = new ExpandedNodeId(Opc.Ua.Gds.ObjectTypes.AuthorizationServiceType, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CredentialRequestedAuditEventType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId CredentialRequestedAuditEventType = new ExpandedNodeId(Opc.Ua.Gds.ObjectTypes.CredentialRequestedAuditEventType, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CredentialDeliveredAuditEventType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId CredentialDeliveredAuditEventType = new ExpandedNodeId(Opc.Ua.Gds.ObjectTypes.CredentialDeliveredAuditEventType, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CredentialRevokedAuditEventType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId CredentialRevokedAuditEventType = new ExpandedNodeId(Opc.Ua.Gds.ObjectTypes.CredentialRevokedAuditEventType, Opc.Ua.Gds.Namespaces.OpcUaGds);
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
        /// The identifier for the OPCUAGDSNamespaceMetadata_NamespaceUri Variable.
        /// </summary>
        public static readonly ExpandedNodeId OPCUAGDSNamespaceMetadata_NamespaceUri = new ExpandedNodeId(Opc.Ua.Gds.Variables.OPCUAGDSNamespaceMetadata_NamespaceUri, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the OPCUAGDSNamespaceMetadata_NamespaceVersion Variable.
        /// </summary>
        public static readonly ExpandedNodeId OPCUAGDSNamespaceMetadata_NamespaceVersion = new ExpandedNodeId(Opc.Ua.Gds.Variables.OPCUAGDSNamespaceMetadata_NamespaceVersion, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the OPCUAGDSNamespaceMetadata_NamespacePublicationDate Variable.
        /// </summary>
        public static readonly ExpandedNodeId OPCUAGDSNamespaceMetadata_NamespacePublicationDate = new ExpandedNodeId(Opc.Ua.Gds.Variables.OPCUAGDSNamespaceMetadata_NamespacePublicationDate, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the OPCUAGDSNamespaceMetadata_IsNamespaceSubset Variable.
        /// </summary>
        public static readonly ExpandedNodeId OPCUAGDSNamespaceMetadata_IsNamespaceSubset = new ExpandedNodeId(Opc.Ua.Gds.Variables.OPCUAGDSNamespaceMetadata_IsNamespaceSubset, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the OPCUAGDSNamespaceMetadata_StaticNodeIdTypes Variable.
        /// </summary>
        public static readonly ExpandedNodeId OPCUAGDSNamespaceMetadata_StaticNodeIdTypes = new ExpandedNodeId(Opc.Ua.Gds.Variables.OPCUAGDSNamespaceMetadata_StaticNodeIdTypes, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the OPCUAGDSNamespaceMetadata_StaticNumericNodeIdRange Variable.
        /// </summary>
        public static readonly ExpandedNodeId OPCUAGDSNamespaceMetadata_StaticNumericNodeIdRange = new ExpandedNodeId(Opc.Ua.Gds.Variables.OPCUAGDSNamespaceMetadata_StaticNumericNodeIdRange, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the OPCUAGDSNamespaceMetadata_StaticStringNodeIdPattern Variable.
        /// </summary>
        public static readonly ExpandedNodeId OPCUAGDSNamespaceMetadata_StaticStringNodeIdPattern = new ExpandedNodeId(Opc.Ua.Gds.Variables.OPCUAGDSNamespaceMetadata_StaticStringNodeIdPattern, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the OPCUAGDSNamespaceMetadata_NamespaceFile_Size Variable.
        /// </summary>
        public static readonly ExpandedNodeId OPCUAGDSNamespaceMetadata_NamespaceFile_Size = new ExpandedNodeId(Opc.Ua.Gds.Variables.OPCUAGDSNamespaceMetadata_NamespaceFile_Size, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the OPCUAGDSNamespaceMetadata_NamespaceFile_Writable Variable.
        /// </summary>
        public static readonly ExpandedNodeId OPCUAGDSNamespaceMetadata_NamespaceFile_Writable = new ExpandedNodeId(Opc.Ua.Gds.Variables.OPCUAGDSNamespaceMetadata_NamespaceFile_Writable, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the OPCUAGDSNamespaceMetadata_NamespaceFile_UserWritable Variable.
        /// </summary>
        public static readonly ExpandedNodeId OPCUAGDSNamespaceMetadata_NamespaceFile_UserWritable = new ExpandedNodeId(Opc.Ua.Gds.Variables.OPCUAGDSNamespaceMetadata_NamespaceFile_UserWritable, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the OPCUAGDSNamespaceMetadata_NamespaceFile_OpenCount Variable.
        /// </summary>
        public static readonly ExpandedNodeId OPCUAGDSNamespaceMetadata_NamespaceFile_OpenCount = new ExpandedNodeId(Opc.Ua.Gds.Variables.OPCUAGDSNamespaceMetadata_NamespaceFile_OpenCount, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the OPCUAGDSNamespaceMetadata_NamespaceFile_Open_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId OPCUAGDSNamespaceMetadata_NamespaceFile_Open_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.OPCUAGDSNamespaceMetadata_NamespaceFile_Open_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the OPCUAGDSNamespaceMetadata_NamespaceFile_Open_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId OPCUAGDSNamespaceMetadata_NamespaceFile_Open_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.OPCUAGDSNamespaceMetadata_NamespaceFile_Open_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the OPCUAGDSNamespaceMetadata_NamespaceFile_Close_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId OPCUAGDSNamespaceMetadata_NamespaceFile_Close_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.OPCUAGDSNamespaceMetadata_NamespaceFile_Close_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the OPCUAGDSNamespaceMetadata_NamespaceFile_Read_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId OPCUAGDSNamespaceMetadata_NamespaceFile_Read_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.OPCUAGDSNamespaceMetadata_NamespaceFile_Read_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the OPCUAGDSNamespaceMetadata_NamespaceFile_Read_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId OPCUAGDSNamespaceMetadata_NamespaceFile_Read_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.OPCUAGDSNamespaceMetadata_NamespaceFile_Read_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the OPCUAGDSNamespaceMetadata_NamespaceFile_Write_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId OPCUAGDSNamespaceMetadata_NamespaceFile_Write_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.OPCUAGDSNamespaceMetadata_NamespaceFile_Write_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the OPCUAGDSNamespaceMetadata_NamespaceFile_GetPosition_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId OPCUAGDSNamespaceMetadata_NamespaceFile_GetPosition_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.OPCUAGDSNamespaceMetadata_NamespaceFile_GetPosition_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the OPCUAGDSNamespaceMetadata_NamespaceFile_GetPosition_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId OPCUAGDSNamespaceMetadata_NamespaceFile_GetPosition_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.OPCUAGDSNamespaceMetadata_NamespaceFile_GetPosition_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the OPCUAGDSNamespaceMetadata_NamespaceFile_SetPosition_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId OPCUAGDSNamespaceMetadata_NamespaceFile_SetPosition_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.OPCUAGDSNamespaceMetadata_NamespaceFile_SetPosition_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the OPCUAGDSNamespaceMetadata_DefaultRolePermissions Variable.
        /// </summary>
        public static readonly ExpandedNodeId OPCUAGDSNamespaceMetadata_DefaultRolePermissions = new ExpandedNodeId(Opc.Ua.Gds.Variables.OPCUAGDSNamespaceMetadata_DefaultRolePermissions, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the OPCUAGDSNamespaceMetadata_DefaultUserRolePermissions Variable.
        /// </summary>
        public static readonly ExpandedNodeId OPCUAGDSNamespaceMetadata_DefaultUserRolePermissions = new ExpandedNodeId(Opc.Ua.Gds.Variables.OPCUAGDSNamespaceMetadata_DefaultUserRolePermissions, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the OPCUAGDSNamespaceMetadata_DefaultAccessRestrictions Variable.
        /// </summary>
        public static readonly ExpandedNodeId OPCUAGDSNamespaceMetadata_DefaultAccessRestrictions = new ExpandedNodeId(Opc.Ua.Gds.Variables.OPCUAGDSNamespaceMetadata_DefaultAccessRestrictions, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the DirectoryType_FindApplications_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId DirectoryType_FindApplications_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.DirectoryType_FindApplications_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the DirectoryType_FindApplications_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId DirectoryType_FindApplications_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.DirectoryType_FindApplications_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the DirectoryType_RegisterApplication_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId DirectoryType_RegisterApplication_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.DirectoryType_RegisterApplication_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the DirectoryType_RegisterApplication_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId DirectoryType_RegisterApplication_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.DirectoryType_RegisterApplication_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the DirectoryType_UpdateApplication_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId DirectoryType_UpdateApplication_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.DirectoryType_UpdateApplication_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the DirectoryType_UnregisterApplication_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId DirectoryType_UnregisterApplication_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.DirectoryType_UnregisterApplication_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the DirectoryType_GetApplication_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId DirectoryType_GetApplication_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.DirectoryType_GetApplication_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the DirectoryType_GetApplication_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId DirectoryType_GetApplication_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.DirectoryType_GetApplication_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the DirectoryType_QueryServers_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId DirectoryType_QueryServers_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.DirectoryType_QueryServers_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the DirectoryType_QueryServers_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId DirectoryType_QueryServers_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.DirectoryType_QueryServers_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_FindApplications_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_FindApplications_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_FindApplications_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_FindApplications_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_FindApplications_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_FindApplications_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_RegisterApplication_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_RegisterApplication_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_RegisterApplication_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_RegisterApplication_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_RegisterApplication_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_RegisterApplication_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_UpdateApplication_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_UpdateApplication_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_UpdateApplication_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_UnregisterApplication_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_UnregisterApplication_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_UnregisterApplication_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_GetApplication_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_GetApplication_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_GetApplication_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_GetApplication_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_GetApplication_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_GetApplication_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_QueryServers_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_QueryServers_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_QueryServers_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_QueryServers_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_QueryServers_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_QueryServers_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_Size Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_Size = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_Size, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_Writable Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_Writable = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_Writable, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_UserWritable Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_UserWritable = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_UserWritable, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_OpenCount Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_OpenCount = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_OpenCount, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_Open_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_Open_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_Open_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_Open_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_Open_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_Open_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_Close_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_Close_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_Close_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_Read_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_Read_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_Read_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_Read_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_Read_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_Read_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_Write_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_Write_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_Write_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_GetPosition_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_GetPosition_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_GetPosition_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_GetPosition_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_GetPosition_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_GetPosition_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_SetPosition_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_SetPosition_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_SetPosition_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_LastUpdateTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_LastUpdateTime = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_LastUpdateTime, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_OpenWithMasks_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_OpenWithMasks_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_OpenWithMasks_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_OpenWithMasks_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_OpenWithMasks_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_OpenWithMasks_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_CloseAndUpdate_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_CloseAndUpdate_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_CloseAndUpdate_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_CloseAndUpdate_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_CloseAndUpdate_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_CloseAndUpdate_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_AddCertificate_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_AddCertificate_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_AddCertificate_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_RemoveCertificate_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_RemoveCertificate_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList_RemoveCertificate_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_CertificateTypes Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_CertificateTypes = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_CertificateTypes, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_Size Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_Size = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_Size, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_Writable Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_Writable = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_Writable, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_UserWritable Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_UserWritable = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_UserWritable, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_OpenCount Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_OpenCount = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_OpenCount, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_Open_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_Open_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_Open_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_Open_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_Open_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_Open_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_Close_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_Close_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_Close_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_Read_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_Read_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_Read_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_Read_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_Read_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_Read_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_Write_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_Write_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_Write_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_GetPosition_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_GetPosition_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_GetPosition_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_GetPosition_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_GetPosition_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_GetPosition_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_SetPosition_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_SetPosition_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_SetPosition_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_LastUpdateTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_LastUpdateTime = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_LastUpdateTime, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_OpenWithMasks_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_OpenWithMasks_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_OpenWithMasks_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_OpenWithMasks_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_OpenWithMasks_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_OpenWithMasks_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_CloseAndUpdate_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_CloseAndUpdate_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_CloseAndUpdate_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_CloseAndUpdate_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_CloseAndUpdate_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_CloseAndUpdate_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_AddCertificate_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_AddCertificate_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_AddCertificate_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_RemoveCertificate_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_RemoveCertificate_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList_RemoveCertificate_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_CertificateTypes Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_CertificateTypes = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_CertificateTypes, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_Size Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_Size = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_Size, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_Writable Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_Writable = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_Writable, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_UserWritable Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_UserWritable = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_UserWritable, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_OpenCount Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_OpenCount = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_OpenCount, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_Open_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_Open_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_Open_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_Open_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_Open_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_Open_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_Close_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_Close_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_Close_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_Read_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_Read_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_Read_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_Read_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_Read_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_Read_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_Write_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_Write_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_Write_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_GetPosition_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_GetPosition_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_GetPosition_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_GetPosition_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_GetPosition_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_GetPosition_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_SetPosition_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_SetPosition_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_SetPosition_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_LastUpdateTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_LastUpdateTime = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_LastUpdateTime, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_OpenWithMasks_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_OpenWithMasks_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_OpenWithMasks_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_OpenWithMasks_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_OpenWithMasks_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_OpenWithMasks_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_CloseAndUpdate_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_CloseAndUpdate_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_CloseAndUpdate_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_CloseAndUpdate_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_CloseAndUpdate_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_CloseAndUpdate_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_AddCertificate_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_AddCertificate_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_AddCertificate_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_RemoveCertificate_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_RemoveCertificate_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList_RemoveCertificate_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_CertificateTypes Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_CertificateTypes = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_CertificateTypes, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_StartSigningRequest_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_StartSigningRequest_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_StartSigningRequest_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_StartSigningRequest_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_StartSigningRequest_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_StartSigningRequest_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_StartNewKeyPairRequest_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_StartNewKeyPairRequest_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_StartNewKeyPairRequest_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_StartNewKeyPairRequest_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_StartNewKeyPairRequest_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_StartNewKeyPairRequest_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_FinishRequest_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_FinishRequest_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_FinishRequest_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_FinishRequest_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_FinishRequest_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_FinishRequest_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_GetCertificateGroups_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_GetCertificateGroups_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_GetCertificateGroups_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_GetCertificateGroups_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_GetCertificateGroups_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_GetCertificateGroups_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_GetTrustList_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_GetTrustList_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_GetTrustList_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_GetTrustList_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_GetTrustList_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_GetTrustList_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_GetCertificateStatus_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_GetCertificateStatus_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_GetCertificateStatus_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDirectoryType_GetCertificateStatus_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDirectoryType_GetCertificateStatus_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDirectoryType_GetCertificateStatus_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateRequestedAuditEventType_CertificateGroup Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateRequestedAuditEventType_CertificateGroup = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateRequestedAuditEventType_CertificateGroup, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateRequestedAuditEventType_CertificateType Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateRequestedAuditEventType_CertificateType = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateRequestedAuditEventType_CertificateType, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDeliveredAuditEventType_CertificateGroup Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDeliveredAuditEventType_CertificateGroup = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDeliveredAuditEventType_CertificateGroup, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CertificateDeliveredAuditEventType_CertificateType Variable.
        /// </summary>
        public static readonly ExpandedNodeId CertificateDeliveredAuditEventType_CertificateType = new ExpandedNodeId(Opc.Ua.Gds.Variables.CertificateDeliveredAuditEventType_CertificateType, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_FindApplications_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_FindApplications_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_FindApplications_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_FindApplications_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_FindApplications_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_FindApplications_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_RegisterApplication_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_RegisterApplication_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_RegisterApplication_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_RegisterApplication_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_RegisterApplication_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_RegisterApplication_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_UpdateApplication_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_UpdateApplication_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_UpdateApplication_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_UnregisterApplication_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_UnregisterApplication_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_UnregisterApplication_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_GetApplication_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_GetApplication_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_GetApplication_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_GetApplication_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_GetApplication_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_GetApplication_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_QueryServers_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_QueryServers_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_QueryServers_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_QueryServers_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_QueryServers_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_QueryServers_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList_Size Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultApplicationGroup_TrustList_Size = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultApplicationGroup_TrustList_Size, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList_Writable Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultApplicationGroup_TrustList_Writable = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultApplicationGroup_TrustList_Writable, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList_UserWritable Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultApplicationGroup_TrustList_UserWritable = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultApplicationGroup_TrustList_UserWritable, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList_OpenCount Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultApplicationGroup_TrustList_OpenCount = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultApplicationGroup_TrustList_OpenCount, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList_Open_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultApplicationGroup_TrustList_Open_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultApplicationGroup_TrustList_Open_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList_Open_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultApplicationGroup_TrustList_Open_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultApplicationGroup_TrustList_Open_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList_Close_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultApplicationGroup_TrustList_Close_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultApplicationGroup_TrustList_Close_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList_Read_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultApplicationGroup_TrustList_Read_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultApplicationGroup_TrustList_Read_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList_Read_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultApplicationGroup_TrustList_Read_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultApplicationGroup_TrustList_Read_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList_Write_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultApplicationGroup_TrustList_Write_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultApplicationGroup_TrustList_Write_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList_GetPosition_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultApplicationGroup_TrustList_GetPosition_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultApplicationGroup_TrustList_GetPosition_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList_GetPosition_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultApplicationGroup_TrustList_GetPosition_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultApplicationGroup_TrustList_GetPosition_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList_SetPosition_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultApplicationGroup_TrustList_SetPosition_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultApplicationGroup_TrustList_SetPosition_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList_LastUpdateTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultApplicationGroup_TrustList_LastUpdateTime = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultApplicationGroup_TrustList_LastUpdateTime, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList_OpenWithMasks_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultApplicationGroup_TrustList_OpenWithMasks_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultApplicationGroup_TrustList_OpenWithMasks_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList_OpenWithMasks_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultApplicationGroup_TrustList_OpenWithMasks_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultApplicationGroup_TrustList_OpenWithMasks_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList_CloseAndUpdate_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultApplicationGroup_TrustList_CloseAndUpdate_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultApplicationGroup_TrustList_CloseAndUpdate_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList_CloseAndUpdate_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultApplicationGroup_TrustList_CloseAndUpdate_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultApplicationGroup_TrustList_CloseAndUpdate_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList_AddCertificate_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultApplicationGroup_TrustList_AddCertificate_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultApplicationGroup_TrustList_AddCertificate_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_TrustList_RemoveCertificate_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultApplicationGroup_TrustList_RemoveCertificate_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultApplicationGroup_TrustList_RemoveCertificate_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultApplicationGroup_CertificateTypes Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultApplicationGroup_CertificateTypes = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultApplicationGroup_CertificateTypes, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList_Size Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultHttpsGroup_TrustList_Size = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultHttpsGroup_TrustList_Size, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList_Writable Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultHttpsGroup_TrustList_Writable = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultHttpsGroup_TrustList_Writable, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList_UserWritable Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultHttpsGroup_TrustList_UserWritable = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultHttpsGroup_TrustList_UserWritable, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList_OpenCount Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultHttpsGroup_TrustList_OpenCount = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultHttpsGroup_TrustList_OpenCount, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList_Open_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultHttpsGroup_TrustList_Open_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultHttpsGroup_TrustList_Open_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList_Open_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultHttpsGroup_TrustList_Open_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultHttpsGroup_TrustList_Open_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList_Close_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultHttpsGroup_TrustList_Close_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultHttpsGroup_TrustList_Close_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList_Read_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultHttpsGroup_TrustList_Read_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultHttpsGroup_TrustList_Read_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList_Read_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultHttpsGroup_TrustList_Read_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultHttpsGroup_TrustList_Read_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList_Write_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultHttpsGroup_TrustList_Write_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultHttpsGroup_TrustList_Write_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList_GetPosition_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultHttpsGroup_TrustList_GetPosition_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultHttpsGroup_TrustList_GetPosition_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList_GetPosition_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultHttpsGroup_TrustList_GetPosition_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultHttpsGroup_TrustList_GetPosition_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList_SetPosition_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultHttpsGroup_TrustList_SetPosition_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultHttpsGroup_TrustList_SetPosition_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList_LastUpdateTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultHttpsGroup_TrustList_LastUpdateTime = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultHttpsGroup_TrustList_LastUpdateTime, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList_OpenWithMasks_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultHttpsGroup_TrustList_OpenWithMasks_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultHttpsGroup_TrustList_OpenWithMasks_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList_OpenWithMasks_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultHttpsGroup_TrustList_OpenWithMasks_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultHttpsGroup_TrustList_OpenWithMasks_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList_CloseAndUpdate_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultHttpsGroup_TrustList_CloseAndUpdate_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultHttpsGroup_TrustList_CloseAndUpdate_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList_CloseAndUpdate_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultHttpsGroup_TrustList_CloseAndUpdate_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultHttpsGroup_TrustList_CloseAndUpdate_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList_AddCertificate_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultHttpsGroup_TrustList_AddCertificate_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultHttpsGroup_TrustList_AddCertificate_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_TrustList_RemoveCertificate_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultHttpsGroup_TrustList_RemoveCertificate_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultHttpsGroup_TrustList_RemoveCertificate_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultHttpsGroup_CertificateTypes Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultHttpsGroup_CertificateTypes = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultHttpsGroup_CertificateTypes, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_Size Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_Size = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_Size, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_Writable Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_Writable = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_Writable, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_UserWritable Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_UserWritable = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_UserWritable, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_OpenCount Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_OpenCount = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_OpenCount, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_Open_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_Open_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_Open_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_Open_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_Open_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_Open_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_Close_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_Close_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_Close_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_Read_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_Read_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_Read_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_Read_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_Read_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_Read_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_Write_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_Write_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_Write_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_GetPosition_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_GetPosition_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_GetPosition_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_GetPosition_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_GetPosition_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_GetPosition_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_SetPosition_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_SetPosition_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_SetPosition_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_LastUpdateTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_LastUpdateTime = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_LastUpdateTime, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_OpenWithMasks_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_OpenWithMasks_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_OpenWithMasks_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_OpenWithMasks_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_OpenWithMasks_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_OpenWithMasks_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_CloseAndUpdate_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_CloseAndUpdate_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_CloseAndUpdate_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_CloseAndUpdate_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_CloseAndUpdate_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_CloseAndUpdate_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_AddCertificate_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_AddCertificate_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_AddCertificate_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_RemoveCertificate_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_RemoveCertificate_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultUserTokenGroup_TrustList_RemoveCertificate_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_CertificateGroups_DefaultUserTokenGroup_CertificateTypes Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultUserTokenGroup_CertificateTypes = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_CertificateGroups_DefaultUserTokenGroup_CertificateTypes, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_StartSigningRequest_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_StartSigningRequest_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_StartSigningRequest_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_StartSigningRequest_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_StartSigningRequest_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_StartSigningRequest_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_StartNewKeyPairRequest_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_StartNewKeyPairRequest_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_StartNewKeyPairRequest_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_StartNewKeyPairRequest_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_StartNewKeyPairRequest_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_StartNewKeyPairRequest_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_FinishRequest_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_FinishRequest_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_FinishRequest_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_FinishRequest_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_FinishRequest_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_FinishRequest_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_GetCertificateGroups_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_GetCertificateGroups_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_GetCertificateGroups_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_GetCertificateGroups_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_GetCertificateGroups_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_GetCertificateGroups_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_GetTrustList_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_GetTrustList_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_GetTrustList_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_GetTrustList_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_GetTrustList_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_GetTrustList_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_GetCertificateStatus_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_GetCertificateStatus_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_GetCertificateStatus_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the Directory_GetCertificateStatus_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Directory_GetCertificateStatus_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.Directory_GetCertificateStatus_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the NetworkServiceFolderType_ServiceName_Placeholder_StartCredentialRequest_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId NetworkServiceFolderType_ServiceName_Placeholder_StartCredentialRequest_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.NetworkServiceFolderType_ServiceName_Placeholder_StartCredentialRequest_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the NetworkServiceFolderType_ServiceName_Placeholder_StartCredentialRequest_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId NetworkServiceFolderType_ServiceName_Placeholder_StartCredentialRequest_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.NetworkServiceFolderType_ServiceName_Placeholder_StartCredentialRequest_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the NetworkServiceFolderType_ServiceName_Placeholder_FinishCredentialRequest_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId NetworkServiceFolderType_ServiceName_Placeholder_FinishCredentialRequest_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.NetworkServiceFolderType_ServiceName_Placeholder_FinishCredentialRequest_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the NetworkServiceFolderType_ServiceName_Placeholder_FinishCredentialRequest_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId NetworkServiceFolderType_ServiceName_Placeholder_FinishCredentialRequest_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.NetworkServiceFolderType_ServiceName_Placeholder_FinishCredentialRequest_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the NetworkServiceFolderType_ServiceName_Placeholder_RevokeCredential_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId NetworkServiceFolderType_ServiceName_Placeholder_RevokeCredential_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.NetworkServiceFolderType_ServiceName_Placeholder_RevokeCredential_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the AuthorizationServices_ServiceName_Placeholder_StartCredentialRequest_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId AuthorizationServices_ServiceName_Placeholder_StartCredentialRequest_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.AuthorizationServices_ServiceName_Placeholder_StartCredentialRequest_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the AuthorizationServices_ServiceName_Placeholder_StartCredentialRequest_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId AuthorizationServices_ServiceName_Placeholder_StartCredentialRequest_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.AuthorizationServices_ServiceName_Placeholder_StartCredentialRequest_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the AuthorizationServices_ServiceName_Placeholder_FinishCredentialRequest_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId AuthorizationServices_ServiceName_Placeholder_FinishCredentialRequest_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.AuthorizationServices_ServiceName_Placeholder_FinishCredentialRequest_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the AuthorizationServices_ServiceName_Placeholder_FinishCredentialRequest_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId AuthorizationServices_ServiceName_Placeholder_FinishCredentialRequest_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.AuthorizationServices_ServiceName_Placeholder_FinishCredentialRequest_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the AuthorizationServices_ServiceName_Placeholder_RevokeCredential_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId AuthorizationServices_ServiceName_Placeholder_RevokeCredential_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.AuthorizationServices_ServiceName_Placeholder_RevokeCredential_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CredentialManagementType_StartCredentialRequest_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CredentialManagementType_StartCredentialRequest_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CredentialManagementType_StartCredentialRequest_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CredentialManagementType_StartCredentialRequest_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CredentialManagementType_StartCredentialRequest_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CredentialManagementType_StartCredentialRequest_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CredentialManagementType_FinishCredentialRequest_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CredentialManagementType_FinishCredentialRequest_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CredentialManagementType_FinishCredentialRequest_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CredentialManagementType_FinishCredentialRequest_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CredentialManagementType_FinishCredentialRequest_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CredentialManagementType_FinishCredentialRequest_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CredentialManagementType_RevokeCredential_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CredentialManagementType_RevokeCredential_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.CredentialManagementType_RevokeCredential_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the NetworkServiceType_ServiceUri Variable.
        /// </summary>
        public static readonly ExpandedNodeId NetworkServiceType_ServiceUri = new ExpandedNodeId(Opc.Ua.Gds.Variables.NetworkServiceType_ServiceUri, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the NetworkServiceType_ServiceProfileUri Variable.
        /// </summary>
        public static readonly ExpandedNodeId NetworkServiceType_ServiceProfileUri = new ExpandedNodeId(Opc.Ua.Gds.Variables.NetworkServiceType_ServiceProfileUri, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the NetworkServiceType_ServiceEndpointUrls Variable.
        /// </summary>
        public static readonly ExpandedNodeId NetworkServiceType_ServiceEndpointUrls = new ExpandedNodeId(Opc.Ua.Gds.Variables.NetworkServiceType_ServiceEndpointUrls, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the NetworkServiceType_CredentialManagement_StartCredentialRequest_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId NetworkServiceType_CredentialManagement_StartCredentialRequest_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.NetworkServiceType_CredentialManagement_StartCredentialRequest_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the NetworkServiceType_CredentialManagement_StartCredentialRequest_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId NetworkServiceType_CredentialManagement_StartCredentialRequest_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.NetworkServiceType_CredentialManagement_StartCredentialRequest_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the NetworkServiceType_CredentialManagement_FinishCredentialRequest_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId NetworkServiceType_CredentialManagement_FinishCredentialRequest_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.NetworkServiceType_CredentialManagement_FinishCredentialRequest_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the NetworkServiceType_CredentialManagement_FinishCredentialRequest_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId NetworkServiceType_CredentialManagement_FinishCredentialRequest_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.NetworkServiceType_CredentialManagement_FinishCredentialRequest_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the NetworkServiceType_CredentialManagement_RevokeCredential_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId NetworkServiceType_CredentialManagement_RevokeCredential_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.NetworkServiceType_CredentialManagement_RevokeCredential_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the AuthorizationServiceType_CredentialManagement_StartCredentialRequest_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId AuthorizationServiceType_CredentialManagement_StartCredentialRequest_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.AuthorizationServiceType_CredentialManagement_StartCredentialRequest_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the AuthorizationServiceType_CredentialManagement_StartCredentialRequest_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId AuthorizationServiceType_CredentialManagement_StartCredentialRequest_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.AuthorizationServiceType_CredentialManagement_StartCredentialRequest_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the AuthorizationServiceType_CredentialManagement_FinishCredentialRequest_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId AuthorizationServiceType_CredentialManagement_FinishCredentialRequest_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.AuthorizationServiceType_CredentialManagement_FinishCredentialRequest_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the AuthorizationServiceType_CredentialManagement_FinishCredentialRequest_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId AuthorizationServiceType_CredentialManagement_FinishCredentialRequest_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.AuthorizationServiceType_CredentialManagement_FinishCredentialRequest_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the AuthorizationServiceType_CredentialManagement_RevokeCredential_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId AuthorizationServiceType_CredentialManagement_RevokeCredential_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.AuthorizationServiceType_CredentialManagement_RevokeCredential_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the AuthorizationServiceType_UserTokenPolicies Variable.
        /// </summary>
        public static readonly ExpandedNodeId AuthorizationServiceType_UserTokenPolicies = new ExpandedNodeId(Opc.Ua.Gds.Variables.AuthorizationServiceType_UserTokenPolicies, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the AuthorizationServiceType_RequestAccessToken_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId AuthorizationServiceType_RequestAccessToken_InputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.AuthorizationServiceType_RequestAccessToken_InputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the AuthorizationServiceType_RequestAccessToken_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId AuthorizationServiceType_RequestAccessToken_OutputArguments = new ExpandedNodeId(Opc.Ua.Gds.Variables.AuthorizationServiceType_RequestAccessToken_OutputArguments, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CredentialRequestedAuditEventType_ServiceUri Variable.
        /// </summary>
        public static readonly ExpandedNodeId CredentialRequestedAuditEventType_ServiceUri = new ExpandedNodeId(Opc.Ua.Gds.Variables.CredentialRequestedAuditEventType_ServiceUri, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CredentialDeliveredAuditEventType_ServiceUri Variable.
        /// </summary>
        public static readonly ExpandedNodeId CredentialDeliveredAuditEventType_ServiceUri = new ExpandedNodeId(Opc.Ua.Gds.Variables.CredentialDeliveredAuditEventType_ServiceUri, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the CredentialRevokedAuditEventType_ServiceUri Variable.
        /// </summary>
        public static readonly ExpandedNodeId CredentialRevokedAuditEventType_ServiceUri = new ExpandedNodeId(Opc.Ua.Gds.Variables.CredentialRevokedAuditEventType_ServiceUri, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the OpcUaGds_XmlSchema Variable.
        /// </summary>
        public static readonly ExpandedNodeId OpcUaGds_XmlSchema = new ExpandedNodeId(Opc.Ua.Gds.Variables.OpcUaGds_XmlSchema, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the OpcUaGds_XmlSchema_NamespaceUri Variable.
        /// </summary>
        public static readonly ExpandedNodeId OpcUaGds_XmlSchema_NamespaceUri = new ExpandedNodeId(Opc.Ua.Gds.Variables.OpcUaGds_XmlSchema_NamespaceUri, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the OpcUaGds_XmlSchema_ApplicationRecordDataType Variable.
        /// </summary>
        public static readonly ExpandedNodeId OpcUaGds_XmlSchema_ApplicationRecordDataType = new ExpandedNodeId(Opc.Ua.Gds.Variables.OpcUaGds_XmlSchema_ApplicationRecordDataType, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the OpcUaGds_BinarySchema Variable.
        /// </summary>
        public static readonly ExpandedNodeId OpcUaGds_BinarySchema = new ExpandedNodeId(Opc.Ua.Gds.Variables.OpcUaGds_BinarySchema, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the OpcUaGds_BinarySchema_NamespaceUri Variable.
        /// </summary>
        public static readonly ExpandedNodeId OpcUaGds_BinarySchema_NamespaceUri = new ExpandedNodeId(Opc.Ua.Gds.Variables.OpcUaGds_BinarySchema_NamespaceUri, Opc.Ua.Gds.Namespaces.OpcUaGds);

        /// <summary>
        /// The identifier for the OpcUaGds_BinarySchema_ApplicationRecordDataType Variable.
        /// </summary>
        public static readonly ExpandedNodeId OpcUaGds_BinarySchema_ApplicationRecordDataType = new ExpandedNodeId(Opc.Ua.Gds.Variables.OpcUaGds_BinarySchema_ApplicationRecordDataType, Opc.Ua.Gds.Namespaces.OpcUaGds);
    }
    #endregion

    #region BrowseName Declarations
    /// <summary>
    /// Declares all of the BrowseNames used in the Model Design.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class BrowseNames
    {
        /// <summary>
        /// The BrowseName for the ApplicationRecordDataType component.
        /// </summary>
        public const string ApplicationRecordDataType = "ApplicationRecordDataType";

        /// <summary>
        /// The BrowseName for the ApplicationRegistrationChangedAuditEventType component.
        /// </summary>
        public const string ApplicationRegistrationChangedAuditEventType = "ApplicationRegistrationChangedAuditEventType";

        /// <summary>
        /// The BrowseName for the Applications component.
        /// </summary>
        public const string Applications = "Applications";

        /// <summary>
        /// The BrowseName for the AuthorizationServices component.
        /// </summary>
        public const string AuthorizationServices = "AuthorizationServices";

        /// <summary>
        /// The BrowseName for the AuthorizationServiceType component.
        /// </summary>
        public const string AuthorizationServiceType = "AuthorizationServiceType";

        /// <summary>
        /// The BrowseName for the CertificateDeliveredAuditEventType component.
        /// </summary>
        public const string CertificateDeliveredAuditEventType = "CertificateDeliveredAuditEventType";

        /// <summary>
        /// The BrowseName for the CertificateDirectoryType component.
        /// </summary>
        public const string CertificateDirectoryType = "CertificateDirectoryType";

        /// <summary>
        /// The BrowseName for the CertificateGroup component.
        /// </summary>
        public const string CertificateGroup = "CertificateGroup";

        /// <summary>
        /// The BrowseName for the CertificateGroups component.
        /// </summary>
        public const string CertificateGroups = "CertificateGroups";

        /// <summary>
        /// The BrowseName for the CertificateRequestedAuditEventType component.
        /// </summary>
        public const string CertificateRequestedAuditEventType = "CertificateRequestedAuditEventType";

        /// <summary>
        /// The BrowseName for the CertificateType component.
        /// </summary>
        public const string CertificateType = "CertificateType";

        /// <summary>
        /// The BrowseName for the CredentialDeliveredAuditEventType component.
        /// </summary>
        public const string CredentialDeliveredAuditEventType = "CredentialDeliveredAuditEventType";

        /// <summary>
        /// The BrowseName for the CredentialManagement component.
        /// </summary>
        public const string CredentialManagement = "CredentialManagement";

        /// <summary>
        /// The BrowseName for the CredentialManagementType component.
        /// </summary>
        public const string CredentialManagementType = "CredentialManagementType";

        /// <summary>
        /// The BrowseName for the CredentialRequestedAuditEventType component.
        /// </summary>
        public const string CredentialRequestedAuditEventType = "CredentialRequestedAuditEventType";

        /// <summary>
        /// The BrowseName for the CredentialRevokedAuditEventType component.
        /// </summary>
        public const string CredentialRevokedAuditEventType = "CredentialRevokedAuditEventType";

        /// <summary>
        /// The BrowseName for the DefaultAccessRestrictions component.
        /// </summary>
        public const string DefaultAccessRestrictions = "DefaultAccessRestrictions";

        /// <summary>
        /// The BrowseName for the DefaultRolePermissions component.
        /// </summary>
        public const string DefaultRolePermissions = "DefaultRolePermissions";

        /// <summary>
        /// The BrowseName for the DefaultUserRolePermissions component.
        /// </summary>
        public const string DefaultUserRolePermissions = "DefaultUserRolePermissions";

        /// <summary>
        /// The BrowseName for the Directory component.
        /// </summary>
        public const string Directory = "Directory";

        /// <summary>
        /// The BrowseName for the DirectoryType component.
        /// </summary>
        public const string DirectoryType = "DirectoryType";

        /// <summary>
        /// The BrowseName for the FindApplications component.
        /// </summary>
        public const string FindApplications = "FindApplications";

        /// <summary>
        /// The BrowseName for the FinishCredentialRequest component.
        /// </summary>
        public const string FinishCredentialRequest = "FinishCredentialRequest";

        /// <summary>
        /// The BrowseName for the FinishRequest component.
        /// </summary>
        public const string FinishRequest = "FinishRequest";

        /// <summary>
        /// The BrowseName for the GetApplication component.
        /// </summary>
        public const string GetApplication = "GetApplication";

        /// <summary>
        /// The BrowseName for the GetCertificateGroups component.
        /// </summary>
        public const string GetCertificateGroups = "GetCertificateGroups";

        /// <summary>
        /// The BrowseName for the GetCertificateStatus component.
        /// </summary>
        public const string GetCertificateStatus = "GetCertificateStatus";

        /// <summary>
        /// The BrowseName for the GetTrustList component.
        /// </summary>
        public const string GetTrustList = "GetTrustList";

        /// <summary>
        /// The BrowseName for the IsNamespaceSubset component.
        /// </summary>
        public const string IsNamespaceSubset = "IsNamespaceSubset";

        /// <summary>
        /// The BrowseName for the NamespacePublicationDate component.
        /// </summary>
        public const string NamespacePublicationDate = "NamespacePublicationDate";

        /// <summary>
        /// The BrowseName for the NamespaceUri component.
        /// </summary>
        public const string NamespaceUri = "NamespaceUri";

        /// <summary>
        /// The BrowseName for the NamespaceVersion component.
        /// </summary>
        public const string NamespaceVersion = "NamespaceVersion";

        /// <summary>
        /// The BrowseName for the NetworkServiceFolderType component.
        /// </summary>
        public const string NetworkServiceFolderType = "NetworkServiceFolderType";

        /// <summary>
        /// The BrowseName for the NetworkServiceType component.
        /// </summary>
        public const string NetworkServiceType = "NetworkServiceType";

        /// <summary>
        /// The BrowseName for the OpcUaGds_BinarySchema component.
        /// </summary>
        public const string OpcUaGds_BinarySchema = "Opc.Ua.Gds";

        /// <summary>
        /// The BrowseName for the OpcUaGds_XmlSchema component.
        /// </summary>
        public const string OpcUaGds_XmlSchema = "Opc.Ua.Gds";

        /// <summary>
        /// The BrowseName for the OPCUAGDSNamespaceMetadata component.
        /// </summary>
        public const string OPCUAGDSNamespaceMetadata = "http://opcfoundation.org/UA/GDS/";

        /// <summary>
        /// The BrowseName for the QueryServers component.
        /// </summary>
        public const string QueryServers = "QueryServers";

        /// <summary>
        /// The BrowseName for the RegisterApplication component.
        /// </summary>
        public const string RegisterApplication = "RegisterApplication";

        /// <summary>
        /// The BrowseName for the RequestAccessToken component.
        /// </summary>
        public const string RequestAccessToken = "RequestAccessToken";

        /// <summary>
        /// The BrowseName for the RevokeCredential component.
        /// </summary>
        public const string RevokeCredential = "RevokeCredential";

        /// <summary>
        /// The BrowseName for the ServiceEndpointUrls component.
        /// </summary>
        public const string ServiceEndpointUrls = "ServiceEndpointUrls";

        /// <summary>
        /// The BrowseName for the ServiceName_Placeholder component.
        /// </summary>
        public const string ServiceName_Placeholder = "<ServiceName>";

        /// <summary>
        /// The BrowseName for the ServiceProfileUri component.
        /// </summary>
        public const string ServiceProfileUri = "ServiceProfileUri";

        /// <summary>
        /// The BrowseName for the ServiceUri component.
        /// </summary>
        public const string ServiceUri = "ServiceUri";

        /// <summary>
        /// The BrowseName for the StartCredentialRequest component.
        /// </summary>
        public const string StartCredentialRequest = "StartCredentialRequest";

        /// <summary>
        /// The BrowseName for the StartNewKeyPairRequest component.
        /// </summary>
        public const string StartNewKeyPairRequest = "StartNewKeyPairRequest";

        /// <summary>
        /// The BrowseName for the StartSigningRequest component.
        /// </summary>
        public const string StartSigningRequest = "StartSigningRequest";

        /// <summary>
        /// The BrowseName for the StaticNodeIdTypes component.
        /// </summary>
        public const string StaticNodeIdTypes = "StaticNodeIdTypes";

        /// <summary>
        /// The BrowseName for the StaticNumericNodeIdRange component.
        /// </summary>
        public const string StaticNumericNodeIdRange = "StaticNumericNodeIdRange";

        /// <summary>
        /// The BrowseName for the StaticStringNodeIdPattern component.
        /// </summary>
        public const string StaticStringNodeIdPattern = "StaticStringNodeIdPattern";

        /// <summary>
        /// The BrowseName for the UnregisterApplication component.
        /// </summary>
        public const string UnregisterApplication = "UnregisterApplication";

        /// <summary>
        /// The BrowseName for the UpdateApplication component.
        /// </summary>
        public const string UpdateApplication = "UpdateApplication";

        /// <summary>
        /// The BrowseName for the UserTokenPolicies component.
        /// </summary>
        public const string UserTokenPolicies = "UserTokenPolicies";
    }
    #endregion

    #region Namespace Declarations
    /// <summary>
    /// Defines constants for all namespaces referenced by the model design.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Namespaces
    {
        /// <summary>
        /// The URI for the OpcUaGds namespace (.NET code namespace is 'Opc.Ua.Gds').
        /// </summary>
        public const string OpcUaGds = "http://opcfoundation.org/UA/GDS/";

        /// <summary>
        /// The URI for the OpcUaGdsXsd namespace (.NET code namespace is 'Opc.Ua.Gds').
        /// </summary>
        public const string OpcUaGdsXsd = "http://opcfoundation.org/UA/GDS/Types.xsd";

        /// <summary>
        /// The URI for the OpcUa namespace (.NET code namespace is 'Opc.Ua').
        /// </summary>
        public const string OpcUa = "http://opcfoundation.org/UA/";

        /// <summary>
        /// The URI for the OpcUaXsd namespace (.NET code namespace is 'Opc.Ua').
        /// </summary>
        public const string OpcUaXsd = "http://opcfoundation.org/UA/2008/02/Types.xsd";
    }
    #endregion
}