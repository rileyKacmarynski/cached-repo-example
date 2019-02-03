using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class InvoiceLineEntityTypeConfiguration : IEntityTypeConfiguration<InvoiceLine>
    {
        public void Configure(EntityTypeBuilder<InvoiceLine> builder)
        {
            builder.ToTable("InvoiceLine");

            builder.HasIndex(e => e.InvoiceId)
                .HasName("IFK_InvoiceLineInvoiceId");

            builder.HasIndex(e => e.TrackId)
                .HasName("IFK_InvoiceLineTrackId");

            builder.Property(e => e.Id)
                .HasColumnName("InvoiceLineId")
                .ValueGeneratedNever();

            builder.Property(e => e.UnitPrice).HasColumnType("numeric(10, 2)");

            builder.HasOne(d => d.Invoice)
                .WithMany(p => p.InvoiceLine)
                .HasForeignKey(d => d.InvoiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InvoiceLineInvoiceId");

            builder.HasOne(d => d.Track)
                .WithMany(p => p.InvoiceLine)
                .HasForeignKey(d => d.TrackId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InvoiceLineTrackId");
        }
    }
}
