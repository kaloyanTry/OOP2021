using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciseVehicles
{
    public class Truck : Vehicle
    {
        private const double TruckAirModifier =  1.6;

        public Truck(double fuel, double fuelConsumption, double tankCapacity)
            : base(fuel, fuelConsumption, tankCapacity, TruckAirModifier)
        {

        }

        public override void Refuel(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (Fuel + amount > TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {amount} fuel in the tank");
            }
            Fuel += amount * 0.95;
        }

    }
}
