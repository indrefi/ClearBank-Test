using ClearBank.Domain.Common;
using System;

namespace ClearBank.Application.UseCases.Payment.Commnads.MakePayment
{
    public class MakePaymentRequest
    {
        public string CreditorAccountNumber { get; set; }

        public string DebtorAccountNumber { get; set; }

        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; }

        public AllowedPaymentSchemes PaymentScheme { get; set; }
    }
}
