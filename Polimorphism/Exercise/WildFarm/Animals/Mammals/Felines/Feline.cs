using System.Collections.Generic;

namespace ExerciseWildFarm.Animals.Mammals.Felines
{
    public abstract class Feline : Mammal
    {
        protected Feline(string name, 
            double weight, 
            HashSet<string> allowedFoods, 
            double weightModifier, 
            string livingRegion, 
            string breed) 
            : base(name, weight, allowedFoods, weightModifier, livingRegion)
        {
            Breed = breed;
        }

        public string Breed { get; private set; }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
