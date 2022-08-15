namespace basicFunctions_DB.FacadeLayer
{
    internal static class PrintMenu
    {
        public static void Authorization()
        {
            Console.WriteLine("-- Select a menu item by pressing the desired number and Enter --");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("[1] Sign up   *if you don't have an account");
            Console.WriteLine("[2] Log in   *if you have an account\n");
            Console.WriteLine("[0] Close the program");
            Console.WriteLine("-----------------------------------------------------------------");

        }

        public static void General()
        {
            Console.WriteLine("-- Select a menu item by pressing the desired number and Enter --");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("[1] Materials operations");
            Console.WriteLine("[2] Courses operations\n");
            Console.WriteLine("[0] Close the program");
            Console.WriteLine("-----------------------------------------------------------------");
        }

        public static void CoursesOperations()
        {
            Console.WriteLine("-- Select a menu item by pressing the desired number and Enter --");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("[1] Create course");
            Console.WriteLine("[2] Find by Id course");
            Console.WriteLine("[3] Update course");
            Console.WriteLine("[4] Delete course");
            Console.WriteLine("[5] Show all course\n");
            Console.WriteLine("[9] <--- Back");
            Console.WriteLine("[0] Close the program");
            Console.WriteLine("-----------------------------------------------------------------");
        }

        public static void MaterialOperations()
        {
            Console.WriteLine("-- Select a menu item by pressing the desired number and Enter --");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("[1] Create material");
            Console.WriteLine("[2] Find by Id material");
            Console.WriteLine("[3] Update material");
            Console.WriteLine("[4] Delete material");
            Console.WriteLine("[5] Show all materials\n");
            Console.WriteLine("[9] <--- Back");
            Console.WriteLine("[0] Close the program");
            Console.WriteLine("-----------------------------------------------------------------");
        }

        internal static void ChooseMaterialType()
        {
            Console.WriteLine("-- Select a menu item by pressing the desired number and Enter --");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("[1] new Book");
            Console.WriteLine("[2] new Video");
            Console.WriteLine("[3] new Publication\n");
            Console.WriteLine("[9] <--- Back");
            Console.WriteLine("[0] Close the program");
            Console.WriteLine("-----------------------------------------------------------------");

        }
    }
}
