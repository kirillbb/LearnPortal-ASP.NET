// <copyright file="Book.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BasicFunctionality
{
    public class Book
    {
        public Book(User creator, string author, string title, DateTime publicationDate, int pages, string format)
        {
            this.Creator = creator;
            this.Author = author;
            this.Title = title;
            this.PublicationDate = publicationDate;
            this.Pages = pages;
            this.BookFormat = format;
            this.Id = SetId();
            this.Type = MaterialType.Book.ToString();
        }

        public string? Author { get; set; }

        public DateTime PublicationDate { get; set; }

        public int Pages { get; set; }

        public string? BookFormat { get; set; }

        public string? Title { get; set; }

        public int Id { get; set; }

        public User Creator { get; set; }

        public string Type { get; }

        public override string ToString()
        {
            return $"Title: {this.Title} Author: {this.Author}\n {this.Pages} pages, Creator: {this.Creator} MaterialType: {this.Type.ToString()} ID: {this.Id}";
        }

        private static int SetId()
        {
            string path = @"C:\Users\Kirill\source\repos\LearnPortal\BasicFunctionality\data\materials\books.txt";
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
