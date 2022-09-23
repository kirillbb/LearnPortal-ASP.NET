namespace LearnPortalASP.BLL.Interfaces
{
    public interface IRegistrator
    {
        public bool SignUp(string email, string password, string name);
    }
}