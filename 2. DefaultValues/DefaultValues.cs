using System;
using System.Collections.Generic;
using System.Linq;

class DefaultValues
{
    static void Main()
    {
        var result = new Dictionary<string, string>();
        var replacedByDefault = new Dictionary<string, string>();

        var input = Console.ReadLine();

        while (input != "end")
        {
            var tokens = input.Split(new[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries);
            var key = tokens[0];
            var value = tokens[1];

            if (! result.ContainsKey(key))
            {
                result[key] = string.Empty;
            }
            
            result[key] = value;

            input = Console.ReadLine();
        }

        input = Console.ReadLine();

        var unchangedValues = result
            .Where(x => x.Value != "null")
            .OrderByDescending(x => x.Value.Length)
            .ToDictionary(x => x.Key, x => x.Value);

        var changedValues = result
            .Where(x => x.Value == "null")
            .ToDictionary(x => x.Key, x => x.Value);

        foreach (var kvp in unchangedValues)
        {
            Console.WriteLine($"{kvp.Key} <-> {kvp.Value}");            
        }

        foreach (var kvp in changedValues)
        {
            Console.WriteLine($"{kvp.Key} <-> {input}");
        }       
    }
}

