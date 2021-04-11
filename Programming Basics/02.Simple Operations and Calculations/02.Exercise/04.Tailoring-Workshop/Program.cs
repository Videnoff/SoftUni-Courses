using System;

namespace TailoringWorkshop
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int tables = int.Parse(Console.ReadLine());
            double tablesLength = double.Parse(Console.ReadLine());
            double tablesWidth = double.Parse(Console.ReadLine());

            double coverArea = tables * (tablesLength + (2 * 0.30)) * (tablesWidth + (2 * 0.30));
            double squareArea = tables * (tablesLength / 2) * (tablesLength / 2);

            double coverPriceUSD = coverArea * 7;
            double squarePriceUSD = squareArea * 9;

            double coverPriceBGN = coverPriceUSD * 1.85;
            double squarePriceBGN = squarePriceUSD * 1.85;

            double totalPriceUSD = coverPriceUSD + squarePriceUSD;
            double totalPriceBGN = coverPriceBGN + squarePriceBGN;

            Console.WriteLine("{0:F2} USD", totalPriceUSD);
            Console.WriteLine("{0:F2} BGN", totalPriceBGN);
        }
    }
}
