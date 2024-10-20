using Core.Cqrs.CommandAndQueryHandler;
using Core.Cqrs.Domain.Repository;
using Template.Domain.AccountAggregate;
using Template.Domain.ClassifiersAggregate;
using Template.Domain.MovementAggregate;

namespace Template.Services.Command.Movements
{
    public class StoreMovementCommandHandler : BaseCommandHandler<IRepository<Movement>, StoreMovementCommand, bool>
    {

        private readonly IReadRepository<CategoryMovement> _categoryRepository;
        private readonly IReadRepository<Account> _repositoryAccount;

        public StoreMovementCommandHandler(IRepository<Movement> repository
        , IReadRepository<CategoryMovement> categoryRepository, IReadRepository<Account> repositoryAccount) : base(repository)
        {
            _categoryRepository = categoryRepository;
            _repositoryAccount = repositoryAccount;

        }

        public async override Task<bool> Handle(StoreMovementCommand request, CancellationToken cancellationToken)
        {

            var categoryMovement = await _categoryRepository.GetByIdAsync(request.CategoryMovementId, cancellationToken);
            var account = await _repositoryAccount.GetByIdAsync(request.AccountId);
            var movement = Movement.AddMovement(categoryMovement, request.TypeMovement, request.Amount,
            request.Descripcion, request.Date, request.AccountId, account.Salary);
            _repository.Add(movement);
            await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            return true;
        }
    }
}
