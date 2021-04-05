namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar : Car
    {
        private const int InitialMinHorsePower = 250;
        private const int InitialMaxHorsePower = 450;
        private const int InitialCubicCentimeters = 3000;

        public SportsCar(string model, int horsePower)
            : base(model, horsePower, InitialCubicCentimeters, InitialMinHorsePower, InitialMaxHorsePower)
        {
        }
    }
}
