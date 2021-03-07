using System;
using System.Collections.Generic;
using System.Linq;

namespace Pizza
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name)
        {
            Name = name;
            Toppings = new List<Topping>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (String.IsNullOrEmpty(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }
        public Dough Dough
        {
            get { return dough; }
            set { dough = value; }
        }
        public List<Topping> Toppings
        {
            get { return toppings; }
            private set { toppings = value; }
        }

        public void AddTopping(Topping topping)
        {
            if (Toppings.Count > 9)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            Toppings.Add(topping);
        }

        private double Calories()
        {
            return Dough.Calories + Toppings.Sum(t => t.Calories);
        }
        public override string ToString()
        {
            return $"{Name} - {Calories():F2} Calories.";
        }
    }
}