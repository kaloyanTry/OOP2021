using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private readonly List<IComponent> components;
        private readonly List<IPeripheral> peripherals;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) :
            base(id, manufacturer, model, price, overallPerformance)
        {
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components => components.AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals => peripherals.AsReadOnly();

        public override double OverallPerformance
        {
            get
            {
                if (Components.Count > 0)
                {
                    double avrgPerfAll = Components.Sum(c => c.OverallPerformance) / Components.Count;
                    
                    return base.OverallPerformance + avrgPerfAll;
                }

                return base.OverallPerformance;
            }
        }

        public override decimal Price
        {
            get
            {
                decimal componetsPrice = Components.Sum(c => c.Price);
                decimal periferialPrice = Peripherals.Sum(p => p.Price);

                return base.Price + componetsPrice + periferialPrice;
            }
        }

        public void AddComponent(IComponent component)
        {
            if (Components.Any(c => c.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponent, component.GetType().Name, GetType().Name, Id));
            }

            components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (Peripherals.Any(p => p.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingPeripheral, peripheral.GetType().Name, GetType().Name, Id));
            }

            peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (Components.Count == 0 || Components.All(c => c.GetType().Name != componentType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent, componentType, GetType().Name, Id));
            }

            IComponent coomponentRemove = Components.First(c => c.GetType().Name == componentType);
            components.Remove(coomponentRemove);

            return coomponentRemove;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (Peripherals.Count == 0 || Peripherals.All(p => p.GetType().Name != peripheralType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, GetType().Name, Id));
            }

            IPeripheral peripheralRemove = Peripherals.First(p => p.GetType().Name == peripheralType);
            peripherals.Remove(peripheralRemove);

            return peripheralRemove;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());

            sb.AppendLine($" Components ({Components.Count}):");
            foreach (var component in Components)
            {
                sb.AppendLine($"  {component}");
            }

            double avgPerformance = Peripherals.Sum(p => p.OverallPerformance) / Peripherals.Count;

            string avgPerfString = Peripherals.Count == 0 ? $"{Peripherals.Count:F2}" : $"{avgPerformance:F2}";

            sb.AppendLine($" Peripherals ({Peripherals.Count}); Average Overall Performance ({avgPerfString}):");
            foreach (var peripherial in Peripherals)
            {
                sb.AppendLine($"  {peripherial}");
            }

            return sb.ToString().Trim();
        }
    }
}