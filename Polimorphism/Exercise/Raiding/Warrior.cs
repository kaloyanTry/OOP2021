namespace ExerciseRaiding
{
    public class Warrior : BaseHero
    {
        private const int BasePower = 100;
        public Warrior(string name) : base(name, BasePower)
        {
        }

        public override string CastAbillity()
        {
            return$"{nameof(Warrior)} - {Name} hit for {Power} damage" ;
        }
    }
}
