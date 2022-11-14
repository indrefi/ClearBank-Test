using AutoMapper;
using ClearBank.Application.Interfaces;
using ClearBank.Application.UseCases.Payment.Commnads.MakePayment;
using System.Threading;
using System.Threading.Tasks;

namespace ClearBank.Application.UseCases.Payment.Commands.MakePayment
{
    public class MakePaymentCommandHandler : IMakePaymentCommandHandler
    {
        private readonly IClearBankDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IPaymentService _paymentService;

        public MakePaymentCommandHandler(IClearBankDbContext dbContext, IMapper mapper, IPaymentService paymentService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _paymentService = paymentService;
        }

        public Task<MakePaymentResult> Handle(MakePaymentCommand request, CancellationToken cancellationToken)
        {
            var paymentResult = _paymentService.MakePayment(new MakePaymentRequest 
            {
                Amount = request.Amount,
                CreditorAccountNumber = request.CreditorAccountNumber,
                DebtorAccountNumber = request.DebtorAccountNumber,
                PaymentDate = request.PaymentDate,
                PaymentScheme = request.PaymentScheme
            });

            return Task.FromResult(paymentResult);
        }
    }
}
