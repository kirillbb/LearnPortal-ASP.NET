namespace basicFunctions_DB.BLL.Authorization
{
    using basicFunctions_DB.BLL.Interfaces;
    using basicFunctions_DB.DAL;
    using basicFunctions_DB.DAL.UserType;

    public class Registrator : IRegistrator
    {
        private readonly ApplicationContext _context;

        public Registrator(ApplicationContext context)
        {
            this._context = context;
        }

        public bool SignUp(string email, string password, string name)
        {
            //
            //string? name = Console.ReadLine();
            //
            //string? email = Console.ReadLine();
            //
            //string? password = Console.ReadLine();

            if (password != null && password != string.Empty && email != string.Empty && email != null && name != null)
            {
                //if (!IsExistingUser(email))
                //{
                //    User user = new User { Email = email, FirstName = name, Password = password };
                //    SaveUserInDataBase(user);
                //    return true;
                //}
                //else
                //{
                //    return false;
                //}
                return false;
            }
            else
            {
                //Console.WriteLine("email or password can't be empty!\n");
                return false;
            }
        }

        private bool IsExistingUser(string email)
        {
            var user = this._context.Users.Where(x => x.Email == email).FirstOrDefault();

            return user != null;
        }

        private void SaveUserInDataBase(ApplicationUser user)
        {
            this._context.Users.Add(user);
            this._context.SaveChanges();
        }
    }
}
