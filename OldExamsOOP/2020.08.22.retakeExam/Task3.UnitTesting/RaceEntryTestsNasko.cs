using NUnit.Framework;
using TheRace;
using System;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry raceEntry;

        [SetUp]
        public void Setup()
        {
            raceEntry = new RaceEntry();
        }

        //--Counter tests--
        [Test]
        public void Counter_ShoulBeZeroByDefault()
        {
            Assert.That(raceEntry.Counter, Is.Zero);
        }

        [Test]
        public void Counter_IncreasesWhenAddDriver()
        {
            raceEntry.AddDriver(new UnitDriver("Sena", new UnitCar("Reno", 4000, 400)));
            raceEntry.AddDriver(new UnitDriver("Prost", new UnitCar("BMW", 5000, 500)));
            Assert.That(raceEntry.Counter, Is.EqualTo(2));
        }

        //--AddDriver method--
        [Test]
        public void AddDriver_ThrowsException_WhenDriverIsNull()
        {
            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(null));
        }

        //--AddDriver method--
        [Test]
        public void AddDriver_ThrowsException_WhenDriverNameExist()
        {
            string driverName = "Sena";
            raceEntry.AddDriver(new UnitDriver(driverName, new UnitCar("BMW", 5000, 500)));
            

            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(new UnitDriver(driverName, new UnitCar("Tesla", 6000, 300))));
        }

        [Test]
        public void AddDriver_ReturnCorrectMessage()
        {
            string driverName = "Sena";
            var actual = raceEntry.AddDriver(new UnitDriver(driverName, new UnitCar("BMW", 5000, 500)));
            var expected = $"Driver {driverName} added in race.";

            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void CalculateAvrgHP_ThrowsException_WhenParticipantsAreLess()
        {
            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower());

            raceEntry.AddDriver(new UnitDriver("Sena", new UnitCar("MC", 5000, 500)));
            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void CalculateAvrgHP_ReturnsCorrectResult()
        {
            raceEntry.AddDriver(new UnitDriver("Sena", new UnitCar("MC", 500, 200)));
            raceEntry.AddDriver(new UnitDriver("Prost", new UnitCar("MC", 500, 100)));

            Assert.That(raceEntry.CalculateAverageHorsePower, Is.EqualTo(500));
        }
    }
}