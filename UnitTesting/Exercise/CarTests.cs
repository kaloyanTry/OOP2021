using NUnit.Framework;
using System;

namespace Tests
{
    using CarManager; //Comment for Judge

    public class CarTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            car = new Car("Make,", "Model", 10, 100);
        }

        [Test]
        [TestCase("", "Model", 10, 100)]
        [TestCase(null, "Model", 10, 100)]
        [TestCase("Make", "", 10, 100)]
        [TestCase("Make", null, 10, 100)]
        [TestCase("Make", "Model", 0, 100)]
        [TestCase("Make", "Model", -10, 100)]
        [TestCase("Make", "Model", 10, 0)]
        [TestCase("Make", "Model", 10, -50)]
        public void Ctor_ThrowsException_WhenDataIsInvalid(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void Ctor_SetInitialValues_WhenArgumentsAreValid()
        {
            string make = "Make";
            string model = "Model";
            double fuelConsumption = 10.0;
            double fuelCapacity = 100.0;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            Assert.That(car.Make, Is.EqualTo(make));
            Assert.That(car.Model, Is.EqualTo(model));
            Assert.That(car.FuelConsumption, Is.EqualTo(fuelConsumption));
            Assert.That(car.FuelCapacity, Is.EqualTo(fuelCapacity));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-20)]
        public void Refuel_ThrowsException_WhenFuelIsZeroOrNegative(double fuel)
        {
            Car car = new Car("Make", "Model", 10, 100);

            Assert.Throws<ArgumentException>(() => car.Refuel(fuel));
        }

        [Test]
        public void Refuel_IncreaseFuelAmount_WhenFuelAmountIsValid()
        {
            double refuelAmount = car.FuelCapacity / 2;
            car.Refuel(refuelAmount);

            Assert.That(car.FuelAmount, Is.EqualTo(refuelAmount));
        }

        [Test]
        public void Refuel_SetFuelAmountToCapacity_WhenCapacityExceed()
        {
            car.Refuel(car.FuelCapacity * 1.2);

            Assert.That(car.FuelAmount, Is.EqualTo(car.FuelCapacity));
        }

        [Test]
        public void Drive_ThrowsException_WhenFuelIsZero()
        {
            Assert.Throws<InvalidOperationException>(() => car.Drive(100));
        }

        [Test]
        public void Drive_DecreasesFuelAmount_WhenDistanceIsValid()
        {
            double initialFuel = car.FuelCapacity;
            car.Refuel(initialFuel);

            car.Drive(100);

            Assert.That(car.FuelAmount, Is.EqualTo(initialFuel - car.FuelConsumption));
        }

        [Test]
        public void Drive_DecreasesFuelAmountToZero_WhenRequiredFuelIsEqualToFuelAmount()
        {
            car.Refuel(car.FuelCapacity);

            double distance = car.FuelCapacity * car.FuelConsumption;

            car.Drive(distance);

            Assert.That(car.FuelAmount, Is.EqualTo(0));
        }

        [Test]
        public void FuelAmount_ThrowsException_WhenNegativeValueIsPassed()
        {
            car.Refuel(car.FuelCapacity);

            double beforeDrive = car.FuelAmount;

            car.Drive(100);

            double afterDrive = car.FuelAmount;

            Assert.That(afterDrive, Is.LessThan(beforeDrive));
        }
    }
}