using System.Collections.Generic;
using System.Linq;

namespace Organizing_Containers
{
    public class Container
    {
        public Dictionary<long, long> Balls { get; } = new Dictionary<long, long>();

        public long Capacity => Balls.Sum(x => x.Value);

        public Container(long[] matrix)
        {
            for (var i = 0; i < matrix.Length; i++)
            {
                Balls.Add(i, matrix[i]);
            }
        }
    }
}