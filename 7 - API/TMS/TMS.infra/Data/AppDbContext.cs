using Microsoft.EntityFrameworkCore;
using TMS.core.Entites;

namespace TMS.infra.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<TaskItem> Tasks { get; set; }
       public DbSet<User> users { get; set; }
    }
}
