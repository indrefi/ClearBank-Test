using ClearBank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClearBank.Persistance.Configurations
{
    public class AccountConfigurations : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable(name: "Account", schema: "ClearBank")
                .HasKey(cc => new { cc.AccountNumber });

            builder.Property(e => e.AccountNumber)
                   .HasColumnName("AccountNumber")
                   .HasColumnType("VARCHAR")
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(e => e.Balance)
                   .HasColumnName("Balance")
                   .HasColumnType("DECIMAL(13,3)")
                   .IsRequired();

            builder.Property(e => e.AccountStatusID)
                   .HasColumnName("AccountStatusID")
                   .HasColumnType("INT")
                   .IsRequired();

            builder.Property(e => e.AccountAllowedPaymentSchemeID)
                   .HasColumnName("AccountAllowedPaymentSchemeID")
                   .HasColumnType("INT")
                   .IsRequired();

            builder.HasOne(a => a.AccountStatus)
                  .WithMany(accs => accs.Accounts)
                  .HasForeignKey(a => a.AccountStatusID)
                  .HasPrincipalKey(accs => accs.ID);

            builder.HasOne(a => a.AllowedPaymentScheme)
                  .WithMany(accs => accs.Accounts)
                  .HasForeignKey(a => a.AccountAllowedPaymentSchemeID)
                  .HasPrincipalKey(accs => accs.ID);
        }
    }
}