namespace basicFunctions_DB.DAL
{
    using basicFunctions_DB.DAL.CourseType;
    using basicFunctions_DB.DAL.MaterialType;
    using basicFunctions_DB.DAL.UserType;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
        }

        public DbSet<User> Users { get; set; } = null!;
        
        public DbSet<Material> Materials { get; set; } = null!;
        
        public DbSet<Book> Books { get; set; } = null!;
        
        public DbSet<Video> Videos { get; set; } = null!;
        
        public DbSet<Publication> Publications { get; set; } = null!;

        public DbSet<Course> Courses { get; set; } = null!;

        public DbSet<Skill> Skills { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-6KJ2COE;Database=LearnPortal;Trusted_Connection=True;");
        }
    }
}
