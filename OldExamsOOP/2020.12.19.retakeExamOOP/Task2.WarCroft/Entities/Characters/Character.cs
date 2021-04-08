using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
		// TODO: Implement the rest of the class.

		private string name;

        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
			BaseHealth = health;
			BaseArmor = armor;

			Name = name;
			Health = health;
			Armor = armor;
			AbilityPoints = abilityPoints;
			Bag = bag;
        }

		public string Name 
		{
			get => name;
			private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
					throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }
				name = value;
            }
		}

		public double BaseHealth { get; private set; }
		public double Health { get; set; }
		public double BaseArmor { get; private set; }
		public double Armor { get; private set; }
		public double AbilityPoints  { get; private set; }
		public Bag Bag { get; set; }
		public bool IsAlive { get; set; } = true;

		public void TakeDamage(double hitPoints)
        {
			EnsureAlive();

            if (Armor >= hitPoints)
            {
				Armor -= hitPoints;
			}
            else if (hitPoints > Armor)
            {
				hitPoints -= Armor;
				Armor = 0;
				Health -= hitPoints;
			}

            if (Health <= 0)
            {
				Health = 0;
				IsAlive = false;
            }
        }

		public void UseItem(Item item)
        {
			EnsureAlive();
			item.AffectCharacter(this);
		}

		protected void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}
	}
}