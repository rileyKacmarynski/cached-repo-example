using ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class MediaTypeEntityTypeConfiguration : IEntityTypeConfiguration<MediaType>
    {
        public void Configure(EntityTypeBuilder<MediaType> builder)
        {
            builder.Property(e => e.Id)
                .HasColumnName("MediaTypeId")
                .ValueGeneratedNever();
            builder.Property(e => e.Name).HasMaxLength(120);
        }
    }
}
