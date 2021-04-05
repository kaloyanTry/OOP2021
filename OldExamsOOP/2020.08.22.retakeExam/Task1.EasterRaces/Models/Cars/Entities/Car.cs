using EasterRaces.Models.Cars.Contracts;
using System;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private string model;
        private int horsePower;
        private double cubicCentimeters;
        private int minHorsePower;
        private int maxHorsePower;

        protected Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            Model = model;
            HorsePower = horsePower;
            CubicCentimeters = cubicCentimeters;
            this.minHorsePower = minHorsePower;
            this.maxHorsePower = maxHorsePower;
        }

        public string Model
        {
            get => model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    throw new ArgumentException($"Model {model} cannot be less than 4 symbols.");
                }
                model = value;
            }
        }

        public int HorsePower
        {
            get => horsePower;
            private set
            {
                if (horsePower < minHorsePower && horsePower > maxHorsePower)
                {
                    throw new ArgumentException($"Invalid horse power: {horsePower}.");
                }
                horsePower = value;
            }
        }

        public double CubicCentimeters{ get; private set; }

        public double CalculateRacePoints(int laps)
        {
            return cubicCentimeters / horsePower * laps;
        }
    }
}
