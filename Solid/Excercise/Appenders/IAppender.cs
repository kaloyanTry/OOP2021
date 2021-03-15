using ConsoleLogger.Enums;

namespace ConsoleLogger
{
    public interface IAppender
    {
        ILayout Layout { get; }

        void Append(string date, ReportLevel level, string message);

        ReportLevel ReportLevel { get; set; }
    }
}
