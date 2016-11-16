using System;
using System.Collections.Generic;
namespace Sets_And_Dictionaries
{
    class UniqueUsernames
    {
        static void Main(string[] args)
        {
            var NumberUsernames = int.Parse(Console.ReadLine());
            var set = new HashSet<string>();

            for (int i = 0; i < NumberUsernames; i++)
            {
                set.Add(Console.ReadLine());
            }

            Console.WriteLine(string.Join("\n", set));
        }
    }
}
