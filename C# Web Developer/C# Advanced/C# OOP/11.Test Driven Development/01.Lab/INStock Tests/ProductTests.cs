using System;

namespace INStock.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class ProductTests
    {
        [Test]
        public void LabelCannotBeNull()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var product = new Product(null, 10, 5);
            }, "Label cannot be null or empty");
        }

        [Test]
        public void LabelCannotBeEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var product = new Product("Test", -10, 5);
            }, "Price cannot be less than zero.");
        }

        [Test]
        public void PriceCannotBeLessThanZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var product = new Product(string.Empty, 10, 5);
            }, "Label cannot be null or empty");
        }

        [Test]
        public void QuantityCannotBeLessThanZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var product = new Product("Test Product Label", 10, -1);
            }, "Quantity cannot be less than zero.");
        }

        [Test]
        public void ProductShouldBeComparedByPriceWhenOrderIsCorrect()
        {
            var firstProduct = new Product("Test 1", 10, 1);
            var secondProduct = new Product("Test 2", 5, 1);

            var correctOrderResult = secondProduct.CompareTo(firstProduct);

            Assert.That(correctOrderResult < 0, Is.True);
        }
        
        [Test]
        public void ProductShouldBeComparedByPriceWhenOrderIsIncorrect()
        {
            var firstProduct = new Product("Test 1", 10, 1);
            var secondProduct = new Product("Test 2", 5, 1);

            var incorrectOrderResult = firstProduct.CompareTo(secondProduct);

            Assert.That(incorrectOrderResult > 0, Is.True);
        }

        [Test]
        public void ProductShouldBeComparedByPriceWhenOrderIsEqual()
        {
            var firstProduct = new Product("Test 1", 10, 1);
            var secondProduct = new Product("Test 2", 10, 1);

            var incorrectOrderResult = firstProduct.CompareTo(secondProduct);

            Assert.That(incorrectOrderResult == 0, Is.True);
        }
    }
}
