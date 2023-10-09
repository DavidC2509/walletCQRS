using AutoMapper;
using Core.CommandAndQueryHandler;
using Core.Domain.Repository;
using Template.Domain.AccountAggregate;
using Template.Domain.Specification;
using Template.Services.Models;

namespace Template.Services.Query.Accounts
{
    public class ListAccountQueryHandler : BaseQueryHandler<Account, ListAccountQuery, IEnumerable<AccountModel>>
    {
        private readonly IMapper _mapper;

        public ListAccountQueryHandler(IReadRepository<Account> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }

        public async override Task<IEnumerable<AccountModel>> Handle(ListAccountQuery request, CancellationToken cancellationToken)
        {
            var spec = new AccountSpec();
            var list = await _repository.ListAsync(spec, cancellationToken);
            Console.WriteLine("Obtuvo listado : " + list.Count);

            var resultMapper = _mapper.Map<List<AccountModel>>(list);
            return resultMapper;
        }
    }
}