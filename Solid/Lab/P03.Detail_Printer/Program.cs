using System.Collections.Generic;

namespace P03.DetailPrinter
{
    public class Program
    {
        static void Main()
        {
            List<IEmployee> employees = new List<IEmployee>();

            IEmployee employee = new Employee("Vanio");
            IEmployee manager = new Manager("Gosho", new string[] { "Document Word", "Document Exel", "Document .txt" });
            IEmployee quixote = new DonQuixote("Don Quixote");

            employees.Add(employee);
            employees.Add(manager);
            employees.Add(quixote);

            DetailsPrinter detailsPrinter = new DetailsPrinter(employees);
            detailsPrinter.PrintDetails();
        }
    }
}
