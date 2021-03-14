namespace RaidingExcercise
{
    public class Rogue : BaseHero
    {
        private const int BasePower = 80;
        public Rogue(string name) : base(name, BasePower)
        {
        }

        public override string CastAbility()
        {
            return $"{nameof(Rogue)} - {Name} hit for {Power} damage";
        }
    }
}
