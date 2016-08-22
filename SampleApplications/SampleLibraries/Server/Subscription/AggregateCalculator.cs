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
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.Threading;
using System.Diagnostics;
using System.Globalization;

namespace Opc.Ua.Server
{	
    /// <summary>
    /// Calculates the value for an aggregate.
    /// </summary>
    public class AggregateCalculator
    {
        #region Public Methods
        /// <summary>
        /// Initializes the aggregate calculator with a filter.
        /// </summary>
        public virtual void Initialize(AggregateFilter filter)
        {
            m_startTime = filter.StartTime;
            m_processingInterval = filter.ProcessingInterval;
        }

        /// <summary>
        /// Returns the processed values.
        /// </summary>
        public IList<DataValue> GetProcessedValues()
        {
            DateTime now = DateTime.UtcNow;

            List<DataValue> processedValues = null;
            
            // check if at least one interval has elasped.
            if ((now.Ticks - m_startTime.Ticks) > m_processingInterval*TimeSpan.TicksPerMillisecond)
            {
                processedValues = new List<DataValue>();

                // process all completed intervals.
                while (m_startTime.AddMilliseconds(m_processingInterval) < now)
                {
                    // get the next process value.
                    DataValue processedValue = GetProcessedValue(m_worstStatus, m_startTime, m_processingInterval);

                    // cast the processed value to the last received data type.
                    if (m_typeInfo != null && m_typeInfo.BuiltInType != BuiltInType.Double)
                    {
                        if (StatusCode.IsGood(processedValue.StatusCode))
                        {
                            try
                            {
                                processedValue.Value = TypeInfo.Cast(processedValue.Value, m_typeInfo.BuiltInType);
                            }
                            catch (Exception)
                            {
                                processedValue = new DataValue(StatusCodes.BadTypeMismatch);
                            }
                        }
                    }

                    // reset object for the start of the next interval.
                    m_startTime = m_startTime.AddMilliseconds(m_processingInterval);
                    m_worstStatus = StatusCodes.Good;

                    // server timestamp always the end of the interval.
                    processedValue.ServerTimestamp = m_startTime;

                    // add to list.
                    processedValues.Add(processedValue);
                }
            }

            return processedValues;
        }

        /// <summary>
        /// Processes an incoming value.
        /// </summary>
        /// <remarks>
        /// Returns a set of processed data value if an interval is complete.
        /// </remarks>
        public IList<DataValue> ProcessValue(DataValue value, ServiceResult result)
        {
            // returns the processed values.
            IList<DataValue> processedValues = GetProcessedValues();

            // check for bad status.
            if (StatusCode.IsNotBad(m_worstStatus))
            {
                if (StatusCode.IsBad(value.StatusCode))
                {
                    m_worstStatus = value.StatusCode;
                }
            }

            // check for uncertain status.
            if (StatusCode.IsGood(m_worstStatus))
            {
                if (StatusCode.IsUncertain(value.StatusCode))
                {
                    m_worstStatus = value.StatusCode;
                }
            }

            // process good or uncertain value.
            if (StatusCode.IsNotBad(value.StatusCode))
            {
                // save the last data type used.
                TypeInfo typeInfo = TypeInfo.Construct(value.Value);

                if (m_typeInfo == null || m_typeInfo.BuiltInType != typeInfo.BuiltInType)
                {
                    m_typeInfo = typeInfo;
                }

                // process the sample.
                try
                {
                    double sample = Convert.ToDouble(value.Value, CultureInfo.InvariantCulture);
                    ProcessValue(sample, value.StatusCode, value.SourceTimestamp, m_startTime, m_processingInterval);
                }
                catch (Exception)
                {
                    m_worstStatus = StatusCodes.BadTypeMismatch;
                }                
            }

            return processedValues;
        }
        #endregion
        
        #region Protected Methods
        /// <summary>
        /// Returns the processed value for the interval. Sets the source timestamp and status.
        /// </summary>
        /// <remarks>
        /// Resets the object
        /// </remarks>
        protected virtual DataValue GetProcessedValue(
            StatusCode worstStatus, 
            DateTime   startTime, 
            double     processingInterval)
        {
            DataValue value = new DataValue(StatusCodes.BadNoData);
            value.SourceTimestamp = startTime;
            return value;
        }

        /// <summary>
        /// Processes the incoming value.
        /// </summary>
        protected virtual void ProcessValue(
            double     value, 
            StatusCode status, 
            DateTime   timestamp,
            DateTime   startTime, 
            double     processingInterval)
        {
        }
        #endregion

        #region Private Fields
        private TypeInfo m_typeInfo;
        private StatusCode m_worstStatus;
        private DateTime m_startTime;
        private double m_processingInterval;
        #endregion
    }

    /// <summary>
    /// Calculates the maximum aggregate for a stream of values.
    /// </summary>
    public class MaxAggregateCalculator : AggregateCalculator
    {        
        #region Overridden Methods
        /// <summary cref="AggregateCalculator.GetProcessedValue" />
        protected override DataValue GetProcessedValue(
            StatusCode worstStatus, 
            DateTime   startTime, 
            double     processingInterval)
        {
            DataValue value = null;

            if (!m_dataExists)
            {                
                value = new DataValue(StatusCodes.BadNoData);
                value.SourceTimestamp = startTime;
                return value;
            }

            StatusCode status = worstStatus;
            status.AggregateBits = AggregateBits.Calculated;

            value = new DataValue(m_maximumValue, status, startTime);

            m_maximumValue = Double.MinValue;
            m_dataExists   = false;

            return value;
        }

        /// <summary cref="AggregateCalculator.ProcessValue(double,StatusCode,DateTime,DateTime,double)" />
        protected override void ProcessValue(
            double     value, 
            StatusCode status, 
            DateTime   timestamp,
            DateTime   startTime, 
            double     processingInterval)
        {
            if (!m_dataExists || m_maximumValue < value)
            {
                m_maximumValue = value;
                m_dataExists = true;
            }
        }
        #endregion

        #region Private Fields
        private double m_maximumValue;
        private bool m_dataExists;
        #endregion
    }
}
