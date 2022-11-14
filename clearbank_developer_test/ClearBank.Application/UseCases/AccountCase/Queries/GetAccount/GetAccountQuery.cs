using MediatR;

namespace ClearBank.Application.UseCases.AccountCase.Queries.GetAccount
{
    public class GetAccountQuery : IRequest<AccountDto>
    {
        public string AccountNumber { get; set; }
    }
}