using Core.Cqrs.CommandAndQueryHandler;
using Core.Cqrs.Domain.Repository;
using Template.Domain.ClassifiersAggregate;

namespace Template.Services.Command.CategoryMovements
{
    public class UpdateCategoryMovementCommandHandler : BaseCommandHandler<IRepository<CategoryMovement>, UpdateCategoryMovementCommand, bool>
    {


        public UpdateCategoryMovementCommandHandler(IRepository<CategoryMovement> repository) : base(repository)
        {
        }

        public async override Task<bool> Handle(UpdateCategoryMovementCommand request, CancellationToken cancellationToken)
        {

            var categoryMovement = await _repository.GetByIdAsync(request.Id);
            categoryMovement.UpdateCategoryMovement(request.Name);
            _repository.Update(categoryMovement);
            await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            return true;
        }
    }
}
