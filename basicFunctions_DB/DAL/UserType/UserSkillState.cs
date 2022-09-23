using basicFunctions_DB.DAL.CourseType;

namespace basicFunctions_DB.DAL.UserType
{
    public class UserSkillState
    {
        public int Id { get; set; }

        public Skill Skill { get; set; }

        public ApplicationUser User { get; set; }

        public int Level { get; set; }
    }
}
