using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Sherlock_and_the_Valid_String
{
    public static class SherlockStringAnalyzer
    {
        public static string IsValid (string verifyingString)
        {
            switch (verifyingString.Length)
            {
                case 0:
                    return "NO";
                case 1:
                    return "YES";
                default:
                {
                    var charDatabase = verifyingString
                        .GroupBy(ch => ch)
                        .ToDictionary(charGroup => charGroup.Key, charGroup => charGroup.Count());

                    return TryValidate(charDatabase) ? "YES" : "NO";
                }
            }
        }

        private static bool TryValidate(Dictionary<char, int> charDatabase)
        {
            var sortedCharCount = charDatabase.Values.OrderBy(x => x).ToArray();
            var tryCounter = 0;
            int smallestNum;
            
            // If we see that the smallest number of certain character appears once in the sequence, 
            // skip it and use our attempt to delete one character
            if (sortedCharCount[1] != sortedCharCount[0])
            {
                smallestNum = sortedCharCount[1];
                tryCounter++;
            }
            else smallestNum = sortedCharCount[0];
            
            for (var i = 1; i < sortedCharCount.Length; i++)
            {
                if (sortedCharCount[i] > smallestNum + 1) return false;
                if (sortedCharCount[i] == smallestNum + 1) tryCounter++;
                if (tryCounter == 2) return false;
            }
            return true;
        }
    }
}