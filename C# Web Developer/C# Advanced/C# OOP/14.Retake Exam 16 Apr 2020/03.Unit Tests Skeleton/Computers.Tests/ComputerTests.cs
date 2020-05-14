using System;
using System.Collections.Generic;

namespace Computers.Tests
{
    using NUnit.Framework;

    public class ComputerTests
    {
        private List<Part> parts;
        private string name;
        private Computer computer;
        private Part part;

        [SetUp]
        public void Setup()
        {
            this.parts = new List<Part>();
            this.computer = new Computer("asd");
            this.part = new Part("somePart", 5);

        }

        [Test]
        public void ConstructorShouldWork()
        {
            var computer = new Computer("someComputer");

            Assert.AreEqual(computer.Name, "someComputer");
        }

        [Test]
        public void NameShouldThrowExceptionWhenNullOrWhiteSpace()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                computer = new Computer(null);
            });
        }

        [Test]
        public void NameShouldWork()
        {
            computer = new Computer("Pesho");
        }

        [Test]
        public void AddPartShouldThrowExceptionWhenNull()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                computer.AddPart(null);
            });
        }

        [Test]
        public void AddPartShouldWork()
        {
            this.computer.AddPart(this.part);
        }

        [Test]
        public void RemovePartShouldWork()
        {
            computer.AddPart(part);
            Assert.True(computer.RemovePart(part));
        }

        [Test]
        public void RemovePartShouldNotWork()
        {
            computer.AddPart(new Part("otherPart", 9));
            Assert.False(computer.RemovePart(part));
        }

        [Test]
        public void GetPartShouldWork()
        {
            computer.AddPart(part);
            Assert.NotNull(computer.GetPart("somePart"));
        }

        [Test]
        public void GetPartShouldNotWork()
        {
            computer.AddPart(new Part("otherPart", 9));
            Assert.Null(computer.GetPart("somePart"));
        }

        [Test]
        public void TotalPriceShouldWork()
        {
            var expected = 0;
            var actual = this.computer.TotalPrice;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TotalPriceShouldNotWork()
        {
            var expected = 100;
            var actual = this.computer.TotalPrice;

            Assert.AreNotEqual(expected, actual);
        }
    }
}
