using AutoMapper;
using Core.Cqrs.CommandAndQueryHandler;
using Core.Cqrs.Domain.Repository;
using Template.Domain.ClassifiersAggregate;
using Template.Services.Models;

namespace Template.Services.Query.CategoryAccounts
{
    public class CategoryAccountByIdQueryHandler : BaseQueryHandler<CategoryAccount, CategoryAccountByIdQuery, ClassifierModel>
    {
        private readonly IMapper _mapper;

        public CategoryAccountByIdQueryHandler(IReadRepository<CategoryAccount> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }

        public async override Task<ClassifierModel> Handle(CategoryAccountByIdQuery request, CancellationToken cancellationToken)
        {
            var categoryAccount = await _repository.GetByIdAsync(request.Id, cancellationToken);
            var resultMapper = _mapper.Map<ClassifierModel>(categoryAccount);
            return resultMapper;
        }
    }
}