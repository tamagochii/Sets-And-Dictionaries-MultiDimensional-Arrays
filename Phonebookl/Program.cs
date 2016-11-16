using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
    class Program
    {
        static void Main()
        {
            var PeopleAndPhones = new Dictionary<string, string>();
            var Input = Console.ReadLine();

            while (Input != "search")
            {
                var GetInfo = Input.Split(new[] { '-', ' ', '\r', '\n' },StringSplitOptions.RemoveEmptyEntries);
                var Person = GetInfo[0];
                var Phone =  GetInfo[1];

                if (!PeopleAndPhones.ContainsKey(Person))
                {
                    PeopleAndPhones[Person] = string.Empty;
                }

                PeopleAndPhones[Person] = Phone;
                Input = Console.ReadLine();
            }

            Input = Console.ReadLine();
            while (Input.ToLower() !="stop")
            {
                if (PeopleAndPhones.ContainsKey(Input))
                {
                    Console.WriteLine($"{Input} -> {PeopleAndPhones[Input]}");
                }
                else
                {
                    Console.WriteLine($"Contact {Input} does not exist.");
                }
                Input = Console.ReadLine();
            }

        }
    }
}
