namespace _1.Vehicles
{
    public class Car : Vehicle
    {
        private const double CarAirModifier = 0.9;
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity, CarAirModifier)
        {
        }
    }
}
