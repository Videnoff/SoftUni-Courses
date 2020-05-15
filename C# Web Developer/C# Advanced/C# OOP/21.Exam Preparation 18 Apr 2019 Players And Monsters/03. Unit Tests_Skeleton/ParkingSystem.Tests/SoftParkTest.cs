using System;

namespace ParkingSystem.Tests
{
    using NUnit.Framework;

    public class SoftParkTest
    {
        private SoftPark softPark;

        [SetUp]
        public void Setup()
        {
            this.softPark = new SoftPark();
        }

        [Test]
        public void ConstructorShouldInitialize()
        {
            SoftPark softPark = new SoftPark();

            Assert.AreEqual(softPark.Parking.Count, 12);
        }

        [Test]
        public void ParkingDoesntContainParkSpotShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.softPark.ParkCar("D1", new Car("", ""));
            });
        }

        [Test]
        public void ParkingOnTakenPlaceShouldThrowException()
        {
            this.softPark.ParkCar("A1", new Car("BMW", "ABC132"));

            Assert.Throws<ArgumentException>(() =>
            {
                this.softPark.ParkCar("A1", new Car("Audi", "DEF456"));
            });
        }

        [Test]
        public void CarAlreadyParkedShouldThrowException()
        {
            var car = new Car("BMW", "ABC123");

            this.softPark.ParkCar("A1", car);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.softPark.ParkCar("B1", car);
            });
        }

        [Test]
        public void CarParkedSuccessfully()
        {
            var regNumber = "ABC123";
            var car = new Car("VW", regNumber);

            var actual = this.softPark.ParkCar("A1", car);
            var expected = $"Car:{car.RegistrationNumber} parked successfully!";

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void ParkingDoesntContainParkSpotShouldThrowExceptionWhenRemove()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.softPark.RemoveCar("D1", new Car("", ""));
            });
        }

        [Test]
        public void CarOnSpotDoesntExistShouldThrowExceptionWhenRemove()
        {
            var car = new Car("VW", "ASD789");
            this.softPark.ParkCar("A2", car);

            Assert.Throws<ArgumentException>(() =>
            {
                this.softPark.RemoveCar("B1", car);
            });
        }

        [Test]
        public void CarRemovedSuccessfully()
        {
            var regNumber = "ABC123";
            var car = new Car("VW", regNumber);

            softPark.ParkCar("A1", car);

            var actual = this.softPark.RemoveCar("A1", car);
            var expected = $"Remove car:{regNumber} successfully!";

            Assert.AreEqual(actual, expected);

            Assert.AreEqual(softPark.Parking["A1"], null);
        }
    }
}
