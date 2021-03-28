namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar : Car
    {
        private const int InitialCubicCentimeters = 3000;
        private const int InitialHorsePowerMin = 250;
        private const int InitialHorsePowerMax = 450;

        public SportsCar(string model, int horsePower) 
            : base(model, horsePower, InitialCubicCentimeters, InitialHorsePowerMin, InitialHorsePowerMax)
        {
        }
    }
}
