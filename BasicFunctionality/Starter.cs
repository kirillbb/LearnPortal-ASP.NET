using Portal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFunctionality
{
    internal class Starter
    {
        public void Run()
        {
            Menu(ChooseMenuItem());
        }

        public void Menu(int menuItem)
        {
            switch (menuItem)
            {
                case 1:
                    Authorization.SignUp();
                    break;
                case 2:
                    Authorization.LogIn();
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
                if (isItem == false)
                {
                    Console.Clear();
                }

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
            Console.WriteLine("[1] Sign up   *if you don't have an account");
            Console.WriteLine("[2] Log in   *if you have an account");
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
