using System;
using System.Collections.Generic;
using NUnit.Framework.Internal;

namespace Telecom.Tests
{
    using NUnit.Framework;

    public class Tests
    { 
        private const string make = "Samsung";
        private const string model = "S10+";

        private Phone phone;

        [SetUp]
        public void SetUp()
        {
            this.phone = new Phone(make, model);
        }

            [Test]
        public void ConstructorShouldWokrCorrectly()
        {
            Assert.AreEqual(make, this.phone.Make);

            Assert.AreEqual(model, this.phone.Model);
        }

        [Test]
        public void TestWithLikeEmptyMake()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Phone phone = new Phone(string.Empty, model);
            });
        }

        [Test]
        public void TestWithlikeEmptyModel()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Phone phone = new Phone(make, string.Empty);
            });
        }

        [Test]
        public void InitialCountShouldBeZero()
        {
            var expectedCount = 0;

            Assert.AreEqual(expectedCount, this.phone.Count);
        }

        [Test]
        public void TestIfAddWorksCorrectly()
        {
            var expectedCount = 2;

            this.phone.AddContact("Pesho", "+3598889999");

            this.phone.AddContact("Gosho", "+3598888888");

            Assert.AreEqual(expectedCount, this.phone.Count);
        }

        [Test]
        public void TestIfAddThrowsException()
        {
            this.phone.AddContact("Pesho", "+3598889999");

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.phone.AddContact("Pesho", "+3598888888");
            });
        }

        [Test]
        public void TestIfCallThrowsException()
        {
            this.phone.AddContact("Pesho", "+3598889999");

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.phone.Call("Gosho");
            });
        }

        [Test]
        public void TestIfCallWorksCorrectly()
        {
            var name = "Pesho";
            var number = $"3598889999";

            var expected = $"Calling {name} - {number}...";

            this.phone.AddContact(name, number);

            var actual = this.phone.Call(name);

            Assert.AreEqual(expected, actual);
        }
    }
}
