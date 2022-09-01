namespace basicFunctions_DB.BLL.Authorization
{
    using basicFunctions_DB.BLL.Authorization;
    using basicFunctions_DB.DAL.UserType;

    public static class Auth
    {
        public static User AuthorizatedUser { get; private set; }
        // to DTO
        
        public static User Control()
        {
            int menuItem;
            bool isMenu = int.TryParse(Console.ReadLine(), out menuItem);

            if (!isMenu)
            {
                menuItem = 999; // to make it work in default-case if it is not a number
            }

            User? user = new User();
            AuthorizatedUser = null;

            //switch (menuItem)
            //{
            //    case 1:
            //        Registrator.SignUp();
            //        break;
            //    case 2:
            //        Authorizator.LogIn();
            //        AuthorizatedUser = Authorizator.AuthorizatedUser;
            //        break;
            //    case 0:
            //        Environment.Exit(0);
            //        break;
            //    default:
            //        break;
            //}

            return user;
        }
    }
}
