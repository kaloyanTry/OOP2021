using ExerciseWildFarm.Foods;
using System.Collections.Generic;

namespace ExerciseWildFarm.Animals.Mammals
{
    public class Mouse : Mammal
    {
        private const double BaseWightModifier = 0.1;
        private static HashSet<string> allowedFoods = new HashSet<string>
        {
            nameof(Vegetable),
            nameof(Fruit)
        };
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, allowedFoods, BaseWightModifier, livingRegion)
        {
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }

    }
}
