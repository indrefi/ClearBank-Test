using MediatR;

namespace ClearBank.Application.UseCases.AccountCase.Commands.UpdateAccount
{
    public interface IUpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand, UpdateAccountResponse>
    {
    }
}