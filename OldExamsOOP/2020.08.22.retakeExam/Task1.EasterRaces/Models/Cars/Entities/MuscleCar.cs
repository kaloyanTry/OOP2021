namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        private const int InitialCubicCentimeters = 5000;
        private const int InitialHorsePowerMin = 400;
        private const int InitialHorsePowerMax = 600;

        public MuscleCar(string model, int horsePower) 
            : base(model, horsePower, InitialCubicCentimeters, InitialHorsePowerMin, InitialHorsePowerMax)
        {
        }

        public MuscleCar(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower) : base(model, horsePower, cubicCentimeters, minHorsePower, maxHorsePower)
        {
        }
    }
}
