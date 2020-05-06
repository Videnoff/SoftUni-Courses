using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            // Vlogger -> Followers
            Dictionary<string, SortedSet<string>> vloggerWithFollowers = new Dictionary<string, SortedSet<string>>();

            // Vlogger -> Following
            Dictionary<string, SortedSet<string>> vloggerWithHisFollowings = new Dictionary<string, SortedSet<string>>();

            string command;

            while ((command = Console.ReadLine()) != "Statistics")
            {
                ProcessInput(command, vloggerWithFollowers, vloggerWithHisFollowings);
            }

            // Output

            vloggerWithFollowers = vloggerWithFollowers.OrderByDescending(kvp => kvp.Value.Count) 
                // This is the count of following
                .ThenBy(kvp => vloggerWithHisFollowings[kvp.Key].Count).ToDictionary(a => a.Key, b => b.Value);

            int cnt = 1;

            Console.WriteLine($"The V-Logger has a total of {vloggerWithFollowers.Count} vloggers in its logs.");

            var mostFamousVlogger = vloggerWithFollowers.First();
            string mostFamousVloggerName = mostFamousVlogger.Key;
            SortedSet<string> mostFamousVloggerFollowers = mostFamousVlogger.Value;

            Console.WriteLine($"{cnt++}. {mostFamousVloggerName} : {mostFamousVloggerFollowers.Count} followers, {vloggerWithHisFollowings[mostFamousVloggerName].Count} following");

            foreach (var follower in mostFamousVloggerFollowers)
            {
                Console.WriteLine($"*  {follower}");
            }

            foreach (var vloggerFollowersPair in vloggerWithFollowers.Skip(1))
            {
                string name = vloggerFollowersPair.Key;
                SortedSet<string> followers = vloggerFollowersPair.Value;

                Console.WriteLine($"{cnt++}. {name} : {followers.Count} followers, {vloggerWithHisFollowings[name].Count} following");
            }

        }

        private static void ProcessInput(string command, Dictionary<string, SortedSet<string>> vloggerWithFollowers, Dictionary<string, SortedSet<string>> vloggerWithHisFollowings)
        {
            var commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            string cmdType = commandArgs[1];

            if (cmdType == "joined")
            {
                JoinVlogger(commandArgs, vloggerWithFollowers, vloggerWithHisFollowings);
            }
            else if (cmdType == "followed")
            {
                Follow(commandArgs, vloggerWithHisFollowings, vloggerWithFollowers);
            }
        }

        private static void Follow(string[] commandArgs, Dictionary<string, SortedSet<string>> vloggerWithHisFollowings, Dictionary<string, SortedSet<string>> vloggerWithFollowers)
        {
            string follower = commandArgs[0];
            string toBeFollowed = commandArgs[2];

            if (follower != toBeFollowed)
            {
                if (vloggerWithHisFollowings.ContainsKey(follower) && vloggerWithFollowers.ContainsKey(toBeFollowed))
                {
                    vloggerWithFollowers[toBeFollowed].Add(follower);
                    vloggerWithHisFollowings[follower].Add(toBeFollowed);
                }
            }
        }

        private static void JoinVlogger(string[] commandArgs, Dictionary<string, SortedSet<string>> vloggerWithFollowers,
            Dictionary<string, SortedSet<string>> vloggerWithHisFollowings)
        {
            string vloggerToJoin = commandArgs[0];

            if (!vloggerWithFollowers.ContainsKey(vloggerToJoin))
            {
                vloggerWithFollowers[vloggerToJoin] = new SortedSet<string>();
                vloggerWithHisFollowings[vloggerToJoin] = new SortedSet<string>();
            }
        }
    }
}
