using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using System.Configuration;
using System.Reflection;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class DataContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //Data Source=DESKTOP-LAEV069;Initial Catalog=Weekly;Integrated Security=True
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-LAEV069;Initial Catalog=Task;Integrated Security=True");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Write Fluent API configurations here

            //Property Configurations
            modelBuilder.Entity<Task>().Property(s => s.Status).HasDefaultValue(true).IsRequired();
            modelBuilder.Entity<Task>().Property(s => s.Status) .HasDefaultValue(true).IsRequired();
            modelBuilder.Entity<Task>().Property(s => s.Explanation).HasDefaultValue(true).IsRequired().HasMaxLength(250);
            modelBuilder.Entity<Task>().Property(s => s.TaskName).HasDefaultValue(true).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<User>().Property(s => s.FirstName).HasDefaultValue(true).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<User>().Property(s => s.LastName).HasDefaultValue(true).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<User>().Property(s => s.Email).HasDefaultValue(true).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<User>().Property(s => s.Password).HasDefaultValue(true).IsRequired().HasMaxLength(100);
            

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }



    }
}
