using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry race;

        [SetUp]
        public void Setup()
        {
            race = new RaceEntry();
        }

        [Test]
        public void ShouldThrowException_WhenAddDriverNull()
        {
            Exception ex = Assert.Throws<InvalidOperationException>(() =>
            {
                race.AddDriver(null);
            });

            Assert.AreEqual(ex.Message, "Driver cannot be null.");
        }

        [Test]
        public void ShouldThrowException_WhenAddDriverExistName()
        {
            Exception ex = Assert.Throws<InvalidOperationException>(() =>
            {
                var car = new UnitCar("model", 100, 1000);
                var driver = new UnitDriver("Sena", car);

                race.AddDriver(driver);
                race.AddDriver(driver);
            });

            Assert.AreEqual(ex.Message, $"Driver Sena is already added.");
        }

        [Test]
        public void ShouldSetCorrectly_WhenAddDriver()
        {
            var car = new UnitCar("model", 100, 1000);
            var driver = new UnitDriver("Sena", car);

            race.AddDriver(driver);
            Assert.That(driver.Name, Is.EqualTo("Sena"));
        }

        [Test]
        public void ShouldCountCorrectly_WhenAddDriver()
        {
            var car1 = new UnitCar("model1", 100, 1000);
            var driver1 = new UnitDriver("Sena", car1);

            var car2 = new UnitCar("model2", 200, 2000);
            var driver2 = new UnitDriver("Prost", car2);

            race.AddDriver(driver1);
            race.AddDriver(driver2);
            Assert.That(race.Counter, Is.EqualTo(2));
        }

        [Test]
        public void ShouldCountLess_WhenParticipantsLessThenCounter()
        {
            var car1 = new UnitCar("model1", 100, 1000);
            var driver1 = new UnitDriver("Sena", car1);
            race.AddDriver(driver1);

            var count = race.Counter;

            Assert.That(count, Is.LessThan(2));
        }

        [Test]
        public void ShouldCalculateCorrectly_WhenAddDriver()
        {
            var car1 = new UnitCar("model1", 100, 1000);
            var driver1 = new UnitDriver("Sena", car1);

            var car2 = new UnitCar("model2", 200, 2000);
            var driver2 = new UnitDriver("Prost", car2);

            race.AddDriver(driver1);
            race.AddDriver(driver2);

            race.CalculateAverageHorsePower();
            Assert.That(race.CalculateAverageHorsePower, Is.EqualTo(150));
        }
    }
}