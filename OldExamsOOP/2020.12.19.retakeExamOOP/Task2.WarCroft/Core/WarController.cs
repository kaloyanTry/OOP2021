using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
	{
		private readonly List<Item> items;
		private readonly List<Character> characters;
		
		public WarController()
		{
			items = new List<Item>();
			characters = new List<Character>();
		}

		public string JoinParty(string[] args)
		{
			var characterType = args[0];
			var name = args[1];
			Character character = null;

            if (characterType != "Warrior" && characterType != "Priest")
            {
				throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterType));
			}

            if (characterType == "Warrior")
            {
				character = new Warrior(name);
            }
            else if (characterType == "Priest")
            {
				character = new Priest(name);
            }

			characters.Add(character);

			return string.Format(SuccessMessages.JoinParty, name);
		}

		public string AddItemToPool(string[] args)
		{
			string itemName = args[0];
			Item item = null;

            if (itemName != "FirePotion" && itemName != "HealthPotion")
            {
				throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemName));
			}

            if (itemName == "FirePotion")
			{
				item = new FirePotion();
            }
            else if (itemName == "HealthPotion")
            {
				item = new HealthPotion();
            }

			items.Add(item);

			return string.Format(SuccessMessages.AddItemToPool, itemName);
		}

		public string PickUpItem(string[] args)
		{
			var characterName = args[0];
			Character character = characters.FirstOrDefault(c => c.Name == characterName);

            if (character == null)
            {
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
			}

            if (items.Count == 0)
            {
				throw new ArgumentException(ExceptionMessages.ItemPoolEmpty);
			}

			var item = items.Last();
			character.Bag.AddItem(item);
			items.RemoveAt(items.Count - 1);

			return string.Format(SuccessMessages.PickUpItem, characterName, item.GetType().Name);
		}

		public string UseItem(string[] args)
		{
			var characterName = args[0];
			var itemName = args[1];
			var character = characters.FirstOrDefault(c => c.Name == characterName);

            if (character == null)
            {
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
			}

			var item = character.Bag.GetItem(itemName);
			character.UseItem(item);

			return string.Format(SuccessMessages.UsedItem, characterName, item.GetType().Name);
		}

		public string GetStats()
		{
			StringBuilder sb = new StringBuilder();

			var charactersSorted = characters.OrderByDescending(c => c.IsAlive).ThenByDescending(c => c.Health);

            foreach (var character in charactersSorted)
            {
				string characterStatus = character.IsAlive ? "Alive" : "Dead";
				sb.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: {characterStatus}");
			}

			return sb.ToString().TrimEnd();
		}

		public string Attack(string[] args)
		{
			var attackerName = args[0];
			var receiverName = args[1];

			var attacker = characters.FirstOrDefault(c => c.Name == attackerName);
			var reciever = characters.FirstOrDefault(c => c.Name == receiverName);

			if (attacker == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
			}
			if (reciever == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiverName));
			}
			if (attacker.GetType().Name != "Warrior")
			{
				throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attackerName));
			}
			var warrior = (Warrior)attacker;
			warrior.Attack(reciever);

			StringBuilder sb = new StringBuilder();
			sb.AppendLine(string.Format(SuccessMessages.AttackCharacter, attackerName, receiverName, warrior.AbilityPoints, receiverName, reciever.Health, reciever.BaseHealth, reciever.Armor, reciever.BaseArmor));
            if (!reciever.IsAlive)
            {
				sb.AppendLine(string.Format(SuccessMessages.AttackKillsCharacter, receiverName));
            }

			return sb.ToString().TrimEnd();
		}

		public string Heal(string[] args)
		{
			var healerName = args[0];
			var healingReceiverName = args[1];

			var healer = characters.FirstOrDefault(c => c.Name == healerName);
			var reciever = characters.FirstOrDefault(c => c.Name == healingReceiverName);
			if (healer == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healer));
			}
			if (reciever == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, reciever));
			}
			if (healer.GetType().Name != "Priest")
			{
				throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, healerName));
			}
			var priest = (Priest)healer;
			priest.Heal(reciever);
			
			return string.Format(SuccessMessages.HealCharacter, healerName, healingReceiverName, healer.AbilityPoints, healingReceiverName, reciever.Health);
		}
	}
}
