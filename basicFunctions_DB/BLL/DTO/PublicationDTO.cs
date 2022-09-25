namespace basicFunctions_DB.BLL.DTO
{
    public class PublicationDTO : MaterialDTO
    {
        public DateTime CreationDate { get; set; }

        public string? Source { get; set; }
    }
}
