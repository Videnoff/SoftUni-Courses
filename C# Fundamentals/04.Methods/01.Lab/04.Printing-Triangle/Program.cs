using System;

namespace PrintingTriangle
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            PrintFigure(n);
        }

        private static void PrintFigure(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                PrintLine(i);
            }
            for (int i = n - 1; i >= 1; i--)
            {
                PrintLine(i);
            }
        }

        public static void PrintLine(int i)
        {
            for (int j = 1; j <= i; j++)
            {
                Console.Write(j + " ");
            }
            Console.WriteLine();
        }
    }
}
