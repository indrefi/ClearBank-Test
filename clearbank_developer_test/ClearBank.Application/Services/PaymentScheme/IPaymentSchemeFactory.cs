namespace ClearBank.Application.Services.PaymentScheme
{
    public interface IPaymentSchemeFactory
    {
        public IPaymentScheme GetPaymentSchemeInstance(string requestedValidation);
    }
}
