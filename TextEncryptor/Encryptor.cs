using System;
using System.Collections.Generic;
using System.Text;

namespace TextEncryptor
{
    public static class Encryptor
    {
        private static int EncryptionKey = 0b0011111001101011;
        
        public static string Encrypt(string text)
        {
            var encryptedString = new StringBuilder(text.Length);
            
            foreach (var c in text)
            {
                var encryptedChar = c ^ EncryptionKey;
                encryptedString.Append(Convert.ToChar(encryptedChar));
            }

            return encryptedString.ToString();
        }

        public static string Decrypt(string text) => Encrypt(text);

    }
}