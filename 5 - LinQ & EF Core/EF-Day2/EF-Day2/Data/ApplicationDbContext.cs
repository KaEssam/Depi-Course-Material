using EF_Day2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace EF_Day2.Data
{
    class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext():base()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=EF2;Trusted_Connection=True;Trust Server Certificate = True;");

        }

        DbSet<Employee> Employees { get; set; }
        DbSet<Department> Departments { get; set; }
        DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .HasKey(p => p.ProjectSsN); //pk

            modelBuilder.Entity<Project>()
                .Property(p => p.ProjectSsN)
                .ValueGeneratedOnAdd();


            modelBuilder.Entity<Project>()
                .Property(p => p.Name)
                .IsRequired()
                .HasColumnName("ProjectN")
                .HasMaxLength(250);

            modelBuilder.Entity<Project>()
                .HasKey(p => new { p.ProjectSsN, p.Name });

            modelBuilder.Entity<Employee>()
                .Property(e => e.CreatedAt)
                .HasDefaultValueSql("GETDATE()");


            //1:m
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);


            ////1:1
            //modelBuilder.Entity<Department>()
            //    .HasOne(d => d.Manager)
            //    .WithOne(e => e.department)
            //    .HasForeignKey<Employee>(e => e.DepartmentId);

            ////m:m
            //modelBuilder.Entity<Project>()
            //    .HasMany(p => p.Departments)
            //    .WithMany(d => d.Projects)
            //    .UsingEntity(c => c.ToTable("projDept"));

            ////self

            //modelBuilder.Entity<Employee>()
            //    .HasOne(e => e.Super)
            //    .WithMany(e => e.emps)
            //    .HasForeignKey(e => e.SuperId)
            //    .OnDelete(DeleteBehavior.NoAction);



        }
    }
}
