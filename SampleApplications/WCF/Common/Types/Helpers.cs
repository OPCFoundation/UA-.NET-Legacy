/* ========================================================================
 * Copyright (c) 2005-2017 The OPC Foundation, Inc. All rights reserved.
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
using System.Reflection;
using System.Xml;

namespace Opc.Ua
{
	/// <summary>
	/// A class that defines constants used by UA applications.
	/// </summary>
	public static partial class DataTypes
	{
        #region Static Helper Functions
        /// <summary>
        /// Converts an enumerated value to its correct wire protocol value.
        /// </summary>
        /// <remarks>
        /// Only required for enumerations which define bit masks instead of sequential numbers.
        /// </remarks>
        public static int EnumToMask(Enum value)
        {
            string text = value.ToString();

            int index = text.LastIndexOf('_');

            if (index == -1)
            {
                return Convert.ToInt32(value);
            }

            return Convert.ToInt32(text.Substring(index + 1));
        }

        /// <summary>
		/// Returns the browse name for the attribute.
		/// </summary>
        public static string GetBrowseName(int identifier)
		{
			FieldInfo[] fields = typeof(DataTypes).GetFields(BindingFlags.Public | BindingFlags.Static);

			foreach (FieldInfo field in fields)
			{
                if (identifier == (int)field.GetValue(typeof(DataTypes)))
				{
					return field.Name;
				}
			}

			return System.String.Empty;
		}

		/// <summary>
		/// Returns the browse names for all attributes.
		/// </summary>
		public static string[] GetBrowseNames()
		{
			FieldInfo[] fields = typeof(DataTypes).GetFields(BindingFlags.Public | BindingFlags.Static);
            
            int ii = 0;

            string[] names = new string[fields.Length];
            
			foreach (FieldInfo field in fields)
			{
				names[ii++] = field.Name;
			}

			return names;
		}

		/// <summary>
		/// Returns the id for the attribute with the specified browse name.
		/// </summary>
        public static uint GetIdentifier(string browseName)
		{
			FieldInfo[] fields = typeof(DataTypes).GetFields(BindingFlags.Public | BindingFlags.Static);

			foreach (FieldInfo field in fields)
			{
				if (field.Name == browseName)
				{
                    return (uint)field.GetValue(typeof(DataTypes));
				}
			}

			return 0;
        }
        #endregion
    }

	/// <summary>
	/// A class that defines constants used by UA applications.
	/// </summary>
	public static partial class StatusCodes
	{
        #region Static Helper Functions
        /// <summary>
		/// Returns the browse name for the attribute.
		/// </summary>
        public static string GetBrowseName(uint identifier)
		{
			FieldInfo[] fields = typeof(StatusCodes).GetFields(BindingFlags.Public | BindingFlags.Static);

			foreach (FieldInfo field in fields)
			{
                if (identifier == (uint)field.GetValue(typeof(StatusCodes)))
				{
					return field.Name;
				}
			}

			return System.String.Empty;
		}

		/// <summary>
		/// Returns the browse names for all attributes.
		/// </summary>
		public static string[] GetBrowseNames()
		{
			FieldInfo[] fields = typeof(StatusCodes).GetFields(BindingFlags.Public | BindingFlags.Static);
            
            int ii = 0;

            string[] names = new string[fields.Length];
            
			foreach (FieldInfo field in fields)
			{
				names[ii++] = field.Name;
			}

			return names;
		}

		/// <summary>
		/// Returns the id for the attribute with the specified browse name.
		/// </summary>
        public static uint GetIdentifier(string browseName)
		{
			FieldInfo[] fields = typeof(StatusCodes).GetFields(BindingFlags.Public | BindingFlags.Static);

			foreach (FieldInfo field in fields)
			{
				if (field.Name == browseName)
				{
                    return (uint)field.GetValue(typeof(StatusCodes));
				}
			}

			return 0;
        }
        #endregion
    }
            
    /// <summary>
	/// A class that defines constants used by UA applications.
	/// </summary>
	public static partial class ReferenceTypes
	{
        #region Static Helper Functions
        /// <summary>
		/// Returns the browse name for the attribute.
		/// </summary>
        public static string GetBrowseName(uint identifier)
		{
			FieldInfo[] fields = typeof(ReferenceTypes).GetFields(BindingFlags.Public | BindingFlags.Static);

			foreach (FieldInfo field in fields)
			{
                if (identifier == (uint)field.GetValue(typeof(ReferenceTypes)))
				{
					return field.Name;
				}
			}

			return System.String.Empty;
		}

		/// <summary>
		/// Returns the browse names for all attributes.
		/// </summary>
		public static string[] GetBrowseNames()
		{
			FieldInfo[] fields = typeof(ReferenceTypes).GetFields(BindingFlags.Public | BindingFlags.Static);
            
            int ii = 0;

            string[] names = new string[fields.Length];
            
			foreach (FieldInfo field in fields)
			{
				names[ii++] = field.Name;
			}

			return names;
		}

		/// <summary>
		/// Returns the id for the attribute with the specified browse name.
		/// </summary>
        public static uint GetIdentifier(string browseName)
		{
			FieldInfo[] fields = typeof(ReferenceTypes).GetFields(BindingFlags.Public | BindingFlags.Static);

			foreach (FieldInfo field in fields)
			{
				if (field.Name == browseName)
				{
                    return (uint)field.GetValue(typeof(ReferenceTypes));
				}
			}

			return 0;
        }
        #endregion
    }

	/// <summary>
	/// A class that defines constants used by UA applications.
	/// </summary>
    public static partial class Attributes
    {        
        #region Static Helper Functions
        /// <summary>
		/// Returns true is the attribute id is valid.
		/// </summary>
        public static bool IsValid(uint attributeId)
		{
            return (attributeId >= Attributes.NodeId && attributeId <= Attributes.UserExecutable);
        }

        /// <summary>
		/// Returns the browse name for the attribute.
		/// </summary>
        public static string GetBrowseName(uint identifier)
		{
			FieldInfo[] fields = typeof(Attributes).GetFields(BindingFlags.Public | BindingFlags.Static);

			foreach (FieldInfo field in fields)
			{
                if (identifier == (uint)field.GetValue(typeof(Attributes)))
				{
					return field.Name;
				}
			}

			return System.String.Empty;
		}

		/// <summary>
		/// Returns the browse names for all attributes.
		/// </summary>
		public static string[] GetBrowseNames()
		{
			FieldInfo[] fields = typeof(Attributes).GetFields(BindingFlags.Public | BindingFlags.Static);
            
            int ii = 0;

            string[] names = new string[fields.Length];
            
			foreach (FieldInfo field in fields)
			{
				names[ii++] = field.Name;
			}

			return names;
		}

		/// <summary>
		/// Returns the id for the attribute with the specified browse name.
		/// </summary>
        public static uint GetIdentifier(string browseName)
		{
			FieldInfo[] fields = typeof(Attributes).GetFields(BindingFlags.Public | BindingFlags.Static);

			foreach (FieldInfo field in fields)
			{
				if (field.Name == browseName)
				{
                    return (uint)field.GetValue(typeof(Attributes));
				}
			}

			return 0;
        }

		/// <summary>
		/// Returns the ids for all attributes.
		/// </summary>
		public static uint[] GetIdentifiers()
		{
			FieldInfo[] fields = typeof(Attributes).GetFields(BindingFlags.Public | BindingFlags.Static);
            
            int ii = 0;
            uint[] ids = new uint[fields.Length];
            
			foreach (FieldInfo field in fields)
			{
                ids[ii++] = (uint)field.GetValue(typeof(Attributes));
			}

			return ids;
		}
        
		/// <summary>
		/// Returns the ids for all attributes which are valid for the at least one of the node classes specified by the mask.
		/// </summary>
        public static ListOfUInt32 GetIdentifiers(NodeClass nodeClass)
        {
			FieldInfo[] fields = typeof(Attributes).GetFields(BindingFlags.Public | BindingFlags.Static);
            
            ListOfUInt32 ids = new ListOfUInt32();
            
			foreach (FieldInfo field in fields)
			{
                uint id = (uint)field.GetValue(typeof(Attributes));

                if (IsValid(nodeClass, id))
                {
                    ids.Add(id);
                }
			}

			return ids;
        }

        /// <summary>
        /// Returns the data type id for the attribute.
        /// </summary>
        public static NodeId GetDataTypeId(uint attributeId)
        {
            switch (attributeId)
            {
                case Value:                   return new NodeId(DataTypes.BaseDataType);
                case DisplayName:             return new NodeId(DataTypes.LocalizedText);
                case Description:             return new NodeId(DataTypes.LocalizedText);
                case WriteMask:               return new NodeId(DataTypes.UInt32);
                case UserWriteMask:           return new NodeId(DataTypes.UInt32);
                case NodeId:                  return new NodeId(DataTypes.NodeId);
                case NodeClass:               return new NodeId(DataTypes.Enumeration);
                case BrowseName:              return new NodeId(DataTypes.QualifiedName);
                case IsAbstract:              return new NodeId(DataTypes.Boolean);
                case Symmetric:               return new NodeId(DataTypes.Boolean);
                case InverseName:             return new NodeId(DataTypes.LocalizedText);
                case ContainsNoLoops:         return new NodeId(DataTypes.Boolean);
                case EventNotifier:           return new NodeId(DataTypes.Byte);
                case DataType:                return new NodeId(DataTypes.NodeId);
                case ValueRank:               return new NodeId(DataTypes.Int32);
                case AccessLevel:             return new NodeId(DataTypes.Byte);
                case UserAccessLevel:         return new NodeId(DataTypes.Byte);
                case MinimumSamplingInterval: return new NodeId(DataTypes.Int32);
                case Historizing:             return new NodeId(DataTypes.Boolean);
                case Executable:              return new NodeId(DataTypes.Boolean);
                case UserExecutable:          return new NodeId(DataTypes.Boolean);
                case ArrayDimensions:         return new NodeId(DataTypes.UInt32);
            }
                    
            return null;
        }
        
        /// <summary>
        /// Returns the value rank for the attribute.
        /// </summary>
        public static int GetValueRank(uint attributeId)
        {
            if (attributeId == Attributes.Value)
            {
                return ValueRanks.Any;
            }
            
            if (attributeId == Attributes.ArrayDimensions)
            {
                return ValueRanks.OneDimension;
            }

            return ValueRanks.Scalar;
        }

        /// <summary>
        /// Checks if the attribute is valid for at least one of node classes specified in the mask.
        /// </summary>
        public static bool IsValid(NodeClass nodeClass, uint attributeId)
        {
            switch (attributeId)
            {
                case NodeId:
                case NodeClass:
                case BrowseName:
                case DisplayName:
                case Description:
                case WriteMask:
                case UserWriteMask:
                {
                    return true;
                }

                case Value:
                case DataType: 
                case ValueRank: 
                case ArrayDimensions: 
                {
                    return (nodeClass & (Opc.Ua.NodeClass.VariableType_16 | Opc.Ua.NodeClass.Variable_2)) != 0;
                }                    

                case IsAbstract:
                {
                    return (nodeClass & (Opc.Ua.NodeClass.VariableType_16 | Opc.Ua.NodeClass.ObjectType_8 | Opc.Ua.NodeClass.ReferenceType_32 | Opc.Ua.NodeClass.DataType_64)) != 0;
                }               

                case Symmetric:
                case InverseName:
                {
                    return (nodeClass & Opc.Ua.NodeClass.ReferenceType_32) != 0;
                }      

                case ContainsNoLoops:
                {
                    return (nodeClass & Opc.Ua.NodeClass.View_128) != 0;
                }                    

                case EventNotifier:
                {
                    return (nodeClass & (Opc.Ua.NodeClass.Object_1 | Opc.Ua.NodeClass.View_128)) != 0;
                } 
                    
                case AccessLevel:
                case UserAccessLevel:
                case MinimumSamplingInterval:
                case Historizing:
                {
                    return (nodeClass & Opc.Ua.NodeClass.Variable_2) != 0;
                } 

                case Executable:
                case UserExecutable:
                {
                    return (nodeClass & Opc.Ua.NodeClass.Method_4) != 0;
                }
            }

            return false;
        }
        #endregion
    }
}
