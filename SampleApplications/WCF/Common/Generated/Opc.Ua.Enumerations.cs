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
using System.ServiceModel;
using System.Runtime.Serialization;

namespace Opc.Ua
{
    /// <summary>
    /// Flags that can be set for the EventNotifier attribute.
    /// </summary>
    /// <remarks>
    /// Flags that can be set for the EventNotifier attribute.
    /// </remarks>
    public static class EventNotifiers
    {
        /// <summary>
        /// The Object or View produces no event and has no event history.
        /// </summary>
        public const byte None = 0x0;

        /// <summary>
        /// The Object or View produces event notifications.
        /// </summary>
        public const byte SubscribeToEvents = 0x1;

        /// <summary>
        /// The Object has an event history which may be read.
        /// </summary>
        public const byte HistoryRead = 0x4;
        
        /// <summary>
        /// The Object has an event history which may be updated.
        /// </summary>
        public const byte HistoryWrite = 0x8;
    }

    /// <summary>
    /// Flags that can be set for the AccessLevel attribute.
    /// </summary>
    /// <remarks>
    /// Flags that can be set for the AccessLevel attribute.
    /// </remarks>
    public static class AccessLevels
    {
        /// <summary>
        /// The Variable value cannot be accessed and has no event history.
        /// </summary>
        public const byte None = 0x0;

        /// <summary>
        /// The current value of the Variable may be read.
        /// </summary>
        public const byte CurrentRead = 0x1;
        
        /// <summary>
        /// The current value of the Variable may be written.
        /// </summary>
        public const byte CurrentWrite = 0x2;
        
        /// <summary>
        /// The current value of the Variable may be read or written.
        /// </summary>
        public const byte CurrentReadOrWrite = 0x3;

        /// <summary>
        /// The history for the Variable may be read.
        /// </summary>
        public const byte HistoryRead = 0x4;
        
        /// <summary>
        /// The history for the Variable may be updated.
        /// </summary>
        public const byte HistoryWrite = 0x8;
        
        /// <summary>
        /// The history value of the Variable may be read or updated.
        /// </summary>
        public const byte HistoryReadOrWrite = 0xC;
        
        /// <summary>
        /// Indicates if the Variable generates SemanticChangeEvents when its value changes.
        /// </summary>
        public const byte SemanticChange = 0x10;
    }
        
    /// <summary>
    /// Constants defined for the ValueRank attribute.
    /// </summary>
    /// <remarks>
    /// Constants defined for the ValueRank attribute.
    /// </remarks>
    public static class ValueRanks
    {
        /// <summary>
        /// The variable may be a scalar or a one dimensional array.
        /// </summary>
        public const int ScalarOrOneDimension = -3;
        
        /// <summary>
        /// The variable may be a scalar or an array of any dimension.
        /// </summary>
        public const int Any = -2;
        
        /// <summary>
        /// The variable is always a scalar.
        /// </summary>
        public const int Scalar = -1;

        /// <summary>
        /// The variable is always an array with one or more dimensions.
        /// </summary>
        public const int OneOrMoreDimensions = 0;

        /// <summary>
        /// The variable is always one dimensional array.
        /// </summary>
        public const int OneDimension = 1;

        /// <summary>
        /// The variable is always an array with two or more dimensions.
        /// </summary>
        public const int TwoDimensions = 2;
        
        /// <summary>
        /// Checks if the actual value rank is compatible with the expected value rank.
        /// </summary>
        public static bool IsValid(int actualValueRank, int expectedValueRank)
        {
            if (actualValueRank == expectedValueRank)
            {
                return true;
            }
    
            switch (expectedValueRank)
            {
                case ValueRanks.Any:
                {
                    return true;
                }

                case ValueRanks.OneOrMoreDimensions:
                {
                    if (actualValueRank < 0)
                    {
                        return false;
                    }

                    break;
                }

                case ValueRanks.ScalarOrOneDimension:
                {
                    if (actualValueRank != ValueRanks.Scalar && actualValueRank != ValueRanks.OneDimension)
                    {
                        return false;
                    }

                    break;
                }

                default:
                {
                    return false;
                }
            }

            return true;
        }
        
        /// <summary>
        /// Checks if the actual array diminesions is compatible with the expected value rank and array dimensions.
        /// </summary>
        public static bool IsValid(IList<uint> actualArrayDimensions, int valueRank, IList<uint> expectedArrayDimensions)
        {
            // check if parameter omitted.
            if (actualArrayDimensions == null || actualArrayDimensions.Count == 0)
            {
                return expectedArrayDimensions == null || expectedArrayDimensions.Count == 0;
            }

            // no array dimensions allowed for scalars.
            if (valueRank == ValueRanks.Scalar)
            {
                return false;
            }

            // check if one dimension required.
            if (valueRank == ValueRanks.OneDimension || valueRank == ValueRanks.ScalarOrOneDimension)
            {
                if (actualArrayDimensions.Count != 1)
                {
                    return false;
                }
            }

            // check number of dimensions.
            if (valueRank != ValueRanks.OneOrMoreDimensions)
            {
                if (actualArrayDimensions.Count != valueRank)
                {
                    return false;
                }
            }

            // nothing more to do if expected dimensions omitted.
            if (expectedArrayDimensions == null || expectedArrayDimensions.Count == 0)
            {
                return true;
            }

            // check dimensions.
            if (expectedArrayDimensions.Count != actualArrayDimensions.Count)
            {
                return false;
            }

            // check length of each dimension.
            for (int ii = 0; ii < expectedArrayDimensions.Count; ii++)
            {
                if (expectedArrayDimensions[ii] != actualArrayDimensions[ii] && expectedArrayDimensions[ii] != 0)
                {
                    return false;
                }
            }

            // everything ok.
            return true;
        }
    }
    
	/// <summary>
	/// The bit masks used to indicate the write access to the attributes for a node.
	/// </summary>
	public static class WriteMasks
	{
		/// <summary>
		/// No attributes are writeable.
		/// </summary>
		public const uint None = 0;

		/// <summary>
		/// The BrowseName attribute is writeable.
		/// </summary>
		public const uint BrowseName = 1;

		/// <summary>
		/// The DisplayName attribute is writeable.
		/// </summary>
		public const uint DisplayName = 2;

		/// <summary>
		/// The Description attribute is writeable.
		/// </summary>
		public const uint Description = 4;

		/// <summary>
		/// The IsAbstract attribute is writeable.
		/// </summary>
		public const uint IsAbstract = 8;

		/// <summary>
		/// The Symmetric attribute is writeable.
		/// </summary>
		public const uint Symmetric = 16;

		/// <summary>
		/// The InverseName attribute is writeable.
		/// </summary>
		public const uint InverseName = 32;

		/// <summary>
		/// The ContainsNoLoops attribute is writeable.
		/// </summary>
		public const uint ContainsNoLoops = 64;

		/// <summary>
		/// The EventNotifier attribute is writeable.
		/// </summary>
		public const uint EventNotifier = 128;

		/// <summary>
		/// The DataType attribute is writeable.
		/// </summary>
		public const uint DataType = 256;

		/// <summary>
		/// The ValueRank attribute is writeable.
		/// </summary>
		public const uint ValueRank = 512;

		/// <summary>
		/// The AccessLevel attribute is writeable.
		/// </summary>
		public const uint AccessLevel = 1024;

		/// <summary>
		/// The UserAccessLevel attribute is writeable.
		/// </summary>
		public const uint UserAccessLevel = 2048;

		/// <summary>
		/// The MinimumSamplingInterval attribute is writeable.
		/// </summary>
		public const uint MinimumSamplingInterval = 4096;

		/// <summary>
		/// The Historizing attribute is writeable.
		/// </summary>
		public const uint Historizing = 8192;

		/// <summary>
		/// The Executable attribute is writeable.
		/// </summary>
		public const uint Executable = 16384;

		/// <summary>
		/// The UserExecutable attribute is writeable.
		/// </summary>
		public const uint UserExecutable = 32768;

		/// <summary>
		/// The WriteAccess attribute is writeable.
		/// </summary>
		public const uint WriteAccess = 65536;

		/// <summary>
		/// The UserWriteAccess attribute is writeable.
		/// </summary>
		public const uint UserWriteAccess = 131072;
	}

    /// <summary>
    /// Constants defined for the MinimumSamplingInterval attribute.
    /// </summary>
    /// <remarks>
    /// Constants defined for the MinimumSamplingInterval attribute.
    /// </remarks>
    public static class MinimumSamplingIntervals
    {
        /// <summary>
        /// The server does not know how fast the value can be sampled.
        /// </summary>
        public const double Indeterminate = -1;

        /// <summary>
        /// TThe server can sample the variable continuously.
        /// </summary>
        public const double Continuous = 0;
    }

    /// <summary>
    /// The set of bits masks used for ReturnDiagnostics parameter in the RequestHeader.
    /// </summary>
    [Flags]
    public enum DiagnosticsMasks
    {
        /// <summary>
        /// ServiceSymbolicId = 1,
        /// </summary>
        ServiceSymbolicId = 1,

        /// <summary>
        /// ServiceLocalizedText = 2,
        /// </summary>
        ServiceLocalizedText = 2,

        /// <summary>
        /// ServiceAdditionalInfo = 4,
        /// </summary>
        ServiceAdditionalInfo = 4,

        /// <summary>
        /// ServiceInnerStatusCode = 8,
        /// </summary>
        ServiceInnerStatusCode = 8,

        /// <summary>
        /// ServiceInnerDiagnostics = 16,
        /// </summary>
        ServiceInnerDiagnostics = 16,

        /// <summary>
        /// ServiceSymbolicIdAndText = 3,
        /// </summary>
        ServiceSymbolicIdAndText = 3,

        /// <summary>
        /// ServiceNoInnerStatus = 15,
        /// </summary>
        ServiceNoInnerStatus = 15,

        /// <summary>
        /// ServiceAll = 31,
        /// </summary>
        ServiceAll = 31,

        /// <summary>
        /// OperationSymbolicId = 32,
        /// </summary>
        OperationSymbolicId = 32,

        /// <summary>
        /// OperationLocalizedText = 64,
        /// </summary>
        OperationLocalizedText = 64,

        /// <summary>
        /// OperationAdditionalInfo = 128,
        /// </summary>
        OperationAdditionalInfo = 128,

        /// <summary>
        /// OperationInnerStatusCode = 256,
        /// </summary>
        OperationInnerStatusCode = 256,

        /// <summary>
        /// OperationInnerDiagnostics = 512,
        /// </summary>
        OperationInnerDiagnostics = 512,

        /// <summary>
        /// OperationSymbolicIdAndText = 96,
        /// </summary>
        OperationSymbolicIdAndText = 96,

        /// <summary>
        /// OperationNoInnerStatus = 224,
        /// </summary>
        OperationNoInnerStatus = 224,

        /// <summary>
        /// OperationAll = 992,
        /// </summary>
        OperationAll = 992,

        /// <summary>
        /// SymbolicId = 33,
        /// </summary>
        SymbolicId = 33,

        /// <summary>
        /// LocalizedText = 66,
        /// </summary>
        LocalizedText = 66,

        /// <summary>
        /// AdditionalInfo = 132,
        /// </summary>
        AdditionalInfo = 132,

        /// <summary>
        /// InnerStatusCode = 264,
        /// </summary>
        InnerStatusCode = 264,

        /// <summary>
        /// InnerDiagnostics = 528,
        /// </summary>
        InnerDiagnostics = 528,

        /// <summary>
        /// SymbolicIdAndText = 99,
        /// </summary>
        SymbolicIdAndText = 99,

        /// <summary>
        /// NoInnerStatus = 239,
        /// </summary>
        NoInnerStatus = 239,

        /// <summary>
        /// All = 1023
        /// </summary>
        All = 1023
    }
}
