using System;

namespace Encryption
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var text = "haveaniceday";


            //foreach (var i in Encoder.EncodeText(text))
            //{
            //    Console.WriteLine($"{i}, {i.GetType()}");
            //}

             Console.WriteLine(Encoder.EncodeText(text));
             
        }
    }
}