namespace basicFunctions_DB.BLL.Interfaces
{
    using basicFunctions_DB.DAL.UserType;

    internal interface IAuthorizator
    {
        public Task<bool> LogInAsync(string email, string password);
        public User AuthorizatedUser { get; }
    }
}
