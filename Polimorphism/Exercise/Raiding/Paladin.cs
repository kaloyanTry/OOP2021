namespace RaidingExcercise
{
    public class Paladin : BaseHero
    {
        private const int BasePower = 100;
        public Paladin(string name) : base(name, BasePower)
        {
        }

        public override string CastAbility()
        {
            return $"{nameof(Paladin)} - {Name} healed for {Power}";
        }
    }
}
