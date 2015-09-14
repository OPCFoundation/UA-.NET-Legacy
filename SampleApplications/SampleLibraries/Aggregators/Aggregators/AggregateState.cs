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
using System.Globalization;
using System.Text;

namespace Opc.Ua.Server
{
    /// <summary>
    /// A snapshot of a structured window over a stream of data to be aggregated
    /// </summary>
    public class AggregateCursor
    {
        /// <summary>
        /// A good data point later in time than the processed point(s) we want to compute.
        /// It could be used as one bounding value in a sloped interpolation. or as the only
        /// value needed for stepped interpolation. EarlyPoint and LatePoint may also be used
        /// to provide stepped extrapolation. If both exist, they may be used for sloped
        /// extrapolation
        /// </summary>
        public DataValue LatePoint { get; set; }

        /// <summary>
        /// A good data point earlier in time than the processed point(s) we want to compute.
        /// It could be used as one bounding value in a sloped interpolation. or as the only
        /// value needed for stepped interpolation. EarlyPoint and LatePoint may also be used
        /// to provide stepped extrapolation. If both exist, they may be used for sloped
        /// extrapolation
        /// </summary>
        public DataValue EarlyPoint { get; set; }

        /// <summary>
        /// The most recently superceded value of EarlyPoint. This is therefore a good data point.
        /// It can be used for sloped extrapolation with EarlyPoint in the case where no good
        /// value exists for LatePoint.
        /// </summary>
        public DataValue PriorPoint { get; set; }

        /// <summary>
        /// A collection of all bad points received since EarlyPoint. This is required to
        /// compute the status of interpolated and extrapolated points that use EarlyPoint as
        /// one bounding value.
        /// </summary>
        public List<DataValue> CurrentBadPoints { get; set; }

        /// <summary>
        /// A collection of all bad points received between PriorPoint and EarlyPoint. This
        /// is required to compute the status of values extrapolated using both PriorPoint and
        /// EarlyPoint.
        /// </summary>
        public List<DataValue> PriorBadPoints { get; set; }
    }

    /// <summary>
    /// Represents a snapshot or window onto a stream of raw data, presenting an interface
    /// helpful to aggregation methods
    /// </summary>
    public class AggregateState : AggregateCursor
    {
        /// <summary>
        /// Timestamp of the latest raw data point to be input. Note: this is not the most recent
        /// timestamp value that has been input, it is the timestamp of the raw data point most
        /// recently handled.
        /// </summary>
        public DateTime LatestTimestamp { get; set; }

        /// <summary>
        /// StatusCode of the latest raw data point to be input. Note: this is not the most recent
        /// StatusCode value that has been input, it is the StatusCode of the raw data point most
        /// recently handled.
        /// </summary>
        public StatusCode LatestStatus { get; set; }

        /// <summary>
        /// Indicates that no more data will be provided, regardless of whether we have enough
        /// to calculate good values for all of the remaining aggregation intervals
        /// </summary>
        public bool HasTerminated { get; set; }

        /// <summary>
        /// Provides contextual details of the aggregation
        /// </summary>
        private IAggregationContext AggregationContext;

        /// <summary>
        /// Something to call back on when we are ready to produce processed data points
        /// </summary>
        private IAggregationActor AggregationActor;

        public AggregateState(IAggregationContext context, IAggregationActor actor)
        {
            AggregationContext = context;
            AggregationActor = actor;
            CurrentBadPoints = new List<DataValue>();
            PriorBadPoints = new List<DataValue>();
        }

        /// <summary>
        /// Use the TreatUncertainAsBad directive to determine whether a raw data point is a
        /// good value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool RawValueIsGood(DataValue value)
        {
            if (AggregationContext.TreatUncertainAsBad)
                return StatusCode.IsGood(value.StatusCode);
            else
                return !StatusCode.IsBad(value.StatusCode);
        }

        /// <summary>
        /// Returns a -1 if we are not yet far enough into the stream of raw data points to
        /// be in the time range of the aggregation. Once we are in the time range, the return
        /// value will be 0. After we have left the time range, the return value will be 1.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private int RawValueInWindow(DataValue value)
        {
            int retval = -1;
            if (AggregationContext.IsReverseAggregation)
            {
                if (value.SourceTimestamp <= AggregationContext.EndTime) retval = 0;
                if (value.SourceTimestamp <= AggregationContext.StartTime) retval = 1;
            }
            else
            {
                if (value.SourceTimestamp >= AggregationContext.StartTime) retval = 0;
                if (value.SourceTimestamp >= AggregationContext.EndTime) retval = 1;
            }
            return retval;
        }

        /// <summary>
        /// Accept one raw data value.
        /// </summary>
        /// <param name="rawData"></param>
        public void AddRawData(DataValue rawData)
        {
            if (rawData == null) throw new ArgumentException("Attempted to add null value instead of valid DataValue");
            LatestTimestamp = rawData.SourceTimestamp;
            LatestStatus = rawData.StatusCode;
            int relevance = RawValueInWindow(rawData);
            if (RawValueIsGood(rawData))
            {
                switch (relevance)
                {
                    case -1:
                        PriorPoint = EarlyPoint;
                        PriorBadPoints = CurrentBadPoints;
                        EarlyPoint = rawData;
                        CurrentBadPoints = new List<DataValue>();
                        break;
                    case 0:
                        if (EarlyPoint == null)
                        {
                            PriorBadPoints = CurrentBadPoints;
                            EarlyPoint = rawData;
                            CurrentBadPoints = new List<DataValue>();
                            AggregationActor.UpdateProcessedData(rawData, this);
                        }
                        else
                        {
                            LatePoint = rawData;
                            AggregationActor.UpdateProcessedData(rawData, this);
                            PriorPoint = EarlyPoint;
                            PriorBadPoints = CurrentBadPoints;
                            EarlyPoint = rawData;
                            LatePoint = null;
                            CurrentBadPoints = new List<DataValue>();
                        }
                        break;
                    case 1:
                        if (LatePoint == null)
                            LatePoint = rawData;
                        AggregationActor.UpdateProcessedData(rawData, this);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                if (LatePoint == null)
                {
                    CurrentBadPoints.Add(rawData);
                    if (relevance >= 0)
                        AggregationActor.UpdateProcessedData(rawData, this);
                }
            }
        }

        /// <summary>
        /// Call once to indicate that the end of the sequence of raw data points has been
        /// reached.
        /// </summary>
        public void EndOfData()
        {
            HasTerminated = true;
            LatestTimestamp = DateTime.MaxValue;
            LatestStatus = StatusCodes.GoodNoData;
            AggregationActor.UpdateProcessedData(null, this);
        }
    }

    public enum BoundingValueType
    {
        None,
        Raw,
        QualityRaw,
        SteppedInterpolation,
        SlopedInterpolation,
        QualityInterpolation,
        SteppedExtrapolation,
        SlopedExtrapolation,
        QualityExtrapolation
    }

    public class BoundingValue : AggregateCursor
    {
        /// <summary>
        /// Indicates how the bounding value was obtained.
        /// </summary>
        public BoundingValueType DerivationType { get; set; }

        /// <summary>
        /// Timestamp of the boundary
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// A good data point coincident in time to the bounding value we want to compute.
        /// </summary>
        public DataValue RawPoint { get; set; }

        private double ProjectedValue(DataValue p1, DataValue p2, DateTime time)
        {
            double ve = Convert.ToDouble(p1.Value, CultureInfo.InvariantCulture);
            double vl = Convert.ToDouble(p2.Value, CultureInfo.InvariantCulture);
            double fraction = (time - p1.SourceTimestamp).TotalMilliseconds /
                              (p2.SourceTimestamp - p1.SourceTimestamp).TotalMilliseconds;
            return ve + (fraction * (vl - ve));
        }

        public DataValue Value
        {
            get
            {
                if (_value == null)
                {
                    StatusCode code = 0;
                    switch (DerivationType)
                    {
                        case BoundingValueType.Raw:
                            if (RawPoint != null)
                            {
                                _value = new DataValue(RawPoint);
                                _value.ServerTimestamp = DateTime.UtcNow;
                                code = StatusCodes.Good;
                                code.AggregateBits = AggregateBits.Raw;
                                _value.StatusCode = code;
                            }
                            break;
                        case BoundingValueType.QualityRaw:
                            if (RawPoint != null)
                            {
                                _value = new DataValue();
                                _value.Value = RawPoint.StatusCode;
                                _value.SourceTimestamp = Timestamp;
                                _value.ServerTimestamp = DateTime.UtcNow;
                                code = StatusCodes.Good;
                                code.AggregateBits = AggregateBits.Raw;
                                _value.StatusCode = code;
                            }
                            break;
                        case BoundingValueType.SlopedExtrapolation:
                            if ((PriorPoint != null) && (EarlyPoint != null))
                            {
                                _value = new DataValue();
                                _value.Value = ProjectedValue(PriorPoint, EarlyPoint, Timestamp);
                                _value.SourceTimestamp = Timestamp;
                                _value.ServerTimestamp = DateTime.UtcNow;
                                code = StatusCodes.UncertainDataSubNormal;
                                code.AggregateBits = AggregateBits.Interpolated;
                                _value.StatusCode = code;
                            }
                            break;
                        case BoundingValueType.SlopedInterpolation:
                            if ((EarlyPoint != null) && (LatePoint != null))
                            {
                                _value = new DataValue(EarlyPoint);
                                _value.Value = ProjectedValue(EarlyPoint, LatePoint, Timestamp);
                                _value.SourceTimestamp = Timestamp;
                                _value.ServerTimestamp = DateTime.UtcNow;
                                code = (CurrentBadPoints.Count > 0) ? StatusCodes.UncertainDataSubNormal : StatusCodes.Good;
                                code.AggregateBits = AggregateBits.Interpolated;
                                _value.StatusCode = code;
                            }
                            break;
                        case BoundingValueType.SteppedExtrapolation:
                            if (EarlyPoint != null)
                            {
                                _value = new DataValue(EarlyPoint);
                                _value.SourceTimestamp = Timestamp;
                                _value.ServerTimestamp = DateTime.UtcNow;
                                code = StatusCodes.UncertainDataSubNormal;
                                code.AggregateBits = AggregateBits.Interpolated;
                                _value.StatusCode = code;
                            }
                            break;
                        case BoundingValueType.SteppedInterpolation:
                            if (EarlyPoint != null)
                            {
                                _value = new DataValue(EarlyPoint);
                                _value.SourceTimestamp = Timestamp;
                                _value.ServerTimestamp = DateTime.UtcNow;
                                code = (CurrentBadPoints.Count > 0) ? StatusCodes.UncertainDataSubNormal : StatusCodes.Good;
                                code.AggregateBits = AggregateBits.Interpolated;
                                _value.StatusCode = code;
                            }
                            break;
                        case BoundingValueType.QualityExtrapolation:
                            if (EarlyPoint != null)
                            {
                                _value = new DataValue();
                                DataValue valueToUse = EarlyPoint;
                                foreach (DataValue dv in CurrentBadPoints)
                                    if ((dv.SourceTimestamp > valueToUse.SourceTimestamp) && (dv.SourceTimestamp < Timestamp))
                                        valueToUse = dv;
                                _value.Value = valueToUse.StatusCode;
                                _value.SourceTimestamp = Timestamp;
                                _value.ServerTimestamp = DateTime.UtcNow;
                                code = StatusCodes.UncertainDataSubNormal;
                                code.AggregateBits = AggregateBits.Interpolated;
                                _value.StatusCode = code;
                            }
                            break;
                        case BoundingValueType.QualityInterpolation:
                            if (EarlyPoint != null)
                            {
                                _value = new DataValue();
                                DataValue valueToUse = EarlyPoint;
                                foreach (DataValue dv in CurrentBadPoints)
                                    if ((dv.SourceTimestamp > valueToUse.SourceTimestamp) && (dv.SourceTimestamp < Timestamp))
                                        valueToUse = dv;
                                _value.Value = valueToUse.StatusCode;
                                _value.SourceTimestamp = Timestamp;
                                _value.ServerTimestamp = DateTime.UtcNow;
                                code = StatusCodes.Good;
                                code.AggregateBits = AggregateBits.Interpolated;
                                _value.StatusCode = code;
                            }
                            break;
                        case BoundingValueType.None:
                        default:
                            break;
                    }
                }
                return _value;
            }
        } private DataValue _value = null;
    }
}
