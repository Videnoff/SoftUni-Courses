using System;

namespace Birthday
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());

            double volume = length * width * height;
            double litters = volume * 0.001;
            double sandPercent = percent * 0.01;
            double waterLitters = litters * (1 - sandPercent);


            Console.WriteLine("{0:F3}" ,waterLitters);
        }
    }
}
