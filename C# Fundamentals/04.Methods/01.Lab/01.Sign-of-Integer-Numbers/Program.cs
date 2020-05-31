using System;

namespace SignofIntegerNumbers
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            PrintSign();
        }

        private static void PrintSign()
        {
            string sign = "";
            int n = int.Parse(Console.ReadLine());
            if (n > 0)
            {
                sign = "positive";
            }
            else if (n < 0)
            {
                sign = "negative";
            }
            else
            {
                sign = "zero";
            }
            Console.WriteLine($"The number {n} is {sign}.");
        }
    }
}
