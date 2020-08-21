using System;

namespace Sherlock_and_the_Valid_String
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = "aabbc";
            var analyzer = SherlockStringAnalyzer.IsValid(test);
        }
    }
}