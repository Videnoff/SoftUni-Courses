using System;

namespace MaxNumber
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string s = Console.ReadLine();
            int maxNumber = int.MinValue;
            int minNumber = int.MaxValue;

            while (s != "END")
            {
                int n = int.Parse(s);

                if (n < minNumber)
                {
                    minNumber = n;
                }
                if (n > maxNumber)
                {
                    maxNumber = n;
                }
                s = Console.ReadLine();
            }

            Console.WriteLine($"Max number: {maxNumber}");
            Console.WriteLine($"Min number: {minNumber}");
        }
    }
}
