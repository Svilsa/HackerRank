using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace GoodNumbers
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            const int endRange = 1000000000;
            
            var startTime = DateTime.UtcNow;
            
            var threadPool = new Thread[Environment.ProcessorCount];
            var ranges = RangeSlicer.SliceRange((uint)threadPool.Length, endRange).ToArray();
            
            for (var i = 0; i < threadPool.Length; i++)
            {
                threadPool[i] = new Thread(GoodNumbersCounter.CountGoodNumbers);
                threadPool[i].Start(ranges[i]);
            }
            
            foreach (var thread in threadPool)
            {
                thread.Join();
            }

            var stopTime = DateTime.UtcNow;

            Console.WriteLine($"Result is {GoodNumbersCounter.Result}");
            Console.WriteLine($"Time to execute was {stopTime - startTime}");
            Console.ReadLine();

        }
    }
}