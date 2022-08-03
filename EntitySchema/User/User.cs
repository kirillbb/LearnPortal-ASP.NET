namespace EntitySchema
{
    public class User
    {
        public string? Name { get; set; }

        public string? Email { get; set; }

        public DateTime Created { get; set; }

        public int Id { get; set; }

        public string? Password { get; set; }

        public List<SkillState> UserSkillList { get; set; }

        public List<Course> CompletedCourse { get; set; }
    }
}