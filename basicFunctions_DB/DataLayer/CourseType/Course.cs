using basicFunctions_DB.DataLayer.MaterialType;
using basicFunctions_DB.DataLayer.UserType;

namespace basicFunctions_DB.DataLayer.CourseType
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
