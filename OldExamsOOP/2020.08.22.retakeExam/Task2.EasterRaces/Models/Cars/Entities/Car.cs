using System;

namespace EasterRaces.Models.Cars.Entities
{
    using EasterRaces.Utilities.Messages;
    using EasterRaces.Models.Cars.Contracts;

    public abstract class Car : ICar
    {
        private string model;
        private int horsePower;
        private double cubicCentimeters;

        protected Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            Model = model;
            HorsePower = horsePower;
            CubicCentimeters = cubicCentimeters;
        }

        public string Model
        {
            get => model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel, model, 4));
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
                if (value < MinHorsePower && value > MaxHorsePower)
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
