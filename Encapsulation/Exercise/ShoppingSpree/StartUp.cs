using System;
using System.Collections.Generic;
using System.Linq;

namespace Spree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();

            string[] inputPersons = Console.ReadLine().Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < inputPersons.Length; i += 2)
            {
                string name = inputPersons[i];
                decimal money = decimal.Parse(inputPersons[i + 1]);

                try
                {
                    Person person = new Person(name, money);
                    persons.Add(person);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
            }

            List<Product> products = new List<Product>();

            string[] inputProducts = Console.ReadLine().Split(new char[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < inputProducts.Length; i += 2)
            {
                string name = inputProducts[i];
                decimal cost = decimal.Parse(inputProducts[i + 1]);

                try
                {
                    Product product = new Product(name, cost);
                    products.Add(product);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
            }

            string[] inputOrder = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            while (inputOrder[0] != "END")
            {
                string ordererName = inputOrder[0];
                string orderedProduct = inputOrder[1];

                Product product = products.FirstOrDefault(p => p.Name == orderedProduct);

                persons.FirstOrDefault(p => p.Name == ordererName).AddProduct(product);

                inputOrder = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (Person person in persons)
            {
                Console.WriteLine(person.ToString());
            }
        }
    }
}
