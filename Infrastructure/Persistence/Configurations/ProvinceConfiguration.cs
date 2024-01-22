using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Configurations
{
    public class ProvinceConfiguration : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder)
        {
            builder.Property(p => p.ProvinceName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.CountryId)
                .IsRequired()
                .HasMaxLength(10);

            builder.HasOne(pi => pi.Country)
               .WithMany(p => p.Provinces)
               .HasForeignKey(pi => pi.CountryId);
        }
    }
}
