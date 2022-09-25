// <copyright file="MaterialOperations.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BasicFunctionality
{
    internal static class MaterialOperations
    {
        public static void PrintMenu()
        {
            Console.WriteLine("-- Select a menu item by pressing the desired number and Enter --");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("[1] Create material");
            Console.WriteLine("[2] Find by Id material");
            Console.WriteLine("[3] Update material");
            Console.WriteLine("[4] Delete material");
            Console.WriteLine("[5] Show all materials");
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
                    ShowAllMaterials();
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

        private static void ShowAllMaterials()
        {
            throw new NotImplementedException();
        }

        private static void Delete()
        {
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
