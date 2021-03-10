using System.Collections.Generic;

namespace ExerciseWildFarm.Animals.Birds
{
    public abstract class Bird : Animal
    {
        public Bird(string name, 
            double weight, HashSet<string> allowedFoods, 
            double weightModifier, 
            double wingSize) 
            : base(name, weight, allowedFoods, weightModifier)
        {
            WingSize = wingSize;
        }

        public double WingSize { get; private set; }
        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}
