using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.SubTitle)
                .HasMaxLength(200);
            builder.Property(x => x.Introduction)
                .HasMaxLength(1000);

            builder.Property(p => p.SalePrice)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(p => p.CostPrice)
            .HasPrecision(18, 2)
            .IsRequired();

            builder.Property(p => p.DiscountPercent)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(x => x.Sku)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.CategoryId)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(d => d.Description)
                .WithOne(p => p.Product)
                .HasForeignKey<Description>(d => d.ProductId);



        }
    }
}
