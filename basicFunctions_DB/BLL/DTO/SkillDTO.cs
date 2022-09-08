namespace basicFunctions_DB.BLL.DTO
{
    internal class SkillDTO
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public List<CourseDTO> Courses { get; set; }

        public int Id { get; set; }

        public override string ToString()
        {
            return $"ID: {Id} | Name: {Name} | Description: {Description}";
        }
    }
}
