using System;
using System.Linq;
using System.Collections.Generic;

namespace BombNumbers
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int[] specialNumberAndPower = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int specialNumber = specialNumberAndPower[0];
            int power = specialNumberAndPower[1];

            int indexOfSpecialNumber = 0;

            while (numbers.Contains(specialNumber))
            {
                indexOfSpecialNumber = numbers.IndexOf(specialNumber);
                int leftRange = power;
                int rightRange = power;

                if (indexOfSpecialNumber - leftRange < 0)
                {
                    leftRange = indexOfSpecialNumber;
                }

                if (indexOfSpecialNumber + rightRange >= numbers.Count)
                {
                    rightRange = numbers.Count - indexOfSpecialNumber - 1;
                }

                numbers.RemoveRange(indexOfSpecialNumber - leftRange, leftRange + rightRange + 1);
            }

            Console.WriteLine(numbers.Sum());
        }
    }
}
