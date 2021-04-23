using System;

namespace Coins
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine()) * 100;
            double rest = 0;
            double coinCounter = 0;

            while (money > 0)
            {
                // 2 lv
                rest = money % 200;
                coinCounter += Math.Floor(money / 200);
                money = money - coinCounter * 200;

                // 1 lv
                money = rest;
                rest = money % 100;
                coinCounter += Math.Floor(money / 100);
                money = money - coinCounter * 100;

                // 0.50 lv
                money = rest;
                rest = money % 50;
                coinCounter += Math.Floor(money / 50);
                money = money - coinCounter * 50;

                // 0.20 lv
                money = rest;
                rest = money % 20;
                coinCounter += Math.Floor(money / 20);
                money = money - coinCounter * 20;

                // 0.10 lv
                money = rest;
                rest = money % 10;
                coinCounter += Math.Floor(money / 10);
                money = money - coinCounter * 10;

                // 0.05 lv
                money = rest;
                rest = money % 5;
                coinCounter += Math.Floor(money / 5);
                money = money - coinCounter * 5;

                // 0.02 lv
                money = rest;
                rest = money % 2;
                coinCounter += Math.Floor(money / 2);
                money = money - coinCounter * 2;

                // 0.01 lv
                money = rest;
                rest = money % 1;
                coinCounter += Math.Floor(money / 1);
                money = money - coinCounter * 1;
            }

            Console.WriteLine(coinCounter);
        }
    }
}
