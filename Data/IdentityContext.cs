using InternForge.Models.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InternForge.Data
{
    public class IdentityContext : IdentityDbContext<
        IdentityModel.User,
        IdentityModel.Role,
        long,
        IdentityModel.UserClaim,
        IdentityModel.UserRole,
        IdentityModel.UserLogin,
        IdentityModel.RoleClaim,
        IdentityModel.UserToken>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // keep your composite keys (like you had)
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
}
