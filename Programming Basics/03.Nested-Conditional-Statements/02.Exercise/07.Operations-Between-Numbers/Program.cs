using System;

namespace OperationsBetweenNumbers
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double N1 = int.Parse(Console.ReadLine());
            double N2 = int.Parse(Console.ReadLine());
            char ch = char.Parse(Console.ReadLine());
            double result = 0.0;
            string oddEven = "";

            if (ch == '+')
            {
                result = N1 + N2;
                if (result % 2 != 0)
                {
                    oddEven = "odd";
                    Console.WriteLine($"{N1} {ch} {N2} = {result} - {oddEven}");
                }
                else
                {
                    oddEven = "even";
                    Console.WriteLine($"{N1} {ch} {N2} = {result} - {oddEven}");
                }
            }
            else if (ch == '-')
            {
                result = N1 - N2;
                if (result % 2 != 0)
                {
                    oddEven = "odd";
                    Console.WriteLine($"{N1} {ch} {N2} = {result} - {oddEven}");
                }
                else
                {
                    oddEven = "even";
                    Console.WriteLine($"{N1} {ch} {N2} = {result} - {oddEven}");
                }
            }
            else if (ch == '*')
            {
                result = N1 * N2;
                if (result % 2 != 0)
                {
                    oddEven = "odd";
                    Console.WriteLine($"{N1} {ch} {N2} = {result} - {oddEven}");
                }
                else
                {
                    oddEven = "even";
                    Console.WriteLine($"{N1} {ch} {N2} = {result} - {oddEven}");
                }
            }
            else if (ch == '/')
            {
                result = N1 / N2;
                if (N2 == 0)
                {
                    Console.WriteLine($"Cannot divide {N1} by zero");
                }
                else
                {
                    Console.WriteLine($"{N1} / {N2} = {result:F2}");
                }
            }
            else if (ch == '%')
            {
                result = N1 % N2;
                if (N2 == 0)
                {
                    Console.WriteLine($"Cannot divide {N1} by zero");
                }
                else
                {
                    Console.WriteLine($"{N1} % {N2} = {result}");
                }
            }
        }
    }
}
