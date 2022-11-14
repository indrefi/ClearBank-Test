using MediatR;

namespace ClearBank.Application.UseCases.AccountCase.Queries.GetAccount
{
    public interface IGetAccountQueryHandler : IRequestHandler<GetAccountQuery, AccountDto>
    {
    }
}