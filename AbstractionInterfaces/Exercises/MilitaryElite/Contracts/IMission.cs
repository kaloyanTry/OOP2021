namespace MilitaryElite.Contracts
{
    using Enums;
    public interface IMission
    {
        string CodeName { get; }
        MissionState MissionState { get; }

        void CompleteMission();
    }
}
