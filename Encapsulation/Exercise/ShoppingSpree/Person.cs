using System;
using System.Collections.Generic;
using System.Linq;

namespace Spree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            products = new List<Product>();
        }

        public string Name
        {
            get => name; 
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }
        public decimal Money
        {
            get => money;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }
        public List<Product> Products
        {
            get => products;
        }

        public void AddProduct(Product product)
        {
            if (product.Cost > Money)
            {
                Console.WriteLine($"{Name} can't afford {product.Name}");
                return;
            }
            products.Add(product);
            Money -= product.Cost;
            Console.WriteLine($"{Name} bought {product.Name}");
        }
        public override string ToString()
        {
            if (this.Products.Count == 0)
            {
                return $"{Name} - Nothing bought";
            }
            else
            {
                return $"{Name} - {string.Join(", ", Products.Select(p => p.Name))}";
            }
        }
    }
}