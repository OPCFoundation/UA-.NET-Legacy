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

namespace Quickstarts.Reference
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
        /// The identifier for the DataType1 DataType.
        /// </summary>
        public const uint DataType1 = 1;

        /// <summary>
        /// The identifier for the DataType2 DataType.
        /// </summary>
        public const uint DataType2 = 2;

        /// <summary>
        /// The identifier for the DataType3 DataType.
        /// </summary>
        public const uint DataType3 = 3;

        /// <summary>
        /// The identifier for the DataType4 DataType.
        /// </summary>
        public const uint DataType4 = 4;
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
        /// The identifier for the StructuredTypeVariables Object.
        /// </summary>
        public const uint StructuredTypeVariables = 5;

        /// <summary>
        /// The identifier for the DataType1_Encoding_DefaultXml Object.
        /// </summary>
        public const uint DataType1_Encoding_DefaultXml = 10;

        /// <summary>
        /// The identifier for the DataType2_Encoding_DefaultXml Object.
        /// </summary>
        public const uint DataType2_Encoding_DefaultXml = 11;

        /// <summary>
        /// The identifier for the DataType3_Encoding_DefaultXml Object.
        /// </summary>
        public const uint DataType3_Encoding_DefaultXml = 12;

        /// <summary>
        /// The identifier for the DataType4_Encoding_DefaultXml Object.
        /// </summary>
        public const uint DataType4_Encoding_DefaultXml = 13;

        /// <summary>
        /// The identifier for the DataType1_Encoding_DefaultBinary Object.
        /// </summary>
        public const uint DataType1_Encoding_DefaultBinary = 29;

        /// <summary>
        /// The identifier for the DataType2_Encoding_DefaultBinary Object.
        /// </summary>
        public const uint DataType2_Encoding_DefaultBinary = 30;

        /// <summary>
        /// The identifier for the DataType3_Encoding_DefaultBinary Object.
        /// </summary>
        public const uint DataType3_Encoding_DefaultBinary = 31;

        /// <summary>
        /// The identifier for the DataType4_Encoding_DefaultBinary Object.
        /// </summary>
        public const uint DataType4_Encoding_DefaultBinary = 32;
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
        /// The identifier for the StructuredTypeVariables_DataType1Variable Variable.
        /// </summary>
        public const uint StructuredTypeVariables_DataType1Variable = 6;

        /// <summary>
        /// The identifier for the StructuredTypeVariables_DataType2Variable Variable.
        /// </summary>
        public const uint StructuredTypeVariables_DataType2Variable = 7;

        /// <summary>
        /// The identifier for the StructuredTypeVariables_DataType3Variable Variable.
        /// </summary>
        public const uint StructuredTypeVariables_DataType3Variable = 8;

        /// <summary>
        /// The identifier for the StructuredTypeVariables_DataType4Variable Variable.
        /// </summary>
        public const uint StructuredTypeVariables_DataType4Variable = 9;

        /// <summary>
        /// The identifier for the Reference_XmlSchema Variable.
        /// </summary>
        public const uint Reference_XmlSchema = 14;

        /// <summary>
        /// The identifier for the Reference_XmlSchema_NamespaceUri Variable.
        /// </summary>
        public const uint Reference_XmlSchema_NamespaceUri = 16;

        /// <summary>
        /// The identifier for the Reference_XmlSchema_DataType1 Variable.
        /// </summary>
        public const uint Reference_XmlSchema_DataType1 = 17;

        /// <summary>
        /// The identifier for the Reference_XmlSchema_DataType2 Variable.
        /// </summary>
        public const uint Reference_XmlSchema_DataType2 = 20;

        /// <summary>
        /// The identifier for the Reference_XmlSchema_DataType3 Variable.
        /// </summary>
        public const uint Reference_XmlSchema_DataType3 = 23;

        /// <summary>
        /// The identifier for the Reference_XmlSchema_DataType4 Variable.
        /// </summary>
        public const uint Reference_XmlSchema_DataType4 = 26;

        /// <summary>
        /// The identifier for the Reference_BinarySchema Variable.
        /// </summary>
        public const uint Reference_BinarySchema = 33;

        /// <summary>
        /// The identifier for the Reference_BinarySchema_NamespaceUri Variable.
        /// </summary>
        public const uint Reference_BinarySchema_NamespaceUri = 35;

        /// <summary>
        /// The identifier for the Reference_BinarySchema_DataType1 Variable.
        /// </summary>
        public const uint Reference_BinarySchema_DataType1 = 36;

        /// <summary>
        /// The identifier for the Reference_BinarySchema_DataType2 Variable.
        /// </summary>
        public const uint Reference_BinarySchema_DataType2 = 39;

        /// <summary>
        /// The identifier for the Reference_BinarySchema_DataType3 Variable.
        /// </summary>
        public const uint Reference_BinarySchema_DataType3 = 42;

        /// <summary>
        /// The identifier for the Reference_BinarySchema_DataType4 Variable.
        /// </summary>
        public const uint Reference_BinarySchema_DataType4 = 45;
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
        /// The identifier for the DataType1 DataType.
        /// </summary>
        public static readonly ExpandedNodeId DataType1 = new ExpandedNodeId(Quickstarts.Reference.DataTypes.DataType1, Quickstarts.Reference.Namespaces.Reference);

        /// <summary>
        /// The identifier for the DataType2 DataType.
        /// </summary>
        public static readonly ExpandedNodeId DataType2 = new ExpandedNodeId(Quickstarts.Reference.DataTypes.DataType2, Quickstarts.Reference.Namespaces.Reference);

        /// <summary>
        /// The identifier for the DataType3 DataType.
        /// </summary>
        public static readonly ExpandedNodeId DataType3 = new ExpandedNodeId(Quickstarts.Reference.DataTypes.DataType3, Quickstarts.Reference.Namespaces.Reference);

        /// <summary>
        /// The identifier for the DataType4 DataType.
        /// </summary>
        public static readonly ExpandedNodeId DataType4 = new ExpandedNodeId(Quickstarts.Reference.DataTypes.DataType4, Quickstarts.Reference.Namespaces.Reference);
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
        /// The identifier for the StructuredTypeVariables Object.
        /// </summary>
        public static readonly ExpandedNodeId StructuredTypeVariables = new ExpandedNodeId(Quickstarts.Reference.Objects.StructuredTypeVariables, Quickstarts.Reference.Namespaces.Reference);

        /// <summary>
        /// The identifier for the DataType1_Encoding_DefaultXml Object.
        /// </summary>
        public static readonly ExpandedNodeId DataType1_Encoding_DefaultXml = new ExpandedNodeId(Quickstarts.Reference.Objects.DataType1_Encoding_DefaultXml, Quickstarts.Reference.Namespaces.Reference);

        /// <summary>
        /// The identifier for the DataType2_Encoding_DefaultXml Object.
        /// </summary>
        public static readonly ExpandedNodeId DataType2_Encoding_DefaultXml = new ExpandedNodeId(Quickstarts.Reference.Objects.DataType2_Encoding_DefaultXml, Quickstarts.Reference.Namespaces.Reference);

        /// <summary>
        /// The identifier for the DataType3_Encoding_DefaultXml Object.
        /// </summary>
        public static readonly ExpandedNodeId DataType3_Encoding_DefaultXml = new ExpandedNodeId(Quickstarts.Reference.Objects.DataType3_Encoding_DefaultXml, Quickstarts.Reference.Namespaces.Reference);

        /// <summary>
        /// The identifier for the DataType4_Encoding_DefaultXml Object.
        /// </summary>
        public static readonly ExpandedNodeId DataType4_Encoding_DefaultXml = new ExpandedNodeId(Quickstarts.Reference.Objects.DataType4_Encoding_DefaultXml, Quickstarts.Reference.Namespaces.Reference);

        /// <summary>
        /// The identifier for the DataType1_Encoding_DefaultBinary Object.
        /// </summary>
        public static readonly ExpandedNodeId DataType1_Encoding_DefaultBinary = new ExpandedNodeId(Quickstarts.Reference.Objects.DataType1_Encoding_DefaultBinary, Quickstarts.Reference.Namespaces.Reference);

        /// <summary>
        /// The identifier for the DataType2_Encoding_DefaultBinary Object.
        /// </summary>
        public static readonly ExpandedNodeId DataType2_Encoding_DefaultBinary = new ExpandedNodeId(Quickstarts.Reference.Objects.DataType2_Encoding_DefaultBinary, Quickstarts.Reference.Namespaces.Reference);

        /// <summary>
        /// The identifier for the DataType3_Encoding_DefaultBinary Object.
        /// </summary>
        public static readonly ExpandedNodeId DataType3_Encoding_DefaultBinary = new ExpandedNodeId(Quickstarts.Reference.Objects.DataType3_Encoding_DefaultBinary, Quickstarts.Reference.Namespaces.Reference);

        /// <summary>
        /// The identifier for the DataType4_Encoding_DefaultBinary Object.
        /// </summary>
        public static readonly ExpandedNodeId DataType4_Encoding_DefaultBinary = new ExpandedNodeId(Quickstarts.Reference.Objects.DataType4_Encoding_DefaultBinary, Quickstarts.Reference.Namespaces.Reference);
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
        /// The identifier for the StructuredTypeVariables_DataType1Variable Variable.
        /// </summary>
        public static readonly ExpandedNodeId StructuredTypeVariables_DataType1Variable = new ExpandedNodeId(Quickstarts.Reference.Variables.StructuredTypeVariables_DataType1Variable, Quickstarts.Reference.Namespaces.Reference);

        /// <summary>
        /// The identifier for the StructuredTypeVariables_DataType2Variable Variable.
        /// </summary>
        public static readonly ExpandedNodeId StructuredTypeVariables_DataType2Variable = new ExpandedNodeId(Quickstarts.Reference.Variables.StructuredTypeVariables_DataType2Variable, Quickstarts.Reference.Namespaces.Reference);

        /// <summary>
        /// The identifier for the StructuredTypeVariables_DataType3Variable Variable.
        /// </summary>
        public static readonly ExpandedNodeId StructuredTypeVariables_DataType3Variable = new ExpandedNodeId(Quickstarts.Reference.Variables.StructuredTypeVariables_DataType3Variable, Quickstarts.Reference.Namespaces.Reference);

        /// <summary>
        /// The identifier for the StructuredTypeVariables_DataType4Variable Variable.
        /// </summary>
        public static readonly ExpandedNodeId StructuredTypeVariables_DataType4Variable = new ExpandedNodeId(Quickstarts.Reference.Variables.StructuredTypeVariables_DataType4Variable, Quickstarts.Reference.Namespaces.Reference);

        /// <summary>
        /// The identifier for the Reference_XmlSchema Variable.
        /// </summary>
        public static readonly ExpandedNodeId Reference_XmlSchema = new ExpandedNodeId(Quickstarts.Reference.Variables.Reference_XmlSchema, Quickstarts.Reference.Namespaces.Reference);

        /// <summary>
        /// The identifier for the Reference_XmlSchema_NamespaceUri Variable.
        /// </summary>
        public static readonly ExpandedNodeId Reference_XmlSchema_NamespaceUri = new ExpandedNodeId(Quickstarts.Reference.Variables.Reference_XmlSchema_NamespaceUri, Quickstarts.Reference.Namespaces.Reference);

        /// <summary>
        /// The identifier for the Reference_XmlSchema_DataType1 Variable.
        /// </summary>
        public static readonly ExpandedNodeId Reference_XmlSchema_DataType1 = new ExpandedNodeId(Quickstarts.Reference.Variables.Reference_XmlSchema_DataType1, Quickstarts.Reference.Namespaces.Reference);

        /// <summary>
        /// The identifier for the Reference_XmlSchema_DataType2 Variable.
        /// </summary>
        public static readonly ExpandedNodeId Reference_XmlSchema_DataType2 = new ExpandedNodeId(Quickstarts.Reference.Variables.Reference_XmlSchema_DataType2, Quickstarts.Reference.Namespaces.Reference);

        /// <summary>
        /// The identifier for the Reference_XmlSchema_DataType3 Variable.
        /// </summary>
        public static readonly ExpandedNodeId Reference_XmlSchema_DataType3 = new ExpandedNodeId(Quickstarts.Reference.Variables.Reference_XmlSchema_DataType3, Quickstarts.Reference.Namespaces.Reference);

        /// <summary>
        /// The identifier for the Reference_XmlSchema_DataType4 Variable.
        /// </summary>
        public static readonly ExpandedNodeId Reference_XmlSchema_DataType4 = new ExpandedNodeId(Quickstarts.Reference.Variables.Reference_XmlSchema_DataType4, Quickstarts.Reference.Namespaces.Reference);

        /// <summary>
        /// The identifier for the Reference_BinarySchema Variable.
        /// </summary>
        public static readonly ExpandedNodeId Reference_BinarySchema = new ExpandedNodeId(Quickstarts.Reference.Variables.Reference_BinarySchema, Quickstarts.Reference.Namespaces.Reference);

        /// <summary>
        /// The identifier for the Reference_BinarySchema_NamespaceUri Variable.
        /// </summary>
        public static readonly ExpandedNodeId Reference_BinarySchema_NamespaceUri = new ExpandedNodeId(Quickstarts.Reference.Variables.Reference_BinarySchema_NamespaceUri, Quickstarts.Reference.Namespaces.Reference);

        /// <summary>
        /// The identifier for the Reference_BinarySchema_DataType1 Variable.
        /// </summary>
        public static readonly ExpandedNodeId Reference_BinarySchema_DataType1 = new ExpandedNodeId(Quickstarts.Reference.Variables.Reference_BinarySchema_DataType1, Quickstarts.Reference.Namespaces.Reference);

        /// <summary>
        /// The identifier for the Reference_BinarySchema_DataType2 Variable.
        /// </summary>
        public static readonly ExpandedNodeId Reference_BinarySchema_DataType2 = new ExpandedNodeId(Quickstarts.Reference.Variables.Reference_BinarySchema_DataType2, Quickstarts.Reference.Namespaces.Reference);

        /// <summary>
        /// The identifier for the Reference_BinarySchema_DataType3 Variable.
        /// </summary>
        public static readonly ExpandedNodeId Reference_BinarySchema_DataType3 = new ExpandedNodeId(Quickstarts.Reference.Variables.Reference_BinarySchema_DataType3, Quickstarts.Reference.Namespaces.Reference);

        /// <summary>
        /// The identifier for the Reference_BinarySchema_DataType4 Variable.
        /// </summary>
        public static readonly ExpandedNodeId Reference_BinarySchema_DataType4 = new ExpandedNodeId(Quickstarts.Reference.Variables.Reference_BinarySchema_DataType4, Quickstarts.Reference.Namespaces.Reference);
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
        /// The BrowseName for the DataType1 component.
        /// </summary>
        public const string DataType1 = "DataType1";

        /// <summary>
        /// The BrowseName for the DataType1Variable component.
        /// </summary>
        public const string DataType1Variable = "DataType1Variable";

        /// <summary>
        /// The BrowseName for the DataType2 component.
        /// </summary>
        public const string DataType2 = "DataType2";

        /// <summary>
        /// The BrowseName for the DataType2Variable component.
        /// </summary>
        public const string DataType2Variable = "DataType2Variable";

        /// <summary>
        /// The BrowseName for the DataType3 component.
        /// </summary>
        public const string DataType3 = "DataType3";

        /// <summary>
        /// The BrowseName for the DataType3Variable component.
        /// </summary>
        public const string DataType3Variable = "DataType3Variable";

        /// <summary>
        /// The BrowseName for the DataType4 component.
        /// </summary>
        public const string DataType4 = "DataType4";

        /// <summary>
        /// The BrowseName for the DataType4Variable component.
        /// </summary>
        public const string DataType4Variable = "DataType4Variable";

        /// <summary>
        /// The BrowseName for the Reference_BinarySchema component.
        /// </summary>
        public const string Reference_BinarySchema = "Quickstarts.Reference";

        /// <summary>
        /// The BrowseName for the Reference_XmlSchema component.
        /// </summary>
        public const string Reference_XmlSchema = "Quickstarts.Reference";

        /// <summary>
        /// The BrowseName for the StructuredTypeVariables component.
        /// </summary>
        public const string StructuredTypeVariables = "StructuredTypeVariables";
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
        /// The URI for the OpcUa namespace (.NET code namespace is 'Opc.Ua').
        /// </summary>
        public const string OpcUa = "http://opcfoundation.org/UA/";

        /// <summary>
        /// The URI for the OpcUaXsd namespace (.NET code namespace is 'Opc.Ua').
        /// </summary>
        public const string OpcUaXsd = "http://opcfoundation.org/UA/2008/02/Types.xsd";

        /// <summary>
        /// The URI for the Reference namespace (.NET code namespace is 'Quickstarts.Reference').
        /// </summary>
        public const string Reference = "http://opcfoundation.org/Quickstarts/Reference";
    }
    #endregion
}