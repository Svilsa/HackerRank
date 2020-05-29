using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Organizing_Containers
{
    internal static class Program
    {
        private static void Main()
        {
            TextReader textReader = new StreamReader(@"D:\testcase.txt");

            int q = Convert.ToInt32(textReader.ReadLine());

            for (int qItr = 0; qItr < q; qItr++)
            {
                int n = Convert.ToInt32(textReader.ReadLine());

                long[][] container = new long[n][];

                for (int i = 0; i < n; i++)
                {
                    container[i] = Array.ConvertAll(textReader.ReadLine().Split(' '),
                        containerTemp => Convert.ToInt64(containerTemp));
                }

                Console.WriteLine(OrganizingContainers(container));
            }
        }

        private static string OrganizingContainers(long[][] containers)
        {
            var array = containers.Select(i => new Container(i)).ToArray();

            return DavidSort.IsPossibleToSort(array) ? "Possible" : "Impossible";
        }
    }
}