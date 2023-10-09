using AutoMapper;
using Core.CommandAndQueryHandler;
using Core.Domain.Repository;
using Microsoft.AspNetCore.Identity;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.AccountAggregate;
using Template.Domain.UserAggregate;

namespace Template.Services.Command.Users
{
    public class StoreUserCommandHandler : BaseSimpleHandler<StoreUserCommand, IdentityResult>
    {
        private readonly UserManager<User> _userManager;

        private readonly IMapper _mapper;

        public StoreUserCommandHandler(IMapper mapper, UserManager<User> userManager) : base()
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async override Task<IdentityResult> Handle(StoreUserCommand request, CancellationToken cancellationToken)
        {

            var user = _mapper.Map<User>(request);
            user.GenerateRandomTenantId();
            user.AddCategoryDefaultEvent();
            user.AddCategoryMovementDefaultEvent();

            return await _userManager.CreateAsync(user, request.Password);
        }
    }
}
