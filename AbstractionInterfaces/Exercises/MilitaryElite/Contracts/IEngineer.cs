namespace MilitaryElite.Contracts
{
    using System.Collections.Generic;
    public interface IEngineer
    {
        IReadOnlyCollection<IRepair> Repairs { get; }

        void AddRepair(IRepair repair);
    }
}
