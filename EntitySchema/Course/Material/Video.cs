namespace EntitySchema
{
    public partial class Video : IMaterial
    {
        public int Resolution { get; set; }
        
        public int Duration { get; set; }
        
        public string? Title { get; set; }
        
        public int Id { get; set; }
        
        public User Creator { get; set; }
        
        public MaterialType Type { get; } = MaterialType.Video;
    }
}
