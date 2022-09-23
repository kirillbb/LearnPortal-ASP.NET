namespace LearnPortalASP.BLL.Interfaces
{
    using LearnPortalASP.Models.UserType;

    internal interface IAuthorizator
    {
        public Task<bool> LogInAsync(string email, string password);

        public ApplicationUser AuthorizatedUser { get; }
    }
}
