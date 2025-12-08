using InternForge.Models;
using InternForge.Models.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InternForge.Data
{
    public class InternForgeContext: IdentityDbContext<IdentityModel.User, IdentityModel.Role, long, IdentityModel.UserClaim, IdentityModel.UserRole, IdentityModel.UserLogin, IdentityModel.RoleClaim, IdentityModel.UserToken>
    {
        public InternForgeContext(DbContextOptions<InternForgeContext> options) : base(options)
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
