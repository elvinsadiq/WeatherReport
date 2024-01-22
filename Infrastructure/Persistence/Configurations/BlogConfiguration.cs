using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.Property(x => x.Header)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Text)
                .HasMaxLength(2000);

            builder.Property(x => x.CreatedDate)
                .IsRequired();

            builder.Property(p => p.AppUserId)
             .IsRequired();


            builder.Property(x => x.CategoryId)
                .IsRequired();
        }
    }
}