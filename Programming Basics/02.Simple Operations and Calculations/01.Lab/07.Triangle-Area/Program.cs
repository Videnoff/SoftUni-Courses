using System;

namespace TriangleArea
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double side = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());
            double area = side * h / 2;
            Console.WriteLine("{0:F2}", area);
        }
    }
}
