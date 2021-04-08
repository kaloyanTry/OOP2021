using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Priest : Character, IHealer
    {
        private const int InitialHealth = 50;
        private const int InitialArmor = 25;
        private const int InitialAbility = 40;

        public Priest(string name) 
            : base(name, InitialHealth, InitialArmor, InitialAbility, new Backpack())
        {
        }

        public void Heal(Character character)
        {
            EnsureAlive();
            character.Health += AbilityPoints;
        }
    }
}
