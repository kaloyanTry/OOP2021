using System;
using System.Collections.Generic;
using WildFarm.Foods;

namespace WildFarm.Animals.Births
{
    public class Hen : Bird
    {
        private const double BaseWightModifier = 0.35;
        private static HashSet<string> allowedFoods = new HashSet<string>
        {
            nameof(Meat),
            nameof(Vegetable),
            nameof(Fruit),
            nameof(Seeds)
        };

        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, allowedFoods, BaseWightModifier, wingSize)
        {
        }
        public override string ProduceSound()
        {
            return "Cluck";
        }

    }
}
