using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace EasterRaces.Repositories
{
    public class CarRepository : IRepository<ICar>
    {
        private readonly List<ICar> races;

        public CarRepository()
        {
            races = new List<ICar>();
        }

        public void Add(ICar model) => races.Add(model);

        public IReadOnlyCollection<ICar> GetAll() => races;

        public ICar GetByName(string name) => races.FirstOrDefault(c => c.Model == name);

        public bool Remove(ICar model) => races.Remove(model);
    }
}
