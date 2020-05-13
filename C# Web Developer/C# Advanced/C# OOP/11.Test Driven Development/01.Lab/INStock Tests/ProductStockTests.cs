using System;
using System.Linq;

namespace INStock.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class ProductStockTests
    {
        private const string ProductLabel = "Test";
        private const string AnotherProductLabel = "Another Test";

        private ProductStock productStock;
        private Product product;
        private Product anotherProduct;

        [SetUp]
        public void SetUpProduct()
        {
            this.product = new Product(ProductLabel, 10, 1);
            this.productStock = new ProductStock();
            this.anotherProduct = new Product(AnotherProductLabel, 20, 5);
        }

        [Test]
        public void AddProductShouldSaveTheProduct()
        {
            this.productStock.Add(this.product);

            var productInStock = this.productStock.FindByLabel(ProductLabel);

            Assert.That(productInStock, Is.Not.Null);
            Assert.That(productInStock.Label, Is.EqualTo(ProductLabel));
            Assert.That(productInStock.Price, Is.EqualTo(10));
            Assert.That(productInStock.Quantity, Is.EqualTo(1));
        }

        [Test]
        public void AddProductShouldThrowExceptionWithDuplicateLabel()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.productStock.Add(product);
                this.productStock.Add(product);
            }, $"A product with '{ProductLabel}' label already exists.");
        }

        [Test]
        public void AddingTwoProductShouldSaveThem()
        {
            this.productStock.Add(this.product);
            this.productStock.Add(this.anotherProduct);

            var firstProductInStock = this.productStock.FindByLabel(ProductLabel);
            var secondProductInStock = this.productStock.FindByLabel(AnotherProductLabel);

            Assert.That(firstProductInStock, Is.Not.Null);
            Assert.That(firstProductInStock.Label, Is.EqualTo(ProductLabel));
            Assert.That(firstProductInStock.Price, Is.EqualTo(10));
            Assert.That(firstProductInStock.Quantity, Is.EqualTo(1));

            Assert.That(secondProductInStock, Is.Not.Null);
            Assert.That(secondProductInStock.Label, Is.EqualTo(AnotherProductLabel));
            Assert.That(secondProductInStock.Price, Is.EqualTo(20));
            Assert.That(secondProductInStock.Quantity, Is.EqualTo(5));
        }

        [Test]
        public void RemoveShouldThrowExceptionWhenProductIsNull()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.productStock.Remove(null);
            }, $"Product cannot be null.");
        }

        [Test]
        public void RemoveShouldReturnTrueWhenProductIsRemoved()
        {
            this.AddMultipleProductsInProductStock();

            var productToRemove = this.productStock.Find(3);

            var result = this.productStock.Remove(productToRemove);

            Assert.That(result, Is.True);
            Assert.That(this.productStock.Count, Is.EqualTo(4));
            Assert.That(this.productStock[3].Label, Is.EqualTo("5"));
        }

        [Test]
        public void RemoveShouldReturnFalseWhenProductIsNotFound()
        {
            this.AddMultipleProductsInProductStock();

            var productNotInStock = new Product(ProductLabel, 10, 20);

            var result = this.productStock.Remove(productNotInStock);

            Assert.That(result, Is.False);
            Assert.That(this.productStock.Count, Is.EqualTo(5));
        }

        [Test]
        public void ContainsShouldReturnTrueWhenProductExists()
        {
            this.productStock.Add(this.product);

            var result = this.productStock.Contains(this.product);

            Assert.That(result, Is.True);
        }

        [Test]
        public void ContainsShouldReturnFalseWhenProductDoesNotExists()
        {
            var result = this.productStock.Contains(this.product);

            Assert.That(result, Is.False);
        }

        [Test]
        public void ContainsShouldThrowExceptionWhenProductIsNull()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.productStock.Contains(null);
            }, $"Product cannot be null");
        }

        [Test]
        public void CountShouldReturnCorrectProductCount()
        {
            this.productStock.Add(this.product);
            this.productStock.Add(this.anotherProduct);

            var result = this.productStock.Count;

            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void FindShouldReturnCorrectProductByIndex()
        {
            this.productStock.Add(this.product);
            this.productStock.Add(this.anotherProduct);

            var productInStock = this.productStock.Find(1);

            Assert.That(productInStock, Is.Not.Null);
            Assert.That(productInStock.Label, Is.EqualTo(AnotherProductLabel));
            Assert.That(productInStock.Price, Is.EqualTo(20));
            Assert.That(productInStock.Quantity, Is.EqualTo(5));
        }

        [Test]
        public void FindShouldThrowExceptionWhenIndexIsOutOfRange()
        {
            this.productStock.Add(this.product);

            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                this.productStock.Find(1);
            }, $"Product index does not exist.");
        }

        [Test]
        public void FindShouldThrowExceptionWhenIndexIsBelowZero()
        {
            this.productStock.Add(this.product);

            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                this.productStock.Find(-1);
            }, $"Product index does not exist.");
        }

        [Test]
        public void FindByLabelShouldThrowExceptionWhenLabelIsNull()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.productStock.FindByLabel(null);
            }, $"Product label cannot be null");
        }

        [Test]
        public void FindByLabelShouldReturnCorrectProduct()
        {
            this.productStock.Add(this.product);
            this.productStock.Add(this.anotherProduct);

            var productInStock = this.productStock.FindByLabel(ProductLabel);

            Assert.That(productInStock, Is.Not.Null);
            Assert.That(productInStock.Label, Is.EqualTo(ProductLabel));
            Assert.That(productInStock.Price, Is.EqualTo(10));
            Assert.That(productInStock.Quantity, Is.EqualTo(1));
        }

        [Test]
        public void FindAllInPriceRangeShouldReturnEmptyCollectionWhenNoProductMatch()
        {
            this.AddMultipleProductsInProductStock();

            var result = this.productStock.FindAllInRange(30, 50);

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void FindAllInPriceRangeShouldReturnCorrectCollectionWithCorrectOrder()
        {
            this.AddMultipleProductsInProductStock();

            var result = this.productStock.FindAllInRange(4, 21).ToList();

            Assert.That(result.Count(), Is.EqualTo(3));

            Assert.That(result[0].Price, Is.EqualTo(20));
            Assert.That(result[1].Price, Is.EqualTo(10));
            Assert.That(result[2].Price, Is.EqualTo(5));
        }

        [Test]
        public void FindAllByPriceShouldReturnEmptyCollectionWhenNoProductMatch()
        {
            this.AddMultipleProductsInProductStock();

            var result = this.productStock.FindAllByPrice(30);

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void FindMostExpensiveProductsShouldReturnCorrectProduct()
        {
            this.AddMultipleProductsInProductStock();

            var productInStock = this.productStock.FindMostExpensiveProduct();

            Assert.That(productStock, Is.Not.Null);
            Assert.That(productInStock.Label, Is.EqualTo("4"));
            Assert.That(productInStock.Price, Is.EqualTo(400));
            Assert.That(productInStock.Quantity, Is.EqualTo(4));
        }

        [Test]
        public void FindMostExpensiveProductsShouldThrowExceptionWhenProductStockIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.productStock.FindMostExpensiveProduct();
            }, $"Product stock is empty");
        }

        [Test]
        public void FindAllByPriceShouldReturnCorrectCollection()
        {
            this.AddMultipleProductsInProductStock();

            var result = this.productStock.FindAllByPrice(400).ToList();

            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result[0].Label, Is.EqualTo("4"));
            Assert.That(result[1].Label, Is.EqualTo("5"));
        }

        [Test]
        public void FindAllByQuantityShouldReturnEmptyCollectionWhenNoProductMatch()
        {
            this.AddMultipleProductsInProductStock();

            var result = this.productStock.FindAllByQuantity(6);

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void FindAllByQuantityShouldReturnCorrectCollection()
        {
            this.AddMultipleProductsInProductStock();

            var result = this.productStock.FindAllByQuantity(5).ToList();

            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0].Label, Is.EqualTo("5"));
        }

        [Test]
        public void GetEnumeratorShouldReturnCorrectInsertionOrder()
        {
            this.AddMultipleProductsInProductStock();

            var result = this.productStock.ToList();

            Assert.That(result[0].Label, Is.EqualTo("1"));
            Assert.That(result[1].Label, Is.EqualTo("2"));
            Assert.That(result[2].Label, Is.EqualTo("3"));
            Assert.That(result[3].Label, Is.EqualTo("4"));
            Assert.That(result[4].Label, Is.EqualTo("5"));
        }

        [Test]
        public void GetIndexShouldReturnCorrectProductByIndex()
        {
            this.productStock.Add(this.product);
            this.productStock.Add(this.anotherProduct);

            var productInStock = this.productStock[1];

            Assert.That(productInStock, Is.Not.Null);
            Assert.That(productInStock.Label, Is.EqualTo(AnotherProductLabel));
            Assert.That(productInStock.Price, Is.EqualTo(20));
            Assert.That(productInStock.Quantity, Is.EqualTo(5));
        }

        [Test]
        public void GetIndexShouldThrowExceptionWhenIndexIsOutOfRange()
        {
            this.productStock.Add(this.product);

           Assert.That(() =>
                   this.productStock[1],
               Throws.Exception.InstanceOf<IndexOutOfRangeException>().With.Message
                   .EqualTo($"Product index does not exist."));
        }

        [Test]
        public void GetIndexShouldThrowExceptionWhenIndexIsBelowZero()
        {
            this.productStock.Add(this.product);

            Assert.That(() =>
                    this.productStock[-1],
                Throws.Exception.InstanceOf<IndexOutOfRangeException>().With.Message
                    .EqualTo($"Product index does not exist."));
        }

        [Test]
        public void SetIndexShouldChangeProduct()
        {
            const string productLabel = "Yet Another Test";

            this.AddMultipleProductsInProductStock();

            this.productStock[3] = new Product(productLabel, 50, 3);

            var productInStock = this.productStock.Find(3);

            Assert.That(productInStock, Is.Not.Null);
            Assert.That(productInStock.Label, Is.EqualTo(productLabel));
            Assert.That(productInStock.Price, Is.EqualTo(50));
            Assert.That(productInStock.Quantity, Is.EqualTo(3));
        }

        [Test]
        public void SetIndexShouldThrowExceptionWhenIndexIsOutOfRange()
        {
            this.productStock.Add(this.product);

            Assert.That(() =>
                    this.productStock[1] = new Product(ProductLabel, 10, 10),
                Throws.Exception.InstanceOf<IndexOutOfRangeException>().With.Message
                    .EqualTo($"Product index does not exist."));
        }

        [Test]
        public void SetIndexShouldThrowExceptionWhenIndexIsBelowZero()
        {
            this.productStock.Add(this.product);

            Assert.That(() =>
                    this.productStock[-1] = new Product(ProductLabel, 10, 10),
                Throws.Exception.InstanceOf<IndexOutOfRangeException>().With.Message
                    .EqualTo($"Product index does not exist."));
        }

        private void AddMultipleProductsInProductStock()
        {
            this.productStock.Add(new Product("1", 10, 1));
            this.productStock.Add(new Product("2", 5, 2));
            this.productStock.Add(new Product("3", 20, 3));
            this.productStock.Add(new Product("4", 400, 4));
            this.productStock.Add(new Product("5", 400, 5));
        }
    }
}