using CommandPattern.Core.Contracts;

namespace CommandPattern.Core.Commands
{
    class HelloCommand : ICommand
    {
        public string Execute(string[] args)
        {
            string name = args[1];
            return $"Hello, {name}";
        }
    }
}
