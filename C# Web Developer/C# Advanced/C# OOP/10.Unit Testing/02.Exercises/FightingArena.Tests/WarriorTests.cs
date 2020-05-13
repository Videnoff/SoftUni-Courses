using System;
using FightingArena;
using NUnit.Framework;

namespace Tests
{
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            var expectedName = "Pesho";
            var expectedDmg = 50;
            var expectedHP = 100;

            Warrior warrior = new Warrior(expectedName, expectedDmg, expectedHP);

            var actualName = warrior.Name;
            var actualDmg = warrior.Damage;
            var actualHP = warrior.HP;

            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedDmg, actualDmg);
            Assert.AreEqual(expectedHP, actualHP);
        }

        [Test]
        public void TestWithLikeEmptyName()
        {
            var name = string.Empty;

            var dmg = 50;
            var hp = 100;

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, dmg, hp);
            });
        }

        [Test]
        public void TestWithLikeNullName()
        {
            string name = null;
            var dmg = 50;
            var hp = 100;

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, dmg, hp);
            });
        }

        [Test]
        public void TestWithLikeWhiteSpaceName()
        {
            var name = "         ";

            var dmg = 50;
            var hp = 100;

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, dmg, hp);
            });
        }

        [Test]
        public void TestWithLikeZeroDamage()
        {
            var name = "Pesho";

            var dmg = 0;
            var hp = 100;

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, dmg, hp);
            });
        }

        [Test]
        public void TestWithLikeNegativeDamage()
        {
            var name = "Pesho";

            var dmg = -10;
            var hp = 100;

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, dmg, hp);
            });
        }

        [Test]
        public void TestWithLikeNegativeHP()
        {
            var name = "Pesho";

            var dmg = 500;
            var hp = -10;

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, dmg, hp);
            });
        }

        [Test]
        [TestCase(25)]
        [TestCase(30)]
        public void TestAttckingWithLowHP(int attackerHP)
        {
            var attackerName = "Pesho";
            var attackerDmg = 10;

            var defenderName = "Gosho";
            var defenderDmg = 10;
            var defenderHP = 40;

            Warrior attacker = new Warrior(attackerName, attackerDmg, attackerHP);
            Warrior defender = new Warrior(defenderName, defenderDmg, defenderHP);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            });
        }

        [Test]
        [TestCase(25)]
        [TestCase(30)]
        public void TestAttackingEnemyWithLowHP(int defenderHP)
        {
            var attackerName = "Pesho";
            var attackerDmg = 10;
            var attackerHP = 100;

            var defenderName = "Gosho";
            var defenderDmg = 10;

            Warrior attacker = new Warrior(attackerName, attackerDmg, attackerHP);
            Warrior defender = new Warrior(defenderName, defenderDmg, defenderHP);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            });
        }

        [Test]
        public void TestAttackingStrongerEnemy()
        {
            var attackerName = "Pesho";
            var attackerDmg = 10;
            var attackerHP = 35;

            var defenderName = "Gosho";
            var defenderDmg = 40;
            var defenderHP = 35;

            Warrior attacker = new Warrior(attackerName, attackerDmg, attackerHP);
            Warrior defender = new Warrior(defenderName, defenderDmg, defenderHP);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            });
        }

        [Test]
        public void AttackingShouldDecreaseHPWhenSuccessfull()
        {
            var attackerName = "Pesho";
            var attackerDmg = 10;
            var attackerHP = 40;

            var defenderName = "Gosho";
            var defenderDmg = 5;
            var defenderHP = 50;

            Warrior attacker = new Warrior(attackerName, attackerDmg, attackerHP);
            Warrior defender = new Warrior(defenderName, defenderDmg, defenderHP);

            var expectedAttackerHP = attackerHP - defenderDmg;
            var expectedDefenderHP = defenderHP - attackerDmg;

            attacker.Attack(defender);

            Assert.AreEqual(expectedAttackerHP, attacker.HP);
            Assert.AreEqual(expectedDefenderHP, defender.HP);
        }

        [Test]
        public void TestKillingEnemy()
        {
            var attackerName = "Pesho";
            var attackerDmg = 80;
            var attackerHP = 100;

            var defenderName = "Gosho";
            var defenderDmg = 10;
            var defenderHP = 60;

            Warrior attacker = new Warrior(attackerName, attackerDmg, attackerHP);
            Warrior defender = new Warrior(defenderName, defenderDmg, defenderHP);

            var expectedAttackerHP = attackerHP - defenderDmg;    // 90
            var expectedDefenderHP = 0;                           // 60 - 80 = -20 < 0 => 0 

            attacker.Attack(defender);

            Assert.AreEqual(expectedAttackerHP, attacker.HP);
            Assert.AreEqual(expectedDefenderHP, defender.HP);
        }
    }
}