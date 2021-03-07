using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonInfo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<IBirthable> birthables = new List<IBirthable>();

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "End")
                {
                    break;
                }

                string[] data = line.Split();
                string type = data[0];

                if (type == nameof(Citizen))
                {
                    string name = data[1];
                    int age = int.Parse(data[2]);
                    string id = data[3];
                    string birthdate = data[4];

                    birthables.Add(new Citizen(name, age, id, birthdate));
                }
                else if(type == nameof(Pet))
                {
                    string name = data[1];
                    string birthdate = data[2];

                    birthables.Add(new Pet(name, birthdate));
                }
            }

            string criteriaBirthdate = Console.ReadLine();

            List<IBirthable> result = birthables.Where(i => i.Birthdate.EndsWith(criteriaBirthdate)).ToList();

            foreach (var item in result)
            {
                Console.WriteLine(item.Birthdate);
            }
        }
    }
}
