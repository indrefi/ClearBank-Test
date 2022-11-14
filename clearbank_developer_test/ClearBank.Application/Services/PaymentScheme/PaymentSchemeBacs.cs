using ClearBank.Application.UseCases.AccountCase.Queries.GetAccount;
using ClearBank.Domain.Common;

namespace ClearBank.Application.Services.PaymentScheme
{
    public class PaymentSchemeBacs : IPaymentScheme
    {
        public bool ValidateAccountWithScheme(AccountDto accountDto, decimal amount)
        {
            if (!accountDto.AllowedPaymentSchemeId.HasFlag(AllowedPaymentSchemes.Bacs))
            {
                return false;
            }

            return true;
        }
    }
}
