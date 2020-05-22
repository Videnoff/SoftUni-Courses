using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

public class HeroRepositoryTests
{
    [Test]
    public void TestIfConstructorWorksCorrectly()
    {
        var data = new List<Hero>();

        Assert.IsNotNull(data);
    }

    [Test]
    public void CreateThrowsExceptionWhenHeroIsNull()
    {
        var heroRepository = new HeroRepository();

        Assert.Throws<ArgumentNullException>(() =>
        {
            heroRepository.Create(null);
        });
    }

    [Test]
    public void CreateThrowsExceptionWhenHeroNameExists()
    {
        var heroRepository = new HeroRepository();

        var hero = new Hero("Pesho", 1);
        heroRepository.Create(hero);

        var hero2 = new Hero("Pesho", 10);

        Assert.Throws<InvalidOperationException>(() =>
        {
            heroRepository.Create(hero2);
        });
    }

    [Test]
    public void CreateWorkCorrectly()
    {
        var heroRepository = new HeroRepository();

        var hero = new Hero("Pesho", 1);
        heroRepository.Create(hero);

        var expected = 1;
        var actual = heroRepository.Heroes.Count;

        Assert.AreEqual(expected, actual);
        Assert.That(heroRepository.Heroes.Contains(hero));
    }

    [Test]
    public void CreateAddWorkCorrectly()
    {
        var heroRepository = new HeroRepository();

        var hero = new Hero("Pesho", 1);
        heroRepository.Create(hero);

        var data = new List<Hero>();
        data.Add(hero);

        var expected = 1;
        var actual = data.Count;

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void CreateReturnsCorrectMessage()
    {
        var heroRepository = new HeroRepository();
        var hero = new Hero("Pesho", 1);

        var expected = $"Successfully added hero Pesho with level 1";
        var actual = heroRepository.Create(hero);

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void RemoveShouldWorkCorrectly()
    {
        var heroRepository = new HeroRepository();
        var hero = new Hero("Pesho", 9);

        heroRepository.Create(hero);
        heroRepository.Remove(hero.Name);

        var expected = 0;
        var actual = heroRepository.Heroes.Count;

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void RemoveShouldThrowExceptionWhenNull()
    {
        var heroRepository = new HeroRepository();

        Assert.Throws<ArgumentNullException>(() =>
        {
            heroRepository.Remove(null);
        });
    }

    [Test]
    public void RemoveShouldThrowExceptionWhenWhitespace()
    {
        var heroRepository = new HeroRepository();

        Assert.Throws<ArgumentNullException>(() =>
        {
            heroRepository.Remove("          ");
        });
    }

    [Test]
    public void GetHeroWithHighestLevelShouldWorkCorrectly()
    {
        var heroRepository = new HeroRepository();

        var hero = new Hero("Pesho", 10);
        var hero2 = new Hero("Gosho", 100);

        heroRepository.Create(hero);
        heroRepository.Create(hero2);

        var actual = heroRepository.GetHeroWithHighestLevel();

        Assert.AreEqual(hero2, actual);
    }

    [Test]
    public void GetShouldWorkCorrectly()
    {
        var heroRepository = new HeroRepository();

        var hero = new Hero("Pesho", 10);
        var hero2 = new Hero("Gosho", 100);

        heroRepository.Create(hero);
        heroRepository.Create(hero2);

        var actual = heroRepository.GetHero("Pesho");

        Assert.AreEqual(hero, actual);
    }
}