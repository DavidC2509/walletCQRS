using Core.Cqrs.Domain.Repository;
using MediatR;
using Template.Domain.AccountAggregate;
using Template.Domain.AccountAggregate.Specification;
using Template.Domain.MovementAggregate;
using Template.Domain.MovementTransferAggregate.Events;

namespace Template.Services.HandlerEvents
{
    public class DeleteOriginMovementEventHandler : INotificationHandler<DeleteOriginMovementEvent>
    {
        private IReadRepository<Account> _accountRepository;
        private IRepository<Movement> _movementRepository;

        public DeleteOriginMovementEventHandler(IReadRepository<Account> category, IRepository<Movement> movementRepository)
        {
            _accountRepository = category;
            _movementRepository = movementRepository;
        }

        public async Task Handle(DeleteOriginMovementEvent notification, CancellationToken cancellationToken)
        {
            var spec = new AccountByIdSpec(notification.MovementTransfer.AccountOriginId);
            var account = await _accountRepository.FirstOrDefaultAsync(spec, cancellationToken);

            var movement = await _movementRepository.GetByIdAsync(notification.MovementTransfer.MovementOriginId);
            movement.DeleteMovement(account.Salary);
            movement.DeleteMovementDestiny(notification.MovementTransfer);
            _movementRepository.Delete(movement);
            await _movementRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
