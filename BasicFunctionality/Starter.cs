﻿namespace BasicFunctionality
{
    internal class Starter
    {
        public void Run()
        {
            bool isAuthorizated = false;

            isAuthorizated = Authorization.AuthorizationMenu();
            if (isAuthorizated)
            {
                Menu(ChooseMenuItem());
            }
        }

        public void Menu(int menuItem)
        {
            switch (menuItem)
            {
                case 1:

                    break;
                case 2:

                    break;
                case 3:

                    break;
                case 4:

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

        private static void PrintMenu()
        {
            Console.WriteLine("-- Select a menu item by pressing the desired number and Enter --");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("[1] ");
            Console.WriteLine("[2] ");
            Console.WriteLine("[3] ");
            Console.WriteLine("[4] ");
            Console.WriteLine("[5] ");
            Console.WriteLine("[6] ");
            Console.WriteLine("[7] ");
            Console.WriteLine("[0] Close the program");
            Console.WriteLine("-----------------------------------------------------");
        }
    }
}
