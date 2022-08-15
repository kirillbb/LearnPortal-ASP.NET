namespace basicFunctions_DB.LogicLayer.Operations
{
    using basicFunctions_DB.FacadeLayer;

    internal static class OperationControler
    {
        public static void Control()
        {
            PrintMenu.General();

            int menuItem;
            bool isMenu = int.TryParse(Console.ReadLine(), out menuItem);

            if (!isMenu)
            {
                menuItem = 999; // to make it work in default-case if it is not a number
            }

            switch (menuItem)
            {
                case 1:
                    MaterialOperation.Run();
                    break;
                case 2:
                    CourseOperation.Run();
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    Control();
                    break;
            }
        }
    }
}
