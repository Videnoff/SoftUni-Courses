using System;

namespace FloatingEquality
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double eps = 0.000001;

            double diff = Math.Abs(a - b);

            if (diff >= eps)
            {
                Console.WriteLine("False");
            }
            else
            {
                Console.WriteLine("True");
            }
        }
    }
}
