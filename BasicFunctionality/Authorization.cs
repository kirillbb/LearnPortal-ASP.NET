using Newtonsoft.Json;
using Portal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFunctionality
{
    internal static class Authorization
    {
        public static void SignUp()
        {

            Console.WriteLine("Enter your Name and press Enter key:");
            string? name = Console.ReadLine();

            Console.WriteLine("Enter your email and press Enter key:");
            string? email = Console.ReadLine();

            Console.WriteLine("Enter your password and press Enter key:");
            string? password = Console.ReadLine();
            
            User user = new User();

            if (!IsExistingLogin() && password != null && password != "")
            {

                user.Email = email;
                user.Password = password;
                user.Name = name;
            }

            SaveUserInFile(user);
        }

        private static bool IsExistingLogin()
        {
            //
            return false;
            //
        }

        private static void SaveUserInFile(User user)
        {
            List<User> currentUser = new List<User>();
            currentUser.Add(new User()
            {
                Email = user.Email.ToString(),
                Password = user.Password.ToString(),
                Name = user.Name.ToString()
            });

            string json = JsonConvert.SerializeObject(currentUser.ToArray());

            using (System.IO.StreamWriter writer = new(@"C:\Users\Kirill\source\repos\LearnPortal\BasicFunctionality\data\users.txt", true))
            {
                writer.WriteLine(json);
            }

        }

        public static void LogIn()
        {

        }
    }
}
