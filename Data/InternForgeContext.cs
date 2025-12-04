using InternForge.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace InternForge.Data
{
    public class InternForgeContext : DbContext
    {
        public InternForgeContext(DbContextOptions<InternForgeContext> options)
            : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<PortfolioEntry> PortfolioEntries { get; set; }
        public DbSet<Certificate> Certificates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Map table names (in case they differ)
            modelBuilder.Entity<Project>().ToTable("Projects");
            modelBuilder.Entity<Application>().ToTable("Applications");
            modelBuilder.Entity<PortfolioEntry>().ToTable("PortfolioEntries");
            modelBuilder.Entity<Certificate>().ToTable("Certificates");
        }
    }
}
