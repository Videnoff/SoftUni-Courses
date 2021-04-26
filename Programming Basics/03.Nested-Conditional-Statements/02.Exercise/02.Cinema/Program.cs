using System;

namespace Cinema
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string projection = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            double sum = rows * cols;

            if (projection == "Premiere")
            {
                sum *= 12.00;
                Console.WriteLine($"{sum:F2} leva");
            }
            else if (projection == "Normal")
            {
                sum *= 7.50;
                Console.WriteLine($"{sum:F2} leva");
            }
            else if (projection == "Discount")
            {
                sum *= 5.00;
                Console.WriteLine($"{sum:F2} leva");
            }
        }
    }
}
