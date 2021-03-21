using System;
using System.Collections.Generic;
using System.Linq;

namespace TeamGenerator
{
    public class Engine
    {
        private readonly List<Team> teams;

        public Engine()
        {
            teams = new List<Team>();
        }

        public void Run()
        {
            string[] data = Console.ReadLine().Split(';');
            while (data[0] != "END")
            {
                string command = data[0];
                string teamName = data[1];

                if (command == "Team")
                {
                    if (!TeamExists(teamName))
                    {
                        teams.Add(new Team(teamName));
                    }                 
                }
                else if (command == "Add")
                {
                    if (!TeamExists(teamName))
                    {
                        Console.WriteLine($"Team {teamName} does not exist.");
                    }
                    else
                    {
                        Team team = teams.FirstOrDefault(t => t.TeamName == teamName);
                        try
                        {  
                            Stats stats = new Stats(int.Parse(data[3]), int.Parse(data[4]), int.Parse(data[5]), int.Parse(data[6]), int.Parse(data[7]));
                            
                            Player player = new Player(data[2], stats);

                            team.AddPlayer(player);
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
                else if (command == "Remove")
                {
                    if (TeamExists(teamName))
                    {
                        Team team = teams.First(t => t.TeamName == teamName);
                        try
                        {
                            team.RemovePlayer(data[2]);
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
                else if (command == "Rating")
                {
                    if (!TeamExists(teamName))
                    {
                        Console.WriteLine($"Team {teamName} does not exist.");
                    }
                    else
                    {
                        Console.WriteLine(teams.First(t => t.TeamName == teamName).ToString());
                    }
                }

                data = Console.ReadLine().Split(';');
            }
        }

        private bool TeamExists(string teamName)
        {
            return teams.Any(t => t.TeamName == teamName);
        }
    }
}
