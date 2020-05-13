using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using ExtendedDatabase;

public class PersonDatabaseTests
{
    public Person pesho;
    public Person gosho;

    [SetUp]
    public void TestInit()
    {
        pesho = new Person(114560, "Pesho");
        gosho = new Person(447788556699, "Gosho");
    }

    [Test]
    public void ConstructorShoudInitializeCollection()
    {
        var expected = new Person[] { pesho, gosho };
        var db = new ExtendedDatabase.ExtendedDatabase(expected);

        var actual = expected;

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void CountShouldWorkCorrectly()
    {
        var expectedCount = 3;

        var persons = new Person[] { pesho, gosho };
        var db = new ExtendedDatabase.ExtendedDatabase(persons);

        var newPerson = new Person(554466, "Stamat");

        db.Add(newPerson);

        var actualCount = db.Count;

        Assert.AreEqual(expectedCount, actualCount);
    }

    [Test]
    [TestCase(17)]
    [TestCase(18)]
    [TestCase(22)]
    [TestCase(555)]
    [TestCase(100)]
    [TestCase(1000)]
    public void AddBiggerCollectionShouldThrow(int count)
    {
        var persons = new Person[count];

        Assert.Throws<ArgumentException>(() =>
        {
            var extendedDatabase = new ExtendedDatabase.ExtendedDatabase(persons);
        });
    }

    [Test]
    [TestCase(16)]
    public void AddWhenCountIs16ShouldThrow(int count)
    {
        var persons = new Person[count];
        for (int i = 0; i < persons.Length; i++)
        {
            persons[i] = new Person(i, "Ivan" + i);
        }

        var db = new ExtendedDatabase.ExtendedDatabase(persons);

        Assert.Throws<InvalidOperationException>(() =>
        {
            db.Add(new Person(554466, "Stamat"));
        });
    }

    [Test]
    public void AddSameUsernameShouldThrow()
    {
        var persons = new Person[] { pesho, gosho };
        var db = new ExtendedDatabase.ExtendedDatabase(persons);
        var newPerson = new Person(554466, "Gosho");

        Assert.That(() => db.Add(newPerson), Throws.InvalidOperationException);
    }

    [Test]
    public void AddSameIdShouldThrow()
    {
        var persons = new Person[] { pesho, gosho };
        var db = new ExtendedDatabase.ExtendedDatabase(persons);
        var newPerson = new Person(114560, "Stamat");

        Assert.Throws<InvalidOperationException>(() =>
        {
            db.Add(newPerson);
        });
    }

    [Test]
    public void RemoveShouldRemove()
    {
        var persons = new Person[] { pesho, gosho };
        var db = new ExtendedDatabase.ExtendedDatabase(persons);

        db.Remove();
        db.Remove();

        Assert.Throws<InvalidOperationException>(() =>
        {
            db.Remove();
        });
    }

    [Test]
    public void FindByUsernameNullArgumentShouldThrow()
    {
        var persons = new Person[] { pesho, gosho };
        var db = new ExtendedDatabase.ExtendedDatabase(persons);

        Assert.Throws<ArgumentNullException>(() =>
        {
            db.FindByUsername(null);
        });
    }

    [Test]
    public void FindByUsernameNonExistingPersonShouldThrow()
    {
        var persons = new Person[] { pesho, gosho };
        var db = new ExtendedDatabase.ExtendedDatabase(persons);

        Assert.Throws<InvalidOperationException>(() =>
        {
            db.FindByUsername("Stamat");
        });
    }

    [Test]
    public void FindByUsernameExistingPersonShouldReturnPerson()
    {
        var persons = new Person[] { pesho, gosho };
        var db = new ExtendedDatabase.ExtendedDatabase(persons);

        var expected = pesho;
        var actual = db.FindByUsername("Pesho");

        Assert.AreEqual(actual, expected);
    }

    [Test]
    public void FindByIdExistingPersonShouldReturnPerson()
    {
        var persons = new Person[] { pesho, gosho };
        var db = new ExtendedDatabase.ExtendedDatabase(persons);

        var expected = pesho;
        var actual = db.FindById(114560);

        Assert.AreEqual(actual, expected);
    }

    [Test]
    public void FindByIdNonExistingPersonShouldThrow()
    {
        var persons = new Person[] { pesho, gosho };
        var db = new ExtendedDatabase.ExtendedDatabase(persons);

        Assert.Throws<InvalidOperationException>(() =>
        {
            db.FindById(5);
        });
    }

    [Test]
    public void FindByUsernameNegativeArgumentShouldThrow()
    {
        var persons = new Person[] { pesho, gosho };
        var db = new ExtendedDatabase.ExtendedDatabase(persons);

        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            db.FindById(-1);
        });
    }
}