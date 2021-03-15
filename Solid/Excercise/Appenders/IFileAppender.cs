using ConsoleLogger.Enums;
using ConsoleLogger.LogFiles;

namespace ConsoleLogger.Appenders
{
    public interface IFileAppender
    {
        ILogFile File { get; set; }

        void Append(string date, ReportLevel level, string message);
        string ToString();
    }
}