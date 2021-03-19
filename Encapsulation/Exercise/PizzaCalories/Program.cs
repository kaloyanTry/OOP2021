using System;

namespace PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                string[] dataPizza = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string typePizza = string.Empty;
                if (dataPizza.Length == 2)
                {
                    typePizza = dataPizza[1];
                }

                Pizza pizza = new Pizza(typePizza);


                dataPizza = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string flourType = dataPizza[1];
                string backingTechnique = dataPizza[2];
                double weight = double.Parse(dataPizza[3]);

                Dough dough = new Dough(flourType, backingTechnique, weight);
                pizza.DoughPizza = dough;

                dataPizza = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                while (dataPizza[0] != "END")
                {
                    string toppingType = dataPizza[1];
                    double toppingWeight = double.Parse(dataPizza[2]);
                    
                    Topping topping = new Topping(toppingType, toppingWeight);
                    pizza.AddTopping(topping);

                    dataPizza = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
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
