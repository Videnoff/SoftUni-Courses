using System;

namespace Vacation
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double excMoney = double.Parse(Console.ReadLine());
            double actMoney = double.Parse(Console.ReadLine());
            int daysCounter = 0;
            int spendCounter = 0;

            while (actMoney < excMoney)
            {
                string action = Console.ReadLine();
                double sum = double.Parse(Console.ReadLine());

                if (action == "spend")
                {
                    if (actMoney <= sum)
                    {
                        actMoney = 0.0;
                    }
                    else
                    {
                        actMoney -= sum;
                    }
                    daysCounter++;
                    spendCounter++;
                    if (spendCounter >= 5)
                    {
                        Console.WriteLine("You can't save the money.");
                        Console.WriteLine($"{daysCounter}");
                        break;
                    }
                }
                else if (action == "save")
                {
                    actMoney += sum;
                    daysCounter++;
                    spendCounter = 0;
                }
            }
            if (actMoney >= excMoney)
            {
                Console.WriteLine($"You saved the money for {daysCounter} days.");
            }
        }
    }
}
