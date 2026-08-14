using Microsoft.EntityFrameworkCore;
using Products.Core.Entities;

namespace Products.Infrastructure.Peristincy
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Product> products { get; set; }
    }
}
