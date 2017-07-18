using System;
using System.Collections.Generic;
using System.Linq;

class CottageScraper
{
    static void Main()
    {
        var treesInfo = new Dictionary<string, List<int>>();
        var input = Console.ReadLine();

        while (input != "chop chop")
        {
            var tokens = input.Split(new[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries);

            var treeType = tokens[0];
            var treeHeight = int.Parse(tokens[1]);

            if (! treesInfo.ContainsKey(treeType))
            {
                treesInfo[treeType] = new List<int>();
            }

            treesInfo[treeType].Add(treeHeight);

            input = Console.ReadLine();
        }

        input = Console.ReadLine();
        var atLeastHeight = int.Parse(Console.ReadLine());

        decimal sum = 0;
        decimal treeCount = 0;

        foreach (var tree in treesInfo)
        {
            treeCount += tree.Value.Count;

            var heightSum = tree.Value.Sum();
            sum += heightSum;
        }

        decimal averagePrice = Math.Round(sum / treeCount, 2);

        decimal usedLogs = 0;
        decimal unusedLogs = 0;

        foreach (var tree in treesInfo)
        {
            if (tree.Key == input)
            {
                foreach (var height in tree.Value)
                {
                    if (height >= atLeastHeight)
                    {
                        usedLogs += height;
                    }
                    else
                    {
                        unusedLogs += height;
                    }
                }
            }
            else
            {
                foreach (var height in tree.Value)
                {
                    unusedLogs += height;
                }
            }
        }

        var usedLogsPrice = Math.Round(usedLogs * averagePrice, 2);
        var unusedLogsPrice = Math.Round(unusedLogs * averagePrice * 0.25m, 2);
        var subtotal = Math.Round(usedLogsPrice + unusedLogsPrice, 2);

        Console.WriteLine($"Price per meter: ${averagePrice}");
        Console.WriteLine($"Used logs price: ${usedLogsPrice}");
        Console.WriteLine($"Unused logs price: ${unusedLogsPrice}");
        Console.WriteLine($"CottageScraper subtotal: ${subtotal}");
    }
}

