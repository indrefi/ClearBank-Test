using ClearBank.Application.Services.PaymentScheme;
using ClearBank.Application.UseCases.AccountCase.Commands.UpdateAccount;
using ClearBank.Application.UseCases.AccountCase.Queries.GetAccount;
using Moq;

namespace ClearBank.DeveloperTest.Tests.ServicesUnitTests
{
    public class PaymentServiceFixture
    {
        public Mock<IGetAccountQueryHandler> getAccountQueryHandler { get; set; }
        public Mock<IUpdateAccountCommandHandler> updateAccountCommandHandler { get; set; }
        public IPaymentSchemeFactory paymentSchemeFactory { get; set; }

        public AccountDto ValidDebitorAccountStatusLiveSchmeFasterPayments { get; private set; }
        public AccountDto ValidDebitorAccountStatusLiveSchmeBacs { get; private set; }
        public AccountDto ValidDebitorAccountStatusLiveSchmeChaps { get; private set; }
       
        public AccountDto ValidDebitorAccountStatusDisabledSchmeFasterPayments { get; private set; }
        public AccountDto ValidDebitorAccountStatusDisabledSchmeBacs { get; private set; }
        public AccountDto ValidDebitorAccountStatusDisabledSchmeChaps { get; private set; }

        public AccountDto ValidDebitorAccountStatusInboundPaymentsOnlySchmeFasterPayments { get; private set; }
        public AccountDto ValidDebitorAccountStatusInboundPaymentsOnlySchmeBacs { get; private set; }
        public AccountDto ValidDebitorAccountStatusInboundPaymentsOnlySchmeChaps { get; private set; }

        public AccountDto InValidDebitorAccount { get; private set; }
        public AccountDto InValidCreditorAccount { get; private set; }


        public PaymentServiceFixture()
        {
            paymentSchemeFactory = new PaymentSchemeFactory();
            getAccountQueryHandler = new Mock<IGetAccountQueryHandler>();
            updateAccountCommandHandler = new Mock<IUpdateAccountCommandHandler>();

            PopulateAccountDtos();
        }

        private void PopulateAccountDtos()
        {
            #region Live Status

            ValidDebitorAccountStatusLiveSchmeBacs = new AccountDto
            {
                AccountNumber = "RO06BTRL019393434",
                AccountStatusId = Domain.Common.AccountStatus.Live,
                AllowedPaymentSchemeId = Domain.Common.AllowedPaymentSchemes.Bacs,
                Balance = 100
            };

            ValidDebitorAccountStatusLiveSchmeChaps = new AccountDto
            {
                AccountNumber = "RO06BTRL019393434",
                AccountStatusId = Domain.Common.AccountStatus.Live,
                AllowedPaymentSchemeId = Domain.Common.AllowedPaymentSchemes.Chaps,
                Balance = 100
            };

            ValidDebitorAccountStatusLiveSchmeFasterPayments = new AccountDto
            {
                AccountNumber = "RO06BTRL019393434",
                AccountStatusId = Domain.Common.AccountStatus.Live,
                AllowedPaymentSchemeId = Domain.Common.AllowedPaymentSchemes.FasterPayments,
                Balance = 1
            };

            #endregion Live Status

            #region Disabled Status

            ValidDebitorAccountStatusDisabledSchmeBacs = new AccountDto
            {
                AccountNumber = "RO06BTRL019393434",
                AccountStatusId = Domain.Common.AccountStatus.Disabled,
                AllowedPaymentSchemeId = Domain.Common.AllowedPaymentSchemes.Bacs,
                Balance = 100
            };

            ValidDebitorAccountStatusDisabledSchmeChaps = new AccountDto
            {
                AccountNumber = "RO06BTRL019393434",
                AccountStatusId = Domain.Common.AccountStatus.Disabled,
                AllowedPaymentSchemeId = Domain.Common.AllowedPaymentSchemes.Chaps,
                Balance = 100
            };

            ValidDebitorAccountStatusDisabledSchmeFasterPayments = new AccountDto
            {
                AccountNumber = "RO06BTRL019393434",
                AccountStatusId = Domain.Common.AccountStatus.Disabled,
                AllowedPaymentSchemeId = Domain.Common.AllowedPaymentSchemes.FasterPayments,
                Balance = 100
            };

            #endregion Disabled Status

            #region InboundPaymentsOnly Status 

            ValidDebitorAccountStatusInboundPaymentsOnlySchmeBacs = new AccountDto
            {
                AccountNumber = "RO06BTRL019393434",
                AccountStatusId = Domain.Common.AccountStatus.InboundPaymentsOnly,
                AllowedPaymentSchemeId = Domain.Common.AllowedPaymentSchemes.Bacs,
                Balance = 100
            };

            ValidDebitorAccountStatusInboundPaymentsOnlySchmeChaps = new AccountDto
            {
                AccountNumber = "RO06BTRL019393434",
                AccountStatusId = Domain.Common.AccountStatus.InboundPaymentsOnly,
                AllowedPaymentSchemeId = Domain.Common.AllowedPaymentSchemes.Chaps,
                Balance = 100
            };

            ValidDebitorAccountStatusInboundPaymentsOnlySchmeFasterPayments = new AccountDto
            {
                AccountNumber = "RO06BTRL019393434",
                AccountStatusId = Domain.Common.AccountStatus.InboundPaymentsOnly,
                AllowedPaymentSchemeId = Domain.Common.AllowedPaymentSchemes.FasterPayments,
                Balance = 100
            };

            #endregion InboundPaymentsOnly Status

            #region Invalid Accounts

            InValidDebitorAccount = new AccountDto
            {
                AccountNumber = "RO06BTRL000000000",
                AccountStatusId = Domain.Common.AccountStatus.Disabled,
                AllowedPaymentSchemeId = Domain.Common.AllowedPaymentSchemes.Bacs,
                Balance = 100
            };

            InValidCreditorAccount = new AccountDto
            {
                AccountNumber = "RO06BTRL000000000",
                AccountStatusId = Domain.Common.AccountStatus.Disabled,
                AllowedPaymentSchemeId = Domain.Common.AllowedPaymentSchemes.Bacs,
                Balance = 100
            };

            #endregion Invalid Accounts
        }
    }
}
