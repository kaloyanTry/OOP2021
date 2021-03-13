using System;

namespace _1.Vehicles
{
    public class Bus : Vehicle
    {
        private const double BusAirModifier = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity, BusAirModifier)
        {
        }

        public void DriveEmpty(double distance)
        {
            double fuelNeeded = FuelConsumption * distance;

            if (fuelNeeded > FuelQuantity)
            {
                throw new InvalidOperationException($"{GetType().Name} needs refueling");
            }
            FuelQuantity -= fuelNeeded;
        }
    }
}
