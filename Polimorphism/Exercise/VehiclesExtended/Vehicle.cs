using System;

namespace _1.Vehicles
{
    public abstract class Vehicle
    {
        private double fuel;
        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity, double airModifier)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            AirModifier = airModifier;
        }
        private double AirModifier { get; set; }
        public double FuelQuantity 
        { 
            get => fuel;
            protected set
            {
                if (value > TankCapacity)
                {
                    fuel = 0;
                }
                else
                {
                    fuel = value;
                }
            }
        }
        public double FuelConsumption { get; private set; }
        public double TankCapacity { get; private set; }

        public void Drive (double distance)
        {
            double fuelNeeded = (FuelConsumption + AirModifier) * distance;
            if (FuelQuantity < fuelNeeded)
            {
                throw new InvalidOperationException($"{GetType().Name} needs refueling");
            }
            FuelQuantity -= fuelNeeded;
        }

        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (FuelQuantity + liters > TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {liters} fuel in the tank");
            }

            FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {FuelQuantity:F2}"; 
        }
    }
}
