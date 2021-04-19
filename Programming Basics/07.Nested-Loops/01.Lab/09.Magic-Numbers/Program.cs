using System;

namespace MagicNumbers
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= 9; i++)
            {
                for (int j = 1; j <= 9; j++)
                {
                    for (int k = 1; k <= 9; k++)
                    {
                        for (int x = 1; x <= 9; x++)
                        {
                            for (int y = 1; y <= 9; y++)
                            {
                                for (int z = 1; z <= 9; z++)
                                {
                                    int num = i * j * k * x * y * z;
                                    if (num == n)
                                    {
                                        Console.Write($"{i}{j}{k}{x}{y}{z} ");
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
