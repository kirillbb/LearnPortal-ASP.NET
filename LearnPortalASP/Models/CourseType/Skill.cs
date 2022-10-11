using System.ComponentModel.DataAnnotations;

namespace LearnPortalASP.Models.CourseType
{
    public class Skill
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public List<Course>? Courses { get; set; }

        public int Id { get; set; }

        [Required(ErrorMessage = "You must be authorizated!")]
        public string CreatorUserName { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
