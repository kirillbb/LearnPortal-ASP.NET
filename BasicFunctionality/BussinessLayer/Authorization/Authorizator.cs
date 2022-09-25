// <copyright file="Authorizator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BasicFunctionality
{
    using Newtonsoft.Json;

    internal static class Authorizator
    {
        public static readonly string Path = @"C:\Users\Kirill\source\repos\LearnPortal\BasicFunctionality\data\users.txt";
        private static bool isAuthorizated = false;

        public static bool IsAuthorizated
        {
            get { return isAuthorizated; }
        }

        public static bool LogIn()
        {
            Console.WriteLine("Enter your email and press Enter key:");
            string? email = Console.ReadLine();

            Console.WriteLine("Enter your password and press Enter key:");
            string? password = Console.ReadLine();

            var jsons = File.ReadLines(Path);
            List<User> users = new List<User>();

            foreach (string json in jsons)
            {
                #pragma warning disable CS8604 // Possible null reference argument.
                users.Add(JsonConvert.DeserializeObject<User>(json.ToString()));
                #pragma warning restore CS8604 // Possible null reference argument.
            }

            foreach (var user in users)
            {
                if (email == user.Email)
                {
                    if (password == user.Password)
                    {
                        Console.WriteLine("Authorization successful!\n");
                        isAuthorizated = true;
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Authorization failed!\n");
                        isAuthorizated = false;
                        return false;
                    }
                }
            }

            Console.WriteLine("Email or password is not correct\n");
            return false;
        }
    }
}
