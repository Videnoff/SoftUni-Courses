using System;
using System.Numerics;

namespace ExactSumofRealNumbers
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            decimal n = decimal.Parse(Console.ReadLine());
            decimal sum = 0;
            for (int i = 1; i <= n; i++)
            {
                decimal num = decimal.Parse(Console.ReadLine());
                sum += num;
            }
            Console.WriteLine(sum);
        }
    }
}
