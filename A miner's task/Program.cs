using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_miner_s_task
{
    class Program
    {
        static void Main()
        {
            var Resources = new Dictionary<string, long>();
            var InputResource = Console.ReadLine();
            var Quantity = Console.ReadLine();

            while (InputResource.ToLower() != "stop")
            {
                if (!Resources.ContainsKey(InputResource))
                {
                    Resources.Add(InputResource, 0);
                }

                Resources[InputResource] += long.Parse(Quantity);

                InputResource = Console.ReadLine();
                Quantity = Console.ReadLine();
            }

            foreach (var resource in Resources.Keys)
            {
                Console.WriteLine($"{resource} -> {Resources[resource]}");
            }
        }
    }
}
