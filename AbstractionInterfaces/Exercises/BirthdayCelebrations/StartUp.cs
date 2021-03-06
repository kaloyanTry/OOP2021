using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBirthable> birthable = new List<IBirthable>();

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "End")
                {
                    break;
                }

                string[] parts = line.Split();

                string type = parts[0];

                if (type == nameof(Citizen))
                {
                    string name = parts[1];
                    int age = int.Parse(parts[2]);
                    string id = parts[3];
                    string bithdate = parts[4];

                    birthable.Add(new Citizen(name, age, id, bithdate));
                }
                else if (type == nameof(Pet))
                {
                    string name = parts[1];
                    string bithdate = parts[2];

                    birthable.Add(new Pet(name, bithdate));
                }
            }

            string filterYear = Console.ReadLine();

            List<IBirthable> filtred = birthable.Where(i => i.Birthdate.EndsWith(filterYear)).ToList();

            foreach (var birthab in filtred)
            {
                Console.WriteLine(birthab.Birthdate);
            }
        }
    }
}
