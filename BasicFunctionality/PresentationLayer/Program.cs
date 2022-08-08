// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BasicFunctionality
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            // Starter.Run();
            BookRepository<Book> repository = new BookRepository<Book>();

            User kirillUser = new User("kirill@gmail.com", "kirill", "kirill");
            User stepanUser = new User("stepan@gmail.com", "stepan", "stepan");

            Book book1 = new Book(kirillUser, "g.Wiede", "Bookname1", DateTime.Now, 101, "pdf");
            repository.Create(book1);
            Book book2 = new Book(stepanUser, "g.hgdf", "Bookname2", DateTime.Parse("12.12.2012"), 101, "epub");
            repository.Create(book2);
            Book book3 = new Book(kirillUser, "g.afas", "Bookname3", DateTime.Parse("2.09.2002"), 101, "doc");
            repository.Create(book3);
            Book book4 = new Book(stepanUser, "g.gfhj", "Bookname4", DateTime.Parse("10.02.1991"), 101, "pdf");
            repository.Create(book4);

            repository.Remove(book1);

            ICourseRepository courseRepository = new CourseRepository<Course>();

            Console.WriteLine();
        }
    }
}