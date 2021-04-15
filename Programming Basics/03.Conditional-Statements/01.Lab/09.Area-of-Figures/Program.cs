using System;

namespace AreaofFigures
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string figure = Console.ReadLine();

            if (figure == "square")
            {
                double side = double.Parse(Console.ReadLine());
                double area = side * side;
                Console.WriteLine($"{area:F3}");
            }
            else if (figure == "rectangle")
            {
                double side = double.Parse(Console.ReadLine());
                double sideB = double.Parse(Console.ReadLine());
                double area = side * sideB;
                Console.WriteLine($"{area:F3}");
            }
            else if (figure == "circle")
            {
                double radius = double.Parse(Console.ReadLine());
                double area = Math.PI * radius * radius;
                Console.WriteLine($"{area:F3}");
            }
            else if (figure == "triangle")
            {
                double side = double.Parse(Console.ReadLine());
                double h = double.Parse(Console.ReadLine());
                double area = side * h / 2;
                Console.WriteLine($"{area:F3}");
            }
        }
    }
}
