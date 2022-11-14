using ClearBank.Application.UseCases.AccountCase.Queries.GetAccount;

namespace ClearBank.Application.Services.PaymentScheme
{
    public interface IPaymentScheme
    {
        public bool ValidateAccountWithScheme(AccountDto accountDto, decimal amount);
    }
}
