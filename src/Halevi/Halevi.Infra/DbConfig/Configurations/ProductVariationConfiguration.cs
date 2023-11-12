using Halevi.Core.Domain.Entities;
using Halevi.Infra.Constants;
using Halevi.Infra.DbConfig.Configurations.Base;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Halevi.Infra.DbConfig.Configurations
{
    public class ProductVariationConfiguration : BaseConfiguration<ProductVariation>
    {
        public override void Configure(EntityTypeBuilder<ProductVariation> builder)
        {
            base.Configure(builder);

            builder
                .Property(pv => pv.Name)
                .IsRequired();

            builder
                .Property(pv => pv.Image)
                .HasColumnType(SQLiteDataTypes.BLOB);

            builder
                .HasOne(pv => pv.Product)
                .WithMany(p => p.ProductVariations)
                .HasForeignKey(pv => pv.ProductId)
                .IsRequired();
        }
    }
}
