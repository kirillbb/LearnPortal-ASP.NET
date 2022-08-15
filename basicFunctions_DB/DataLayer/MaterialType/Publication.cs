namespace basicFunctions_DB.DataLayer.MaterialType
{
    public class Publication : Material
    {
        public DateTime CreationDate { get; set; }

        public string? Source { get; set; }
        public override string ToString()
        {
            return $"({CreationDate}), {Source}";
        }
    }
}
