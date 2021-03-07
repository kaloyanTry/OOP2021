using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonInfo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Dictionary<string, IBuyer> buyersByName = new Dictionary<string, IBuyer>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();

                if (data.Length == 3)
                {
                    string name = data[0];
                    int age = int.Parse(data[1]);
                    string group = data[2];

                    buyersByName[name] = new Rebel(name, age, group);

                }
                else
                {
                    string name = data[0];
                    int age = int.Parse(data[1]);
                    string id = data[2];
                    string birthdate = data[3];

                    buyersByName[name] = new Citizen(name, age, id, birthdate);
                }
            }

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "End")
                {
                    break;
                }

                if (!buyersByName.ContainsKey(line))
                {
                    continue;
                }

                IBuyer buyer = buyersByName[line];
                buyer.BuyFood();
            }

            var totalAmountFood = buyersByName.Values.Sum(b => b.Food);

            Console.WriteLine(totalAmountFood);
        }
    }
}
