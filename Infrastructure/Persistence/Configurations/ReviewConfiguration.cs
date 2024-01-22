﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.CreatedAt)
            .IsRequired();

        builder.Property(r => r.Rate)
            .IsRequired();

        builder.Property(r => r.Text)
            .HasMaxLength(1000);

        builder.HasOne(r => r.Product)
            .WithMany(p => p.Reviews)
            .HasForeignKey(r => r.ProductId);

        builder.HasOne(r => r.AppUser)
            .WithMany(u => u.Reviews)
            .HasForeignKey(r => r.AppUserId);
    }
}

