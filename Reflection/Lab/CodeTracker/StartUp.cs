using System;

namespace AuthorProblem
{
    [AuthorAttribute("Kaloyan")]
    public class StartUp
    {
        [AuthorAttribute("Georgi")]
        static void Main(string[] args)
        {
            var tracer = new Tracker();
            tracer.PrintMethodsByAuthor();
        }
    }
}
