using System;
using System.Collections.Generic;
using _03.Shopping_Spree.Common;

namespace _03.Shopping_Spree.Models
{
    public class Person
    {
        private const decimal MONEY_MIN_VALUE = 0;

        private string name;
        private decimal money;
        private List<Product> bag;

        private Person()
        {
            this.bag = new List<Product>();
        }

        public Person(string name, decimal money)
            : this()
        {
            this.Name = name;
            this.Money = money;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(GlobalConstants.InvalidNameExceptionMessage);
                }

                this.name = value;
            }
        }

        public decimal Money
        {
            get
            {
                return this.money;
            }
            private set
            {
                if (value < MONEY_MIN_VALUE)
                {
                    throw new ArgumentException(GlobalConstants.InvalidMoneyExceptionMessage);
                }

                this.money = value;
            }
        }

        public IReadOnlyCollection<Product> Bag => this.bag;

        public void BuyProduct(Product product)
        {
            if (this.Money < product.Cost)
            {
                throw new InvalidOperationException(string.Format(GlobalConstants.InsufficientMoneyExceptionMessage, this.Name, product.Name));
            }

            this.Money -= product.Cost;
            this.bag.Add(product);
        }

        public override string ToString()
        {
            string productOutput = this.Bag.Count > 0 ? string.Join(", ", this.Bag) : $"Nothing bought";
            return $"{this.Name} - {productOutput}";
        }
    }
}