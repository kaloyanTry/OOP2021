namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        private const int InitialMinHorsePower = 400;
        private const int InitialMaxHorsePower = 600;
        private const int InitialCubicCentimeters = 5000;

        public MuscleCar(string model, int horsePower) 
            : base(model, horsePower, InitialCubicCentimeters, InitialMinHorsePower, InitialMaxHorsePower)
        {
        }
    }
}
