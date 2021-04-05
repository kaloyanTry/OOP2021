using EasterRaces.Models.Cars.Contracts;
using System;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private string model;
        private int horsePower;

        protected Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            Model = model;
            HorsePower = horsePower;
            CubicCentimeters = cubicCentimeters;
            MinHorsePower = minHorsePower;
            MaxHorsePower = maxHorsePower;
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

        public int MinHorsePower { get; private set; }

        public int MaxHorsePower { get; private set; }

        public int HorsePower
        {
            get => horsePower;
            private set
            {
                if (horsePower < MinHorsePower && horsePower > MaxHorsePower)
                {
                    throw new ArgumentException($"Invalid horse power: {horsePower}.");
                }
                horsePower = value;
            }
        }

        public double CubicCentimeters{ get; private set; }

        public double CalculateRacePoints(int laps) => CubicCentimeters / HorsePower * laps;
    }
}
