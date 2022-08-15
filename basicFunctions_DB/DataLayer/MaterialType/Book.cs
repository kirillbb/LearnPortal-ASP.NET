namespace basicFunctions_DB.DataLayer.MaterialType
{
    public class Book : Material
    {
        public string? Author { get; set; }

        public DateTime PublicationDate { get; set; }

        public int Pages { get; set; }

        public string BookFormat { get; set; }

        public override string ToString()
        {
            return $"{Author} - ({PublicationDate}), {Pages} pages - {BookFormat}";
        }
    }
}
