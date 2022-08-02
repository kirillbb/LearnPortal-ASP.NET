namespace BasicFunctionality
{
    public class User
    {
        public User(string email, string password, string name, int id)
        {
            Email = email;
            Password = password;
            Name = name;
            Id = id;
        }

        public string? Email { get; internal set; }

        public string? Password { get; internal set; }

        public string? Name { get; internal set; }

        public int Id { get; set; }
    }
}