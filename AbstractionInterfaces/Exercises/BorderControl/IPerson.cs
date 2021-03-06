namespace PersonInfo
{
    public interface IPerson : IIdentifiable
    {
        public string Name { get; }
        public int Age { get; }
    }
}
