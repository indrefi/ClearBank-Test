using ClearBank.Application.UseCases.Payment.Commnads.MakePayment;
using MediatR;

namespace ClearBank.Application.UseCases.Payment.Commands.MakePayment
{
    public interface IMakePaymentCommandHandler : IRequestHandler<MakePaymentCommand, MakePaymentResult>
    {
    }
}
