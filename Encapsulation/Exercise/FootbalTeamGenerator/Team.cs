using System;
using System.Collections.Generic;
using System.Linq;

namespace TeamGenerator
{
    public class Team
    {
        private string teamName;
        private readonly List<Player> players;

        public Team(string teamName)
        {
            TeamName = teamName;
            players = new List<Player>();
        }

        public string TeamName
        {
            get => teamName;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                teamName = value;
            }
        }

        public IReadOnlyCollection<Player> Players => players.AsReadOnly();

        private int Rating => (Players.Count != 0) ? (int)Math.Round(Players.Sum(p => p.SkillLevel) / Players.Count) : 0;

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            if (!players.Any(p => p.Name == playerName))
            {
                throw new ArgumentException($"Player {playerName} is not in {TeamName} team.");
            }
            players.Remove(players.First(p => p.Name == playerName));
        }

        public override string ToString()
        {
            return $"{TeamName} - {Rating}";
        }
    }
}
