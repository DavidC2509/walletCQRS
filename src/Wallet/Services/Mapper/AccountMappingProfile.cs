using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.AccountAggregate;
using Template.Domain.ClassifiersAggregate;
using Template.Domain.MovementAggregate;
using Template.Services.Command.Users;
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
