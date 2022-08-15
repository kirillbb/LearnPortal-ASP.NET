namespace basicFunctions_DB.DataLayer.MaterialType
{
    using basicFunctions_DB.DataLayer.UserType;

    public partial class Material
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public User Creator { get; set; }
    }
}
