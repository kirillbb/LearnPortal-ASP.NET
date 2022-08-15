namespace basicFunctions_DB.LogicLayer.Authorization
{
    using basicFunctions_DB.DataLayer;
    using basicFunctions_DB.DataLayer.UserType;
    using System.Linq;

    internal static class Authorizator
    {
        private static User authorizatedUser = null;

        public static User AuthorizatedUser
        {
            get { return authorizatedUser; }
        }

        public static void LogIn()
        {
            Console.WriteLine("Enter your email and press Enter key:");
            string? email = Console.ReadLine();

            Console.WriteLine("Enter your password and press Enter key:");
            string? password = Console.ReadLine();

            using (ApplicationContext db = new ApplicationContext())
            {
                try
                {
                    var user = db.Users.Where(x => x.Email == email).FirstOrDefault();
                    if (password == user.Password)
                    {
                        Console.WriteLine("Authorization successful!\n");
                        authorizatedUser = user;
                        return;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nEmail or password is not correct\n");
                }
            }
        }

    }
}
