using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using INStock.Contracts;

namespace INStock
{
    public class ProductStock : IProductStock
    {
        private readonly List<IProduct> productsByIndex;
        private readonly HashSet<string> productLabels;
        private readonly Dictionary<string, IProduct> productsByLabel;
        private readonly SortedDictionary<decimal, List<IProduct>> productsSortedByPrice;
        private readonly Dictionary<int, List<IProduct>> productsByQuantity;

        public ProductStock()
        {
            this.productsByQuantity = new Dictionary<int, List<IProduct>>();
            this.productsSortedByPrice =
                new SortedDictionary<decimal, List<IProduct>>(Comparer<decimal>.Create((first, second) =>
                    second.CompareTo(first)));
            this.productsByLabel = new Dictionary<string, IProduct>();
            this.productLabels = new HashSet<string>();
            this.productsByIndex = new List<IProduct>();
        }

        public int Count => this.productsByIndex.Count;

        public bool Contains(IProduct product)
        {
            this.ValidateNullProduct(product);

            return this.productLabels.Contains(product.Label);
        }

        public IProduct Find(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException($"Product index does not exist.");
            }

            return this.productsByIndex[index];
        }

        public IProduct FindByLabel(string label)
        {
            if (!this.productLabels.Contains(label))
            {
                throw new ArgumentException($"Product with '{label}' label could not be found");
            }

            return this.productsByLabel[label];
        }

        public IProduct FindMostExpensiveProduct()
        {
            if (!this.productsSortedByPrice.Any())
            {
                throw new InvalidOperationException($"Product stock is empty");
            }

            var mostExpensiveProducts = this.productsSortedByPrice.First().Value;
            var firstAddedExpensiveProduct = mostExpensiveProducts.First();


            return firstAddedExpensiveProduct;
        }

        public IEnumerable<IProduct> FindAllInRange(double lo, double hi)
        {
            var result = new List<IProduct>();

            foreach (var (price, products) in this.productsSortedByPrice)
            {
                var priceAsDouble = (double) price;

                if (lo <= priceAsDouble && priceAsDouble <= hi)
                {
                    result.AddRange(products);
                }

                if ((double) price < lo)
                {
                    break;
                }
            }

            return result;
        }

        public IEnumerable<IProduct> FindAllByPrice(double price)
        {
            var priceAsDecimal = (decimal) price;

            if (!this.productsSortedByPrice.ContainsKey(priceAsDecimal))
            {
                return Enumerable.Empty<IProduct>();
            }

            return this.productsSortedByPrice[priceAsDecimal];
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            if (!this.productsByQuantity.ContainsKey(quantity))
            {
                return Enumerable.Empty<IProduct>();
            }

            return this.productsByQuantity[quantity];
        }

        public IEnumerator<IProduct> GetEnumerator() => this.productsByIndex.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        public IProduct this[int index]
        {
            get => this.Find(index);

            set
            {
                this.ValidateNullProduct(value);

                this.RemoveProductFromCollections(this.Find(index));

                this.InitializeCollections(value);

                this.productsByIndex[index] = value;
            }
        }


        public void Add(IProduct product)
        {
            ValidateNullProduct(product);

            if (this.productLabels.Contains(product.Label))
            {
                throw new ArgumentException($"A product with '{product.Label}' label already exists.");
            }

            this.InitializeCollections(product);

            this.productLabels.Add(product.Label);
            this.productsByIndex.Add(product);
            this.productsByLabel[product.Label] = product;
            this.productsByQuantity[product.Quantity].Add(product);
            this.productsSortedByPrice[product.Price].Add(product);
        }

        public bool Remove(IProduct product)
        {
            this.ValidateNullProduct(product);

            var label = product.Label;

            if (!this.productLabels.Contains(product.Label))
            {
                return false;
            }

            this.RemoveProductFromCollections(product);

            this.productsByIndex.RemoveAll(pr => pr.Label == label);

            return true;
        }

        private void ValidateNullProduct(IProduct product)
        {
            if (product == null)
            {
                throw new ArgumentException("Product cannot be null");
            }
        }

        private void InitializeCollections(IProduct product)
        {
            if (!this.productsByQuantity.ContainsKey(product.Quantity))
            {
                this.productsByQuantity[product.Quantity] = new List<IProduct>();
            }

            if (!this.productsSortedByPrice.ContainsKey(product.Price))
            {
                this.productsSortedByPrice[product.Price] = new List<IProduct>();
            }
        }

        private void RemoveProductFromCollections(IProduct product)
        {
            var label = product.Label;

            var allWithProductQuantity = this.productsByQuantity[product.Quantity];
            allWithProductQuantity.RemoveAll(pr => pr.Label == label);

            var allWithProductPrice = this.productsSortedByPrice[product.Price];
            allWithProductPrice.RemoveAll(pr => pr.Label == label);

            this.productsByLabel.Remove(label);

            this.productLabels.Remove(label);
        }
    }
}