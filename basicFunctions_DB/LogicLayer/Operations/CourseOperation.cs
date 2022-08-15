using basicFunctions_DB.FacadeLayer;

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
            throw new NotImplementedException();
        }

        private static void FindById()
        {
            throw new NotImplementedException();
        }

        private static void UpdateCourse()
        {
            throw new NotImplementedException();
        }

        private static void PrintAll()
        {
            throw new NotImplementedException();
        }

        private static void DeleteCourse()
        {
            throw new NotImplementedException();
        }
    }
}
