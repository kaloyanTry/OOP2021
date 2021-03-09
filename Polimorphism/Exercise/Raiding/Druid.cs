namespace ExerciseRaiding
{
    public class Druid : BaseHero
    {
        private const int BasePower = 80;
        public Druid(string name) 
            : base(name, BasePower)
        {
        }

        public override string CastAbillity()
        {
            return $"{nameof(Druid)} - { Name} healed for { Power}";
        }
    }
}
