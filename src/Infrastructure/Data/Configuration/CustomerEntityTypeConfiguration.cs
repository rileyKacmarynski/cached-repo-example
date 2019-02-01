using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");

            builder.HasIndex(e => e.SupportRepId)
            .HasName("IFK_CustomerSupportRepId");

            builder.Property(e => e.Id)
                .HasColumnName("CustomerId")
                .ValueGeneratedNever();

            builder.Property(e => e.Address).HasMaxLength(70);

            builder.Property(e => e.City).HasMaxLength(40);

            builder.Property(e => e.Company).HasMaxLength(80);

            builder.Property(e => e.Country).HasMaxLength(40);

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(60);

            builder.Property(e => e.Fax).HasMaxLength(24);

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(e => e.Phone).HasMaxLength(24);

            builder.Property(e => e.PostalCode).HasMaxLength(10);

            builder.Property(e => e.State).HasMaxLength(40);

            builder.HasOne(d => d.SupportRep)
                .WithMany(p => p.Customer)
                .HasForeignKey(d => d.SupportRepId)
                .HasConstraintName("FK_CustomerSupportRepId");
        }
    }
}
