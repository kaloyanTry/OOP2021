using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciseVehicles
{
    public abstract class Vehicle
    {
        private double fuel;
        protected Vehicle(double fuel, double fuelConsumption, double tankCapacity, double airConditionerModifier)
        {
            TankCapacity = tankCapacity;
            Fuel = fuel;
            FuelConsumption = fuelConsumption;
            AirConditionerModifier = airConditionerModifier;
        }
        private double AirConditionerModifier { get; set; }

        public double Fuel 
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

        public void Drive(double distance)
        {
            double requiredFuel = (FuelConsumption + AirConditionerModifier) * distance;

            if (requiredFuel > Fuel)
            {
                throw new InvalidOperationException($"{GetType().Name} needs refueling");
            }
            Fuel -= requiredFuel;
        }

        public virtual void Refuel(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (Fuel + amount > TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {amount} fuel in the tank");
            }
            Fuel += amount;
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {Fuel:F2}";
        }
    }
}
