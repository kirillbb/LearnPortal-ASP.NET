// <copyright file="CoursesOperations.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BasicFunctionality
{
    public static class CoursesOperations
    {
        private static ICourseRepository? courseRepository;

        public static void PrintMenu()
        {
            Console.WriteLine("-- Select a menu item by pressing the desired number and Enter --");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("[1] Create course");
            Console.WriteLine("[2] Find by Id course");
            Console.WriteLine("[3] Update course");
            Console.WriteLine("[4] Delete course");
            Console.WriteLine("[5] Show all course");
            Console.WriteLine("\n[9] <--- Back");
            Console.WriteLine("[0] Close the program");
            Console.WriteLine("-----------------------------------------------------------------");
        }

        public static void Menu(int menuItem)
        {
            switch (menuItem)
            {
                case 1:
                    Create();
                    break;
                case 2:
                    FindById();
                    break;
                case 3:
                    Update();
                    break;
                case 4:
                    Delete();
                    break;
                case 5:
                    ShowAllCourses();
                    break;
                case 9:
                    Starter.Menu(Starter.ChooseMenuItem());
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    Menu(ChooseMenuItem());
                    break;
            }
        }

        public static int ChooseMenuItem()
        {
            int menuItem;
            bool isItem = false;

            do
            {
                PrintMenu();
                isItem = int.TryParse(Console.ReadLine(), out menuItem);
            }
            while (!isItem);

            return menuItem;
        }

        private static void ShowAllCourses()
        {
            courseRepository = new CourseRepository<Course>();
            foreach (var item in courseRepository)
            {
                item.ToString();
            }
        }

        private static void Delete()
        {
            Console.WriteLine("enter id to delete:");
            int id = 0;
            int.TryParse(Console.ReadLine(), out id);

            throw new NotImplementedException();
        }

        private static void Update()
        {
            throw new NotImplementedException();
        }

        private static void FindById()
        {
            throw new NotImplementedException();
        }

        private static void Create()
        {
            throw new NotImplementedException();
        }
    }
}
