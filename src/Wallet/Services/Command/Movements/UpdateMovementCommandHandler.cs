using Core.Cqrs.CommandAndQueryHandler;
using Core.Cqrs.Domain.Repository;
using Template.Domain.AccountAggregate;
using Template.Domain.MovementAggregate;

namespace Template.Services.Command.Movements
{
    public class UpdateMovementCommandHandler : BaseCommandHandler<IRepository<Movement>, UpdateMovementCommand, bool>
    {

        private readonly IReadRepository<Account> _repositoryAccount;

        public UpdateMovementCommandHandler(IRepository<Movement> repository, IReadRepository<Account> repositoryAccount) : base(repository)
        {
            _repositoryAccount = repositoryAccount;

        }

        public async override Task<bool> Handle(UpdateMovementCommand request, CancellationToken cancellationToken)
        {

            var movement = await _repository.GetByIdAsync(request.MovementId);
            var account = await _repositoryAccount.GetByIdAsync(movement.AccountId);

            movement.UpdateMovement(request.Amount, request.Descripcion, request.Date, account.Salary);

            _repository.Update(movement);
            await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            return true;
        }
    }
}
