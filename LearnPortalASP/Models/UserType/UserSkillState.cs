using LearnPortalASP.CourseType;

namespace LearnPortalASP.UserType
{
    public class UserSkillState
    {
        public int Id { get; set; }

        public Skill Skill { get; set; }

        public User User { get; set; }

        public int Level { get; set; }
    }
}
