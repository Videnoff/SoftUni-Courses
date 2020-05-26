using System;

namespace EvenNumber
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            while (!(n % 2 == 0))
            {
                Console.WriteLine("Please write an even number.");
                n = int.Parse(Console.ReadLine());
            }
            Console.WriteLine($"The number is: {Math.Abs(n)}");
        }
    }
}
