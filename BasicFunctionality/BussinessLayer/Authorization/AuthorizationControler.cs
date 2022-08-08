// <copyright file="AuthorizationControler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BasicFunctionality
{
    public static class AuthorizationControler
    {
        public static void AuthorizationMenu()
        {
            Console.WriteLine("-- Select a menu item by pressing the desired number and Enter --");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("[1] Sign up   *if you don't have an account");
            Console.WriteLine("[2] Log in   *if you have an account");
            Console.WriteLine("[0] Close the program");
            Console.WriteLine("-----------------------------------------------------------------");

            int menuItem;
            bool isMenu = int.TryParse(Console.ReadLine(), out menuItem);

            if (!isMenu)
            {
                menuItem = 999; // to make it work in default-case if it is not a number
            }

            switch (menuItem)
            {
                case 1:
                    Registrator.SignUp();
                    break;
                case 2:
                    Authorizator.LogIn();
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }
    }
}
