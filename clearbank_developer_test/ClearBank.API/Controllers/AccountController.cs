using ClearBank.Application.UseCases.AccountCase.Queries.GetAccount;
using ClearBank.Application.UseCases.Payment.Commands.MakePayment;
using ClearBank.Application.UseCases.Payment.Commnads.MakePayment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ClearBank.API.Controllers
{
    [ApiController]
    [Route("account")]
    public class AccountController : ApiControllerBase
    {
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Gets an account by account number.
        /// </summary>
        /// <returns>returns an account.</returns>
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AccountDto>> GetAccountByAccountNumber(string accountNumber) =>
            await Mediator.Send(new GetAccountQuery { AccountNumber = accountNumber } );

        /// <summary>
        /// Gets a random choise.
        /// </summary>
        /// <returns>return as AvailableChoisesDto.</returns>
        [HttpPost("/makePayment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<MakePaymentResult>> MakePayment(MakePaymentRequest makePaymentRequest) =>
            await Mediator.Send(new MakePaymentCommand 
            { 
                Amount = makePaymentRequest.Amount,
                CreditorAccountNumber = makePaymentRequest.CreditorAccountNumber,
                DebtorAccountNumber = makePaymentRequest.DebtorAccountNumber,
                PaymentDate = makePaymentRequest.PaymentDate,
                PaymentScheme = makePaymentRequest.PaymentScheme,
            });
    }
}
