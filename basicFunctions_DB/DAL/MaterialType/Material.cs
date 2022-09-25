namespace basicFunctions_DB.DAL.MaterialType
{
    using basicFunctions_DB.DAL.CourseType;
    using basicFunctions_DB.DAL.UserType;

    public partial class Material
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string CreatorUserName { get; set; }

        public string Discriminator { get; set; }

        public List<Course>? Courses { get; set; }
    }
}
