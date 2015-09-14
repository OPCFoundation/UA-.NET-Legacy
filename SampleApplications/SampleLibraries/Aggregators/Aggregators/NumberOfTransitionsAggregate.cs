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
    public class NumberOfTransitionsAggregate : SteppedInterpolatingCalculator
    {
        public override void UpdateBoundingValues(TimeSlice bucket, AggregateState state)
        {
            base.UpdateBoundingValues(bucket, state);
            UpdatePriorPoint(bucket.EarlyBound, state);
        }
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
            int nTransitions = 0;
            long stateCode = -1;
            IEnumerator<DataValue> enumerator = bucket.Values.GetEnumerator();
            bool bucketValueNotEmpty = enumerator.MoveNext();
            if (bucketValueNotEmpty && enumerator.Current != null)
            {
                if (bucket.EarlyBound != null)
                {
                    if (enumerator.Current.SourceTimestamp == bucket.EarlyBound.Timestamp && bucket.EarlyBound.PriorPoint != null)
                    {
                        stateCode = Convert.ToInt32(Convert.ToBoolean(bucket.EarlyBound.PriorPoint.Value));
                    }
                    else if (bucket.EarlyBound.Value != null)
                    {
                        stateCode = Convert.ToInt32(Convert.ToBoolean(bucket.EarlyBound.Value.Value));
                    }
                }
            }

            // viz. UA MultiStateNodeState & TwoStateNodeState, 
            // assume DataValue.Value is either an EnumValueType or a bool
            if (bucketValueNotEmpty)
            {
                do
                {
                    DataValue dv = enumerator.Current;
                    if (state.RawValueIsGood(dv))
                    {
                        EnumValueType ev = dv.Value as EnumValueType;
                        if (ev == null)
                        {
                            bool b;
                            if (bool.TryParse(dv.Value.ToString(), out b))
                            {
                                if (stateCode < 0)
                                    stateCode = b ? 1 : 0;
                                else if (b.CompareTo(Convert.ToBoolean(stateCode)) != 0)
                                {
                                    nTransitions++;
                                    stateCode = b ? 1 : 0;
                                }
                            }
                            else
                                continue;
                        }
                        else
                        {
                            long s = ev.Value;
                            if (stateCode < 0)
                                stateCode = s;
                            else if (!s.Equals(stateCode))
                            {
                                nTransitions++;
                                stateCode = s;
                            }
                        }
                        numGood++;
                    }
                    else
                    {
                        numBad++;
                    }
                } while (enumerator.MoveNext());
            }

            StatusCode code = ComputeStatus(context, numGood, numBad, bucket).Code;
            DataValue retval = new DataValue { SourceTimestamp = bucket.From, Value = nTransitions };
            code.AggregateBits = AggregateBits.Calculated;
            if (bucket.Incomplete) code.AggregateBits |= AggregateBits.Partial;
            retval.StatusCode = code;
            return retval;
        }
    }
}
