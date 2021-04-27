using System;

namespace MetricConverter
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double n = double.Parse(Console.ReadLine());
            string unitIn = Console.ReadLine();
            string unitOut = Console.ReadLine();

            if (unitIn == "mm")
            {
                if (unitOut == "mm")
                {
                    n += n;
                }
                else if (unitOut == "cm")
                {
                    n /= 10;
                }
                else if (unitOut == "m")
                {
                    n /= 1000; 
                }
            }
            else if (unitIn == "cm")
            {
                if (unitOut == "cm")
                {
                    n += n;
                }
                else if (unitOut == "mm")
                {
                    n *= 10;
                }
                else if (unitOut == "m")
                {
                    n /= 100;
                }
            }
            else if (unitIn == "m")
            {
                if (unitOut == "m")
                {
                    n += n;
                }
                else if (unitOut == "mm")
                {
                    n *= 1000;
                }
                else if (unitOut == "cm")
                {
                    n *= 100;;
                }
            }
            Console.WriteLine($"{n:F3}");
        }
    }
}
