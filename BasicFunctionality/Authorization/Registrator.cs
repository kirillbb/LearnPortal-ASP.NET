// <copyright file="Registrator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BasicFunctionality
{
    using Newtonsoft.Json;

    public static class Registrator
    {
        public static bool SignUp()
        {
            Console.WriteLine("Enter your Name and press Enter key:");
            string? name = Console.ReadLine();

            Console.WriteLine("Enter your email and press Enter key:");
            string? email = Console.ReadLine();

            Console.WriteLine("Enter your password and press Enter key:");
            string? password = Console.ReadLine();
            bool isExistingUser = false;

            if (email != null)
            {
                isExistingUser = IsExistingUser(email);
            }

            if (isExistingUser)
            {
                Console.WriteLine("Error! User is already registered\n");
                return false;
            }

            User user;

            if (password != null && password != string.Empty && email != string.Empty && email != null && name != null)
            {
                user = new User(email: email, password: password, name: name);
            }
            else
            {
                Console.WriteLine("email or password can't be empty!\n");
                return false;
            }

            SaveUserInFile(user);
            return true;
        }

        private static bool IsExistingUser(string email)
        {
            IEnumerable<string>? jsons = File.ReadLines(Authorizator.Path);

            foreach (string json in jsons)
            {
                User? user = JsonConvert.DeserializeObject<User>(json.ToString());

#pragma warning disable CS8602 // Dereference of a possibly null reference.
                if (user.Email != null)
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                {
                    return email == user.Email ? true : false;
                }
            }

            return false;
        }

        private static void SaveUserInFile(User user)
        {
            string json = JsonConvert.SerializeObject(user);

            using (System.IO.StreamWriter writer = new (Authorizator.Path, true))
            {
                writer.WriteLine(json);
            }

            Console.WriteLine("User is successfully registered\n");
        }
    }
}
