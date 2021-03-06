namespace MilitaryElite.Contracts
{
    using System.Collections.Generic;
    public interface ICommando
    {
        IReadOnlyCollection<IMission> Missions { get; }

        void AddMission(IMission mission);
    }
}
