namespace basicFunctions_DB.DAL.CourseType
{
    public class Skill
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public List<Course> Courses { get; set; }

        public int Id { get; set; }
    }
}
