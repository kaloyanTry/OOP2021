using System;

namespace Vehicles
{
    public abstract class Vehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption, double airConditionerModifier)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            AirConditionerModifier = airConditionerModifier;
        }

        private double AirConditionerModifier { get; set; }
        public double FuelQuantity { get; private set; }
        public double FuelConsumption { get; private set; }

        public void DriveDistance(double distance)
        {
            double fuelRequired = (FuelConsumption + AirConditionerModifier) * distance;

            if (fuelRequired > FuelQuantity)
            {
                throw new InvalidOperationException($"{GetType().Name} needs refueling");
            }

            FuelQuantity -= fuelRequired;
        }

        public virtual void Refuel(double amount)
        {
            FuelQuantity += amount;
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {FuelQuantity:F2}";
        }
    }
}
