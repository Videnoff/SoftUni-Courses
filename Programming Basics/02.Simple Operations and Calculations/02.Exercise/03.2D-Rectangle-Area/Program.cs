using System;

namespace DRectangleArea
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            double area = (Math.Abs(x1 - x2) * (Math.Abs(y1 - y2)));
            double perimeter = Math.Abs((x1 - x2) * 2) + Math.Abs((y1 - y2) * 2);
            Console.WriteLine("{0:F2}", area);
            Console.WriteLine("{0:F2}", perimeter);
        }
    }
}
