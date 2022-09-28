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
            _context = context;
        }

        public bool SignUp(string email, string password, string name)
        {
            if (password != null && password != string.Empty && email != string.Empty && email != null && name != null)
            {
                if (!IsExistingUser(email))
                {
                    User user = new User { Email = email, Name = name, Password = password };
                    SaveUserInDataBase(user);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private bool IsExistingUser(string email)
        {
            var user = _context.Users.Where(x => x.Email == email).FirstOrDefault();

            return user != null;
        }

        private void SaveUserInDataBase(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
