using ecommerce_net_9.Configuration;
using ecommerce_net_9.Models.AuthModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_net_9.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApiUser>
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}
