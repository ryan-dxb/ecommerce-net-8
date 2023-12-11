using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ecommerce_net_9.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                    new IdentityRole()
                    {
                        Id = "b3f7d8a0-1bdf-4b1e-9f9f-2b5d2e9d5b9c",
                        Name = Constants.Roles.Admin,
                        NormalizedName = Constants.Roles.Admin.ToUpper()
                    },
                    new IdentityRole()
                    {
                        Id = "c5f5a0a0-1bdf-4b1e-9f9f-2b5d2e9d5b9c",
                        Name = Constants.Roles.Customer,
                        NormalizedName = Constants.Roles.Customer.ToUpper()
                    });
        }
    }
}
