namespace LearnPortalASP.BLL.DTO
{
    public class SkillDTO
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public List<CourseDTO>? Courses { get; set; }

        public int Id { get; set; }
    }
}
