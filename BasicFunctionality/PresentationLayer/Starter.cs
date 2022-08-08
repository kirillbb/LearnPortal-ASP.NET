﻿// <copyright file="Starter.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BasicFunctionality
{
    internal class Starter
    {
        public static void Run()
        {
            do
            {
                try
                {
                    AuthorizationControler.AuthorizationMenu();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            while (!Authorizator.IsAuthorizated);

            Menu(ChooseMenuItem());
        }

        public static void Menu(int menuItem)
        {
            switch (menuItem)
            {
                case 1:
                        throw new NotImplementedException();
                case 2:
                        throw new NotImplementedException();
                case 3:
                        throw new NotImplementedException();
                case 4:
                        throw new NotImplementedException();
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
            Console.WriteLine("-----------------------------------------------------------------");
        }
    }
}