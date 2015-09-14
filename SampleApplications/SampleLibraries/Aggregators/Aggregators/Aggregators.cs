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
using System.Globalization;

namespace Opc.Ua.Server
{
    /// <summary>
    /// Uses the current AggregateState to compute the processed value for a TimeSlice.
    /// If the AggregateState does not contain enough information (yet) to compute the
    /// processed value, the method MUST return null.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="bucket"></param>
    /// <param name="state"></param>
    /// <returns></returns>
    public delegate AggregateCalculatorImpl AggregatorFactory();

    /// <summary>
    /// Class that manages the set of standard Aggregator implementations for OPC-UA
    /// </summary>
    public static class Aggregators
    {
        /// <summary>
        /// Dictionary that allows the correct implementation of an aggregator to be looked
        /// up given the NodeId of the standard AggregationType.
        /// </summary>
        private static Dictionary<NodeId, AggregatorFactory> Lookup;

        /// <summary>
        /// Use this to register the AggregatorFactory for a custom or vendor-defined
        /// Aggregator. This method assumes that the AggregateType node has been created
        /// and placed in the appropriate place in the namespace already.
        /// </summary>
        /// <param name="key">NodeId of the Aggregatetype node</param>
        /// <param name="factory">AggregatorFactory delegate</param>
        public static void RegisterAggregatorFactory(NodeId key, AggregatorFactory factory)
        {
            Lookup[key] = factory;
        }

        /// <summary>
        /// Create an AggregateCalculator for a subscription
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="steppedVariable"></param>
        /// <returns></returns>
        public static AggregateCalculatorImpl CreateAggregator(AggregateFilter filter, bool steppedVariable)
        {
            AggregatorFactory aci = null;
            if (Lookup.TryGetValue(filter.AggregateType, out aci))
            {
                AggregateCalculatorImpl retval = aci();
                retval.StartTime = filter.StartTime;
                retval.EndTime = DateTime.MaxValue;
                retval.ProcessingInterval = filter.ProcessingInterval;
                retval.Configuration = filter.AggregateConfiguration;
                retval.SteppedVariable = steppedVariable;
                return retval;
            }
            return null;
        }

        /// <summary>
        /// Create and AggregateCalculator for a ReadProcessed service call.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="steppedVariable"></param>
        /// <returns></returns>
        public static AggregateCalculatorImpl CreateAggregator(NewAggregateFilter filter, bool steppedVariable)
        {
            AggregatorFactory aci = null;
            if (Lookup.TryGetValue(filter.AggregateType, out aci))
            {
                AggregateCalculatorImpl retval = aci();
                retval.StartTime = filter.StartTime;
                retval.EndTime = filter.EndTime;
                retval.ProcessingInterval = filter.ProcessingInterval;
                retval.Configuration = filter.AggregateConfiguration;
                retval.SteppedVariable = steppedVariable;
                return retval;
            }
            return null;
        }

        static Aggregators()
        {
            Lookup = new Dictionary<NodeId, AggregatorFactory>();
            Lookup[Opc.Ua.ObjectIds.AggregateFunction_Interpolative] = InterpolativeFactory;
            Lookup[Opc.Ua.ObjectIds.AggregateFunction_Average] = AverageFactory;
            Lookup[Opc.Ua.ObjectIds.AggregateFunction_TimeAverage] = TimeAverageFactory;
            Lookup[Opc.Ua.ObjectIds.AggregateFunction_Total] = TotalFactory;
            Lookup[Opc.Ua.ObjectIds.AggregateFunction_Total2] = TotalizeAverageFactory;
            Lookup[Opc.Ua.ObjectIds.AggregateFunction_Minimum] = MinimumFactory;
            Lookup[Opc.Ua.ObjectIds.AggregateFunction_Maximum] = MaximumFactory;
            Lookup[Opc.Ua.ObjectIds.AggregateFunction_MinimumActualTime] = MinimumActualTimeFactory;
            Lookup[Opc.Ua.ObjectIds.AggregateFunction_MaximumActualTime] = MaximumActualTimeFactory;
            Lookup[Opc.Ua.ObjectIds.AggregateFunction_Range] = RangeFactory;
            Lookup[Opc.Ua.ObjectIds.AggregateFunction_Count] = CountFactory;
            Lookup[Opc.Ua.ObjectIds.AggregateFunction_DurationInStateZero] = DurationInState0Factory;
            Lookup[Opc.Ua.ObjectIds.AggregateFunction_DurationInStateNonZero] = DurationInState1Factory;
            Lookup[Opc.Ua.ObjectIds.AggregateFunction_NumberOfTransitions] = NumberOfTransitionsFactory;
            Lookup[Opc.Ua.ObjectIds.AggregateFunction_Start] = StartFactory;
            Lookup[Opc.Ua.ObjectIds.AggregateFunction_End] = EndFactory;
            Lookup[Opc.Ua.ObjectIds.AggregateFunction_Delta] = DeltaFactory;
            Lookup[Opc.Ua.ObjectIds.AggregateFunction_DurationGood] = DurationGoodFactory;
            Lookup[Opc.Ua.ObjectIds.AggregateFunction_DurationBad] = DurationBadFactory;
            Lookup[Opc.Ua.ObjectIds.AggregateFunction_PercentGood] = PercentGoodFactory;
            Lookup[Opc.Ua.ObjectIds.AggregateFunction_PercentBad] = PercentBadFactory;
            Lookup[Opc.Ua.ObjectIds.AggregateFunction_WorstQuality] = WorstQualityFactory;
            // Lookup[Opc.Ua.ObjectIds.AggregateFunction_AnnotationCount] = AnnotationCountFactory;
        }

        public static AggregateCalculatorImpl InterpolativeFactory() { return new InterpolativeAggregate(); }
        public static AggregateCalculatorImpl AverageFactory() { return new AverageAggregate(); }
        public static AggregateCalculatorImpl TimeAverageFactory() { return new TimeAverageAggregate(); }
        public static AggregateCalculatorImpl TotalFactory() { return new TotalAggregate(); }
        public static AggregateCalculatorImpl TotalizeAverageFactory() { return new TotalizeAverageAggregate(); }
        public static AggregateCalculatorImpl MinimumFactory() { return new MinimumAggregate(); }
        public static AggregateCalculatorImpl MaximumFactory() { return new MaximumAggregate(); }
        public static AggregateCalculatorImpl MinimumActualTimeFactory() { return new MinimumActualTimeAggregate(); }
        public static AggregateCalculatorImpl MaximumActualTimeFactory() { return new MaximumActualTimeAggregate(); }
        public static AggregateCalculatorImpl RangeFactory() { return new RangeAggregate(); }
        public static AggregateCalculatorImpl CountFactory() { return new CountAggregate(); }
        public static AggregateCalculatorImpl DurationInState0Factory() { return new DurationInState0Aggregate(); }
        public static AggregateCalculatorImpl DurationInState1Factory() { return new DurationInState1Aggregate(); }
        public static AggregateCalculatorImpl NumberOfTransitionsFactory() { return new NumberOfTransitionsAggregate(); }
        public static AggregateCalculatorImpl StartFactory() { return new StartAggregate(); }
        public static AggregateCalculatorImpl EndFactory() { return new EndAggregate(); }
        public static AggregateCalculatorImpl DeltaFactory() { return new DeltaAggregate(); }
        public static AggregateCalculatorImpl DurationGoodFactory() { return new DurationGoodAggregate(); }
        public static AggregateCalculatorImpl DurationBadFactory() { return new DurationBadAggregate(); }
        public static AggregateCalculatorImpl PercentGoodFactory() { return new PercentGoodAggregate(); }
        public static AggregateCalculatorImpl PercentBadFactory() { return new PercentBadAggregate(); }
        public static AggregateCalculatorImpl WorstQualityFactory() { return new WorstQualityAggregate(); }
        // public static AggregateCalculatorImpl AnnotationCountFactory() { return new AnnotationCountAggregate(); }
    }

}
