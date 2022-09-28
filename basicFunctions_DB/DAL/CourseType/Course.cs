namespace basicFunctions_DB.DAL.CourseType
{
    using basicFunctions_DB.DAL.MaterialType;
    using basicFunctions_DB.DAL.UserType;

    public class Course
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public List<Material>? CourseMaterials { get; set; }

        public List<Skill>? CourseSkills { get; set; }

        public int CreatorId { get; set; }

        public List<User> Students { get; set; }

        public override string ToString()
        {
            return $"ID: {Id} | Name: {Name} | Description: {Description}";
        }
    }
}
