namespace basicFunctions_DB.BLL.DTO
{
    internal class BookDTO : MaterialDTO
    {
        public string? Author { get; set; }

        public DateTime PublicationDate { get; set; }

        public int Pages { get; set; }

        public string BookFormat { get; set; }

        public override string ToString()
        {
            return $"ID: {Id} | Title: \"{Title}\" | Author: {Author} | Publication date: {PublicationDate.ToString("d")} | {Pages} pages | Format: {BookFormat} | added: {Creator.ToString()} ";
        }
    }
}
