namespace basicFunctions_DB.BLL.DTO
{
    using basicFunctions_DB.DAL.CourseType;
    using basicFunctions_DB.DAL.UserType;

    internal class UserDTO
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
