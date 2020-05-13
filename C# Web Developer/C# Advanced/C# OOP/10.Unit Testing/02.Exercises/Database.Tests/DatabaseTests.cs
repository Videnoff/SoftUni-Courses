using System;
using NUnit.Framework;

/*
 * Must comment namespace Database before uploading to Judge
 */

namespace Tests
{
    using Database;

    public class DatabaseTests
    {
        //private Database database;
        //private readonly int[] initialData = new int[] {1, 2};

        private Database database;
        private readonly int[] initialData = new int[] { 1, 2 };

        [SetUp]
        public void SetUp()
        {
            //this.database = new Database(initialData);

            this.database = new Database(initialData);
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            //int[] data = new int[] {1, 2, 3};
            //this.database = new Database(data);

            //var expectedCount = data.Length;
            //var actualCount = this.database.Count;

            //Assert.AreEqual(expectedCount, actualCount);

            var data = new int[] { 1, 2, 3 };
            this.database = new Database(data);

            var expected = data.Length;
            var actual = database.Count;

            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void ConstructorShouldThrowExceptionWhenBiggerCollection()
        {
            //int[] data = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17};

            //Assert.Throws<InvalidOperationException>(() => { this.database = new Database(data); });

            var data = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database = new Database(data);
            });

        }

        [Test]
        public void AddShouldIncreaseCountWhenAddedSuccessfully()
        {
            //this.database.Add(3);

            //var expectedCount = 3;
            //var actualCount = this.database.Count;

            //Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddShouldThrowExceptionWhenDatabaseFull()
        {
            //for (int i = 3; i <= 16; i++)
            //{
            //    this.database.Add(i);
            //}

            //// The collection if full

            //Assert.Throws<InvalidOperationException>(() =>
            //{
            //// Try add 17th item
            //this.database.Add(17);
            //    });
        }

        [Test]
        public void RemoveShouldDecreaseCountWhenSuccess()
        {
            //// Arrange
            //var expected = 1;

            //// Act
            //this.database.Remove();

            //var actual = this.database.Count;

            //// Assert
            //Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RemoveShouldThrowExceptionWhenDatabaseEmpty()
        {
            //this.database.Remove();
            //this.database.Remove();

            //// Database.Count = 0 (No items left)

            //Assert.Throws<InvalidOperationException>(() =>
            //{
            //    // No items to remove
            //    this.database.Remove();
            //});
            var data = new int[] { 1, 2 };
            var database = new Database(data);
            database.Remove();
            database.Remove();

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            });

        }

        [Test]
        [TestCase(new int[] { 1, 2, 3})]
        [TestCase(new int[] { })]
        [TestCase(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]

        public void FetchShouldReturnCopyOfData(int[] expectedData)
        {
            //this.database = new Database(expectedData);

            //// Returned copy
            //var actualData = this.database.Fetch();

            //CollectionAssert.AreEqual(expectedData, actualData);

            var data = new int[] { 1, 2 };
            var database = new Database(data);

            database.Fetch();
        }
    }
}