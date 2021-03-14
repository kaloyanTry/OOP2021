namespace P03.DetailPrinter
{
    public class DonQuixote : IEmployee
    {
        public DonQuixote(string name)
        {
            Name = name;
        }

        public string Name  { get; private set; }

        public override string ToString()
        {
            return $"{Name} works only with Dulcinea";
        }
    }
}
