using AutoMapper;
using Core.Cqrs.CommandAndQueryHandler;
using Microsoft.AspNetCore.Identity;
using Template.Domain.Interface;
using Template.Domain.UserAggregate;
using Template.Services.Models;

namespace Template.Services.Query.Users
{
    public class InfoQueryHandler : BaseSimpleHandler<InfoQuery, InfoUserModel>
    {
        private readonly UserManager<User> _userManager;
        private readonly ICurrentUser _currentUser;
        private readonly IMapper _mapper;

        public InfoQueryHandler(UserManager<User> userManager, ICurrentUser currentUser, IMapper mapper) : base()
        {
            _userManager = userManager;
            _currentUser = currentUser;
            _mapper = mapper;
        }

        public override async Task<InfoUserModel> Handle(InfoQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(_currentUser.GetNameUser());

            var resultMapper = _mapper.Map<InfoUserModel>(user);
            return resultMapper;
        }

    }
}