using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry raceEntry;
        private UnitRider rider;

        [SetUp]
        public void Setup()
        {
            this.raceEntry = new RaceEntry();
            this.rider = new UnitRider("Pesho", new UnitMotorcycle("Kawasaki", 150, 175));
        }

        [Test]
        public void AddRiderShouldCorrectly()
        {
            raceEntry = new RaceEntry();
            var unitMotorcycle = new UnitMotorcycle("asd", 50, 25);
            var thirdRider = new UnitRider("Stamat", unitMotorcycle);

            var actualMessage = raceEntry.AddRider(thirdRider);

            var expectedMessage = $"Rider Stamat added in race.";

            Assert.AreEqual(expectedMessage, actualMessage);
            Assert.AreEqual(raceEntry.Counter, 1);
        }

        [Test]
        public void ConstructorShouldWorkCorrectly()
        {
            raceEntry = new RaceEntry();

            Assert.AreEqual(0, raceEntry.Counter);
        }

        [Test]
        public void AddShouldThrowExceptionWhenRiderNull()
        {
            UnitRider secondRider = null;

            Assert.Throws<InvalidOperationException>(() =>
            {
                raceEntry.AddRider(secondRider);
            });
        }

        [Test]
        public void AddShouldThrowExceptionWhenExistingRider()
        {
            var secondRider = new UnitRider("Pesho", new UnitMotorcycle("BMW", 100, 75));

            raceEntry.AddRider(rider);

            Assert.Throws<InvalidOperationException>(() =>
            {
                raceEntry.AddRider(secondRider);
            });
        }

        [Test]
        public void CalculateHPShouldThrowExceptionWhenRidersMin()
        {
            raceEntry.AddRider(rider);

            Assert.Throws<InvalidOperationException>(() =>
            {
                raceEntry.CalculateAverageHorsePower();
            });
        }


        [Test]
        public void CalculateAverageHPShouldWorkCorrectly()
        {
            var secondRider = new UnitRider("Gosho", new UnitMotorcycle("Honda", 70, 50));

            var thirdRider = new UnitRider("Kolyo", new UnitMotorcycle("Yamaha", 80, 90));

            raceEntry.AddRider(rider);
            raceEntry.AddRider(secondRider);
            raceEntry.AddRider(thirdRider);
            
            var result = raceEntry.CalculateAverageHorsePower();
            var expected = 100;

            Assert.AreEqual(result, expected);

        }
    }
}
