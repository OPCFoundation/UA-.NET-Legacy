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
using System.Text;

namespace Opc.Ua.Server
{
    /// <summary>
    /// All aggregators implement this interface. It describes the relationship between the
    /// aggregator and any TimeSlice instances processed by it.
    /// </summary>
    public interface IAggregator
    {
        /// <summary>
        /// Compute a processed value from raw values in a slice of time.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="bucket"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        DataValue Compute(IAggregationContext context, TimeSlice bucket, AggregateState state);

        /// <summary>
        /// Determine whether there is sufficient data in a TimeSlice with respect to the
        /// AggregateState to permit reliable computation of a processed value. This decision
        /// is largely governed by the requirements for interpolation or extrapolation.
        /// </summary>
        /// <param name="bucket"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        bool WaitForMoreData(TimeSlice bucket, AggregateState state);

        /// <summary>
        /// Take snapshot data from the AggregationState in order to determine bounding values
        /// for the TimeSlice.
        /// </summary>
        /// <param name="bucket"></param>
        /// <param name="state"></param>
        void UpdateBoundingValues(TimeSlice bucket, AggregateState state);
    }

    /// <summary>
    /// An interface that allows the basic information about an aggregate query to be
    /// communicated
    /// </summary>
    public interface IAggregationContext
    {
        /// <summary>
        /// The start of the time window we are aggregating over. Note this may be later
        /// than the EndTime.
        /// </summary>
        DateTime StartTime { get; }

        /// <summary>
        /// The end time of the window we are aggregating over, if known. Note this may be
        /// earlier than the StartTime.
        /// </summary>
        DateTime EndTime { get; }

        /// <summary>
        /// The size (in milliseconds) of each sampling interval in the time window. If this
        /// is zero, then the entire window is treated as one sampling interval.
        /// </summary>
        double ProcessingInterval { get; }

        /// <summary>
        /// Indicates that the time window for aggregation has a start time later than its
        /// end time, and that raw data will be presented in reverse order.
        /// This value is computed from StartTime and EndTime, however EndTime will be null
        /// if the aggregation is used as a filter in a subscription.
        /// </summary>
        bool IsReverseAggregation { get; }

        /// <summary>
        /// The maximum percentage of points in a sampling interval that may be bad  for
        /// the processed value to have a non-bad status
        /// </summary>
        byte PercentDataBad { get; }

        /// <summary>
        /// The minimum percentage of points in a sampling interval that must be good
        /// for the processed value to have a good status
        /// </summary>
        byte PercentDataGood { get; }

        /// <summary>
        /// Indicator thet determines whether stepped or sloped extrapolation should
        /// be used
        /// </summary>
        bool UseSlopedExtrapolation { get; }
        
        /// <summary>
        /// Indicator that determines whether stepped or sloped interpolation should
        /// be used
        /// </summary>
        bool SteppedVariable { get; }

        /// <summary>
        /// Indicates that raw data points with status Uncertain should be handled as if they
        /// were bad points rather than as good points.
        /// </summary>
        bool TreatUncertainAsBad { get; }
    }

    /// <summary>
    /// An interface that allows new processed data points to be generated as a response to
    /// new raw data
    /// </summary>
    public interface IAggregationActor
    {
        /// <summary>
        /// Causes the derivation of 0 or more new processed data points from the given raw
        /// data point and the current state of the aggregator.
        /// </summary>
        /// <param name="rawValue"></param>
        /// <param name="state"></param>
        void UpdateProcessedData(DataValue rawValue, AggregateState state);

        /// <summary>
        /// Allows those processed data points already derived to be released to the outside
        /// world.
        /// </summary>
        /// <returns></returns>
        IList<DataValue> ProcessedValues();
    }

    /// <summary>
    /// An interface that captures the original active API of the AggregateCalculator class
    /// required to integrate with the subscription code.
    /// </summary>
    public interface IAggregateCalculator
    {
        /// <summary>
        /// Returns the processed values.
        /// *** Is this ever used? ***
        /// </summary>
        IList<DataValue> GetProcessedValues();

        /// <summary>
        /// Processes an incoming value.
        /// </summary>
        /// <remarks>
        /// Returns a set of processed data values if any intervals are complete.
        /// </remarks>
        IList<DataValue> ProcessValue(DataValue value, ServiceResult result);

        /// <summary>
        /// Processes the fact that there is no more data.
        /// </summary>
        /// <remarks>
        /// Returns a set of processed data values if any intervals is remain to be processed.
        /// </remarks>
        IList<DataValue> ProcessTermination(ServiceResult result);
    }

    /// <summary>
    /// Coordinates aggregation over a time series of raw data points to yield a time
    /// series of processed data points.
    /// </summary>
    public abstract class AggregateCalculatorImpl : IAggregateCalculator, IAggregationContext, IAggregationActor, IAggregator
    {
        public AggregateConfiguration Configuration { get; set; }
        private AggregateState m_state = null;

        private TimeSlice m_latest;
        private Queue<TimeSlice> m_pending;
        private List<DataValue> m_released;

        #region IAggregationContext Members

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsReverseAggregation { get { return EndTime < StartTime; } }
        public byte PercentDataBad { get { return Configuration.PercentDataBad; } }
        public byte PercentDataGood { get { return Configuration.PercentDataGood; } }
        public bool UseSlopedExtrapolation { get { return Configuration.UseSlopedExtrapolation; } }
        public bool SteppedVariable { get; set; }
        public bool TreatUncertainAsBad { get { return Configuration.TreatUncertainAsBad; } }
        public double ProcessingInterval { get; set; }

        #endregion

        private void InitializeAggregation()
        {
            m_state = new AggregateState(this, this);
        }

        #region IAggregateCalculator Members

        public IList<DataValue> GetProcessedValues()
        {
            throw new NotImplementedException();
        }

        public IList<DataValue> ProcessValue(DataValue value, ServiceResult result)
        {
            if (m_state == null) InitializeAggregation();
            m_state.AddRawData(value);
            // TODO: something with ServiceResult...
            return ProcessedValues();
        }

        public IList<DataValue> ProcessTermination(ServiceResult result)
        {
            if (m_state == null) InitializeAggregation();
            m_state.EndOfData();
            return ProcessedValues();
        }

        #endregion

        #region IAggregationActor Members

        public void UpdateProcessedData(DataValue rawValue, AggregateState state)
        {
            // step 1: compute new TimeSlice instances to enqueue, until we reach the one the
            // rawValue belongs in or we've reached the one that goes to the EndTime. Ensure
            // that the raw value is added to the last one created.
            TimeSlice tmpTS = null;
            if (m_pending == null)
                m_pending = new Queue<TimeSlice>();
            if (m_latest == null)
            {
                tmpTS = TimeSlice.CreateInitial(StartTime, EndTime, ProcessingInterval);
                if (tmpTS != null)
                {
                    m_pending.Enqueue(tmpTS);
                    m_latest = tmpTS;
                }
            }
            else
            {
                tmpTS = m_latest;
            }
            DateTime latestTime = (StartTime > EndTime) ? StartTime : EndTime;
            while ((tmpTS != null) && (state.HasTerminated || !tmpTS.AcceptValue(rawValue)))
            {
                tmpTS = TimeSlice.CreateNext(latestTime, ProcessingInterval, tmpTS);
                if (tmpTS != null)
                {
                    m_pending.Enqueue(tmpTS);
                    m_latest = tmpTS;
                }
            }

            // step 2: apply the aggregator to the head of the queue to see if we can convert
            // it into a processed point. If so, dequeue it and add the processed value to the
            // m_released list. Keep doing it until one of the TimeSlices returns null or we
            // run out of enqueued TimeSlices (should only happen on termination).
            if (m_released == null)
                m_released = new List<DataValue>();
            foreach (TimeSlice b in m_pending)
                UpdateBoundingValues(b, state);
            bool active = true;
            while ((m_pending.Count > 0) && active)
            {
                TimeSlice top = m_pending.Peek();
                DataValue computed = null;
                if (!WaitForMoreData(top, state))
                    computed = Compute(this, top, state);
                if (computed != null)
                {
                    m_released.Add(computed);
                    m_pending.Dequeue();
                }
                else
                {
                    active = false;
                }
            }
        }

        public IList<DataValue> ProcessedValues()
        {
            IList<DataValue> retval = null;
            retval = (m_released != null) ? m_released : new List<DataValue>();
            m_released = null;
            return retval;
        }

        #endregion

        /// <summary>
        /// Computes the status code for the processing interval using the percent good/bad
        /// information in the context.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="numGood"></param>
        /// <param name="numBad"></param>
        /// <returns></returns>
        protected virtual StatusCode ComputeStatus(IAggregationContext context, int numGood, int numBad, TimeSlice bucket)
        {
            int total = numGood + numBad;
            if (total > 0)
            {
                double pbad = (numBad * 100) / total;
                if (pbad > context.PercentDataBad) return StatusCodes.Bad;
                double pgood = (numGood * 100) / total;
                if (pgood >= context.PercentDataGood) return StatusCodes.Good;
                return StatusCodes.Uncertain;
                // return StatusCodes.UncertainDataSubNormal;
            }
            else
            {
                return StatusCodes.GoodNoData;
            }
        }

        #region IAggregator Members

        public abstract DataValue Compute(IAggregationContext context, TimeSlice bucket, AggregateState state);

        public abstract bool WaitForMoreData(TimeSlice bucket, AggregateState state);

        public abstract void UpdateBoundingValues(TimeSlice bucket, AggregateState state);

        #endregion
    }

    public abstract class NonInterpolatingCalculator : AggregateCalculatorImpl
    {
        public override bool WaitForMoreData(TimeSlice bucket, AggregateState state)
        {
            bool wait = false;
            if (!state.HasTerminated)
            {
                if (bucket.ContainsTime(state.LatestTimestamp))
                {
                    wait = true;
                }
            }
            return wait;
        }

        public override void UpdateBoundingValues(TimeSlice bucket, AggregateState state)
        {
        }
    }

    public abstract class InterpolatingCalculator : AggregateCalculatorImpl
    {
        public override bool WaitForMoreData(TimeSlice bucket, AggregateState state)
        {
            bool wait = false;
            if (!state.HasTerminated)
            {
                if (bucket.ContainsTime(state.LatestTimestamp))
                {
                    wait = true;
                }
                if ((bucket.EarlyBound.Value == null) || (bucket.LateBound.Value == null))
                {
                    wait = true;
                }
            }
            return wait;
        }
        protected override StatusCode ComputeStatus(IAggregationContext context, int numGood, int numBad, TimeSlice bucket)
        {
            StatusCode code = (bucket.EarlyBound.Value == null && numGood + numBad == 0) ? // no inital bound, do not extrapolate
                StatusCodes.BadNoData : base.ComputeStatus(context, numGood, numBad, bucket);
            return code;
        }
        protected void UpdatePriorPoint(BoundingValue bound, AggregateState state)
        {
            if (state.HasTerminated && (state.LatePoint == null) && bound.PriorPoint == null)
            {
                bound.PriorPoint = state.PriorPoint;
                bound.PriorBadPoints = state.PriorBadPoints;
                bound.DerivationType = UseSlopedExtrapolation ? BoundingValueType.SlopedExtrapolation : BoundingValueType.SteppedExtrapolation;
            }
        }
    }

    public abstract class FloatInterpolatingCalculator : InterpolatingCalculator
    {
        public override void UpdateBoundingValues(TimeSlice bucket, AggregateState state)
        {
            BoundingValue EarlyBound = bucket.EarlyBound;
            BoundingValue LateBound = bucket.LateBound;
            if (bucket.ExactMatch(state.LatestTimestamp) && StatusCode.IsGood(state.LatestStatus))
            {
                EarlyBound.RawPoint = state.LatePoint == null ? state.EarlyPoint : state.LatePoint;
                EarlyBound.DerivationType = BoundingValueType.Raw;
            }
            else
            {
                if (EarlyBound.DerivationType != BoundingValueType.Raw)
                {
                    if (EarlyBound.EarlyPoint == null)
                    {
                        if ((state.EarlyPoint != null) && (state.EarlyPoint.SourceTimestamp < bucket.From))
                        {
                            EarlyBound.EarlyPoint = state.EarlyPoint;
                        }
                    }
                    if (EarlyBound.LatePoint == null)
                    {
                        if ((state.LatePoint != null) && (state.LatePoint.SourceTimestamp >= bucket.From))
                        {
                            EarlyBound.LatePoint = state.LatePoint;
                            if (SteppedVariable)
                            {
                                EarlyBound.CurrentBadPoints = new List<DataValue>();
                                foreach (DataValue dv in state.CurrentBadPoints)
                                    if (dv.SourceTimestamp < EarlyBound.Timestamp)
                                        EarlyBound.CurrentBadPoints.Add(dv);
                            }
                            else
                            {
                                EarlyBound.CurrentBadPoints = state.CurrentBadPoints;
                            }
                            EarlyBound.DerivationType = SteppedVariable ? BoundingValueType.SteppedInterpolation : BoundingValueType.SlopedInterpolation;
                        }
                    }
                }
                if (state.HasTerminated && (state.LatePoint == null))
                {
                    if (SteppedVariable)
                    {
                        EarlyBound.CurrentBadPoints = new List<DataValue>();
                        foreach (DataValue dv in state.CurrentBadPoints)
                            if (dv.SourceTimestamp < EarlyBound.Timestamp)
                                EarlyBound.CurrentBadPoints.Add(dv);
                    }
                    else
                    {
                        EarlyBound.CurrentBadPoints = state.CurrentBadPoints;
                    }
                }
            }

            if (bucket.EndMatch(state.LatestTimestamp) && StatusCode.IsGood(state.LatestStatus))
            {
                LateBound.RawPoint = state.LatePoint == null ? state.EarlyPoint : state.LatePoint;
                LateBound.DerivationType = BoundingValueType.Raw;
            }
            else
            {
                if (LateBound.DerivationType != BoundingValueType.Raw)
                {
                    if ((state.EarlyPoint != null) && (state.EarlyPoint.SourceTimestamp < bucket.To))
                        LateBound.EarlyPoint = state.EarlyPoint;
                    if (LateBound.LatePoint == null)
                    {
                        if ((state.LatePoint != null) && (state.LatePoint.SourceTimestamp >= bucket.To))
                        {
                            LateBound.LatePoint = state.LatePoint;
                            if (SteppedVariable)
                            {
                                LateBound.CurrentBadPoints = new List<DataValue>();
                                foreach (DataValue dv in state.CurrentBadPoints)
                                    if (dv.SourceTimestamp < LateBound.Timestamp)
                                        LateBound.CurrentBadPoints.Add(dv);
                            }
                            else
                            {
                                LateBound.CurrentBadPoints = state.CurrentBadPoints;
                            }
                            LateBound.DerivationType = SteppedVariable ? BoundingValueType.SteppedInterpolation : BoundingValueType.SlopedInterpolation;
                        }
                    }
                }
                if (state.HasTerminated && (state.LatePoint == null))
                {
                    if (SteppedVariable)
                    {
                        LateBound.CurrentBadPoints = new List<DataValue>();
                        foreach (DataValue dv in state.CurrentBadPoints)
                            if (dv.SourceTimestamp < LateBound.Timestamp)
                                LateBound.CurrentBadPoints.Add(dv);
                    }
                    else
                    {
                        LateBound.CurrentBadPoints = state.CurrentBadPoints;
                    }
                }
                UpdatePriorPoint(LateBound, state);
            }
        }
    }

    public abstract class SteppedInterpolatingCalculator : InterpolatingCalculator
    {
        public override void UpdateBoundingValues(TimeSlice bucket, AggregateState state)
        {
            BoundingValue EarlyBound = bucket.EarlyBound;
            BoundingValue LateBound = bucket.LateBound;
            if (bucket.ExactMatch(state.LatestTimestamp) && StatusCode.IsGood(state.LatestStatus))
            {
                EarlyBound.RawPoint = state.LatePoint == null ? state.EarlyPoint : state.LatePoint;
                EarlyBound.DerivationType = BoundingValueType.Raw;
            }
            else
            {
                if (EarlyBound.DerivationType != BoundingValueType.Raw)
                {
                    if (EarlyBound.EarlyPoint == null)
                    {
                        if ((state.EarlyPoint != null) && (state.EarlyPoint.SourceTimestamp < bucket.From))
                        {
                            EarlyBound.EarlyPoint = state.EarlyPoint;
                        }
                    }
                    if (EarlyBound.LatePoint == null)
                    {
                        if ((state.LatePoint != null) && (state.LatePoint.SourceTimestamp >= bucket.From))
                        {
                            EarlyBound.CurrentBadPoints = new List<DataValue>();
                            foreach (DataValue dv in state.CurrentBadPoints)
                                if (dv.SourceTimestamp < EarlyBound.Timestamp)
                                    EarlyBound.CurrentBadPoints.Add(dv);
                            EarlyBound.DerivationType = BoundingValueType.SteppedInterpolation;
                        }
                    }
                }
                if (state.HasTerminated && (state.LatePoint == null))
                {
                    EarlyBound.CurrentBadPoints = new List<DataValue>();
                    foreach (DataValue dv in state.CurrentBadPoints)
                        if (dv.SourceTimestamp < EarlyBound.Timestamp)
                            EarlyBound.CurrentBadPoints.Add(dv);
                    EarlyBound.DerivationType = BoundingValueType.SteppedExtrapolation;
                }
            }

            if (bucket.EndMatch(state.LatestTimestamp) && StatusCode.IsGood(state.LatestStatus))
            {
                LateBound.RawPoint = state.LatePoint == null ? state.EarlyPoint : state.LatePoint;
                LateBound.DerivationType = BoundingValueType.Raw;
            }
            else
            {
                if (LateBound.DerivationType != BoundingValueType.Raw)
                {
                    if ((state.EarlyPoint != null) && (state.EarlyPoint.SourceTimestamp < bucket.To))
                        LateBound.EarlyPoint = state.EarlyPoint;
                    if (LateBound.LatePoint == null)
                    {
                        if ((state.LatePoint != null) && (state.LatePoint.SourceTimestamp >= bucket.To))
                        {
                            LateBound.CurrentBadPoints = new List<DataValue>();
                            foreach (DataValue dv in state.CurrentBadPoints)
                                if (dv.SourceTimestamp < LateBound.Timestamp)
                                    LateBound.CurrentBadPoints.Add(dv);
                            LateBound.DerivationType = BoundingValueType.SteppedInterpolation;
                        }
                    }
                }
                if (state.HasTerminated && (state.LatePoint == null))
                {
                    LateBound.CurrentBadPoints = new List<DataValue>();
                    foreach (DataValue dv in state.CurrentBadPoints)
                        if (dv.SourceTimestamp < LateBound.Timestamp)
                            LateBound.CurrentBadPoints.Add(dv);
                    if (EarlyBound.PriorPoint == null)
                    {
                        EarlyBound.PriorPoint = state.PriorPoint;
                        EarlyBound.PriorBadPoints = state.PriorBadPoints;
                        EarlyBound.DerivationType = UseSlopedExtrapolation ? BoundingValueType.SlopedExtrapolation : BoundingValueType.SteppedExtrapolation;
                    }
                    LateBound.DerivationType = BoundingValueType.SteppedExtrapolation;
                }
            }
        }
    }

    public abstract class QualityDurationCalculator : InterpolatingCalculator
    {
        protected abstract bool RightStatusCode(DataValue dv);

        public override DataValue Compute(IAggregationContext context, TimeSlice bucket, AggregateState state)
        {
            DataValue retval = new DataValue { SourceTimestamp = bucket.From }; ;
            StatusCode code = StatusCodes.Good;
            DataValue previous = new DataValue { SourceTimestamp = bucket.From };
            if (bucket.EarlyBound.Value != null)
                previous.StatusCode = (StatusCode)bucket.EarlyBound.Value.WrappedValue.Value;
            else
                previous.StatusCode = StatusCodes.Bad;
            if (!RightStatusCode(previous))
                previous = null;
            double total = 0.0;
            foreach (DataValue v in bucket.Values)
            {
                if (previous != null)
                    total += (v.SourceTimestamp - previous.SourceTimestamp).TotalMilliseconds;
                if (RightStatusCode(v))
                    previous = v;
                else
                    previous = null;
            }
            if (previous != null)
                total += (bucket.To - previous.SourceTimestamp).TotalMilliseconds;
            retval.Value = total;
            code.AggregateBits = AggregateBits.Calculated;
            if (bucket.Incomplete) code.AggregateBits |= AggregateBits.Partial;
            retval.StatusCode = code;
            return retval;
        }

        public override void UpdateBoundingValues(TimeSlice bucket, AggregateState state)
        {
            BoundingValue EarlyBound = bucket.EarlyBound;
            BoundingValue LateBound = bucket.LateBound;
            if (bucket.ExactMatch(state.LatestTimestamp))
            {
                EarlyBound.RawPoint = state.LatePoint == null ? state.EarlyPoint : state.LatePoint;
                EarlyBound.DerivationType = BoundingValueType.QualityRaw;
            }
            else
            {
                if (EarlyBound.DerivationType != BoundingValueType.QualityRaw)
                {
                    if (EarlyBound.EarlyPoint == null)
                    {
                        if ((state.EarlyPoint != null) && (state.EarlyPoint.SourceTimestamp < bucket.From))
                        {
                            EarlyBound.EarlyPoint = state.EarlyPoint;
                        }
                    }
                    if (EarlyBound.LatePoint == null)
                    {
                        if ((state.LatePoint != null) && (state.LatePoint.SourceTimestamp >= bucket.From))
                        {
                            EarlyBound.CurrentBadPoints = new List<DataValue>();
                            foreach (DataValue dv in state.CurrentBadPoints)
                                if (dv.SourceTimestamp < EarlyBound.Timestamp)
                                    EarlyBound.CurrentBadPoints.Add(dv);
                            EarlyBound.DerivationType = BoundingValueType.QualityInterpolation;
                        }
                    }
                }
                if (state.HasTerminated && (state.LatePoint == null))
                {
                    EarlyBound.CurrentBadPoints = new List<DataValue>();
                    foreach (DataValue dv in state.CurrentBadPoints)
                        if (dv.SourceTimestamp < EarlyBound.Timestamp)
                            EarlyBound.CurrentBadPoints.Add(dv);
                    EarlyBound.DerivationType = BoundingValueType.QualityExtrapolation;
                }
            }

            if (bucket.EndMatch(state.LatestTimestamp))
            {
                LateBound.RawPoint = state.LatePoint == null ? state.EarlyPoint : state.LatePoint;
                LateBound.DerivationType = BoundingValueType.QualityRaw;
            }
            else
            {
                if (LateBound.DerivationType != BoundingValueType.QualityRaw)
                {
                    if ((state.EarlyPoint != null) && (state.EarlyPoint.SourceTimestamp < bucket.To))
                        LateBound.EarlyPoint = state.EarlyPoint;
                    if (LateBound.LatePoint == null)
                    {
                        if ((state.LatePoint != null) && (state.LatePoint.SourceTimestamp >= bucket.To))
                        {
                            LateBound.CurrentBadPoints = new List<DataValue>();
                            foreach (DataValue dv in state.CurrentBadPoints)
                                if (dv.SourceTimestamp < LateBound.Timestamp)
                                    LateBound.CurrentBadPoints.Add(dv);
                            LateBound.DerivationType = BoundingValueType.QualityInterpolation;
                        }
                    }
                }
                if (state.HasTerminated && (state.LatePoint == null))
                {
                    LateBound.CurrentBadPoints = new List<DataValue>();
                    foreach (DataValue dv in state.CurrentBadPoints)
                        if (dv.SourceTimestamp < LateBound.Timestamp)
                            LateBound.CurrentBadPoints.Add(dv);
                    LateBound.DerivationType = BoundingValueType.QualityExtrapolation;
                }
            }
        }
    }
}
