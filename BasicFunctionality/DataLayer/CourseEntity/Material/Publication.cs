// <copyright file="Publication.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BasicFunctionality
{
    public class Publication : IMaterial
    {
        public Publication(User creator, DateTime creationDate, string sourse, string title)
        {
            this.Creator = creator;
            this.CreationDate = creationDate;
            this.Source = sourse;
            this.Id = SetId();
            this.Type = MaterialType.Publication;
        }

        public DateTime CreationDate { get; set; }

        public string? Source { get; set; }

        public string? Title { get; set; }

        public int Id { get; set; }

        public User Creator { get; set; }

        public MaterialType Type { get; } = MaterialType.Publication;

        public override string ToString()
        {
            return $"Title: {this.Title} Source: {this.Source} Creation Date: {this.CreationDate}\nCreator: {this.Creator} MaterialType: {this.Type.ToString()} ID: {this.Id}";
        }

        private static int SetId()
        {
            string path = @"C:\Users\Kirill\source\repos\LearnPortal\BasicFunctionality\data\materials\publications.txt";
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
