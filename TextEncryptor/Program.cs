using System;
using System.Text;
using CommandLine;

namespace TextEncryptor
{
    class Program
    {
        private class Options
        {
            [Option('e', "encrypt", Required = false, HelpText = "Encrypt Text", SetName = "Enc")]
            public string TextToEncrypt { get; set; }
            
            [Option('d', "decrypt", Required = false, HelpText = "Decrypt Text", SetName = "Dec")]
            public string TextToDecrypt { get; set; }
        }

        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(RunOptions);
        }

        private static void RunOptions(Options opts)
        {
            if (opts.TextToEncrypt is not null) Console.WriteLine(Encryptor.Encrypt(opts.TextToEncrypt));
            if (opts.TextToDecrypt is not null) Console.WriteLine(Encryptor.Encrypt(opts.TextToDecrypt));
        }

    }
}