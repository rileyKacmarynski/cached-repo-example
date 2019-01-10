using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class GenreEntityTypeConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.Property(e => e.Id)
                .HasColumnName("GenreId")
                .ValueGeneratedNever();
            builder.Property(e => e.Name).HasMaxLength(120);
        }
    }
}
