using AutoMapper;
using Core.Cqrs.CommandAndQueryHandler;
using Microsoft.AspNetCore.Identity;
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
