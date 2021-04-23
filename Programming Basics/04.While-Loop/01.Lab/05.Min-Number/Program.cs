using System;

namespace MinNumber
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int counter = 0;
            int max = int.MaxValue;
            while (counter < n)
            {
                int a = int.Parse(Console.ReadLine());
                counter++;

                if (a < max)
                {
                    max = a;
                }
            }
            Console.WriteLine(max);
        }
    }
}
