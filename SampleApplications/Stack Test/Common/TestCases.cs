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
using System.Configuration;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Xml;
using System.Reflection;
using System.IO;

namespace Opc.Ua.StackTest
{
    /// <summary>
    /// A class that defines constants for the test cases supported by the test harness.
    /// </summary>
    public class TestCases
    {
        /// <summary>
        /// Interoperability between the ANSI C and the .NET Serializers.
        /// </summary>
        public const string SerializerDirect = "SerializerDirect";

        /// <summary>
        /// Interoperability between the ANSI C and the .NET Serializers.
        /// </summary>
        public const string SerializerDirectEx = "SerializerDirectEx";

        /// <summary>
        /// Basic message exchange with scalar values.
        /// </summary>
        public const string ScalarValues = "ScalarValues";

        /// <summary>
        /// Basic message exchange with array values.
        /// </summary>
        public const string ArrayValues = "ArrayValues";

        /// <summary>
        /// Basic message exchange with Extension Object values.
        /// </summary>
        public const string ExtensionObjectValues = "ExtensionObjectValues";

        /// <summary>
        /// Basic message exchange with all Built-In types.
        /// </summary>
        public const string BuiltInTypes = "BuiltInTypes";

        /// <summary>
        /// Tests using large messages that exceeed the limits set by the sender/receiver.
        /// </summary>
        public const string LargeMessages = "LargeMessages";

        /// <summary>
        /// Protocol test: Multiple Channels Test
        /// </summary>
        public const string MultipleChannels = "MultipleChannels";

        /// <summary>
        /// Sends a series of requests that take time to complete.
        /// </summary>
        public const string AutoReconnect = "AutoReconnect";     

        /// <summary>
        /// Basic message exchange with Server Fault.
        /// </summary>
        public const string ServerFault = "ServerFault";

        /// <summary>
        /// Basic message exchange with Server Fault.
        /// </summary>
        public const string ServerTimeout = "ServerTimeout";

        /// <summary>
        /// Maximum length of the a string
        /// </summary>
        public const string MaxStringLength = "MaxStringLength";

        /// <summary>
        /// Maximum length of an array
        /// </summary>
        public const string MaxArrayLength = "MaxArrayLength";

        /// <summary>
        /// Maximum length of a message allowed by the server.
        /// </summary>
        public const string ServerMaxMessageSize = "ServerMaxMessageSize";

        /// <summary>
        /// Maximum length of a message allowed by the client.
        /// </summary>
        public const string ClientMaxMessageSize = "ClientMaxMessageSize";

        /// <summary>
        /// Maximum depth of the nesting
        /// </summary>
        public const string MaxDepth = "MaxDepth";

        /// <summary>
        /// Iteration that is used to initialize a test case
        /// </summary>
        public const int TestSetupIteration = -1;

        /// <summary>
        /// Iteration that is used to windup a test case
        /// </summary>
        public const int TestCleanupIteration = Int32.MaxValue;

        /// <summary>
        /// Maximum timeout value
        /// </summary>
        public const string MaxTimeout = "MaxTimeout";

        /// <summary>
        /// Minimum timeout value
        /// </summary>
        public const string MinTimeout = "MinTimeout";

        /// <summary>
        /// Maximum service execution
        /// </summary>
        public const string MaxTransportDelay = "MaxTransportDelay";

        /// <summary>
        /// Max response delay
        /// </summary>
        public const string MaxResponseDelay = "MaxResponseDelay";

        /// <summary>
        /// The iterval between tests.
        /// </summary>
        public const string RequestInterval = "RequestInterval";

        /// <summary>
        /// The type of stack events.
        /// </summary>
        public const string StackEventType = "StackEventType";
        
        /// <summary>
        /// Frequency of stack actions
        /// </summary>
        public const string StackEventFrequency = "StackEventFrequency";
        
        /// <summary>
        /// The maximum error recovery time.
        /// </summary>
        public const string MaxRecoveryTime = "MaxRecoveryTime";
        
        /// <summary>
        /// Number of channels for the multiple channel test case.
        /// </summary>
        public const string ChannelsPerServer = "ChannelsPerServer";

        /// <summary>
        /// Server details for the multiple channel test case.
        /// </summary>
        public const string ServerDetails = "ServerDetails";   

        /// <summary>
        /// Whether to verify the extension object lengths during the serializer direct tests.
        /// </summary>
        public const string AlwaysCheckSizes = "AlwaysCheckSizes";        
    }
}
