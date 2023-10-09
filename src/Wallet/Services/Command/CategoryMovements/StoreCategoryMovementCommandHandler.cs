using Core.CommandAndQueryHandler;
using Core.Domain.Repository;
using Template.Domain.AccountAggregate;
using Template.Domain.ClassifiersAggregate;

namespace Template.Services.Command.CategoryMovements
{
    public class StoreCategoryMovementCommandHandler : BaseCommandHandler<IRepository<CategoryMovement>, StoreCategoryMovementCommand, bool>
    {


        public StoreCategoryMovementCommandHandler(IRepository<CategoryMovement> repository) : base(repository)
        {
        }

        public async override Task<bool> Handle(StoreCategoryMovementCommand request, CancellationToken cancellationToken)
        {

            var categoryMovement = new CategoryMovement(request.Name);
            _repository.Add(categoryMovement);
            await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            return true;
        }
    }
}
