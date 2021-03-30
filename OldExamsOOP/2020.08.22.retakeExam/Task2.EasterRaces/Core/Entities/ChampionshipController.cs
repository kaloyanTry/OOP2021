using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EasterRaces.Core.Entities
{
    using EasterRaces.Core.Contracts;
    using EasterRaces.Models.Cars.Contracts;
    using EasterRaces.Models.Cars.Entities;
    using EasterRaces.Models.Drivers.Contracts;
    using EasterRaces.Models.Drivers.Entities;
    using EasterRaces.Models.Races.Contracts;
    using EasterRaces.Models.Races.Entities;
    using EasterRaces.Repositories;
    using EasterRaces.Repositories.Contracts;
    using EasterRaces.Repositories.Entities;
    using EasterRaces.Utilities.Messages;

    public class ChampionshipController : IChampionshipController
    {
        private readonly IRepository<IDriver> driverRepository;
        private readonly IRepository<ICar> carRepository;
        private readonly IRepository<IRace> raceRepository;

        public ChampionshipController()
        {
            driverRepository = new DriverRepository();
            carRepository = new CarRepository();
            raceRepository = new RaceRepository();
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            var car = carRepository.GetByName(carModel);
            var driver = driverRepository.GetByName(driverName);

            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            if (car == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }

            driver.AddCar(car);

            //return $"Driver {driverName} receied car {carModel}.";
            var message = string.Format(OutputMessages.CarAdded, driverName, carModel);
            return message;
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            var race = raceRepository.GetByName(raceName);
            var driver = driverRepository.GetByName(driverName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            race.AddDriver(driver);

            //return $"Driver {driverName} added in {raceName} race.";
            var message = string.Format(OutputMessages.DriverAdded, driverName, raceName);
            return message;
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            var carExist = carRepository.GetByName(model);

            if (carExist != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model));
            }

            ICar car = null;
            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }
            else if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }

            carRepository.Add(car);

            //return $"{car.GetType().Name} {model} is created.";

            var message = string.Format(OutputMessages.CarCreated, type, model);
            return message;
        }

        public string CreateDriver(string driverName)
        {
            var driverExists = driverRepository.GetByName(driverName);

            if (driverExists != null)
            {
                //throw new ArgumentException($"Driver {driverName} is already created.");
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
            }

            var driver = new Driver(driverName);

            driverRepository.Add(driver);

            //return $"Driver {driverName} is created.";
            var message = string.Format(OutputMessages.DriverCreated, driverName);
            return message;
        }

        public string CreateRace(string name, int laps)
        {
            if (raceRepository.GetByName(name) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            var race = new Race(name, laps);

            raceRepository.Add(race);

            //return $"Race {name} is created.";
            var message = string.Format(OutputMessages.RaceCreated, name);
            return message;
        }

        public string StartRace(string raceName)
        {
            var race = raceRepository.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            else if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            var drivers = race.Drivers.OrderByDescending(d => d.Car.CalculateRacePoints(race.Laps)).ToList();

            var first = drivers[0];
            var second = drivers[1];
            var third = drivers[2];

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Driver {first.Name} wins {race.Name} race.");
            sb.AppendLine($"Driver {second.Name} is second in {race.Name} race.");
            sb.AppendLine($"Driver {third.Name} is third in {race.Name} race.");

            //raceRepository.Remove(race);
            return sb.ToString().TrimEnd();
        }
    }
}
