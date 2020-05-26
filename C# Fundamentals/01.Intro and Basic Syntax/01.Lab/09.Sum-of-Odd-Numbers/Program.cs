using System;

namespace SumofOddNumbers
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("{0}", i * i - sum);
                sum += 2 * i - 1;
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
