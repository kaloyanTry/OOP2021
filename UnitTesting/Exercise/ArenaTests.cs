using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    using FightingArena; //Comment for Judge

    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            arena = new Arena();
        }

        [Test]
        public void Ctor_InitializeWarriors()
        {
            Assert.That(arena.Warriors, Is.Not.Null);
        }

        [Test]
        public void Count_IsZero_WhenArenaIsEmpty ()
        {
            Assert.That(arena.Count, Is.EqualTo(0));
        }

        [Test]
        public void Enroll_ThrowsExceptionWhenWarriorsAlreadyExist()
        {
            string name = "Warrior";
            arena.Enroll(new Warrior(name, 50, 50));
            
            Assert.Throws<InvalidOperationException>(() => arena.Enroll(new Warrior(name, 55, 55)));
        }

        [Test]
        public void Enroll_IncreasesArenaCount()
        {
            arena.Enroll(new Warrior("Warrior", 50, 50));

            Assert.That(arena.Count, Is.EqualTo(1));
        }

        [Test]
        public void Enroll_AddsWarriorToWarriors()
        {
            string name = "Warrior";
            arena.Enroll(new Warrior(name, 50, 50));

            Assert.That(arena.Warriors.Any(w => w.Name == name), Is.True);
        }

        [Test]
        public void Fight_ThrowsException_WhenWarriorNotExist()
        {
            string name = "Attacker";
            arena.Enroll(new Warrior(name, 40, 40));

            Assert.Throws<InvalidOperationException>(() => arena.Fight(name, "Defender"));
        }

        [Test]
        public void Fight_ThrowsException_WhenAttackerNotExist()
        {
            string name = "Defender";
            arena.Enroll(new Warrior(name, 40, 40));

            Assert.Throws<InvalidOperationException>(() => arena.Fight("Attacker", name));
        }

        [Test]
        public void Fight_ThrowsException_WhenBothNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => arena.Fight("Attacker", "Defender"));
        }

        [Test]
        public void Fight_BothWarriorsLoseHPInFight()
        {
            int initialHP = 100;

            Warrior attacker = new Warrior("Attacer", 50, initialHP);
            Warrior defender = new Warrior("Defender", 50, initialHP);

            arena.Enroll(attacker);
            arena.Enroll(defender);

            arena.Fight(attacker.Name, defender.Name);

            Assert.That(attacker.HP, Is.EqualTo(initialHP - defender.Damage));
            Assert.That(defender.HP, Is.EqualTo(initialHP - attacker.Damage));
        }
    }
}
