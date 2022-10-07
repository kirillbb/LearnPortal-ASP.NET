namespace LearnPortalASP.Models.MaterialType
{
    using LearnPortalASP.Models.CourseType;

    public partial class Material
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string CreatorUserName { get; set; }

        public string Discriminator { get; set; }

        public List<Course>? Courses { get; set; }

        public override string ToString()
        {
            return $"{Title}({Discriminator})";
        }
    }
}
