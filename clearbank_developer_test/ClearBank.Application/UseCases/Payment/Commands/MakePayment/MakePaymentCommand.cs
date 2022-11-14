using ClearBank.Application.UseCases.Payment.Commnads.MakePayment;
using ClearBank.Domain.Common;
using MediatR;
using System;

namespace ClearBank.Application.UseCases.Payment.Commands.MakePayment
{
    public class MakePaymentCommand : IRequest<MakePaymentResult>
    {
        public string CreditorAccountNumber { get; set; }

        public string DebtorAccountNumber { get; set; }

        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; }

        public AllowedPaymentSchemes PaymentScheme { get; set; }
    }
}
