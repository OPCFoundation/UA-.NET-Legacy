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
    public abstract class ComparisonAggregate : NonInterpolatingCalculator
    {
        protected abstract bool Comparison(DataValue value1, DataValue value2); // true if keep value1.

        public override DataValue Compute(IAggregationContext context, TimeSlice bucket, AggregateState state)
        {
            int numGood = 0;
            int numBad = 0;
            DataValue valueToKeep = new DataValue() { SourceTimestamp = bucket.From, StatusCode = StatusCodes.BadNoData };
            bool moreData = false;
            bool hasGoodData = false;
            foreach (DataValue dv in bucket.Values)
            {
                if (state.RawValueIsGood(dv))
                {
                    hasGoodData = true;
                    if (valueToKeep.StatusCode == StatusCodes.BadNoData)
                    {
                        valueToKeep = dv;
                    }
                    else
                    {
                        moreData = valueToKeep == dv;
                        if (Comparison(dv, valueToKeep))
                        {
                            valueToKeep = dv;
                        }
                    }
                    numGood++;
                }
                else
                {
                    numBad++;
                    if (!hasGoodData)
                        valueToKeep = dv;
                }
            }
            DataValue retval = valueToKeep.StatusCode == StatusCodes.BadNoData ? valueToKeep : (DataValue)valueToKeep.Clone();
            if (hasGoodData)
            {
                StatusCode code = StatusCodes.Good;
                code = ComputeStatus(context, numGood, numBad, bucket).Code;
                code.AggregateBits = moreData ? AggregateBits.ExtraData : AggregateBits.Raw;
                if (bucket.Incomplete) code.AggregateBits |= AggregateBits.Partial;
                retval.StatusCode = code;
            } // numGood = 0, hasGoodData = false beyond this point, i.e., no good data
            else if(numBad > 0)
            {
                retval.Value = null;
                retval.StatusCode = StatusCodes.Bad;
                retval.StatusCode = retval.StatusCode.SetAggregateBits(AggregateBits.Raw);
            }
            return retval;
        }
    }

    public class MinimumActualTimeAggregate : ComparisonAggregate
    {
        protected override bool Comparison(DataValue value1, DataValue value2)
        {
            return Convert.ToDouble(value1.Value) < Convert.ToDouble(value2.Value);
        }
    }

}
