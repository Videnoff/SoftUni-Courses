using System;

namespace CharityCampaign
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int campaignDays = int.Parse(Console.ReadLine());
            int chefs = int.Parse(Console.ReadLine());
            int cakes = int.Parse(Console.ReadLine());
            int wafles = int.Parse(Console.ReadLine());
            int pancakes = int.Parse(Console.ReadLine());

            double cakesSum = cakes * 45;
            double waflesSum = wafles * 5.80;
            double pancakesSum = pancakes * 3.20;

            double chefsSum = chefs * (cakesSum + waflesSum + pancakesSum);
            double totalProd = chefsSum * campaignDays;
            double campaignExpences = totalProd / 8;
            double profit = totalProd - campaignExpences;
            Console.WriteLine($"{profit:F2}");
        }
    }
}
