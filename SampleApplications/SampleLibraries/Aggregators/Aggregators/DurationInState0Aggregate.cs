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
    public abstract class DurationAggregate : SteppedInterpolatingCalculator
    {
        protected abstract bool RightState(DataValue dv);

        protected override StatusCode ComputeStatus(IAggregationContext context, int numGood, int numBad, TimeSlice bucket)
        {
            StatusCode code = base.ComputeStatus(context, numGood, numBad, bucket);
            if (bucket.EarlyBound.Value == null || StatusCode.IsNotGood(bucket.EarlyBound.Value.StatusCode))
                code = StatusCodes.Uncertain;
            return code;
        }
        public override DataValue Compute(IAggregationContext context, TimeSlice bucket, AggregateState state)
        {
            int numGood = 0;
            int numBad = 0;
            DataValue previous = RightState(bucket.EarlyBound.Value) ? bucket.EarlyBound.Value : null;
            double total = 0.0;

            DataValue retval = new DataValue { SourceTimestamp = bucket.From };
            StatusCode code = StatusCodes.BadNoData;

            foreach (DataValue v in bucket.Values)
            {
                if (state.RawValueIsGood(v))
                {
                    numGood += 1;
                    if (previous != null)
                        total += (v.SourceTimestamp - previous.SourceTimestamp).TotalMilliseconds;
                    previous = RightState(v) ? v : null;
                }
                else
                {
                    numBad += 1;
                }
            }
            if (previous != null)
                total += (bucket.LateBound.Value.SourceTimestamp - previous.SourceTimestamp).TotalMilliseconds;
            retval.Value = total;
            code = ComputeStatus(context, numGood, numBad, bucket).Code;
            code.AggregateBits = AggregateBits.Calculated;
            if (bucket.Incomplete) code.AggregateBits |= AggregateBits.Partial;
            retval.StatusCode = code;
            return retval;
        }
    }

    public class DurationInState0Aggregate : DurationAggregate
    {
        protected override bool RightState(DataValue dv)
        {
            if(dv != null && dv.Value != null)
                return Convert.ToBoolean(dv.Value) == false;
            return false;
        }
    }
}
