using ConsoleLogger.Enums;
using ConsoleLogger.LogFiles;
using System;

namespace ConsoleLogger.Appenders
{
    public class FileAppender : Appender
    {
        public FileAppender(ILayout layout)
        : base(layout)
        {
        }

        public ILogFile File { get; set; }

        public override void Append(string date, ReportLevel level, string message)
        {
            if (level >= ReportLevel)
            {
                this.File.Write(String.Format(Layout.Format, date, level, message));
                this.MessagesCount++;
            }
        }

        public override string ToString()
        {
            return base.ToString() + $", File size: {this.File.Size}";
        }
    }
}
