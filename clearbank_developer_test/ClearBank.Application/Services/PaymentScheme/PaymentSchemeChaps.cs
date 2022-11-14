using ClearBank.Application.UseCases.AccountCase.Queries.GetAccount;
using ClearBank.Domain.Common;
using AccountStatus = ClearBank.Domain.Common.AccountStatus;

namespace ClearBank.Application.Services.PaymentScheme
{
    public class PaymentSchemeChaps : IPaymentScheme
    {
        public bool ValidateAccountWithScheme(AccountDto accountDto, decimal amount)
        {
            if (!accountDto.AllowedPaymentSchemeId.HasFlag(AllowedPaymentSchemes.Chaps))
            {
                return false;
            }
            else if (accountDto.AccountStatusId != AccountStatus.Live)
            {
                return  false;
            }

            return true;
        }
    }
}
