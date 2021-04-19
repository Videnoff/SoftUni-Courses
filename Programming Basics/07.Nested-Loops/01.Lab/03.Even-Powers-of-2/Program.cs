using System;

namespace EvenPowersof2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int current = 1;
            for (int i = 0; i <= n; i += 2)
            {
                Console.WriteLine(current);
                current = current * 4;

            }
        }
    }
}
