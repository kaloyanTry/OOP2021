using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var persons = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                var inputData = Console.ReadLine().Split();
                Person person = new Person(inputData[0], inputData[1], int.Parse(inputData[2]));
                persons.Add(person);
            }

            persons.OrderBy(p => p.FirstName)
                .ThenBy(p => p.Age).ToList()
                .ForEach(p => Console.WriteLine(p.ToString()));
        }
    }
}
