using ClearBank.DeveloperTest.Tests.ServicesUnitTests;
using System.Threading.Tasks;
using System.Threading;
using Xunit;
using System;
using ClearBank.Application.UseCases.AccountCase.Queries.GetAccount;
using Moq;
using ClearBank.Application.UseCases.AccountCase.Commands.UpdateAccount;
using ClearBank.Application.Services;
using ClearBank.Application.UseCases.Payment.Commnads.MakePayment;
using ClearBank.Application.Exceptions;

namespace ClearBank.DeveloperTest.Tests.ServiceTests
{
    public class PaymentServiceUnitTests : IClassFixture<PaymentServiceFixture>
    {
        private readonly PaymentServiceFixture _fixture;

        public PaymentServiceUnitTests(PaymentServiceFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void MakePayment_ValidAccount_StatusLive_SchemaBacs_ExpectTrue()
        {
            var creditor = _fixture.ValidDebitorAccountStatusLiveSchmeChaps;
            var debitor = _fixture.ValidDebitorAccountStatusLiveSchmeBacs;

            _fixture.getAccountQueryHandler.Setup(x => 
                x.Handle(It.Is<GetAccountQuery>(q => q.AccountNumber == creditor.AccountNumber), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(creditor));
            _fixture.getAccountQueryHandler.Setup(x =>
                x.Handle(It.Is<GetAccountQuery>(q => q.AccountNumber == debitor.AccountNumber), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(debitor));
            _fixture.updateAccountCommandHandler
                .Setup( x => x.Handle(It.IsAny<UpdateAccountCommand>(),It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new UpdateAccountResponse()));
            var paymentRequest = new MakePaymentRequest
            {
                Amount = 50,
                DebtorAccountNumber = debitor.AccountNumber,
                CreditorAccountNumber = creditor.AccountNumber,
                PaymentDate = DateTime.UtcNow,
                PaymentScheme = Domain.Common.AllowedPaymentSchemes.Bacs
            };

            var sut = new PaymentService(_fixture.getAccountQueryHandler.Object, _fixture.updateAccountCommandHandler.Object, _fixture.paymentSchemeFactory);
            var result = sut.MakePayment(paymentRequest);

            Assert.True(result.Success);
        }

        [Fact]
        public void MakePayment_ValidAccount_StatusDisabled_SchemaChaps_ExpectTrue()
        {
            var creditor = _fixture.ValidDebitorAccountStatusLiveSchmeChaps;
            var debitor = _fixture.ValidDebitorAccountStatusDisabledSchmeChaps;

            _fixture.getAccountQueryHandler.Setup(x =>
                x.Handle(It.Is<GetAccountQuery>(q => q.AccountNumber == creditor.AccountNumber), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(creditor));
            _fixture.getAccountQueryHandler.Setup(x =>
                x.Handle(It.Is<GetAccountQuery>(q => q.AccountNumber == debitor.AccountNumber), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(debitor));
            _fixture.updateAccountCommandHandler
                .Setup(x => x.Handle(It.IsAny<UpdateAccountCommand>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new UpdateAccountResponse()));
            var paymentRequest = new MakePaymentRequest
            {
                Amount = 50,
                DebtorAccountNumber = debitor.AccountNumber,
                CreditorAccountNumber = creditor.AccountNumber,
                PaymentDate = DateTime.UtcNow,
                PaymentScheme = Domain.Common.AllowedPaymentSchemes.Bacs
            };

            var sut = new PaymentService(_fixture.getAccountQueryHandler.Object, _fixture.updateAccountCommandHandler.Object, _fixture.paymentSchemeFactory);
            var result = sut.MakePayment(paymentRequest);

            Assert.True(result.Success);
        }

        [Fact]
        public void MakePayment_ValidAccount_StatusLive_SchemaFasterPayments_ExpectTrue()
        {
            var creditor = _fixture.ValidDebitorAccountStatusLiveSchmeChaps;
            var debitor = _fixture.ValidDebitorAccountStatusLiveSchmeFasterPayments;

            _fixture.getAccountQueryHandler.Setup(x =>
                x.Handle(It.Is<GetAccountQuery>(q => q.AccountNumber == creditor.AccountNumber), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(creditor));
            _fixture.getAccountQueryHandler.Setup(x =>
                x.Handle(It.Is<GetAccountQuery>(q => q.AccountNumber == debitor.AccountNumber), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(debitor));
            _fixture.updateAccountCommandHandler
                .Setup(x => x.Handle(It.IsAny<UpdateAccountCommand>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new UpdateAccountResponse()));
            var paymentRequest = new MakePaymentRequest
            {
                Amount = 5000,
                DebtorAccountNumber = debitor.AccountNumber,
                CreditorAccountNumber = creditor.AccountNumber,
                PaymentDate = DateTime.UtcNow,
                PaymentScheme = Domain.Common.AllowedPaymentSchemes.Bacs
            };

            var sut = new PaymentService(_fixture.getAccountQueryHandler.Object, _fixture.updateAccountCommandHandler.Object, _fixture.paymentSchemeFactory);
            var result = sut.MakePayment(paymentRequest);

            Assert.True(result.Success);
        }

        [Fact]
        public void MakePayment_InValidAccount_StatusLive_SchemaFasterPayments_Expect404Exception()
        {
            var creditor = _fixture.ValidDebitorAccountStatusLiveSchmeChaps;
            var debitor = _fixture.InValidDebitorAccount;

            _fixture.getAccountQueryHandler.Setup(x =>
                x.Handle(It.Is<GetAccountQuery>(q => q.AccountNumber == creditor.AccountNumber), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(creditor));
            
            _fixture.updateAccountCommandHandler
                .Setup(x => x.Handle(It.IsAny<UpdateAccountCommand>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new UpdateAccountResponse()));
            var paymentRequest = new MakePaymentRequest
            {
                Amount = 5000,
                DebtorAccountNumber = debitor.AccountNumber,
                CreditorAccountNumber = creditor.AccountNumber,
                PaymentDate = DateTime.UtcNow,
                PaymentScheme = Domain.Common.AllowedPaymentSchemes.Bacs
            };

            var sut = new PaymentService(_fixture.getAccountQueryHandler.Object, _fixture.updateAccountCommandHandler.Object, _fixture.paymentSchemeFactory);

            Assert.Throws<NotFoundException>(() => sut.MakePayment(paymentRequest));
        }

    }
}