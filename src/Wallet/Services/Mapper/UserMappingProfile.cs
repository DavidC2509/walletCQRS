using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.UserAggregate;
using Template.Services.Command.Users;

namespace Template.Services.Mapper
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<StoreUserCommand, User>();
        }
    }
}
