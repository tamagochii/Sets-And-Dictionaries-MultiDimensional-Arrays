using System;
using System.Collections.Generic;
using System.Linq;
namespace Legendary_Farming
{
    class Program
    {
        static void Main()
        {
            //Acquire one of these three legendaries 
            //⦁	Shadowmourne – requires 250 Shards;
            //⦁	Valanyr – requires 250 Fragments;
            //⦁	Dragonwrath – requires 250 Motes;

            var KeyItems = new Dictionary<string, long>();
            var JunkItems = new Dictionary<string, long>();

            KeyItems.Add("shards", 0);
            KeyItems.Add("fragments", 0);
            KeyItems.Add("motes", 0);

            while (true)
            {
                //⦁	All materials are case-insensitive.
                //⦁	All output should be lowercase, except the first letter of the legendary
                //check! if it has problems
                var Input = Console.ReadLine()
                            .ToLower()
                            .Split(new[] { ' ', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < Input.Length - 1; i += 2)
                {
                    var AmountResource = long.Parse(Input[i]);
                    var NameResource = Input[i + 1];

                    if (NameResource == "shards" || NameResource == "motes"
                        || NameResource == "fragments")
                    {
                        KeyItems[NameResource] += AmountResource;

                        //when one of the three key items reaches 250 or more print on a new line {Legendary} obtained
                        if (KeyItems[NameResource] >= 250)
                        {
                            Print(KeyItems, JunkItems, NameResource);
                            return;
                        }
                    }
                    else
                    {
                        if (!JunkItems.ContainsKey(NameResource))
                        {
                            JunkItems.Add(NameResource, 0);
                        }

                        JunkItems[NameResource] += AmountResource;
                    }
                }
            }
        }

        static void Print(Dictionary<string, long> KeyItems, Dictionary<string, long> JunkItems, string WinningResource)
        {
            if (WinningResource == "fragments")
            {
                Console.WriteLine("Valanyr obtained!");
            }
            else if (WinningResource == "shards")
            {
                Console.WriteLine("Shadowmourne obtained!");
            }
            else if (WinningResource == "motes")
            {
                Console.WriteLine("Dragonwrath obtained!");
            }

            //on the next 3 lines prin the  shards,motes and fragments in a descending order



            KeyItems[WinningResource] -= 250;
            if (KeyItems.Values.Distinct().Count() != 3)
            {//if 2 of 3 key materials have the same value print them in alphabetical order
                KeyItems = KeyItems.OrderBy(x => x.Key)
                                   .ToDictionary(x => x.Key, x => x.Value);
            }

            KeyItems = KeyItems.OrderByDescending(x => x.Value)
                                          .ToDictionary(x => x.Key, x => x.Value);

            foreach (var keyItem in KeyItems.Keys)
            {
                Console.WriteLine($"{keyItem}: {KeyItems[keyItem]}");
            }

            JunkItems = JunkItems.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);


            foreach (var junkItem in JunkItems.Keys)
            {
                Console.WriteLine($"{junkItem}: {JunkItems[junkItem]}");
            }
        }
    }
}
