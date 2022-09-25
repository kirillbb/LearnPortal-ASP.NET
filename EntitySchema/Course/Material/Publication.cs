namespace EntitySchema
{
    internal class Publication : IMaterial
    {
        public DateTime CreationDate { get; set; }

        public string? Source { get; set; }
        
        public string? Title { get; set; }
        
        public int Id { get; set; }
        
        public User Creator { get; set; }
        
        public MaterialType Type { get; } = MaterialType.Publication;
    }
}
