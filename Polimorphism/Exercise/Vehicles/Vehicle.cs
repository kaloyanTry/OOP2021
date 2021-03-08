using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciseVehicles
{
    public abstract class Vehicle
    {
        protected Vehicle(double fuel, double fuelConsumption, double airConditionerModifier)
        {
            Fuel = fuel;
            FuelConsumption = fuelConsumption;
            AirConditionerModifier = airConditionerModifier;
        }
        private double AirConditionerModifier { get; set; }

        public double Fuel { get; private set; }

        public double FuelConsumption { get; private set; }

        public void Drive(double distance)
        {
            double requiredFuel = (FuelConsumption+ AirConditionerModifier) * distance;

            if (requiredFuel > this.Fuel)
            {
                throw new InvalidOperationException($"{GetType().Name} needs refueling");
            }
            Fuel -= requiredFuel;
        }

        public virtual void Refuel(double amount)
        {
            Fuel += amount;
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {Fuel:F2}";
        }
    }
}
