using ClearBank.Application.UseCases.AccountCase.Queries.GetAccount;
using ClearBank.Domain.Common;

namespace ClearBank.Application.Services.PaymentScheme
{
    public class PaymentSchemeFasterPayments : IPaymentScheme
    {
        public bool ValidateAccountWithScheme(AccountDto accountDto, decimal amount)
        {

            if (!accountDto.AllowedPaymentSchemeId.HasFlag(AllowedPaymentSchemes.FasterPayments))
            {
                return false;
            }
            else if (accountDto.Balance < amount)
            {
                return false;
            }

            return true;
        }
    }
}