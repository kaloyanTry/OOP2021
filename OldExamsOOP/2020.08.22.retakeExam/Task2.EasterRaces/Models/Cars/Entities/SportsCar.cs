using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar : Car
    {
        private const int InitialCubicCentimeters = 3000;
        private const int InitialMinHorsePower = 250;
        private const int InitialMaxHorsePower = 450;

        public SportsCar(string model, int horsePower) 
            : base(model, horsePower, InitialCubicCentimeters, InitialMinHorsePower, InitialMaxHorsePower)
        {
        }
    }
}
