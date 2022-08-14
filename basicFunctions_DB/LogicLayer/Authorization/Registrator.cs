namespace basicFunctions_DB.LogicLayer.Authorization
{
    using basicFunctions_DB.DataLayer;
    using basicFunctions_DB.DataLayer.UserType;

    internal static class Registrator
    {
        internal static void SignUp()
        {
            Console.WriteLine("Enter your Name and press Enter key:");
            string? name = Console.ReadLine();

            Console.WriteLine("Enter your email and press Enter key:");
            string? email = Console.ReadLine();

            Console.WriteLine("Enter your password and press Enter key:");
            string? password = Console.ReadLine();

            if (email != null && email != "")
            {
                if (IsExistingUser(email))
                {
                    Console.WriteLine("Error! User is already registered\n");
                }
            }

            if (password != null && password != string.Empty && email != string.Empty && email != null && name != null)
            {
                User user = new User { Email = email, Name = name, Password = password };
                SaveUserInDataBase(user);
            }
            else
            {
                Console.WriteLine("email or password can't be empty!\n");
            }
        }

        private static bool IsExistingUser(string email)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var users = db.Users.ToList();

                foreach (var user in users)
                {
                    if (user.Email == email)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static void SaveUserInDataBase(User user)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }

            Console.WriteLine("User is successfully registered\n");
        }
    }
}
