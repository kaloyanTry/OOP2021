namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    public class AquariumsTests
    {
        private Aquarium aquarium;
        private List<Fish> fish;

        [SetUp]
        public void SetUp()
        {
            aquarium = new Aquarium("Fresh", 50);
            fish = new List<Fish>();
        }

        [Test]
        public void Ctor_ShouldReturnCheck()
        {
            Assert.IsNotNull(aquarium);
        }

        [Test]
        public void Ctor_ShouldReturnFishList()
        {
            Assert.IsNotNull(fish);
        }


        [Test]
        public void Ctor_ShouldReturnCheckName()
        {
            Assert.AreEqual(aquarium.Name, "Fresh");
        }

        [Test]
        public void Ctor_ShouldReturnCheckCapacity()
        {
            Assert.AreEqual(aquarium.Capacity, 50);
        }

        [Test]
        public void Name_ShouldReturnCheckThrowsName()
        {
            Assert.Throws<ArgumentNullException>(() => aquarium = new Aquarium("", 25), "Invalid aquarium name!");
        }

        [Test]
        public void Ctor_ShouldReturnCheckThrows()
        {
            Assert.That(() => aquarium = new Aquarium("Sisi", -5), Throws.ArgumentException.With.Message.EqualTo("Invalid aquarium capacity!"));
        }

        [Test]
        public void Ad_ShouldCountCorrect()
        {
            aquarium.Add(new Fish("Miim"));

            Assert.That(aquarium.Count, Is.EqualTo(1));
        }

        [Test]
        public void Remove_ShouldThrowException_WhenNameNotExsist()
        {
            var fishName = "Sina";

            Assert.Throws< InvalidOperationException>(() => aquarium.RemoveFish(fishName), $"Fish with the name {fishName} doesn't exist!");
        }

        [Test]
        public void SellFish_ShouldThrowException_WhenNameNotExsist()
        {
            var fishName = "Nofish";

            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish(fishName), $"Fish with the name {fishName} doesn't exist!");
        }
    }
}
