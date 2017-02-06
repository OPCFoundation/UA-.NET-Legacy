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
using System.IO;
using System.Security.Cryptography;
using System.Reflection;
using System.Xml;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua.StackTest
{
    #region Class PseudoRandom
    /// <summary>
    /// A class that generates random numbers.
    /// </summary>
    public class PseudoRandom
    {
        #region Constructors
        /// <summary>
        /// Initializes the random number generator.
        /// </summary>
        /// <param name="filepath">Random data file path.</param>
        public PseudoRandom(string filepath)
        {
            m_filepath = filepath;

            // simply verifying that the file exists for now.
            byte[] buffer = File.ReadAllBytes(filepath);
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// The file containing the random data used to create the sequences.
        /// </summary>
        public string FilePath
        {
            get { return m_filepath; }
        }

        /// <summary>
        /// Starts a new sequence of numbers with the specified seed.
        /// </summary>
        /// <param name="seed">Seed number for random number generation.</param>
        /// <param name="step">Step size for getting the random number from the file.</param>
        /// <param name="testCaseContext">This parameter stores the test case parameter values.</param>
        public void Start(int seed, int step, TestCaseContext testCaseContext)
        {
            // Create the random number file.
            Create(m_filepath, seed, step, testCaseContext);

            m_seed    = seed;
            m_context = testCaseContext;
        }

        #region Byte
        /// <summary>
        /// This method returns a random byte.
        /// </summary>
        public byte GetRandomByte()
        {
            return GetValueUInt8(m_random);
        }

        /// <summary>
        /// This method returns a byte.
        /// </summary>
        public byte GetByte()
        {
            if (UseBoundaryValue())
            {
                return m_ByteValues[GetRandomIndex(m_ByteValues)];
            }

            return GetRandomByte();
        }

        // Boundary values to use when generating a Byte.       
        private static readonly byte[] m_ByteValues = new byte[] { Byte.MaxValue, Byte.MinValue };

        /// <summary>
        /// This method returns a byte array.
        /// </summary>
        public byte[] GetByteArray()
        {
            int length = GetInt32Range(-1, m_context.MaxArrayLength);

            if (length < 0)
            {
                return null;
            }

            byte[] value = new byte[length];

            for (int ii = 0; ii < value.Length; ii++)
            {
                value[ii] = GetByte();
            }

            return value;
        }
        #endregion

        #region SByte
        /// <summary>
        /// This method returns a random signed byte.
        /// </summary>
        public sbyte GetRandomSByte()
        {
            return GetValueInt8(m_random);
        }

        /// <summary>
        /// This method returns a signed byte.
        /// </summary>
        public sbyte GetSByte()
        {
            if (UseBoundaryValue())
            {
                return m_SByteValues[GetRandomIndex(m_SByteValues)];
            }

            return GetRandomSByte();
        }

        // Boundary values to use when generating an SByte.        
        private static readonly sbyte[] m_SByteValues = new sbyte[] { 0, -1, SByte.MaxValue, SByte.MinValue };

        /// <summary>
        /// This method returns a signed byte array.
        /// </summary>
        public sbyte[] GetSByteArray()
        {
            int length = GetInt32Range(-1, m_context.MaxArrayLength);

            if (length < 0)
            {
                return null;
            }

            sbyte[] value = new sbyte[length];

            for (int ii = 0; ii < value.Length; ii++)
            {
                value[ii] = GetSByte();
            }

            return value;
        }
        #endregion

        #region Int16
        /// <summary>
        /// Returns a random 16-bit integer.
        /// </summary>
        public short GetRandomInt16()
        {
            return GetValueInt16(m_random);
        }

        /// <summary>
        /// Returns a 16-bit integer.
        /// </summary>
        public short GetInt16()
        {
            if (UseBoundaryValue())
            {
                return m_Int16Values[GetRandomIndex(m_Int16Values)];
            }

            return GetRandomInt16();
        }
                
        // Boundary values to use when generating an Int16.
        private static readonly short[] m_Int16Values = new short[] { 0, -1, Int16.MaxValue, Int16.MinValue };

        /// <summary>
        /// Returns a 16-bit integer array.
        /// </summary>
        public short[] GetInt16Array()
        {
            int length = GetInt32Range(-1, m_context.MaxArrayLength);

            if (length < 0)
            {
                return null;
            }

            short[] value = new short[length];

            for (int ii = 0; ii < value.Length; ii++)
            {
                value[ii] = GetInt16();
            }

            return value;
        }
        #endregion

        #region UInt16
        /// <summary>
        /// Returns a random 16-bit unsigned integer.
        /// </summary>
        public ushort GetRandomUInt16()
        {
            return GetValueUInt16(m_random);
        }

        /// <summary>
        /// Returns a 16-bit unsigned integer.
        /// </summary>
        public ushort GetUInt16()
        {
            if (UseBoundaryValue())
            {
                return m_UInt16Values[GetRandomIndex(m_UInt16Values)];
            }

            return GetRandomUInt16();
        }
        
        // Boundary values to use when generating a UInt16.       
        private static readonly ushort[] m_UInt16Values = new ushort[] { UInt16.MaxValue, UInt16.MinValue };

        /// <summary>
        /// Returns a 16-bit unsigned integer array.
        /// </summary>
        public ushort[] GetUInt16Array()
        {
            int length = GetInt32Range(-1, m_context.MaxArrayLength);

            if (length < 0)
            {
                return null;
            }

            ushort[] value = new ushort[length];

            for (int ii = 0; ii < value.Length; ii++)
            {
                value[ii] = GetUInt16();
            }

            return value;
        }
        #endregion

        #region Int32
        /// <summary>
        /// Returns a random 32-bit integer.
        /// </summary>
        public int GetRandomInt32()
        {
            return GetValueInt32(m_random);
        }

        /// <summary>
        /// Returns a 32-bit integer.
        /// </summary>
        public int GetInt32()
        {
            if (UseBoundaryValue())
            {
                return m_Int32Values[GetRandomIndex(m_Int32Values)];
            }

            return GetRandomInt32();
        }
       
        // Boundary values to use when generating a Int32.       
        private static readonly int[] m_Int32Values = new int[] { 0, -1, Int32.MaxValue, Int32.MinValue };

        /// <summary>
        /// Returns a 32-bit integer array.
        /// </summary>
        public int[] GetInt32Array()
        {
            int length = GetInt32Range(-1, m_context.MaxArrayLength);

            if (length < 0)
            {
                return null;
            }

            int[] value = new int[length];

            for (int ii = 0; ii < value.Length; ii++)
            {
                value[ii] = GetInt32();
            }

            return value;
        }
        #endregion

        #region UInt32
        /// <summary>
        /// Returns a random 32-bit unsigned integer.
        /// </summary>
        public uint GetRandomUInt32()
        {
            return GetValueUInt32(m_random);
        }

        /// <summary>
        /// Returns a 32-bit unsigned integer.
        /// </summary>
        public uint GetUInt32()
        {
            if (UseBoundaryValue())
            {
                return m_UInt32Values[GetRandomIndex(m_UInt32Values)];
            }

            return GetRandomUInt32();
        }

        // Boundary values to use when generating a UInt32.      
        private static readonly uint[] m_UInt32Values = new uint[] { UInt32.MaxValue, UInt32.MinValue };

        /// <summary>
        /// Returns a 32-bit unsigned integer array.
        /// </summary>
        public uint[] GetUInt32Array()
        {
            int length = GetInt32Range(-1, m_context.MaxArrayLength);

            if (length < 0)
            {
                return null;
            }

            uint[] value = new uint[length];

            for (int ii = 0; ii < value.Length; ii++)
            {
                value[ii] = GetUInt32();
            }

            return value;
        }
        #endregion

        #region Int64
        /// <summary>
        /// Returns a random 64-bit integer.
        /// </summary>
        public long GetRandomInt64()
        {
            return GetValueInt64(m_random);
        }

        /// <summary>
        /// Returns a 64-bit integer.
        /// </summary>
        public long GetInt64()
        {
            if (UseBoundaryValue())
            {
                return m_Int64Values[GetRandomIndex(m_Int64Values)];
            }

            return GetRandomInt64();
        }
        
        // Boundary values to use when generating a Int64.       
        private static readonly long[] m_Int64Values = new long[] { 0, -1, Int64.MaxValue, Int64.MinValue };

        /// <summary>
        /// Returns a 64-bit integer array.
        /// </summary>
        public long[] GetInt64Array()
        {
            int length = GetInt32Range(-1, m_context.MaxArrayLength);

            if (length < 0)
            {
                return null;
            }

            long[] value = new long[length];

            for (int ii = 0; ii < value.Length; ii++)
            {
                value[ii] = GetInt64();
            }

            return value;
        }
        #endregion

        #region UInt64
        /// <summary>
        /// Returns a random 64-bit unsigned integer.
        /// </summary>
        public ulong GetRandomUInt64()
        {
            return GetValueUInt64(m_random);
        }

        /// <summary>
        /// Returns a 64-bit integer.
        /// </summary>
        public ulong GetUInt64()
        {
            if (UseBoundaryValue())
            {
                return m_UInt64Values[GetRandomIndex(m_UInt64Values)];
            }

            return GetRandomUInt64();
        }

        // Boundary values to use when generating a UInt64.
        private static readonly ulong[] m_UInt64Values = new ulong[] { UInt64.MaxValue, UInt64.MinValue };

        /// <summary>
        /// Returns a 64-bit unsigned integer array.
        /// </summary>
        public ulong[] GetUInt64Array()
        {
            int length = GetInt32Range(-1, m_context.MaxArrayLength);

            if (length < 0)
            {
                return null;
            }

            ulong[] value = new ulong[length];

            for (int ii = 0; ii < value.Length; ii++)
            {
                value[ii] = GetUInt64();
            }

            return value;
        }
        #endregion

        #region Float
        /// <summary>
        /// Returns a random 32-bit floating point value.
        /// </summary>
        public float GetRandomFloat()
        {
            return GetValueFloat(m_random);
        }

        /// <summary>
        /// Returns a 32-bit floating point value.
        /// </summary>
        public float GetFloat()
        {
            if (UseBoundaryValue())
            {
                return m_FloatValues[GetRandomIndex(m_FloatValues)];
            }

            return GetRandomFloat();
        }
        
        // Boundary values to use when generating a Float.      
        private static readonly float[] m_FloatValues = new float[] { Single.Epsilon, Single.NaN, Single.MinValue, Single.MaxValue, 0, -1 };

        /// <summary>
        /// Returns a 32-bit floating point array.
        /// </summary>
        public float[] GetFloatArray()
        {
            int length = GetInt32Range(-1, m_context.MaxArrayLength);

            if (length < 0)
            {
                return null;
            }

            float[] value = new float[length];

            for (int ii = 0; ii < value.Length; ii++)
            {
                value[ii] = GetFloat();
            }

            return value;
        }
        #endregion

        #region Double
        /// <summary>
        /// Returns a random 64-bit floating point value.
        /// </summary>
        public double GetRandomDouble()
        {
            return GetValueDouble(m_random);
        }

        /// <summary>
        /// Returns a 64-bit floating point value.
        /// </summary>
        public double GetDouble()
        {
            if (UseBoundaryValue())
            {
                return m_DoubleValues[GetRandomIndex(m_DoubleValues)];
            }

            return GetRandomDouble();
        }
        
        // Boundary values to use when generating a Double. 
        private static readonly double[] m_DoubleValues = new double[] { Double.Epsilon, Double.NaN, Double.MinValue, Double.MaxValue, 0, -1 };

        /// <summary>
        /// Returns a 32-bit floating point array.
        /// </summary>
        public double[] GetDoubleArray()
        {
            int length = GetInt32Range(-1, m_context.MaxArrayLength);

            if (length < 0)
            {
                return null;
            }

            double[] value = new double[length];

            for (int ii = 0; ii < value.Length; ii++)
            {
                value[ii] = GetDouble();
            }

            return value;
        }
        #endregion

        #region DateTime
        /// <summary>
        /// Returns a random date time value.
        /// </summary>
        public DateTime GetRandomDateTime()
        {
            long ticks = GetValueDateTime(m_random) + Utils.TimeBase.Ticks;
            return new DateTime(ticks, DateTimeKind.Utc);
        }

        /// <summary>
        /// Returns a date time value.
        /// </summary>
        public DateTime GetDateTime()
        {
            if (UseBoundaryValue())
            {
                return m_DateTimeValues[GetRandomIndex(m_DateTimeValues)];
            }

            return GetRandomDateTime();
        }
      
        // Boundary values to use when generating a DateTime.      
        private static readonly DateTime[] m_DateTimeValues = new DateTime[] 
        { 
            DateTime.MinValue, 
            DateTime.MaxValue, 
            new DateTime(1997, 2, 18, 21, 0, 0, DateTimeKind.Local),
            new DateTime(2001, 9, 1, 9, 0, 0, DateTimeKind.Unspecified),
        };

        /// <summary>
        /// Returns a date time array.
        /// </summary>
        public DateTime[] GetDateTimeArray()
        {
            int length = GetInt32Range(-1, m_context.MaxArrayLength);

            if (length < 0)
            {
                return null;
            }

            DateTime[] value = new DateTime[length];

            for (int ii = 0; ii < value.Length; ii++)
            {
                value[ii] = GetDateTime();
            }

            return value;
        }
        #endregion

        #region Guid
        /// <summary>
        /// Returns a random guid value.
        /// </summary>
        public Guid GetRandomGuid()
        {
            byte[] bytes = Next(16);
            return new Guid(bytes);
        }

        /// <summary>
        /// Returns a guid value.
        /// </summary>
        public Guid GetGuid()
        {
            return GetRandomGuid();
        }

        /// <summary>
        /// Returns a guid array.
        /// </summary>
        public Guid[] GetGuidArray()
        {
            int length = GetInt32Range(-1, m_context.MaxArrayLength);

            if (length < 0)
            {
                return null;
            }

            Guid[] value = new Guid[length];

            for (int ii = 0; ii < value.Length; ii++)
            {
                value[ii] = GetGuid();
            }

            return value;
        }

        /// <summary>
        /// Returns a guid array.
        /// </summary>
        public Uuid[] GetUuidArray()
        {
            int length = GetInt32Range(-1, m_context.MaxArrayLength);

            if (length < 0)
            {
                return null;
            }

            Uuid[] value = new Uuid[length];

            for (int ii = 0; ii < value.Length; ii++)
            {
                value[ii] = (Uuid)GetGuid();
            }

            return value;
        }
        #endregion

        #region Boolean
        /// <summary>
        /// Returns a random boolean.
        /// </summary>
        public bool GetRandomBoolean()
        {
            return GetRandomSByte() >= 0;
        }

        /// <summary>
        /// Returns a boolean.
        /// </summary>
        public bool GetBoolean()
        {
            return GetRandomSByte() >= 0;
        }

        /// <summary>
        /// Returns a boolean array.
        /// </summary>
        public bool[] GetBooleanArray()
        {
            int length = GetInt32Range(-1, m_context.MaxArrayLength);

            if (length < 0)
            {
                return null;
            }

            bool[] value = new bool[length];

            for (int ii = 0; ii < value.Length; ii++)
            {
                value[ii] = GetBoolean();
            }

            return value;
        }
        #endregion

        #region String
        /// <summary>
        /// Returns a random string value.
        /// </summary>
        public string GetRandomString()
        {
            GetValueString(m_random, m_stringBuffer, m_context.MaxStringLength+1);
            return Marshal.PtrToStringUni(m_stringBuffer);
        }

        /// <summary>
        /// Returns a string value.
        /// </summary>
        public string GetString()
        {
            if (UseBoundaryValue())
            {
                return m_StringValues[GetRandomIndex(m_StringValues)];
            }

            return GetRandomString();
        }
      
        // Boundary values to use when generating a String.     
        private static readonly string[] m_StringValues = new string[] { null, String.Empty };

        /// <summary>
        /// Returns a string array.
        /// </summary>
        public string[] GetStringArray()
        {
            int length = GetInt32Range(-1, m_context.MaxArrayLength);

            if (length < 0)
            {
                return null;
            }

            string[] value = new string[length];

            for (int ii = 0; ii < value.Length; ii++)
            {
                value[ii] = GetString();
            }

            return value;
        }
        #endregion

        #region ByteString
        /// <summary>
        /// Returns a random byte string value.
        /// </summary>
        public byte[] GetRandomByteString()
        {
            int length = GetInt32Range(1, m_context.MaxStringLength);
            return Next(length);
        }

        /// <summary>
        /// Returns a random byte string value.
        /// </summary>
        public byte[] GetRandomByteString(int length)
        {
            byte[] buffer = new byte[length];

            for (int ii = 0; ii < buffer.Length; ii++)
            {
                Array.Copy(Next(1), 0, buffer, ii, 1);
            }

            return buffer;
        }

        /// <summary>
        /// Returns a byte string value.
        /// </summary>
        public byte[] GetByteString()
        {
            if (UseBoundaryValue())
            {
                return m_ByteStringValues[GetRandomIndex(m_ByteStringValues)];
            }

            return GetRandomByteString();
        }

        // Boundary values to use when generating a ByteString.
        private static readonly byte[][] m_ByteStringValues = new byte[][] { null, new byte[0] };

        /// <summary>
        /// Returns a string array.
        /// </summary>
        public byte[][] GetByteStringArray()
        {
            int length = GetInt32Range(-1, m_context.MaxArrayLength);

            if (length < 0)
            {
                return null;
            }

            byte[][] value = new byte[length][];

            for (int ii = 0; ii < value.Length; ii++)
            {
                value[ii] = GetByteString();
            }

            return value;
        }
        #endregion

        #region NodeId
        /// <summary>
        /// Returns a random node id value.
        /// </summary>
        public NodeId GetRandomNodeId()
        {
            IdType idType = (IdType)GetEnum(typeof(IdType));

            switch (idType)
            {
                default:
                case IdType.Numeric:
                    {
                        return new NodeId(GetUInt32(), GetUInt16());
                    }

                case IdType.String:
                    {
                        return new NodeId(GetString(), GetUInt16());
                    }

                case IdType.Guid:
                    {
                        return new NodeId(GetGuid(), GetUInt16());
                    }

                case IdType.Opaque:
                    {
                        return new NodeId(GetByteString(), GetUInt16());
                    }
            }
        }

        /// <summary>
        /// Returns a node id value.
        /// </summary>
        public NodeId GetNodeId()
        {
            if (UseBoundaryValue())
            {
                return m_NodeIdValues[GetRandomIndex(m_NodeIdValues)];
            }

            return GetRandomNodeId();
        }

        // Boundary values to use when generating a NodeId.
        private static readonly NodeId[] m_NodeIdValues = new NodeId[] 
        { 
            null, 
            NodeId.Null,
            new NodeId(String.Empty, 0),
            new NodeId(Guid.Empty),
            new NodeId(new byte[0])
        };

        /// <summary>
        /// Returns a node id array.
        /// </summary>
        public NodeId[] GetNodeIdArray()
        {
            int length = GetInt32Range(-1, m_context.MaxArrayLength);

            if (length < 0)
            {
                return null;
            }

            NodeId[] value = new NodeId[length];

            for (int ii = 0; ii < value.Length; ii++)
            {
                value[ii] = GetNodeId();
            }

            return value;
        }
        #endregion

        #region ExpandedNodeId
        /// <summary>
        /// Returns a random expanded node id value.
        /// </summary>
        public ExpandedNodeId GetRandomExpandedNodeId()
        {
            NodeId nodeId = GetRandomNodeId();

            if (GetRandomSByte() < 0)
            {
                return new ExpandedNodeId(nodeId);
            }

            string uri = GetRandomString();
            uint serverIndex = GetRandomUInt32();

            return new ExpandedNodeId(nodeId, uri, serverIndex);
        }

        /// <summary>
        /// Returns a expanded node id value.
        /// </summary>
        public ExpandedNodeId GetExpandedNodeId()
        {
            if (UseBoundaryValue())
            {
                return m_ExpandedNodeIdValues[GetRandomIndex(m_ExpandedNodeIdValues)];
            }

            return GetRandomExpandedNodeId();
        }

        // Boundary values to use when generating an ExpandedNodeId.
        private static readonly ExpandedNodeId[] m_ExpandedNodeIdValues = new ExpandedNodeId[] 
        { 
            null, 
            ExpandedNodeId.Null,
            new ExpandedNodeId(String.Empty, 0),
            new ExpandedNodeId(Guid.Empty),
            new ExpandedNodeId(new byte[0])
        };

        /// <summary>
        /// Returns a expanded node id array.
        /// </summary>
        public ExpandedNodeId[] GetExpandedNodeIdArray()
        {
            int length = GetInt32Range(-1, m_context.MaxArrayLength);

            if (length < 0)
            {
                return null;
            }

            ExpandedNodeId[] value = new ExpandedNodeId[length];

            for (int ii = 0; ii < value.Length; ii++)
            {
                value[ii] = GetExpandedNodeId();
            }

            return value;
        }
        #endregion

        #region QualifiedName
        /// <summary>
        /// Returns a random qualified name value.
        /// </summary>
        public QualifiedName GetRandomQualifiedName()
        {
            string name = GetRandomString();

            if (GetRandomSByte() < 0)
            {
                return new QualifiedName(name);
            }

            return new QualifiedName(name, GetUInt16());
        }

        /// <summary>
        /// Returns a expanded node id value.
        /// </summary>
        public QualifiedName GetQualifiedName()
        {
            if (UseBoundaryValue())
            {
                return m_QualifiedNameValues[GetRandomIndex(m_QualifiedNameValues)];
            }

            return GetRandomQualifiedName();
        }

        // Boundary values to use when generating a QualifiedName.
        private static readonly QualifiedName[] m_QualifiedNameValues = new QualifiedName[] 
        { 
            null, 
            QualifiedName.Null
        };

        /// <summary>
        /// Returns a expanded node id array.
        /// </summary>
        public QualifiedName[] GetQualifiedNameArray()
        {
            int length = GetInt32Range(-1, m_context.MaxArrayLength);

            if (length < 0)
            {
                return null;
            }

            QualifiedName[] value = new QualifiedName[length];

            for (int ii = 0; ii < value.Length; ii++)
            {
                value[ii] = GetQualifiedName();
            }

            return value;
        }
        #endregion

        #region LocalizedText
        /// <summary>
        /// Returns a random qualified name value.
        /// </summary>
        public LocalizedText GetRandomLocalizedText()
        {
            string text = GetRandomString();

            if (GetRandomSByte() < 0)
            {
                return new LocalizedText(text);
            }

            return new LocalizedText(text, GetRandomString());
        }

        /// <summary>
        /// Returns a expanded node id value.
        /// </summary>
        public LocalizedText GetLocalizedText()
        {
            if (UseBoundaryValue())
            {
                return m_LocalizedTextValues[GetRandomIndex(m_LocalizedTextValues)];
            }

            return GetRandomLocalizedText();
        }

        // Boundary values to use when generating a LocalizedText.
        private static readonly LocalizedText[] m_LocalizedTextValues = new LocalizedText[] 
        { 
            null, 
            LocalizedText.Null
        };

        /// <summary>
        /// Returns a expanded node id array.
        /// </summary>
        public LocalizedText[] GetLocalizedTextArray()
        {
            int length = GetInt32Range(-1, m_context.MaxArrayLength);

            if (length < 0)
            {
                return null;
            }

            LocalizedText[] value = new LocalizedText[length];

            for (int ii = 0; ii < value.Length; ii++)
            {
                value[ii] = GetLocalizedText();
            }

            return value;
        }
        #endregion

        #region StatusCodes
        /// <summary>
        /// Returns a random StatusCode value.
        /// </summary>
        public StatusCode GetRandomStatusCode()
        {
            // create a random code without the severity.
            uint code = GetRandomUInt32() & 0x7FFFFFFF;

            // select the severity.
            byte type = GetRandomByte();

            // return uncertain code.
            if (type < 85)
            {
                return new StatusCode(code | 0x40000000);
            }

            // return bad code.
            if (type < 170)
            {
                return new StatusCode(code | 0xC0000000);
            }

            // return good code.
            return new StatusCode(code);
        }

        /// <summary>
        /// Returns a StatusCode.
        /// </summary>
        public StatusCode GetStatusCode()
        {
            if (UseBoundaryValue())
            {
                return m_StatusCodeValues[GetRandomIndex(m_StatusCodeValues)];
            }

            return GetRandomStatusCode();
        }

        // Boundary values to use when generating a StatusCode.
        private static StatusCode[] m_StatusCodeValues = new StatusCode[] 
        { 
            StatusCodes.Good
        };

        /// <summary>
        /// Returns a StatusCode array.
        /// </summary>
        public StatusCode[] GetStatusCodeArray()
        {
            int length = GetInt32Range(-1, m_context.MaxArrayLength);

            if (length < 0)
            {
                return null;
            }

            StatusCode[] values = new StatusCode[length];

            for (int ii = 0; ii < values.Length; ii++)
            {
                values[ii] = GetStatusCode();
            }

            return values;
        }
        #endregion

        #region DiagnosticInfo
        /// <summary>
        /// Returns a random DiagnosticInfo value.
        /// </summary>
        public DiagnosticInfo GetDiagnosticInfo()
        {
            byte mask = GetRandomByte();

            if (mask == 0)
            {
                return null;
            }

            DiagnosticInfo diagnosticInfo = new DiagnosticInfo();

            diagnosticInfo.SymbolicId = ((mask & 0x01) != 0) ? GetUInt16() : -1;
            diagnosticInfo.NamespaceUri = ((mask & 0x02) != 0) ? GetUInt16() : -1;
            diagnosticInfo.LocalizedText = ((mask & 0x04) != 0) ? GetUInt16() : -1;
            diagnosticInfo.InnerStatusCode = ((mask & 0x08) != 0) ? GetStatusCode() : StatusCodes.Good;
            diagnosticInfo.Locale = ((mask & 0x10) != 0) ? GetUInt16() : -1;

            if ((mask & 0x10) != 0)
            {
                if (m_currentDepth < m_context.MaxDepth)
                {
                    m_currentDepth++;
                    diagnosticInfo.InnerDiagnosticInfo = GetDiagnosticInfo();
                    m_currentDepth--;
                }
            }

            return diagnosticInfo;
        }

        /// <summary>
        /// Returns a DiagnosticInfo array.
        /// </summary>
        public DiagnosticInfo[] GetDiagnosticInfoArray()
        {
            int length = GetInt32Range(-1, m_context.MaxArrayLength);

            if (length < 0)
            {
                return null;
            }

            DiagnosticInfo[] values = new DiagnosticInfo[length];

            for (int ii = 0; ii < values.Length; ii++)
            {
                values[ii] = GetDiagnosticInfo();
            }

            return values;
        }
        #endregion

        #region XmlElement
        /// <summary>
        /// Returns XmlElement.
        /// </summary>
        public XmlElement GetRandomXmlElement()
        {
            if (m_XmlElements == null)
            {
                XmlTextReader reader = new XmlTextReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("Opc.Ua.StackTest.SampleXmlData.xml"));
                XmlDocument document = new XmlDocument();
                document.Load(reader);
                reader.Close();

                XmlElementCollection elements = new XmlElementCollection();
                CollectElements(document, elements);
                m_XmlElements = elements.ToArray();
            }

            int index = GetInt32Range(-1, m_XmlElements.Length - 1);

            if (index < 0)
            {
                return null;
            }

            return m_XmlElements[index];
        }
        
        // Array of type XML Element.     
        private static XmlElement[] m_XmlElements = null;

        /// <summary>
        /// Returns a expanded node id value.
        /// </summary>
        public XmlElement GetXmlElement()
        {
            return GetRandomXmlElement();
        }

        /// <summary>
        /// Collect all the elements from XMLNode.
        /// </summary>
        private static void CollectElements(XmlNode parent, XmlElementCollection elements)
        {
            for (XmlNode node = parent.FirstChild; node != null; node = node.NextSibling)
            {
                XmlElement element = node as XmlElement;

                if (element != null)
                {
                    elements.Add(element);
                    CollectElements(element, elements);
                }
            }
        }

        /// <summary>
        /// Returns a XmlElement array.
        /// </summary>
        public XmlElement[] GetXmlElementArray()
        {
            int length = GetInt32Range(-1, m_context.MaxArrayLength);

            if (length < 0)
            {
                return null;
            }

            XmlElement[] values = new XmlElement[length];

            for (int ii = 0; ii < values.Length; ii++)
            {
                values[ii] = GetXmlElement();
            }

            return values;
        }
        #endregion

        #region DataValue Functions
        /// <summary>
        /// Returns a DataValue. 
        /// </summary>
        public DataValue GetDataValue()
        {
            DataValue value = new DataValue();

            value.Value             = GetVariant().Value;
            value.StatusCode        = GetStatusCode();
            value.SourceTimestamp   = GetDateTime();
            value.SourcePicoseconds = GetUInt16();
            value.ServerTimestamp   = GetDateTime();
            value.ServerPicoseconds = GetUInt16();

            return value;
        }

        /// <summary>
        /// Returns a DataValue array. 
        /// </summary>
        public DataValue[] GetDataValueArray()
        {
            int length = GetInt32Range(-1, m_context.MaxArrayLength);

            if (length < 0)
            {
                return null;
            }

            DataValue[] values = new DataValue[length];

            for (int ii = 0; ii < values.Length; ii++)
            {
                values[ii] = GetDataValue();
            }

            return values;
        }
        #endregion

        #region ExtensionObject Functions
        /// <summary>
        /// Returns a ExtensionObject. 
        /// </summary>
        public ExtensionObject GetExtensionObject()
        {
            try
            {
                m_currentDepth++;

                Type type = m_ExtensionObjectTypes[GetRandomIndex(m_ExtensionObjectTypes)];

                if (type == typeof(byte[]))
                {
                    return new ExtensionObject(GetRandomNodeId(), GetByteString());
                }

                if (type == typeof(XmlElement))
                {
                    return new ExtensionObject(GetRandomNodeId(), GetXmlElement());
                }

                if (type == typeof(Driver))
                {
                    return new ExtensionObject(GetDriver());
                }

                if (type == typeof(AcmeWidget))
                {
                    return new ExtensionObject(GetAcmeWidget());
                }

                if (type == typeof(CoyoteGadget))
                {
                    return new ExtensionObject(GetCoyoteGadget());
                }

                if (type == typeof(SkyNetRobot))
                {
                    return new ExtensionObject(GetSkyNetRobot());
                }

                if (type == typeof(S88Batch))
                {
                    return new ExtensionObject(GetS88Batch());
                }

                if (type == typeof(S88UnitProcedure))
                {
                    return new ExtensionObject(GetS88UnitProcedure());
                }

                if (type == typeof(S88Operation))
                {
                    return new ExtensionObject(GetS88Operation());
                }

                if (type == typeof(S88Phase))
                {
                    return new ExtensionObject(GetS88Phase());
                }

                return null;
            }
            finally
            {
                m_currentDepth--;
            }
        }
      
        // Boundary values to use when generating an ExtensionObject.       
        private static readonly Type[] m_ExtensionObjectTypes = new Type[]
        {
            typeof(byte[]),
            typeof(XmlElement),
            typeof(Driver),
            typeof(AcmeWidget),
            typeof(CoyoteGadget),
            typeof(SkyNetRobot),
            typeof(S88Batch),
            typeof(S88UnitProcedure),
            typeof(S88Operation),
            typeof(S88Phase)
        };

        /// <summary>
        /// Returns a ExtensionObject array. 
        /// </summary>
        public ExtensionObject[] GetExtensionObjectArray()
        {
            int length = GetInt32Range(-1, m_context.MaxArrayLength);

            if (length < 0)
            {
                return null;
            }

            ExtensionObject[] values = new ExtensionObject[length];

            for (int ii = 0; ii < values.Length; ii++)
            {
                values[ii] = GetExtensionObject();
            }

            return values;
        }
        #endregion

        #region Variant
        /// <summary>
        /// Returns a Variant. 
        /// </summary>
        public Variant GetVariant()
        {
            try
            {
                m_currentDepth++;

                if (GetBoolean())
                {
                    return GetScalarVariant(m_currentDepth < m_context.MaxDepth);
                }
                else
                {
                    return GetArrayVariant(m_currentDepth < m_context.MaxDepth);
                }
            }
            finally
            {
                m_currentDepth--;
            }
        }

        /// <summary>
        /// Returns a variant containing a scalar value.
        /// </summary>
        public Variant GetScalarVariant(bool allowNesting)
        {
            BuiltInType last = BuiltInType.LocalizedText;

            if (allowNesting)
            {
                last = BuiltInType.DataValue;
            }

            BuiltInType type = (BuiltInType)GetInt32Range((int)BuiltInType.Null, (int)last);

            switch (type)
            {
                case BuiltInType.Boolean: { return GetBoolean(); }
                case BuiltInType.SByte: { return GetSByte(); }
                case BuiltInType.Byte: { return GetByte(); }
                case BuiltInType.Int16: { return GetInt16(); }
                case BuiltInType.UInt16: { return GetUInt16(); }
                case BuiltInType.Int32: { return GetInt32(); }
                case BuiltInType.UInt32: { return GetUInt32(); }
                case BuiltInType.Int64: { return GetInt64(); }
                case BuiltInType.UInt64: { return GetUInt64(); }
                case BuiltInType.Float: { return GetFloat(); }
                case BuiltInType.Double: { return GetDouble(); }
                case BuiltInType.String: { return GetString(); }
                case BuiltInType.DateTime: { return GetDateTime(); }
                case BuiltInType.Guid: { return GetGuid(); }
                case BuiltInType.ByteString: { return GetByteString(); }
                case BuiltInType.XmlElement: { return GetXmlElement(); }
                case BuiltInType.NodeId: { return GetNodeId(); }
                case BuiltInType.ExpandedNodeId: { return GetExpandedNodeId(); }
                case BuiltInType.StatusCode: { return GetStatusCode(); }
                case BuiltInType.QualifiedName: { return GetQualifiedName(); }
                case BuiltInType.LocalizedText: { return GetLocalizedText(); }
                case BuiltInType.ExtensionObject: { return GetExtensionObject(); }
                case BuiltInType.DataValue: { return GetDataValue(); }
            }

            return Variant.Null;
        }

        /// <summary>
        /// Returns a variant containing a array value.
        /// </summary>
        public Variant GetArrayVariant(bool allowNesting)
        {
            BuiltInType last = BuiltInType.LocalizedText;

            if (allowNesting)
            {
                last = BuiltInType.Variant;
            }

            BuiltInType type = (BuiltInType)GetInt32Range((int)BuiltInType.Null, (int)last);

            Array array = null;

            switch (type)
            {
                case BuiltInType.Boolean: { array = GetBooleanArray(); break; }
                case BuiltInType.Byte: { array = GetByteArray(); break; }
                case BuiltInType.SByte: { array = GetSByteArray(); break; }
                case BuiltInType.Int16: { array = GetInt16Array(); break; }
                case BuiltInType.UInt16: { array = GetUInt16Array(); break; }
                case BuiltInType.Int32: { array = GetInt32Array(); break; }
                case BuiltInType.UInt32: { array = GetUInt32Array(); break; }
                case BuiltInType.Int64: { array = GetInt64Array(); break; }
                case BuiltInType.UInt64: { array = GetUInt64Array(); break; }
                case BuiltInType.Float: { array = GetFloatArray(); break; }
                case BuiltInType.Double: { array = GetDoubleArray(); break; }
                case BuiltInType.String: { array = GetStringArray(); break; }
                case BuiltInType.DateTime: { array = GetDateTimeArray(); break; }
                case BuiltInType.Guid: { array = GetUuidArray(); break; }
                case BuiltInType.ByteString: { array = GetByteStringArray(); break; }
                case BuiltInType.XmlElement: { array = GetXmlElementArray(); break; }
                case BuiltInType.NodeId: { array = GetNodeIdArray(); break; }
                case BuiltInType.ExpandedNodeId: { array = GetExpandedNodeIdArray(); break; }
                case BuiltInType.StatusCode: { array = GetStatusCodeArray(); break; }
                case BuiltInType.QualifiedName: { array = GetQualifiedNameArray(); break; }
                case BuiltInType.LocalizedText: { array = GetLocalizedTextArray(); break; }
                case BuiltInType.ExtensionObject: { array = GetExtensionObjectArray(); break; }
                case BuiltInType.DataValue: { array = GetDataValueArray(); break; }
                case BuiltInType.Variant: { array = GetVariantArray(); break; }
            }           

            if (array == null)
            {
                return Variant.Null;
            }

            if (array.Length == 0)
            {
                return new Variant(array);
            }

            if (GetRandomByte() > 128)
            {
                int[] dimensions = new int[GetRandomByte()%3+2];

                int length = array.Length;

                for (int jj = 0; jj < dimensions.Length-1; jj++)
                {                
                    if (length > 3)
                    {
                        bool prime = true;

                        for (int ii = 2; ii <= length/2; ii++)
                        {
                            if (length % ii == 0)
                            {
                                dimensions[jj] = ii;                            
                                length = length/ii;
                                prime = false; 
                                break;
                            }
                        }

                        if (prime)
                        {
                            dimensions[jj] = length; 
                            length = 1;
                        }
                    }
                    else if (length > 1)
                    {
                        dimensions[jj] = length;
                        length = 1;
                    }
                    else
                    {
                        dimensions[jj] = 1;
                    }
                }
                
                dimensions[dimensions.Length-1] = length;
                       
                return new Variant(new Matrix(array, type, dimensions));
            }

            return new Variant(array);
        }

        /// <summary>
        /// Returns a Variant array. 
        /// </summary>
        public Variant[] GetVariantArray()
        {
            int length = GetInt32Range(-1, m_context.MaxArrayLength);

            if (length < 0)
            {
                return null;
            }

            Variant[] values = new Variant[length];

            for (int ii = 0; ii < values.Length; ii++)
            {
                values[ii] = GetVariant();
            }

            return values;
        }
        #endregion

        #region Structure Values
        #region ScalarTestType
        /// <summary>
        /// This method returns ScalarTestType.
        /// </summary>
        public ScalarTestType GetScalarTestType()
        {
            ScalarTestType value = new ScalarTestType();

            value.Boolean = GetBoolean();
            value.SByte = GetSByte();
            value.Byte = GetByte();
            value.Int16 = GetInt16();
            value.UInt16 = GetUInt16();
            value.Int32 = GetInt32();
            value.UInt32 = GetUInt32();
            value.Int64 = GetInt64();
            value.UInt64 = GetUInt64();
            value.Float = GetFloat();
            value.Double = GetDouble();
            value.String = GetString();
            value.DateTime = GetDateTime();
            value.Guid = (Uuid)GetGuid();
            value.ByteString = GetByteString();
            value.XmlElement = GetXmlElement();
            value.NodeId = GetNodeId();
            value.ExpandedNodeId = GetExpandedNodeId();
            value.StatusCode = GetStatusCode();
            value.DiagnosticInfo = GetDiagnosticInfo();
            value.QualifiedName = GetQualifiedName();
            value.LocalizedText = GetLocalizedText();
            value.ExtensionObject = GetExtensionObject();
            value.DataValue = GetDataValue();
            value.EnumeratedValue = (EnumeratedTestType)GetEnum(typeof(EnumeratedTestType));

            return value;
        }
        #endregion
        
        #region ArrayTestType
        /// <summary>
        /// This method returns ArrayTestType.
        /// </summary>
        public ArrayTestType GetArrayTestType()
        {
            ArrayTestType value = new ArrayTestType();

            value.Booleans = GetBooleanArray();
            value.SBytes = GetSByteArray();
            value.Int16s = GetInt16Array();
            value.UInt16s = GetUInt16Array();
            value.Int32s = GetInt32Array();
            value.UInt32s = GetUInt32Array();
            value.Int64s = GetInt64Array();
            value.UInt64s = GetUInt64Array();
            value.Floats = GetFloatArray();
            value.Doubles = GetDoubleArray();
            value.Strings = GetStringArray();
            value.DateTimes = GetDateTimeArray();
            
            value.Guids = new UuidCollection();

            Guid[] guids = GetGuidArray();

            if (guids != null)
            {
                foreach (Guid guid in guids)
                {
                    value.Guids.Add((Uuid)guid);
                }
            }

            value.ByteStrings = GetByteStringArray();
            value.XmlElements = GetXmlElementArray();
            value.NodeIds = GetNodeIdArray();
            value.ExpandedNodeIds = GetExpandedNodeIdArray();
            value.StatusCodes = GetStatusCodeArray();
            value.DiagnosticInfos = GetDiagnosticInfoArray();
            value.QualifiedNames = GetQualifiedNameArray();
            value.LocalizedTexts = GetLocalizedTextArray();
            value.ExtensionObjects = GetExtensionObjectArray();                  
            value.DataValues = GetDataValueArray();
            value.Variants = GetVariantArray();

            value.EnumeratedValues = new EnumeratedTestTypeCollection();

            object[] enums = GetEnumArray(typeof(EnumeratedTestType));

            if (enums != null)
            {
                foreach (object current in enums)
                {
                    value.EnumeratedValues.Add((EnumeratedTestType)current);
                }
            }

            return value;
        }

        #region CompositeTestType
        /// <summary>
        /// This method returns CompositeTestType.
        /// </summary>
        public CompositeTestType GetCompositeTestType()
        {
            CompositeTestType value = new CompositeTestType();
            
            value.Field1 = GetScalarTestType();
            value.Field2 = GetArrayTestType();

            return value;
        }
        #endregion        
        #endregion

        #region Driver
        /// <summary>
        /// This method returns Driver.
        /// </summary>
        public Driver GetDriver()
        {
            Driver value = new Driver();

            value.Name = GetLocalizedText();

            if (GetRandomBoolean())
            {
                value.Vehicle = new ExtensionObject(GetCar());
            }
            else
            {
                value.Vehicle = new ExtensionObject(GetTruck());
            }

            value.LicenseNumber = new Uuid(GetGuid());

            return value;
        }

        /// <summary>
        /// This method returns Car.
        /// </summary>
        public Car GetCar()
        {
            Car value = new Car();

            value.Make = GetString();
            value.Model = GetString();
            value.Year = GetUInt16();
            value.Wheels = GetWheels();
            value.IsHatchback = GetBoolean();

            return value;
        }

        /// <summary>
        /// This method returns Truck.
        /// </summary>
        public Truck GetTruck()
        {
            Truck value = new Truck();

            value.Make = GetString();
            value.Model = GetString();
            value.Year = GetUInt16();
            value.Wheels = GetWheels();
            value.Capacity = GetUInt32();

            return value;
        }

        /// <summary>
        /// This method returns WheelCollection.
        /// </summary>
        public WheelCollection GetWheels()
        {
            WheelCollection value = new WheelCollection();

            int length = GetInt32Range(-1, m_context.MaxArrayLength);

            if (length < 0)
            {
                return value;
            }

            for (int ii = 0; ii < length; ii++)
            {
                Wheel wheel = new Wheel();
                wheel.Installed = GetDateTime();
                wheel.Manufacturer = GetString();
                value.Add(wheel);
            }

            return value;
        }
        #endregion

        #region AcmeWidget
        /// <summary>
        /// This method returns AcmeWidget.
        /// </summary>
        public AcmeWidget GetAcmeWidget()
        {
            AcmeWidget widget = new AcmeWidget();

            widget.Color = GetString();
            widget.Quantity = GetInt32();
            widget.BuildDate = GetDateTime();

            return widget;
        }
        #endregion

        #region CoyoteGadget
        /// <summary>
        /// This method returns CoyoteGadget.
        /// </summary>
        public AcmeWidget GetCoyoteGadget()
        {
            CoyoteGadget widget = new CoyoteGadget();

            widget.Color = GetString();
            widget.Quantity = GetInt32();
            widget.BuildDate = GetDateTime();
            widget.CookTime = GetUInt32();
            widget.Spices = GetStringArray();

            return widget;
        }
        #endregion

        #region SkyNetRobot
        /// <summary>
        /// This method returns SkyNetRobot.
        /// </summary>
        public SkyNetRobot GetSkyNetRobot()
        {
            SkyNetRobot robot = new SkyNetRobot();

            robot.Model = GetString();
            robot.TargetSensor = GetAcmeWidget();
            robot.BuildDate = GetDateTime();

            return robot;
        }
        #endregion

        #region S88Types
        /// <summary>
        /// This method returns S88Types.
        /// </summary>
        public S88Batch GetS88Batch()
        {
            S88Batch batch = new S88Batch();

            batch.BatchID = GetInt32();
            batch.RecipeID = GetUInt16();
            batch.StartTime = GetDateTime();
            batch.EndTime = GetDateTime();
            batch.UnitProcedures = GetS88UnitProcedureArray();

            return batch;
        }
        #endregion

        #region S88Procedures
        /// <summary>
        /// This method returns S88Procedures
        /// </summary>
        public S88UnitProcedure GetS88UnitProcedure()
        {
            S88UnitProcedure procedure = new S88UnitProcedure();

            procedure.UnitProcedureName = GetString();
            procedure.StartTime = GetDateTime();
            procedure.EndTime = GetDateTime();

            return procedure;
        }

        /// <summary>
        /// This method returns a S88Procedures array.
        /// </summary>
        public S88UnitProcedure[] GetS88UnitProcedureArray()
        {
            // Minimum count should be 1.
            int length = GetInt32Range(1, m_context.MaxArrayLength);

            if (length < 0)
            {
                return null;
            }

            S88UnitProcedure[] value = new S88UnitProcedure[length];

            for (int ii = 0; ii < value.Length; ii++)
            {
                value[ii] = GetS88UnitProcedure();
            }

            return value;
        }
        #endregion

        #region S88Types
        /// <summary>
        /// This method returns S88Types.
        /// </summary>
        public S88Operation GetS88Operation()
        {
            S88Operation operation = new S88Operation();

            operation.OperationName = GetString();
            operation.StartTime = GetDateTime();
            operation.EndTime = GetDateTime();
            operation.Phases = GetS88PhaseArray();

            return operation;
        }

        /// <summary>
        /// This method returns a S88Types array.
        /// </summary>
        public S88Operation[] GetS88OperationArray()
        {
            int length = GetInt32Range(-1, m_context.MaxArrayLength);

            if (length < 0)
            {
                return null;
            }

            S88Operation[] value = new S88Operation[length];

            for (int ii = 0; ii < value.Length; ii++)
            {
                value[ii] = GetS88Operation();
            }

            return value;
        }
        #endregion

        #region S88Procedures
        /// <summary>
        /// This method returns S88Procedures
        /// </summary>
        public S88Phase GetS88Phase()
        {
            S88Phase phase = new S88Phase();

            phase.PhaseName = GetString();
            phase.StartTime = GetDateTime();
            phase.EndTime = GetDateTime();

            return phase;
        }

        /// <summary>
        /// This method returns a S88Procedures array.
        /// </summary>
        public S88Phase[] GetS88PhaseArray()
        {
            int length = GetInt32Range(-1, m_context.MaxArrayLength);

            if (length < 0)
            {
                return null;
            }

            S88Phase[] value = new S88Phase[length];

            for (int ii = 0; ii < value.Length; ii++)
            {
                value[ii] = GetS88Phase();
            }

            return value;
        }
        #endregion
        #endregion
        
        /// <summary>
        /// Creates a file with random numbers.
        /// </summary>
        /// <param name="filepath">Path for generating the file.</param>
        /// <param name="length">Length in bytes.</param>
        public static void GenerateFile(string filepath, int length)
        {
            byte[] buffer = new byte[length];
            new RNGCryptoServiceProvider().GetBytes(buffer);
            File.WriteAllBytes(filepath, buffer);
        }

        /// <summary>
        /// This method returns a random index in an array.
        /// </summary>
        /// <param name="value">Array</param>
        /// <returns></returns>
        public int GetRandomIndex(Array value)
        {
            if (value == null) throw new ArgumentNullException("value");
            return GetInt32Range(0, value.Length - 1);
        }

        /// <summary>
        /// Check is a boundary value should be generated.
        /// </summary>
        public bool UseBoundaryValue()
        {
            return GetRandomByte() <= m_context.BoundaryValueRate;
        }

        /// <summary>
        /// This method returns a Int32 value that is greater than or equal to first and less than or equal to last.
        /// </summary>
        /// <param name="first">Minimum range value.</param>
        /// <param name="last">Maximum range value.</param>
        /// <returns>Int32 value.</returns>
        public int GetInt32Range(int first, int last)
        {
            if (last == first)
            {
                return first;
            }

            long sample = GetRandomUInt32();

            if (first < last)
            {
                long value = sample % (last - first + 1);
                return (int)(value + first);
            }
            else
            {
                long value = sample % (first - last + 1);
                return (int)(value + last);
            }
        }

        /// <summary>
        /// This method returns a Int64 value that is greater than or equal to first and less than or equal to last.
        /// </summary>
        /// <param name="first">Minimum range value.</param>
        /// <param name="last">Maximum range value.</param>
        /// <returns>Int64 value.</returns>
        public long GetInt64Range(long first, long last)
        {
            if (last == first)
            {
                return first;
            }

            if (first < last)
            {
                return (GetRandomInt64() % (last - first + 1)) + first;
            }
            else
            {
                return (GetRandomInt64() % (first - last + 1)) + last;
            }
        }

        /// <summary>
        /// This method returns a random enumerated value.
        /// </summary>
        /// <param name="enumType">Enum Type.</param>
        /// <returns>Random enumerated value</returns>
        public object GetEnum(Type enumType)
        {
            Array values = Enum.GetValues(enumType);

            int index = GetInt32Range(0, values.Length - 1);

            return values.GetValue(index);
        }        

        /// <summary>
        /// This method returns a S88Procedures array.
        /// </summary>
        public object[] GetEnumArray(Type enumType)
        {
            int length = GetInt32Range(-1, m_context.MaxArrayLength);

            if (length < 0)
            {
                return null;
            }

            object[] value = new object[length];

            for (int ii = 0; ii < value.Length; ii++)
            {
                value[ii] = GetEnum(enumType);
            }

            return value;
        }

        /// <summary>
        /// This method returns a 32-bit integer Timeout Value.
        /// </summary>
        public int GetTimeout()
        {
            return GetInt32Range(m_context.MinTimeout, m_context.MaxTimeout);
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// Creates a new random number generator.
        /// </summary>
        [DllImport("Opc.Ua.Random.dll")]
        private static extern int RandomCreate(
            ref IntPtr pRandom,
            [MarshalAs(UnmanagedType.LPStr)] string pPathToFile,
            int nSeed,
            int nStep);

        /// <summary>
        /// This method returns random bytes.
        /// </summary>
        [DllImport("Opc.Ua.Random.dll")]
        private static extern int RandomGetValue(IntPtr pRandom, IntPtr pData, int nCount);

        /// <summary>
        /// Destroys a random number generator.
        /// </summary>
        [DllImport("Opc.Ua.Random.dll")]
        private static extern int RandomDestroy(ref IntPtr pRandom);
        
        /// <summary>
        /// Returns a random 8-bit signed integer.
        /// </summary>
        [DllImport("Opc.Ua.Random.dll")]
        private static extern sbyte GetValueInt8(IntPtr pRandom);
        
        /// <summary>
        /// Returns a random 16-bit signed integer.
        /// </summary>
        [DllImport("Opc.Ua.Random.dll")]
        private static extern short GetValueInt16(IntPtr pRandom);
        
        /// <summary>
        /// Returns a random 32-bit signed integer.
        /// </summary>
        [DllImport("Opc.Ua.Random.dll")]
        private static extern int GetValueInt32(IntPtr pRandom);
        
        /// <summary>
        /// Returns a random 64-bit signed integer.
        /// </summary>
        [DllImport("Opc.Ua.Random.dll")]
        private static extern long GetValueInt64(IntPtr pRandom);
        
        /// <summary>
        /// Returns a random 8-bit unsigned integer.
        /// </summary>
        [DllImport("Opc.Ua.Random.dll")]
        private static extern byte GetValueUInt8(IntPtr pRandom);
        
        /// <summary>
        /// Returns a random 16-bit unsigned integer.
        /// </summary>
        [DllImport("Opc.Ua.Random.dll")]
        private static extern ushort GetValueUInt16(IntPtr pRandom);
        
        /// <summary>
        /// Returns a random 32-bit unsigned integer.
        /// </summary>
        [DllImport("Opc.Ua.Random.dll")]
        private static extern uint GetValueUInt32(IntPtr pRandom);
        
        /// <summary>
        /// Returns a random 64-bit unsigned integer.
        /// </summary>
        [DllImport("Opc.Ua.Random.dll")]
        private static extern ulong GetValueUInt64(IntPtr pRandom);
        
        /// <summary>
        /// Returns a random 32-bit floating point value.
        /// </summary>
        [DllImport("Opc.Ua.Random.dll")]
        private static extern float GetValueFloat(IntPtr pRandom);
        
        /// <summary>
        /// Returns a random 64-bit floating point value.
        /// </summary>
        [DllImport("Opc.Ua.Random.dll")]
        private static extern double GetValueDouble(IntPtr pRandom);
                
        /// <summary>
        /// Returns a random DateTime value as a number of ticks.
        /// </summary>
        [DllImport("Opc.Ua.Random.dll")]
        private static extern long GetValueDateTime(IntPtr pRandom);
        
        /// <summary>
        /// Fills in a buffer with a random number of random characters.
        /// </summary>
        [DllImport("Opc.Ua.Random.dll")]
        private static extern ushort GetValueString(IntPtr pData, IntPtr pString, int nSize);

        /// <summary>
        /// Creates a new random number generator.
        /// </summary>
        /// <param name="filepath">Path for generating the file.</param>
        /// <param name="seed">Seed number for random number generation.</param>
        /// <param name="step">Step size for getting the random number from the file.</param>
        /// <param name="context">The context to use when generating random data.</param>
        private void Create(string filepath, int seed, int step, TestCaseContext context)
        {
            if (m_random != IntPtr.Zero)
            {
                Destroy();
                m_random = IntPtr.Zero;
            }

            int result = RandomCreate(ref m_random, m_filepath, seed, step);

            if (result != 0)
            {
                throw new ServiceResultException(StatusCodes.BadConfigurationError, "Could not initialize random number generator.");
            }

            m_buffer = Marshal.AllocCoTaskMem(4096);
            m_stringBuffer = Marshal.AllocCoTaskMem((context.MaxStringLength+1)*2);
        }

        /// <summary>
        /// Destroys a random number generator.
        /// </summary>
        private void Destroy()
        {
            if (m_buffer != IntPtr.Zero)
            {
                Marshal.FreeCoTaskMem(m_buffer);
                m_buffer = IntPtr.Zero;
            }
            
            if (m_stringBuffer != IntPtr.Zero)
            {
                Marshal.FreeCoTaskMem(m_stringBuffer);
                m_stringBuffer = IntPtr.Zero;
            }

            if (m_random != IntPtr.Zero)
            {
                RandomDestroy(ref m_random);
                m_random = IntPtr.Zero;
            }
        }

        /// <summary>
        /// This method returns an array of random bytes.
        /// </summary>
        /// <param name="length">Size of the array.</param>
        /// <returns></returns>
        private byte[] Next(int length)
        {
            int result = RandomGetValue(m_random, m_buffer, length);

            if (result != 0)
            {
                throw new ServiceResultException(StatusCodes.BadConfigurationError, "Could not generate a random number.");
            }

            byte[] buffer = new byte[length];
            Marshal.Copy(m_buffer, buffer, 0, length);
            return buffer;
        }
        #endregion

        #region Private Fields
        // The seed passed to the random generator.       
        private int m_seed;

        // The path to the random data source file.      
        private string m_filepath;

        // The context to use        
        private TestCaseContext m_context;

        // The handle created by the random generator.       
        private IntPtr m_random;

        // A buffer used to store bytes returned by the random generator.
        private IntPtr m_buffer;

        // A buffer used to store strings returned by the random generator.
        private IntPtr m_stringBuffer;

        // The current level of structure nesting.        
        private int m_currentDepth;
        #endregion
    }
    #endregion
}
