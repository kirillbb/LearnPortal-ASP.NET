namespace LearnPortalASP.Models.CourseType
{
    using LearnPortalASP.Models.MaterialType;
    using System.ComponentModel.DataAnnotations;

    public class Course
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public List<Material>? CourseMaterials { get; set; }

        public List<Skill>? CourseSkills { get; set; }

        [Required(ErrorMessage = "You must be authorizated!")]
        public string CreatorUserName { get; set; }
    }
}
