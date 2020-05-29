using System;
using System.IO;

namespace AppleAndOrange
{
    class Program
    {
        static void Main(string[] args)
        {

            StreamReader testCase = new StreamReader("D:\\testcase.txt");

            string[] st = testCase.ReadLine().Split(' ');

            int s = Convert.ToInt32(st[0]);

            int t = Convert.ToInt32(st[1]);

            string[] ab = testCase.ReadLine().Split(' ');

            int a = Convert.ToInt32(ab[0]);

            int b = Convert.ToInt32(ab[1]);

            int[] apples = Array.ConvertAll(testCase.ReadLine().Split(' '),
                applesTemp => Convert.ToInt32(applesTemp));

            int[] oranges = Array.ConvertAll(testCase.ReadLine().Split(' '),
                orangesTemp => Convert.ToInt32(orangesTemp));


            CountApplesAndOranges(s, t, a, b, apples, oranges);

            //Home home = new Home(s, t);
            //Tree appleTree = new Tree(a);
            //Tree orangeTree = new Tree(b);


            //Console.WriteLine("Начальная точка дома {0}, конечная точка дома {1}",
            //    home.StartPosition, home.EndPosition);

            //Console.WriteLine("Яблоня в точке {0}",
            //    appleTree.position);

            //Console.WriteLine("Апельсин в точке {0}",
            //    orangeTree.position);

            //foreach (int i in apples)
            //{
            //    Console.WriteLine(i);
            //}
        }

        static void CountApplesAndOranges(int s, int t, int a, int b, int[] apples, int[] oranges)
        {
            int appleCounter = 0;
            int orangeCounter = 0;
            
            Home home = new Home(s, t);
            Tree appleTree = new Tree(a);
            Tree orangeTree = new Tree(b);

            foreach(int dropRange in apples)
            {
                if (appleTree.Drop(dropRange) <= home.EndPosition && appleTree.Drop(dropRange) >=
                    home.StartPosition)
                {
                    appleCounter++;
                }
            }

            Console.WriteLine(appleCounter);

            foreach (int dropRange in oranges)
            {
                if (orangeTree.Drop(dropRange) <= home.EndPosition && orangeTree.Drop(dropRange) >=
                    home.StartPosition)
                {
                    orangeCounter++;
                }
            }

            Console.WriteLine(orangeCounter);

        }
    }
}
