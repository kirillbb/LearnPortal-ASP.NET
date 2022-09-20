using basicFunctions_DB.DAL.CourseType;
using basicFunctions_DB.DAL.MaterialType;
using basicFunctions_DB.DAL.UserType;
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

        public virtual DbSet<User> Users { get; set; } = null!;

        public DbSet<Material> Materials { get; set; } = null!;

        public DbSet<Book> Books { get; set; } = null!;

        public DbSet<Video> Videos { get; set; } = null!;

        public DbSet<Publication> Publications { get; set; } = null!;

        public DbSet<Course> Courses { get; set; } = null!;

        public DbSet<Skill> Skills { get; set; } = null!;
    }
}