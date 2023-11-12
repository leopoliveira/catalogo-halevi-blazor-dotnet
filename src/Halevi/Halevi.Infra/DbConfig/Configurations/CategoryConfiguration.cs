using Halevi.Core.Domain.Entities;
using Halevi.Infra.DbConfig.Configurations.Base;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Halevi.Infra.DbConfig.Configurations
{
    public class CategoryConfiguration : BaseConfiguration<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);

            builder
                .Property(c => c.Name)
                .IsRequired();

            builder
                .Navigation(c => c.Products)
                .UsePropertyAccessMode(PropertyAccessMode.Property);
        }
    }
}
