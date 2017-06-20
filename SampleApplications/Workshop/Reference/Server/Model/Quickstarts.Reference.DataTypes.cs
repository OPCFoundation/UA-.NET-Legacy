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
    #region DataType1 Class
    #if (!OPCUA_EXCLUDE_DataType1)
    /// <summary>
    /// A description for the DataType1 DataType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = Quickstarts.Reference.Namespaces.Reference)]
    public partial class DataType1 : IEncodeable
    {
        #region Constructors
        /// <summary>
        /// The default constructor.
        /// </summary>
        public DataType1()
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
            m_int32Field = (int)0;
            m_floatField = (float)0;
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// A description for the Int32Field field.
        /// </summary>
        [DataMember(Name = "Int32Field", IsRequired = false, Order = 1)]
        public int Int32Field
        {
            get { return m_int32Field;  }
            set { m_int32Field = value; }
        }

        /// <summary>
        /// A description for the FloatField field.
        /// </summary>
        [DataMember(Name = "FloatField", IsRequired = false, Order = 2)]
        public float FloatField
        {
            get { return m_floatField;  }
            set { m_floatField = value; }
        }
        #endregion

        #region IEncodeable Members
        /// <summary cref="IEncodeable.TypeId" />
        public virtual ExpandedNodeId TypeId
        {
            get { return DataTypeIds.DataType1; }
        }

        /// <summary cref="IEncodeable.BinaryEncodingId" />
        public virtual ExpandedNodeId BinaryEncodingId
        {
            get { return ObjectIds.DataType1_Encoding_DefaultBinary; }
        }

        /// <summary cref="IEncodeable.XmlEncodingId" />
        public virtual ExpandedNodeId XmlEncodingId
        {
            get { return ObjectIds.DataType1_Encoding_DefaultXml; }
        }

        /// <summary cref="IEncodeable.Encode(IEncoder)" />
        public virtual void Encode(IEncoder encoder)
        {
            encoder.PushNamespace(Quickstarts.Reference.Namespaces.Reference);

            encoder.WriteInt32("Int32Field", Int32Field);
            encoder.WriteFloat("FloatField", FloatField);

            encoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.Decode(IDecoder)" />
        public virtual void Decode(IDecoder decoder)
        {
            decoder.PushNamespace(Quickstarts.Reference.Namespaces.Reference);

            Int32Field = decoder.ReadInt32("Int32Field");
            FloatField = decoder.ReadFloat("FloatField");

            decoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.IsEqual(IEncodeable)" />
        public virtual bool IsEqual(IEncodeable encodeable)
        {
            if (Object.ReferenceEquals(this, encodeable))
            {
                return true;
            }

            DataType1 value = encodeable as DataType1;

            if (value == null)
            {
                return false;
            }

            if (!Utils.IsEqual(m_int32Field, value.m_int32Field)) return false;
            if (!Utils.IsEqual(m_floatField, value.m_floatField)) return false;

            return true;
        }

        /// <summary cref="ICloneable.Clone" />
        public virtual object Clone()
        {
            DataType1 clone = (DataType1)this.MemberwiseClone();

            clone.m_int32Field = (int)Utils.Clone(this.m_int32Field);
            clone.m_floatField = (float)Utils.Clone(this.m_floatField);

            return clone;
        }
        #endregion

        #region Private Fields
        private int m_int32Field;
        private float m_floatField;
        #endregion
    }

    #region DataType1Collection Class
    /// <summary>
    /// A collection of DataType1 objects.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfDataType1", Namespace = Quickstarts.Reference.Namespaces.Reference, ItemName = "DataType1")]
    public partial class DataType1Collection : List<DataType1>, ICloneable
    {
        #region Constructors
        /// <summary>
        /// Initializes the collection with default values.
        /// </summary>
        public DataType1Collection() {}

        /// <summary>
        /// Initializes the collection with an initial capacity.
        /// </summary>
        public DataType1Collection(int capacity) : base(capacity) {}

        /// <summary>
        /// Initializes the collection with another collection.
        /// </summary>
        public DataType1Collection(IEnumerable<DataType1> collection) : base(collection) {}
        #endregion

        #region Static Operators
        /// <summary>
        /// Converts an array to a collection.
        /// </summary>
        public static implicit operator DataType1Collection(DataType1[] values)
        {
            if (values != null)
            {
                return new DataType1Collection(values);
            }

            return new DataType1Collection();
        }

        /// <summary>
        /// Converts a collection to an array.
        /// </summary>
        public static explicit operator DataType1[](DataType1Collection values)
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
            DataType1Collection clone = new DataType1Collection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((DataType1)Utils.Clone(this[ii]));
            }

            return clone;
        }
        #endregion
    }
    #endregion
    #endif
    #endregion

    #region DataType2 Class
    #if (!OPCUA_EXCLUDE_DataType2)
    /// <summary>
    /// A description for the DataType2 DataType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = Quickstarts.Reference.Namespaces.Reference)]
    public partial class DataType2 : DataType1
    {
        #region Constructors
        /// <summary>
        /// The default constructor.
        /// </summary>
        public DataType2()
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
            m_stringField = null;
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// A description for the StringField field.
        /// </summary>
        [DataMember(Name = "StringField", IsRequired = false, Order = 1)]
        public string StringField
        {
            get { return m_stringField;  }
            set { m_stringField = value; }
        }
        #endregion

        #region IEncodeable Members
        /// <summary cref="IEncodeable.TypeId" />
        public override ExpandedNodeId TypeId
        {
            get { return DataTypeIds.DataType2; }
        }

        /// <summary cref="IEncodeable.BinaryEncodingId" />
        public override ExpandedNodeId BinaryEncodingId
        {
            get { return ObjectIds.DataType2_Encoding_DefaultBinary; }
        }

        /// <summary cref="IEncodeable.XmlEncodingId" />
        public override ExpandedNodeId XmlEncodingId
        {
            get { return ObjectIds.DataType2_Encoding_DefaultXml; }
        }

        /// <summary cref="IEncodeable.Encode(IEncoder)" />
        public override void Encode(IEncoder encoder)
        {
            base.Encode(encoder);

            encoder.PushNamespace(Quickstarts.Reference.Namespaces.Reference);

            encoder.WriteString("StringField", StringField);

            encoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.Decode(IDecoder)" />
        public override void Decode(IDecoder decoder)
        {
            base.Decode(decoder);

            decoder.PushNamespace(Quickstarts.Reference.Namespaces.Reference);

            StringField = decoder.ReadString("StringField");

            decoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.IsEqual(IEncodeable)" />
        public override bool IsEqual(IEncodeable encodeable)
        {
            if (Object.ReferenceEquals(this, encodeable))
            {
                return true;
            }

            DataType2 value = encodeable as DataType2;

            if (value == null)
            {
                return false;
            }

            if (!base.IsEqual(encodeable)) return false;
            if (!Utils.IsEqual(m_stringField, value.m_stringField)) return false;

            return true;
        }

        /// <summary cref="ICloneable.Clone" />
        public override object Clone()
        {
            DataType2 clone = (DataType2)base.Clone();

            clone.m_stringField = (string)Utils.Clone(this.m_stringField);

            return clone;
        }
        #endregion

        #region Private Fields
        private string m_stringField;
        #endregion
    }

    #region DataType2Collection Class
    /// <summary>
    /// A collection of DataType2 objects.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfDataType2", Namespace = Quickstarts.Reference.Namespaces.Reference, ItemName = "DataType2")]
    public partial class DataType2Collection : List<DataType2>, ICloneable
    {
        #region Constructors
        /// <summary>
        /// Initializes the collection with default values.
        /// </summary>
        public DataType2Collection() {}

        /// <summary>
        /// Initializes the collection with an initial capacity.
        /// </summary>
        public DataType2Collection(int capacity) : base(capacity) {}

        /// <summary>
        /// Initializes the collection with another collection.
        /// </summary>
        public DataType2Collection(IEnumerable<DataType2> collection) : base(collection) {}
        #endregion

        #region Static Operators
        /// <summary>
        /// Converts an array to a collection.
        /// </summary>
        public static implicit operator DataType2Collection(DataType2[] values)
        {
            if (values != null)
            {
                return new DataType2Collection(values);
            }

            return new DataType2Collection();
        }

        /// <summary>
        /// Converts a collection to an array.
        /// </summary>
        public static explicit operator DataType2[](DataType2Collection values)
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
            DataType2Collection clone = new DataType2Collection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((DataType2)Utils.Clone(this[ii]));
            }

            return clone;
        }
        #endregion
    }
    #endregion
    #endif
    #endregion

    #region DataType3 Class
    #if (!OPCUA_EXCLUDE_DataType3)
    /// <summary>
    /// A description for the DataType3 DataType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = Quickstarts.Reference.Namespaces.Reference)]
    public partial class DataType3 : IEncodeable
    {
        #region Constructors
        /// <summary>
        /// The default constructor.
        /// </summary>
        public DataType3()
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
            m_int32Field = (int)0;
            m_byteField = (byte)0;
            m_floatField = (float)0;
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// A description for the Int32Field field.
        /// </summary>
        [DataMember(Name = "Int32Field", IsRequired = false, Order = 1)]
        public int Int32Field
        {
            get { return m_int32Field;  }
            set { m_int32Field = value; }
        }

        /// <summary>
        /// A description for the ByteField field.
        /// </summary>
        [DataMember(Name = "ByteField", IsRequired = false, Order = 2)]
        public byte ByteField
        {
            get { return m_byteField;  }
            set { m_byteField = value; }
        }

        /// <summary>
        /// A description for the FloatField field.
        /// </summary>
        [DataMember(Name = "FloatField", IsRequired = false, Order = 3)]
        public float FloatField
        {
            get { return m_floatField;  }
            set { m_floatField = value; }
        }
        #endregion

        #region IEncodeable Members
        /// <summary cref="IEncodeable.TypeId" />
        public virtual ExpandedNodeId TypeId
        {
            get { return DataTypeIds.DataType3; }
        }

        /// <summary cref="IEncodeable.BinaryEncodingId" />
        public virtual ExpandedNodeId BinaryEncodingId
        {
            get { return ObjectIds.DataType3_Encoding_DefaultBinary; }
        }

        /// <summary cref="IEncodeable.XmlEncodingId" />
        public virtual ExpandedNodeId XmlEncodingId
        {
            get { return ObjectIds.DataType3_Encoding_DefaultXml; }
        }

        /// <summary cref="IEncodeable.Encode(IEncoder)" />
        public virtual void Encode(IEncoder encoder)
        {
            encoder.PushNamespace(Quickstarts.Reference.Namespaces.Reference);

            encoder.WriteInt32("Int32Field", Int32Field);
            encoder.WriteByte("ByteField", ByteField);
            encoder.WriteFloat("FloatField", FloatField);

            encoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.Decode(IDecoder)" />
        public virtual void Decode(IDecoder decoder)
        {
            decoder.PushNamespace(Quickstarts.Reference.Namespaces.Reference);

            Int32Field = decoder.ReadInt32("Int32Field");
            ByteField = decoder.ReadByte("ByteField");
            FloatField = decoder.ReadFloat("FloatField");

            decoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.IsEqual(IEncodeable)" />
        public virtual bool IsEqual(IEncodeable encodeable)
        {
            if (Object.ReferenceEquals(this, encodeable))
            {
                return true;
            }

            DataType3 value = encodeable as DataType3;

            if (value == null)
            {
                return false;
            }

            if (!Utils.IsEqual(m_int32Field, value.m_int32Field)) return false;
            if (!Utils.IsEqual(m_byteField, value.m_byteField)) return false;
            if (!Utils.IsEqual(m_floatField, value.m_floatField)) return false;

            return true;
        }

        /// <summary cref="ICloneable.Clone" />
        public virtual object Clone()
        {
            DataType3 clone = (DataType3)this.MemberwiseClone();

            clone.m_int32Field = (int)Utils.Clone(this.m_int32Field);
            clone.m_byteField = (byte)Utils.Clone(this.m_byteField);
            clone.m_floatField = (float)Utils.Clone(this.m_floatField);

            return clone;
        }
        #endregion

        #region Private Fields
        private int m_int32Field;
        private byte m_byteField;
        private float m_floatField;
        #endregion
    }

    #region DataType3Collection Class
    /// <summary>
    /// A collection of DataType3 objects.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfDataType3", Namespace = Quickstarts.Reference.Namespaces.Reference, ItemName = "DataType3")]
    public partial class DataType3Collection : List<DataType3>, ICloneable
    {
        #region Constructors
        /// <summary>
        /// Initializes the collection with default values.
        /// </summary>
        public DataType3Collection() {}

        /// <summary>
        /// Initializes the collection with an initial capacity.
        /// </summary>
        public DataType3Collection(int capacity) : base(capacity) {}

        /// <summary>
        /// Initializes the collection with another collection.
        /// </summary>
        public DataType3Collection(IEnumerable<DataType3> collection) : base(collection) {}
        #endregion

        #region Static Operators
        /// <summary>
        /// Converts an array to a collection.
        /// </summary>
        public static implicit operator DataType3Collection(DataType3[] values)
        {
            if (values != null)
            {
                return new DataType3Collection(values);
            }

            return new DataType3Collection();
        }

        /// <summary>
        /// Converts a collection to an array.
        /// </summary>
        public static explicit operator DataType3[](DataType3Collection values)
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
            DataType3Collection clone = new DataType3Collection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((DataType3)Utils.Clone(this[ii]));
            }

            return clone;
        }
        #endregion
    }
    #endregion
    #endif
    #endregion

    #region DataType4 Class
    #if (!OPCUA_EXCLUDE_DataType4)
    /// <summary>
    /// A description for the DataType4 DataType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = Quickstarts.Reference.Namespaces.Reference)]
    public partial class DataType4 : IEncodeable
    {
        #region Constructors
        /// <summary>
        /// The default constructor.
        /// </summary>
        public DataType4()
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
            m_int32Field = (int)0;
            m_floatField = (float)0;
            m_byteField = (byte)0;
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// A description for the Int32Field field.
        /// </summary>
        [DataMember(Name = "Int32Field", IsRequired = false, Order = 1)]
        public int Int32Field
        {
            get { return m_int32Field;  }
            set { m_int32Field = value; }
        }

        /// <summary>
        /// A description for the FloatField field.
        /// </summary>
        [DataMember(Name = "FloatField", IsRequired = false, Order = 2)]
        public float FloatField
        {
            get { return m_floatField;  }
            set { m_floatField = value; }
        }

        /// <summary>
        /// A description for the ByteField field.
        /// </summary>
        [DataMember(Name = "ByteField", IsRequired = false, Order = 3)]
        public byte ByteField
        {
            get { return m_byteField;  }
            set { m_byteField = value; }
        }
        #endregion

        #region IEncodeable Members
        /// <summary cref="IEncodeable.TypeId" />
        public virtual ExpandedNodeId TypeId
        {
            get { return DataTypeIds.DataType4; }
        }

        /// <summary cref="IEncodeable.BinaryEncodingId" />
        public virtual ExpandedNodeId BinaryEncodingId
        {
            get { return ObjectIds.DataType4_Encoding_DefaultBinary; }
        }

        /// <summary cref="IEncodeable.XmlEncodingId" />
        public virtual ExpandedNodeId XmlEncodingId
        {
            get { return ObjectIds.DataType4_Encoding_DefaultXml; }
        }

        /// <summary cref="IEncodeable.Encode(IEncoder)" />
        public virtual void Encode(IEncoder encoder)
        {
            encoder.PushNamespace(Quickstarts.Reference.Namespaces.Reference);

            encoder.WriteInt32("Int32Field", Int32Field);
            encoder.WriteFloat("FloatField", FloatField);
            encoder.WriteByte("ByteField", ByteField);

            encoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.Decode(IDecoder)" />
        public virtual void Decode(IDecoder decoder)
        {
            decoder.PushNamespace(Quickstarts.Reference.Namespaces.Reference);

            Int32Field = decoder.ReadInt32("Int32Field");
            FloatField = decoder.ReadFloat("FloatField");
            ByteField = decoder.ReadByte("ByteField");

            decoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.IsEqual(IEncodeable)" />
        public virtual bool IsEqual(IEncodeable encodeable)
        {
            if (Object.ReferenceEquals(this, encodeable))
            {
                return true;
            }

            DataType4 value = encodeable as DataType4;

            if (value == null)
            {
                return false;
            }

            if (!Utils.IsEqual(m_int32Field, value.m_int32Field)) return false;
            if (!Utils.IsEqual(m_floatField, value.m_floatField)) return false;
            if (!Utils.IsEqual(m_byteField, value.m_byteField)) return false;

            return true;
        }

        /// <summary cref="ICloneable.Clone" />
        public virtual object Clone()
        {
            DataType4 clone = (DataType4)this.MemberwiseClone();

            clone.m_int32Field = (int)Utils.Clone(this.m_int32Field);
            clone.m_floatField = (float)Utils.Clone(this.m_floatField);
            clone.m_byteField = (byte)Utils.Clone(this.m_byteField);

            return clone;
        }
        #endregion

        #region Private Fields
        private int m_int32Field;
        private float m_floatField;
        private byte m_byteField;
        #endregion
    }

    #region DataType4Collection Class
    /// <summary>
    /// A collection of DataType4 objects.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfDataType4", Namespace = Quickstarts.Reference.Namespaces.Reference, ItemName = "DataType4")]
    public partial class DataType4Collection : List<DataType4>, ICloneable
    {
        #region Constructors
        /// <summary>
        /// Initializes the collection with default values.
        /// </summary>
        public DataType4Collection() {}

        /// <summary>
        /// Initializes the collection with an initial capacity.
        /// </summary>
        public DataType4Collection(int capacity) : base(capacity) {}

        /// <summary>
        /// Initializes the collection with another collection.
        /// </summary>
        public DataType4Collection(IEnumerable<DataType4> collection) : base(collection) {}
        #endregion

        #region Static Operators
        /// <summary>
        /// Converts an array to a collection.
        /// </summary>
        public static implicit operator DataType4Collection(DataType4[] values)
        {
            if (values != null)
            {
                return new DataType4Collection(values);
            }

            return new DataType4Collection();
        }

        /// <summary>
        /// Converts a collection to an array.
        /// </summary>
        public static explicit operator DataType4[](DataType4Collection values)
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
            DataType4Collection clone = new DataType4Collection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((DataType4)Utils.Clone(this[ii]));
            }

            return clone;
        }
        #endregion
    }
    #endregion
    #endif
    #endregion
}