using System;

namespace CleverLily
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int lilisAge = int.Parse(Console.ReadLine());
            double washmashinePrice = double.Parse(Console.ReadLine());
            double toyPrice = int.Parse(Console.ReadLine());
            double toys = 0;
            double money = 0;
            double brother = 1.00;

            for (int i = 1; i <= lilisAge; i++)
            {
                if (i % 2 == 0)
                {
                    money += (i * 10 / 2);
                    money -= brother;
                }
                else
                {
                    toys++;
                }
            }
            double toysSum = toys * toyPrice;
            double totalMoney = money + toysSum;
            double diff = Math.Abs(totalMoney - washmashinePrice);

            if (totalMoney >= washmashinePrice)
            {
                Console.WriteLine($"Yes! {diff:F2}");
            }
            else
            {
                Console.WriteLine($"No! {diff:F2}");
            }
        }
    }
}
