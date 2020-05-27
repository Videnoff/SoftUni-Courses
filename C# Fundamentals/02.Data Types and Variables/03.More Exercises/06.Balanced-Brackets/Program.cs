using System;

namespace BalancedBrackets
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int counter = n;
            int openBrackets = 0;
            int closeBrackets = 0;
            while (counter > 0)
            {
                string symbol = Console.ReadLine();
                if (symbol == "(")
                {
                    openBrackets++;
                }
                else if (symbol == ")")
                {
                    closeBrackets++;
                    if (openBrackets - closeBrackets != 0)
                    {
                        Console.WriteLine("UNBALANCED");
                        return;
                    }
                }
                counter--;
            }
            if (openBrackets == closeBrackets)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}
