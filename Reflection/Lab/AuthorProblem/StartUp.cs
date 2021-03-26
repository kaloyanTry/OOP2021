namespace AuthorProblem
{
    [Author("Victor")]
    [Author("Kaloyan")]
    [Author("TheTeam")]
    public class StartUp
    {
        [Author("Victor2")]
        static void Main(string[] args)
        {
            Tracker tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }

        [Author("Victor3")]
        private static void NextGen()
        {

        }
    }
}
