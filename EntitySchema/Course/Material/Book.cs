namespace EntitySchema
{
    internal class Book : IMaterial
    {
        public string? Author { get; set; }
        
        public DateTime PublicationDate { get; set; }
        
        public int Pages { get; set; }
        
        public string BookFormat { get; set; }
        
        public string? Title { get; set; }
        
        public int Id { get; set; }
        
        public User Creator { get; set; }
        
        public MaterialType Type { get; } = MaterialType.Book;
    }
}
