using System;

namespace Matrix
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int d = int.Parse(Console.ReadLine());

            for (int i = a; i <= b; i++)
            {
                for (int j = a; j <= b; j++)
                {
                    for (int k = c; k <= d; k++)
                    {
                        for (int z = c; z <= d; z++)
                        {
                            if ((i + z) == (j + k) && (i != j) && (k != z))
                            {
                                Console.WriteLine($"{i}{j}");
                                Console.WriteLine($"{k}{z}");
                                Console.WriteLine();
                            }
                        }
                    }
                }
            }
        }
    }
}
