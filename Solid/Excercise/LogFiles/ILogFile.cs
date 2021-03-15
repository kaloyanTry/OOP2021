namespace ConsoleLogger.LogFiles
{
    public interface ILogFile
    {
        int Size { get; }
        void Write(string content);
    }
}
