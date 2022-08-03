namespace EntitySchema
{
    public interface IMaterial
    {
        string? Title { get; set; }
        
        int Id { get; set; }
        
        User Creator { get; set; }
        
        MaterialType Type { get; }
    }
}
