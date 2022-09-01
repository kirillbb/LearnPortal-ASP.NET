namespace basicFunctions_DB.BLL.Authorization
{
    using basicFunctions_DB.BLL.Interfaces;
    using basicFunctions_DB.DAL;
    using basicFunctions_DB.DAL.UserType;
    using Microsoft.EntityFrameworkCore;

    internal class Authorizator : IAuthorizator
    {
        private readonly ApplicationContext _context;
        private static User authorizatedUser = null;

        public Authorizator(ApplicationContext context)
        {
            this._context = context;
        }

        public User AuthorizatedUser
        {
            get { return authorizatedUser; }
        }

        public async Task<bool> LogInAsync(string email, string password)
        {
            //Console.WriteLine("Enter your email and press Enter key:");
            //string? email = Console.ReadLine();
            //Console.WriteLine("Enter your password and press Enter key:");
            //string? password = Console.ReadLine();
            try
            {
                var user = await this._context.Users.Where(x => x.Email == email).FirstOrDefaultAsync();

                if (user != null)
                {
                    if (password == user.Password)
                    {
                        //Console.WriteLine("Authorization successful!\n");
                        authorizatedUser = user;
                        return true;
                    }
                    else
                    {
                        //Console.WriteLine("\nEmail or password is not correct\n");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }

    }
}
