using System;

namespace PadawanEquipment
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            double students = int.Parse(Console.ReadLine());
            double sablePrice = double.Parse(Console.ReadLine());
            double robePrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());

            double sableMoney = students * sablePrice;
            double sableMore = Math.Ceiling(students * 10 / 100) * sablePrice;
            double sableTotal = sableMoney + sableMore;
            double robeMoney = students * robePrice;
            double beltMoney = students * beltPrice;
            int freeBelts = 0;
            if (students >= 6)
            {
                freeBelts = ((int)students / 6);
            }

            double totalSum = sableTotal + robeMoney + (beltMoney - (freeBelts * beltPrice));

            if (totalSum <= money)
            {
                Console.WriteLine($"The money is enough - it would cost {totalSum:F2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {Math.Abs(totalSum - money):F2}lv more.");
            }
        }
    }
}
