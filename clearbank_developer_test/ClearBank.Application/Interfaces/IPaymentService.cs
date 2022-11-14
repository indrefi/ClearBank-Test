using ClearBank.Application.UseCases.Payment.Commnads.MakePayment;

namespace ClearBank.Application.Interfaces
{
    public interface IPaymentService
    {
        MakePaymentResult MakePayment(MakePaymentRequest request);
    }
}