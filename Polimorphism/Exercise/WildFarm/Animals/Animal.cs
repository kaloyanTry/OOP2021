using System;
using System.Collections.Generic;
using WildFarm.Foods;

namespace WildFarm.Animals
{
    public abstract class Animal
    {
        protected Animal(string name, 
            double weight, 
            HashSet<string> allowedFoods, 
            double weightModifier)
        {
            Name = name;
            Weight = weight;
            AllowedFoods = allowedFoods;
            WeightModifier = weightModifier;
        }

        private HashSet<string> AllowedFoods { get; set; }
        private double WeightModifier { get; set; }
        public string Name { get; private set; }
        public double Weight { get; private set; }
        public int FoodEaten { get; private set; }

        public abstract string ProduceSound();
        public void Eat(Food food)
        {
            string foodTypeName = food.GetType().Name;
            if (!AllowedFoods.Contains(foodTypeName))
            {
                throw new InvalidOperationException($"{GetType().Name} does not eat {foodTypeName}!");
            }

            FoodEaten += food.Quantity;

            Weight += WeightModifier * food.Quantity;
        }

    }
}
