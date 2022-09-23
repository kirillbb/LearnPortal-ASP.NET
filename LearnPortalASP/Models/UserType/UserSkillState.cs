using LearnPortalASP.Models.CourseType;

namespace LearnPortalASP.Models.UserType
{
    public class UserSkillState
    {
        public int Id { get; set; }

        public Skill Skill { get; set; }

        public ApplicationUser User { get; set; }

        public int Level { get; set; }
    }
}
