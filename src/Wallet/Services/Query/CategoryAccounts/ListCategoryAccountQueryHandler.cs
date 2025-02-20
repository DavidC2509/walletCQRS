using AutoMapper;
using Core.Cqrs.CommandAndQueryHandler;
using Core.Cqrs.Domain.Repository;
using Template.Domain.ClassifiersAggregate;
using Template.Services.Models;

namespace Template.Services.Query.CategoryAccounts
{
    public class ListCategoryAccountQueryHandler : BaseQueryHandler<CategoryAccount, ListCategoryAccountQuery, IEnumerable<ClassifierModel>>
    {
        private readonly IMapper _mapper;

        public ListCategoryAccountQueryHandler(IReadRepository<CategoryAccount> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }

        public async override Task<IEnumerable<ClassifierModel>> Handle(ListCategoryAccountQuery request, CancellationToken cancellationToken)
        {
            var list = await _repository.ListAsync(cancellationToken);
            Console.WriteLine("Obtuvo listado : " + list.Count);

            var resultMapper = _mapper.Map<List<ClassifierModel>>(list);
            return resultMapper;
        }
    }
}