namespace basicFunctions_DB.DataLayer.UserType
{
    using basicFunctions_DB.DataLayer.CourseType;

    public class User
    {
        public int Id { get; set; }

        public string Email { get; internal set; }

        public string Name { get; internal set; }

        public string Password { get; internal set; }

        public List<UserSkillState> UserSkillList { get; set; }

        public List<Course> CompletedCourse { get; set; }
    }
}
