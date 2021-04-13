using System;

namespace InchestoCentimeters
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double inches = double.Parse(Console.ReadLine());
            double centimeters = inches * 2.54;
            Console.WriteLine("{0:F2}", centimeters);
        }
    }
}
