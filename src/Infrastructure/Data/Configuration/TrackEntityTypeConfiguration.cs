using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class TrackEntityTypeConfiguration : IEntityTypeConfiguration<Track>
    {
        public void Configure(EntityTypeBuilder<Track> builder)
        {
            builder.ToTable("Track");

            builder.HasIndex(e => e.AlbumId)
                .HasName("IFK_TrackAlbumId");

            builder.HasIndex(e => e.GenreId)
                .HasName("IFK_TrackGenreId");

            builder.HasIndex(e => e.MediaTypeId)
                .HasName("IFK_TrackMediaTypeId");

            builder.Property(e => e.Id)
                .HasColumnName("TrackId")
                .ValueGeneratedNever();

            builder.Property(e => e.Composer).HasMaxLength(220);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.UnitPrice).HasColumnType("numeric(10, 2)");

            builder.HasOne(d => d.Album)
                .WithMany(p => p.Track)
                .HasForeignKey(d => d.AlbumId)
                .HasConstraintName("FK_TrackAlbumId");

            builder.HasOne(d => d.Genre)
                .WithMany(p => p.Track)
                .HasForeignKey(d => d.GenreId)
                .HasConstraintName("FK_TrackGenreId");

            builder.HasOne(d => d.MediaType)
                .WithMany(p => p.Track)
                .HasForeignKey(d => d.MediaTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TrackMediaTypeId");
        }
    }
}
