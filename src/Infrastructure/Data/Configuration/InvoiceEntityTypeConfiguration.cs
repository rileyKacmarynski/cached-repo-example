using ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class InvoiceEntityTypeConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasIndex(e => e.CustomerId)
            .HasName("IFK_InvoiceCustomerId");

            builder.Property(e => e.InvoiceId).ValueGeneratedNever();

            builder.Property(e => e.BillingAddress).HasMaxLength(70);

            builder.Property(e => e.BillingCity).HasMaxLength(40);

            builder.Property(e => e.BillingCountry).HasMaxLength(40);

            builder.Property(e => e.BillingPostalCode).HasMaxLength(10);

            builder.Property(e => e.BillingState).HasMaxLength(40);

            builder.Property(e => e.InvoiceDate).HasColumnType("datetime");

            builder.Property(e => e.Total).HasColumnType("numeric(10, 2)");

            builder.HasOne(d => d.Customer)
                .WithMany(p => p.Invoice)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InvoiceCustomerId");
        }
    }
}
