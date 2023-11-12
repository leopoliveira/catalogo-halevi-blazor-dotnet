using Halevi.Core.Domain.Entities;
using Halevi.Infra.Constants;
using Halevi.Infra.DbConfig.Configurations.Base;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Halevi.Infra.DbConfig.Configurations
{
    public class ProductConfiguration : BaseConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);

            builder
                .Property(p => p.Name)
                .IsRequired();

            builder
                .Property(p => p.InStock)
                .HasColumnType(SQLiteDataTypes.INTEGER);

            builder
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .IsRequired();

            builder
                .Navigation(p => p.ProductVariations)
                .UsePropertyAccessMode(PropertyAccessMode.Property);
        }
    }
}
