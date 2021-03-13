using System;

namespace _1.Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Vehicle car = CreateVehicle();
            Vehicle truck = CreateVehicle();
            Vehicle bus = CreateVehicle();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string command = input[0];
                string type = input[1];
                double parameter = double.Parse(input[2]);

                try
                {
                    if (type == nameof(Car))
                    {
                        PocessCommand(car, command, parameter);
                    }
                    else if (type == nameof(Truck))
                    {
                        PocessCommand(truck, command, parameter);
                    }
                    else if (type == nameof(Bus))
                    {
                        PocessCommand(bus, command, parameter);
                    }
                }
                catch (Exception ex)
                    when (ex is InvalidOperationException || ex is ArgumentException)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }


        private static void PocessCommand(Vehicle vehicle, string command, double parameter)
        {
            if (command == "Drive")
            {
                vehicle.Drive(parameter);

                Console.WriteLine($"{vehicle.GetType().Name} travelled {parameter} km");
            }
            else if (command == "DriveEmpty")
            {
                ((Bus)vehicle).DriveEmpty(parameter);
                Console.WriteLine($"{vehicle.GetType().Name} travelled {parameter} km");
            }
            else if (command == "Refuel")
            {
                vehicle.Refuel(parameter);
            }
        }
        private static Vehicle CreateVehicle()
        {
            string[] infoVehicle = Console.ReadLine().Split();
            string type = infoVehicle[0];
            double quantity = double.Parse(infoVehicle[1]);
            double liters = double.Parse(infoVehicle[2]);
            double tankCapacity = double.Parse(infoVehicle[3]);

            Vehicle vehicle = null;

            if (type == nameof(Car))
            {
                vehicle = new Car(quantity, liters, tankCapacity);
            }
            else if(type == nameof(Truck))
            {
                vehicle = new Truck(quantity, liters, tankCapacity);
            }
            else if (type == nameof(Bus))
            {
                vehicle = new Bus(quantity, liters, tankCapacity);
            }

            return vehicle;
        }
    }
}
