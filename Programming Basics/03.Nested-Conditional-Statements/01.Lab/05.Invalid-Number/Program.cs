using System;

namespace InvalidNumber
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            if (!(n == 0 || n >= 100 && n <= 200))
            {
                Console.WriteLine("invalid");
            }
        }
    }
}
