using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static InternForge.Models.Auth.IdentityModel;

namespace InternForge.Configuration.AuthConfiguration;

public class RoleConfiguration :IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasData(new Role
        {
            Id = 1,
            Name = "SME",
            NormalizedName = "SME",
            Description = "Default role assigned to all employees."

        }, new Role
        {
            Id = 2,
            Name = "User",
            NormalizedName = "User",
            Description = "Default role assigned to all employees."
        });
    }
}