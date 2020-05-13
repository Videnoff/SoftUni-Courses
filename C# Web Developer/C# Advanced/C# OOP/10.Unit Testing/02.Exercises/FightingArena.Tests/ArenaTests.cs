using System;
using FightingArena;
using NUnit.Framework;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;
        private Warrior warrior;
        private Warrior attacker;
        private Warrior defender;

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
            this.warrior = new Warrior("Pesho", 5, 50);

            this.attacker = new Warrior("Pesho", 10, 80);
            this.defender = new Warrior("Gosho", 5, 60);
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            Assert.IsNotNull(this.arena.Warriors);
        }

        [Test]
        public void TestIfEnrollWorksCorrectly()
        {
            this.arena.Enroll(this.warrior);

            Assert.That(this.arena.Warriors, Has.Member(this.warrior));
        }

        [Test]
        public void EnrollShouldIncreaseCount()
        {
            var expectedCount = 2;

            this.arena.Enroll(this.warrior);
            this.arena.Enroll(new Warrior("Gosho", 5, 60));

            var actualCount = this.arena.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void TestEnrollSameWarriorShouldThrowException()
        {
            // Arrange
            this.arena.Enroll(this.warrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Enroll(this.warrior);
            });
        }

        [Test]
        public void EnrollTwoWarriorsWithSameNameShouldThrowException()
        {
            Warrior warriorCopy = new Warrior(warrior.Name, warrior.Damage, warrior.HP);

            this.arena.Enroll(warriorCopy);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Enroll(warriorCopy);
            });
        }

        [Test]
        public void TestIfFightWorksCorrectly()
        {
            // Arrange
            var expectedAttackerHP = this.attacker.HP - this.defender.Damage;
            var expectedDefenderHP = this.defender.HP - this.attacker.Damage;

            this.arena.Enroll(this.attacker);
            this.arena.Enroll(this.defender);

            // Act
            this.arena.Fight(this.attacker.Name, this.defender.Name);

            // Assert
            Assert.AreEqual(expectedAttackerHP, this.attacker.HP);
            Assert.AreEqual(expectedDefenderHP, this.defender.HP);
        }

        [Test]
        public void TestFightWithMissingAttacker()
        {
            this.arena.Enroll(this.defender);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Fight(this.attacker.Name, this.defender.Name);
            });
        }

        [Test]
        public void TestFightWithMissingDefender()
        {
            this.arena.Enroll(this.attacker);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Fight(this.attacker.Name, this.defender.Name);
            });
        }
    }
}
