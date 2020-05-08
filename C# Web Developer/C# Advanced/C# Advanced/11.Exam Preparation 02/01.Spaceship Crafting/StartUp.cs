using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Spaceship_Crafting
{
    public class StartUp
    {
        private const int GLASS_MIN_VALUE = 25;
        private const int ALUMINIUM_MIN_VALUE = 50;
        private const int LITHIUM_MIN_VALUE = 75;
        private const int CARBON_MIN_VALUE = 100;

        private static int glassCount;
        private static int aluminiumCount;
        private static int lithiumCount;
        private static int carbonCount;

        static void Main(string[] args)
        {
            var InputLiquids = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var inputPhysicalItems = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var chemicalLiquids = new Queue<int>(InputLiquids);
            var physicalItems = new Stack<int>(inputPhysicalItems);

            while (chemicalLiquids.Count > 0 && physicalItems.Count > 0)
            {
                MixLiquidAndItem(chemicalLiquids, physicalItems);
            }

            PrintOutput(chemicalLiquids, physicalItems);
        }

        private static void PrintOutput(Queue<int> chemicalLiquids, Stack<int> physicalItems)
        {
            if (glassCount > 0 && aluminiumCount > 0 && lithiumCount > 0 && carbonCount > 0)
            {
                Console.WriteLine($"Wohoo! You succeeded in building the spaceship!");
            }
            else
            {
                Console.WriteLine($"Ugh, what a pity! You didn't have enough materials to build the spaceship.");
            }

            string liquidsString = chemicalLiquids.Count > 0 ? string.Join(", ", chemicalLiquids) : "none";
            Console.WriteLine($"Liquids left: {liquidsString}");

            string itemsString = physicalItems.Count > 0 ? string.Join(", ", physicalItems) : "none";
            Console.WriteLine($"Physical items left: {itemsString}");

            Console.WriteLine($"Aluminium: {aluminiumCount}");
            Console.WriteLine($"Carbon fiber: {carbonCount}");
            Console.WriteLine($"Glass: {glassCount}");
            Console.WriteLine($"Lithium: {lithiumCount}");
        }

        private static void MixLiquidAndItem(Queue<int> chemicalLiquids, Stack<int> physicalItems)
        {
            var currentLiquid = chemicalLiquids.Dequeue();
            var currentItem = physicalItems.Pop();

            var currentSum = currentLiquid + currentItem;

            switch (currentSum)
            {
                case GLASS_MIN_VALUE:
                    glassCount++;
                    break;
                case ALUMINIUM_MIN_VALUE:
                    aluminiumCount++;
                    break;
                case LITHIUM_MIN_VALUE:
                    lithiumCount++;
                    break;
                case CARBON_MIN_VALUE:
                    carbonCount++;
                    break;
                default:
                    physicalItems.Push(currentItem + 3);
                    break;
            }
        }
    }
}
