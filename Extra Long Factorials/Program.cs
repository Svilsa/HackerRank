using System;
using System.Numerics;

class Result
{
    /*
     * Complete the 'extraLongFactorials' function below.
     *
     * The function accepts INTEGER n as parameter.
     */

    public static void extraLongFactorials(int n)
    {
        if (n < 0)
            throw new ArgumentException();

        var answer = new BigInteger(1);
        while (n > 0)
        {
            answer *= n;
            n--;
        }

        Console.WriteLine(answer);
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        Result.extraLongFactorials(n);
    }
}