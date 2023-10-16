using Core.Domain.Repository;
using MediatR;
using Template.Domain.AccountAggregate;
using Template.Domain.MovementAggregate;
using Template.Domain.MovementAggregate.Events;
using Template.Domain.Specification;


namespace Template.Services.HandlerEvents
{
    public class DeleteDestinyMovementEventHandler : INotificationHandler<DeleteDestinyMovementEvent>
    {
        private IReadRepository<Account> _accountRepository;

        private IRepository<Movement> _movementRepository;

        public DeleteDestinyMovementEventHandler(IReadRepository<Account> category, IRepository<Movement> movementRepository)
        {
            _accountRepository = category;
            _movementRepository = movementRepository;
        }

        public async Task Handle(DeleteDestinyMovementEvent notification, CancellationToken cancellationToken)
        {
            var spec = new AccountByIdSpec(notification.MovementTransfer.AccountDestinyId);
            var account = await _accountRepository.FirstOrDefaultAsync(spec, cancellationToken);
            var movement = await _movementRepository.GetByIdAsync(notification.MovementTransfer.MovementOriginId);
            movement.DeleteMovement(account.Salary);
            _movementRepository.Delete(movement);
            await _movementRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
