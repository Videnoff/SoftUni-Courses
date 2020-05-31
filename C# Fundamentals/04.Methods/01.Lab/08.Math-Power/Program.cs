using System;

namespace MathPower
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            double n = double.Parse(Console.ReadLine());
            int pow = int.Parse(Console.ReadLine());
            Console.WriteLine(Power(n, pow));
        }

        private static double Power(double n, int pow)
        {
            double result = 1;
            for (int i = 0; i < pow; i++)
            {
                result *= n;
            }
            return result;
        }
    }
}
