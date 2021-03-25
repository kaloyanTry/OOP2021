using NUnit.Framework;
using System;

namespace Tests
{
    using FightingArena; //Comment for Judge

    public class WarriorTests
    {
        //--Ctor tests--
        [Test]
        [TestCase("", 50, 100)]
        [TestCase(" ", 50, 100)]
        [TestCase(null, 50, 100)]
        [TestCase("Warrior", 0, 100)]
        [TestCase("Warrior", -10, 100)]
        [TestCase("Warrior", 50, -10)]
        public void Ctor_ThrowsException_WhenDataIsInvalid(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp));
        }

        [Test]
        public void Ctor_SetInitialValues_WhenArgumentsAreValid()
        {
            string name = "Warrior";
            int damage = 10;
            int hp = 30;

            Warrior warrior = new Warrior(name, damage, hp);

            Assert.That(warrior.Name, Is.EqualTo(name));
            Assert.That(warrior.Damage, Is.EqualTo(damage));
            Assert.That(warrior.HP, Is.EqualTo(hp));
        }

        [Test]
        [TestCase(30, 55)]
        [TestCase(15, 55)]
        [TestCase(55, 30)]
        [TestCase(55, 15)]
        public void Attac_WhenHpIsLessThenMinAttackHp(int atteckerHp, int warriorHp)
        {
            Warrior attacker = new Warrior("Attacer", 50, atteckerHp);
            Warrior warrior = new Warrior("Warrior", 10, warriorHp);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(warrior));
        }

        [Test]
        public void Attack_ThrowsExeption_WhenWarriorKillsAttacer()
        {
            Warrior attacker = new Warrior("Attacer", 50, 100);
            Warrior warrior = new Warrior("Warrior", attacker.HP + 1, 100);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(warrior));
        }

        [Test]
        public void Attack_DecreasedHPForBothSides()
        {
            int initialAttackerHP = 100;
            int initialWarriorHP = 100;

            Warrior attacker = new Warrior("Attacer", 50, initialAttackerHP);
            Warrior warrior = new Warrior("Warrior", 30, initialWarriorHP);

            attacker.Attack(warrior);

            Assert.That(attacker.HP, Is.EqualTo(initialAttackerHP - warrior.Damage));
            Assert.That(warrior.HP, Is.EqualTo(initialWarriorHP - attacker.Damage));
        }

        [Test]
        public void Attack_SetEnemyHPToZero_WhenAttackerDamageIsGreaterThanEnemy()
        {
            Warrior attacker = new Warrior("Attacer", 50, 100);
            Warrior warrior = new Warrior("Warrior", 30, 40);

            attacker.Attack(warrior);

            Assert.That(warrior.HP, Is.EqualTo(0));
        }
    }
}