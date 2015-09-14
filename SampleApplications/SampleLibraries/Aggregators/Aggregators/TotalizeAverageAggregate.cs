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
using System.Diagnostics;

namespace Opc.Ua.Server
{
    public class TotalizeAverageAggregate : FloatInterpolatingCalculator
    {
        protected override StatusCode ComputeStatus(IAggregationContext context, int numGood, int numBad, TimeSlice bucket)
        {
            StatusCode code = base.ComputeStatus(context, numGood, numBad, bucket).Code;
            if (StatusCode.IsGood(code) && (bucket.EarlyBound.Value == null || StatusCode.IsNotGood(bucket.EarlyBound.Value.StatusCode)))
                code = StatusCodes.Uncertain;
            if (StatusCode.IsGood(code) && (bucket.LateBound.Value == null || StatusCode.IsNotGood(bucket.LateBound.Value.StatusCode)))
                code = StatusCodes.Uncertain;
            return code;
        }

        public override DataValue Compute(IAggregationContext context, TimeSlice bucket, AggregateState state)
        {
            DataValue retval = new DataValue { SourceTimestamp = bucket.From };
            DataValue initValue = bucket.EarlyBound.Value, finalValue = bucket.LateBound.Value;
            IEnumerator<DataValue> enumerator = bucket.Values.GetEnumerator();
            StatusCode code = StatusCodes.BadNoData;
            if (initValue == null && enumerator.MoveNext()) // first element
            {
                initValue = enumerator.Current;
            }
            if (finalValue == null)
            {
                while (enumerator.MoveNext())
                {
                    finalValue = enumerator.Current;
                }
            }
            if (initValue != null && finalValue != null)
            {
                int numGood = 0;
                int numBad = 0;
                double total = 0.0;
                double early = 0.0;
                double late = 0.0;
                double width = 0.0;

                Debug.WriteLine(String.Format("bucket starts @ {0}, ends @ {1}", bucket.From.TimeOfDay, bucket.To.TimeOfDay));

                if ((initValue.StatusCode.AggregateBits & AggregateBits.Raw) == 0)
                {
                    if (state.RawValueIsGood(initValue))
                        numGood += 1;
                    else
                        numBad += 1;
                }
                if ((finalValue.StatusCode.AggregateBits & AggregateBits.Raw) == 0)
                {
                    if (state.RawValueIsGood(finalValue))
                        numGood += 1;
                    else
                        numBad += 1;
                }
                DataValue preceding = initValue;
                foreach (DataValue v in bucket.Values)
                {
                    if (state.RawValueIsGood(v))
                    {
                        numGood += 1;
                        early = Convert.ToDouble(preceding.Value, CultureInfo.InvariantCulture);
                        late = Convert.ToDouble(v.Value, CultureInfo.InvariantCulture);
                        width = (v.SourceTimestamp - preceding.SourceTimestamp).TotalMilliseconds;
                        total += SteppedVariable ? width * early : width * (late + early) / 2;
                        preceding = v;
                    }
                    else
                    {
                        numBad += 1;
                    }
                }
                early = Convert.ToDouble(preceding.Value, CultureInfo.InvariantCulture);
                late = Convert.ToDouble(finalValue.Value, CultureInfo.InvariantCulture);
                width = (finalValue.SourceTimestamp - preceding.SourceTimestamp).TotalMilliseconds;
                total += SteppedVariable ? width * early : width * (late + early) / 2;
                retval.Value = total;
                code = ComputeStatus(context, numGood, numBad, bucket).Code;
            }
            code.AggregateBits = AggregateBits.Calculated;
            if (StatusCode.IsNotBad(code) && bucket.Incomplete) 
                code.AggregateBits |= AggregateBits.Partial;
            retval.StatusCode = code;
            return retval;
        }
    }
}
