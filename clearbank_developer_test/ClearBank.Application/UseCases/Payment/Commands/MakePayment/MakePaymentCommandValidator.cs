using FluentValidation;

namespace ClearBank.Application.UseCases.Payment.Commands.MakePayment
{
    public class MakePaymentCommandValidator : AbstractValidator<MakePaymentCommand>, IValidator
    {
        public MakePaymentCommandValidator()
        {
            RuleFor(x => x.CreditorAccountNumber).NotNull().WithMessage("Creditor Account number cannot be null or empty");
            RuleFor(x => x.DebtorAccountNumber).NotNull().WithMessage(" Debtor Account number cannot be null or empty");
            RuleFor(x => x.PaymentScheme).IsInEnum().WithMessage("Payment scheme cannot be out of range.");
            RuleFor(x => x.Amount).GreaterThanOrEqualTo(0).WithMessage("Amount cannot be negative.");
        }
    }

}
