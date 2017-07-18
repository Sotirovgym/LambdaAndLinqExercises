using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

class RegisteredUsers
{
    static void Main()
    {
        var usersAndDate = new Dictionary<string, DateTime>();

        var input = Console.ReadLine();

        while (input != "end")
        {
            var tokens = input.Split(new[] { ' ', '-', '>' },StringSplitOptions.RemoveEmptyEntries);
            var user = tokens[0];
            var date = DateTime.ParseExact(tokens[1], "dd/MM/yyyy", CultureInfo.InvariantCulture);
           
            usersAndDate[user] = date;
            
            input = Console.ReadLine();
        }

        var orderedUsers = usersAndDate
            .Reverse()
            .OrderBy(x => x.Value)
            .Take(5)
            .OrderByDescending(x => x.Value)
            .ToDictionary(x => x.Key, x => x.Value);

        foreach (var kvp in orderedUsers)
        {
            Console.WriteLine(kvp.Key);
        }
    }
}

