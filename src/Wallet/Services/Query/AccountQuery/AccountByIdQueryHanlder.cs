using AutoMapper;
using Core.Cqrs.CommandAndQueryHandler;
using Core.Cqrs.Domain.Repository;
using Template.Domain.AccountAggregate;
using Template.Domain.AccountAggregate.Specification;
using Template.Services.Models;

namespace Template.Services.Query.AccountQuery
{
    public class AccountByIdQueryHandler : BaseQueryHandler<Account, AccountByIdQuery, AccountModel>
    {
        private readonly IMapper _mapper;

        public AccountByIdQueryHandler(IReadRepository<Account> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }

        public async override Task<AccountModel> Handle(AccountByIdQuery request, CancellationToken cancellationToken)
        {
            var spec = new AccountByIdSpec(request.Id);
            var account = await _repository.FirstOrDefaultAsync(spec, cancellationToken);

            var resultMapper = _mapper.Map<AccountModel>(account);
            return resultMapper;
        }
    }
}