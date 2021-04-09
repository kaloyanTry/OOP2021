using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Computers.Tests
{
    public class Tests
    {
        private ComputerManager computerManager;
        private Computer computer;

        [SetUp]
        public void Setup()
        {
            computerManager = new ComputerManager();
            computer = new Computer("Asus", "Yoga", 1600.00m);
        }

        [Test]
        public void Ctor_ShouldInitializeCollection()
        {
            Assert.IsNotNull(computerManager.Computers);
        }

        [Test]
        public void Counter_ShouldBeSetZero()
        {
            Assert.That(() => computerManager.Count, Is.Zero);
            //Assert.That(() => computerManager.Count, Is.Zero);
        }

        [Test]
        public void AddCount_ShouldReturnCorrectCount()
        {
            computerManager.AddComputer(new Computer("HP", "Laptop", 1200.0m));
            computerManager.AddComputer(new Computer("Lenovo", "PC", 890.0m));

            Assert.That(computerManager.Count, Is.EqualTo(2));
        }

        [Test]
        public void AddComputer_ShouldThrowExceptionWhenAddingNull()
        {
            Assert.Throws<ArgumentNullException>(() => computerManager.AddComputer(null));
        }

        [Test]
        public void AddComputer_ShouldThrowExceptionWhenComputerExist()
        {
            computerManager.AddComputer(new Computer("HP", "Laptop", 1200.0m));

            Assert.Throws<ArgumentException>(() => computerManager.AddComputer(new Computer("HP", "Laptop", 1200.0m)));
        }

        [Test]
        public void AddingSameComputer_ShouldTrhrowExceptionMessage()
        {
            computerManager.AddComputer(computer);

            Assert.That(() => computerManager.AddComputer(computer), Throws.ArgumentException.With.Message.EqualTo("This computer already exists."));

            //Exception ex = Assert.Throws<ArgumentException>(() =>
            //{
            //    computerManager.AddComputer(new Computer("HP", "Laptop", 1200.0m));
            //    computerManager.AddComputer(new Computer("HP", "Laptop", 1200.0m));
            //});
            //Assert.AreEqual(ex.Message, "This computer already exists.");
        }

        [Test]
        public void AddComputer_ShouldAddGivenComputer()
        {
            computerManager.AddComputer(computer);

            Assert.IsTrue(computerManager.Computers.Contains(computer));
        }

        [Test]
        public void AddingComputerMethod_ShouldWorksCorrectly()
        {
            var comp = new Computer("HP", "Laptop", 1200.0m);
            computerManager.AddComputer(comp);

            Assert.That(comp.Manufacturer, Is.EqualTo("HP"));
        }

        [Test]
        public void RemoveComputer_ShouldWorksCorrectly()
        {
            computerManager.AddComputer(new Computer("HP", "Laptop", 1200.0m));
            computerManager.RemoveComputer("HP", "Laptop");

            Assert.That(computerManager.Count, Is.EqualTo(0));
        }

        [Test]
        public void RemoveComputer_ShouldWorksCorrectlyGetComputer()
        {
            var comp = new Computer("HP", "Laptop", 1200.0m);
            computerManager.AddComputer(comp);

             var getComp = computerManager.GetComputer("HP", "Laptop");

            Assert.That(comp, Is.EqualTo(getComp));
        }

        [Test]
        public void RemoveComputer_ShouldRemoveTheCorrectComputerWithGivenManufacturerAndModel()
        {
            computerManager.AddComputer(computer);

            computerManager.RemoveComputer(computer.Manufacturer, computer.Model);

            CollectionAssert.DoesNotContain(computerManager.Computers, computer);
        }

        [Test]
        public void GetComputer_ShouldThrowArgumentExceptionWhenManufacturerNull()
        {
            Assert.Throws<ArgumentNullException>(() => computerManager.GetComputer(null, "Yoga"));
        }

        [Test]
        public void GetComputer_ShouldThrowArgumentExceptionWhenModelNull()
        {
            Assert.Throws<ArgumentNullException>(() => computerManager.GetComputer("Lenovo", null));
        }

        [Test]
        public void GetComputer_ShouldThrowsExceptionWhenComputerNotExist()
        {
            Assert.That(() => computerManager.GetComputer("noone", "less"), Throws.ArgumentException.With.Message.EqualTo("There is no computer with this manufacturer and model."));
        }

        [Test]
        public void GetComputersByManufacturer_ShouldReturnCollectionOfAllCompsWithGivenManufacturer()
        {
            computerManager.AddComputer(computer);
            var comp = new Computer("Asus", "K54HR", 1000m);
            computerManager.AddComputer(comp);
            var otherComp = new Computer("IBM", "model", 1300m);
            computerManager.AddComputer(otherComp);
            ICollection<Computer> expectedCollection = new List<Computer>()
            {
                computer,
                comp
            };

            var actualCollection = this.computerManager.GetComputersByManufacturer("Asus");

            CollectionAssert.AreEqual(expectedCollection, actualCollection);
        }

        [Test]
        public void GetComputersByManufacturer_ShouldReturnEmptyCollectionWhenNoComputersWithGivenManufacturer()
        {
            computerManager.AddComputer(computer);
            var comp = new Computer("Asus", "K54HR", 1000m);
            computerManager.AddComputer(comp);
            var otherComp = new Computer("IBM", "model", 1300m);
            computerManager.AddComputer(otherComp);

            var collection = computerManager.GetComputersByManufacturer("Toshiba");

            CollectionAssert.IsEmpty(collection);
        }
    }
}