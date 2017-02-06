/* Copyright (c) 1996-2017, OPC Foundation. All rights reserved.

   The source code in this file is covered under a dual-license scenario:
     - RCL: for OPC Foundation members in good-standing
     - GPL V2: everybody else

   RCL license terms accompanied with this source code. See http://opcfoundation.org/License/RCL/1.00/

   GNU General Public License as published by the Free Software Foundation;
   version 2 of the License are accompanied with this source code. See http://opcfoundation.org/License/GPLv2

   This source code is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.ComponentModel;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.ServiceModel;

namespace Opc.Ua
{	
	/// <summary>
	/// An exception thrown when a UA defined error occurs.
	/// </summary>
    [Serializable]
	public class ServiceResultException : Exception
	{
		#region Constructors
		/// <summary>
		/// The default constructor.
		/// </summary>
		public ServiceResultException() : base(Strings.DefaultMessage)
		{
            m_status = StatusCodes.Bad;

            if ((Utils.TraceMask & Utils.TraceMasks.StackTrace) != 0)
            {
                Utils.Trace(Utils.TraceMasks.StackTrace, "***EXCEPTION*** {0}", m_status);
            }
		}

		/// <summary>
		/// Initializes the exception with a message.
		/// </summary>
		public ServiceResultException(string message) : base(message)
		{
            m_status = StatusCodes.Bad;

            if ((Utils.TraceMask & Utils.TraceMasks.StackTrace) != 0)
            {
                Utils.Trace(Utils.TraceMasks.StackTrace, "***EXCEPTION*** {0} {1}", m_status, message);
            }
		}
                
		/// <summary>
		/// Initializes the exception with a message and an exception.
		/// </summary>
		public ServiceResultException(Exception e, uint defaultCode) : base(e.Message, e)
		{
            m_status = ServiceResult.Create(e, defaultCode, String.Empty);

            if ((Utils.TraceMask & Utils.TraceMasks.StackTrace) != 0)
            {
                Utils.Trace(Utils.TraceMasks.StackTrace, "***EXCEPTION*** {0} {1} {2}", m_status, e.GetType().Name, e.Message);
            }
		}
                        
		/// <summary>
		/// Initializes the exception with a message and an exception.
		/// </summary>
		public ServiceResultException(string message, Exception e) : base(message, e)
		{
            m_status = StatusCodes.Bad;

            if ((Utils.TraceMask & Utils.TraceMasks.StackTrace) != 0)
            {
                Utils.Trace(Utils.TraceMasks.StackTrace, "***EXCEPTION*** {0} {1} {2}", m_status, e.GetType().Name, message);
            }
		}

		/// <summary>
		/// Initializes the exception with a status code.
		/// </summary>
		public ServiceResultException(uint statusCode) : base(GetMessage(statusCode))
		{
			m_status = new ServiceResult(statusCode);

            if ((Utils.TraceMask & Utils.TraceMasks.StackTrace) != 0)
            {
                Utils.Trace(Utils.TraceMasks.StackTrace, "***EXCEPTION*** {0}", m_status);
            }
		}

		/// <summary>
		/// Initializes the exception with a status code and a message.
		/// </summary>
		public ServiceResultException(uint statusCode, string message) : base(message)
		{
            m_status = new ServiceResult(statusCode, message);

            if ((Utils.TraceMask & Utils.TraceMasks.StackTrace) != 0)
            {
                Utils.Trace(Utils.TraceMasks.StackTrace, "***EXCEPTION*** {0} {1}", m_status, message);
            }
		}

		/// <summary>
		/// Initializes the exception with a status code and an inner exception.
		/// </summary>
		public ServiceResultException(uint statusCode, Exception e) : base(GetMessage(statusCode), e)
		{
            m_status = new ServiceResult(statusCode, e);

            if ((Utils.TraceMask & Utils.TraceMasks.StackTrace) != 0)
            {
                Utils.Trace(Utils.TraceMasks.StackTrace, "***EXCEPTION*** {0} {1} {2}", m_status, e.GetType().Name, e.Message);
            }
		}

		/// <summary>
		/// Initializes the exception with a status code, a message and an inner exception.
		/// </summary>
		public ServiceResultException(uint statusCode, string message, Exception e) : base(message, e)
		{
            m_status = new ServiceResult(statusCode, message, e);
            
            if ((Utils.TraceMask & Utils.TraceMasks.StackTrace) != 0)
            {
                Utils.Trace(Utils.TraceMasks.StackTrace, "***EXCEPTION*** {0} {1} {2}", m_status, e.GetType().Name, message);
            }
		}

		/// <summary>
		/// Initializes the exception with a Result object.
		/// </summary>
		public ServiceResultException(ServiceResult status) : base(GetMessage(status))
		{
			if (status != null)
			{
				m_status = status;
			}
			else
			{
				m_status = new ServiceResult(StatusCodes.Bad);
            }

            // avoid false warnings in the log file when closing the channel.
            if (((Utils.TraceMask & Utils.TraceMasks.StackTrace) != 0) && (status == null || (status != null && status.Code != StatusCodes.BadSecureChannelClosed)))
            {
                Utils.Trace(Utils.TraceMasks.StackTrace, "***EXCEPTION*** {0}", m_status);
            }
		}
		#endregion

		#region Public Properties
		/// <summary>
		/// The identifier for the status code.
		/// </summary>
		public uint StatusCode
		{
			get { return m_status.Code; }
		}

		/// <summary>
		/// The namespace that qualifies symbolic identifier.
		/// </summary>		
		public string NamespaceUri
		{
			get { return m_status.NamespaceUri; }
		}

		/// <summary>
		/// The qualified name of the symbolic identifier associated with the status code.
		/// </summary>		
		public string SymbolicId
		{
			get { return m_status.SymbolicId; }
		}

		/// <summary>
		/// The localized description for the status code.
		/// </summary>
		public LocalizedText LocalizedText
		{
			get { return m_status.LocalizedText; }	
		}

		/// <summary>
		/// Additional diagnostic/debugging information associated with the operation.
		/// </summary>
		public string AdditionalInfo
		{
			get { return m_status.AdditionalInfo; }
		}

		/// <summary>
		/// Returns the status result associated with the exception.
		/// </summary>
		public ServiceResult Result
		{
			get { return m_status; }
		}

		/// <summary>
		/// Nested error information.
		/// </summary>
		public ServiceResult InnerResult
		{
			get { return m_status.InnerResult;  }
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Returns a formatted string with the contents of exeception.
		/// </summary>
		public string ToLongString()
		{
			StringBuilder buffer = new StringBuilder();

			buffer.Append(Message);
			buffer.Append("\r\n");
			buffer.Append(m_status.ToLongString());

			return buffer.ToString();
		}
		#endregion
                        
		#region Static Interface
        /// <summary>
        /// Creates a new instance of a ServiceResultException
        /// </summary>
        public static ServiceResultException Create(uint code, string format, params object[] args)
        {
            if (format == null)
            {
                return new ServiceResultException(code);
            }

            return new ServiceResultException(code, Utils.Format(format, args));
        }
        
        /// <summary>
        /// Creates a new instance of a ServiceResultException
        /// </summary>
        public static ServiceResultException Create(uint code, Exception e, string format, params object[] args)
        {
            if (format == null)
            {
                return new ServiceResultException(code, e);
            }

            return new ServiceResultException(code, Utils.Format(format, args), e);
        }

        /// <summary>
        /// Creates a new instance of a ServiceResultException
        /// </summary>
        public static ServiceResultException Create(StatusCode code, int index, DiagnosticInfoCollection diagnosticInfos, IList<string> stringTable)
        {
            return new ServiceResultException(new ServiceResult(code, index, diagnosticInfos, stringTable));
        }
        #endregion

        #region Private Methods
        /// <summary>
		/// Extracts an exception message from a Result object.
		/// </summary>
		private static string GetMessage(ServiceResult status)
		{
			if (status == null)
			{
				return Strings.DefaultMessage;
			}

			if (!LocalizedText.IsNullOrEmpty(status.LocalizedText))
			{
				return status.LocalizedText.Text;
			}

			return status.ToString();
		}
		#endregion

		#region Private Fields
		private ServiceResult m_status;
		#endregion

		#region Private Constants
		/// <summary>
		/// Wraps string constants defined in the class.
		/// </summary>
		private static class Strings
		{
            public const string DefaultMessage = "A UA specific error occurred.";
		}
		#endregion

        #region ISerializable Members
        #if !SILVERLIGHT
		/// <summary>
		/// Initializes the object from a stream.
		/// </summary>
		protected ServiceResultException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
            if (info == null)
            {
                throw new System.ArgumentNullException("info - ServiceResultException");
            }

            m_status = DeserializeServiceResult(info, string.Empty);    
		}

        /// <summary>
        /// Writes the object to the stream.
        /// </summary>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            if (info == null)
            {
                throw new System.ArgumentNullException("info - ServiceResultException - GetObjectData");
            }

            SerializeServiceResult(info, m_status, string.Empty);
        }

        /// <summary>
        /// Serializes the service result.
        /// </summary>
        /// <param name="info">The info.</param>
        /// <param name="serviceResult">The service result.</param>
        /// <param name="prefix">The prefix.</param>
        private static void SerializeServiceResult(SerializationInfo info, ServiceResult serviceResult, string prefix)
        {
            info.AddValue(prefix + "StatusCode", serviceResult.Code);
            info.AddValue(prefix + "NamespaceUri", serviceResult.NamespaceUri);
            info.AddValue(prefix + "SymbolicId", serviceResult.SymbolicId);
            info.AddValue(prefix + "AdditionalInfo", serviceResult.AdditionalInfo);

            if (serviceResult.LocalizedText != null)
            {
                info.AddValue(prefix + "LocalizedTextText", serviceResult.LocalizedText.Text);
                info.AddValue(prefix + "LocalizedTextKey", serviceResult.LocalizedText.Key);
                info.AddValue(prefix + "LocalizedTextLocale", serviceResult.LocalizedText.Locale);
            }

            if (serviceResult.InnerResult != null)
            {
                SerializeServiceResult(info, serviceResult.InnerResult, "InnerResult");
            }
        }

        /// <summary>
        /// Deserializes the service result.
        /// </summary>
        /// <param name="info">The info.</param>
        /// <param name="prefix">The prefix.</param>
        /// <returns></returns>
        private static ServiceResult DeserializeServiceResult(SerializationInfo info, string prefix)
        {
            uint statusCode = info.GetUInt32(prefix + "StatusCode");
            string namespaceUri = info.GetString(prefix + "NamespaceUri");
            string symbolicId = info.GetString(prefix + "SymbolicId");
            string additionalInfo = info.GetString(prefix + "AdditionalInfo");

            bool isLocalizedTextNull = false;
            string localizedTextText = null;
            LocalizedText localizedText = null;

            try
            {
                localizedTextText = info.GetString(prefix + "LocalizedTextText");
            }
            catch (SerializationException ex)
            {
                isLocalizedTextNull = true;
                Utils.Trace("Deserialization - localized text is null." + ex.Message);
            }

            if (!isLocalizedTextNull)
            {
                string localizedTextKey = info.GetString(prefix + "LocalizedTextKey");
                string localizedTextLocale = info.GetString(prefix + "LocalizedTextLocale");
                if (localizedTextText != null || localizedTextLocale != null || localizedTextKey != null)
                {
                    localizedText = new LocalizedText(localizedTextKey, localizedTextLocale, localizedTextText);
                }
            }

            bool isInnerResultNull = false;
            ServiceResult innerServiceResult = null;
            uint innerResultStatusCode;
            try
            {
                innerResultStatusCode = info.GetUInt32(prefix + "InnerResultStatusCode");
            }
            catch (SerializationException ex)
            {
                isInnerResultNull = true;
                Utils.Trace("Deserialization - inner result is null." + ex.Message);
            }

            if (!isInnerResultNull)
            {
                innerServiceResult = DeserializeServiceResult(info, prefix + "InnerResult");
            }

            return new ServiceResult(statusCode, symbolicId, namespaceUri, localizedText, additionalInfo, innerServiceResult);
        }
        #endif
        #endregion
    }		
}
