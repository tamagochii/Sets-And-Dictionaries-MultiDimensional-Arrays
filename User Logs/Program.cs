using System;
using System.Collections.Generic;
using System.Linq;
namespace User_Logs
{
    class Program
    {
        static void Main()
        {
            var UserAndIps = new Dictionary<string, Dictionary<string, int>>();
            var Input = Console.ReadLine();

            while (Input != "end")
            {
                var IP = Input.Substring(3, Input.IndexOf(' ') - 3);
                var User = Input.Substring(Input.LastIndexOf("user=") + 5);

                if (!UserAndIps.ContainsKey(User))
                {
                    UserAndIps.Add(User, new Dictionary<string, int>());
                    UserAndIps[User].Add(IP, 1);
                }
                else
                {
                    if (!UserAndIps[User].ContainsKey(IP))
                    {
                        UserAndIps[User].Add(IP, 0);
                    }

                    UserAndIps[User][IP]++;
                }

                Input = Console.ReadLine();
            }

            Print(UserAndIps.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value));
        }

        static void Print(Dictionary<string, Dictionary<string, int>> UserAndIps)
        {
            foreach (var user in UserAndIps.Keys)
            {
                Console.WriteLine($"{user}:");

                var TrackLastIp = 0;
                foreach (var ip in UserAndIps[user].Keys)
                {
                    TrackLastIp++;

                    if (TrackLastIp >= UserAndIps[user].Count)
                    {
                        Console.Write($"{ip} => {UserAndIps[user][ip]}.");
                        break;
                    }
                    Console.Write($"{ip} => {UserAndIps[user][ip]}, ");
                }
                Console.WriteLine();
            }
        }
    }
}
