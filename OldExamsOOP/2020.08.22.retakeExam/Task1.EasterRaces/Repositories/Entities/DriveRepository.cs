using System.Collections.Generic;
using System.Linq;

namespace EasterRaces.Repositories.Entities
{
    using EasterRaces.Models.Drivers.Contracts;
    using EasterRaces.Repositories.Contracts;

    public abstract class DriverRepository : IRepository<IDriver>
    {
        private readonly List<IDriver> races;

        public DriverRepository()
        {
            races = new List<IDriver>();
        }

        public void Add(IDriver model) => races.Add(model);

        public IReadOnlyCollection<IDriver> GetAll() => races;

        public IDriver GetByName(string name) => races.FirstOrDefault(r => r.Name == name);

        public bool Remove(IDriver model) => races.Remove(model);
    }
}
