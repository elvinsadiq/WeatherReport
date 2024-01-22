using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.Property(c => c.CountryName)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(c => c.Provinces)
                   .WithOne(c => c.Country)
                   .HasForeignKey(c => c.CountryId)
                   .IsRequired();
        }
    }
}