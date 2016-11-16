using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            var Text = Console.ReadLine();
            var KeepSymbolOccurances = new Dictionary<char, int>();

            for (int i = 0; i < Text.Length; i++)
            {
                if (!KeepSymbolOccurances.ContainsKey(Text[i]))
                {
                    KeepSymbolOccurances.Add(Text[i], 0);
                }

                KeepSymbolOccurances[Text[i]]++;
            }

            KeepSymbolOccurances = KeepSymbolOccurances
                .OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var symbol in KeepSymbolOccurances.Keys)
            {
                Console.WriteLine($"{symbol}: {KeepSymbolOccurances[symbol]} time/s");
            }

        }
    }
}
