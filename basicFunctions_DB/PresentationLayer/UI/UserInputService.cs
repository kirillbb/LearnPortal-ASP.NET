﻿using basicFunctions_DB.BLL.DTO;
using basicFunctions_DB.DAL.UserType;

namespace basicFunctions_DB.BLL.UI
{
    internal static class UserInputService
    {
        public static UserDTO Authorization()
        {
            Console.WriteLine("Enter your email and press Enter key:");
            string email = Console.ReadLine();
            Console.WriteLine("Enter your password and press Enter key:");
            string password = Console.ReadLine();

            return new UserDTO { Email = email, Password = password };
        }
        public static UserDTO Registration()
        {
            Console.WriteLine("Enter your Name and press Enter key:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your email and press Enter key:");
            string email = Console.ReadLine();
            Console.WriteLine("Enter your password and press Enter key:");
            string password = Console.ReadLine();

            return new UserDTO { Email = email, Name = name, Password = password };
        }

        public static int GetId()
        {
            Console.WriteLine("Enter Id:");
            int id = int.Parse(Console.ReadLine());
            return id;
        }

        public static BookDTO AddBook(User user)
        {
            try
            {
                Console.WriteLine("Enter a Title of a book:");
                string title = Console.ReadLine();
                Console.WriteLine("Enter a Author of a book:");
                string author = Console.ReadLine();
                Console.WriteLine("Enter a count of pages of a book:");
                int pages = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter a format of a book:");
                string format = Console.ReadLine();
                Console.WriteLine("Enter a publication date of a book:");
                DateTime date = DateTime.Parse(Console.ReadLine());

                BookDTO book = new BookDTO
                {
                    Title = title,
                    Author = author,
                    Pages = pages,
                    BookFormat = format,
                    Creator = user
                };

                return book;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        public static VideoDTO AddVideo(User user)
        {
            try
            {
                Console.WriteLine("Enter a Title of a video:");
                string title = Console.ReadLine();
                Console.WriteLine("Enter a resolution of a video (480,720,1080, etc):");
                int resolution = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter a duration of a video in minutes:");
                int duration = int.Parse(Console.ReadLine());

                VideoDTO video = new VideoDTO
                {
                    Title = title,
                    Resolution = resolution,
                    Duration = duration,
                    Creator = user
                };

                return video;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        public static PublicationDTO AddPublication(User user)
        {
            try
            {
                Console.WriteLine("Enter a Title of a publication:");
                string title = Console.ReadLine();
                Console.WriteLine("Enter a publication date:");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Enter a sourse of a publication:");
                string source = Console.ReadLine();

                PublicationDTO publication = new PublicationDTO
                {
                    Title = title,
                    CreationDate = date,
                    Source = source,
                    Creator = user
                };

                return publication;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        public static CourseDTO AddCourse(User user)
        {
            try
            {
                Console.WriteLine("Enter a Name of a course:");
                string name = Console.ReadLine();
                Console.WriteLine("Enter a description of a course:");
                string description = Console.ReadLine();

                CourseDTO course = new CourseDTO
                {
                    Name = name,
                    Description = description,
                    Creator = user
                };

                return course;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }
    }
}