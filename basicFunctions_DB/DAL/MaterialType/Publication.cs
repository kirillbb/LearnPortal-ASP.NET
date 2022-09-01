namespace basicFunctions_DB.DAL.MaterialType
{
    public class Publication : Material
    {
        public DateTime CreationDate { get; set; }

        public string? Source { get; set; }
    }
}
