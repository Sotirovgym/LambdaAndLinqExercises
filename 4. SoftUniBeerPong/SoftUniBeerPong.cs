using System;
using System.Collections.Generic;
using System.Linq;

class SoftUniBeerPong
{
    static void Main()
    {
        var teamData = new Dictionary<string, Dictionary<string, int>>();

        var input = Console.ReadLine();

        while (input != "stop the game")
        {
            var tokens = input.Split('|');

            var players = tokens[0];
            var teamName = tokens[1];
            var points = int.Parse(tokens[2]);

            if (! teamData.ContainsKey(teamName))
            {
                teamData[teamName] = new Dictionary<string, int>();
            }

            if (teamData[teamName].Count < 3)
            {
                teamData[teamName][players] = points;
            }

            input = Console.ReadLine();
        }

        var orderedTeams = teamData
            .OrderByDescending(x => x.Value.Values.Sum())
            .ToDictionary(x => x.Key, x => x.Value);

        var count = 0;

        foreach (var kvp in orderedTeams)
        {
            var team = kvp.Key;
            var players = kvp.Value;

            var orderedPlayers = players
                .OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);

            if (orderedPlayers.Count == 3)
            {
                count++;
                Console.WriteLine($"{count}. {team}; Players:");

                foreach (var item in orderedPlayers)
                {
                    Console.WriteLine($"###{item.Key}: {item.Value}");
                }
            }
        }
    }
}

