using System;

namespace RadianstoDegrees
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double rads = double.Parse(Console.ReadLine());
            double grads = rads * 180 / Math.PI;
            Console.WriteLine(Math.Round(grads));
        }
    }
}
