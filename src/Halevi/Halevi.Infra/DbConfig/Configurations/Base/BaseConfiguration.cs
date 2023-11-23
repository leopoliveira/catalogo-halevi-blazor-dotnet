using Halevi.Core.Domain.Entities.Base;
using Halevi.Infra.Constants;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Halevi.Infra.DbConfig.Configurations.Base
{
    public class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntitiy
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasColumnType(SQLiteDataTypes.TEXT);

            builder
                .Property(x => x.Code)
                .HasColumnType(SQLiteDataTypes.INTEGER)
                .ValueGeneratedOnAdd();

            builder
                .Property(x => x.CreatedAt)
                .HasColumnType(SQLiteDataTypes.TEXT);

            builder
                .Property(x => x.Active)
                .HasColumnType(SQLiteDataTypes.INTEGER);

            builder
                .HasIndex(x => x.Code)
                .IsUnique();
        }
    }
}
