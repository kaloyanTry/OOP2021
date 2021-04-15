namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AquariumsTests
    {
        private Aquarium aquarium;
        private List<Fish> fish;

        [SetUp]
        public void SetUp()
        {
            aquarium = new Aquarium("Freshwater", 50);
            fish = new List<Fish>();
        }

        [Test]
        public void CtorAquarium_ShouldNotSetEmpty()
        {
            Assert.IsNotNull(aquarium);
        }

        [Test]
        public void CtorFish_ShouldNotSetEmpty()
        {
            Assert.IsNotNull(fish);
        }

        [Test]
        public void Name_ShoulThrowException_WhenNull()
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(null, 50));
        }

        [Test]
        public void Name_ShoulThrowException_WhenEmpty()
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium("", 50));
        }

        [Test]
        public void Capacity_ShoulThrowException_WhenLess()
        {
            Assert.Throws<ArgumentException>(() => new Aquarium("Salty", -5));
        }

        [Test]
        public void Count_ShouldBeCorrect()
        {
            Assert.That(fish.Count, Is.Zero);
        }

        [Test]
        public void AddCount_ShouldBeCorrect_WhenAdd()
        {
            fish.Add(new Fish("Sisi"));
            
            Assert.That(fish.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddCount_ShouldBeCorrect_WhenAdd2()
        {
            var fishName = "Sisi";
            var fishToAdd = new Fish(fishName);
            fish.Add(fishToAdd);
            
            Assert.That(fish.Contains(fishToAdd));
        }

        [Test]
        public void Add_ShouldThrowRightMessage()
        {
            for (int i = 0; i < aquarium.Capacity; i++)
            {
                aquarium.Add(new Fish($"{i}"));
            }

            Assert.That(() =>
            {
                aquarium.Add(new Fish("Resi"));
            }, Throws.InvalidOperationException.With.Message.EqualTo("Aquarium is full!"));

        }

        [Test]
        public void Remove_ShouldBeCorrect()
        {    
            aquarium.Add(new Fish("Sisi"));
            aquarium.RemoveFish("Sisi");

            Assert.That(fish.Count, Is.EqualTo(0));
        }

        [Test]
        public void Remove_ShouldThrowRightMessage()
        {
            var fishName = "Misi";
            var fishToAdd = new Fish(fishName);
            aquarium.Add(fishToAdd);

            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("Jisi"), "Fish with the name Jisi doesn't exist!");
        }

        [Test]
        public void SellFish_ShouldBeCorrect()
        {
            var fishName = "Misi";
            var fishToAdd = new Fish(fishName);
            aquarium.Add(fishToAdd);

            var aquaSell =  aquarium.SellFish("Misi");

            Assert.AreEqual(fishToAdd, aquaSell);
        }

        [Test]
        public void SellFish_ShouldThrowRightMessage()
        {
            var fishName = "Misi";
            var fishToAdd = new Fish(fishName);
            aquarium.Add(fishToAdd);

            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish("Jisi"), "Fish with the name Jisi doesn't exist!");
        }

    }
}
