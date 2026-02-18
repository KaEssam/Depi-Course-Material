<<<<<<< HEAD
﻿using Microsoft.EntityFrameworkCore;

namespace Day1.Models
{
    public class AppDbContext : DbContext
=======
﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Day1.Models
{
    //public class AppDbContext : DbContext
    public class AppDbContext : IdentityDbContext<AppUser>
>>>>>>> 6637ba3848b8a5abbbf0993260116f21b21a1fa6
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<TaskItem> taskItems { get; set; }

<<<<<<< HEAD
=======


>>>>>>> 6637ba3848b8a5abbbf0993260116f21b21a1fa6
    }
}
