namespace basicFunctions_DB.DAL.UserType
{
    using basicFunctions_DB.DAL.CourseType;

    public class User
    {
        public int Id { get; set; }

        public string Email { get; internal set; }

        public string Name { get; internal set; }

        public string Password { get; internal set; }

        public List<UserSkillState> UserSkillList { get; set; }

        public List<Course> Courses { get; set; }

        public override string ToString()
        {
            return $"Id:{Id} | Name:{Name}";
        }
    }
}
