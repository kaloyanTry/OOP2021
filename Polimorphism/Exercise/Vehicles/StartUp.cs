using System;

namespace ExerciseVehicles
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Vehicle car = CreateVehicle();
            Vehicle truck = CreateVehicle();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] parts = Console.ReadLine().Split();

                string command = parts[0];
                string vehicleType = parts[1];
                double parameter = double.Parse(parts[2]);

                if (command == "Drive")
                {
                    try
                    {
                        if (vehicleType == nameof(Car))
                        {
                            car.Drive(parameter);
                        }
                        else
                        {
                            truck.Drive(parameter);
                        }

                        Console.WriteLine($"{vehicleType} travelled {parameter} km");

                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    if (vehicleType == nameof(Car))
                    {
                        car.Refuel(parameter);
                    }
                    else
                    {
                        truck.Refuel(parameter);
                    }
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }

        private static Vehicle CreateVehicle()
        {
            string[] parts = Console.ReadLine().Split();
            string type = parts[0];
            double fuelQuantity = double.Parse(parts[1]);
            double fuelConsumption = double.Parse(parts[2]);

            Vehicle vehicle = null;

            if (type == nameof(Car))
            {
                vehicle = new Car(fuelQuantity, fuelConsumption);

            }
            else if (type == nameof(Truck))
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption);

            }
            return vehicle;
        }
    }
}
