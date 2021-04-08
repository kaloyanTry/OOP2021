using System;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Warrior : Character, IAttacker
    {
        private const int InitialHealth = 100;
        private const int InitialArmor = 50;
        private const int InitialAbility = 40;

        public Warrior(string name) 
            : base(name, InitialHealth, InitialArmor, InitialAbility, new Satchel())
        {
        }

        public void Attack(Character character)
        {
            EnsureAlive();
            if (Name == character.Name)
            {
                throw new InvalidOperationException(ExceptionMessages.CharacterAttacksSelf);
            }
            character.TakeDamage(AbilityPoints);      
        }
    }
}
