using System;

namespace RefactoringPrimeChecker
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());
            for (int i = 2; i <= numbers; i++)
            {
                bool isPrime = true;
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                Console.WriteLine($"{i} -> {isPrime.ToString().ToLower()}");
            }
        }
    }
}
