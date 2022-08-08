// <copyright file="User.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BasicFunctionality
{
    public class User
    {
        public User(string email, string password, string name)
        {
            this.Email = email;
            this.Password = password;
            this.Name = name;
            this.Id = SetId();
        }

        public string Email { get; internal set; }

        public string Password { get; internal set; }

        public string Name { get; internal set; }

        public int Id { get; set; }

        private static int SetId()
        {
            string path = Authorizator.Path;
            int id = 1;

            if (File.Exists(path))
            {
                using (TextReader reader = new StreamReader(path))
                {
                    while (reader.ReadLine() != null)
                    {
                        id++;
                    }
                }
            }

            return id;
        }
    }
}