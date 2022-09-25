// <copyright file="BookRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BasicFunctionality
{
    using System.Collections;
    using Newtonsoft.Json;

    public class BookRepository<TBook> : IEnumerable
    {
        private List<Book> data;
        private string path = @"C:\Users\Kirill\source\repos\LearnPortal\BasicFunctionality\data\materials\books.txt";

        public BookRepository()
        {
            var jsons = File.ReadLines(this.path);
            List<Book> materials = new List<Book>();

            foreach (string json in jsons)
            {
                    #pragma warning disable CS8604 // Possible null reference argument.
                materials.Add(JsonConvert.DeserializeObject<Book>(json.ToString()));
                    #pragma warning restore CS8604 // Possible null reference argument.
            }

            this.data = materials;
        }

        private List<Book> Data
        {
            get { return this.data; }
        }

        public Book? FindById(int id)
        {
            foreach (var item in this.data)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }

            return null;
        }

        public void Create(Book book)
        {
            this.data.Add(book);
            this.SaveChanges(book);
        }

        public void Update(Book book, User newCreator, string newAuthor, string newTitle, DateTime newPublicationDate, int newPages, string newFormat)
        {
            foreach (var oldBook in this.data)
            {
                if (oldBook == book)
                {
                    oldBook.Title = newTitle;
                    oldBook.Author = newAuthor;
                    oldBook.Pages = newPages;
                    oldBook.PublicationDate = newPublicationDate;
                    oldBook.BookFormat = newFormat;
                    oldBook.Creator = newCreator;
                }
            }

            this.SaveChanges(this.data);
        }

        public void Remove(Book book)
        {
            this.data.Remove(book);
            this.SaveChanges(this.data);
        }

        public void SaveChanges(List<Book> books)
        {
            File.WriteAllText(this.path, string.Empty);
            foreach (var item in books)
            {
                string json = JsonConvert.SerializeObject(item);

                using (System.IO.StreamWriter writer = new (this.path, true))
                {
                    writer.WriteLine(json);
                }
            }

            Console.WriteLine("Material saved");
        }

        public void SaveChanges(Book book)
        {
            string json = JsonConvert.SerializeObject(book);

            using (System.IO.StreamWriter writer = new (this.path, true))
            {
                writer.WriteLine(json);
            }

            Console.WriteLine("Material saved");
        }

        public IEnumerator GetEnumerator() => this.data.GetEnumerator();
    }
}
