using System;

namespace MultiplyEvensbyOdds
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int n = Math.Abs(int.Parse(Console.ReadLine()));
            int result = GetMultipleOfEvenAndOdds(n);
            Console.WriteLine(result);
        }
        static int GetMultipleOfEvenAndOdds(int n)
        {
            int result = GetSumOfEvenDigits(n) * GetSumOfOddDigits(n);
            return result;
        }
        static int GetSumOfEvenDigits(int n)
        {
            int evenSum = 0;
            while (n > 0)
            {
                int result = n % 10;
                n /= 10;
                if (result % 2 != 0)
                {
                    evenSum += result;
                }
            }
            return evenSum;
        }
        static int GetSumOfOddDigits(int n)
        {
            int oddSum = 0;
            while (n > 0)
            {
                int result = n % 10;
                n /= 10;
                if (result % 2 == 0)
                {
                    oddSum += result;
                }
            }
            return oddSum;
        }
    }
}
