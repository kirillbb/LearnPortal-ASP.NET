// <copyright file="Book.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BasicFunctionality
{
    internal class Book : IMaterial
    {
        public Book(User user, string author, string title, DateTime publicationDate, int pages, string format)
        {
            this.Creator = user;
            this.Author = author;
            this.Title = title;
            this.PublicationDate = publicationDate;
            this.Pages = pages;
            this.BookFormat = format;
            this.Id = SetId();
        }

        public string? Author { get; set; }

        public DateTime PublicationDate { get; set; }

        public int Pages { get; set; }

        public string? BookFormat { get; set; }

        public string? Title { get; set; }

        public int Id { get; set; }

        public User Creator { get; set; }

        public MaterialType Type { get; } = MaterialType.Book;

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
