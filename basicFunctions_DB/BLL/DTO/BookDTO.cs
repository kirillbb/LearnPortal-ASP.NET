namespace basicFunctions_DB.BLL.DTO
{
    public class BookDTO : MaterialDTO
    {
        public string? Author { get; set; }

        public DateTime PublicationDate { get; set; }

        public int Pages { get; set; }

        public string BookFormat { get; set; }
    }
}
