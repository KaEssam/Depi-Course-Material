using Microsoft.EntityFrameworkCore;

namespace Day1.Data
{
    public class AppDbContext: DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options):base( options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
    }
}
