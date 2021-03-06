namespace MilitaryElite.Models
{
    using Contracts;
    using Enums;
    using System;
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {

        protected SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, Corps corps)
            : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }
     
        public Corps Corps { get; private set; }

        public override string ToString()
        {
            return $"{base.ToString()}" + Environment.NewLine +
                   $"Corps: {this.Corps}";
        }
    }
}
