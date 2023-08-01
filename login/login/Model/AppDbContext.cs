using Microsoft.EntityFrameworkCore;

namespace login.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<User> User { get; set; } = default;
    }
}
