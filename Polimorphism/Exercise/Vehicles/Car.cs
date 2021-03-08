using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciseVehicles
{
    public class Car : Vehicle
    {
        private const double CarAirModifier = 0.9;

        public Car(double fuel, double fuelConsumption)
            : base(fuel, fuelConsumption, CarAirModifier)
        {

        }
    }
}
