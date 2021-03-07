﻿using System;

namespace Pizza
{
    class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = String.Empty;
                if (tokens.Length == 2)
                {
                    name = tokens[1];
                }
                Pizza pizza = new Pizza(name);

                tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string flourType = tokens[1];
                string bakingTechnique = tokens[2];
                double weight = double.Parse(tokens[3]);
                Dough dough = new Dough(flourType, bakingTechnique, weight);
                pizza.Dough = dough;

                tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                while (tokens[0] != "END")
                {
                    string toppingType = tokens[1];
                    double toppingWeight = double.Parse(tokens[2]);
                    Topping topping = new Topping(toppingType, toppingWeight);
                    pizza.AddTopping(topping);

                    tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                }
                Console.WriteLine(pizza.ToString());
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
