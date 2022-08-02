using Newtonsoft.Json;

namespace BasicFunctionality
{
    internal static class Authorization
    {
        public static bool AuthorizationMenu()
        {
            Console.WriteLine("-- Select a menu item by pressing the desired number and Enter --");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("[1] Sign up   *if you don't have an account");
            Console.WriteLine("[2] Log in   *if you have an account");
            Console.WriteLine("[0] Close the program");

            int menuItem;
            int.TryParse(Console.ReadLine(), out menuItem);

            bool isAuthorizated = false;

            switch (menuItem)
            {
                case 1:
                        SignUp();
                        break;
                case 2:
                        isAuthorizated = LogIn();
                        break;
                case 0:
                        Environment.Exit(0);
                        break;
                default:
                        AuthorizationMenu();
                        break;
            }

            if (!isAuthorizated)
            {
                AuthorizationMenu();
            }
            else
            {
                return isAuthorizated;
            }

            return isAuthorizated;
        }

        public static bool SignUp()
        {
            Console.WriteLine("Enter your Name and press Enter key:");
            string? name = Console.ReadLine();

            Console.WriteLine("Enter your email and press Enter key:");
            string? email = Console.ReadLine();

            Console.WriteLine("Enter your password and press Enter key:");
            string? password = Console.ReadLine();
            bool isExistingUser = false;

            if (email != null)
            {
                isExistingUser = IsExistingUser(email);
            }

            if (isExistingUser)
            {
                Console.WriteLine("Error! User is already registered\n");
                return false;
            }

            User user;

            if (password != null && password != "" && email != "" && email != null && name != null)
            {
                user = new User(email: email, password: password, name: name, id: SetUserId());
            }
            else
            {
                Console.WriteLine("email or password can't be empty!\n");
                return false;
            }

            SaveUserInFile(user);
            return true;
        }

        public static bool LogIn()
        {
            Console.WriteLine("Enter your email and press Enter key:");
            string? email = Console.ReadLine();

            Console.WriteLine("Enter your password and press Enter key:");
            string? password = Console.ReadLine();

            var jsons = File.ReadLines(@"C:\Users\Kirill\source\repos\LearnPortal\BasicFunctionality\data\users.txt");
            List<User> users = new List<User>();

            foreach(string json in jsons)
            {
                users.Add(JsonConvert.DeserializeObject<User>(json.ToString()));
            }

            foreach (var user in users)
            {
                if (email == user.Email)
                {
                    if (password == user.Password)
                    {
                        Console.WriteLine("Authorization successful!\n");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Authorization failed!\n");
                        return false;
                    }
                }
            }
            
            Console.WriteLine("Email or password is not correct\n");
            return false;
        }

        public static int SetUserId()
        {
            int id = 1;

            using (TextReader reader = new StreamReader(@"C:\Users\Kirill\source\repos\LearnPortal\BasicFunctionality\data\users.txt"))
            {
                while ((reader.ReadLine()) != null)
                {
                    id++;
                }
            }

            return id;
        }

        private static bool IsExistingUser(string email)
        {
            IEnumerable<string>? jsons = File.ReadLines(@"C:\Users\Kirill\source\repos\LearnPortal\BasicFunctionality\data\users.txt");

            foreach (string json in jsons)
            {
                User? user = JsonConvert.DeserializeObject<User>(json.ToString());

                if (user.Email != null)
                {   
                    return email == user.Email ?  true : false;
                }
            }

            return false;
        }

        private static void SaveUserInFile(User user)
        {
            string json = JsonConvert.SerializeObject(user);

            using (System.IO.StreamWriter writer = new(@"C:\Users\Kirill\source\repos\LearnPortal\BasicFunctionality\data\users.txt", true))
            {
                writer.WriteLine(json);
            }

            Console.WriteLine("User is successfully registered\n");
        }
    }
}
