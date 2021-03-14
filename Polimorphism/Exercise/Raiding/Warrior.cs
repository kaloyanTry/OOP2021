﻿namespace RaidingExcercise
{
    public class Warrior : BaseHero
    {
        private const int BasePower = 100;
        public Warrior(string name) : base(name, BasePower)
        {
        }

        public override string CastAbility()
        {
            return $"{nameof(Warrior)} - {Name} hit for {Power} damage";
        }
    }
}
