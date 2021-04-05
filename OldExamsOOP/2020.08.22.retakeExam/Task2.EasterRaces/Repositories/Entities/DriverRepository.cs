using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace EasterRaces.Repositories.Entities
{
    class DriverRepository : IRepository<IDriver>
    {
        private readonly List<IDriver> drivers;

        public DriverRepository()
        {
            drivers = new List<IDriver>();
        }
        public void Add(IDriver model) => drivers.Add(model);

        public IReadOnlyCollection<IDriver> GetAll() => drivers.ToList();

        public IDriver GetByName(string name)
        {
            IDriver driver = drivers.FirstOrDefault(d => d.Name == name);
            return driver;
        }

        public bool Remove(IDriver model) => drivers.Remove(model);
    }
}
