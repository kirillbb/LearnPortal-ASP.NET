using LearnPortalASP.CourseType;
using LearnPortalASP.MaterialType;
using LearnPortalASP.UserType;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace LearnPortalASP.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;

        public DbSet<Material> Materials { get; set; } = null!;

        public DbSet<Book> Books { get; set; } = null!;

        public DbSet<Video> Videos { get; set; } = null!;

        public DbSet<Publication> Publications { get; set; } = null!;

        public DbSet<Course> Courses { get; set; } = null!;

        public DbSet<Skill> Skills { get; set; } = null!;
    }
}