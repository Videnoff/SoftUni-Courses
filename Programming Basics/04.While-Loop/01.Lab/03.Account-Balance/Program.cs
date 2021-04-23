using System;

namespace AccountBalance
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int counter = 0;
            double balance = 0.0;
            while (counter < n)
            {
                double k = double.Parse(Console.ReadLine());
                if (k < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                Console.WriteLine($"Increase: {k:F2}");
                counter++;
                balance += k;
            }
            Console.WriteLine($"Total: {balance:F2}");
        }
    }
}
