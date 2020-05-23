using System;

namespace Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = 10;
            var b = 20;

            if (a < b)
            {
                throw new Exception();
            }

            Console.WriteLine("Finished");
        }
    }
}
