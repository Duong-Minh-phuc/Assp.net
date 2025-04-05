using Example_02.Model;
using Microsoft.EntityFrameworkCore;

namespace Example_02.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; } = null!;

    }
}
