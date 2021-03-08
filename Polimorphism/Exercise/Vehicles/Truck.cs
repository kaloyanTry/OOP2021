using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciseVehicles
{
    public class Truck : Vehicle
    {
        private const double TruckAirModifier =  1.6;

        public Truck(double fuel, double fuelConsumption)
            : base(fuel, fuelConsumption, TruckAirModifier)
        {

        }

        public override void Refuel(double amount)
        {
            base.Refuel(amount * 0.95);
        }

    }
}
