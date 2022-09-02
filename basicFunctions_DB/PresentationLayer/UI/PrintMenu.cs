namespace basicFunctions_DB.PresentationLayer
{
    internal static class PrintMenu
    {
        public static void Authorization()
        {
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("-- Select a menu item by pressing the desired number and Enter --");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("[1] Sign up   *if you don't have an account");
            Console.WriteLine("[2] Log in   *if you have an account\n");
            Console.WriteLine("[0] Close the program");
            Console.WriteLine("-----------------------------------------------------------------");
        }

        internal static void SkillOperations()
        {
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("-- Select a menu item by pressing the desired number and Enter --");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("[1] Create skill");
            Console.WriteLine("[2] Find skill by Id");
            Console.WriteLine("[3] Update skill");
            Console.WriteLine("[4] Delete skill");
            Console.WriteLine("[5] Show all skills\n");
            Console.WriteLine("[9] <--- Back");
            Console.WriteLine("[0] Close the program");
            Console.WriteLine("-----------------------------------------------------------------");
        }

        public static void General()
        {
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("-- Select a menu item by pressing the desired number and Enter --");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("[1] Materials operations");
            Console.WriteLine("[2] Courses operations");
            Console.WriteLine("[3] Skills operations");
            Console.WriteLine("[4] Take a course");
            Console.WriteLine("[5] User profile\n");
            Console.WriteLine("[0] Close the program");
            Console.WriteLine("-----------------------------------------------------------------");
        }

        public static void CoursesOperations()
        {
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("-- Select a menu item by pressing the desired number and Enter --");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("[1] Create course");
            Console.WriteLine("[2] Find by Id course");
            Console.WriteLine("[3] Update course");
            Console.WriteLine("[4] Delete course");
            Console.WriteLine("[5] Show all courses");
            Console.WriteLine("[6] Add skills to course\n");
            Console.WriteLine("[9] <--- Back");
            Console.WriteLine("[0] Close the program");
            Console.WriteLine("-----------------------------------------------------------------");
        }

        public static void MaterialOperations()
        {
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("-- Select a menu item by pressing the desired number and Enter --");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("[1] Create material");
            Console.WriteLine("[2] Find by Id material");
            Console.WriteLine("[3] Update material");
            Console.WriteLine("[4] Delete material");
            Console.WriteLine("[5] Show all materials\n");
            Console.WriteLine("[9] <--- Back");
            Console.WriteLine("[0] Close the program");
            Console.WriteLine("-----------------------------------------------------------------");
        }
        public static void BreakLine()
        {
            Console.WriteLine("-----------------------------------------------------------------");
        }
        internal static void ChooseMaterialType()
        {
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("-- Select a menu item by pressing the desired number and Enter --");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("[1] Book");
            Console.WriteLine("[2] Video");
            Console.WriteLine("[3] Publication\n");
            Console.WriteLine("[9] <--- Back");
            Console.WriteLine("[0] Close the program");
            Console.WriteLine("-----------------------------------------------------------------");
        }
    }
}
