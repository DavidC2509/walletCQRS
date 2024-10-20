using AutoMapper;
using Template.Domain.UserAggregate;
using Template.Services.Command.Users;
using Template.Services.Models;

namespace Template.Services.Mapper
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<StoreUserCommand, User>();
            CreateMap<User, InfoUserModel>();

        }
    }
}
