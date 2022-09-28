namespace basicFunctions_DB.DAL.UserType
{
    using basicFunctions_DB.DAL.CourseType;

    public class UserSkillState
    {
        public int Id { get; set; }

        public Skill Skill { get; set; }

        public User User { get; set; }

        public int Level { get; set; }
    }
}
