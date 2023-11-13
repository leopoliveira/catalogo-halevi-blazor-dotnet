using System.Data;

using Halevi.Core.Domain.Entities;
using Halevi.Infra.DbConfig.Configurations;

using Microsoft.EntityFrameworkCore;

namespace Halevi.Infra.DbConfig
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> PRODUCT { get; set; }

        public DbSet<Category> CATEGORY { get; set; }

        public DbSet<ProductVariation> PRODUCTVARIATION { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());

            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            modelBuilder.ApplyConfiguration(new ProductVariationConfiguration());

            DataSeed(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private static void DataSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = new Guid("E1E7E405-4690-42E8-8423-DD9ECD389BC7"),
                Code = 1,
                CreatedAt = DateOnly.FromDateTime(DateTime.Now.ToLocalTime()),
                Active = true,
                Name = "Categoria 1"
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = new Guid("A4679709-46FC-4FE4-92BC-B227354ABAA7"),
                Code = 1,
                CreatedAt = DateOnly.FromDateTime(DateTime.Now.ToLocalTime()),
                Active = true,
                Name = "Produto 1",
                Description = "É o Produto 1",
                InStock = true,
                Price = 20.50d,
                CategoryId = new Guid("E1E7E405-4690-42E8-8423-DD9ECD389BC7")
            });

            modelBuilder.Entity<ProductVariation>().HasData(new ProductVariation
            {
                Id = new Guid("48250A1E-4B9B-4360-BE12-C41EC66219EA"),
                Code = 1,
                CreatedAt = DateOnly.FromDateTime(DateTime.Now.ToLocalTime()),
                Active = true,
                Name = "Variação do Produto 1",
                ProductId = new Guid("A4679709-46FC-4FE4-92BC-B227354ABAA7"),
            });
        }
    }
}
