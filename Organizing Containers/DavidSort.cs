using System;
using System.Collections.Generic;
using System.Linq;

namespace Organizing_Containers
{
    public static class DavidSort
    {
        public static bool IsPossibleToSort(Container[] containers)
        {
            var allBalls = SumOfBalls(containers);

            var capacityContainersArray = containers.Select(x => x.Capacity).OrderBy(x => x);
            var allBallsArray = allBalls.Select(x => x.Value).OrderBy(x => x);

            return capacityContainersArray.SequenceEqual(allBallsArray);
        }

        private static Dictionary<long, long> SumOfBalls(IEnumerable<Container> containers)
        {
            var allBalls = new Dictionary<long, long>();

            foreach (var container in containers)
            {
                foreach (var (key, value) in container.Balls)
                {
                    if (allBalls.ContainsKey(key))
                    {
                        allBalls[key] += value;
                    }
                    else
                    {
                        allBalls.Add(key, value);
                    }
                }
            }

            return allBalls;
        }
    }
}