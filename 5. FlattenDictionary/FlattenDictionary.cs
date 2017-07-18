using System;
using System.Collections.Generic;
using System.Linq;

class FlattenDictionary
{
    static void Main()
    {
        var productsData = new Dictionary<string, Dictionary<string, string>>();

        var input = Console.ReadLine();

        while (input != "end")
        {
            var tokens = input.Split(' ');

            if (tokens[0] != "flatten")
            {
                var key = tokens[0];
                var innerKey = tokens[1];
                var innerValue = tokens[2];

                if (!productsData.ContainsKey(key))
                {
                    productsData[key] = new Dictionary<string, string>();
                }

                productsData[key][innerKey] = innerValue;
            }
            else
            {
                var key = tokens[1];

                productsData[key] = productsData[key].ToDictionary(x => x.Key + x.Value, x => "flattened");
            }
                        
            input = Console.ReadLine();
        }

        var orderedKeys = productsData
            .OrderByDescending(x => x.Key.Length)
            .ToDictionary(x => x.Key, x => x.Value);

        foreach (var innerKeys in orderedKeys)
        {
            var orderedInnerKeys = innerKeys.Value
                .Where(x => x.Value != "flattened")
                .OrderBy(x => x.Key.Length)
                .ToDictionary(x => x.Key, x => x.Value);

            var flattenedKeys = innerKeys.Value
                .Where(x => x.Value == "flattened")
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine($"{innerKeys.Key}");

            var count = 0;

            foreach (var innerKvp in orderedInnerKeys)
            {
                count++;

                Console.WriteLine($"{count}. {innerKvp.Key} - {innerKvp.Value}");
            }

            foreach (var flattenedKey in flattenedKeys)
            {
                count++;
                Console.WriteLine($"{count}. {flattenedKey.Key}");
            }
        }
    }
}

