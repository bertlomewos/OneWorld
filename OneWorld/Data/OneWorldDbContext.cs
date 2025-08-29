using Microsoft.EntityFrameworkCore;
using OneWorld.Model;
namespace OneWorld.Data
{
    public class OneWorldDbContext : DbContext
    {
        public OneWorldDbContext(DbContextOptions<OneWorldDbContext> options) : base(options) { }
        public DbSet<Developer> Developers => Set<Developer>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<ProductScreenShoot> ProductScreenShoots => Set<ProductScreenShoot>();
    }
}
