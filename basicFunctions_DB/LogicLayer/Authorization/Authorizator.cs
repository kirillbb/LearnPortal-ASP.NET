﻿namespace basicFunctions_DB.LogicLayer.Authorization
{
    using basicFunctions_DB.DataLayer;
    using basicFunctions_DB.DataLayer.UserType;
    using System.Linq;

    internal static class Authorizator
    {
        private static User authorizatedUser = null;

        public static User AuthorizatedUser
        {
            get { return authorizatedUser; }
        }

        public static void LogIn()
        {
            Console.WriteLine("Enter your email and press Enter key:");
            string? email = Console.ReadLine();

            Console.WriteLine("Enter your password and press Enter key:");
            string? password = Console.ReadLine();

            using (ApplicationContext db = new ApplicationContext())
            {
                var users = db.Users.ToList();


                foreach (var user in users)
                {
                    if (email == user.Email)
                    {
                        if (password == user.Password)
                        {
                            Console.WriteLine("Authorization successful!\n");
                            authorizatedUser = user;
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Authorization failed!\n");
                            return;
                        }
                    }
                }
            }

            Console.WriteLine("Email or password is not correct\n");
        }

    }
}