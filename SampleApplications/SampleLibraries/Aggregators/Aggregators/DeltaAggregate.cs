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
    public class DeltaAggregate : NonInterpolatingCalculator
    {
        public override DataValue Compute(IAggregationContext context, TimeSlice bucket, AggregateState state)
        {
            int numGood = 0;
            int numBad = 0;
            DataValue firstGoodDv = null;
            DataValue lastGoodDv = null;
            DataValue lastDv = null;
            bool uncertainDataSubNormal = false;
            double delta = double.NaN;
            
            foreach (DataValue dv in bucket.Values)
            {
                if (state.RawValueIsGood(dv))
                {
                    if (firstGoodDv == null)
                    {
                        firstGoodDv = dv;
                    }
                    lastGoodDv = dv;                   
                    numGood++;
                }
                else
                {
                    // check for non-good value occuring before first good value
                    if (firstGoodDv == null)
                        uncertainDataSubNormal = true;
                    numBad++;
                }
                lastDv = dv;
            }
            if (firstGoodDv != null)
            {
                double fv = Convert.ToDouble(firstGoodDv.Value);
                double lv = Convert.ToDouble(lastGoodDv.Value);
                delta = lv - fv;
            }
            
            // check for non-good value occuring after latest good value
            if (!uncertainDataSubNormal && lastGoodDv != null && lastGoodDv.SourceTimestamp < lastDv.SourceTimestamp)
                uncertainDataSubNormal = true;

            StatusCode code = (uncertainDataSubNormal)
                ? StatusCodes.UncertainDataSubNormal
                : (numGood > 0) ? StatusCodes.Good : StatusCodes.BadNoData;
            DataValue retval = new DataValue { SourceTimestamp = bucket.From };
            if (!double.IsNaN(delta))
                retval.Value = delta;
            code.AggregateBits = AggregateBits.Calculated;
            if (bucket.Incomplete) code.AggregateBits |= AggregateBits.Partial;
            retval.StatusCode = code;
            return retval;
        }
    }
}
