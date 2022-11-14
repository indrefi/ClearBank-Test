using System;
using System.Linq;
using System.Reflection;

namespace ClearBank.Application.Services.PaymentScheme
{
    public class PaymentSchemeFactory : IPaymentSchemeFactory
    {
        public IPaymentScheme GetPaymentSchemeInstance(string requestedValidation)
        {
            IPaymentScheme paymentScheme = null;

            paymentScheme = Assembly.GetExecutingAssembly()
                                   .GetTypes()
                                   .Where(type => typeof(IPaymentScheme).IsAssignableFrom(type) && type.IsClass && type.Name.Equals($"PaymentScheme{requestedValidation}"))
                                   .Select(type => Activator.CreateInstance(type))
                                   .Cast<IPaymentScheme>()
                                   .FirstOrDefault();

            return paymentScheme;
        }
    }
}
