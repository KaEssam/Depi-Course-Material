using Microsoft.EntityFrameworkCore;

namespace Day1.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<TaskItem> taskItems { get; set; }

    }
}
