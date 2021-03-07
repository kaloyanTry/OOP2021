using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza
{
    public class Topping
    {
        private string toppingType;
        private double weight;

        public Topping(string toppingType, double weight)
        {
            ToppingType = toppingType;
            Weight = weight;
        }
        public string ToppingType
        {
            get { return toppingType; }
            private set
            {
                string topping = value.ToLower();
                if (topping != "meat" && topping != "veggies" && topping != "cheese" && topping != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                toppingType = value.ToLower();
            }
        }
        public double Weight
        {
            get { return weight; }
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
        public double Calories
        {
            get { return this.GetCalories(); }
        }

        private double GetCalories()
        {
            double toppingModifier = 0;
            switch (ToppingType)
            {
                case "meat":
                    toppingModifier = 1.2;
                    break;
                case "veggies":
                    toppingModifier = 0.8;
                    break;
                case "cheese":
                    toppingModifier = 1.1;
                    break;
                case "sauce":
                    toppingModifier = 0.9;
                    break;
            }

            return 2 * (Weight * toppingModifier);
        }
    }
}