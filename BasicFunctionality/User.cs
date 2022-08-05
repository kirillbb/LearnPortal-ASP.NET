// <copyright file="User.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BasicFunctionality
{
    public class User
    {
<<<<<<< HEAD
        public User(string email, string password, string name)
=======
        public User(string email, string password, string name, int id)
>>>>>>> f136b713f83d82b3d848ff98d1c6a9f2dd23abca
        {
            this.Email = email;
            this.Password = password;
            this.Name = name;
<<<<<<< HEAD
            this.Id = SetId();
=======
            this.Id = id;
>>>>>>> f136b713f83d82b3d848ff98d1c6a9f2dd23abca
        }

        public string Email { get; internal set; }

        public string Password { get; internal set; }

        public string Name { get; internal set; }

        public int Id { get; set; }
<<<<<<< HEAD

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
=======
>>>>>>> f136b713f83d82b3d848ff98d1c6a9f2dd23abca
    }
}