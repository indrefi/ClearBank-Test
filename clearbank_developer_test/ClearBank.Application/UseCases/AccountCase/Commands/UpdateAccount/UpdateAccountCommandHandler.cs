using AutoMapper;
using ClearBank.Application.Exceptions;
using ClearBank.Application.Interfaces;
using ClearBank.Domain.Entities;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace ClearBank.Application.UseCases.AccountCase.Commands.UpdateAccount
{
    public class UpdateAccountCommandHandler : IUpdateAccountCommandHandler
    {
        private readonly IClearBankDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateAccountCommandHandler(IClearBankDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<UpdateAccountResponse> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            var account = await _dbContext.Accounts
            .SingleOrDefaultAsync(x => x.AccountNumber == request.AccountNumber, cancellationToken);

            if (account != null)
            {
                account.Balance = request.Balance;
                _dbContext.Accounts.Update(account);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return new UpdateAccountResponse();
            }

            throw new NotFoundException(nameof(Account), request.AccountNumber);
        }
    }
}
