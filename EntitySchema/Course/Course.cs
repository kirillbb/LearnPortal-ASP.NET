namespace EntitySchema
{
    public class Course
    {
        public int Id { get; set; }
        
        public string? Name { get; set; }
        
        public string Description { get; set; }
        
        public List<IMaterial> MaterialList { get; set; }
        
        public List<Skill> CourseSkillList { get; set; }
        
        public User Creator { get; set; }
    }
}
