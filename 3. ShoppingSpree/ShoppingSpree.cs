using System;
using System.Collections.Generic;
using System.Linq;

class ShoppingSpree
{
    static void Main()
    {
        var products = new Dictionary<string, double>();

        var budget = double.Parse(Console.ReadLine());

        var input = Console.ReadLine();

        while (input != "end")
        {
            var tokens = input.Split(' ');
            var product = tokens[0];
            var prices = double.Parse(tokens[1]);

            if (! products.ContainsKey(product))
            {
                products[product] = prices;
            }
            else
            {
                if (products[product] > prices)
                {
                    products[product] = prices;
                }
            }

            input = Console.ReadLine();
        }

        var sumOfProducts = products.Values.Sum();

        if (sumOfProducts <= budget)
        {
            var orderedProducts = products
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key.Length)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in orderedProducts)
            {
                Console.WriteLine($"{kvp.Key} costs {kvp.Value:f2}");
            }
        }
        else
        {
            Console.WriteLine($"Need more money... Just buy banichka");
        }
    }
}

