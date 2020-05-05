using System;

namespace ConvertMeterstoKilometers
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double meters = double.Parse(Console.ReadLine());
            double kilos = meters / 1000;
            Console.WriteLine($"{kilos:F2}");
        }
    }
}
