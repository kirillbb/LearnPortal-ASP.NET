namespace basicFunctions_DB.DAL.MaterialType
{
    using basicFunctions_DB.DAL.UserType;

    public partial class Material
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public User Creator { get; set; }
    }
}
