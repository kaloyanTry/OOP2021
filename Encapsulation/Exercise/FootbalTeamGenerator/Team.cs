using System;
using System.Collections.Generic;
using System.Linq;

namespace FootbalTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            Name = name;
            players = new List<Player>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }

        public IReadOnlyCollection<Player> Players => players.AsReadOnly();

        private int Rating => (Players.Count != 0) ? (int)Math.Round(Players.Sum(p => p.Skill) / Players.Count) : 0;


        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            if (!Players.Any(p => p.Name == playerName))
            {
                throw new ArgumentException($"Player {playerName} is not in {Name} team.");
            }
            players.Remove(players.First(p => p.Name == playerName));
        }

        public override string ToString()
        {
            return $"{Name} - {Rating}";
        }
    }
}
