using System;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Vehicle car = CreateVehice();
            Vehicle truck = CreateVehice();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string command = input[0];
                string vehicleType = input[1];
                double parameter = double.Parse(input[2]);

                if (command == "Drive")
                {
                    try
                    {
                        if (vehicleType == nameof(Car))
                        {
                            car.DriveDistance(parameter);
                        }
                        else
                        {
                            truck.DriveDistance(parameter);
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

        private static Vehicle CreateVehice()
        {
            string[] infoVehicle = Console.ReadLine().Split();

            string vehicleType = infoVehicle[0];
            double fuelQuantity = double.Parse(infoVehicle[1]);
            double fuelConsumption = double.Parse(infoVehicle[2]);

            Vehicle vehicle = null;
            if (vehicleType == nameof(Car))
            {
                vehicle = new Car(fuelQuantity, fuelConsumption);
            }
            else if (vehicleType == nameof(Truck))
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption);
            }

            return vehicle;
        }
    }
}
