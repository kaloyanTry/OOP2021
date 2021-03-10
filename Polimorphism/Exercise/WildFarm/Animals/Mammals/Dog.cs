using ExerciseWildFarm.Foods;
using System.Collections.Generic;

namespace ExerciseWildFarm.Animals.Mammals
{
    public class Dog : Mammal
    {
        private const double BaseWightModifier = 0.4;
        private static HashSet<string> allowedFoods = new HashSet<string>
        {
            nameof(Meat)
        };
        public Dog(string name, 
            double weight,  
            string livingRegion) 
            : base(name, weight, allowedFoods, BaseWightModifier, livingRegion)
        {
        }

        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}
