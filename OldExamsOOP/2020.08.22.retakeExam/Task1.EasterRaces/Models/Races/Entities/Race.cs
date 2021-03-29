using System;
using System.Collections.Generic;
using System.Linq;

namespace EasterRaces.Models.Races.Entities
{
    using EasterRaces.Models.Drivers.Contracts;
    using EasterRaces.Models.Races.Contracts;
    using EasterRaces.Utilities.Messages;

    public class Race : IRace
    {
        private string name;
        private int laps;
        private readonly List<IDriver> drivers;

        public Race(string name, int laps)
        {
            Name = name;
            Laps = laps;
            drivers = new List<IDriver>();
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

        public int Laps
        {
            get => laps;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfLaps);
                }
                laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers => drivers;

        public void AddDriver(IDriver driver)
        {
            if (driver == null)
            {
                throw new ArgumentNullException(ExceptionMessages.DriverInvalid);
            }
            else if (!driver.CanParticipate)
            {
                throw new ArgumentException(ExceptionMessages.DriverNotParticipate);
            }
            else if (drivers.Any(d => d.Name == driver.Name))
            {
                throw new ArgumentNullException(ExceptionMessages.DriverAlreadyAdded);
            }

            drivers.Add(driver);
        }
    }
}