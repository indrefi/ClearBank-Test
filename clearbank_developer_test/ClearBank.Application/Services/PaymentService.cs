using ClearBank.Application.Exceptions;
using ClearBank.Application.Interfaces;
using ClearBank.Application.Services.PaymentScheme;
using ClearBank.Application.UseCases.AccountCase.Commands.UpdateAccount;
using ClearBank.Application.UseCases.AccountCase.Queries.GetAccount;
using ClearBank.Application.UseCases.Payment.Commnads.MakePayment;
using ClearBank.Domain.Common;
using System;
using System.Threading;

namespace ClearBank.Application.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IGetAccountQueryHandler _getAccountQueryHandler;
        private readonly IUpdateAccountCommandHandler _updateAccountCommandHandler;
        private readonly IPaymentSchemeFactory _paymentSchemeFactory;
        public PaymentService(IGetAccountQueryHandler getAccountQueryHandler, IUpdateAccountCommandHandler updateAccountCommandHandler, IPaymentSchemeFactory paymentSchemeFactory)
        {
            _getAccountQueryHandler = getAccountQueryHandler;
            _updateAccountCommandHandler = updateAccountCommandHandler;
            _paymentSchemeFactory = paymentSchemeFactory;
        }

        public MakePaymentResult MakePayment(MakePaymentRequest request)
        {
            var result = new MakePaymentResult { Success = true };

            // Note: since there was a requirement not to modify the signature I am forced to use .Result() and to create cancellation token
            // in order not to change the signature to async Task<T>.
            var cancellationToken = new CancellationTokenSource(new TimeSpan(0, 0, 5)).Token;
            var accountDebtor = _getAccountQueryHandler.Handle(new GetAccountQuery { AccountNumber = request.DebtorAccountNumber}, cancellationToken).Result;
            var accountCreditor = _getAccountQueryHandler.Handle(new GetAccountQuery { AccountNumber = request.CreditorAccountNumber }, cancellationToken).Result;

            if(accountCreditor == null || accountDebtor == null)
            {
                throw new NotFoundException();
            }

            var instanceName = Enum.GetName(typeof(AllowedPaymentSchemes), request.PaymentScheme).ToString();
            var paymentSchmeObject = _paymentSchemeFactory.GetPaymentSchemeInstance(instanceName);

            var paymentSchemeValidationResult = paymentSchmeObject.ValidateAccountWithScheme(accountDebtor, request.Amount);
            
            if (paymentSchemeValidationResult)
            {
                accountDebtor.Balance -= request.Amount;
                accountCreditor.Balance += request.Amount;

                cancellationToken = new CancellationTokenSource(new TimeSpan(0, 0, 5)).Token;
                var creditorResult =_updateAccountCommandHandler.Handle(new UpdateAccountCommand { AccountNumber = request.CreditorAccountNumber, Balance = accountCreditor.Balance }, cancellationToken).Result;
                
                cancellationToken = new CancellationTokenSource(new TimeSpan(0, 0, 5)).Token;
                var debtorResult = _updateAccountCommandHandler.Handle(new UpdateAccountCommand { AccountNumber = request.DebtorAccountNumber, Balance = accountDebtor.Balance }, cancellationToken).Result;
            }

            return result;
        }
    }
}
