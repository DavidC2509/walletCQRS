using Core.CommandAndQueryHandler;
using Core.Domain.Repository;
using Template.Domain.AccountAggregate;
using Template.Domain.MovementAggregate;

namespace Template.Services.Command.Movements
{
    public class DeleteMovemenCommandHandler : BaseCommandHandler<IRepository<Movement>, DeleteMovementCommand, bool>
    {

        private readonly IReadRepository<Account> _repositoryAccount;

        public DeleteMovemenCommandHandler(IRepository<Movement> repository, IReadRepository<Account> repositoryAccount) : base(repository)
        {
            _repositoryAccount = repositoryAccount;
        }

        public async override Task<bool> Handle(DeleteMovementCommand request, CancellationToken cancellationToken)
        {
            var movement = await _repository.GetByIdAsync(request.MovementId);
            var account = await _repositoryAccount.GetByIdAsync(movement.AccountId);
            movement.DeleteMovement(account.Salary);
            _repository.Delete(movement);
            await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            return true;
        }
    }
}
