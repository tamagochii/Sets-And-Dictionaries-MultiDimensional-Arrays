using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sets_Of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {

            var Lengths = Console.ReadLine()
                .Split(new[] { ' ', '\n', '\t', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var FirstSet = new HashSet<int>();

            for (int i = 0; i < Lengths[0]; i++)
            {
                FirstSet.Add(int.Parse(Console.ReadLine()));
            }

            var SecondSet = new HashSet<int>();
            for (int i = 0; i < Lengths[1]; i++)
            {
               SecondSet.Add(int.Parse(Console.ReadLine()));
            }

            var IntersectionOfSets = FirstSet.Intersect(SecondSet);

            foreach (var num in IntersectionOfSets)
            {
                Console.Write($"{num} ");
            }

            Console.WriteLine();

        }
    }
}
