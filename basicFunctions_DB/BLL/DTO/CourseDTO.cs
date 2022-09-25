using basicFunctions_DB.DAL.CourseType;
using basicFunctions_DB.DAL.MaterialType;
using System.ComponentModel.DataAnnotations;

namespace basicFunctions_DB.BLL.DTO
{
    public class CourseDTO
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public List<Material>? CourseMaterials { get; set; }

        public List<Skill>? CourseSkills { get; set; }

        [Required(ErrorMessage = "You must be authorizated!")]
        public string? CreatorUserName { get; set; }

        public ICollection<UserDTO>? Students { get; set; }
    }
}
