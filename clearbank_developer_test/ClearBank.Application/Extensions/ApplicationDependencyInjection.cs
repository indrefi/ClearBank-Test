using ClearBank.Application.Behaviors;
using ClearBank.Application.Interfaces;
using ClearBank.Application.Services;
using ClearBank.Application.Services.PaymentScheme;
using ClearBank.Application.UseCases.AccountCase.Commands.UpdateAccount;
using ClearBank.Application.UseCases.AccountCase.Queries.GetAccount;
using ClearBank.Application.UseCases.Payment.Commands.MakePayment;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ClearBank.Application.Extensions
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            services.AddHandlers();
            services.AddMediatRDependencies();

            return services;
        }

        private static void AddHandlers(this IServiceCollection services)
        {
            services.AddTransient<IPaymentService, PaymentService>();
            services.AddTransient<IPaymentSchemeFactory, PaymentSchemeFactory>();

            services.AddTransient<IGetAccountQueryHandler, GetAccountQueryHandler>();
            services.AddTransient<IUpdateAccountCommandHandler, UpdateAccountCommandHandler>();
            services.AddTransient<IMakePaymentCommandHandler, MakePaymentCommandHandler>();
        }

        private static void AddMediatRDependencies(this IServiceCollection services)
        {
            services.AddMediatR(typeof(IGetAccountQueryHandler), typeof(GetAccountQueryHandler));
            services.AddMediatR(typeof(IUpdateAccountCommandHandler), typeof(UpdateAccountCommandHandler));
            services.AddMediatR(typeof(IMakePaymentCommandHandler), typeof(MakePaymentCommandHandler));
        }
    }
}
