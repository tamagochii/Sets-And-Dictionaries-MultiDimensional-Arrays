using System;
using System.Collections.Generic;
using System.Linq;

namespace Hand_Of_Cards
{
    class Program
    {
        static void Main()
        {
            //everyone has a deck in which there are no repeated cards ,if we draws such discard it 
            //after that calculate the total sum for the player in terms of card paint 2 : A -> 2:14 multiplied
            //by types way (S -> 4, H-> 3, D -> 2, C -> 1).


            var PlayersAndDecks = new Dictionary<string, List<string>>();

            var Input = Console.ReadLine();

            while (Input != "JOKER")
            {
                var UserInfo = Input
                    .Split(new[] { ' ', ':', ','}, StringSplitOptions.RemoveEmptyEntries)
                    .Distinct()
                    .ToArray();

                var PlayerName = Input.Substring(0, Input.IndexOf(':'));

                if (!PlayersAndDecks.ContainsKey(PlayerName))
                {
                    PlayersAndDecks.Add(PlayerName, new List<string>());
                    PlayersAndDecks[PlayerName].AddRange(UserInfo.Skip(1).Take(UserInfo.Length - 1));
                }
                else //check for repated cards
                {
                    for (int i = 1; i < UserInfo.Length; i++) //start from the first card(1)
                    {
                        if (!PlayersAndDecks[PlayerName].Contains(UserInfo[i]))
                        {
                            PlayersAndDecks[PlayerName].Add(UserInfo[i]);
                        }
                    }
                }

                Input = Console.ReadLine();
            }

            EvaluateDecks(PlayersAndDecks);
        }

        static void EvaluateDecks(Dictionary<string, List<string>> PlayersAndDecks)
        {
            foreach (var player in PlayersAndDecks.Keys)
            {
                var deck = PlayersAndDecks[player];
                var SumPlayer = 0;
                for (int i = 0; i < deck.Count; i++) //evaluate the player score
                {
                    if (deck[i].Length > 2) //the power is 10
                    {
                        SumPlayer += 10 * Types(deck[i][2]);
                    }
                    else
                    {
                        SumPlayer += Powers(deck[i][0]) * Types(deck[i][1]);
                    }
                }

                Console.WriteLine($"{player}: {SumPlayer}");
            }
        }

        static int Powers(char Power)
        {
            switch (Power)
            {
                case '2': return 2;
                case '3': return 3;
                case '4': return 4;
                case '5': return 5;
                case '6': return 6;
                case '7': return 7;
                case '8': return 8;
                case '9': return 9;
                case 'J': return 11;
                case 'Q': return 12;
                case 'K': return 13;
                case 'A': return 14;
            }

            return 0;
        }

        static int Types(char Type)
        {
            switch (Type)
            {
                case 'S': return 4;
                case 'H': return 3;
                case 'D': return 2;
                case 'C': return 1;
            }

            return 0;
        }
    }
}
