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
    #region CalibrationDataType Class
    #if (!OPCUA_EXCLUDE_CalibrationDataType)
    /// <summary>
    /// A description for the CalibrationDataType DataType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = TutorialModel.Namespaces.Tutorial)]
    public partial class CalibrationDataType : IEncodeable
    {
    	#region Constructors
    	/// <summary>
    	/// The default constructor.
    	/// </summary>
    	public CalibrationDataType()
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
    		m_offset = (double)0;
    		m_period = (double)0;
    	}
    	#endregion

    	#region Public Properties
    	/// <summary>
    	/// A description for the Offset field.
    	/// </summary>
    	[DataMember(Name = "Offset", IsRequired = false, Order = 1)]
    	public double Offset
    	{
    		get { return m_offset;  }
    		set { m_offset = value; }
    	}

    	/// <summary>
    	/// A description for the Period field.
    	/// </summary>
    	[DataMember(Name = "Period", IsRequired = false, Order = 2)]
    	public double Period
    	{
    		get { return m_period;  }
    		set { m_period = value; }
    	}
    	#endregion

        #region IEncodeable Members
        /// <summary cref="IEncodeable.TypeId" />
        public virtual ExpandedNodeId TypeId
        {
            get { return DataTypeIds.CalibrationDataType; }
        }

        /// <summary cref="IEncodeable.BinaryEncodingId" />
        public virtual ExpandedNodeId BinaryEncodingId
        {
            get { return ObjectIds.CalibrationDataType_Encoding_DefaultBinary; }
        }
        
        /// <summary cref="IEncodeable.XmlEncodingId" />
        public virtual ExpandedNodeId XmlEncodingId
        {
            get { return ObjectIds.CalibrationDataType_Encoding_DefaultXml; }
        }
        
        /// <summary cref="IEncodeable.Encode(IEncoder)" />
        public virtual void Encode(IEncoder encoder)
        {
            encoder.PushNamespace(TutorialModel.Namespaces.Tutorial);

            encoder.WriteDouble("Offset", Offset);
            encoder.WriteDouble("Period", Period);

            encoder.PopNamespace();
        }
        
        /// <summary cref="IEncodeable.Decode(IDecoder)" />
        public virtual void Decode(IDecoder decoder)
        {
            decoder.PushNamespace(TutorialModel.Namespaces.Tutorial);

            Offset = decoder.ReadDouble("Offset");
            Period = decoder.ReadDouble("Period");

            decoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.IsEqual(IEncodeable)" />
        public virtual bool IsEqual(IEncodeable encodeable)
        {
            if (Object.ReferenceEquals(this, encodeable))
            {
                return true;
            }
            
            CalibrationDataType value = encodeable as CalibrationDataType;
            
            if (value == null)
            {
                return false;
            }

            if (!Utils.IsEqual(m_offset, value.m_offset)) return false;
            if (!Utils.IsEqual(m_period, value.m_period)) return false;

            return true;
        }
        
        /// <summary cref="ICloneable.Clone" />
        public virtual object Clone()
        {
            CalibrationDataType clone = (CalibrationDataType)this.MemberwiseClone();

            clone.m_offset = (double)Utils.Clone(this.m_offset);
            clone.m_period = (double)Utils.Clone(this.m_period);

            return clone;
        }
        #endregion
        
    	#region Private Fields
    	private double m_offset;
    	private double m_period;
    	#endregion
    }

    #region CalibrationDataTypeCollection Class
    /// <summary>
    /// A collection of CalibrationDataType objects.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfCalibrationDataType", Namespace = TutorialModel.Namespaces.Tutorial, ItemName = "CalibrationDataType")]
    public partial class CalibrationDataTypeCollection : List<CalibrationDataType>, ICloneable
    {
    	#region Constructors
    	/// <summary>
    	/// Initializes the collection with default values.
    	/// </summary>
    	public CalibrationDataTypeCollection() {}
    	
    	/// <summary>
    	/// Initializes the collection with an initial capacity.
    	/// </summary>
    	public CalibrationDataTypeCollection(int capacity) : base(capacity) {}
    	
    	/// <summary>
    	/// Initializes the collection with another collection.
    	/// </summary>
    	public CalibrationDataTypeCollection(IEnumerable<CalibrationDataType> collection) : base(collection) {}
    	#endregion
                    
        #region Static Operators
        /// <summary>
        /// Converts an array to a collection.
        /// </summary>
        public static implicit operator CalibrationDataTypeCollection(CalibrationDataType[] values)
        {
            if (values != null)
            {
                return new CalibrationDataTypeCollection(values);
            }

            return new CalibrationDataTypeCollection();
        }
        
        /// <summary>
        /// Converts a collection to an array.
        /// </summary>
        public static explicit operator CalibrationDataType[](CalibrationDataTypeCollection values)
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
            CalibrationDataTypeCollection clone = new CalibrationDataTypeCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((CalibrationDataType)Utils.Clone(this[ii]));
            }

            return clone;
        }
        #endregion
    }
    #endregion
    #endif
    #endregion
}
