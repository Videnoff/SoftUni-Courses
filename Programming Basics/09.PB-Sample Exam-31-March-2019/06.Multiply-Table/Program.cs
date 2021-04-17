using System;

namespace MultiplyTable
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int singleDigitNum = 0;
            int doubleDigitNum = 0;
            int tripleDigitNum = 0;

            singleDigitNum = n % 10;
            doubleDigitNum = (n / 10) % 10;
            tripleDigitNum = n / 100;

            for (int i = 1; i <= singleDigitNum; i++)
            {
                for (int j = 1; j <= doubleDigitNum; j++)
                {
                    for (int k = 1; k <= tripleDigitNum; k++)
                    {
                        Console.WriteLine($"{i} * {j} * {k} = {i * j * k};");
                    }
                }
            }
        }
    }
}
