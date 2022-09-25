namespace LearnPortalASP.BLL.DTO
{
    using LearnPortalASP.Models.CourseType;
    using LearnPortalASP.Models.UserType;

    public class UserDTO
    {
        public string Id { get; set; }

        public string Email { get; internal set; }

        public string FirstName { get; internal set; }

        public string Password { get; internal set; }

        public List<UserSkillState> UserSkillList { get; set; }

        public List<Course> Courses { get; set; }
    }
}
