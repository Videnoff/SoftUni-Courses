using System;
using System.Linq;
using System.Collections.Generic;

namespace TeamworkProjects
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int teamCount = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>();

            for (int i = 0; i < teamCount; i++)
            {
                string[] userTeam = Console.ReadLine().Split('-');

                var currentTeam = new Team();

                string creator = userTeam[0];
                string teamName = userTeam[1];

                currentTeam.Creator = creator;
                currentTeam.Name = teamName;

                if (teams.Any(x => x.Name == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                }

                if (teams.Any(x => x.Creator == creator))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                    continue;
                }

                teams.Add(currentTeam);
                Console.WriteLine($"Team {teamName} has been created by {creator}!");
            }

            string command;

            while ((command = Console.ReadLine()) != "end of assignment")
            {
                string[] secondInput = command.Split(new string[] { "->" }, StringSplitOptions.None);
                string user = secondInput[0];
                string wantedTeam = secondInput[1];

                if (!teams.Any(x => x.Name == wantedTeam))
                {
                    Console.WriteLine($"Team {wantedTeam} does not exist!");
                    continue;
                }

                if (teams.Any(x => x.Creator == user) || teams.Any(x => x.Members.Contains(user)))
                {
                    Console.WriteLine($"Member {user} cannot join team {wantedTeam}!");
                    continue;
                }

                if (teams.Any(x => x.Name == wantedTeam))
                {
                    var existingTeam = teams.First(x => x.Name == wantedTeam);

                    existingTeam.Members.Add(user);
                }
            }

            var teamsDisband = teams.Where(x => x.Members.Count == 0).Select(x => x.Name).ToList();

            foreach (var team in teams.OrderByDescending(x => x.Members.Count).ThenBy(x => x.Name))
            {
                if (team.Members.Count == 0)
                {
                    continue;
                }

                Console.WriteLine($"{team.Name}");
                Console.WriteLine($"- {team.Creator}");

                foreach (var name in team.Members.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {name}");
                }
            }

            Console.WriteLine("Teams to disband:");

            foreach (var item in teamsDisband.OrderBy(x => x))
            {
                Console.WriteLine(item);
            }
        }
    }

    class Team
    {
        public string Creator { get; set; }
        public string Name { get; set; }
        public List<string> Members = new List<string>();

        public Team(string creator, string teamName)
        {
            this.Creator = creator;
            this.Name = teamName;
        }

        public Team(string creator, string teamName, List<string> members)
        {
            this.Creator = creator;
            this.Name = teamName;
            this.Members = members;
        }

        public Team()
        {
            
        }
    }
}
