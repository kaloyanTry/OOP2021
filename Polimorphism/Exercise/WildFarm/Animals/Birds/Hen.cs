using ExerciseWildFarm.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciseWildFarm.Animals.Birds
{
    public class Hen : Bird
    {
        private const double BaseWeightModifier = 0.35;
        private static HashSet<string> allowedFoods = new HashSet<string>
        {
            nameof(Meat),
            nameof(Fruit),
            nameof(Vegetable),
            nameof(Seeds)
        };
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, allowedFoods, BaseWeightModifier, wingSize)
        {
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
