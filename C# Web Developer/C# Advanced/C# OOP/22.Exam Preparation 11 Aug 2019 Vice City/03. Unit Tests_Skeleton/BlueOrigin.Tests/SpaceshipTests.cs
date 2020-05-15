namespace BlueOrigin.Tests
{
    using System;
    using NUnit.Framework;

    public class SpaceshipTests
    {
        [Test]
        public void Count_Should_Return_Correct_Result()
        {
            Spaceship spaceship = new Spaceship("Name One", 10);

            Assert.AreEqual(0, spaceship.Count);
        }

        [Test]
        public void Name_Should_Return_Correct_Result()
        {
            Spaceship spaceship = new Spaceship("Name One", 10);

            Assert.AreEqual("Name One", spaceship.Name);
        }
        
        [Test]
        public void Name_Should_Throw_Exception()
        {
            Assert.Throws<ArgumentNullException>(() => new Spaceship(null, 10));
        }

        [Test]
        public void Capacity_Should_Return_Correct_Result()
        {
            Spaceship spaceship = new Spaceship("Name One", 10);

            Assert.AreEqual(10, spaceship.Capacity);
        }

        [Test]
        public void Capacity_Less_Than_Zeto_Should_Throw_Exception()
        {
            Assert.Throws<ArgumentException>(() => new Spaceship("Name One", -1));
        }

        [Test]
        public void AddMethod_Without_Capacity_Should_Throw_Exception()
        {
            Spaceship spaceship = new Spaceship("Name One", 1);
            spaceship.Add(new Astronaut("Name One", 10));
            

            Assert.Throws<InvalidOperationException>(() => spaceship.Add(new Astronaut("Name Two", 10)));
        }

        [Test]
        public void AddMethod_Already_Existing_Astronaut_Should_Throw_Exception()
        {
            Spaceship spaceship = new Spaceship("Name One", 10);
            spaceship.Add(new Astronaut("Name One", 10));


            Assert.Throws<InvalidOperationException>(() => spaceship.Add(new Astronaut("Name One", 10)));
        }

        [Test]
        public void AddMethod_Should_Successfully_Add_Astronaut()
        {
            Spaceship spaceship = new Spaceship("Name One", 10);
            spaceship.Add(new Astronaut("Name One", 10));


            Assert.AreEqual(1, spaceship.Count);
        }

        [Test]
        public void Remove_With_Invalid_Name_Should_Return_False()
        {
            Spaceship spaceship = new Spaceship("Name One", 10);
            spaceship.Add(new Astronaut("Name One", 10));

            Assert.False(spaceship.Remove("Name Two"));
        }

        [Test]
        public void Remove_With_Valid_Name_Should_Return_True()
        {
            Spaceship spaceship = new Spaceship("Name One", 10);
            spaceship.Add(new Astronaut("Name One", 10));

            Assert.True(spaceship.Remove("Name One"));
        }

        [Test]
        public void Remove_With_Valid_Name_Should_Successfully_Remove_Astronaut()
        {
            Spaceship spaceship = new Spaceship("Name One", 10);
            spaceship.Add(new Astronaut("Name One", 10));
            spaceship.Remove("Name One");

            Assert.AreEqual(0, spaceship.Count);
        }
    }
}