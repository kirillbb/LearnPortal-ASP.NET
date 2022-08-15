using basicFunctions_DB.DataLayer;
using basicFunctions_DB.DataLayer.CourseType;
using basicFunctions_DB.FacadeLayer;
using basicFunctions_DB.GenericRepository;
using basicFunctions_DB.LogicLayer.Authorization;

namespace basicFunctions_DB.LogicLayer.Operations
{
    internal static class CourseOperation
    {
        public static void Run()
        {
            Console.WriteLine("\nits course operations\n");
            Control();
        }

        private static void Control()
        {
            PrintMenu.CoursesOperations();
            int menuItem;
            bool isMenu = int.TryParse(Console.ReadLine(), out menuItem);

            if (!isMenu)
            {
                menuItem = 999; // to make it work in default-case if it is not a number
            }

            switch (menuItem)
            {
                case 1:
                    CreateCourse();
                    break;
                case 2:
                    FindById();
                    break;
                case 3:
                    UpdateCourse();
                    break;
                case 4:
                    DeleteCourse();
                    break;
                case 5:
                    PrintAll();
                    break;
                case 9:
                    OperationControler.Control();
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }

            Run();
        }

        private static void CreateCourse()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                GenericRepository<Course> repository = new GenericRepository<Course>(db);

                Course course;
                Console.WriteLine("Name:");
                string name = Console.ReadLine();
                Console.WriteLine("Description:");
                string description = Console.ReadLine();

                course = new Course
                {
                    Creator = db.Users.Where(x => x.Id == AuthorizationControler.AuthorizatedUser.Id).FirstOrDefault(),
                    Name = name,
                    Description = description
                };

                repository.Insert(course);
                repository.Save();
            }
        }

        private static void FindById()
        {
            Console.WriteLine("Enter ID:");
            using (ApplicationContext db = new ApplicationContext())
            {
                GenericRepository<Course> repository = new GenericRepository<Course>(db);

                string id = Console.ReadLine();
                var course = repository.GetById(int.Parse(id));

                Console.WriteLine("ID: " + course.Id + " \"" + course.Name + "\" " + course.Description);

                Console.ReadLine();
            }
        }

        private static void UpdateCourse()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                GenericRepository<Course> repository = new GenericRepository<Course>(db);

                Console.WriteLine("Enter ID:");
                string id = Console.ReadLine();
                var course = repository.GetById(int.Parse(id));

                Console.WriteLine($"Current Name = {course.Name} enter a new Name:");
                course.Name = Console.ReadLine();
                Console.WriteLine($"Current Description = {course.Description} enter a new Description:");
                course.Description = Console.ReadLine();

                repository.Update(course);

                repository.Save();
            }

            Console.ReadLine();
            Control();
        }

        private static void PrintAll()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                GenericRepository<Course> repository = new GenericRepository<Course>(db);

                Console.WriteLine("List of all materials:");
                var list = repository.GetAll();
                foreach (var course in list)
                {
                    Console.WriteLine("ID: " + course.Id + " " + course.Name + " - " + course.Description);
                }

                Console.ReadLine();
                Control();
            }
        }

        private static void DeleteCourse()
        {
            int id = 0;
            Console.WriteLine("Enter course-ID to remove:");
            int.TryParse(Console.ReadLine(), out id);

            using (ApplicationContext db = new ApplicationContext())
            {
                GenericRepository<Course> repository = new GenericRepository<Course>(db);
                repository.Delete(id);
                repository.Save();
            }

            Console.WriteLine();
            Console.ReadLine();
            Control();
        }
    }
}
