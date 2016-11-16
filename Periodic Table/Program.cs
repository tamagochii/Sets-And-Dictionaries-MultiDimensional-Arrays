using System;
using System.Collections.Generic;
using System.Linq;

namespace Periodic_Table
{
    class Program
    {
        static void Main()
        {

            int NumberOfElements = int.Parse(Console.ReadLine());
            var PeriodicTable = new HashSet<string>();

            for (int i = 0; i < NumberOfElements; i++)
            {
                var Elements = Console.ReadLine().Split(' ');

                for (int j = 0; j < Elements.Length; j++)
                {
                    PeriodicTable.Add(Elements[j]);
                }
            }

            Console.WriteLine(string.Join(" ", PeriodicTable.OrderBy(x => x)));
        }
    }
}
