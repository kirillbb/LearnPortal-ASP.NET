namespace basicFunctions_DB.BLL.DTO
{
    internal class PublicationDTO : MaterialDTO
    {
        public DateTime CreationDate { get; set; }

        public string? Source { get; set; }
        public override string ToString()
        {
            return $"ID: {Id} | Title: \"{Title}\" | Source: {Source} | Creation date: {CreationDate.ToShortDateString} | added: {Creator.ToString} ";
        }
    }
}
