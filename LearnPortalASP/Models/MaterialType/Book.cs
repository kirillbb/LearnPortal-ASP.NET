namespace LearnPortalASP.Models.MaterialType
{
    public class Book : Material
    {
        public string? Author { get; set; }

        public DateTime PublicationDate { get; set; }

        public int Pages { get; set; }

        public string BookFormat { get; set; }
    }
}
