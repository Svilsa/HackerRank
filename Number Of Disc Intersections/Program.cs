using System;
using System.Collections.Generic;
using System.Linq;

namespace Number_Of_Disc_Intersections
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] taskArray = {1, 5, 2, 1, 4, 0};

            var diskArray = new DiscArray(taskArray);

            var result = diskArray.IntersectCount;

            Console.WriteLine(result);

            // foreach (var (disk1, disk2) in diskArray.Intersects())
            // {
            //     Console.WriteLine($"Disk {disk1} intersects disk {disk2}");
            // }
        }
    }
}