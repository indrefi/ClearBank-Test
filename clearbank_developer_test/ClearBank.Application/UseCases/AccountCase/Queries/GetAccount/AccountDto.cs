using AutoMapper;
using ClearBank.Application.Common.Mappings;
using ClearBank.Domain.Common;
using ClearBank.Domain.Entities;
using AccountStatus = ClearBank.Domain.Common.AccountStatus;

namespace ClearBank.Application.UseCases.AccountCase.Queries.GetAccount
{
    public class AccountDto : IMapFrom<Account>
    {
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public AccountStatus AccountStatusId { get; set; }
        public AllowedPaymentSchemes AllowedPaymentSchemeId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Account, AccountDto>()
                  .ForMember(d => d.AccountNumber, opt => opt.MapFrom(s => s.AccountNumber))
                  .ForMember(d => d.Balance, opt => opt.MapFrom(s => s.Balance))
                  .ForMember(d => d.AccountStatusId, opt => opt.MapFrom(s => s.AccountStatusID))
                  .ForMember(d => d.AllowedPaymentSchemeId, opt => opt.MapFrom(s => s.AccountAllowedPaymentSchemeID));

        }
    }
}
