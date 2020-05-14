using System.Collections.Generic;
using System.Diagnostics.Contracts;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Robots.Tests
{
    using System;

    public class RobotsTests
    {
        private List<Robot> robots;
        private Robot robot;
        private RobotManager robotManager;

        [SetUp]
        public void SetUp()
        {
            this.robots = new List<Robot>();
            this.robot = new Robot("Pesho", 99);
            this.robotManager = new RobotManager(2);
            this.robot.Battery = 50;
        }

        [Test]
        public void BatteryWorksCorrectly()
        {
            var battery = robot.MaximumBattery;

            var expected = 99;
            var actual = this.robot.MaximumBattery;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AddShouldThrowExceptionWhenNameExists()
        {
            this.robotManager.Add(this.robot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                 robotManager.Add(new Robot("Pesho", 50));   
            });
        }

        [Test]
        public void AddShouldWorkCorrectly()
        {
            this.robotManager.Add(this.robot);

        }

        [Test]
        public void AddShouldThrowExceptionWhenCountEqualsCapacity()
        {
            var secondRobot = new Robot("Gosho", 25);
            var thirdRobot = new Robot("Stamat", 35);

            this.robotManager.Add(this.robot);
            this.robotManager.Add(secondRobot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Add(thirdRobot);
            });
        }

        [Test]
        public void ChargeShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Charge(null);
            });
        }

        [Test]
        public void ChargeShouldWorkCorrectly()
        {
            
        }

        [Test]
        public void InitialCountShouldBeZero()
        {
            var expectedCount = 0;

            Assert.AreEqual(expectedCount, robots.Count);
        }

        [Test]
        public void CountShouldWorkCorrectly()
        {
            this.robotManager.Add(this.robot);

            var expected = 1;

            Assert.AreEqual(expected, this.robotManager.Count);
        }

        [Test]
        public void CapacityShouldWorkCorrectly()
        {
            this.robotManager = new RobotManager(2);
        }

        [Test]
        public void RemoveShouldThrowExceptionWhenNull()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Remove(null);
            });
        }

        [Test]
        public void RemoveWorks()
        {
            this.robotManager.Add(robot);

            this.robotManager.Remove("Pesho");
        }

        [Test]
        public void WorkShouldThrowExceptionWhenNull()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Work(null, "asd", 99);
            });
        }

        [Test]
        public void WorkShouldThrowExceptionWhenBatteryLess()
        {
            var robotToWork = new Robot("Sasho", 90);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Work(nameof(this.robot), "nikakva", 150);
            });
        }

        [Test]
        public void WorkShouldWorkCorrectly()
        {
            
        }

        [Test]
        public void ConstructorShouldWorkCorrectly()
        {
            var expectedCapacity = 10;
            var robotManager = new RobotManager(expectedCapacity);

            var actual = robotManager.Capacity;

            Assert.AreEqual(expectedCapacity, actual);

        }

        [Test]
        public void Constructor()
        {
            var data = new List<Robot>();

            Assert.IsNotNull(data);
        }

        [Test]
        public void CapacityShouldThrowExceptionWhenBelowZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new RobotManager(-10);
            });
        }
    }
}
