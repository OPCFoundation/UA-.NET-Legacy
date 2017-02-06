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
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Opc.Ua.StackTest
{
    #region AcmeWidget Class
    /// <summary>
    /// The AcmeWidget class.
    /// </summary>
    [DataContract(Namespace = VendorNamespaces.Acme)]
    public class AcmeWidget : EncodeableObject
    {
        #region Constructors
        /// <summary>
        /// The default constructor.
        /// </summary>
        public AcmeWidget()
        {
            Initialize();
        }

        /// <summary>
        /// Sets private members to default values.
        /// </summary>
        private void Initialize()
        {
            m_color = null;
            m_quantity = 0;
            m_buildDate = DateTime.MinValue;
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// The SoftwareVersion property.
        /// </summary>
        [DataMember(Name = "Color", Order = 1)]
        public string Color
        {
            get { return m_color; }
            set { m_color = value; }
        }

        /// <summary>
        /// The Quantity property.
        /// </summary>
        [DataMember(Name = "Quantity", Order = 2)]
        public int Quantity
        {
            get { return m_quantity; }
            set { m_quantity = value; }
        }

        /// <summary>
        /// The BuildDate property.
        /// </summary>
        [DataMember(Name = "BuildDate", Order = 3)]
        public DateTime BuildDate
        {
            get { return m_buildDate; }
            set { m_buildDate = value; }
        }

        #endregion

        #region IEncodeable Members

        /// <summary cref="IEncodeable.TypeId"/>
        public override ExpandedNodeId TypeId
        {
            get { return m_TypeId; }
        }

        /// <summary cref="IEncodeable.BinaryEncodingId"/>
        public override ExpandedNodeId BinaryEncodingId
        {
            get { return m_BinaryEncodingId; }
        }

        /// <summary cref="IEncodeable.XmlEncodingId"/>
        public override ExpandedNodeId XmlEncodingId
        {
            get { return m_XmlEncodingId; }
        }

        /// <summary>
        /// Encodes the object in a stream.
        /// </summary>
        public override void Encode(IEncoder encoder)
        {
            base.Encode(encoder);

            encoder.PushNamespace(VendorNamespaces.Acme);
            encoder.WriteString("Color", Color);
            encoder.WriteInt32("Quantity", Quantity);
            encoder.WriteDateTime("BuildDate", BuildDate);
            encoder.PopNamespace();
        }

        /// <summary>
        /// Decodes the object from a stream.
        /// </summary>
        public override void Decode(IDecoder decoder)
        {
            base.Decode(decoder);

            decoder.PushNamespace(VendorNamespaces.Acme);
            Color = decoder.ReadString("Color");
            Quantity = decoder.ReadInt32("Quantity");
            BuildDate = decoder.ReadDateTime("BuildDate");
            decoder.PopNamespace();
        }

        /// <summary>
        /// Method for comparing two objects of the class AcmeWidget.
        /// </summary>
        /// <see cref="IEncodeable.IsEqual(IEncodeable)"/>
        public override bool IsEqual(IEncodeable encodeable)
        {
            if (Object.ReferenceEquals(this, encodeable))
            {
                return true;
            }

            AcmeWidget value = encodeable as AcmeWidget;

            if (value == null)
            {
                return false;
            }

            if (GetType().BaseType != typeof(EncodeableObject))
            {
                if (!base.IsEqual(encodeable))
                {
                    return false;
                }
            }

            if (!Utils.IsEqual(m_color, value.m_color)) return false;
            if (!Utils.IsEqual(m_quantity, value.m_quantity)) return false;
            if (!Utils.IsEqual(m_buildDate, value.m_buildDate)) return false;

            return true;
        }

        #region Private Fields
        // The type Id for IEncodeable object.      
        private static ExpandedNodeId m_TypeId = new ExpandedNodeId(1, VendorNamespaces.Acme);

        // The Id used for Binary Encoding.     
        private static ExpandedNodeId m_BinaryEncodingId = new ExpandedNodeId(11, VendorNamespaces.Acme);

        // The Id used for XML Encoding.      
        private static ExpandedNodeId m_XmlEncodingId = new ExpandedNodeId(12, VendorNamespaces.Acme);
        #endregion
        #endregion

        #region Null Fields
        /// <summary>
        /// This method returns an instance of a null AcmeWidget.
        /// </summary>
        public static AcmeWidget Null
        {
            get { return m_null; }
        }

        // The null object.
        private static readonly AcmeWidget m_null = new AcmeWidget();
        #endregion

        #region Private Fields
        //The color.        
        private string m_color;

        //The quantity.        
        private int m_quantity;

        //The build date.        
        private DateTime m_buildDate;
        #endregion
    }
    #endregion

    #region CoyoteGadget Class
    /// <summary>
    /// The CoyoteGadget class.
    /// </summary>
    [DataContract(Namespace = VendorNamespaces.Coyote)]
    public class CoyoteGadget : AcmeWidget
    {
        #region Constructors
        /// <summary>
        /// The default constructor.
        /// </summary>
        public CoyoteGadget()
        {
            Initialize();
        }

        /// <summary>
        /// Sets private members to default values.
        /// </summary>
        private void Initialize()
        {
            m_cookTime = 0;
            m_spices = new StringCollection();
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// The CookTime property.
        /// </summary>
        [DataMember(Name = "CookTime", Order = 1)]
        public uint CookTime
        {
            get { return m_cookTime; }
            set { m_cookTime = value; }
        }

        /// <summary>
        /// The Spices property.
        /// </summary>
        [DataMember(Name = "Spices", Order = 1)]
        public StringCollection Spices
        {
            get { return m_spices; }

            set
            {
                if (value != null)
                {
                    m_spices = value;
                }
                else
                {
                    m_spices = new StringCollection();
                }
            }
        }
        #endregion

        #region IEncodeable Members
        /// <summary cref="IEncodeable.TypeId"/>
        public override ExpandedNodeId TypeId
        {
            get { return m_TypeId; }
        }

        /// <summary cref="IEncodeable.BinaryEncodingId"/>
        public override ExpandedNodeId BinaryEncodingId
        {
            get { return m_BinaryEncodingId; }
        }

        /// <summary cref="IEncodeable.XmlEncodingId"/>
        public override ExpandedNodeId XmlEncodingId
        {
            get { return m_XmlEncodingId; }
        }

        /// <summary cref="IEncodeable.Encode(IEncoder)" />
        public override void Encode(IEncoder encoder)
        {
            base.Encode(encoder);

            encoder.PushNamespace(VendorNamespaces.Coyote);
            encoder.WriteUInt32("CookTime", CookTime);
            encoder.WriteStringArray("Spices", Spices);
            encoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.Decode(IDecoder)" />
        public override void Decode(IDecoder decoder)
        {
            base.Decode(decoder);

            decoder.PushNamespace(VendorNamespaces.Coyote);
            CookTime = decoder.ReadUInt32("CookTime");
            Spices = decoder.ReadStringArray("Spices");
            decoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.IsEqual(IEncodeable)" />
        public override bool IsEqual(IEncodeable encodeable)
        {
            if (Object.ReferenceEquals(this, encodeable))
            {
                return true;
            }

            CoyoteGadget value = encodeable as CoyoteGadget;

            if (value == null)
            {
                return false;
            }

            if (GetType().BaseType != typeof(EncodeableObject))
            {
                if (!base.IsEqual(encodeable))
                {
                    return false;
                }
            }

            if (!Utils.IsEqual(m_cookTime, value.m_cookTime)) return false;
            if (!Utils.IsEqual(m_spices, value.m_spices)) return false;

            return true;
        }

        /// <summary cref="ICloneable.Clone" />
        public override object Clone()
        {
            CoyoteGadget clone = (CoyoteGadget)base.Clone();
            clone.m_cookTime = (uint)Utils.Clone(this.m_cookTime);
            clone.m_spices = (StringCollection)Utils.Clone(this.m_spices);
            return clone;
        }

        #region Private Fields
        // The Id used for Binary Encoding.        
        private static ExpandedNodeId m_BinaryEncodingId = new ExpandedNodeId(11, VendorNamespaces.Coyote);

        // The type Id for IEncodeable object.      
        private static ExpandedNodeId m_TypeId = new ExpandedNodeId(1, VendorNamespaces.Coyote);

        // The Id used for XML Encoding.        
        private static ExpandedNodeId m_XmlEncodingId = new ExpandedNodeId(12, VendorNamespaces.Coyote);
        #endregion

        #endregion

        #region Null Fields
        /// <summary>
        /// This method returns an instance of a null CoyoteGadget.
        /// </summary>
        public new static CoyoteGadget Null
        {
            get { return m_null; }
        }


        // The null object.        
        private static readonly CoyoteGadget m_null = new CoyoteGadget();
        #endregion

        #region Private Fields
        private uint m_cookTime;
        private StringCollection m_spices;
        #endregion
    }
    #endregion

    #region SkyNetRobot Class
    /// <summary>
    /// The SkyNet class.
    /// </summary>
    [DataContract(Namespace = VendorNamespaces.Cyberdyne)]
    public class SkyNetRobot : EncodeableObject
    {
        #region Constructors
        /// <summary>
        /// The default constructor.
        /// </summary>
        public SkyNetRobot()
        {
            Initialize();
        }

        /// <summary>
        /// Sets private members to default values.
        /// </summary>
        private void Initialize()
        {
            m_model = null;
            m_targetSensor = new AcmeWidget();
            m_buildDate = DateTime.MinValue;
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// The SoftwareVersion property.
        /// </summary>
        [DataMember(Name = "Model", Order = 1)]
        public string Model
        {
            get { return m_model; }
            set { m_model = value; }
        }

        /// <summary>
        /// The TargetSensor property.
        /// </summary>
        [DataMember(Name = "TargetSensor", Order = 2)]
        public AcmeWidget TargetSensor
        {
            get { return m_targetSensor; }
            set { m_targetSensor = value; }
        }

        /// <summary>
        /// The BuildDate property.
        /// </summary>
        [DataMember(Name = "BuildDate", Order = 3)]
        public DateTime BuildDate
        {
            get { return m_buildDate; }
            set { m_buildDate = value; }
        }
        #endregion

        #region IEncodeable Members

        /// <summary cref="IEncodeable.TypeId"/>
        public override ExpandedNodeId TypeId
        {
            get { return m_TypeId; }
        }


        /// <summary cref="IEncodeable.BinaryEncodingId"/>
        public override ExpandedNodeId BinaryEncodingId
        {
            get { return m_BinaryEncodingId; }
        }

        /// <summary cref="IEncodeable.XmlEncodingId"/>
        public override ExpandedNodeId XmlEncodingId
        {
            get { return m_XmlEncodingId; }
        }

        /// <summary>
        /// Encodes the object in a stream.
        /// </summary>
        public override void Encode(IEncoder encoder)
        {
            base.Encode(encoder);

            encoder.PushNamespace(VendorNamespaces.Cyberdyne);
            encoder.WriteString("Model", Model);
            encoder.WriteEncodeable("TargetSensor", TargetSensor, typeof(AcmeWidget));
            encoder.WriteDateTime("BuildDate", BuildDate);
            encoder.PopNamespace();
        }

        /// <summary>
        /// Decodes the object from a stream.
        /// </summary>
        public override void Decode(IDecoder decoder)
        {
            base.Decode(decoder);

            decoder.PushNamespace(VendorNamespaces.Cyberdyne);
            Model = decoder.ReadString("Model");
            TargetSensor = (AcmeWidget)decoder.ReadEncodeable("TargetSensor", typeof(AcmeWidget));
            BuildDate = decoder.ReadDateTime("BuildDate");
            decoder.PopNamespace();
        }

        /// <summary>
        /// Method for comparing two objects of the class SkyNetRobot.
        /// </summary>
        /// <see cref="IEncodeable.IsEqual(IEncodeable)"/>
        public override bool IsEqual(IEncodeable encodeable)
        {
            if (Object.ReferenceEquals(this, encodeable))
            {
                return true;
            }

            SkyNetRobot value = encodeable as SkyNetRobot;

            if (value == null)
            {
                return false;
            }

            if (GetType().BaseType != typeof(EncodeableObject))
            {
                if (!base.IsEqual(encodeable))
                {
                    return false;
                }
            }

            if (!Utils.IsEqual(m_model, value.m_model)) return false;
            if (!Utils.IsEqual(m_targetSensor, value.m_targetSensor)) return false;
            if (!Utils.IsEqual(m_buildDate, value.m_buildDate)) return false;

            return true;
        }

        #region Private Fields
        // The type Id for IEncodeable object.        
        private static ExpandedNodeId m_TypeId = new ExpandedNodeId(1, VendorNamespaces.Cyberdyne);

        // The Id used for Binary Encoding.      
        private static ExpandedNodeId m_BinaryEncodingId = new ExpandedNodeId(11, VendorNamespaces.Cyberdyne);

        // The Id used for XML Encoding.       
        private static ExpandedNodeId m_XmlEncodingId = new ExpandedNodeId(12, VendorNamespaces.Cyberdyne);
        #endregion
        #endregion

        #region Null Fields
        /// <summary>
        /// This method returns an instance of a null AcmeWidget.
        /// </summary>
        public static SkyNetRobot Null
        {
            get { return m_null; }
        }

        // The null object.    
        private static readonly SkyNetRobot m_null = new SkyNetRobot();
        #endregion

        #region Private Fields
        //The Model.        
        private string m_model;

        //The target sensor.        
        private AcmeWidget m_targetSensor;

        //The build date.        
        private DateTime m_buildDate;
        #endregion
    }
    #endregion

    #region S88Batch Class
    /// <summary>
    /// The S88Batch class.
    /// </summary>
    [DataContract(Namespace = VendorNamespaces.S88Types)]
    public class S88Batch : EncodeableObject
    {
        #region Constructors
        /// <summary>
        /// The default constructor.
        /// </summary>
        public S88Batch()
        {
            Initialize();
        }

        /// <summary>
        /// Sets private members to default values.
        /// </summary>
        private void Initialize()
        {
            m_batchID = 0;
            m_recipeID = 0;
            m_startTime = DateTime.MinValue;
            m_endTime = DateTime.MinValue;
            m_unitProcedures = null;
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// The BatchID property.
        /// </summary>
        [DataMember(Name = "BatchID", Order = 1)]
        public Int32 BatchID
        {
            get { return m_batchID; }
            set { m_batchID = value; }
        }

        /// <summary>
        /// The RecipeID property.
        /// </summary>
        [DataMember(Name = "RecipeID", Order = 2)]
        public UInt16 RecipeID
        {
            get { return m_recipeID; }
            set { m_recipeID = value; }
        }

        /// <summary>
        /// The StartTime property.
        /// </summary>
        [DataMember(Name = "StartTime", Order = 3)]
        public DateTime StartTime
        {
            get { return m_startTime; }
            set { m_startTime = value; }
        }

        /// <summary>
        /// The EndTime property.
        /// </summary>
        [DataMember(Name = "EndTime", Order = 4)]
        public DateTime EndTime
        {
            get { return m_endTime; }
            set { m_endTime = value; }
        }

        /// <summary>
        /// The UnitProcedures property.
        /// </summary>
        [DataMember(Name = "UnitProcedures", Order = 5)]
        public S88UnitProcedure[] UnitProcedures
        {
            get { return m_unitProcedures; }
            set { m_unitProcedures = value; }
        }
        #endregion

        #region IEncodeable Members

        /// <summary cref="IEncodeable.TypeId"/>
        public override ExpandedNodeId TypeId
        {
            get { return m_TypeId; }
        }

        /// <summary cref="IEncodeable.BinaryEncodingId"/>
        public override ExpandedNodeId BinaryEncodingId
        {
            get { return m_BinaryEncodingId; }
        }

        /// <summary cref="IEncodeable.XmlEncodingId"/>
        public override ExpandedNodeId XmlEncodingId
        {
            get { return m_XmlEncodingId; }
        }

        /// <summary>
        /// Encodes the object in a stream.
        /// </summary>
        public override void Encode(IEncoder encoder)
        {
            base.Encode(encoder);

            encoder.PushNamespace(VendorNamespaces.S88Types);
            encoder.WriteInt32("BatchID", BatchID);
            encoder.WriteUInt16("RecipeID", RecipeID);
            encoder.WriteDateTime("StartTime", StartTime);
            encoder.WriteDateTime("EndTime", EndTime);
            encoder.WriteEncodeableArray("UnitProcedures", UnitProcedures, typeof(S88UnitProcedure));

            encoder.PopNamespace();
        }

        /// <summary>
        /// Decodes the object from a stream.
        /// </summary>
        public override void Decode(IDecoder decoder)
        {
            base.Decode(decoder);

            decoder.PushNamespace(VendorNamespaces.S88Types);
            BatchID = decoder.ReadInt32("BatchID");
            RecipeID = decoder.ReadUInt16("RecipeID");
            StartTime = decoder.ReadDateTime("StartTime");
            EndTime = decoder.ReadDateTime("EndTime");
            UnitProcedures = (S88UnitProcedure[])decoder.ReadEncodeableArray("UnitProcedures", typeof(S88UnitProcedure));

            decoder.PopNamespace();
        }

        /// <summary>
        /// Method for comparing two objects of the class S88Types.
        /// </summary>
        /// <see cref="IEncodeable.IsEqual(IEncodeable)"/>
        public override bool IsEqual(IEncodeable encodeable)
        {
            if (Object.ReferenceEquals(this, encodeable))
            {
                return true;
            }

            S88Batch value = encodeable as S88Batch;

            if (value == null)
            {
                return false;
            }

            if (GetType().BaseType != typeof(EncodeableObject))
            {
                if (!base.IsEqual(encodeable))
                {
                    return false;
                }
            }

            if (!Utils.IsEqual(m_batchID, value.m_batchID)) return false;
            if (!Utils.IsEqual(m_recipeID, value.m_recipeID)) return false;
            if (!Utils.IsEqual(m_startTime, value.m_startTime)) return false;
            if (!Utils.IsEqual(m_endTime, value.m_endTime)) return false;
            return true;
        }

        #region Private Fields
        // The type Id for IEncodeable object.      
        private static ExpandedNodeId m_TypeId = new ExpandedNodeId(1, VendorNamespaces.S88Types);

        // The Id used for Binary Encoding.   
        private static ExpandedNodeId m_BinaryEncodingId = new ExpandedNodeId(11, VendorNamespaces.S88Types);

        // The Id used for XML Encoding.        
        private static ExpandedNodeId m_XmlEncodingId = new ExpandedNodeId(12, VendorNamespaces.S88Types);
        #endregion
        #endregion

        #region Null Fields
        /// <summary>
        /// This method returns an instance of a null AcmeWidget.
        /// </summary>
        public static S88Batch Null
        {
            get { return m_null; }
        }

        // The null object.       
        private static readonly S88Batch m_null = new S88Batch();
        #endregion

        #region Private Fields
        //The batch id.        
        private Int32 m_batchID;

        //The recipe id.        
        private UInt16 m_recipeID;

        //The start time.        
        private DateTime m_startTime;

        //The end time.        
        private DateTime m_endTime;

        //No of unit procedures in the batch. Minimum count should be 1        
        private S88UnitProcedure[] m_unitProcedures;
        #endregion
    }
    #endregion

    #region S88UnitProcedure Class
    /// <summary>
    /// The S88UnitProcedure class.
    /// </summary>
    [DataContract(Namespace = VendorNamespaces.S88Procedures)]
    public class S88UnitProcedure : EncodeableObject
    {
        #region Constructors
        /// <summary>
        /// The default constructor.
        /// </summary>
        public S88UnitProcedure()
        {
            Initialize();
        }

        /// <summary>
        /// Sets private members to default values.
        /// </summary>
        private void Initialize()
        {
            m_unitProcedureName = null;
            m_unitId = null;
            m_startTime = DateTime.MinValue;
            m_endTime = DateTime.MinValue;
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// The UnitProcedureName property.
        /// </summary>
        [DataMember(Name = "UnitProcedureName", Order = 1)]
        public string UnitProcedureName
        {
            get { return m_unitProcedureName; }
            set { m_unitProcedureName = value; }
        }

        /// <summary>
        /// The UnitId property.
        /// </summary>
        [DataMember(Name = "UnitId", Order = 2)]
        public QualifiedName UnitId
        {
            get { return m_unitId; }
            set { m_unitId = value; }
        }

        /// <summary>
        /// The StartTime property.
        /// </summary>
        [DataMember(Name = "StartTime", Order = 3)]
        public DateTime StartTime
        {
            get { return m_startTime; }
            set { m_startTime = value; }
        }

        /// <summary>
        /// The EndTime property.
        /// </summary>
        [DataMember(Name = "EndTime", Order = 4)]
        public DateTime EndTime
        {
            get { return m_endTime; }
            set { m_endTime = value; }
        }
        #endregion

        #region IEncodeable Members

        /// <summary cref="IEncodeable.TypeId"/>
        public override ExpandedNodeId TypeId
        {
            get { return m_TypeId; }
        }

        /// <summary cref="IEncodeable.BinaryEncodingId"/>
        public override ExpandedNodeId BinaryEncodingId
        {
            get { return m_BinaryEncodingId; }
        }

        /// <summary cref="IEncodeable.XmlEncodingId"/>
        public override ExpandedNodeId XmlEncodingId
        {
            get { return m_XmlEncodingId; }
        }

        /// <summary>
        /// Encodes the object in a stream.
        /// </summary>
        public override void Encode(IEncoder encoder)
        {
            base.Encode(encoder);

            encoder.PushNamespace(VendorNamespaces.S88Procedures);
            encoder.WriteString("UnitProcedureName", UnitProcedureName);
            encoder.WriteQualifiedName("UnitId", UnitId);
            encoder.WriteDateTime("StartTime", StartTime);
            encoder.WriteDateTime("EndTime", EndTime);

            encoder.PopNamespace();
        }

        /// <summary>
        /// Decodes the object from a stream.
        /// </summary>
        public override void Decode(IDecoder decoder)
        {
            base.Decode(decoder);

            decoder.PushNamespace(VendorNamespaces.S88Procedures);
            UnitProcedureName = decoder.ReadString("UnitProcedureName");
            UnitId = decoder.ReadQualifiedName("UnitId");
            StartTime = decoder.ReadDateTime("StartTime");
            EndTime = decoder.ReadDateTime("EndTime");

            decoder.PopNamespace();
        }

        /// <summary>
        /// Method for comparing two objects of the class S88Procedures.
        /// </summary>
        /// <see cref="IEncodeable.IsEqual(IEncodeable)"/>
        public override bool IsEqual(IEncodeable encodeable)
        {
            if (Object.ReferenceEquals(this, encodeable))
            {
                return true;
            }

            S88UnitProcedure value = encodeable as S88UnitProcedure;

            if (value == null)
            {
                return false;
            }

            if (GetType().BaseType != typeof(EncodeableObject))
            {
                if (!base.IsEqual(encodeable))
                {
                    return false;
                }
            }

            if (!Utils.IsEqual(m_unitProcedureName, value.m_unitProcedureName)) return false;
            if (!Utils.IsEqual(m_unitId, value.m_unitId)) return false;
            if (!Utils.IsEqual(m_startTime, value.m_startTime)) return false;
            if (!Utils.IsEqual(m_endTime, value.m_endTime)) return false;
            return true;
        }

        #region Private Fields
        // The type Id for IEncodeable object.    
        private static ExpandedNodeId m_TypeId = new ExpandedNodeId(1, VendorNamespaces.S88Procedures);

        // The Id used for Binary Encoding.
        private static ExpandedNodeId m_BinaryEncodingId = new ExpandedNodeId(11, VendorNamespaces.S88Procedures);

        // The Id used for XML Encoding.
        private static ExpandedNodeId m_XmlEncodingId = new ExpandedNodeId(12, VendorNamespaces.S88Procedures);

        #endregion
        #endregion

        #region Null Fields
        /// <summary>
        /// This method returns an instance of a null S88Procedures.
        /// </summary>
        public static S88UnitProcedure Null
        {
            get { return m_null; }
        }

        // The null object.        
        private static readonly S88UnitProcedure m_null = new S88UnitProcedure();
        #endregion

        #region Private Fields
        // The unit procedure name.        
        private string m_unitProcedureName;

        // The Unit Id.        
        private QualifiedName m_unitId;

        // The start time.        
        private DateTime m_startTime;

        // The end time.        
        private DateTime m_endTime;
        #endregion
    }
    #endregion

    #region S88Operation Class
    /// <summary>
    /// The S88Operation class.
    /// </summary>
    [DataContract(Namespace = VendorNamespaces.S88Types)]
    public class S88Operation : EncodeableObject
    {
        #region Constructors
        /// <summary>
        /// The default constructor.
        /// </summary>
        public S88Operation()
        {
            Initialize();
        }

        /// <summary>
        /// Sets private members to default values.
        /// </summary>
        private void Initialize()
        {
            m_operationName = null;
            m_startTime = DateTime.MinValue;
            m_endTime = DateTime.MinValue;
            m_phases = null;
        }
        #endregion

        #region Public Properties

        /// <summary>
        /// The OperationName property.
        /// </summary>
        [DataMember(Name = "OperationName", Order = 1)]
        public string OperationName
        {
            get { return m_operationName; }
            set { m_operationName = value; }
        }

        /// <summary>
        /// The StartTimeproperty.
        /// </summary>
        [DataMember(Name = "StartTime", Order = 2)]
        public DateTime StartTime
        {
            get { return m_startTime; }
            set { m_startTime = value; }
        }

        /// <summary>
        /// The EndTime property.
        /// </summary>
        [DataMember(Name = "EndTime", Order = 3)]
        public DateTime EndTime
        {
            get { return m_endTime; }
            set { m_endTime = value; }
        }

        /// <summary>
        /// The Phases property.
        /// </summary>
        [DataMember(Name = "Phases", Order = 4)]
        public S88Phase[] Phases
        {
            get { return m_phases; }
            set { m_phases = value; }
        }
        #endregion

        #region IEncodeable Members
        /// <summary cref="IEncodeable.TypeId"/>
        public override ExpandedNodeId TypeId
        {
            get { return m_TypeId; }
        }

        /// <summary cref="IEncodeable.BinaryEncodingId"/>
        public override ExpandedNodeId BinaryEncodingId
        {
            get { return m_BinaryEncodingId; }
        }

        /// <summary cref="IEncodeable.XmlEncodingId"/>
        public override ExpandedNodeId XmlEncodingId
        {
            get { return m_XmlEncodingId; }
        }


        /// <summary>
        /// Encodes the object in a stream.
        /// </summary>
        public override void Encode(IEncoder encoder)
        {
            base.Encode(encoder);

            encoder.PushNamespace(VendorNamespaces.S88Types);
            encoder.WriteString("OperationName", OperationName);
            encoder.WriteDateTime("StartTime", StartTime);
            encoder.WriteDateTime("EndTime", EndTime);
            encoder.WriteEncodeableArray("Phases", Phases, typeof(S88Phase));
            encoder.PopNamespace();
        }

        /// <summary>
        /// Decodes the object from a stream.
        /// </summary>
        public override void Decode(IDecoder decoder)
        {
            base.Decode(decoder);

            decoder.PushNamespace(VendorNamespaces.S88Types);
            OperationName = decoder.ReadString("OperationName");
            StartTime = decoder.ReadDateTime("StartTime");
            EndTime = decoder.ReadDateTime("EndTime");
            Phases = (S88Phase[])decoder.ReadEncodeableArray("Phases", typeof(S88Phase));
            decoder.PopNamespace();
        }

        /// <summary>
        /// Method for comparing two objects of the class S88Types.
        /// </summary>
        /// <see cref="IEncodeable.IsEqual(IEncodeable)"/>
        public override bool IsEqual(IEncodeable encodeable)
        {
            if (Object.ReferenceEquals(this, encodeable))
            {
                return true;
            }

            S88Operation value = encodeable as S88Operation;

            if (value == null)
            {
                return false;
            }

            if (GetType().BaseType != typeof(EncodeableObject))
            {
                if (!base.IsEqual(encodeable))
                {
                    return false;
                }
            }

            if (!Utils.IsEqual(m_operationName, value.m_operationName)) return false;
            if (!Utils.IsEqual(m_startTime, value.m_startTime)) return false;
            if (!Utils.IsEqual(m_endTime, value.m_endTime)) return false;

            return true;
        }
        #region Private Fields
        // The type Id for IEncodeable object.        
        private static ExpandedNodeId m_TypeId = new ExpandedNodeId(2, VendorNamespaces.S88Types);

        // The Id used for Binary Encoding.       
        private static ExpandedNodeId m_BinaryEncodingId = new ExpandedNodeId(21, VendorNamespaces.S88Types);

        // The Id used for XML Encoding.      
        private static ExpandedNodeId m_XmlEncodingId = new ExpandedNodeId(22, VendorNamespaces.S88Types);

        #endregion
        #endregion

        #region Null Fields
        /// <summary>
        /// This method returns an instance of a null S88Types.
        /// </summary>
        public static S88Operation Null
        {
            get { return m_null; }
        }

        // The null object.       
        private static readonly S88Operation m_null = new S88Operation();
        #endregion

        #region Private Fields
        // The operation name.        
        private string m_operationName;

        // The start time.        
        private DateTime m_startTime;

        // The end time.        
        private DateTime m_endTime;

        // The array of phases.        
        private S88Phase[] m_phases;
        #endregion
    }
    #endregion

    #region S88Phase Class
    /// <summary>
    /// The S88 class.
    /// </summary>
    [DataContract(Namespace = VendorNamespaces.S88Procedures)]
    public class S88Phase : EncodeableObject
    {
        #region Constructors
        /// <summary>
        /// The default constructor.
        /// </summary>
        public S88Phase()
        {
            Initialize();
        }

        /// <summary>
        /// Sets private members to default values.
        /// </summary>
        private void Initialize()
        {
            m_phaseName = null;
            m_startTime = DateTime.MinValue;
            m_endTime = DateTime.MinValue;
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// The PhaseName property.
        /// </summary>
        [DataMember(Name = "PhaseName", Order = 1)]
        public string PhaseName
        {
            get { return m_phaseName; }
            set { m_phaseName = value; }
        }

        /// <summary>
        /// The StartTime property.
        /// </summary>
        [DataMember(Name = "StartTime", Order = 2)]
        public DateTime StartTime
        {
            get { return m_startTime; }
            set { m_startTime = value; }
        }

        /// <summary>
        /// The EndTime property.
        /// </summary>
        [DataMember(Name = "EndTime", Order = 3)]
        public DateTime EndTime
        {
            get { return m_endTime; }
            set { m_endTime = value; }
        }

        #endregion

        #region IEncodeable Members

        /// <summary cref="IEncodeable.TypeId"/>
        public override ExpandedNodeId TypeId
        {
            get { return m_TypeId; }
        }

        /// <summary cref="IEncodeable.BinaryEncodingId"/>
        public override ExpandedNodeId BinaryEncodingId
        {
            get { return m_BinaryEncodingId; }
        }

        /// <summary cref="IEncodeable.XmlEncodingId"/>
        public override ExpandedNodeId XmlEncodingId
        {
            get { return m_XmlEncodingId; }
        }

        /// <summary>
        /// Encodes the object in a stream.
        /// </summary>
        public override void Encode(IEncoder encoder)
        {
            base.Encode(encoder);

            encoder.PushNamespace(VendorNamespaces.S88Procedures);
            encoder.WriteString("PhaseName", PhaseName);
            encoder.WriteDateTime("StartTime", StartTime);
            encoder.WriteDateTime("EndTime", EndTime);
            encoder.PopNamespace();
        }

        /// <summary>
        /// Decodes the object from a stream.
        /// </summary>
        public override void Decode(IDecoder decoder)
        {
            base.Decode(decoder);

            decoder.PushNamespace(VendorNamespaces.S88Procedures);
            PhaseName = decoder.ReadString("PhaseName");
            StartTime = decoder.ReadDateTime("StartTime");
            EndTime = decoder.ReadDateTime("EndTime");
            decoder.PopNamespace();
        }

        /// <summary>
        /// Method for comparing two objects of the class S88Procedures.
        /// </summary>
        /// <see cref="IEncodeable.IsEqual(IEncodeable)"/>
        public override bool IsEqual(IEncodeable encodeable)
        {
            if (Object.ReferenceEquals(this, encodeable))
            {
                return true;
            }

            S88Phase value = encodeable as S88Phase;

            if (value == null)
            {
                return false;
            }

            if (GetType().BaseType != typeof(EncodeableObject))
            {
                if (!base.IsEqual(encodeable))
                {
                    return false;
                }
            }

            if (!Utils.IsEqual(m_phaseName, value.m_phaseName)) return false;
            if (!Utils.IsEqual(m_startTime, value.m_startTime)) return false;
            if (!Utils.IsEqual(m_endTime, value.m_endTime)) return false;
            return true;
        }

        #region Private Fields
        // The type Id for IEncodeable object.      
        private static ExpandedNodeId m_TypeId = new ExpandedNodeId(2, VendorNamespaces.S88Procedures);

        // The Id used for Binary Encoding.        
        private static ExpandedNodeId m_BinaryEncodingId = new ExpandedNodeId(21, VendorNamespaces.S88Procedures);

        // The Id used for XML Encoding.      
        private static ExpandedNodeId m_XmlEncodingId = new ExpandedNodeId(22, VendorNamespaces.S88Procedures);

        #endregion
        #endregion

        #region Null Fields
        /// <summary>
        /// This method returns an instance of a null S88Procedures.
        /// </summary>
        public static S88Phase Null
        {
            get { return m_null; }
        }

        // The null object.      
        private static readonly S88Phase m_null = new S88Phase();
        #endregion

        #region Private Fields
        // The phase name.        
        private string m_phaseName;

        // The start time.        
        private DateTime m_startTime;

        // The end time.        
        private DateTime m_endTime;
        #endregion
    }
    #endregion
    
	#region Wheel Class
	/// <summary>
	/// The Wheel class.
	/// </summary>
	[DataContract(Namespace = VendorNamespaces.StandardsBody)]
	public partial class Wheel : EncodeableObject
	{
		#region Constructors
		/// <summary>
		/// The default constructor.
		/// </summary>
		public Wheel()
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
			m_manufacturer = null;
			m_installed = DateTime.MinValue;
		}
		#endregion

		#region Public Properties
		/// <summary>
		/// The Manufacturer property.
		/// </summary>
		[DataMember(Name = "Manufacturer", Order = 1)]
		public string Manufacturer
		{
			get { return m_manufacturer;  }
			set { m_manufacturer = value; }
		}

		/// <summary>
		/// The Installed property.
		/// </summary>
		[DataMember(Name = "Installed", Order = 2)]
		public DateTime Installed
		{
			get { return m_installed;  }
			set { m_installed = value; }
		}
		#endregion

	    #region IEncodeable Members
	    /// <summary cref="IEncodeable.TypeId" />
	    public override ExpandedNodeId TypeId
	    {
	        get { return m_TypeId; }
	    }

	    private static ExpandedNodeId m_TypeId = new ExpandedNodeId(VendorIds.Wheel, VendorNamespaces.StandardsBody);

	    /// <summary cref="IEncodeable.BinaryEncodingId" />
	    public override ExpandedNodeId BinaryEncodingId
	    {
	        get { return m_BinaryEncodingId; }
	    }

	    private static ExpandedNodeId m_BinaryEncodingId = new ExpandedNodeId(VendorIds.Wheel_DefaultBinary_Encoding, VendorNamespaces.StandardsBody);
	    
	    /// <summary cref="IEncodeable.XmlEncodingId" />
	    public override ExpandedNodeId XmlEncodingId
	    {
	        get { return m_XmlEncodingId; }
	    }
	    
	    private static ExpandedNodeId m_XmlEncodingId = new ExpandedNodeId(VendorIds.Wheel_DefaultXml_Encoding, VendorNamespaces.StandardsBody);

	    /// <summary cref="IEncodeable.Encode(IEncoder)" />
	    public override void Encode(IEncoder encoder)
	    {
	        base.Encode(encoder);

	        encoder.PushNamespace(VendorNamespaces.StandardsBody);
			encoder.WriteString("Manufacturer", Manufacturer);
			encoder.WriteDateTime("Installed", Installed);
	        encoder.PopNamespace();
	    }
	    
	    /// <summary cref="IEncodeable.Decode(IDecoder)" />
	    public override void Decode(IDecoder decoder)
	    {
	        base.Decode(decoder);

	        decoder.PushNamespace(VendorNamespaces.StandardsBody);
			Manufacturer = decoder.ReadString("Manufacturer");
			Installed = decoder.ReadDateTime("Installed");
	        decoder.PopNamespace();
	    }

	    /// <summary cref="IEncodeable.IsEqual(IEncodeable)" />
	    public override bool IsEqual(IEncodeable encodeable)
	    {
	        if (Object.ReferenceEquals(this, encodeable))
	        {
	            return true;
	        }
	        
	        Wheel value = encodeable as Wheel;
	        
	        if (value == null)
	        {
	            return false;
	        }

	        if (GetType().BaseType != typeof(EncodeableObject))
	        {
	            if (!base.IsEqual(encodeable))
	            {
	                return false;
	            }
	        }
	        
			if (!Utils.IsEqual(m_manufacturer, value.m_manufacturer)) return false;
			if (!Utils.IsEqual(m_installed, value.m_installed)) return false;

	        return true;
	    }
	    
	    /// <summary cref="ICloneable.Clone" />
	    public override object Clone()
	    {
	        Wheel clone = (Wheel)base.Clone();
	        clone.m_manufacturer = (string)Utils.Clone(this.m_manufacturer);
	        clone.m_installed = (DateTime)Utils.Clone(this.m_installed);
	        return clone;
	    }
	    #endregion

		#region Private Fields
		private string m_manufacturer;
		private DateTime m_installed;
		#endregion
	}

	#region WheelCollection Class
	/// <summary>
	/// A collection of Wheel objects.
	/// </summary>
	[CollectionDataContract(Name = "ListOfWheel", Namespace = VendorNamespaces.StandardsBody, ItemName="Wheel")]
	public partial class WheelCollection : List<Wheel>, ICloneable
	{
		#region Constructors
		/// <summary>
		/// Initializes the collection with default values.
		/// </summary>
		public WheelCollection() {}
		
		/// <summary>
		/// Initializes the collection with an initial capacity.
		/// </summary>
		public WheelCollection(int capacity) : base(capacity) {}
		
		/// <summary>
		/// Initializes the collection with another collection.
		/// </summary>
		public WheelCollection(IEnumerable<Wheel> collection) : base(collection) {}
		#endregion
	                
	    #region Static Operators
	    /// <summary>
	    /// Converts an array to a collection.
	    /// </summary>
	    public static implicit operator WheelCollection(Wheel[] values)
	    {
	        if (values != null)
	        {
	            return new WheelCollection(values);
	        }

	        return new WheelCollection();
	    }
	    
	    /// <summary>
	    /// Converts a collection to an array.
	    /// </summary>
	    public static explicit operator Wheel[](WheelCollection values)
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
	        WheelCollection clone = new WheelCollection(this.Count);

	        foreach (Wheel element in this)
	        {
	            if (element != null)
	            {
	                clone.Add((Wheel)element.Clone());
	            }
	            else
	            {
	                clone.Add(null);
	            }
	        }

	        return clone;
	    }
	    #endregion
	}
	#endregion
	#endregion

	#region Vehicle Class
	/// <summary>
	/// The Vehicle class.
	/// </summary>
	[DataContract(Namespace = VendorNamespaces.StandardsBody)]
	public partial class Vehicle : EncodeableObject
	{
		#region Constructors
		/// <summary>
		/// The default constructor.
		/// </summary>
		public Vehicle()
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
			m_make = null;
			m_model = null;
			m_year = 0;
			m_wheels = new WheelCollection();
		}
		#endregion

		#region Public Properties
		/// <summary>
		/// The Make property.
		/// </summary>
		[DataMember(Name = "Make", Order = 1)]
		public string Make
		{
			get { return m_make;  }
			set { m_make = value; }
		}

		/// <summary>
		/// The Model property.
		/// </summary>
		[DataMember(Name = "Model", Order = 2)]
		public string Model
		{
			get { return m_model;  }
			set { m_model = value; }
		}

		/// <summary>
		/// The Year property.
		/// </summary>
		[DataMember(Name = "Year", Order = 3)]
		public ushort Year
		{
			get { return m_year;  }
			set { m_year = value; }
		}

		/// <summary>
		/// The Wheels property.
		/// </summary>
		[DataMember(Name = "Wheels", Order = 4)]
		public WheelCollection Wheels
		{
			get { return m_wheels;  }

		    set
		    {
		        if (value != null)
		        {
		            m_wheels = value;
		        }
		        else
		        {
		            m_wheels = new WheelCollection();
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

	    private static ExpandedNodeId m_TypeId = new ExpandedNodeId(VendorIds.Vehicle, VendorNamespaces.StandardsBody);

	    /// <summary cref="IEncodeable.BinaryEncodingId" />
	    public override ExpandedNodeId BinaryEncodingId
	    {
	        get { return m_BinaryEncodingId; }
	    }

	    private static ExpandedNodeId m_BinaryEncodingId = new ExpandedNodeId(VendorIds.Vehicle_DefaultBinary_Encoding, VendorNamespaces.StandardsBody);
	    
	    /// <summary cref="IEncodeable.XmlEncodingId" />
	    public override ExpandedNodeId XmlEncodingId
	    {
	        get { return m_XmlEncodingId; }
	    }
	    
	    private static ExpandedNodeId m_XmlEncodingId = new ExpandedNodeId(VendorIds.Vehicle_DefaultXml_Encoding, VendorNamespaces.StandardsBody);

	    /// <summary cref="IEncodeable.Encode(IEncoder)" />
	    public override void Encode(IEncoder encoder)
	    {
	        base.Encode(encoder);

	        encoder.PushNamespace(VendorNamespaces.StandardsBody);
			encoder.WriteString("Make", Make);
			encoder.WriteString("Model", Model);
			encoder.WriteUInt16("Year", Year);
			encoder.WriteEncodeableArray("Wheels", (Wheel[])Wheels, typeof(Wheel));
	        encoder.PopNamespace();
	    }
	    
	    /// <summary cref="IEncodeable.Decode(IDecoder)" />
	    public override void Decode(IDecoder decoder)
	    {
	        base.Decode(decoder);

	        decoder.PushNamespace(VendorNamespaces.StandardsBody);
			Make = decoder.ReadString("Make");
			Model = decoder.ReadString("Model");
			Year = decoder.ReadUInt16("Year");
			Wheels = (WheelCollection)decoder.ReadEncodeableArray("Wheels", typeof(Wheel));
	        decoder.PopNamespace();
	    }

	    /// <summary cref="IEncodeable.IsEqual(IEncodeable)" />
	    public override bool IsEqual(IEncodeable encodeable)
	    {
	        if (Object.ReferenceEquals(this, encodeable))
	        {
	            return true;
	        }
	        
	        Vehicle value = encodeable as Vehicle;
	        
	        if (value == null)
	        {
	            return false;
	        }

	        if (GetType().BaseType != typeof(EncodeableObject))
	        {
	            if (!base.IsEqual(encodeable))
	            {
	                return false;
	            }
	        }
	        
			if (!Utils.IsEqual(m_make, value.m_make)) return false;
			if (!Utils.IsEqual(m_model, value.m_model)) return false;
			if (!Utils.IsEqual(m_year, value.m_year)) return false;
			if (!Utils.IsEqual(m_wheels, value.m_wheels)) return false;

	        return true;
	    }
	    
	    /// <summary cref="ICloneable.Clone" />
	    public override object Clone()
	    {
	        Vehicle clone = (Vehicle)base.Clone();
	        clone.m_make = (string)Utils.Clone(this.m_make);
	        clone.m_model = (string)Utils.Clone(this.m_model);
	        clone.m_year = (ushort)Utils.Clone(this.m_year);
	        clone.m_wheels = (WheelCollection)Utils.Clone(this.m_wheels);
	        return clone;
	    }
	    #endregion

		#region Private Fields
		private string m_make;
		private string m_model;
		private ushort m_year;
		private WheelCollection m_wheels;
		#endregion
	}
	#endregion

	#region Car Class
	/// <summary>
	/// The Car class.
	/// </summary>
	[DataContract(Namespace = VendorNamespaces.Vendor1)]
	public partial class Car : Vehicle
	{
		#region Constructors
		/// <summary>
		/// The default constructor.
		/// </summary>
		public Car()
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
			m_isHatchback = false;
		}
		#endregion

		#region Public Properties
		/// <summary>
		/// The IsHatchback property.
		/// </summary>
		[DataMember(Name = "IsHatchback", Order = 1)]
		public bool IsHatchback
		{
			get { return m_isHatchback;  }
			set { m_isHatchback = value; }
		}
		#endregion

	    #region IEncodeable Members
	    /// <summary cref="IEncodeable.TypeId" />
	    public override ExpandedNodeId TypeId
	    {
	        get { return m_TypeId; }
	    }

	    private static ExpandedNodeId m_TypeId = new ExpandedNodeId(VendorIds.Car, VendorNamespaces.Vendor1);

	    /// <summary cref="IEncodeable.BinaryEncodingId" />
	    public override ExpandedNodeId BinaryEncodingId
	    {
	        get { return m_BinaryEncodingId; }
	    }

	    private static ExpandedNodeId m_BinaryEncodingId = new ExpandedNodeId(VendorIds.Car_DefaultBinary_Encoding, VendorNamespaces.Vendor1);
	    
	    /// <summary cref="IEncodeable.XmlEncodingId" />
	    public override ExpandedNodeId XmlEncodingId
	    {
	        get { return m_XmlEncodingId; }
	    }
	    
	    private static ExpandedNodeId m_XmlEncodingId = new ExpandedNodeId(VendorIds.Car_DefaultXml_Encoding, VendorNamespaces.Vendor1);

	    /// <summary cref="IEncodeable.Encode(IEncoder)" />
	    public override void Encode(IEncoder encoder)
	    {
	        base.Encode(encoder);

	        encoder.PushNamespace(VendorNamespaces.Vendor1);
			encoder.WriteBoolean("IsHatchback", IsHatchback);
	        encoder.PopNamespace();
	    }
	    
	    /// <summary cref="IEncodeable.Decode(IDecoder)" />
	    public override void Decode(IDecoder decoder)
	    {
	        base.Decode(decoder);

	        decoder.PushNamespace(VendorNamespaces.Vendor1);
			IsHatchback = decoder.ReadBoolean("IsHatchback");
	        decoder.PopNamespace();
	    }

	    /// <summary cref="IEncodeable.IsEqual(IEncodeable)" />
	    public override bool IsEqual(IEncodeable encodeable)
	    {
	        if (Object.ReferenceEquals(this, encodeable))
	        {
	            return true;
	        }
	        
	        Car value = encodeable as Car;
	        
	        if (value == null)
	        {
	            return false;
	        }

	        if (GetType().BaseType != typeof(EncodeableObject))
	        {
	            if (!base.IsEqual(encodeable))
	            {
	                return false;
	            }
	        }
	        
			if (!Utils.IsEqual(m_isHatchback, value.m_isHatchback)) return false;

	        return true;
	    }
	    
	    /// <summary cref="ICloneable.Clone" />
	    public override object Clone()
	    {
	        Car clone = (Car)base.Clone();
	        clone.m_isHatchback = (bool)Utils.Clone(this.m_isHatchback);
	        return clone;
	    }
	    #endregion

		#region Private Fields
		private bool m_isHatchback;
		#endregion
	}
	#endregion

	#region Truck Class
	/// <summary>
	/// The Truck class.
	/// </summary>
	[DataContract(Namespace = VendorNamespaces.Vendor2)]
	public partial class Truck : Vehicle
	{
		#region Constructors
		/// <summary>
		/// The default constructor.
		/// </summary>
		public Truck()
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
			m_capacity = 0;
		}
		#endregion

		#region Public Properties
		/// <summary>
		/// The Capacity property.
		/// </summary>
		[DataMember(Name = "Capacity", Order = 1)]
		public uint Capacity
		{
			get { return m_capacity;  }
			set { m_capacity = value; }
		}
		#endregion

	    #region IEncodeable Members
	    /// <summary cref="IEncodeable.TypeId" />
	    public override ExpandedNodeId TypeId
	    {
	        get { return m_TypeId; }
	    }

	    private static ExpandedNodeId m_TypeId = new ExpandedNodeId(VendorIds.Truck, VendorNamespaces.Vendor2);

	    /// <summary cref="IEncodeable.BinaryEncodingId" />
	    public override ExpandedNodeId BinaryEncodingId
	    {
	        get { return m_BinaryEncodingId; }
	    }

	    private static ExpandedNodeId m_BinaryEncodingId = new ExpandedNodeId(VendorIds.Truck_DefaultBinary_Encoding, VendorNamespaces.Vendor2);
	    
	    /// <summary cref="IEncodeable.XmlEncodingId" />
	    public override ExpandedNodeId XmlEncodingId
	    {
	        get { return m_XmlEncodingId; }
	    }
	    
	    private static ExpandedNodeId m_XmlEncodingId = new ExpandedNodeId(VendorIds.Truck_DefaultXml_Encoding, VendorNamespaces.Vendor2);

	    /// <summary cref="IEncodeable.Encode(IEncoder)" />
	    public override void Encode(IEncoder encoder)
	    {
	        base.Encode(encoder);

	        encoder.PushNamespace(VendorNamespaces.Vendor2);
			encoder.WriteUInt32("Capacity", Capacity);
	        encoder.PopNamespace();
	    }
	    
	    /// <summary cref="IEncodeable.Decode(IDecoder)" />
	    public override void Decode(IDecoder decoder)
	    {
	        base.Decode(decoder);

	        decoder.PushNamespace(VendorNamespaces.Vendor2);
			Capacity = decoder.ReadUInt32("Capacity");
	        decoder.PopNamespace();
	    }

	    /// <summary cref="IEncodeable.IsEqual(IEncodeable)" />
	    public override bool IsEqual(IEncodeable encodeable)
	    {
	        if (Object.ReferenceEquals(this, encodeable))
	        {
	            return true;
	        }
	        
	        Truck value = encodeable as Truck;
	        
	        if (value == null)
	        {
	            return false;
	        }

	        if (GetType().BaseType != typeof(EncodeableObject))
	        {
	            if (!base.IsEqual(encodeable))
	            {
	                return false;
	            }
	        }
	        
			if (!Utils.IsEqual(m_capacity, value.m_capacity)) return false;

	        return true;
	    }
	    
	    /// <summary cref="ICloneable.Clone" />
	    public override object Clone()
	    {
	        Truck clone = (Truck)base.Clone();
	        clone.m_capacity = (uint)Utils.Clone(this.m_capacity);
	        return clone;
	    }
	    #endregion

		#region Private Fields
		private uint m_capacity;
		#endregion
	}
	#endregion

	#region Driver Class
	/// <summary>
	/// The Driver class.
	/// </summary>
	[DataContract(Namespace = VendorNamespaces.StandardsBody)]
	public partial class Driver : EncodeableObject
	{
		#region Constructors
		/// <summary>
		/// The default constructor.
		/// </summary>
		public Driver()
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
			m_name = Opc.Ua.LocalizedText.Null;
			m_vehicle = null;
			m_licenseNumber = Opc.Ua.Uuid.Empty;
		}
		#endregion

		#region Public Properties
		/// <summary>
		/// The Name property.
		/// </summary>
		[DataMember(Name = "Name", Order = 1)]
		public LocalizedText Name
		{
			get { return m_name;  }
			set { m_name = value; }
		}

		/// <summary>
		/// The Vehicle property.
		/// </summary>
		[DataMember(Name = "Vehicle", Order = 2)]
		public ExtensionObject Vehicle
		{
			get { return m_vehicle;  }
			set { m_vehicle = value; }
		}

		/// <summary>
		/// The LicenseNumber property.
		/// </summary>
		[DataMember(Name = "LicenseNumber", Order = 3)]
		public Uuid LicenseNumber
		{
			get { return m_licenseNumber;  }
			set { m_licenseNumber = value; }
		}
		#endregion

	    #region IEncodeable Members
	    /// <summary cref="IEncodeable.TypeId" />
	    public override ExpandedNodeId TypeId
	    {
	        get { return m_TypeId; }
	    }

	    private static ExpandedNodeId m_TypeId = new ExpandedNodeId(VendorIds.Driver, VendorNamespaces.StandardsBody);

	    /// <summary cref="IEncodeable.BinaryEncodingId" />
	    public override ExpandedNodeId BinaryEncodingId
	    {
	        get { return m_BinaryEncodingId; }
	    }

	    private static ExpandedNodeId m_BinaryEncodingId = new ExpandedNodeId(VendorIds.Driver_DefaultBinary_Encoding, VendorNamespaces.StandardsBody);
	    
	    /// <summary cref="IEncodeable.XmlEncodingId" />
	    public override ExpandedNodeId XmlEncodingId
	    {
	        get { return m_XmlEncodingId; }
	    }
	    
	    private static ExpandedNodeId m_XmlEncodingId = new ExpandedNodeId(VendorIds.Driver_DefaultXml_Encoding, VendorNamespaces.StandardsBody);

	    /// <summary cref="IEncodeable.Encode(IEncoder)" />
	    public override void Encode(IEncoder encoder)
	    {
	        base.Encode(encoder);

	        encoder.PushNamespace(VendorNamespaces.StandardsBody);
			encoder.WriteLocalizedText("Name", Name);
			encoder.WriteExtensionObject("Vehicle", Vehicle);
			encoder.WriteGuid("LicenseNumber", LicenseNumber);
	        encoder.PopNamespace();
	    }
	    
	    /// <summary cref="IEncodeable.Decode(IDecoder)" />
	    public override void Decode(IDecoder decoder)
	    {
	        base.Decode(decoder);

	        decoder.PushNamespace(VendorNamespaces.StandardsBody);
			Name = decoder.ReadLocalizedText("Name");
			Vehicle = decoder.ReadExtensionObject("Vehicle");
			LicenseNumber = decoder.ReadGuid("LicenseNumber");
	        decoder.PopNamespace();
	    }

	    /// <summary cref="IEncodeable.IsEqual(IEncodeable)" />
	    public override bool IsEqual(IEncodeable encodeable)
	    {
	        if (Object.ReferenceEquals(this, encodeable))
	        {
	            return true;
	        }
	        
	        Driver value = encodeable as Driver;
	        
	        if (value == null)
	        {
	            return false;
	        }

	        if (GetType().BaseType != typeof(EncodeableObject))
	        {
	            if (!base.IsEqual(encodeable))
	            {
	                return false;
	            }
	        }
	        
			if (!Utils.IsEqual(m_name, value.m_name)) return false;
			if (!Utils.IsEqual(m_vehicle, value.m_vehicle)) return false;
			if (!Utils.IsEqual(m_licenseNumber, value.m_licenseNumber)) return false;

	        return true;
	    }
	    
	    /// <summary cref="ICloneable.Clone" />
	    public override object Clone()
	    {
	        Driver clone = (Driver)base.Clone();
	        clone.m_name = (LocalizedText)Utils.Clone(this.m_name);
	        clone.m_vehicle = (ExtensionObject)Utils.Clone(this.m_vehicle);
	        clone.m_licenseNumber = (Uuid)Utils.Clone(this.m_licenseNumber);
	        return clone;
	    }
	    #endregion

		#region Private Fields
		private LocalizedText m_name;
		private ExtensionObject m_vehicle;
		private Uuid m_licenseNumber;
		#endregion
	}
	#endregion
        
    #region VendorNamespaces Class
    /// <summary>
    /// Namespaces used for vendor defined types.
    /// </summary>
    public static class VendorNamespaces
    {
        /// <summary>
        /// The Acme namespace.
        /// </summary>
        public const string Acme = "http://acme.com/widgets";

        /// <summary>
        /// The Coyote Enterprises namespace.
        /// </summary>
        public const string Coyote = "http://coyote.com/gadgets";

        /// <summary>
        /// The Cyberdyne namespace.
        /// </summary>
        public const string Cyberdyne = "http://cyberdyne.net/robots";

        /// <summary>
        /// The S88Types namespace.
        /// </summary>
        public const string S88Types = "http://S88.com/types";

        /// <summary>
        /// The S88Procedures namespace.
        /// </summary>
        public const string S88Procedures = "http://S88.com/procedures";
                
        /// <summary>
        /// The StandardsBody namespace.
        /// </summary>
        public const string StandardsBody = "http://standardsrus.org/test";
                
        /// <summary>
        /// The Vendor1 namespace.
        /// </summary>
        public const string Vendor1 = "http://carsandmore.com/test";
                
        /// <summary>
        /// The Vendor2 namespace.
        /// </summary>
        public const string Vendor2 = "http://toughtrucks.com/test";      
    }
    #endregion

    /// <summary>
    /// The data type identifiers for the vendor defined types.
    /// </summary>
    public static class VendorIds
    {
        /// <remarks />
        public const uint Wheel                                            = 1393;
        /// <remarks />
        public const uint Wheel_DefaultBinary_Encoding                     = 1394;
        /// <remarks />
        public const uint Wheel_DefaultXml_Encoding                        = 1395;
        /// <remarks />
        public const uint Wheel_BinarySchema_Description                   = 1396;
        /// <remarks />
        public const uint Wheel_BinarySchema_Description_DataTypeVersion   = 1397;
        /// <remarks />
        public const uint Wheel_XmlSchema_Description                      = 1398;
        /// <remarks />
        public const uint Wheel_XmlSchema_Description_DataTypeVersion      = 1399;
        /// <remarks />
        public const uint Vehicle                                          = 1400;
        /// <remarks />
        public const uint Vehicle_DefaultBinary_Encoding                   = 1401;
        /// <remarks />
        public const uint Vehicle_DefaultXml_Encoding                      = 1402;
        /// <remarks />
        public const uint Vehicle_BinarySchema_Description                 = 1403;
        /// <remarks />
        public const uint Vehicle_BinarySchema_Description_DataTypeVersion = 1404;
        /// <remarks />
        public const uint Vehicle_XmlSchema_Description                    = 1405;
        /// <remarks />
        public const uint Vehicle_XmlSchema_Description_DataTypeVersion    = 1406;
        /// <remarks>Deliberately use the same ids as Vehicle to ensure the namespace uri is used correctly.</remarks>
        public const uint Car                                              = 1400;
        /// <remarks />
        public const uint Car_DefaultBinary_Encoding                       = 1401;
        /// <remarks />
        public const uint Car_DefaultXml_Encoding                          = 1402;
        /// <remarks />
        public const uint Car_BinarySchema_Description                     = 1403;
        /// <remarks />
        public const uint Car_BinarySchema_Description_DataTypeVersion     = 1404;
        /// <remarks />
        public const uint Car_XmlSchema_Description                        = 1405;
        /// <remarks />
        public const uint Car_XmlSchema_Description_DataTypeVersion        = 1406;
        /// <remarks />
        public const uint Truck                                            = 1;
        /// <remarks />
        public const uint Truck_DefaultBinary_Encoding                     = 2;
        /// <remarks />
        public const uint Truck_DefaultXml_Encoding                        = 3;
        /// <remarks />
        public const uint Truck_BinarySchema_Description                   = 4;
        /// <remarks />
        public const uint Truck_BinarySchema_Description_DataTypeVersion   = 5;
        /// <remarks />
        public const uint Truck_XmlSchema_Description                      = 6;
        /// <remarks />
        public const uint Truck_XmlSchema_Description_DataTypeVersion      = 7;
        /// <remarks />
        public const uint Driver                                           = 1421;
        /// <remarks />
        public const uint Driver_DefaultBinary_Encoding                    = 1422;
        /// <remarks />
        public const uint Driver_DefaultXml_Encoding                       = 1423;
        /// <remarks />
        public const uint Driver_BinarySchema_Description                  = 1424;
        /// <remarks />
        public const uint Driver_BinarySchema_Description_DataTypeVersion  = 1425;
        /// <remarks />
        public const uint Driver_XmlSchema_Description                     = 1426;
        /// <remarks />
        public const uint Driver_XmlSchema_Description_DataTypeVersion     = 1427;
    }
}
