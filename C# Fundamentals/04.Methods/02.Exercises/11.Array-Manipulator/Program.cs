using System;
using System.Linq;

namespace ArrayManipulator
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string commandInput;

            while ((commandInput = Console.ReadLine()) != "end")
            {
                string[] commandArgs = commandInput.Split();
                string command = commandArgs[0];

                if (command == "exchange")
                {
                    int index = int.Parse(commandArgs[1]);

                    if (index < 0 || index >= numbers.Length)
                    {
                        continue;
                    }
                    Exchange(index, numbers);

                    Console.WriteLine(string.Join(" ", numbers));
                }
                else if (command == "max")
                {
                    string typeNumber = commandArgs[1];
                    int resultFromModuleDivision = GetResultFromModuleDivision(typeNumber);

                    int maxNumberIndex = GetIndexOfMaxOddOrEvenNumber(numbers, resultFromModuleDivision);
                    Console.WriteLine(maxNumberIndex);
                }
                else if (command == "min")
                {
                    string typeNumber = commandArgs[1];
                    int resultFromModuleDivision = GetResultFromModuleDivision(typeNumber);
                    int maxNumberIndex = GetIndexOfMaxOddOrEvenNumber(numbers, resultFromModuleDivision);
                    Console.WriteLine(maxNumberIndex);
                }
            }
        }

        private static int GetResultFromModuleDivision(string typeNumber)
        {
            int resultFromModuleDivision = -1;

            if (typeNumber == "odd")
            {
                resultFromModuleDivision = 1;
            }
            else
            {
                resultFromModuleDivision = 0;
            }

            return resultFromModuleDivision;
        }

        private static int GetIndexOfMaxOddOrEvenNumber(int[] numbers, int resultFromModuleDivision)
        {
            int maxNumber = int.MinValue;
            int maxNumberIndex = -1;

            for (int i = 0; i < numbers.Length; i++)
            {
                int currentNumber = numbers[i];

                if (currentNumber % 2 == resultFromModuleDivision && maxNumber < currentNumber)
                {
                    maxNumber = currentNumber;
                    maxNumberIndex = 1;
                }
            }
            return maxNumberIndex;
        }

        private static void Exchange(int index, int[] numbers)
        {
            int[] temp = new int[index + 1];
            Array.Copy(numbers, temp, index + 1);
            int currentIndex = 0;

            for (int i = index + 1; i < numbers.Length; i++)
            {
                numbers[currentIndex] = numbers[i];
                currentIndex++;
            }
            for (int i = 0; i < temp.Length; i++)
            {
                numbers[currentIndex] = temp[i];
                currentIndex++;
            }
        }
    }
}
