using System;
using CarManager;
using NUnit.Framework;

/*
 * Must comment namespace CarManager before uploading to Judge
 */

namespace Tests
{

    using CarManager;

    public class CarTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorShouldInitializeCorrectly()
        {
            //string make = "VW";
            //string model = "Golf";
            //double fuelConsumption = 2;
            //double fuelCapacity = 100;

            //Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            //Assert.AreEqual(make, car.Make);
            //Assert.AreEqual(model, car.Model);
            //Assert.AreEqual(fuelConsumption, car.FuelConsumption);
            //Assert.AreEqual(fuelCapacity, car.FuelCapacity);
            var make = "Mercedes";
            var model = "CLS";
            var fuelConsumption = 12;
            var fuelCapacity = 75;

            var car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.AreEqual(make, car.Make);
            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(fuelConsumption, car.FuelConsumption);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
        }

        [Test]
        public void ModelShouldThrowArgumentExceptionWhenNameIsNull()
        {
            // throw new ArgumentException("Make cannot be null or empty!");

            //string make = "VW";
            //string model = null;
            //double fuelConsumption = 2;
            //double fuelCapacity = 100;

            //Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));

            var make = "Mercedes";
            var model = string.Empty;
            var fuelConsumption = 12;
            var fuelCapacity = 75;

            Assert.Throws<ArgumentException>(() =>
            {
                var car = new Car(make, model, fuelConsumption, fuelCapacity);
            });
        }

        [Test]
        public void MakeShouldThrowArgumentExceptionWhenNameIsNull()
        {
            // throw new ArgumentException("Make cannot be null or empty!");

            //string make = null;
            //string model = "Golf";
            //double fuelConsumption = 2;
            //double fuelCapacity = 100;

            //Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));

            var make = string.Empty;
            var model = "CLS";
            var fuelConsumption = 12;
            var fuelCapacity = 75;

            Assert.Throws<ArgumentException>(() =>
            {
                var car = new Car(make, model, fuelConsumption, fuelCapacity);
            });


        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void FuelConsumptionShouldThrowArgumentExceptionWhenIsBellowZero(int fuelConsumption)
        {
            // throw new ArgumentException("Make cannot be null or empty!");

            //string make = "VW";
            //string model = "Golf";
            //double fuelConsumption = -10;
            //double fuelCapacity = 100;

            //Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));

            var make = "Mercedes";
            var model = "CLS";
            var fuelCapacity = 75;

            Assert.Throws<ArgumentException>(() =>
            {
                var car = new Car(make, model, fuelConsumption, fuelCapacity);
            });
        }

        [Test]
        public void FuelShouldThrowArgumentExceptionWhenIsZero()
        {
            // throw new ArgumentException("Make cannot be null or empty!");

            //string make = "VW";
            //string model = "Golf";
            //double fuelConsumption = 0;
            //double fuelCapacity = 100;

            //Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void FuelCapacityThrowArgumentExceptionWhenIsZero(int fuelCapacity)
        {
            // throw new ArgumentException("Make cannot be null or empty!");

            //string make = "VW";
            //string model = "Golf";
            //double fuelConsumption = 10;
            //double fuelCapacity = 0;

            //Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));

            var make = "Mercedes";
            var model = "CLS";
            var fuelConsumption = 15;

            Assert.Throws<ArgumentException>(() =>
            {
                var car = new Car(make, model, fuelConsumption, fuelCapacity);
            });
        }

        [Test]
        public void FuelCapacityThrowArgumentExceptionWhenIsBellowZero()
        {
            // throw new ArgumentException("Make cannot be null or empty!");

            //string make = "VW";
            //string model = "Golf";
            //double fuelConsumption = 10;
            //double fuelCapacity = -10;

            //Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        //[TestCase(null, "Golf", 10, 20)]
        //[TestCase("VW", null, 10, 20)]
        //[TestCase("VW", "Golf", -10, 20)]
        //[TestCase("VW", "Golf", 0, 20)]
        //[TestCase("VW", "Golf", 10, -20)]
        //[TestCase("VW", "Golf", 10, 0)]
        public void AllPropertiesShouldThrowArgumentExceptionOrInvalidValues(string make, string model,
            double fuelConsumption, double fuelCapacity)
        {
            //Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void ShouldRefuelNormally()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(10);

            double expectedFuelAmount = 10;
            double actualFuelAmount = car.FuelAmount;

            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }

        [Test]
        public void ShouldRefuelUntilTheTotalFuelCapacity()
        {
            //string make = "VW";
            //string model = "Golf";
            //double fuelConsumption = 2;
            //double fuelCapacity = 100;

            //Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            //car.Refuel(150);

            //double expectedFuelAmount = 100;
            //double actualFuelAmount = car.FuelAmount;

            //Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }

        [Test]
        [TestCase(-10)]
        [TestCase(0)]
        public void RefuelShouldThrowArgumentExceptionWhenInputAmountIsBellowZero(double inputAmount)
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.Throws<ArgumentException>(() => car.Refuel(inputAmount));
        }

        [Test]
        public void ShouldDriveNormally()
        {
            //string make = "VW";
            //string model = "Golf";
            //double fuelConsumption = 2;
            //double fuelCapacity = 100;

            //Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            //car.Refuel(20);
            //car.Drive(20);

            //double expectedFuelAmount = 19.6;
            //double actualFuelAmount = car.FuelAmount;

            //Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }

        [Test]
        public void DriveShouldInvalidOperationExceptionWhenFuelAmountIsNotEnough()
        {
            //string make = "VW";
            //string model = "Golf";
            //double fuelConsumption = 2;
            //double fuelCapacity = 100;

            //Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            //Assert.Throws<InvalidOperationException>(() => car.Drive(20));
        }

    }
}