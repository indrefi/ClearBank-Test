using FluentValidation;

namespace ClearBank.Application.UseCases.AccountCase.Commands.UpdateAccount
{
    public class UpdateAccountCommandValidator : AbstractValidator<UpdateAccountCommand>, IValidator
    {
        public UpdateAccountCommandValidator()
        {
            RuleFor(x => x.AccountNumber).NotNull().WithMessage("Account number cannot be null or empty.");
            RuleFor(x => x.Balance).GreaterThanOrEqualTo(0).WithMessage("Balance has to be equal or greater than 0.");
        }
    }
}