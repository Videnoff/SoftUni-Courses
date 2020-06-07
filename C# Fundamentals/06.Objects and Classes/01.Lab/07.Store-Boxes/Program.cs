using System;
using System.Linq;

namespace StoreBoxes
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string input;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] splittedInput = input.Split();
                string serialNumber = splittedInput[0];
                string itemName = splittedInput[1];
                int itemQuantity = int.Parse(splittedInput[2]);
                decimal itemPrice = decimal.Parse(splittedInput[3]);

                Item item = new Item();
            }
        }
    }

    class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    class Box
    {
        public Box()
        {
            Item = new Item();
        }
        public string SerialNumber { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public decimal PriceBox { get; set; }
    }
}
