namespace Portal
{
    public class User
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public DateTime Created { get; set; }
        public int Id { get; set; }
        public string? Password { get; set; }
        public List<Skill> UserSkillList { get; set; }
    }
}