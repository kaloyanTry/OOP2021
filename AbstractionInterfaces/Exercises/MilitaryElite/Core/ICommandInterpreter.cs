namespace MilitaryElite.Core
{
    public interface ICommandInterpreter
    {
        string Read(string[] args);
    }
}
