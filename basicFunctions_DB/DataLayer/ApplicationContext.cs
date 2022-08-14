namespace basicFunctions_DB.DataLayer
{
    using basicFunctions_DB.DataLayer.CourseType;
    using basicFunctions_DB.DataLayer.MaterialType;
    using basicFunctions_DB.DataLayer.UserType;
    using Microsoft.EntityFrameworkCore;

    internal class ApplicationContext : DbContext
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
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-6KJ2COE;Database=LearnPortal_DB;Trusted_Connection=True;");
        }
    }
}
