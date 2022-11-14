using MediatR;

namespace ClearBank.Application.UseCases.AccountCase.Commands.UpdateAccount
{
    public class UpdateAccountCommand : IRequest<UpdateAccountResponse>
    {
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
    }
}
