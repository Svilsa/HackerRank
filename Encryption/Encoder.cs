using System;
using System.Collections.Generic;
using System.Text;

namespace Encryption
{
    static class Encoder
    {
        private static char[,] EncodeMatrix(string text)
        {
 
            int row = (int)Math.Floor(Math.Sqrt(text.Length));
            int col = (int)Math.Ceiling(Math.Sqrt(text.Length));

            if (row * col < text.Length) row++;
            
            char[,] resultMatrix = new char[row, col];

            for (int i = 0, currRow = 0, currCol = 0; i < text.Length; i++, currCol++)
            {
                //Пробегаемся по строке, потом переключаем ряд
                if (currCol == col) { currCol = 0; currRow++; }
                
                resultMatrix[currRow, currCol] = text[i];
            }
            return resultMatrix;
        }

        public static string EncodeText(string text)
        {
            text = text.Replace(" ", String.Empty);

            string result = "";
            var matrix = Encoder.EncodeMatrix(text);

            for (int col = 0; col <= matrix.GetUpperBound(1); col++)
            {
                for (int row = 0; row <= matrix.GetUpperBound(0); row++)
                {
                    if (matrix[row, col] == '\0') continue;
                    result += matrix[row, col];
                }
                result += ' ';
            }
            return result;
        }
    }
}
