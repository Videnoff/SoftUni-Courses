using System;

namespace FromLefttoTheRight
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string numbers = Console.ReadLine();
                char delimeter = ' ';
                string[] splitNumbers = numbers.Split(delimeter);

				long leftNum = long.Parse(splitNumbers[0]);
                long rightNum = long.Parse(splitNumbers[1]);

                long biggerNumber = rightNum;

                if (leftNum > rightNum)
                {
                    biggerNumber = leftNum;
                }

                long sumOfDigits = 0;

                while (biggerNumber != 0)
                {
                    sumOfDigits += biggerNumber % 10;
                    biggerNumber /= 10;
                }
                Console.WriteLine(Math.Abs(sumOfDigits));
            }
        }
    }
}
