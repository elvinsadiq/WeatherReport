using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.Property(bi => bi.AppUserId)
                .IsRequired();
                

            builder.Property(bi => bi.ProductId)
                .IsRequired();

            builder.Property(bi => bi.ColorId)
               .IsRequired();

            builder.Property(bi => bi.Count)
                .IsRequired();


            builder.HasOne(bi => bi.AppUser)
                .WithMany(au => au.CartItems)
                .HasForeignKey(bi => bi.AppUserId);

            builder.HasOne(bi => bi.Product)
                .WithMany(p => p.CartItems)
                .HasForeignKey(bi => bi.ProductId);

            builder.HasOne(bi => bi.Color)
               .WithMany(p => p.CartItems)
               .HasForeignKey(bi => bi.ColorId);

        }

    }
}
