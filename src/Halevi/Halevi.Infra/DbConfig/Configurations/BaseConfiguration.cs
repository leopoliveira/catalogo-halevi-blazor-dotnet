using Halevi.Core.Domain.Entities;
using Halevi.Core.Domain.Entities.Base;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Halevi.Infra.DbConfig.Configurations
{
    public class BaseConfiguration : IEntityTypeConfiguration<BaseEntitiy>
    {
        public void Configure(EntityTypeBuilder<BaseEntitiy> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Code)
                .HasColumnType("INTEGER")
                .ValueGeneratedOnAdd();

            builder
                .Property(x => x.CreatedAt)
                .HasColumnType("TEXT");

            builder
                .Property(x => x.Active)
                .HasColumnType("INTEGER");
        }
    }
}
