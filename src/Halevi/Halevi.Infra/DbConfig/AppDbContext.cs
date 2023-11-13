using Halevi.Infra.DbConfig.Configurations;

using Microsoft.EntityFrameworkCore;

namespace Halevi.Infra.DbConfig
{
    public class AppDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());

            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            modelBuilder.ApplyConfiguration(new ProductVariationConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
