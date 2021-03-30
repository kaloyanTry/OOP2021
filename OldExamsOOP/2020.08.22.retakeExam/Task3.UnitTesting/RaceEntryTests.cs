using NUnit.Framework;
using TheRace;
using System;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddDriverMethod_ShouldThrowExceptionWhenNullIsPassed()
        {
            var raceEntry = new RaceEntry();

            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(null));
        }

        [Test]
        public void AddDriverMethod_ShouldThrowExceptionWhenDriverExist()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var raceEntry = new RaceEntry();

                var unitCar = new UnitCar("model", 10, 10);
                var unitDriver = new UnitDriver("Gesho", unitCar);

                raceEntry.AddDriver(unitDriver);
                raceEntry.AddDriver(unitDriver);
            });
        }

        [Test]
        public void AddDriverMethod_ShouldWork()
        {
            var raceEntry = new RaceEntry();

            var unitCar = new UnitCar("model", 10, 10);
            var unitDriver = new UnitDriver("Gesho", unitCar);

            var result = raceEntry.AddDriver(unitDriver);

            Assert.AreEqual($"Driver {unitDriver.Name} added in race.", result);
            Assert.AreEqual(1, raceEntry.Counter);
        }

        [Test]
        public void CalculateAvrgHP_ShouldThrowExceptionWhenParticipantsNotEnough()
        {
            var raceEntry = new RaceEntry();

            var unitCar = new UnitCar("model", 10, 10);
            var unitDriver = new UnitDriver("Gesho", unitCar);

            var result = raceEntry.AddDriver(unitDriver);

            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void CalculateAvrgHP_ShouldWork()
        {
            var raceEntry = new RaceEntry();

            var unitCar = new UnitCar("VW", 100, 4600);
            var unitDriver = new UnitDriver("Kiro", unitCar);

            var unitCar2 = new UnitCar("BVW", 100, 5800);
            var unitDriver2 = new UnitDriver("Ivan", unitCar2);

            var unitCar3 = new UnitCar("Lada", 100, 6500);
            var unitDriver3 = new UnitDriver("Stoyan", unitCar3);

            raceEntry.AddDriver(unitDriver);
            raceEntry.AddDriver(unitDriver2);
            raceEntry.AddDriver(unitDriver3);

            var result = raceEntry.CalculateAverageHorsePower();

            Assert.AreEqual(100, result);
        }
    }
}