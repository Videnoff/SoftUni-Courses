using System;

namespace CompositePattern
{
    class StartUp
    {
        static void Main(string[] args)
        {
            SingleGift phone = new SingleGift("Phone", 256);
            phone.CalculateTotalPrice();
            Console.WriteLine();

            CompositeGift roobBox = new CompositeGift("RootBox", 0);

            SingleGift truckToy = new SingleGift("Truck", 289);
            SingleGift plainToy = new SingleGift("PlainToy", 587);

            roobBox.Add(truckToy);
            roobBox.Add(plainToy);

            CompositeGift childBox = new CompositeGift("ChildBox", 0);
            SingleGift soldier = new SingleGift("SoldierToy", 200);

            childBox.Add(soldier);
            roobBox.Add(childBox);

            Console.WriteLine($"Total price of this composite present is: {roobBox.CalculateTotalPrice()}");
        }
    }
}
