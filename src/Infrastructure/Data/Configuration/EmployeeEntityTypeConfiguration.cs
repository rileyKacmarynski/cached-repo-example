using ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class EmployeeEntityTypeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasIndex(e => e.ReportsTo)
            .HasName("IFK_EmployeeReportsTo");

            builder.Property(e => e.Id)
                .HasColumnName("EmployeeId")
                .ValueGeneratedNever();

            builder.Property(e => e.Address).HasMaxLength(70);

            builder.Property(e => e.BirthDate).HasColumnType("datetime");

            builder.Property(e => e.City).HasMaxLength(40);

            builder.Property(e => e.Country).HasMaxLength(40);

            builder.Property(e => e.Email).HasMaxLength(60);

            builder.Property(e => e.Fax).HasMaxLength(24);

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(e => e.HireDate).HasColumnType("datetime");

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(e => e.Phone).HasMaxLength(24);

            builder.Property(e => e.PostalCode).HasMaxLength(10);

            builder.Property(e => e.State).HasMaxLength(40);

            builder.Property(e => e.Title).HasMaxLength(30);

            builder.HasOne(d => d.ReportsToNavigation)
                .WithMany(p => p.InverseReportsToNavigation)
                .HasForeignKey(d => d.ReportsTo)
                .HasConstraintName("FK_EmployeeReportsTo");
        }
    }
}
