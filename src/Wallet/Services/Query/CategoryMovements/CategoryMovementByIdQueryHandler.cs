using AutoMapper;
using Core.Cqrs.CommandAndQueryHandler;
using Core.Cqrs.Domain.Repository;
using Template.Domain.ClassifiersAggregate;
using Template.Services.Models;

namespace Template.Services.Query.CategoryMovements
{
    public class CategoryMovementByIdQueryHandler : BaseQueryHandler<CategoryMovement, CategoryMovementByIdQuery, ClassifierModel>
    {
        private readonly IMapper _mapper;

        public CategoryMovementByIdQueryHandler(IReadRepository<CategoryMovement> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }

        public async override Task<ClassifierModel> Handle(CategoryMovementByIdQuery request, CancellationToken cancellationToken)
        {
            var categoryAccount = await _repository.GetByIdAsync(request.Id, cancellationToken);
            var resultMapper = _mapper.Map<ClassifierModel>(categoryAccount);
            return resultMapper;
        }
    }
}