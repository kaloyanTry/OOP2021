using System;

namespace EasterRaces.Models.Drivers.Entities
{
    using EasterRaces.Models.Cars.Contracts;
    using EasterRaces.Models.Drivers.Contracts;
    using EasterRaces.Utilities.Messages;

    public class Driver : IDriver
    {
        private string name;

        public Driver(string name)
        {
            Name = name;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidName);
                }
                name = value;
            }
        }
        public ICar Car { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate => Car != null;

        public void AddCar(ICar car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(ExceptionMessages.CarInvalid);
            }

            Car = car;
        }

        public void WinRace() => NumberOfWins++;
    }
}
