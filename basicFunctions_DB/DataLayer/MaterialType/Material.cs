namespace basicFunctions_DB.DataLayer.MaterialType
{
    using basicFunctions_DB.DataLayer.UserType;

    public partial class Material
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public User Creator { get; set; }
    }

    public class Book : Material
    {
        public string? Author { get; set; }

        public DateTime PublicationDate { get; set; }

        public int Pages { get; set; }

        public string BookFormat { get; set; }
    }

    public class Video : Material
    {
        public int Resolution { get; set; }

        public int Duration { get; set; }
    }
    public class Publication : Material
    {
        public DateTime CreationDate { get; set; }

        public string? Source { get; set; }
    }
}
