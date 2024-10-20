using AutoMapper;
using Template.Domain.AccountAggregate;
using Template.Domain.ClassifiersAggregate;
using Template.Domain.MovementAggregate;
using Template.Services.Models;

namespace Template.Services.Mapper
{
    public class AccountMappingProfile : Profile
    {
        public AccountMappingProfile()
        {
            CreateMap<Account, AccountModel>();
            CreateMap<CategoryAccount, ClassifierModel>();

            CreateMap<Movement, MovementModel>();

        }
    }
}
