// <copyright file="Skill.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BasicFunctionality
{
    public class Skill
    {
        public Skill(string name, string description)
        {
            this.Name = name;
            this.Description = description;
            this.Id = SetId();
        }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public int Id { get; private set; }

        private static int SetId()
        {
            string path = @"C:\Users\Kirill\source\repos\LearnPortal\BasicFunctionality\data\skills.txt";
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
