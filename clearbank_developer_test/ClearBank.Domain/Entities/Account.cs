namespace ClearBank.Domain.Entities
{
    public class Account
    {
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }

        public AccountStatus AccountStatus { get; set; }
        public AllowedPaymentScheme AllowedPaymentScheme { get; set; }

        public int AccountStatusID { get; set; }
        public int AccountAllowedPaymentSchemeID { get; set; }
    }
}