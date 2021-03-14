using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DetailPrinter
{
    public class Manager : Employee
    {
        private IReadOnlyCollection<string> documents;
        public Manager(string name, ICollection<string> documents) 
            : base(name)
        {
            this.documents = new List<string>(documents);
        }

        public IReadOnlyCollection<string> Documents => documents;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Documents: {String.Join(", ", Documents)}");

            return sb.ToString().TrimEnd();
        }
    }
}
