﻿namespace IPerson
{
    class Citizen : IPerson
    {
        public Citizen(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
    }
}
