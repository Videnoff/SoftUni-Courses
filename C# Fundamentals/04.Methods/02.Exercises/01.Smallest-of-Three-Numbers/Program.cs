using System;

namespace SmallestofThreeNumbers
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Result();
        }
        static void Result()
        {
            int result = int.Parse(Console.ReadLine());
            for (int i = 0; i < 2; i++)
            {
                int number = int.Parse(Console.ReadLine());
                result = SmallerNumber(number, result);
            }
            Console.WriteLine(result);
        }
        static int SmallerNumber(int result, int number)
        {
            if (result > number)
            {
                return number;
            }
            return result;
        }
    }
}

