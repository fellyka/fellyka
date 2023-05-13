using fellyka.Model;
using Microsoft.EntityFrameworkCore;

namespace fellyka.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts)
        {   }
        public DbSet<Category> Categories { get; set; }
    }
}