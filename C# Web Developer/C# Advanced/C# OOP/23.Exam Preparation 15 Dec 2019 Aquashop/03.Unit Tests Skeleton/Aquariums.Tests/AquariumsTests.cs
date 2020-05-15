using NUnit.Framework;

namespace Aquariums.Tests
{
    using System;

    [TestFixture]
    public class AquariumsTests
    {
        [Test]
        public void ConstructorShouldWorkCorrectly()
        {
            var expectedName = "Strange";
            var expectedCapacity = 10;

            Aquarium aquarium = new Aquarium(expectedName, expectedCapacity);

            var actualName = aquarium.Name;
            var actualCapacity = aquarium.Capacity;

            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedCapacity, actualCapacity);
        }

        [Test]
        public void SetNameShouldThrowExceptionWhenIsNullOrEmpty()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new Aquarium(null, 10);
            });
            
            Assert.Throws<ArgumentNullException>(() =>
            {
                new Aquarium(string.Empty, 10);
            });
        }

        [Test]
        public void SetCapacityShouldThrowExceptionWhenBelowZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Aquarium("Strange", -10);
            });
        }


        [Test]
        public void AddFishShouldWorkCorrectly()
        {
            var fish = new Fish("Nemo");
            var aquarium = new Aquarium("Strange", 10);

            aquarium.Add(fish);

            var expectedCount = 1;

            Assert.AreEqual(expectedCount, aquarium.Count);
        }

        [Test]
        public void AddFishShouldThrowExceptionWhenInvalidCapacity()
        {
            var fish = new Fish("Nemo");
            var aquarium = new Aquarium("Strange", 0);

            Assert.Throws<InvalidOperationException>(() => aquarium.Add(fish));
        }

        [Test]
        public void RemoveFishShouldWorkCorrectly()
        {
            var fish = new Fish("Nemo");
            var aquarium = new Aquarium("Strange", 10);

            aquarium.Add(fish);
            aquarium.RemoveFish("Nemo");

            var expectedCount = 0;

            Assert.AreEqual(expectedCount, aquarium.Count);
        }

        [Test]
        public void RemoveFishShouldThrowExceptionWhenNameNotFound()
        {
            var aquarium = new Aquarium("Strange", 10);

            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.RemoveFish("None");
            });
        }

        [Test]
        public void SellFishShouldSetAvailablePropertyToFalse()
        {
            var fish = new Fish("Nemo");
            var aquarium = new Aquarium("Strange", 10);

            aquarium.Add(fish);
            var soldFish = aquarium.SellFish("Nemo");

            var expectedAvailability = false;

            Assert.AreEqual(expectedAvailability, soldFish.Available);
        }

        [Test]
        public void SellFishShouldThrowExceptionWhenNameNotFound()
        {
            var aquarium = new Aquarium("Strange", 0);

            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.SellFish("None");
            });
        }

        [Test]
        public void ValidateReportMessage()
        {
            var fish = new Fish("Nemo");
            var fish2 = new Fish("Nemo2");

            var aquarium = new Aquarium("Strange", 10);

            aquarium.Add(fish);
            aquarium.Add(fish2);

            var expectedResult = $"Fish available at Strange: Nemo, Nemo2";
            var actualResult = aquarium.Report();

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
