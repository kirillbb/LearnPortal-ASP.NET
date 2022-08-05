// <copyright file="Publication.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BasicFunctionality
{
    internal class Publication : IMaterial
    {
        public Publication(User user, DateTime creationDate, string sourse, string title)
        {
            this.Creator = user;
            this.CreationDate = creationDate;
            this.Source = sourse;
            this.Id = SetId();
        }

        public DateTime CreationDate { get; set; }

        public string? Source { get; set; }

        public string? Title { get; set; }

        public int Id { get; set; }

        public User Creator { get; set; }

        public MaterialType Type { get; } = MaterialType.Publication;

        private static int SetId()
        {
            string path = @"C:\Users\Kirill\source\repos\LearnPortal\BasicFunctionality\data\materials.txt";
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
