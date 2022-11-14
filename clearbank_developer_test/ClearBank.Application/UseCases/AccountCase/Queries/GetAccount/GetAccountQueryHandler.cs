using AutoMapper;
using AutoMapper.QueryableExtensions;
using ClearBank.Application.Exceptions;
using ClearBank.Application.Interfaces;
using ClearBank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ClearBank.Application.UseCases.AccountCase.Queries.GetAccount
{
    public class GetAccountQueryHandler : IGetAccountQueryHandler
    {
        private readonly IClearBankDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAccountQueryHandler(IClearBankDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<AccountDto> Handle(GetAccountQuery request, CancellationToken cancellationToken)
        {
            var accounts = await _dbContext.Accounts
                .Where(x => x.AccountNumber == request.AccountNumber)
                .ProjectTo<AccountDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            if (accounts.Any())
            {
                // will be only one dto since account number is PK. Must use first due to lack of support on AutoMapper.
                return accounts.First(); 
            }

            throw new NotFoundException(nameof(Account), request.AccountNumber);
        }
    }
}
