using System;

namespace BasketballEquipment
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double yearTax = double.Parse(Console.ReadLine());

            double boots = yearTax - ((yearTax * 40) / 100);
            double outfit = boots - ((boots * 20) / 100);
            double ball = outfit / 4.0;
            double accessories = ball / 5.0;
            double total = yearTax + boots + outfit + ball + accessories;
            Console.WriteLine($"{total:F2}");
        }
    }
}
