using ClearBank.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;
using ClearBank.Domain.Entities;

namespace ClearBank.Persistance
{
    public class ClearBankDbContext : DbContext, IClearBankDbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountStatus> AccountStatuses { get; set; }
        public DbSet<AllowedPaymentScheme> AllowedPaymentSchemes { get; set; }

        public ClearBankDbContext(DbContextOptions<ClearBankDbContext> options)
            : base(options)
        {
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClearBankDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

    }
}
