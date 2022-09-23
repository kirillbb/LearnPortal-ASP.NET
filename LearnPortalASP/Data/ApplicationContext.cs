namespace LearnPortalASP.Data
{
    using LearnPortalASP.Models.CourseType;
    using LearnPortalASP.Models.MaterialType;
    using LearnPortalASP.Models.UserType;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationContext : IdentityDbContext
    {
        public ApplicationContext()
        {
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApplicationUser> Users { get; set; } = null!;
        
        public DbSet<Material> Materials { get; set; } = null!;
        
        public DbSet<Book> Books { get; set; } = null!;
        
        public DbSet<Video> Videos { get; set; } = null!;
        
        public DbSet<Publication> Publications { get; set; } = null!;

        public DbSet<Course> Courses { get; set; } = null!;
        
        public DbSet<Student> Students { get; set; } = null!;


        public DbSet<Skill> Skills { get; set; } = null!;

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=DESKTOP-6KJ2COE;Database=LearnPortal;Trusted_Connection=True;");
        //}
    }
}
