namespace LearnPortalASP.Models.UserType
{
    public class ApplicationUser
    {
        public string Id { get; set; }

        public string Email { get; internal set; }

        public string UserName { get; internal set; }

        public string FirstName { get; internal set; }

        public string LastName { get; internal set; }

        public List<UserSkillState> UserSkillList { get; set; }
    }
}
