using basicFunctions_DB.DataLayer.CourseType;

namespace basicFunctions_DB.DataLayer.UserType
{
    public class UserSkillState
    {
        public int Id { get; set; }

        public Skill Skill { get; set; }

        public User User { get; set; }

        public int Level { get; set; }
    }
}
