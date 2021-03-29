using System;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private string model;
        private int horsePower;
        private readonly double cubicCentimeters;

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
                    throw new ArgumentException(ExceptionMessages.InvalidModel);
                }
                model = value;
            }
        }

        public int MinHorsePower { get; }

        public int MaxHorsePower { get; }
        
        public int HorsePower
        {
            get => horsePower;
            private set
            {
                if (value < MinHorsePower || value > MaxHorsePower)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidHorsePower);
                }
                horsePower = value;
            }
        }

        public double CubicCentimeters { get; }

        public double CalculateRacePoints(int laps)
        {
            return cubicCentimeters / horsePower * laps;
        }
    }
}
