using System;

namespace PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string backingTechnique, double weight)
        {
            FlourType = flourType;
            BackingTechnique = backingTechnique;
            Weight = weight;
        }

        public string FlourType
        {
            get => flourType;
            private set
            {
                string flour = value.ToLower();
                if (flour != "white" && flour != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                flourType = value.ToLower();
            }
        }
        public string BackingTechnique
        {
            get => bakingTechnique; 
            private set
            {
                string technique = value.ToLower();
                if (technique != "crispy" && technique != "chewy" && technique != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                bakingTechnique = value.ToLower();
            }
        }

        public double Weight
        {
            get => weight;
            private set
            {
                if (value <= 0 || value > 200)
                {
                    Console.WriteLine("Dough weight should be in the range [1..200].");
                }
                weight = value;
            }
        }

        public double Calories
        {
            get => GetCalories();
        }

        private double GetCalories()
        {
            double flourModifier = 0;

            if (FlourType == "white")
            {
                flourModifier = 1.5;
            }
            else if (FlourType == "wholegrain")
            {
                flourModifier = 1.0;
            }

            double backingModifier = 0;
            if (BackingTechnique == "crispy")
            {
                backingModifier = 0.9;
            }
            else if (BackingTechnique == "chewy")
            {
                backingModifier = 1.1;
            }
            else if (BackingTechnique == "homemade")
            {
                backingModifier = 1.0;
            }

            return (2 * Weight) * flourModifier * backingModifier;
        }
    }
}
