using System;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var numberOfPeople = int.Parse(Console.ReadLine());

            var team = new Team("SoftUni");

            while (numberOfPeople > 0)
            {
                var input = Console.ReadLine().Split();

                var person = new Person(input[0], input[1], int.Parse(input[2]), decimal.Parse(input[3]));
                team.AddPlayer(person);

                numberOfPeople--;
            }

            Console.WriteLine($"First team have {team.FirstTeam.Count} players");
            Console.WriteLine($"Reserve team have {team.ReserveTeam.Count} players");
        }
    }
}
