using System.ComponentModel.DataAnnotations;

namespace LearnPortalASP.BLL.DTO
{
    public class SkillDTO
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public List<CourseDTO>? Courses { get; set; }

        public int Id { get; set; }

        [Required(ErrorMessage = "You must be authorizated!")]
        public string CreatorUserName { get; set; }
    }
}
