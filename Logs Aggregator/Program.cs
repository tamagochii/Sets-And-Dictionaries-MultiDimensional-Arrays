using System;
using System.Collections.Generic;
using System.Linq;
namespace Logs_Aggregator
{
    class Program
    {
        static void Main()
        {
            //receive n lines with ip username duration of the usage of the ip
            //for each user print user : totalduration(used ips seperated by ' '',')    
            //the printed ips shoud be only unique ones


            var LinesToInput = int.Parse(Console.ReadLine());
            var UsersAndIps = new Dictionary<string, Dictionary<string, long>>();

            for (int i = 0; i < LinesToInput; i++)
            {
                var InputArgs = Console.ReadLine()
                    .Split(new[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                var Ip = InputArgs[0];
                var User = InputArgs[1];
                var Duration = long.Parse(InputArgs[2]);

                if (!UsersAndIps.ContainsKey(User))
                {
                    UsersAndIps.Add(User, new Dictionary<string, long>());
                    UsersAndIps[User].Add(Ip, Duration);
                }
                else
                {
                    if (!UsersAndIps[User].ContainsKey(Ip))
                    {
                        UsersAndIps[User].Add(Ip, 0);
                    }

                    UsersAndIps[User][Ip] += Duration;
                }
            }

            //the users and the ips shoud be ordered alphabetically
            UsersAndIps = UsersAndIps.OrderBy(x => x.Key)
                                     .ToDictionary(x => x.Key, x => x.Value);

            foreach (var user in UsersAndIps.Keys)
            {
                var SortedIpsSet = UsersAndIps[user].OrderBy(x => x.Key)
                                                     .ToDictionary(x => x.Key, x => x.Value);

                var TotalDurationOfUser = UsersAndIps[user].Sum(x => x.Value);

                Console.Write($"{user}: {TotalDurationOfUser} [");
                var CountForEnding = 0;

                foreach (var ip in SortedIpsSet.Keys)
                {
                    CountForEnding++;

                    if (CountForEnding >= SortedIpsSet.Count)
                    {
                        Console.WriteLine($"{ip}]");
                        break;
                    }

                    Console.Write($"{ip}, ");
                }

            }

        }
    }
}
