using basicFunctions_DB.DAL.MaterialType;
using basicFunctions_DB.DAL.UserType;

namespace basicFunctions_DB.DAL.CourseType
{
    public class Course
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public List<Material>? CourseMaterials { get; set; }

        public List<Skill>? CourseSkills { get; set; }

        public User? Creator { get; set; }
    }
}
