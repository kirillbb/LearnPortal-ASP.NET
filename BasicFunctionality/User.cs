// <copyright file="User.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BasicFunctionality
{
    public class User
    {
        public User(string email, string password, string name, int id)
        {
            this.Email = email;
            this.Password = password;
            this.Name = name;
            this.Id = id;
        }

        public string Email { get; internal set; }

        public string Password { get; internal set; }

        public string Name { get; internal set; }

        public int Id { get; set; }
    }
}