using System;

namespace IntegerOperations
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());
            int fourthNum = int.Parse(Console.ReadLine());

            int sum = firstNum + secondNum;
            int div = sum / thirdNum;
            int mul = div * fourthNum;
            Console.WriteLine(mul);
        }
    }
}
