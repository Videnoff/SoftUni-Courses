using System;

namespace SortNumbers
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());

            if ((firstNum > secNum) && (firstNum > thirdNum))
            {
                if (secNum > thirdNum)
                {
                    Console.WriteLine($"{firstNum}");
                    Console.WriteLine($"{secNum}");
                    Console.WriteLine($"{thirdNum}");
                }
                else
                {
                    Console.WriteLine($"{firstNum}");
                    Console.WriteLine($"{thirdNum}");
                    Console.WriteLine($"{secNum}");
                }
            }
            else if ((secNum > firstNum) && (secNum > thirdNum))
            {
                if (firstNum > thirdNum)
                {
                    Console.WriteLine($"{secNum}");
                    Console.WriteLine($"{firstNum}");
                    Console.WriteLine($"{thirdNum}");
                }
                else
                {
                    Console.WriteLine($"{secNum}");
                    Console.WriteLine($"{thirdNum}");
                    Console.WriteLine($"{firstNum}");
                }
            }
            else if ((thirdNum > firstNum) && (thirdNum > secNum))
            {
                if (firstNum > secNum)
                {
                    Console.WriteLine($"{thirdNum}");
                    Console.WriteLine($"{firstNum}");
                    Console.WriteLine($"{secNum}");
                }
                else
                {
                    Console.WriteLine($"{thirdNum}");
                    Console.WriteLine($"{secNum}");
                    Console.WriteLine($"{firstNum}");
                }
            }
        }
    }
}
