using System;

namespace MathOperations
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            char @operator = char.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            double result = Calculator(firstNum, @operator, secondNum);

            Console.WriteLine($"{result}");
        }

        private static double Calculator(int firstNum, char @operator, int secondNum)
        {
            double result = 0;

            if (@operator == '/')
            {
                result = firstNum / secondNum;
            }
            else if (@operator == '*')
            {
                result = firstNum * secondNum;
            }
            else if (@operator == '+')
            {
                result = firstNum + secondNum;
            }
            else if (@operator == '-')
            {
                result = firstNum - secondNum;
            }
            return result;
        }
    }
}
