using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            var result = new Stack<string>(input.Reverse());

            while (result.Count > 1)
            {
                var firstNumber = int.Parse(result.Pop());
                var operation = result.Pop();
                var secondNumber = int.Parse(result.Pop());

                var tempResult = operation switch
                {
                    "+" => (firstNumber + secondNumber),
                    "-" => (firstNumber - secondNumber),
                    _ => 0
                };

                result.Push(tempResult.ToString());
            }

            Console.WriteLine(result.Pop());
        }
    }
}
