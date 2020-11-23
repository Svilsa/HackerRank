using System;

namespace Utopian_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new UtopianTree(1);
            Console.WriteLine(tree.PredictGrowth(5));
        }
    }
}