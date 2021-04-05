using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Repositories.Entities;
using System;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
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
            var driver = driverRepository.GetByName(driverName);
            if (driver == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }

            var car = carRepository.GetByName(carModel);
            if (car == null)
            {
                throw new InvalidOperationException($"Car {carModel} could not be found.");
            }

            driver.AddCar(car);

            return $"Driver {driverName} received car {carModel}.";
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            var race = raceRepository.GetByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            var driver = driverRepository.GetByName(driverName);
            if (driver == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }

            race.AddDriver(driver);

            return $"Driver {driverName} added in {raceName} race.";
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            var existingCar = carRepository.GetByName(model);
            if (existingCar != null)
            {
                throw new ArgumentException($"Car {model} is already created.");
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
            return $"{car.GetType().Name} {model} is created.";
        }

        public string CreateDriver(string driverName)
        {
            var existingDriver = driverRepository.GetByName(driverName);
            if (existingDriver != null)
            {
                throw new ArgumentException($"Driver {driverName} is already created.");
            }

            var driver = new Driver(driverName);
            driverRepository.Add(driver);

            return $"Driver {driverName} is created.";
        }

        public string CreateRace(string name, int laps)
        {
            var existingRace = raceRepository.GetByName(name);
            if (existingRace != null)
            {
                throw new InvalidOperationException($"Race {name} is already created.");
            }

            var race = new Race(name, laps);
            raceRepository.Add(race);

            return $"Race {name} is created."; 
        }

        public string StartRace(string raceName)
        {
            var startingRace = raceRepository.GetByName(raceName);

            var firstThree = startingRace.Drivers.OrderByDescending(d => d.Car.CalculateRacePoints(startingRace.Laps)).ToList();

            var first = firstThree[0];
            var second = firstThree[1];
            var third = firstThree[2];

            if (startingRace == null)
            {
                throw new InvalidOperationException($"Race {startingRace.GetType().Name} could not be found.");
            }
            else if (startingRace.Drivers.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }

            raceRepository.Remove(startingRace);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Driver {first.Name} wins {startingRace.Name} race.");
            sb.AppendLine($"Driver {second.Name} wins {startingRace.Name} race.");
            sb.AppendLine($"Driver {third.Name} wins {startingRace.Name} race.");

            return sb.ToString().TrimEnd();
        }
    }
}
