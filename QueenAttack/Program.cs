using System;
using System.IO;

namespace QueenAttack_2
{
    class Program
    {
        static void Main(string[] args)
        {

            StreamReader testcase = new StreamReader("D:\\testcase.txt");

            string[] nk = testcase.ReadLine().Split(' ');

            int n = Convert.ToInt32(nk[0]);

            int k = Convert.ToInt32(nk[1]);

            string[] r_qC_q = testcase.ReadLine().Split(' ');

            int r_q = Convert.ToInt32(r_qC_q[0]);

            int c_q = Convert.ToInt32(r_qC_q[1]);

            int[][] obstacles = new int[k][];

            for (int i = 0; i < k; i++)
            {
                obstacles[i] = Array.ConvertAll(testcase.ReadLine().Split(' '), obstaclesTemp => Convert.ToInt32(obstaclesTemp));
            }

            Console.WriteLine(queensAttack(n, k, r_q, c_q, obstacles));


        }

        static int queensAttack(int n, int k, int r_q, int c_q, int[][] obstaclesPos)
        {

            ChessFigure.BoardSize = n;

            Queen queen = new Queen(r_q, c_q);

            Obstacle[] obstacles = new Obstacle[k];

            for (var i = 0; i < k; i++)
            {

                obstacles[i] = new Obstacle(obstaclesPos[i][0], obstaclesPos[i][1]);

            }

            // 

            return queen.PossibleWays(obstacles);


        }



    }
}