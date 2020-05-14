using System.Collections.Generic;
using NUnit.Framework;

namespace Presents.Tests
{
    using System;

    public class PresentsTests
    {
        private List<Present> presents;
        private Bag bag;
        private Present present;

        [SetUp]
        public void SetUp()
        {
            this.presents = new List<Present>();
            this.bag = new Bag();
            this.present = new Present("somePresent", 5.5);
        }

        [Test]
        public void PresentConstructorShouldWorkCorrectly()
        {
            var expName = "somePresent";
            var expMag = 5.5;

            Assert.AreEqual(expName, this.present.Name);
            Assert.AreEqual(expMag, this.present.Magic);
        }

        [Test]
        public void BagConstructorShouldWorkCorrectly()
        {
            Assert.IsNotNull(this.bag.GetPresents());
        }

        [Test]
        public void CreateShouldThrowExceptionWhenPresentNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.bag.Create(null);
            });
        }

        [Test]
        public void CreateShoulThrowExceptionWhenPresentExists()
        {
            this.bag.Create(present);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.bag.Create(present);
            });
        }

        [Test]
        public void CreateShouldAddPresent()
        {
            var secondPresent = new Present("secondName", 200);

            this.bag.Create(present);
            this.bag.Create(secondPresent);

            IReadOnlyCollection<Present> expexted = new List<Present>()
            {
                present, secondPresent
            };

            IReadOnlyCollection<Present> actual = this.bag.GetPresents();

            CollectionAssert.AreEqual(expexted, actual);
        }

        [Test]
        public void CreateShouldReturnCorrectMessage()
        {
            var expected = $"Successfully added present {present.Name}.";
            var result = this.bag.Create(present);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void RemoveShouldWork()
        {
            var secondPresent = new Present("secondName", 200);

            this.bag.Create(present);
            this.bag.Create(secondPresent);

            var result = this.bag.Remove(present);

            IReadOnlyCollection<Present> expexted = new List<Present>()
            {
                secondPresent
            };

            IReadOnlyCollection<Present> actual = this.bag.GetPresents();

            Assert.IsTrue(result);
            CollectionAssert.AreEqual(expexted, actual);
        }

        [Test]
        public void RemoveShouldNotWork()
        {
            var result = this.bag.Remove(present);

            Assert.IsFalse(result);
        }

        [Test]
        public void GetPresentWithLeastMagicShouldWork()
        {
            var secondPresent = new Present("asd", 100);

            var expected = new Present("asd", 3);

            this.bag.Create(present);
            this.bag.Create(secondPresent);
            this.bag.Create(expected);

            var actual = this.bag.GetPresentWithLeastMagic();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetPresentWithLeastMagicShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.bag.GetPresentWithLeastMagic();
            });
        }

        [Test]
        public void GetPresentShouldReturnCorrectPresentWhenNoDuplicates()
        {
            var expectedName = "Stick";

            var expected = new Present(expectedName, 100);
            var secondPresent = new Present("anotherPresent", 50);

            this.bag.Create(expected);
            this.bag.Create(secondPresent);

            var actual = this.bag.GetPresent(expectedName);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetPresentShouldReturnCorrectPresentWhenDuplicates()
        {
            var secondPresent = new Present("anotherPresent", 50);

            this.bag.Create(present);
            this.bag.Create(secondPresent);

            var actual = this.bag.GetPresent(this.present.Name);

            Assert.AreEqual(present, actual);
        }

        [Test]
        public void GetPresentShouldReturnNullWhenNameExists()
        {
            var secondPresent = new Present("anotherPresent", 50);

            this.bag.Create(present);
            this.bag.Create(secondPresent);

            var invalidName = "Non Existing name";

            var actual = this.bag.GetPresent(invalidName);

            Assert.IsNull(actual);
        }
    }
}
