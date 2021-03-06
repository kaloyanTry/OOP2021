namespace MilitaryElite.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Contracts;
    using Enums;
    public class Commando : SpecialisedSoldier, ICommando
    {
        private List<IMission> missions;

        public Commando(int id, string firstName, string lastName, decimal salary, Corps corps, params IMission[] missions)
            : base(id, firstName, lastName, salary, corps)
        {
            this.missions = new List<IMission>(missions);
        }

        public IReadOnlyCollection<IMission> Missions => this.missions.AsReadOnly();

        public void AddMission(IMission mission)
        {
            this.missions.Add(mission);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Missions:");
            sb.Append("  " + String.Join(Environment.NewLine + "  ", this.Missions));
            return sb.ToString().TrimEnd();
        }
    }
}
