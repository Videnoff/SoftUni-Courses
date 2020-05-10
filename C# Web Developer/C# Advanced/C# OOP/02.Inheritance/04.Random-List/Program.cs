using System;

namespace _04.Random_List
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 100; i++)
            {
                var random = new Random();

                Console.WriteLine(random.Next(0, 100));
            }
        }
    }
}
