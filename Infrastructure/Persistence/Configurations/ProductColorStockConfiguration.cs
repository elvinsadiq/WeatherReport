using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    public class ProductColorStockConfiguration : IEntityTypeConfiguration<ProductColorStock>
    {
        public void Configure(EntityTypeBuilder<ProductColorStock> builder)
        {
            builder.Property(pi => pi.StockCount)
                 .IsRequired();

            builder.HasOne(pi => pi.Product)
                .WithMany(p => p.ProductColorStocks)
                .HasForeignKey(pi => pi.ProductId);

            builder.HasOne(pi => pi.Color)
               .WithMany(p => p.ProductColorStocks)
               .HasForeignKey(pi => pi.ColorId);

        }
    }
}
