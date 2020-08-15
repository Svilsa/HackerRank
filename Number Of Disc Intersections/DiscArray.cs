using System.Collections.Generic;
using System.Linq;

namespace Number_Of_Disc_Intersections
{
    public class DiscArray
    {
        private int _intersectCount = -2;
        private readonly Disc[] _discs;

        public DiscArray(int[] sourceData)
        {
            _discs = ConvertToDisc(sourceData).ToArray();
        }

        public int IntersectCount
        {
            get
            {
                if (_intersectCount == -2) FindNumberOfIntersects();
                return _intersectCount;
            }
        }

        public IEnumerable<(int, int)> Intersects()
        {
            var intersects = new List<(int, int)>();

            for (int i = 0, offset = 1; i < _discs.Length; i++, offset++)
            {
                for (var j = offset; j < _discs.Length; j++)
                {
                    if (_discs[i].RightPoint >= _discs[j].LeftPoint) intersects.Add((i, j));
                }
            }

            return intersects;
        }

        private void FindNumberOfIntersects()
        {
            var counter = 0;

            var sortedDiscs = _discs
                .OrderBy(disk => disk.LeftPoint)
                .ToArray();

            for (int i = 0, offset = 1; i < sortedDiscs.Length; i++, offset++)
            {
                for (int j = offset; j < sortedDiscs.Length; j++)
                {
                    if (counter == 10000000)
                    {
                        _intersectCount = -1;
                        return;
                    }
                    
                    if (sortedDiscs[i].RightPoint >= sortedDiscs[j].LeftPoint) counter++;
                    else break;
                    
                }
            }
            _intersectCount = counter;
        }

        private static IEnumerable<Disc> ConvertToDisc(int[] intArray)
        {
            var discArray = new Disc[intArray.Length];

            for (uint i = 0; i < intArray.Length; i++)
            {
                discArray[i] = new Disc(i, (uint) intArray[i]);
            }

            return discArray;
        }
    }
}