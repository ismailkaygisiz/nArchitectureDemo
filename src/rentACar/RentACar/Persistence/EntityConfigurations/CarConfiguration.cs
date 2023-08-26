using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("Cars").HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("Id").IsRequired();
            builder.Property(e => e.ModelId).HasColumnName("ModelId").IsRequired();
            builder.Property(e => e.Kilometer).HasColumnName("Kilometer").IsRequired();
            builder.Property(e => e.ModelYear).HasColumnName("ModelYear").IsRequired();
            builder.Property(e => e.Plate).HasColumnName("Plate").IsRequired();
            builder.Property(e => e.MinFindexScore).HasColumnName("MinFindexScore").IsRequired();
            builder.Property(e => e.CarState).HasColumnName("CarState").IsRequired();

            builder.Property(e => e.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(e => e.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(e => e.DeletedDate).HasColumnName("DeletedDate");

            builder.HasOne(e => e.Model);

            builder.HasQueryFilter(e => !e.DeletedDate.HasValue);
        }
    }
}
