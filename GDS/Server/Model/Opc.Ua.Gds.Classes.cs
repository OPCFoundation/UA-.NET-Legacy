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
    #region FindApplicationsMethodState Class
    #if (!OPCUA_EXCLUDE_FindApplicationsMethodState)
    /// <summary>
    /// Stores an instance of the FindApplicationsMethodType Method.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class FindApplicationsMethodState : MethodState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public FindApplicationsMethodState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Constructs an instance of a node.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <returns>The new node.</returns>
        public new static NodeState Construct(NodeState parent)
        {
            return new FindApplicationsMethodState(parent);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AQAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvR0RTL/////8EYYIKBAAAAAEAGgAAAEZp" +
           "bmRBcHBsaWNhdGlvbnNNZXRob2RUeXBlAQECAAAvAQECAAIAAAABAf////8CAAAAFWCpCgIAAAAAAA4A" +
           "AABJbnB1dEFyZ3VtZW50cwEBAwAALgBEAwAAAJYBAAAAAQAqAQEdAAAADgAAAEFwcGxpY2F0aW9uVXJp" +
           "AAz/////AAAAAAABACgBAQAAAAEB/////wAAAAAVYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEB" +
           "BAAALgBEBAAAAJYBAAAAAQAqAQEdAAAADAAAAEFwcGxpY2F0aW9ucwEBAQABAAAAAAAAAAABACgBAQAA" +
           "AAEB/////wAAAAA=";
        #endregion
        #endif
        #endregion

        #region Event Callbacks
        /// <summary>
        /// Raised when the the method is called.
        /// </summary>
        public FindApplicationsMethodStateMethodCallHandler OnCall;
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Invokes the method, returns the result and output argument.
        /// </summary>
        /// <param name="context">The current context.</param>
        /// <param name="objectId">The id of the object.</param>
        /// <param name="inputArguments">The input arguments which have been already validated.</param>
        /// <param name="outputArguments">The output arguments which have initialized with thier default values.</param>
        /// <returns></returns>
        protected override ServiceResult Call(
            ISystemContext context,
            NodeId objectId,
            IList<object> inputArguments,
            IList<object> outputArguments)
        {
            if (OnCall == null)
            {
                return base.Call(context, objectId, inputArguments, outputArguments);
            }

            ServiceResult result = null;

            string applicationUri = (string)inputArguments[0];

            ApplicationRecordDataType[] applications = (ApplicationRecordDataType[])outputArguments[0];

            if (OnCall != null)
            {
                result = OnCall(
                    context,
                    this,
                    objectId,
                    applicationUri,
                    ref applications);
            }

            outputArguments[0] = applications;

            return result;
        }
        #endregion

        #region Private Fields
        #endregion
    }

    /// <summary>
    /// Used to receive notifications when the method is called.
    /// </summary>
    /// <exclude />
    public delegate ServiceResult FindApplicationsMethodStateMethodCallHandler(
        ISystemContext context,
        MethodState method,
        NodeId objectId,
        string applicationUri,
        ref ApplicationRecordDataType[] applications);
    #endif
    #endregion

    #region RegisterApplicationMethodState Class
    #if (!OPCUA_EXCLUDE_RegisterApplicationMethodState)
    /// <summary>
    /// Stores an instance of the RegisterApplicationMethodType Method.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class RegisterApplicationMethodState : MethodState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public RegisterApplicationMethodState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Constructs an instance of a node.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <returns>The new node.</returns>
        public new static NodeState Construct(NodeState parent)
        {
            return new RegisterApplicationMethodState(parent);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AQAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvR0RTL/////8EYYIKBAAAAAEAHQAAAFJl" +
           "Z2lzdGVyQXBwbGljYXRpb25NZXRob2RUeXBlAQEFAAAvAQEFAAUAAAABAf////8CAAAAFWCpCgIAAAAA" +
           "AA4AAABJbnB1dEFyZ3VtZW50cwEBBgAALgBEBgAAAJYBAAAAAQAqAQEcAAAACwAAAEFwcGxpY2F0aW9u" +
           "AQEBAP////8AAAAAAAEAKAEBAAAAAQH/////AAAAABVgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRz" +
           "AQEHAAAuAEQHAAAAlgEAAAABACoBARwAAAANAAAAQXBwbGljYXRpb25JZAAR/////wAAAAAAAQAoAQEA" +
           "AAABAf////8AAAAA";
        #endregion
        #endif
        #endregion

        #region Event Callbacks
        /// <summary>
        /// Raised when the the method is called.
        /// </summary>
        public RegisterApplicationMethodStateMethodCallHandler OnCall;
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Invokes the method, returns the result and output argument.
        /// </summary>
        /// <param name="context">The current context.</param>
        /// <param name="objectId">The id of the object.</param>
        /// <param name="inputArguments">The input arguments which have been already validated.</param>
        /// <param name="outputArguments">The output arguments which have initialized with thier default values.</param>
        /// <returns></returns>
        protected override ServiceResult Call(
            ISystemContext context,
            NodeId objectId,
            IList<object> inputArguments,
            IList<object> outputArguments)
        {
            if (OnCall == null)
            {
                return base.Call(context, objectId, inputArguments, outputArguments);
            }

            ServiceResult result = null;

            ApplicationRecordDataType application = (ApplicationRecordDataType)ExtensionObject.ToEncodeable((ExtensionObject)inputArguments[0]);

            NodeId applicationId = (NodeId)outputArguments[0];

            if (OnCall != null)
            {
                result = OnCall(
                    context,
                    this,
                    objectId,
                    application,
                    ref applicationId);
            }

            outputArguments[0] = applicationId;

            return result;
        }
        #endregion

        #region Private Fields
        #endregion
    }

    /// <summary>
    /// Used to receive notifications when the method is called.
    /// </summary>
    /// <exclude />
    public delegate ServiceResult RegisterApplicationMethodStateMethodCallHandler(
        ISystemContext context,
        MethodState method,
        NodeId objectId,
        ApplicationRecordDataType application,
        ref NodeId applicationId);
    #endif
    #endregion

    #region UpdateApplicationMethodState Class
    #if (!OPCUA_EXCLUDE_UpdateApplicationMethodState)
    /// <summary>
    /// Stores an instance of the UpdateApplicationMethodType Method.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class UpdateApplicationMethodState : MethodState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public UpdateApplicationMethodState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Constructs an instance of a node.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <returns>The new node.</returns>
        public new static NodeState Construct(NodeState parent)
        {
            return new UpdateApplicationMethodState(parent);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AQAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvR0RTL/////8EYYIKBAAAAAEAGwAAAFVw" +
           "ZGF0ZUFwcGxpY2F0aW9uTWV0aG9kVHlwZQEBugAALwEBugC6AAAAAQH/////AQAAABVgqQoCAAAAAAAO" +
           "AAAASW5wdXRBcmd1bWVudHMBAbsAAC4ARLsAAACWAQAAAAEAKgEBHAAAAAsAAABBcHBsaWNhdGlvbgEB" +
           "AQD/////AAAAAAABACgBAQAAAAEB/////wAAAAA=";
        #endregion
        #endif
        #endregion

        #region Event Callbacks
        /// <summary>
        /// Raised when the the method is called.
        /// </summary>
        public UpdateApplicationMethodStateMethodCallHandler OnCall;
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Invokes the method, returns the result and output argument.
        /// </summary>
        /// <param name="context">The current context.</param>
        /// <param name="objectId">The id of the object.</param>
        /// <param name="inputArguments">The input arguments which have been already validated.</param>
        /// <param name="outputArguments">The output arguments which have initialized with thier default values.</param>
        /// <returns></returns>
        protected override ServiceResult Call(
            ISystemContext context,
            NodeId objectId,
            IList<object> inputArguments,
            IList<object> outputArguments)
        {
            if (OnCall == null)
            {
                return base.Call(context, objectId, inputArguments, outputArguments);
            }

            ServiceResult result = null;

            ApplicationRecordDataType application = (ApplicationRecordDataType)ExtensionObject.ToEncodeable((ExtensionObject)inputArguments[0]);

            if (OnCall != null)
            {
                result = OnCall(
                    context,
                    this,
                    objectId,
                    application);
            }

            return result;
        }
        #endregion

        #region Private Fields
        #endregion
    }

    /// <summary>
    /// Used to receive notifications when the method is called.
    /// </summary>
    /// <exclude />
    public delegate ServiceResult UpdateApplicationMethodStateMethodCallHandler(
        ISystemContext context,
        MethodState method,
        NodeId objectId,
        ApplicationRecordDataType application);
    #endif
    #endregion

    #region UnregisterApplicationMethodState Class
    #if (!OPCUA_EXCLUDE_UnregisterApplicationMethodState)
    /// <summary>
    /// Stores an instance of the UnregisterApplicationMethodType Method.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class UnregisterApplicationMethodState : MethodState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public UnregisterApplicationMethodState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Constructs an instance of a node.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <returns>The new node.</returns>
        public new static NodeState Construct(NodeState parent)
        {
            return new UnregisterApplicationMethodState(parent);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AQAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvR0RTL/////8EYYIKBAAAAAEAHwAAAFVu" +
           "cmVnaXN0ZXJBcHBsaWNhdGlvbk1ldGhvZFR5cGUBAQgAAC8BAQgACAAAAAEB/////wEAAAAVYKkKAgAA" +
           "AAAADgAAAElucHV0QXJndW1lbnRzAQEJAAAuAEQJAAAAlgEAAAABACoBARwAAAANAAAAQXBwbGljYXRp" +
           "b25JZAAR/////wAAAAAAAQAoAQEAAAABAf////8AAAAA";
        #endregion
        #endif
        #endregion

        #region Event Callbacks
        /// <summary>
        /// Raised when the the method is called.
        /// </summary>
        public UnregisterApplicationMethodStateMethodCallHandler OnCall;
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Invokes the method, returns the result and output argument.
        /// </summary>
        /// <param name="context">The current context.</param>
        /// <param name="objectId">The id of the object.</param>
        /// <param name="inputArguments">The input arguments which have been already validated.</param>
        /// <param name="outputArguments">The output arguments which have initialized with thier default values.</param>
        /// <returns></returns>
        protected override ServiceResult Call(
            ISystemContext context,
            NodeId objectId,
            IList<object> inputArguments,
            IList<object> outputArguments)
        {
            if (OnCall == null)
            {
                return base.Call(context, objectId, inputArguments, outputArguments);
            }

            ServiceResult result = null;

            NodeId applicationId = (NodeId)inputArguments[0];

            if (OnCall != null)
            {
                result = OnCall(
                    context,
                    this,
                    objectId,
                    applicationId);
            }

            return result;
        }
        #endregion

        #region Private Fields
        #endregion
    }

    /// <summary>
    /// Used to receive notifications when the method is called.
    /// </summary>
    /// <exclude />
    public delegate ServiceResult UnregisterApplicationMethodStateMethodCallHandler(
        ISystemContext context,
        MethodState method,
        NodeId objectId,
        NodeId applicationId);
    #endif
    #endregion

    #region GetApplicationMethodState Class
    #if (!OPCUA_EXCLUDE_GetApplicationMethodState)
    /// <summary>
    /// Stores an instance of the GetApplicationMethodType Method.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class GetApplicationMethodState : MethodState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public GetApplicationMethodState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Constructs an instance of a node.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <returns>The new node.</returns>
        public new static NodeState Construct(NodeState parent)
        {
            return new GetApplicationMethodState(parent);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AQAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvR0RTL/////8EYYIKBAAAAAEAGAAAAEdl" +
           "dEFwcGxpY2F0aW9uTWV0aG9kVHlwZQEBzwAALwEBzwDPAAAAAQH/////AgAAABVgqQoCAAAAAAAOAAAA" +
           "SW5wdXRBcmd1bWVudHMBAdAAAC4ARNAAAACWAQAAAAEAKgEBHAAAAA0AAABBcHBsaWNhdGlvbklkABH/" +
           "////AAAAAAABACgBAQAAAAEB/////wAAAAAVYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEB0QAA" +
           "LgBE0QAAAJYBAAAAAQAqAQEcAAAACwAAAEFwcGxpY2F0aW9uAQEBAP////8AAAAAAAEAKAEBAAAAAQH/" +
           "////AAAAAA==";
        #endregion
        #endif
        #endregion

        #region Event Callbacks
        /// <summary>
        /// Raised when the the method is called.
        /// </summary>
        public GetApplicationMethodStateMethodCallHandler OnCall;
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Invokes the method, returns the result and output argument.
        /// </summary>
        /// <param name="context">The current context.</param>
        /// <param name="objectId">The id of the object.</param>
        /// <param name="inputArguments">The input arguments which have been already validated.</param>
        /// <param name="outputArguments">The output arguments which have initialized with thier default values.</param>
        /// <returns></returns>
        protected override ServiceResult Call(
            ISystemContext context,
            NodeId objectId,
            IList<object> inputArguments,
            IList<object> outputArguments)
        {
            if (OnCall == null)
            {
                return base.Call(context, objectId, inputArguments, outputArguments);
            }

            ServiceResult result = null;

            NodeId applicationId = (NodeId)inputArguments[0];

            ApplicationRecordDataType application = (ApplicationRecordDataType)outputArguments[0];

            if (OnCall != null)
            {
                result = OnCall(
                    context,
                    this,
                    objectId,
                    applicationId,
                    ref application);
            }

            outputArguments[0] = application;

            return result;
        }
        #endregion

        #region Private Fields
        #endregion
    }

    /// <summary>
    /// Used to receive notifications when the method is called.
    /// </summary>
    /// <exclude />
    public delegate ServiceResult GetApplicationMethodStateMethodCallHandler(
        ISystemContext context,
        MethodState method,
        NodeId objectId,
        NodeId applicationId,
        ref ApplicationRecordDataType application);
    #endif
    #endregion

    #region QueryServersMethodState Class
    #if (!OPCUA_EXCLUDE_QueryServersMethodState)
    /// <summary>
    /// Stores an instance of the QueryServersMethodType Method.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class QueryServersMethodState : MethodState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public QueryServersMethodState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Constructs an instance of a node.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <returns>The new node.</returns>
        public new static NodeState Construct(NodeState parent)
        {
            return new QueryServersMethodState(parent);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AQAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvR0RTL/////8EYYIKBAAAAAEAFgAAAFF1" +
           "ZXJ5U2VydmVyc01ldGhvZFR5cGUBAQoAAC8BAQoACgAAAAEB/////wIAAAAVYKkKAgAAAAAADgAAAElu" +
           "cHV0QXJndW1lbnRzAQELAAAuAEQLAAAAlgYAAAABACoBAR8AAAAQAAAAU3RhcnRpbmdSZWNvcmRJZAAH" +
           "/////wAAAAAAAQAqAQEhAAAAEgAAAE1heFJlY29yZHNUb1JldHVybgAH/////wAAAAAAAQAqAQEeAAAA" +
           "DwAAAEFwcGxpY2F0aW9uTmFtZQAM/////wAAAAAAAQAqAQEdAAAADgAAAEFwcGxpY2F0aW9uVXJpAAz/" +
           "////AAAAAAABACoBARkAAAAKAAAAUHJvZHVjdFVyaQAM/////wAAAAAAAQAqAQEhAAAAEgAAAFNlcnZl" +
           "ckNhcGFiaWxpdGllcwAMAQAAAAAAAAAAAQAoAQEAAAABAf////8AAAAAFWCpCgIAAAAAAA8AAABPdXRw" +
           "dXRBcmd1bWVudHMBAQwAAC4ARAwAAACWAgAAAAEAKgEBJQAAABQAAABMYXN0Q291bnRlclJlc2V0VGlt" +
           "ZQEAJgH/////AAAAAAABACoBARgAAAAHAAAAU2VydmVycwEAnS8BAAAAAAAAAAABACgBAQAAAAEB////" +
           "/wAAAAA=";
        #endregion
        #endif
        #endregion

        #region Event Callbacks
        /// <summary>
        /// Raised when the the method is called.
        /// </summary>
        public QueryServersMethodStateMethodCallHandler OnCall;
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Invokes the method, returns the result and output argument.
        /// </summary>
        /// <param name="context">The current context.</param>
        /// <param name="objectId">The id of the object.</param>
        /// <param name="inputArguments">The input arguments which have been already validated.</param>
        /// <param name="outputArguments">The output arguments which have initialized with thier default values.</param>
        /// <returns></returns>
        protected override ServiceResult Call(
            ISystemContext context,
            NodeId objectId,
            IList<object> inputArguments,
            IList<object> outputArguments)
        {
            if (OnCall == null)
            {
                return base.Call(context, objectId, inputArguments, outputArguments);
            }

            ServiceResult result = null;

            uint startingRecordId = (uint)inputArguments[0];
            uint maxRecordsToReturn = (uint)inputArguments[1];
            string applicationName = (string)inputArguments[2];
            string applicationUri = (string)inputArguments[3];
            string productUri = (string)inputArguments[4];
            string[] serverCapabilities = (string[])inputArguments[5];

            DateTime lastCounterResetTime = (DateTime)outputArguments[0];
            ServerOnNetwork[] servers = (ServerOnNetwork[])outputArguments[1];

            if (OnCall != null)
            {
                result = OnCall(
                    context,
                    this,
                    objectId,
                    startingRecordId,
                    maxRecordsToReturn,
                    applicationName,
                    applicationUri,
                    productUri,
                    serverCapabilities,
                    ref lastCounterResetTime,
                    ref servers);
            }

            outputArguments[0] = lastCounterResetTime;
            outputArguments[1] = servers;

            return result;
        }
        #endregion

        #region Private Fields
        #endregion
    }

    /// <summary>
    /// Used to receive notifications when the method is called.
    /// </summary>
    /// <exclude />
    public delegate ServiceResult QueryServersMethodStateMethodCallHandler(
        ISystemContext context,
        MethodState method,
        NodeId objectId,
        uint startingRecordId,
        uint maxRecordsToReturn,
        string applicationName,
        string applicationUri,
        string productUri,
        string[] serverCapabilities,
        ref DateTime lastCounterResetTime,
        ref ServerOnNetwork[] servers);
    #endif
    #endregion

    #region DirectoryState Class
    #if (!OPCUA_EXCLUDE_DirectoryState)
    /// <summary>
    /// Stores an instance of the DirectoryType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class DirectoryState : FolderState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public DirectoryState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.Gds.ObjectTypes.DirectoryType, Opc.Ua.Gds.Namespaces.OpcUaGds, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AQAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvR0RTL/////8EYIAAAQAAAAEAFQAAAERp" +
           "cmVjdG9yeVR5cGVJbnN0YW5jZQEBDQABAQ0A/////wcAAAAEYIAKAQAAAAEADAAAAEFwcGxpY2F0aW9u" +
           "cwEBDgAALwA9DgAAAP////8AAAAABGGCCgQAAAABABAAAABGaW5kQXBwbGljYXRpb25zAQEPAAAvAQEP" +
           "AA8AAAABAf////8CAAAAFWCpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEBEAAALgBEEAAAAJYBAAAA" +
           "AQAqAQEdAAAADgAAAEFwcGxpY2F0aW9uVXJpAAz/////AAAAAAABACgBAQAAAAEB/////wAAAAAVYKkK" +
           "AgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEBEQAALgBEEQAAAJYBAAAAAQAqAQEdAAAADAAAAEFwcGxp" +
           "Y2F0aW9ucwEBAQABAAAAAAAAAAABACgBAQAAAAEB/////wAAAAAEYYIKBAAAAAEAEwAAAFJlZ2lzdGVy" +
           "QXBwbGljYXRpb24BARIAAC8BARIAEgAAAAEB/////wIAAAAVYKkKAgAAAAAADgAAAElucHV0QXJndW1l" +
           "bnRzAQETAAAuAEQTAAAAlgEAAAABACoBARwAAAALAAAAQXBwbGljYXRpb24BAQEA/////wAAAAAAAQAo" +
           "AQEAAAABAf////8AAAAAFWCpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBARQAAC4ARBQAAACWAQAA" +
           "AAEAKgEBHAAAAA0AAABBcHBsaWNhdGlvbklkABH/////AAAAAAABACgBAQAAAAEB/////wAAAAAEYYIK" +
           "BAAAAAEAEQAAAFVwZGF0ZUFwcGxpY2F0aW9uAQG8AAAvAQG8ALwAAAABAf////8BAAAAFWCpCgIAAAAA" +
           "AA4AAABJbnB1dEFyZ3VtZW50cwEBvQAALgBEvQAAAJYBAAAAAQAqAQEcAAAACwAAAEFwcGxpY2F0aW9u" +
           "AQEBAP////8AAAAAAAEAKAEBAAAAAQH/////AAAAAARhggoEAAAAAQAVAAAAVW5yZWdpc3RlckFwcGxp" +
           "Y2F0aW9uAQEVAAAvAQEVABUAAAABAf////8BAAAAFWCpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEB" +
           "FgAALgBEFgAAAJYBAAAAAQAqAQEcAAAADQAAAEFwcGxpY2F0aW9uSWQAEf////8AAAAAAAEAKAEBAAAA" +
           "AQH/////AAAAAARhggoEAAAAAQAOAAAAR2V0QXBwbGljYXRpb24BAdIAAC8BAdIA0gAAAAEB/////wIA" +
           "AAAVYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQHTAAAuAETTAAAAlgEAAAABACoBARwAAAANAAAA" +
           "QXBwbGljYXRpb25JZAAR/////wAAAAAAAQAoAQEAAAABAf////8AAAAAFWCpCgIAAAAAAA8AAABPdXRw" +
           "dXRBcmd1bWVudHMBAdQAAC4ARNQAAACWAQAAAAEAKgEBHAAAAAsAAABBcHBsaWNhdGlvbgEBAQD/////" +
           "AAAAAAABACgBAQAAAAEB/////wAAAAAEYYIKBAAAAAEADAAAAFF1ZXJ5U2VydmVycwEBFwAALwEBFwAX" +
           "AAAAAQH/////AgAAABVgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBARgAAC4ARBgAAACWBgAAAAEA" +
           "KgEBHwAAABAAAABTdGFydGluZ1JlY29yZElkAAf/////AAAAAAABACoBASEAAAASAAAATWF4UmVjb3Jk" +
           "c1RvUmV0dXJuAAf/////AAAAAAABACoBAR4AAAAPAAAAQXBwbGljYXRpb25OYW1lAAz/////AAAAAAAB" +
           "ACoBAR0AAAAOAAAAQXBwbGljYXRpb25VcmkADP////8AAAAAAAEAKgEBGQAAAAoAAABQcm9kdWN0VXJp" +
           "AAz/////AAAAAAABACoBASEAAAASAAAAU2VydmVyQ2FwYWJpbGl0aWVzAAwBAAAAAAAAAAABACgBAQAA" +
           "AAEB/////wAAAAAVYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEBGQAALgBEGQAAAJYCAAAAAQAq" +
           "AQElAAAAFAAAAExhc3RDb3VudGVyUmVzZXRUaW1lAQAmAf////8AAAAAAAEAKgEBGAAAAAcAAABTZXJ2" +
           "ZXJzAQCdLwEAAAAAAAAAAAEAKAEBAAAAAQH/////AAAAAA==";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// A description for the Applications Object.
        /// </summary>
        public FolderState Applications
        {
            get
            {
                return m_applications;
            }

            set
            {
                if (!Object.ReferenceEquals(m_applications, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_applications = value;
            }
        }

        /// <summary>
        /// A description for the FindApplicationsMethodType Method.
        /// </summary>
        public FindApplicationsMethodState FindApplications
        {
            get
            {
                return m_findApplicationsMethod;
            }

            set
            {
                if (!Object.ReferenceEquals(m_findApplicationsMethod, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_findApplicationsMethod = value;
            }
        }

        /// <summary>
        /// A description for the RegisterApplicationMethodType Method.
        /// </summary>
        public RegisterApplicationMethodState RegisterApplication
        {
            get
            {
                return m_registerApplicationMethod;
            }

            set
            {
                if (!Object.ReferenceEquals(m_registerApplicationMethod, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_registerApplicationMethod = value;
            }
        }

        /// <summary>
        /// A description for the UpdateApplicationMethodType Method.
        /// </summary>
        public UpdateApplicationMethodState UpdateApplication
        {
            get
            {
                return m_updateApplicationMethod;
            }

            set
            {
                if (!Object.ReferenceEquals(m_updateApplicationMethod, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_updateApplicationMethod = value;
            }
        }

        /// <summary>
        /// A description for the UnregisterApplicationMethodType Method.
        /// </summary>
        public UnregisterApplicationMethodState UnregisterApplication
        {
            get
            {
                return m_unregisterApplicationMethod;
            }

            set
            {
                if (!Object.ReferenceEquals(m_unregisterApplicationMethod, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_unregisterApplicationMethod = value;
            }
        }

        /// <summary>
        /// A description for the GetApplicationMethodType Method.
        /// </summary>
        public GetApplicationMethodState GetApplication
        {
            get
            {
                return m_getApplicationMethod;
            }

            set
            {
                if (!Object.ReferenceEquals(m_getApplicationMethod, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_getApplicationMethod = value;
            }
        }

        /// <summary>
        /// A description for the QueryServersMethodType Method.
        /// </summary>
        public QueryServersMethodState QueryServers
        {
            get
            {
                return m_queryServersMethod;
            }

            set
            {
                if (!Object.ReferenceEquals(m_queryServersMethod, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_queryServersMethod = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_applications != null)
            {
                children.Add(m_applications);
            }

            if (m_findApplicationsMethod != null)
            {
                children.Add(m_findApplicationsMethod);
            }

            if (m_registerApplicationMethod != null)
            {
                children.Add(m_registerApplicationMethod);
            }

            if (m_updateApplicationMethod != null)
            {
                children.Add(m_updateApplicationMethod);
            }

            if (m_unregisterApplicationMethod != null)
            {
                children.Add(m_unregisterApplicationMethod);
            }

            if (m_getApplicationMethod != null)
            {
                children.Add(m_getApplicationMethod);
            }

            if (m_queryServersMethod != null)
            {
                children.Add(m_queryServersMethod);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case Opc.Ua.Gds.BrowseNames.Applications:
                {
                    if (createOrReplace)
                    {
                        if (Applications == null)
                        {
                            if (replacement == null)
                            {
                                Applications = new FolderState(this);
                            }
                            else
                            {
                                Applications = (FolderState)replacement;
                            }
                        }
                    }

                    instance = Applications;
                    break;
                }

                case Opc.Ua.Gds.BrowseNames.FindApplications:
                {
                    if (createOrReplace)
                    {
                        if (FindApplications == null)
                        {
                            if (replacement == null)
                            {
                                FindApplications = new FindApplicationsMethodState(this);
                            }
                            else
                            {
                                FindApplications = (FindApplicationsMethodState)replacement;
                            }
                        }
                    }

                    instance = FindApplications;
                    break;
                }

                case Opc.Ua.Gds.BrowseNames.RegisterApplication:
                {
                    if (createOrReplace)
                    {
                        if (RegisterApplication == null)
                        {
                            if (replacement == null)
                            {
                                RegisterApplication = new RegisterApplicationMethodState(this);
                            }
                            else
                            {
                                RegisterApplication = (RegisterApplicationMethodState)replacement;
                            }
                        }
                    }

                    instance = RegisterApplication;
                    break;
                }

                case Opc.Ua.Gds.BrowseNames.UpdateApplication:
                {
                    if (createOrReplace)
                    {
                        if (UpdateApplication == null)
                        {
                            if (replacement == null)
                            {
                                UpdateApplication = new UpdateApplicationMethodState(this);
                            }
                            else
                            {
                                UpdateApplication = (UpdateApplicationMethodState)replacement;
                            }
                        }
                    }

                    instance = UpdateApplication;
                    break;
                }

                case Opc.Ua.Gds.BrowseNames.UnregisterApplication:
                {
                    if (createOrReplace)
                    {
                        if (UnregisterApplication == null)
                        {
                            if (replacement == null)
                            {
                                UnregisterApplication = new UnregisterApplicationMethodState(this);
                            }
                            else
                            {
                                UnregisterApplication = (UnregisterApplicationMethodState)replacement;
                            }
                        }
                    }

                    instance = UnregisterApplication;
                    break;
                }

                case Opc.Ua.Gds.BrowseNames.GetApplication:
                {
                    if (createOrReplace)
                    {
                        if (GetApplication == null)
                        {
                            if (replacement == null)
                            {
                                GetApplication = new GetApplicationMethodState(this);
                            }
                            else
                            {
                                GetApplication = (GetApplicationMethodState)replacement;
                            }
                        }
                    }

                    instance = GetApplication;
                    break;
                }

                case Opc.Ua.Gds.BrowseNames.QueryServers:
                {
                    if (createOrReplace)
                    {
                        if (QueryServers == null)
                        {
                            if (replacement == null)
                            {
                                QueryServers = new QueryServersMethodState(this);
                            }
                            else
                            {
                                QueryServers = (QueryServersMethodState)replacement;
                            }
                        }
                    }

                    instance = QueryServers;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private FolderState m_applications;
        private FindApplicationsMethodState m_findApplicationsMethod;
        private RegisterApplicationMethodState m_registerApplicationMethod;
        private UpdateApplicationMethodState m_updateApplicationMethod;
        private UnregisterApplicationMethodState m_unregisterApplicationMethod;
        private GetApplicationMethodState m_getApplicationMethod;
        private QueryServersMethodState m_queryServersMethod;
        #endregion
    }
    #endif
    #endregion

    #region ApplicationRegistrationChangedAuditEventState Class
    #if (!OPCUA_EXCLUDE_ApplicationRegistrationChangedAuditEventState)
    /// <summary>
    /// Stores an instance of the ApplicationRegistrationChangedAuditEventType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class ApplicationRegistrationChangedAuditEventState : AuditUpdateMethodEventState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public ApplicationRegistrationChangedAuditEventState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.Gds.ObjectTypes.ApplicationRegistrationChangedAuditEventType, Opc.Ua.Gds.Namespaces.OpcUaGds, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AQAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvR0RTL/////8EYIAAAQAAAAEANAAAAEFw" +
           "cGxpY2F0aW9uUmVnaXN0cmF0aW9uQ2hhbmdlZEF1ZGl0RXZlbnRUeXBlSW5zdGFuY2UBARoAAQEaAP//" +
           "//8QAAAANWCJCgIAAAAAAAcAAABFdmVudElkAQEbAAMAAAAAKwAAAEEgZ2xvYmFsbHkgdW5pcXVlIGlk" +
           "ZW50aWZpZXIgZm9yIHRoZSBldmVudC4ALgBEGwAAAAAP/////wEB/////wAAAAA1YIkKAgAAAAAACQAA" +
           "AEV2ZW50VHlwZQEBHAADAAAAACIAAABUaGUgaWRlbnRpZmllciBmb3IgdGhlIGV2ZW50IHR5cGUuAC4A" +
           "RBwAAAAAEf////8BAf////8AAAAANWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQEdAAMAAAAAGAAAAFRo" +
           "ZSBzb3VyY2Ugb2YgdGhlIGV2ZW50LgAuAEQdAAAAABH/////AQH/////AAAAADVgiQoCAAAAAAAKAAAA" +
           "U291cmNlTmFtZQEBHgADAAAAACkAAABBIGRlc2NyaXB0aW9uIG9mIHRoZSBzb3VyY2Ugb2YgdGhlIGV2" +
           "ZW50LgAuAEQeAAAAAAz/////AQH/////AAAAADVgiQoCAAAAAAAEAAAAVGltZQEBHwADAAAAABgAAABX" +
           "aGVuIHRoZSBldmVudCBvY2N1cnJlZC4ALgBEHwAAAAEAJgH/////AQH/////AAAAADVgiQoCAAAAAAAL" +
           "AAAAUmVjZWl2ZVRpbWUBASAAAwAAAAA+AAAAV2hlbiB0aGUgc2VydmVyIHJlY2VpdmVkIHRoZSBldmVu" +
           "dCBmcm9tIHRoZSB1bmRlcmx5aW5nIHN5c3RlbS4ALgBEIAAAAAEAJgH/////AQH/////AAAAADVgiQoC" +
           "AAAAAAAJAAAATG9jYWxUaW1lAQEhAAMAAAAAPAAAAEluZm9ybWF0aW9uIGFib3V0IHRoZSBsb2NhbCB0" +
           "aW1lIHdoZXJlIHRoZSBldmVudCBvcmlnaW5hdGVkLgAuAEQhAAAAAQDQIv////8BAf////8AAAAANWCJ" +
           "CgIAAAAAAAcAAABNZXNzYWdlAQEiAAMAAAAAJQAAAEEgbG9jYWxpemVkIGRlc2NyaXB0aW9uIG9mIHRo" +
           "ZSBldmVudC4ALgBEIgAAAAAV/////wEB/////wAAAAA1YIkKAgAAAAAACAAAAFNldmVyaXR5AQEjAAMA" +
           "AAAAIQAAAEluZGljYXRlcyBob3cgdXJnZW50IGFuIGV2ZW50IGlzLgAuAEQjAAAAAAX/////AQH/////" +
           "AAAAADVgiQoCAAAAAAAPAAAAQWN0aW9uVGltZVN0YW1wAQEkAAMAAAAALgAAAFdoZW4gdGhlIGFjdGlv" +
           "biB0cmlnZ2VyaW5nIHRoZSBldmVudCBvY2N1cnJlZC4ALgBEJAAAAAEAJgH/////AQH/////AAAAADVg" +
           "iQoCAAAAAAAGAAAAU3RhdHVzAQElAAMAAAAAYQAAAElmIFRSVUUgdGhlIGFjdGlvbiB3YXMgcGVyZm9y" +
           "bWVkLiBJZiBGQUxTRSB0aGUgYWN0aW9uIGZhaWxlZCBhbmQgdGhlIHNlcnZlciBzdGF0ZSBkaWQgbm90" +
           "IGNoYW5nZS4ALgBEJQAAAAAB/////wEB/////wAAAAA1YIkKAgAAAAAACAAAAFNlcnZlcklkAQEmAAMA" +
           "AAAAOgAAAFRoZSB1bmlxdWUgaWRlbnRpZmllciBmb3IgdGhlIHNlcnZlciBnZW5lcmF0aW5nIHRoZSBl" +
           "dmVudC4ALgBEJgAAAAAM/////wEB/////wAAAAA1YIkKAgAAAAAAEgAAAENsaWVudEF1ZGl0RW50cnlJ" +
           "ZAEBJwADAAAAAEMAAABUaGUgbG9nIGVudHJ5IGlkIHByb3ZpZGVkIGluIHRoZSByZXF1ZXN0IHRoYXQg" +
           "aW5pdGlhdGVkIHRoZSBhY3Rpb24uAC4ARCcAAAAADP////8BAf////8AAAAANWCJCgIAAAAAAAwAAABD" +
           "bGllbnRVc2VySWQBASgAAwAAAABIAAAAVGhlIHVzZXIgaWRlbnRpdHkgYXNzb2NpYXRlZCB3aXRoIHRo" +
           "ZSBzZXNzaW9uIHRoYXQgaW5pdGlhdGVkIHRoZSBhY3Rpb24uAC4ARCgAAAAADP////8BAf////8AAAAA" +
           "FWCJCgIAAAAAAAgAAABNZXRob2RJZAEBKQAALgBEKQAAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAA" +
           "DgAAAElucHV0QXJndW1lbnRzAQEqAAAuAEQqAAAAABgBAAAAAQH/////AAAAAA==";
        #endregion
        #endif
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        #endregion

        #region Private Fields
        #endregion
    }
    #endif
    #endregion

    #region StartSigningRequestMethodState Class
    #if (!OPCUA_EXCLUDE_StartSigningRequestMethodState)
    /// <summary>
    /// Stores an instance of the StartSigningRequestMethodType Method.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class StartSigningRequestMethodState : MethodState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public StartSigningRequestMethodState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Constructs an instance of a node.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <returns>The new node.</returns>
        public new static NodeState Construct(NodeState parent)
        {
            return new StartSigningRequestMethodState(parent);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AQAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvR0RTL/////8EYYIKBAAAAAEAHQAAAFN0" +
           "YXJ0U2lnbmluZ1JlcXVlc3RNZXRob2RUeXBlAQEzAAAvAQEzADMAAAABAf////8CAAAAFWCpCgIAAAAA" +
           "AA4AAABJbnB1dEFyZ3VtZW50cwEBNAAALgBENAAAAJYEAAAAAQAqAQEcAAAADQAAAEFwcGxpY2F0aW9u" +
           "SWQAEf////8AAAAAAAEAKgEBIQAAABIAAABDZXJ0aWZpY2F0ZUdyb3VwSWQAEf////8AAAAAAAEAKgEB" +
           "IAAAABEAAABDZXJ0aWZpY2F0ZVR5cGVJZAAR/////wAAAAAAAQAqAQEhAAAAEgAAAENlcnRpZmljYXRl" +
           "UmVxdWVzdAAP/////wAAAAAAAQAoAQEAAAABAf////8AAAAAFWCpCgIAAAAAAA8AAABPdXRwdXRBcmd1" +
           "bWVudHMBATUAAC4ARDUAAACWAQAAAAEAKgEBGAAAAAkAAABSZXF1ZXN0SWQAEf////8AAAAAAAEAKAEB" +
           "AAAAAQH/////AAAAAA==";
        #endregion
        #endif
        #endregion

        #region Event Callbacks
        /// <summary>
        /// Raised when the the method is called.
        /// </summary>
        public StartSigningRequestMethodStateMethodCallHandler OnCall;
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Invokes the method, returns the result and output argument.
        /// </summary>
        /// <param name="context">The current context.</param>
        /// <param name="objectId">The id of the object.</param>
        /// <param name="inputArguments">The input arguments which have been already validated.</param>
        /// <param name="outputArguments">The output arguments which have initialized with thier default values.</param>
        /// <returns></returns>
        protected override ServiceResult Call(
            ISystemContext context,
            NodeId objectId,
            IList<object> inputArguments,
            IList<object> outputArguments)
        {
            if (OnCall == null)
            {
                return base.Call(context, objectId, inputArguments, outputArguments);
            }

            ServiceResult result = null;

            NodeId applicationId = (NodeId)inputArguments[0];
            NodeId certificateGroupId = (NodeId)inputArguments[1];
            NodeId certificateTypeId = (NodeId)inputArguments[2];
            byte[] certificateRequest = (byte[])inputArguments[3];

            NodeId requestId = (NodeId)outputArguments[0];

            if (OnCall != null)
            {
                result = OnCall(
                    context,
                    this,
                    objectId,
                    applicationId,
                    certificateGroupId,
                    certificateTypeId,
                    certificateRequest,
                    ref requestId);
            }

            outputArguments[0] = requestId;

            return result;
        }
        #endregion

        #region Private Fields
        #endregion
    }

    /// <summary>
    /// Used to receive notifications when the method is called.
    /// </summary>
    /// <exclude />
    public delegate ServiceResult StartSigningRequestMethodStateMethodCallHandler(
        ISystemContext context,
        MethodState method,
        NodeId objectId,
        NodeId applicationId,
        NodeId certificateGroupId,
        NodeId certificateTypeId,
        byte[] certificateRequest,
        ref NodeId requestId);
    #endif
    #endregion

    #region StartNewKeyPairRequestMethodState Class
    #if (!OPCUA_EXCLUDE_StartNewKeyPairRequestMethodState)
    /// <summary>
    /// Stores an instance of the StartNewKeyPairRequestMethodType Method.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class StartNewKeyPairRequestMethodState : MethodState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public StartNewKeyPairRequestMethodState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Constructs an instance of a node.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <returns>The new node.</returns>
        public new static NodeState Construct(NodeState parent)
        {
            return new StartNewKeyPairRequestMethodState(parent);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AQAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvR0RTL/////8EYYIKBAAAAAEAIAAAAFN0" +
           "YXJ0TmV3S2V5UGFpclJlcXVlc3RNZXRob2RUeXBlAQEwAAAvAQEwADAAAAABAf////8CAAAAFWCpCgIA" +
           "AAAAAA4AAABJbnB1dEFyZ3VtZW50cwEBMQAALgBEMQAAAJYHAAAAAQAqAQEcAAAADQAAAEFwcGxpY2F0" +
           "aW9uSWQAEf////8AAAAAAAEAKgEBIQAAABIAAABDZXJ0aWZpY2F0ZUdyb3VwSWQAEf////8AAAAAAAEA" +
           "KgEBIAAAABEAAABDZXJ0aWZpY2F0ZVR5cGVJZAAR/////wAAAAAAAQAqAQEaAAAACwAAAFN1YmplY3RO" +
           "YW1lAAz/////AAAAAAABACoBARoAAAALAAAARG9tYWluTmFtZXMADAEAAAAAAAAAAAEAKgEBHwAAABAA" +
           "AABQcml2YXRlS2V5Rm9ybWF0AAz/////AAAAAAABACoBASEAAAASAAAAUHJpdmF0ZUtleVBhc3N3b3Jk" +
           "AAz/////AAAAAAABACgBAQAAAAEB/////wAAAAAVYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEB" +
           "MgAALgBEMgAAAJYBAAAAAQAqAQEYAAAACQAAAFJlcXVlc3RJZAAR/////wAAAAAAAQAoAQEAAAABAf//" +
           "//8AAAAA";
        #endregion
        #endif
        #endregion

        #region Event Callbacks
        /// <summary>
        /// Raised when the the method is called.
        /// </summary>
        public StartNewKeyPairRequestMethodStateMethodCallHandler OnCall;
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Invokes the method, returns the result and output argument.
        /// </summary>
        /// <param name="context">The current context.</param>
        /// <param name="objectId">The id of the object.</param>
        /// <param name="inputArguments">The input arguments which have been already validated.</param>
        /// <param name="outputArguments">The output arguments which have initialized with thier default values.</param>
        /// <returns></returns>
        protected override ServiceResult Call(
            ISystemContext context,
            NodeId objectId,
            IList<object> inputArguments,
            IList<object> outputArguments)
        {
            if (OnCall == null)
            {
                return base.Call(context, objectId, inputArguments, outputArguments);
            }

            ServiceResult result = null;

            NodeId applicationId = (NodeId)inputArguments[0];
            NodeId certificateGroupId = (NodeId)inputArguments[1];
            NodeId certificateTypeId = (NodeId)inputArguments[2];
            string subjectName = (string)inputArguments[3];
            string[] domainNames = (string[])inputArguments[4];
            string privateKeyFormat = (string)inputArguments[5];
            string privateKeyPassword = (string)inputArguments[6];

            NodeId requestId = (NodeId)outputArguments[0];

            if (OnCall != null)
            {
                result = OnCall(
                    context,
                    this,
                    objectId,
                    applicationId,
                    certificateGroupId,
                    certificateTypeId,
                    subjectName,
                    domainNames,
                    privateKeyFormat,
                    privateKeyPassword,
                    ref requestId);
            }

            outputArguments[0] = requestId;

            return result;
        }
        #endregion

        #region Private Fields
        #endregion
    }

    /// <summary>
    /// Used to receive notifications when the method is called.
    /// </summary>
    /// <exclude />
    public delegate ServiceResult StartNewKeyPairRequestMethodStateMethodCallHandler(
        ISystemContext context,
        MethodState method,
        NodeId objectId,
        NodeId applicationId,
        NodeId certificateGroupId,
        NodeId certificateTypeId,
        string subjectName,
        string[] domainNames,
        string privateKeyFormat,
        string privateKeyPassword,
        ref NodeId requestId);
    #endif
    #endregion

    #region FinishRequestMethodState Class
    #if (!OPCUA_EXCLUDE_FinishRequestMethodState)
    /// <summary>
    /// Stores an instance of the FinishRequestMethodType Method.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class FinishRequestMethodState : MethodState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public FinishRequestMethodState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Constructs an instance of a node.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <returns>The new node.</returns>
        public new static NodeState Construct(NodeState parent)
        {
            return new FinishRequestMethodState(parent);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AQAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvR0RTL/////8EYYIKBAAAAAEAFwAAAEZp" +
           "bmlzaFJlcXVlc3RNZXRob2RUeXBlAQE5AAAvAQE5ADkAAAABAf////8CAAAAFWCpCgIAAAAAAA4AAABJ" +
           "bnB1dEFyZ3VtZW50cwEBOgAALgBEOgAAAJYCAAAAAQAqAQEcAAAADQAAAEFwcGxpY2F0aW9uSWQAEf//" +
           "//8AAAAAAAEAKgEBGAAAAAkAAABSZXF1ZXN0SWQAEf////8AAAAAAAEAKAEBAAAAAQH/////AAAAABVg" +
           "qQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQE7AAAuAEQ7AAAAlgMAAAABACoBARoAAAALAAAAQ2Vy" +
           "dGlmaWNhdGUAD/////8AAAAAAAEAKgEBGQAAAAoAAABQcml2YXRlS2V5AA//////AAAAAAABACoBASEA" +
           "AAASAAAASXNzdWVyQ2VydGlmaWNhdGVzAA8BAAAAAAAAAAABACgBAQAAAAEB/////wAAAAA=";
        #endregion
        #endif
        #endregion

        #region Event Callbacks
        /// <summary>
        /// Raised when the the method is called.
        /// </summary>
        public FinishRequestMethodStateMethodCallHandler OnCall;
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Invokes the method, returns the result and output argument.
        /// </summary>
        /// <param name="context">The current context.</param>
        /// <param name="objectId">The id of the object.</param>
        /// <param name="inputArguments">The input arguments which have been already validated.</param>
        /// <param name="outputArguments">The output arguments which have initialized with thier default values.</param>
        /// <returns></returns>
        protected override ServiceResult Call(
            ISystemContext context,
            NodeId objectId,
            IList<object> inputArguments,
            IList<object> outputArguments)
        {
            if (OnCall == null)
            {
                return base.Call(context, objectId, inputArguments, outputArguments);
            }

            ServiceResult result = null;

            NodeId applicationId = (NodeId)inputArguments[0];
            NodeId requestId = (NodeId)inputArguments[1];

            byte[] certificate = (byte[])outputArguments[0];
            byte[] privateKey = (byte[])outputArguments[1];
            byte[][] issuerCertificates = (byte[][])outputArguments[2];

            if (OnCall != null)
            {
                result = OnCall(
                    context,
                    this,
                    objectId,
                    applicationId,
                    requestId,
                    ref certificate,
                    ref privateKey,
                    ref issuerCertificates);
            }

            outputArguments[0] = certificate;
            outputArguments[1] = privateKey;
            outputArguments[2] = issuerCertificates;

            return result;
        }
        #endregion

        #region Private Fields
        #endregion
    }

    /// <summary>
    /// Used to receive notifications when the method is called.
    /// </summary>
    /// <exclude />
    public delegate ServiceResult FinishRequestMethodStateMethodCallHandler(
        ISystemContext context,
        MethodState method,
        NodeId objectId,
        NodeId applicationId,
        NodeId requestId,
        ref byte[] certificate,
        ref byte[] privateKey,
        ref byte[][] issuerCertificates);
    #endif
    #endregion

    #region GetCertificateGroupsMethodState Class
    #if (!OPCUA_EXCLUDE_GetCertificateGroupsMethodState)
    /// <summary>
    /// Stores an instance of the GetCertificateGroupsMethodType Method.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class GetCertificateGroupsMethodState : MethodState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public GetCertificateGroupsMethodState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Constructs an instance of a node.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <returns>The new node.</returns>
        public new static NodeState Construct(NodeState parent)
        {
            return new GetCertificateGroupsMethodState(parent);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AQAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvR0RTL/////8EYYIKBAAAAAEAHgAAAEdl" +
           "dENlcnRpZmljYXRlR3JvdXBzTWV0aG9kVHlwZQEB5gAALwEB5gDmAAAAAQH/////AgAAABVgqQoCAAAA" +
           "AAAOAAAASW5wdXRBcmd1bWVudHMBAecAAC4AROcAAACWAQAAAAEAKgEBHAAAAA0AAABBcHBsaWNhdGlv" +
           "bklkABH/////AAAAAAABACgBAQAAAAEB/////wAAAAAVYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50" +
           "cwEB6AAALgBE6AAAAJYBAAAAAQAqAQEiAAAAEwAAAENlcnRpZmljYXRlR3JvdXBJZHMAEQEAAAAAAAAA" +
           "AAEAKAEBAAAAAQH/////AAAAAA==";
        #endregion
        #endif
        #endregion

        #region Event Callbacks
        /// <summary>
        /// Raised when the the method is called.
        /// </summary>
        public GetCertificateGroupsMethodStateMethodCallHandler OnCall;
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Invokes the method, returns the result and output argument.
        /// </summary>
        /// <param name="context">The current context.</param>
        /// <param name="objectId">The id of the object.</param>
        /// <param name="inputArguments">The input arguments which have been already validated.</param>
        /// <param name="outputArguments">The output arguments which have initialized with thier default values.</param>
        /// <returns></returns>
        protected override ServiceResult Call(
            ISystemContext context,
            NodeId objectId,
            IList<object> inputArguments,
            IList<object> outputArguments)
        {
            if (OnCall == null)
            {
                return base.Call(context, objectId, inputArguments, outputArguments);
            }

            ServiceResult result = null;

            NodeId applicationId = (NodeId)inputArguments[0];

            NodeId[] certificateGroupIds = (NodeId[])outputArguments[0];

            if (OnCall != null)
            {
                result = OnCall(
                    context,
                    this,
                    objectId,
                    applicationId,
                    ref certificateGroupIds);
            }

            outputArguments[0] = certificateGroupIds;

            return result;
        }
        #endregion

        #region Private Fields
        #endregion
    }

    /// <summary>
    /// Used to receive notifications when the method is called.
    /// </summary>
    /// <exclude />
    public delegate ServiceResult GetCertificateGroupsMethodStateMethodCallHandler(
        ISystemContext context,
        MethodState method,
        NodeId objectId,
        NodeId applicationId,
        ref NodeId[] certificateGroupIds);
    #endif
    #endregion

    #region GetTrustListMethodState Class
    #if (!OPCUA_EXCLUDE_GetTrustListMethodState)
    /// <summary>
    /// Stores an instance of the GetTrustListMethodType Method.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class GetTrustListMethodState : MethodState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public GetTrustListMethodState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Constructs an instance of a node.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <returns>The new node.</returns>
        public new static NodeState Construct(NodeState parent)
        {
            return new GetTrustListMethodState(parent);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AQAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvR0RTL/////8EYYIKBAAAAAEAFgAAAEdl" +
           "dFRydXN0TGlzdE1ldGhvZFR5cGUBAb4AAC8BAb4AvgAAAAEB/////wIAAAAVYKkKAgAAAAAADgAAAElu" +
           "cHV0QXJndW1lbnRzAQG/AAAuAES/AAAAlgIAAAABACoBARwAAAANAAAAQXBwbGljYXRpb25JZAAR////" +
           "/wAAAAAAAQAqAQEhAAAAEgAAAENlcnRpZmljYXRlR3JvdXBJZAAR/////wAAAAAAAQAoAQEAAAABAf//" +
           "//8AAAAAFWCpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAcAAAC4ARMAAAACWAQAAAAEAKgEBGgAA" +
           "AAsAAABUcnVzdExpc3RJZAAR/////wAAAAAAAQAoAQEAAAABAf////8AAAAA";
        #endregion
        #endif
        #endregion

        #region Event Callbacks
        /// <summary>
        /// Raised when the the method is called.
        /// </summary>
        public GetTrustListMethodStateMethodCallHandler OnCall;
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Invokes the method, returns the result and output argument.
        /// </summary>
        /// <param name="context">The current context.</param>
        /// <param name="objectId">The id of the object.</param>
        /// <param name="inputArguments">The input arguments which have been already validated.</param>
        /// <param name="outputArguments">The output arguments which have initialized with thier default values.</param>
        /// <returns></returns>
        protected override ServiceResult Call(
            ISystemContext context,
            NodeId objectId,
            IList<object> inputArguments,
            IList<object> outputArguments)
        {
            if (OnCall == null)
            {
                return base.Call(context, objectId, inputArguments, outputArguments);
            }

            ServiceResult result = null;

            NodeId applicationId = (NodeId)inputArguments[0];
            NodeId certificateGroupId = (NodeId)inputArguments[1];

            NodeId trustListId = (NodeId)outputArguments[0];

            if (OnCall != null)
            {
                result = OnCall(
                    context,
                    this,
                    objectId,
                    applicationId,
                    certificateGroupId,
                    ref trustListId);
            }

            outputArguments[0] = trustListId;

            return result;
        }
        #endregion

        #region Private Fields
        #endregion
    }

    /// <summary>
    /// Used to receive notifications when the method is called.
    /// </summary>
    /// <exclude />
    public delegate ServiceResult GetTrustListMethodStateMethodCallHandler(
        ISystemContext context,
        MethodState method,
        NodeId objectId,
        NodeId applicationId,
        NodeId certificateGroupId,
        ref NodeId trustListId);
    #endif
    #endregion

    #region GetCertificateStatusMethodState Class
    #if (!OPCUA_EXCLUDE_GetCertificateStatusMethodState)
    /// <summary>
    /// Stores an instance of the GetCertificateStatusMethodType Method.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class GetCertificateStatusMethodState : MethodState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public GetCertificateStatusMethodState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Constructs an instance of a node.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <returns>The new node.</returns>
        public new static NodeState Construct(NodeState parent)
        {
            return new GetCertificateStatusMethodState(parent);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AQAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvR0RTL/////8EYYIKBAAAAAEAHgAAAEdl" +
           "dENlcnRpZmljYXRlU3RhdHVzTWV0aG9kVHlwZQEB2wAALwEB2wDbAAAAAQH/////AgAAABVgqQoCAAAA" +
           "AAAOAAAASW5wdXRBcmd1bWVudHMBAdwAAC4ARNwAAACWAwAAAAEAKgEBHAAAAA0AAABBcHBsaWNhdGlv" +
           "bklkABH/////AAAAAAABACoBASEAAAASAAAAQ2VydGlmaWNhdGVHcm91cElkABH/////AAAAAAABACoB" +
           "ASAAAAARAAAAQ2VydGlmaWNhdGVUeXBlSWQAEf////8AAAAAAAEAKAEBAAAAAQH/////AAAAABVgqQoC" +
           "AAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQHdAAAuAETdAAAAlgEAAAABACoBAR0AAAAOAAAAVXBkYXRl" +
           "UmVxdWlyZWQAAf////8AAAAAAAEAKAEBAAAAAQH/////AAAAAA==";
        #endregion
        #endif
        #endregion

        #region Event Callbacks
        /// <summary>
        /// Raised when the the method is called.
        /// </summary>
        public GetCertificateStatusMethodStateMethodCallHandler OnCall;
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Invokes the method, returns the result and output argument.
        /// </summary>
        /// <param name="context">The current context.</param>
        /// <param name="objectId">The id of the object.</param>
        /// <param name="inputArguments">The input arguments which have been already validated.</param>
        /// <param name="outputArguments">The output arguments which have initialized with thier default values.</param>
        /// <returns></returns>
        protected override ServiceResult Call(
            ISystemContext context,
            NodeId objectId,
            IList<object> inputArguments,
            IList<object> outputArguments)
        {
            if (OnCall == null)
            {
                return base.Call(context, objectId, inputArguments, outputArguments);
            }

            ServiceResult result = null;

            NodeId applicationId = (NodeId)inputArguments[0];
            NodeId certificateGroupId = (NodeId)inputArguments[1];
            NodeId certificateTypeId = (NodeId)inputArguments[2];

            bool updateRequired = (bool)outputArguments[0];

            if (OnCall != null)
            {
                result = OnCall(
                    context,
                    this,
                    objectId,
                    applicationId,
                    certificateGroupId,
                    certificateTypeId,
                    ref updateRequired);
            }

            outputArguments[0] = updateRequired;

            return result;
        }
        #endregion

        #region Private Fields
        #endregion
    }

    /// <summary>
    /// Used to receive notifications when the method is called.
    /// </summary>
    /// <exclude />
    public delegate ServiceResult GetCertificateStatusMethodStateMethodCallHandler(
        ISystemContext context,
        MethodState method,
        NodeId objectId,
        NodeId applicationId,
        NodeId certificateGroupId,
        NodeId certificateTypeId,
        ref bool updateRequired);
    #endif
    #endregion

    #region CertificateDirectoryState Class
    #if (!OPCUA_EXCLUDE_CertificateDirectoryState)
    /// <summary>
    /// Stores an instance of the CertificateDirectoryType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class CertificateDirectoryState : DirectoryState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public CertificateDirectoryState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.Gds.ObjectTypes.CertificateDirectoryType, Opc.Ua.Gds.Namespaces.OpcUaGds, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AQAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvR0RTL/////8EYIAAAQAAAAEAIAAAAENl" +
           "cnRpZmljYXRlRGlyZWN0b3J5VHlwZUluc3RhbmNlAQE/AAEBPwD/////DgAAAARggAoBAAAAAQAMAAAA" +
           "QXBwbGljYXRpb25zAQFAAAAvAD1AAAAA/////wAAAAAEYYIKBAAAAAEAEAAAAEZpbmRBcHBsaWNhdGlv" +
           "bnMBAUEAAC8BAQ8AQQAAAAEB/////wIAAAAVYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQFCAAAu" +
           "AERCAAAAlgEAAAABACoBAR0AAAAOAAAAQXBwbGljYXRpb25VcmkADP////8AAAAAAAEAKAEBAAAAAQH/" +
           "////AAAAABVgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQFDAAAuAERDAAAAlgEAAAABACoBAR0A" +
           "AAAMAAAAQXBwbGljYXRpb25zAQEBAAEAAAAAAAAAAAEAKAEBAAAAAQH/////AAAAAARhggoEAAAAAQAT" +
           "AAAAUmVnaXN0ZXJBcHBsaWNhdGlvbgEBRAAALwEBEgBEAAAAAQH/////AgAAABVgqQoCAAAAAAAOAAAA" +
           "SW5wdXRBcmd1bWVudHMBAUUAAC4AREUAAACWAQAAAAEAKgEBHAAAAAsAAABBcHBsaWNhdGlvbgEBAQD/" +
           "////AAAAAAABACgBAQAAAAEB/////wAAAAAVYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEBRgAA" +
           "LgBERgAAAJYBAAAAAQAqAQEcAAAADQAAAEFwcGxpY2F0aW9uSWQAEf////8AAAAAAAEAKAEBAAAAAQH/" +
           "////AAAAAARhggoEAAAAAQARAAAAVXBkYXRlQXBwbGljYXRpb24BAcEAAC8BAbwAwQAAAAEB/////wEA" +
           "AAAVYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQHCAAAuAETCAAAAlgEAAAABACoBARwAAAALAAAA" +
           "QXBwbGljYXRpb24BAQEA/////wAAAAAAAQAoAQEAAAABAf////8AAAAABGGCCgQAAAABABUAAABVbnJl" +
           "Z2lzdGVyQXBwbGljYXRpb24BAUcAAC8BARUARwAAAAEB/////wEAAAAVYKkKAgAAAAAADgAAAElucHV0" +
           "QXJndW1lbnRzAQFIAAAuAERIAAAAlgEAAAABACoBARwAAAANAAAAQXBwbGljYXRpb25JZAAR/////wAA" +
           "AAAAAQAoAQEAAAABAf////8AAAAABGGCCgQAAAABAA4AAABHZXRBcHBsaWNhdGlvbgEB1QAALwEB0gDV" +
           "AAAAAQH/////AgAAABVgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAdYAAC4ARNYAAACWAQAAAAEA" +
           "KgEBHAAAAA0AAABBcHBsaWNhdGlvbklkABH/////AAAAAAABACgBAQAAAAEB/////wAAAAAVYKkKAgAA" +
           "AAAADwAAAE91dHB1dEFyZ3VtZW50cwEB1wAALgBE1wAAAJYBAAAAAQAqAQEcAAAACwAAAEFwcGxpY2F0" +
           "aW9uAQEBAP////8AAAAAAAEAKAEBAAAAAQH/////AAAAAARhggoEAAAAAQAMAAAAUXVlcnlTZXJ2ZXJz" +
           "AQFJAAAvAQEXAEkAAAABAf////8CAAAAFWCpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEBSgAALgBE" +
           "SgAAAJYGAAAAAQAqAQEfAAAAEAAAAFN0YXJ0aW5nUmVjb3JkSWQAB/////8AAAAAAAEAKgEBIQAAABIA" +
           "AABNYXhSZWNvcmRzVG9SZXR1cm4AB/////8AAAAAAAEAKgEBHgAAAA8AAABBcHBsaWNhdGlvbk5hbWUA" +
           "DP////8AAAAAAAEAKgEBHQAAAA4AAABBcHBsaWNhdGlvblVyaQAM/////wAAAAAAAQAqAQEZAAAACgAA" +
           "AFByb2R1Y3RVcmkADP////8AAAAAAAEAKgEBIQAAABIAAABTZXJ2ZXJDYXBhYmlsaXRpZXMADAEAAAAA" +
           "AAAAAAEAKAEBAAAAAQH/////AAAAABVgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQFLAAAuAERL" +
           "AAAAlgIAAAABACoBASUAAAAUAAAATGFzdENvdW50ZXJSZXNldFRpbWUBACYB/////wAAAAAAAQAqAQEY" +
           "AAAABwAAAFNlcnZlcnMBAJ0vAQAAAAAAAAAAAQAoAQEAAAABAf////8AAAAABGCACgEAAAABABEAAABD" +
           "ZXJ0aWZpY2F0ZUdyb3VwcwEB/wEAIwEA9TX/AQAA/////wEAAAAEYIAKAQAAAAAAFwAAAERlZmF1bHRB" +
           "cHBsaWNhdGlvbkdyb3VwAQEAAgAvAQALMQACAAD/////AgAAAARggAoBAAAAAAAJAAAAVHJ1c3RMaXN0" +
           "AQEBAgAvAQDqMAECAAD/////DAAAADVgiQoCAAAAAAAEAAAAU2l6ZQEBAgIDAAAAAB4AAABUaGUgc2l6" +
           "ZSBvZiB0aGUgZmlsZSBpbiBieXRlcy4ALgBEAgIAAAAJ/////wEB/////wAAAAA1YIkKAgAAAAAACAAA" +
           "AFdyaXRhYmxlAQEDAgMAAAAAHQAAAFdoZXRoZXIgdGhlIGZpbGUgaXMgd3JpdGFibGUuAC4ARAMCAAAA" +
           "Af////8BAf////8AAAAANWCJCgIAAAAAAAwAAABVc2VyV3JpdGFibGUBAQQCAwAAAAAxAAAAV2hldGhl" +
           "ciB0aGUgZmlsZSBpcyB3cml0YWJsZSBieSB0aGUgY3VycmVudCB1c2VyLgAuAEQEAgAAAAH/////AQH/" +
           "////AAAAADVgiQoCAAAAAAAJAAAAT3BlbkNvdW50AQEFAgMAAAAAKAAAAFRoZSBjdXJyZW50IG51bWJl" +
           "ciBvZiBvcGVuIGZpbGUgaGFuZGxlcy4ALgBEBQIAAAAF/////wEB/////wAAAAAEYYIKBAAAAAAABAAA" +
           "AE9wZW4BAQcCAC8BADwtBwIAAAEB/////wIAAAAVYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQEI" +
           "AgAuAEQIAgAAlgEAAAABACoBARMAAAAEAAAATW9kZQAD/////wAAAAAAAQAoAQEAAAABAf////8AAAAA" +
           "FWCpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAQkCAC4ARAkCAACWAQAAAAEAKgEBGQAAAAoAAABG" +
           "aWxlSGFuZGxlAAf/////AAAAAAABACgBAQAAAAEB/////wAAAAAEYYIKBAAAAAAABQAAAENsb3NlAQEK" +
           "AgAvAQA/LQoCAAABAf////8BAAAAFWCpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEBCwIALgBECwIA" +
           "AJYBAAAAAQAqAQEZAAAACgAAAEZpbGVIYW5kbGUAB/////8AAAAAAAEAKAEBAAAAAQH/////AAAAAARh" +
           "ggoEAAAAAAAEAAAAUmVhZAEBDAIALwEAQS0MAgAAAQH/////AgAAABVgqQoCAAAAAAAOAAAASW5wdXRB" +
           "cmd1bWVudHMBAQ0CAC4ARA0CAACWAgAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxlAAf/////AAAAAAAB" +
           "ACoBARUAAAAGAAAATGVuZ3RoAAb/////AAAAAAABACgBAQAAAAEB/////wAAAAAVYKkKAgAAAAAADwAA" +
           "AE91dHB1dEFyZ3VtZW50cwEBDgIALgBEDgIAAJYBAAAAAQAqAQETAAAABAAAAERhdGEAD/////8AAAAA" +
           "AAEAKAEBAAAAAQH/////AAAAAARhggoEAAAAAAAFAAAAV3JpdGUBAQ8CAC8BAEQtDwIAAAEB/////wEA" +
           "AAAVYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQEQAgAuAEQQAgAAlgIAAAABACoBARkAAAAKAAAA" +
           "RmlsZUhhbmRsZQAH/////wAAAAAAAQAqAQETAAAABAAAAERhdGEAD/////8AAAAAAAEAKAEBAAAAAQH/" +
           "////AAAAAARhggoEAAAAAAALAAAAR2V0UG9zaXRpb24BARECAC8BAEYtEQIAAAEB/////wIAAAAVYKkK" +
           "AgAAAAAADgAAAElucHV0QXJndW1lbnRzAQESAgAuAEQSAgAAlgEAAAABACoBARkAAAAKAAAARmlsZUhh" +
           "bmRsZQAH/////wAAAAAAAQAoAQEAAAABAf////8AAAAAFWCpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVu" +
           "dHMBARMCAC4ARBMCAACWAQAAAAEAKgEBFwAAAAgAAABQb3NpdGlvbgAJ/////wAAAAAAAQAoAQEAAAAB" +
           "Af////8AAAAABGGCCgQAAAAAAAsAAABTZXRQb3NpdGlvbgEBFAIALwEASS0UAgAAAQH/////AQAAABVg" +
           "qQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBARUCAC4ARBUCAACWAgAAAAEAKgEBGQAAAAoAAABGaWxl" +
           "SGFuZGxlAAf/////AAAAAAABACoBARcAAAAIAAAAUG9zaXRpb24ACf////8AAAAAAAEAKAEBAAAAAQH/" +
           "////AAAAABVgiQoCAAAAAAAOAAAATGFzdFVwZGF0ZVRpbWUBARYCAC4ARBYCAAABACYB/////wEB////" +
           "/wAAAAAEYYIKBAAAAAAADQAAAE9wZW5XaXRoTWFza3MBARcCAC8BAP8wFwIAAAEB/////wIAAAAVYKkK" +
           "AgAAAAAADgAAAElucHV0QXJndW1lbnRzAQEYAgAuAEQYAgAAlgEAAAABACoBARQAAAAFAAAATWFza3MA" +
           "B/////8AAAAAAAEAKAEBAAAAAQH/////AAAAABVgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQEZ" +
           "AgAuAEQZAgAAlgEAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAoAQEAAAABAf//" +
           "//8AAAAAFWCJCgIAAAAAABAAAABDZXJ0aWZpY2F0ZVR5cGVzAQEhAgAuAEQhAgAAABEBAAAAAQH/////" +
           "AAAAAARhggoEAAAAAQATAAAAU3RhcnRTaWduaW5nUmVxdWVzdAEBTwAALwEBTwBPAAAAAQH/////AgAA" +
           "ABVgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAVAAAC4ARFAAAACWBAAAAAEAKgEBHAAAAA0AAABB" +
           "cHBsaWNhdGlvbklkABH/////AAAAAAABACoBASEAAAASAAAAQ2VydGlmaWNhdGVHcm91cElkABH/////" +
           "AAAAAAABACoBASAAAAARAAAAQ2VydGlmaWNhdGVUeXBlSWQAEf////8AAAAAAAEAKgEBIQAAABIAAABD" +
           "ZXJ0aWZpY2F0ZVJlcXVlc3QAD/////8AAAAAAAEAKAEBAAAAAQH/////AAAAABVgqQoCAAAAAAAPAAAA" +
           "T3V0cHV0QXJndW1lbnRzAQFRAAAuAERRAAAAlgEAAAABACoBARgAAAAJAAAAUmVxdWVzdElkABH/////" +
           "AAAAAAABACgBAQAAAAEB/////wAAAAAEYYIKBAAAAAEAFgAAAFN0YXJ0TmV3S2V5UGFpclJlcXVlc3QB" +
           "AUwAAC8BAUwATAAAAAEB/////wIAAAAVYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQFNAAAuAERN" +
           "AAAAlgcAAAABACoBARwAAAANAAAAQXBwbGljYXRpb25JZAAR/////wAAAAAAAQAqAQEhAAAAEgAAAENl" +
           "cnRpZmljYXRlR3JvdXBJZAAR/////wAAAAAAAQAqAQEgAAAAEQAAAENlcnRpZmljYXRlVHlwZUlkABH/" +
           "////AAAAAAABACoBARoAAAALAAAAU3ViamVjdE5hbWUADP////8AAAAAAAEAKgEBGgAAAAsAAABEb21h" +
           "aW5OYW1lcwAMAQAAAAAAAAAAAQAqAQEfAAAAEAAAAFByaXZhdGVLZXlGb3JtYXQADP////8AAAAAAAEA" +
           "KgEBIQAAABIAAABQcml2YXRlS2V5UGFzc3dvcmQADP////8AAAAAAAEAKAEBAAAAAQH/////AAAAABVg" +
           "qQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQFOAAAuAEROAAAAlgEAAAABACoBARgAAAAJAAAAUmVx" +
           "dWVzdElkABH/////AAAAAAABACgBAQAAAAEB/////wAAAAAEYYIKBAAAAAEADQAAAEZpbmlzaFJlcXVl" +
           "c3QBAVUAAC8BAVUAVQAAAAEB/////wIAAAAVYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQFWAAAu" +
           "AERWAAAAlgIAAAABACoBARwAAAANAAAAQXBwbGljYXRpb25JZAAR/////wAAAAAAAQAqAQEYAAAACQAA" +
           "AFJlcXVlc3RJZAAR/////wAAAAAAAQAoAQEAAAABAf////8AAAAAFWCpCgIAAAAAAA8AAABPdXRwdXRB" +
           "cmd1bWVudHMBAVcAAC4ARFcAAACWAwAAAAEAKgEBGgAAAAsAAABDZXJ0aWZpY2F0ZQAP/////wAAAAAA" +
           "AQAqAQEZAAAACgAAAFByaXZhdGVLZXkAD/////8AAAAAAAEAKgEBIQAAABIAAABJc3N1ZXJDZXJ0aWZp" +
           "Y2F0ZXMADwEAAAAAAAAAAAEAKAEBAAAAAQH/////AAAAAARhggoEAAAAAQAUAAAAR2V0Q2VydGlmaWNh" +
           "dGVHcm91cHMBAXEBAC8BAXEBcQEAAAEB/////wIAAAAVYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRz" +
           "AQFyAQAuAERyAQAAlgEAAAABACoBARwAAAANAAAAQXBwbGljYXRpb25JZAAR/////wAAAAAAAQAoAQEA" +
           "AAABAf////8AAAAAFWCpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAXMBAC4ARHMBAACWAQAAAAEA" +
           "KgEBIgAAABMAAABDZXJ0aWZpY2F0ZUdyb3VwSWRzABEBAAAAAAAAAAABACgBAQAAAAEB/////wAAAAAE" +
           "YYIKBAAAAAEADAAAAEdldFRydXN0TGlzdAEBxQAALwEBxQDFAAAAAQH/////AgAAABVgqQoCAAAAAAAO" +
           "AAAASW5wdXRBcmd1bWVudHMBAcYAAC4ARMYAAACWAgAAAAEAKgEBHAAAAA0AAABBcHBsaWNhdGlvbklk" +
           "ABH/////AAAAAAABACoBASEAAAASAAAAQ2VydGlmaWNhdGVHcm91cElkABH/////AAAAAAABACgBAQAA" +
           "AAEB/////wAAAAAVYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEBxwAALgBExwAAAJYBAAAAAQAq" +
           "AQEaAAAACwAAAFRydXN0TGlzdElkABH/////AAAAAAABACgBAQAAAAEB/////wAAAAAEYYIKBAAAAAEA" +
           "FAAAAEdldENlcnRpZmljYXRlU3RhdHVzAQHeAAAvAQHeAN4AAAABAf////8CAAAAFWCpCgIAAAAAAA4A" +
           "AABJbnB1dEFyZ3VtZW50cwEB3wAALgBE3wAAAJYDAAAAAQAqAQEcAAAADQAAAEFwcGxpY2F0aW9uSWQA" +
           "Ef////8AAAAAAAEAKgEBIQAAABIAAABDZXJ0aWZpY2F0ZUdyb3VwSWQAEf////8AAAAAAAEAKgEBIAAA" +
           "ABEAAABDZXJ0aWZpY2F0ZVR5cGVJZAAR/////wAAAAAAAQAoAQEAAAABAf////8AAAAAFWCpCgIAAAAA" +
           "AA8AAABPdXRwdXRBcmd1bWVudHMBAeAAAC4AROAAAACWAQAAAAEAKgEBHQAAAA4AAABVcGRhdGVSZXF1" +
           "aXJlZAAB/////wAAAAAAAQAoAQEAAAABAf////8AAAAA";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// A description for the CertificateGroups Object.
        /// </summary>
        public CertificateGroupFolderState CertificateGroups
        {
            get
            {
                return m_certificateGroups;
            }

            set
            {
                if (!Object.ReferenceEquals(m_certificateGroups, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_certificateGroups = value;
            }
        }

        /// <summary>
        /// A description for the StartSigningRequestMethodType Method.
        /// </summary>
        public StartSigningRequestMethodState StartSigningRequest
        {
            get
            {
                return m_startSigningRequestMethod;
            }

            set
            {
                if (!Object.ReferenceEquals(m_startSigningRequestMethod, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_startSigningRequestMethod = value;
            }
        }

        /// <summary>
        /// A description for the StartNewKeyPairRequestMethodType Method.
        /// </summary>
        public StartNewKeyPairRequestMethodState StartNewKeyPairRequest
        {
            get
            {
                return m_startNewKeyPairRequestMethod;
            }

            set
            {
                if (!Object.ReferenceEquals(m_startNewKeyPairRequestMethod, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_startNewKeyPairRequestMethod = value;
            }
        }

        /// <summary>
        /// A description for the FinishRequestMethodType Method.
        /// </summary>
        public FinishRequestMethodState FinishRequest
        {
            get
            {
                return m_finishRequestMethod;
            }

            set
            {
                if (!Object.ReferenceEquals(m_finishRequestMethod, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_finishRequestMethod = value;
            }
        }

        /// <summary>
        /// A description for the GetCertificateGroupsMethodType Method.
        /// </summary>
        public GetCertificateGroupsMethodState GetCertificateGroups
        {
            get
            {
                return m_getCertificateGroupsMethod;
            }

            set
            {
                if (!Object.ReferenceEquals(m_getCertificateGroupsMethod, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_getCertificateGroupsMethod = value;
            }
        }

        /// <summary>
        /// A description for the GetTrustListMethodType Method.
        /// </summary>
        public GetTrustListMethodState GetTrustList
        {
            get
            {
                return m_getTrustListMethod;
            }

            set
            {
                if (!Object.ReferenceEquals(m_getTrustListMethod, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_getTrustListMethod = value;
            }
        }

        /// <summary>
        /// A description for the GetCertificateStatusMethodType Method.
        /// </summary>
        public GetCertificateStatusMethodState GetCertificateStatus
        {
            get
            {
                return m_getCertificateStatusMethod;
            }

            set
            {
                if (!Object.ReferenceEquals(m_getCertificateStatusMethod, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_getCertificateStatusMethod = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_certificateGroups != null)
            {
                children.Add(m_certificateGroups);
            }

            if (m_startSigningRequestMethod != null)
            {
                children.Add(m_startSigningRequestMethod);
            }

            if (m_startNewKeyPairRequestMethod != null)
            {
                children.Add(m_startNewKeyPairRequestMethod);
            }

            if (m_finishRequestMethod != null)
            {
                children.Add(m_finishRequestMethod);
            }

            if (m_getCertificateGroupsMethod != null)
            {
                children.Add(m_getCertificateGroupsMethod);
            }

            if (m_getTrustListMethod != null)
            {
                children.Add(m_getTrustListMethod);
            }

            if (m_getCertificateStatusMethod != null)
            {
                children.Add(m_getCertificateStatusMethod);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case Opc.Ua.Gds.BrowseNames.CertificateGroups:
                {
                    if (createOrReplace)
                    {
                        if (CertificateGroups == null)
                        {
                            if (replacement == null)
                            {
                                CertificateGroups = new CertificateGroupFolderState(this);
                            }
                            else
                            {
                                CertificateGroups = (CertificateGroupFolderState)replacement;
                            }
                        }
                    }

                    instance = CertificateGroups;
                    break;
                }

                case Opc.Ua.Gds.BrowseNames.StartSigningRequest:
                {
                    if (createOrReplace)
                    {
                        if (StartSigningRequest == null)
                        {
                            if (replacement == null)
                            {
                                StartSigningRequest = new StartSigningRequestMethodState(this);
                            }
                            else
                            {
                                StartSigningRequest = (StartSigningRequestMethodState)replacement;
                            }
                        }
                    }

                    instance = StartSigningRequest;
                    break;
                }

                case Opc.Ua.Gds.BrowseNames.StartNewKeyPairRequest:
                {
                    if (createOrReplace)
                    {
                        if (StartNewKeyPairRequest == null)
                        {
                            if (replacement == null)
                            {
                                StartNewKeyPairRequest = new StartNewKeyPairRequestMethodState(this);
                            }
                            else
                            {
                                StartNewKeyPairRequest = (StartNewKeyPairRequestMethodState)replacement;
                            }
                        }
                    }

                    instance = StartNewKeyPairRequest;
                    break;
                }

                case Opc.Ua.Gds.BrowseNames.FinishRequest:
                {
                    if (createOrReplace)
                    {
                        if (FinishRequest == null)
                        {
                            if (replacement == null)
                            {
                                FinishRequest = new FinishRequestMethodState(this);
                            }
                            else
                            {
                                FinishRequest = (FinishRequestMethodState)replacement;
                            }
                        }
                    }

                    instance = FinishRequest;
                    break;
                }

                case Opc.Ua.Gds.BrowseNames.GetCertificateGroups:
                {
                    if (createOrReplace)
                    {
                        if (GetCertificateGroups == null)
                        {
                            if (replacement == null)
                            {
                                GetCertificateGroups = new GetCertificateGroupsMethodState(this);
                            }
                            else
                            {
                                GetCertificateGroups = (GetCertificateGroupsMethodState)replacement;
                            }
                        }
                    }

                    instance = GetCertificateGroups;
                    break;
                }

                case Opc.Ua.Gds.BrowseNames.GetTrustList:
                {
                    if (createOrReplace)
                    {
                        if (GetTrustList == null)
                        {
                            if (replacement == null)
                            {
                                GetTrustList = new GetTrustListMethodState(this);
                            }
                            else
                            {
                                GetTrustList = (GetTrustListMethodState)replacement;
                            }
                        }
                    }

                    instance = GetTrustList;
                    break;
                }

                case Opc.Ua.Gds.BrowseNames.GetCertificateStatus:
                {
                    if (createOrReplace)
                    {
                        if (GetCertificateStatus == null)
                        {
                            if (replacement == null)
                            {
                                GetCertificateStatus = new GetCertificateStatusMethodState(this);
                            }
                            else
                            {
                                GetCertificateStatus = (GetCertificateStatusMethodState)replacement;
                            }
                        }
                    }

                    instance = GetCertificateStatus;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private CertificateGroupFolderState m_certificateGroups;
        private StartSigningRequestMethodState m_startSigningRequestMethod;
        private StartNewKeyPairRequestMethodState m_startNewKeyPairRequestMethod;
        private FinishRequestMethodState m_finishRequestMethod;
        private GetCertificateGroupsMethodState m_getCertificateGroupsMethod;
        private GetTrustListMethodState m_getTrustListMethod;
        private GetCertificateStatusMethodState m_getCertificateStatusMethod;
        #endregion
    }
    #endif
    #endregion

    #region CertificateRequestedAuditEventState Class
    #if (!OPCUA_EXCLUDE_CertificateRequestedAuditEventState)
    /// <summary>
    /// Stores an instance of the CertificateRequestedAuditEventType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class CertificateRequestedAuditEventState : AuditUpdateMethodEventState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public CertificateRequestedAuditEventState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.Gds.ObjectTypes.CertificateRequestedAuditEventType, Opc.Ua.Gds.Namespaces.OpcUaGds, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AQAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvR0RTL/////8EYIAAAQAAAAEAKgAAAENl" +
           "cnRpZmljYXRlUmVxdWVzdGVkQXVkaXRFdmVudFR5cGVJbnN0YW5jZQEBWwABAVsA/////xIAAAA1YIkK" +
           "AgAAAAAABwAAAEV2ZW50SWQBAVwAAwAAAAArAAAAQSBnbG9iYWxseSB1bmlxdWUgaWRlbnRpZmllciBm" +
           "b3IgdGhlIGV2ZW50LgAuAERcAAAAAA//////AQH/////AAAAADVgiQoCAAAAAAAJAAAARXZlbnRUeXBl" +
           "AQFdAAMAAAAAIgAAAFRoZSBpZGVudGlmaWVyIGZvciB0aGUgZXZlbnQgdHlwZS4ALgBEXQAAAAAR////" +
           "/wEB/////wAAAAA1YIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBAV4AAwAAAAAYAAAAVGhlIHNvdXJjZSBv" +
           "ZiB0aGUgZXZlbnQuAC4ARF4AAAAAEf////8BAf////8AAAAANWCJCgIAAAAAAAoAAABTb3VyY2VOYW1l" +
           "AQFfAAMAAAAAKQAAAEEgZGVzY3JpcHRpb24gb2YgdGhlIHNvdXJjZSBvZiB0aGUgZXZlbnQuAC4ARF8A" +
           "AAAADP////8BAf////8AAAAANWCJCgIAAAAAAAQAAABUaW1lAQFgAAMAAAAAGAAAAFdoZW4gdGhlIGV2" +
           "ZW50IG9jY3VycmVkLgAuAERgAAAAAQAmAf////8BAf////8AAAAANWCJCgIAAAAAAAsAAABSZWNlaXZl" +
           "VGltZQEBYQADAAAAAD4AAABXaGVuIHRoZSBzZXJ2ZXIgcmVjZWl2ZWQgdGhlIGV2ZW50IGZyb20gdGhl" +
           "IHVuZGVybHlpbmcgc3lzdGVtLgAuAERhAAAAAQAmAf////8BAf////8AAAAANWCJCgIAAAAAAAkAAABM" +
           "b2NhbFRpbWUBAWIAAwAAAAA8AAAASW5mb3JtYXRpb24gYWJvdXQgdGhlIGxvY2FsIHRpbWUgd2hlcmUg" +
           "dGhlIGV2ZW50IG9yaWdpbmF0ZWQuAC4ARGIAAAABANAi/////wEB/////wAAAAA1YIkKAgAAAAAABwAA" +
           "AE1lc3NhZ2UBAWMAAwAAAAAlAAAAQSBsb2NhbGl6ZWQgZGVzY3JpcHRpb24gb2YgdGhlIGV2ZW50LgAu" +
           "AERjAAAAABX/////AQH/////AAAAADVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAWQAAwAAAAAhAAAASW5k" +
           "aWNhdGVzIGhvdyB1cmdlbnQgYW4gZXZlbnQgaXMuAC4ARGQAAAAABf////8BAf////8AAAAANWCJCgIA" +
           "AAAAAA8AAABBY3Rpb25UaW1lU3RhbXABAWUAAwAAAAAuAAAAV2hlbiB0aGUgYWN0aW9uIHRyaWdnZXJp" +
           "bmcgdGhlIGV2ZW50IG9jY3VycmVkLgAuAERlAAAAAQAmAf////8BAf////8AAAAANWCJCgIAAAAAAAYA" +
           "AABTdGF0dXMBAWYAAwAAAABhAAAASWYgVFJVRSB0aGUgYWN0aW9uIHdhcyBwZXJmb3JtZWQuIElmIEZB" +
           "TFNFIHRoZSBhY3Rpb24gZmFpbGVkIGFuZCB0aGUgc2VydmVyIHN0YXRlIGRpZCBub3QgY2hhbmdlLgAu" +
           "AERmAAAAAAH/////AQH/////AAAAADVgiQoCAAAAAAAIAAAAU2VydmVySWQBAWcAAwAAAAA6AAAAVGhl" +
           "IHVuaXF1ZSBpZGVudGlmaWVyIGZvciB0aGUgc2VydmVyIGdlbmVyYXRpbmcgdGhlIGV2ZW50LgAuAERn" +
           "AAAAAAz/////AQH/////AAAAADVgiQoCAAAAAAASAAAAQ2xpZW50QXVkaXRFbnRyeUlkAQFoAAMAAAAA" +
           "QwAAAFRoZSBsb2cgZW50cnkgaWQgcHJvdmlkZWQgaW4gdGhlIHJlcXVlc3QgdGhhdCBpbml0aWF0ZWQg" +
           "dGhlIGFjdGlvbi4ALgBEaAAAAAAM/////wEB/////wAAAAA1YIkKAgAAAAAADAAAAENsaWVudFVzZXJJ" +
           "ZAEBaQADAAAAAEgAAABUaGUgdXNlciBpZGVudGl0eSBhc3NvY2lhdGVkIHdpdGggdGhlIHNlc3Npb24g" +
           "dGhhdCBpbml0aWF0ZWQgdGhlIGFjdGlvbi4ALgBEaQAAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAA" +
           "CAAAAE1ldGhvZElkAQFqAAAuAERqAAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAOAAAASW5wdXRB" +
           "cmd1bWVudHMBAWsAAC4ARGsAAAAAGAEAAAABAf////8AAAAAFWCJCgIAAAABABAAAABDZXJ0aWZpY2F0" +
           "ZUdyb3VwAQHNAgAuAETNAgAAABH/////AQH/////AAAAABVgiQoCAAAAAQAPAAAAQ2VydGlmaWNhdGVU" +
           "eXBlAQHOAgAuAETOAgAAABH/////AQH/////AAAAAA==";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// A description for the CertificateGroup Property.
        /// </summary>
        public PropertyState<NodeId> CertificateGroup
        {
            get
            {
                return m_certificateGroup;
            }

            set
            {
                if (!Object.ReferenceEquals(m_certificateGroup, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_certificateGroup = value;
            }
        }

        /// <summary>
        /// A description for the CertificateType Property.
        /// </summary>
        public PropertyState<NodeId> CertificateType
        {
            get
            {
                return m_certificateType;
            }

            set
            {
                if (!Object.ReferenceEquals(m_certificateType, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_certificateType = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_certificateGroup != null)
            {
                children.Add(m_certificateGroup);
            }

            if (m_certificateType != null)
            {
                children.Add(m_certificateType);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case Opc.Ua.Gds.BrowseNames.CertificateGroup:
                {
                    if (createOrReplace)
                    {
                        if (CertificateGroup == null)
                        {
                            if (replacement == null)
                            {
                                CertificateGroup = new PropertyState<NodeId>(this);
                            }
                            else
                            {
                                CertificateGroup = (PropertyState<NodeId>)replacement;
                            }
                        }
                    }

                    instance = CertificateGroup;
                    break;
                }

                case Opc.Ua.Gds.BrowseNames.CertificateType:
                {
                    if (createOrReplace)
                    {
                        if (CertificateType == null)
                        {
                            if (replacement == null)
                            {
                                CertificateType = new PropertyState<NodeId>(this);
                            }
                            else
                            {
                                CertificateType = (PropertyState<NodeId>)replacement;
                            }
                        }
                    }

                    instance = CertificateType;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private PropertyState<NodeId> m_certificateGroup;
        private PropertyState<NodeId> m_certificateType;
        #endregion
    }
    #endif
    #endregion

    #region CertificateDeliveredAuditEventState Class
    #if (!OPCUA_EXCLUDE_CertificateDeliveredAuditEventState)
    /// <summary>
    /// Stores an instance of the CertificateDeliveredAuditEventType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class CertificateDeliveredAuditEventState : AuditUpdateMethodEventState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public CertificateDeliveredAuditEventState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.Gds.ObjectTypes.CertificateDeliveredAuditEventType, Opc.Ua.Gds.Namespaces.OpcUaGds, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AQAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvR0RTL/////8EYIAAAQAAAAEAKgAAAENl" +
           "cnRpZmljYXRlRGVsaXZlcmVkQXVkaXRFdmVudFR5cGVJbnN0YW5jZQEBbQABAW0A/////xIAAAA1YIkK" +
           "AgAAAAAABwAAAEV2ZW50SWQBAW4AAwAAAAArAAAAQSBnbG9iYWxseSB1bmlxdWUgaWRlbnRpZmllciBm" +
           "b3IgdGhlIGV2ZW50LgAuAERuAAAAAA//////AQH/////AAAAADVgiQoCAAAAAAAJAAAARXZlbnRUeXBl" +
           "AQFvAAMAAAAAIgAAAFRoZSBpZGVudGlmaWVyIGZvciB0aGUgZXZlbnQgdHlwZS4ALgBEbwAAAAAR////" +
           "/wEB/////wAAAAA1YIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBAXAAAwAAAAAYAAAAVGhlIHNvdXJjZSBv" +
           "ZiB0aGUgZXZlbnQuAC4ARHAAAAAAEf////8BAf////8AAAAANWCJCgIAAAAAAAoAAABTb3VyY2VOYW1l" +
           "AQFxAAMAAAAAKQAAAEEgZGVzY3JpcHRpb24gb2YgdGhlIHNvdXJjZSBvZiB0aGUgZXZlbnQuAC4ARHEA" +
           "AAAADP////8BAf////8AAAAANWCJCgIAAAAAAAQAAABUaW1lAQFyAAMAAAAAGAAAAFdoZW4gdGhlIGV2" +
           "ZW50IG9jY3VycmVkLgAuAERyAAAAAQAmAf////8BAf////8AAAAANWCJCgIAAAAAAAsAAABSZWNlaXZl" +
           "VGltZQEBcwADAAAAAD4AAABXaGVuIHRoZSBzZXJ2ZXIgcmVjZWl2ZWQgdGhlIGV2ZW50IGZyb20gdGhl" +
           "IHVuZGVybHlpbmcgc3lzdGVtLgAuAERzAAAAAQAmAf////8BAf////8AAAAANWCJCgIAAAAAAAkAAABM" +
           "b2NhbFRpbWUBAXQAAwAAAAA8AAAASW5mb3JtYXRpb24gYWJvdXQgdGhlIGxvY2FsIHRpbWUgd2hlcmUg" +
           "dGhlIGV2ZW50IG9yaWdpbmF0ZWQuAC4ARHQAAAABANAi/////wEB/////wAAAAA1YIkKAgAAAAAABwAA" +
           "AE1lc3NhZ2UBAXUAAwAAAAAlAAAAQSBsb2NhbGl6ZWQgZGVzY3JpcHRpb24gb2YgdGhlIGV2ZW50LgAu" +
           "AER1AAAAABX/////AQH/////AAAAADVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAXYAAwAAAAAhAAAASW5k" +
           "aWNhdGVzIGhvdyB1cmdlbnQgYW4gZXZlbnQgaXMuAC4ARHYAAAAABf////8BAf////8AAAAANWCJCgIA" +
           "AAAAAA8AAABBY3Rpb25UaW1lU3RhbXABAXcAAwAAAAAuAAAAV2hlbiB0aGUgYWN0aW9uIHRyaWdnZXJp" +
           "bmcgdGhlIGV2ZW50IG9jY3VycmVkLgAuAER3AAAAAQAmAf////8BAf////8AAAAANWCJCgIAAAAAAAYA" +
           "AABTdGF0dXMBAXgAAwAAAABhAAAASWYgVFJVRSB0aGUgYWN0aW9uIHdhcyBwZXJmb3JtZWQuIElmIEZB" +
           "TFNFIHRoZSBhY3Rpb24gZmFpbGVkIGFuZCB0aGUgc2VydmVyIHN0YXRlIGRpZCBub3QgY2hhbmdlLgAu" +
           "AER4AAAAAAH/////AQH/////AAAAADVgiQoCAAAAAAAIAAAAU2VydmVySWQBAXkAAwAAAAA6AAAAVGhl" +
           "IHVuaXF1ZSBpZGVudGlmaWVyIGZvciB0aGUgc2VydmVyIGdlbmVyYXRpbmcgdGhlIGV2ZW50LgAuAER5" +
           "AAAAAAz/////AQH/////AAAAADVgiQoCAAAAAAASAAAAQ2xpZW50QXVkaXRFbnRyeUlkAQF6AAMAAAAA" +
           "QwAAAFRoZSBsb2cgZW50cnkgaWQgcHJvdmlkZWQgaW4gdGhlIHJlcXVlc3QgdGhhdCBpbml0aWF0ZWQg" +
           "dGhlIGFjdGlvbi4ALgBEegAAAAAM/////wEB/////wAAAAA1YIkKAgAAAAAADAAAAENsaWVudFVzZXJJ" +
           "ZAEBewADAAAAAEgAAABUaGUgdXNlciBpZGVudGl0eSBhc3NvY2lhdGVkIHdpdGggdGhlIHNlc3Npb24g" +
           "dGhhdCBpbml0aWF0ZWQgdGhlIGFjdGlvbi4ALgBEewAAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAA" +
           "CAAAAE1ldGhvZElkAQF8AAAuAER8AAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAOAAAASW5wdXRB" +
           "cmd1bWVudHMBAX0AAC4ARH0AAAAAGAEAAAABAf////8AAAAAFWCJCgIAAAABABAAAABDZXJ0aWZpY2F0" +
           "ZUdyb3VwAQHPAgAuAETPAgAAABH/////AQH/////AAAAABVgiQoCAAAAAQAPAAAAQ2VydGlmaWNhdGVU" +
           "eXBlAQHQAgAuAETQAgAAABH/////AQH/////AAAAAA==";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// A description for the CertificateGroup Property.
        /// </summary>
        public PropertyState<NodeId> CertificateGroup
        {
            get
            {
                return m_certificateGroup;
            }

            set
            {
                if (!Object.ReferenceEquals(m_certificateGroup, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_certificateGroup = value;
            }
        }

        /// <summary>
        /// A description for the CertificateType Property.
        /// </summary>
        public PropertyState<NodeId> CertificateType
        {
            get
            {
                return m_certificateType;
            }

            set
            {
                if (!Object.ReferenceEquals(m_certificateType, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_certificateType = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_certificateGroup != null)
            {
                children.Add(m_certificateGroup);
            }

            if (m_certificateType != null)
            {
                children.Add(m_certificateType);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case Opc.Ua.Gds.BrowseNames.CertificateGroup:
                {
                    if (createOrReplace)
                    {
                        if (CertificateGroup == null)
                        {
                            if (replacement == null)
                            {
                                CertificateGroup = new PropertyState<NodeId>(this);
                            }
                            else
                            {
                                CertificateGroup = (PropertyState<NodeId>)replacement;
                            }
                        }
                    }

                    instance = CertificateGroup;
                    break;
                }

                case Opc.Ua.Gds.BrowseNames.CertificateType:
                {
                    if (createOrReplace)
                    {
                        if (CertificateType == null)
                        {
                            if (replacement == null)
                            {
                                CertificateType = new PropertyState<NodeId>(this);
                            }
                            else
                            {
                                CertificateType = (PropertyState<NodeId>)replacement;
                            }
                        }
                    }

                    instance = CertificateType;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private PropertyState<NodeId> m_certificateGroup;
        private PropertyState<NodeId> m_certificateType;
        #endregion
    }
    #endif
    #endregion

    #region CredentialManagementFolderState Class
    #if (!OPCUA_EXCLUDE_CredentialManagementFolderState)
    /// <summary>
    /// Stores an instance of the CredentialManagementFolderType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class CredentialManagementFolderState : FolderState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public CredentialManagementFolderState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.Gds.ObjectTypes.CredentialManagementFolderType, Opc.Ua.Gds.Namespaces.OpcUaGds, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AQAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvR0RTL/////8EYIAAAQAAAAEAJgAAAENy" +
           "ZWRlbnRpYWxNYW5hZ2VtZW50Rm9sZGVyVHlwZUluc3RhbmNlAQHvAgEB7wL/////AQAAABVgiQoCAAAA" +
           "AQAaAAAAQ3JlZGVudGlhbFNlY3VyaXR5UG9saWNpZXMBAf4CAC4ARP4CAAAADAEAAAABAf////8AAAAA";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// A description for the CredentialSecurityPolicies Property.
        /// </summary>
        public PropertyState<string[]> CredentialSecurityPolicies
        {
            get
            {
                return m_credentialSecurityPolicies;
            }

            set
            {
                if (!Object.ReferenceEquals(m_credentialSecurityPolicies, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_credentialSecurityPolicies = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_credentialSecurityPolicies != null)
            {
                children.Add(m_credentialSecurityPolicies);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case Opc.Ua.Gds.BrowseNames.CredentialSecurityPolicies:
                {
                    if (createOrReplace)
                    {
                        if (CredentialSecurityPolicies == null)
                        {
                            if (replacement == null)
                            {
                                CredentialSecurityPolicies = new PropertyState<string[]>(this);
                            }
                            else
                            {
                                CredentialSecurityPolicies = (PropertyState<string[]>)replacement;
                            }
                        }
                    }

                    instance = CredentialSecurityPolicies;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private PropertyState<string[]> m_credentialSecurityPolicies;
        #endregion
    }
    #endif
    #endregion

    #region CredentialManagementState Class
    #if (!OPCUA_EXCLUDE_CredentialManagementState)
    /// <summary>
    /// Stores an instance of the CredentialManagementType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class CredentialManagementState : BaseObjectState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public CredentialManagementState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.Gds.ObjectTypes.CredentialManagementType, Opc.Ua.Gds.Namespaces.OpcUaGds, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);

            if (RevokeCredential != null)
            {
                RevokeCredential.Initialize(context, RevokeCredential_InitializationString);
            }

            if (RequestAccessToken != null)
            {
                RequestAccessToken.Initialize(context, RequestAccessToken_InitializationString);
            }
        }

        #region Initialization String
        private const string RevokeCredential_InitializationString =
           "AQAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvR0RTL/////8EYYIKBAAAAAEAEAAAAFJl" +
           "dm9rZUNyZWRlbnRpYWwBARgDAC8BARgDGAMAAAEB/////wEAAAAVYKkKAgAAAAAADgAAAElucHV0QXJn" +
           "dW1lbnRzAQEZAwAuAEQZAwAAlgIAAAABACoBARwAAAANAAAAQXBwbGljYXRpb25JZAAR/////wAAAAAA" +
           "AQAqAQEbAAAADAAAAENyZWRlbnRpYWxJZAAM/////wAAAAAAAQAoAQEAAAABAf////8AAAAA";

        private const string RequestAccessToken_InitializationString =
           "AQAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvR0RTL/////8EYYIKBAAAAAEAEgAAAFJl" +
           "cXVlc3RBY2Nlc3NUb2tlbgEBGgMALwEBGgMaAwAAAQH/////AgAAABVgqQoCAAAAAAAOAAAASW5wdXRB" +
           "cmd1bWVudHMBARsDAC4ARBsDAACWBAAAAAEAKgEBHAAAAA0AAABBcHBsaWNhdGlvbklkABH/////AAAA" +
           "AAABACoBARsAAAAMAAAAQ3JlZGVudGlhbElkAAz/////AAAAAAABACoBAR8AAAAQAAAAQ3JlZGVudGlh" +
           "bFNlY3JldAAM/////wAAAAAAAQAqAQEZAAAACgAAAFJlc291cmNlSWQADP////8AAAAAAAEAKAEBAAAA" +
           "AQH/////AAAAABVgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQEcAwAuAEQcAwAAlgEAAAABACoB" +
           "ARoAAAALAAAAQWNjZXNzVG9rZW4ADP////8AAAAAAAEAKAEBAAAAAQH/////AAAAAA==";

        private const string InitializationString =
           "AQAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvR0RTL/////8EYIAAAQAAAAEAIAAAAENy" +
           "ZWRlbnRpYWxNYW5hZ2VtZW50VHlwZUluc3RhbmNlAQEPAwEBDwP/////BgAAABVgiQoCAAAAAQAKAAAA" +
           "U2VydmljZVVyaQEBEAMALgBEEAMAAAAM/////wEB/////wAAAAAVYIkKAgAAAAEACQAAAEVuZHBvaW50" +
           "cwEBEQMALgBEEQMAAAEAOAEBAAAAAQH/////AAAAAARhggoEAAAAAQAWAAAAU3RhcnRDcmVkZW50aWFs" +
           "UmVxdWVzdAEBEgMALwEBEgMSAwAAAQH/////AgAAABVgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMB" +
           "ARMDAC4ARBMDAACWAwAAAAEAKgEBHAAAAA0AAABBcHBsaWNhdGlvbklkABH/////AAAAAAABACoBARoA" +
           "AAALAAAAQ2VydGlmaWNhdGUAD/////8AAAAAAAEAKgEBIAAAABEAAABTZWN1cml0eVBvbGljeVVyaQAM" +
           "/////wAAAAAAAQAoAQEAAAABAf////8AAAAAFWCpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBARQD" +
           "AC4ARBQDAACWAQAAAAEAKgEBGAAAAAkAAABSZXF1ZXN0SWQAEf////8AAAAAAAEAKAEBAAAAAQH/////" +
           "AAAAAARhggoEAAAAAQAXAAAARmluaXNoQ3JlZGVudGlhbFJlcXVlc3QBARUDAC8BARUDFQMAAAEB////" +
           "/wIAAAAVYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQEWAwAuAEQWAwAAlgMAAAABACoBARwAAAAN" +
           "AAAAQXBwbGljYXRpb25JZAAR/////wAAAAAAAQAqAQEYAAAACQAAAFJlcXVlc3RJZAAR/////wAAAAAA" +
           "AQAqAQEcAAAADQAAAENhbmNlbFJlcXVlc3QAAf////8AAAAAAAEAKAEBAAAAAQH/////AAAAABVgqQoC" +
           "AAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQEXAwAuAEQXAwAAlgQAAAABACoBARsAAAAMAAAAQ3JlZGVu" +
           "dGlhbElkAAz/////AAAAAAABACoBAR8AAAAQAAAAQ3JlZGVudGlhbFNlY3JldAAP/////wAAAAAAAQAq" +
           "AQEkAAAAFQAAAENlcnRpZmljYXRlVGh1bWJwcmludAAM/////wAAAAAAAQAqAQEgAAAAEQAAAFNlY3Vy" +
           "aXR5UG9saWN5VXJpAAz/////AAAAAAABACgBAQAAAAEB/////wAAAAAEYYIKBAAAAAEAEAAAAFJldm9r" +
           "ZUNyZWRlbnRpYWwBARgDAC8BARgDGAMAAAEB/////wEAAAAVYKkKAgAAAAAADgAAAElucHV0QXJndW1l" +
           "bnRzAQEZAwAuAEQZAwAAlgIAAAABACoBARwAAAANAAAAQXBwbGljYXRpb25JZAAR/////wAAAAAAAQAq" +
           "AQEbAAAADAAAAENyZWRlbnRpYWxJZAAM/////wAAAAAAAQAoAQEAAAABAf////8AAAAABGGCCgQAAAAB" +
           "ABIAAABSZXF1ZXN0QWNjZXNzVG9rZW4BARoDAC8BARoDGgMAAAEB/////wIAAAAVYKkKAgAAAAAADgAA" +
           "AElucHV0QXJndW1lbnRzAQEbAwAuAEQbAwAAlgQAAAABACoBARwAAAANAAAAQXBwbGljYXRpb25JZAAR" +
           "/////wAAAAAAAQAqAQEbAAAADAAAAENyZWRlbnRpYWxJZAAM/////wAAAAAAAQAqAQEfAAAAEAAAAENy" +
           "ZWRlbnRpYWxTZWNyZXQADP////8AAAAAAAEAKgEBGQAAAAoAAABSZXNvdXJjZUlkAAz/////AAAAAAAB" +
           "ACgBAQAAAAEB/////wAAAAAVYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEBHAMALgBEHAMAAJYB" +
           "AAAAAQAqAQEaAAAACwAAAEFjY2Vzc1Rva2VuAAz/////AAAAAAABACgBAQAAAAEB/////wAAAAA=";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// A description for the ServiceUri Property.
        /// </summary>
        public PropertyState<string> ServiceUri
        {
            get
            {
                return m_serviceUri;
            }

            set
            {
                if (!Object.ReferenceEquals(m_serviceUri, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_serviceUri = value;
            }
        }

        /// <summary>
        /// A description for the Endpoints Property.
        /// </summary>
        public PropertyState<EndpointDescription[]> Endpoints
        {
            get
            {
                return m_endpoints;
            }

            set
            {
                if (!Object.ReferenceEquals(m_endpoints, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_endpoints = value;
            }
        }

        /// <summary>
        /// A description for the StartCredentialRequestMethodType Method.
        /// </summary>
        public StartCredentialRequestMethodState StartCredentialRequest
        {
            get
            {
                return m_startCredentialRequestMethod;
            }

            set
            {
                if (!Object.ReferenceEquals(m_startCredentialRequestMethod, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_startCredentialRequestMethod = value;
            }
        }

        /// <summary>
        /// A description for the FinishCredentialRequestMethodType Method.
        /// </summary>
        public FinishCredentialRequestMethodState FinishCredentialRequest
        {
            get
            {
                return m_finishCredentialRequestMethod;
            }

            set
            {
                if (!Object.ReferenceEquals(m_finishCredentialRequestMethod, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_finishCredentialRequestMethod = value;
            }
        }

        /// <summary>
        /// A description for the RevokeCredentialMethodType Method.
        /// </summary>
        public RevokeCredentialMethodState RevokeCredential
        {
            get
            {
                return m_revokeCredentialMethod;
            }

            set
            {
                if (!Object.ReferenceEquals(m_revokeCredentialMethod, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_revokeCredentialMethod = value;
            }
        }

        /// <summary>
        /// A description for the RequestAccessTokenMethodType Method.
        /// </summary>
        public RequestAccessTokenMethodState RequestAccessToken
        {
            get
            {
                return m_requestAccessTokenMethod;
            }

            set
            {
                if (!Object.ReferenceEquals(m_requestAccessTokenMethod, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_requestAccessTokenMethod = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_serviceUri != null)
            {
                children.Add(m_serviceUri);
            }

            if (m_endpoints != null)
            {
                children.Add(m_endpoints);
            }

            if (m_startCredentialRequestMethod != null)
            {
                children.Add(m_startCredentialRequestMethod);
            }

            if (m_finishCredentialRequestMethod != null)
            {
                children.Add(m_finishCredentialRequestMethod);
            }

            if (m_revokeCredentialMethod != null)
            {
                children.Add(m_revokeCredentialMethod);
            }

            if (m_requestAccessTokenMethod != null)
            {
                children.Add(m_requestAccessTokenMethod);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case Opc.Ua.Gds.BrowseNames.ServiceUri:
                {
                    if (createOrReplace)
                    {
                        if (ServiceUri == null)
                        {
                            if (replacement == null)
                            {
                                ServiceUri = new PropertyState<string>(this);
                            }
                            else
                            {
                                ServiceUri = (PropertyState<string>)replacement;
                            }
                        }
                    }

                    instance = ServiceUri;
                    break;
                }

                case Opc.Ua.Gds.BrowseNames.Endpoints:
                {
                    if (createOrReplace)
                    {
                        if (Endpoints == null)
                        {
                            if (replacement == null)
                            {
                                Endpoints = new PropertyState<EndpointDescription[]>(this);
                            }
                            else
                            {
                                Endpoints = (PropertyState<EndpointDescription[]>)replacement;
                            }
                        }
                    }

                    instance = Endpoints;
                    break;
                }

                case Opc.Ua.Gds.BrowseNames.StartCredentialRequest:
                {
                    if (createOrReplace)
                    {
                        if (StartCredentialRequest == null)
                        {
                            if (replacement == null)
                            {
                                StartCredentialRequest = new StartCredentialRequestMethodState(this);
                            }
                            else
                            {
                                StartCredentialRequest = (StartCredentialRequestMethodState)replacement;
                            }
                        }
                    }

                    instance = StartCredentialRequest;
                    break;
                }

                case Opc.Ua.Gds.BrowseNames.FinishCredentialRequest:
                {
                    if (createOrReplace)
                    {
                        if (FinishCredentialRequest == null)
                        {
                            if (replacement == null)
                            {
                                FinishCredentialRequest = new FinishCredentialRequestMethodState(this);
                            }
                            else
                            {
                                FinishCredentialRequest = (FinishCredentialRequestMethodState)replacement;
                            }
                        }
                    }

                    instance = FinishCredentialRequest;
                    break;
                }

                case Opc.Ua.Gds.BrowseNames.RevokeCredential:
                {
                    if (createOrReplace)
                    {
                        if (RevokeCredential == null)
                        {
                            if (replacement == null)
                            {
                                RevokeCredential = new RevokeCredentialMethodState(this);
                            }
                            else
                            {
                                RevokeCredential = (RevokeCredentialMethodState)replacement;
                            }
                        }
                    }

                    instance = RevokeCredential;
                    break;
                }

                case Opc.Ua.Gds.BrowseNames.RequestAccessToken:
                {
                    if (createOrReplace)
                    {
                        if (RequestAccessToken == null)
                        {
                            if (replacement == null)
                            {
                                RequestAccessToken = new RequestAccessTokenMethodState(this);
                            }
                            else
                            {
                                RequestAccessToken = (RequestAccessTokenMethodState)replacement;
                            }
                        }
                    }

                    instance = RequestAccessToken;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private PropertyState<string> m_serviceUri;
        private PropertyState<EndpointDescription[]> m_endpoints;
        private StartCredentialRequestMethodState m_startCredentialRequestMethod;
        private FinishCredentialRequestMethodState m_finishCredentialRequestMethod;
        private RevokeCredentialMethodState m_revokeCredentialMethod;
        private RequestAccessTokenMethodState m_requestAccessTokenMethod;
        #endregion
    }
    #endif
    #endregion

    #region StartCredentialRequestMethodState Class
    #if (!OPCUA_EXCLUDE_StartCredentialRequestMethodState)
    /// <summary>
    /// Stores an instance of the StartCredentialRequestMethodType Method.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class StartCredentialRequestMethodState : MethodState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public StartCredentialRequestMethodState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Constructs an instance of a node.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <returns>The new node.</returns>
        public new static NodeState Construct(NodeState parent)
        {
            return new StartCredentialRequestMethodState(parent);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AQAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvR0RTL/////8EYYIKBAAAAAEAIAAAAFN0" +
           "YXJ0Q3JlZGVudGlhbFJlcXVlc3RNZXRob2RUeXBlAQEdAwAvAQEdAx0DAAABAf////8CAAAAFWCpCgIA" +
           "AAAAAA4AAABJbnB1dEFyZ3VtZW50cwEBHgMALgBEHgMAAJYDAAAAAQAqAQEcAAAADQAAAEFwcGxpY2F0" +
           "aW9uSWQAEf////8AAAAAAAEAKgEBGgAAAAsAAABDZXJ0aWZpY2F0ZQAP/////wAAAAAAAQAqAQEgAAAA" +
           "EQAAAFNlY3VyaXR5UG9saWN5VXJpAAz/////AAAAAAABACgBAQAAAAEB/////wAAAAAVYKkKAgAAAAAA" +
           "DwAAAE91dHB1dEFyZ3VtZW50cwEBHwMALgBEHwMAAJYBAAAAAQAqAQEYAAAACQAAAFJlcXVlc3RJZAAR" +
           "/////wAAAAAAAQAoAQEAAAABAf////8AAAAA";
        #endregion
        #endif
        #endregion

        #region Event Callbacks
        /// <summary>
        /// Raised when the the method is called.
        /// </summary>
        public StartCredentialRequestMethodStateMethodCallHandler OnCall;
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Invokes the method, returns the result and output argument.
        /// </summary>
        /// <param name="context">The current context.</param>
        /// <param name="objectId">The id of the object.</param>
        /// <param name="inputArguments">The input arguments which have been already validated.</param>
        /// <param name="outputArguments">The output arguments which have initialized with thier default values.</param>
        /// <returns></returns>
        protected override ServiceResult Call(
            ISystemContext context,
            NodeId objectId,
            IList<object> inputArguments,
            IList<object> outputArguments)
        {
            if (OnCall == null)
            {
                return base.Call(context, objectId, inputArguments, outputArguments);
            }

            ServiceResult result = null;

            NodeId applicationId = (NodeId)inputArguments[0];
            byte[] certificate = (byte[])inputArguments[1];
            string securityPolicyUri = (string)inputArguments[2];

            NodeId requestId = (NodeId)outputArguments[0];

            if (OnCall != null)
            {
                result = OnCall(
                    context,
                    this,
                    objectId,
                    applicationId,
                    certificate,
                    securityPolicyUri,
                    ref requestId);
            }

            outputArguments[0] = requestId;

            return result;
        }
        #endregion

        #region Private Fields
        #endregion
    }

    /// <summary>
    /// Used to receive notifications when the method is called.
    /// </summary>
    /// <exclude />
    public delegate ServiceResult StartCredentialRequestMethodStateMethodCallHandler(
        ISystemContext context,
        MethodState method,
        NodeId objectId,
        NodeId applicationId,
        byte[] certificate,
        string securityPolicyUri,
        ref NodeId requestId);
    #endif
    #endregion

    #region FinishCredentialRequestMethodState Class
    #if (!OPCUA_EXCLUDE_FinishCredentialRequestMethodState)
    /// <summary>
    /// Stores an instance of the FinishCredentialRequestMethodType Method.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class FinishCredentialRequestMethodState : MethodState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public FinishCredentialRequestMethodState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Constructs an instance of a node.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <returns>The new node.</returns>
        public new static NodeState Construct(NodeState parent)
        {
            return new FinishCredentialRequestMethodState(parent);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AQAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvR0RTL/////8EYYIKBAAAAAEAIQAAAEZp" +
           "bmlzaENyZWRlbnRpYWxSZXF1ZXN0TWV0aG9kVHlwZQEBIAMALwEBIAMgAwAAAQH/////AgAAABVgqQoC" +
           "AAAAAAAOAAAASW5wdXRBcmd1bWVudHMBASEDAC4ARCEDAACWAwAAAAEAKgEBHAAAAA0AAABBcHBsaWNh" +
           "dGlvbklkABH/////AAAAAAABACoBARgAAAAJAAAAUmVxdWVzdElkABH/////AAAAAAABACoBARwAAAAN" +
           "AAAAQ2FuY2VsUmVxdWVzdAAB/////wAAAAAAAQAoAQEAAAABAf////8AAAAAFWCpCgIAAAAAAA8AAABP" +
           "dXRwdXRBcmd1bWVudHMBASIDAC4ARCIDAACWBAAAAAEAKgEBGwAAAAwAAABDcmVkZW50aWFsSWQADP//" +
           "//8AAAAAAAEAKgEBHwAAABAAAABDcmVkZW50aWFsU2VjcmV0AA//////AAAAAAABACoBASQAAAAVAAAA" +
           "Q2VydGlmaWNhdGVUaHVtYnByaW50AAz/////AAAAAAABACoBASAAAAARAAAAU2VjdXJpdHlQb2xpY3lV" +
           "cmkADP////8AAAAAAAEAKAEBAAAAAQH/////AAAAAA==";
        #endregion
        #endif
        #endregion

        #region Event Callbacks
        /// <summary>
        /// Raised when the the method is called.
        /// </summary>
        public FinishCredentialRequestMethodStateMethodCallHandler OnCall;
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Invokes the method, returns the result and output argument.
        /// </summary>
        /// <param name="context">The current context.</param>
        /// <param name="objectId">The id of the object.</param>
        /// <param name="inputArguments">The input arguments which have been already validated.</param>
        /// <param name="outputArguments">The output arguments which have initialized with thier default values.</param>
        /// <returns></returns>
        protected override ServiceResult Call(
            ISystemContext context,
            NodeId objectId,
            IList<object> inputArguments,
            IList<object> outputArguments)
        {
            if (OnCall == null)
            {
                return base.Call(context, objectId, inputArguments, outputArguments);
            }

            ServiceResult result = null;

            NodeId applicationId = (NodeId)inputArguments[0];
            NodeId requestId = (NodeId)inputArguments[1];
            bool cancelRequest = (bool)inputArguments[2];

            string credentialId = (string)outputArguments[0];
            byte[] credentialSecret = (byte[])outputArguments[1];
            string certificateThumbprint = (string)outputArguments[2];
            string securityPolicyUri = (string)outputArguments[3];

            if (OnCall != null)
            {
                result = OnCall(
                    context,
                    this,
                    objectId,
                    applicationId,
                    requestId,
                    cancelRequest,
                    ref credentialId,
                    ref credentialSecret,
                    ref certificateThumbprint,
                    ref securityPolicyUri);
            }

            outputArguments[0] = credentialId;
            outputArguments[1] = credentialSecret;
            outputArguments[2] = certificateThumbprint;
            outputArguments[3] = securityPolicyUri;

            return result;
        }
        #endregion

        #region Private Fields
        #endregion
    }

    /// <summary>
    /// Used to receive notifications when the method is called.
    /// </summary>
    /// <exclude />
    public delegate ServiceResult FinishCredentialRequestMethodStateMethodCallHandler(
        ISystemContext context,
        MethodState method,
        NodeId objectId,
        NodeId applicationId,
        NodeId requestId,
        bool cancelRequest,
        ref string credentialId,
        ref byte[] credentialSecret,
        ref string certificateThumbprint,
        ref string securityPolicyUri);
    #endif
    #endregion

    #region RevokeCredentialMethodState Class
    #if (!OPCUA_EXCLUDE_RevokeCredentialMethodState)
    /// <summary>
    /// Stores an instance of the RevokeCredentialMethodType Method.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class RevokeCredentialMethodState : MethodState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public RevokeCredentialMethodState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Constructs an instance of a node.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <returns>The new node.</returns>
        public new static NodeState Construct(NodeState parent)
        {
            return new RevokeCredentialMethodState(parent);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AQAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvR0RTL/////8EYYIKBAAAAAEAGgAAAFJl" +
           "dm9rZUNyZWRlbnRpYWxNZXRob2RUeXBlAQEjAwAvAQEjAyMDAAABAf////8BAAAAFWCpCgIAAAAAAA4A" +
           "AABJbnB1dEFyZ3VtZW50cwEBJAMALgBEJAMAAJYCAAAAAQAqAQEcAAAADQAAAEFwcGxpY2F0aW9uSWQA" +
           "Ef////8AAAAAAAEAKgEBGwAAAAwAAABDcmVkZW50aWFsSWQADP////8AAAAAAAEAKAEBAAAAAQH/////" +
           "AAAAAA==";
        #endregion
        #endif
        #endregion

        #region Event Callbacks
        /// <summary>
        /// Raised when the the method is called.
        /// </summary>
        public RevokeCredentialMethodStateMethodCallHandler OnCall;
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Invokes the method, returns the result and output argument.
        /// </summary>
        /// <param name="context">The current context.</param>
        /// <param name="objectId">The id of the object.</param>
        /// <param name="inputArguments">The input arguments which have been already validated.</param>
        /// <param name="outputArguments">The output arguments which have initialized with thier default values.</param>
        /// <returns></returns>
        protected override ServiceResult Call(
            ISystemContext context,
            NodeId objectId,
            IList<object> inputArguments,
            IList<object> outputArguments)
        {
            if (OnCall == null)
            {
                return base.Call(context, objectId, inputArguments, outputArguments);
            }

            ServiceResult result = null;

            NodeId applicationId = (NodeId)inputArguments[0];
            string credentialId = (string)inputArguments[1];

            if (OnCall != null)
            {
                result = OnCall(
                    context,
                    this,
                    objectId,
                    applicationId,
                    credentialId);
            }

            return result;
        }
        #endregion

        #region Private Fields
        #endregion
    }

    /// <summary>
    /// Used to receive notifications when the method is called.
    /// </summary>
    /// <exclude />
    public delegate ServiceResult RevokeCredentialMethodStateMethodCallHandler(
        ISystemContext context,
        MethodState method,
        NodeId objectId,
        NodeId applicationId,
        string credentialId);
    #endif
    #endregion

    #region RequestAccessTokenMethodState Class
    #if (!OPCUA_EXCLUDE_RequestAccessTokenMethodState)
    /// <summary>
    /// Stores an instance of the RequestAccessTokenMethodType Method.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class RequestAccessTokenMethodState : MethodState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public RequestAccessTokenMethodState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Constructs an instance of a node.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <returns>The new node.</returns>
        public new static NodeState Construct(NodeState parent)
        {
            return new RequestAccessTokenMethodState(parent);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AQAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvR0RTL/////8EYYIKBAAAAAEAHAAAAFJl" +
           "cXVlc3RBY2Nlc3NUb2tlbk1ldGhvZFR5cGUBASUDAC8BASUDJQMAAAEB/////wIAAAAVYKkKAgAAAAAA" +
           "DgAAAElucHV0QXJndW1lbnRzAQEmAwAuAEQmAwAAlgQAAAABACoBARwAAAANAAAAQXBwbGljYXRpb25J" +
           "ZAAR/////wAAAAAAAQAqAQEbAAAADAAAAENyZWRlbnRpYWxJZAAM/////wAAAAAAAQAqAQEfAAAAEAAA" +
           "AENyZWRlbnRpYWxTZWNyZXQADP////8AAAAAAAEAKgEBGQAAAAoAAABSZXNvdXJjZUlkAAz/////AAAA" +
           "AAABACgBAQAAAAEB/////wAAAAAVYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEBJwMALgBEJwMA" +
           "AJYBAAAAAQAqAQEaAAAACwAAAEFjY2Vzc1Rva2VuAAz/////AAAAAAABACgBAQAAAAEB/////wAAAAA=";
        #endregion
        #endif
        #endregion

        #region Event Callbacks
        /// <summary>
        /// Raised when the the method is called.
        /// </summary>
        public RequestAccessTokenMethodStateMethodCallHandler OnCall;
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Invokes the method, returns the result and output argument.
        /// </summary>
        /// <param name="context">The current context.</param>
        /// <param name="objectId">The id of the object.</param>
        /// <param name="inputArguments">The input arguments which have been already validated.</param>
        /// <param name="outputArguments">The output arguments which have initialized with thier default values.</param>
        /// <returns></returns>
        protected override ServiceResult Call(
            ISystemContext context,
            NodeId objectId,
            IList<object> inputArguments,
            IList<object> outputArguments)
        {
            if (OnCall == null)
            {
                return base.Call(context, objectId, inputArguments, outputArguments);
            }

            ServiceResult result = null;

            NodeId applicationId = (NodeId)inputArguments[0];
            string credentialId = (string)inputArguments[1];
            string credentialSecret = (string)inputArguments[2];
            string resourceId = (string)inputArguments[3];

            string accessToken = (string)outputArguments[0];

            if (OnCall != null)
            {
                result = OnCall(
                    context,
                    this,
                    objectId,
                    applicationId,
                    credentialId,
                    credentialSecret,
                    resourceId,
                    ref accessToken);
            }

            outputArguments[0] = accessToken;

            return result;
        }
        #endregion

        #region Private Fields
        #endregion
    }

    /// <summary>
    /// Used to receive notifications when the method is called.
    /// </summary>
    /// <exclude />
    public delegate ServiceResult RequestAccessTokenMethodStateMethodCallHandler(
        ISystemContext context,
        MethodState method,
        NodeId objectId,
        NodeId applicationId,
        string credentialId,
        string credentialSecret,
        string resourceId,
        ref string accessToken);
    #endif
    #endregion

    #region CredentialRequestedAuditEventState Class
    #if (!OPCUA_EXCLUDE_CredentialRequestedAuditEventState)
    /// <summary>
    /// Stores an instance of the CredentialRequestedAuditEventType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class CredentialRequestedAuditEventState : AuditUpdateMethodEventState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public CredentialRequestedAuditEventState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.Gds.ObjectTypes.CredentialRequestedAuditEventType, Opc.Ua.Gds.Namespaces.OpcUaGds, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AQAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvR0RTL/////8EYIAAAQAAAAEAKQAAAENy" +
           "ZWRlbnRpYWxSZXF1ZXN0ZWRBdWRpdEV2ZW50VHlwZUluc3RhbmNlAQEoAwEBKAP/////EQAAADVgiQoC" +
           "AAAAAAAHAAAARXZlbnRJZAEBKQMDAAAAACsAAABBIGdsb2JhbGx5IHVuaXF1ZSBpZGVudGlmaWVyIGZv" +
           "ciB0aGUgZXZlbnQuAC4ARCkDAAAAD/////8BAf////8AAAAANWCJCgIAAAAAAAkAAABFdmVudFR5cGUB" +
           "ASoDAwAAAAAiAAAAVGhlIGlkZW50aWZpZXIgZm9yIHRoZSBldmVudCB0eXBlLgAuAEQqAwAAABH/////" +
           "AQH/////AAAAADVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEBKwMDAAAAABgAAABUaGUgc291cmNlIG9m" +
           "IHRoZSBldmVudC4ALgBEKwMAAAAR/////wEB/////wAAAAA1YIkKAgAAAAAACgAAAFNvdXJjZU5hbWUB" +
           "ASwDAwAAAAApAAAAQSBkZXNjcmlwdGlvbiBvZiB0aGUgc291cmNlIG9mIHRoZSBldmVudC4ALgBELAMA" +
           "AAAM/////wEB/////wAAAAA1YIkKAgAAAAAABAAAAFRpbWUBAS0DAwAAAAAYAAAAV2hlbiB0aGUgZXZl" +
           "bnQgb2NjdXJyZWQuAC4ARC0DAAABACYB/////wEB/////wAAAAA1YIkKAgAAAAAACwAAAFJlY2VpdmVU" +
           "aW1lAQEuAwMAAAAAPgAAAFdoZW4gdGhlIHNlcnZlciByZWNlaXZlZCB0aGUgZXZlbnQgZnJvbSB0aGUg" +
           "dW5kZXJseWluZyBzeXN0ZW0uAC4ARC4DAAABACYB/////wEB/////wAAAAA1YIkKAgAAAAAACQAAAExv" +
           "Y2FsVGltZQEBLwMDAAAAADwAAABJbmZvcm1hdGlvbiBhYm91dCB0aGUgbG9jYWwgdGltZSB3aGVyZSB0" +
           "aGUgZXZlbnQgb3JpZ2luYXRlZC4ALgBELwMAAAEA0CL/////AQH/////AAAAADVgiQoCAAAAAAAHAAAA" +
           "TWVzc2FnZQEBMAMDAAAAACUAAABBIGxvY2FsaXplZCBkZXNjcmlwdGlvbiBvZiB0aGUgZXZlbnQuAC4A" +
           "RDADAAAAFf////8BAf////8AAAAANWCJCgIAAAAAAAgAAABTZXZlcml0eQEBMQMDAAAAACEAAABJbmRp" +
           "Y2F0ZXMgaG93IHVyZ2VudCBhbiBldmVudCBpcy4ALgBEMQMAAAAF/////wEB/////wAAAAA1YIkKAgAA" +
           "AAAADwAAAEFjdGlvblRpbWVTdGFtcAEBMgMDAAAAAC4AAABXaGVuIHRoZSBhY3Rpb24gdHJpZ2dlcmlu" +
           "ZyB0aGUgZXZlbnQgb2NjdXJyZWQuAC4ARDIDAAABACYB/////wEB/////wAAAAA1YIkKAgAAAAAABgAA" +
           "AFN0YXR1cwEBMwMDAAAAAGEAAABJZiBUUlVFIHRoZSBhY3Rpb24gd2FzIHBlcmZvcm1lZC4gSWYgRkFM" +
           "U0UgdGhlIGFjdGlvbiBmYWlsZWQgYW5kIHRoZSBzZXJ2ZXIgc3RhdGUgZGlkIG5vdCBjaGFuZ2UuAC4A" +
           "RDMDAAAAAf////8BAf////8AAAAANWCJCgIAAAAAAAgAAABTZXJ2ZXJJZAEBNAMDAAAAADoAAABUaGUg" +
           "dW5pcXVlIGlkZW50aWZpZXIgZm9yIHRoZSBzZXJ2ZXIgZ2VuZXJhdGluZyB0aGUgZXZlbnQuAC4ARDQD" +
           "AAAADP////8BAf////8AAAAANWCJCgIAAAAAABIAAABDbGllbnRBdWRpdEVudHJ5SWQBATUDAwAAAABD" +
           "AAAAVGhlIGxvZyBlbnRyeSBpZCBwcm92aWRlZCBpbiB0aGUgcmVxdWVzdCB0aGF0IGluaXRpYXRlZCB0" +
           "aGUgYWN0aW9uLgAuAEQ1AwAAAAz/////AQH/////AAAAADVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklk" +
           "AQE2AwMAAAAASAAAAFRoZSB1c2VyIGlkZW50aXR5IGFzc29jaWF0ZWQgd2l0aCB0aGUgc2Vzc2lvbiB0" +
           "aGF0IGluaXRpYXRlZCB0aGUgYWN0aW9uLgAuAEQ2AwAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAI" +
           "AAAATWV0aG9kSWQBATcDAC4ARDcDAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABJbnB1dEFy" +
           "Z3VtZW50cwEBOAMALgBEOAMAAAAYAQAAAAEB/////wAAAAAVYIkKAgAAAAEACgAAAFNlcnZpY2VVcmkB" +
           "ATkDAC4ARDkDAAAADP////8BAf////8AAAAA";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// A description for the ServiceUri Property.
        /// </summary>
        public PropertyState<string> ServiceUri
        {
            get
            {
                return m_serviceUri;
            }

            set
            {
                if (!Object.ReferenceEquals(m_serviceUri, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_serviceUri = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_serviceUri != null)
            {
                children.Add(m_serviceUri);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case Opc.Ua.Gds.BrowseNames.ServiceUri:
                {
                    if (createOrReplace)
                    {
                        if (ServiceUri == null)
                        {
                            if (replacement == null)
                            {
                                ServiceUri = new PropertyState<string>(this);
                            }
                            else
                            {
                                ServiceUri = (PropertyState<string>)replacement;
                            }
                        }
                    }

                    instance = ServiceUri;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private PropertyState<string> m_serviceUri;
        #endregion
    }
    #endif
    #endregion

    #region CredentialDeliveredAuditEventState Class
    #if (!OPCUA_EXCLUDE_CredentialDeliveredAuditEventState)
    /// <summary>
    /// Stores an instance of the CredentialDeliveredAuditEventType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class CredentialDeliveredAuditEventState : AuditUpdateMethodEventState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public CredentialDeliveredAuditEventState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.Gds.ObjectTypes.CredentialDeliveredAuditEventType, Opc.Ua.Gds.Namespaces.OpcUaGds, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AQAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvR0RTL/////8EYIAAAQAAAAEAKQAAAENy" +
           "ZWRlbnRpYWxEZWxpdmVyZWRBdWRpdEV2ZW50VHlwZUluc3RhbmNlAQE6AwEBOgP/////EQAAADVgiQoC" +
           "AAAAAAAHAAAARXZlbnRJZAEBOwMDAAAAACsAAABBIGdsb2JhbGx5IHVuaXF1ZSBpZGVudGlmaWVyIGZv" +
           "ciB0aGUgZXZlbnQuAC4ARDsDAAAAD/////8BAf////8AAAAANWCJCgIAAAAAAAkAAABFdmVudFR5cGUB" +
           "ATwDAwAAAAAiAAAAVGhlIGlkZW50aWZpZXIgZm9yIHRoZSBldmVudCB0eXBlLgAuAEQ8AwAAABH/////" +
           "AQH/////AAAAADVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEBPQMDAAAAABgAAABUaGUgc291cmNlIG9m" +
           "IHRoZSBldmVudC4ALgBEPQMAAAAR/////wEB/////wAAAAA1YIkKAgAAAAAACgAAAFNvdXJjZU5hbWUB" +
           "AT4DAwAAAAApAAAAQSBkZXNjcmlwdGlvbiBvZiB0aGUgc291cmNlIG9mIHRoZSBldmVudC4ALgBEPgMA" +
           "AAAM/////wEB/////wAAAAA1YIkKAgAAAAAABAAAAFRpbWUBAT8DAwAAAAAYAAAAV2hlbiB0aGUgZXZl" +
           "bnQgb2NjdXJyZWQuAC4ARD8DAAABACYB/////wEB/////wAAAAA1YIkKAgAAAAAACwAAAFJlY2VpdmVU" +
           "aW1lAQFAAwMAAAAAPgAAAFdoZW4gdGhlIHNlcnZlciByZWNlaXZlZCB0aGUgZXZlbnQgZnJvbSB0aGUg" +
           "dW5kZXJseWluZyBzeXN0ZW0uAC4AREADAAABACYB/////wEB/////wAAAAA1YIkKAgAAAAAACQAAAExv" +
           "Y2FsVGltZQEBQQMDAAAAADwAAABJbmZvcm1hdGlvbiBhYm91dCB0aGUgbG9jYWwgdGltZSB3aGVyZSB0" +
           "aGUgZXZlbnQgb3JpZ2luYXRlZC4ALgBEQQMAAAEA0CL/////AQH/////AAAAADVgiQoCAAAAAAAHAAAA" +
           "TWVzc2FnZQEBQgMDAAAAACUAAABBIGxvY2FsaXplZCBkZXNjcmlwdGlvbiBvZiB0aGUgZXZlbnQuAC4A" +
           "REIDAAAAFf////8BAf////8AAAAANWCJCgIAAAAAAAgAAABTZXZlcml0eQEBQwMDAAAAACEAAABJbmRp" +
           "Y2F0ZXMgaG93IHVyZ2VudCBhbiBldmVudCBpcy4ALgBEQwMAAAAF/////wEB/////wAAAAA1YIkKAgAA" +
           "AAAADwAAAEFjdGlvblRpbWVTdGFtcAEBRAMDAAAAAC4AAABXaGVuIHRoZSBhY3Rpb24gdHJpZ2dlcmlu" +
           "ZyB0aGUgZXZlbnQgb2NjdXJyZWQuAC4AREQDAAABACYB/////wEB/////wAAAAA1YIkKAgAAAAAABgAA" +
           "AFN0YXR1cwEBRQMDAAAAAGEAAABJZiBUUlVFIHRoZSBhY3Rpb24gd2FzIHBlcmZvcm1lZC4gSWYgRkFM" +
           "U0UgdGhlIGFjdGlvbiBmYWlsZWQgYW5kIHRoZSBzZXJ2ZXIgc3RhdGUgZGlkIG5vdCBjaGFuZ2UuAC4A" +
           "REUDAAAAAf////8BAf////8AAAAANWCJCgIAAAAAAAgAAABTZXJ2ZXJJZAEBRgMDAAAAADoAAABUaGUg" +
           "dW5pcXVlIGlkZW50aWZpZXIgZm9yIHRoZSBzZXJ2ZXIgZ2VuZXJhdGluZyB0aGUgZXZlbnQuAC4AREYD" +
           "AAAADP////8BAf////8AAAAANWCJCgIAAAAAABIAAABDbGllbnRBdWRpdEVudHJ5SWQBAUcDAwAAAABD" +
           "AAAAVGhlIGxvZyBlbnRyeSBpZCBwcm92aWRlZCBpbiB0aGUgcmVxdWVzdCB0aGF0IGluaXRpYXRlZCB0" +
           "aGUgYWN0aW9uLgAuAERHAwAAAAz/////AQH/////AAAAADVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklk" +
           "AQFIAwMAAAAASAAAAFRoZSB1c2VyIGlkZW50aXR5IGFzc29jaWF0ZWQgd2l0aCB0aGUgc2Vzc2lvbiB0" +
           "aGF0IGluaXRpYXRlZCB0aGUgYWN0aW9uLgAuAERIAwAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAI" +
           "AAAATWV0aG9kSWQBAUkDAC4AREkDAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABJbnB1dEFy" +
           "Z3VtZW50cwEBSgMALgBESgMAAAAYAQAAAAEB/////wAAAAAVYIkKAgAAAAEACgAAAFNlcnZpY2VVcmkB" +
           "AUsDAC4AREsDAAAADP////8BAf////8AAAAA";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// A description for the ServiceUri Property.
        /// </summary>
        public PropertyState<string> ServiceUri
        {
            get
            {
                return m_serviceUri;
            }

            set
            {
                if (!Object.ReferenceEquals(m_serviceUri, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_serviceUri = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_serviceUri != null)
            {
                children.Add(m_serviceUri);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case Opc.Ua.Gds.BrowseNames.ServiceUri:
                {
                    if (createOrReplace)
                    {
                        if (ServiceUri == null)
                        {
                            if (replacement == null)
                            {
                                ServiceUri = new PropertyState<string>(this);
                            }
                            else
                            {
                                ServiceUri = (PropertyState<string>)replacement;
                            }
                        }
                    }

                    instance = ServiceUri;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private PropertyState<string> m_serviceUri;
        #endregion
    }
    #endif
    #endregion

    #region CredentialRevokedAuditEventState Class
    #if (!OPCUA_EXCLUDE_CredentialRevokedAuditEventState)
    /// <summary>
    /// Stores an instance of the CredentialRevokedAuditEventType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class CredentialRevokedAuditEventState : AuditUpdateMethodEventState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public CredentialRevokedAuditEventState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.Gds.ObjectTypes.CredentialRevokedAuditEventType, Opc.Ua.Gds.Namespaces.OpcUaGds, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AQAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvR0RTL/////8EYIAAAQAAAAEAJwAAAENy" +
           "ZWRlbnRpYWxSZXZva2VkQXVkaXRFdmVudFR5cGVJbnN0YW5jZQEBTAMBAUwD/////xEAAAA1YIkKAgAA" +
           "AAAABwAAAEV2ZW50SWQBAU0DAwAAAAArAAAAQSBnbG9iYWxseSB1bmlxdWUgaWRlbnRpZmllciBmb3Ig" +
           "dGhlIGV2ZW50LgAuAERNAwAAAA//////AQH/////AAAAADVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQFO" +
           "AwMAAAAAIgAAAFRoZSBpZGVudGlmaWVyIGZvciB0aGUgZXZlbnQgdHlwZS4ALgBETgMAAAAR/////wEB" +
           "/////wAAAAA1YIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBAU8DAwAAAAAYAAAAVGhlIHNvdXJjZSBvZiB0" +
           "aGUgZXZlbnQuAC4ARE8DAAAAEf////8BAf////8AAAAANWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQFQ" +
           "AwMAAAAAKQAAAEEgZGVzY3JpcHRpb24gb2YgdGhlIHNvdXJjZSBvZiB0aGUgZXZlbnQuAC4ARFADAAAA" +
           "DP////8BAf////8AAAAANWCJCgIAAAAAAAQAAABUaW1lAQFRAwMAAAAAGAAAAFdoZW4gdGhlIGV2ZW50" +
           "IG9jY3VycmVkLgAuAERRAwAAAQAmAf////8BAf////8AAAAANWCJCgIAAAAAAAsAAABSZWNlaXZlVGlt" +
           "ZQEBUgMDAAAAAD4AAABXaGVuIHRoZSBzZXJ2ZXIgcmVjZWl2ZWQgdGhlIGV2ZW50IGZyb20gdGhlIHVu" +
           "ZGVybHlpbmcgc3lzdGVtLgAuAERSAwAAAQAmAf////8BAf////8AAAAANWCJCgIAAAAAAAkAAABMb2Nh" +
           "bFRpbWUBAVMDAwAAAAA8AAAASW5mb3JtYXRpb24gYWJvdXQgdGhlIGxvY2FsIHRpbWUgd2hlcmUgdGhl" +
           "IGV2ZW50IG9yaWdpbmF0ZWQuAC4ARFMDAAABANAi/////wEB/////wAAAAA1YIkKAgAAAAAABwAAAE1l" +
           "c3NhZ2UBAVQDAwAAAAAlAAAAQSBsb2NhbGl6ZWQgZGVzY3JpcHRpb24gb2YgdGhlIGV2ZW50LgAuAERU" +
           "AwAAABX/////AQH/////AAAAADVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAVUDAwAAAAAhAAAASW5kaWNh" +
           "dGVzIGhvdyB1cmdlbnQgYW4gZXZlbnQgaXMuAC4ARFUDAAAABf////8BAf////8AAAAANWCJCgIAAAAA" +
           "AA8AAABBY3Rpb25UaW1lU3RhbXABAVYDAwAAAAAuAAAAV2hlbiB0aGUgYWN0aW9uIHRyaWdnZXJpbmcg" +
           "dGhlIGV2ZW50IG9jY3VycmVkLgAuAERWAwAAAQAmAf////8BAf////8AAAAANWCJCgIAAAAAAAYAAABT" +
           "dGF0dXMBAVcDAwAAAABhAAAASWYgVFJVRSB0aGUgYWN0aW9uIHdhcyBwZXJmb3JtZWQuIElmIEZBTFNF" +
           "IHRoZSBhY3Rpb24gZmFpbGVkIGFuZCB0aGUgc2VydmVyIHN0YXRlIGRpZCBub3QgY2hhbmdlLgAuAERX" +
           "AwAAAAH/////AQH/////AAAAADVgiQoCAAAAAAAIAAAAU2VydmVySWQBAVgDAwAAAAA6AAAAVGhlIHVu" +
           "aXF1ZSBpZGVudGlmaWVyIGZvciB0aGUgc2VydmVyIGdlbmVyYXRpbmcgdGhlIGV2ZW50LgAuAERYAwAA" +
           "AAz/////AQH/////AAAAADVgiQoCAAAAAAASAAAAQ2xpZW50QXVkaXRFbnRyeUlkAQFZAwMAAAAAQwAA" +
           "AFRoZSBsb2cgZW50cnkgaWQgcHJvdmlkZWQgaW4gdGhlIHJlcXVlc3QgdGhhdCBpbml0aWF0ZWQgdGhl" +
           "IGFjdGlvbi4ALgBEWQMAAAAM/////wEB/////wAAAAA1YIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEB" +
           "WgMDAAAAAEgAAABUaGUgdXNlciBpZGVudGl0eSBhc3NvY2lhdGVkIHdpdGggdGhlIHNlc3Npb24gdGhh" +
           "dCBpbml0aWF0ZWQgdGhlIGFjdGlvbi4ALgBEWgMAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAACAAA" +
           "AE1ldGhvZElkAQFbAwAuAERbAwAAABH/////AQH/////AAAAABVgiQoCAAAAAAAOAAAASW5wdXRBcmd1" +
           "bWVudHMBAVwDAC4ARFwDAAAAGAEAAAABAf////8AAAAAFWCJCgIAAAABAAoAAABTZXJ2aWNlVXJpAQFd" +
           "AwAuAERdAwAAAAz/////AQH/////AAAAAA==";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// A description for the ServiceUri Property.
        /// </summary>
        public PropertyState<string> ServiceUri
        {
            get
            {
                return m_serviceUri;
            }

            set
            {
                if (!Object.ReferenceEquals(m_serviceUri, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_serviceUri = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_serviceUri != null)
            {
                children.Add(m_serviceUri);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case Opc.Ua.Gds.BrowseNames.ServiceUri:
                {
                    if (createOrReplace)
                    {
                        if (ServiceUri == null)
                        {
                            if (replacement == null)
                            {
                                ServiceUri = new PropertyState<string>(this);
                            }
                            else
                            {
                                ServiceUri = (PropertyState<string>)replacement;
                            }
                        }
                    }

                    instance = ServiceUri;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private PropertyState<string> m_serviceUri;
        #endregion
    }
    #endif
    #endregion
}