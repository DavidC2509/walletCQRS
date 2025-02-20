using AutoMapper;
using Core.Cqrs.CommandAndQueryHandler;
using Core.Cqrs.Domain.Repository;
using Template.Domain.AccountAggregate;
using Template.Domain.AccountAggregate.Specification;
using Template.Services.Models;

namespace Template.Services.Query.AccountQuery
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