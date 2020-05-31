using System;

namespace Calculations
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            switch (command)
            {
                case "subtract":
                    Subtract(firstNum, secondNum);
                    break;
                case "divide":
                    Divide(firstNum, secondNum);
                    break;
                case "add":
                    Add(firstNum, secondNum);
                    break;
                case "multiply":
                    Multiply(firstNum, secondNum);
                    break;
            }
        }

        private static void Multiply(int firstNum, int secondNum)
        {
            Console.WriteLine(firstNum * secondNum);
        }

        private static void Add(int firstNum, int secondNum)
        {
            Console.WriteLine(firstNum + secondNum);
        }

        private static void Divide(int firstNum, int secondNum)
        {
            Console.WriteLine(firstNum / secondNum);
        }

        private static void Subtract(int firstNum, int secondNum)
        {
            Console.WriteLine(firstNum - secondNum);
        }
    }
}
