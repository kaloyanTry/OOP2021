using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCalories
{
    public class Pizza
    {
        private string namePizza;
        private Dough doughPizza;
        private List<Topping> toppingsPizza;

        public Pizza(string namePizza)
        {
            NamePizza = namePizza;
            ToppingsPizza = new List<Topping>();
        }

        public string NamePizza 
        { 
            get => namePizza;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                namePizza = value;
            }
        }
        public Dough DoughPizza
        {
            get => doughPizza; 
            set => doughPizza = value;
        }

        public List<Topping> ToppingsPizza
        {
            get => toppingsPizza;
            private set { toppingsPizza = value; }
        }

        public void AddTopping(Topping topping)
        {
            if (ToppingsPizza.Count >= 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            ToppingsPizza.Add(topping);
        }

        public double CaloriesPizza()
        {
            double caloriesTotal = DoughPizza.Calories + ToppingsPizza.Sum(t => t.Calories);

            return caloriesTotal;
        }

        public override string ToString()
        {
            return $"{NamePizza} - {CaloriesPizza():F2} Calories.";
        }
    }
}
