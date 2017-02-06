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
using System.Threading;
using System.Text;
using System.IO;
using System.Xml;
using System.Reflection;
using System.ServiceModel.Channels;
using System.Diagnostics;

using Opc.Ua.Client;

namespace Opc.Ua.StackTest
{
    #region Class TestCaseContext
    /// <summary>
    /// Specifies parameters to use when executing a test case.
    /// </summary>
    public class TestCaseContext
    {
        #region Constructors
        /// <summary>
        /// Creates a context with suitable default values.
        /// </summary>
        public TestCaseContext()
        {
            MaxStringLength = 256;
            MaxArrayLength = 256;
            MaxDepth = 1;
            BoundaryValueRate = 64;
            MinDateTime = new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            MaxDateTime = new DateTime(2100, 12, 13, 23, 59, 59, 999, DateTimeKind.Utc);

            CharRanges = new List<CharRange>();

            CharRanges.Add(new CharRange(0x0041, 0x005A));

            /*
            CharRanges.Add(new CharRange(0x0001, 0x00FF));
            CharRanges.Add(new CharRange(0x0400, 0x04FF));
            CharRanges.Add(new CharRange(0x4E00, 0x9FA5));
            */

            MaxTransportDelay = 2000;
            MaxResponseDelay = 60000;
            RequestInterval = 1000;
            StackEventFrequency = 3;
            StackEventType = 0;
            MaxRecoveryTime = 30000;
        }
        #endregion

        #region Public Fields
        /// <summary>
        /// How frequent values should be choosen from the set of boundary values for the data type.
        /// </summary>
        /// <remarks>
        /// A random byte is tested against this value. If that byte is less than or equal to this value then a boundary value is choosen.
        /// </remarks>
        public byte BoundaryValueRate;

        /// <summary>
        /// The minimum date/time value to use when generating random dates.
        /// </summary>
        public DateTime MinDateTime;

        /// <summary>
        /// The maximum date/time value to use when generating random dates.
        /// </summary>
        public DateTime MaxDateTime;

        /// <summary>
        /// The range(s) for valid character values when generating random strings.
        /// </summary>
        public List<CharRange> CharRanges;

        /// <summary>
        /// A range of character values.
        /// </summary>
        public struct CharRange
        {
            /// <summary>
            /// Creates an instance with the specified range.
            /// </summary>
            public CharRange(int first, int last)
            {
                First = first;
                Last = last;
            }

            /// <summary>
            /// The first character in the range.
            /// </summary>
            public int First;

            /// <summary>
            /// The last character in the range.
            /// </summary>
            public int Last;
        }

        #region Test Parameters Fields
        /// <summary>
        /// Maximum length for any randomly created string value.
        /// </summary>
        /// <example>
        /// <Parameter>
        ///     <Name>MaxStringLength</Name>
        ///     <Value>1024</Value>    
        /// </Parameter>
        /// </example>
        public int MaxStringLength;

        /// <summary>
        /// Maximum length for any randomly created array.
        /// </summary>
        /// <example>
        /// <Parameter>
        ///     <Name>MaxArrayLength</Name>
        ///     <Value>2</Value>    
        /// </Parameter>
        /// </example>
        public int MaxArrayLength;

        /// <summary>
        /// Maximum length for any message sent to the server.
        /// </summary>
        public int ServerMaxMessageSize;
        
        /// <summary>
        /// Maximum length for any message sent to the client.
        /// </summary>
        public int ClientMaxMessageSize;
        
        /// <summary>
        /// The maximum number of nested structures allowed in random data.
        /// </summary>
        /// <example>
        /// <Parameter>
        ///     <Name>MaxDepth</Name>
        ///     <Value>4</Value>    
        /// </Parameter>
        /// </example>
        public int MaxDepth;

        /// <summary>
        /// Maximum response delay.
        /// </summary>
        /// <remarks>
        /// Time in miliseconds.
        /// </remarks>
        /// <example>
        /// <Parameter>
        ///     <Name>MaxResponseDelay</Name>
        ///     <Value>30000</Value>    
        /// </Parameter>
        /// </example>
        public int MaxResponseDelay;

        /// <summary>
        /// Maximum time taken since the time of request initiation in the client and request arrival at server's target method
        /// It does not consider the actual service execution time
        /// </summary>
        /// <remarks>
        /// Time in miliseconds.
        /// </remarks>
        /// <example>
        /// <Parameter>
        ///     <Name>MaxTransportDelay</Name>
        ///     <Value>5000</Value>    
        /// </Parameter>
        /// </example>
        public int MaxTransportDelay;

        /// <summary>
        /// The minimum timeout value to use when generating random timeouts.
        /// </summary>
        /// <remarks>
        /// Time in miliseconds.It should have value less than MaxTimeout and ReceiveRequest timeout.
        /// </remarks>
        /// <example>
        /// <Parameter>
        ///     <Name>MinTimeout</Name>
        ///     <Value>120000</Value>
        /// </Parameter>
        /// </example>
        public int MinTimeout;

        /// <summary>
        /// The maximum timeout value to use when generating random timeouts.
        /// </summary>
        /// <remarks>
        /// Time in miliseconds.It should have value greater than MinTimeout and ReceiveRequest timeout.
        /// </remarks>
        /// <example>
        /// <Parameter>
        ///     <Name>MaxTimeout</Name>
        ///     <Value>180000</Value>
        /// </Parameter>
        /// </example>
        public int MaxTimeout;

        /// <summary>
        /// The interval between requests in milliseconds
        /// </summary>
        public int RequestInterval;

        /// <summary>
        /// The type of stack event to trigger.
        /// </summary>
        /// <remarks>
        /// 0 - None
        /// 1 - CorruptMessage
        /// 2 - ReuseSequenceNumber
        /// 3 - BrokenSocket
        /// </remarks>
        public int StackEventType;

        /// <summary>
        /// The frequency of stack events (expressed as a ratio 1:n iterations)
        /// </summary>
        public int StackEventFrequency;

        /// <summary>
        /// The maximum time taken to recover from network interruption.
        /// </summary>
        public int MaxRecoveryTime;
        
        /// <summary>
        /// Server details for the multiple channel test case.This will contain
        /// list of the object of type ServerDetail.
        /// </summary>
        /// <remarks>
        /// It will contain $ separated server name and server url.i.e.servername$serverurl       
        /// </remarks>
        /// <example>
        /// <Parameter>
        ///     <Name>ServerDetails</Name>
        ///     <Value>Server1$opc.tcp://localhost:51210/UA/SampleServer</Value>
        /// </Parameter>
        /// </example>
        public List<ServerDetail> ServerDetails;

        /// <summary>
        /// Number of channels per server for the multiple channel test case.
        /// </summary>
        /// <remarks>
        /// Please remember maximum allowed channels for server is limited by the maximum concurrent channels
        /// allowed by the underlying stack and or server
        /// Out of the maimum allowed, one will be reserved for the default channel and one for the discovery.
        /// </remarks>
        /// <example>
        /// <Parameter>
        ///     <Name>ChannelsPerServer</Name>
        ///     <Value>5</Value>
        /// </Parameter>   
        /// </example>
        public int ChannelsPerServer;
        #endregion
        #endregion
    }
    #endregion

    #region ChannelContext Class
    /// <summary>
    /// Class for storing complete state of a channel
    /// </summary>
    public class ChannelContext
    {
        #region Public Fields
        /// <summary>
        /// Client proxy
        /// </summary>
        public ITransportChannel Channel;
        /// <summary>
        /// The security mode.
        /// </summary>
        public EndpointDescription EndpointDescription;
        /// <summary>
        /// The message context used for the channel.
        /// </summary>
        public ServiceMessageContext MessageContext;
        /// <summary>
        /// Client session
        /// </summary>
        public SessionClient ClientSession;
        /// <summary>
        /// Unique channel identification
        /// </summary>
        public string ChannelID;
        /// <summary>
        /// Event to trigger the completion of test case that uses asynchronous test services
        /// </summary>
        public AutoResetEvent AsyncTestsComplete;
        /// <summary>
        /// Count indicating the number of pending tests that uses asynchronous calls to test services.
        /// </summary>
        public uint PendingAsycnTests;
        /// <summary>
        /// Event to trigger the completion of a test case
        /// </summary>
        public AutoResetEvent TestCaseComplete;
        /// <summary>
        /// PseudoRandom class object.
        /// </summary>
        public PseudoRandom Random;
        /// <summary>
        /// Logger used to log events
        /// </summary>
        public Logger EventLogger;
        #endregion
    }
    #endregion

}
