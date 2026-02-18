using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Day1_EF
{
    internal class AppDbContext : DbContext
    {
       public DbSet<Category> categories { get; set; }
       public DbSet<Product> products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EFCore;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            //modelBuilder.Entity<Category>(entity =>
            //{
            //    entity.ToTable("Category");
            //    entity.HasKey(c => c.CategoryCode);
            //    entity.Property(c => c.Name).IsRequired().HasMaxLength(50);
            //});

            //modelBuilder.Entity<Product>(entity =>
            //{
            //    entity.ToTable("product");
            //    entity.HasKey(p => p.Id);


            //    entity.HasOne(p => p.category).WithMany(c => c.Products)
            //    .HasForeignKey(p=> p.CategoryId).OnDelete(DeleteBehavior.Restrict);


            //    entity.HasMany(p => p.Orders)
            //     .WithMany(o => o.products)
            //     .UsingEntity(i => i.ToTable("product_order"));


            //    //entity.HasMany(p =>p.Abdos)
            //    //.WithOne(a => a.tests)
            //});
        }
    }
}
