using EasterRaces.Models.Cars.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace EasterRaces.Repositories.Contracts
{
    public class CarRepository : IRepository<ICar>
    {
    
        private readonly List<ICar> cars;

        public CarRepository()
        {
            cars = new List<ICar>();
        }

        public void Add(ICar model) => cars.Add(model);

        public IReadOnlyCollection<ICar> GetAll() => cars.ToList();

        public ICar GetByName(string name)
        {
            ICar car = cars.FirstOrDefault(c => c.Model == name);
            return car;
        }

        public bool Remove(ICar model) => cars.Remove(model);
    }
}
