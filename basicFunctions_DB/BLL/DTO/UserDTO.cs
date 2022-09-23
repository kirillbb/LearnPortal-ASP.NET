using basicFunctions_DB.DAL.CourseType;
using basicFunctions_DB.DAL.UserType;

namespace basicFunctions_DB.BLL.DTO
{
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
