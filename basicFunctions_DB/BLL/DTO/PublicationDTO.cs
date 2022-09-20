namespace basicFunctions_DB.BLL.DTO
{
    internal class PublicationDTO : MaterialDTO
    {
        public DateTime CreationDate { get; set; }

        public string? Source { get; set; }
    }
}
