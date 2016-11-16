using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fix_Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            var InputUser = Console.ReadLine();
           

            var UsersAndEmails = new Dictionary<string, string>();

            while (InputUser.ToLower() != "stop" )
            {
                var UserEmail = Console.ReadLine();
                var Domain = UserEmail[UserEmail.Length - 2].ToString() 
                           + UserEmail[UserEmail.Length - 1].ToString();

                if (Domain != "us" && Domain != "uk")
                {
                    if (!UsersAndEmails.ContainsKey(InputUser))
                    {
                        UsersAndEmails[InputUser] = string.Empty;
                    }

                    UsersAndEmails[InputUser] = UserEmail;
                }

                InputUser = Console.ReadLine();
            }


            foreach (var user in UsersAndEmails.Keys)
            {
                Console.WriteLine($"{user} -> {UsersAndEmails[user]}");
            }
        }
    }
}
