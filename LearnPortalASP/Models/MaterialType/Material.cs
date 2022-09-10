namespace LearnPortalASP.MaterialType
{
    using LearnPortalASP.UserType;

    public partial class Material
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public User Creator { get; set; }
    }
}
