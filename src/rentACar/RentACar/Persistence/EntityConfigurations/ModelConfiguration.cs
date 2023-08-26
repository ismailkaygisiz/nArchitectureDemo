using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class ModelConfiguration : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.ToTable("Models").HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("Id").IsRequired();
            builder.Property(e => e.Name).HasColumnName("Name").IsRequired();
            builder.Property(e => e.BrandId).HasColumnName("BrandId").IsRequired();
            builder.Property(e => e.FuelId).HasColumnName("FuelId").IsRequired();
            builder.Property(e => e.TransmissionId).HasColumnName("TransmissionId").IsRequired();
            builder.Property(e => e.DailyPrice).HasColumnName("DailyPrice").IsRequired();
            builder.Property(e => e.ImageUrl).HasColumnName("ImageUrl").IsRequired();

            builder.Property(e => e.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(e => e.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(e => e.DeletedDate).HasColumnName("DeletedDate");

            builder.HasIndex(indexExpression: e => e.Name, name: "UK_Models_Name").IsUnique();
            builder.HasOne(e => e.Brand);
            builder.HasOne(e => e.Fuel);
            builder.HasOne(e => e.Transmission);
            builder.HasMany(e => e.Cars);

            builder.HasQueryFilter(e => !e.DeletedDate.HasValue);
        }
    }
}
