namespace NetCoreAppProj.Models
{
    using Microsoft.EntityFrameworkCore;
    using NetCoreAppProj.Models.Board;
    using NetCoreAppProj.Models.Identity;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Post> Posts { get; set; }
    }
}
