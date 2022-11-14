using ClearBank.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ClearBank.Persistance.Configurations
{
    public class AllowedPaymentSchemeConfigurations : IEntityTypeConfiguration<AllowedPaymentScheme>
    {
        public void Configure(EntityTypeBuilder<AllowedPaymentScheme> builder)
        {
            builder.ToTable(name: "AllowedPaymentScheme", schema: "ClearBank")
                .HasKey(acc => new { acc.ID });

            builder.Property(e => e.Name)
                   .HasColumnName("Name")
                   .HasColumnType("VARCHAR")
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(e => e.ID)
                   .HasColumnName("ID")
                   .HasColumnType("INT")
                   .IsRequired();
        }
    }
}
