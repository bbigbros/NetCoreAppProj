namespace NetCoreAppProj.Models
{
    using JetBrains.Annotations;
    using Microsoft.EntityFrameworkCore;
    using NetCoreAppProj.Models.Identity;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) 
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
