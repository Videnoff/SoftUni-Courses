using System;

namespace Combination
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int validCombinations = 0;

            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    for (int k = 0; k <= n; k++)
                    {
                        for (int y = 0; y <= n; y++)
                        {
                            for (int v = 0; v <= n; v++)
                            {
                                if (i + j + k + y + v == n)
                                {
                                    validCombinations++;
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine(validCombinations);
        }
    }
}
