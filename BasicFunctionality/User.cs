namespace Portal
{
    public class User
    {
        public string? Email { get; internal set; }
        public string? Password { get; internal set; }
        public string? Name { get; internal set; }
        public static DateTime RegistrationDate { get; set; }
        public int Id { get; set; }
    }
}