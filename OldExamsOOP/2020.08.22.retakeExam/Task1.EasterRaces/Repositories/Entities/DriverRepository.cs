using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : IRepository<IDriver>
    {
        private readonly List<IDriver> races;

        public DriverRepository()
        {
            races = new List<IDriver>();
        }

        public void Add(IDriver model) => races.Add(model);

        public IReadOnlyCollection<IDriver> GetAll() => races;

        public IDriver GetByName(string name) => races.FirstOrDefault(d => d.Name == name);

        public bool Remove(IDriver model) => races.Remove(model);
    }
}
