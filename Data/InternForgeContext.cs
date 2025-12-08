using InternForge.Models;
using InternForge.Models.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace InternForge.Data;

public class InternForgeContext(DbContextOptions<InternForgeContext> options) : IdentityDbContext<IdentityModel.User, IdentityModel.Role, long, IdentityModel.UserClaim, IdentityModel.UserRole, IdentityModel.UserLogin, IdentityModel.RoleClaim, IdentityModel.UserToken>(options)
{
    public DbSet<Project> Projects { get; set; }
    public DbSet<Application> Applications { get; set; }
    public DbSet<PortfolioEntry> PortfolioEntries { get; set; }
    public DbSet<Certificate> Certificates { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        // Your custom tables
        modelBuilder.Entity<Project>().ToTable("Projects");
        modelBuilder.Entity<Application>().ToTable("Applications");
        modelBuilder.Entity<PortfolioEntry>().ToTable("PortfolioEntries");
        modelBuilder.Entity<Certificate>().ToTable("Certificates");

        // Fix: prevent cascade delete loops
        foreach (var fk in modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetForeignKeys())
            .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade))
        {
            fk.DeleteBehavior = DeleteBehavior.Restrict;
        }

        // ✔ Corrected: use your actual Identity model classes with long keys
        modelBuilder.Entity<IdentityModel.UserLogin>(entity =>
        {
            entity.HasKey(l => new { l.LoginProvider, l.ProviderKey, l.UserId });
            entity.Property(l => l.LoginProvider).HasMaxLength(128);
            entity.Property(l => l.ProviderKey).HasMaxLength(128);
        });

        modelBuilder.Entity<IdentityModel.UserToken>(entity =>
        {
            entity.HasKey(t => new { t.UserId, t.LoginProvider, t.Name });
            entity.Property(t => t.LoginProvider).HasMaxLength(128);
            entity.Property(t => t.Name).HasMaxLength(128);
        });
    }

}
