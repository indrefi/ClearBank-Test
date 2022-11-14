using ClearBank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;

namespace ClearBank.Application.Interfaces
{
    public interface IClearBankDbContext : IBaseDbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountStatus> AccountStatuses { get; set; }
        public DbSet<AllowedPaymentScheme> AllowedPaymentSchemes { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}