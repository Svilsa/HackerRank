using System.Collections.Generic;

namespace GoodNumbers
{
    public static class RangeSlicer
    {
        public static IEnumerable<NumberRange> SliceRange(uint numberOfSlice, uint maxNumber)
        {
            var step = maxNumber / numberOfSlice;
            var currStart = 0u;
            var currEnd = step;

            for (var i = 1; i < numberOfSlice; i++)
            {
                yield return new NumberRange {Start = currStart + 1, End = currEnd};
                currStart = currEnd;
                currEnd += step;
            }

            yield return new NumberRange {Start = currStart + 1, End = maxNumber};
        }
    }
}