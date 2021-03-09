using System;
using System.Collections.Generic;
using WildFarm.Foods;

namespace WildFarm.Animals.Mammals.Felines
{
    public class Cat : Feline
    {
        private const double BaseWightModifier = 0.3;
        private static HashSet<string> allowedFoods = new HashSet<string>
        {
            nameof(Meat),
            nameof(Vegetable)
        };
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, allowedFoods, BaseWightModifier, livingRegion, breed)
        {
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
