using System;

namespace Bakery.Models.Drinks
{
    using Bakery.Models.Drinks.Contracts;

    public abstract class Drink : IDrink
    {
        private string name;
        private int portion;
        private decimal price;
        private string brand;

        protected Drink(string name, int portion, decimal price, string brand)
        {
            Name = name;
            Portion = portion;
            Price = price;
            Brand = brand;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or white space!");
                }
                name = value;
            }
        }

        public int Portion
        {
            get => portion;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Portion cannot be less or equal to zero");

                }
                portion = value;
            }
        }


        public decimal Price
        {
            get => price;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price cannot be less or equal to zero!");
                }
                price = value;
            }
        }

        public string Brand
        {
            get => brand;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Brand cannot be null or white space!");
                }
            }
        }

        public override string ToString()
        {
            return $"{GetType().Name} {Brand} - {Portion}ml - {Price:F2}lv"; 
        }
    }
}
