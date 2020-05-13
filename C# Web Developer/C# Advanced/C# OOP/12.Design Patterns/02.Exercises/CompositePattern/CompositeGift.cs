using System;
using System.Collections;
using System.Collections.Generic;

namespace CompositePattern
{
    public class CompositeGift : GiftBase, IGiftOperations
    {
        private readonly ICollection<GiftBase> gifts;

        public CompositeGift(string name, int price) 
            : base(name, price)
        {
            this.gifts = new List<GiftBase>();
        }

        public override int CalculateTotalPrice()
        {
            var totalPrice = 0;

            // Output
            Console.WriteLine($"{this.name} contains following products with prices:");

            foreach (var gift in this.gifts)
            {
                totalPrice += gift.CalculateTotalPrice();
            }

            return totalPrice;
        }

        public void Add(GiftBase gift)
        {
            this.gifts.Add(gift);
        }

        public void Remove(GiftBase gift)
        {
            this.gifts.Remove(gift);
        }
    }
}