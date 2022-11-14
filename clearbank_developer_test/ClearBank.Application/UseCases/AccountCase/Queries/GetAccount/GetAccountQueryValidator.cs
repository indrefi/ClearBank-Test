using FluentValidation;

namespace ClearBank.Application.UseCases.AccountCase.Queries.GetAccount
{
    public class GetAccountQueryValidator : AbstractValidator<GetAccountQuery>, IValidator
    {
        public GetAccountQueryValidator()
        {
            RuleFor(x => x.AccountNumber).NotNull().WithMessage("Account number cannot be null or empty");
        }
    }
}
