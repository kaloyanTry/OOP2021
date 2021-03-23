using NUnit.Framework;
using System.Collections.Generic;
using FightingArena; //Comment for Judge

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            arena = new Arena();
        }

        //--Ctor tests--
        [Test]
        public void ConstructorShouldInitializeCollection()
        {
            arena = new Arena();
            List<Warrior> warriors = new List<Warrior>();

            CollectionAssert.AreEqual(warriors, arena.Warriors);
        }

        //--Method tests--
        [Test]
        public void EnrollOperationShouldEnrollWarriorsCorrectly()
        {
            arena = new Arena();
            Warrior firstWarrior = new Warrior("First", 5, 100);
            Warrior secondWarrior = new Warrior("Second", 5, 120);

            arena.Enroll(firstWarrior);
            arena.Enroll(secondWarrior);

            List<Warrior> expected = new List<Warrior> { firstWarrior, secondWarrior };

            CollectionAssert.AreEqual(expected, arena.Warriors);
        }

        [Test] 
        public void ShouldThrowInvalidOperation_IfEntrollAlreadyEntrolledWarrior()
        {
            Warrior warrior = new Warrior("Lorush_Huko", 25, 120);
            arena.Enroll(warrior);

            Assert.That(() => arena.Enroll(warrior), Throws.InvalidOperationException.With.Message.EqualTo("Warrior is already enrolled for the fights!"));
        }

        [Test]
        public void FighOperationExecuteSuccessfully()
        {
            arena = new Arena();
            Warrior firstWarrior = new Warrior("First", 5, 100);
            Warrior secondWarrior = new Warrior("Second", 5, 120);
            arena.Enroll(firstWarrior);
            arena.Enroll(secondWarrior);

            arena.Fight("First", "Second");

            var expectedFirstHp = 115;
            var actual = secondWarrior.HP;
            Assert.AreEqual(expectedFirstHp, actual);
        }

        [Test]
        public void FightOperationShouldThrowInvalidOperationExceptionInAttemptToFightWithMissingAttackerName()
        {
            arena.Enroll(new Warrior("Stoyan", 5, 120));
            string attacker = "Ivan";

            Assert.That(() => arena.Fight(attacker, "Stoyan"), Throws.InvalidOperationException.With.Message.EqualTo($"There is no fighter with name {attacker} enrolled for the fights!"));
        }

        [Test]
        public void FightOperationShouldThrowInvalidOperationExceptionInAttemptToFightWithMissingDefenderName()
        {
            arena.Enroll(new Warrior("Stoyan", 5, 120));
            string defender = "Ivan";

            Assert.That(() => arena.Fight("Stoyan", defender), Throws.InvalidOperationException.With.Message.EqualTo($"There is no fighter with name {defender} enrolled for the fights!"));
        }
    }
}
