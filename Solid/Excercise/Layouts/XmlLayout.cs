using System.Text;

namespace ConsoleLogger.Layouts
{
    class XmlLayout : ILayout
    {
        public string Format 
        { 
            get
            {
                StringBuilder builder = new StringBuilder();

                builder.AppendLine("<log>")
                .AppendLine("   <date>{0}</date>")
                .AppendLine("   <level>{1}</level>")
                .AppendLine("   <message>{2}</message>")
                .Append("</log>");

                return builder.ToString();
            }
        }

    }
}
