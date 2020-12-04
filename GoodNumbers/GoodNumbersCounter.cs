using System.Threading;

namespace GoodNumbers
{
    public static class GoodNumbersCounter
    {
        private static readonly Mutex MutexObj = new Mutex(); 
        public static uint Result { get; private set; }

        public static void ResetResult() => Result = 0;
        
        public static void CountGoodNumbers(object rangeObj)
        {
            if (!(rangeObj is NumberRange)) return;
           
            var range = (NumberRange) rangeObj;
            var localResult = 0u;
            
            for (var n = range.Start; n <= range.End; n++)
                if (n.IsGoodNumber())
                    localResult++;
            
            MutexObj.WaitOne();
            Result += localResult;
            MutexObj.ReleaseMutex();
        }
        
        private static bool IsGoodNumber(this uint number)
        {
            var tempNum = number;
            var digitSum = 0u;

            while (tempNum > 0)
            {
                digitSum += tempNum % 10;
                tempNum /= 10;
            }

            return number % digitSum == 0;
        }
    }
}