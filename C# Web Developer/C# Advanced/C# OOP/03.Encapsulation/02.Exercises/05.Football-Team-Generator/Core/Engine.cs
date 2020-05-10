using System;
using System.Collections.Generic;
using System.Linq;
using _05.Football_Team_Generator.Common;
using _05.Football_Team_Generator.Models;

namespace _05.Football_Team_Generator.Core
{
    public class Engine
    {
        private List<Team> teams;

        public Engine()
        {
            this.teams = new List<Team>();
        }

        public void Run()
        {
            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] commandArgs = command.Split(";", StringSplitOptions.None).ToArray();

                    string cmdType = commandArgs[0];

                    if (cmdType == "Team")
                    {
                        AddTeam(commandArgs);
                    }
                    else if (cmdType == "Add")
                    {
                        AddPlayerToTeam(commandArgs);
                    }
                    else if (cmdType == "Remove")
                    {
                        RemovePlayer(commandArgs);
                    }
                    else if (cmdType == "Rating")
                    {
                        PrintRating(commandArgs);
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }
        }

        private void PrintRating(string[] commandArgs)
        {
            string teamName = commandArgs[1];

            this.ValidateTeamExists(teamName);

            Team team = this.teams.First(t => t.Name == teamName);

            Console.WriteLine(team);
        }

        private void RemovePlayer(string[] commandArgs)
        {
            string teamName = commandArgs[1];
            string playerName = commandArgs[2];

            this.ValidateTeamExists(teamName);
            Team team = this.teams.First(t => t.Name == teamName);

            team.RemovePlayer(playerName);
        }

        private void AddPlayerToTeam(string[] commandArgs)
        {
            string teamName = commandArgs[1];
            string playerName = commandArgs[2];

            this.ValidateTeamExists(teamName);

            Team team = this.teams.First(t => t.Name == teamName);

            Stats stats = this.CreateStats(commandArgs.Skip(2).ToArray());

            Player player = new Player(playerName, stats);

            team.AddPlayer(player);
        }

        private Stats CreateStats(string[] cmdArgs)
        {
            int endurance = int.Parse(cmdArgs[0]);
            int sprint = int.Parse(cmdArgs[1]);
            int dribble = int.Parse(cmdArgs[2]);
            int passing = int.Parse(cmdArgs[3]);
            int shooting = int.Parse(cmdArgs[4]);

            Stats stats = new Stats(endurance, sprint, dribble, passing, shooting);

            return stats;
        }

        private void ValidateTeamExists(string name)
        {
            if (!this.teams.Any(t => t.Name == name))
            {
                throw new ArgumentException(string.Format(GlobalConstants.MissingTeamExceptionMessage, name));
            }
        }

        private void AddTeam(string[] commandArgs)
        {
            string teamName = commandArgs[1];

            Team team = new Team(teamName);

            this.teams.Add(team);
        }
    }
}