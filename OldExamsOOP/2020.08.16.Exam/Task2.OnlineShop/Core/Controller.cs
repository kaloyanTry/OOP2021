using System;
using System.Collections.Generic;
using System.Linq;

using OnlineShop.Common.Constants;
using OnlineShop.Common.Enums;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private readonly List<IComputer> computers;
        private readonly List<IComponent> components;
        private readonly List<IPeripheral> peripherals;

        public Controller()
        {
            computers = new List<IComputer>();
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            if (components.Any(c => c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }

            if (!IsValidComponent(componentType))
            {
                throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }

            EnsureExistence(computerId);

            IComponent component = null;

            switch (componentType)
            {
                case "CentralProcessingUnit":
                    component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "Motherboard":
                    component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "PowerSupply":
                    component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "RandomAccessMemory":
                    component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "SolidStateDrive":
                    component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "VideoCard":
                    component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
                    break;
            }

            computers.First(c => c.Id == computerId).AddComponent(component);
            components.Add(component);

            return string.Format(SuccessMessages.AddedComponent, component.GetType().Name, component.Id, computerId);
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (computers.Any(c => c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            if (!IsValidComputer(computerType))
            {
                throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }

            IComputer computer = null;

            switch (computerType)
            {
                case "DesktopComputer":
                    computer = new DesktopComputer(id, manufacturer, model, price);
                    break;
                case "Laptop":
                    computer = new Laptop(id, manufacturer, model, price);
                    break;
            }

            computers.Add(computer);

            return string.Format(SuccessMessages.AddedComputer, id);
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            if (peripherals.Any(p => p.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }

            if (!IsValidPeriferial(peripheralType))
            {
                throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }

            EnsureExistence(computerId);

            IPeripheral peripheral = null;
            switch (peripheralType)
            {
                case "Headset":
                    peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case "Keyboard":
                    peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case "Monitor":
                    peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case "Mouse":
                    peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
            }


            this.computers.First(c => c.Id == computerId).AddPeripheral(peripheral);
            this.peripherals.Add(peripheral);

            return string.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);
        }

        public string BuyBest(decimal budget)
        {
            if (this.computers.Count == 0 || this.computers.All(c => c.Price > budget))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }

            var comp = this.computers
                            .Where(c => c.Price <= budget)
                            .OrderByDescending(c => c.OverallPerformance)
                            .FirstOrDefault();
            if (comp != null)
            {
                this.computers.Remove(comp);
                return comp.ToString();
            }

            return null;
        }

        public string BuyComputer(int id)
        {
            EnsureExistence(id);
            var comp = computers.First(c => c.Id == id);
            if (computers.Remove(comp))
            {
                return comp.ToString();
            }

            return null;
        }

        public string GetComputerData(int id)
        {
            EnsureExistence(id);
            var comp = computers.First(c => c.Id == id);

            return comp.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            EnsureExistence(computerId);

            var comp = computers.First(c => c.Id == computerId);
            var component = comp.Components.FirstOrDefault(c => c.GetType().Name == componentType);
            comp.RemoveComponent(componentType);

            if (components.Remove(component))
            {
                return string.Format(SuccessMessages.RemovedComponent, componentType, component.Id);
            }

            return null;
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            EnsureExistence(computerId);
            var comp = this.computers.First(c => c.Id == computerId);
            var periferial = comp.Peripherals.FirstOrDefault(c => c.GetType().Name == peripheralType);
            comp.RemovePeripheral(peripheralType);
            if (this.peripherals.Remove(periferial))
            {
                return string.Format(SuccessMessages.RemovedPeripheral, peripheralType, periferial.Id);
            }

            return null;
        }

        private bool IsValidComponent(string componentType)
        {
            return Enum.TryParse(componentType, out ComponentType type);
        }

        private bool IsValidComputer(string computerType)
        {
            return Enum.TryParse(computerType, out ComputerType type);
        }

        private bool IsValidPeriferial(string peripheralType)
        {
            return Enum.TryParse(peripheralType, out PeripheralType result);
        }

        private void EnsureExistence(int computerId)
        {
            if (computers.FirstOrDefault(c => c.Id == computerId) == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
        }
    }
}