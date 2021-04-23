using System;

namespace EqualPairs
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int sum1 = num1 + num2;
            int sum2 = sum1;
            bool isTrue = true;
            int maxValue = 0;
            int diff = 0;

            for (int i = 1; i <= n - 1; i++)
            {
                int a = int.Parse(Console.ReadLine());
                int b = int.Parse(Console.ReadLine());
                sum1 = (a + b);

                if (sum1 != sum2)
                {
                    isTrue = false;
                }
                diff = Math.Abs(sum1 - sum2);
                if (diff >maxValue)
                {
                    maxValue = diff;
                }
                sum2 = sum1;
            }

            if (isTrue)
            {
                Console.WriteLine($"Yes, value={sum1}");
            }
            else
            {
                Console.WriteLine($"No, maxdiff={maxValue}");
            }
        }
    }
}
