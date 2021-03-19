using System;

namespace PizzaCalories
{
    public class Topping
    {
        private string toppingTypes;
        private double weight;

        public Topping(string toppingType, double weight)
        {
            ToppingType = toppingType;
            Weight = weight;
        }

        public string ToppingType 
        {
            get => toppingTypes;
            private set
            {
                string toppingLower = value.ToLower();
                if (toppingLower != "meat" && toppingLower != "veggies" && toppingLower != "cheese" && toppingLower != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                toppingTypes = value.ToLower();

            } 
        }

        public double Weight
        {
            get => weight;
            private set
            {
                if (value <= 0 || value > 50)
                {
                    string type = Char.ToUpper(ToppingType[0]) + ToppingType.Substring(1);
                    throw new ArgumentException($"{type} weight should be in the range [1..50].");
                }
                weight = value;
            }           
        }

        public double Calories { get => GetCalories();  }

        private double GetCalories()
        {
            double toppingModifier = 0;

            if (ToppingType == "meat")
            {
                toppingModifier = 1.2;
            }
            else if (ToppingType == "veggies")
            {
                toppingModifier = 0.8;
            }
            else if (ToppingType == "cheese")
            {
                toppingModifier = 1.1;
            }
            else if (ToppingType == "sauce")
            {
                toppingModifier = 0.9;
            }

            return 2 * (toppingModifier * Weight);
        }
    }
}
