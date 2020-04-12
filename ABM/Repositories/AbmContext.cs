using System;
using ABM.Models;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace ABM.Repositories
{
    public class AbmContext : DbContext
    {
        public AbmContext(DbContextOptions<AbmContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Persons").HasDiscriminator<string>("Discriminator")
            .HasValue<Employee>("Employee");
            modelBuilder.Entity<Person>().HasKey(p => p.ID);

            base.OnModelCreating(modelBuilder);

        }
    }
}